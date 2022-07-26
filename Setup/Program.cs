using Setup.Properties;
using System.IO.Compression;
using System.Security.Principal;
using Application = System.Windows.Forms.Application;
using Setup;
using System.Diagnostics;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal class Program
{
    public const string APPLICATION_NAME = "ScoreManager.exe",
            APPLICATION_LNK = "ScoreManager.lnk",
            UNINSTALLER_NAME = "Uninstall.exe",
            APPLICATION_ID = "{578CC202-76BC-4CDA-AB3F-A84E3B204802}";

    [STAThread]
    private static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (!IsAdmin())
        {
            if (!RequestPrivilege())
            {
                MessageBox.Show("未能获得管理员权限。", "无法安装", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }
        var configDialog = new ConfigForm();

        if (configDialog.ShowDialog() == DialogResult.Cancel)
        {
            return;
        }

        try
        {
            using var stream = new MemoryStream(Resources.Package);
            using var zip = new ZipArchive(stream!);
            zip.ExtractToDirectory(configDialog.TargetLocation);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            _ = MessageBox.Show(string.Format("由于{0}, 解包失败。", e.Message), "安装未完成", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            SetAssociation(".smp", "smproject", "计分管理器项目文件");
        }
        catch (Exception e)
        {
            Debug.Write(e.Message);
            _ = MessageBox.Show(string.Format("由于{0}，创建失败。", e.Message), "未创建文件关联", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        try
        {
            RegisterApp("scoremanager.exe");
        }
        catch (Exception e)
        {
            Debug.Write(e.Message);
            _ = MessageBox.Show(string.Format("由于{0}，创建注册表失败。", e.Message), "未注册应用", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        if (configDialog.CreateDesktopShortcut)
        {
            try
            {
                var shortcut = GetShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), APPLICATION_LNK));
                shortcut.Save();

                shortcut = GetShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), APPLICATION_LNK));
                shortcut.Save();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(string.Format("由于{0}，创建失败。", e.Message), "未创建快捷方式", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        MessageBox.Show("安装已完成。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);


        bool IsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(identity);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        bool RequestPrivilege()
        {
            if (!IsAdmin())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };
                Application.Exit();
                try
                {
                    Process.Start(startInfo);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        WshShortcut GetShortcut(string placeIn)
        {
            var shell = new WshShell();
            var shortcut = shell.CreateShortcut(placeIn)
                    as WshShortcut;
            shortcut.TargetPath = Path.Combine(configDialog.TargetLocation, APPLICATION_NAME);
            shortcut!.Arguments = "";
            shortcut.Description = "启动计分管理器";
            shortcut.WindowStyle = 1;
            shortcut.WorkingDirectory = configDialog.TargetLocation;
            return shortcut;
        }

        void SetAssociation(string Extension, string KeyName, string FileDescription)
        {
            RegistryKey BaseKey;
            RegistryKey OpenMethod;
            RegistryKey Shell;
            string OpenWith = Path.Combine(configDialog.TargetLocation, APPLICATION_NAME);


            BaseKey = Registry.ClassesRoot.CreateSubKey(Extension);
            BaseKey.SetValue("", KeyName);

            OpenMethod = Registry.ClassesRoot.CreateSubKey(KeyName);
            OpenMethod.SetValue("", FileDescription);
            OpenMethod.CreateSubKey("DefaultIcon").SetValue("", "\"" + OpenWith + "\",0");
            Shell = OpenMethod.CreateSubKey("Shell");
            Shell.CreateSubKey("open").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
            BaseKey.Close();
            OpenMethod.Close();
            Shell.Close();

            // Tell explorer the file association has been changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        void RegisterApp(string keyName)
        {
            string appPath = Path.Combine(configDialog.TargetLocation, APPLICATION_NAME);
            string uninstallPath = Path.Combine(configDialog.TargetLocation, UNINSTALLER_NAME);

            var baseKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\", true);
            var pathKey = baseKey!.CreateSubKey(@"App Paths\" + keyName);
            var uninstallKey = baseKey.CreateSubKey(@"Uninstall\" + APPLICATION_ID);

            pathKey.SetValue("", appPath);
            var date = DateTime.Now;
            var uninstallForm = new Dictionary<string, object>
            {
                { "DisplayName" , "ScoreManager" },
                { "DisplayIcon", appPath },
                { "DisplayVersion", "1.1.1" },
                { "EstimatedSize", 4322 },
                { "InstallDate", date.ToString("yyyyMMdd") },
                { "InstallLocation", configDialog.TargetLocation },
                { "ModifyPath", uninstallPath },
                { "NoRepair", 1 },
                { "Publisher", "zhufucdev" },
                { "UninstallString", uninstallPath }
            };
            foreach (var entry in uninstallForm)
            {
                uninstallKey.SetValue(entry.Key, entry.Value);
            }
        }
    }
}