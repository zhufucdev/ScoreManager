﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScoreManager.Statics;

namespace ScoreManager
{
    public partial class QuickIndexView : UserControl
    {
        private Project Project;
        private Dictionary<Person, Score> data = new Dictionary<Person, Score>();
        public QuickIndexView(Project project)
        {
            InitializeComponent();
            UpdateLanguage();
            Project = project;
        }

        public void UpdateLanguage()
        {
            Utility.ApplySource(this);
        }

        private string getGeneralName(Person it)
        {
            return it.Name + "(" + it.Group.Name + ")";
        }
        public void QuickIndexView_Load(object sender, EventArgs e)
        {
            Project.Groups.ForEach((g) =>
            {
                g.People.ForEach((it) => nameBox.AutoCompleteOptions.Add(getGeneralName(it)));
                g.Record.ForEach((it) =>
                {
                    if (!reasonBox.AutoCompleteOptions.Contains(it.Reason))
                    {
                        reasonBox.AutoCompleteOptions.Add(it.Reason);
                    }
                });
            });
        }
        private void add(string name)
        {
            Person person = Project.FindPerson(name);
            if (person == null)
            {
                ComponentResourceManager res = new ComponentResourceManager(typeof(QuickIndexView));
                MessageBox.Show(res.GetString("error.NoSuchPerson").Replace("%s", name), res.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                data[person] = new Score(decimal.ToInt32(scoreBox.Value), reasonBox.Text, person);
                UpdateListView();
            }
        }
        private void UpdateListView()
        {
            listView.BeginUpdate();
            listView.Items.Clear();
            foreach(Person person in data.Keys)
            {
                listView.Items.Add(person.Name).Tag = person.ID;
            }

            listView.EndUpdate();
            confirm.Enabled = data.Count > 0;
        }

        private void EnterPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                add(nameBox.Text);
                nameBox.Text = "";
                reasonBox.Text = "";
                scoreBox.Value = 0;
                e.Handled = true;
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView.SelectedItems)
            {
                data.Remove(Project.FindPerson((Guid)item.Tag));
            }
            remove.Enabled = false;
            UpdateListView();
        }

        private List<Person> lastSelected = null;
        private bool scoreChanged = false, reasonChanged = false;
        private void RestBoxes()
        {
            nameBox.Enabled = true;
            nameBox.Text = "";
            reasonBox.Text = "";
            scoreBox.Value = 0;
        }
        private void Sync()
        {
            if (lastSelected != null)
            {
                if (lastSelected.Count > 1)
                {
                    lastSelected.ForEach((it) =>
                    {
                        if (scoreChanged && reasonChanged)
                        {
                            data[it] = new Score(decimal.ToInt32(scoreBox.Value), reasonBox.Text, it);
                        }
                        else if (scoreChanged)
                        {
                            data[it].Value = decimal.ToInt32(scoreBox.Value);
                        }
                        else if (reasonChanged)
                        {
                            data[it].Reason = reasonBox.Text;
                        }
                    });
                }
                else
                {
                    data[lastSelected[0]] = new Score(decimal.ToInt32(scoreBox.Value), reasonBox.Text, lastSelected[0]);
                }
            }
        }
        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            void removeListeners()
            {
                scoreBox.ValueChanged -= ScoreChange;
                reasonBox.TextChanged -= ReasonChange;
            }
            lock (this) {
                Sync();
                removeListeners();
                lastSelected = null;
                scoreChanged = reasonChanged = false;
            }
            remove.Enabled = listView.SelectedItems.Count > 0;
            if (listView.SelectedItems.Count == 0)
            {
                RestBoxes();
                lastSelected = null;
            }
            else if (listView.SelectedItems.Count == 1)
            {
                Person person = Project.FindPerson((Guid)listView.SelectedItems[0].Tag);
                Score score = data[person];
                nameBox.Enabled = true;
                nameBox.Text = getGeneralName(person);
                reasonBox.Text = score.Reason;
                scoreBox.Value = score.Value;
                lastSelected = new List<Person>() { person };
            }
            else
            {
                nameBox.Text = new ComponentResourceManager(typeof(QuickIndexView)).GetString("dualItems");
                nameBox.Enabled = false;
                lastSelected = new List<Person>();
                bool sameReason = true, sameScore = true;
                Score lastScore = null;
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    Person person = Project.FindPerson((Guid)item.Tag);
                    if (lastScore == null)
                        lastScore = data[person];
                    else
                    {
                        if (sameReason && lastScore.Reason != data[person].Reason)
                            sameReason = false;
                        if (sameScore && lastScore.Value != data[person].Value)
                            sameScore = false;
                    }
                    lastSelected.Add(person);
                }
                reasonBox.Text = sameReason ? lastScore.Reason : "";
                scoreBox.Value = sameScore ? lastScore.Value : 0;
                reasonBox.TextChanged += ReasonChange;
                scoreBox.ValueChanged += ScoreChange;
            }
        }

        private void ScoreChange(object sender, EventArgs e)
        {
            scoreChanged = true;
        }

        private void ReasonChange(object sender, EventArgs e)
        {
            reasonChanged = true;
        }

        private void Input_Focused(object sender, EventArgs e)
        {
            Utility.ShowInputPanel();
        }

        private void Input_Leave(object sender, EventArgs e)
        {
            Utility.HideInputPanel();
        }

        private void nameBox_Leave(object sender, EventArgs e)
        {

        }

        private void confirm_Click(object sender, EventArgs e)
        {
            Sync();
            List<ScoreChange> operations = new List<ScoreChange>();
            foreach(KeyValuePair<Person, Score> d in data)
            {
                d.Key.Group.Record.Add(d.Value);
                operations.Add(new ScoreChange(d.Value));
            }
            Project.Do(new OperationSticker(operations.ToArray()));
            data.Clear();

            UpdateListView();
            RestBoxes();
        }
    }
}