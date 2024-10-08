
namespace RadioStationReports
{
    partial class FormReport
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSplit = new System.Windows.Forms.SplitContainer();
            this.panelSplitTop = new System.Windows.Forms.TableLayoutPanel();
            this.lvReportLines = new System.Windows.Forms.ListView();
            this.panelSplitBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tabDetails = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucReportLineWork = new RadioStationReports.UcReportLineWork();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.labLinesCnt = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.TableLayoutPanel();
            this.tbDistrFileName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateDistributionFile = new System.Windows.Forms.Button();
            this.btnShowDistributionFile = new System.Windows.Forms.Button();
            this.btnBallancePercents = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCodesExportImport = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateSearchFile = new System.Windows.Forms.Button();
            this.btnShowSearchFile = new System.Windows.Forms.Button();
            this.btnImportSearchFile = new System.Windows.Forms.Button();
            this.labAutoSearch = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSearchFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelAutoSearchStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.labAutoSearchStatus = new System.Windows.Forms.Label();
            this.btnAutoSearch = new System.Windows.Forms.Button();
            this.panelCalcShare = new System.Windows.Forms.FlowLayoutPanel();
            this.labCalcShareStatus = new System.Windows.Forms.Label();
            this.btnCalcRoyalty = new System.Windows.Forms.Button();
            this.btnShowHideActions = new System.Windows.Forms.Button();
            this.timerImportSearchFileProgress = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbOperationProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplit)).BeginInit();
            this.panelSplit.Panel1.SuspendLayout();
            this.panelSplit.Panel2.SuspendLayout();
            this.panelSplit.SuspendLayout();
            this.panelSplitTop.SuspendLayout();
            this.panelSplitBottom.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelCodesExportImport.SuspendLayout();
            this.panelAutoSearchStatus.SuspendLayout();
            this.panelCalcShare.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 381F));
            this.panelMain.Controls.Add(this.panelSplit, 0, 1);
            this.panelMain.Controls.Add(this.panelFilter, 0, 0);
            this.panelMain.Controls.Add(this.panelActions, 1, 1);
            this.panelMain.Controls.Add(this.btnShowHideActions, 1, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1270, 562);
            this.panelMain.TabIndex = 0;
            // 
            // panelSplit
            // 
            this.panelSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSplit.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.panelSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.panelSplit.Location = new System.Drawing.Point(3, 39);
            this.panelSplit.Name = "panelSplit";
            this.panelSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelSplit.Panel1
            // 
            this.panelSplit.Panel1.Controls.Add(this.panelSplitTop);
            // 
            // panelSplit.Panel2
            // 
            this.panelSplit.Panel2.Controls.Add(this.panelSplitBottom);
            this.panelSplit.Size = new System.Drawing.Size(883, 512);
            this.panelSplit.SplitterDistance = 162;
            this.panelSplit.TabIndex = 3;
            // 
            // panelSplitTop
            // 
            this.panelSplitTop.AutoSize = true;
            this.panelSplitTop.ColumnCount = 1;
            this.panelSplitTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSplitTop.Controls.Add(this.lvReportLines, 0, 0);
            this.panelSplitTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelSplitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitTop.Location = new System.Drawing.Point(0, 0);
            this.panelSplitTop.Name = "panelSplitTop";
            this.panelSplitTop.RowCount = 3;
            this.panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSplitTop.Size = new System.Drawing.Size(881, 160);
            this.panelSplitTop.TabIndex = 0;
            // 
            // lvReportLines
            // 
            this.lvReportLines.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvReportLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportLines.HideSelection = false;
            this.lvReportLines.Location = new System.Drawing.Point(3, 3);
            this.lvReportLines.Name = "lvReportLines";
            this.lvReportLines.Size = new System.Drawing.Size(875, 145);
            this.lvReportLines.TabIndex = 0;
            this.lvReportLines.UseCompatibleStateImageBehavior = false;
            this.lvReportLines.SelectedIndexChanged += new System.EventHandler(this.lvReportLines_SelectedIndexChanged);
            // 
            // panelSplitBottom
            // 
            this.panelSplitBottom.ColumnCount = 1;
            this.panelSplitBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSplitBottom.Controls.Add(this.tabDetails, 0, 0);
            this.panelSplitBottom.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelSplitBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitBottom.Location = new System.Drawing.Point(0, 0);
            this.panelSplitBottom.Name = "panelSplitBottom";
            this.panelSplitBottom.RowCount = 2;
            this.panelSplitBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSplitBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelSplitBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSplitBottom.Size = new System.Drawing.Size(881, 344);
            this.panelSplitBottom.TabIndex = 0;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.tabPage1);
            this.tabDetails.Controls.Add(this.tabPage2);
            this.tabDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDetails.Location = new System.Drawing.Point(3, 3);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedIndex = 0;
            this.tabDetails.Size = new System.Drawing.Size(875, 330);
            this.tabDetails.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucReportLineWork);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(867, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Пов\'язаний твір";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucReportLineWork
            // 
            this.ucReportLineWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportLineWork.Location = new System.Drawing.Point(3, 3);
            this.ucReportLineWork.Name = "ucReportLineWork";
            this.ucReportLineWork.Size = new System.Drawing.Size(861, 296);
            this.ucReportLineWork.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(867, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Автори твору";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.cbFilter);
            this.panelFilter.Controls.Add(this.labLinesCnt);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(883, 30);
            this.panelFilter.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Рядки звіту:";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(85, 3);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(186, 23);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // labLinesCnt
            // 
            this.labLinesCnt.AutoSize = true;
            this.labLinesCnt.Location = new System.Drawing.Point(277, 0);
            this.labLinesCnt.Name = "labLinesCnt";
            this.labLinesCnt.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labLinesCnt.Size = new System.Drawing.Size(100, 20);
            this.labLinesCnt.TabIndex = 2;
            this.labLinesCnt.Text = "(кількість рядків)";
            // 
            // panelActions
            // 
            this.panelActions.ColumnCount = 1;
            this.panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelActions.Controls.Add(this.tbDistrFileName, 0, 10);
            this.panelActions.Controls.Add(this.flowLayoutPanel1, 0, 11);
            this.panelActions.Controls.Add(this.label2, 0, 9);
            this.panelActions.Controls.Add(this.panelCodesExportImport, 0, 5);
            this.panelActions.Controls.Add(this.labAutoSearch, 0, 0);
            this.panelActions.Controls.Add(this.label5, 0, 2);
            this.panelActions.Controls.Add(this.label3, 0, 3);
            this.panelActions.Controls.Add(this.tbSearchFileName, 0, 4);
            this.panelActions.Controls.Add(this.label4, 0, 6);
            this.panelActions.Controls.Add(this.label6, 0, 8);
            this.panelActions.Controls.Add(this.panelAutoSearchStatus, 0, 1);
            this.panelActions.Controls.Add(this.panelCalcShare, 0, 7);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActions.Location = new System.Drawing.Point(892, 39);
            this.panelActions.Name = "panelActions";
            this.panelActions.RowCount = 15;
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelActions.Size = new System.Drawing.Size(375, 512);
            this.panelActions.TabIndex = 5;
            // 
            // tbDistrFileName
            // 
            this.tbDistrFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDistrFileName.Location = new System.Drawing.Point(3, 317);
            this.tbDistrFileName.Name = "tbDistrFileName";
            this.tbDistrFileName.ReadOnly = true;
            this.tbDistrFileName.Size = new System.Drawing.Size(369, 23);
            this.tbDistrFileName.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnCreateDistributionFile);
            this.flowLayoutPanel1.Controls.Add(this.btnShowDistributionFile);
            this.flowLayoutPanel1.Controls.Add(this.btnBallancePercents);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 350);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(369, 67);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCreateDistributionFile
            // 
            this.btnCreateDistributionFile.Location = new System.Drawing.Point(3, 3);
            this.btnCreateDistributionFile.Name = "btnCreateDistributionFile";
            this.btnCreateDistributionFile.Size = new System.Drawing.Size(82, 39);
            this.btnCreateDistributionFile.TabIndex = 1;
            this.btnCreateDistributionFile.Text = "Створити файл";
            this.btnCreateDistributionFile.UseVisualStyleBackColor = true;
            this.btnCreateDistributionFile.Click += new System.EventHandler(this.btnCreateDistributionFile_Click);
            // 
            // btnShowDistributionFile
            // 
            this.btnShowDistributionFile.Location = new System.Drawing.Point(91, 3);
            this.btnShowDistributionFile.Name = "btnShowDistributionFile";
            this.btnShowDistributionFile.Size = new System.Drawing.Size(74, 39);
            this.btnShowDistributionFile.TabIndex = 1;
            this.btnShowDistributionFile.Text = "Показати в фолдері";
            this.btnShowDistributionFile.UseVisualStyleBackColor = true;
            this.btnShowDistributionFile.Click += new System.EventHandler(this.btnShowDistributionFile_Click);
            // 
            // btnBallancePercents
            // 
            this.btnBallancePercents.Location = new System.Drawing.Point(171, 3);
            this.btnBallancePercents.Name = "btnBallancePercents";
            this.btnBallancePercents.Size = new System.Drawing.Size(95, 39);
            this.btnBallancePercents.TabIndex = 1;
            this.btnBallancePercents.Text = "Вирівняти проценти";
            this.btnBallancePercents.UseVisualStyleBackColor = true;
            this.btnBallancePercents.Click += new System.EventHandler(this.btnBallancePercents_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 288);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Файл розподілу:";
            // 
            // panelCodesExportImport
            // 
            this.panelCodesExportImport.AutoSize = true;
            this.panelCodesExportImport.Controls.Add(this.btnCreateSearchFile);
            this.panelCodesExportImport.Controls.Add(this.btnShowSearchFile);
            this.panelCodesExportImport.Controls.Add(this.btnImportSearchFile);
            this.panelCodesExportImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCodesExportImport.Location = new System.Drawing.Point(3, 144);
            this.panelCodesExportImport.Name = "panelCodesExportImport";
            this.panelCodesExportImport.Size = new System.Drawing.Size(369, 49);
            this.panelCodesExportImport.TabIndex = 1;
            // 
            // btnCreateSearchFile
            // 
            this.btnCreateSearchFile.Location = new System.Drawing.Point(3, 3);
            this.btnCreateSearchFile.Name = "btnCreateSearchFile";
            this.btnCreateSearchFile.Size = new System.Drawing.Size(82, 38);
            this.btnCreateSearchFile.TabIndex = 1;
            this.btnCreateSearchFile.Text = "Створити файл";
            this.btnCreateSearchFile.UseVisualStyleBackColor = true;
            this.btnCreateSearchFile.Click += new System.EventHandler(this.btnCreateSearchFile_Click);
            // 
            // btnShowSearchFile
            // 
            this.btnShowSearchFile.Location = new System.Drawing.Point(91, 3);
            this.btnShowSearchFile.Name = "btnShowSearchFile";
            this.btnShowSearchFile.Size = new System.Drawing.Size(74, 38);
            this.btnShowSearchFile.TabIndex = 1;
            this.btnShowSearchFile.Text = "Показати в фолдері";
            this.btnShowSearchFile.UseVisualStyleBackColor = true;
            this.btnShowSearchFile.Click += new System.EventHandler(this.btnShowSearchFile_Click);
            // 
            // btnImportSearchFile
            // 
            this.btnImportSearchFile.Location = new System.Drawing.Point(171, 3);
            this.btnImportSearchFile.Name = "btnImportSearchFile";
            this.btnImportSearchFile.Size = new System.Drawing.Size(95, 38);
            this.btnImportSearchFile.TabIndex = 1;
            this.btnImportSearchFile.Text = "Імпортувати дані";
            this.btnImportSearchFile.UseVisualStyleBackColor = true;
            this.btnImportSearchFile.Click += new System.EventHandler(this.btnImportSearchFile_Click);
            // 
            // labAutoSearch
            // 
            this.labAutoSearch.AutoSize = true;
            this.labAutoSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labAutoSearch.Location = new System.Drawing.Point(3, 0);
            this.labAutoSearch.Name = "labAutoSearch";
            this.labAutoSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labAutoSearch.Size = new System.Drawing.Size(132, 20);
            this.labAutoSearch.TabIndex = 0;
            this.labAutoSearch.Text = "Автоматичний пошук";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label5.Size = new System.Drawing.Size(175, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Пошук через експорт/імпорт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Файл пошуку:";
            // 
            // tbSearchFileName
            // 
            this.tbSearchFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearchFileName.Location = new System.Drawing.Point(3, 114);
            this.tbSearchFileName.Name = "tbSearchFileName";
            this.tbSearchFileName.ReadOnly = true;
            this.tbSearchFileName.Size = new System.Drawing.Size(369, 23);
            this.tbSearchFileName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 196);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Розрахунок процентів";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 262);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Розподіл";
            // 
            // panelAutoSearchStatus
            // 
            this.panelAutoSearchStatus.Controls.Add(this.labAutoSearchStatus);
            this.panelAutoSearchStatus.Controls.Add(this.btnAutoSearch);
            this.panelAutoSearchStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAutoSearchStatus.Location = new System.Drawing.Point(3, 28);
            this.panelAutoSearchStatus.Name = "panelAutoSearchStatus";
            this.panelAutoSearchStatus.Size = new System.Drawing.Size(369, 29);
            this.panelAutoSearchStatus.TabIndex = 2;
            // 
            // labAutoSearchStatus
            // 
            this.labAutoSearchStatus.AutoSize = true;
            this.labAutoSearchStatus.Location = new System.Drawing.Point(3, 0);
            this.labAutoSearchStatus.Name = "labAutoSearchStatus";
            this.labAutoSearchStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labAutoSearchStatus.Size = new System.Drawing.Size(38, 20);
            this.labAutoSearchStatus.TabIndex = 2;
            this.labAutoSearchStatus.Text = "label7";
            // 
            // btnAutoSearch
            // 
            this.btnAutoSearch.Location = new System.Drawing.Point(47, 3);
            this.btnAutoSearch.Name = "btnAutoSearch";
            this.btnAutoSearch.Size = new System.Drawing.Size(121, 23);
            this.btnAutoSearch.TabIndex = 1;
            this.btnAutoSearch.Text = "Виконати пошук";
            this.btnAutoSearch.UseVisualStyleBackColor = true;
            this.btnAutoSearch.Click += new System.EventHandler(this.btnAutoSearch_Click);
            // 
            // panelCalcShare
            // 
            this.panelCalcShare.Controls.Add(this.labCalcShareStatus);
            this.panelCalcShare.Controls.Add(this.btnCalcRoyalty);
            this.panelCalcShare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCalcShare.Location = new System.Drawing.Point(3, 225);
            this.panelCalcShare.Name = "panelCalcShare";
            this.panelCalcShare.Size = new System.Drawing.Size(369, 34);
            this.panelCalcShare.TabIndex = 3;
            // 
            // labCalcShareStatus
            // 
            this.labCalcShareStatus.AutoSize = true;
            this.labCalcShareStatus.Location = new System.Drawing.Point(3, 0);
            this.labCalcShareStatus.Name = "labCalcShareStatus";
            this.labCalcShareStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labCalcShareStatus.Size = new System.Drawing.Size(185, 20);
            this.labCalcShareStatus.TabIndex = 2;
            this.labCalcShareStatus.Text = "Розрахунок процентів виконано";
            // 
            // btnCalcRoyalty
            // 
            this.btnCalcRoyalty.Location = new System.Drawing.Point(194, 3);
            this.btnCalcRoyalty.Name = "btnCalcRoyalty";
            this.btnCalcRoyalty.Size = new System.Drawing.Size(145, 27);
            this.btnCalcRoyalty.TabIndex = 1;
            this.btnCalcRoyalty.Text = "Виконати розрахунок";
            this.btnCalcRoyalty.UseVisualStyleBackColor = true;
            this.btnCalcRoyalty.Click += new System.EventHandler(this.btnCalcRoyalty_Click);
            // 
            // btnShowHideActions
            // 
            this.btnShowHideActions.AutoSize = true;
            this.btnShowHideActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowHideActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShowHideActions.Location = new System.Drawing.Point(1242, 3);
            this.btnShowHideActions.Name = "btnShowHideActions";
            this.btnShowHideActions.Size = new System.Drawing.Size(25, 30);
            this.btnShowHideActions.TabIndex = 6;
            this.btnShowHideActions.Text = ">";
            this.btnShowHideActions.UseVisualStyleBackColor = true;
            this.btnShowHideActions.Click += new System.EventHandler(this.btnShowHideActions_Click);
            // 
            // timerImportSearchFileProgress
            // 
            this.timerImportSearchFileProgress.Tick += new System.EventHandler(this.timerImportSearchFileProgress_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel,
            this.pbOperationProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1270, 36);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Padding = new System.Windows.Forms.Padding(8);
            this.statusBarLabel.Size = new System.Drawing.Size(139, 31);
            this.statusBarLabel.Text = "Очікування операцій";
            // 
            // pbOperationProgress
            // 
            this.pbOperationProgress.Name = "pbOperationProgress";
            this.pbOperationProgress.Padding = new System.Windows.Forms.Padding(8);
            this.pbOperationProgress.Size = new System.Drawing.Size(648, 32);
            this.pbOperationProgress.Visible = false;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelMain);
            this.Name = "FormReport";
            this.Text = "Звіт";
            this.Load += new System.EventHandler(this.FormReport_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelSplit.Panel1.ResumeLayout(false);
            this.panelSplit.Panel1.PerformLayout();
            this.panelSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplit)).EndInit();
            this.panelSplit.ResumeLayout(false);
            this.panelSplitTop.ResumeLayout(false);
            this.panelSplitBottom.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelCodesExportImport.ResumeLayout(false);
            this.panelAutoSearchStatus.ResumeLayout(false);
            this.panelAutoSearchStatus.PerformLayout();
            this.panelCalcShare.ResumeLayout(false);
            this.panelCalcShare.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.ListView lvReportLines;
        private System.Windows.Forms.Button btnCreateSearchFile;
        private System.Windows.Forms.SplitContainer panelSplit;
        private System.Windows.Forms.TableLayoutPanel panelSplitTop;
        private System.Windows.Forms.TableLayoutPanel panelSplitBottom;
        private System.Windows.Forms.TabControl tabDetails;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel panelCodesExportImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSearchFileName;
        private System.Windows.Forms.Button btnShowSearchFile;
        private System.Windows.Forms.Button btnImportSearchFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDistrFileName;
        private System.Windows.Forms.Button btnCreateDistributionFile;
        private System.Windows.Forms.Button btnShowDistributionFile;
        private System.Windows.Forms.Label labAutoSearch;
        private System.Windows.Forms.Button btnAutoSearch;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label labLinesCnt;
        private UcReportLineWork ucReportLineWork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalcRoyalty;
        private System.Windows.Forms.TableLayoutPanel panelActions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel panelAutoSearchStatus;
        private System.Windows.Forms.Label labAutoSearchStatus;
        private System.Windows.Forms.FlowLayoutPanel panelCalcShare;
        private System.Windows.Forms.Label labCalcShareStatus;
        private System.Windows.Forms.Button btnShowHideActions;
        private System.Windows.Forms.Button btnBallancePercents;
        private System.Windows.Forms.Timer timerImportSearchFileProgress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel;
        private System.Windows.Forms.ToolStripProgressBar pbOperationProgress;
    }
}