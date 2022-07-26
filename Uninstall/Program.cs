using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

const string APPLICATION_ID = "{578CC202-76BC-4CDA-AB3F-A84E3B204802}";

Application.EnableVisualStyles();

if (!IsAdmin())
{
    if (!RequestPrivilege())
    {
        MessageBox.Show("未能获得管理员权限。", "无法卸载", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    return;
}


if (!Delete())
{
    return;
}

try
{
    ClearAssociation(".smp");
}
catch(Exception e)
{
    Debug.WriteLine(e.Message);
    _ = MessageBox.Show(string.Format("由于{0}，未清除。", e.Message), "文件关联未清除", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}

try
{
    ClearUninstaller();
}
catch (Exception e)
{
    Debug.WriteLine(e.Message);
}

_ = MessageBox.Show("卸载已完成。", "完成", MessageBoxButtons.OK);

Delete(selfIncluded: true);

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

void ClearAssociation(string Extension)
{
    Registry.ClassesRoot.DeleteSubKey(Extension);
    SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
}

[DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

void ClearUninstaller()
{
    var baseKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true);
    baseKey!.DeleteSubKey(APPLICATION_ID);
}

bool Delete(bool selfIncluded = false)
{
    try
    {
        var container = Path.GetDirectoryName(Application.ExecutablePath);
        Process.Start(new ProcessStartInfo()
        {
            Arguments = "/C choice /C Y /N /D Y /T " + (selfIncluded ? 0 : 3) + "& Rd /s /q \"" + container + "\"",
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            FileName = "cmd.exe"
        });
    }
    catch (Exception e)
    {
        Debug.WriteLine(e.Message);
        _ = MessageBox.Show(string.Format("由于{0}，卸载失败。", e.Message), "卸载未完成", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
    return true;
}