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
using static ScoreManager.Statics.Project;

namespace ScoreManager
{
    public partial class ProjectForm : Form
    {
        public Project ReturnValue;
        private List<DailyAdmin> dailyAdmins = new List<DailyAdmin>();
        private readonly bool AddMode;
        public ProjectForm()
        {
            InitializeComponent();
            ResourceController.ApplySource(this);
            Height = 200;
            AddMode = true;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public ProjectForm(Project project)
        {
            InitializeComponent();
            ResourceController.ApplySource(this);
            Height = 200;
            AddMode = false;
            ReturnValue = project;

            fileBox.Enabled = false;
            fileBox.Text = project.Path;
            fileButton.Enabled = false;
            nameBox.Text = project.Name;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            if (project.Encryted)
                dailyAdmins.AddRange(project.DailyAdmins);
            UpdateSelections(null, null);
            DrawAdmins();
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
            if (((AddMode && securityPanel.Visible) || (!AddMode && !ReturnValue.Encryted)) && passwordBox.Text == "")
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
                {
                    ReturnValue = new Project(fileBox.Text, nameBox.Text, passwordBox.Text);
                    SyncWorkdaySelections();
                    ReturnValue.DailyAdmins.AddRange(dailyAdmins);
                }
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
                if (ReturnValue.Encryted)
                {
                    SyncWorkdaySelections();
                    ReturnValue.DailyAdmins = dailyAdmins;
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
            listView1.ItemSelectionChanged += UpdateSelections;
        }

        private void SyncWorkdaySelections()
        {
            if (listView1.Tag != null)
            {
                CheckBox[] selections = new CheckBox[7] { sun, mon, tue, wed, thur, fri, sat };
                DailyAdmin lastSelect = (DailyAdmin)listView1.Tag;

                for (int i = 0; i < selections.Length; i++)
                {
                    CheckBox checkBox = selections[i];
                    if (checkBox.Checked && !lastSelect.WorkingDays.Contains((DayOfWeek)i))
                    {
                        lastSelect.WorkingDays.Add((DayOfWeek)i);
                    }
                    else if (!checkBox.Checked && lastSelect.WorkingDays.Contains((DayOfWeek)i))
                    {
                        lastSelect.WorkingDays.Remove((DayOfWeek)i);
                    }
                }

                listView1.Tag = null;
            }
        }
        private void UpdateSelections(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            CheckBox[] selections = new CheckBox[7] { sun, mon, tue, wed, thur, fri, sat };
            ComponentResourceManager res = new ComponentResourceManager(typeof(ProjectForm));

            listView1.ContextMenu = new ContextMenu();
            if (listView1.SelectedItems.Count == 1)
            {
                
                SyncWorkdaySelections();
                foreach (CheckBox checkBox in selections)
                {
                    checkBox.Checked = false;
                    checkBox.Enabled = true;
                }
                DailyAdmin modify = dailyAdmins.Find((it) => it.Name == listView1.SelectedItems[0].Text);
                listView1.Tag = modify;

                modify.WorkingDays.ForEach((day) =>
                {
                    selections[(int)day].Checked = true;
                });

                listView1.ContextMenu.MenuItems.Add(res.GetString("properities"),
                    (s, ea) =>
                    {
                        DailyAdminForm form = new DailyAdminForm(modify);
                        form.ShowDialog();
                        form.Dispose();
                    }
                );
            }
            else
            {
                SyncWorkdaySelections();
                foreach (CheckBox checkBox in selections)
                {
                    checkBox.Enabled = false;
                }
            }
            listView1.ContextMenu.MenuItems.Add(res.GetString("remove"),
                    (s, ea) =>
                    {
                        ListView.SelectedListViewItemCollection selected = listView1.SelectedItems;
                        foreach (ListViewItem item in selected)
                        {
                            listView1.Items.Remove(item);
                            dailyAdmins.RemoveAll((it) => it.Name == item.Text);
                        }
                    }
                );
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
                    Interval = 5
                };
                securityButton.Enabled = false;
                if (securityPanel.Visible)
                {
                    int oldHeight = Height;
                    int oldY = confirm.Location.Y;
                    timer.Tick += (s, ea) =>
                    {
                        Height += 10;
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
                        Height -= 10;
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
                        if (ReturnValue.MatchPassword(edit.ValueReturn).Permission == Permission.ChiefAdmin)
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

        private void addAdmin_Click(object sender, EventArgs e)
        {
            DailyAdminForm form = new DailyAdminForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (dailyAdmins.Exists((it) => it.Name == form.ValueReturn.Name))
                {
                    ComponentResourceManager res = new ComponentResourceManager(typeof(ProjectForm));
                    MessageBox.Show(res.GetString("error.DualAdmin"), res.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dailyAdmins.Add(form.ValueReturn);
                    DrawAdmins();
                }
            }
            form.Dispose();
        }

        private void DrawAdmins()
        {
            listView1.BeginUpdate();

            listView1.Items.Clear();
            dailyAdmins.ForEach((it) =>
            {
                listView1.Items.Add(it.Name);
            });

            listView1.EndUpdate();
        }
    }
}
