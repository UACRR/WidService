namespace DdexInvoicing
{
    partial class UcExceptionSets
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGrid = new Telerik.WinControls.UI.RadGridView();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radBtnNewExc = new Telerik.WinControls.UI.RadButton();
            this.radBtnImportExc = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid.MasterTemplate)).BeginInit();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnNewExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnImportExc)).BeginInit();
            this.SuspendLayout();
            // 
            // radGrid
            // 
            this.radGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGrid.EnableHotTracking = false;
            this.radGrid.Location = new System.Drawing.Point(3, 38);
            // 
            // 
            // 
            this.radGrid.MasterTemplate.AllowAddNewRow = false;
            this.radGrid.MasterTemplate.AllowColumnReorder = false;
            this.radGrid.MasterTemplate.AllowDeleteRow = false;
            this.radGrid.MasterTemplate.AllowEditRow = false;
            this.radGrid.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn1.Expression = "";
            gridViewTextBoxColumn1.FieldName = "setCode";
            gridViewTextBoxColumn1.HeaderText = "Номер";
            gridViewTextBoxColumn1.Name = "setCode";
            gridViewTextBoxColumn1.Width = 60;
            gridViewTextBoxColumn2.FieldName = "setName";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Name = "setName";
            gridViewTextBoxColumn2.Width = 250;
            gridViewTextBoxColumn3.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn3.FieldName = "dateCreated";
            gridViewTextBoxColumn3.FormatString = "{0:yyyy-MM-dd hh:mm:ss}";
            gridViewTextBoxColumn3.HeaderText = "Дата створення";
            gridViewTextBoxColumn3.Name = "dateCreated";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn4.FieldName = "dateUpdated";
            gridViewTextBoxColumn4.FormatString = "{0:yyyy-MM-dd hh:mm:ss}";
            gridViewTextBoxColumn4.HeaderText = "Дата зміни";
            gridViewTextBoxColumn4.Name = "dateUpdated";
            gridViewTextBoxColumn4.Width = 120;
            gridViewTextBoxColumn5.FieldName = "setStatus";
            gridViewTextBoxColumn5.HeaderText = "Статус";
            gridViewTextBoxColumn5.Name = "setStatus";
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn6.FieldName = "isUsed";
            gridViewTextBoxColumn6.HeaderText = "Застосований";
            gridViewTextBoxColumn6.Name = "isUsed";
            gridViewTextBoxColumn6.Width = 80;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.FieldName = "Show";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "Show";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 70;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.FieldName = "Delete";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "Delete";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 70;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.Expression = "";
            gridViewCommandColumn3.FieldName = "Clone";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Name = "Clone";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 100;
            gridViewCommandColumn4.FieldName = "Export";
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Name = "Export";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.Width = 86;
            this.radGrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.radGrid.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGrid.MasterTemplate.EnableSorting = false;
            this.radGrid.MasterTemplate.ShowFilteringRow = false;
            this.radGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGrid.Name = "radGrid";
            this.radGrid.ShowGroupPanel = false;
            this.radGrid.ShowGroupPanelScrollbars = false;
            this.radGrid.Size = new System.Drawing.Size(1154, 517);
            this.radGrid.TabIndex = 3;
            this.radGrid.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.radGrid_CommandCellClick);
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.panelMain.Controls.Add(this.radGrid, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(1160, 566);
            this.panelMain.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radBtnNewExc, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.radBtnImportExc, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1154, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(218, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Перелік наяних конфігурацій виключень";
            // 
            // radBtnNewExc
            // 
            this.radBtnNewExc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radBtnNewExc.Location = new System.Drawing.Point(812, 3);
            this.radBtnNewExc.Name = "radBtnNewExc";
            this.radBtnNewExc.Size = new System.Drawing.Size(165, 23);
            this.radBtnNewExc.TabIndex = 1;
            this.radBtnNewExc.Text = "Створити нову конфігурацію";
            this.radBtnNewExc.Click += new System.EventHandler(this.radBtnNewExc_Click);
            // 
            // radBtnImportExc
            // 
            this.radBtnImportExc.Location = new System.Drawing.Point(983, 3);
            this.radBtnImportExc.Name = "radBtnImportExc";
            this.radBtnImportExc.Size = new System.Drawing.Size(153, 23);
            this.radBtnImportExc.TabIndex = 2;
            this.radBtnImportExc.Text = "Імпортувати конфігурацію";
            this.radBtnImportExc.Click += new System.EventHandler(this.radBtnImportExc_Click);
            // 
            // UcExceptionSets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panelMain);
            this.Name = "UcExceptionSets";
            this.Size = new System.Drawing.Size(1160, 566);
            ((System.ComponentModel.ISupportInitialize)(this.radGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGrid)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnNewExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnImportExc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGrid;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radBtnNewExc;
        private Telerik.WinControls.UI.RadButton radBtnImportExc;
    }
}
