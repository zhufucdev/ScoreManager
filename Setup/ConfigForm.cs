using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup
{
    public partial class ConfigForm : Form
    {
        public const string DEFAULT_INSTALL_LOCATION = @"C:\Program Files\ScoreManager";

        private string _location = DEFAULT_INSTALL_LOCATION;
        public string TargetLocation
        {
            get => _location;
            private set
            {
                _location = value;
                textLocation.Text = value;
                labelOverwrite.Visible = Directory.Exists(value);
            }
        }

        public bool CreateDesktopShortcut
        {
            get => checkDesktopIcon.Checked;
        }
        public ConfigForm()
        {
            InitializeComponent();
            TargetLocation = _location;
            DialogResult = DialogResult.Cancel;
            EnsureSafe(_location);
        }
        private void buttonLocation_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var target = folderBrowserDialog.SelectedPath;
                EnsureSafe(target);

                TargetLocation = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Ensure existing isn't other App.
        /// </summary>
        /// <param name="target">Installation location to be tested.</param>
        private void EnsureSafe(string target)
        {
            var durable = true;
            if (Directory.Exists(target)
                && Directory.GetFiles(target).Length > 0
                && Directory.GetDirectories(target).Length > 0)
            {
                var registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + Program.APPLICATION_ID);
                var installation = registryKey?.GetValue("InstallLocation")?.ToString();
                if (installation == null || target != installation)
                {
                    durable = false;
                }
            }
            buttonInstall.Enabled = durable;
        }
    }
}
