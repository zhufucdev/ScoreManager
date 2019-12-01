using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace ScoreManager
{
    public static class Utility
    {
        public static ComponentResourceManager ApplySource(ContainerControl form)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            ComponentResourceManager res = new ComponentResourceManager(form.GetType());
            System.Reflection.FieldInfo[] fieldInfo = form.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            form.SuspendLayout();
            foreach(System.Reflection.FieldInfo info in fieldInfo)
            {
                object control = info.GetValue(form);
                if (control != null)
                    res.ApplyResources(control, info.Name);
            }
            form.ResumeLayout();
            res.ApplyResources(form, "this");
            return res;
        }

        static bool requestPrivilege()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            bool isAdmin()
            {
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            };

            if (!isAdmin())
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                startInfo.Verb = "runas";
                Application.Exit();
                System.Diagnostics.Process.Start(startInfo);
            }
            return isAdmin();
        }

        
        public static bool StartWithSystem
        {
            set
            {
                if (!requestPrivilege())
                {
                    return;
                }
                RegistryKey machine = Registry.CurrentUser;
                RegistryKey run = machine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (value)
                {
                    run.SetValue("ScoreManger", Application.ExecutablePath + " -open-last");
                }
                else
                {
                    run.DeleteValue("ScoreManger", false);
                }
                run.Close();
                machine.Close();
            }
            get
            {
                requestPrivilege();
                RegistryKey machine = Registry.CurrentUser;
                RegistryKey run = machine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                bool result = run.OpenSubKey("ScoreManager") != null;
                run.Close();
                machine.Close();
                return result;
            }
        }

        public static void SetAssociation(string Extension, string KeyName, string FileDescription)
        {
            if (!requestPrivilege())
            {
                return;
            }

            RegistryKey BaseKey;
            RegistryKey OpenMethod;
            RegistryKey Shell;
            RegistryKey CurrentUser;
            string OpenWith = Application.ExecutablePath;


            BaseKey = Registry.ClassesRoot.CreateSubKey(Extension);
            BaseKey.SetValue("", KeyName);

            OpenMethod = Registry.ClassesRoot.CreateSubKey(KeyName);
            OpenMethod.SetValue("", FileDescription);
            OpenMethod.CreateSubKey("DefaultIcon").SetValue("", "\"" + OpenWith + "\",0");
            Shell = OpenMethod.CreateSubKey("Shell");
            Shell.CreateSubKey("edit").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
            Shell.CreateSubKey("open").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
            BaseKey.Close();
            OpenMethod.Close();
            Shell.Close();

            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        public static int ShowInputPanel()
        {
            try
            {
                dynamic file = "C:\\Program Files\\Common Files\\microsoft shared\\ink\\TabTip.exe";
                if (!System.IO.File.Exists(file))
                    return -1;
                Process.Start(file);
                return 1;
            }
            catch (Exception)
            {
                return 255;
            }
        }


        private const Int32 WM_SYSCOMMAND = 274;
        private const UInt32 SC_CLOSE = 61536;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //隐藏屏幕键盘
        public static void HideInputPanel()
        {
            IntPtr TouchhWnd = new IntPtr(0);
            TouchhWnd = FindWindow("IPTip_Main_Window", null);
            if (TouchhWnd == IntPtr.Zero)
                return;
            PostMessage(TouchhWnd, WM_SYSCOMMAND, SC_CLOSE, 0);
        }
    }
}
