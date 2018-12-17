namespace IpsViewComponentLibrary
{
    partial class GlobalControlConsumerMainGrid
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewConsumers = new Telerik.WinControls.UI.RadGridView();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.ddbtnAddConsumer = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnAddJurConsumer = new Telerik.WinControls.UI.RadMenuItem();
            this.btnAddPhisConsumer = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnAddConsumer)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewConsumers
            // 
            this.gvViewConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewConsumers.EnableCustomFiltering = true;
            this.gvViewConsumers.Location = new System.Drawing.Point(3, 30);
            // 
            // 
            // 
            this.gvViewConsumers.MasterTemplate.AllowAddNewRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDeleteRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDragToGroup = false;
            this.gvViewConsumers.MasterTemplate.AllowEditRow = false;
            this.gvViewConsumers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn6.DataType = typeof(int);
            gridViewTextBoxColumn6.FieldName = "innokpo";
            gridViewTextBoxColumn6.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn6.Name = "Innokpo";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 94;
            gridViewTextBoxColumn7.FieldName = "name";
            gridViewTextBoxColumn7.HeaderText = "Назва";
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "Name";
            gridViewTextBoxColumn7.Width = 385;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.DataType = typeof(int);
            gridViewTextBoxColumn8.FieldName = "countAgree";
            gridViewTextBoxColumn8.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn8.Name = "CountAgree";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 94;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.DataType = typeof(double);
            gridViewTextBoxColumn9.FieldName = "undistribamount";
            gridViewTextBoxColumn9.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn9.Name = "Undistribamount";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 105;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.DataType = typeof(int);
            gridViewTextBoxColumn10.FieldName = "custId";
            gridViewTextBoxColumn10.HeaderText = "ID";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "CustId";
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.AllowSort = false;
            gridViewCommandColumn2.DefaultText = "Відкрити";
            gridViewCommandColumn2.FieldName = "btnsEdit";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.MaxWidth = 25;
            gridViewCommandColumn2.MinWidth = 25;
            gridViewCommandColumn2.Name = "btnsEdit";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 25;
            this.gvViewConsumers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewCommandColumn2});
            this.gvViewConsumers.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableGrouping = false;
            this.gvViewConsumers.MasterTemplate.ShowFilteringRow = false;
            this.gvViewConsumers.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvViewConsumers.Name = "gvViewConsumers";
            this.gvViewConsumers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewConsumers.Size = new System.Drawing.Size(725, 339);
            this.gvViewConsumers.TabIndex = 3;
            this.gvViewConsumers.ThemeName = "Office2013Light";
            this.gvViewConsumers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rGridViewConsumers_CommandCellClick);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 4);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(479, 20);
            this.ctrlSearch.TabIndex = 6;
            // 
            // ddbtnAddConsumer
            // 
            this.ddbtnAddConsumer.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAddJurConsumer,
            this.btnAddPhisConsumer});
            this.ddbtnAddConsumer.Location = new System.Drawing.Point(488, 4);
            this.ddbtnAddConsumer.Name = "ddbtnAddConsumer";
            this.ddbtnAddConsumer.Size = new System.Drawing.Size(164, 20);
            this.ddbtnAddConsumer.TabIndex = 7;
            this.ddbtnAddConsumer.Text = "Новий споживач";
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
            // GlobalControlConsumerMainGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddbtnAddConsumer);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.gvViewConsumers);
            this.Name = "GlobalControlConsumerMainGrid";
            this.Size = new System.Drawing.Size(731, 372);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnAddConsumer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvViewConsumers;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadDropDownButton ddbtnAddConsumer;
        private Telerik.WinControls.UI.RadMenuItem btnAddJurConsumer;
        private Telerik.WinControls.UI.RadMenuItem btnAddPhisConsumer;
    }
}
