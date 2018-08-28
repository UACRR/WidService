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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn6 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn7 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn8 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn9 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn10 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
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
            gridViewComboBoxColumn6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            gridViewComboBoxColumn6.DataType = typeof(int);
            gridViewComboBoxColumn6.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewComboBoxColumn6.EnableExpressionEditor = false;
            gridViewComboBoxColumn6.FieldName = "Author.RoleCode";
            gridViewComboBoxColumn6.HeaderText = "Творча роль";
            gridViewComboBoxColumn6.Name = "RoleCode";
            gridViewComboBoxColumn6.Width = 59;
            gridViewCheckBoxColumn2.FieldName = "IsRightholder";
            gridViewCheckBoxColumn2.HeaderText = "Є правовласником";
            gridViewCheckBoxColumn2.MaxWidth = 30;
            gridViewCheckBoxColumn2.MinWidth = 30;
            gridViewCheckBoxColumn2.Name = "IsRightholder";
            gridViewCheckBoxColumn2.Width = 30;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Author.AuthorName";
            gridViewTextBoxColumn4.HeaderText = "ПІБ";
            gridViewTextBoxColumn4.Name = "AuthorName";
            gridViewTextBoxColumn4.Width = 69;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "InnerCode";
            gridViewTextBoxColumn5.HeaderText = "Шифр автора";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "InnerCode";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 46;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Country";
            gridViewTextBoxColumn6.HeaderText = "Країна автора";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "Country";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 47;
            gridViewDecimalColumn3.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "CopyRight.RoleRate";
            gridViewDecimalColumn3.FormatString = "{0:N2}";
            gridViewDecimalColumn3.HeaderText = "Доля";
            gridViewDecimalColumn3.Name = "RoleRate";
            gridViewDecimalColumn3.Width = 47;
            gridViewComboBoxColumn7.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn7.EnableExpressionEditor = false;
            gridViewComboBoxColumn7.FieldName = "LicAuthorBr.PrepayType";
            gridViewComboBoxColumn7.HeaderText = "Тип передплати";
            gridViewComboBoxColumn7.Name = "PrepayType";
            gridViewComboBoxColumn7.Width = 57;
            gridViewComboBoxColumn8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            gridViewComboBoxColumn8.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewComboBoxColumn8.EnableExpressionEditor = false;
            gridViewComboBoxColumn8.FieldName = "LicAuthorBr.R030";
            gridViewComboBoxColumn8.HeaderText = "Валюта";
            gridViewComboBoxColumn8.Name = "Currency";
            gridViewComboBoxColumn8.Width = 52;
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "LicAuthorBr.PrepaySum";
            gridViewDecimalColumn4.FormatString = "{0:N2}";
            gridViewDecimalColumn4.HeaderText = "Сума передплати";
            gridViewDecimalColumn4.Name = "PrepaySum";
            gridViewDecimalColumn4.Width = 57;
            gridViewComboBoxColumn9.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn9.EnableExpressionEditor = false;
            gridViewComboBoxColumn9.FieldName = "WorkRh.WorkTypeRh";
            gridViewComboBoxColumn9.HeaderText = "Стан роботи з автором";
            gridViewComboBoxColumn9.Name = "WorkTypeRh";
            gridViewComboBoxColumn9.Width = 70;
            gridViewComboBoxColumn10.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn10.EnableExpressionEditor = false;
            gridViewComboBoxColumn10.FieldName = "WorkRh.WorkTypeCl";
            gridViewComboBoxColumn10.HeaderText = "Стан роботи з клієнтом";
            gridViewComboBoxColumn10.Name = "WorkTypeCl";
            gridViewComboBoxColumn10.Width = 89;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.DefaultText = "Редагувати";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.IsVisible = false;
            gridViewCommandColumn3.Name = "EditColumn";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 80;
            gridViewCommandColumn4.AllowResize = false;
            gridViewCommandColumn4.DefaultText = "Видалити";
            gridViewCommandColumn4.EnableExpressionEditor = false;
            gridViewCommandColumn4.Name = "DeleteColumn";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.UseDefaultText = true;
            gridViewCommandColumn4.Width = 79;
            this.gvAuthorRightholderList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn6,
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewDecimalColumn3,
            gridViewComboBoxColumn7,
            gridViewComboBoxColumn8,
            gridViewDecimalColumn4,
            gridViewComboBoxColumn9,
            gridViewComboBoxColumn10,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.gvAuthorRightholderList.MasterTemplate.DataSource = this.objectAuthorRightholderBrViewModelBindingSource;
            this.gvAuthorRightholderList.MasterTemplate.EnableCustomFiltering = true;
            this.gvAuthorRightholderList.MasterTemplate.EnableFiltering = true;
            this.gvAuthorRightholderList.MasterTemplate.ShowFilteringRow = false;
            this.gvAuthorRightholderList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvAuthorRightholderList.MasterTemplate.ViewDefinition = tableViewDefinition2;
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
