using IpsViewComponentLibrary.ExtensionControls;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class PartnerAnketaPhisControl
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
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvPartnerName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPartnerName = new IpsViewComponentLibrary.PartnerControls.PartnerNameControl();
            this.pvContact = new Telerik.WinControls.UI.RadPageViewPage();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.btnCopyFromRegToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToReg = new Telerik.WinControls.UI.RadButton();
            this.ctrlAddressLetter = new IpsViewComponentLibrary.AddressLetter();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAddressRegister = new IpsViewComponentLibrary.IpsAddressControl();
            this.ctrlAddressLive = new IpsViewComponentLibrary.IpsAddressControl();
            this.ctrlContacts = new ContactsPersonControl();
            this.pvPasport = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.ctrlInternalPassport = new IpsViewComponentLibrary.PassportControl();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsBankAccountControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.checkPartnerInternal = new Telerik.WinControls.UI.RadCheckBox();
            this.bsPartner = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgreement = new IpsViewComponentLibrary.PartnerControls.AgreementPartnerControl();
            this.pvTerms = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlConditions = new IpsViewComponentLibrary.PartnerControls.ConditionsControl();
            this.ctrlTabNavigationExpanded = new TabNavigationExpandedControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvPartnerName.SuspendLayout();
            this.pvContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtPostIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.pvPasport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            this.pvBank.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPartnerInternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartner)).BeginInit();
            this.pvTerms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvPartnerName);
            this.pageView.Controls.Add(this.pvContact);
            this.pageView.Controls.Add(this.pvPasport);
            this.pageView.Controls.Add(this.pvBank);
            this.pageView.Controls.Add(this.pvAgreement);
            this.pageView.Controls.Add(this.pvTerms);
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvPartnerName;
            this.pageView.Size = new System.Drawing.Size(934, 556);
            this.pageView.TabIndex = 12;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvPartnerName
            // 
            this.pvPartnerName.Controls.Add(this.ctrlPartnerName);
            this.pvPartnerName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPartnerName.Location = new System.Drawing.Point(134, 5);
            this.pvPartnerName.Name = "pvPartnerName";
            this.pvPartnerName.Size = new System.Drawing.Size(795, 546);
            this.pvPartnerName.Text = "Представник";
            // 
            // ctrlPartnerName
            // 
            this.ctrlPartnerName.DataSourceAnketa = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlPartnerName.Location = new System.Drawing.Point(22, 6);
            this.ctrlPartnerName.Name = "ctrlPartnerName";
            this.ctrlPartnerName.Size = new System.Drawing.Size(689, 157);
            this.ctrlPartnerName.TabIndex = 33;
            // 
            // pvContact
            // 
            this.pvContact.Controls.Add(this.radSeparator2);
            this.pvContact.Controls.Add(this.radSeparator3);
            this.pvContact.Controls.Add(this.radSeparator1);
            this.pvContact.Controls.Add(this.btnCopyFromRegToLett);
            this.pvContact.Controls.Add(this.btnCopyFromLiveToLett);
            this.pvContact.Controls.Add(this.btnCopyFromLiveToReg);
            this.pvContact.Controls.Add(this.ctrlAddressLetter);
            this.pvContact.Controls.Add(this.radLabel3);
            this.pvContact.Controls.Add(this.radLabel2);
            this.pvContact.Controls.Add(this.radLabel1);
            this.pvContact.Controls.Add(this.ctrlAddressRegister);
            this.pvContact.Controls.Add(this.ctrlAddressLive);
            this.pvContact.Controls.Add(this.ctrlContacts);
            this.pvContact.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvContact.Location = new System.Drawing.Point(134, 5);
            this.pvContact.Name = "pvContact";
            this.pvContact.Size = new System.Drawing.Size(795, 546);
            this.pvContact.Text = "Контакти";
            // 
            // radSeparator2
            // 
            this.radSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator2.Location = new System.Drawing.Point(152, 8);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(636, 18);
            this.radSeparator2.TabIndex = 57;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator3.Location = new System.Drawing.Point(144, 190);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(644, 19);
            this.radSeparator3.TabIndex = 59;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(138, 86);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(650, 19);
            this.radSeparator1.TabIndex = 58;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // btnCopyFromRegToLett
            // 
            this.btnCopyFromRegToLett.Location = new System.Drawing.Point(360, 215);
            this.btnCopyFromRegToLett.Name = "btnCopyFromRegToLett";
            this.btnCopyFromRegToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromRegToLett.TabIndex = 56;
            this.btnCopyFromRegToLett.Text = "Копіювати з адреси реєстрації";
            this.btnCopyFromRegToLett.ThemeName = "Office2013Light";
            // 
            // btnCopyFromLiveToLett
            // 
            this.btnCopyFromLiveToLett.Location = new System.Drawing.Point(154, 215);
            this.btnCopyFromLiveToLett.Name = "btnCopyFromLiveToLett";
            this.btnCopyFromLiveToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToLett.TabIndex = 55;
            this.btnCopyFromLiveToLett.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToLett.ThemeName = "Office2013Light";
            // 
            // btnCopyFromLiveToReg
            // 
            this.btnCopyFromLiveToReg.Location = new System.Drawing.Point(154, 111);
            this.btnCopyFromLiveToReg.Name = "btnCopyFromLiveToReg";
            this.btnCopyFromLiveToReg.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToReg.TabIndex = 54;
            this.btnCopyFromLiveToReg.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToReg.ThemeName = "Office2013Light";
            // 
            // ctrlAddressLetter
            // 
            this.ctrlAddressLetter.AddressDataMember = null;
            this.ctrlAddressLetter.CityDataMember = null;
            this.ctrlAddressLetter.CountriesDataMember = "";
            this.ctrlAddressLetter.CountriesDataSource = null;
            this.ctrlAddressLetter.CountriesDisplayMember = "";
            this.ctrlAddressLetter.CountriesValueMember = "";
            this.ctrlAddressLetter.CountryDataMember = null;
            this.ctrlAddressLetter.DataMember = "";
            this.ctrlAddressLetter.DataSource = null;
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddressLetter.DdlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ctrlAddressLetter.DdlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ctrlAddressLetter.DdlCountry.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddressLetter.DdlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.DdlCountry.Name = "ddlCountry";
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 234, 20);
            this.ctrlAddressLetter.DdlCountry.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.DdlCountry.Size = new System.Drawing.Size(190, 20);
            this.ctrlAddressLetter.DdlCountry.TabIndex = 0;
            this.ctrlAddressLetter.DdlCountry.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddressLetter.DdlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ctrlAddressLetter.DdlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ctrlAddressLetter.DdlRegion.Location = new System.Drawing.Point(210, 0);
            this.ctrlAddressLetter.DdlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.DdlRegion.Name = "ddlRegion";
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(254, 0, 234, 20);
            this.ctrlAddressLetter.DdlRegion.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.DdlRegion.Size = new System.Drawing.Size(190, 20);
            this.ctrlAddressLetter.DdlRegion.TabIndex = 1;
            this.ctrlAddressLetter.DdlRegion.ThemeName = "Office2013Light";
            this.ctrlAddressLetter.Location = new System.Drawing.Point(154, 240);
            this.ctrlAddressLetter.Name = "ctrlAddressLetter";
            this.ctrlAddressLetter.PostIndexDataMember = null;
            this.ctrlAddressLetter.RegionDataMember = null;
            this.ctrlAddressLetter.RegionsDataMember = "";
            this.ctrlAddressLetter.RegionsDataSource = null;
            this.ctrlAddressLetter.RegionsDisplayMember = "";
            this.ctrlAddressLetter.RegionsValueMember = "";
            this.ctrlAddressLetter.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLetter.TabIndex = 53;
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtAddress.Location = new System.Drawing.Point(0, 25);
            this.ctrlAddressLetter.TxtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.TxtAddress.Name = "txtAddress";
            this.ctrlAddressLetter.TxtAddress.NullText = "Адреса";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 100, 14);
            this.ctrlAddressLetter.TxtAddress.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.TxtAddress.Size = new System.Drawing.Size(400, 20);
            this.ctrlAddressLetter.TxtAddress.TabIndex = 5;
            this.ctrlAddressLetter.TxtAddress.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddressLetter.TxtCity.Location = new System.Drawing.Point(420, 0);
            this.ctrlAddressLetter.TxtCity.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.TxtCity.Name = "txtCity";
            this.ctrlAddressLetter.TxtCity.NullText = "Місто";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtCity.RootElement.ControlBounds = new System.Drawing.Rectangle(420, 0, 192, 20);
            this.ctrlAddressLetter.TxtCity.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.TxtCity.Size = new System.Drawing.Size(192, 20);
            this.ctrlAddressLetter.TxtCity.TabIndex = 2;
            this.ctrlAddressLetter.TxtCity.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtPostIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddressLetter.TxtPostIndex.Location = new System.Drawing.Point(420, 25);
            this.ctrlAddressLetter.TxtPostIndex.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.TxtPostIndex.Name = "txtPostIndex";
            this.ctrlAddressLetter.TxtPostIndex.NullText = "Поштовий індекс";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtPostIndex.RootElement.ControlBounds = new System.Drawing.Rectangle(420, 25, 192, 20);
            this.ctrlAddressLetter.TxtPostIndex.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.TxtPostIndex.Size = new System.Drawing.Size(192, 20);
            this.ctrlAddressLetter.TxtPostIndex.TabIndex = 4;
            this.ctrlAddressLetter.TxtPostIndex.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(24, 190);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(114, 19);
            this.radLabel3.TabIndex = 52;
            this.radLabel3.Text = "Адреса листування";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(24, 86);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(108, 19);
            this.radLabel2.TabIndex = 51;
            this.radLabel2.Text = "Адреса реєстрації";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(24, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(122, 19);
            this.radLabel1.TabIndex = 50;
            this.radLabel1.Text = "Адреса проживання";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ctrlAddressRegister
            // 
            this.ctrlAddressRegister.AddressDataMember = null;
            this.ctrlAddressRegister.CityDataMember = null;
            this.ctrlAddressRegister.CountryDataMember = null;
            this.ctrlAddressRegister.DataMember = "";
            this.ctrlAddressRegister.DataSource = null;
            this.ctrlAddressRegister.Location = new System.Drawing.Point(154, 136);
            this.ctrlAddressRegister.Name = "ctrlAddressRegister";
            this.ctrlAddressRegister.RegionDataMember = null;
            this.ctrlAddressRegister.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressRegister.TabIndex = 48;
            // 
            // ctrlAddressLive
            // 
            this.ctrlAddressLive.AddressDataMember = null;
            this.ctrlAddressLive.CityDataMember = null;
            this.ctrlAddressLive.CountryDataMember = null;
            this.ctrlAddressLive.DataMember = "";
            this.ctrlAddressLive.DataSource = null;
            this.ctrlAddressLive.Location = new System.Drawing.Point(154, 32);
            this.ctrlAddressLive.Name = "ctrlAddressLive";
            this.ctrlAddressLive.RegionDataMember = null;
            this.ctrlAddressLive.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLive.TabIndex = 47;
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlContacts.Location = new System.Drawing.Point(31, 294);
            this.ctrlContacts.MaximumSize = new System.Drawing.Size(625, 50);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(625, 50);
            this.ctrlContacts.TabIndex = 49;
            // 
            // pvPasport
            // 
            this.pvPasport.Controls.Add(this.radGroupBox3);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(134, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(795, 546);
            this.pvPasport.Text = "Паспортні дані";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.ctrlInternalPassport);
            this.radGroupBox3.HeaderText = "Паспорт";
            this.radGroupBox3.Location = new System.Drawing.Point(24, 8);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(420, 120);
            this.radGroupBox3.TabIndex = 37;
            this.radGroupBox3.Text = "Паспорт";
            this.radGroupBox3.ThemeName = "Office2013Light";
            // 
            // ctrlInternalPassport
            // 
            this.ctrlInternalPassport.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlInternalPassport.Location = new System.Drawing.Point(5, 21);
            this.ctrlInternalPassport.MaximumSize = new System.Drawing.Size(410, 94);
            this.ctrlInternalPassport.Name = "ctrlInternalPassport";
            this.ctrlInternalPassport.Size = new System.Drawing.Size(410, 94);
            this.ctrlInternalPassport.TabIndex = 24;
            // 
            // pvBank
            // 
            this.pvBank.Controls.Add(this.ctrlBankAccount);
            this.pvBank.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBank.Location = new System.Drawing.Point(134, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(795, 546);
            this.pvBank.Text = "Банківські реквізити";
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            this.ctrlBankAccount.Location = new System.Drawing.Point(22, 6);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(409, 127);
            this.ctrlBankAccount.TabIndex = 0;
            // 
            // pvAgreement
            // 
            this.pvAgreement.Controls.Add(this.checkPartnerInternal);
            this.pvAgreement.Controls.Add(this.ctrlAgreement);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(795, 546);
            this.pvAgreement.Text = "Договір";
            // 
            // checkPartnerInternal
            // 
            this.checkPartnerInternal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsPartner, "IsMy", true));
            this.checkPartnerInternal.Location = new System.Drawing.Point(32, 152);
            this.checkPartnerInternal.Name = "checkPartnerInternal";
            this.checkPartnerInternal.Size = new System.Drawing.Size(233, 19);
            this.checkPartnerInternal.TabIndex = 1;
            this.checkPartnerInternal.Text = "Представник - співробітник компанії";
            this.checkPartnerInternal.ThemeName = "Office2013Light";
            // 
            // bsPartner
            // 
            this.bsPartner.DataSource = typeof(ipsFormsDesign.Model.Partner);
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementCommunityDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.Location = new System.Drawing.Point(22, 6);
            this.ctrlAgreement.MaximumSize = new System.Drawing.Size(504, 140);
            this.ctrlAgreement.MinimumSize = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(484, 140);
            this.ctrlAgreement.TabIndex = 0;
            // 
            // pvTerms
            // 
            this.pvTerms.Controls.Add(this.ctrlConditions);
            this.pvTerms.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvTerms.Location = new System.Drawing.Point(134, 5);
            this.pvTerms.Name = "pvTerms";
            this.pvTerms.Size = new System.Drawing.Size(795, 546);
            this.pvTerms.Text = "Умои представника";
            // 
            // ctrlConditions
            // 
            this.ctrlConditions.AgreementAddPartnerDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlConditions.Location = new System.Drawing.Point(22, 6);
            this.ctrlConditions.Name = "ctrlConditions";
            this.ctrlConditions.Size = new System.Drawing.Size(702, 357);
            this.ctrlConditions.TabIndex = 0;
            // 
            // ctrlTabNavigationExpanded
            // 
            this.ctrlTabNavigationExpanded.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigationExpanded.Location = new System.Drawing.Point(0, 556);
            this.ctrlTabNavigationExpanded.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigationExpanded.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigationExpanded.Name = "ctrlTabNavigationExpanded";
            this.ctrlTabNavigationExpanded.Size = new System.Drawing.Size(934, 31);
            this.ctrlTabNavigationExpanded.TabIndex = 13;
            // 
            // PartnerAnketaPhisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.ctrlTabNavigationExpanded);
            this.Name = "PartnerAnketaPhisControl";
            this.Size = new System.Drawing.Size(934, 587);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
            this.pvContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtPostIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.pvPasport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.pvBank.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            this.pvAgreement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPartnerInternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartner)).EndInit();
            this.pvTerms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerName;
        private PartnerNameControl ctrlPartnerName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
        private Telerik.WinControls.UI.RadSeparator radSeparator2;
        private Telerik.WinControls.UI.RadSeparator radSeparator3;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadButton btnCopyFromRegToLett;
        private Telerik.WinControls.UI.RadButton btnCopyFromLiveToLett;
        private Telerik.WinControls.UI.RadButton btnCopyFromLiveToReg;
        private AddressLetter ctrlAddressLetter;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private IpsAddressControl ctrlAddressRegister;
        private IpsAddressControl ctrlAddressLive;
        private ContactsPersonControl ctrlContacts;
        private Telerik.WinControls.UI.RadPageViewPage pvPasport;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private PassportControl ctrlInternalPassport;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private AgreementPartnerControl ctrlAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvTerms;
        private ConditionsControl ctrlConditions;
        private TabNavigationExpandedControl ctrlTabNavigationExpanded;
        private Telerik.WinControls.UI.RadCheckBox checkPartnerInternal;
        private System.Windows.Forms.BindingSource bsPartner;
    }
}
