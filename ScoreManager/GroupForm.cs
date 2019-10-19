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
    public partial class GroupForm : Form
    {
        public Group ReturnValue;
        public GroupForm()
        {
            InitializeComponent();
            ResourceController.ApplySource(this);
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {

        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                errorProvider.SetError(nameLabel, new ComponentResourceManager(typeof(GroupForm)).GetString("error.nameEmpty"));
                SystemSounds.Beep.Play();
                nameBox.Focus();
                return;
            }
            Group result = new Group(nameBox.Text, long.TryParse(initalScoreBox.Text, out long initalScore) ? initalScore : 0);
            foreach (ListViewItem item in memberList.Items)
            {
                result.People.Add(new Person(item.Text, result));
            }
            DialogResult = DialogResult.OK;
            ReturnValue = result;
            Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ComponentResourceManager res = new ComponentResourceManager(typeof(GroupForm));
            EditValue dialog = new EditValue(res.GetString("personName"))
            {
                CheckEmpty = true
            };
            void show()
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (ListViewItem item in memberList.Items)
                    {
                        if (item.Text == dialog.ValueReturn)
                        {
                            MessageBox.Show(res.GetString("error.MemberExist"), res.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            show();
                            return;
                        }
                    }
                    memberList.Items.Add(dialog.ValueReturn);
                }
                dialog.Dispose();
            }
            show();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            memberList.BeginUpdate();
            foreach(ListViewItem item in memberList.SelectedItems)
            {
                memberList.Items.Remove(item);
            }
            memberList.EndUpdate();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
