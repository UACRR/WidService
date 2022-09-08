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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
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
            gridViewTextBoxColumn9.FieldName = "Id";
            gridViewTextBoxColumn9.HeaderText = "Id";
            gridViewTextBoxColumn9.Name = "Id";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            gridViewTextBoxColumn9.Width = 95;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "ResourceTitle";
            gridViewTextBoxColumn10.HeaderText = "Назва запису";
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "ResourceTitle";
            gridViewTextBoxColumn10.Width = 235;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "Title";
            gridViewTextBoxColumn11.HeaderText = "Назва твору";
            gridViewTextBoxColumn11.Multiline = true;
            gridViewTextBoxColumn11.Name = "Title";
            gridViewTextBoxColumn11.Width = 235;
            gridViewTextBoxColumn11.WrapText = true;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Authors";
            gridViewTextBoxColumn12.HeaderText = "Автор(и)";
            gridViewTextBoxColumn12.Multiline = true;
            gridViewTextBoxColumn12.Name = "Authors";
            gridViewTextBoxColumn12.Width = 235;
            gridViewTextBoxColumn12.WrapText = true;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "Performers";
            gridViewTextBoxColumn13.HeaderText = "Виконавець";
            gridViewTextBoxColumn13.Multiline = true;
            gridViewTextBoxColumn13.Name = "Performers";
            gridViewTextBoxColumn13.Width = 184;
            gridViewTextBoxColumn13.WrapText = true;
            gridViewTextBoxColumn14.AllowResize = false;
            gridViewTextBoxColumn14.FieldName = "ISWC";
            gridViewTextBoxColumn14.HeaderText = "ISWC";
            gridViewTextBoxColumn14.Name = "ISWC";
            gridViewTextBoxColumn14.Width = 84;
            gridViewTextBoxColumn15.AllowResize = false;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "netrevenue";
            gridViewTextBoxColumn15.FormatString = "{0:### ### ### ##0.00}";
            gridViewTextBoxColumn15.HeaderText = "Прибуток";
            gridViewTextBoxColumn15.Name = "netrevenue";
            gridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn15.Width = 80;
            gridViewTextBoxColumn15.WrapText = true;
            gridViewTextBoxColumn16.AllowResize = false;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "Wic";
            gridViewTextBoxColumn16.HeaderText = "Wic";
            gridViewTextBoxColumn16.Name = "Wic";
            gridViewTextBoxColumn16.Width = 73;
            gridViewTextBoxColumn16.WrapText = true;
            gridViewComboBoxColumn2.AllowResize = false;
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.FieldName = "ObjId";
            gridViewComboBoxColumn2.HeaderText = "ObjId";
            gridViewComboBoxColumn2.Name = "ObjId";
            gridViewComboBoxColumn2.Width = 54;
            gridViewComboBoxColumn2.WrapText = true;
            gridViewImageColumn2.AllowResize = false;
            gridViewImageColumn2.HeaderText = "Статус";
            gridViewImageColumn2.Name = "Status";
            gridViewImageColumn2.Width = 51;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.FieldName = "Reject";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Name = "Reject";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 70;
            gridViewCommandColumn4.AllowResize = false;
            gridViewCommandColumn4.FieldName = "Postpone";
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Name = "Postpone";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.Width = 70;
            this.radGridSales.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewComboBoxColumn2,
            gridViewImageColumn2,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.radGridSales.MasterTemplate.EnableSorting = false;
            this.radGridSales.MasterTemplate.ViewDefinition = tableViewDefinition2;
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
            this.panelTop.ColumnCount = 2;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 847F));
            this.panelTop.Controls.Add(this.panelFilter, 0, 0);
            this.panelTop.Controls.Add(this.btnApplyFilter, 1, 0);
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
            this.panelFilter.Size = new System.Drawing.Size(542, 28);
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
            this.btnApplyFilter.Location = new System.Drawing.Point(551, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(89, 28);
            this.btnApplyFilter.TabIndex = 7;
            this.btnApplyFilter.Text = "Завантажити";
            this.btnApplyFilter.Visible = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
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
    }
}
