namespace DdexInvoicing
{
    partial class UcDdexReports
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGridAgreements = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radGridViewReports = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabelReports = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGridAgreements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridAgreements.MasterTemplate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewReports.MasterTemplate)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelReports)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridAgreements
            // 
            this.radGridAgreements.AutoSizeRows = true;
            this.radGridAgreements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridAgreements.EnableHotTracking = false;
            this.radGridAgreements.Location = new System.Drawing.Point(3, 37);
            // 
            // 
            // 
            this.radGridAgreements.MasterTemplate.AllowAddNewRow = false;
            this.radGridAgreements.MasterTemplate.AllowColumnReorder = false;
            this.radGridAgreements.MasterTemplate.AllowDeleteRow = false;
            this.radGridAgreements.MasterTemplate.AllowEditRow = false;
            this.radGridAgreements.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.Expression = "";
            gridViewTextBoxColumn1.FieldName = "licId";
            gridViewTextBoxColumn1.HeaderText = "licId";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "licId";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "custId";
            gridViewTextBoxColumn2.HeaderText = "custId";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "custId";
            gridViewTextBoxColumn2.Width = 60;
            gridViewTextBoxColumn3.FieldName = "licenseeName";
            gridViewTextBoxColumn3.HeaderText = "Клієнт";
            gridViewTextBoxColumn3.Name = "licenseeName";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "licenseDescription";
            gridViewTextBoxColumn4.HeaderText = "Договір";
            gridViewTextBoxColumn4.Name = "licenseDescription";
            gridViewTextBoxColumn4.Width = 400;
            gridViewCommandColumn1.FieldName = "RegisterReport";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "RegisterReport";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 100;
            gridViewCommandColumn2.FieldName = "EditParameters";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "EditParameters";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 140;
            this.radGridAgreements.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.radGridAgreements.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridAgreements.MasterTemplate.ShowFilteringRow = false;
            this.radGridAgreements.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridAgreements.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridAgreements.Name = "radGridAgreements";
            this.radGridAgreements.ShowGroupPanel = false;
            this.radGridAgreements.ShowGroupPanelScrollbars = false;
            this.radGridAgreements.Size = new System.Drawing.Size(986, 244);
            this.radGridAgreements.TabIndex = 2;
            this.radGridAgreements.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridAgreements_CellFormatting);
            this.radGridAgreements.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.radGridAgreements_CurrentRowChanged);
            this.radGridAgreements.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGridAgreements_CommandCellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radGridViewReports, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radGridAgreements, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 430);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // radGridViewReports
            // 
            this.radGridViewReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewReports.EnableHotTracking = false;
            this.radGridViewReports.Location = new System.Drawing.Point(3, 321);
            // 
            // 
            // 
            this.radGridViewReports.MasterTemplate.AllowAddNewRow = false;
            this.radGridViewReports.MasterTemplate.AllowColumnReorder = false;
            this.radGridViewReports.MasterTemplate.AllowDeleteRow = false;
            this.radGridViewReports.MasterTemplate.AllowEditRow = false;
            this.radGridViewReports.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn5.Expression = "";
            gridViewTextBoxColumn5.FieldName = "ddexReportingPeriodId";
            gridViewTextBoxColumn5.HeaderText = "Код періода";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "ddexReportingPeriodId";
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn6.FieldName = "ddexReportId";
            gridViewTextBoxColumn6.HeaderText = "Код звіту";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "ddexReportId";
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn7.FieldName = "year";
            gridViewTextBoxColumn7.HeaderText = "Рік";
            gridViewTextBoxColumn7.Name = "year";
            gridViewTextBoxColumn7.Width = 60;
            gridViewTextBoxColumn8.FieldName = "quarter";
            gridViewTextBoxColumn8.HeaderText = "Квартал";
            gridViewTextBoxColumn8.Name = "quarter";
            gridViewTextBoxColumn8.Width = 60;
            gridViewTextBoxColumn9.FieldName = "serviceDescription";
            gridViewTextBoxColumn9.HeaderText = "Тип звіту";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "s";
            gridViewTextBoxColumn9.Width = 300;
            gridViewTextBoxColumn10.FieldName = "status";
            gridViewTextBoxColumn10.HeaderText = "statusCode";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "status";
            gridViewTextBoxColumn11.FieldName = "statusName";
            gridViewTextBoxColumn11.HeaderText = "Статус";
            gridViewTextBoxColumn11.Name = "statusName";
            gridViewTextBoxColumn11.Width = 150;
            gridViewCommandColumn3.FieldName = "Show";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Name = "Show";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 70;
            gridViewCommandColumn4.FieldName = "Archive";
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Name = "Archive";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.Width = 140;
            gridViewTextBoxColumn12.FieldName = "licenseeName";
            gridViewTextBoxColumn12.HeaderText = "licenseeName";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "licenseeName";
            gridViewTextBoxColumn13.FieldName = "licenseDescription";
            gridViewTextBoxColumn13.HeaderText = "licenseDescription";
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "licenseDescription";
            this.radGridViewReports.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewCommandColumn3,
            gridViewCommandColumn4,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13});
            this.radGridViewReports.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridViewReports.MasterTemplate.ShowFilteringRow = false;
            this.radGridViewReports.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridViewReports.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridViewReports.Name = "radGridViewReports";
            this.radGridViewReports.ShowGroupPanel = false;
            this.radGridViewReports.ShowGroupPanelScrollbars = false;
            this.radGridViewReports.Size = new System.Drawing.Size(986, 106);
            this.radGridViewReports.TabIndex = 2;
            this.radGridViewReports.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridViewReports_CellFormatting);
            this.radGridViewReports.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGridViewReports_CommandCellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel2.Controls.Add(this.radLabelReports, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 287);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(986, 28);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // radLabelReports
            // 
            this.radLabelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelReports.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabelReports.Location = new System.Drawing.Point(3, 3);
            this.radLabelReports.Name = "radLabelReports";
            this.radLabelReports.Size = new System.Drawing.Size(70, 22);
            this.radLabelReports.TabIndex = 0;
            this.radLabelReports.Text = "Звіти";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel3.Controls.Add(this.radLabel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(986, 28);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(3, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(70, 22);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Договори";
            // 
            // UcDdexReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcDdexReports";
            this.Size = new System.Drawing.Size(992, 430);
            ((System.ComponentModel.ISupportInitialize)(this.radGridAgreements.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridAgreements)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewReports.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewReports)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelReports)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridAgreements;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadGridView radGridViewReports;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabelReports;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
