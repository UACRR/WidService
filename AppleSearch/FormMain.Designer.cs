
namespace AppleSearch
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitTop = new System.Windows.Forms.SplitContainer();
            this.panelLocalWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvLocalWorks = new System.Windows.Forms.ListView();
            this.ilState = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelLocalWorksFilter = new System.Windows.Forms.TableLayoutPanel();
            this.labLocalWorksAuthor = new System.Windows.Forms.Label();
            this.btnLocalWorksAuthorSearch = new System.Windows.Forms.Button();
            this.cbHistAuthors = new System.Windows.Forms.ComboBox();
            this.panelButtonsLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAutoJoin = new System.Windows.Forms.Button();
            this.panelLocalSearchLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLocalSearchLeft = new System.Windows.Forms.TextBox();
            this.btnLocalSearchLeft = new System.Windows.Forms.Button();
            this.btnLocalSearchLeftCancel = new System.Windows.Forms.Button();
            this.panelReportWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvReportWorks = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelReportWorksFilter = new System.Windows.Forms.TableLayoutPanel();
            this.btnReportWorksSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripHistAuthorFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReportFilterPerformer = new System.Windows.Forms.TextBox();
            this.tbReportFilterAuthor = new System.Windows.Forms.TextBox();
            this.tbReportFilterName = new System.Windows.Forms.TextBox();
            this.panelButtonsRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnJoinSelectedReportWorks = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnShowLocalWork = new System.Windows.Forms.Button();
            this.panelLocalSearchRight = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLocalSearchRight = new System.Windows.Forms.TextBox();
            this.btnLocalSearchRight = new System.Windows.Forms.Button();
            this.btnLocalSearchRightCancel = new System.Windows.Forms.Button();
            this.panelFoundWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvFoundWorks = new System.Windows.Forms.ListView();
            this.labFoundWorksTitle = new System.Windows.Forms.Label();
            this.panelBottomButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDisjoin = new System.Windows.Forms.Button();
            this.panelFileExchange = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadReportFile = new System.Windows.Forms.Button();
            this.btnCreateInvoiceFilePub = new System.Windows.Forms.Button();
            this.btnCreateInvoiceMec = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTop)).BeginInit();
            this.splitTop.Panel1.SuspendLayout();
            this.splitTop.Panel2.SuspendLayout();
            this.splitTop.SuspendLayout();
            this.panelLocalWorks.SuspendLayout();
            this.panelLocalWorksFilter.SuspendLayout();
            this.panelButtonsLeft.SuspendLayout();
            this.panelLocalSearchLeft.SuspendLayout();
            this.panelReportWorks.SuspendLayout();
            this.panelReportWorksFilter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelButtonsRight.SuspendLayout();
            this.panelLocalSearchRight.SuspendLayout();
            this.panelFoundWorks.SuspendLayout();
            this.panelBottomButtons.SuspendLayout();
            this.panelFileExchange.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.splitMain, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(1050, 532);
            this.panelMain.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(4, 13);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitTop);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.panelFoundWorks);
            this.splitMain.Size = new System.Drawing.Size(1042, 506);
            this.splitMain.SplitterDistance = 279;
            this.splitMain.TabIndex = 0;
            // 
            // splitTop
            // 
            this.splitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitTop.Location = new System.Drawing.Point(0, 0);
            this.splitTop.Name = "splitTop";
            // 
            // splitTop.Panel1
            // 
            this.splitTop.Panel1.Controls.Add(this.panelLocalWorks);
            // 
            // splitTop.Panel2
            // 
            this.splitTop.Panel2.Controls.Add(this.panelReportWorks);
            this.splitTop.Size = new System.Drawing.Size(1042, 279);
            this.splitTop.SplitterDistance = 508;
            this.splitTop.TabIndex = 0;
            // 
            // panelLocalWorks
            // 
            this.panelLocalWorks.ColumnCount = 1;
            this.panelLocalWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorks.Controls.Add(this.lvLocalWorks, 0, 3);
            this.panelLocalWorks.Controls.Add(this.label1, 0, 0);
            this.panelLocalWorks.Controls.Add(this.panelLocalWorksFilter, 0, 1);
            this.panelLocalWorks.Controls.Add(this.panelButtonsLeft, 0, 4);
            this.panelLocalWorks.Controls.Add(this.panelLocalSearchLeft, 0, 2);
            this.panelLocalWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocalWorks.Location = new System.Drawing.Point(0, 0);
            this.panelLocalWorks.Name = "panelLocalWorks";
            this.panelLocalWorks.RowCount = 6;
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalWorks.Size = new System.Drawing.Size(508, 279);
            this.panelLocalWorks.TabIndex = 0;
            // 
            // lvLocalWorks
            // 
            this.lvLocalWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocalWorks.FullRowSelect = true;
            this.lvLocalWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLocalWorks.HideSelection = false;
            this.lvLocalWorks.Location = new System.Drawing.Point(3, 89);
            this.lvLocalWorks.MultiSelect = false;
            this.lvLocalWorks.Name = "lvLocalWorks";
            this.lvLocalWorks.ShowItemToolTips = true;
            this.lvLocalWorks.Size = new System.Drawing.Size(502, 144);
            this.lvLocalWorks.SmallImageList = this.ilState;
            this.lvLocalWorks.TabIndex = 0;
            this.lvLocalWorks.UseCompatibleStateImageBehavior = false;
            this.lvLocalWorks.View = System.Windows.Forms.View.Details;
            this.lvLocalWorks.Click += new System.EventHandler(this.lvLocalWorks_Click);
            this.lvLocalWorks.DoubleClick += new System.EventHandler(this.lvLocalWorks_DoubleClick);
            // 
            // ilState
            // 
            this.ilState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilState.ImageStream")));
            this.ilState.TransparentColor = System.Drawing.Color.Transparent;
            this.ilState.Images.SetKeyName(0, "pending");
            this.ilState.Images.SetKeyName(1, "inprogress");
            this.ilState.Images.SetKeyName(2, "completed");
            this.ilState.Images.SetKeyName(3, "failed");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Локальні твори";
            // 
            // panelLocalWorksFilter
            // 
            this.panelLocalWorksFilter.ColumnCount = 4;
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalWorksFilter.Controls.Add(this.labLocalWorksAuthor, 0, 0);
            this.panelLocalWorksFilter.Controls.Add(this.btnLocalWorksAuthorSearch, 2, 0);
            this.panelLocalWorksFilter.Controls.Add(this.cbHistAuthors, 1, 0);
            this.panelLocalWorksFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocalWorksFilter.Location = new System.Drawing.Point(3, 23);
            this.panelLocalWorksFilter.Name = "panelLocalWorksFilter";
            this.panelLocalWorksFilter.RowCount = 1;
            this.panelLocalWorksFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorksFilter.Size = new System.Drawing.Size(502, 27);
            this.panelLocalWorksFilter.TabIndex = 2;
            // 
            // labLocalWorksAuthor
            // 
            this.labLocalWorksAuthor.AutoSize = true;
            this.labLocalWorksAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labLocalWorksAuthor.Location = new System.Drawing.Point(3, 0);
            this.labLocalWorksAuthor.Name = "labLocalWorksAuthor";
            this.labLocalWorksAuthor.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labLocalWorksAuthor.Size = new System.Drawing.Size(80, 27);
            this.labLocalWorksAuthor.TabIndex = 0;
            this.labLocalWorksAuthor.Text = "Твори автора";
            // 
            // btnLocalWorksAuthorSearch
            // 
            this.btnLocalWorksAuthorSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocalWorksAuthorSearch.Location = new System.Drawing.Point(424, 3);
            this.btnLocalWorksAuthorSearch.Name = "btnLocalWorksAuthorSearch";
            this.btnLocalWorksAuthorSearch.Size = new System.Drawing.Size(67, 21);
            this.btnLocalWorksAuthorSearch.TabIndex = 2;
            this.btnLocalWorksAuthorSearch.Text = "Вибрати";
            this.btnLocalWorksAuthorSearch.UseVisualStyleBackColor = true;
            this.btnLocalWorksAuthorSearch.Click += new System.EventHandler(this.btnLocalWorksAuthorSearch_Click);
            // 
            // cbHistAuthors
            // 
            this.cbHistAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbHistAuthors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHistAuthors.FormattingEnabled = true;
            this.cbHistAuthors.Location = new System.Drawing.Point(89, 3);
            this.cbHistAuthors.Name = "cbHistAuthors";
            this.cbHistAuthors.Size = new System.Drawing.Size(329, 21);
            this.cbHistAuthors.TabIndex = 3;
            this.cbHistAuthors.SelectedIndexChanged += new System.EventHandler(this.cbHistAuthors_SelectedIndexChanged);
            // 
            // panelButtonsLeft
            // 
            this.panelButtonsLeft.Controls.Add(this.btnAutoJoin);
            this.panelButtonsLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonsLeft.Location = new System.Drawing.Point(3, 239);
            this.panelButtonsLeft.Name = "panelButtonsLeft";
            this.panelButtonsLeft.Size = new System.Drawing.Size(502, 29);
            this.panelButtonsLeft.TabIndex = 3;
            // 
            // btnAutoJoin
            // 
            this.btnAutoJoin.Location = new System.Drawing.Point(3, 3);
            this.btnAutoJoin.Name = "btnAutoJoin";
            this.btnAutoJoin.Size = new System.Drawing.Size(166, 23);
            this.btnAutoJoin.TabIndex = 0;
            this.btnAutoJoin.Text = "Поєднати автоматично";
            this.btnAutoJoin.UseVisualStyleBackColor = true;
            this.btnAutoJoin.Click += new System.EventHandler(this.btnAutoJoin_Click);
            // 
            // panelLocalSearchLeft
            // 
            this.panelLocalSearchLeft.ColumnCount = 5;
            this.panelLocalSearchLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.panelLocalSearchLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalSearchLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.panelLocalSearchLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.panelLocalSearchLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalSearchLeft.Controls.Add(this.label3, 0, 0);
            this.panelLocalSearchLeft.Controls.Add(this.tbLocalSearchLeft, 1, 0);
            this.panelLocalSearchLeft.Controls.Add(this.btnLocalSearchLeft, 2, 0);
            this.panelLocalSearchLeft.Controls.Add(this.btnLocalSearchLeftCancel, 3, 0);
            this.panelLocalSearchLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocalSearchLeft.Location = new System.Drawing.Point(3, 56);
            this.panelLocalSearchLeft.Name = "panelLocalSearchLeft";
            this.panelLocalSearchLeft.RowCount = 1;
            this.panelLocalSearchLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalSearchLeft.Size = new System.Drawing.Size(502, 27);
            this.panelLocalSearchLeft.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label3.Size = new System.Drawing.Size(121, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Шукати серед обраних";
            // 
            // tbLocalSearchLeft
            // 
            this.tbLocalSearchLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocalSearchLeft.Location = new System.Drawing.Point(130, 3);
            this.tbLocalSearchLeft.Name = "tbLocalSearchLeft";
            this.tbLocalSearchLeft.Size = new System.Drawing.Size(201, 20);
            this.tbLocalSearchLeft.TabIndex = 1;
            this.tbLocalSearchLeft.Enter += new System.EventHandler(this.tbLocalSearchLeft_Enter);
            this.tbLocalSearchLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLocalSearchLeft_KeyDown);
            // 
            // btnLocalSearchLeft
            // 
            this.btnLocalSearchLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocalSearchLeft.Location = new System.Drawing.Point(337, 3);
            this.btnLocalSearchLeft.Name = "btnLocalSearchLeft";
            this.btnLocalSearchLeft.Size = new System.Drawing.Size(73, 21);
            this.btnLocalSearchLeft.TabIndex = 2;
            this.btnLocalSearchLeft.Text = "Шукати";
            this.btnLocalSearchLeft.UseVisualStyleBackColor = true;
            this.btnLocalSearchLeft.Click += new System.EventHandler(this.btnLocalSearchLeft_Click);
            // 
            // btnLocalSearchLeftCancel
            // 
            this.btnLocalSearchLeftCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocalSearchLeftCancel.Location = new System.Drawing.Point(416, 3);
            this.btnLocalSearchLeftCancel.Name = "btnLocalSearchLeftCancel";
            this.btnLocalSearchLeftCancel.Size = new System.Drawing.Size(75, 21);
            this.btnLocalSearchLeftCancel.TabIndex = 2;
            this.btnLocalSearchLeftCancel.Text = "Скасувати";
            this.btnLocalSearchLeftCancel.UseVisualStyleBackColor = true;
            this.btnLocalSearchLeftCancel.Click += new System.EventHandler(this.btnLocalSearchLeftCancel_Click);
            // 
            // panelReportWorks
            // 
            this.panelReportWorks.ColumnCount = 1;
            this.panelReportWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorks.Controls.Add(this.lvReportWorks, 0, 3);
            this.panelReportWorks.Controls.Add(this.label2, 0, 0);
            this.panelReportWorks.Controls.Add(this.panelReportWorksFilter, 0, 1);
            this.panelReportWorks.Controls.Add(this.panelButtonsRight, 0, 4);
            this.panelReportWorks.Controls.Add(this.panelLocalSearchRight, 0, 2);
            this.panelReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorks.Location = new System.Drawing.Point(0, 0);
            this.panelReportWorks.Name = "panelReportWorks";
            this.panelReportWorks.RowCount = 6;
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReportWorks.Size = new System.Drawing.Size(530, 279);
            this.panelReportWorks.TabIndex = 0;
            // 
            // lvReportWorks
            // 
            this.lvReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportWorks.FullRowSelect = true;
            this.lvReportWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReportWorks.HideSelection = false;
            this.lvReportWorks.Location = new System.Drawing.Point(3, 87);
            this.lvReportWorks.Name = "lvReportWorks";
            this.lvReportWorks.Size = new System.Drawing.Size(524, 145);
            this.lvReportWorks.SmallImageList = this.ilState;
            this.lvReportWorks.TabIndex = 0;
            this.lvReportWorks.UseCompatibleStateImageBehavior = false;
            this.lvReportWorks.View = System.Windows.Forms.View.Details;
            this.lvReportWorks.Click += new System.EventHandler(this.lvReportWorks_Click);
            this.lvReportWorks.DoubleClick += new System.EventHandler(this.lvReportWorks_DoubleClick);
            this.lvReportWorks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReportWorks_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Твори звіту";
            // 
            // panelReportWorksFilter
            // 
            this.panelReportWorksFilter.ColumnCount = 9;
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelReportWorksFilter.Controls.Add(this.btnReportWorksSearch, 6, 0);
            this.panelReportWorksFilter.Controls.Add(this.menuStrip1, 7, 0);
            this.panelReportWorksFilter.Controls.Add(this.label4, 0, 0);
            this.panelReportWorksFilter.Controls.Add(this.label5, 2, 0);
            this.panelReportWorksFilter.Controls.Add(this.label6, 4, 0);
            this.panelReportWorksFilter.Controls.Add(this.tbReportFilterPerformer, 5, 0);
            this.panelReportWorksFilter.Controls.Add(this.tbReportFilterAuthor, 3, 0);
            this.panelReportWorksFilter.Controls.Add(this.tbReportFilterName, 1, 0);
            this.panelReportWorksFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorksFilter.Location = new System.Drawing.Point(3, 23);
            this.panelReportWorksFilter.Name = "panelReportWorksFilter";
            this.panelReportWorksFilter.RowCount = 1;
            this.panelReportWorksFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorksFilter.Size = new System.Drawing.Size(524, 26);
            this.panelReportWorksFilter.TabIndex = 2;
            // 
            // btnReportWorksSearch
            // 
            this.btnReportWorksSearch.Location = new System.Drawing.Point(374, 3);
            this.btnReportWorksSearch.Name = "btnReportWorksSearch";
            this.btnReportWorksSearch.Size = new System.Drawing.Size(66, 20);
            this.btnReportWorksSearch.TabIndex = 0;
            this.btnReportWorksSearch.Text = "Шукати";
            this.btnReportWorksSearch.UseVisualStyleBackColor = true;
            this.btnReportWorksSearch.Click += new System.EventHandler(this.btnReportWorksSearch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripHistAuthorFilter});
            this.menuStrip1.Location = new System.Drawing.Point(446, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(69, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "Історія";
            // 
            // menuStripHistAuthorFilter
            // 
            this.menuStripHistAuthorFilter.Name = "menuStripHistAuthorFilter";
            this.menuStripHistAuthorFilter.Size = new System.Drawing.Size(56, 22);
            this.menuStripHistAuthorFilter.Text = "Історія";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label4.Size = new System.Drawing.Size(42, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Назва";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(117, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label5.Size = new System.Drawing.Size(41, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "Автор";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(230, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label6.Size = new System.Drawing.Size(72, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "Виконавець";
            // 
            // tbReportFilterPerformer
            // 
            this.tbReportFilterPerformer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReportFilterPerformer.Location = new System.Drawing.Point(308, 3);
            this.tbReportFilterPerformer.Name = "tbReportFilterPerformer";
            this.tbReportFilterPerformer.Size = new System.Drawing.Size(60, 20);
            this.tbReportFilterPerformer.TabIndex = 2;
            // 
            // tbReportFilterAuthor
            // 
            this.tbReportFilterAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReportFilterAuthor.Location = new System.Drawing.Point(164, 3);
            this.tbReportFilterAuthor.Name = "tbReportFilterAuthor";
            this.tbReportFilterAuthor.Size = new System.Drawing.Size(60, 20);
            this.tbReportFilterAuthor.TabIndex = 2;
            // 
            // tbReportFilterName
            // 
            this.tbReportFilterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReportFilterName.Location = new System.Drawing.Point(51, 3);
            this.tbReportFilterName.Name = "tbReportFilterName";
            this.tbReportFilterName.Size = new System.Drawing.Size(60, 20);
            this.tbReportFilterName.TabIndex = 2;
            // 
            // panelButtonsRight
            // 
            this.panelButtonsRight.Controls.Add(this.btnJoinSelectedReportWorks);
            this.panelButtonsRight.Controls.Add(this.btnJoin);
            this.panelButtonsRight.Controls.Add(this.btnShowLocalWork);
            this.panelButtonsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonsRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtonsRight.Location = new System.Drawing.Point(3, 238);
            this.panelButtonsRight.Name = "panelButtonsRight";
            this.panelButtonsRight.Size = new System.Drawing.Size(524, 30);
            this.panelButtonsRight.TabIndex = 3;
            // 
            // btnJoinSelectedReportWorks
            // 
            this.btnJoinSelectedReportWorks.Location = new System.Drawing.Point(417, 3);
            this.btnJoinSelectedReportWorks.Name = "btnJoinSelectedReportWorks";
            this.btnJoinSelectedReportWorks.Size = new System.Drawing.Size(104, 23);
            this.btnJoinSelectedReportWorks.TabIndex = 0;
            this.btnJoinSelectedReportWorks.Text = "Однаковий твір";
            this.btnJoinSelectedReportWorks.UseVisualStyleBackColor = true;
            this.btnJoinSelectedReportWorks.Click += new System.EventHandler(this.btnJoinSelectedReportWorks_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(336, 3);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 1;
            this.btnJoin.Text = "Поєднати";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnShowLocalWork
            // 
            this.btnShowLocalWork.Location = new System.Drawing.Point(166, 3);
            this.btnShowLocalWork.Name = "btnShowLocalWork";
            this.btnShowLocalWork.Size = new System.Drawing.Size(164, 23);
            this.btnShowLocalWork.TabIndex = 2;
            this.btnShowLocalWork.Text = "Показати локальний твір ...";
            this.btnShowLocalWork.UseVisualStyleBackColor = true;
            this.btnShowLocalWork.Click += new System.EventHandler(this.btnShowLocalWork_Click);
            // 
            // panelLocalSearchRight
            // 
            this.panelLocalSearchRight.ColumnCount = 5;
            this.panelLocalSearchRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.panelLocalSearchRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalSearchRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.panelLocalSearchRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.panelLocalSearchRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalSearchRight.Controls.Add(this.label8, 0, 0);
            this.panelLocalSearchRight.Controls.Add(this.tbLocalSearchRight, 1, 0);
            this.panelLocalSearchRight.Controls.Add(this.btnLocalSearchRight, 2, 0);
            this.panelLocalSearchRight.Controls.Add(this.btnLocalSearchRightCancel, 3, 0);
            this.panelLocalSearchRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocalSearchRight.Location = new System.Drawing.Point(3, 55);
            this.panelLocalSearchRight.Name = "panelLocalSearchRight";
            this.panelLocalSearchRight.RowCount = 1;
            this.panelLocalSearchRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalSearchRight.Size = new System.Drawing.Size(524, 26);
            this.panelLocalSearchRight.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label8.Size = new System.Drawing.Size(127, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "Шукати серед обраних";
            // 
            // tbLocalSearchRight
            // 
            this.tbLocalSearchRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocalSearchRight.Location = new System.Drawing.Point(136, 3);
            this.tbLocalSearchRight.Name = "tbLocalSearchRight";
            this.tbLocalSearchRight.Size = new System.Drawing.Size(226, 20);
            this.tbLocalSearchRight.TabIndex = 1;
            // 
            // btnLocalSearchRight
            // 
            this.btnLocalSearchRight.Location = new System.Drawing.Point(368, 3);
            this.btnLocalSearchRight.Name = "btnLocalSearchRight";
            this.btnLocalSearchRight.Size = new System.Drawing.Size(69, 20);
            this.btnLocalSearchRight.TabIndex = 2;
            this.btnLocalSearchRight.Text = "Шукати";
            this.btnLocalSearchRight.UseVisualStyleBackColor = true;
            this.btnLocalSearchRight.Click += new System.EventHandler(this.btnLocalSearchRight_Click);
            // 
            // btnLocalSearchRightCancel
            // 
            this.btnLocalSearchRightCancel.Location = new System.Drawing.Point(443, 3);
            this.btnLocalSearchRightCancel.Name = "btnLocalSearchRightCancel";
            this.btnLocalSearchRightCancel.Size = new System.Drawing.Size(70, 20);
            this.btnLocalSearchRightCancel.TabIndex = 3;
            this.btnLocalSearchRightCancel.Text = "Скасувати";
            this.btnLocalSearchRightCancel.UseVisualStyleBackColor = true;
            this.btnLocalSearchRightCancel.Click += new System.EventHandler(this.btnLocalSearchRightCancel_Click);
            // 
            // panelFoundWorks
            // 
            this.panelFoundWorks.ColumnCount = 1;
            this.panelFoundWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFoundWorks.Controls.Add(this.lvFoundWorks, 0, 1);
            this.panelFoundWorks.Controls.Add(this.labFoundWorksTitle, 0, 0);
            this.panelFoundWorks.Controls.Add(this.panelBottomButtons, 0, 2);
            this.panelFoundWorks.Controls.Add(this.panelFileExchange, 0, 3);
            this.panelFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoundWorks.Location = new System.Drawing.Point(0, 0);
            this.panelFoundWorks.Name = "panelFoundWorks";
            this.panelFoundWorks.RowCount = 4;
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelFoundWorks.Size = new System.Drawing.Size(1042, 223);
            this.panelFoundWorks.TabIndex = 0;
            // 
            // lvFoundWorks
            // 
            this.lvFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFoundWorks.FullRowSelect = true;
            this.lvFoundWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFoundWorks.HideSelection = false;
            this.lvFoundWorks.Location = new System.Drawing.Point(3, 23);
            this.lvFoundWorks.MultiSelect = false;
            this.lvFoundWorks.Name = "lvFoundWorks";
            this.lvFoundWorks.Size = new System.Drawing.Size(1036, 122);
            this.lvFoundWorks.TabIndex = 0;
            this.lvFoundWorks.UseCompatibleStateImageBehavior = false;
            this.lvFoundWorks.View = System.Windows.Forms.View.Details;
            // 
            // labFoundWorksTitle
            // 
            this.labFoundWorksTitle.AutoSize = true;
            this.labFoundWorksTitle.Location = new System.Drawing.Point(3, 0);
            this.labFoundWorksTitle.Name = "labFoundWorksTitle";
            this.labFoundWorksTitle.Size = new System.Drawing.Size(84, 13);
            this.labFoundWorksTitle.TabIndex = 1;
            this.labFoundWorksTitle.Text = "Знайдені твори";
            // 
            // panelBottomButtons
            // 
            this.panelBottomButtons.Controls.Add(this.btnDisjoin);
            this.panelBottomButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottomButtons.Location = new System.Drawing.Point(3, 151);
            this.panelBottomButtons.Name = "panelBottomButtons";
            this.panelBottomButtons.Size = new System.Drawing.Size(1036, 30);
            this.panelBottomButtons.TabIndex = 2;
            // 
            // btnDisjoin
            // 
            this.btnDisjoin.Location = new System.Drawing.Point(958, 3);
            this.btnDisjoin.Name = "btnDisjoin";
            this.btnDisjoin.Size = new System.Drawing.Size(75, 23);
            this.btnDisjoin.TabIndex = 0;
            this.btnDisjoin.Text = "Роз\'єднати";
            this.btnDisjoin.UseVisualStyleBackColor = true;
            this.btnDisjoin.Click += new System.EventHandler(this.btnDisjoin_Click);
            // 
            // panelFileExchange
            // 
            this.panelFileExchange.Controls.Add(this.btnLoadReportFile);
            this.panelFileExchange.Controls.Add(this.btnCreateInvoiceFilePub);
            this.panelFileExchange.Controls.Add(this.btnCreateInvoiceMec);
            this.panelFileExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileExchange.Location = new System.Drawing.Point(3, 187);
            this.panelFileExchange.Name = "panelFileExchange";
            this.panelFileExchange.Size = new System.Drawing.Size(1036, 33);
            this.panelFileExchange.TabIndex = 3;
            // 
            // btnLoadReportFile
            // 
            this.btnLoadReportFile.Location = new System.Drawing.Point(3, 3);
            this.btnLoadReportFile.Name = "btnLoadReportFile";
            this.btnLoadReportFile.Size = new System.Drawing.Size(121, 23);
            this.btnLoadReportFile.TabIndex = 0;
            this.btnLoadReportFile.Text = "Завантажити звіт";
            this.btnLoadReportFile.UseVisualStyleBackColor = true;
            this.btnLoadReportFile.Click += new System.EventHandler(this.btnLoadReportFile_Click);
            // 
            // btnCreateInvoiceFilePub
            // 
            this.btnCreateInvoiceFilePub.Location = new System.Drawing.Point(130, 3);
            this.btnCreateInvoiceFilePub.Name = "btnCreateInvoiceFilePub";
            this.btnCreateInvoiceFilePub.Size = new System.Drawing.Size(131, 23);
            this.btnCreateInvoiceFilePub.TabIndex = 0;
            this.btnCreateInvoiceFilePub.Text = "Створити інвойс ПУБ";
            this.btnCreateInvoiceFilePub.UseVisualStyleBackColor = true;
            this.btnCreateInvoiceFilePub.Click += new System.EventHandler(this.btnCreateInvoiceFilePub_Click);
            // 
            // btnCreateInvoiceMec
            // 
            this.btnCreateInvoiceMec.Location = new System.Drawing.Point(267, 3);
            this.btnCreateInvoiceMec.Name = "btnCreateInvoiceMec";
            this.btnCreateInvoiceMec.Size = new System.Drawing.Size(131, 23);
            this.btnCreateInvoiceMec.TabIndex = 0;
            this.btnCreateInvoiceMec.Text = "Створити інвойс МЕХ";
            this.btnCreateInvoiceMec.UseVisualStyleBackColor = true;
            this.btnCreateInvoiceMec.Click += new System.EventHandler(this.btnCreateInvoiceMec_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 532);
            this.Controls.Add(this.panelMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Пошук творів у звітах";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitTop.Panel1.ResumeLayout(false);
            this.splitTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTop)).EndInit();
            this.splitTop.ResumeLayout(false);
            this.panelLocalWorks.ResumeLayout(false);
            this.panelLocalWorks.PerformLayout();
            this.panelLocalWorksFilter.ResumeLayout(false);
            this.panelLocalWorksFilter.PerformLayout();
            this.panelButtonsLeft.ResumeLayout(false);
            this.panelLocalSearchLeft.ResumeLayout(false);
            this.panelLocalSearchLeft.PerformLayout();
            this.panelReportWorks.ResumeLayout(false);
            this.panelReportWorks.PerformLayout();
            this.panelReportWorksFilter.ResumeLayout(false);
            this.panelReportWorksFilter.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelButtonsRight.ResumeLayout(false);
            this.panelLocalSearchRight.ResumeLayout(false);
            this.panelLocalSearchRight.PerformLayout();
            this.panelFoundWorks.ResumeLayout(false);
            this.panelFoundWorks.PerformLayout();
            this.panelBottomButtons.ResumeLayout(false);
            this.panelFileExchange.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitTop;
        private System.Windows.Forms.TableLayoutPanel panelLocalWorks;
        private System.Windows.Forms.ListView lvLocalWorks;
        private System.Windows.Forms.TableLayoutPanel panelReportWorks;
        private System.Windows.Forms.ListView lvReportWorks;
        private System.Windows.Forms.TableLayoutPanel panelFoundWorks;
        private System.Windows.Forms.ListView lvFoundWorks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labFoundWorksTitle;
        private System.Windows.Forms.TableLayoutPanel panelLocalWorksFilter;
        private System.Windows.Forms.Label labLocalWorksAuthor;
        private System.Windows.Forms.Button btnLocalWorksAuthorSearch;
        private System.Windows.Forms.TableLayoutPanel panelReportWorksFilter;
        private System.Windows.Forms.Button btnReportWorksSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReportFilterPerformer;
        private System.Windows.Forms.TextBox tbReportFilterAuthor;
        private System.Windows.Forms.TextBox tbReportFilterName;
        private System.Windows.Forms.ImageList ilState;
        private System.Windows.Forms.FlowLayoutPanel panelButtonsRight;
        private System.Windows.Forms.Button btnJoinSelectedReportWorks;
        private System.Windows.Forms.FlowLayoutPanel panelBottomButtons;
        private System.Windows.Forms.Button btnDisjoin;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.FlowLayoutPanel panelButtonsLeft;
        private System.Windows.Forms.Button btnAutoJoin;
        private System.Windows.Forms.Button btnShowLocalWork;
        private System.Windows.Forms.TableLayoutPanel panelLocalSearchRight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbLocalSearchRight;
        private System.Windows.Forms.Button btnLocalSearchRight;
        private System.Windows.Forms.Button btnLocalSearchRightCancel;
        private System.Windows.Forms.TableLayoutPanel panelLocalSearchLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLocalSearchLeft;
        private System.Windows.Forms.Button btnLocalSearchLeft;
        private System.Windows.Forms.Button btnLocalSearchLeftCancel;
        private System.Windows.Forms.ComboBox cbHistAuthors;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStripHistAuthorFilter;
        private System.Windows.Forms.FlowLayoutPanel panelFileExchange;
        private System.Windows.Forms.Button btnLoadReportFile;
        private System.Windows.Forms.Button btnCreateInvoiceFilePub;
        private System.Windows.Forms.Button btnCreateInvoiceMec;
    }
}

