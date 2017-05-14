using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace updaterionv._3
{
    class AutoLoginBuilder
    {
        public void autoLogin(string username, string password)
        {
            string path = @"c:\temp\autologin.bat";
            string pathEnd = @"c:\temp\endauto.bat";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (!File.Exists(path))
            {
                char c = '"';
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("reg add " + c + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + " /v AutoAdminLogon /t REG_SZ /d 1 /reg:64 /f");
                    sw.WriteLine("reg add " + c + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + " /v DefaultUserName /t REG_SZ /d "+username+ " /reg:64 /f");
                    sw.WriteLine("reg add "+c+"HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon"+c+" /v DefaultPassword /t REG_SZ /d "+password+ " /reg:64 /f");
                    //sw.WriteLine("Timeout 10"); debug
                }
            }
            if (File.Exists(pathEnd))
            {
                File.Delete(pathEnd);
            }
            if (!File.Exists(pathEnd))
            {
                char c = '"';
                // Create a file to write to.
                using (StreamWriter dw = File.CreateText(pathEnd))
                {
                    dw.WriteLine("reg add " + c + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + " /v AutoAdminLogon /t REG_SZ /d 0 /reg:64 /f");
                    dw.WriteLine("reg add " + c + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + " /v DefaultUserName /t REG_SZ /d " + "null" + " /reg:64 /f");
                    dw.WriteLine("reg add " + c + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + " /v DefaultPassword /t REG_SZ /d " + "null" + " /reg:64 /f");
                } 
            }
            
        }
        
    }
}
