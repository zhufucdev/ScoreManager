namespace ScoreManager
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScoreboardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.projectProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.addMember = new System.Windows.Forms.ToolStripMenuItem();
            this.recordScore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.validate = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autostartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProject = new System.Windows.Forms.Button();
            this.recent = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.readyStatusLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.startPanel = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.projectPanel = new System.Windows.Forms.TableLayoutPanel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.adminBox = new System.Windows.Forms.ComboBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.viewToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickIndexItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.startPanel.SuspendLayout();
            this.projectPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.editToolStripMenuItem,
            this.viewToolStripItem,
            this.settingsItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // file
            // 
            this.file.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.projectProperties});
            this.file.Name = "file";
            resources.ApplyResources(this.file, "file");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.newScoreboardItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            resources.ApplyResources(this.projectToolStripMenuItem, "projectToolStripMenuItem");
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.New_Project);
            // 
            // newScoreboardItem
            // 
            this.newScoreboardItem.Name = "newScoreboardItem";
            resources.ApplyResources(this.newScoreboardItem, "newScoreboardItem");
            this.newScoreboardItem.Click += new System.EventHandler(this.newScoreboardItem_Click);
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            resources.ApplyResources(this.openItem, "openItem");
            this.openItem.Click += new System.EventHandler(this.openItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // projectProperties
            // 
            this.projectProperties.Name = "projectProperties";
            resources.ApplyResources(this.projectProperties, "projectProperties");
            this.projectProperties.Click += new System.EventHandler(this.projectProperties_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoMenuItem,
            this.redoMenuItem,
            this.toolStripSeparator2,
            this.addGroup,
            this.addMember,
            this.recordScore,
            this.toolStripSeparator3,
            this.validate});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Name = "undoMenuItem";
            resources.ApplyResources(this.undoMenuItem, "undoMenuItem");
            this.undoMenuItem.Click += new System.EventHandler(this.undoMenuItem_Click);
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Name = "redoMenuItem";
            resources.ApplyResources(this.redoMenuItem, "redoMenuItem");
            this.redoMenuItem.Click += new System.EventHandler(this.redoMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // addGroup
            // 
            this.addGroup.Name = "addGroup";
            resources.ApplyResources(this.addGroup, "addGroup");
            this.addGroup.Click += new System.EventHandler(this.AddGroup_Click);
            // 
            // addMember
            // 
            this.addMember.Name = "addMember";
            resources.ApplyResources(this.addMember, "addMember");
            this.addMember.Click += new System.EventHandler(this.AddMember_Click);
            // 
            // recordScore
            // 
            this.recordScore.Name = "recordScore";
            resources.ApplyResources(this.recordScore, "recordScore");
            this.recordScore.Click += new System.EventHandler(this.RecordScore_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // validate
            // 
            this.validate.Name = "validate";
            resources.ApplyResources(this.validate, "validate");
            this.validate.Click += new System.EventHandler(this.validate_Click);
            // 
            // settingsItem
            // 
            this.settingsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageItem,
            this.autostartItem});
            this.settingsItem.Name = "settingsItem";
            resources.ApplyResources(this.settingsItem, "settingsItem");
            // 
            // languageItem
            // 
            this.languageItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chineseItem,
            this.englishItem});
            this.languageItem.Name = "languageItem";
            resources.ApplyResources(this.languageItem, "languageItem");
            // 
            // chineseItem
            // 
            this.chineseItem.Name = "chineseItem";
            resources.ApplyResources(this.chineseItem, "chineseItem");
            this.chineseItem.Click += new System.EventHandler(this.chineseItem_Click);
            // 
            // englishItem
            // 
            this.englishItem.Name = "englishItem";
            resources.ApplyResources(this.englishItem, "englishItem");
            this.englishItem.Click += new System.EventHandler(this.englishItem_Click);
            // 
            // autostartItem
            // 
            this.autostartItem.Name = "autostartItem";
            resources.ApplyResources(this.autostartItem, "autostartItem");
            this.autostartItem.Click += new System.EventHandler(this.autostartItem_Click);
            // 
            // newProject
            // 
            resources.ApplyResources(this.newProject, "newProject");
            this.newProject.Name = "newProject";
            this.newProject.UseVisualStyleBackColor = true;
            this.newProject.Click += new System.EventHandler(this.New_Project);
            // 
            // recent
            // 
            resources.ApplyResources(this.recent, "recent");
            this.recent.Name = "recent";
            this.recent.UseVisualStyleBackColor = true;
            this.recent.Click += new System.EventHandler(this.Recent_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readyStatusLable});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // readyStatusLable
            // 
            this.readyStatusLable.Name = "readyStatusLable";
            resources.ApplyResources(this.readyStatusLable, "readyStatusLable");
            // 
            // startPanel
            // 
            this.startPanel.Controls.Add(this.recent);
            this.startPanel.Controls.Add(this.newProject);
            resources.ApplyResources(this.startPanel, "startPanel");
            this.startPanel.Name = "startPanel";
            // 
            // listView
            // 
            resources.ApplyResources(this.listView, "listView");
            this.listView.HideSelection = false;
            this.listView.Name = "listView";
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // projectPanel
            // 
            resources.ApplyResources(this.projectPanel, "projectPanel");
            this.projectPanel.Controls.Add(this.listView, 0, 0);
            this.projectPanel.Controls.Add(this.infoPanel, 1, 0);
            this.projectPanel.Name = "projectPanel";
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.chart);
            resources.ApplyResources(this.infoPanel, "infoPanel");
            this.infoPanel.Name = "infoPanel";
            // 
            // chart
            // 
            resources.ApplyResources(this.chart, "chart");
            this.chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Cursor = System.Windows.Forms.Cursors.Default;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            // 
            // adminBox
            // 
            resources.ApplyResources(this.adminBox, "adminBox");
            this.adminBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adminBox.FormattingEnabled = true;
            this.adminBox.Name = "adminBox";
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // viewToolStripItem
            // 
            this.viewToolStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overviewItem,
            this.quickIndexItem});
            this.viewToolStripItem.Name = "viewToolStripItem";
            resources.ApplyResources(this.viewToolStripItem, "viewToolStripItem");
            // 
            // overviewItem
            // 
            resources.ApplyResources(this.overviewItem, "overviewItem");
            this.overviewItem.Name = "overviewItem";
            this.overviewItem.Click += new System.EventHandler(this.overviewItem_Click);
            // 
            // quickIndexItem
            // 
            resources.ApplyResources(this.quickIndexItem, "quickIndexItem");
            this.quickIndexItem.Name = "quickIndexItem";
            this.quickIndexItem.Click += new System.EventHandler(this.quickIndexItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.adminBox);
            this.Controls.Add(this.projectPanel);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.startPanel.ResumeLayout(false);
            this.projectPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.Button newProject;
        private System.Windows.Forms.Button recent;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel readyStatusLable;
        private System.Windows.Forms.Panel startPanel;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGroup;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMember;
        private System.Windows.Forms.ToolStripMenuItem recordScore;
        private System.Windows.Forms.ToolStripMenuItem validate;
        private System.Windows.Forms.ToolStripMenuItem projectProperties;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TableLayoutPanel projectPanel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newScoreboardItem;
        private System.Windows.Forms.ToolStripMenuItem settingsItem;
        private System.Windows.Forms.ToolStripMenuItem languageItem;
        private System.Windows.Forms.ToolStripMenuItem chineseItem;
        private System.Windows.Forms.ToolStripMenuItem englishItem;
        private System.Windows.Forms.ComboBox adminBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem autostartItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem overviewItem;
        private System.Windows.Forms.ToolStripMenuItem quickIndexItem;
    }
}

