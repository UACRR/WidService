namespace IpsViewComponentLibrary.RegisterControls
{
    partial class RegisterItemListControl
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn9 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn10 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn5 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn6 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn7 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn8 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterItemListControl));
            Telerik.WinControls.UI.ColumnGroupsViewDefinition columnGroupsViewDefinition2 = new Telerik.WinControls.UI.ColumnGroupsViewDefinition();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup4 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow4 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup5 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow5 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup6 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow6 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            this.ddlLinkedStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.gvRegisterItemList = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.registerItemViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlLinkedStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterItemList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerItemViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlLinkedStatus
            // 
            this.ddlLinkedStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem4.Text = "Всі";
            radListDataItem5.Text = "Знайдені";
            radListDataItem6.Text = "Не знайдені";
            this.ddlLinkedStatus.Items.Add(radListDataItem4);
            this.ddlLinkedStatus.Items.Add(radListDataItem5);
            this.ddlLinkedStatus.Items.Add(radListDataItem6);
            this.ddlLinkedStatus.Location = new System.Drawing.Point(81, 3);
            this.ddlLinkedStatus.Name = "ddlLinkedStatus";
            this.ddlLinkedStatus.Size = new System.Drawing.Size(189, 21);
            this.ddlLinkedStatus.TabIndex = 35;
            this.ddlLinkedStatus.ThemeName = "Office2013Light";
            this.ddlLinkedStatus.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlLinkedStatus_SelectedIndexChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 3);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(72, 19);
            this.radLabel3.TabIndex = 34;
            this.radLabel3.Text = "Показувати";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // gvRegisterItemList
            // 
            this.gvRegisterItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRegisterItemList.BackColor = System.Drawing.SystemColors.Control;
            this.gvRegisterItemList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvRegisterItemList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvRegisterItemList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gvRegisterItemList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvRegisterItemList.Location = new System.Drawing.Point(3, 30);
            // 
            // 
            // 
            this.gvRegisterItemList.MasterTemplate.AllowAddNewRow = false;
            this.gvRegisterItemList.MasterTemplate.AllowDeleteRow = false;
            this.gvRegisterItemList.MasterTemplate.AllowEditRow = false;
            this.gvRegisterItemList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn2.AllowResize = false;
            gridViewCheckBoxColumn2.DataType = typeof(System.Nullable<int>);
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "ObjId";
            gridViewCheckBoxColumn2.HeaderText = "Знайдений";
            gridViewCheckBoxColumn2.MaxWidth = 50;
            gridViewCheckBoxColumn2.MinWidth = 50;
            gridViewCheckBoxColumn2.Name = "Linked";
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "ItemName";
            gridViewTextBoxColumn11.HeaderText = "Назва твору";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "ItemName";
            gridViewTextBoxColumn11.Width = 46;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Performer";
            gridViewTextBoxColumn12.HeaderText = "Виконавець";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "Performer";
            gridViewTextBoxColumn12.Width = 46;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "AuthorMusic";
            gridViewTextBoxColumn13.HeaderText = "Автор музики";
            gridViewTextBoxColumn13.IsAutoGenerated = true;
            gridViewTextBoxColumn13.Name = "AuthorMusic";
            gridViewTextBoxColumn13.Width = 46;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "AuthorText";
            gridViewTextBoxColumn14.HeaderText = "Автор тексту";
            gridViewTextBoxColumn14.IsAutoGenerated = true;
            gridViewTextBoxColumn14.Name = "AuthorText";
            gridViewTextBoxColumn14.Width = 46;
            gridViewDecimalColumn6.AllowResize = false;
            gridViewDecimalColumn6.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn6.EnableExpressionEditor = false;
            gridViewDecimalColumn6.FieldName = "CategoryCode";
            gridViewDecimalColumn6.HeaderText = "Категорія";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.IsVisible = false;
            gridViewDecimalColumn6.Name = "CategoryCode";
            gridViewDecimalColumn6.Width = 35;
            gridViewTextBoxColumn15.AllowResize = false;
            gridViewTextBoxColumn15.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "DurationItem";
            gridViewTextBoxColumn15.HeaderText = "Тривалість звучання";
            gridViewTextBoxColumn15.IsAutoGenerated = true;
            gridViewTextBoxColumn15.Name = "DurationItem";
            gridViewTextBoxColumn15.Width = 16;
            gridViewDecimalColumn7.AllowResize = false;
            gridViewDecimalColumn7.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn7.EnableExpressionEditor = false;
            gridViewDecimalColumn7.FieldName = "CountUse";
            gridViewDecimalColumn7.HeaderText = "К-ть сповіщень";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.Name = "CountUse";
            gridViewDecimalColumn7.Width = 7;
            gridViewTextBoxColumn16.AllowResize = false;
            gridViewTextBoxColumn16.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "DurationUse";
            gridViewTextBoxColumn16.HeaderText = "Тривалість використання";
            gridViewTextBoxColumn16.IsAutoGenerated = true;
            gridViewTextBoxColumn16.Name = "DurationUse";
            gridViewTextBoxColumn16.Width = 15;
            gridViewDecimalColumn8.DataType = typeof(int);
            gridViewDecimalColumn8.EnableExpressionEditor = false;
            gridViewDecimalColumn8.FieldName = "RegId";
            gridViewDecimalColumn8.HeaderText = "RegId";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.IsVisible = false;
            gridViewDecimalColumn8.Name = "RegId";
            gridViewDecimalColumn8.Width = 36;
            gridViewDecimalColumn9.DataType = typeof(int);
            gridViewDecimalColumn9.EnableExpressionEditor = false;
            gridViewDecimalColumn9.FieldName = "RegIitemId";
            gridViewDecimalColumn9.HeaderText = "RegIitemId";
            gridViewDecimalColumn9.IsAutoGenerated = true;
            gridViewDecimalColumn9.IsVisible = false;
            gridViewDecimalColumn9.Name = "RegIitemId";
            gridViewDecimalColumn9.Width = 38;
            gridViewDecimalColumn10.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn10.EnableExpressionEditor = false;
            gridViewDecimalColumn10.FieldName = "ObjId";
            gridViewDecimalColumn10.HeaderText = "ObjId";
            gridViewDecimalColumn10.IsAutoGenerated = true;
            gridViewDecimalColumn10.IsVisible = false;
            gridViewDecimalColumn10.Name = "ObjId";
            gridViewDecimalColumn10.Width = 40;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "ObjectName";
            gridViewTextBoxColumn17.HeaderText = "Назва твору";
            gridViewTextBoxColumn17.Name = "ObjectName";
            gridViewTextBoxColumn17.Width = 30;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.FieldName = "ObjectAuthors";
            gridViewTextBoxColumn18.HeaderText = "Автори";
            gridViewTextBoxColumn18.Name = "ObjectAuthors";
            gridViewTextBoxColumn18.Width = 38;
            gridViewTextBoxColumn19.EnableExpressionEditor = false;
            gridViewTextBoxColumn19.FieldName = "ObjectPerformers";
            gridViewTextBoxColumn19.HeaderText = "Виконавці";
            gridViewTextBoxColumn19.Name = "ObjectPerformers";
            gridViewTextBoxColumn19.Width = 38;
            gridViewTextBoxColumn20.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn20.EnableExpressionEditor = false;
            gridViewTextBoxColumn20.FieldName = "ObjectDuration";
            gridViewTextBoxColumn20.HeaderText = "Тривалість виконання";
            gridViewTextBoxColumn20.Name = "ObjectDuration";
            gridViewTextBoxColumn20.Width = 38;
            gridViewCommandColumn5.AllowResize = false;
            gridViewCommandColumn5.DefaultText = "Об\'єкт";
            gridViewCommandColumn5.EnableExpressionEditor = false;
            gridViewCommandColumn5.MaxWidth = 80;
            gridViewCommandColumn5.MinWidth = 80;
            gridViewCommandColumn5.Name = "ShowObjectColumn";
            gridViewCommandColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn5.UseDefaultText = true;
            gridViewCommandColumn5.Width = 80;
            gridViewCommandColumn6.AllowResize = false;
            gridViewCommandColumn6.DefaultText = "Прив\'язати";
            gridViewCommandColumn6.EnableExpressionEditor = false;
            gridViewCommandColumn6.MaxWidth = 80;
            gridViewCommandColumn6.MinWidth = 80;
            gridViewCommandColumn6.Name = "LinkColumn";
            gridViewCommandColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn6.UseDefaultText = true;
            gridViewCommandColumn6.Width = 80;
            gridViewCommandColumn7.AllowResize = false;
            gridViewCommandColumn7.DefaultText = "Шукати";
            gridViewCommandColumn7.EnableExpressionEditor = false;
            gridViewCommandColumn7.MaxWidth = 80;
            gridViewCommandColumn7.MinWidth = 80;
            gridViewCommandColumn7.Name = "FindColumn";
            gridViewCommandColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn7.UseDefaultText = true;
            gridViewCommandColumn7.Width = 80;
            gridViewCommandColumn8.EnableExpressionEditor = false;
            gridViewCommandColumn8.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn8.Image")));
            gridViewCommandColumn8.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            gridViewCommandColumn8.MaxWidth = 30;
            gridViewCommandColumn8.MinWidth = 30;
            gridViewCommandColumn8.Name = "CreateObjectColumn";
            gridViewCommandColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn8.Width = 30;
            this.gvRegisterItemList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewDecimalColumn6,
            gridViewTextBoxColumn15,
            gridViewDecimalColumn7,
            gridViewTextBoxColumn16,
            gridViewDecimalColumn8,
            gridViewDecimalColumn9,
            gridViewDecimalColumn10,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewCommandColumn5,
            gridViewCommandColumn6,
            gridViewCommandColumn7,
            gridViewCommandColumn8});
            this.gvRegisterItemList.MasterTemplate.DataSource = this.registerItemViewModelBindingSource;
            this.gvRegisterItemList.MasterTemplate.EnableFiltering = true;
            this.gvRegisterItemList.MasterTemplate.ShowFilteringRow = false;
            this.gvRegisterItemList.MasterTemplate.ShowRowHeaderColumn = false;
            gridViewColumnGroup4.Name = "registerGroup";
            gridViewColumnGroupRow4.ColumnNames.Add("Linked");
            gridViewColumnGroupRow4.ColumnNames.Add("ItemName");
            gridViewColumnGroupRow4.ColumnNames.Add("Performer");
            gridViewColumnGroupRow4.ColumnNames.Add("AuthorMusic");
            gridViewColumnGroupRow4.ColumnNames.Add("AuthorText");
            gridViewColumnGroupRow4.ColumnNames.Add("CategoryCode");
            gridViewColumnGroupRow4.ColumnNames.Add("DurationItem");
            gridViewColumnGroupRow4.ColumnNames.Add("CountUse");
            gridViewColumnGroupRow4.ColumnNames.Add("DurationUse");
            gridViewColumnGroupRow4.ColumnNames.Add("RegId");
            gridViewColumnGroupRow4.ColumnNames.Add("RegIitemId");
            gridViewColumnGroupRow4.ColumnNames.Add("ObjId");
            gridViewColumnGroupRow4.ColumnNames.Add("ModifyDate");
            gridViewColumnGroupRow4.ColumnNames.Add("ModifyLogin");
            gridViewColumnGroupRow4.MinHeight = 25;
            gridViewColumnGroup4.Rows.Add(gridViewColumnGroupRow4);
            gridViewColumnGroup4.RowSpan = 25;
            gridViewColumnGroup4.Text = "Дані відомості";
            gridViewColumnGroup5.Name = "objectGroup";
            gridViewColumnGroupRow5.ColumnNames.Add("ObjectName");
            gridViewColumnGroupRow5.ColumnNames.Add("ObjectAuthors");
            gridViewColumnGroupRow5.ColumnNames.Add("ObjectPerformers");
            gridViewColumnGroupRow5.ColumnNames.Add("ObjectDuration");
            gridViewColumnGroup5.Rows.Add(gridViewColumnGroupRow5);
            gridViewColumnGroup5.Text = "Привязаний об\'єкт";
            gridViewColumnGroup6.Name = "commandGroup";
            gridViewColumnGroupRow6.ColumnNames.Add("CreateObjectColumn");
            gridViewColumnGroupRow6.ColumnNames.Add("ShowObjectColumn");
            gridViewColumnGroupRow6.ColumnNames.Add("LinkColumn");
            gridViewColumnGroupRow6.ColumnNames.Add("FindColumn");
            gridViewColumnGroup6.Rows.Add(gridViewColumnGroupRow6);
            gridViewColumnGroup6.Text = "";
            columnGroupsViewDefinition2.ColumnGroups.Add(gridViewColumnGroup4);
            columnGroupsViewDefinition2.ColumnGroups.Add(gridViewColumnGroup5);
            columnGroupsViewDefinition2.ColumnGroups.Add(gridViewColumnGroup6);
            this.gvRegisterItemList.MasterTemplate.ViewDefinition = columnGroupsViewDefinition2;
            this.gvRegisterItemList.Name = "gvRegisterItemList";
            this.gvRegisterItemList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvRegisterItemList.ShowGroupPanel = false;
            this.gvRegisterItemList.Size = new System.Drawing.Size(693, 317);
            this.gvRegisterItemList.TabIndex = 36;
            this.gvRegisterItemList.ThemeName = "Office2013Light";
            this.gvRegisterItemList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRegisterItemList_CommandCellClick);
            this.gvRegisterItemList.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvRegisterItemList_ToolTipTextNeeded);
            // 
            // registerItemViewModelBindingSource
            // 
            this.registerItemViewModelBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterItemViewModel);
            // 
            // RegisterItemListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvRegisterItemList);
            this.Controls.Add(this.ddlLinkedStatus);
            this.Controls.Add(this.radLabel3);
            this.Name = "RegisterItemListControl";
            this.Size = new System.Drawing.Size(700, 350);
            ((System.ComponentModel.ISupportInitialize)(this.ddlLinkedStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterItemList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerItemViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlLinkedStatus;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView gvRegisterItemList;
        private System.Windows.Forms.BindingSource registerItemViewModelBindingSource;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
    }
}
