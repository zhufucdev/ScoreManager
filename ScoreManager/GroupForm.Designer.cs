namespace ScoreManager
{
    partial class GroupForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.initalScoreLabel = new System.Windows.Forms.Label();
            this.initalScoreBox = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.memberGroupBox = new System.Windows.Forms.GroupBox();
            this.memberList = new System.Windows.Forms.ListView();
            this.cancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.memberGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(32, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "名称";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameBox.Location = new System.Drawing.Point(12, 29);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(401, 23);
            this.nameBox.TabIndex = 1;
            // 
            // initalScoreLabel
            // 
            this.initalScoreLabel.AutoSize = true;
            this.initalScoreLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.initalScoreLabel.Location = new System.Drawing.Point(12, 61);
            this.initalScoreLabel.Name = "initalScoreLabel";
            this.initalScoreLabel.Size = new System.Drawing.Size(56, 17);
            this.initalScoreLabel.TabIndex = 2;
            this.initalScoreLabel.Text = "初始分数";
            // 
            // initalScoreBox
            // 
            this.initalScoreBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.initalScoreBox.Location = new System.Drawing.Point(12, 81);
            this.initalScoreBox.Name = "initalScoreBox";
            this.initalScoreBox.Size = new System.Drawing.Size(401, 23);
            this.initalScoreBox.TabIndex = 3;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(312, 178);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 31);
            this.add.TabIndex = 6;
            this.add.Text = "添加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.Add_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(228, 178);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 31);
            this.remove.TabIndex = 7;
            this.remove.Text = "移除";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(255, 352);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 28);
            this.confirm.TabIndex = 8;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // memberGroupBox
            // 
            this.memberGroupBox.Controls.Add(this.memberList);
            this.memberGroupBox.Controls.Add(this.add);
            this.memberGroupBox.Controls.Add(this.remove);
            this.memberGroupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.memberGroupBox.Location = new System.Drawing.Point(12, 121);
            this.memberGroupBox.Name = "memberGroupBox";
            this.memberGroupBox.Size = new System.Drawing.Size(399, 220);
            this.memberGroupBox.TabIndex = 9;
            this.memberGroupBox.TabStop = false;
            this.memberGroupBox.Text = "成员";
            // 
            // memberList
            // 
            this.memberList.HideSelection = false;
            this.memberList.Location = new System.Drawing.Point(15, 22);
            this.memberList.Name = "memberList";
            this.memberList.Size = new System.Drawing.Size(372, 150);
            this.memberList.TabIndex = 9;
            this.memberList.UseCompatibleStateImageBehavior = false;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(336, 352);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 28);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // GroupForm
            // 
            this.AcceptButton = this.confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(425, 389);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.memberGroupBox);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.initalScoreBox);
            this.Controls.Add(this.initalScoreLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GroupForm";
            this.Text = "小组属性";
            this.Load += new System.EventHandler(this.GroupForm_Load);
            this.memberGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label initalScoreLabel;
        private System.Windows.Forms.TextBox initalScoreBox;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.GroupBox memberGroupBox;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ListView memberList;
    }
}