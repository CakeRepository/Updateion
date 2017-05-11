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
            string pathEnd = @"c:\temp\endauto.ps1";
            if (!File.Exists(path))
            {
                char c = '"';
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("reg add " + c + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + " /v AutoAdminLogon /t REG_SZ /d 0 /f");
                    sw.WriteLine("reg add " + c + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + " /v DefaultUserName /t REG_SZ /d "+username+" /f");
                    sw.WriteLine("reg add "+c+"HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon"+c+" /v DefaultPassword /t REG_SZ /d "+password+" /f");
                    sw.WriteLine("Timeout 10");
                }
            }
            if (!File.Exists(pathEnd))
            {
                char c = '"';
                // Create a file to write to.
                using (StreamWriter dw = File.CreateText(pathEnd))
                {
                    dw.WriteLine("$RegPath = " + c + "HKLM:\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + c + "  ");
                    dw.WriteLine("Set-ItemProperty $RegPath " + c + "AutoAdminLogon" + c + " -Value " + c + "0" + c + " -type String  ");
                    dw.WriteLine("Set-ItemProperty $RegPath " + c + "DefaultUsername" + c + " -Value " + c + " " + c + " -type String  ");
                    dw.WriteLine("Set-ItemProperty $RegPath " + c + "DefaultPassword" + c + " -Value " + c + " " + c + " -type String");
                }
            }
            
        }
        
    }
}
