﻿namespace ScoreManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScoreboardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.addMember = new System.Windows.Forms.ToolStripMenuItem();
            this.recordScore = new System.Windows.Forms.ToolStripMenuItem();
            this.validate = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProject = new System.Windows.Forms.Button();
            this.recent = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.readyStatusLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.startPanel = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.projectPanel = new System.Windows.Forms.TableLayoutPanel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.englishItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.settingsItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // file
            // 
            this.file.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
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
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
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
            this.addGroup,
            this.addMember,
            this.recordScore,
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
            // validate
            // 
            this.validate.Name = "validate";
            resources.ApplyResources(this.validate, "validate");
            this.validate.Click += new System.EventHandler(this.validate_Click);
            // 
            // settingsItem
            // 
            this.settingsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageItem});
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
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            // 
            // englishItem
            // 
            this.englishItem.Name = "englishItem";
            resources.ApplyResources(this.englishItem, "englishItem");
            this.englishItem.Click += new System.EventHandler(this.englishItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.projectPanel);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
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
    }
}

