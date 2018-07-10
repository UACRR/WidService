namespace IpsViewComponentLibrary
{
    partial class MiddleControlAgreementProlPlacesType
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblTitleClientName = new Telerik.WinControls.UI.RadLabel();
            this.bindingSourceAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgrMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.bindingSourceAgr = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgrSecond = new IpsViewComponentLibrary.ContractConsumerDetailControl();
            this.panel = new Telerik.WinControls.UI.RadPanel();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.gvPlaces = new Telerik.WinControls.UI.RadGridView();
            this.ddlLicType = new Telerik.WinControls.UI.RadDropDownList();
            this.licenseAgreementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDictionary = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(14, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 22);
            this.radLabel1.TabIndex = 22;
            this.radLabel1.Text = "Споживач";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleClientName
            // 
            this.lblTitleClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleClientName.AutoSize = false;
            this.lblTitleClientName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAnketaCompany, "Name", true));
            this.lblTitleClientName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleClientName.Location = new System.Drawing.Point(86, 3);
            this.lblTitleClientName.Name = "lblTitleClientName";
            this.lblTitleClientName.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.lblTitleClientName.Size = new System.Drawing.Size(601, 22);
            this.lblTitleClientName.TabIndex = 21;
            this.lblTitleClientName.Text = "Назва «Клієнта»";
            this.lblTitleClientName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bindingSourceAnketaCompany
            // 
            this.bindingSourceAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // ctrlAgrMain
            // 
            this.ctrlAgrMain.AgreementName = "";
            this.ctrlAgrMain.DataSource = this.bindingSourceAgr;
            this.ctrlAgrMain.DateBeginDataMember = "";
            this.ctrlAgrMain.DateDataMember = "";
            this.ctrlAgrMain.DateEndDataMember = "";
            this.ctrlAgrMain.DateEndNullDate = new System.DateTime(((long)(0)));
            this.ctrlAgrMain.DateEndNullText = "";
            this.ctrlAgrMain.Location = new System.Drawing.Point(14, 31);
            this.ctrlAgrMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.Name = "ctrlAgrMain";
            this.ctrlAgrMain.NumberDataMember = "";
            this.ctrlAgrMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.TabIndex = 23;
            // 
            // bindingSourceAgr
            // 
            this.bindingSourceAgr.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // ctrlAgrSecond
            // 
            this.ctrlAgrSecond.AutoprolongationDataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgrSecond.AutoprolongationPercent = null;
            this.ctrlAgrSecond.DataSourceBinding = null;
            this.ctrlAgrSecond.IsAutoprolongation = false;
            this.ctrlAgrSecond.Location = new System.Drawing.Point(3, 14);
            this.ctrlAgrSecond.MaximumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.MinimumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.MinPayment = null;
            this.ctrlAgrSecond.Name = "ctrlAgrSecond";
            this.ctrlAgrSecond.PercentPayment = null;
            this.ctrlAgrSecond.PeriodPaymentDataMember = null;
            this.ctrlAgrSecond.PeriodPaymentDataSource = null;
            this.ctrlAgrSecond.PeriodPaymentDisplayMember = "";
            this.ctrlAgrSecond.PeriodPaymentSelectedValue = null;
            this.ctrlAgrSecond.PeriodPaymentValueMember = "";
            this.ctrlAgrSecond.Size = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.TabIndex = 17;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.btnPrint);
            this.panel.Controls.Add(this.ctrlAgrSecond);
            this.panel.Location = new System.Drawing.Point(4, 285);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(683, 125);
            this.panel.TabIndex = 26;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(613, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 43);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Друкувати договір";
            this.btnPrint.TextWrap = true;
            this.btnPrint.ThemeName = "Office2013Light";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(570, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 24);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Зберегти зміни";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel3.Location = new System.Drawing.Point(14, 275);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(116, 18);
            this.radLabel3.TabIndex = 25;
            this.radLabel3.Text = "Параметри договору";
            // 
            // gvPlaces
            // 
            this.gvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPlaces.Location = new System.Drawing.Point(3, 114);
            // 
            // 
            // 
            this.gvPlaces.MasterTemplate.AllowAddNewRow = false;
            this.gvPlaces.MasterTemplate.AllowColumnReorder = false;
            this.gvPlaces.MasterTemplate.AllowDeleteRow = false;
            this.gvPlaces.MasterTemplate.AllowDragToGroup = false;
            this.gvPlaces.MasterTemplate.AutoGenerateColumns = false;
            this.gvPlaces.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.FieldName = "PlaceId";
            gridViewTextBoxColumn5.HeaderText = "n/n";
            gridViewTextBoxColumn5.MaxWidth = 70;
            gridViewTextBoxColumn5.MinWidth = 70;
            gridViewTextBoxColumn5.Name = "PlaceId";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 70;
            gridViewTextBoxColumn6.FieldName = "PlaceAddress";
            gridViewTextBoxColumn6.HeaderText = "Фактична адреса закладу";
            gridViewTextBoxColumn6.Name = "PlaceAddress";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 296;
            gridViewTextBoxColumn7.FieldName = "PlaceName";
            gridViewTextBoxColumn7.HeaderText = "Назва Закладу";
            gridViewTextBoxColumn7.Name = "PlaceName";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 147;
            gridViewTextBoxColumn8.FieldName = "Amount";
            gridViewTextBoxColumn8.HeaderText = "Сума";
            gridViewTextBoxColumn8.MaxWidth = 135;
            gridViewTextBoxColumn8.MinWidth = 120;
            gridViewTextBoxColumn8.Name = "Amount";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 120;
            gridViewCheckBoxColumn2.Checked = Telerik.WinControls.Enumerations.ToggleState.On;
            gridViewCheckBoxColumn2.EnableHeaderCheckBox = true;
            gridViewCheckBoxColumn2.FieldName = "CheckIn";
            gridViewCheckBoxColumn2.HeaderText = "";
            gridViewCheckBoxColumn2.Name = "CheckIn";
            gridViewCheckBoxColumn2.Width = 34;
            this.gvPlaces.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCheckBoxColumn2});
            this.gvPlaces.MasterTemplate.EnableGrouping = false;
            this.gvPlaces.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvPlaces.Name = "gvPlaces";
            this.gvPlaces.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPlaces.Size = new System.Drawing.Size(684, 155);
            this.gvPlaces.TabIndex = 28;
            this.gvPlaces.ThemeName = "Office2007Silver";
            this.gvPlaces.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvPlaces_CellValueChanged);
            // 
            // ddlLicType
            // 
            this.ddlLicType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlLicType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.licenseAgreementBindingSource, "LicCode", true));
            this.ddlLicType.DataSource = this.bindingSourceDictionary;
            this.ddlLicType.DisplayMember = "Name";
            this.ddlLicType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlLicType.Location = new System.Drawing.Point(96, 88);
            this.ddlLicType.Name = "ddlLicType";
            this.ddlLicType.Size = new System.Drawing.Size(588, 20);
            this.ddlLicType.TabIndex = 30;
            this.ddlLicType.ValueMember = "CodeI";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlLicType.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.ddlLicType.GetChildAt(0).GetChildAt(2))).TextWrap = true;
            // 
            // licenseAgreementBindingSource
            // 
            this.licenseAgreementBindingSource.DataSource = typeof(ipsFormsDesign.Model.LicenseAgreement);
            // 
            // bindingSourceDictionary
            // 
            this.bindingSourceDictionary.DataSource = typeof(ipsFormsDesign.Model.AgrLicenseType);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(17, 88);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(73, 18);
            this.radLabel2.TabIndex = 31;
            this.radLabel2.Text = "Тип ліцензії";
            // 
            // MiddleControlAgreementProlPlacesType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlLicType);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.gvPlaces);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblTitleClientName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.ctrlAgrMain);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(690, 390);
            this.Name = "MiddleControlAgreementProlPlacesType";
            this.Size = new System.Drawing.Size(690, 443);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblTitleClientName;
        private System.Windows.Forms.BindingSource bindingSourceAnketaCompany;
        private ContractConsumerMainControl ctrlAgrMain;
        private System.Windows.Forms.BindingSource bindingSourceAgr;
        private ContractConsumerDetailControl ctrlAgrSecond;
        private Telerik.WinControls.UI.RadPanel panel;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView gvPlaces;
        private Telerik.WinControls.UI.RadDropDownList ddlLicType;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.BindingSource licenseAgreementBindingSource;
        private System.Windows.Forms.BindingSource bindingSourceDictionary;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
