using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        int scanCounter = 0;
        public List<string> MyList { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        void scanWorker()
        {
            
            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            ///Checks if Driver box is checked and updates list for updates in "Drivers"
            if (driverCheckBox.Checked)
            {
                ISearchResult dResult = uSearcher.Search("IsInstalled=0 and Type='Driver'");
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
                ISearchResult uResult = uSearcher.Search("IsInstalled=0 and Type='Software'");
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
            ISearchResult uResult = uSearcher.Search("IsInstalled=0 and Type='Software'");

            UpdateDownloader downloader = uSession.CreateUpdateDownloader();
            downloader.Updates = uResult.Updates;
            downloader.Download();
            UpdateCollection updatesToInstall = new UpdateCollection();
            foreach (IUpdate update in uResult.Updates)
            {
                if (update.IsDownloaded)
                    updatesToInstall.Add(update);
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
    }
}
