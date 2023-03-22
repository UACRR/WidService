using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.Reports.Forms
{
    partial class ReportExcelForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTimeSpanColumn gridViewTimeSpanColumn1 = new Telerik.WinControls.UI.GridViewTimeSpanColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTimeSpanColumn gridViewTimeSpanColumn2 = new Telerik.WinControls.UI.GridViewTimeSpanColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportExcelForm));
            this.btn = new Telerik.WinControls.UI.RadButton();
            this.gvReportContentView = new Telerik.WinControls.UI.RadGridView();
            this.bindingRegItems = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnAddRow = new Telerik.WinControls.UI.RadButton();
            this.txtReportPeriod = new Telerik.WinControls.UI.RadTextBoxControl();
            this.bsRegisterName = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlGridRowCount = new IPSComponentLibrary.Common.GridRowCountControl();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRegItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn.Location = new System.Drawing.Point(12, 411);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(110, 24);
            this.btn.TabIndex = 1;
            this.btn.Text = "Закрити";
            this.btn.ThemeName = "Office2013Light";
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // gvReportContentView
            // 
            this.gvReportContentView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvReportContentView.AutoScroll = true;
            this.gvReportContentView.AutoSizeRows = true;
            this.gvReportContentView.Location = new System.Drawing.Point(12, 42);
            // 
            // 
            // 
            this.gvReportContentView.MasterTemplate.AllowAddNewRow = false;
            this.gvReportContentView.MasterTemplate.AllowDeleteRow = false;
            this.gvReportContentView.MasterTemplate.AllowDragToGroup = false;
            this.gvReportContentView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "IdReport";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Multiline = true;
            gridViewTextBoxColumn1.Name = "IdReport";
            gridViewTextBoxColumn2.FieldName = "ItemName";
            gridViewTextBoxColumn2.HeaderText = "Назва твору";
            gridViewTextBoxColumn2.MinWidth = 165;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "ItemName";
            gridViewTextBoxColumn2.Width = 197;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Performer";
            gridViewTextBoxColumn3.HeaderText = "Виконавець";
            gridViewTextBoxColumn3.MinWidth = 165;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "Performer";
            gridViewTextBoxColumn3.Width = 177;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "AuthorMusic";
            gridViewTextBoxColumn4.HeaderText = "Автор музики";
            gridViewTextBoxColumn4.MinWidth = 165;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "AuthorMusic";
            gridViewTextBoxColumn4.Width = 177;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "AuthorText";
            gridViewTextBoxColumn5.HeaderText = "Автор тексту";
            gridViewTextBoxColumn5.MinWidth = 165;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "AuthorText";
            gridViewTextBoxColumn5.Width = 195;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTimeSpanColumn1.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTimeSpanColumn1.FieldName = "DurationItem";
            gridViewTimeSpanColumn1.Format = "hh:mm:ss";
            gridViewTimeSpanColumn1.FormatString = "hh:mm:ss";
            gridViewTimeSpanColumn1.HeaderText = "Тривалість звучання твору";
            gridViewTimeSpanColumn1.MaxWidth = 95;
            gridViewTimeSpanColumn1.Minimum = System.TimeSpan.Parse("00:00:01");
            gridViewTimeSpanColumn1.MinWidth = 95;
            gridViewTimeSpanColumn1.Name = "DurationItem";
            gridViewTimeSpanColumn1.Width = 95;
            gridViewTimeSpanColumn1.WrapText = true;
            gridViewDecimalColumn1.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn1.DecimalPlaces = 0;
            gridViewDecimalColumn1.FieldName = "CountUse";
            gridViewDecimalColumn1.HeaderText = "Кількість публічних сповіщень твору";
            gridViewDecimalColumn1.MaxWidth = 80;
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            gridViewDecimalColumn1.MinWidth = 80;
            gridViewDecimalColumn1.Name = "CountUse";
            gridViewDecimalColumn1.Width = 80;
            gridViewDecimalColumn1.WrapText = true;
            gridViewTimeSpanColumn2.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTimeSpanColumn2.FieldName = "DurationUse";
            gridViewTimeSpanColumn2.Format = "hh:mm:ss";
            gridViewTimeSpanColumn2.FormatString = "d.hh:mm:ss";
            gridViewTimeSpanColumn2.HeaderText = "Загальна тривалість звучання твору";
            gridViewTimeSpanColumn2.MaxWidth = 95;
            gridViewTimeSpanColumn2.Minimum = System.TimeSpan.Parse("00:00:01");
            gridViewTimeSpanColumn2.MinWidth = 120;
            gridViewTimeSpanColumn2.Name = "DurationUse";
            gridViewTimeSpanColumn2.ReadOnly = true;
            gridViewTimeSpanColumn2.Width = 95;
            gridViewTimeSpanColumn2.WrapText = true;
            gridViewCommandColumn1.FieldName = "Delete";
            gridViewCommandColumn1.HeaderImage = global::IPSComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IPSComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.IsVisible = false;
            gridViewCommandColumn1.MaxWidth = 25;
            gridViewCommandColumn1.MinWidth = 25;
            gridViewCommandColumn1.Name = "Delete";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 25;
            this.gvReportContentView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTimeSpanColumn1,
            gridViewDecimalColumn1,
            gridViewTimeSpanColumn2,
            gridViewCommandColumn1});
            this.gvReportContentView.MasterTemplate.DataSource = this.bindingRegItems;
            this.gvReportContentView.MasterTemplate.EnableGrouping = false;
            this.gvReportContentView.MasterTemplate.ShowFilteringRow = false;
            this.gvReportContentView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvReportContentView.Name = "gvReportContentView";
            this.gvReportContentView.ShowGroupPanel = false;
            this.gvReportContentView.Size = new System.Drawing.Size(1038, 364);
            this.gvReportContentView.TabIndex = 2;
            this.gvReportContentView.ThemeName = "Office2013Light";
            this.gvReportContentView.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvReportContentView_CellValueChanged);
            this.gvReportContentView.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvReportContentView_CommandCellClick);
            // 
            // bindingRegItems
            // 
            this.bindingRegItems.DataSource = typeof(ipsFormsDesign.Model.RegisterItem);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRow.Location = new System.Drawing.Point(138, 411);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(110, 24);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "Додати твір";
            this.btnAddRow.ThemeName = "Office2013Light";
            this.btnAddRow.Visible = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // txtReportPeriod
            // 
            this.txtReportPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportPeriod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRegisterName, "FileName", true));
            this.txtReportPeriod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtReportPeriod.Location = new System.Drawing.Point(12, 12);
            this.txtReportPeriod.Name = "txtReportPeriod";
            this.txtReportPeriod.NullText = "(найменування звіту)";
            // 
            // 
            // 
            this.txtReportPeriod.RootElement.PositionOffset = new System.Drawing.SizeF(0F, 0F);
            this.txtReportPeriod.Size = new System.Drawing.Size(1038, 24);
            this.txtReportPeriod.TabIndex = 4;
            this.txtReportPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReportPeriod.ThemeName = "Office2013Light";
            this.txtReportPeriod.WordWrap = false;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtReportPeriod.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtReportPeriod.GetChildAt(0).GetChildAt(0))).BorderRightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtReportPeriod.GetChildAt(0).GetChildAt(1))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsRegisterName
            // 
            this.bsRegisterName.DataSource = typeof(ipsFormsDesign.Model.Register);
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(895, 412);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 5;
            // 
            // ReportExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1062, 448);
            this.Controls.Add(this.ctrlGridRowCount);
            this.Controls.Add(this.txtReportPeriod);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.gvReportContentView);
            this.Controls.Add(this.btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 460);
            this.Name = "ReportExcelForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Перегляд звіту";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRegItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton btn;
        private Telerik.WinControls.UI.RadGridView gvReportContentView;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bindingRegItems;
        private Telerik.WinControls.UI.RadButton btnAddRow;
        private Telerik.WinControls.UI.RadTextBoxControl txtReportPeriod;
        private BindingSource bsRegisterName;
        private IPSComponentLibrary.Common.GridRowCountControl ctrlGridRowCount;
    }
}
