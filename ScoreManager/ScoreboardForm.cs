using ScoreManager.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ResourceController.ApplySource(this);
            Info = info;

            parent.ProjectOpen += Draw;
            LocationChanged += ScoreboardForm_LocationChanged;
            StartPosition = FormStartPosition.Manual;
        }

        private void ScoreboardForm_LocationChanged(object sender, EventArgs e)
        {
            Info.Position = Location;
        }

        private OperationDoneEventHandler LastDrawEvent;
        private void Draw(Project project)
        {
            project.OperationHeaderChanged -= LastDrawEvent;

            SuspendLayout();
            Controls.Clear();
            ComponentResourceManager res = new ComponentResourceManager(typeof(ScoreboardForm));

            if (Info.Type == Scoreboard.ScoreboardType.Charts)
            {
                ListView listView = new ListView();
                listView.Columns.Add(res.GetString("col.Name"), 240);
                listView.Columns.Add(res.GetString("col.Score"), 240);
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
                        } else {
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
                
                project.OperationHeaderChanged += LastDrawEvent;

                listView.Dock = DockStyle.Fill;
                listView.View = View.Details;
                Controls.Add(listView);
            } 
            else
            {

            }
            ResumeLayout();
        }

        private void ScoreboardForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Info.Position);
            Location = Info.Position;

        }
    }
}
