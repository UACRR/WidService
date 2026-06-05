namespace SmartViewer
{
    partial class UcSearchIpiCodes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.panelRightHolders = new System.Windows.Forms.TableLayoutPanel();
            this.panelRightHolderFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowRightHolders = new System.Windows.Forms.Button();
            this.ucRightHolders = new SmartViewer.UcListViewBase();
            this.panelSearch = new System.Windows.Forms.TableLayoutPanel();
            this.panelRightHolderName = new System.Windows.Forms.FlowLayoutPanel();
            this.labSearchTitle = new System.Windows.Forms.Label();
            this.ucFoundCodes = new SmartViewer.UcListViewBase();
            this.label4 = new System.Windows.Forms.Label();
            this.panelSourceNames = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMsName = new System.Windows.Forms.TextBox();
            this.tbMsNameTr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbIpBaseNr = new System.Windows.Forms.TextBox();
            this.tbIpNameNr = new System.Windows.Forms.TextBox();
            this.panelSearchName = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSearchName = new System.Windows.Forms.TextBox();
            this.rbEqual1 = new System.Windows.Forms.RadioButton();
            this.rbStarts1 = new System.Windows.Forms.RadioButton();
            this.rbContains1 = new System.Windows.Forms.RadioButton();
            this.panelSearchFirstName = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSearchFirstName = new System.Windows.Forms.TextBox();
            this.rbEqual2 = new System.Windows.Forms.RadioButton();
            this.rbStarts2 = new System.Windows.Forms.RadioButton();
            this.rbContains2 = new System.Windows.Forms.RadioButton();
            this.panelDoSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDoSearch = new System.Windows.Forms.Button();
            this.panelApplyRightHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.btnApplyCodes = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rbIgnore1 = new System.Windows.Forms.RadioButton();
            this.rbIgnore2 = new System.Windows.Forms.RadioButton();
            this.panelSearchTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSwapSearchParameters = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelRightHolders.SuspendLayout();
            this.panelRightHolderFilter.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelRightHolderName.SuspendLayout();
            this.panelSourceNames.SuspendLayout();
            this.panelSearchName.SuspendLayout();
            this.panelSearchFirstName.SuspendLayout();
            this.panelDoSearch.SuspendLayout();
            this.panelApplyRightHolder.SuspendLayout();
            this.panelSearchTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(993, 498);
            this.panelMain.TabIndex = 0;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(3, 17);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.panelRightHolders);
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.panelSearch);
            this.panelMiddle.Size = new System.Drawing.Size(979, 458);
            this.panelMiddle.SplitterDistance = 284;
            this.panelMiddle.TabIndex = 1;
            // 
            // panelRightHolders
            // 
            this.panelRightHolders.ColumnCount = 2;
            this.panelRightHolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRightHolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelRightHolders.Controls.Add(this.panelRightHolderFilter, 0, 0);
            this.panelRightHolders.Controls.Add(this.ucRightHolders, 0, 1);
            this.panelRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightHolders.Location = new System.Drawing.Point(0, 0);
            this.panelRightHolders.Name = "panelRightHolders";
            this.panelRightHolders.RowCount = 4;
            this.panelRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.633094F));
            this.panelRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.36691F));
            this.panelRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelRightHolders.Size = new System.Drawing.Size(284, 458);
            this.panelRightHolders.TabIndex = 0;
            // 
            // panelRightHolderFilter
            // 
            this.panelRightHolderFilter.Controls.Add(this.label1);
            this.panelRightHolderFilter.Controls.Add(this.btnShowRightHolders);
            this.panelRightHolderFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightHolderFilter.Location = new System.Drawing.Point(3, 3);
            this.panelRightHolderFilter.Name = "panelRightHolderFilter";
            this.panelRightHolderFilter.Size = new System.Drawing.Size(270, 30);
            this.panelRightHolderFilter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Правовласники";
            // 
            // btnShowRightHolders
            // 
            this.btnShowRightHolders.Location = new System.Drawing.Point(96, 3);
            this.btnShowRightHolders.Name = "btnShowRightHolders";
            this.btnShowRightHolders.Size = new System.Drawing.Size(75, 23);
            this.btnShowRightHolders.TabIndex = 1;
            this.btnShowRightHolders.Text = "Вибрати";
            this.btnShowRightHolders.UseVisualStyleBackColor = true;
            this.btnShowRightHolders.Click += new System.EventHandler(this.btnShowRightHolders_Click_1);
            // 
            // ucRightHolders
            // 
            this.ucRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRightHolders.Location = new System.Drawing.Point(3, 39);
            this.ucRightHolders.Name = "ucRightHolders";
            this.ucRightHolders.Size = new System.Drawing.Size(270, 375);
            this.ucRightHolders.SqlSelect = null;
            this.ucRightHolders.TabIndex = 1;
            // 
            // panelSearch
            // 
            this.panelSearch.ColumnCount = 2;
            this.panelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelSearch.Controls.Add(this.panelRightHolderName, 0, 0);
            this.panelSearch.Controls.Add(this.panelSearchTitle, 0, 2);
            this.panelSearch.Controls.Add(this.ucFoundCodes, 0, 7);
            this.panelSearch.Controls.Add(this.label4, 0, 6);
            this.panelSearch.Controls.Add(this.panelSourceNames, 0, 1);
            this.panelSearch.Controls.Add(this.panelSearchName, 0, 3);
            this.panelSearch.Controls.Add(this.panelSearchFirstName, 0, 4);
            this.panelSearch.Controls.Add(this.panelDoSearch, 0, 5);
            this.panelSearch.Controls.Add(this.panelApplyRightHolder, 0, 8);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.RowCount = 9;
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelSearch.Size = new System.Drawing.Size(691, 458);
            this.panelSearch.TabIndex = 0;
            // 
            // panelRightHolderName
            // 
            this.panelRightHolderName.Controls.Add(this.labSearchTitle);
            this.panelRightHolderName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightHolderName.Location = new System.Drawing.Point(3, 3);
            this.panelRightHolderName.Name = "panelRightHolderName";
            this.panelRightHolderName.Size = new System.Drawing.Size(677, 32);
            this.panelRightHolderName.TabIndex = 0;
            // 
            // labSearchTitle
            // 
            this.labSearchTitle.AutoSize = true;
            this.labSearchTitle.Location = new System.Drawing.Point(3, 0);
            this.labSearchTitle.Name = "labSearchTitle";
            this.labSearchTitle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labSearchTitle.Size = new System.Drawing.Size(201, 20);
            this.labSearchTitle.TabIndex = 0;
            this.labSearchTitle.Text = "Деталі селектованого правовласника";
            // 
            // ucFoundCodes
            // 
            this.ucFoundCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFoundCodes.Location = new System.Drawing.Point(3, 246);
            this.ucFoundCodes.Name = "ucFoundCodes";
            this.ucFoundCodes.Size = new System.Drawing.Size(677, 172);
            this.ucFoundCodes.SqlSelect = null;
            this.ucFoundCodes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Знайдено в IPI";
            // 
            // panelSourceNames
            // 
            this.panelSourceNames.ColumnCount = 4;
            this.panelSourceNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.49871F));
            this.panelSourceNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.50129F));
            this.panelSourceNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.panelSourceNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.panelSourceNames.Controls.Add(this.label5, 0, 0);
            this.panelSourceNames.Controls.Add(this.tbMsName, 0, 1);
            this.panelSourceNames.Controls.Add(this.tbMsNameTr, 1, 1);
            this.panelSourceNames.Controls.Add(this.label6, 1, 0);
            this.panelSourceNames.Controls.Add(this.label2, 2, 0);
            this.panelSourceNames.Controls.Add(this.label9, 3, 0);
            this.panelSourceNames.Controls.Add(this.tbIpBaseNr, 2, 1);
            this.panelSourceNames.Controls.Add(this.tbIpNameNr, 3, 1);
            this.panelSourceNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSourceNames.Location = new System.Drawing.Point(3, 41);
            this.panelSourceNames.Name = "panelSourceNames";
            this.panelSourceNames.RowCount = 2;
            this.panelSourceNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSourceNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSourceNames.Size = new System.Drawing.Size(677, 49);
            this.panelSourceNames.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Оригінальна назва";
            // 
            // tbMsName
            // 
            this.tbMsName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMsName.Location = new System.Drawing.Point(3, 23);
            this.tbMsName.Name = "tbMsName";
            this.tbMsName.ReadOnly = true;
            this.tbMsName.Size = new System.Drawing.Size(259, 20);
            this.tbMsName.TabIndex = 2;
            // 
            // tbMsNameTr
            // 
            this.tbMsNameTr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMsNameTr.Location = new System.Drawing.Point(268, 23);
            this.tbMsNameTr.Name = "tbMsNameTr";
            this.tbMsNameTr.ReadOnly = true;
            this.tbMsNameTr.Size = new System.Drawing.Size(215, 20);
            this.tbMsNameTr.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Транслітерована назва";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Базовий код";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(576, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Код назви";
            // 
            // tbIpBaseNr
            // 
            this.tbIpBaseNr.Location = new System.Drawing.Point(489, 23);
            this.tbIpBaseNr.Name = "tbIpBaseNr";
            this.tbIpBaseNr.ReadOnly = true;
            this.tbIpBaseNr.Size = new System.Drawing.Size(81, 20);
            this.tbIpBaseNr.TabIndex = 3;
            // 
            // tbIpNameNr
            // 
            this.tbIpNameNr.Location = new System.Drawing.Point(576, 23);
            this.tbIpNameNr.Name = "tbIpNameNr";
            this.tbIpNameNr.ReadOnly = true;
            this.tbIpNameNr.Size = new System.Drawing.Size(89, 20);
            this.tbIpNameNr.TabIndex = 3;
            // 
            // panelSearchName
            // 
            this.panelSearchName.Controls.Add(this.label7);
            this.panelSearchName.Controls.Add(this.tbSearchName);
            this.panelSearchName.Controls.Add(this.rbEqual1);
            this.panelSearchName.Controls.Add(this.rbStarts1);
            this.panelSearchName.Controls.Add(this.rbContains1);
            this.panelSearchName.Controls.Add(this.rbIgnore1);
            this.panelSearchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearchName.Location = new System.Drawing.Point(3, 131);
            this.panelSearchName.Name = "panelSearchName";
            this.panelSearchName.Size = new System.Drawing.Size(677, 26);
            this.panelSearchName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label7.Size = new System.Drawing.Size(98, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Назва/Прізвище";
            // 
            // tbSearchName
            // 
            this.tbSearchName.Location = new System.Drawing.Point(107, 3);
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.Size = new System.Drawing.Size(141, 20);
            this.tbSearchName.TabIndex = 1;
            // 
            // rbEqual1
            // 
            this.rbEqual1.AutoSize = true;
            this.rbEqual1.Checked = true;
            this.rbEqual1.Location = new System.Drawing.Point(254, 3);
            this.rbEqual1.Name = "rbEqual1";
            this.rbEqual1.Size = new System.Drawing.Size(76, 17);
            this.rbEqual1.TabIndex = 2;
            this.rbEqual1.TabStop = true;
            this.rbEqual1.Text = "Співпадає";
            this.rbEqual1.UseVisualStyleBackColor = true;
            // 
            // rbStarts1
            // 
            this.rbStarts1.AutoSize = true;
            this.rbStarts1.Location = new System.Drawing.Point(336, 3);
            this.rbStarts1.Name = "rbStarts1";
            this.rbStarts1.Size = new System.Drawing.Size(81, 17);
            this.rbStarts1.TabIndex = 2;
            this.rbStarts1.Text = "На початку";
            this.rbStarts1.UseVisualStyleBackColor = true;
            // 
            // rbContains1
            // 
            this.rbContains1.AutoSize = true;
            this.rbContains1.Location = new System.Drawing.Point(423, 3);
            this.rbContains1.Name = "rbContains1";
            this.rbContains1.Size = new System.Drawing.Size(95, 17);
            this.rbContains1.TabIndex = 2;
            this.rbContains1.Text = "Містить текст";
            this.rbContains1.UseVisualStyleBackColor = true;
            // 
            // panelSearchFirstName
            // 
            this.panelSearchFirstName.Controls.Add(this.label8);
            this.panelSearchFirstName.Controls.Add(this.tbSearchFirstName);
            this.panelSearchFirstName.Controls.Add(this.rbEqual2);
            this.panelSearchFirstName.Controls.Add(this.rbStarts2);
            this.panelSearchFirstName.Controls.Add(this.rbContains2);
            this.panelSearchFirstName.Controls.Add(this.rbIgnore2);
            this.panelSearchFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearchFirstName.Location = new System.Drawing.Point(3, 163);
            this.panelSearchFirstName.Name = "panelSearchFirstName";
            this.panelSearchFirstName.Size = new System.Drawing.Size(677, 26);
            this.panelSearchFirstName.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label8.Size = new System.Drawing.Size(98, 30);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ім\'я і По батькові";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbSearchFirstName
            // 
            this.tbSearchFirstName.Location = new System.Drawing.Point(107, 3);
            this.tbSearchFirstName.Name = "tbSearchFirstName";
            this.tbSearchFirstName.Size = new System.Drawing.Size(141, 20);
            this.tbSearchFirstName.TabIndex = 1;
            // 
            // rbEqual2
            // 
            this.rbEqual2.AutoSize = true;
            this.rbEqual2.Checked = true;
            this.rbEqual2.Location = new System.Drawing.Point(254, 3);
            this.rbEqual2.Name = "rbEqual2";
            this.rbEqual2.Size = new System.Drawing.Size(76, 17);
            this.rbEqual2.TabIndex = 2;
            this.rbEqual2.TabStop = true;
            this.rbEqual2.Text = "Співпадає";
            this.rbEqual2.UseVisualStyleBackColor = true;
            // 
            // rbStarts2
            // 
            this.rbStarts2.AutoSize = true;
            this.rbStarts2.Location = new System.Drawing.Point(336, 3);
            this.rbStarts2.Name = "rbStarts2";
            this.rbStarts2.Size = new System.Drawing.Size(81, 17);
            this.rbStarts2.TabIndex = 2;
            this.rbStarts2.Text = "На початку";
            this.rbStarts2.UseVisualStyleBackColor = true;
            // 
            // rbContains2
            // 
            this.rbContains2.AutoSize = true;
            this.rbContains2.Location = new System.Drawing.Point(423, 3);
            this.rbContains2.Name = "rbContains2";
            this.rbContains2.Size = new System.Drawing.Size(95, 17);
            this.rbContains2.TabIndex = 2;
            this.rbContains2.Text = "Містить текст";
            this.rbContains2.UseVisualStyleBackColor = true;
            // 
            // panelDoSearch
            // 
            this.panelDoSearch.Controls.Add(this.btnDoSearch);
            this.panelDoSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDoSearch.Location = new System.Drawing.Point(3, 195);
            this.panelDoSearch.Name = "panelDoSearch";
            this.panelDoSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelDoSearch.Size = new System.Drawing.Size(677, 27);
            this.panelDoSearch.TabIndex = 7;
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Location = new System.Drawing.Point(599, 3);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(75, 23);
            this.btnDoSearch.TabIndex = 0;
            this.btnDoSearch.Text = "Шукати";
            this.btnDoSearch.UseVisualStyleBackColor = true;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // panelApplyRightHolder
            // 
            this.panelApplyRightHolder.Controls.Add(this.btnApplyCodes);
            this.panelApplyRightHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApplyRightHolder.Location = new System.Drawing.Point(3, 424);
            this.panelApplyRightHolder.Name = "panelApplyRightHolder";
            this.panelApplyRightHolder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelApplyRightHolder.Size = new System.Drawing.Size(677, 31);
            this.panelApplyRightHolder.TabIndex = 8;
            // 
            // btnApplyCodes
            // 
            this.btnApplyCodes.Location = new System.Drawing.Point(533, 3);
            this.btnApplyCodes.Name = "btnApplyCodes";
            this.btnApplyCodes.Size = new System.Drawing.Size(141, 23);
            this.btnApplyCodes.TabIndex = 0;
            this.btnApplyCodes.Text = "Застосувати коди";
            this.btnApplyCodes.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // rbIgnore1
            // 
            this.rbIgnore1.AutoSize = true;
            this.rbIgnore1.Location = new System.Drawing.Point(524, 3);
            this.rbIgnore1.Name = "rbIgnore1";
            this.rbIgnore1.Size = new System.Drawing.Size(79, 17);
            this.rbIgnore1.TabIndex = 2;
            this.rbIgnore1.Text = "Ігнорувати";
            this.rbIgnore1.UseVisualStyleBackColor = true;
            // 
            // rbIgnore2
            // 
            this.rbIgnore2.AutoSize = true;
            this.rbIgnore2.Location = new System.Drawing.Point(524, 3);
            this.rbIgnore2.Name = "rbIgnore2";
            this.rbIgnore2.Size = new System.Drawing.Size(79, 17);
            this.rbIgnore2.TabIndex = 2;
            this.rbIgnore2.Text = "Ігнорувати";
            this.rbIgnore2.UseVisualStyleBackColor = true;
            // 
            // panelSearchTitle
            // 
            this.panelSearchTitle.Controls.Add(this.label3);
            this.panelSearchTitle.Controls.Add(this.btnSwapSearchParameters);
            this.panelSearchTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearchTitle.Location = new System.Drawing.Point(3, 96);
            this.panelSearchTitle.Name = "panelSearchTitle";
            this.panelSearchTitle.Size = new System.Drawing.Size(677, 29);
            this.panelSearchTitle.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Параметри для пошуку";
            // 
            // btnSwapSearchParameters
            // 
            this.btnSwapSearchParameters.Location = new System.Drawing.Point(133, 3);
            this.btnSwapSearchParameters.Name = "btnSwapSearchParameters";
            this.btnSwapSearchParameters.Size = new System.Drawing.Size(141, 23);
            this.btnSwapSearchParameters.TabIndex = 1;
            this.btnSwapSearchParameters.Text = "Переставити місцями";
            this.btnSwapSearchParameters.UseVisualStyleBackColor = true;
            this.btnSwapSearchParameters.Click += new System.EventHandler(this.btnSwapSearchParameters_Click);
            // 
            // UcSearchIpiCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcSearchIpiCodes";
            this.Size = new System.Drawing.Size(993, 498);
            this.Load += new System.EventHandler(this.UcSearchIpiCodes_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.panelRightHolders.ResumeLayout(false);
            this.panelRightHolderFilter.ResumeLayout(false);
            this.panelRightHolderFilter.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelRightHolderName.ResumeLayout(false);
            this.panelRightHolderName.PerformLayout();
            this.panelSourceNames.ResumeLayout(false);
            this.panelSourceNames.PerformLayout();
            this.panelSearchName.ResumeLayout(false);
            this.panelSearchName.PerformLayout();
            this.panelSearchFirstName.ResumeLayout(false);
            this.panelSearchFirstName.PerformLayout();
            this.panelDoSearch.ResumeLayout(false);
            this.panelApplyRightHolder.ResumeLayout(false);
            this.panelSearchTitle.ResumeLayout(false);
            this.panelSearchTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.TableLayoutPanel panelRightHolders;
        private System.Windows.Forms.FlowLayoutPanel panelRightHolderFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowRightHolders;
        private System.Windows.Forms.TableLayoutPanel panelSearch;
        private System.Windows.Forms.FlowLayoutPanel panelRightHolderName;
        private System.Windows.Forms.Label labSearchTitle;
        private System.Windows.Forms.TextBox tbMsName;
        private System.Windows.Forms.TextBox tbMsNameTr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel panelSourceNames;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel panelSearchName;
        private System.Windows.Forms.FlowLayoutPanel panelSearchFirstName;
        private System.Windows.Forms.FlowLayoutPanel panelDoSearch;
        private System.Windows.Forms.FlowLayoutPanel panelApplyRightHolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSearchName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSearchFirstName;
        private System.Windows.Forms.Button btnDoSearch;
        private System.Windows.Forms.Button btnApplyCodes;
        private System.Windows.Forms.RadioButton rbEqual1;
        private System.Windows.Forms.RadioButton rbStarts1;
        private System.Windows.Forms.RadioButton rbContains1;
        private System.Windows.Forms.RadioButton rbEqual2;
        private System.Windows.Forms.RadioButton rbStarts2;
        private System.Windows.Forms.RadioButton rbContains2;
        private UcListViewBase ucRightHolders;
        private UcListViewBase ucFoundCodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbIpBaseNr;
        private System.Windows.Forms.TextBox tbIpNameNr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RadioButton rbIgnore1;
        private System.Windows.Forms.RadioButton rbIgnore2;
        private System.Windows.Forms.FlowLayoutPanel panelSearchTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSwapSearchParameters;
    }
}
