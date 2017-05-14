using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WUApiLib;


namespace updaterionv._3
{
    public partial class Form1 : Form
    {
        string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        int scanCounter = 0;
        public List<string> MyList { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            passwordTextBox.Text = "";
            usernameTextBox.Text = username;
            passwordTextBox.PasswordChar = '*';
        }
        private void scanButton_Click(object sender, EventArgs e)
        {
            if (scanCounter == 0)
            {
                scanCounter++;
                MyList = new List<string>();
                var bw = new BackgroundWorker();
                bw.DoWork += (o, args) => scanWorker();
                bw.RunWorkerCompleted += (o, args) => MethodToUpdateControl();
                bw.RunWorkerAsync();
                
            }
            else
            {
                errorBox1.Text = "Please press clear before rescanning.";
            }
            
        }
        public void MethodToUpdateControl()
        {
            // since the BackgroundWorker is designed to use
            // the form's UI thread on the RunWorkerCompleted
            // event, you should just be able to add the items
            // to the list box:
            checkedListBox1.Items.AddRange(MyList.ToArray());

            // the above should not block the UI, if it does
            // due to some other code, then use the ListBox's
            // Invoke method:
            // listBox1.Invoke( new Action( () => listBox1.Items.AddRange( MyList.ToArray() ) ) );
        }

        /// <summary>
        /// Checks for Updates with Scan button DOES NOT INSTALL
        /// </summary>

        static ISearchResult diResult;
        static ISearchResult swResult;
        void scanWorker()
        {
            
            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            ///Checks if Driver box is checked and updates list for updates in "Drivers"
            if (driverCheckBox.Checked)
            {
                diResult = uSearcher.Search("IsInstalled=0 and Type='Driver'");
                foreach (IUpdate update in diResult.Updates)
                {
                    if (update == null)
                    {

                    }
                    else if (!MyList.Contains(update.Title))
                    {
                        MyList.Add(update.Title);
                    }
                }
            }
            ///Checks if software box is checked and updates list for updates in "Software"
            if (softwareCheckBox.Checked)
            {
                swResult = uSearcher.Search("IsInstalled=0 and Type='Software'");
                Console.WriteLine(swResult.Updates.Count);
                foreach (IUpdate update in swResult.Updates)
                {
                    if (update.ToString() == "")
                    {
                        MyList.Add("no updates found");
                    }
                    if (!MyList.Contains(update.Title))
                    {
                        MyList.Add(update.Title);
                        //checks MaxDownloadSize of update
                        //MyList.Add(update.MaxDownloadSize.ToString());
                        
                    }
                }
            }
        }

        void diWorker()
        {
            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            UpdateCollection updatesToInstall = new UpdateCollection();

            //checks if software box is checked and installed those updates
            if (softwareCheckBox.Checked)
            {
                UpdateDownloader downloader = uSession.CreateUpdateDownloader();
                downloader.Updates = swResult.Updates;
                downloader.Download();
                foreach (IUpdate update in swResult.Updates)
                {
                    if (update.IsDownloaded)
                        updatesToInstall.Add(update);
                }
            }
            if (driverCheckBox.Checked)
            {
                UpdateDownloader downloader = uSession.CreateUpdateDownloader();
                downloader.Updates = diResult.Updates;
                downloader.Download();
                foreach (IUpdate update in diResult.Updates)
                {
                    if (update.IsDownloaded)
                        updatesToInstall.Add(update);
                }

            }
            
            
            IUpdateInstaller installer = uSession.CreateUpdateInstaller();
            installer.Updates = updatesToInstall;
            IInstallationResult installationRes = installer.Install();
            for (int i = 0; i < updatesToInstall.Count; i++)
            {
                if (installationRes.GetUpdateResult(i).HResult == 0)
                {
                    Console.WriteLine("Installed : " + updatesToInstall[i].Title);
                }
                else
                {
                    //Failed update
                    Console.WriteLine("Failed : " + updatesToInstall[i].Title);
                }
            }
        }

        private void driverCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void softwareCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            scanCounter = 0;
            errorBox1.Text = "";
        }

        private void dibutton_Click(object sender, EventArgs e)
        {
            if (scanCounter == 0)
            {
                errorBox1.Text = "Please scan before Downloading\\Installing";
            }
            else
            {
                MyList = new List<string>();
                var bw = new BackgroundWorker();
                bw.DoWork += (o, args) => diWorker();
                bw.RunWorkerCompleted += (o, args) => MethodToUpdateControl();
                bw.RunWorkerAsync();
            }
            
        }

        private async void automateButton_Click(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            bool dcheckbox = false;
            bool scheckbox = false;
            bool valid = false;
            MyList = new List<string>();

            errorBox1.Text = "";
            if (driverCheckBox.Checked)
            {
                dcheckbox = true;
            }
            if (softwareCheckBox.Checked)
            {
                scheckbox = true;
            }
            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                valid = context.ValidateCredentials(username, password);
            }
            if (valid == false)
            {
                errorBox1.Text = "Incorrect Password";
            }
            else if(!driverCheckBox.Checked && !softwareCheckBox.Checked)
            {
                errorBox1.Text = "Please select updates";
            }
            else
            {
                disableBox(false);
                try
                {
                    // Run your operation asynchronously
                    
                    await Task.Factory.StartNew(() => automateWorker(dcheckbox, scheckbox, username, password),
                                                TaskCreationOptions.LongRunning);

                    MethodToUpdateControl();
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    errorBox1.Text = "completed";
                    
                }
                finally
                {
                    disableBox(true); // Re-enable everything after the above completes
                }
                
                
            }
        }
        /// <summary>
        /// Disables all boxes on Form1 if items are added they will need to be added here to disable
        /// </summary>
        public void disableBox(bool state)
        {
            this.automateButton.Enabled = state;
            this.scanButton.Enabled = state;
            this.dibutton.Enabled = state;
            this.driverCheckBox.Enabled = state;
            this.softwareCheckBox.Enabled = state;
            this.clearButton.Enabled = state;
            this.passwordTextBox.Enabled = state;
        }
        /// <summary>
        /// Automates software installs with 
        /// </summary>
        /// <param name="driverCheckBox">true = checks for driver updates, false = doest not</param>
        /// <param name="softwareCheckBox">true = checks for software updates, false = doest not</param>
        /// <param name="username">Currently logged in username</param>
        /// <param name="password"></param>
        public void automateWorker(bool driverCheckBox, bool softwareCheckBox, string username, string password)
        {
            Form1 frm1 = new Form1();
            ISearchResult dResult = null;
            ISearchResult uResult = null;
            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            UpdateCollection updatesToInstall = new UpdateCollection();

            ///Checks if Driver box is checked and updates list for updates in "Drivers"
            if (driverCheckBox == true)
            {
                dResult = uSearcher.Search("IsInstalled=0 and Type='Driver'");
                foreach (IUpdate update in dResult.Updates)
                {

                    MyList.Add(update.Title);
                    Console.WriteLine(update.Title);
                }
            }
            ///Checks if software box is checked and updates list for updates in "Software"
            if (softwareCheckBox == true)
            {
                uResult = uSearcher.Search("IsInstalled=0 and Type='Software'");
                Console.WriteLine(uResult.Updates.Count);
                foreach (IUpdate update in uResult.Updates)
                {

                    Console.WriteLine(update.Title);
                }
            }

            //checks if software box is checked and installed those updates
            if (softwareCheckBox == true)
            {
                UpdateDownloader downloader = uSession.CreateUpdateDownloader();
                downloader.Updates = uResult.Updates;
                try
                {
                    downloader.Download();
                }
                catch { }

                foreach (IUpdate update in uResult.Updates)
                {
                    if (update.IsDownloaded)
                        updatesToInstall.Add(update);
                }
            }
            if (driverCheckBox == true)
            {
                UpdateDownloader downloader = uSession.CreateUpdateDownloader();
                downloader.Updates = dResult.Updates;
                downloader.Download();
                foreach (IUpdate update in dResult.Updates)
                {
                    if (update.IsDownloaded)
                        updatesToInstall.Add(update);
                }

            }
            IUpdateInstaller installer = uSession.CreateUpdateInstaller();
            Console.WriteLine(updatesToInstall.ToString());

            //Checks if 0 updates will error on install if 0 updates
            if(updatesToInstall.Count == 0)
            {
                MyList.Add("No updates found");
            }
            //if there is updates
            else
            {
                installer.Updates = updatesToInstall;
                IInstallationResult installationRes = installer.Install();
                for (int i = 0; i < updatesToInstall.Count; i++)
                {
                    if (installationRes.GetUpdateResult(i).HResult == 0)
                    {
                        Console.WriteLine("Installed : " + updatesToInstall[i].Title);
                        if (installationRes.RebootRequired == true)
                        {
                            AutoLoginBuilder al = new AutoLoginBuilder();
                            al.autoLogin(username, password);
                            changeRegKey();
                        }
                    }
                    else
                    {
                        //Failed update
                        Console.WriteLine("Failed : " + updatesToInstall[i].Title);
                    }
                }
                if (installationRes.RebootRequired == true)
                {
                    AutoLoginBuilder al = new AutoLoginBuilder();
                    al.autoLogin(username, password);
                    changeRegKey();
                }
            }
            
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void changeRegKey()
        {
            Process proc = Process.Start(@"C:\temp\endauto.bat");
        }
    }
}
