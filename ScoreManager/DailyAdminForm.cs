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
    public partial class DailyAdminForm : Form
    {
        public DailyAdmin ValueReturn;
        private bool AddMode = true;
        public DailyAdminForm()
        {
            InitializeComponent();
            Utility.ApplySource(this);
        }

        public DailyAdminForm(DailyAdmin admin)
        {
            InitializeComponent();
            Utility.ApplySource(this);
            ValueReturn = admin;
            AddMode = false;

            nameBox.Text = admin.Name;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            ComponentResourceManager res = new ComponentResourceManager(typeof(DailyAdminForm));
            if (nameBox.Text == "")
            {
                errorProvider.SetError(nameLabel, res.GetString("error.EmptyName"));
                nameBox.Focus();
                SystemSounds.Beep.Play();
                return;
            }
            if (AddMode && passwordBox.Text == "")
            {
                errorProvider.SetError(passwordLabel, res.GetString("error.EmptyName"));
                passwordLabel.Focus();
                SystemSounds.Beep.Play();
                return;
            }
            DialogResult = DialogResult.OK;
            if (AddMode)
                ValueReturn = new DailyAdmin(nameBox.Text, passwordBox.Text);
            else
            {
                ValueReturn.Name = nameBox.Text;
                if (passwordBox.Text != "")
                    ValueReturn.ChangePassword(passwordBox.Text);
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
