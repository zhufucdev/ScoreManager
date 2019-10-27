using ScoreManager.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace ScoreManager
{
    public partial class ScoreboardForm : Form
    {
        public Scoreboard.Scoreboard Info
        {
            private set;
            get;
        }
        public ScoreboardForm(Scoreboard.Scoreboard info, Form1 parent)
        {
            InitializeComponent();
            ComponentResourceManager res = Utility.ApplySource(this);
            if (info.Name != "")
                Text = info.Name;
            Info = info;

            parent.ProjectOpen += Draw;
            LocationChanged += ScoreboardForm_LocationChanged;
            ResizeEnd += ScoreboardForm_ResizeEnd;
            StartPosition = FormStartPosition.Manual;
            Size = info.Size;
            ShowInTaskbar = false;

            Draw(parent.CurrentProject);

            ContextMenu = new ContextMenu();
            ContextMenu.MenuItems.Add(res.GetString("properties"), (e, g) =>
            {
                ScoreboardConfigForm configForm = new ScoreboardConfigForm(Info);
                switch (configForm.ShowDialog())
                {
                    case DialogResult.OK:
                        Draw(LastProject);
                        break;
                    case DialogResult.Abort:
                        Info.Removed = true;
                        parent.ProjectOpen -= Draw;
                        LocationChanged -= ScoreboardForm_LocationChanged;
                        ResizeEnd -= ScoreboardForm_ResizeEnd;
                        if (LastDrawEvent != null)
                            parent.CurrentProject.OperationHeaderChanged -= LastDrawEvent;
                        Close();
                        break;
                }
                configForm.Dispose();
            });
        }

        private void ScoreboardForm_ResizeEnd(object sender, EventArgs e)
        {
            Info.Size = Size;
        }

        private void ScoreboardForm_LocationChanged(object sender, EventArgs e)
        {
            Info.Position = Location;
        }

        private OperationDoneEventHandler LastDrawEvent;
        private Project LastProject;
        private void Draw(Project project)
        {
            if (LastDrawEvent != null)
                project.OperationHeaderChanged -= LastDrawEvent;
            LastProject = project;

            Location = Info.Position;
            TopMost = Info.Overflow;
            
            SuspendLayout();
            Controls.Clear();
            ComponentResourceManager res = new ComponentResourceManager(typeof(ScoreboardForm));

            if (project != null)
            {
                Text = (Info.Name == "" ? res.GetString("this.Text") : Info.Name) + " - " + project.Name;

                if (Info.Type == Scoreboard.ScoreboardType.Charts)
                {
                    ListView listView = new ListView();
                    listView.Columns.Add(res.GetString("col.Name"), 240);
                    listView.Columns.Add(res.GetString("col.Score"), 120);
                    List<Person> chart = project.ChartedPeople;
                    foreach (Person person in chart)
                    {
                        listView.Items.Add(person.Name).SubItems.Add(person.Score.ToString());
                    }

                    LastDrawEvent = () =>
                    {
                        chart = project.ChartedPeople;
                        for (int i = 0; i < chart.Count; i++)
                        {
                            if (listView.Items.Count <= i || listView.Items[i].Text != chart[i].Name)
                            {
                                listView.Items.Insert(i, chart[i].Name).SubItems.Add(chart[i].Score.ToString());
                                for (int j = i + 1; j < listView.Items.Count; j++)
                                {
                                    if (listView.Items[j].Text == chart[i].Name)
                                    {
                                        listView.Items.RemoveAt(j);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                string newSore = chart[i].Score.ToString();
                                ListViewSubItem subItem = listView.Items[i].SubItems[1];
                                if (subItem.Text != newSore)
                                {
                                    subItem.Text = newSore;
                                }
                            }
                        }
                        for (int i = chart.Count; i < listView.Items.Count; i++)
                            listView.Items.RemoveAt(i);
                    };

                    listView.Dock = DockStyle.Fill;
                    listView.View = System.Windows.Forms.View.Details;
                    Controls.Add(listView);
                }
                else
                {
                    Chart chart = new Chart();
                    chart.ChartAreas.Add("MainArea");
                    chart.Legends.Add("MainLegend");

                    string score = res.GetString("col.Score");
                    switch (Info.Type) {
                        case Scoreboard.ScoreboardType.GroupScale:
                            LastDrawEvent = () =>
                            {
                                chart.BeginInit();
                                chart.Series.Clear();
                                Series series = chart.Series.Add(score);
                                foreach (Group group in project.Groups)
                                {
                                    series.Points.AddXY(group.Name, group.Score);
                                }
                                series.ChartType = SeriesChartType.Pie;
                                chart.EndInit();
                            };
                            LastDrawEvent();
                            break;
                        case Scoreboard.ScoreboardType.GroupRanking:
                            LastDrawEvent = () =>
                            {
                                chart.BeginInit();
                                chart.Series.Clear();
                                foreach (Group group in project.Groups) 
                                {
                                    Series series = chart.Series.Add(group.Name);
                                    long ach = group.Score;
                                    series.Points.AddXY(score, ach);
                                    series.Label = ach.ToString();
                                    series.ChartType = SeriesChartType.Column;
                                }
                                chart.EndInit();
                            };
                            LastDrawEvent();
                            break;
                    }
                    chart.Dock = DockStyle.Fill;
                    Controls.Add(chart);
                }
                project.OperationHeaderChanged += LastDrawEvent;
            }
            else
            {
                Label label = new Label()
                {
                    Name = "noData",
                    Text = res.GetString("noData"),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Controls.Add(label);
                label.Dock = DockStyle.Fill;
            }
            ResumeLayout();
        }
    }
}
