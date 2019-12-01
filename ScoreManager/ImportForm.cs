using ScoreManager.Properties;
using ScoreManager.Statics;
using ScoreManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ScoreManager.Statics.Project;

namespace ScoreManager
{
    public partial class ImportForm : Form
    {
        private readonly ProjectImporter importer = new ProjectImporter();
        private readonly Project from, to;
        public ImportForm(Project from, Project to)
        {
            this.from = from;
            this.to = to;

            InitializeComponent();
            panel2.Top = 11;
            Height = 167;

            Utility.ApplySource(this);

            var res = new ComponentResourceManager(typeof(ImportForm));
            infoLabel.Text = res.GetString("infoLabel.Text").Replace("%s", from.Name);

            importer.GroupDuplicated += (object first, object second) =>
            {
                return MessageBox.Show(res.GetString("warn.DuplicatedGroup").Replace("%s", ((Group)first).Name), res.GetString("warn"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            };
            importer.MemberDuplicated += (object first, object second) =>
            {
                return MessageBox.Show(res.GetString("warn.DuplicatedPerson").Replace("%s", ((Person)first).Name), res.GetString("warn"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            };
            importer.ProgressChanged += Importer_ProgressChanged;
        }
        private bool showPanel1 = true;
        private void Importer_ProgressChanged(float percentage)
        {
            if (showPanel1)
            {
                showPanel1 = false;

                panel1.Visible = false;
                panel2.Top = 12;
                panel2.Visible = true;

                var animator = Animator.OfInt(167, 67);
                animator.Duration = 300;
                animator.Action = (v) => Height = (int)v;
                animator.Start();
            }
            progressBar1.Value = (int) Math.Round(progressBar1.Maximum * percentage);
        }

        private void doRecord_Click(object sender, EventArgs e)
        {
            importer.Import(to, from, ProjectImporter.Mode.Record);
            Close();
        }

        private void doMember_Click(object sender, EventArgs e)
        {
            importer.Import(to, from, ProjectImporter.Mode.Group);
            Close();
        }
    }
}
