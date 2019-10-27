namespace ScoreManager
{
    partial class QuickIndexView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickIndexView));
            this.listView = new System.Windows.Forms.ListView();
            this.scoreBox = new System.Windows.Forms.NumericUpDown();
            this.confirm = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.reasonBox = new ScoreManager.View.AutoCompleteComboBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.nameBox = new ScoreManager.View.AutoCompleteComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(6, 22);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(444, 135);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // scoreBox
            // 
            this.scoreBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreBox.Location = new System.Drawing.Point(406, 163);
            this.scoreBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(44, 23);
            this.scoreBox.TabIndex = 2;
            this.scoreBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterPress);
            // 
            // confirm
            // 
            this.confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirm.Enabled = false;
            this.confirm.Location = new System.Drawing.Point(384, 202);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 3;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Enabled = false;
            this.remove.Location = new System.Drawing.Point(303, 202);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 4;
            this.remove.Text = "移除";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.reasonLabel);
            this.groupBox.Controls.Add(this.reasonBox);
            this.groupBox.Controls.Add(this.scoreLabel);
            this.groupBox.Controls.Add(this.listView);
            this.groupBox.Controls.Add(this.nameBox);
            this.groupBox.Controls.Add(this.scoreBox);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(456, 194);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "目标";
            // 
            // reasonLabel
            // 
            this.reasonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(88, 166);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(32, 17);
            this.reasonLabel.TabIndex = 5;
            this.reasonLabel.Text = "原因";
            // 
            // reasonBox
            // 
            this.reasonBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reasonBox.AutoCompleteOptions = ((System.Collections.Specialized.StringCollection)(resources.GetObject("reasonBox.AutoCompleteOptions")));
            this.reasonBox.FilterThreshold = 0.7F;
            this.reasonBox.FormattingEnabled = true;
            this.reasonBox.Location = new System.Drawing.Point(134, 161);
            this.reasonBox.Name = "reasonBox";
            this.reasonBox.Size = new System.Drawing.Size(221, 25);
            this.reasonBox.Sorted = true;
            this.reasonBox.TabIndex = 4;
            this.reasonBox.Enter += new System.EventHandler(this.Input_Focused);
            this.reasonBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterPress);
            this.reasonBox.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(361, 164);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(32, 17);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "分数";
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameBox.AutoCompleteOptions = ((System.Collections.Specialized.StringCollection)(resources.GetObject("nameBox.AutoCompleteOptions")));
            this.nameBox.FilterThreshold = 0.7F;
            this.nameBox.Location = new System.Drawing.Point(6, 163);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(76, 25);
            this.nameBox.TabIndex = 1;
            this.nameBox.Enter += new System.EventHandler(this.Input_Focused);
            this.nameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterPress);
            this.nameBox.Leave += new System.EventHandler(this.Input_Leave);
            // 
            // QuickIndexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.confirm);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuickIndexView";
            this.Size = new System.Drawing.Size(462, 228);
            this.Load += new System.EventHandler(this.QuickIndexView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scoreBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private View.AutoCompleteComboBox nameBox;
        private System.Windows.Forms.NumericUpDown scoreBox;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label reasonLabel;
        private View.AutoCompleteComboBox reasonBox;
    }
}
