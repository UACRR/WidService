namespace IpsViewComponentLibrary
{
    partial class ReportExcelViewForm
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportExcelViewForm));
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.btn = new Telerik.WinControls.UI.RadButton();
            this.gvReportContentView = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bindingRegItems = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRegItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(868, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Звіт HJH768_ds_vv";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.ThemeName = "Office2013Light";
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn.Location = new System.Drawing.Point(12, 393);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(110, 24);
            this.btn.TabIndex = 1;
            this.btn.Text = "Закрити";
            this.btn.ThemeName = "Office2007Silver";
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // gvReportContentView
            // 
            this.gvReportContentView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvReportContentView.AutoSizeRows = true;
            this.gvReportContentView.Location = new System.Drawing.Point(12, 55);
            // 
            // 
            // 
            this.gvReportContentView.MasterTemplate.AllowAddNewRow = false;
            this.gvReportContentView.MasterTemplate.AllowDeleteRow = false;
            this.gvReportContentView.MasterTemplate.AllowDragToGroup = false;
            this.gvReportContentView.MasterTemplate.AllowEditRow = false;
            this.gvReportContentView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "IdReport";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Multiline = true;
            gridViewTextBoxColumn1.Name = "IdReport";
            gridViewTextBoxColumn2.FieldName = "ItemName";
            gridViewTextBoxColumn2.HeaderText = "Назва твору";
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "ItemName";
            gridViewTextBoxColumn2.Width = 163;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Performer";
            gridViewTextBoxColumn3.HeaderText = "Виконавець";
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "Performer";
            gridViewTextBoxColumn3.Width = 149;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "AuthorMusic";
            gridViewTextBoxColumn4.HeaderText = "Автор музики";
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "AuthorMusic";
            gridViewTextBoxColumn4.Width = 112;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "AuthorText";
            gridViewTextBoxColumn5.HeaderText = "Автор тексту";
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "AuthorText";
            gridViewTextBoxColumn5.Width = 89;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewDateTimeColumn1.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewDateTimeColumn1.FieldName = "DurationItem";
            gridViewDateTimeColumn1.HeaderText = "Тривалість звучання твору";
            gridViewDateTimeColumn1.MaxWidth = 95;
            gridViewDateTimeColumn1.MinWidth = 95;
            gridViewDateTimeColumn1.Name = "DurationItem";
            gridViewDateTimeColumn1.Width = 95;
            gridViewDateTimeColumn1.WrapText = true;
            gridViewTextBoxColumn6.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn6.FieldName = "CountUse";
            gridViewTextBoxColumn6.HeaderText = "Кількість публічних сповіщень твору";
            gridViewTextBoxColumn6.MaxWidth = 120;
            gridViewTextBoxColumn6.MinWidth = 120;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "CountUse";
            gridViewTextBoxColumn6.Width = 120;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewDateTimeColumn2.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewDateTimeColumn2.FieldName = "DurationUse";
            gridViewDateTimeColumn2.HeaderText = "Загальна тривалість звучання твору";
            gridViewDateTimeColumn2.MaxWidth = 120;
            gridViewDateTimeColumn2.MinWidth = 120;
            gridViewDateTimeColumn2.Name = "DurationUse";
            gridViewDateTimeColumn2.Width = 120;
            gridViewDateTimeColumn2.WrapText = true;
            this.gvReportContentView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn6,
            gridViewDateTimeColumn2});
            this.gvReportContentView.MasterTemplate.DataSource = this.bindingRegItems;
            this.gvReportContentView.MasterTemplate.EnableGrouping = false;
            this.gvReportContentView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvReportContentView.Name = "gvReportContentView";
            this.gvReportContentView.ReadOnly = true;
            this.gvReportContentView.Size = new System.Drawing.Size(868, 332);
            this.gvReportContentView.TabIndex = 2;
            this.gvReportContentView.ThemeName = "Office2013Light";
            // 
            // bindingRegItems
            // 
            this.bindingRegItems.DataSource = typeof(ipsFormsDesign.Model.RegisterItem);
            // 
            // ReportExcelViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 430);
            this.Controls.Add(this.gvReportContentView);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 460);
            this.Name = "ReportExcelViewForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = " Перегляд звіту";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportContentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRegItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private Telerik.WinControls.UI.RadButton btn;
        private Telerik.WinControls.UI.RadGridView gvReportContentView;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bindingRegItems;
    }
}
