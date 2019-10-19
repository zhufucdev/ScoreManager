using ScoreManager.Statics;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ScoreManager
{
    public partial class Form1 : Form
    {
        private readonly List<Scoreboard.Scoreboard> scoreboards = new List<Scoreboard.Scoreboard>();
        public Form1()
        {
            Settings.Default.Language = Settings.Default.Language ?? Thread.CurrentThread.CurrentCulture.Name;
            InitializeComponent();
            Relayout();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            FormClosed += (sender, e) =>
            {
                Settings.Default.Scoreboards.Clear();
                scoreboards.ForEach((it) => {
                    Console.WriteLine(it.Position + "@Form1");
                    Console.WriteLine(it.ToString());
                    Settings.Default.Scoreboards.Add(it.ToString());
                });
                Settings.Default.Save();
            };
            listView.ItemSelectionChanged += (sender, e) =>
            {
                recordScore.Enabled = unlocked && listView.SelectedItems.Count > 0;
                DrawCharts();
            };

            if(Settings.Default.Scoreboards != null)
            {
                for (int i = 0; i < Settings.Default.Scoreboards.Count; i++)
                {
                    Scoreboard.Scoreboard scoreboard = Scoreboard.Scoreboard.Deserialize(Settings.Default.Scoreboards[i]);
                    scoreboards.Add(scoreboard);
                    new ScoreboardForm(scoreboard, this).Show();
                }
            }
        }

        private Project currentProject;
        private bool unlocked = true;
        public event ProjectOpenEventHandler ProjectOpen;
        void OpenProject(Project project)
        {
            currentProject = project;
            if (project.Encryted)
            {
                unlocked = false;
            }
            UpdateMenuStrip();

            Relayout();
            ColumnStyle column = projectPanel.ColumnStyles[0];
            column.SizeType = SizeType.Percent;
            column.Width = 50f;
            FormBorderStyle = FormBorderStyle.Sizable;

            UpdateGroupView();
            DrawCharts();

            project.OperationDone += UpdateUndoRedoMenuStrip;
            ProjectOpen.Invoke(project);
        }

        private void Relayout()
        {
            ComponentResourceManager res = ResourceController.ApplySource(this);
            if (currentProject == null)
            {
                projectPanel.Visible = false;
                startPanel.Visible = true;
                startPanel.Dock = DockStyle.Fill;
                projectPanel.Dock = DockStyle.None;
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
            }
        }

        private void UpdateGroupView()
        {
            listView.BeginUpdate();
            listView.Groups.Clear();
            listView.Items.Clear();
            currentProject.Groups.ForEach((group) =>
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
            saveToolStripMenuItem.Enabled = unlocked;
            undoMenuItem.Enabled = unlocked;
            redoMenuItem.Enabled = unlocked;
            if (unlocked)
            {
                undoMenuItem.Enabled = currentProject.LastOperation != null;
                redoMenuItem.Enabled = currentProject.OperationHeader < currentProject.Operations.Count - 1 
                    && currentProject.Operations.Count > 0;
                saveToolStripMenuItem.Enabled = currentProject.CanBeSaved;
            }
            menuStrip.ResumeLayout();
        }
        private void UpdateMenuStrip()
        {
            addGroup.Enabled = unlocked;
            addMember.Enabled = unlocked;
            validate.Enabled = currentProject.Encryted;
            UpdateUndoRedoMenuStrip();
            if (currentProject.Encryted)
            {
                ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                validate.Text = res.GetString(unlocked ? "lock" : "validate.Text");
            }

            if (!unlocked)
                recordScore.Enabled = false;
            projectProperties.Enabled = unlocked;
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

        private void Recent_Click(object sender, EventArgs e)
        {
            try
            {
                OpenProject(Project.Open(recentFolders[0]));
            }
            catch(Exception error)
            {
                MessageBox.Show(error.GetType().FullName + ": " + error.Message, new ComponentResourceManager(typeof(Form1)).GetString("error.OpenProject"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        System.Collections.Specialized.StringCollection recentFolders;
        private readonly ContextMenu listMenu = new ContextMenu();
        private void PopupHandler(object sender, EventArgs e)
        {
            listMenu.MenuItems.Clear();
            ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));

            if (listView.SelectedItems.Count == 1)
                listMenu.MenuItems.Add(res.GetString("properties"), this.PropertiesMenuClickHandler);
            if (listView.SelectedItems.Count > 0)
                listMenu.MenuItems.Add(res.GetString("recordScore.Text"), this.RecordScoreMenuClickHandler);
            if (!unlocked)
            {
                foreach(MenuItem item in listMenu.MenuItems)
                {
                    item.Enabled = false;
                }
            }
        }

        private void PropertiesMenuClickHandler(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(currentProject.FindPerson((Guid)listView.SelectedItems[0].Tag), currentProject);
            if (memberForm.ShowDialog() == DialogResult.OK)
                UpdateGroupView();
            memberForm.Dispose();
        }
        private void RecordScoreMenuClickHandler(object sender, EventArgs e)
        {
            List<Operation> operations = new List<Operation>();
            foreach (ListViewItem item in listView.SelectedItems) {
                ScoreForm scoreForm = new ScoreForm(currentProject.FindPerson((Guid)item.Tag));
                if (scoreForm.ShowDialog() != DialogResult.OK)
                {
                    scoreForm.Dispose();
                    break;
                }
                operations.Add(new ScoreChange(scoreForm.ValueReturn));
                scoreForm.Dispose();
            }
            currentProject.Do(new MulitOperations()
            {
                Operations = operations.ToArray()
            });
            UpdateGroupView();
            DrawCharts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recentFolders = Settings.Default.RecentFolders;
            recent.Enabled = recentFolders != null && recentFolders.Count > 0;
            saveToolStripMenuItem.Enabled = false;
            addGroup.Enabled = false;
            addMember.Enabled = false;
            recordScore.Enabled = false;
            validate.Enabled = false;
            projectProperties.Enabled = false;
            undoMenuItem.Enabled = false;
            redoMenuItem.Enabled = false;
            listView.View = View.Details;
            listMenu.Popup += this.PopupHandler;
            listView.ContextMenu = listMenu;

            UpdateLanguageMenuStrip();
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
                currentProject.Groups.Add(groupForm.ReturnValue);
                currentProject.Do(new AddGroup(groupForm.ReturnValue));
                UpdateGroupView();
            }
            groupForm.Dispose();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentProject.Save();
            saveToolStripMenuItem.Enabled = false;
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AddMember_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(currentProject);
            if (memberForm.ShowDialog() == DialogResult.OK)
            {
                currentProject.AddPerson(memberForm.ValueReturn);
                currentProject.Do(new AddMember(memberForm.ValueReturn));
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
            if (!unlocked)
            {
                EditValue edit = new EditValue(res.GetString("password"), true);
                if (edit.ShowDialog() == DialogResult.OK)
                {
                    if (!currentProject.MatchPassword(edit.ValueReturn))
                    {
                        MessageBox.Show(res.GetString("error.WrongPassword"), res.GetString("error.WPC"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        unlocked = true;
                        UpdateMenuStrip();
                        validate.Text = res.GetString("lock");
                    }
                }
                edit.Dispose();
            }
            else
            {
                unlocked = false;
                UpdateMenuStrip();
                validate.Text = res.GetString("validate.Text");
            }
        }

        private void projectProperties_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(currentProject);
            if (projectForm.ShowDialog() == DialogResult.OK)
            {
                if (currentProject.Encryted)
                {
                    unlocked = false;
                }
                UpdateMenuStrip();
            }
            projectForm.Dispose();
        }

        private void DrawCharts()
        {
            chart.BeginInit();
            chart.Series.Clear();
            if (listView.SelectedItems.Count == 1)
            {
                Person member = currentProject.FindPerson((Guid)listView.SelectedItems[0].Tag);
                List<Score> record = member.Record;

                Series series = chart.Series.Add(member.Name);
                series.ChartType = SeriesChartType.Line;

                record.ForEach((score) =>
                {
                    series.Points.AddXY(score.Time.ToShortDateString(), score.Value);
                });
            }
            else
            {
                bool allSelectionsInGroup = true;
                List<Group> selectedGroups = new List<Group>();
                void validate() {
                    Group previousGroup = null;
                    int previousCount = 0;
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        Person member = currentProject.FindPerson((Guid)item.Tag);
                        if (previousGroup != null)
                        {
                            if(previousGroup != member.Group)
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

                ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
                if (!allSelectionsInGroup || selectedGroups.Count == 1)
                {
                    bool isSameGroup = true;
                    Group lastGroup = null;
                    List<Person> people = new List<Person>();
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        Person member = currentProject.FindPerson((Guid)item.Tag);
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
                    selectedGroups.ForEach((group) => {
                        chart.Series.Add(group.Name).Points.AddXY(score, group.Score);
                    });
                }
            }
            chart.EndInit();
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            currentProject.LastOperation.Undo();
            UpdateUndoRedoMenuStrip();
            UpdateGroupView();
        }

        private void redoMenuItem_Click(object sender, EventArgs e)
        {
            currentProject.Operations[currentProject.OperationHeader + 1].Redo();
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
    }
}
