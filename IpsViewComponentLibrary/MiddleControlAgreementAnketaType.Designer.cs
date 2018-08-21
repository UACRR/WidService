namespace IpsViewComponentLibrary
{
    partial class MiddleControlAgreementAnketaType
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
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.anketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgreementMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.ctrlAgreementSecond = new IpsViewComponentLibrary.ContractConsumerDetailControl();
            this.ddlLicType = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.gvPlaces = new Telerik.WinControls.UI.RadGridView();
            this.lblParam = new Telerik.WinControls.UI.RadLabel();
            this.panel = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "Name", true));
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(35, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 22);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Назва «Клієнта»";
            this.lblTitle.ThemeName = "Office2013Light";
            // 
            // anketaCompanyBindingSource
            // 
            this.anketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // ctrlAgreementMain
            // 
            this.ctrlAgreementMain.AgreementLabelType = ipsFormsDesign.Dictionary.TypeRights.SmallRights;
            this.ctrlAgreementMain.AgreementName = "";
            this.ctrlAgreementMain.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgreementMain.DataSourceBr = typeof(ipsFormsDesign.Model.AgreementAddBr);
            this.ctrlAgreementMain.DateBeginDataMember = "";
            this.ctrlAgreementMain.DateDataMember = "";
            this.ctrlAgreementMain.DateEndDataMember = "";
            this.ctrlAgreementMain.DateEndNullDate = new System.DateTime(((long)(0)));
            this.ctrlAgreementMain.DateEndNullText = "";
            this.ctrlAgreementMain.DateTimeType = IpsViewComponentLibrary.ConsumerAgreementInitType.None;
            this.ctrlAgreementMain.Location = new System.Drawing.Point(3, 31);
            this.ctrlAgreementMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.Name = "ctrlAgreementMain";
            this.ctrlAgreementMain.NumberDataMember = "";
            this.ctrlAgreementMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.TabIndex = 10;
            // 
            // ctrlAgreementSecond
            // 
            this.ctrlAgreementSecond.AutoprolongationDataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgreementSecond.AutoprolongationPercent = null;
            this.ctrlAgreementSecond.DataSourceBinding = null;
            this.ctrlAgreementSecond.IsAutoprolongation = false;
            this.ctrlAgreementSecond.Location = new System.Drawing.Point(3, 17);
            this.ctrlAgreementSecond.MaximumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.MinAmount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctrlAgreementSecond.MinimumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.MinPayment = null;
            this.ctrlAgreementSecond.Name = "ctrlAgreementSecond";
            this.ctrlAgreementSecond.PercentPayment = null;
            this.ctrlAgreementSecond.PeriodPaymentDataMember = null;
            this.ctrlAgreementSecond.PeriodPaymentDataSource = null;
            this.ctrlAgreementSecond.PeriodPaymentDisplayMember = "";
            this.ctrlAgreementSecond.PeriodPaymentSelectedValue = null;
            this.ctrlAgreementSecond.PeriodPaymentValueMember = "";
            this.ctrlAgreementSecond.Size = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.TabIndex = 11;
            // 
            // ddlLicType
            // 
            this.ddlLicType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlLicType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlLicType.Location = new System.Drawing.Point(93, 86);
            this.ddlLicType.Name = "ddlLicType";
            this.ddlLicType.Size = new System.Drawing.Size(594, 21);
            this.ddlLicType.TabIndex = 12;
            this.ddlLicType.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlLicType.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.ddlLicType.GetChildAt(0).GetChildAt(2))).TextWrap = true;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 86);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(84, 19);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "Тип договору";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // gvPlaces
            // 
            this.gvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPlaces.Location = new System.Drawing.Point(3, 110);
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
            gridViewTextBoxColumn8.FieldName = "PlCode";
            gridViewTextBoxColumn8.HeaderText = "Сума";
            gridViewTextBoxColumn8.MaxWidth = 135;
            gridViewTextBoxColumn8.MinWidth = 120;
            gridViewTextBoxColumn8.Name = "PlCode";
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
            this.gvPlaces.Size = new System.Drawing.Size(684, 150);
            this.gvPlaces.TabIndex = 31;
            this.gvPlaces.ThemeName = "Office2007Silver";
            this.gvPlaces.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvPlaces_CellValueChanged);
            // 
            // lblParam
            // 
            this.lblParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblParam.Location = new System.Drawing.Point(13, 266);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(116, 18);
            this.lblParam.TabIndex = 29;
            this.lblParam.Text = "Параметри договору";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel.Controls.Add(this.ctrlAgreementSecond);
            this.panel.Location = new System.Drawing.Point(3, 276);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(489, 125);
            this.panel.TabIndex = 30;
            this.panel.ThemeName = "Office2013Light";
            // 
            // MiddleControlAgreementAnketaType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvPlaces);
            this.Controls.Add(this.lblParam);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.ddlLicType);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ctrlAgreementMain);
            this.Controls.Add(this.lblTitle);
            this.MinimumSize = new System.Drawing.Size(490, 218);
            this.Name = "MiddleControlAgreementAnketaType";
            this.Size = new System.Drawing.Size(690, 404);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private ContractConsumerMainControl ctrlAgreementMain;
        private ContractConsumerDetailControl ctrlAgreementSecond;
        private Telerik.WinControls.UI.RadDropDownList ddlLicType;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView gvPlaces;
        private Telerik.WinControls.UI.RadLabel lblParam;
        private Telerik.WinControls.UI.RadPanel panel;
        private System.Windows.Forms.BindingSource anketaCompanyBindingSource;
    }
}
