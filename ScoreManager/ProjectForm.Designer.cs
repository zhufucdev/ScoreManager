namespace ScoreManager
{
    partial class ProjectForm
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
            this.components = new System.ComponentModel.Container();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.ComboBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.securityButton = new System.Windows.Forms.Button();
            this.securityPanel = new System.Windows.Forms.Panel();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.adminLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.securityPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameBox.Location = new System.Drawing.Point(12, 31);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(367, 23);
            this.nameBox.TabIndex = 0;
            this.nameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameLabel.Location = new System.Drawing.Point(12, 11);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(32, 17);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "名称";
            // 
            // fileBox
            // 
            this.fileBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileBox.FormattingEnabled = true;
            this.fileBox.Location = new System.Drawing.Point(12, 84);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(330, 25);
            this.fileBox.TabIndex = 2;
            this.fileBox.TextChanged += new System.EventHandler(this.FileBox_TextChanged);
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(348, 82);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(31, 27);
            this.fileButton.TabIndex = 3;
            this.fileButton.Text = "...";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileLabel.Location = new System.Drawing.Point(12, 64);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(32, 17);
            this.fileLabel.TabIndex = 4;
            this.fileLabel.Text = "文件";
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(223, 132);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 28);
            this.confirm.TabIndex = 5;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(304, 132);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 28);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // securityButton
            // 
            this.securityButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.securityButton.Location = new System.Drawing.Point(15, 132);
            this.securityButton.Name = "securityButton";
            this.securityButton.Size = new System.Drawing.Size(75, 28);
            this.securityButton.TabIndex = 7;
            this.securityButton.Text = "安全选项";
            this.securityButton.UseVisualStyleBackColor = true;
            this.securityButton.Click += new System.EventHandler(this.scurityButton_Click);
            // 
            // securityPanel
            // 
            this.securityPanel.Controls.Add(this.passwordBox);
            this.securityPanel.Controls.Add(this.adminLabel);
            this.securityPanel.Location = new System.Drawing.Point(12, 115);
            this.securityPanel.Name = "securityPanel";
            this.securityPanel.Size = new System.Drawing.Size(367, 50);
            this.securityPanel.TabIndex = 8;
            this.securityPanel.Visible = false;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(0, 26);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(364, 21);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.adminLabel.Location = new System.Drawing.Point(-3, 6);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(92, 17);
            this.adminLabel.TabIndex = 0;
            this.adminLabel.Text = "首要管理员密码";
            // 
            // ProjectForm
            // 
            this.AcceptButton = this.confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(391, 172);
            this.Controls.Add(this.securityButton);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.securityPanel);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameBox);
            this.Name = "ProjectForm";
            this.Text = "项目";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.securityPanel.ResumeLayout(false);
            this.securityPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox fileBox;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button securityButton;
        private System.Windows.Forms.Panel securityPanel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label adminLabel;
    }
}