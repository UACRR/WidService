namespace IpsViewComponentLibrary.ObjectRightControls
{
    partial class ObjectRightListControl
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectRightListControl));
            this.gvObjectsRightsList = new Telerik.WinControls.UI.RadGridView();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnUpdateList = new Telerik.WinControls.UI.RadButton();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.objectRightMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarMaskedEditBox1 = new Telerik.WinControls.UI.CommandBarMaskedEditBox();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.commandBarDropDownButton1 = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarButton8 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.commandButtonPanel = new System.Windows.Forms.Panel();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton4 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.tvFilters = new Telerik.WinControls.UI.RadTreeView();
            this.navigatorPanel = new IpsViewComponentLibrary.Common.NavigatorPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList.MasterTemplate)).BeginInit();
            this.gvObjectsRightsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightMainViewBindingSource)).BeginInit();
            this.commandPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).BeginInit();
            this.SuspendLayout();
            // 
            // gvObjectsRightsList
            // 
            this.gvObjectsRightsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvObjectsRightsList.Controls.Add(this.waitingBar);
            this.gvObjectsRightsList.Location = new System.Drawing.Point(3, 30);
            // 
            // 
            // 
            this.gvObjectsRightsList.MasterTemplate.AllowAddNewRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowDeleteRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowEditRow = false;
            this.gvObjectsRightsList.MasterTemplate.AutoGenerateColumns = false;
            this.gvObjectsRightsList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "ObjId";
            gridViewDecimalColumn1.HeaderText = "Шифр твору";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "ObjId";
            gridViewDecimalColumn1.Width = 67;
            gridViewTextBoxColumn1.FieldName = "Name";
            gridViewTextBoxColumn1.HeaderText = "Назва твору";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 149;
            gridViewTextBoxColumn2.FieldName = "Category";
            gridViewTextBoxColumn2.HeaderText = "В/М";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Category";
            gridViewTextBoxColumn2.Width = 36;
            gridViewTextBoxColumn3.FieldName = "GenreName";
            gridViewTextBoxColumn3.HeaderText = "Жанр";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "GenreName";
            gridViewTextBoxColumn3.Width = 75;
            gridViewDecimalColumn2.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewDecimalColumn2.FieldName = "Duration";
            gridViewDecimalColumn2.HeaderText = "Час";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "Duration";
            gridViewDecimalColumn2.Width = 54;
            gridViewTextBoxColumn4.FieldName = "SpecName";
            gridViewTextBoxColumn4.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "SpecName";
            gridViewTextBoxColumn4.Width = 75;
            gridViewDecimalColumn3.DataType = typeof(double);
            gridViewDecimalColumn3.FieldName = "RateTotal";
            gridViewDecimalColumn3.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "RateTotal";
            gridViewDecimalColumn3.Width = 54;
            gridViewTextBoxColumn5.FieldName = "Performer";
            gridViewTextBoxColumn5.HeaderText = "Виконавець";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Performer";
            gridViewTextBoxColumn5.Width = 75;
            gridViewDecimalColumn4.DataType = typeof(double);
            gridViewDecimalColumn4.FieldName = "Profit";
            gridViewDecimalColumn4.FormatString = "{0:N2}";
            gridViewDecimalColumn4.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "Profit";
            gridViewDecimalColumn4.Width = 70;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Редагувати";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "EditColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            this.gvObjectsRightsList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn5,
            gridViewDecimalColumn4,
            gridViewCommandColumn1});
            this.gvObjectsRightsList.MasterTemplate.DataSource = this.objectRightMainViewBindingSource;
            this.gvObjectsRightsList.MasterTemplate.ShowFilteringRow = false;
            this.gvObjectsRightsList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvObjectsRightsList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvObjectsRightsList.Name = "gvObjectsRightsList";
            this.gvObjectsRightsList.ShowGroupPanel = false;
            this.gvObjectsRightsList.Size = new System.Drawing.Size(687, 314);
            this.gvObjectsRightsList.TabIndex = 22;
            this.gvObjectsRightsList.ThemeName = "Office2013Light";
            this.gvObjectsRightsList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvObjectsRightsList_CellDoubleClick);
            this.gvObjectsRightsList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvObjectsRightsList_CommandCellClick);
            // 
            // waitingBar
            // 
            this.waitingBar.AssociatedControl = this.splitPanel2;
            this.waitingBar.Location = new System.Drawing.Point(315, 81);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 1;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.ThemeName = "Office2013Light";
            this.waitingBar.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.waitingBar.WaitingSpeed = 50;
            this.waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.waitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.txtSearch);
            this.splitPanel2.Controls.Add(this.btnUpdateList);
            this.splitPanel2.Controls.Add(this.gvObjectsRightsList);
            this.splitPanel2.Location = new System.Drawing.Point(107, 0);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(693, 344);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.3770186F, 0F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(238, 0);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.ThemeName = "Office2013Light";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(130, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 33;
            this.txtSearch.ThemeName = "Office2013Light";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearchObject_TextChanged);
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).Image = global::IpsViewComponentLibrary.Properties.Resources.search;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Location = new System.Drawing.Point(3, 3);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(110, 21);
            this.btnUpdateList.TabIndex = 25;
            this.btnUpdateList.Text = "Оновити";
            this.btnUpdateList.ThemeName = "Office2013Light";
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            // 
            // objectRightMainViewBindingSource
            // 
            this.objectRightMainViewBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectRightMainView);
            // 
            // timerSearch
            // 
            this.timerSearch.Interval = 300;
            this.timerSearch.Tick += new System.EventHandler(this.timerSearch_Tick);
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement2.Name = "commandBarRowElement2";
            this.commandBarRowElement2.Text = "";
            this.commandBarRowElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement2.UseCompatibleTextRendering = false;
            // 
            // commandBarMaskedEditBox1
            // 
            this.commandBarMaskedEditBox1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarMaskedEditBox1.DisplayName = "commandBarMaskedEditBox1";
            this.commandBarMaskedEditBox1.MaxSize = new System.Drawing.Size(50, 0);
            this.commandBarMaskedEditBox1.MinSize = new System.Drawing.Size(106, 22);
            this.commandBarMaskedEditBox1.Name = "commandBarMaskedEditBox1";
            this.commandBarMaskedEditBox1.Text = "commandBarMaskedEditBox1";
            this.commandBarMaskedEditBox1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarMaskedEditBox1.UseCompatibleTextRendering = false;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "radMenuItem1";
            this.radMenuItem1.UseCompatibleTextRendering = false;
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "radMenuItem2";
            this.radMenuItem2.UseCompatibleTextRendering = false;
            // 
            // commandBarDropDownButton1
            // 
            this.commandBarDropDownButton1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarDropDownButton1.DisplayName = "commandBarDropDownButton1";
            this.commandBarDropDownButton1.DrawImage = false;
            this.commandBarDropDownButton1.DrawText = true;
            this.commandBarDropDownButton1.Image = null;
            this.commandBarDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2});
            this.commandBarDropDownButton1.Name = "commandBarDropDownButton1";
            this.commandBarDropDownButton1.Text = "Додати";
            this.commandBarDropDownButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarDropDownButton1.UseCompatibleTextRendering = false;
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarDropDownButton1,
            this.commandBarButton8});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            this.commandBarStripElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement2.UseCompatibleTextRendering = false;
            // 
            // commandBarButton8
            // 
            this.commandBarButton8.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton8.DisplayName = "commandBarButton8";
            this.commandBarButton8.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton8.Image")));
            this.commandBarButton8.Name = "commandBarButton8";
            this.commandBarButton8.Text = "commandBarButton8";
            this.commandBarButton8.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton8.UseCompatibleTextRendering = false;
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.tableLayoutPanel1);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandPanel.Location = new System.Drawing.Point(0, 344);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(800, 36);
            this.commandPanel.TabIndex = 32;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.21316F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.78684F));
            this.tableLayoutPanel1.Controls.Add(this.commandButtonPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.navigatorPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 36);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // commandButtonPanel
            // 
            this.commandButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandButtonPanel.Location = new System.Drawing.Point(3, 3);
            this.commandButtonPanel.Name = "commandButtonPanel";
            this.commandButtonPanel.Size = new System.Drawing.Size(387, 30);
            this.commandButtonPanel.TabIndex = 0;
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton1.Image")));
            this.commandBarButton1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton1.UseCompatibleTextRendering = false;
            // 
            // commandBarButton2
            // 
            this.commandBarButton2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton2.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton2.Image")));
            this.commandBarButton2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.commandBarButton2.Name = "commandBarButton2";
            this.commandBarButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton2.UseCompatibleTextRendering = false;
            // 
            // commandBarButton4
            // 
            this.commandBarButton4.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton4.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton4.Image")));
            this.commandBarButton4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.commandBarButton4.Name = "commandBarButton4";
            this.commandBarButton4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton4.UseCompatibleTextRendering = false;
            // 
            // commandBarButton3
            // 
            this.commandBarButton3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton3.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton3.Image")));
            this.commandBarButton3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.commandBarButton3.Name = "commandBarButton3";
            this.commandBarButton3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarButton3.UseCompatibleTextRendering = false;
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.EnableCollapsing = true;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(800, 344);
            this.radSplitContainer1.SplitterWidth = 10;
            this.radSplitContainer1.TabIndex = 34;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.ThemeName = "Office2013Light";
            this.radSplitContainer1.UseSplitterButtons = true;
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.tvFilters);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(97, 344);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.3770186F, 0F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-238, 0);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            this.splitPanel1.ThemeName = "Office2013Light";
            // 
            // tvFilters
            // 
            this.tvFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFilters.Location = new System.Drawing.Point(0, 0);
            this.tvFilters.Name = "tvFilters";
            this.tvFilters.ShowExpandCollapse = false;
            this.tvFilters.Size = new System.Drawing.Size(97, 344);
            this.tvFilters.TabIndex = 1;
            this.tvFilters.ThemeName = "Office2013Light";
            this.tvFilters.ToggleMode = Telerik.WinControls.UI.ToggleMode.None;
            this.tvFilters.SelectedNodeChanging += new Telerik.WinControls.UI.RadTreeView.RadTreeViewCancelEventHandler(this.tvFilters_SelectedNodeChanging);
            this.tvFilters.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.tvFilters_SelectedNodeChanged);
            this.tvFilters.NodeFormatting += new Telerik.WinControls.UI.TreeNodeFormattingEventHandler(this.tvFilters_NodeFormatting);
            // 
            // navigatorPanel
            // 
            this.navigatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navigatorPanel.CurrentPage = 1;
            this.navigatorPanel.Location = new System.Drawing.Point(447, 3);
            this.navigatorPanel.Name = "navigatorPanel";
            this.navigatorPanel.PageSize = 20;
            this.navigatorPanel.Size = new System.Drawing.Size(350, 28);
            this.navigatorPanel.TabIndex = 1;
            this.navigatorPanel.TotalPages = 0;
            this.navigatorPanel.CurrentPageChanged += new System.EventHandler(this.navigatorPanel_CurrentPageChanged);
            this.navigatorPanel.PageSizeChanged += new System.EventHandler(this.navigatorPanel_PageSizeChanged);
            // 
            // ObjectRightListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSplitContainer1);
            this.Controls.Add(this.commandPanel);
            this.Name = "ObjectRightListControl";
            this.Size = new System.Drawing.Size(800, 380);
            this.Load += new System.EventHandler(this.ObjectRightListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList)).EndInit();
            this.gvObjectsRightsList.ResumeLayout(false);
            this.gvObjectsRightsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightMainViewBindingSource)).EndInit();
            this.commandPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView gvObjectsRightsList;
        private System.Windows.Forms.BindingSource objectRightMainViewBindingSource;
        private Telerik.WinControls.UI.RadButton btnUpdateList;
        private System.Windows.Forms.Timer timerSearch;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton4;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private Telerik.WinControls.UI.CommandBarMaskedEditBox commandBarMaskedEditBox1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.CommandBarDropDownButton commandBarDropDownButton1;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton8;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton3;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel commandButtonPanel;
        private Common.NavigatorPanelControl navigatorPanel;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadTreeView tvFilters;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
    }
}
