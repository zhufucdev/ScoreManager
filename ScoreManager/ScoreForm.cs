using ScoreManager.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager
{
    public partial class ScoreForm : Form
    {
        private Person target;
        private Project project;
        public Score ValueReturn;
        public ScoreForm(Person target, Project project)
        {
            this.target = target;
            this.project = project;

            InitializeComponent();
            Utility.ApplySource(this);
            StartPosition = FormStartPosition.CenterParent;
            
            targetLabel.Text = new ResourceManager(typeof(ScoreForm)).GetString("target", System.Threading.Thread.CurrentThread.CurrentUICulture).Replace("%s1", target.Group.Name).Replace("%s2", target.Name);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            reasonBox.Click += ReasonBox_Click;
            reasonBox.SelectionChangeCommitted += ReasonBox_SelectionChangeCommitted;
        }

        private void ReasonBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string newItem = (string)reasonBox.SelectedItem;
            if (newItem.EndsWith(")"))
            {
                int a = newItem.LastIndexOf('(');
                if (a != -1)
                {
                    string tryScore = newItem.Substring(a + 1, newItem.Length - a - 2);
                    long score;
                    if (long.TryParse(tryScore, out score))
                    {
                        if (score < 0)
                        {
                            button11.Text = "-";
                            negative = true;
                            score *= -1;
                        }
                        textBox.Text = score.ToString();
                    }
                }
            }
        }

        private void ReasonBox_Click(object sender, EventArgs e)
        {
            if (reasonBox.Items.Count <= 0)
            {
                reasonBox.BeginUpdate();
                reasonBox.Items.Clear();
                project.Groups.ForEach((g) =>
                {
                    g.Record.ForEach((r) =>
                    {
                        if (!reasonBox.Items.Contains(r.Reason))
                        {
                            reasonBox.Items.Add(r.Reason);
                            reasonBox.Items.Add(r.Reason + "(" + r.Value + ")");
                        }
                    });
                });
                reasonBox.EndUpdate();
            }
        }

        private void ScoreForm_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!textBox.Text.StartsWith("0"))
            {
                textBox.Text += '0';
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            string reason = reasonBox.Text;
            if (reason.EndsWith(")"))
            {
                int a = reason.LastIndexOf('(');
                string substr = reason.Substring(a + 1, reason.Length - a - 2);
                long tryParse;
                if (long.TryParse(substr, out tryParse))
                {
                    reason = reason.Substring(0, a);
                }
            }
            ValueReturn = new Score(int.Parse(textBox.Text) * (negative ? -1 : 1), reason, target);
            target.Group.Record.Add(ValueReturn);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            if (text.Length > 1)
            {
                textBox.Text = text.Substring(0, text.Length - 1);
            } 
            else
            {
                textBox.Text = "0";
            }
        }

        private void darken(Control control)
        {
            control.BackColor = SystemColors.ControlDarkDark;
            control.ForeColor = SystemColors.ButtonHighlight;
        }

        private void lighten(Control control)
        {
            control.BackColor = SystemColors.ControlLight;
            control.ForeColor = SystemColors.ActiveCaptionText;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            lighten(sender as Control);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            darken(sender as Control);
        }

        private void OnNumber(object sender, EventArgs e)
        {
            char number = (sender as Control).Text[0];
            if (textBox.Text.Length >= 6)
                return;
            if (textBox.Text.StartsWith("0"))
            {
                if (number == '0')
                {
                    return;
                }
                else
                {
                    textBox.Text = number.ToString();
                }
            }
            else
            {
                textBox.Text += number;
            }
        }

        private bool negative = false;
        private void button11_Click(object sender, EventArgs e)
        {
            negative = !negative;
            button11.Text = negative ? "-" : "+";
        }

        private void reasonBox_Enter(object sender, EventArgs e)
        {
            Utility.ShowInputPanel();
        }

        private void reasonBox_Leave(object sender, EventArgs e)
        {
            Utility.HideInputPanel();
        }
    }
}
