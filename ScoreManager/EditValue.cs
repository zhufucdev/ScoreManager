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
    public partial class EditValue : Form
    {
        public bool CheckEmpty = false;
        public string ValueReturn;
        public EditValue(string type, bool password = false)
        {
            InitializeComponent();
            typeLabel.Text = type;
            textBox1.UseSystemPasswordChar = password;
            StartPosition = FormStartPosition.CenterParent;
            ResourceController.ApplySource(this);
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (CheckEmpty && textBox1.Text == "")
            {
                errorProvider.SetError(typeLabel, new ComponentResourceManager(typeof(EditValue)).GetString("error.Empty"));
                SystemSounds.Beep.Play();
                textBox1.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            ValueReturn = textBox1.Text;
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
