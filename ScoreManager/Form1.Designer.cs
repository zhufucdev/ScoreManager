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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonMain = new System.Windows.Forms.Ribbon();
            this.openItem = new System.Windows.Forms.RibbonOrbMenuItem();
            this.createItem = new System.Windows.Forms.RibbonOrbMenuItem();
            this.createProjectItem = new System.Windows.Forms.RibbonButton();
            this.createScoreboardItem = new System.Windows.Forms.RibbonButton();
            this.importItem = new System.Windows.Forms.RibbonOrbMenuItem();
            this.fileOptionSeparator = new System.Windows.Forms.RibbonSeparator();
            this.projectProperties = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButtonRedo = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonSave = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonUndo = new System.Windows.Forms.RibbonButton();
            this.editTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.recordScore = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.addMember = new System.Windows.Forms.RibbonButton();
            this.addGroup = new System.Windows.Forms.RibbonButton();
            this.properties = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.validate = new System.Windows.Forms.RibbonButton();
            this.adminBox = new System.Windows.Forms.RibbonComboBox();
            this.viewTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.overviewItem = new System.Windows.Forms.RibbonButton();
            this.quickIndexItem = new System.Windows.Forms.RibbonButton();
            this.settingsItem = new System.Windows.Forms.RibbonTab();
            this.languageItem = new System.Windows.Forms.RibbonPanel();
            this.chineseItem = new System.Windows.Forms.RibbonButton();
            this.englishItem = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.autostartItem = new System.Windows.Forms.RibbonButton();
            this.scoreboardPanel = new System.Windows.Forms.RibbonPanel();
            this.newScoreboardButton = new System.Windows.Forms.RibbonButton();
            this.labelStart = new System.Windows.Forms.Label();
            this.startPanel = new System.Windows.Forms.Panel();
            this.labelHint = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.readyStatusLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.projectPanel = new System.Windows.Forms.SplitContainer();
            this.listView = new System.Windows.Forms.ListView();
            this.splitContainerH = new System.Windows.Forms.SplitContainer();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.recordListView = new System.Windows.Forms.ListView();
            this.startPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectPanel)).BeginInit();
            this.projectPanel.Panel1.SuspendLayout();
            this.projectPanel.Panel2.SuspendLayout();
            this.projectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerH)).BeginInit();
            this.splitContainerH.Panel1.SuspendLayout();
            this.splitContainerH.Panel2.SuspendLayout();
            this.splitContainerH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            resources.ApplyResources(this.ribbonTab1, "ribbonTab1");
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            resources.ApplyResources(this.ribbonButton2, "ribbonButton2");
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            resources.ApplyResources(this.ribbonButton3, "ribbonButton3");
            // 
            // ribbonMain
            // 
            this.ribbonMain.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.ribbonMain, "ribbonMain");
            this.ribbonMain.Minimized = false;
            this.ribbonMain.Name = "ribbonMain";
            // 
            // 
            // 
            this.ribbonMain.OrbDropDown.BorderRoundness = 8;
            this.ribbonMain.OrbDropDown.Location = ((System.Drawing.Point)(resources.GetObject("ribbonMain.OrbDropDown.Location")));
            this.ribbonMain.OrbDropDown.MenuItems.Add(this.openItem);
            this.ribbonMain.OrbDropDown.MenuItems.Add(this.createItem);
            this.ribbonMain.OrbDropDown.MenuItems.Add(this.importItem);
            this.ribbonMain.OrbDropDown.MenuItems.Add(this.fileOptionSeparator);
            this.ribbonMain.OrbDropDown.MenuItems.Add(this.projectProperties);
            this.ribbonMain.OrbDropDown.Name = "";
            this.ribbonMain.OrbDropDown.Size = ((System.Drawing.Size)(resources.GetObject("ribbonMain.OrbDropDown.Size")));
            this.ribbonMain.OrbDropDown.TabIndex = ((int)(resources.GetObject("ribbonMain.OrbDropDown.TabIndex")));
            this.ribbonMain.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbonMain.OrbText = "文件";
            // 
            // 
            // 
            this.ribbonMain.QuickAccessToolbar.DropDownButtonItems.Add(this.ribbonButtonRedo);
            this.ribbonMain.QuickAccessToolbar.Items.Add(this.ribbonButtonSave);
            this.ribbonMain.QuickAccessToolbar.Items.Add(this.ribbonButtonUndo);
            this.ribbonMain.RibbonTabFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonMain.Tabs.Add(this.editTab);
            this.ribbonMain.Tabs.Add(this.viewTab);
            this.ribbonMain.Tabs.Add(this.settingsItem);
            this.ribbonMain.TabSpacing = 4;
            this.ribbonMain.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // openItem
            // 
            this.openItem.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.openItem.Image = global::ScoreManager.Properties.Resources.icons8_opened_folder_30;
            this.openItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_opened_folder_30;
            this.openItem.Name = "openItem";
            this.openItem.SmallImage = global::ScoreManager.Properties.Resources.icons8_opened_folder_30;
            resources.ApplyResources(this.openItem, "openItem");
            this.openItem.Click += new System.EventHandler(this.openItem_Click);
            // 
            // createItem
            // 
            this.createItem.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Right;
            this.createItem.DropDownItems.Add(this.createProjectItem);
            this.createItem.DropDownItems.Add(this.createScoreboardItem);
            this.createItem.Image = global::ScoreManager.Properties.Resources.icons8_create_30;
            this.createItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_create_30;
            this.createItem.Name = "createItem";
            this.createItem.SmallImage = global::ScoreManager.Properties.Resources.icons8_create_30;
            resources.ApplyResources(this.createItem, "createItem");
            this.createItem.Click += new System.EventHandler(this.New_Project);
            // 
            // createProjectItem
            // 
            this.createProjectItem.Image = ((System.Drawing.Image)(resources.GetObject("createProjectItem.Image")));
            this.createProjectItem.LargeImage = ((System.Drawing.Image)(resources.GetObject("createProjectItem.LargeImage")));
            this.createProjectItem.Name = "createProjectItem";
            this.createProjectItem.SmallImage = global::ScoreManager.Properties.Resources.icons8_add_folder_40;
            resources.ApplyResources(this.createProjectItem, "createProjectItem");
            // 
            // createScoreboardItem
            // 
            this.createScoreboardItem.Image = ((System.Drawing.Image)(resources.GetObject("createScoreboardItem.Image")));
            this.createScoreboardItem.LargeImage = ((System.Drawing.Image)(resources.GetObject("createScoreboardItem.LargeImage")));
            this.createScoreboardItem.Name = "createScoreboardItem";
            this.createScoreboardItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("createScoreboardItem.SmallImage")));
            resources.ApplyResources(this.createScoreboardItem, "createScoreboardItem");
            // 
            // importItem
            // 
            this.importItem.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.importItem.Enabled = false;
            this.importItem.Image = global::ScoreManager.Properties.Resources.icons8_import_30;
            this.importItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_import_30;
            this.importItem.Name = "importItem";
            this.importItem.SmallImage = global::ScoreManager.Properties.Resources.icons8_import_30;
            resources.ApplyResources(this.importItem, "importItem");
            this.importItem.Click += new System.EventHandler(this.importItem_Click);
            // 
            // fileOptionSeparator
            // 
            this.fileOptionSeparator.Name = "fileOptionSeparator";
            // 
            // projectProperties
            // 
            this.projectProperties.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.projectProperties.Enabled = false;
            this.projectProperties.Image = global::ScoreManager.Properties.Resources.icons8_edit_property_30;
            this.projectProperties.LargeImage = global::ScoreManager.Properties.Resources.icons8_edit_property_30;
            this.projectProperties.Name = "projectProperties";
            this.projectProperties.SmallImage = global::ScoreManager.Properties.Resources.icons8_edit_property_30;
            resources.ApplyResources(this.projectProperties, "projectProperties");
            this.projectProperties.Click += new System.EventHandler(this.projectProperties_Click);
            // 
            // ribbonButtonRedo
            // 
            this.ribbonButtonRedo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonButtonRedo.Enabled = false;
            this.ribbonButtonRedo.Image = global::ScoreManager.Properties.Resources.icons8_redo_80;
            this.ribbonButtonRedo.LargeImage = global::ScoreManager.Properties.Resources.icons8_redo_80;
            this.ribbonButtonRedo.Name = "ribbonButtonRedo";
            this.ribbonButtonRedo.SmallImage = global::ScoreManager.Properties.Resources.icons8_redo_16;
            resources.ApplyResources(this.ribbonButtonRedo, "ribbonButtonRedo");
            this.ribbonButtonRedo.Click += new System.EventHandler(this.redoMenuItem_Click);
            // 
            // ribbonButtonSave
            // 
            this.ribbonButtonSave.Enabled = false;
            this.ribbonButtonSave.Image = global::ScoreManager.Properties.Resources.icons8_save_80;
            this.ribbonButtonSave.LargeImage = global::ScoreManager.Properties.Resources.icons8_save_80;
            this.ribbonButtonSave.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonSave.Name = "ribbonButtonSave";
            this.ribbonButtonSave.SmallImage = global::ScoreManager.Properties.Resources.icons8_save_16;
            resources.ApplyResources(this.ribbonButtonSave, "ribbonButtonSave");
            this.ribbonButtonSave.Click += new System.EventHandler(this.ribbonButtonSave_Click);
            // 
            // ribbonButtonUndo
            // 
            this.ribbonButtonUndo.Enabled = false;
            this.ribbonButtonUndo.Image = global::ScoreManager.Properties.Resources.icons8_undo_80__1_;
            this.ribbonButtonUndo.LargeImage = global::ScoreManager.Properties.Resources.icons8_undo_80__1_;
            this.ribbonButtonUndo.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButtonUndo.Name = "ribbonButtonUndo";
            this.ribbonButtonUndo.SmallImage = global::ScoreManager.Properties.Resources.icons8_undo_16;
            resources.ApplyResources(this.ribbonButtonUndo, "ribbonButtonUndo");
            this.ribbonButtonUndo.Click += new System.EventHandler(this.undoMenuItem_Click);
            // 
            // editTab
            // 
            this.editTab.Enabled = false;
            this.editTab.Name = "editTab";
            this.editTab.Panels.Add(this.ribbonPanel2);
            this.editTab.Panels.Add(this.ribbonPanel4);
            this.editTab.Panels.Add(this.ribbonPanel5);
            resources.ApplyResources(this.editTab, "editTab");
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Enabled = false;
            this.ribbonPanel2.Items.Add(this.recordScore);
            this.ribbonPanel2.Name = "ribbonPanel2";
            resources.ApplyResources(this.ribbonPanel2, "ribbonPanel2");
            // 
            // recordScore
            // 
            this.recordScore.Enabled = false;
            this.recordScore.Image = global::ScoreManager.Properties.Resources.icons8_add_to_favorites_40;
            this.recordScore.LargeImage = global::ScoreManager.Properties.Resources.icons8_add_to_favorites_40;
            this.recordScore.Name = "recordScore";
            this.recordScore.SmallImage = ((System.Drawing.Image)(resources.GetObject("recordScore.SmallImage")));
            resources.ApplyResources(this.recordScore, "recordScore");
            this.recordScore.Click += new System.EventHandler(this.RecordScoreMenuClickHandler);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Enabled = false;
            this.ribbonPanel4.Items.Add(this.addMember);
            this.ribbonPanel4.Items.Add(this.addGroup);
            this.ribbonPanel4.Items.Add(this.properties);
            this.ribbonPanel4.Name = "ribbonPanel4";
            resources.ApplyResources(this.ribbonPanel4, "ribbonPanel4");
            // 
            // addMember
            // 
            this.addMember.Enabled = false;
            this.addMember.Image = global::ScoreManager.Properties.Resources.icons8_add_user_male_40;
            this.addMember.LargeImage = global::ScoreManager.Properties.Resources.icons8_add_user_male_40;
            this.addMember.Name = "addMember";
            this.addMember.SmallImage = ((System.Drawing.Image)(resources.GetObject("addMember.SmallImage")));
            resources.ApplyResources(this.addMember, "addMember");
            this.addMember.Click += new System.EventHandler(this.AddMember_Click);
            // 
            // addGroup
            // 
            this.addGroup.Enabled = false;
            this.addGroup.Image = global::ScoreManager.Properties.Resources.icons8_add_folder_40;
            this.addGroup.LargeImage = global::ScoreManager.Properties.Resources.icons8_add_folder_40;
            this.addGroup.Name = "addGroup";
            this.addGroup.SmallImage = ((System.Drawing.Image)(resources.GetObject("addGroup.SmallImage")));
            resources.ApplyResources(this.addGroup, "addGroup");
            this.addGroup.Click += new System.EventHandler(this.AddGroup_Click);
            // 
            // properties
            // 
            this.properties.Enabled = false;
            this.properties.Image = global::ScoreManager.Properties.Resources.icons8_edit_property_40;
            this.properties.LargeImage = global::ScoreManager.Properties.Resources.icons8_edit_property_40;
            this.properties.Name = "properties";
            this.properties.SmallImage = ((System.Drawing.Image)(resources.GetObject("properties.SmallImage")));
            resources.ApplyResources(this.properties, "properties");
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Enabled = false;
            this.ribbonPanel5.Items.Add(this.validate);
            this.ribbonPanel5.Items.Add(this.adminBox);
            this.ribbonPanel5.Name = "ribbonPanel5";
            resources.ApplyResources(this.ribbonPanel5, "ribbonPanel5");
            // 
            // validate
            // 
            this.validate.Enabled = false;
            this.validate.Image = global::ScoreManager.Properties.Resources.icons8_access_40;
            this.validate.LargeImage = global::ScoreManager.Properties.Resources.icons8_access_40;
            this.validate.Name = "validate";
            this.validate.SmallImage = ((System.Drawing.Image)(resources.GetObject("validate.SmallImage")));
            resources.ApplyResources(this.validate, "validate");
            this.validate.Click += new System.EventHandler(this.validate_Click);
            // 
            // adminBox
            // 
            this.adminBox.AllowTextEdit = false;
            this.adminBox.DrawIconsBar = false;
            this.adminBox.Name = "adminBox";
            this.adminBox.SelectedIndex = -1;
            this.adminBox.TextBoxText = "";
            // 
            // viewTab
            // 
            this.viewTab.Enabled = false;
            this.viewTab.Name = "viewTab";
            this.viewTab.Panels.Add(this.ribbonPanel3);
            resources.ApplyResources(this.viewTab, "viewTab");
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Enabled = false;
            this.ribbonPanel3.Items.Add(this.overviewItem);
            this.ribbonPanel3.Items.Add(this.quickIndexItem);
            this.ribbonPanel3.Name = "ribbonPanel3";
            resources.ApplyResources(this.ribbonPanel3, "ribbonPanel3");
            // 
            // overviewItem
            // 
            this.overviewItem.Image = global::ScoreManager.Properties.Resources.icons8_overview_40;
            this.overviewItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_overview_40;
            this.overviewItem.Name = "overviewItem";
            this.overviewItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("overviewItem.SmallImage")));
            resources.ApplyResources(this.overviewItem, "overviewItem");
            this.overviewItem.Click += new System.EventHandler(this.overviewItem_Click);
            // 
            // quickIndexItem
            // 
            this.quickIndexItem.Image = global::ScoreManager.Properties.Resources.icons8_search_40;
            this.quickIndexItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_search_40;
            this.quickIndexItem.Name = "quickIndexItem";
            this.quickIndexItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("quickIndexItem.SmallImage")));
            resources.ApplyResources(this.quickIndexItem, "quickIndexItem");
            this.quickIndexItem.Click += new System.EventHandler(this.quickIndexItem_Click);
            // 
            // settingsItem
            // 
            this.settingsItem.Name = "settingsItem";
            this.settingsItem.Panels.Add(this.languageItem);
            this.settingsItem.Panels.Add(this.ribbonPanel6);
            this.settingsItem.Panels.Add(this.scoreboardPanel);
            resources.ApplyResources(this.settingsItem, "settingsItem");
            // 
            // languageItem
            // 
            this.languageItem.Items.Add(this.chineseItem);
            this.languageItem.Items.Add(this.englishItem);
            this.languageItem.Name = "languageItem";
            resources.ApplyResources(this.languageItem, "languageItem");
            // 
            // chineseItem
            // 
            this.chineseItem.Image = global::ScoreManager.Properties.Resources.icons8_china_40;
            this.chineseItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_china_40;
            this.chineseItem.Name = "chineseItem";
            this.chineseItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("chineseItem.SmallImage")));
            resources.ApplyResources(this.chineseItem, "chineseItem");
            this.chineseItem.Click += new System.EventHandler(this.chineseItem_Click);
            // 
            // englishItem
            // 
            this.englishItem.Image = global::ScoreManager.Properties.Resources.icons8_great_britain_40;
            this.englishItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_great_britain_40;
            this.englishItem.Name = "englishItem";
            this.englishItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("englishItem.SmallImage")));
            resources.ApplyResources(this.englishItem, "englishItem");
            this.englishItem.Click += new System.EventHandler(this.englishItem_Click);
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.autostartItem);
            this.ribbonPanel6.Name = "ribbonPanel6";
            resources.ApplyResources(this.ribbonPanel6, "ribbonPanel6");
            // 
            // autostartItem
            // 
            this.autostartItem.Image = global::ScoreManager.Properties.Resources.icons8_flash_auto_40;
            this.autostartItem.LargeImage = global::ScoreManager.Properties.Resources.icons8_flash_auto_40;
            this.autostartItem.Name = "autostartItem";
            this.autostartItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("autostartItem.SmallImage")));
            resources.ApplyResources(this.autostartItem, "autostartItem");
            this.autostartItem.Click += new System.EventHandler(this.autostartItem_Click);
            // 
            // scoreboardPanel
            // 
            this.scoreboardPanel.Items.Add(this.newScoreboardButton);
            this.scoreboardPanel.Name = "scoreboardPanel";
            resources.ApplyResources(this.scoreboardPanel, "scoreboardPanel");
            // 
            // newScoreboardButton
            // 
            this.newScoreboardButton.Image = global::ScoreManager.Properties.Resources.icons8_create_40;
            this.newScoreboardButton.LargeImage = global::ScoreManager.Properties.Resources.icons8_create_40;
            this.newScoreboardButton.Name = "newScoreboardButton";
            this.newScoreboardButton.SmallImage = global::ScoreManager.Properties.Resources.icons8_create_30;
            resources.ApplyResources(this.newScoreboardButton, "newScoreboardButton");
            this.newScoreboardButton.Click += new System.EventHandler(this.newScoreboardItem_Click);
            // 
            // labelStart
            // 
            resources.ApplyResources(this.labelStart, "labelStart");
            this.labelStart.Name = "labelStart";
            // 
            // startPanel
            // 
            resources.ApplyResources(this.startPanel, "startPanel");
            this.startPanel.Controls.Add(this.labelHint);
            this.startPanel.Controls.Add(this.labelStart);
            this.startPanel.Name = "startPanel";
            // 
            // labelHint
            // 
            resources.ApplyResources(this.labelHint, "labelHint");
            this.labelHint.Name = "labelHint";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readyStatusLable});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // readyStatusLable
            // 
            this.readyStatusLable.Name = "readyStatusLable";
            resources.ApplyResources(this.readyStatusLable, "readyStatusLable");
            // 
            // projectPanel
            // 
            resources.ApplyResources(this.projectPanel, "projectPanel");
            this.projectPanel.Name = "projectPanel";
            // 
            // projectPanel.Panel1
            // 
            this.projectPanel.Panel1.Controls.Add(this.listView);
            // 
            // projectPanel.Panel2
            // 
            this.projectPanel.Panel2.Controls.Add(this.splitContainerH);
            // 
            // listView
            // 
            resources.ApplyResources(this.listView, "listView");
            this.listView.HideSelection = false;
            this.listView.Name = "listView";
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainerH
            // 
            resources.ApplyResources(this.splitContainerH, "splitContainerH");
            this.splitContainerH.Name = "splitContainerH";
            // 
            // splitContainerH.Panel1
            // 
            this.splitContainerH.Panel1.Controls.Add(this.chart);
            // 
            // splitContainerH.Panel2
            // 
            this.splitContainerH.Panel2.Controls.Add(this.recordListView);
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            resources.ApplyResources(this.chart, "chart");
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart.Series.Add(series3);
            // 
            // recordListView
            // 
            resources.ApplyResources(this.recordListView, "recordListView");
            this.recordListView.HideSelection = false;
            this.recordListView.Name = "recordListView";
            this.recordListView.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.projectPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.ribbonMain);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.projectPanel.Panel1.ResumeLayout(false);
            this.projectPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectPanel)).EndInit();
            this.projectPanel.ResumeLayout(false);
            this.splitContainerH.Panel1.ResumeLayout(false);
            this.splitContainerH.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerH)).EndInit();
            this.splitContainerH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.Ribbon ribbonMain;
        private System.Windows.Forms.RibbonButton ribbonButtonUndo;
        private System.Windows.Forms.RibbonTab editTab;
        private System.Windows.Forms.RibbonButton ribbonButtonSave;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton recordScore;
        private System.Windows.Forms.RibbonTab viewTab;
        private System.Windows.Forms.RibbonOrbMenuItem projectProperties;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton quickIndexItem;
        private System.Windows.Forms.RibbonButton overviewItem;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton addMember;
        private System.Windows.Forms.RibbonButton addGroup;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton validate;
        private System.Windows.Forms.RibbonOrbMenuItem importItem;
        private System.Windows.Forms.RibbonTab settingsItem;
        private System.Windows.Forms.RibbonPanel languageItem;
        private System.Windows.Forms.RibbonButton chineseItem;
        private System.Windows.Forms.RibbonButton englishItem;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton autostartItem;
        private System.Windows.Forms.RibbonButton ribbonButtonRedo;
        private System.Windows.Forms.RibbonButton properties;
        private System.Windows.Forms.RibbonOrbMenuItem openItem;
        private System.Windows.Forms.RibbonSeparator fileOptionSeparator;
        private System.Windows.Forms.RibbonComboBox adminBox;
        private System.Windows.Forms.RibbonOrbMenuItem createItem;
        private System.Windows.Forms.RibbonButton createProjectItem;
        private System.Windows.Forms.RibbonButton createScoreboardItem;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Panel startPanel;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel readyStatusLable;
        private System.Windows.Forms.RibbonPanel scoreboardPanel;
        private System.Windows.Forms.RibbonButton newScoreboardButton;
        private System.Windows.Forms.SplitContainer projectPanel;
        private System.Windows.Forms.SplitContainer splitContainerH;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ListView recordListView;
        private System.Windows.Forms.ListView listView;
    }
}

