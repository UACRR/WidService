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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
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
            this.navigatorPanel = new IpsViewComponentLibrary.Common.NavigatorPanelControl();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton4 = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.tvFilters = new Telerik.WinControls.UI.RadTreeView();
            this.lblTextRightList = new System.Windows.Forms.Label();
            this.lblCountRightList = new System.Windows.Forms.Label();
            this.commandButtonPanel = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).BeginInit();
            this.commandButtonPanel.SuspendLayout();
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
            gridViewDecimalColumn5.DataType = typeof(int);
            gridViewDecimalColumn5.FieldName = "ObjId";
            gridViewDecimalColumn5.HeaderText = "Шифр твору";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "ObjId";
            gridViewDecimalColumn5.Width = 68;
            gridViewTextBoxColumn6.FieldName = "Name";
            gridViewTextBoxColumn6.HeaderText = "Назва твору";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "Name";
            gridViewTextBoxColumn6.Width = 151;
            gridViewTextBoxColumn7.FieldName = "Category";
            gridViewTextBoxColumn7.HeaderText = "В/М";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "Category";
            gridViewTextBoxColumn7.Width = 36;
            gridViewTextBoxColumn8.FieldName = "GenreName";
            gridViewTextBoxColumn8.HeaderText = "Жанр";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "GenreName";
            gridViewTextBoxColumn8.Width = 76;
            gridViewDecimalColumn6.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewDecimalColumn6.FieldName = "Duration";
            gridViewDecimalColumn6.HeaderText = "Час";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.Name = "Duration";
            gridViewDecimalColumn6.Width = 55;
            gridViewTextBoxColumn9.FieldName = "SpecName";
            gridViewTextBoxColumn9.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "SpecName";
            gridViewTextBoxColumn9.Width = 76;
            gridViewDecimalColumn7.DataType = typeof(double);
            gridViewDecimalColumn7.FieldName = "RateTotal";
            gridViewDecimalColumn7.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.Name = "RateTotal";
            gridViewDecimalColumn7.Width = 55;
            gridViewTextBoxColumn10.FieldName = "Performer";
            gridViewTextBoxColumn10.HeaderText = "Виконавець";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.Name = "Performer";
            gridViewTextBoxColumn10.Width = 76;
            gridViewDecimalColumn8.DataType = typeof(double);
            gridViewDecimalColumn8.FieldName = "Profit";
            gridViewDecimalColumn8.FormatString = "{0:N2}";
            gridViewDecimalColumn8.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.Name = "Profit";
            gridViewDecimalColumn8.Width = 71;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Редагувати";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "EditColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 30;
            this.gvObjectsRightsList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewDecimalColumn6,
            gridViewTextBoxColumn9,
            gridViewDecimalColumn7,
            gridViewTextBoxColumn10,
            gridViewDecimalColumn8,
            gridViewCommandColumn2});
            this.gvObjectsRightsList.MasterTemplate.DataSource = this.objectRightMainViewBindingSource;
            this.gvObjectsRightsList.MasterTemplate.ShowFilteringRow = false;
            this.gvObjectsRightsList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvObjectsRightsList.MasterTemplate.ViewDefinition = tableViewDefinition2;
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
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.waitingBar.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
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
            this.commandPanel.Controls.Add(this.commandButtonPanel);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandPanel.Location = new System.Drawing.Point(0, 344);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(800, 36);
            this.commandPanel.TabIndex = 32;
            // 
            // navigatorPanel
            // 
            this.navigatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navigatorPanel.CurrentPage = 1;
            this.navigatorPanel.Location = new System.Drawing.Point(308, 1);
            this.navigatorPanel.Name = "navigatorPanel";
            this.navigatorPanel.PageSize = 20;
            this.navigatorPanel.ReadOnlyPageSize = false;
            this.navigatorPanel.Size = new System.Drawing.Size(350, 28);
            this.navigatorPanel.TabIndex = 1;
            this.navigatorPanel.TotalPages = 0;
            this.navigatorPanel.CurrentPageChanged += new System.EventHandler(this.navigatorPanel_CurrentPageChanged);
            this.navigatorPanel.PageSizeChanged += new System.EventHandler(this.navigatorPanel_PageSizeChanged);
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
            // lblTextRightList
            // 
            this.lblTextRightList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextRightList.BackColor = System.Drawing.Color.Transparent;
            this.lblTextRightList.Location = new System.Drawing.Point(667, 7);
            this.lblTextRightList.Name = "lblTextRightList";
            this.lblTextRightList.Size = new System.Drawing.Size(73, 16);
            this.lblTextRightList.TabIndex = 0;
            this.lblTextRightList.Text = "К-ть об\'єктів";
            // 
            // lblCountRightList
            // 
            this.lblCountRightList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountRightList.BackColor = System.Drawing.Color.Transparent;
            this.lblCountRightList.Location = new System.Drawing.Point(747, 8);
            this.lblCountRightList.Name = "lblCountRightList";
            this.lblCountRightList.Size = new System.Drawing.Size(50, 14);
            this.lblCountRightList.TabIndex = 1;
            this.lblCountRightList.Text = "0";
            this.lblCountRightList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // commandButtonPanel
            // 
            this.commandButtonPanel.BackColor = System.Drawing.Color.Silver;
            this.commandButtonPanel.Controls.Add(this.lblTextRightList);
            this.commandButtonPanel.Controls.Add(this.navigatorPanel);
            this.commandButtonPanel.Controls.Add(this.lblCountRightList);
            this.commandButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandButtonPanel.Location = new System.Drawing.Point(0, 6);
            this.commandButtonPanel.Name = "commandButtonPanel";
            this.commandButtonPanel.Size = new System.Drawing.Size(800, 30);
            this.commandButtonPanel.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).EndInit();
            this.commandButtonPanel.ResumeLayout(false);
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
        private Common.NavigatorPanelControl navigatorPanel;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadTreeView tvFilters;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private System.Windows.Forms.Panel commandButtonPanel;
        private System.Windows.Forms.Label lblTextRightList;
        private System.Windows.Forms.Label lblCountRightList;
    }
}
