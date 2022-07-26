namespace Setup
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.labelLocation = new System.Windows.Forms.Label();
            this.textLocation = new System.Windows.Forms.TextBox();
            this.buttonLocation = new System.Windows.Forms.Button();
            this.checkDesktopIcon = new System.Windows.Forms.CheckBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelOverwrite = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(47, 45);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(230, 31);
            this.labelLocation.TabIndex = 0;
            this.labelLocation.Text = "将安装至以下位置：";
            // 
            // textLocation
            // 
            this.textLocation.Location = new System.Drawing.Point(47, 103);
            this.textLocation.Name = "textLocation";
            this.textLocation.ReadOnly = true;
            this.textLocation.Size = new System.Drawing.Size(609, 38);
            this.textLocation.TabIndex = 1;
            // 
            // buttonLocation
            // 
            this.buttonLocation.Location = new System.Drawing.Point(662, 98);
            this.buttonLocation.Name = "buttonLocation";
            this.buttonLocation.Size = new System.Drawing.Size(98, 46);
            this.buttonLocation.TabIndex = 2;
            this.buttonLocation.Text = "...";
            this.buttonLocation.UseVisualStyleBackColor = true;
            this.buttonLocation.Click += new System.EventHandler(this.buttonLocation_Click);
            // 
            // checkDesktopIcon
            // 
            this.checkDesktopIcon.AutoSize = true;
            this.checkDesktopIcon.Checked = true;
            this.checkDesktopIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDesktopIcon.Location = new System.Drawing.Point(47, 177);
            this.checkDesktopIcon.Name = "checkDesktopIcon";
            this.checkDesktopIcon.Size = new System.Drawing.Size(238, 35);
            this.checkDesktopIcon.TabIndex = 3;
            this.checkDesktopIcon.Text = "创建桌面快捷方式";
            this.checkDesktopIcon.UseVisualStyleBackColor = true;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Location = new System.Drawing.Point(610, 227);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(150, 46);
            this.buttonInstall.TabIndex = 4;
            this.buttonInstall.Text = "确定";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "选择安装位置";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.ProgramFiles;
            // 
            // labelOverwrite
            // 
            this.labelOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOverwrite.AutoSize = true;
            this.labelOverwrite.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelOverwrite.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelOverwrite.Location = new System.Drawing.Point(47, 227);
            this.labelOverwrite.Name = "labelOverwrite";
            this.labelOverwrite.Size = new System.Drawing.Size(182, 31);
            this.labelOverwrite.TabIndex = 5;
            this.labelOverwrite.Text = "将覆盖已有文件";
            this.labelOverwrite.Visible = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.labelOverwrite);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.checkDesktopIcon);
            this.Controls.Add(this.buttonLocation);
            this.Controls.Add(this.textLocation);
            this.Controls.Add(this.labelLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "安装计分管理器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelLocation;
        private TextBox textLocation;
        private Button buttonLocation;
        private CheckBox checkDesktopIcon;
        private Button buttonInstall;
        private FolderBrowserDialog folderBrowserDialog;
        private Label labelOverwrite;
    }
}