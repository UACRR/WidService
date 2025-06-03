
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
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            lvReportLines = new System.Windows.Forms.ListView();
            panelCodesEdit = new System.Windows.Forms.TableLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            tbObjId = new System.Windows.Forms.TextBox();
            tbWic = new System.Windows.Forms.TextBox();
            tbIswc = new System.Windows.Forms.TextBox();
            btnApplyCode = new System.Windows.Forms.Button();
            btnCancelCode = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            panelCheckValue = new System.Windows.Forms.FlowLayoutPanel();
            label13 = new System.Windows.Forms.Label();
            rbCheckValueUndefined = new System.Windows.Forms.RadioButton();
            rbCheckValue100 = new System.Windows.Forms.RadioButton();
            rbCheckValue0 = new System.Windows.Forms.RadioButton();
            panelUpdateFromWid = new System.Windows.Forms.FlowLayoutPanel();
            label17 = new System.Windows.Forms.Label();
            btnUpdateFromWid = new System.Windows.Forms.Button();
            panelSplitBottom = new System.Windows.Forms.TableLayoutPanel();
            tabDetails = new System.Windows.Forms.TabControl();
            tabPage2 = new System.Windows.Forms.TabPage();
            ucReportLineDistribution = new UcReportLineDistribution();
            tabPage1 = new System.Windows.Forms.TabPage();
            ucReportLineWork = new UcReportLineWork();
            panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            cbFilter = new System.Windows.Forms.ComboBox();
            labLinesCnt = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            tbFilterEx = new System.Windows.Forms.TextBox();
            btnApplyFilterEx = new System.Windows.Forms.Button();
            panelActions = new System.Windows.Forms.TableLayoutPanel();
            btnCreatePrintFile = new System.Windows.Forms.Button();
            tbDistrFileName = new System.Windows.Forms.TextBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCreateDistributionFile = new System.Windows.Forms.Button();
            btnShowDistributionFile = new System.Windows.Forms.Button();
            btnBallancePercents = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            panelCodesExportImport = new System.Windows.Forms.FlowLayoutPanel();
            btnCreateCheckFile = new System.Windows.Forms.Button();
            btnShowCheckFile = new System.Windows.Forms.Button();
            labAutoSearch = new System.Windows.Forms.Label();
            tbCheckFileName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            panelAutoSearchStatus = new System.Windows.Forms.FlowLayoutPanel();
            labAutoSearchStatus = new System.Windows.Forms.Label();
            btnAutoSearch = new System.Windows.Forms.Button();
            panelCalcShare = new System.Windows.Forms.FlowLayoutPanel();
            labCalcShareStatus = new System.Windows.Forms.Label();
            btnCalcRoyalty = new System.Windows.Forms.Button();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            btnShowHideActions = new System.Windows.Forms.Button();
            panelExtraFilter = new System.Windows.Forms.FlowLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            rbCheckedAll = new System.Windows.Forms.RadioButton();
            rbCheckedDefined = new System.Windows.Forms.RadioButton();
            rbChecked100 = new System.Windows.Forms.RadioButton();
            rbChecked0 = new System.Windows.Forms.RadioButton();
            rbCheckedUndefined = new System.Windows.Forms.RadioButton();
            rbCheckedContradictory = new System.Windows.Forms.RadioButton();
            label14 = new System.Windows.Forms.Label();
            timerImportSearchFileProgress = new System.Windows.Forms.Timer(components);
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            pbOperationProgress = new System.Windows.Forms.ToolStripProgressBar();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelSplit).BeginInit();
            panelSplit.Panel1.SuspendLayout();
            panelSplit.Panel2.SuspendLayout();
            panelSplit.SuspendLayout();
            panelSplitTop.SuspendLayout();
            panelCodesEdit.SuspendLayout();
            panelCheckValue.SuspendLayout();
            panelUpdateFromWid.SuspendLayout();
            panelSplitBottom.SuspendLayout();
            tabDetails.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            panelFilter.SuspendLayout();
            panelActions.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelCodesExportImport.SuspendLayout();
            panelAutoSearchStatus.SuspendLayout();
            panelCalcShare.SuspendLayout();
            panelExtraFilter.SuspendLayout();
            statusStrip1.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 381F));
            panelMain.Controls.Add(panelSplit, 0, 3);
            panelMain.Controls.Add(panelFilter, 0, 1);
            panelMain.Controls.Add(panelActions, 1, 3);
            panelMain.Controls.Add(btnShowHideActions, 1, 1);
            panelMain.Controls.Add(panelExtraFilter, 0, 2);
            panelMain.Controls.Add(label14, 0, 0);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 5;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            panelMain.Size = new System.Drawing.Size(1244, 670);
            panelMain.TabIndex = 0;
            // 
            // panelSplit
            // 
            panelSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            panelSplit.Location = new System.Drawing.Point(3, 94);
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
            panelSplit.Size = new System.Drawing.Size(857, 549);
            panelSplit.SplitterDistance = 274;
            panelSplit.TabIndex = 3;
            // 
            // panelSplitTop
            // 
            panelSplitTop.AutoSize = true;
            panelSplitTop.ColumnCount = 2;
            panelSplitTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelSplitTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            panelSplitTop.Controls.Add(label16, 0, 1);
            panelSplitTop.Controls.Add(label15, 1, 0);
            panelSplitTop.Controls.Add(lvReportLines, 0, 0);
            panelSplitTop.Controls.Add(panelCodesEdit, 0, 2);
            panelSplitTop.Controls.Add(panelCheckValue, 0, 4);
            panelSplitTop.Controls.Add(panelUpdateFromWid, 0, 5);
            panelSplitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSplitTop.Location = new System.Drawing.Point(0, 0);
            panelSplitTop.Name = "panelSplitTop";
            panelSplitTop.RowCount = 6;
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            panelSplitTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            panelSplitTop.Size = new System.Drawing.Size(855, 272);
            panelSplitTop.TabIndex = 0;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = System.Drawing.SystemColors.ActiveCaption;
            label16.Dock = System.Windows.Forms.DockStyle.Fill;
            label16.Location = new System.Drawing.Point(3, 151);
            label16.Name = "label16";
            label16.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            label16.Size = new System.Drawing.Size(841, 20);
            label16.TabIndex = 10;
            label16.Text = "Редагування рядків";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            label15.Dock = System.Windows.Forms.DockStyle.Fill;
            label15.Location = new System.Drawing.Point(850, 0);
            label15.Name = "label15";
            label15.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            label15.Size = new System.Drawing.Size(2, 151);
            label15.TabIndex = 9;
            label15.Text = "Вибір рядків";
            // 
            // lvReportLines
            // 
            lvReportLines.Dock = System.Windows.Forms.DockStyle.Fill;
            lvReportLines.Location = new System.Drawing.Point(3, 3);
            lvReportLines.Name = "lvReportLines";
            lvReportLines.Size = new System.Drawing.Size(841, 145);
            lvReportLines.TabIndex = 0;
            lvReportLines.UseCompatibleStateImageBehavior = false;
            lvReportLines.ColumnClick += lvReportLines_ColumnClick;
            lvReportLines.SelectedIndexChanged += lvReportLines_SelectedIndexChanged;
            lvReportLines.MouseDown += lvReportLines_MouseDown;
            // 
            // panelCodesEdit
            // 
            panelCodesEdit.ColumnCount = 10;
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelCodesEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelCodesEdit.Controls.Add(label7, 0, 0);
            panelCodesEdit.Controls.Add(label8, 2, 0);
            panelCodesEdit.Controls.Add(label9, 4, 0);
            panelCodesEdit.Controls.Add(tbObjId, 1, 0);
            panelCodesEdit.Controls.Add(tbWic, 3, 0);
            panelCodesEdit.Controls.Add(tbIswc, 5, 0);
            panelCodesEdit.Controls.Add(btnApplyCode, 6, 0);
            panelCodesEdit.Controls.Add(btnCancelCode, 7, 0);
            panelCodesEdit.Controls.Add(btnSearch, 8, 0);
            panelCodesEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCodesEdit.Location = new System.Drawing.Point(3, 174);
            panelCodesEdit.Name = "panelCodesEdit";
            panelCodesEdit.RowCount = 1;
            panelCodesEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelCodesEdit.Size = new System.Drawing.Size(841, 30);
            panelCodesEdit.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 0);
            label7.Name = "label7";
            label7.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label7.Size = new System.Drawing.Size(71, 22);
            label7.TabIndex = 0;
            label7.Text = "Код СМАРТ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(181, 0);
            label8.Name = "label8";
            label8.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label8.Size = new System.Drawing.Size(52, 22);
            label8.TabIndex = 0;
            label8.Text = "Код WID";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(338, 0);
            label9.Name = "label9";
            label9.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label9.Size = new System.Drawing.Size(58, 22);
            label9.TabIndex = 0;
            label9.Text = "Код ISWC";
            // 
            // tbObjId
            // 
            tbObjId.Dock = System.Windows.Forms.DockStyle.Fill;
            tbObjId.Location = new System.Drawing.Point(82, 3);
            tbObjId.Name = "tbObjId";
            tbObjId.Size = new System.Drawing.Size(93, 23);
            tbObjId.TabIndex = 1;
            tbObjId.TextChanged += tbObjId_TextChanged;
            // 
            // tbWic
            // 
            tbWic.Dock = System.Windows.Forms.DockStyle.Fill;
            tbWic.Location = new System.Drawing.Point(240, 3);
            tbWic.Name = "tbWic";
            tbWic.Size = new System.Drawing.Size(92, 23);
            tbWic.TabIndex = 1;
            tbWic.TextChanged += tbWic_TextChanged;
            // 
            // tbIswc
            // 
            tbIswc.Dock = System.Windows.Forms.DockStyle.Fill;
            tbIswc.Location = new System.Drawing.Point(404, 3);
            tbIswc.Name = "tbIswc";
            tbIswc.Size = new System.Drawing.Size(118, 23);
            tbIswc.TabIndex = 1;
            tbIswc.TextChanged += tbIswc_TextChanged;
            // 
            // btnApplyCode
            // 
            btnApplyCode.Location = new System.Drawing.Point(528, 3);
            btnApplyCode.Name = "btnApplyCode";
            btnApplyCode.Size = new System.Drawing.Size(95, 22);
            btnApplyCode.TabIndex = 2;
            btnApplyCode.Text = "Застосувати";
            btnApplyCode.UseVisualStyleBackColor = true;
            btnApplyCode.Click += btnApplyCode_Click;
            // 
            // btnCancelCode
            // 
            btnCancelCode.Location = new System.Drawing.Point(629, 3);
            btnCancelCode.Name = "btnCancelCode";
            btnCancelCode.Size = new System.Drawing.Size(71, 22);
            btnCancelCode.TabIndex = 2;
            btnCancelCode.Text = "Відмінити";
            btnCancelCode.UseVisualStyleBackColor = true;
            btnCancelCode.Click += btnCancelCode_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(711, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(74, 22);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Шукати ...";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panelCheckValue
            // 
            panelCheckValue.Controls.Add(label13);
            panelCheckValue.Controls.Add(rbCheckValueUndefined);
            panelCheckValue.Controls.Add(rbCheckValue100);
            panelCheckValue.Controls.Add(rbCheckValue0);
            panelCheckValue.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCheckValue.Location = new System.Drawing.Point(3, 210);
            panelCheckValue.Name = "panelCheckValue";
            panelCheckValue.Size = new System.Drawing.Size(841, 26);
            panelCheckValue.TabIndex = 2;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(3, 5);
            label13.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(118, 15);
            label13.TabIndex = 0;
            label13.Text = "Результат перевірки";
            // 
            // rbCheckValueUndefined
            // 
            rbCheckValueUndefined.AutoSize = true;
            rbCheckValueUndefined.Location = new System.Drawing.Point(127, 3);
            rbCheckValueUndefined.Name = "rbCheckValueUndefined";
            rbCheckValueUndefined.Size = new System.Drawing.Size(95, 19);
            rbCheckValueUndefined.TabIndex = 1;
            rbCheckValueUndefined.TabStop = true;
            rbCheckValueUndefined.Text = "Не виконана";
            rbCheckValueUndefined.UseVisualStyleBackColor = true;
            rbCheckValueUndefined.CheckedChanged += rbCheckValueUndefined_CheckedChanged;
            // 
            // rbCheckValue100
            // 
            rbCheckValue100.AutoSize = true;
            rbCheckValue100.Location = new System.Drawing.Point(228, 3);
            rbCheckValue100.Name = "rbCheckValue100";
            rbCheckValue100.Size = new System.Drawing.Size(109, 19);
            rbCheckValue100.TabIndex = 1;
            rbCheckValue100.TabStop = true;
            rbCheckValue100.Text = "Виконана 100%";
            rbCheckValue100.UseVisualStyleBackColor = true;
            rbCheckValue100.CheckedChanged += rbCheckValue100_CheckedChanged;
            // 
            // rbCheckValue0
            // 
            rbCheckValue0.AutoSize = true;
            rbCheckValue0.Location = new System.Drawing.Point(343, 3);
            rbCheckValue0.Name = "rbCheckValue0";
            rbCheckValue0.Size = new System.Drawing.Size(97, 19);
            rbCheckValue0.TabIndex = 1;
            rbCheckValue0.TabStop = true;
            rbCheckValue0.Text = "Виконана 0%";
            rbCheckValue0.UseVisualStyleBackColor = true;
            rbCheckValue0.CheckedChanged += rbCheckValue0_CheckedChanged;
            // 
            // panelUpdateFromWid
            // 
            panelUpdateFromWid.Controls.Add(label17);
            panelUpdateFromWid.Controls.Add(btnUpdateFromWid);
            panelUpdateFromWid.Dock = System.Windows.Forms.DockStyle.Fill;
            panelUpdateFromWid.Location = new System.Drawing.Point(3, 239);
            panelUpdateFromWid.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            panelUpdateFromWid.Name = "panelUpdateFromWid";
            panelUpdateFromWid.Size = new System.Drawing.Size(841, 30);
            panelUpdateFromWid.TabIndex = 11;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(3, 7);
            label17.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(317, 15);
            label17.TabIndex = 0;
            label17.Text = "Оновити проценти в СМАРТ на основі інформації у WID";
            // 
            // btnUpdateFromWid
            // 
            btnUpdateFromWid.Location = new System.Drawing.Point(326, 3);
            btnUpdateFromWid.Name = "btnUpdateFromWid";
            btnUpdateFromWid.Size = new System.Drawing.Size(75, 23);
            btnUpdateFromWid.TabIndex = 1;
            btnUpdateFromWid.Text = "Виконати";
            btnUpdateFromWid.UseVisualStyleBackColor = true;
            btnUpdateFromWid.Click += btnUpdateFromWid_Click;
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
            panelSplitBottom.Size = new System.Drawing.Size(855, 269);
            panelSplitBottom.TabIndex = 0;
            // 
            // tabDetails
            // 
            tabDetails.Controls.Add(tabPage2);
            tabDetails.Controls.Add(tabPage1);
            tabDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            tabDetails.Location = new System.Drawing.Point(3, 3);
            tabDetails.Name = "tabDetails";
            tabDetails.SelectedIndex = 0;
            tabDetails.Size = new System.Drawing.Size(849, 255);
            tabDetails.TabIndex = 0;
            tabDetails.SelectedIndexChanged += tabDetails_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ucReportLineDistribution);
            tabPage2.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(841, 227);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Розподіл (правовласники на поточну дату)";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucReportLineDistribution
            // 
            ucReportLineDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            ucReportLineDistribution.Location = new System.Drawing.Point(3, 3);
            ucReportLineDistribution.Name = "ucReportLineDistribution";
            ucReportLineDistribution.Size = new System.Drawing.Size(835, 221);
            ucReportLineDistribution.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ucReportLineWork);
            tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(841, 227);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Додаткова інформація";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucReportLineWork
            // 
            ucReportLineWork.Dock = System.Windows.Forms.DockStyle.Fill;
            ucReportLineWork.Location = new System.Drawing.Point(3, 3);
            ucReportLineWork.Name = "ucReportLineWork";
            ucReportLineWork.Size = new System.Drawing.Size(835, 221);
            ucReportLineWork.TabIndex = 0;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(label1);
            panelFilter.Controls.Add(cbFilter);
            panelFilter.Controls.Add(labLinesCnt);
            panelFilter.Controls.Add(label12);
            panelFilter.Controls.Add(tbFilterEx);
            panelFilter.Controls.Add(btnApplyFilterEx);
            panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFilter.Location = new System.Drawing.Point(3, 23);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(857, 30);
            panelFilter.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
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
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label12.Location = new System.Drawing.Point(383, 0);
            label12.Name = "label12";
            label12.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label12.Size = new System.Drawing.Size(246, 20);
            label12.TabIndex = 3;
            label12.Text = "Серед рядків вибрати ті, які містять текст";
            // 
            // tbFilterEx
            // 
            tbFilterEx.Location = new System.Drawing.Point(635, 3);
            tbFilterEx.Name = "tbFilterEx";
            tbFilterEx.Size = new System.Drawing.Size(100, 23);
            tbFilterEx.TabIndex = 4;
            // 
            // btnApplyFilterEx
            // 
            btnApplyFilterEx.Location = new System.Drawing.Point(741, 3);
            btnApplyFilterEx.Name = "btnApplyFilterEx";
            btnApplyFilterEx.Size = new System.Drawing.Size(92, 23);
            btnApplyFilterEx.TabIndex = 5;
            btnApplyFilterEx.Text = "Застосувати";
            btnApplyFilterEx.UseVisualStyleBackColor = true;
            btnApplyFilterEx.Click += btnApplyFilterEx_Click;
            // 
            // panelActions
            // 
            panelActions.ColumnCount = 1;
            panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelActions.Controls.Add(btnCreatePrintFile, 0, 13);
            panelActions.Controls.Add(tbDistrFileName, 0, 10);
            panelActions.Controls.Add(flowLayoutPanel1, 0, 11);
            panelActions.Controls.Add(label2, 0, 9);
            panelActions.Controls.Add(panelCodesExportImport, 0, 5);
            panelActions.Controls.Add(labAutoSearch, 0, 0);
            panelActions.Controls.Add(tbCheckFileName, 0, 4);
            panelActions.Controls.Add(label4, 0, 6);
            panelActions.Controls.Add(label6, 0, 8);
            panelActions.Controls.Add(panelAutoSearchStatus, 0, 1);
            panelActions.Controls.Add(panelCalcShare, 0, 7);
            panelActions.Controls.Add(label10, 0, 2);
            panelActions.Controls.Add(label11, 0, 3);
            panelActions.Controls.Add(label3, 0, 12);
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.Location = new System.Drawing.Point(866, 94);
            panelActions.Name = "panelActions";
            panelActions.RowCount = 18;
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
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelActions.Size = new System.Drawing.Size(375, 549);
            panelActions.TabIndex = 5;
            // 
            // btnCreatePrintFile
            // 
            btnCreatePrintFile.Location = new System.Drawing.Point(3, 432);
            btnCreatePrintFile.Name = "btnCreatePrintFile";
            btnCreatePrintFile.Size = new System.Drawing.Size(266, 26);
            btnCreatePrintFile.TabIndex = 1;
            btnCreatePrintFile.Text = "Показати в провіднику Інтернет";
            btnCreatePrintFile.UseVisualStyleBackColor = true;
            btnCreatePrintFile.Click += btnCreatePrintFile_Click;
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
            flowLayoutPanel1.Size = new System.Drawing.Size(369, 50);
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
            panelCodesExportImport.Controls.Add(btnCreateCheckFile);
            panelCodesExportImport.Controls.Add(btnShowCheckFile);
            panelCodesExportImport.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCodesExportImport.Location = new System.Drawing.Point(3, 144);
            panelCodesExportImport.Name = "panelCodesExportImport";
            panelCodesExportImport.Size = new System.Drawing.Size(369, 49);
            panelCodesExportImport.TabIndex = 1;
            // 
            // btnCreateCheckFile
            // 
            btnCreateCheckFile.Location = new System.Drawing.Point(3, 3);
            btnCreateCheckFile.Name = "btnCreateCheckFile";
            btnCreateCheckFile.Size = new System.Drawing.Size(82, 39);
            btnCreateCheckFile.TabIndex = 1;
            btnCreateCheckFile.Text = "Створити файл";
            btnCreateCheckFile.UseVisualStyleBackColor = true;
            btnCreateCheckFile.Click += btnCreateCheckFile_Click;
            // 
            // btnShowCheckFile
            // 
            btnShowCheckFile.Location = new System.Drawing.Point(91, 3);
            btnShowCheckFile.Name = "btnShowCheckFile";
            btnShowCheckFile.Size = new System.Drawing.Size(74, 39);
            btnShowCheckFile.TabIndex = 1;
            btnShowCheckFile.Text = "Показати в фолдері";
            btnShowCheckFile.UseVisualStyleBackColor = true;
            btnShowCheckFile.Click += btnShowCheckFile_Click;
            // 
            // labAutoSearch
            // 
            labAutoSearch.AutoSize = true;
            labAutoSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labAutoSearch.Location = new System.Drawing.Point(3, 0);
            labAutoSearch.Name = "labAutoSearch";
            labAutoSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            labAutoSearch.Size = new System.Drawing.Size(132, 20);
            labAutoSearch.TabIndex = 0;
            labAutoSearch.Text = "Автоматичний пошук";
            // 
            // tbCheckFileName
            // 
            tbCheckFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbCheckFileName.Location = new System.Drawing.Point(3, 114);
            tbCheckFileName.Name = "tbCheckFileName";
            tbCheckFileName.ReadOnly = true;
            tbCheckFileName.Size = new System.Drawing.Size(369, 23);
            tbCheckFileName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
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
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
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
            labAutoSearchStatus.Size = new System.Drawing.Size(191, 20);
            labAutoSearchStatus.TabIndex = 2;
            labAutoSearchStatus.Text = "Автоматичний пошук виконаний";
            // 
            // btnAutoSearch
            // 
            btnAutoSearch.Enabled = false;
            btnAutoSearch.Location = new System.Drawing.Point(200, 3);
            btnAutoSearch.Name = "btnAutoSearch";
            btnAutoSearch.Size = new System.Drawing.Size(121, 23);
            btnAutoSearch.TabIndex = 1;
            btnAutoSearch.Text = "Виконати пошук";
            btnAutoSearch.UseVisualStyleBackColor = true;
            btnAutoSearch.Visible = false;
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(3, 60);
            label10.Name = "label10";
            label10.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label10.Size = new System.Drawing.Size(67, 20);
            label10.TabIndex = 0;
            label10.Text = "Перевірка";
            // 
            // label11
            // 
            label11.Location = new System.Drawing.Point(3, 86);
            label11.Name = "label11";
            label11.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label11.Size = new System.Drawing.Size(105, 23);
            label11.TabIndex = 0;
            label11.Text = "Файл перевірки:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(3, 403);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label3.Size = new System.Drawing.Size(36, 20);
            label3.TabIndex = 0;
            label3.Text = "Друк";
            // 
            // btnShowHideActions
            // 
            btnShowHideActions.AutoSize = true;
            btnShowHideActions.Dock = System.Windows.Forms.DockStyle.Right;
            btnShowHideActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnShowHideActions.Location = new System.Drawing.Point(1216, 23);
            btnShowHideActions.Name = "btnShowHideActions";
            btnShowHideActions.Size = new System.Drawing.Size(25, 30);
            btnShowHideActions.TabIndex = 6;
            btnShowHideActions.Text = ">";
            btnShowHideActions.UseVisualStyleBackColor = true;
            btnShowHideActions.Click += btnShowHideActions_Click;
            // 
            // panelExtraFilter
            // 
            panelExtraFilter.Controls.Add(label5);
            panelExtraFilter.Controls.Add(rbCheckedAll);
            panelExtraFilter.Controls.Add(rbCheckedDefined);
            panelExtraFilter.Controls.Add(rbChecked100);
            panelExtraFilter.Controls.Add(rbChecked0);
            panelExtraFilter.Controls.Add(rbCheckedUndefined);
            panelExtraFilter.Controls.Add(rbCheckedContradictory);
            panelExtraFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelExtraFilter.Location = new System.Drawing.Point(3, 59);
            panelExtraFilter.Name = "panelExtraFilter";
            panelExtraFilter.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            panelExtraFilter.Size = new System.Drawing.Size(857, 29);
            panelExtraFilter.TabIndex = 7;
            panelExtraFilter.WrapContents = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 7);
            label5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(183, 15);
            label5.TabIndex = 0;
            label5.Text = "Додатково за станом перевірки:";
            // 
            // rbCheckedAll
            // 
            rbCheckedAll.AutoSize = true;
            rbCheckedAll.Checked = true;
            rbCheckedAll.Location = new System.Drawing.Point(192, 6);
            rbCheckedAll.Name = "rbCheckedAll";
            rbCheckedAll.Size = new System.Drawing.Size(76, 19);
            rbCheckedAll.TabIndex = 1;
            rbCheckedAll.TabStop = true;
            rbCheckedAll.Text = "Всі рядки";
            rbCheckedAll.UseVisualStyleBackColor = true;
            rbCheckedAll.CheckedChanged += rbCheckedAll_CheckedChanged;
            // 
            // rbCheckedDefined
            // 
            rbCheckedDefined.AutoSize = true;
            rbCheckedDefined.Location = new System.Drawing.Point(274, 6);
            rbCheckedDefined.Name = "rbCheckedDefined";
            rbCheckedDefined.Size = new System.Drawing.Size(102, 19);
            rbCheckedDefined.TabIndex = 1;
            rbCheckedDefined.Text = "Всі перевірені";
            rbCheckedDefined.UseVisualStyleBackColor = true;
            rbCheckedDefined.CheckedChanged += rbCheckedDefined_CheckedChanged;
            // 
            // rbChecked100
            // 
            rbChecked100.AutoSize = true;
            rbChecked100.Location = new System.Drawing.Point(382, 6);
            rbChecked100.Name = "rbChecked100";
            rbChecked100.Size = new System.Drawing.Size(116, 19);
            rbChecked100.TabIndex = 1;
            rbChecked100.Text = "Перевірені 100%";
            rbChecked100.UseVisualStyleBackColor = true;
            rbChecked100.CheckedChanged += rbChecked100_CheckedChanged;
            // 
            // rbChecked0
            // 
            rbChecked0.AutoSize = true;
            rbChecked0.Location = new System.Drawing.Point(504, 6);
            rbChecked0.Name = "rbChecked0";
            rbChecked0.Size = new System.Drawing.Size(104, 19);
            rbChecked0.TabIndex = 1;
            rbChecked0.Text = "Перевірені 0%";
            rbChecked0.UseVisualStyleBackColor = true;
            rbChecked0.CheckedChanged += rbChecked0_CheckedChanged;
            // 
            // rbCheckedUndefined
            // 
            rbCheckedUndefined.AutoSize = true;
            rbCheckedUndefined.Location = new System.Drawing.Point(614, 6);
            rbCheckedUndefined.Name = "rbCheckedUndefined";
            rbCheckedUndefined.Size = new System.Drawing.Size(101, 19);
            rbCheckedUndefined.TabIndex = 1;
            rbCheckedUndefined.Text = "Не перевірені";
            rbCheckedUndefined.UseVisualStyleBackColor = true;
            rbCheckedUndefined.CheckedChanged += rbCheckedUndefined_CheckedChanged;
            // 
            // rbCheckedContradictory
            // 
            rbCheckedContradictory.AutoSize = true;
            rbCheckedContradictory.Location = new System.Drawing.Point(721, 6);
            rbCheckedContradictory.Name = "rbCheckedContradictory";
            rbCheckedContradictory.Size = new System.Drawing.Size(162, 19);
            rbCheckedContradictory.TabIndex = 1;
            rbCheckedContradictory.Text = "Протиречить процентам";
            rbCheckedContradictory.UseVisualStyleBackColor = true;
            rbCheckedContradictory.CheckedChanged += rbCheckedCOntradictory_CheckedChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            label14.Dock = System.Windows.Forms.DockStyle.Fill;
            label14.Location = new System.Drawing.Point(3, 0);
            label14.Name = "label14";
            label14.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            label14.Size = new System.Drawing.Size(857, 20);
            label14.TabIndex = 8;
            label14.Text = "Вибір рядків";
            // 
            // timerImportSearchFileProgress
            // 
            timerImportSearchFileProgress.Tick += timerImportSearchFileProgress_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusBarLabel, pbOperationProgress });
            statusStrip1.Location = new System.Drawing.Point(0, 634);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1244, 36);
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
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemCopy });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(133, 26);
            contextMenuStrip.ItemClicked += contextMenuStrip_ItemClicked;
            // 
            // toolStripMenuItemCopy
            // 
            toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            toolStripMenuItemCopy.Size = new System.Drawing.Size(132, 22);
            toolStripMenuItemCopy.Text = "Копіювати";
            // 
            // FormReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1244, 670);
            Controls.Add(statusStrip1);
            Controls.Add(panelMain);
            MinimumSize = new System.Drawing.Size(920, 39);
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
            panelSplitTop.PerformLayout();
            panelCodesEdit.ResumeLayout(false);
            panelCodesEdit.PerformLayout();
            panelCheckValue.ResumeLayout(false);
            panelCheckValue.PerformLayout();
            panelUpdateFromWid.ResumeLayout(false);
            panelUpdateFromWid.PerformLayout();
            panelSplitBottom.ResumeLayout(false);
            tabDetails.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
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
            panelExtraFilter.ResumeLayout(false);
            panelExtraFilter.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.ListView lvReportLines;
        private System.Windows.Forms.SplitContainer panelSplit;
        private System.Windows.Forms.TableLayoutPanel panelSplitTop;
        private System.Windows.Forms.TableLayoutPanel panelSplitBottom;
        private System.Windows.Forms.TabControl tabDetails;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel panelCodesExportImport;
        private System.Windows.Forms.TextBox tbCheckFileName;
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
        private System.Windows.Forms.TableLayoutPanel panelCodesEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbFilterEx;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnApplyCode;
        private System.Windows.Forms.Button btnCancelCode;
        private System.Windows.Forms.TextBox tbObjId;
        private System.Windows.Forms.TextBox tbWic;
        private System.Windows.Forms.TextBox tbIswc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.Button btnSearch;
        private UcReportLineDistribution ucReportLineDistribution;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCreateCheckFile;
        private System.Windows.Forms.Button btnShowCheckFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnApplyFilterEx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreatePrintFile;
        private System.Windows.Forms.FlowLayoutPanel panelExtraFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbCheckedAll;
        private System.Windows.Forms.RadioButton rbCheckedDefined;
        private System.Windows.Forms.RadioButton rbChecked100;
        private System.Windows.Forms.RadioButton rbChecked0;
        private System.Windows.Forms.RadioButton rbCheckedUndefined;
        private System.Windows.Forms.FlowLayoutPanel panelCheckValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rbCheckValueUndefined;
        private System.Windows.Forms.RadioButton rbCheckValue100;
        private System.Windows.Forms.RadioButton rbCheckValue0;
        private System.Windows.Forms.RadioButton rbCheckedContradictory;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.FlowLayoutPanel panelUpdateFromWid;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnUpdateFromWid;
    }
}