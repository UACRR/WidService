namespace IpsViewComponentLibrary.ObjectRightControls
{
    partial class AuthorRightholderBrListControl
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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn3 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn4 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn5 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvAuthorRightholderList = new Telerik.WinControls.UI.RadGridView();
            this.objectAuthorRightholderBrViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthorRightholderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthorRightholderList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectAuthorRightholderBrViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // gvAuthorRightholderList
            // 
            this.gvAuthorRightholderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvAuthorRightholderList.BackColor = System.Drawing.SystemColors.Control;
            this.gvAuthorRightholderList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvAuthorRightholderList.EnableCustomFiltering = true;
            this.gvAuthorRightholderList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvAuthorRightholderList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gvAuthorRightholderList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvAuthorRightholderList.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gvAuthorRightholderList.MasterTemplate.AllowAddNewRow = false;
            this.gvAuthorRightholderList.MasterTemplate.AllowDeleteRow = false;
            this.gvAuthorRightholderList.MasterTemplate.AutoGenerateColumns = false;
            this.gvAuthorRightholderList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewComboBoxColumn1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            gridViewComboBoxColumn1.DataType = typeof(int);
            gridViewComboBoxColumn1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.FieldName = "Author.RoleCode";
            gridViewComboBoxColumn1.HeaderText = "Творча роль";
            gridViewComboBoxColumn1.Name = "RoleCode";
            gridViewComboBoxColumn1.Width = 64;
            gridViewCheckBoxColumn1.FieldName = "IsRightholder";
            gridViewCheckBoxColumn1.HeaderText = "Є правовласником";
            gridViewCheckBoxColumn1.MaxWidth = 30;
            gridViewCheckBoxColumn1.MinWidth = 30;
            gridViewCheckBoxColumn1.Name = "IsRightholder";
            gridViewCheckBoxColumn1.Width = 30;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Author.AuthorName";
            gridViewTextBoxColumn1.HeaderText = "ПІБ";
            gridViewTextBoxColumn1.Name = "AuthorName";
            gridViewTextBoxColumn1.Width = 74;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "InnerCode";
            gridViewTextBoxColumn2.HeaderText = "Шифр автора";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "InnerCode";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Country";
            gridViewTextBoxColumn3.HeaderText = "Країна автора";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "Country";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 51;
            gridViewDecimalColumn1.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "CopyRight.RoleRate";
            gridViewDecimalColumn1.FormatString = "{0:N2}";
            gridViewDecimalColumn1.HeaderText = "Доля";
            gridViewDecimalColumn1.Name = "RoleRate";
            gridViewDecimalColumn1.Width = 51;
            gridViewComboBoxColumn2.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.FieldName = "LicAuthorBr.PrepayType";
            gridViewComboBoxColumn2.HeaderText = "Тип передплати";
            gridViewComboBoxColumn2.Name = "PrepayType";
            gridViewComboBoxColumn2.Width = 61;
            gridViewComboBoxColumn3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            gridViewComboBoxColumn3.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewComboBoxColumn3.EnableExpressionEditor = false;
            gridViewComboBoxColumn3.FieldName = "LicAuthorBr.R030";
            gridViewComboBoxColumn3.HeaderText = "Валюта";
            gridViewComboBoxColumn3.Name = "Currency";
            gridViewComboBoxColumn3.Width = 56;
            gridViewDecimalColumn2.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "LicAuthorBr.PrepaySum";
            gridViewDecimalColumn2.FormatString = "{0:N2}";
            gridViewDecimalColumn2.HeaderText = "Сума передплати";
            gridViewDecimalColumn2.Name = "PrepaySum";
            gridViewDecimalColumn2.Width = 61;
            gridViewComboBoxColumn4.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn4.EnableExpressionEditor = false;
            gridViewComboBoxColumn4.FieldName = "WorkRh.WorkTypeRh";
            gridViewComboBoxColumn4.HeaderText = "Стан роботи з автором";
            gridViewComboBoxColumn4.Name = "WorkTypeRh";
            gridViewComboBoxColumn4.Width = 76;
            gridViewComboBoxColumn5.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn5.EnableExpressionEditor = false;
            gridViewComboBoxColumn5.FieldName = "WorkRh.WorkTypeCl";
            gridViewComboBoxColumn5.HeaderText = "Стан роботи з клієнтом";
            gridViewComboBoxColumn5.Name = "WorkTypeCl";
            gridViewComboBoxColumn5.Width = 98;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Редагувати";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.IsVisible = false;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "EditColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Видалити";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "DeleteColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 30;
            this.gvAuthorRightholderList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDecimalColumn1,
            gridViewComboBoxColumn2,
            gridViewComboBoxColumn3,
            gridViewDecimalColumn2,
            gridViewComboBoxColumn4,
            gridViewComboBoxColumn5,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvAuthorRightholderList.MasterTemplate.DataSource = this.objectAuthorRightholderBrViewModelBindingSource;
            this.gvAuthorRightholderList.MasterTemplate.EnableCustomFiltering = true;
            this.gvAuthorRightholderList.MasterTemplate.EnableFiltering = true;
            this.gvAuthorRightholderList.MasterTemplate.ShowFilteringRow = false;
            this.gvAuthorRightholderList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvAuthorRightholderList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvAuthorRightholderList.Name = "gvAuthorRightholderList";
            this.gvAuthorRightholderList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvAuthorRightholderList.ShowGroupPanel = false;
            this.gvAuthorRightholderList.Size = new System.Drawing.Size(693, 369);
            this.gvAuthorRightholderList.TabIndex = 23;
            this.gvAuthorRightholderList.ThemeName = "Office2013Light";
            this.gvAuthorRightholderList.EditorRequired += new Telerik.WinControls.UI.EditorRequiredEventHandler(this.gvAuthorRightholderList_EditorRequired);
            this.gvAuthorRightholderList.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gvAuthorRightholderList_CellBeginEdit);
            this.gvAuthorRightholderList.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvAuthorRightholderList_CellEditorInitialized);
            this.gvAuthorRightholderList.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvAuthorRightholderList_CurrentRowChanged);
            this.gvAuthorRightholderList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvObjectsRightsList_CommandCellClick);
            this.gvAuthorRightholderList.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvAuthorRightholderList_ToolTipTextNeeded);
            // 
            // objectAuthorRightholderBrViewModelBindingSource
            // 
            this.objectAuthorRightholderBrViewModelBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectAuthorRightholderBrViewModel);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(4, 378);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Додати";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AuthorRightholderBrListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvAuthorRightholderList);
            this.Name = "AuthorRightholderBrListControl";
            this.Size = new System.Drawing.Size(699, 405);
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthorRightholderList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthorRightholderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectAuthorRightholderBrViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvAuthorRightholderList;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private System.Windows.Forms.BindingSource objectAuthorRightholderBrViewModelBindingSource;
    }
}
