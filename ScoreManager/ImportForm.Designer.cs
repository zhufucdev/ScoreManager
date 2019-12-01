namespace ScoreManager
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.infoLabel = new System.Windows.Forms.Label();
            this.doMember = new System.Windows.Forms.Button();
            this.doRecord = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.infoLabel.Location = new System.Drawing.Point(-4, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(167, 20);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "你想从%s导入什么数据？";
            // 
            // doMember
            // 
            this.doMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doMember.Location = new System.Drawing.Point(0, 35);
            this.doMember.Name = "doMember";
            this.doMember.Size = new System.Drawing.Size(297, 32);
            this.doMember.TabIndex = 1;
            this.doMember.Text = "成员分布";
            this.doMember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.doMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.doMember.UseVisualStyleBackColor = true;
            this.doMember.Click += new System.EventHandler(this.doMember_Click);
            // 
            // doRecord
            // 
            this.doRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doRecord.BackColor = System.Drawing.Color.Transparent;
            this.doRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.doRecord.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.doRecord.Location = new System.Drawing.Point(0, 73);
            this.doRecord.Name = "doRecord";
            this.doRecord.Size = new System.Drawing.Size(297, 32);
            this.doRecord.TabIndex = 2;
            this.doRecord.Text = "计分记录";
            this.doRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.doRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.doRecord.UseVisualStyleBackColor = false;
            this.doRecord.Click += new System.EventHandler(this.doRecord_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.infoLabel);
            this.panel1.Controls.Add(this.doRecord);
            this.panel1.Controls.Add(this.doMember);
            this.panel1.Location = new System.Drawing.Point(16, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 124);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.progressLabel);
            this.panel2.Location = new System.Drawing.Point(16, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 43);
            this.panel2.TabIndex = 4;
            this.panel2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(-3, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(43, 17);
            this.progressLabel.TabIndex = 0;
            this.progressLabel.Text = "label1";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 212);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button doMember;
        private System.Windows.Forms.Button doRecord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
    }
}