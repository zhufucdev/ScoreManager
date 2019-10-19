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
        public Score ValueReturn;
        public ScoreForm(Person target)
        {
            this.target = target;

            InitializeComponent();
            ResourceController.ApplySource(this);
            StartPosition = FormStartPosition.CenterParent;
            
            targetLabel.Text = new ResourceManager(typeof(ScoreForm)).GetString("target", System.Threading.Thread.CurrentThread.CurrentUICulture).Replace("%s1", target.Group.Name).Replace("%s2", target.Name);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
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
            ValueReturn = new Score(int.Parse(textBox.Text) * (negative ? -1 : 1), reasonBox.Text, target);
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
    }
}
