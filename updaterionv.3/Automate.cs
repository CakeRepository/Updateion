using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUApiLib;

namespace updaterionv._3
{
    class Automate
    {
        void diWorker(bool driverCheckBox, bool softwareCheckBox, string username, string password)
        {
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
                downloader.Download();
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
    }
}
