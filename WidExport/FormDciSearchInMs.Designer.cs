
namespace WidExport
{
    partial class FormDciSearchInMs
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitTop = new System.Windows.Forms.SplitContainer();
            this.panelReportWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvReportWorks = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelReportWorksFilter = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbReportAuthor = new System.Windows.Forms.ComboBox();
            this.panelLeftButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDisregard = new System.Windows.Forms.Button();
            this.panelLocalWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvLocalWorks = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLocalWorksFilter = new System.Windows.Forms.TableLayoutPanel();
            this.labLocalWorksAuthor = new System.Windows.Forms.Label();
            this.tbLocalWorksAuthor = new System.Windows.Forms.TextBox();
            this.btnLocalWorksAuthorSearch = new System.Windows.Forms.Button();
            this.panelContainingText = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSearchText = new System.Windows.Forms.TextBox();
            this.btnSearchText = new System.Windows.Forms.Button();
            this.panelRightButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnJoin = new System.Windows.Forms.Button();
            this.panelFoundWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvFoundWorks = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFoundWorkFilter = new System.Windows.Forms.TableLayoutPanel();
            this.cbCoAuthors = new System.Windows.Forms.ComboBox();
            this.labCoAuthor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFoundWorkAuthor = new System.Windows.Forms.ComboBox();
            this.panelBottomButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUnJoin = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTop)).BeginInit();
            this.splitTop.Panel1.SuspendLayout();
            this.splitTop.Panel2.SuspendLayout();
            this.splitTop.SuspendLayout();
            this.panelReportWorks.SuspendLayout();
            this.panelReportWorksFilter.SuspendLayout();
            this.panelLeftButtons.SuspendLayout();
            this.panelLocalWorks.SuspendLayout();
            this.panelLocalWorksFilter.SuspendLayout();
            this.panelContainingText.SuspendLayout();
            this.panelRightButtons.SuspendLayout();
            this.panelFoundWorks.SuspendLayout();
            this.panelFoundWorkFilter.SuspendLayout();
            this.panelBottomButtons.SuspendLayout();
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
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1064, 555);
            this.panelMain.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(4, 25);
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
            this.splitMain.Size = new System.Drawing.Size(1056, 505);
            this.splitMain.SplitterDistance = 244;
            this.splitMain.TabIndex = 0;
            // 
            // splitTop
            // 
            this.splitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTop.Location = new System.Drawing.Point(0, 0);
            this.splitTop.Name = "splitTop";
            // 
            // splitTop.Panel1
            // 
            this.splitTop.Panel1.Controls.Add(this.panelReportWorks);
            // 
            // splitTop.Panel2
            // 
            this.splitTop.Panel2.Controls.Add(this.panelLocalWorks);
            this.splitTop.Size = new System.Drawing.Size(1056, 244);
            this.splitTop.SplitterDistance = 515;
            this.splitTop.TabIndex = 0;
            // 
            // panelReportWorks
            // 
            this.panelReportWorks.ColumnCount = 1;
            this.panelReportWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorks.Controls.Add(this.lvReportWorks, 0, 2);
            this.panelReportWorks.Controls.Add(this.label2, 0, 0);
            this.panelReportWorks.Controls.Add(this.panelReportWorksFilter, 0, 1);
            this.panelReportWorks.Controls.Add(this.panelLeftButtons, 0, 3);
            this.panelReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorks.Location = new System.Drawing.Point(0, 0);
            this.panelReportWorks.Name = "panelReportWorks";
            this.panelReportWorks.RowCount = 5;
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorks.Size = new System.Drawing.Size(515, 244);
            this.panelReportWorks.TabIndex = 0;
            // 
            // lvReportWorks
            // 
            this.lvReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportWorks.FullRowSelect = true;
            this.lvReportWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReportWorks.HideSelection = false;
            this.lvReportWorks.Location = new System.Drawing.Point(3, 55);
            this.lvReportWorks.MultiSelect = false;
            this.lvReportWorks.Name = "lvReportWorks";
            this.lvReportWorks.Size = new System.Drawing.Size(509, 142);
            this.lvReportWorks.TabIndex = 0;
            this.lvReportWorks.UseCompatibleStateImageBehavior = false;
            this.lvReportWorks.View = System.Windows.Forms.View.Details;
            this.lvReportWorks.DoubleClick += new System.EventHandler(this.lvReportWorks_DoubleClick);
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
            this.panelReportWorksFilter.ColumnCount = 3;
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorksFilter.Controls.Add(this.label5, 0, 0);
            this.panelReportWorksFilter.Controls.Add(this.cbReportAuthor, 1, 0);
            this.panelReportWorksFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorksFilter.Location = new System.Drawing.Point(3, 23);
            this.panelReportWorksFilter.Name = "panelReportWorksFilter";
            this.panelReportWorksFilter.RowCount = 1;
            this.panelReportWorksFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorksFilter.Size = new System.Drawing.Size(509, 26);
            this.panelReportWorksFilter.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label5.Size = new System.Drawing.Size(68, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "Автор";
            // 
            // cbReportAuthor
            // 
            this.cbReportAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbReportAuthor.DropDownHeight = 300;
            this.cbReportAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReportAuthor.FormattingEnabled = true;
            this.cbReportAuthor.IntegralHeight = false;
            this.cbReportAuthor.Location = new System.Drawing.Point(77, 3);
            this.cbReportAuthor.Name = "cbReportAuthor";
            this.cbReportAuthor.Size = new System.Drawing.Size(421, 21);
            this.cbReportAuthor.TabIndex = 2;
            this.cbReportAuthor.SelectedIndexChanged += new System.EventHandler(this.cbReportAuthor_SelectedIndexChanged);
            // 
            // panelLeftButtons
            // 
            this.panelLeftButtons.Controls.Add(this.btnDisregard);
            this.panelLeftButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelLeftButtons.Location = new System.Drawing.Point(3, 203);
            this.panelLeftButtons.Name = "panelLeftButtons";
            this.panelLeftButtons.Size = new System.Drawing.Size(509, 30);
            this.panelLeftButtons.TabIndex = 3;
            // 
            // btnDisregard
            // 
            this.btnDisregard.Location = new System.Drawing.Point(386, 3);
            this.btnDisregard.Name = "btnDisregard";
            this.btnDisregard.Size = new System.Drawing.Size(120, 23);
            this.btnDisregard.TabIndex = 0;
            this.btnDisregard.Text = "Зняти з розгляду";
            this.btnDisregard.UseVisualStyleBackColor = true;
            this.btnDisregard.Click += new System.EventHandler(this.btnDisregard_Click);
            // 
            // panelLocalWorks
            // 
            this.panelLocalWorks.ColumnCount = 1;
            this.panelLocalWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorks.Controls.Add(this.lvLocalWorks, 0, 3);
            this.panelLocalWorks.Controls.Add(this.label1, 0, 0);
            this.panelLocalWorks.Controls.Add(this.panelLocalWorksFilter, 0, 1);
            this.panelLocalWorks.Controls.Add(this.panelContainingText, 0, 2);
            this.panelLocalWorks.Controls.Add(this.panelRightButtons, 0, 4);
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
            this.panelLocalWorks.Size = new System.Drawing.Size(537, 244);
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
            this.lvLocalWorks.Size = new System.Drawing.Size(531, 109);
            this.lvLocalWorks.TabIndex = 0;
            this.lvLocalWorks.UseCompatibleStateImageBehavior = false;
            this.lvLocalWorks.View = System.Windows.Forms.View.Details;
            this.lvLocalWorks.DoubleClick += new System.EventHandler(this.lvLocalWorks_DoubleClick);
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
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalWorksFilter.Controls.Add(this.labLocalWorksAuthor, 0, 0);
            this.panelLocalWorksFilter.Controls.Add(this.tbLocalWorksAuthor, 1, 0);
            this.panelLocalWorksFilter.Controls.Add(this.btnLocalWorksAuthorSearch, 2, 0);
            this.panelLocalWorksFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocalWorksFilter.Location = new System.Drawing.Point(3, 23);
            this.panelLocalWorksFilter.Name = "panelLocalWorksFilter";
            this.panelLocalWorksFilter.RowCount = 1;
            this.panelLocalWorksFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorksFilter.Size = new System.Drawing.Size(531, 27);
            this.panelLocalWorksFilter.TabIndex = 2;
            // 
            // labLocalWorksAuthor
            // 
            this.labLocalWorksAuthor.AutoSize = true;
            this.labLocalWorksAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labLocalWorksAuthor.Location = new System.Drawing.Point(3, 0);
            this.labLocalWorksAuthor.Name = "labLocalWorksAuthor";
            this.labLocalWorksAuthor.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labLocalWorksAuthor.Size = new System.Drawing.Size(96, 27);
            this.labLocalWorksAuthor.TabIndex = 0;
            this.labLocalWorksAuthor.Text = "Твори автора";
            // 
            // tbLocalWorksAuthor
            // 
            this.tbLocalWorksAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocalWorksAuthor.Location = new System.Drawing.Point(105, 3);
            this.tbLocalWorksAuthor.Name = "tbLocalWorksAuthor";
            this.tbLocalWorksAuthor.Size = new System.Drawing.Size(331, 20);
            this.tbLocalWorksAuthor.TabIndex = 1;
            // 
            // btnLocalWorksAuthorSearch
            // 
            this.btnLocalWorksAuthorSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocalWorksAuthorSearch.Location = new System.Drawing.Point(442, 3);
            this.btnLocalWorksAuthorSearch.Name = "btnLocalWorksAuthorSearch";
            this.btnLocalWorksAuthorSearch.Size = new System.Drawing.Size(78, 21);
            this.btnLocalWorksAuthorSearch.TabIndex = 2;
            this.btnLocalWorksAuthorSearch.Text = "Шукати";
            this.btnLocalWorksAuthorSearch.UseVisualStyleBackColor = true;
            this.btnLocalWorksAuthorSearch.Click += new System.EventHandler(this.btnLocalWorksAuthorSearch_Click);
            // 
            // panelContainingText
            // 
            this.panelContainingText.ColumnCount = 4;
            this.panelContainingText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.panelContainingText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelContainingText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.panelContainingText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelContainingText.Controls.Add(this.label4, 0, 0);
            this.panelContainingText.Controls.Add(this.tbSearchText, 1, 0);
            this.panelContainingText.Controls.Add(this.btnSearchText, 2, 0);
            this.panelContainingText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainingText.Location = new System.Drawing.Point(3, 56);
            this.panelContainingText.Name = "panelContainingText";
            this.panelContainingText.RowCount = 1;
            this.panelContainingText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelContainingText.Size = new System.Drawing.Size(531, 27);
            this.panelContainingText.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label4.Size = new System.Drawing.Size(97, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Що містять текст";
            // 
            // tbSearchText
            // 
            this.tbSearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearchText.Location = new System.Drawing.Point(106, 3);
            this.tbSearchText.Name = "tbSearchText";
            this.tbSearchText.Size = new System.Drawing.Size(329, 20);
            this.tbSearchText.TabIndex = 1;
            // 
            // btnSearchText
            // 
            this.btnSearchText.Location = new System.Drawing.Point(441, 3);
            this.btnSearchText.Name = "btnSearchText";
            this.btnSearchText.Size = new System.Drawing.Size(75, 21);
            this.btnSearchText.TabIndex = 2;
            this.btnSearchText.Text = "Шукати";
            this.btnSearchText.UseVisualStyleBackColor = true;
            this.btnSearchText.Click += new System.EventHandler(this.btnSearchText_Click);
            // 
            // panelRightButtons
            // 
            this.panelRightButtons.Controls.Add(this.btnJoin);
            this.panelRightButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelRightButtons.Location = new System.Drawing.Point(3, 204);
            this.panelRightButtons.Name = "panelRightButtons";
            this.panelRightButtons.Size = new System.Drawing.Size(531, 29);
            this.panelRightButtons.TabIndex = 4;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(453, 3);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 0;
            this.btnJoin.Text = "Поєднати";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // panelFoundWorks
            // 
            this.panelFoundWorks.ColumnCount = 1;
            this.panelFoundWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFoundWorks.Controls.Add(this.lvFoundWorks, 0, 2);
            this.panelFoundWorks.Controls.Add(this.label3, 0, 0);
            this.panelFoundWorks.Controls.Add(this.panelFoundWorkFilter, 0, 1);
            this.panelFoundWorks.Controls.Add(this.panelBottomButtons, 0, 3);
            this.panelFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoundWorks.Location = new System.Drawing.Point(0, 0);
            this.panelFoundWorks.Name = "panelFoundWorks";
            this.panelFoundWorks.RowCount = 5;
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelFoundWorks.Size = new System.Drawing.Size(1056, 257);
            this.panelFoundWorks.TabIndex = 0;
            // 
            // lvFoundWorks
            // 
            this.lvFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFoundWorks.FullRowSelect = true;
            this.lvFoundWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFoundWorks.HideSelection = false;
            this.lvFoundWorks.Location = new System.Drawing.Point(3, 56);
            this.lvFoundWorks.MultiSelect = false;
            this.lvFoundWorks.Name = "lvFoundWorks";
            this.lvFoundWorks.Size = new System.Drawing.Size(1050, 155);
            this.lvFoundWorks.TabIndex = 0;
            this.lvFoundWorks.UseCompatibleStateImageBehavior = false;
            this.lvFoundWorks.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Знайдені твори";
            // 
            // panelFoundWorkFilter
            // 
            this.panelFoundWorkFilter.ColumnCount = 5;
            this.panelFoundWorkFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.panelFoundWorkFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelFoundWorkFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.panelFoundWorkFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelFoundWorkFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.panelFoundWorkFilter.Controls.Add(this.cbCoAuthors, 3, 0);
            this.panelFoundWorkFilter.Controls.Add(this.labCoAuthor, 2, 0);
            this.panelFoundWorkFilter.Controls.Add(this.label6, 0, 0);
            this.panelFoundWorkFilter.Controls.Add(this.cbFoundWorkAuthor, 1, 0);
            this.panelFoundWorkFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoundWorkFilter.Location = new System.Drawing.Point(3, 23);
            this.panelFoundWorkFilter.Name = "panelFoundWorkFilter";
            this.panelFoundWorkFilter.RowCount = 1;
            this.panelFoundWorkFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFoundWorkFilter.Size = new System.Drawing.Size(1050, 27);
            this.panelFoundWorkFilter.TabIndex = 2;
            // 
            // cbCoAuthors
            // 
            this.cbCoAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCoAuthors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoAuthors.FormattingEnabled = true;
            this.cbCoAuthors.Location = new System.Drawing.Point(583, 3);
            this.cbCoAuthors.Name = "cbCoAuthors";
            this.cbCoAuthors.Size = new System.Drawing.Size(443, 21);
            this.cbCoAuthors.TabIndex = 1;
            // 
            // labCoAuthor
            // 
            this.labCoAuthor.AutoSize = true;
            this.labCoAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCoAuthor.Location = new System.Drawing.Point(507, 0);
            this.labCoAuthor.Name = "labCoAuthor";
            this.labCoAuthor.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labCoAuthor.Size = new System.Drawing.Size(70, 27);
            this.labCoAuthor.TabIndex = 0;
            this.labCoAuthor.Text = "Співавтори";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label6.Size = new System.Drawing.Size(49, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Автор";
            // 
            // cbFoundWorkAuthor
            // 
            this.cbFoundWorkAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFoundWorkAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFoundWorkAuthor.FormattingEnabled = true;
            this.cbFoundWorkAuthor.Location = new System.Drawing.Point(58, 3);
            this.cbFoundWorkAuthor.Name = "cbFoundWorkAuthor";
            this.cbFoundWorkAuthor.Size = new System.Drawing.Size(443, 21);
            this.cbFoundWorkAuthor.TabIndex = 1;
            this.cbFoundWorkAuthor.SelectedIndexChanged += new System.EventHandler(this.cbFoundWorkAuthor_SelectedIndexChanged);
            // 
            // panelBottomButtons
            // 
            this.panelBottomButtons.Controls.Add(this.btnUnJoin);
            this.panelBottomButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottomButtons.Location = new System.Drawing.Point(3, 217);
            this.panelBottomButtons.Name = "panelBottomButtons";
            this.panelBottomButtons.Size = new System.Drawing.Size(1050, 29);
            this.panelBottomButtons.TabIndex = 3;
            // 
            // btnUnJoin
            // 
            this.btnUnJoin.Location = new System.Drawing.Point(894, 3);
            this.btnUnJoin.Name = "btnUnJoin";
            this.btnUnJoin.Size = new System.Drawing.Size(153, 23);
            this.btnUnJoin.TabIndex = 0;
            this.btnUnJoin.Text = "Повернути на розгляд";
            this.btnUnJoin.UseVisualStyleBackColor = true;
            this.btnUnJoin.Click += new System.EventHandler(this.btnUnJoin_Click);
            // 
            // FormDciSearchInMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 555);
            this.Controls.Add(this.panelMain);
            this.Name = "FormDciSearchInMs";
            this.Text = "Звіт MSI - поєднання творів WID з творами локальною БД";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDciSearchInMs_FormClosing);
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
            this.panelReportWorks.ResumeLayout(false);
            this.panelReportWorks.PerformLayout();
            this.panelReportWorksFilter.ResumeLayout(false);
            this.panelReportWorksFilter.PerformLayout();
            this.panelLeftButtons.ResumeLayout(false);
            this.panelLocalWorks.ResumeLayout(false);
            this.panelLocalWorks.PerformLayout();
            this.panelLocalWorksFilter.ResumeLayout(false);
            this.panelLocalWorksFilter.PerformLayout();
            this.panelContainingText.ResumeLayout(false);
            this.panelContainingText.PerformLayout();
            this.panelRightButtons.ResumeLayout(false);
            this.panelFoundWorks.ResumeLayout(false);
            this.panelFoundWorks.PerformLayout();
            this.panelFoundWorkFilter.ResumeLayout(false);
            this.panelFoundWorkFilter.PerformLayout();
            this.panelBottomButtons.ResumeLayout(false);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel panelLocalWorksFilter;
        private System.Windows.Forms.Label labLocalWorksAuthor;
        private System.Windows.Forms.TextBox tbLocalWorksAuthor;
        private System.Windows.Forms.Button btnLocalWorksAuthorSearch;
        private System.Windows.Forms.TableLayoutPanel panelReportWorksFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbReportAuthor;
        private System.Windows.Forms.TableLayoutPanel panelContainingText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearchText;
        private System.Windows.Forms.Button btnSearchText;
        private System.Windows.Forms.FlowLayoutPanel panelLeftButtons;
        private System.Windows.Forms.Button btnDisregard;
        private System.Windows.Forms.FlowLayoutPanel panelRightButtons;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TableLayoutPanel panelFoundWorkFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFoundWorkAuthor;
        private System.Windows.Forms.FlowLayoutPanel panelBottomButtons;
        private System.Windows.Forms.Button btnUnJoin;
        private System.Windows.Forms.Label labCoAuthor;
        private System.Windows.Forms.ComboBox cbCoAuthors;
    }
}

