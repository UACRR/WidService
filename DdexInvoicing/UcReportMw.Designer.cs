namespace DdexInvoicing
{
    partial class UcReportMw
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcReportMw));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.radGridSales = new Telerik.WinControls.UI.RadGridView();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ddbBlock = new Telerik.WinControls.UI.RadDropDownButton();
            this.label2 = new System.Windows.Forms.Label();
            this.ddbStatus = new Telerik.WinControls.UI.RadDropDownButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ddbSort = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnApplyFilter = new Telerik.WinControls.UI.RadButton();
            this.radBtnAutoSearch = new Telerik.WinControls.UI.RadButton();
            this.ilExpandCollapse = new System.Windows.Forms.ImageList(this.components);
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridSales.MasterTemplate)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddbBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApplyFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAutoSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.radGridSales, 0, 1);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(1482, 514);
            this.panelMain.TabIndex = 2;
            // 
            // radGridSales
            // 
            this.radGridSales.AutoSizeRows = true;
            this.radGridSales.BackColor = System.Drawing.SystemColors.Control;
            this.radGridSales.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridSales.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridSales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridSales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridSales.Location = new System.Drawing.Point(3, 43);
            // 
            // 
            // 
            this.radGridSales.MasterTemplate.AllowAddNewRow = false;
            this.radGridSales.MasterTemplate.AllowColumnReorder = false;
            this.radGridSales.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            gridViewTextBoxColumn1.Width = 95;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ResourceTitle";
            gridViewTextBoxColumn2.HeaderText = "Назва запису";
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "ResourceTitle";
            gridViewTextBoxColumn2.Width = 235;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Title";
            gridViewTextBoxColumn3.HeaderText = "Назва твору";
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "Title";
            gridViewTextBoxColumn3.Width = 235;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Authors";
            gridViewTextBoxColumn4.HeaderText = "Автор(и)";
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "Authors";
            gridViewTextBoxColumn4.Width = 235;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Performers";
            gridViewTextBoxColumn5.HeaderText = "Виконавець";
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "Performers";
            gridViewTextBoxColumn5.Width = 184;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.AllowResize = false;
            gridViewTextBoxColumn6.FieldName = "ISWC";
            gridViewTextBoxColumn6.HeaderText = "ISWC";
            gridViewTextBoxColumn6.Name = "ISWC";
            gridViewTextBoxColumn6.Width = 84;
            gridViewTextBoxColumn7.AllowResize = false;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "netrevenue";
            gridViewTextBoxColumn7.FormatString = "{0:### ### ### ##0.00}";
            gridViewTextBoxColumn7.HeaderText = "Прибуток";
            gridViewTextBoxColumn7.Name = "netrevenue";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 80;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.AllowResize = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Wic";
            gridViewTextBoxColumn8.HeaderText = "Wic";
            gridViewTextBoxColumn8.Name = "Wic";
            gridViewTextBoxColumn8.Width = 73;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewComboBoxColumn1.AllowResize = false;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "ObjId";
            gridViewComboBoxColumn1.HeaderText = "ObjId";
            gridViewComboBoxColumn1.Name = "ObjId";
            gridViewComboBoxColumn1.Width = 54;
            gridViewComboBoxColumn1.WrapText = true;
            gridViewImageColumn1.AllowResize = false;
            gridViewImageColumn1.HeaderText = "Статус";
            gridViewImageColumn1.Name = "Status";
            gridViewImageColumn1.Width = 51;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.FieldName = "Reject";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "Reject";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 70;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.FieldName = "Postpone";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "Postpone";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 70;
            this.radGridSales.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewComboBoxColumn1,
            gridViewImageColumn1,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.radGridSales.MasterTemplate.EnableSorting = false;
            this.radGridSales.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridSales.Name = "radGridSales";
            this.radGridSales.ReadOnly = true;
            this.radGridSales.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridSales.ShowGroupPanel = false;
            this.radGridSales.Size = new System.Drawing.Size(1476, 460);
            this.radGridSales.TabIndex = 5;
            this.radGridSales.SelectionChanged += new System.EventHandler(this.radGridSales_SelectionChanged);
            this.radGridSales.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridSales_CellClick);
            // 
            // panelTop
            // 
            this.panelTop.AutoSize = true;
            this.panelTop.ColumnCount = 3;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 621F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 692F));
            this.panelTop.Controls.Add(this.panelFilter, 0, 0);
            this.panelTop.Controls.Add(this.btnApplyFilter, 1, 0);
            this.panelTop.Controls.Add(this.radBtnAutoSearch, 2, 0);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 1;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(1476, 34);
            this.panelTop.TabIndex = 7;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.ddbBlock);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.ddbStatus);
            this.panelFilter.Controls.Add(this.label3);
            this.panelFilter.Controls.Add(this.ddbSort);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(3, 3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(615, 28);
            this.panelFilter.TabIndex = 6;
            this.panelFilter.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Показати твори з блоку";
            // 
            // ddbBlock
            // 
            this.ddbBlock.AutoSize = true;
            this.ddbBlock.Location = new System.Drawing.Point(132, 3);
            this.ddbBlock.Name = "ddbBlock";
            this.ddbBlock.Size = new System.Drawing.Size(61, 20);
            this.ddbBlock.TabIndex = 1;
            this.ddbBlock.Text = "1 - 1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = ", включити";
            // 
            // ddbStatus
            // 
            this.ddbStatus.AutoSize = true;
            this.ddbStatus.Location = new System.Drawing.Point(260, 3);
            this.ddbStatus.Name = "ddbStatus";
            this.ddbStatus.Size = new System.Drawing.Size(37, 20);
            this.ddbStatus.TabIndex = 1;
            this.ddbStatus.Text = "всі ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "твори в порядку";
            // 
            // ddbSort
            // 
            this.ddbSort.AutoSize = true;
            this.ddbSort.Location = new System.Drawing.Point(392, 3);
            this.ddbSort.Name = "ddbSort";
            this.ddbSort.Size = new System.Drawing.Size(90, 20);
            this.ddbSort.TabIndex = 1;
            this.ddbSort.Text = "прибутковісті";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(624, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(89, 28);
            this.btnApplyFilter.TabIndex = 7;
            this.btnApplyFilter.Text = "Завантажити";
            this.btnApplyFilter.Visible = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // radBtnAutoSearch
            // 
            this.radBtnAutoSearch.Location = new System.Drawing.Point(726, 3);
            this.radBtnAutoSearch.Name = "radBtnAutoSearch";
            this.radBtnAutoSearch.Size = new System.Drawing.Size(136, 28);
            this.radBtnAutoSearch.TabIndex = 7;
            this.radBtnAutoSearch.Text = "Шукати автоматично";
            this.radBtnAutoSearch.Click += new System.EventHandler(this.radBtnAutoSearch_Click);
            // 
            // ilExpandCollapse
            // 
            this.ilExpandCollapse.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilExpandCollapse.ImageStream")));
            this.ilExpandCollapse.TransparentColor = System.Drawing.Color.Transparent;
            this.ilExpandCollapse.Images.SetKeyName(0, "1608603_caret_down_icon.png");
            this.ilExpandCollapse.Images.SetKeyName(1, "1608844_sort_up_icon.png");
            // 
            // ilStatuses
            // 
            this.ilStatuses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStatuses.ImageStream")));
            this.ilStatuses.TransparentColor = System.Drawing.Color.Transparent;
            this.ilStatuses.Images.SetKeyName(0, "red-x-line-icon.png");
            this.ilStatuses.Images.SetKeyName(1, "green-checkmark-line-icon.png");
            this.ilStatuses.Images.SetKeyName(2, "question-mark-round-line-icon.png");
            // 
            // UcReportMw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcReportMw";
            this.Size = new System.Drawing.Size(1482, 514);
            this.Load += new System.EventHandler(this.UcReportMw_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridSales.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridSales)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddbBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApplyFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAutoSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private Telerik.WinControls.UI.RadGridView radGridSales;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private Telerik.WinControls.UI.RadDropDownButton ddbBlock;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownButton ddbStatus;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadDropDownButton ddbSort;
        private Telerik.WinControls.UI.RadButton btnApplyFilter;
        private System.Windows.Forms.ImageList ilExpandCollapse;
        private System.Windows.Forms.ImageList ilStatuses;
        private Telerik.WinControls.UI.RadButton radBtnAutoSearch;
    }
}
