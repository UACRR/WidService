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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ddlLinkedStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.gvRegisterItemList = new Telerik.WinControls.UI.RadGridView();
            this.registerItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlLinkedStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterItemList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerItemBindingSource)).BeginInit();
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
            gridViewCheckBoxColumn1.FieldName = "ObjId";
            gridViewCheckBoxColumn1.HeaderText = "Знайдений";
            gridViewCheckBoxColumn1.Name = "Linked";
            gridViewCheckBoxColumn1.Width = 75;
            gridViewTextBoxColumn1.FieldName = "ItemName";
            gridViewTextBoxColumn1.HeaderText = "Назва твору";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "ItemName";
            gridViewTextBoxColumn1.Width = 43;
            gridViewTextBoxColumn2.FieldName = "Performer";
            gridViewTextBoxColumn2.HeaderText = "Виконавець";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Performer";
            gridViewTextBoxColumn2.Width = 43;
            gridViewTextBoxColumn3.FieldName = "AuthorMusic";
            gridViewTextBoxColumn3.HeaderText = "Автор музики";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "AuthorMusic";
            gridViewTextBoxColumn3.Width = 44;
            gridViewTextBoxColumn4.FieldName = "AuthorText";
            gridViewTextBoxColumn4.HeaderText = "Автор тексту";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "AuthorText";
            gridViewTextBoxColumn4.Width = 43;
            gridViewDecimalColumn1.AllowResize = false;
            gridViewDecimalColumn1.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn1.FieldName = "CategoryCode";
            gridViewDecimalColumn1.HeaderText = "Категорія";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "CategoryCode";
            gridViewDecimalColumn1.Width = 46;
            gridViewTextBoxColumn5.AllowResize = false;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn5.FieldName = "DurationItem";
            gridViewTextBoxColumn5.HeaderText = "Тривалість звучання";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "DurationItem";
            gridViewTextBoxColumn5.Width = 88;
            gridViewDecimalColumn2.AllowResize = false;
            gridViewDecimalColumn2.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn2.FieldName = "CountUse";
            gridViewDecimalColumn2.HeaderText = "К-ть сповіщень";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "CountUse";
            gridViewDecimalColumn2.Width = 78;
            gridViewTextBoxColumn6.AllowResize = false;
            gridViewTextBoxColumn6.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn6.FieldName = "DurationUse";
            gridViewTextBoxColumn6.HeaderText = "Тривалість використання";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "DurationUse";
            gridViewTextBoxColumn6.Width = 78;
            gridViewDecimalColumn3.DataType = typeof(int);
            gridViewDecimalColumn3.FieldName = "RegId";
            gridViewDecimalColumn3.HeaderText = "RegId";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.IsVisible = false;
            gridViewDecimalColumn3.Name = "RegId";
            gridViewDecimalColumn3.Width = 36;
            gridViewDecimalColumn4.DataType = typeof(int);
            gridViewDecimalColumn4.FieldName = "RegIitemId";
            gridViewDecimalColumn4.HeaderText = "RegIitemId";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "RegIitemId";
            gridViewDecimalColumn4.Width = 38;
            gridViewDecimalColumn5.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn5.FieldName = "ObjId";
            gridViewDecimalColumn5.HeaderText = "ObjId";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.IsVisible = false;
            gridViewDecimalColumn5.Name = "ObjId";
            gridViewDecimalColumn5.Width = 40;
            gridViewDateTimeColumn1.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn1.FieldName = "ModifyDate";
            gridViewDateTimeColumn1.HeaderText = "ModifyDate";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.IsVisible = false;
            gridViewDateTimeColumn1.Name = "ModifyDate";
            gridViewDateTimeColumn1.Width = 43;
            gridViewTextBoxColumn7.FieldName = "ModifyLogin";
            gridViewTextBoxColumn7.HeaderText = "ModifyLogin";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "ModifyLogin";
            gridViewTextBoxColumn7.Width = 46;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Прив\'язати";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "LinkColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 82;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Шукати";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "FindColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 81;
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
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn7,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvRegisterItemList.MasterTemplate.DataSource = this.registerItemBindingSource;
            this.gvRegisterItemList.MasterTemplate.EnableFiltering = true;
            this.gvRegisterItemList.MasterTemplate.ShowFilteringRow = false;
            this.gvRegisterItemList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRegisterItemList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvRegisterItemList.Name = "gvRegisterItemList";
            this.gvRegisterItemList.ShowGroupPanel = false;
            this.gvRegisterItemList.Size = new System.Drawing.Size(693, 317);
            this.gvRegisterItemList.TabIndex = 36;
            this.gvRegisterItemList.ThemeName = "Office2013Light";
            this.gvRegisterItemList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRegisterItemList_CommandCellClick);
            this.gvRegisterItemList.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvRegisterItemList_ToolTipTextNeeded);
            // 
            // registerItemBindingSource
            // 
            this.registerItemBindingSource.DataSource = typeof(ipsFormsDesign.Model.RegisterItem);
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
            ((System.ComponentModel.ISupportInitialize)(this.registerItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlLinkedStatus;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView gvRegisterItemList;
        private System.Windows.Forms.BindingSource registerItemBindingSource;
    }
}
