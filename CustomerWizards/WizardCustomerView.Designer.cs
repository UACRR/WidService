namespace CustomerWizards
{
    partial class WizardCustomerView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardCustomerView));
            this.radWizard = new Telerik.WinControls.UI.RadWizard();
            this.wizardCompletionPage1 = new Telerik.WinControls.UI.WizardCompletionPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AnketaCompanySource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.wizardPage1 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage4 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage2 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage3 = new Telerik.WinControls.UI.WizardPage();
            this.BankAccountSource = new System.Windows.Forms.BindingSource(this.components);
            this.ipsRegistrationsCompanyControl1 = new IpsViewComponentLibrary.IpsRegistrationsCompanyControl();
            this.ipsServiceComissionControl1 = new IpsViewComponentLibrary.IpsServiceComissionControl();
            this.ipsAnketaCompanyControl1 = new IpsViewComponentLibrary.IpsAnketaCompanyControl();
            this.ipsAddressControl1 = new IpsViewComponentLibrary.IpsAddressControl();
            this.ipsBossNameContactsControl1 = new IpsViewComponentLibrary.IpsBossNameContactsControl();
            this.ipsBankAccountControl = new IpsViewComponentLibrary.IpsBankAccountControl();
            this.ipsExclusionsLimitationsControl1 = new IpsViewComponentLibrary.IpsExclusionsLimitationsControl();
            ((System.ComponentModel.ISupportInitialize)(this.radWizard)).BeginInit();
            this.radWizard.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnketaCompanySource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BankAccountSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.DdlTypeVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.DtRegisterDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtNumberVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtRegisterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtRegisterWho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsServiceComissionControl1.TxtRateCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsServiceComissionControl1.TxtRateCourt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.DdlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.DdlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.TxtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.TxtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtAccountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtTransitNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radWizard
            // 
            this.radWizard.CompletionPage = this.wizardCompletionPage1;
            this.radWizard.Controls.Add(this.panel2);
            this.radWizard.Controls.Add(this.panel1);
            this.radWizard.Controls.Add(this.panel4);
            this.radWizard.Controls.Add(this.panel3);
            this.radWizard.Controls.Add(this.panel5);
            this.radWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radWizard.Location = new System.Drawing.Point(0, 0);
            this.radWizard.Name = "radWizard";
            this.radWizard.PageHeaderIcon = ((System.Drawing.Image)(resources.GetObject("radWizard.PageHeaderIcon")));
            this.radWizard.Pages.Add(this.wizardPage1);
            this.radWizard.Pages.Add(this.wizardPage4);
            this.radWizard.Pages.Add(this.wizardPage2);
            this.radWizard.Pages.Add(this.wizardPage3);
            this.radWizard.Pages.Add(this.wizardCompletionPage1);
            this.radWizard.Size = new System.Drawing.Size(692, 604);
            this.radWizard.TabIndex = 0;
            this.radWizard.WelcomePage = null;
            ((Telerik.WinControls.UI.Wizard97CommandArea)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3))).IsWelcomePage = false;
            ((Telerik.WinControls.UI.Wizard97CommandArea)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3))).IsCompletionPage = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).Text = "Відміна";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).Text = "Зберегти";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).Text = "Далі   >";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).IsFocusedWizardButton = true;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Text = "<   Назад";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Enabled = true;
            // 
            // wizardCompletionPage1
            // 
            this.wizardCompletionPage1.ContentArea = this.panel3;
            this.wizardCompletionPage1.Name = "wizardCompletionPage1";
            this.wizardCompletionPage1.Title = "Зберегти зміни";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(150, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 500);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ipsRegistrationsCompanyControl1);
            this.panel2.Controls.Add(this.ipsServiceComissionControl1);
            this.panel2.Controls.Add(this.ipsAnketaCompanyControl1);
            this.panel2.Controls.Add(this.ipsAddressControl1);
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 475);
            this.panel2.TabIndex = 1;
            // 
            // AnketaCompanySource
            // 
            this.AnketaCompanySource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ipsExclusionsLimitationsControl1);
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 475);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(0, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(692, 475);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.ipsBossNameContactsControl1);
            this.panel5.Controls.Add(this.ipsBankAccountControl);
            this.panel5.Location = new System.Drawing.Point(0, 81);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(692, 475);
            this.panel5.TabIndex = 5;
            // 
            // wizardPage1
            // 
            this.wizardPage1.ContentArea = this.panel2;
            this.wizardPage1.Header = "Анкета правовласника (юридична особа)";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Title = "Анкета";
            // 
            // wizardPage4
            // 
            this.wizardPage4.ContentArea = this.panel5;
            this.wizardPage4.Header = "Page header ...";
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.Title = "Банківські реквізити";
            // 
            // wizardPage2
            // 
            this.wizardPage2.ContentArea = this.panel1;
            this.wizardPage2.Header = "Page header ...";
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Title = "Виключення та обмеження";
            // 
            // wizardPage3
            // 
            this.wizardPage3.ContentArea = this.panel4;
            this.wizardPage3.Header = "Page header ...";
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Title = "Комісії обслуговування";
            // 
            // BankAccountSource
            // 
            this.BankAccountSource.DataSource = typeof(ipsFormsDesign.Interfaces.IBankAccount);
            // 
            // ipsRegistrationsCompanyControl1
            // 
            this.ipsRegistrationsCompanyControl1.DataMember = "";
            this.ipsRegistrationsCompanyControl1.DataSource = this.AnketaCompanySource;
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.DdlTypeVat.Location = new System.Drawing.Point(120, 85);
            this.ipsRegistrationsCompanyControl1.DdlTypeVat.Name = "ddlTypeVat";
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.DdlTypeVat.RootElement.ControlBounds = new System.Drawing.Rectangle(120, 85, 125, 20);
            this.ipsRegistrationsCompanyControl1.DdlTypeVat.RootElement.StretchVertically = true;
            this.ipsRegistrationsCompanyControl1.DdlTypeVat.Size = new System.Drawing.Size(120, 20);
            this.ipsRegistrationsCompanyControl1.DdlTypeVat.TabIndex = 28;
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.Location = new System.Drawing.Point(278, 38);
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.Name = "dtRegisterDate";
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.RootElement.ControlBounds = new System.Drawing.Rectangle(278, 38, 164, 20);
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.RootElement.StretchVertically = true;
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.Size = new System.Drawing.Size(92, 20);
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.TabIndex = 24;
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.TabStop = false;
            this.ipsRegistrationsCompanyControl1.DtRegisterDate.Value = new System.DateTime(((long)(0)));
            this.ipsRegistrationsCompanyControl1.Location = new System.Drawing.Point(51, 150);
            this.ipsRegistrationsCompanyControl1.Name = "ipsRegistrationsCompanyControl1";
            this.ipsRegistrationsCompanyControl1.NumberVatDataMember = "NumberVat";
            this.ipsRegistrationsCompanyControl1.OkpoDataMember = "Okpo";
            this.ipsRegistrationsCompanyControl1.RegisterDateDataMember = "RegistrDate";
            this.ipsRegistrationsCompanyControl1.RegisterNumberDataMember = "RegistrNumber";
            this.ipsRegistrationsCompanyControl1.RegisterWhoDataMember = "RegistrWho";
            this.ipsRegistrationsCompanyControl1.Size = new System.Drawing.Size(600, 110);
            this.ipsRegistrationsCompanyControl1.TabIndex = 5;
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtNumberVat.Location = new System.Drawing.Point(436, 85);
            this.ipsRegistrationsCompanyControl1.TxtNumberVat.Name = "txtNumberVat";
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtNumberVat.RootElement.ControlBounds = new System.Drawing.Rectangle(436, 85, 100, 20);
            this.ipsRegistrationsCompanyControl1.TxtNumberVat.RootElement.StretchVertically = true;
            this.ipsRegistrationsCompanyControl1.TxtNumberVat.Size = new System.Drawing.Size(164, 20);
            this.ipsRegistrationsCompanyControl1.TxtNumberVat.TabIndex = 27;
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtOkpo.Location = new System.Drawing.Point(120, 1);
            this.ipsRegistrationsCompanyControl1.TxtOkpo.Name = "txtOkpo";
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtOkpo.RootElement.ControlBounds = new System.Drawing.Rectangle(120, 1, 100, 20);
            this.ipsRegistrationsCompanyControl1.TxtOkpo.RootElement.StretchVertically = true;
            this.ipsRegistrationsCompanyControl1.TxtOkpo.Size = new System.Drawing.Size(120, 20);
            this.ipsRegistrationsCompanyControl1.TxtOkpo.TabIndex = 23;
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtRegisterNumber.Location = new System.Drawing.Point(120, 38);
            this.ipsRegistrationsCompanyControl1.TxtRegisterNumber.Name = "txtRegisterNumber";
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtRegisterNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(120, 38, 100, 20);
            this.ipsRegistrationsCompanyControl1.TxtRegisterNumber.RootElement.StretchVertically = true;
            this.ipsRegistrationsCompanyControl1.TxtRegisterNumber.Size = new System.Drawing.Size(120, 20);
            this.ipsRegistrationsCompanyControl1.TxtRegisterNumber.TabIndex = 26;
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtRegisterWho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsRegistrationsCompanyControl1.TxtRegisterWho.Location = new System.Drawing.Point(436, 38);
            this.ipsRegistrationsCompanyControl1.TxtRegisterWho.Name = "txtRegisterWho";
            // 
            // 
            // 
            this.ipsRegistrationsCompanyControl1.TxtRegisterWho.RootElement.ControlBounds = new System.Drawing.Rectangle(436, 38, 100, 20);
            this.ipsRegistrationsCompanyControl1.TxtRegisterWho.RootElement.StretchVertically = true;
            this.ipsRegistrationsCompanyControl1.TxtRegisterWho.Size = new System.Drawing.Size(164, 20);
            this.ipsRegistrationsCompanyControl1.TxtRegisterWho.TabIndex = 25;
            this.ipsRegistrationsCompanyControl1.TypesVatDataMember = "";
            this.ipsRegistrationsCompanyControl1.TypesVatDataSource = null;
            this.ipsRegistrationsCompanyControl1.TypesVatDisplayMember = "";
            this.ipsRegistrationsCompanyControl1.TypesVatValueMember = "";
            this.ipsRegistrationsCompanyControl1.TypeVatDataMember = "TypeVat";
            // 
            // ipsServiceComissionControl1
            // 
            this.ipsServiceComissionControl1.DataMember = "";
            this.ipsServiceComissionControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IAgreementAddRh);
            this.ipsServiceComissionControl1.Location = new System.Drawing.Point(51, 373);
            this.ipsServiceComissionControl1.Name = "ipsServiceComissionControl1";
            this.ipsServiceComissionControl1.Size = new System.Drawing.Size(600, 79);
            this.ipsServiceComissionControl1.TabIndex = 4;
            // 
            // 
            // 
            this.ipsServiceComissionControl1.TxtRateCommission.Location = new System.Drawing.Point(270, 18);
            this.ipsServiceComissionControl1.TxtRateCommission.Mask = "N";
            this.ipsServiceComissionControl1.TxtRateCommission.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.ipsServiceComissionControl1.TxtRateCommission.Name = "mtxtRateCommission";
            this.ipsServiceComissionControl1.TxtRateCommission.PromptChar = '0';
            // 
            // 
            // 
            this.ipsServiceComissionControl1.TxtRateCommission.RootElement.ControlBounds = new System.Drawing.Rectangle(270, 18, 125, 20);
            this.ipsServiceComissionControl1.TxtRateCommission.RootElement.StretchVertically = true;
            this.ipsServiceComissionControl1.TxtRateCommission.Size = new System.Drawing.Size(69, 20);
            this.ipsServiceComissionControl1.TxtRateCommission.TabIndex = 5;
            this.ipsServiceComissionControl1.TxtRateCommission.TabStop = false;
            this.ipsServiceComissionControl1.TxtRateCommission.Text = "0,00";
            // 
            // 
            // 
            this.ipsServiceComissionControl1.TxtRateCourt.Location = new System.Drawing.Point(270, 57);
            this.ipsServiceComissionControl1.TxtRateCourt.Mask = "N";
            this.ipsServiceComissionControl1.TxtRateCourt.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.ipsServiceComissionControl1.TxtRateCourt.Name = "mtxtRateCourt";
            this.ipsServiceComissionControl1.TxtRateCourt.PromptChar = '0';
            // 
            // 
            // 
            this.ipsServiceComissionControl1.TxtRateCourt.RootElement.ControlBounds = new System.Drawing.Rectangle(270, 57, 125, 20);
            this.ipsServiceComissionControl1.TxtRateCourt.RootElement.StretchVertically = true;
            this.ipsServiceComissionControl1.TxtRateCourt.Size = new System.Drawing.Size(69, 20);
            this.ipsServiceComissionControl1.TxtRateCourt.TabIndex = 6;
            this.ipsServiceComissionControl1.TxtRateCourt.TabStop = false;
            this.ipsServiceComissionControl1.TxtRateCourt.Text = "0,00";
            // 
            // ipsAnketaCompanyControl1
            // 
            this.ipsAnketaCompanyControl1.ActivityCodeDataMember = "";
            this.ipsAnketaCompanyControl1.ActivityCodeDataSource = null;
            this.ipsAnketaCompanyControl1.ActivityCodeDisplayMember = "";
            this.ipsAnketaCompanyControl1.ActivityCodeValueMember = "";
            this.ipsAnketaCompanyControl1.DataMember = "";
            this.ipsAnketaCompanyControl1.DataSource = this.AnketaCompanySource;
            this.ipsAnketaCompanyControl1.Location = new System.Drawing.Point(51, 4);
            this.ipsAnketaCompanyControl1.Name = "ipsAnketaCompanyControl1";
            this.ipsAnketaCompanyControl1.Size = new System.Drawing.Size(600, 71);
            this.ipsAnketaCompanyControl1.TabIndex = 1;
            // 
            // ipsAddressControl1
            // 
            this.ipsAddressControl1.AddressDataMember = "FaAddress";
            this.ipsAddressControl1.CityDataMember = "FaCity";
            this.ipsAddressControl1.CountriesDataMember = "";
            this.ipsAddressControl1.CountriesDataSource = null;
            this.ipsAddressControl1.CountriesDisplayMember = "";
            this.ipsAddressControl1.CountriesValueMember = "";
            this.ipsAddressControl1.CountryDataMember = "FaCountry";
            this.ipsAddressControl1.DataMember = "";
            this.ipsAddressControl1.DataSource = this.AnketaCompanySource;
            // 
            // 
            // 
            this.ipsAddressControl1.DdlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.DdlCountry.AutoSize = false;
            this.ipsAddressControl1.DdlCountry.Location = new System.Drawing.Point(0, 0);
            this.ipsAddressControl1.DdlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.DdlCountry.Name = "ddlCountry";
            // 
            // 
            // 
            this.ipsAddressControl1.DdlCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 186, 20);
            this.ipsAddressControl1.DdlCountry.Size = new System.Drawing.Size(186, 20);
            this.ipsAddressControl1.DdlCountry.TabIndex = 18;
            // 
            // 
            // 
            this.ipsAddressControl1.DdlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.DdlRegion.AutoSize = false;
            this.ipsAddressControl1.DdlRegion.Location = new System.Drawing.Point(206, 0);
            this.ipsAddressControl1.DdlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.DdlRegion.Name = "ddlRegion";
            // 
            // 
            // 
            this.ipsAddressControl1.DdlRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(206, 0, 186, 20);
            this.ipsAddressControl1.DdlRegion.Size = new System.Drawing.Size(186, 20);
            this.ipsAddressControl1.DdlRegion.TabIndex = 22;
            this.ipsAddressControl1.Location = new System.Drawing.Point(51, 88);
            this.ipsAddressControl1.Name = "ipsAddressControl1";
            this.ipsAddressControl1.RegionDataMember = "FaRegion";
            this.ipsAddressControl1.RegionsDataMember = "";
            this.ipsAddressControl1.RegionsDataSource = null;
            this.ipsAddressControl1.RegionsDisplayMember = "";
            this.ipsAddressControl1.RegionsValueMember = "";
            this.ipsAddressControl1.Size = new System.Drawing.Size(600, 45);
            this.ipsAddressControl1.TabIndex = 0;
            // 
            // 
            // 
            this.ipsAddressControl1.TxtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.TxtAddress.AutoSize = false;
            this.ipsAddressControl1.TxtAddress.Location = new System.Drawing.Point(0, 25);
            this.ipsAddressControl1.TxtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.TxtAddress.Name = "txtAddress";
            // 
            // 
            // 
            this.ipsAddressControl1.TxtAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 600, 20);
            this.ipsAddressControl1.TxtAddress.Size = new System.Drawing.Size(600, 20);
            this.ipsAddressControl1.TxtAddress.TabIndex = 10;
            // 
            // 
            // 
            this.ipsAddressControl1.TxtCity.AutoSize = false;
            this.ipsAddressControl1.TxtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipsAddressControl1.TxtCity.Location = new System.Drawing.Point(412, 0);
            this.ipsAddressControl1.TxtCity.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.TxtCity.Name = "txtCity";
            // 
            // 
            // 
            this.ipsAddressControl1.TxtCity.RootElement.ControlBounds = new System.Drawing.Rectangle(412, 0, 188, 20);
            this.ipsAddressControl1.TxtCity.Size = new System.Drawing.Size(188, 20);
            this.ipsAddressControl1.TxtCity.TabIndex = 23;
            // 
            // ipsBossNameContactsControl1
            // 
            this.ipsBossNameContactsControl1.DataMember = "";
            this.ipsBossNameContactsControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IEmployee);
            this.ipsBossNameContactsControl1.Location = new System.Drawing.Point(44, 167);
            this.ipsBossNameContactsControl1.Name = "ipsBossNameContactsControl1";
            this.ipsBossNameContactsControl1.Size = new System.Drawing.Size(600, 56);
            this.ipsBossNameContactsControl1.TabIndex = 1;
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBossNameContactsControl1.TxtEmail.AutoSize = false;
            this.ipsBossNameContactsControl1.TxtEmail.Location = new System.Drawing.Point(425, 34);
            this.ipsBossNameContactsControl1.TxtEmail.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ipsBossNameContactsControl1.TxtEmail.Name = "txtEmail";
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtEmail.RootElement.ControlBounds = new System.Drawing.Rectangle(425, 36, 175, 20);
            this.ipsBossNameContactsControl1.TxtEmail.Size = new System.Drawing.Size(175, 20);
            this.ipsBossNameContactsControl1.TxtEmail.TabIndex = 24;
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBossNameContactsControl1.TxtFirstName.AutoSize = false;
            this.ipsBossNameContactsControl1.TxtFirstName.Location = new System.Drawing.Point(229, 3);
            this.ipsBossNameContactsControl1.TxtFirstName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ipsBossNameContactsControl1.TxtFirstName.Name = "txtFirstName";
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtFirstName.RootElement.ControlBounds = new System.Drawing.Rectangle(229, 4, 173, 20);
            this.ipsBossNameContactsControl1.TxtFirstName.Size = new System.Drawing.Size(173, 20);
            this.ipsBossNameContactsControl1.TxtFirstName.TabIndex = 25;
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBossNameContactsControl1.TxtLastName.AutoSize = false;
            this.ipsBossNameContactsControl1.TxtLastName.Location = new System.Drawing.Point(33, 3);
            this.ipsBossNameContactsControl1.TxtLastName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ipsBossNameContactsControl1.TxtLastName.Name = "txtLastName";
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtLastName.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 4, 173, 20);
            this.ipsBossNameContactsControl1.TxtLastName.Size = new System.Drawing.Size(173, 20);
            this.ipsBossNameContactsControl1.TxtLastName.TabIndex = 26;
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBossNameContactsControl1.TxtPhone.AutoSize = false;
            this.ipsBossNameContactsControl1.TxtPhone.Location = new System.Drawing.Point(33, 34);
            this.ipsBossNameContactsControl1.TxtPhone.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ipsBossNameContactsControl1.TxtPhone.Name = "txtPhone";
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtPhone.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 36, 173, 20);
            this.ipsBossNameContactsControl1.TxtPhone.Size = new System.Drawing.Size(173, 20);
            this.ipsBossNameContactsControl1.TxtPhone.TabIndex = 27;
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtSurName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBossNameContactsControl1.TxtSurName.AutoSize = false;
            this.ipsBossNameContactsControl1.TxtSurName.Location = new System.Drawing.Point(425, 3);
            this.ipsBossNameContactsControl1.TxtSurName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ipsBossNameContactsControl1.TxtSurName.Name = "txtSurName";
            // 
            // 
            // 
            this.ipsBossNameContactsControl1.TxtSurName.RootElement.ControlBounds = new System.Drawing.Rectangle(425, 3, 175, 20);
            this.ipsBossNameContactsControl1.TxtSurName.Size = new System.Drawing.Size(175, 20);
            this.ipsBossNameContactsControl1.TxtSurName.TabIndex = 23;
            // 
            // ipsBankAccountControl
            // 
            this.ipsBankAccountControl.DataMember = "";
            this.ipsBankAccountControl.DataSource = typeof(ipsFormsDesign.Interfaces.IBankAccount);
            this.ipsBankAccountControl.Location = new System.Drawing.Point(12, 4);
            this.ipsBankAccountControl.Name = "ipsBankAccountControl";
            this.ipsBankAccountControl.Size = new System.Drawing.Size(668, 127);
            this.ipsBankAccountControl.TabIndex = 0;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtAccountNumber.Location = new System.Drawing.Point(118, 103);
            this.ipsBankAccountControl.TxtAccountNumber.Name = "txtAccountNumber";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtAccountNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 103, 100, 20);
            this.ipsBankAccountControl.TxtAccountNumber.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtAccountNumber.Size = new System.Drawing.Size(545, 20);
            this.ipsBankAccountControl.TxtAccountNumber.TabIndex = 5;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtMfo.Location = new System.Drawing.Point(118, 28);
            this.ipsBankAccountControl.TxtMfo.Name = "txtMfo";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfo.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 28, 100, 20);
            this.ipsBankAccountControl.TxtMfo.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtMfo.Size = new System.Drawing.Size(545, 20);
            this.ipsBankAccountControl.TxtMfo.TabIndex = 8;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtMfoName.Location = new System.Drawing.Point(118, 3);
            this.ipsBankAccountControl.TxtMfoName.Name = "txtMfoName";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoName.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 3, 100, 20);
            this.ipsBankAccountControl.TxtMfoName.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtMfoName.Size = new System.Drawing.Size(545, 20);
            this.ipsBankAccountControl.TxtMfoName.TabIndex = 9;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoOkpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtMfoOkpo.Location = new System.Drawing.Point(118, 53);
            this.ipsBankAccountControl.TxtMfoOkpo.Name = "txtMfoOkpo";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoOkpo.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 53, 100, 20);
            this.ipsBankAccountControl.TxtMfoOkpo.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtMfoOkpo.Size = new System.Drawing.Size(545, 20);
            this.ipsBankAccountControl.TxtMfoOkpo.TabIndex = 7;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtTransitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtTransitNumber.Location = new System.Drawing.Point(118, 78);
            this.ipsBankAccountControl.TxtTransitNumber.Name = "txtTransitNumber";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtTransitNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 78, 100, 20);
            this.ipsBankAccountControl.TxtTransitNumber.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtTransitNumber.Size = new System.Drawing.Size(545, 20);
            this.ipsBankAccountControl.TxtTransitNumber.TabIndex = 6;
            // 
            // ipsExclusionsLimitationsControl1
            // 
            this.ipsExclusionsLimitationsControl1.CommunitiesDataMember = "";
            this.ipsExclusionsLimitationsControl1.CommunitiesDataSource = typeof(ipsFormsDesign.Dictionary.CommunityInfo);
            this.ipsExclusionsLimitationsControl1.DataMember = "";
            this.ipsExclusionsLimitationsControl1.DataSource = typeof(ipsFormsDesign.Dictionary.TermsOfServiceWrapper);
            this.ipsExclusionsLimitationsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipsExclusionsLimitationsControl1.Location = new System.Drawing.Point(0, 0);
            this.ipsExclusionsLimitationsControl1.Name = "ipsExclusionsLimitationsControl1";
            this.ipsExclusionsLimitationsControl1.Size = new System.Drawing.Size(692, 475);
            this.ipsExclusionsLimitationsControl1.TabIndex = 0;
            // 
            // WizardCustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 604);
            this.Controls.Add(this.radWizard);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "WizardCustomerView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Wizard Rightholder";
            ((System.ComponentModel.ISupportInitialize)(this.radWizard)).EndInit();
            this.radWizard.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnketaCompanySource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BankAccountSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.DdlTypeVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.DtRegisterDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtNumberVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtRegisterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsRegistrationsCompanyControl1.TxtRegisterWho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsServiceComissionControl1.TxtRateCommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsServiceComissionControl1.TxtRateCourt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.DdlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.DdlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.TxtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.TxtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBossNameContactsControl1.TxtSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtAccountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtTransitNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadWizard radWizard;
        private Telerik.WinControls.UI.WizardCompletionPage wizardCompletionPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.WizardPage wizardPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Telerik.WinControls.UI.WizardPage wizardPage2;
        private Telerik.WinControls.UI.WizardPage wizardPage3;
        private Telerik.WinControls.UI.WizardPage wizardPage4;
        private System.Windows.Forms.BindingSource AnketaCompanySource;
        private System.Windows.Forms.BindingSource BankAccountSource;
        private IpsViewComponentLibrary.IpsBankAccountControl ipsBankAccountControl;
        private IpsViewComponentLibrary.IpsAddressControl ipsAddressControl1;
        private IpsViewComponentLibrary.IpsAnketaCompanyControl ipsAnketaCompanyControl1;
        private IpsViewComponentLibrary.IpsServiceComissionControl ipsServiceComissionControl1;
        private IpsViewComponentLibrary.IpsRegistrationsCompanyControl ipsRegistrationsCompanyControl1;
        private IpsViewComponentLibrary.IpsBossNameContactsControl ipsBossNameContactsControl1;
        private IpsViewComponentLibrary.IpsExclusionsLimitationsControl ipsExclusionsLimitationsControl1;
    }
}