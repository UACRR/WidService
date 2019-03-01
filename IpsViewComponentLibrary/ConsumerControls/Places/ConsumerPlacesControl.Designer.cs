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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ddBtnAddPlace = new Telerik.WinControls.UI.RadDropDownButton();
            this.gvPlaces = new Telerik.WinControls.UI.RadGridView();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnEdit = new Telerik.WinControls.UI.RadButton();
            this.panelParameter = new Telerik.WinControls.UI.RadPanel();
            this.panelHeader = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnAddPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddBtnAddPlace
            // 
            this.ddBtnAddPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddBtnAddPlace.Location = new System.Drawing.Point(3, 244);
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
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "PlaceId";
            gridViewDecimalColumn1.HeaderText = "ID";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "PlaceId";
            gridViewDecimalColumn1.Width = 28;
            gridViewDecimalColumn2.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn2.FieldName = "CustId";
            gridViewDecimalColumn2.HeaderText = "CustId";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Name = "CustId";
            gridViewTextBoxColumn1.FieldName = "PlaceName";
            gridViewTextBoxColumn1.HeaderText = "Назва";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "PlaceName";
            gridViewTextBoxColumn1.Width = 238;
            gridViewTextBoxColumn2.FieldName = "PlaceCountry";
            gridViewTextBoxColumn2.HeaderText = "PlaceCountry";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "PlaceCountry";
            gridViewDecimalColumn3.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn3.FieldName = "PlaceRegion";
            gridViewDecimalColumn3.HeaderText = "PlaceRegion";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.IsVisible = false;
            gridViewDecimalColumn3.Name = "PlaceRegion";
            gridViewTextBoxColumn3.FieldName = "PlaceCity";
            gridViewTextBoxColumn3.HeaderText = "PlaceCity";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "PlaceCity";
            gridViewTextBoxColumn4.FieldName = "PlCodeNavigation.Name";
            gridViewTextBoxColumn4.HeaderText = "Тип бізнес-точки";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "PlCodeNavigation.Name";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 146;
            gridViewTextBoxColumn5.FieldName = "PlaceAddress";
            gridViewTextBoxColumn5.HeaderText = "Адреса";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "PlaceAddress";
            gridViewTextBoxColumn5.Width = 311;
            gridViewTextBoxColumn6.FieldName = "PlacePhone";
            gridViewTextBoxColumn6.HeaderText = "PlacePhone";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "PlacePhone";
            gridViewCheckBoxColumn1.DataType = typeof(System.Nullable<bool>);
            gridViewCheckBoxColumn1.FieldName = "FreeEntry";
            gridViewCheckBoxColumn1.HeaderText = "FreeEntry";
            gridViewCheckBoxColumn1.IsAutoGenerated = true;
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.Name = "FreeEntry";
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn4.FieldName = "PlCode";
            gridViewDecimalColumn4.HeaderText = "PlCode";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "PlCode";
            gridViewTextBoxColumn7.FieldName = "Cust";
            gridViewTextBoxColumn7.HeaderText = "Cust";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "Cust";
            gridViewTextBoxColumn7.Width = 47;
            gridViewTextBoxColumn8.FieldName = "ClnPlaceHoll";
            gridViewTextBoxColumn8.HeaderText = "ClnPlaceHoll";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "ClnPlaceHoll";
            gridViewTextBoxColumn9.FieldName = "LicPlace";
            gridViewTextBoxColumn9.HeaderText = "LicPlace";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "LicPlace";
            gridViewTextBoxColumn10.DataType = typeof(ipsFormsDesign.Interfaces.ITypePlace);
            gridViewTextBoxColumn10.FieldName = "PlCodenavigation";
            gridViewTextBoxColumn10.HeaderText = "PlCodenavigation";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "PlCodenavigation";
            gridViewTextBoxColumn10.Width = 47;
            this.gvPlaces.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCheckBoxColumn1,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.gvPlaces.MasterTemplate.EnableGrouping = false;
            this.gvPlaces.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPlaces.Name = "gvPlaces";
            this.gvPlaces.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPlaces.ReadOnly = true;
            this.gvPlaces.Size = new System.Drawing.Size(746, 235);
            this.gvPlaces.TabIndex = 5;
            this.gvPlaces.ThemeName = "Office2013Light";
            this.gvPlaces.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.RGridViewInstitution_CurrentRowChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(586, 244);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(163, 24);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Видалити бізнес-точку";
            this.btnDelete.ThemeName = "Office2013Light";
            this.btnDelete.Click += new System.EventHandler(this.BtnDeletePlace_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Image = global::IpsViewComponentLibrary.Properties.Resources.angle_double_down_solid;
            this.btnEdit.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(172, 244);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnEdit.Size = new System.Drawing.Size(163, 24);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Редагування";
            this.btnEdit.ThemeName = "Office2013Light";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEdit.GetChildAt(0))).Image = global::IpsViewComponentLibrary.Properties.Resources.angle_double_down_solid;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEdit.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEdit.GetChildAt(0))).Text = "Редагування";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnEdit.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            // 
            // panelParameter
            // 
            this.panelParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParameter.Location = new System.Drawing.Point(0, 271);
            this.panelParameter.Name = "panelParameter";
            this.panelParameter.Size = new System.Drawing.Size(752, 185);
            this.panelParameter.TabIndex = 10;
            this.panelParameter.ThemeName = "Office2013Light";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnDelete);
            this.panelHeader.Controls.Add(this.ddBtnAddPlace);
            this.panelHeader.Controls.Add(this.btnEdit);
            this.panelHeader.Controls.Add(this.gvPlaces);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(752, 271);
            this.panelHeader.TabIndex = 11;
            // 
            // ConsumerPlacesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelParameter);
            this.Controls.Add(this.panelHeader);
            this.DoubleBuffered = true;
            this.Name = "ConsumerPlacesControl";
            this.Size = new System.Drawing.Size(752, 456);
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnAddPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnEdit;
        private Telerik.WinControls.UI.RadDropDownButton ddBtnAddPlace;
        private Telerik.WinControls.UI.RadGridView gvPlaces;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPanel panelParameter;
        private Telerik.WinControls.UI.RadPanel panelHeader;
    }
}
