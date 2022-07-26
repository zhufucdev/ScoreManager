using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

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
        static bool RequestPrivilege()
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
                if (!RequestPrivilege())
                {
                    return;
                }
                RegistryKey machine = Registry.CurrentUser;
                RegistryKey run = machine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (value)
                {
                    run.SetValue("ScoreManger", Application.ExecutablePath + " --open-last");
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
                RequestPrivilege();
                RegistryKey machine = Registry.CurrentUser;
                RegistryKey run = machine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                bool result = run.OpenSubKey("ScoreManager") != null;
                run.Close();
                machine.Close();
                return result;
            }
        }
    }
}
