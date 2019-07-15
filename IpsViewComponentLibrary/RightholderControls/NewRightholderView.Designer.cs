using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.RightholderControls
{
    partial class NewRightholderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRightholderView));
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.rightholderPersonPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAnketaPersonRightholderPage = new IpsViewComponentLibrary.RightholderControls.Anketa.AnketaPersonRightholderPage();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.bsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.bsRightHolder = new System.Windows.Forms.BindingSource(this.components);
            this.rightholderCompanyPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAnketaCompanyRightholderPage = new IpsViewComponentLibrary.RightholderControls.Anketa.AnketaCompanyRightholderPage();
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            this.contactsPersonPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ctrlFaAddress = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnCopyAddressReLe = new Telerik.WinControls.UI.RadButton();
            this.btnCopyAddressFaLe = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnCopyAddressFaRe = new Telerik.WinControls.UI.RadButton();
            this.ctrlReAddress = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.ctrlContacts = new IpsViewComponentLibrary.Shared.Controls.ContactsPersonControl();
            this.contactsCompanyPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlMiddleControlAddress = new IpsViewComponentLibrary.Shared.Controls.JuridicalAddressControl();
            this.passportPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.createRightholderPassportPageView = new Telerik.WinControls.UI.RadPageView();
            this.pasportPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlInternalPassport = new IpsViewComponentLibrary.Shared.Controls.PassportControl();
            this.createRightholderForeignPassportPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlInternationalPassport = new IpsViewComponentLibrary.RightholderControls.PassportInternationalControl();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.managersPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlMiddleControlManagers = new IpsViewComponentLibrary.Shared.Controls.JuridicalManagersControl();
            this.agreementPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgreementNumberDate = new IpsViewComponentLibrary.Shared.Controls.ContractConsumerMainControl();
            this.bsAgreementAddRh = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlServiceComissionControl = new IpsViewComponentLibrary.RightholderControls.Anketa.ServiceComissionControl();
            this.royaltyPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.createRightholderRoyaltyPageView = new Telerik.WinControls.UI.RadPageView();
            this.createRightholderRoyaltyBankPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.bsBankAccount = new System.Windows.Forms.BindingSource(this.components);
            this.createRightholderRoyaltyCashPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.createRightholderRoyaltyPostalTransfer = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBaAddress = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtPostalIndex = new Telerik.WinControls.UI.RadTextBox();
            this.ddlTypeMethodGet = new Telerik.WinControls.UI.RadDropDownList();
            this.rigthLimitationsPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlRightLimitations = new IpsViewComponentLibrary.RightholderControls.Anketa.RightLimitationsControl();
            this.territoryLimitationsPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlTerritoryIncludeExclude = new IpsViewComponentLibrary.RightholderControls.Anketa.TerritoryIncludeExcludeControl();
            this.agreementPrintPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnGenerateRightholderAgreement = new Telerik.WinControls.UI.RadButton();
            this.radPdfViewerNavigator1 = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.pdfvRightholderAgreement = new Telerik.WinControls.UI.RadPdfViewer();
            this.waitbarAgreement = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.sbSave = new Telerik.WinControls.UI.RadSplitButton();
            this.miSave = new Telerik.WinControls.UI.RadMenuItem();
            this.miAcceptAndSave = new Telerik.WinControls.UI.RadMenuItem();
            this.ctrlPageSelector = new IpsViewComponentLibrary.Common.PageSelectorControl();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bsAnketaExternal = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlLeAddress = new IpsViewComponentLibrary.Shared.Controls.AddressLetter();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.rightholderPersonPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).BeginInit();
            this.rightholderCompanyPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            this.contactsPersonPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyAddressReLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyAddressFaLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyAddressFaRe)).BeginInit();
            this.contactsCompanyPage.SuspendLayout();
            this.passportPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createRightholderPassportPageView)).BeginInit();
            this.createRightholderPassportPageView.SuspendLayout();
            this.pasportPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            this.createRightholderForeignPassportPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            this.managersPage.SuspendLayout();
            this.agreementPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddRh)).BeginInit();
            this.royaltyPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createRightholderRoyaltyPageView)).BeginInit();
            this.createRightholderRoyaltyPageView.SuspendLayout();
            this.createRightholderRoyaltyBankPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).BeginInit();
            this.createRightholderRoyaltyPostalTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypeMethodGet)).BeginInit();
            this.rigthLimitationsPage.SuspendLayout();
            this.territoryLimitationsPage.SuspendLayout();
            this.agreementPrintPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerateRightholderAgreement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfvRightholderAgreement)).BeginInit();
            this.pdfvRightholderAgreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitbarAgreement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaExternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPageView
            // 
            this.mainPageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPageView.Controls.Add(this.rightholderPersonPage);
            this.mainPageView.Controls.Add(this.rightholderCompanyPage);
            this.mainPageView.Controls.Add(this.contactsPersonPage);
            this.mainPageView.Controls.Add(this.contactsCompanyPage);
            this.mainPageView.Controls.Add(this.passportPage);
            this.mainPageView.Controls.Add(this.managersPage);
            this.mainPageView.Controls.Add(this.agreementPage);
            this.mainPageView.Controls.Add(this.royaltyPage);
            this.mainPageView.Controls.Add(this.rigthLimitationsPage);
            this.mainPageView.Controls.Add(this.territoryLimitationsPage);
            this.mainPageView.Controls.Add(this.agreementPrintPage);
            this.mainPageView.DefaultPage = this.rightholderPersonPage;
            this.mainPageView.Location = new System.Drawing.Point(1, 1);
            this.mainPageView.Name = "mainPageView";
            this.mainPageView.SelectedPage = this.rightholderPersonPage;
            this.mainPageView.Size = new System.Drawing.Size(995, 437);
            this.mainPageView.TabIndex = 2;
            this.mainPageView.ThemeName = "Office2013Light";
            this.mainPageView.SelectedPageChanged += new System.EventHandler(this.mainPageView_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.mainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.mainPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.mainPageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // rightholderPersonPage
            // 
            this.rightholderPersonPage.Controls.Add(this.ctrlAnketaPersonRightholderPage);
            this.rightholderPersonPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.rightholderPersonPage.Location = new System.Drawing.Point(141, 5);
            this.rightholderPersonPage.Name = "rightholderPersonPage";
            this.rightholderPersonPage.Size = new System.Drawing.Size(849, 427);
            this.rightholderPersonPage.Text = "Правовласник";
            // 
            // ctrlAnketaPersonRightholderPage
            // 
            this.ctrlAnketaPersonRightholderPage.AnketaPersonDataSource = this.bsAnketaPerson;
            this.ctrlAnketaPersonRightholderPage.CustomerDataSource = this.bsCustomer;
            this.ctrlAnketaPersonRightholderPage.Location = new System.Drawing.Point(0, 0);
            this.ctrlAnketaPersonRightholderPage.Name = "ctrlAnketaPersonRightholderPage";
            this.ctrlAnketaPersonRightholderPage.RightholderDataSource = this.bsRightHolder;
            this.ctrlAnketaPersonRightholderPage.Size = new System.Drawing.Size(849, 252);
            this.ctrlAnketaPersonRightholderPage.TabIndex = 0;
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // bsCustomer
            // 
            this.bsCustomer.DataSource = typeof(ipsFormsDesign.Model.Customer);
            // 
            // bsRightHolder
            // 
            this.bsRightHolder.DataSource = typeof(ipsFormsDesign.Model.RightHolder);
            // 
            // rightholderCompanyPage
            // 
            this.rightholderCompanyPage.Controls.Add(this.ctrlAnketaCompanyRightholderPage);
            this.rightholderCompanyPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.rightholderCompanyPage.Location = new System.Drawing.Point(141, 5);
            this.rightholderCompanyPage.Name = "rightholderCompanyPage";
            this.rightholderCompanyPage.Size = new System.Drawing.Size(849, 427);
            this.rightholderCompanyPage.Text = "Правовласник";
            // 
            // ctrlAnketaCompanyRightholderPage
            // 
            this.ctrlAnketaCompanyRightholderPage.AnketaCompanyDataSource = this.bsAnketaCompany;
            this.ctrlAnketaCompanyRightholderPage.Location = new System.Drawing.Point(3, 3);
            this.ctrlAnketaCompanyRightholderPage.Name = "ctrlAnketaCompanyRightholderPage";
            this.ctrlAnketaCompanyRightholderPage.RightholderDataSource = this.bsRightHolder;
            this.ctrlAnketaCompanyRightholderPage.Size = new System.Drawing.Size(670, 300);
            this.ctrlAnketaCompanyRightholderPage.TabIndex = 0;
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // contactsPersonPage
            // 
            this.contactsPersonPage.Controls.Add(this.radGroupBox1);
            this.contactsPersonPage.Controls.Add(this.radGroupBox3);
            this.contactsPersonPage.Controls.Add(this.radGroupBox2);
            this.contactsPersonPage.Controls.Add(this.ctrlContacts);
            this.contactsPersonPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.contactsPersonPage.Location = new System.Drawing.Point(141, 5);
            this.contactsPersonPage.Name = "contactsPersonPage";
            this.contactsPersonPage.Size = new System.Drawing.Size(849, 427);
            this.contactsPersonPage.Text = "Контакти";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.ctrlFaAddress);
            this.radGroupBox1.HeaderText = "Адреса проживання";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 6);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(841, 79);
            this.radGroupBox1.TabIndex = 28;
            this.radGroupBox1.Text = "Адреса проживання";
            this.radGroupBox1.ThemeName = "Office2013Light";
            // 
            // ctrlFaAddress
            // 
            this.ctrlFaAddress.AddressDataMember = "FaAddress";
            this.ctrlFaAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlFaAddress.CityDataMember = "FaCity";
            this.ctrlFaAddress.CountryDataMember = "FaCountry";
            this.ctrlFaAddress.DataSource = this.bsAnketaPerson;
            this.ctrlFaAddress.Location = new System.Drawing.Point(140, 21);
            this.ctrlFaAddress.Name = "ctrlFaAddress";
            this.ctrlFaAddress.RegionDataMember = "FaRegion";
            this.ctrlFaAddress.Size = new System.Drawing.Size(696, 48);
            this.ctrlFaAddress.TabIndex = 0;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.ctrlLeAddress);
            this.radGroupBox3.Controls.Add(this.btnCopyAddressReLe);
            this.radGroupBox3.Controls.Add(this.btnCopyAddressFaLe);
            this.radGroupBox3.HeaderText = "Адреса листування";
            this.radGroupBox3.Location = new System.Drawing.Point(3, 202);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(841, 105);
            this.radGroupBox3.TabIndex = 30;
            this.radGroupBox3.Text = "Адреса листування";
            this.radGroupBox3.ThemeName = "Office2013Light";
            // 
            // btnCopyAddressReLe
            // 
            this.btnCopyAddressReLe.Location = new System.Drawing.Point(310, 17);
            this.btnCopyAddressReLe.Name = "btnCopyAddressReLe";
            this.btnCopyAddressReLe.Size = new System.Drawing.Size(164, 24);
            this.btnCopyAddressReLe.TabIndex = 3;
            this.btnCopyAddressReLe.Text = "Вставити з реєстрації";
            this.btnCopyAddressReLe.ThemeName = "Office2013Light";
            this.btnCopyAddressReLe.Click += new System.EventHandler(this.btnCopyAddressReLe_Click);
            // 
            // btnCopyAddressFaLe
            // 
            this.btnCopyAddressFaLe.Location = new System.Drawing.Point(140, 17);
            this.btnCopyAddressFaLe.Name = "btnCopyAddressFaLe";
            this.btnCopyAddressFaLe.Size = new System.Drawing.Size(164, 24);
            this.btnCopyAddressFaLe.TabIndex = 3;
            this.btnCopyAddressFaLe.Text = "Вставити з проживання";
            this.btnCopyAddressFaLe.ThemeName = "Office2013Light";
            this.btnCopyAddressFaLe.Click += new System.EventHandler(this.btnCopyAddressFaLe_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnCopyAddressFaRe);
            this.radGroupBox2.Controls.Add(this.ctrlReAddress);
            this.radGroupBox2.HeaderText = "Адреса реєстрації";
            this.radGroupBox2.Location = new System.Drawing.Point(3, 91);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(841, 105);
            this.radGroupBox2.TabIndex = 29;
            this.radGroupBox2.Text = "Адреса реєстрації";
            this.radGroupBox2.ThemeName = "Office2013Light";
            // 
            // btnCopyAddressFaRe
            // 
            this.btnCopyAddressFaRe.Location = new System.Drawing.Point(140, 17);
            this.btnCopyAddressFaRe.Name = "btnCopyAddressFaRe";
            this.btnCopyAddressFaRe.Size = new System.Drawing.Size(164, 24);
            this.btnCopyAddressFaRe.TabIndex = 2;
            this.btnCopyAddressFaRe.Text = "Вставити з проживання";
            this.btnCopyAddressFaRe.ThemeName = "Office2013Light";
            this.btnCopyAddressFaRe.Click += new System.EventHandler(this.btnCopyAddressFaRe_Click);
            // 
            // ctrlReAddress
            // 
            this.ctrlReAddress.AddressDataMember = "ReAddress";
            this.ctrlReAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlReAddress.CityDataMember = "ReCity";
            this.ctrlReAddress.CountryDataMember = "ReCountry";
            this.ctrlReAddress.DataSource = this.bsAnketaPerson;
            this.ctrlReAddress.Location = new System.Drawing.Point(140, 52);
            this.ctrlReAddress.Name = "ctrlReAddress";
            this.ctrlReAddress.RegionDataMember = "ReRegion";
            this.ctrlReAddress.Size = new System.Drawing.Size(696, 48);
            this.ctrlReAddress.TabIndex = 1;
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.DataSource = this.bsAnketaPerson;
            this.ctrlContacts.Location = new System.Drawing.Point(143, 314);
            this.ctrlContacts.MaximumSize = new System.Drawing.Size(625, 50);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(625, 50);
            this.ctrlContacts.TabIndex = 21;
            // 
            // contactsCompanyPage
            // 
            this.contactsCompanyPage.Controls.Add(this.ctrlMiddleControlAddress);
            this.contactsCompanyPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.contactsCompanyPage.Location = new System.Drawing.Point(141, 5);
            this.contactsCompanyPage.Name = "contactsCompanyPage";
            this.contactsCompanyPage.Size = new System.Drawing.Size(849, 427);
            this.contactsCompanyPage.Text = "Адреса";
            // 
            // ctrlMiddleControlAddress
            // 
            this.ctrlMiddleControlAddress.Location = new System.Drawing.Point(3, 0);
            this.ctrlMiddleControlAddress.MaximumSize = new System.Drawing.Size(1000, 313);
            this.ctrlMiddleControlAddress.MinimumSize = new System.Drawing.Size(727, 313);
            this.ctrlMiddleControlAddress.Name = "ctrlMiddleControlAddress";
            this.ctrlMiddleControlAddress.Size = new System.Drawing.Size(729, 313);
            this.ctrlMiddleControlAddress.TabIndex = 0;
            // 
            // passportPage
            // 
            this.passportPage.Controls.Add(this.createRightholderPassportPageView);
            this.passportPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.passportPage.Location = new System.Drawing.Point(141, 5);
            this.passportPage.Name = "passportPage";
            this.passportPage.Size = new System.Drawing.Size(849, 427);
            this.passportPage.Text = "Паспортні дані";
            // 
            // createRightholderPassportPageView
            // 
            this.createRightholderPassportPageView.Controls.Add(this.pasportPage);
            this.createRightholderPassportPageView.Controls.Add(this.createRightholderForeignPassportPage);
            this.createRightholderPassportPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createRightholderPassportPageView.Location = new System.Drawing.Point(0, 0);
            this.createRightholderPassportPageView.Name = "createRightholderPassportPageView";
            this.createRightholderPassportPageView.SelectedPage = this.pasportPage;
            this.createRightholderPassportPageView.Size = new System.Drawing.Size(849, 427);
            this.createRightholderPassportPageView.TabIndex = 12;
            this.createRightholderPassportPageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.createRightholderPassportPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.createRightholderPassportPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            // 
            // pasportPage
            // 
            this.pasportPage.Controls.Add(this.radLabel6);
            this.pasportPage.Controls.Add(this.ctrlInternalPassport);
            this.pasportPage.Location = new System.Drawing.Point(31, 5);
            this.pasportPage.Name = "pasportPage";
            this.pasportPage.Size = new System.Drawing.Size(813, 417);
            this.pasportPage.Text = "createRightholderInternalPasportPage";
            // 
            // radLabel6
            // 
            this.radLabel6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel6.Location = new System.Drawing.Point(21, 3);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(134, 25);
            this.radLabel6.TabIndex = 9;
            this.radLabel6.Text = "Паспорт України";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // ctrlInternalPassport
            // 
            this.ctrlInternalPassport.DataSource = this.bsAnketaPerson;
            this.ctrlInternalPassport.Location = new System.Drawing.Point(7, 34);
            this.ctrlInternalPassport.MaximumSize = new System.Drawing.Size(410, 94);
            this.ctrlInternalPassport.Name = "ctrlInternalPassport";
            this.ctrlInternalPassport.Size = new System.Drawing.Size(410, 94);
            this.ctrlInternalPassport.TabIndex = 0;
            // 
            // createRightholderForeignPassportPage
            // 
            this.createRightholderForeignPassportPage.Controls.Add(this.ctrlInternationalPassport);
            this.createRightholderForeignPassportPage.Controls.Add(this.radLabel7);
            this.createRightholderForeignPassportPage.Location = new System.Drawing.Point(31, 5);
            this.createRightholderForeignPassportPage.Name = "createRightholderForeignPassportPage";
            this.createRightholderForeignPassportPage.Size = new System.Drawing.Size(813, 417);
            this.createRightholderForeignPassportPage.Text = "createRightholderForeignPassportPage";
            // 
            // ctrlInternationalPassport
            // 
            this.ctrlInternationalPassport.DataSource = this.bsAnketaPerson;
            this.ctrlInternationalPassport.Location = new System.Drawing.Point(9, 34);
            this.ctrlInternationalPassport.Name = "ctrlInternationalPassport";
            this.ctrlInternationalPassport.Size = new System.Drawing.Size(376, 78);
            this.ctrlInternationalPassport.TabIndex = 11;
            // 
            // radLabel7
            // 
            this.radLabel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel7.Location = new System.Drawing.Point(26, 3);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(175, 25);
            this.radLabel7.TabIndex = 10;
            this.radLabel7.Text = "Закордонний паспорт";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // managersPage
            // 
            this.managersPage.Controls.Add(this.ctrlMiddleControlManagers);
            this.managersPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.managersPage.Location = new System.Drawing.Point(141, 5);
            this.managersPage.Name = "managersPage";
            this.managersPage.Size = new System.Drawing.Size(849, 427);
            this.managersPage.Text = "Контакти";
            // 
            // ctrlMiddleControlManagers
            // 
            this.ctrlMiddleControlManagers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlMiddleControlManagers.Location = new System.Drawing.Point(3, 3);
            this.ctrlMiddleControlManagers.MaximumSize = new System.Drawing.Size(1200, 343);
            this.ctrlMiddleControlManagers.MinimumSize = new System.Drawing.Size(600, 343);
            this.ctrlMiddleControlManagers.Name = "ctrlMiddleControlManagers";
            this.ctrlMiddleControlManagers.Size = new System.Drawing.Size(846, 343);
            this.ctrlMiddleControlManagers.TabIndex = 0;
            // 
            // agreementPage
            // 
            this.agreementPage.Controls.Add(this.ctrlAgreementNumberDate);
            this.agreementPage.Controls.Add(this.ctrlServiceComissionControl);
            this.agreementPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.agreementPage.Location = new System.Drawing.Point(141, 5);
            this.agreementPage.Name = "agreementPage";
            this.agreementPage.Size = new System.Drawing.Size(849, 427);
            this.agreementPage.Text = "Договір";
            // 
            // ctrlAgreementNumberDate
            // 
            this.ctrlAgreementNumberDate.AgreementLabelType = ipsFormsDesign.Dictionary.TypeRights.SmallRights;
            this.ctrlAgreementNumberDate.AgreementName = "ДОГОВІР";
            this.ctrlAgreementNumberDate.DataSourceRh = this.bsAgreementAddRh;
            this.ctrlAgreementNumberDate.DateEndNullDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.ctrlAgreementNumberDate.DateEndNullText = "Не обмежено";
            this.ctrlAgreementNumberDate.DateTimeType = IpsViewComponentLibrary.Extensions.ConsumerAgreementInitType.None;
            this.ctrlAgreementNumberDate.Location = new System.Drawing.Point(187, 6);
            this.ctrlAgreementNumberDate.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgreementNumberDate.Name = "ctrlAgreementNumberDate";
            this.ctrlAgreementNumberDate.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgreementNumberDate.TabIndex = 14;
            // 
            // bsAgreementAddRh
            // 
            this.bsAgreementAddRh.DataSource = typeof(ipsFormsDesign.Model.AgreementAddRh);
            // 
            // ctrlServiceComissionControl
            // 
            this.ctrlServiceComissionControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlServiceComissionControl.DataSource = this.bsAgreementAddRh;
            this.ctrlServiceComissionControl.Location = new System.Drawing.Point(111, 82);
            this.ctrlServiceComissionControl.Name = "ctrlServiceComissionControl";
            this.ctrlServiceComissionControl.Size = new System.Drawing.Size(682, 104);
            this.ctrlServiceComissionControl.TabIndex = 6;
            // 
            // royaltyPage
            // 
            this.royaltyPage.Controls.Add(this.radLabel8);
            this.royaltyPage.Controls.Add(this.createRightholderRoyaltyPageView);
            this.royaltyPage.Controls.Add(this.ddlTypeMethodGet);
            this.royaltyPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.royaltyPage.Location = new System.Drawing.Point(141, 5);
            this.royaltyPage.Name = "royaltyPage";
            this.royaltyPage.Size = new System.Drawing.Size(849, 427);
            this.royaltyPage.Text = "Як отримувати роялті";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(41, 3);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(111, 19);
            this.radLabel8.TabIndex = 16;
            this.radLabel8.Text = "Метод отримання:";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // createRightholderRoyaltyPageView
            // 
            this.createRightholderRoyaltyPageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createRightholderRoyaltyPageView.Controls.Add(this.createRightholderRoyaltyBankPage);
            this.createRightholderRoyaltyPageView.Controls.Add(this.createRightholderRoyaltyCashPage);
            this.createRightholderRoyaltyPageView.Controls.Add(this.createRightholderRoyaltyPostalTransfer);
            this.createRightholderRoyaltyPageView.Location = new System.Drawing.Point(3, 29);
            this.createRightholderRoyaltyPageView.Name = "createRightholderRoyaltyPageView";
            this.createRightholderRoyaltyPageView.SelectedPage = this.createRightholderRoyaltyBankPage;
            this.createRightholderRoyaltyPageView.Size = new System.Drawing.Size(846, 398);
            this.createRightholderRoyaltyPageView.TabIndex = 15;
            this.createRightholderRoyaltyPageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.createRightholderRoyaltyPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.createRightholderRoyaltyPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            // 
            // createRightholderRoyaltyBankPage
            // 
            this.createRightholderRoyaltyBankPage.Controls.Add(this.ctrlBankAccount);
            this.createRightholderRoyaltyBankPage.Location = new System.Drawing.Point(31, 5);
            this.createRightholderRoyaltyBankPage.Name = "createRightholderRoyaltyBankPage";
            this.createRightholderRoyaltyBankPage.Size = new System.Drawing.Size(810, 388);
            this.createRightholderRoyaltyBankPage.Text = "createRightholderRoyaltyBankPage";
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.DataSource = this.bsBankAccount;
            this.ctrlBankAccount.Location = new System.Drawing.Point(3, 3);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(598, 127);
            this.ctrlBankAccount.TabIndex = 0;
            // 
            // bsBankAccount
            // 
            this.bsBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            // 
            // createRightholderRoyaltyCashPage
            // 
            this.createRightholderRoyaltyCashPage.Location = new System.Drawing.Point(31, 5);
            this.createRightholderRoyaltyCashPage.Name = "createRightholderRoyaltyCashPage";
            this.createRightholderRoyaltyCashPage.Size = new System.Drawing.Size(810, 388);
            this.createRightholderRoyaltyCashPage.Text = "createRightholderRoyaltyCash";
            // 
            // createRightholderRoyaltyPostalTransfer
            // 
            this.createRightholderRoyaltyPostalTransfer.Controls.Add(this.ctrlBaAddress);
            this.createRightholderRoyaltyPostalTransfer.Controls.Add(this.radLabel9);
            this.createRightholderRoyaltyPostalTransfer.Controls.Add(this.radLabel10);
            this.createRightholderRoyaltyPostalTransfer.Controls.Add(this.txtPostalIndex);
            this.createRightholderRoyaltyPostalTransfer.Location = new System.Drawing.Point(31, 5);
            this.createRightholderRoyaltyPostalTransfer.Name = "createRightholderRoyaltyPostalTransfer";
            this.createRightholderRoyaltyPostalTransfer.Size = new System.Drawing.Size(810, 388);
            this.createRightholderRoyaltyPostalTransfer.Text = "createRightholderRoyaltyPostalTransfer";
            // 
            // ctrlBaAddress
            // 
            this.ctrlBaAddress.AddressDataMember = "PAddress";
            this.ctrlBaAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBaAddress.CityDataMember = "PCity";
            this.ctrlBaAddress.CountryDataMember = "PCountry";
            this.ctrlBaAddress.DataSource = this.bsBankAccount;
            this.ctrlBaAddress.Location = new System.Drawing.Point(121, 37);
            this.ctrlBaAddress.Name = "ctrlBaAddress";
            this.ctrlBaAddress.RegionDataMember = "PRegion";
            this.ctrlBaAddress.Size = new System.Drawing.Size(686, 48);
            this.ctrlBaAddress.TabIndex = 20;
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(10, 13);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(107, 19);
            this.radLabel9.TabIndex = 17;
            this.radLabel9.Text = "Поштовий індекс:";
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(10, 37);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(50, 19);
            this.radLabel10.TabIndex = 18;
            this.radLabel10.Text = "Адреса:";
            this.radLabel10.ThemeName = "Office2013Light";
            // 
            // txtPostalIndex
            // 
            this.txtPostalIndex.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBankAccount, "PIndex", true));
            this.txtPostalIndex.Location = new System.Drawing.Point(122, 12);
            this.txtPostalIndex.Name = "txtPostalIndex";
            this.txtPostalIndex.Size = new System.Drawing.Size(100, 21);
            this.txtPostalIndex.TabIndex = 19;
            this.txtPostalIndex.ThemeName = "Office2013Light";
            // 
            // ddlTypeMethodGet
            // 
            this.ddlTypeMethodGet.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAgreementAddRh, "GetCode", true));
            this.ddlTypeMethodGet.Location = new System.Drawing.Point(156, 3);
            this.ddlTypeMethodGet.Name = "ddlTypeMethodGet";
            this.ddlTypeMethodGet.Size = new System.Drawing.Size(218, 21);
            this.ddlTypeMethodGet.TabIndex = 14;
            this.ddlTypeMethodGet.ThemeName = "Office2013Light";
            this.ddlTypeMethodGet.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlTypeMethodGet_SelectedIndexChanged);
            // 
            // rigthLimitationsPage
            // 
            this.rigthLimitationsPage.Controls.Add(this.ctrlRightLimitations);
            this.rigthLimitationsPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.rigthLimitationsPage.Location = new System.Drawing.Point(141, 5);
            this.rigthLimitationsPage.Name = "rigthLimitationsPage";
            this.rigthLimitationsPage.Size = new System.Drawing.Size(849, 427);
            this.rigthLimitationsPage.Text = "Передача прав";
            // 
            // ctrlRightLimitations
            // 
            this.ctrlRightLimitations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRightLimitations.DataSource = typeof(ipsFormsDesign.Dictionary.TermsOfServiceWrapper);
            this.ctrlRightLimitations.Location = new System.Drawing.Point(3, 3);
            this.ctrlRightLimitations.Name = "ctrlRightLimitations";
            this.ctrlRightLimitations.Size = new System.Drawing.Size(843, 421);
            this.ctrlRightLimitations.TabIndex = 14;
            // 
            // territoryLimitationsPage
            // 
            this.territoryLimitationsPage.Controls.Add(this.ctrlTerritoryIncludeExclude);
            this.territoryLimitationsPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.territoryLimitationsPage.Location = new System.Drawing.Point(141, 5);
            this.territoryLimitationsPage.Name = "territoryLimitationsPage";
            this.territoryLimitationsPage.Size = new System.Drawing.Size(849, 427);
            this.territoryLimitationsPage.Text = "Територїя";
            // 
            // ctrlTerritoryIncludeExclude
            // 
            this.ctrlTerritoryIncludeExclude.DataSource = this.bsRightHolder;
            this.ctrlTerritoryIncludeExclude.Location = new System.Drawing.Point(3, 3);
            this.ctrlTerritoryIncludeExclude.Name = "ctrlTerritoryIncludeExclude";
            this.ctrlTerritoryIncludeExclude.Size = new System.Drawing.Size(356, 421);
            this.ctrlTerritoryIncludeExclude.TabIndex = 50;
            // 
            // agreementPrintPage
            // 
            this.agreementPrintPage.Controls.Add(this.btnGenerateRightholderAgreement);
            this.agreementPrintPage.Controls.Add(this.radPdfViewerNavigator1);
            this.agreementPrintPage.Controls.Add(this.pdfvRightholderAgreement);
            this.agreementPrintPage.ItemSize = new System.Drawing.SizeF(137F, 27F);
            this.agreementPrintPage.Location = new System.Drawing.Point(141, 5);
            this.agreementPrintPage.Name = "agreementPrintPage";
            this.agreementPrintPage.Size = new System.Drawing.Size(849, 427);
            this.agreementPrintPage.Text = "Друк";
            // 
            // btnGenerateRightholderAgreement
            // 
            this.btnGenerateRightholderAgreement.Location = new System.Drawing.Point(4, 7);
            this.btnGenerateRightholderAgreement.Name = "btnGenerateRightholderAgreement";
            this.btnGenerateRightholderAgreement.Size = new System.Drawing.Size(110, 24);
            this.btnGenerateRightholderAgreement.TabIndex = 1;
            this.btnGenerateRightholderAgreement.Text = "Cформувати";
            this.btnGenerateRightholderAgreement.ThemeName = "Office2013Light";
            this.btnGenerateRightholderAgreement.Click += new System.EventHandler(this.btnGenerateRightholderAgreement_Click);
            // 
            // radPdfViewerNavigator1
            // 
            this.radPdfViewerNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPdfViewerNavigator1.AssociatedViewer = this.pdfvRightholderAgreement;
            this.radPdfViewerNavigator1.Enabled = false;
            this.radPdfViewerNavigator1.Location = new System.Drawing.Point(120, 0);
            this.radPdfViewerNavigator1.Name = "radPdfViewerNavigator1";
            this.radPdfViewerNavigator1.Size = new System.Drawing.Size(729, 0);
            this.radPdfViewerNavigator1.TabIndex = 10;
            this.radPdfViewerNavigator1.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.CommandBarRowElement)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Text = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).ToolTipText = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Text = "Print";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).ToolTipText = "Print";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(4))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).Text = "Rotate Counterclockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).ToolTipText = "Rotate Counterclockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).Text = "Rotate Clockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).ToolTipText = "Rotate Clockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(25))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(25))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(25))).Text = "Find next";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(25))).ToolTipText = "Find next";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(25))).Enabled = false;
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(25))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // pdfvRightholderAgreement
            // 
            this.pdfvRightholderAgreement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfvRightholderAgreement.Controls.Add(this.waitbarAgreement);
            this.pdfvRightholderAgreement.Location = new System.Drawing.Point(3, 45);
            this.pdfvRightholderAgreement.Name = "pdfvRightholderAgreement";
            this.pdfvRightholderAgreement.Size = new System.Drawing.Size(843, 379);
            this.pdfvRightholderAgreement.TabIndex = 0;
            this.pdfvRightholderAgreement.ThemeName = "Office2013Light";
            this.pdfvRightholderAgreement.ThumbnailsScaleFactor = 0.15F;
            // 
            // waitbarAgreement
            // 
            this.waitbarAgreement.AssociatedControl = this.pdfvRightholderAgreement;
            this.waitbarAgreement.Location = new System.Drawing.Point(391, 154);
            this.waitbarAgreement.Name = "waitbarAgreement";
            this.waitbarAgreement.Size = new System.Drawing.Size(70, 70);
            this.waitbarAgreement.TabIndex = 9;
            this.waitbarAgreement.Text = "radWaitingBar1";
            this.waitbarAgreement.ThemeName = "Office2013Light";
            this.waitbarAgreement.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.waitbarAgreement.WaitingSpeed = 50;
            this.waitbarAgreement.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitbarAgreement.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.waitbarAgreement.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.waitbarAgreement.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.Radius = 20;
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Controls.Add(this.sbSave);
            this.radPanel1.Controls.Add(this.ctrlPageSelector);
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radPanel1.Location = new System.Drawing.Point(0, 443);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(998, 31);
            this.radPanel1.TabIndex = 19;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // sbSave
            // 
            this.sbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbSave.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.miSave,
            this.miAcceptAndSave});
            this.sbSave.Location = new System.Drawing.Point(639, 4);
            this.sbSave.Name = "sbSave";
            this.sbSave.Size = new System.Drawing.Size(175, 24);
            this.sbSave.TabIndex = 53;
            this.sbSave.Text = "Зберегти";
            this.sbSave.ThemeName = "Office2013Light";
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Text = "Зберегти";
            this.miSave.UseCompatibleTextRendering = false;
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miAcceptAndSave
            // 
            this.miAcceptAndSave.Name = "miAcceptAndSave";
            this.miAcceptAndSave.Text = "Підтвердити та зберегти";
            this.miAcceptAndSave.UseCompatibleTextRendering = false;
            this.miAcceptAndSave.Click += new System.EventHandler(this.miAcceptAndSave_Click);
            // 
            // ctrlPageSelector
            // 
            this.ctrlPageSelector.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPageSelector.Location = new System.Drawing.Point(0, 1);
            this.ctrlPageSelector.Name = "ctrlPageSelector";
            this.ctrlPageSelector.RelatedPageView = this.mainPageView;
            this.ctrlPageSelector.Size = new System.Drawing.Size(362, 30);
            this.ctrlPageSelector.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(820, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"docx files (*.docx)|*.docx|pdf files (*.pdf)|*.pdf\"";
            // 
            // bsAnketaExternal
            // 
            this.bsAnketaExternal.DataSource = typeof(ipsFormsDesign.Model.Customer);
            // 
            // ctrlLeAddress
            // 
            this.ctrlLeAddress.AddressDataMember = "LeAddress";
            this.ctrlLeAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLeAddress.CityDataMember = "LeCity";
            this.ctrlLeAddress.CountryDataMember = "LeCountry";
            this.ctrlLeAddress.DataSource = this.bsAnketaPerson;
            this.ctrlLeAddress.Location = new System.Drawing.Point(137, 52);
            this.ctrlLeAddress.Name = "ctrlLeAddress";
            this.ctrlLeAddress.PostIndexDataMember = "LePostIndex";
            this.ctrlLeAddress.RegionDataMember = "LeRegion";
            this.ctrlLeAddress.Size = new System.Drawing.Size(699, 54);
            this.ctrlLeAddress.TabIndex = 31;
            // 
            // NewRightholderView
            // 
            this.AcceptButton = this.miSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(998, 474);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.mainPageView);
            this.Name = "NewRightholderView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "(Новий) - Анкета правовласника";
            this.ThemeName = "Office2013Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewRightholderView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).EndInit();
            this.mainPageView.ResumeLayout(false);
            this.rightholderPersonPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).EndInit();
            this.rightholderCompanyPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            this.contactsPersonPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyAddressReLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyAddressFaLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyAddressFaRe)).EndInit();
            this.contactsCompanyPage.ResumeLayout(false);
            this.passportPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.createRightholderPassportPageView)).EndInit();
            this.createRightholderPassportPageView.ResumeLayout(false);
            this.pasportPage.ResumeLayout(false);
            this.pasportPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            this.createRightholderForeignPassportPage.ResumeLayout(false);
            this.createRightholderForeignPassportPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            this.managersPage.ResumeLayout(false);
            this.agreementPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddRh)).EndInit();
            this.royaltyPage.ResumeLayout(false);
            this.royaltyPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createRightholderRoyaltyPageView)).EndInit();
            this.createRightholderRoyaltyPageView.ResumeLayout(false);
            this.createRightholderRoyaltyBankPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).EndInit();
            this.createRightholderRoyaltyPostalTransfer.ResumeLayout(false);
            this.createRightholderRoyaltyPostalTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypeMethodGet)).EndInit();
            this.rigthLimitationsPage.ResumeLayout(false);
            this.territoryLimitationsPage.ResumeLayout(false);
            this.agreementPrintPage.ResumeLayout(false);
            this.agreementPrintPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerateRightholderAgreement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfvRightholderAgreement)).EndInit();
            this.pdfvRightholderAgreement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waitbarAgreement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaExternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView mainPageView;
        private Telerik.WinControls.UI.RadPageViewPage rightholderPersonPage;
        private IpsViewComponentLibrary.RightholderControls.Anketa.ServiceComissionControl ctrlServiceComissionControl;
        private Telerik.WinControls.UI.RadPageViewPage contactsPersonPage;
        private ContactsPersonControl ctrlContacts;
        private Telerik.WinControls.UI.RadPageViewPage passportPage;
        private Telerik.WinControls.UI.RadPageView createRightholderPassportPageView;
        private Telerik.WinControls.UI.RadPageViewPage pasportPage;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private PassportControl ctrlInternalPassport;
        private Telerik.WinControls.UI.RadPageViewPage createRightholderForeignPassportPage;
        private PassportInternationalControl ctrlInternationalPassport;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadPageViewPage royaltyPage;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadPageView createRightholderRoyaltyPageView;
        private Telerik.WinControls.UI.RadPageViewPage createRightholderRoyaltyBankPage;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage createRightholderRoyaltyCashPage;
        private Telerik.WinControls.UI.RadPageViewPage createRightholderRoyaltyPostalTransfer;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadTextBox txtPostalIndex;
        private Telerik.WinControls.UI.RadDropDownList ddlTypeMethodGet;
        private Telerik.WinControls.UI.RadPageViewPage rigthLimitationsPage;
        private IpsViewComponentLibrary.RightholderControls.Anketa.RightLimitationsControl ctrlRightLimitations;
        private Telerik.WinControls.UI.RadPageViewPage territoryLimitationsPage;
        private IpsViewComponentLibrary.RightholderControls.Anketa.TerritoryIncludeExcludeControl ctrlTerritoryIncludeExclude;
        private Telerik.WinControls.UI.RadPageViewPage agreementPrintPage;
        private Telerik.WinControls.UI.RadButton btnGenerateRightholderAgreement;
        private Telerik.WinControls.UI.RadPdfViewer pdfvRightholderAgreement;
        private Telerik.WinControls.UI.RadWaitingBar waitbarAgreement;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Common.PageSelectorControl ctrlPageSelector;
        private Telerik.WinControls.UI.RadSplitButton sbSave;
        private Telerik.WinControls.UI.RadMenuItem miSave;
        private Telerik.WinControls.UI.RadMenuItem miAcceptAndSave;
        private ContractConsumerMainControl ctrlAgreementNumberDate;
        private System.Windows.Forms.BindingSource bsAgreementAddRh;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private IpsAddressControl ctrlBaAddress;
        private System.Windows.Forms.BindingSource bsBankAccount;
        private System.Windows.Forms.BindingSource bsCustomer;
        private System.Windows.Forms.BindingSource bsRightHolder;
        private Telerik.WinControls.UI.RadPageViewPage agreementPage;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private IpsAddressControl ctrlFaAddress;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadButton btnCopyAddressReLe;
        private Telerik.WinControls.UI.RadButton btnCopyAddressFaLe;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnCopyAddressFaRe;
        private IpsAddressControl ctrlReAddress;
        private Telerik.WinControls.UI.RadPageViewPage rightholderCompanyPage;
        private Anketa.AnketaCompanyRightholderPage ctrlAnketaCompanyRightholderPage;
        private System.Windows.Forms.BindingSource bsAnketaCompany;
        private Anketa.AnketaPersonRightholderPage ctrlAnketaPersonRightholderPage;
        private Telerik.WinControls.UI.RadPageViewPage contactsCompanyPage;
        private JuridicalAddressControl ctrlMiddleControlAddress;
        private Telerik.WinControls.UI.RadPageViewPage managersPage;
        private JuridicalManagersControl ctrlMiddleControlManagers;
        private Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigator1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource bsAnketaExternal;
        private AddressLetter ctrlLeAddress;
    }
}
