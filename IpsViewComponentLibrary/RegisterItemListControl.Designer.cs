namespace IpsViewComponentLibrary
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.ColumnGroupsViewDefinition columnGroupsViewDefinition1 = new Telerik.WinControls.UI.ColumnGroupsViewDefinition();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup1 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow1 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup2 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow2 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            Telerik.WinControls.UI.GridViewColumnGroup gridViewColumnGroup3 = new Telerik.WinControls.UI.GridViewColumnGroup();
            Telerik.WinControls.UI.GridViewColumnGroupRow gridViewColumnGroupRow3 = new Telerik.WinControls.UI.GridViewColumnGroupRow();
            this.ddlLinkedStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.gvRegisterItemList = new Telerik.WinControls.UI.RadGridView();
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
            radListDataItem1.Text = "Всі";
            radListDataItem2.Text = "Знайдені";
            radListDataItem3.Text = "Не знайдені";
            this.ddlLinkedStatus.Items.Add(radListDataItem1);
            this.ddlLinkedStatus.Items.Add(radListDataItem2);
            this.ddlLinkedStatus.Items.Add(radListDataItem3);
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
            gridViewCheckBoxColumn1.AllowResize = false;
            gridViewCheckBoxColumn1.DataType = typeof(System.Nullable<int>);
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "ObjId";
            gridViewCheckBoxColumn1.HeaderText = "Знайдений";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Linked";
            gridViewCheckBoxColumn1.Width = 58;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ItemName";
            gridViewTextBoxColumn1.HeaderText = "Назва твору";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "ItemName";
            gridViewTextBoxColumn1.Width = 52;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Performer";
            gridViewTextBoxColumn2.HeaderText = "Виконавець";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Performer";
            gridViewTextBoxColumn2.Width = 52;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "AuthorMusic";
            gridViewTextBoxColumn3.HeaderText = "Автор музики";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "AuthorMusic";
            gridViewTextBoxColumn3.Width = 55;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "AuthorText";
            gridViewTextBoxColumn4.HeaderText = "Автор тексту";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "AuthorText";
            gridViewTextBoxColumn4.Width = 52;
            gridViewDecimalColumn1.AllowResize = false;
            gridViewDecimalColumn1.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "CategoryCode";
            gridViewDecimalColumn1.HeaderText = "Категорія";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "CategoryCode";
            gridViewDecimalColumn1.Width = 35;
            gridViewTextBoxColumn5.AllowResize = false;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "DurationItem";
            gridViewTextBoxColumn5.HeaderText = "Тривалість звучання";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "DurationItem";
            gridViewTextBoxColumn5.Width = 38;
            gridViewDecimalColumn2.AllowResize = false;
            gridViewDecimalColumn2.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "CountUse";
            gridViewDecimalColumn2.HeaderText = "К-ть сповіщень";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "CountUse";
            gridViewDecimalColumn2.Width = 30;
            gridViewTextBoxColumn6.AllowResize = false;
            gridViewTextBoxColumn6.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "DurationUse";
            gridViewTextBoxColumn6.HeaderText = "Тривалість використання";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "DurationUse";
            gridViewTextBoxColumn6.Width = 30;
            gridViewDecimalColumn3.DataType = typeof(int);
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "RegId";
            gridViewDecimalColumn3.HeaderText = "RegId";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.IsVisible = false;
            gridViewDecimalColumn3.Name = "RegId";
            gridViewDecimalColumn3.Width = 36;
            gridViewDecimalColumn4.DataType = typeof(int);
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "RegIitemId";
            gridViewDecimalColumn4.HeaderText = "RegIitemId";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "RegIitemId";
            gridViewDecimalColumn4.Width = 38;
            gridViewDecimalColumn5.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn5.EnableExpressionEditor = false;
            gridViewDecimalColumn5.FieldName = "ObjId";
            gridViewDecimalColumn5.HeaderText = "ObjId";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.IsVisible = false;
            gridViewDecimalColumn5.Name = "ObjId";
            gridViewDecimalColumn5.Width = 40;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "ObjectName";
            gridViewTextBoxColumn7.HeaderText = "Назва твору";
            gridViewTextBoxColumn7.Name = "ObjectName";
            gridViewTextBoxColumn7.Width = 48;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "ObjectAuthors";
            gridViewTextBoxColumn8.HeaderText = "Автори";
            gridViewTextBoxColumn8.Name = "ObjectAuthors";
            gridViewTextBoxColumn8.Width = 52;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "ObjectPerformers";
            gridViewTextBoxColumn9.HeaderText = "Виконавці";
            gridViewTextBoxColumn9.Name = "ObjectPerformers";
            gridViewTextBoxColumn9.Width = 55;
            gridViewTextBoxColumn10.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "ObjectDuration";
            gridViewTextBoxColumn10.HeaderText = "Тривалість виконання";
            gridViewTextBoxColumn10.Name = "ObjectDuration";
            gridViewTextBoxColumn10.Width = 55;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Прив\'язати";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Name = "LinkColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 54;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Шукати";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.Name = "FindColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 54;
            this.gvRegisterItemList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn5,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn6,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewDecimalColumn5,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvRegisterItemList.MasterTemplate.DataSource = this.registerItemViewModelBindingSource;
            this.gvRegisterItemList.MasterTemplate.EnableFiltering = true;
            this.gvRegisterItemList.MasterTemplate.ShowFilteringRow = false;
            this.gvRegisterItemList.MasterTemplate.ShowRowHeaderColumn = false;
            gridViewColumnGroup1.Name = "registerGroup";
            gridViewColumnGroupRow1.ColumnNames.Add("Linked");
            gridViewColumnGroupRow1.ColumnNames.Add("ItemName");
            gridViewColumnGroupRow1.ColumnNames.Add("Performer");
            gridViewColumnGroupRow1.ColumnNames.Add("AuthorMusic");
            gridViewColumnGroupRow1.ColumnNames.Add("AuthorText");
            gridViewColumnGroupRow1.ColumnNames.Add("CategoryCode");
            gridViewColumnGroupRow1.ColumnNames.Add("DurationItem");
            gridViewColumnGroupRow1.ColumnNames.Add("CountUse");
            gridViewColumnGroupRow1.ColumnNames.Add("DurationUse");
            gridViewColumnGroupRow1.ColumnNames.Add("RegId");
            gridViewColumnGroupRow1.ColumnNames.Add("RegIitemId");
            gridViewColumnGroupRow1.ColumnNames.Add("ObjId");
            gridViewColumnGroupRow1.ColumnNames.Add("ModifyDate");
            gridViewColumnGroupRow1.ColumnNames.Add("ModifyLogin");
            gridViewColumnGroupRow1.MinHeight = 27;
            gridViewColumnGroup1.Rows.Add(gridViewColumnGroupRow1);
            gridViewColumnGroup1.RowSpan = 27;
            gridViewColumnGroup1.Text = "Дані відомості";
            gridViewColumnGroup2.Name = "objectGroup";
            gridViewColumnGroupRow2.ColumnNames.Add("ObjectName");
            gridViewColumnGroupRow2.ColumnNames.Add("ObjectAuthors");
            gridViewColumnGroupRow2.ColumnNames.Add("ObjectPerformers");
            gridViewColumnGroupRow2.ColumnNames.Add("ObjectDuration");
            gridViewColumnGroup2.Rows.Add(gridViewColumnGroupRow2);
            gridViewColumnGroup2.Text = "Привязаний об\'єкт";
            gridViewColumnGroup3.Name = "commandGroup";
            gridViewColumnGroupRow3.ColumnNames.Add("FindColumn");
            gridViewColumnGroupRow3.ColumnNames.Add("LinkColumn");
            gridViewColumnGroup3.Rows.Add(gridViewColumnGroupRow3);
            gridViewColumnGroup3.Text = "";
            columnGroupsViewDefinition1.ColumnGroups.Add(gridViewColumnGroup1);
            columnGroupsViewDefinition1.ColumnGroups.Add(gridViewColumnGroup2);
            columnGroupsViewDefinition1.ColumnGroups.Add(gridViewColumnGroup3);
            this.gvRegisterItemList.MasterTemplate.ViewDefinition = columnGroupsViewDefinition1;
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
    }
}
