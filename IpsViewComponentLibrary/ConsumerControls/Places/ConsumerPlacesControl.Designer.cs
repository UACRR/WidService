namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    partial class ConsumerPlacesControl
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ddBtnAddPlace = new Telerik.WinControls.UI.RadDropDownButton();
            this.gvPlaces = new Telerik.WinControls.UI.RadGridView();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnEdit = new Telerik.WinControls.UI.RadButton();
            this.bsPlacesForAgreement = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnAddPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacesForAgreement)).BeginInit();
            this.SuspendLayout();
            // 
            // ddBtnAddPlace
            // 
            this.ddBtnAddPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddBtnAddPlace.Location = new System.Drawing.Point(3, 275);
            this.ddBtnAddPlace.Name = "ddBtnAddPlace";
            this.ddBtnAddPlace.Size = new System.Drawing.Size(163, 24);
            this.ddBtnAddPlace.TabIndex = 7;
            this.ddBtnAddPlace.Text = "Додати бізнес-точку";
            this.ddBtnAddPlace.ThemeName = "Office2013Light";
            // 
            // gvPlaces
            // 
            this.gvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPlaces.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gvPlaces.MasterTemplate.AllowAddNewRow = false;
            this.gvPlaces.MasterTemplate.AllowColumnReorder = false;
            this.gvPlaces.MasterTemplate.AllowDeleteRow = false;
            this.gvPlaces.MasterTemplate.AllowDragToGroup = false;
            this.gvPlaces.MasterTemplate.AllowEditRow = false;
            this.gvPlaces.MasterTemplate.AutoGenerateColumns = false;
            this.gvPlaces.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn5.DataType = typeof(int);
            gridViewDecimalColumn5.FieldName = "PlaceId";
            gridViewDecimalColumn5.HeaderText = "ID";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "PlaceId";
            gridViewDecimalColumn5.Width = 43;
            gridViewDecimalColumn6.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn6.FieldName = "CustId";
            gridViewDecimalColumn6.HeaderText = "CustId";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.IsVisible = false;
            gridViewDecimalColumn6.Name = "CustId";
            gridViewTextBoxColumn12.FieldName = "PlaceName";
            gridViewTextBoxColumn12.HeaderText = "Назва";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "PlaceName";
            gridViewTextBoxColumn12.Width = 225;
            gridViewTextBoxColumn13.FieldName = "PlaceCountry";
            gridViewTextBoxColumn13.HeaderText = "PlaceCountry";
            gridViewTextBoxColumn13.IsAutoGenerated = true;
            gridViewTextBoxColumn13.IsVisible = false;
            gridViewTextBoxColumn13.Name = "PlaceCountry";
            gridViewDecimalColumn7.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn7.FieldName = "PlaceRegion";
            gridViewDecimalColumn7.HeaderText = "PlaceRegion";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.IsVisible = false;
            gridViewDecimalColumn7.Name = "PlaceRegion";
            gridViewTextBoxColumn14.FieldName = "PlaceCity";
            gridViewTextBoxColumn14.HeaderText = "PlaceCity";
            gridViewTextBoxColumn14.IsAutoGenerated = true;
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "PlaceCity";
            gridViewTextBoxColumn15.FieldName = "PlCodeNavigation.Name";
            gridViewTextBoxColumn15.HeaderText = "Тип бізнес-точки";
            gridViewTextBoxColumn15.IsAutoGenerated = true;
            gridViewTextBoxColumn15.MinWidth = 120;
            gridViewTextBoxColumn15.Name = "PlCodeNavigation.Name";
            gridViewTextBoxColumn15.ReadOnly = true;
            gridViewTextBoxColumn15.Width = 120;
            gridViewTextBoxColumn16.FieldName = "PlaceAddress";
            gridViewTextBoxColumn16.HeaderText = "Адреса";
            gridViewTextBoxColumn16.IsAutoGenerated = true;
            gridViewTextBoxColumn16.IsVisible = false;
            gridViewTextBoxColumn16.Name = "PlaceAddress";
            gridViewTextBoxColumn16.Width = 291;
            gridViewTextBoxColumn17.FieldName = "FullAddressPlace";
            gridViewTextBoxColumn17.HeaderText = "Адреса";
            gridViewTextBoxColumn17.MinWidth = 200;
            gridViewTextBoxColumn17.Name = "FullAddressPlace";
            gridViewTextBoxColumn17.Width = 335;
            gridViewTextBoxColumn18.FieldName = "PlacePhone";
            gridViewTextBoxColumn18.HeaderText = "PlacePhone";
            gridViewTextBoxColumn18.IsAutoGenerated = true;
            gridViewTextBoxColumn18.IsVisible = false;
            gridViewTextBoxColumn18.Name = "PlacePhone";
            gridViewCheckBoxColumn2.DataType = typeof(System.Nullable<bool>);
            gridViewCheckBoxColumn2.FieldName = "FreeEntry";
            gridViewCheckBoxColumn2.HeaderText = "FreeEntry";
            gridViewCheckBoxColumn2.IsAutoGenerated = true;
            gridViewCheckBoxColumn2.IsVisible = false;
            gridViewCheckBoxColumn2.Name = "FreeEntry";
            gridViewDecimalColumn8.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn8.FieldName = "PlCode";
            gridViewDecimalColumn8.HeaderText = "PlCode";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.IsVisible = false;
            gridViewDecimalColumn8.Name = "PlCode";
            gridViewTextBoxColumn19.DataType = typeof(ipsFormsDesign.Model.Client);
            gridViewTextBoxColumn19.FieldName = "Cust";
            gridViewTextBoxColumn19.HeaderText = "Cust";
            gridViewTextBoxColumn19.IsVisible = false;
            gridViewTextBoxColumn19.Name = "Cust";
            gridViewTextBoxColumn19.Width = 47;
            gridViewTextBoxColumn20.DataType = typeof(ipsFormsDesign.Interfaces.ObservableListSource<ipsFormsDesign.Model.ClnPlaceHoll>);
            gridViewTextBoxColumn20.FieldName = "ClnPlaceHoll";
            gridViewTextBoxColumn20.HeaderText = "ClnPlaceHoll";
            gridViewTextBoxColumn20.IsVisible = false;
            gridViewTextBoxColumn20.Name = "ClnPlaceHoll";
            gridViewTextBoxColumn21.DataType = typeof(ipsFormsDesign.Interfaces.ObservableListSource<ipsFormsDesign.Model.LicPlace>);
            gridViewTextBoxColumn21.FieldName = "LicPlace";
            gridViewTextBoxColumn21.HeaderText = "LicPlace";
            gridViewTextBoxColumn21.IsVisible = false;
            gridViewTextBoxColumn21.Name = "LicPlace";
            gridViewTextBoxColumn22.DataType = typeof(ipsFormsDesign.Interfaces.ITypePlace);
            gridViewTextBoxColumn22.FieldName = "PlCodenavigation";
            gridViewTextBoxColumn22.HeaderText = "PlCodenavigation";
            gridViewTextBoxColumn22.IsVisible = false;
            gridViewTextBoxColumn22.Name = "PlCodenavigation";
            gridViewTextBoxColumn22.Width = 47;
            this.gvPlaces.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn5,
            gridViewDecimalColumn6,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewDecimalColumn7,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewCheckBoxColumn2,
            gridViewDecimalColumn8,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22});
            this.gvPlaces.MasterTemplate.DataSource = this.bsPlacesForAgreement;
            this.gvPlaces.MasterTemplate.EnableGrouping = false;
            this.gvPlaces.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvPlaces.Name = "gvPlaces";
            this.gvPlaces.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPlaces.ReadOnly = true;
            this.gvPlaces.Size = new System.Drawing.Size(746, 266);
            this.gvPlaces.TabIndex = 5;
            this.gvPlaces.ThemeName = "Office2013Light";
            this.gvPlaces.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvPlaces_CellDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(586, 275);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(163, 24);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Видалити бізнес-точку";
            this.btnDelete.ThemeName = "Office2013Light";
            this.btnDelete.Click += new System.EventHandler(this.btnDeletePlace_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(172, 275);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnEdit.Size = new System.Drawing.Size(163, 24);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Редагувати бізнес-точку";
            this.btnEdit.ThemeName = "Office2013Light";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEdit.GetChildAt(0))).Text = "Редагувати бізнес-точку";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEdit.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            // 
            // bsPlacesForAgreement
            // 
            this.bsPlacesForAgreement.DataSource = typeof(IpsViewComponentLibrary.InternalControlsModel.PlacesForAgreement);
            // 
            // ConsumerPlacesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.ddBtnAddPlace);
            this.Controls.Add(this.gvPlaces);
            this.Controls.Add(this.btnEdit);
            this.DoubleBuffered = true;
            this.Name = "ConsumerPlacesControl";
            this.Size = new System.Drawing.Size(752, 302);
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnAddPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlacesForAgreement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnEdit;
        private Telerik.WinControls.UI.RadDropDownButton ddBtnAddPlace;
        private Telerik.WinControls.UI.RadGridView gvPlaces;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsPlacesForAgreement;
    }
}
