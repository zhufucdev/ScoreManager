using ScoreManager.Statics;
using System;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Collections.Generic;
using static ScoreManager.Statics.Project;
using ScoreManager.Properties;
using Microsoft.Win32;
using ScoreManager.Utils;

namespace ScoreManager
{
    public partial class Form1 : RibbonForm
    {
        private readonly List<Scoreboard.Scoreboard> scoreboards = new List<Scoreboard.Scoreboard>();
        private readonly ListViewColumnSorter lviSorter = new ListViewColumnSorter();
        public Form1()
        {
            Settings.Default.Language = Settings.Default.Language ?? Thread.CurrentThread.CurrentCulture.Name;
            Icon = Resources.AppIcon;
            InitializeComponent();
            Relayout();
            //FormBorderStyle = FormBorderStyle.None;
            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));

            notifyIcon.Text = res.GetString("this.Text");
            notifyIcon.Icon = Resources.AppIcon;
            notifyIcon.ContextMenu = new ContextMenu();
            notifyIcon.ContextMenu.MenuItems.Add(res.GetString("exit"), (e, a) => {
                Application.Exit();
            });

            if (Settings.Default.RecentProjects != null)
            {
                foreach (var recent in Settings.Default.RecentProjects)
                {
                    var item = new RibbonOrbRecentItem()
                    {
                        Text = Path.GetFileNameWithoutExtension(recent)
                    };
                    item.Click += (sender, e) =>
                    {
                        OpenProject(Project.Open(recent));
                    };
                    ribbonMain.OrbDropDown.RecentItems.Add(item);
                }
            }

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
                UpdatePropertiesButtons();
                DrawCharts();
            };
            adminBox.DropDownItemClicked += (sender, e) =>
            {
                int oldIndex = adminBox.Tag != null ? (int)adminBox.Tag : adminBox.DropDownItems.Count - 1;
                adminBox.Tag = adminBox.SelectedIndex;
                if (adminBox.SelectedIndex < adminBox.DropDownItems.Count - 1)
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
                                UpdateRibbonMenu();
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
                                UpdateRibbonMenu();
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
                    UpdateRibbonMenu();
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
            if (Settings.Default.RecentProjects == null)
            {
                Settings.Default.RecentProjects = new System.Collections.Specialized.StringCollection();
            }
            else
            {
                if (Settings.Default.RecentProjects.Contains(project.Path))
                {
                    Settings.Default.RecentProjects.Remove(project.Path);
                }
                Settings.Default.RecentProjects.Insert(0, project.Path);
            }

            unlocked = project.Encryted ? MatchResult.Locked : MatchResult.ChiefAdmin;
            UpdateRibbonMenu(true);

            Relayout();
            projectPanel.SplitterDistance = projectPanel.Width / 2;
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
            Text = res.GetString("this.Text") + (CurrentProject == null ? "" : "-" + CurrentProject.Name);

            if (CurrentProject == null)
            {
                projectPanel.Visible = false;
                startPanel.Visible = true;
                //startPanel.Width = Width - 6;
                startPanel.Dock = DockStyle.Fill;
                projectPanel.Dock = DockStyle.None;
                adminBox.Visible = false;
            }
            else
            {
                if (quickIndexView != null) quickIndexView.UpdateLanguage();
                startPanel.Visible = false;
                projectPanel.Visible = true;
                //projectPanel.Width = Width - 6;
                //projectPanel.Left = 0;
                //projectPanel.Top = ribbonMain.Height + 12;
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
                UpdateRibbonMenu(true);
            }
        }

        private void UpdateGroupView(bool scoreOnly = false)
        {
            listView.BeginUpdate();
            if (!scoreOnly)
            {
                listView.Groups.Clear();
                listView.Items.Clear();
                CurrentProject.Groups.ForEach((group) =>
                {
                    ListViewGroup groupView = new ListViewGroup
                    {
                        Header = group.Name,
                        Name = group.Name
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
            }
            else
            {
                foreach (Group g in CurrentProject.Groups)
                {
                    ListView.ListViewItemCollection groupItems = null;
                    foreach (ListViewGroup group in listView.Groups)
                    {
                        if (group.Name == g.Name)
                        {
                            groupItems = group.Items;
                            break;
                        }
                    }
                    #region skip undrawn groups
                    if (groupItems == null)
                        continue;
                    #endregion
                    g.People.ForEach((p) =>
                    {
                        bool found = false;
                        foreach (ListViewItem item in groupItems)
                        {
                            if ((Guid)item.Tag == p.ID)
                            {
                                item.SubItems[1].Text = p.Score.ToString();
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            ListViewItem newItem = new ListViewItem
                            {
                                Text = p.Name,
                                Tag = p.ID
                            };
                            newItem.SubItems.Add(p.Score.ToString());

                            groupItems.Add(newItem);
                            listView.Items.Add(newItem);
                        }
                    });
                }
            }
            listView.EndUpdate();
        }

        private void UpdateUndoRedoMenuStrip()
        {
            ribbonButtonSave.Enabled = ribbonButtonUndo.Enabled = ribbonButtonRedo.Enabled = unlocked.CanChangeScore;
            if (unlocked.CanChangeScore)
            {
                ribbonButtonUndo.Enabled = CurrentProject.LastOperation != null;
                ribbonButtonRedo.Enabled = CurrentProject.OperationHeader < CurrentProject.Operations.Count - 1 
                    && CurrentProject.Operations.Count > 0;
                ribbonButtonSave.Enabled = CurrentProject.CanBeSaved;
            }
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
                        newMargin.Top += ribbonMain.Height;
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
                    UpdateGroupView(scoreOnly: true);
                    this.ResumeLayout();
                    break;
            }
        }
        private void UpdateRibbonMenu(bool includeAdminBox = false)
        {
            editTab.Enabled = true;
            viewTab.Enabled = true;//quickIndexItem.Enabled = overviewItem.Enabled = true;
            addMember.Enabled = addGroup.Enabled = unlocked.CanChangeMember;
            validate.Enabled = CurrentProject.Encryted;
            UpdateViewType();
            UpdateUndoRedoMenuStrip();
            if (CurrentProject.Encryted)
            {
                ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                validate.Text = res.GetString(unlocked.CanChangeScore ? "lock" : "validate.Text");

                if (includeAdminBox)
                {
                    adminBox.Visible = true;

                    adminBox.DropDownItems.Clear();
                    
                    adminBox.DropDownItems.Add(new RibbonButton
                    {
                        Text = res.GetString("chiefAdmin")
                    });
                    CurrentProject.TodaysAdmins.ForEach((it) => adminBox.DropDownItems.Add(new RibbonButton
                    {
                        Text = it.Name
                    }));
                    adminBox.DropDownItems.Add(new RibbonButton
                    {
                        Text = res.GetString("observer")
                    });
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
                        adminBox.SelectedIndex = adminBox.DropDownItems.Count - 1;
                        break;
                }
            }
            else
            {
                adminBox.Visible = false;
            }

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
                OpenProject(Project.Open(Settings.Default.RecentProjects[0]));
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

                UpdatePropertiesButtons();
            }
        }
        private EventHandler lastPropertiesButtonAction = null;
        private void UpdatePropertiesButtons()
        {
            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
            if (listView.SelectedItems.Count == 0)
                properties.Enabled = false;
            else if (listView.SelectedItems.Count == 1)
            {
                EventHandler action = (x, y) =>
                {
                    MemberForm memberForm = new MemberForm(CurrentProject.FindPerson((Guid)listView.SelectedItems[0].Tag), CurrentProject);
                    if (memberForm.ShowDialog() == DialogResult.OK)
                        UpdateGroupView();
                    memberForm.Dispose();
                };
                listMenu.MenuItems.Add(res.GetString("properties"), action)
                    .Enabled = unlocked.CanChangeMember;
                if (lastPropertiesButtonAction != null)
                    properties.Click -= lastPropertiesButtonAction;
                properties.Click += action;
                lastPropertiesButtonAction = action;
                properties.Enabled = unlocked.CanChangeMember;
            }
            else
            {
                bool inOneGroup = true;
                Group lastGroup = null;
                foreach (ListViewItem item in listView.SelectedItems)
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
                    EventHandler action = (x, y) =>
                    {
                        GroupForm form = new GroupForm(lastGroup);
                        Group oldGroup = lastGroup.Clone() as Group;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            CurrentProject.Do(new ChangeGroupProperties(oldGroup, lastGroup));

                            UpdateGroupView();
                            DrawCharts();
                        }
                        form.Dispose();
                    };
                    listMenu.MenuItems.Add(res.GetString("properties"), action)
                        .Enabled = unlocked.CanChangeMember;
                    if (lastPropertiesButtonAction != null)
                        properties.Click -= lastPropertiesButtonAction;
                    properties.Click += action;
                    lastPropertiesButtonAction = action;
                }
            }
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
            UpdateGroupView(scoreOnly: true);
            DrawCharts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView.View = System.Windows.Forms.View.Details;
            listMenu.Popup += this.PopupHandler;
            listView.ContextMenu = listMenu;
            autostartItem.Checked = Settings.Default.Autostart;
            recordListView.ListViewItemSorter = lviSorter;
            viewTab.Enabled = false;

            UpdateLanguageMenuStrip();

            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
        }

        private void UpdateLanguageMenuStrip()
        {
            ribbonMain.SuspendLayout();
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
            ribbonMain.ResumeLayout();
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

        private void ribbonButtonSave_Click(object sender, EventArgs e)
        {
            CurrentProject.Save();
            ribbonButtonSave.Enabled = false;
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
                        UpdateRibbonMenu();
                        validate.Text = res.GetString("lock");
                    }
                }
                edit.Dispose();
            }
            else
            {
                unlocked = MatchResult.Locked;
                UpdateRibbonMenu();
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
                UpdateRibbonMenu(true);
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
                    splitContainerH.Visible = false;
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

                    splitContainerH.Visible = true;
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
                            if (isSameGroup && lastGroup.People.Count == people.Count)
                            {
                                lastGroup.Record.ForEach((it) =>
                                {
                                    var viewItem = recordListView.Items.Add(it.Maker.Name);
                                    viewItem.SubItems.Add(it.DateString);
                                    viewItem.SubItems.Add(it.Reason);
                                    viewItem.SubItems.Add(it.Value.ToString());
                                });
                            }
                            else
                            {
                                foreach (Person member in people)
                                {
                                    member.Record.ForEach((it) =>
                                    {
                                        var viewItem = recordListView.Items.Add(member.Name);
                                        viewItem.SubItems.Add(it.DateString);
                                        viewItem.SubItems.Add(it.Reason);
                                        viewItem.SubItems.Add(it.Value.ToString());
                                    });
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
                                var series = new Series()
                                {
                                    Name = group.Name,
                                    Color = group.ChosenColor
                                };
                                series.Points.AddXY(score, group.Score);
                                chart.Series.Add(series);
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
            if (keyData == (Keys.Control | Keys.Z) && ribbonButtonUndo.Enabled)
            {
                undoMenuItem_Click(null, null);
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.Z) && ribbonButtonRedo.Enabled)
            {
                redoMenuItem_Click(null, null);
                return true;
            } else if(keyData == (Keys.Control | Keys.S) && ribbonButtonSave.Enabled)
            {
                ribbonButtonSave_Click(null, null);
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

        public static System.Windows.Forms.OpenFileDialog NewOpenSMPDialog()
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
                        var import = new ImportForm(project, CurrentProject);
                        import.ShowDialog();
                        import.Dispose();
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
                    UpdateRibbonMenu(true);
                    DrawCharts();
                }
            }
            dialog.Dispose();
        }
    }
}
