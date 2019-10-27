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
    public partial class MemberForm : Form
    {
        public Person ValueReturn;
        private Project project;
        private bool addMode;
        public MemberForm(Project project)
        {
            InitializeComponent();
            Utility.ApplySource(this);
            this.project = project;
            this.addMode = true;
            StartPosition = FormStartPosition.CenterParent;

            if (project.Groups.Count > 0)
            {
                groupListBox.BeginUpdate();
                project.Groups.ForEach((it) => groupListBox.Items.Add(it.Name));
                groupListBox.EndUpdate();
                groupListBox.SelectedIndex = 0;
            }
        }

        public MemberForm(Person person, Project project)
        {
            InitializeComponent();
            Utility.ApplySource(this);
            this.addMode = false;
            this.project = project;
            ValueReturn = person;
            StartPosition = FormStartPosition.CenterParent;

            if (project.Groups.Count > 0)
            {
                int personalGroup = -1;
                groupListBox.BeginUpdate();
                for (int i = 0; i < project.Groups.Count; i++)
                {
                    Group g = project.Groups[i];
                    groupListBox.Items.Add(g.Name);
                    if (g == person.Group)
                        personalGroup = i;
                }
                groupListBox.EndUpdate();
                groupListBox.SelectedIndex = personalGroup;
            }
            nameBox.Text = person.Name;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            ComponentResourceManager res = new ComponentResourceManager(typeof(MemberForm));
            if (groupListBox.SelectedIndex == -1)
            {
                errorProvider.SetError(groupLabel, res.GetString("error.EmptyGroup"));
                SystemSounds.Beep.Play();
                return;
            }
            if (nameBox.Text == "")
            {
                errorProvider.SetError(nameLabel, res.GetString("error.EmptyName"));
                SystemSounds.Beep.Play();
                return;
            }
            Group selectedGroup = project.Groups[groupListBox.SelectedIndex];
            if (addMode)
            {
                if (selectedGroup.People.Any((person) => person.Name == nameBox.Text))
                {
                    MessageBox.Show(res.GetString("error.PersonExits"), res.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ValueReturn = new Person(nameBox.Text, selectedGroup);
            }
            else
            {
                List<Operation> operations = new List<Operation>();
                if (ValueReturn.Name != nameBox.Name)
                {
                    operations.Add(new RenameMember(ValueReturn, ValueReturn.Name, nameBox.Text));
                    ValueReturn.Name = nameBox.Text;
                }
                if (selectedGroup != ValueReturn.Group)
                {
                    operations.Add(new MoveMember(ValueReturn, ValueReturn.Group, selectedGroup));
                    project.MovePerson(ValueReturn, selectedGroup);
                }
                project.Do(new OperationSticker()
                {
                    Operations = operations.ToArray()
                });
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
