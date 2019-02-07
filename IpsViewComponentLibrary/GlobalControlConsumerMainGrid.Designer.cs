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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
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
            gridViewTextBoxColumn11.DataType = typeof(int);
            gridViewTextBoxColumn11.FieldName = "innokpo";
            gridViewTextBoxColumn11.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn11.Name = "Innokpo";
            gridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn11.Width = 153;
            gridViewTextBoxColumn12.FieldName = "name";
            gridViewTextBoxColumn12.HeaderText = "Назва";
            gridViewTextBoxColumn12.Multiline = true;
            gridViewTextBoxColumn12.Name = "Name";
            gridViewTextBoxColumn12.Width = 625;
            gridViewTextBoxColumn12.WrapText = true;
            gridViewTextBoxColumn13.DataType = typeof(int);
            gridViewTextBoxColumn13.FieldName = "countAgree";
            gridViewTextBoxColumn13.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn13.Name = "CountAgree";
            gridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn13.Width = 153;
            gridViewTextBoxColumn13.WrapText = true;
            gridViewTextBoxColumn14.DataType = typeof(double);
            gridViewTextBoxColumn14.FieldName = "undistribamount";
            gridViewTextBoxColumn14.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn14.Name = "Undistribamount";
            gridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn14.Width = 170;
            gridViewTextBoxColumn14.WrapText = true;
            gridViewTextBoxColumn15.DataType = typeof(int);
            gridViewTextBoxColumn15.FieldName = "custId";
            gridViewTextBoxColumn15.HeaderText = "ID";
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "CustId";
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.AllowSort = false;
            gridViewCommandColumn3.DefaultText = "Відкрити";
            gridViewCommandColumn3.FieldName = "btnsEdit";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn3.MaxWidth = 25;
            gridViewCommandColumn3.MinWidth = 25;
            gridViewCommandColumn3.Name = "btnsEdit";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 25;
            this.gvViewConsumers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewCommandColumn3});
            this.gvViewConsumers.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableGrouping = false;
            this.gvViewConsumers.MasterTemplate.ShowFilteringRow = false;
            this.gvViewConsumers.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gvViewConsumers.Name = "gvViewConsumers";
            this.gvViewConsumers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewConsumers.Size = new System.Drawing.Size(1148, 555);
            this.gvViewConsumers.TabIndex = 3;
            this.gvViewConsumers.ThemeName = "Office2013Light";
            this.gvViewConsumers.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewConsumers_CellDoubleClick);
            this.gvViewConsumers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rGridViewConsumers_CommandCellClick);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 3);
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
            // GlobalControlConsumerMainGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddbtnAddConsumer);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.gvViewConsumers);
            this.Name = "GlobalControlConsumerMainGrid";
            this.Size = new System.Drawing.Size(1154, 588);
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
