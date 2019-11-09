using ScoreManager.Statics;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Collections.Generic;
using static ScoreManager.Statics.Project;
using ScoreManager.Properties;
using Microsoft.Win32;
using System.Drawing;
using ScoreManager.Utils;

namespace ScoreManager
{
    public partial class Form1 : Form
    {
        private readonly List<Scoreboard.Scoreboard> scoreboards = new List<Scoreboard.Scoreboard>();
        private readonly ListViewColumnSorter lviSorter = new ListViewColumnSorter();
        public Form1()
        {
            Settings.Default.Language = Settings.Default.Language ?? Thread.CurrentThread.CurrentCulture.Name;
            Icon = Resources.AppIcon;
            InitializeComponent();
            Relayout();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));

            notifyIcon.Text = res.GetString("this.Text");
            notifyIcon.Icon = Resources.AppIcon;
            notifyIcon.ContextMenu = new ContextMenu();
            notifyIcon.ContextMenu.MenuItems.Add(res.GetString("exit"), (e, a) => {
                Application.Exit();
            });

            FormClosed += (sender, e) =>
            {
                if (Settings.Default.Scoreboards != null)
                {
                    Settings.Default.Scoreboards.Clear();
                    scoreboards.ForEach((it) =>
                    {
                        if (!it.Removed)
                            Settings.Default.Scoreboards.Add(it.ToString());
                    });
                }
                Settings.Default.Save();
            };
            listView.ItemSelectionChanged += (sender, e) =>
            {
                recordScore.Enabled = unlocked.CanChangeScore && listView.SelectedItems.Count > 0;
                DrawCharts();
            };
            adminBox.SelectionChangeCommitted += (sender, e) =>
            {
                int oldIndex = adminBox.Tag != null ? (int)adminBox.Tag : adminBox.Items.Count - 1;
                adminBox.Tag = adminBox.SelectedIndex;
                if (adminBox.SelectedIndex < adminBox.Items.Count - 1)
                {
                    bool isAdmin = adminBox.SelectedIndex == 0;
                    DailyAdmin target = !isAdmin ? CurrentProject.TodaysAdmins[adminBox.SelectedIndex - 1] : null;
                    EditValue edit = new EditValue(isAdmin ? res.GetString("password.Chief") : res.GetString("password.Speciafic").Replace("%s", target.Name), true);
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        MatchResult result = CurrentProject.MatchPassword(edit.ValueReturn);
                        void showError()
                        {
                            MessageBox.Show(res.GetString("error.WrongPassword"), res.GetString("validate.Text"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            adminBox.SelectedIndex = oldIndex;
                        }
                        if (isAdmin)
                        {
                            if (result.Permission == Permission.ChiefAdmin)
                            {
                                unlocked = MatchResult.ChiefAdmin;
                                UpdateMenuStrip();
                            }
                            else
                            {
                                showError();
                            }
                        }
                        else
                        {
                            if (result.Permission == Permission.DailyAdmin && result.Admin.Equals(target))
                            {
                                unlocked = result;
                                UpdateMenuStrip();
                            }
                            else
                            {
                                showError();
                            }
                        }
                    }
                    else
                    {
                        adminBox.SelectedIndex = oldIndex;
                    }
                    edit.Dispose();
                }
                else
                {
                    unlocked = MatchResult.Locked;
                    UpdateMenuStrip();
                }
            };

            if(Settings.Default.Scoreboards != null)
            {
                foreach (string json in Settings.Default.Scoreboards)
                {
                    try
                    {
                        Scoreboard.Scoreboard scoreboard = Scoreboard.Scoreboard.Deserialize(json);
                        scoreboards.Add(scoreboard);
                        scoreboard.NewForm(this).Show();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.GetType().FullName + ": " + e.Message, res.GetString("error.LoadScoreboard"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public Project CurrentProject;
        public MatchResult unlocked
        {
            private set;
            get;
        }
        public event ProjectOpenEventHandler ProjectOpen;
        public void OpenProject(Project project)
        {
            CurrentProject = project;
            if (Settings.Default.RecentFolders == null)
            {
                Settings.Default.RecentFolders = new System.Collections.Specialized.StringCollection();
            }
            else
            {
                if (Settings.Default.RecentFolders.Contains(project.Path))
                {
                    Settings.Default.RecentFolders.Remove(project.Path);
                }
                Settings.Default.RecentFolders.Insert(0, project.Path);
            }

            unlocked = project.Encryted ? MatchResult.Locked : MatchResult.ChiefAdmin;
            UpdateMenuStrip(true);

            Relayout();
            ColumnStyle column = projectPanel.ColumnStyles[0];
            column.SizeType = SizeType.Percent;
            column.Width = 50f;
            FormBorderStyle = FormBorderStyle.Sizable;

            UpdateGroupView();
            DrawCharts();

            project.OperationDone += UpdateUndoRedoMenuStrip;
            if (ProjectOpen != null)
                ProjectOpen.Invoke(project);
        }

        private void Relayout()
        {
            ComponentResourceManager res = Utility.ApplySource(this);
            if (quickIndexView != null) quickIndexView.UpdateLanguage();
            if (CurrentProject == null)
            {
                projectPanel.Visible = false;
                startPanel.Visible = true;
                startPanel.Dock = DockStyle.Fill;
                projectPanel.Dock = DockStyle.None;
                adminBox.Visible = false;
            }
            else
            {
                startPanel.Visible = false;
                projectPanel.Visible = true;
                projectPanel.Dock = DockStyle.Fill;
                startPanel.Dock = DockStyle.None;

                listView.Columns.Clear();
                listView.Columns.Add(new ColumnHeader
                {
                    Text = res.GetString("col.Member"),
                    Width = 240
                });
                listView.Columns.Add(new ColumnHeader
                {
                    Text = res.GetString("col.Score"),
                    Width = 120
                });
                UpdateMenuStrip(true);
            }
        }

        private void UpdateGroupView()
        {
            listView.BeginUpdate();
            listView.Groups.Clear();
            listView.Items.Clear();
            CurrentProject.Groups.ForEach((group) =>
            {
                ListViewGroup groupView = new ListViewGroup
                {
                    Header = group.Name
                };

                group.People.ForEach((it) =>
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = it.Name,
                        Tag = it.ID
                    };
                    item.SubItems.Add(it.Score.ToString());
                    
                    groupView.Items.Add(item);
                    listView.Items.Add(item);
                });

                listView.Groups.Add(groupView);
                listView.ShowGroups = true;
            });
            listView.EndUpdate();
        }

        private void UpdateUndoRedoMenuStrip()
        {
            menuStrip.SuspendLayout();
            saveToolStripMenuItem.Enabled = undoMenuItem.Enabled = redoMenuItem.Enabled = unlocked.CanChangeScore;
            if (unlocked.CanChangeScore)
            {
                undoMenuItem.Enabled = CurrentProject.LastOperation != null;
                redoMenuItem.Enabled = CurrentProject.OperationHeader < CurrentProject.Operations.Count - 1 
                    && CurrentProject.Operations.Count > 0;
                saveToolStripMenuItem.Enabled = CurrentProject.CanBeSaved;
            }
            menuStrip.ResumeLayout();
        }
        private QuickIndexView quickIndexView;
        private void UpdateViewType()
        {
            switch (viewType)
            {
                case ViewType.QuickIndex:
                    quickIndexItem.Checked = true;
                    overviewItem.Checked = false;
                    this.SuspendLayout();
                    if (quickIndexView == null)
                    {
                        quickIndexView = new QuickIndexView(CurrentProject, this);
                        Controls.Add(quickIndexView);
                        quickIndexView.Dock = DockStyle.Fill;
                        Padding newMargin = new Padding(3);
                        newMargin.Bottom += statusStrip.Height;
                        newMargin.Top += MainMenuStrip.Height;
                        quickIndexView.Padding = newMargin;
                    }
                    projectPanel.Visible = false;
                    quickIndexView.Visible = true;
                    this.ResumeLayout();
                    break;
                default:
                    overviewItem.Checked = true;
                    quickIndexItem.Checked = false;
                    this.SuspendLayout();
                    if(quickIndexView != null) quickIndexView.Visible = false;
                    projectPanel.Visible = true;
                    UpdateGroupView();
                    this.ResumeLayout();
                    break;
            }
        }
        private void UpdateMenuStrip(bool includeAdminBox = false)
        {
            addGroup.Enabled = addMember.Enabled = unlocked.CanChangeMember;
            validate.Enabled = CurrentProject.Encryted;
            quickIndexItem.Enabled = overviewItem.Enabled = true;
            UpdateViewType();
            UpdateUndoRedoMenuStrip();
            if (CurrentProject.Encryted)
            {
                ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                validate.Text = res.GetString(unlocked.CanChangeScore ? "lock" : "validate.Text");

                if (includeAdminBox)
                {
                    adminBox.Visible = true;
                    adminBox.BeginUpdate();

                    adminBox.Items.Clear();
                    adminBox.Items.Add(res.GetString("chiefAdmin"));
                    CurrentProject.TodaysAdmins.ForEach((it) => adminBox.Items.Add(it.Name));
                    adminBox.Items.Add(res.GetString("observer"));

                    adminBox.EndUpdate();
                }
                switch (unlocked.Permission)
                {
                    case Permission.ChiefAdmin:
                        adminBox.SelectedIndex = 0;
                        break;
                    case Permission.DailyAdmin:
                        adminBox.SelectedIndex = CurrentProject.TodaysAdmins.IndexOf(unlocked.Admin) + 1;
                        break;
                    case Permission.Locked:
                        adminBox.SelectedIndex = adminBox.Items.Count - 1;
                        break;
                }
            }
            else
            {
                adminBox.Visible = false;
            }

            recordScore.Enabled = unlocked.CanChangeScore;
            projectProperties.Enabled = unlocked.CanChangeMember;
            importItem.Enabled = unlocked.CanChangeMember;

            if (viewType == ViewType.QuickIndex)
            {
                quickIndexView.UpdateComponents();
            }
        }

        private void New_Project(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            if (projectForm.ShowDialog() == DialogResult.OK)
            {
                projectForm.ReturnValue.Save();
                OpenProject(projectForm.ReturnValue);
            }
            projectForm.Dispose();
        }
        private void ShowErrorWhileReading(Exception error)
        {
            MessageBox.Show(error.GetType().FullName + ": " + error.Message, new ComponentResourceManager(typeof(Form1)).GetString("error.OpenProject"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Recent_Click(object sender, EventArgs e)
        {
            try
            {
                OpenProject(Project.Open(Settings.Default.RecentFolders[0]));
            }
            catch(Exception error)
            {
                ShowErrorWhileReading(error);
            }
        }

        private readonly ContextMenu listMenu = new ContextMenu();
        private void PopupHandler(object sender, EventArgs e)
        {
            listMenu.MenuItems.Clear();
            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));

            if (listView.SelectedItems.Count > 0)
            {
                listMenu.MenuItems.Add(res.GetString("recordScore.Text"), RecordScoreMenuClickHandler)
                    .Enabled = unlocked.CanChangeScore;

                if (listView.SelectedItems.Count == 1)
                    listMenu.MenuItems.Add(res.GetString("properties"), PropertiesMenuClickHandler)
                        .Enabled = unlocked.CanChangeMember;
                else
                {
                    bool inOneGroup = true;
                    Group lastGroup = null;
                    foreach(ListViewItem item in listView.SelectedItems)
                    {
                        Person person = CurrentProject.FindPerson((Guid)item.Tag);
                        if (lastGroup == null)
                        {
                            lastGroup = person.Group;
                        }
                        else if (person.Group != lastGroup)
                        {
                            inOneGroup = false;
                            break;
                        }
                    }
                    if (inOneGroup)
                    {
                        listMenu.MenuItems.Add(res.GetString("properties"), (x, y) =>
                        {
                            GroupForm form = new GroupForm(lastGroup);
                            Group oldGroup = lastGroup.Clone() as Group;
                            if (form.ShowDialog() == DialogResult.OK) {
                                CurrentProject.Do(new ChangeGroupProperties(oldGroup, lastGroup));

                                UpdateGroupView();
                                DrawCharts();
                            }
                            form.Dispose();
                        })
                            .Enabled = unlocked.CanChangeMember;
                    }
                }
            }
        }

        private void PropertiesMenuClickHandler(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(CurrentProject.FindPerson((Guid)listView.SelectedItems[0].Tag), CurrentProject);
            if (memberForm.ShowDialog() == DialogResult.OK)
                UpdateGroupView();
            memberForm.Dispose();
        }
        private void RecordScoreMenuClickHandler(object sender, EventArgs e)
        {
            List<Operation> operations = new List<Operation>();
            foreach (ListViewItem item in listView.SelectedItems) {
                ScoreForm scoreForm = new ScoreForm(CurrentProject.FindPerson((Guid)item.Tag), CurrentProject);
                if (scoreForm.ShowDialog() != DialogResult.OK)
                {
                    scoreForm.Dispose();
                    break;
                }
                operations.Add(new ScoreChange(scoreForm.ValueReturn));
                scoreForm.Dispose();
            }
            CurrentProject.Do(new OperationSticker()
            {
                Operations = operations.ToArray()
            });
            UpdateGroupView();
            DrawCharts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recent.Enabled = Settings.Default.RecentFolders != null && Settings.Default.RecentFolders.Count > 0;
            saveToolStripMenuItem.Enabled = false;
            addGroup.Enabled = false;
            addMember.Enabled = false;
            recordScore.Enabled = false;
            validate.Enabled = false;
            projectProperties.Enabled = false;
            importItem.Enabled = false;
            undoMenuItem.Enabled = false;
            redoMenuItem.Enabled = false;
            listView.View = System.Windows.Forms.View.Details;
            listMenu.Popup += this.PopupHandler;
            listView.ContextMenu = listMenu;
            autostartItem.Checked = Settings.Default.Autostart;
            recordListView.ListViewItemSorter = lviSorter;


            UpdateLanguageMenuStrip();

            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
            if (Registry.ClassesRoot.OpenSubKey(".smp") == null)
            {
                Utility.SetAssociation(".smp", "ScoreManager", "");
            }
        }

        private void UpdateLanguageMenuStrip()
        {
            MainMenuStrip.SuspendLayout();
            chineseItem.Checked = false;
            englishItem.Checked = false;
            switch (Settings.Default.Language)
            {
                case "en":
                    englishItem.Checked = true;
                    break;
                case "zh-CN":
                    chineseItem.Checked = true;
                    break;
                default:
                    break;
            }
            MainMenuStrip.ResumeLayout();
            Settings.Default.Save();
        }

        private void AddGroup_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm();
            if(groupForm.ShowDialog() == DialogResult.OK)
            {
                CurrentProject.Groups.Add(groupForm.ReturnValue);
                CurrentProject.Do(new AddGroup(groupForm.ReturnValue));
                UpdateGroupView();
            }
            groupForm.Dispose();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentProject.Save();
            saveToolStripMenuItem.Enabled = false;
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AddMember_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(CurrentProject);
            if (memberForm.ShowDialog() == DialogResult.OK)
            {
                CurrentProject.AddPerson(memberForm.ValueReturn);
                CurrentProject.Do(new AddMember(memberForm.ValueReturn));
                UpdateGroupView();
            }
            memberForm.Dispose();
        }

        private void RecordScore_Click(object sender, EventArgs e)
        {
            RecordScoreMenuClickHandler(sender, e);
        }

        private void validate_Click(object sender, EventArgs e)
        {
            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
            if (!unlocked.CanChangeScore)
            {
                EditValue edit = new EditValue(res.GetString("password"), true);
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    unlocked = CurrentProject.MatchPassword(edit.ValueReturn);
                    if (!unlocked.CanChangeScore)
                    {
                        MessageBox.Show(res.GetString("error.WrongPassword"), res.GetString("error.WPC"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        UpdateMenuStrip();
                        validate.Text = res.GetString("lock");
                    }
                }
                edit.Dispose();
            }
            else
            {
                unlocked = MatchResult.Locked;
                UpdateMenuStrip();
                validate.Text = res.GetString("validate.Text");
            }
        }

        private void projectProperties_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(CurrentProject);
            if (projectForm.ShowDialog() == DialogResult.OK)
            {
                if (CurrentProject.Encryted)
                {
                    unlocked = MatchResult.Locked;
                    CurrentProject.Save();
                }
                UpdateMenuStrip(true);
            }
            projectForm.Dispose();
        }

        private ColumnClickEventHandler lastColumnClickListenr;
        private System.Windows.Forms.Timer chartTimer = null;
        private void DrawCharts()
        {
            void doDrawing()
            {
                chart.BeginInit();
                chart.Series.Clear();
                if (listView.SelectedItems.Count == 0)
                {
                    emptySelection.Visible = true;
                    infoPanel.Visible = false;
                }
                else
                {
                    ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                    int mode;
                    void updateSortMode()
                    {
                        lviSorter.SortDate = lviSorter.SortColumn == mode;
                    }
                    lviSorter.SortColumn = 0;

                    emptySelection.Visible = false;
                    infoPanel.Visible = true;
                    if (listView.SelectedItems.Count == 1)
                    {
                        Person member = CurrentProject.FindPerson((Guid)listView.SelectedItems[0].Tag);
                        List<Score> record = member.Record;

                        // Record List View
                        recordListView.BeginUpdate();
                        recordListView.Items.Clear();
                        recordListView.Columns.Clear();
                        recordListView.Columns.Add(res.GetString("col.Time"), 110);
                        recordListView.Columns.Add(res.GetString("col.Reason"), 200);
                        recordListView.Columns.Add(res.GetString("col.Score"), 40);
                        mode = 0;
                        updateSortMode();

                        Series series = chart.Series.Add(member.Name);
                        series.ChartType = SeriesChartType.Line;

                        record.ForEach((score) =>
                        {
                            series.Points.AddXY(score.Time.ToShortDateString(), score.Value);
                            var item = new ListViewItem
                            {
                                Text = score.DateString
                            };
                            item.SubItems.Add(score.Reason);
                            item.SubItems.Add(score.Value.ToString());
                            recordListView.Items.Add(item);
                        });
                        recordListView.View = System.Windows.Forms.View.Details;
                    }
                    else
                    {
                        bool allSelectionsInGroup = true;
                        List<Group> selectedGroups = new List<Group>();
                        void validate()
                        {
                            Group previousGroup = null;
                            int previousCount = 0;
                            foreach (ListViewItem item in listView.SelectedItems)
                            {
                                Person member = CurrentProject.FindPerson((Guid)item.Tag);
                                if (previousGroup != null)
                                {
                                    if (previousGroup != member.Group)
                                    {
                                        if (previousGroup.People.Count != previousCount)
                                        {
                                            allSelectionsInGroup = false;
                                            selectedGroups = null;
                                            break;
                                        }
                                        previousCount = 0;
                                    }
                                }
                                if (previousGroup != member.Group)
                                {
                                    selectedGroups.Add(member.Group);
                                }
                                previousCount++;
                                previousGroup = member.Group;
                            }
                        };
                        validate();

                        // Record List View
                        recordListView.BeginUpdate();
                        recordListView.Items.Clear();
                        recordListView.Columns.Clear();
                        recordListView.Columns.Add(res.GetString("col.Target"), 60);
                        recordListView.Columns.Add(res.GetString("col.Time"), 110);
                        recordListView.Columns.Add(res.GetString("col.Reason"), 200);
                        recordListView.Columns.Add(res.GetString("col.Score"), 40);
                        mode = 1;
                        updateSortMode();

                        if (!allSelectionsInGroup || selectedGroups.Count == 1)
                        {
                            bool isSameGroup = true;
                            Group lastGroup = null;
                            List<Person> people = new List<Person>();
                            foreach (ListViewItem item in listView.SelectedItems)
                            {
                                Person member = CurrentProject.FindPerson((Guid)item.Tag);
                                people.Add(member);

                                member.Record.ForEach((it) =>
                                {
                                    var viewItem = recordListView.Items.Add(member.Name);
                                    viewItem.SubItems.Add(it.DateString);
                                    viewItem.SubItems.Add(it.Reason);
                                    viewItem.SubItems.Add(it.Value.ToString());
                                });
                                if (isSameGroup)
                                {
                                    if (lastGroup != null && lastGroup != member.Group)
                                    {
                                        isSameGroup = false;
                                    }
                                    else
                                    {
                                        lastGroup = member.Group;
                                    }
                                }
                            }
                            if (isSameGroup)
                            {
                                Series series = chart.Series.Add(res.GetString("col.Score"));
                                people.ForEach((it) => series.Points.AddXY(it.Name, it.Score));
                                series.ChartType = SeriesChartType.Pie;
                            }
                            else
                            {
                                string score = res.GetString("col.Score");
                                people.ForEach((it) => chart.Series.Add(it.Name).Points.AddXY(score, it.Score));
                            }
                        }
                        else
                        {
                            string score = res.GetString("col.Score");
                            selectedGroups.ForEach((group) =>
                            {
                                chart.Series.Add(group.Name).Points.AddXY(score, group.Score);
                            });
                        }

                        recordListView.View = System.Windows.Forms.View.Details;
                    }

                    if (lastColumnClickListenr != null)
                        recordListView.ColumnClick -= lastColumnClickListenr;
                    lastColumnClickListenr = (s, a) =>
                    {
                        if (a.Column == lviSorter.SortColumn)
                        {
                            if (lviSorter.Order == SortOrder.Ascending)
                            {
                                lviSorter.Order = SortOrder.Descending;
                            }
                            else
                            {
                                lviSorter.Order = SortOrder.Ascending;
                            }
                        }
                        else
                        {
                            lviSorter.SortColumn = a.Column;
                            lviSorter.SortDate = a.Column == mode;
                            lviSorter.Order = SortOrder.Ascending;
                        }
                        recordListView.Sort();
                    };

                    recordListView.ColumnClick += lastColumnClickListenr;
                    recordListView.Sort();
                    recordListView.EndUpdate();
                }

                chart.EndInit();
            }
            if (chartTimer != null)
                chartTimer.Dispose();
            chartTimer = new System.Windows.Forms.Timer
            {
                Interval = 100
            };
            chartTimer.Tick += (a, b) =>
            {
                doDrawing();
                chartTimer.Stop();
                chartTimer.Dispose();
            };
            chartTimer.Start();
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            CurrentProject.LastOperation.Undo();
            UpdateUndoRedoMenuStrip();
            UpdateGroupView();
        }

        private void redoMenuItem_Click(object sender, EventArgs e)
        {
            CurrentProject.Operations[CurrentProject.OperationHeader + 1].Redo();
            UpdateUndoRedoMenuStrip();
            UpdateGroupView();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z) && undoMenuItem.Enabled)
            {
                undoMenuItem_Click(null, null);
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.Z) && redoMenuItem.Enabled)
            {
                redoMenuItem_Click(null, null);
                return true;
            } else if(keyData == (Keys.Control | Keys.S) && saveToolStripMenuItem.Enabled)
            {
                SaveToolStripMenuItem_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void newScoreboardItem_Click(object sender, EventArgs e)
        {
            ScoreboardConfigForm configForm = new ScoreboardConfigForm();
            if (configForm.ShowDialog() == DialogResult.OK)
            {
                scoreboards.Add(configForm.ValueReturn);
                if (Settings.Default.Scoreboards == null)
                    Settings.Default.Scoreboards = new System.Collections.Specialized.StringCollection()
                    {
                        configForm.ValueReturn.ToString()
                    };
                else
                    Settings.Default.Scoreboards.Add(configForm.ValueReturn.ToString());

                configForm.ValueReturn.NewForm(this).Show();

                Settings.Default.Save();
            }
            configForm.Dispose();
        }

        private void chineseItem_Click(object sender, EventArgs e)
        {
            Settings.Default.Language = "zh-CN";
            UpdateLanguageMenuStrip();
            Relayout();
        }

        private void englishItem_Click(object sender, EventArgs e)
        {
            Settings.Default.Language = "en";
            UpdateLanguageMenuStrip();
            Relayout();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentProject != null)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    Hide();
                    notifyIcon.Visible = true;
                    if (!Settings.Default.BackgrounMessageShown)
                    {
                        ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                        notifyIcon.ShowBalloonTip(3000, res.GetString("notification.Title"), res.GetString("notification.Subtitle"), ToolTipIcon.Info);
                        Settings.Default.BackgrounMessageShown = true;
                    }
                }
                else if (CurrentProject.CanBeSaved)
                {
                    CurrentProject.Save();
                }
            }
        }

        public void notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            Activate();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private System.Windows.Forms.OpenFileDialog NewOpenSMPDialog()
        {
            return new System.Windows.Forms.OpenFileDialog()
            {
                AddExtension = true,
                Filter = new ComponentResourceManager(typeof(Form1)).GetString("smp") + "(*.smp)|*.smp"
            };
        }
        private void openItem_Click(object sender, EventArgs e)
        {
            var dialog = NewOpenSMPDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenProject(Open(dialog.FileName));
                }
                catch(Exception error)
                {
                    ShowErrorWhileReading(error);
                }
            }
            dialog.Dispose();
        }

        private void autostartItem_Click(object sender, EventArgs e)
        {
            autostartItem.Checked = Settings.Default.Autostart = !Settings.Default.Autostart;
            Utility.StartWithSystem = Settings.Default.Autostart;
        }

        enum ViewType
        {
            Overview, QuickIndex
        }

        private ViewType viewType = ViewType.Overview;
        private void overviewItem_Click(object sender, EventArgs e)
        {
            if (viewType != ViewType.Overview)
            {
                viewType = ViewType.Overview;
                UpdateViewType();
            }
        }

        private void quickIndexItem_Click(object sender, EventArgs e)
        {
            if (viewType != ViewType.QuickIndex)
            {
                viewType = ViewType.QuickIndex;
                UpdateViewType();
            }
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void importItem_Click(object sender, EventArgs e)
        {
            var dialog = NewOpenSMPDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Project project = Open(dialog.FileName);
                    var res = new ComponentResourceManager(typeof(Form1));
                    void doImport()
                    {
                        var importer = new ProjectImporter();
                        importer.GroupDuplicated += (object first, object second) =>
                        {
                            return MessageBox.Show(res.GetString("warn.DuplicatedGroup").Replace("%s", ((Group)first).Name), res.GetString("warn"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        };
                        importer.MemberDuplicated += (object first, object second) =>
                        {
                            return MessageBox.Show(res.GetString("warn.DuplicatedPerson").Replace("%s", ((Person)first).Name), res.GetString("warn"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        };
                        importer.Import(CurrentProject, project);
                    }
                    if (project.Encryted)
                    {
                        var edit = new EditValue(res.GetString("password.Chief"), true);
                        if (edit.ShowDialog() == DialogResult.OK)
                        {
                            if (project.MatchPassword(edit.ValueReturn).CanChangeMember)
                            {
                                doImport();
                            }
                            else
                            {
                                MessageBox.Show(res.GetString("error.WrongPassword"), res.GetString("error.WPC"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        edit.Dispose();
                    }
                    else
                    {
                        doImport();
                    }
                }
                catch (Exception exception)
                {
                    ShowErrorWhileReading(exception);
                }
                finally
                {
                    CurrentProject.CanBeSaved = true;
                    UpdateGroupView();
                    UpdateMenuStrip(true);
                    DrawCharts();
                }
            }
            dialog.Dispose();
        }
    }
}
