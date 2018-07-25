namespace IpsViewComponentLibrary
{
    partial class MiddleControlAgreementBigRights
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
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.ddlLicType = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlPeriodPayment = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDayForPay = new Telerik.WinControls.UI.RadTextBox();
            this.bsLicAgrParam = new System.Windows.Forms.BindingSource(this.components);
            this.bsAgreementAddBr = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictPaidPeriod = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgreementMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.licenseAgreementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictAgrLicType = new System.Windows.Forms.BindingSource(this.components);
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicAgrParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictAgrLicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaCompany, "Name", true));
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(35, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(116, 22);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "Назва Клієнта";
            this.lblTitle.ThemeName = "Office2013Light";
            // 
            // ddlLicType
            // 
            this.ddlLicType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlLicType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.licenseAgreementBindingSource, "LicCode", true));
            this.ddlLicType.DataSource = this.bsDictAgrLicType;
            this.ddlLicType.DisplayMember = "Name";
            this.ddlLicType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlLicType.Location = new System.Drawing.Point(82, 91);
            this.ddlLicType.Name = "ddlLicType";
            this.ddlLicType.Size = new System.Drawing.Size(511, 21);
            this.ddlLicType.TabIndex = 34;
            this.ddlLicType.ThemeName = "Office2013Light";
            this.ddlLicType.ValueMember = "CodeI";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlLicType.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.ddlLicType.GetChildAt(0).GetChildAt(2))).TextWrap = true;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 91);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(73, 19);
            this.radLabel1.TabIndex = 35;
            this.radLabel1.Text = "Тип ліцензії";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ddlPeriodPayment
            // 
            this.ddlPeriodPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlPeriodPayment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAgreementAddBr, "PeriodCode", true));
            this.ddlPeriodPayment.DataSource = this.bsDictPaidPeriod;
            this.ddlPeriodPayment.DisplayMember = "Name";
            this.ddlPeriodPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlPeriodPayment.Location = new System.Drawing.Point(150, 145);
            this.ddlPeriodPayment.Name = "ddlPeriodPayment";
            this.ddlPeriodPayment.Size = new System.Drawing.Size(194, 21);
            this.ddlPeriodPayment.TabIndex = 38;
            this.ddlPeriodPayment.ThemeName = "Office2013Light";
            this.ddlPeriodPayment.ValueMember = "CodeI";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel4.Location = new System.Drawing.Point(3, 144);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(141, 19);
            this.radLabel4.TabIndex = 39;
            this.radLabel4.Text = "Періодичність платежів";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel2.Location = new System.Drawing.Point(3, 119);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(155, 19);
            this.radLabel2.TabIndex = 40;
            this.radLabel2.Text = "Останній день розрахунку";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // txtDayForPay
            // 
            this.txtDayForPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDayForPay.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBr, "DayForPay", true));
            this.txtDayForPay.Location = new System.Drawing.Point(164, 116);
            this.txtDayForPay.Name = "txtDayForPay";
            this.txtDayForPay.Size = new System.Drawing.Size(48, 21);
            this.txtDayForPay.TabIndex = 41;
            this.txtDayForPay.ThemeName = "Office2013Light";
            this.txtDayForPay.TextChanged += new System.EventHandler(this.txtDayForPay_TextChanged);
            this.txtDayForPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayForPay_KeyPress);
            // 
            // bsAgreementAddBr
            // 
            this.bsAgreementAddBr.DataSource = typeof(ipsFormsDesign.Model.AgreementAddBr);
            // 
            // bsDictPaidPeriod
            // 
            this.bsDictPaidPeriod.DataSource = typeof(ipsFormsDesign.Model.Period);
            // 
            // ctrlAgreementMain
            // 
            this.ctrlAgreementMain.AgreementName = "";
            this.ctrlAgreementMain.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgreementMain.DataSourceBr = this.bsAgreementAddBr;
            this.ctrlAgreementMain.DateBeginDataMember = "";
            this.ctrlAgreementMain.DateDataMember = "";
            this.ctrlAgreementMain.DateEndDataMember = "";
            this.ctrlAgreementMain.DateEndNullDate = new System.DateTime(((long)(0)));
            this.ctrlAgreementMain.DateEndNullText = "";
            this.ctrlAgreementMain.Location = new System.Drawing.Point(3, 36);
            this.ctrlAgreementMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.Name = "ctrlAgreementMain";
            this.ctrlAgreementMain.NumberDataMember = "";
            this.ctrlAgreementMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.TabIndex = 33;
            // 
            // licenseAgreementBindingSource
            // 
            this.licenseAgreementBindingSource.DataSource = typeof(ipsFormsDesign.Model.LicenseAgreement);
            // 
            // bsDictAgrLicType
            // 
            this.bsDictAgrLicType.DataSource = typeof(ipsFormsDesign.Model.AgrLicenseType);
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // MiddleControlAgreementBigRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDayForPay);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ddlPeriodPayment);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.ctrlAgreementMain);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ddlLicType);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(900, 168);
            this.MinimumSize = new System.Drawing.Size(500, 168);
            this.Name = "MiddleControlAgreementBigRights";
            this.Size = new System.Drawing.Size(596, 168);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicAgrParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictAgrLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContractConsumerMainControl ctrlAgreementMain;
        private Telerik.WinControls.UI.RadLabel lblTitle;
        private Telerik.WinControls.UI.RadDropDownList ddlLicType;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlPeriodPayment;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtDayForPay;
        private System.Windows.Forms.BindingSource bsDictAgrLicType;
        private System.Windows.Forms.BindingSource licenseAgreementBindingSource;
        private System.Windows.Forms.BindingSource bsLicAgrParam;
        private System.Windows.Forms.BindingSource bsDictPaidPeriod;
        private System.Windows.Forms.BindingSource bsAgreementAddBr;
        private System.Windows.Forms.BindingSource bsAnketaCompany;
    }
}
