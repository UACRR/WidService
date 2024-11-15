
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
            components = new System.ComponentModel.Container();
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            panelSplit = new System.Windows.Forms.SplitContainer();
            panelSplitTop = new System.Windows.Forms.TableLayoutPanel();
            lvReportLines = new System.Windows.Forms.ListView();
            panelSplitBottom = new System.Windows.Forms.TableLayoutPanel();
            tabDetails = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            ucReportLineWork = new UcReportLineWork();
            tabPage2 = new System.Windows.Forms.TabPage();
            ucReportLineDistribution = new UcReportLineDistribution();
            panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            cbFilter = new System.Windows.Forms.ComboBox();
            labLinesCnt = new System.Windows.Forms.Label();
            panelActions = new System.Windows.Forms.TableLayoutPanel();
            tbDistrFileName = new System.Windows.Forms.TextBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCreateDistributionFile = new System.Windows.Forms.Button();
            btnShowDistributionFile = new System.Windows.Forms.Button();
            btnBallancePercents = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            panelCodesExportImport = new System.Windows.Forms.FlowLayoutPanel();
            btnCreateSearchFile = new System.Windows.Forms.Button();
            btnShowSearchFile = new System.Windows.Forms.Button();
            btnImportSearchFile = new System.Windows.Forms.Button();
            labAutoSearch = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tbSearchFileName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            panelAutoSearchStatus = new System.Windows.Forms.FlowLayoutPanel();
            labAutoSearchStatus = new System.Windows.Forms.Label();
            btnAutoSearch = new System.Windows.Forms.Button();
            panelCalcShare = new System.Windows.Forms.FlowLayoutPanel();
            labCalcShareStatus = new System.Windows.Forms.Label();
            btnCalcRoyalty = new System.Windows.Forms.Button();
            btnShowHideActions = new System.Windows.Forms.Button();
            timerImportSearchFileProgress = new System.Windows.Forms.Timer(components);
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            pbOperationProgress = new System.Windows.Forms.ToolStripProgressBar();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelSplit).BeginInit();
            panelSplit.Panel1.SuspendLayout();
            panelSplit.Panel2.SuspendLayout();
            panelSplit.SuspendLayout();
            panelSplitTop.SuspendLayout();
            panelSplitBottom.SuspendLayout();
            tabDetails.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panelFilter.SuspendLayout();
            panelActions.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelCodesExportImport.SuspendLayout();
            panelAutoSearchStatus.SuspendLayout();
            panelCalcShare.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 381F));
            panelMain.Controls.Add(panelSplit, 0, 1);
            panelMain.Controls.Add(panelFilter, 0, 0);
            panelMain.Controls.Add(panelActions, 1, 1);
            panelMain.Controls.Add(btnShowHideActions, 1, 0);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 3;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelMain.Size = new System.Drawing.Size(1231, 570);
            panelMain.TabIndex = 0;
            // 
            // panelSplit
            // 
            panelSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            panelSplit.Location = new System.Drawing.Point(3, 39);
            panelSplit.Name = "panelSplit";
            panelSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelSplit.Panel1
            // 
            panelSplit.Panel1.Controls.Add(panelSplitTop);
            // 
            // panelSplit.Panel2
            // 
            panelSplit.Panel2.Controls.Add(panelSplitBottom);
            panelSplit.Size = new System.Drawing.Size(844, 504);
            panelSplit.SplitterDistance = 159;
            panelSplit.TabIndex = 3;
            // 
            // panelSplitTop
            // 
            panelSplitTop.AutoSize = true;
            panelSplitTop.ColumnCount = 1;
            panelSplitTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelSplitTop.Controls.Add(lvReportLines, 0, 0);
            panelSplitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSplitTop.Location = new System.Drawing.Point(0, 0);
            panelSplitTop.Name = "panelSplitTop";
            panelSplitTop.RowCount = 3;
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelSplitTop.Size = new System.Drawing.Size(842, 157);
            panelSplitTop.TabIndex = 0;
            // 
            // lvReportLines
            // 
            lvReportLines.Dock = System.Windows.Forms.DockStyle.Fill;
            lvReportLines.HideSelection = false;
            lvReportLines.Location = new System.Drawing.Point(3, 3);
            lvReportLines.Name = "lvReportLines";
            lvReportLines.Size = new System.Drawing.Size(836, 142);
            lvReportLines.TabIndex = 0;
            lvReportLines.UseCompatibleStateImageBehavior = false;
            lvReportLines.SelectedIndexChanged += lvReportLines_SelectedIndexChanged;
            // 
            // panelSplitBottom
            // 
            panelSplitBottom.ColumnCount = 1;
            panelSplitBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelSplitBottom.Controls.Add(tabDetails, 0, 0);
            panelSplitBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSplitBottom.Location = new System.Drawing.Point(0, 0);
            panelSplitBottom.Name = "panelSplitBottom";
            panelSplitBottom.RowCount = 2;
            panelSplitBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelSplitBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            panelSplitBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelSplitBottom.Size = new System.Drawing.Size(842, 339);
            panelSplitBottom.TabIndex = 0;
            // 
            // tabDetails
            // 
            tabDetails.Controls.Add(tabPage1);
            tabDetails.Controls.Add(tabPage2);
            tabDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            tabDetails.Location = new System.Drawing.Point(3, 3);
            tabDetails.Name = "tabDetails";
            tabDetails.SelectedIndex = 0;
            tabDetails.Size = new System.Drawing.Size(836, 325);
            tabDetails.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ucReportLineWork);
            tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(828, 297);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Пов'язаний твір";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucReportLineWork
            // 
            ucReportLineWork.Dock = System.Windows.Forms.DockStyle.Fill;
            ucReportLineWork.Location = new System.Drawing.Point(3, 3);
            ucReportLineWork.Name = "ucReportLineWork";
            ucReportLineWork.Size = new System.Drawing.Size(822, 291);
            ucReportLineWork.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ucReportLineDistribution);
            tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(828, 297);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Розподіл";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucReportLineDistribution
            // 
            ucReportLineDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            ucReportLineDistribution.Location = new System.Drawing.Point(3, 3);
            ucReportLineDistribution.Name = "ucReportLineDistribution";
            ucReportLineDistribution.Size = new System.Drawing.Size(822, 291);
            ucReportLineDistribution.TabIndex = 0;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(label1);
            panelFilter.Controls.Add(cbFilter);
            panelFilter.Controls.Add(labLinesCnt);
            panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFilter.Location = new System.Drawing.Point(3, 3);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(844, 30);
            panelFilter.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label1.Size = new System.Drawing.Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Рядки звіту:";
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new System.Drawing.Point(85, 3);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new System.Drawing.Size(186, 23);
            cbFilter.TabIndex = 1;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // labLinesCnt
            // 
            labLinesCnt.AutoSize = true;
            labLinesCnt.Location = new System.Drawing.Point(277, 0);
            labLinesCnt.Name = "labLinesCnt";
            labLinesCnt.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labLinesCnt.Size = new System.Drawing.Size(100, 20);
            labLinesCnt.TabIndex = 2;
            labLinesCnt.Text = "(кількість рядків)";
            // 
            // panelActions
            // 
            panelActions.ColumnCount = 1;
            panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelActions.Controls.Add(tbDistrFileName, 0, 10);
            panelActions.Controls.Add(flowLayoutPanel1, 0, 11);
            panelActions.Controls.Add(label2, 0, 9);
            panelActions.Controls.Add(panelCodesExportImport, 0, 5);
            panelActions.Controls.Add(labAutoSearch, 0, 0);
            panelActions.Controls.Add(label5, 0, 2);
            panelActions.Controls.Add(label3, 0, 3);
            panelActions.Controls.Add(tbSearchFileName, 0, 4);
            panelActions.Controls.Add(label4, 0, 6);
            panelActions.Controls.Add(label6, 0, 8);
            panelActions.Controls.Add(panelAutoSearchStatus, 0, 1);
            panelActions.Controls.Add(panelCalcShare, 0, 7);
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.Location = new System.Drawing.Point(853, 39);
            panelActions.Name = "panelActions";
            panelActions.RowCount = 15;
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelActions.Size = new System.Drawing.Size(375, 504);
            panelActions.TabIndex = 5;
            // 
            // tbDistrFileName
            // 
            tbDistrFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbDistrFileName.Location = new System.Drawing.Point(3, 317);
            tbDistrFileName.Name = "tbDistrFileName";
            tbDistrFileName.ReadOnly = true;
            tbDistrFileName.Size = new System.Drawing.Size(369, 23);
            tbDistrFileName.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnCreateDistributionFile);
            flowLayoutPanel1.Controls.Add(btnShowDistributionFile);
            flowLayoutPanel1.Controls.Add(btnBallancePercents);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 350);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(369, 67);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCreateDistributionFile
            // 
            btnCreateDistributionFile.Location = new System.Drawing.Point(3, 3);
            btnCreateDistributionFile.Name = "btnCreateDistributionFile";
            btnCreateDistributionFile.Size = new System.Drawing.Size(82, 39);
            btnCreateDistributionFile.TabIndex = 1;
            btnCreateDistributionFile.Text = "Створити файл";
            btnCreateDistributionFile.UseVisualStyleBackColor = true;
            btnCreateDistributionFile.Click += btnCreateDistributionFile_Click;
            // 
            // btnShowDistributionFile
            // 
            btnShowDistributionFile.Location = new System.Drawing.Point(91, 3);
            btnShowDistributionFile.Name = "btnShowDistributionFile";
            btnShowDistributionFile.Size = new System.Drawing.Size(74, 39);
            btnShowDistributionFile.TabIndex = 1;
            btnShowDistributionFile.Text = "Показати в фолдері";
            btnShowDistributionFile.UseVisualStyleBackColor = true;
            btnShowDistributionFile.Click += btnShowDistributionFile_Click;
            // 
            // btnBallancePercents
            // 
            btnBallancePercents.Location = new System.Drawing.Point(171, 3);
            btnBallancePercents.Name = "btnBallancePercents";
            btnBallancePercents.Size = new System.Drawing.Size(95, 39);
            btnBallancePercents.TabIndex = 1;
            btnBallancePercents.Text = "Вирівняти проценти";
            btnBallancePercents.UseVisualStyleBackColor = true;
            btnBallancePercents.Click += btnBallancePercents_Click;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(3, 288);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label2.Size = new System.Drawing.Size(105, 24);
            label2.TabIndex = 0;
            label2.Text = "Файл розподілу:";
            // 
            // panelCodesExportImport
            // 
            panelCodesExportImport.AutoSize = true;
            panelCodesExportImport.Controls.Add(btnCreateSearchFile);
            panelCodesExportImport.Controls.Add(btnShowSearchFile);
            panelCodesExportImport.Controls.Add(btnImportSearchFile);
            panelCodesExportImport.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCodesExportImport.Location = new System.Drawing.Point(3, 144);
            panelCodesExportImport.Name = "panelCodesExportImport";
            panelCodesExportImport.Size = new System.Drawing.Size(369, 49);
            panelCodesExportImport.TabIndex = 1;
            // 
            // btnCreateSearchFile
            // 
            btnCreateSearchFile.Location = new System.Drawing.Point(3, 3);
            btnCreateSearchFile.Name = "btnCreateSearchFile";
            btnCreateSearchFile.Size = new System.Drawing.Size(82, 38);
            btnCreateSearchFile.TabIndex = 1;
            btnCreateSearchFile.Text = "Створити файл";
            btnCreateSearchFile.UseVisualStyleBackColor = true;
            btnCreateSearchFile.Click += btnCreateSearchFile_Click;
            // 
            // btnShowSearchFile
            // 
            btnShowSearchFile.Location = new System.Drawing.Point(91, 3);
            btnShowSearchFile.Name = "btnShowSearchFile";
            btnShowSearchFile.Size = new System.Drawing.Size(74, 38);
            btnShowSearchFile.TabIndex = 1;
            btnShowSearchFile.Text = "Показати в фолдері";
            btnShowSearchFile.UseVisualStyleBackColor = true;
            btnShowSearchFile.Click += btnShowSearchFile_Click;
            // 
            // btnImportSearchFile
            // 
            btnImportSearchFile.Location = new System.Drawing.Point(171, 3);
            btnImportSearchFile.Name = "btnImportSearchFile";
            btnImportSearchFile.Size = new System.Drawing.Size(95, 38);
            btnImportSearchFile.TabIndex = 1;
            btnImportSearchFile.Text = "Імпортувати дані";
            btnImportSearchFile.UseVisualStyleBackColor = true;
            btnImportSearchFile.Click += btnImportSearchFile_Click;
            // 
            // labAutoSearch
            // 
            labAutoSearch.AutoSize = true;
            labAutoSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labAutoSearch.Location = new System.Drawing.Point(3, 0);
            labAutoSearch.Name = "labAutoSearch";
            labAutoSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labAutoSearch.Size = new System.Drawing.Size(132, 20);
            labAutoSearch.TabIndex = 0;
            labAutoSearch.Text = "Автоматичний пошук";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(3, 60);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label5.Size = new System.Drawing.Size(175, 20);
            label5.TabIndex = 0;
            label5.Text = "Пошук через експорт/імпорт";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 86);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label3.Size = new System.Drawing.Size(85, 20);
            label3.TabIndex = 0;
            label3.Text = "Файл пошуку:";
            // 
            // tbSearchFileName
            // 
            tbSearchFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbSearchFileName.Location = new System.Drawing.Point(3, 114);
            tbSearchFileName.Name = "tbSearchFileName";
            tbSearchFileName.ReadOnly = true;
            tbSearchFileName.Size = new System.Drawing.Size(369, 23);
            tbSearchFileName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(3, 196);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label4.Size = new System.Drawing.Size(135, 20);
            label4.TabIndex = 0;
            label4.Text = "Розрахунок процентів";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(3, 262);
            label6.Name = "label6";
            label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label6.Size = new System.Drawing.Size(58, 20);
            label6.TabIndex = 0;
            label6.Text = "Розподіл";
            // 
            // panelAutoSearchStatus
            // 
            panelAutoSearchStatus.Controls.Add(labAutoSearchStatus);
            panelAutoSearchStatus.Controls.Add(btnAutoSearch);
            panelAutoSearchStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            panelAutoSearchStatus.Location = new System.Drawing.Point(3, 28);
            panelAutoSearchStatus.Name = "panelAutoSearchStatus";
            panelAutoSearchStatus.Size = new System.Drawing.Size(369, 29);
            panelAutoSearchStatus.TabIndex = 2;
            // 
            // labAutoSearchStatus
            // 
            labAutoSearchStatus.AutoSize = true;
            labAutoSearchStatus.Location = new System.Drawing.Point(3, 0);
            labAutoSearchStatus.Name = "labAutoSearchStatus";
            labAutoSearchStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labAutoSearchStatus.Size = new System.Drawing.Size(38, 20);
            labAutoSearchStatus.TabIndex = 2;
            labAutoSearchStatus.Text = "label7";
            // 
            // btnAutoSearch
            // 
            btnAutoSearch.Location = new System.Drawing.Point(47, 3);
            btnAutoSearch.Name = "btnAutoSearch";
            btnAutoSearch.Size = new System.Drawing.Size(121, 23);
            btnAutoSearch.TabIndex = 1;
            btnAutoSearch.Text = "Виконати пошук";
            btnAutoSearch.UseVisualStyleBackColor = true;
            btnAutoSearch.Click += btnAutoSearch_Click;
            // 
            // panelCalcShare
            // 
            panelCalcShare.Controls.Add(labCalcShareStatus);
            panelCalcShare.Controls.Add(btnCalcRoyalty);
            panelCalcShare.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCalcShare.Location = new System.Drawing.Point(3, 225);
            panelCalcShare.Name = "panelCalcShare";
            panelCalcShare.Size = new System.Drawing.Size(369, 34);
            panelCalcShare.TabIndex = 3;
            // 
            // labCalcShareStatus
            // 
            labCalcShareStatus.AutoSize = true;
            labCalcShareStatus.Location = new System.Drawing.Point(3, 0);
            labCalcShareStatus.Name = "labCalcShareStatus";
            labCalcShareStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labCalcShareStatus.Size = new System.Drawing.Size(184, 20);
            labCalcShareStatus.TabIndex = 2;
            labCalcShareStatus.Text = "Розрахунок процентів виконано";
            // 
            // btnCalcRoyalty
            // 
            btnCalcRoyalty.Location = new System.Drawing.Point(193, 3);
            btnCalcRoyalty.Name = "btnCalcRoyalty";
            btnCalcRoyalty.Size = new System.Drawing.Size(145, 27);
            btnCalcRoyalty.TabIndex = 1;
            btnCalcRoyalty.Text = "Виконати розрахунок";
            btnCalcRoyalty.UseVisualStyleBackColor = true;
            btnCalcRoyalty.Click += btnCalcRoyalty_Click;
            // 
            // btnShowHideActions
            // 
            btnShowHideActions.AutoSize = true;
            btnShowHideActions.Dock = System.Windows.Forms.DockStyle.Right;
            btnShowHideActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnShowHideActions.Location = new System.Drawing.Point(1203, 3);
            btnShowHideActions.Name = "btnShowHideActions";
            btnShowHideActions.Size = new System.Drawing.Size(25, 30);
            btnShowHideActions.TabIndex = 6;
            btnShowHideActions.Text = ">";
            btnShowHideActions.UseVisualStyleBackColor = true;
            btnShowHideActions.Click += btnShowHideActions_Click;
            // 
            // timerImportSearchFileProgress
            // 
            timerImportSearchFileProgress.Tick += timerImportSearchFileProgress_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusBarLabel, pbOperationProgress });
            statusStrip1.Location = new System.Drawing.Point(0, 534);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1231, 36);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            statusBarLabel.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
            statusBarLabel.Name = "statusBarLabel";
            statusBarLabel.Padding = new System.Windows.Forms.Padding(8);
            statusBarLabel.Size = new System.Drawing.Size(139, 31);
            statusBarLabel.Text = "Очікування операцій";
            // 
            // pbOperationProgress
            // 
            pbOperationProgress.Name = "pbOperationProgress";
            pbOperationProgress.Padding = new System.Windows.Forms.Padding(8);
            pbOperationProgress.Size = new System.Drawing.Size(648, 32);
            pbOperationProgress.Visible = false;
            // 
            // FormReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1231, 570);
            Controls.Add(statusStrip1);
            Controls.Add(panelMain);
            Name = "FormReport";
            Text = "Звіт";
            Load += FormReport_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelSplit.Panel1.ResumeLayout(false);
            panelSplit.Panel1.PerformLayout();
            panelSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelSplit).EndInit();
            panelSplit.ResumeLayout(false);
            panelSplitTop.ResumeLayout(false);
            panelSplitBottom.ResumeLayout(false);
            tabDetails.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panelCodesExportImport.ResumeLayout(false);
            panelAutoSearchStatus.ResumeLayout(false);
            panelAutoSearchStatus.PerformLayout();
            panelCalcShare.ResumeLayout(false);
            panelCalcShare.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private UcReportLineDistribution ucReportLineDistribution;
    }
}