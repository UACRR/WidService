namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class ConsumersViewSmallRightControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewConsumers = new Telerik.WinControls.UI.RadGridView();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.backgroundPanel = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.ipsPanel1 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.ddbtnAddConsumer = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnAddJurConsumer = new Telerik.WinControls.UI.RadMenuItem();
            this.btnAddPhisConsumer = new Telerik.WinControls.UI.RadMenuItem();
            this.ipsPanel2 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.navigatorPanel = new IpsViewComponentLibrary.Common.NavigatorPanelControl();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.bsConsumerSmallRightView = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).BeginInit();
            this.gvViewConsumers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPanel)).BeginInit();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).BeginInit();
            this.ipsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnAddConsumer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel2)).BeginInit();
            this.ipsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConsumerSmallRightView)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewConsumers
            // 
            this.gvViewConsumers.AutoScroll = true;
            this.gvViewConsumers.AutoSizeRows = true;
            this.gvViewConsumers.Controls.Add(this.waitingBar);
            this.gvViewConsumers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvViewConsumers.EnableCustomFiltering = true;
            this.gvViewConsumers.Location = new System.Drawing.Point(0, 26);
            // 
            // 
            // 
            this.gvViewConsumers.MasterTemplate.AllowAddNewRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDeleteRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDragToGroup = false;
            this.gvViewConsumers.MasterTemplate.AllowEditRow = false;
            this.gvViewConsumers.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewConsumers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "Innokpo";
            gridViewTextBoxColumn2.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 100;
            gridViewTextBoxColumn2.Name = "Innokpo";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.FieldName = "Name";
            gridViewTextBoxColumn3.HeaderText = "Назва";
            gridViewTextBoxColumn3.MinWidth = 400;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "Name";
            gridViewTextBoxColumn3.Width = 639;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "ClientBrand";
            gridViewTextBoxColumn4.HeaderText = "Бренд";
            gridViewTextBoxColumn4.MinWidth = 140;
            gridViewTextBoxColumn4.Name = "ClientBrand";
            gridViewTextBoxColumn4.Width = 140;
            gridViewTextBoxColumn5.DataType = typeof(int);
            gridViewTextBoxColumn5.FieldName = "CountAgree";
            gridViewTextBoxColumn5.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn5.MaxWidth = 80;
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "CountAgree";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.DataType = typeof(double);
            gridViewTextBoxColumn6.FieldName = "Undistribamount";
            gridViewTextBoxColumn6.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn6.MaxWidth = 150;
            gridViewTextBoxColumn6.MinWidth = 100;
            gridViewTextBoxColumn6.Name = "Undistribamount";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 144;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "btnsEdit";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "btnsEdit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            this.gvViewConsumers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1});
            this.gvViewConsumers.MasterTemplate.DataSource = this.bsConsumerSmallRightView;
            this.gvViewConsumers.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableGrouping = false;
            this.gvViewConsumers.MasterTemplate.EnableSorting = false;
            this.gvViewConsumers.MasterTemplate.ShowFilteringRow = false;
            this.gvViewConsumers.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewConsumers.Name = "gvViewConsumers";
            this.gvViewConsumers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewConsumers.ReadOnly = true;
            this.gvViewConsumers.Size = new System.Drawing.Size(1154, 527);
            this.gvViewConsumers.TabIndex = 3;
            this.gvViewConsumers.ThemeName = "Office2013Light";
            this.gvViewConsumers.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewConsumers_CellDoubleClick);
            this.gvViewConsumers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvConsumers_CommandCellClick);
            // 
            // waitingBar
            // 
            this.waitingBar.AssociatedControl = this.backgroundPanel;
            this.waitingBar.Location = new System.Drawing.Point(542, 228);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 4;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.ThemeName = "Office2013Light";
            this.waitingBar.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.waitingBar.WaitingSpeed = 50;
            this.waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.waitingBar.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.waitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BorderVisible = false;
            this.backgroundPanel.Controls.Add(this.gvViewConsumers);
            this.backgroundPanel.Controls.Add(this.ipsPanel1);
            this.backgroundPanel.Controls.Add(this.ipsPanel2);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(1154, 588);
            this.backgroundPanel.TabIndex = 13;
            this.backgroundPanel.ThemeName = "Office2013Light";
            // 
            // ipsPanel1
            // 
            this.ipsPanel1.BorderVisible = false;
            this.ipsPanel1.Controls.Add(this.txtSearch);
            this.ipsPanel1.Controls.Add(this.ddbtnAddConsumer);
            this.ipsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ipsPanel1.Location = new System.Drawing.Point(0, 0);
            this.ipsPanel1.Name = "ipsPanel1";
            this.ipsPanel1.Size = new System.Drawing.Size(1154, 26);
            this.ipsPanel1.TabIndex = 10;
            this.ipsPanel1.ThemeName = "Office2013Light";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(479, 20);
            this.txtSearch.TabIndex = 35;
            this.txtSearch.ThemeName = "Office2013Light";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).Image = global::IpsViewComponentLibrary.Properties.Resources.search;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            // 
            // ddbtnAddConsumer
            // 
            this.ddbtnAddConsumer.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAddJurConsumer,
            this.btnAddPhisConsumer});
            this.ddbtnAddConsumer.Location = new System.Drawing.Point(488, 3);
            this.ddbtnAddConsumer.Name = "ddbtnAddConsumer";
            this.ddbtnAddConsumer.Size = new System.Drawing.Size(164, 20);
            this.ddbtnAddConsumer.TabIndex = 7;
            this.ddbtnAddConsumer.Text = "Новий користувач";
            this.ddbtnAddConsumer.ThemeName = "Office2013Light";
            // 
            // btnAddJurConsumer
            // 
            this.btnAddJurConsumer.Name = "btnAddJurConsumer";
            this.btnAddJurConsumer.Text = "Юридична особа";
            this.btnAddJurConsumer.Click += new System.EventHandler(this.btnAddJurConsumer_Click);
            // 
            // btnAddPhisConsumer
            // 
            this.btnAddPhisConsumer.Name = "btnAddPhisConsumer";
            this.btnAddPhisConsumer.Text = "Фізична особа";
            this.btnAddPhisConsumer.Click += new System.EventHandler(this.btnAddPhisConsumer_Click);
            // 
            // ipsPanel2
            // 
            this.ipsPanel2.BorderVisible = false;
            this.ipsPanel2.Controls.Add(this.navigatorPanel);
            this.ipsPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipsPanel2.Location = new System.Drawing.Point(0, 553);
            this.ipsPanel2.Name = "ipsPanel2";
            this.ipsPanel2.Size = new System.Drawing.Size(1154, 35);
            this.ipsPanel2.TabIndex = 12;
            this.ipsPanel2.ThemeName = "Office2013Light";
            // 
            // navigatorPanel
            // 
            this.navigatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navigatorPanel.CurrentPage = 1;
            this.navigatorPanel.Location = new System.Drawing.Point(3, 4);
            this.navigatorPanel.Name = "navigatorPanel";
            this.navigatorPanel.PageSize = 200;
            this.navigatorPanel.ReadOnlyPageSize = true;
            this.navigatorPanel.Size = new System.Drawing.Size(350, 28);
            this.navigatorPanel.TabIndex = 25;
            this.navigatorPanel.TotalPages = 0;
            this.navigatorPanel.CurrentPageChanged += new System.EventHandler(this.navigatorPanel_CurrentPageChanged);
            this.navigatorPanel.PageSizeChanged += new System.EventHandler(this.navigatorPanel_PageSizeChanged);
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // bsConsumerSmallRightView
            // 
            this.bsConsumerSmallRightView.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerSmallRightView);
            // 
            // timerSearch
            // 
            this.timerSearch.Interval = 300;
            this.timerSearch.Tick += new System.EventHandler(this.timerSearch_Tick);
            // 
            // ConsumersViewSmallRightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.backgroundPanel);
            this.Name = "ConsumersViewSmallRightControl";
            this.Size = new System.Drawing.Size(1154, 588);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).EndInit();
            this.gvViewConsumers.ResumeLayout(false);
            this.gvViewConsumers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPanel)).EndInit();
            this.backgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).EndInit();
            this.ipsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnAddConsumer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel2)).EndInit();
            this.ipsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsConsumerSmallRightView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvViewConsumers;
        private Telerik.WinControls.UI.RadDropDownButton ddbtnAddConsumer;
        private Telerik.WinControls.UI.RadMenuItem btnAddJurConsumer;
        private Telerik.WinControls.UI.RadMenuItem btnAddPhisConsumer;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Common.Editors.IpsPanel ipsPanel1;
        private Common.Editors.IpsPanel ipsPanel2;
        private System.Windows.Forms.BindingSource bsConsumerSmallRightView;
        private Common.NavigatorPanelControl navigatorPanel;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private System.Windows.Forms.Timer timerSearch;
        private Common.Editors.IpsPanel backgroundPanel;
    }
}
