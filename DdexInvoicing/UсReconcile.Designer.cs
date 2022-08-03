namespace DdexInvoicing
{
    partial class UсReconcile
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UсReconcile));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelPages = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.gridRecords = new Telerik.WinControls.UI.RadGridView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage4 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage5 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage6 = new Telerik.WinControls.UI.RadPageViewPage();
            this.labPrompt = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilter = new Telerik.WinControls.UI.RadDropDownList();
            this.btnApply = new Telerik.WinControls.UI.RadButton();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelStatistics = new System.Windows.Forms.TableLayoutPanel();
            this.gridStatistics = new Telerik.WinControls.UI.RadGridView();
            this.btnRefreshStatistics = new Telerik.WinControls.UI.RadButton();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPages)).BeginInit();
            this.panelPages.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords.MasterTemplate)).BeginInit();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApply)).BeginInit();
            this.panelStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatistics.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelPages, 0, 3);
            this.panelMain.Controls.Add(this.labPrompt, 0, 0);
            this.panelMain.Controls.Add(this.panelFilter, 0, 1);
            this.panelMain.Controls.Add(this.btnApply, 0, 4);
            this.panelMain.Controls.Add(this.panelStatistics, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 6;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(991, 491);
            this.panelMain.TabIndex = 0;
            // 
            // panelPages
            // 
            this.panelPages.Controls.Add(this.radPageViewPage1);
            this.panelPages.Controls.Add(this.radPageViewPage2);
            this.panelPages.Controls.Add(this.radPageViewPage3);
            this.panelPages.Controls.Add(this.radPageViewPage4);
            this.panelPages.Controls.Add(this.radPageViewPage5);
            this.panelPages.Controls.Add(this.radPageViewPage6);
            this.panelPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPages.EnableAnalytics = false;
            this.panelPages.EnableGestures = false;
            this.panelPages.EnableTheming = false;
            this.panelPages.Location = new System.Drawing.Point(3, 230);
            this.panelPages.Name = "panelPages";
            this.panelPages.SelectedPage = this.radPageViewPage1;
            this.panelPages.Size = new System.Drawing.Size(985, 217);
            this.panelPages.TabIndex = 4;
            this.panelPages.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            this.panelPages.SelectedPageChanged += new System.EventHandler(this.panelPages_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewBackstageElement)(this.panelPages.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Top;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.gridRecords);
            this.radPageViewPage1.Description = null;
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(73F, 45F);
            this.radPageViewPage1.Location = new System.Drawing.Point(5, 60);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(976, 153);
            this.radPageViewPage1.Text = "Всі записи";
            this.radPageViewPage1.Title = "Всі записи";
            // 
            // gridRecords
            // 
            this.gridRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRecords.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridRecords.MasterTemplate.AllowAddNewRow = false;
            this.gridRecords.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.HeaderText = "Назва в звіті";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.HeaderText = "Назва в WID";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.HeaderText = "Підтверджено автоматично";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewCheckBoxColumn1.HeaderText = "Підтвердити";
            gridViewCheckBoxColumn1.Name = "column4";
            gridViewCheckBoxColumn1.Width = 100;
            gridViewCheckBoxColumn1.WrapText = true;
            gridViewCheckBoxColumn2.HeaderText = "Скасувати";
            gridViewCheckBoxColumn2.Name = "column5";
            gridViewCheckBoxColumn2.Width = 100;
            gridViewCheckBoxColumn2.WrapText = true;
            gridViewCheckBoxColumn3.HeaderText = "Ідентифікувати";
            gridViewCheckBoxColumn3.Name = "column6";
            gridViewCheckBoxColumn3.Width = 100;
            gridViewCheckBoxColumn3.WrapText = true;
            this.gridRecords.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1,
            gridViewCheckBoxColumn2,
            gridViewCheckBoxColumn3});
            this.gridRecords.MasterTemplate.EnableGrouping = false;
            this.gridRecords.MasterTemplate.EnableSorting = false;
            this.gridRecords.MasterTemplate.MultiSelect = true;
            this.gridRecords.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridRecords.Name = "gridRecords";
            this.gridRecords.Size = new System.Drawing.Size(976, 153);
            this.gridRecords.TabIndex = 0;
            this.gridRecords.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridRecords_CellEndEdit);
            this.gridRecords.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridRecords_CellClick);
            this.gridRecords.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gridRecords_CellValueChanged);
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Description = null;
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(135F, 45F);
            this.radPageViewPage2.Location = new System.Drawing.Point(5, 60);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(976, 155);
            this.radPageViewPage2.Text = "Не оброблені записи";
            this.radPageViewPage2.Title = "Не оброблені записи";
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.ItemSize = new System.Drawing.SizeF(133F, 45F);
            this.radPageViewPage3.Location = new System.Drawing.Point(4, 723);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(958, 292);
            this.radPageViewPage3.Text = "Підтверджені записи";
            // 
            // radPageViewPage4
            // 
            this.radPageViewPage4.ItemSize = new System.Drawing.SizeF(168F, 45F);
            this.radPageViewPage4.Location = new System.Drawing.Point(4, 393);
            this.radPageViewPage4.Name = "radPageViewPage4";
            this.radPageViewPage4.Size = new System.Drawing.Size(958, 292);
            this.radPageViewPage4.Text = "Підтверджені автоматично";
            // 
            // radPageViewPage5
            // 
            this.radPageViewPage5.ItemSize = new System.Drawing.SizeF(113F, 45F);
            this.radPageViewPage5.Location = new System.Drawing.Point(4, 63);
            this.radPageViewPage5.Name = "radPageViewPage5";
            this.radPageViewPage5.Size = new System.Drawing.Size(958, 292);
            this.radPageViewPage5.Text = "Скасовані записи";
            // 
            // radPageViewPage6
            // 
            this.radPageViewPage6.ItemSize = new System.Drawing.SizeF(225F, 45F);
            this.radPageViewPage6.Location = new System.Drawing.Point(5, 60);
            this.radPageViewPage6.Name = "radPageViewPage6";
            this.radPageViewPage6.Size = new System.Drawing.Size(976, 155);
            this.radPageViewPage6.Text = "Записи для повторення ідентифікації";
            // 
            // labPrompt
            // 
            this.labPrompt.AutoSize = true;
            this.labPrompt.BackColor = System.Drawing.SystemColors.Info;
            this.labPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPrompt.Location = new System.Drawing.Point(3, 0);
            this.labPrompt.Name = "labPrompt";
            this.labPrompt.Padding = new System.Windows.Forms.Padding(5);
            this.labPrompt.Size = new System.Drawing.Size(985, 62);
            this.labPrompt.TabIndex = 0;
            this.labPrompt.Text = resources.GetString("labPrompt.Text");
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.cbFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 65);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelFilter.Size = new System.Drawing.Size(985, 48);
            this.panelFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Size = new System.Drawing.Size(206, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Переглянути 1000 записів починаючи з";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownAnimationEnabled = false;
            this.cbFilter.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbFilter.Location = new System.Drawing.Point(215, 13);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(125, 20);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.Text = "1";
            this.cbFilter.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(871, 453);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 21);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Застосувати";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // panelStatistics
            // 
            this.panelStatistics.ColumnCount = 2;
            this.panelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 752F));
            this.panelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelStatistics.Controls.Add(this.gridStatistics, 0, 0);
            this.panelStatistics.Controls.Add(this.btnRefreshStatistics, 1, 0);
            this.panelStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatistics.Location = new System.Drawing.Point(3, 119);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.RowCount = 1;
            this.panelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelStatistics.Size = new System.Drawing.Size(985, 105);
            this.panelStatistics.TabIndex = 7;
            // 
            // gridStatistics
            // 
            this.gridStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatistics.EnableAnalytics = false;
            this.gridStatistics.EnableGestures = false;
            this.gridStatistics.HideSelection = true;
            this.gridStatistics.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gridStatistics.MasterTemplate.AllowAddNewRow = false;
            this.gridStatistics.MasterTemplate.AllowCellContextMenu = false;
            this.gridStatistics.MasterTemplate.AllowColumnChooser = false;
            this.gridStatistics.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.gridStatistics.MasterTemplate.AllowColumnReorder = false;
            this.gridStatistics.MasterTemplate.AllowColumnResize = false;
            this.gridStatistics.MasterTemplate.AllowDeleteRow = false;
            this.gridStatistics.MasterTemplate.AllowDragToGroup = false;
            this.gridStatistics.MasterTemplate.AllowEditRow = false;
            this.gridStatistics.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.gridStatistics.MasterTemplate.AllowRowResize = false;
            this.gridStatistics.MasterTemplate.AutoGenerateColumns = false;
            this.gridStatistics.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.AllowFiltering = false;
            gridViewTextBoxColumn4.AllowGroup = false;
            gridViewTextBoxColumn4.AllowHide = false;
            gridViewTextBoxColumn4.AllowNaturalSort = false;
            gridViewTextBoxColumn4.AllowReorder = false;
            gridViewTextBoxColumn4.AllowSearching = false;
            gridViewTextBoxColumn4.AllowSort = false;
            gridViewTextBoxColumn4.FieldName = "scope";
            gridViewTextBoxColumn4.HeaderText = "";
            gridViewTextBoxColumn4.IsPinned = true;
            gridViewTextBoxColumn4.MinWidth = 40;
            gridViewTextBoxColumn4.Name = "column1";
            gridViewTextBoxColumn4.PinPosition = Telerik.WinControls.UI.PinnedColumnPosition.Left;
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.AllowFiltering = false;
            gridViewTextBoxColumn5.AllowGroup = false;
            gridViewTextBoxColumn5.AllowHide = false;
            gridViewTextBoxColumn5.AllowNaturalSort = false;
            gridViewTextBoxColumn5.AllowReorder = false;
            gridViewTextBoxColumn5.AllowResize = false;
            gridViewTextBoxColumn5.AllowSearching = false;
            gridViewTextBoxColumn5.AllowSort = false;
            gridViewTextBoxColumn5.HeaderText = "Загалом";
            gridViewTextBoxColumn5.Name = "column6";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.AllowFiltering = false;
            gridViewTextBoxColumn6.AllowGroup = false;
            gridViewTextBoxColumn6.AllowHide = false;
            gridViewTextBoxColumn6.AllowNaturalSort = false;
            gridViewTextBoxColumn6.AllowReorder = false;
            gridViewTextBoxColumn6.AllowResize = false;
            gridViewTextBoxColumn6.AllowSearching = false;
            gridViewTextBoxColumn6.AllowSort = false;
            gridViewTextBoxColumn6.HeaderText = "Не оброблено";
            gridViewTextBoxColumn6.Name = "column7";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.AllowFiltering = false;
            gridViewTextBoxColumn7.AllowGroup = false;
            gridViewTextBoxColumn7.AllowHide = false;
            gridViewTextBoxColumn7.AllowNaturalSort = false;
            gridViewTextBoxColumn7.AllowReorder = false;
            gridViewTextBoxColumn7.AllowResize = false;
            gridViewTextBoxColumn7.AllowSearching = false;
            gridViewTextBoxColumn7.AllowSort = false;
            gridViewTextBoxColumn7.HeaderText = "Підтверждено";
            gridViewTextBoxColumn7.Name = "column2";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.AllowFiltering = false;
            gridViewTextBoxColumn8.AllowGroup = false;
            gridViewTextBoxColumn8.AllowHide = false;
            gridViewTextBoxColumn8.AllowNaturalSort = false;
            gridViewTextBoxColumn8.AllowReorder = false;
            gridViewTextBoxColumn8.AllowResize = false;
            gridViewTextBoxColumn8.AllowSearching = false;
            gridViewTextBoxColumn8.AllowSort = false;
            gridViewTextBoxColumn8.HeaderText = "З них автоматично";
            gridViewTextBoxColumn8.Name = "column3";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.AllowFiltering = false;
            gridViewTextBoxColumn9.AllowGroup = false;
            gridViewTextBoxColumn9.AllowHide = false;
            gridViewTextBoxColumn9.AllowNaturalSort = false;
            gridViewTextBoxColumn9.AllowReorder = false;
            gridViewTextBoxColumn9.AllowResize = false;
            gridViewTextBoxColumn9.AllowSearching = false;
            gridViewTextBoxColumn9.AllowSort = false;
            gridViewTextBoxColumn9.HeaderText = "Скасовано";
            gridViewTextBoxColumn9.Name = "column4";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.AllowFiltering = false;
            gridViewTextBoxColumn10.AllowGroup = false;
            gridViewTextBoxColumn10.AllowHide = false;
            gridViewTextBoxColumn10.AllowNaturalSort = false;
            gridViewTextBoxColumn10.AllowReorder = false;
            gridViewTextBoxColumn10.AllowResize = false;
            gridViewTextBoxColumn10.AllowSearching = false;
            gridViewTextBoxColumn10.AllowSort = false;
            gridViewTextBoxColumn10.HeaderText = "Повторити ідентифікацію";
            gridViewTextBoxColumn10.Name = "column5";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn10.Width = 100;
            gridViewTextBoxColumn10.WrapText = true;
            this.gridStatistics.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.gridStatistics.MasterTemplate.EnableAlternatingRowColor = true;
            this.gridStatistics.MasterTemplate.EnableGrouping = false;
            this.gridStatistics.MasterTemplate.EnableSorting = false;
            this.gridStatistics.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.None;
            this.gridStatistics.MasterTemplate.ShowFilteringRow = false;
            this.gridStatistics.MasterTemplate.ShowRowHeaderColumn = false;
            this.gridStatistics.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridStatistics.Name = "gridStatistics";
            this.gridStatistics.ReadOnly = true;
            this.gridStatistics.ShowCellErrors = false;
            this.gridStatistics.ShowGroupPanel = false;
            this.gridStatistics.ShowGroupPanelScrollbars = false;
            this.gridStatistics.Size = new System.Drawing.Size(746, 99);
            this.gridStatistics.TabIndex = 7;
            this.gridStatistics.TitleText = "Статистика обробки (кількість записів)";
            // 
            // btnRefreshStatistics
            // 
            this.btnRefreshStatistics.Location = new System.Drawing.Point(755, 3);
            this.btnRefreshStatistics.Name = "btnRefreshStatistics";
            this.btnRefreshStatistics.Size = new System.Drawing.Size(110, 24);
            this.btnRefreshStatistics.TabIndex = 8;
            this.btnRefreshStatistics.Text = "Оновити";
            this.btnRefreshStatistics.Click += new System.EventHandler(this.btnRefreshStatistics_Click);
            // 
            // UсReconcile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UсReconcile";
            this.Size = new System.Drawing.Size(991, 491);
            this.Load += new System.EventHandler(this.UсReconcile_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPages)).EndInit();
            this.panelPages.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecords)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApply)).EndInit();
            this.panelStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStatistics.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label labPrompt;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList cbFilter;
        private Telerik.WinControls.UI.RadPageView panelPages;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage4;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage5;
        private Telerik.WinControls.UI.RadGridView gridRecords;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage6;
        private Telerik.WinControls.UI.RadButton btnApply;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel panelStatistics;
        private Telerik.WinControls.UI.RadGridView gridStatistics;
        private Telerik.WinControls.UI.RadButton btnRefreshStatistics;
    }
}
