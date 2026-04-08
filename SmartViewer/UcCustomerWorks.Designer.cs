namespace SmartViewer
{
    partial class UcCustomerWorks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCustomerWorks));
            this.splitPanelMain = new System.Windows.Forms.SplitContainer();
            this.panelCustomers = new System.Windows.Forms.TableLayoutPanel();
            this.lvCustomers = new System.Windows.Forms.ListView();
            this.panelCustomerFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCustomerFilterValue = new System.Windows.Forms.TextBox();
            this.btnCustomerFilterApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitPanelWorks = new System.Windows.Forms.SplitContainer();
            this.panelWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvWorks = new System.Windows.Forms.ListView();
            this.panelWorkFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWorkFilterValue = new System.Windows.Forms.TextBox();
            this.btnWorkFilterApply = new System.Windows.Forms.Button();
            this.panelWorksTitle = new System.Windows.Forms.TableLayoutPanel();
            this.panelWorkDetailsTitle = new System.Windows.Forms.Label();
            this.btnWorksExpandCollapse = new System.Windows.Forms.Button();
            this.ilExpandCollapse = new System.Windows.Forms.ImageList(this.components);
            this.panelWorkDetails = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlWorkDetails = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitPanelShares = new System.Windows.Forms.SplitContainer();
            this.panelSharesLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lvShares = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPanelAgreements = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lvShareDetailsIpi = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvAltNames = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvPerformers = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labWorkDetailsTitle = new System.Windows.Forms.Label();
            this.btnWorkDetailsExpandCollapse = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.ucShareDetailsMs = new SmartViewer.UcShareDetailsMs();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelMain)).BeginInit();
            this.splitPanelMain.Panel1.SuspendLayout();
            this.splitPanelMain.Panel2.SuspendLayout();
            this.splitPanelMain.SuspendLayout();
            this.panelCustomers.SuspendLayout();
            this.panelCustomerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelWorks)).BeginInit();
            this.splitPanelWorks.Panel1.SuspendLayout();
            this.splitPanelWorks.Panel2.SuspendLayout();
            this.splitPanelWorks.SuspendLayout();
            this.panelWorks.SuspendLayout();
            this.panelWorkFilter.SuspendLayout();
            this.panelWorksTitle.SuspendLayout();
            this.panelWorkDetails.SuspendLayout();
            this.tabControlWorkDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelShares)).BeginInit();
            this.splitPanelShares.Panel1.SuspendLayout();
            this.splitPanelShares.Panel2.SuspendLayout();
            this.splitPanelShares.SuspendLayout();
            this.panelSharesLeft.SuspendLayout();
            this.tabPanelAgreements.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitPanelMain
            // 
            this.splitPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanelMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitPanelMain.Location = new System.Drawing.Point(3, 23);
            this.splitPanelMain.Name = "splitPanelMain";
            // 
            // splitPanelMain.Panel1
            // 
            this.splitPanelMain.Panel1.Controls.Add(this.panelCustomers);
            // 
            // splitPanelMain.Panel2
            // 
            this.splitPanelMain.Panel2.Controls.Add(this.splitPanelWorks);
            this.splitPanelMain.Size = new System.Drawing.Size(1087, 634);
            this.splitPanelMain.SplitterDistance = 441;
            this.splitPanelMain.TabIndex = 0;
            // 
            // panelCustomers
            // 
            this.panelCustomers.ColumnCount = 1;
            this.panelCustomers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCustomers.Controls.Add(this.lvCustomers, 0, 2);
            this.panelCustomers.Controls.Add(this.panelCustomerFilter, 0, 1);
            this.panelCustomers.Controls.Add(this.label2, 0, 0);
            this.panelCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomers.Location = new System.Drawing.Point(0, 0);
            this.panelCustomers.Name = "panelCustomers";
            this.panelCustomers.RowCount = 4;
            this.panelCustomers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.panelCustomers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelCustomers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCustomers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelCustomers.Size = new System.Drawing.Size(441, 634);
            this.panelCustomers.TabIndex = 0;
            // 
            // lvCustomers
            // 
            this.lvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCustomers.HideSelection = false;
            this.lvCustomers.Location = new System.Drawing.Point(3, 54);
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(435, 557);
            this.lvCustomers.TabIndex = 0;
            this.lvCustomers.UseCompatibleStateImageBehavior = false;
            this.lvCustomers.SelectedIndexChanged += new System.EventHandler(this.lvCustomers_SelectedIndexChanged);
            this.lvCustomers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvCustomers_MouseDown);
            // 
            // panelCustomerFilter
            // 
            this.panelCustomerFilter.AutoSize = true;
            this.panelCustomerFilter.Controls.Add(this.label1);
            this.panelCustomerFilter.Controls.Add(this.tbCustomerFilterValue);
            this.panelCustomerFilter.Controls.Add(this.btnCustomerFilterApply);
            this.panelCustomerFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomerFilter.Location = new System.Drawing.Point(3, 19);
            this.panelCustomerFilter.Name = "panelCustomerFilter";
            this.panelCustomerFilter.Size = new System.Drawing.Size(435, 29);
            this.panelCustomerFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вибрати за назвоюю (3 букви мін)";
            // 
            // tbCustomerFilterValue
            // 
            this.tbCustomerFilterValue.Location = new System.Drawing.Point(188, 3);
            this.tbCustomerFilterValue.Name = "tbCustomerFilterValue";
            this.tbCustomerFilterValue.Size = new System.Drawing.Size(124, 20);
            this.tbCustomerFilterValue.TabIndex = 1;
            // 
            // btnCustomerFilterApply
            // 
            this.btnCustomerFilterApply.Location = new System.Drawing.Point(318, 3);
            this.btnCustomerFilterApply.Name = "btnCustomerFilterApply";
            this.btnCustomerFilterApply.Size = new System.Drawing.Size(97, 23);
            this.btnCustomerFilterApply.TabIndex = 2;
            this.btnCustomerFilterApply.Text = "Застосувати";
            this.btnCustomerFilterApply.UseVisualStyleBackColor = true;
            this.btnCustomerFilterApply.Click += new System.EventHandler(this.btnCustomerFilterApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Правовласники";
            // 
            // splitPanelWorks
            // 
            this.splitPanelWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanelWorks.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPanelWorks.Location = new System.Drawing.Point(0, 0);
            this.splitPanelWorks.Name = "splitPanelWorks";
            this.splitPanelWorks.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitPanelWorks.Panel1
            // 
            this.splitPanelWorks.Panel1.Controls.Add(this.panelWorks);
            // 
            // splitPanelWorks.Panel2
            // 
            this.splitPanelWorks.Panel2.Controls.Add(this.panelWorkDetails);
            this.splitPanelWorks.Size = new System.Drawing.Size(642, 634);
            this.splitPanelWorks.SplitterDistance = 232;
            this.splitPanelWorks.TabIndex = 0;
            // 
            // panelWorks
            // 
            this.panelWorks.ColumnCount = 1;
            this.panelWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorks.Controls.Add(this.lvWorks, 0, 2);
            this.panelWorks.Controls.Add(this.panelWorkFilter, 0, 1);
            this.panelWorks.Controls.Add(this.panelWorksTitle, 0, 0);
            this.panelWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorks.Location = new System.Drawing.Point(0, 0);
            this.panelWorks.Name = "panelWorks";
            this.panelWorks.RowCount = 4;
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelWorks.Size = new System.Drawing.Size(642, 232);
            this.panelWorks.TabIndex = 0;
            // 
            // lvWorks
            // 
            this.lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorks.HideSelection = false;
            this.lvWorks.Location = new System.Drawing.Point(3, 81);
            this.lvWorks.Name = "lvWorks";
            this.lvWorks.Size = new System.Drawing.Size(636, 138);
            this.lvWorks.TabIndex = 0;
            this.lvWorks.UseCompatibleStateImageBehavior = false;
            this.lvWorks.SelectedIndexChanged += new System.EventHandler(this.lvWorks_SelectedIndexChanged);
            this.lvWorks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvWorks_MouseDown);
            // 
            // panelWorkFilter
            // 
            this.panelWorkFilter.Controls.Add(this.label4);
            this.panelWorkFilter.Controls.Add(this.tbWorkFilterValue);
            this.panelWorkFilter.Controls.Add(this.btnWorkFilterApply);
            this.panelWorkFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkFilter.Location = new System.Drawing.Point(3, 38);
            this.panelWorkFilter.Name = "panelWorkFilter";
            this.panelWorkFilter.Size = new System.Drawing.Size(636, 37);
            this.panelWorkFilter.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Вибрати";
            // 
            // tbWorkFilterValue
            // 
            this.tbWorkFilterValue.Location = new System.Drawing.Point(58, 3);
            this.tbWorkFilterValue.Name = "tbWorkFilterValue";
            this.tbWorkFilterValue.Size = new System.Drawing.Size(124, 20);
            this.tbWorkFilterValue.TabIndex = 1;
            // 
            // btnWorkFilterApply
            // 
            this.btnWorkFilterApply.Location = new System.Drawing.Point(188, 3);
            this.btnWorkFilterApply.Name = "btnWorkFilterApply";
            this.btnWorkFilterApply.Size = new System.Drawing.Size(97, 23);
            this.btnWorkFilterApply.TabIndex = 2;
            this.btnWorkFilterApply.Text = "Застосувати";
            this.btnWorkFilterApply.UseVisualStyleBackColor = true;
            // 
            // panelWorksTitle
            // 
            this.panelWorksTitle.BackColor = System.Drawing.Color.LightBlue;
            this.panelWorksTitle.ColumnCount = 3;
            this.panelWorksTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelWorksTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorksTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelWorksTitle.Controls.Add(this.panelWorkDetailsTitle, 0, 0);
            this.panelWorksTitle.Controls.Add(this.btnWorksExpandCollapse, 2, 0);
            this.panelWorksTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorksTitle.Location = new System.Drawing.Point(3, 3);
            this.panelWorksTitle.Name = "panelWorksTitle";
            this.panelWorksTitle.RowCount = 1;
            this.panelWorksTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorksTitle.Size = new System.Drawing.Size(636, 29);
            this.panelWorksTitle.TabIndex = 4;
            // 
            // panelWorkDetailsTitle
            // 
            this.panelWorkDetailsTitle.AutoSize = true;
            this.panelWorkDetailsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkDetailsTitle.Location = new System.Drawing.Point(3, 0);
            this.panelWorkDetailsTitle.Name = "panelWorkDetailsTitle";
            this.panelWorkDetailsTitle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panelWorkDetailsTitle.Size = new System.Drawing.Size(185, 29);
            this.panelWorkDetailsTitle.TabIndex = 2;
            this.panelWorkDetailsTitle.Text = "Твори правовласника (не вибрано)";
            // 
            // btnWorksExpandCollapse
            // 
            this.btnWorksExpandCollapse.ImageIndex = 0;
            this.btnWorksExpandCollapse.ImageList = this.ilExpandCollapse;
            this.btnWorksExpandCollapse.Location = new System.Drawing.Point(606, 3);
            this.btnWorksExpandCollapse.Name = "btnWorksExpandCollapse";
            this.btnWorksExpandCollapse.Size = new System.Drawing.Size(26, 23);
            this.btnWorksExpandCollapse.TabIndex = 3;
            this.btnWorksExpandCollapse.UseVisualStyleBackColor = true;
            this.btnWorksExpandCollapse.Click += new System.EventHandler(this.btnWorksExpandCollapse_Click);
            // 
            // ilExpandCollapse
            // 
            this.ilExpandCollapse.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilExpandCollapse.ImageStream")));
            this.ilExpandCollapse.TransparentColor = System.Drawing.Color.Transparent;
            this.ilExpandCollapse.Images.SetKeyName(0, "Expand.png");
            this.ilExpandCollapse.Images.SetKeyName(1, "Collapse.png");
            // 
            // panelWorkDetails
            // 
            this.panelWorkDetails.ColumnCount = 1;
            this.panelWorkDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelWorkDetails.Controls.Add(this.tabControlWorkDetails, 0, 1);
            this.panelWorkDetails.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.panelWorkDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkDetails.Location = new System.Drawing.Point(0, 0);
            this.panelWorkDetails.Name = "panelWorkDetails";
            this.panelWorkDetails.RowCount = 2;
            this.panelWorkDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelWorkDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkDetails.Size = new System.Drawing.Size(642, 398);
            this.panelWorkDetails.TabIndex = 0;
            // 
            // tabControlWorkDetails
            // 
            this.tabControlWorkDetails.Controls.Add(this.tabPage1);
            this.tabControlWorkDetails.Controls.Add(this.tabPage2);
            this.tabControlWorkDetails.Controls.Add(this.tabPage3);
            this.tabControlWorkDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlWorkDetails.Location = new System.Drawing.Point(3, 38);
            this.tabControlWorkDetails.Name = "tabControlWorkDetails";
            this.tabControlWorkDetails.SelectedIndex = 0;
            this.tabControlWorkDetails.Size = new System.Drawing.Size(636, 357);
            this.tabControlWorkDetails.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.splitPanelShares);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(628, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Проценти";
            // 
            // splitPanelShares
            // 
            this.splitPanelShares.BackColor = System.Drawing.Color.Gainsboro;
            this.splitPanelShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanelShares.Location = new System.Drawing.Point(10, 10);
            this.splitPanelShares.Name = "splitPanelShares";
            this.splitPanelShares.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitPanelShares.Panel1
            // 
            this.splitPanelShares.Panel1.Controls.Add(this.panelSharesLeft);
            // 
            // splitPanelShares.Panel2
            // 
            this.splitPanelShares.Panel2.Controls.Add(this.tabPanelAgreements);
            this.splitPanelShares.Size = new System.Drawing.Size(608, 311);
            this.splitPanelShares.SplitterDistance = 144;
            this.splitPanelShares.TabIndex = 1;
            // 
            // panelSharesLeft
            // 
            this.panelSharesLeft.ColumnCount = 1;
            this.panelSharesLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSharesLeft.Controls.Add(this.lvShares, 0, 1);
            this.panelSharesLeft.Controls.Add(this.label5, 0, 0);
            this.panelSharesLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSharesLeft.Location = new System.Drawing.Point(0, 0);
            this.panelSharesLeft.Name = "panelSharesLeft";
            this.panelSharesLeft.RowCount = 3;
            this.panelSharesLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSharesLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSharesLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelSharesLeft.Size = new System.Drawing.Size(608, 144);
            this.panelSharesLeft.TabIndex = 0;
            // 
            // lvShares
            // 
            this.lvShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShares.HideSelection = false;
            this.lvShares.Location = new System.Drawing.Point(3, 23);
            this.lvShares.Name = "lvShares";
            this.lvShares.Size = new System.Drawing.Size(602, 110);
            this.lvShares.TabIndex = 0;
            this.lvShares.UseCompatibleStateImageBehavior = false;
            this.lvShares.SelectedIndexChanged += new System.EventHandler(this.lvShares_SelectedIndexChanged);
            this.lvShares.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvShares_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Правоволодіння в СМАРТ";
            // 
            // tabPanelAgreements
            // 
            this.tabPanelAgreements.Controls.Add(this.tabPage5);
            this.tabPanelAgreements.Controls.Add(this.tabPage4);
            this.tabPanelAgreements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanelAgreements.Location = new System.Drawing.Point(0, 0);
            this.tabPanelAgreements.Name = "tabPanelAgreements";
            this.tabPanelAgreements.Padding = new System.Drawing.Point(3, 3);
            this.tabPanelAgreements.SelectedIndex = 0;
            this.tabPanelAgreements.Size = new System.Drawing.Size(608, 163);
            this.tabPanelAgreements.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ucShareDetailsMs);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(600, 137);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Внутрішній договір";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lvShareDetailsIpi);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(600, 137);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Міжнародні договори";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lvShareDetailsIpi
            // 
            this.lvShareDetailsIpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShareDetailsIpi.HideSelection = false;
            this.lvShareDetailsIpi.Location = new System.Drawing.Point(3, 3);
            this.lvShareDetailsIpi.Name = "lvShareDetailsIpi";
            this.lvShareDetailsIpi.Size = new System.Drawing.Size(594, 131);
            this.lvShareDetailsIpi.TabIndex = 1;
            this.lvShareDetailsIpi.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvAltNames);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(628, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Альтернативні назви";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvAltNames
            // 
            this.lvAltNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAltNames.HideSelection = false;
            this.lvAltNames.Location = new System.Drawing.Point(3, 3);
            this.lvAltNames.Name = "lvAltNames";
            this.lvAltNames.Size = new System.Drawing.Size(622, 325);
            this.lvAltNames.TabIndex = 1;
            this.lvAltNames.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvPerformers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(628, 331);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Виконавці";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvPerformers
            // 
            this.lvPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPerformers.HideSelection = false;
            this.lvPerformers.Location = new System.Drawing.Point(0, 0);
            this.lvPerformers.Name = "lvPerformers";
            this.lvPerformers.Size = new System.Drawing.Size(628, 331);
            this.lvPerformers.TabIndex = 2;
            this.lvPerformers.UseCompatibleStateImageBehavior = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Azure;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Controls.Add(this.labWorkDetailsTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnWorkDetailsExpandCollapse, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 29);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labWorkDetailsTitle
            // 
            this.labWorkDetailsTitle.AutoSize = true;
            this.labWorkDetailsTitle.Location = new System.Drawing.Point(3, 0);
            this.labWorkDetailsTitle.Name = "labWorkDetailsTitle";
            this.labWorkDetailsTitle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labWorkDetailsTitle.Size = new System.Drawing.Size(156, 20);
            this.labWorkDetailsTitle.TabIndex = 0;
            this.labWorkDetailsTitle.Text = "Подробиці твору (не вибрано)";
            // 
            // btnWorkDetailsExpandCollapse
            // 
            this.btnWorkDetailsExpandCollapse.ImageIndex = 0;
            this.btnWorkDetailsExpandCollapse.ImageList = this.ilExpandCollapse;
            this.btnWorkDetailsExpandCollapse.Location = new System.Drawing.Point(606, 3);
            this.btnWorkDetailsExpandCollapse.Name = "btnWorkDetailsExpandCollapse";
            this.btnWorkDetailsExpandCollapse.Size = new System.Drawing.Size(25, 23);
            this.btnWorkDetailsExpandCollapse.TabIndex = 3;
            this.btnWorkDetailsExpandCollapse.UseVisualStyleBackColor = true;
            this.btnWorkDetailsExpandCollapse.Click += new System.EventHandler(this.btnWorkDetailsExpandCollapse_Click);
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.splitPanelMain, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1093, 680);
            this.panelMain.TabIndex = 1;
            // 
            // ucShareDetailsMs
            // 
            this.ucShareDetailsMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShareDetailsMs.Location = new System.Drawing.Point(3, 3);
            this.ucShareDetailsMs.Name = "ucShareDetailsMs";
            this.ucShareDetailsMs.Size = new System.Drawing.Size(594, 131);
            this.ucShareDetailsMs.TabIndex = 0;
            // 
            // UcCustomerWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcCustomerWorks";
            this.Size = new System.Drawing.Size(1093, 680);
            this.Load += new System.EventHandler(this.UcCustomers_Load);
            this.splitPanelMain.Panel1.ResumeLayout(false);
            this.splitPanelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelMain)).EndInit();
            this.splitPanelMain.ResumeLayout(false);
            this.panelCustomers.ResumeLayout(false);
            this.panelCustomers.PerformLayout();
            this.panelCustomerFilter.ResumeLayout(false);
            this.panelCustomerFilter.PerformLayout();
            this.splitPanelWorks.Panel1.ResumeLayout(false);
            this.splitPanelWorks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelWorks)).EndInit();
            this.splitPanelWorks.ResumeLayout(false);
            this.panelWorks.ResumeLayout(false);
            this.panelWorkFilter.ResumeLayout(false);
            this.panelWorkFilter.PerformLayout();
            this.panelWorksTitle.ResumeLayout(false);
            this.panelWorksTitle.PerformLayout();
            this.panelWorkDetails.ResumeLayout(false);
            this.tabControlWorkDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitPanelShares.Panel1.ResumeLayout(false);
            this.splitPanelShares.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelShares)).EndInit();
            this.splitPanelShares.ResumeLayout(false);
            this.panelSharesLeft.ResumeLayout(false);
            this.panelSharesLeft.PerformLayout();
            this.tabPanelAgreements.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitPanelMain;
        private System.Windows.Forms.TableLayoutPanel panelCustomers;
        private System.Windows.Forms.ListView lvCustomers;
        private System.Windows.Forms.FlowLayoutPanel panelCustomerFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCustomerFilterValue;
        private System.Windows.Forms.Button btnCustomerFilterApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitPanelWorks;
        private System.Windows.Forms.TableLayoutPanel panelWorks;
        private System.Windows.Forms.ListView lvWorks;
        private System.Windows.Forms.Label panelWorkDetailsTitle;
        private System.Windows.Forms.FlowLayoutPanel panelWorkFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbWorkFilterValue;
        private System.Windows.Forms.Button btnWorkFilterApply;
        private System.Windows.Forms.TabControl tabControlWorkDetails;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvAltNames;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvPerformers;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer splitPanelShares;
        private System.Windows.Forms.TableLayoutPanel panelSharesLeft;
        private System.Windows.Forms.ListView lvShares;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabPanelAgreements;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView lvShareDetailsIpi;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel panelWorksTitle;
        private System.Windows.Forms.Button btnWorksExpandCollapse;
        private System.Windows.Forms.TableLayoutPanel panelWorkDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labWorkDetailsTitle;
        private System.Windows.Forms.Button btnWorkDetailsExpandCollapse;
        private System.Windows.Forms.ImageList ilExpandCollapse;
        private UcShareDetailsMs ucShareDetailsMs;
    }
}
