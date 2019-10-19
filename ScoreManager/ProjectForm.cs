using ScoreManager.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager
{
    public partial class ProjectForm : Form
    {
        public Project ReturnValue;
        private readonly bool AddMode;
        public ProjectForm()
        {
            InitializeComponent();
            ResourceController.ApplySource(this);
            AddMode = true;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public ProjectForm(Project project)
        {
            InitializeComponent();
            ResourceController.ApplySource(this);
            AddMode = false;
            ReturnValue = project;

            fileBox.Enabled = false;
            fileBox.Text = project.Path;
            fileButton.Enabled = false;
            nameBox.Text = project.Name;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            ComponentResourceManager res = new ComponentResourceManager(typeof(ProjectForm));

            SaveFileDialog dialog = new SaveFileDialog
            {
                AddExtension = true,
                Filter = res.GetString("smp") + "(*.smp)|*.smp"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileBox.Text = dialog.FileName;
            }
            dialog.Dispose();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            ComponentResourceManager res = new ComponentResourceManager(typeof(ProjectForm));
            if (nameBox.Text == null || nameBox.Text == "")
            {
                errorProvider.SetError(nameLabel, res.GetString("error.NameEmpty"));
                SystemSounds.Beep.Play();
                nameBox.Focus();
                return;
            }
            if (fileBox.Text == null || fileBox.Text == "")
            {
                errorProvider.SetError(fileLabel, res.GetString("error.FileEmpty"));
                SystemSounds.Beep.Play();
                fileBox.Focus();
                return;
            }
            if (((AddMode && securityPanel.Visible) || (ReturnValue != null && ReturnValue.Encryted)) && passwordBox.Text == "")
            {
                MessageBox.Show(res.GetString("error.EmptyPassword"), res.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordBox.Focus();
                return;
            }

            if(Settings.Default.RecentFolders == null)
            {
                Settings.Default.RecentFolders = new System.Collections.Specialized.StringCollection();
            }
            if (!Settings.Default.RecentFolders.Contains(fileBox.Text))
            {
                Settings.Default.RecentFolders.Add(fileBox.Text);
                Settings.Default.Save();
            }

            DialogResult = DialogResult.OK;
            if (AddMode)
            {
                if (securityPanel.Visible)
                    ReturnValue = new Project(fileBox.Text, nameBox.Text, passwordBox.Text);
                else
                    ReturnValue = new Project(fileBox.Text, nameBox.Text);
            }
            else
            {
                ReturnValue.Name = nameBox.Text;
                if (passwordBox.Text != "")
                {
                    ReturnValue.Encrypt(passwordBox.Text);
                }
            }
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.RecentFolders != null)
                foreach (string iterator in Settings.Default.RecentFolders)
                {
                    fileBox.Items.Add(iterator);
                }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            if (nameBox.Text != "" && errorProvider.GetError(nameBox) != null)
            {
                errorProvider.Clear();
            }
        }

        private void FileBox_TextChanged(object sender, EventArgs e)
        {
            if (fileBox.Text != "" && errorProvider.GetError(fileBox) != null)
            {
                errorProvider.Clear();
            }
        }

        private void scurityButton_Click(object sender, EventArgs e)
        {
            void switchPanel()
            {
                securityPanel.Visible = !securityPanel.Visible;
                Timer timer = new Timer
                {
                    Interval = 10
                };
                securityButton.Enabled = false;
                if (securityPanel.Visible)
                {
                    int oldHeight = Height;
                    int oldY = confirm.Location.Y;
                    timer.Tick += (s, ea) =>
                    {
                        Height += 5;
                        int y = Height - oldHeight + oldY;
                        confirm.Location = new Point(confirm.Location.X, y);
                        cancel.Location = new Point(cancel.Location.X, y);
                        securityButton.Location = new Point(securityButton.Location.X, y);
                        if (Height - oldHeight >= securityPanel.Height)
                        {
                            timer.Stop();
                            timer.Dispose();
                            securityButton.Enabled = true;
                            Height = oldHeight + securityPanel.Height;
                        }
                    };
                }
                else
                {
                    int oldHeight = Height;
                    int oldY = confirm.Location.Y;
                    timer.Tick += (s, ea) =>
                    {
                        Height -= 5;
                        int y = Height - oldHeight + oldY;
                        confirm.Location = new Point(confirm.Location.X, y);
                        cancel.Location = new Point(cancel.Location.X, y);
                        securityButton.Location = new Point(securityButton.Location.X, y);
                        if (oldHeight - Height >= securityPanel.Height)
                        {
                            timer.Stop();
                            timer.Dispose();
                            securityButton.Enabled = true;
                            Height = oldHeight - securityPanel.Height;
                        }
                    };
                }

                timer.Enabled = true;
                timer.Start();
            }
            if (AddMode)
            {
                switchPanel();
            }
            else
            {
                if (!securityPanel.Visible && ReturnValue.Encryted)
                {
                    ComponentResourceManager res = new ComponentResourceManager(typeof(ProjectForm));
                    EditValue edit = new EditValue(res.GetString("password"), true);
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        if (ReturnValue.MatchPassword(edit.ValueReturn))
                        {
                            switchPanel();
                        }
                        else
                        {
                            MessageBox.Show(res.GetString("error.Password"), res.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    edit.Dispose();
                }
                else
                {
                    switchPanel();
                }
            }
        }
    }
}
