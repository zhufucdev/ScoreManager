using ScoreManager.Scoreboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager
{
    public partial class ScoreboardConfigForm : Form
    {
        public Scoreboard.Scoreboard ValueReturn;
        private bool AddMode = true;
        public ScoreboardConfigForm()
        {
            InitializeComponent();
            ComponentResourceManager res = ResourceController.ApplySource(this);
            foreach (string name in Enum.GetNames(typeof(ScoreboardType)))
                typeBox.Items.Add(res.GetString("type." + name));
            typeBox.SelectedIndex = 0;
        }

        public ScoreboardConfigForm(Scoreboard.Scoreboard scoreboard)
        {
            InitializeComponent();
            ValueReturn = scoreboard;

            ComponentResourceManager res = ResourceController.ApplySource(this);
            foreach (string name in Enum.GetNames(typeof(ScoreboardType)))
                typeBox.Items.Add(res.GetString("type." + name));

            typeBox.SelectedIndex = (int)scoreboard.Type;
            nameBox.Text = scoreboard.Name;
            overflowCheckbox.Checked = scoreboard.Overflow;
            AddMode = false;

            TopMost = scoreboard.Overflow;
            delete.Visible = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (AddMode)
                ValueReturn = new Scoreboard.Scoreboard(nameBox.Text, (ScoreboardType)typeBox.SelectedIndex, overflowCheckbox.Checked);
            else
            {
                ValueReturn.Name = nameBox.Text;
                ValueReturn.Overflow = overflowCheckbox.Checked;
                ValueReturn.Type = (ScoreboardType)typeBox.SelectedIndex;
            }
            Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
