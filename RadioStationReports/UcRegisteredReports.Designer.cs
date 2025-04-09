namespace RadioStationReports
{
    partial class UcRegisteredReports
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
            panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            btnShowReport = new System.Windows.Forms.Button();
            btnArhive = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            panelFilterArchived = new System.Windows.Forms.FlowLayoutPanel();
            radioFilterActive = new System.Windows.Forms.RadioButton();
            radioFilterArchived = new System.Windows.Forms.RadioButton();
            panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            cbFilterRadioStation = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cbFilterStartYear = new System.Windows.Forms.ComboBox();
            cbFilterStartMonth = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cbFilterEndYear = new System.Windows.Forms.ComboBox();
            cbFilterEndMonth = new System.Windows.Forms.ComboBox();
            splitPanelReports = new System.Windows.Forms.SplitContainer();
            panelReportMain = new System.Windows.Forms.TableLayoutPanel();
            lvReports = new System.Windows.Forms.ListView();
            panelReportMainInfoTitle = new System.Windows.Forms.TableLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            btnShowDetails = new System.Windows.Forms.Button();
            panelReportDetails = new System.Windows.Forms.TableLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            panelReportDetailValues = new System.Windows.Forms.TableLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            tbReportFilePath = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            tbReportWorkFilesPath = new System.Windows.Forms.TextBox();
            tbReportSearchFile = new System.Windows.Forms.TextBox();
            tbReportDistributionFile = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            tbReportFileName = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            tbReprotSourceFileCopyName = new System.Windows.Forms.TextBox();
            openFileDlg = new System.Windows.Forms.OpenFileDialog();
            timerApplyFilter = new System.Windows.Forms.Timer(components);
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            panelMain.SuspendLayout();
            panelBottom.SuspendLayout();
            panelFilterArchived.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitPanelReports).BeginInit();
            splitPanelReports.Panel1.SuspendLayout();
            splitPanelReports.Panel2.SuspendLayout();
            splitPanelReports.SuspendLayout();
            panelReportMain.SuspendLayout();
            panelReportMainInfoTitle.SuspendLayout();
            panelReportDetails.SuspendLayout();
            panelReportDetailValues.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.Controls.Add(panelBottom, 0, 4);
            panelMain.Controls.Add(label1, 0, 0);
            panelMain.Controls.Add(panelFilterArchived, 0, 1);
            panelMain.Controls.Add(panelFilter, 0, 2);
            panelMain.Controls.Add(splitPanelReports, 0, 3);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 7;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelMain.Size = new System.Drawing.Size(872, 524);
            panelMain.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnShowReport);
            panelBottom.Controls.Add(btnArhive);
            panelBottom.Controls.Add(btnDelete);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelBottom.Location = new System.Drawing.Point(3, 461);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(866, 31);
            panelBottom.TabIndex = 0;
            // 
            // btnShowReport
            // 
            btnShowReport.Location = new System.Drawing.Point(783, 3);
            btnShowReport.Name = "btnShowReport";
            btnShowReport.Size = new System.Drawing.Size(80, 23);
            btnShowReport.TabIndex = 0;
            btnShowReport.Text = "Показати";
            btnShowReport.UseVisualStyleBackColor = true;
            btnShowReport.Click += btnShowReport_Click;
            // 
            // btnArhive
            // 
            btnArhive.Location = new System.Drawing.Point(702, 3);
            btnArhive.Name = "btnArhive";
            btnArhive.Size = new System.Drawing.Size(75, 23);
            btnArhive.TabIndex = 1;
            btnArhive.Text = "До архіву";
            btnArhive.UseVisualStyleBackColor = true;
            btnArhive.Click += btnArhive_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(621, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(75, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(5);
            label1.Size = new System.Drawing.Size(866, 30);
            label1.TabIndex = 1;
            label1.Text = "Зареєстровані в базі даних звіти";
            // 
            // panelFilterArchived
            // 
            panelFilterArchived.Controls.Add(radioFilterActive);
            panelFilterArchived.Controls.Add(radioFilterArchived);
            panelFilterArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFilterArchived.Location = new System.Drawing.Point(3, 33);
            panelFilterArchived.Name = "panelFilterArchived";
            panelFilterArchived.Size = new System.Drawing.Size(866, 24);
            panelFilterArchived.TabIndex = 3;
            // 
            // radioFilterActive
            // 
            radioFilterActive.AutoSize = true;
            radioFilterActive.Location = new System.Drawing.Point(3, 3);
            radioFilterActive.Name = "radioFilterActive";
            radioFilterActive.Size = new System.Drawing.Size(67, 19);
            radioFilterActive.TabIndex = 0;
            radioFilterActive.TabStop = true;
            radioFilterActive.Text = "Активні";
            radioFilterActive.UseVisualStyleBackColor = true;
            radioFilterActive.CheckedChanged += radioFilterActive_CheckedChanged;
            // 
            // radioFilterArchived
            // 
            radioFilterArchived.AutoSize = true;
            radioFilterArchived.Location = new System.Drawing.Point(76, 3);
            radioFilterArchived.Name = "radioFilterArchived";
            radioFilterArchived.Size = new System.Drawing.Size(65, 19);
            radioFilterArchived.TabIndex = 0;
            radioFilterArchived.TabStop = true;
            radioFilterArchived.Text = "В архіві";
            radioFilterArchived.UseVisualStyleBackColor = true;
            radioFilterArchived.CheckedChanged += radioFilterArchived_CheckedChanged;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(label2);
            panelFilter.Controls.Add(cbFilterRadioStation);
            panelFilter.Controls.Add(label3);
            panelFilter.Controls.Add(cbFilterStartYear);
            panelFilter.Controls.Add(cbFilterStartMonth);
            panelFilter.Controls.Add(label4);
            panelFilter.Controls.Add(cbFilterEndYear);
            panelFilter.Controls.Add(cbFilterEndMonth);
            panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFilter.Location = new System.Drawing.Point(3, 63);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(866, 29);
            panelFilter.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label2.Size = new System.Drawing.Size(92, 21);
            label2.TabIndex = 0;
            label2.Text = "Від радіостанції";
            // 
            // cbFilterRadioStation
            // 
            cbFilterRadioStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterRadioStation.FormattingEnabled = true;
            cbFilterRadioStation.Location = new System.Drawing.Point(101, 3);
            cbFilterRadioStation.Name = "cbFilterRadioStation";
            cbFilterRadioStation.Size = new System.Drawing.Size(121, 23);
            cbFilterRadioStation.TabIndex = 2;
            cbFilterRadioStation.SelectedIndexChanged += cbFilterRadioStation_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(228, 0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label3.Size = new System.Drawing.Size(75, 21);
            label3.TabIndex = 0;
            label3.Text = "за період від";
            // 
            // cbFilterStartYear
            // 
            cbFilterStartYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterStartYear.FormattingEnabled = true;
            cbFilterStartYear.Location = new System.Drawing.Point(309, 3);
            cbFilterStartYear.Name = "cbFilterStartYear";
            cbFilterStartYear.Size = new System.Drawing.Size(54, 23);
            cbFilterStartYear.TabIndex = 2;
            cbFilterStartYear.SelectedIndexChanged += cbFilterStartYear_SelectedIndexChanged;
            // 
            // cbFilterStartMonth
            // 
            cbFilterStartMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterStartMonth.FormattingEnabled = true;
            cbFilterStartMonth.Location = new System.Drawing.Point(369, 3);
            cbFilterStartMonth.Name = "cbFilterStartMonth";
            cbFilterStartMonth.Size = new System.Drawing.Size(54, 23);
            cbFilterStartMonth.TabIndex = 1;
            cbFilterStartMonth.SelectedIndexChanged += cbFilterStartMonth_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(429, 0);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label4.Size = new System.Drawing.Size(20, 21);
            label4.TabIndex = 0;
            label4.Text = "до";
            // 
            // cbFilterEndYear
            // 
            cbFilterEndYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterEndYear.FormattingEnabled = true;
            cbFilterEndYear.Location = new System.Drawing.Point(455, 3);
            cbFilterEndYear.Name = "cbFilterEndYear";
            cbFilterEndYear.Size = new System.Drawing.Size(54, 23);
            cbFilterEndYear.TabIndex = 2;
            cbFilterEndYear.SelectedIndexChanged += cbFilterEndYear_SelectedIndexChanged;
            // 
            // cbFilterEndMonth
            // 
            cbFilterEndMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFilterEndMonth.FormattingEnabled = true;
            cbFilterEndMonth.Location = new System.Drawing.Point(515, 3);
            cbFilterEndMonth.Name = "cbFilterEndMonth";
            cbFilterEndMonth.Size = new System.Drawing.Size(54, 23);
            cbFilterEndMonth.TabIndex = 1;
            cbFilterEndMonth.SelectedIndexChanged += cbFilterEndMonth_SelectedIndexChanged;
            // 
            // splitPanelReports
            // 
            splitPanelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            splitPanelReports.Location = new System.Drawing.Point(3, 98);
            splitPanelReports.Name = "splitPanelReports";
            // 
            // splitPanelReports.Panel1
            // 
            splitPanelReports.Panel1.Controls.Add(panelReportMain);
            // 
            // splitPanelReports.Panel2
            // 
            splitPanelReports.Panel2.Controls.Add(panelReportDetails);
            splitPanelReports.Size = new System.Drawing.Size(866, 357);
            splitPanelReports.SplitterDistance = 556;
            splitPanelReports.TabIndex = 5;
            // 
            // panelReportMain
            // 
            panelReportMain.ColumnCount = 1;
            panelReportMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportMain.Controls.Add(lvReports, 0, 1);
            panelReportMain.Controls.Add(panelReportMainInfoTitle, 0, 0);
            panelReportMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReportMain.Location = new System.Drawing.Point(0, 0);
            panelReportMain.Name = "panelReportMain";
            panelReportMain.RowCount = 2;
            panelReportMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            panelReportMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportMain.Size = new System.Drawing.Size(556, 357);
            panelReportMain.TabIndex = 0;
            // 
            // lvReports
            // 
            lvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            lvReports.FullRowSelect = true;
            lvReports.GridLines = true;
            lvReports.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvReports.HideSelection = false;
            lvReports.Location = new System.Drawing.Point(3, 36);
            lvReports.MultiSelect = false;
            lvReports.Name = "lvReports";
            lvReports.Size = new System.Drawing.Size(550, 318);
            lvReports.TabIndex = 2;
            lvReports.UseCompatibleStateImageBehavior = false;
            lvReports.View = System.Windows.Forms.View.Details;
            lvReports.SelectedIndexChanged += lvReports_SelectedIndexChanged;
            lvReports.DoubleClick += lvReports_DoubleClick;
            lvReports.MouseDown += lvReports_MouseDown;
            // 
            // panelReportMainInfoTitle
            // 
            panelReportMainInfoTitle.ColumnCount = 2;
            panelReportMainInfoTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportMainInfoTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            panelReportMainInfoTitle.Controls.Add(label5, 0, 0);
            panelReportMainInfoTitle.Controls.Add(btnShowDetails, 1, 0);
            panelReportMainInfoTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReportMainInfoTitle.Location = new System.Drawing.Point(3, 3);
            panelReportMainInfoTitle.Name = "panelReportMainInfoTitle";
            panelReportMainInfoTitle.RowCount = 1;
            panelReportMainInfoTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportMainInfoTitle.Size = new System.Drawing.Size(550, 27);
            panelReportMainInfoTitle.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 0);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            label5.Size = new System.Drawing.Size(120, 17);
            label5.TabIndex = 3;
            label5.Text = "Головна інформація";
            // 
            // btnShowDetails
            // 
            btnShowDetails.Location = new System.Drawing.Point(526, 3);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new System.Drawing.Size(21, 21);
            btnShowDetails.TabIndex = 4;
            btnShowDetails.UseVisualStyleBackColor = true;
            btnShowDetails.Click += btnShowDetails_Click;
            // 
            // panelReportDetails
            // 
            panelReportDetails.ColumnCount = 1;
            panelReportDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportDetails.Controls.Add(label6, 0, 0);
            panelReportDetails.Controls.Add(panelReportDetailValues, 0, 1);
            panelReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReportDetails.Location = new System.Drawing.Point(0, 0);
            panelReportDetails.Name = "panelReportDetails";
            panelReportDetails.RowCount = 2;
            panelReportDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            panelReportDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportDetails.Size = new System.Drawing.Size(306, 357);
            panelReportDetails.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 0);
            label6.Name = "label6";
            label6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label6.Size = new System.Drawing.Size(42, 21);
            label6.TabIndex = 3;
            label6.Text = "Деталі";
            // 
            // panelReportDetailValues
            // 
            panelReportDetailValues.ColumnCount = 1;
            panelReportDetailValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportDetailValues.Controls.Add(label7, 0, 2);
            panelReportDetailValues.Controls.Add(tbReportFilePath, 0, 3);
            panelReportDetailValues.Controls.Add(label9, 0, 4);
            panelReportDetailValues.Controls.Add(label8, 0, 8);
            panelReportDetailValues.Controls.Add(label10, 0, 10);
            panelReportDetailValues.Controls.Add(tbReportWorkFilesPath, 0, 5);
            panelReportDetailValues.Controls.Add(tbReportSearchFile, 0, 9);
            panelReportDetailValues.Controls.Add(tbReportDistributionFile, 0, 11);
            panelReportDetailValues.Controls.Add(label11, 0, 0);
            panelReportDetailValues.Controls.Add(tbReportFileName, 0, 1);
            panelReportDetailValues.Controls.Add(label12, 0, 6);
            panelReportDetailValues.Controls.Add(tbReprotSourceFileCopyName, 0, 7);
            panelReportDetailValues.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReportDetailValues.Location = new System.Drawing.Point(3, 37);
            panelReportDetailValues.Name = "panelReportDetailValues";
            panelReportDetailValues.RowCount = 13;
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            panelReportDetailValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            panelReportDetailValues.Size = new System.Drawing.Size(300, 317);
            panelReportDetailValues.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 55);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(197, 15);
            label7.TabIndex = 0;
            label7.Text = "Розташування початкового файлу";
            // 
            // tbReportFilePath
            // 
            tbReportFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            tbReportFilePath.Location = new System.Drawing.Point(3, 79);
            tbReportFilePath.Name = "tbReportFilePath";
            tbReportFilePath.ReadOnly = true;
            tbReportFilePath.Size = new System.Drawing.Size(294, 23);
            tbReportFilePath.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(3, 110);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(177, 15);
            label9.TabIndex = 0;
            label9.Text = "Розташування робочих файлів";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(3, 217);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(82, 15);
            label8.TabIndex = 0;
            label8.Text = "Файл пошуку";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(3, 264);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(94, 15);
            label10.TabIndex = 0;
            label10.Text = "Файл розподілу";
            // 
            // tbReportWorkFilesPath
            // 
            tbReportWorkFilesPath.Dock = System.Windows.Forms.DockStyle.Fill;
            tbReportWorkFilesPath.Location = new System.Drawing.Point(3, 134);
            tbReportWorkFilesPath.Name = "tbReportWorkFilesPath";
            tbReportWorkFilesPath.ReadOnly = true;
            tbReportWorkFilesPath.Size = new System.Drawing.Size(294, 23);
            tbReportWorkFilesPath.TabIndex = 2;
            // 
            // tbReportSearchFile
            // 
            tbReportSearchFile.Dock = System.Windows.Forms.DockStyle.Fill;
            tbReportSearchFile.Location = new System.Drawing.Point(3, 238);
            tbReportSearchFile.Name = "tbReportSearchFile";
            tbReportSearchFile.ReadOnly = true;
            tbReportSearchFile.Size = new System.Drawing.Size(294, 23);
            tbReportSearchFile.TabIndex = 2;
            // 
            // tbReportDistributionFile
            // 
            tbReportDistributionFile.Dock = System.Windows.Forms.DockStyle.Fill;
            tbReportDistributionFile.Location = new System.Drawing.Point(3, 285);
            tbReportDistributionFile.Name = "tbReportDistributionFile";
            tbReportDistributionFile.ReadOnly = true;
            tbReportDistributionFile.Size = new System.Drawing.Size(294, 23);
            tbReportDistributionFile.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(3, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(77, 15);
            label11.TabIndex = 3;
            label11.Text = "Назва файлу";
            // 
            // tbReportFileName
            // 
            tbReportFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbReportFileName.Location = new System.Drawing.Point(3, 24);
            tbReportFileName.Name = "tbReportFileName";
            tbReportFileName.ReadOnly = true;
            tbReportFileName.Size = new System.Drawing.Size(294, 23);
            tbReportFileName.TabIndex = 4;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(3, 162);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(148, 15);
            label12.TabIndex = 5;
            label12.Text = "Копія початкового файлу";
            // 
            // tbReprotSourceFileCopyName
            // 
            tbReprotSourceFileCopyName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbReprotSourceFileCopyName.Location = new System.Drawing.Point(3, 186);
            tbReprotSourceFileCopyName.Name = "tbReprotSourceFileCopyName";
            tbReprotSourceFileCopyName.ReadOnly = true;
            tbReprotSourceFileCopyName.Size = new System.Drawing.Size(294, 23);
            tbReprotSourceFileCopyName.TabIndex = 6;
            // 
            // openFileDlg
            // 
            openFileDlg.FileName = "openFileDialog1";
            // 
            // timerApplyFilter
            // 
            timerApplyFilter.Tick += timerApplyFilter_Tick;
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
            // UcRegisteredReports
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelMain);
            Name = "UcRegisteredReports";
            Size = new System.Drawing.Size(872, 524);
            Load += UcRegisteredReports_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelFilterArchived.ResumeLayout(false);
            panelFilterArchived.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            splitPanelReports.Panel1.ResumeLayout(false);
            splitPanelReports.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitPanelReports).EndInit();
            splitPanelReports.ResumeLayout(false);
            panelReportMain.ResumeLayout(false);
            panelReportMainInfoTitle.ResumeLayout(false);
            panelReportMainInfoTitle.PerformLayout();
            panelReportDetails.ResumeLayout(false);
            panelReportDetails.PerformLayout();
            panelReportDetailValues.ResumeLayout(false);
            panelReportDetailValues.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.Button btnArhive;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.FlowLayoutPanel panelFilterArchived;
        private System.Windows.Forms.RadioButton radioFilterActive;
        private System.Windows.Forms.RadioButton radioFilterArchived;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilterRadioStation;
        private System.Windows.Forms.ComboBox cbFilterStartYear;
        private System.Windows.Forms.ComboBox cbFilterStartMonth;
        private System.Windows.Forms.ComboBox cbFilterEndYear;
        private System.Windows.Forms.ComboBox cbFilterEndMonth;
        private System.Windows.Forms.SplitContainer splitPanelReports;
        private System.Windows.Forms.TableLayoutPanel panelReportMain;
        private System.Windows.Forms.TableLayoutPanel panelReportDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel panelReportDetailValues;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbReportFilePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbReportWorkFilesPath;
        private System.Windows.Forms.TextBox tbReportSearchFile;
        private System.Windows.Forms.TextBox tbReportDistributionFile;
        private System.Windows.Forms.TableLayoutPanel panelReportMainInfoTitle;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbReportFileName;
        private System.Windows.Forms.Timer timerApplyFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbReprotSourceFileCopyName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
    }
}
