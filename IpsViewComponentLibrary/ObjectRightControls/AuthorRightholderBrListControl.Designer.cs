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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn7 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn8 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn9 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn10 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn11 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn12 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvObjectsRightsList = new Telerik.WinControls.UI.RadGridView();
            this.objectAuthorRightholderBrViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectAuthorRightholderBrViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // gvObjectsRightsList
            // 
            this.gvObjectsRightsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvObjectsRightsList.EnableCustomFiltering = true;
            this.gvObjectsRightsList.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gvObjectsRightsList.MasterTemplate.AllowAddNewRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowDeleteRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowEditRow = false;
            this.gvObjectsRightsList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewComboBoxColumn7.DataType = typeof(int);
            gridViewComboBoxColumn7.FieldName = "Author.RoleCode";
            gridViewComboBoxColumn7.HeaderText = "Творча роль";
            gridViewComboBoxColumn7.Name = "RoleCode";
            gridViewComboBoxColumn7.Width = 69;
            gridViewComboBoxColumn8.FieldName = "Author.AuthorName";
            gridViewComboBoxColumn8.HeaderText = "ПІБ";
            gridViewComboBoxColumn8.Name = "AuthorName";
            gridViewComboBoxColumn8.Width = 87;
            gridViewTextBoxColumn3.FieldName = "InnerCode";
            gridViewTextBoxColumn3.HeaderText = "Шифр автора";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "InnerCode";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 40;
            gridViewTextBoxColumn4.FieldName = "Country";
            gridViewTextBoxColumn4.HeaderText = "Країна автора";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Country";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 42;
            gridViewDecimalColumn3.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn3.FieldName = "CopyRight.RoleRate";
            gridViewDecimalColumn3.HeaderText = "Доля";
            gridViewDecimalColumn3.Name = "RoleRate";
            gridViewDecimalColumn3.Width = 41;
            gridViewComboBoxColumn9.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn9.FieldName = "LicAuthorBr.PrepayType";
            gridViewComboBoxColumn9.HeaderText = "Тип передплати";
            gridViewComboBoxColumn9.Name = "PrepayType";
            gridViewComboBoxColumn9.Width = 49;
            gridViewComboBoxColumn10.FieldName = "LicAuthorBr.R030";
            gridViewComboBoxColumn10.HeaderText = "Валюта";
            gridViewComboBoxColumn10.Name = "Currency";
            gridViewComboBoxColumn10.Width = 46;
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn4.FieldName = "LicAuthorBr.PrepaySum";
            gridViewDecimalColumn4.FormatString = "{0:N2}";
            gridViewDecimalColumn4.HeaderText = "Сума передплати";
            gridViewDecimalColumn4.Name = "PrepaySum";
            gridViewDecimalColumn4.Width = 49;
            gridViewComboBoxColumn11.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn11.FieldName = "WorkRh.WorkTypeRh";
            gridViewComboBoxColumn11.HeaderText = "Стан роботи з автором";
            gridViewComboBoxColumn11.Name = "WorkTypeRh";
            gridViewComboBoxColumn11.Width = 59;
            gridViewComboBoxColumn12.DataType = typeof(System.Nullable<int>);
            gridViewComboBoxColumn12.FieldName = "WorkRh.WorkTypeCl";
            gridViewComboBoxColumn12.HeaderText = "Стан роботи з клієнтом";
            gridViewComboBoxColumn12.Name = "WorkTypeCl";
            gridViewComboBoxColumn12.Width = 61;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.DefaultText = "Редагувати";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Name = "EditColumn";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 80;
            gridViewCommandColumn4.AllowResize = false;
            gridViewCommandColumn4.DefaultText = "Видалити";
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Name = "DeleteColumn";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.UseDefaultText = true;
            gridViewCommandColumn4.Width = 79;
            this.gvObjectsRightsList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn7,
            gridViewComboBoxColumn8,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn3,
            gridViewComboBoxColumn9,
            gridViewComboBoxColumn10,
            gridViewDecimalColumn4,
            gridViewComboBoxColumn11,
            gridViewComboBoxColumn12,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.gvObjectsRightsList.MasterTemplate.DataSource = this.objectAuthorRightholderBrViewModelBindingSource;
            this.gvObjectsRightsList.MasterTemplate.EnableCustomFiltering = true;
            this.gvObjectsRightsList.MasterTemplate.EnableFiltering = true;
            this.gvObjectsRightsList.MasterTemplate.ShowFilteringRow = false;
            this.gvObjectsRightsList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvObjectsRightsList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvObjectsRightsList.Name = "gvObjectsRightsList";
            this.gvObjectsRightsList.ShowGroupPanel = false;
            this.gvObjectsRightsList.Size = new System.Drawing.Size(693, 369);
            this.gvObjectsRightsList.TabIndex = 23;
            this.gvObjectsRightsList.ThemeName = "Office2013Light";
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
            // 
            // AuthorRightholderBrListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvObjectsRightsList);
            this.Name = "AuthorRightholderBrListControl";
            this.Size = new System.Drawing.Size(699, 405);
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectAuthorRightholderBrViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvObjectsRightsList;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private System.Windows.Forms.BindingSource objectAuthorRightholderBrViewModelBindingSource;
    }
}
