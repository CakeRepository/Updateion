using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
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
        private void MethodToUpdateControl()
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
        static ISearchResult dResult;
        static ISearchResult uResult;
        void scanWorker()
        {
            
            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            ///Checks if Driver box is checked and updates list for updates in "Drivers"
            if (driverCheckBox.Checked)
            {
                dResult = uSearcher.Search("IsInstalled=0 and Type='Driver'");
                foreach (IUpdate update in dResult.Updates)
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
                uResult = uSearcher.Search("IsInstalled=0 and Type='Software'");
                Console.WriteLine(uResult.Updates.Count);
                foreach (IUpdate update in uResult.Updates)
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
                downloader.Updates = uResult.Updates;
                downloader.Download();
                foreach (IUpdate update in uResult.Updates)
                {
                    if (update.IsDownloaded)
                        updatesToInstall.Add(update);
                }
            }
            if (driverCheckBox.Checked)
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

        private void automateButton_Click(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            bool dcheckbox = false;
            bool scheckbox = false;
            bool valid = false;
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
            else
            {
                disableBox();
            }
        }
        /// <summary>
        /// Disables all boxes on Form1 if items are added they will need to be added here to disable
        /// </summary>
        public void disableBox()
        {
            this.automateButton.Enabled = false;
            this.scanButton.Enabled = false;
            this.dibutton.Enabled = false;
            this.driverCheckBox.Enabled = false;
            this.softwareCheckBox.Enabled = false;
            this.clearButton.Enabled = false;
            this.passwordTextBox.Enabled = false;
        }
    }
}
