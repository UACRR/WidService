namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class PartnerPhisForm
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvPartnerName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPartnerName = new IpsViewComponentLibrary.PartnerControls.PartnerNameControl();
            this.pvContact = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAddressLetter = new IpsViewComponentLibrary.AddressLetter();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAddressRegister = new IpsViewComponentLibrary.IpsAddressControl();
            this.ctrlAddressLive = new IpsViewComponentLibrary.IpsAddressControl();
            this.ctrlContacts = new DebugFormForControls.ContactsPersonControl();
            this.pvPasport = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.ctrlInternalPassport = new IpsViewComponentLibrary.PassportControl();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.IpsBankAccountControl();
            this.bsBankAccount = new System.Windows.Forms.BindingSource(this.components);
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgreement = new IpsViewComponentLibrary.PartnerControls.AgreementPartnerControl();
            this.pvTerms = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlTabNavigation = new IpsViewComponentLibrary.ConsumerControls.TabNavigationControl();
            this.ctrlConditions = new IpsViewComponentLibrary.PartnerControls.ConditionsControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvPartnerName.SuspendLayout();
            this.pvContact.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).BeginInit();
            this.pvAgreement.SuspendLayout();
            this.pvTerms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
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
            this.pageView.Size = new System.Drawing.Size(1000, 567);
            this.pageView.TabIndex = 10;
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
            this.pvPartnerName.Size = new System.Drawing.Size(861, 557);
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
            this.pvContact.Size = new System.Drawing.Size(861, 557);
            this.pvContact.Text = "Контакти";
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
            this.ctrlAddressLetter.Location = new System.Drawing.Point(152, 116);
            this.ctrlAddressLetter.Name = "ctrlAddressLetter";
            this.ctrlAddressLetter.PostIndexDataMember = null;
            this.ctrlAddressLetter.RegionDataMember = null;
            this.ctrlAddressLetter.RegionsDataMember = "";
            this.ctrlAddressLetter.RegionsDataSource = null;
            this.ctrlAddressLetter.RegionsDisplayMember = "";
            this.ctrlAddressLetter.RegionsValueMember = "";
            this.ctrlAddressLetter.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLetter.TabIndex = 39;
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
            this.radLabel3.Location = new System.Drawing.Point(24, 116);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(114, 19);
            this.radLabel3.TabIndex = 38;
            this.radLabel3.Text = "Адреса листування";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(24, 62);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(108, 19);
            this.radLabel2.TabIndex = 37;
            this.radLabel2.Text = "Адреса реєстрації";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(24, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(122, 19);
            this.radLabel1.TabIndex = 36;
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
            this.ctrlAddressRegister.Location = new System.Drawing.Point(152, 62);
            this.ctrlAddressRegister.Name = "ctrlAddressRegister";
            this.ctrlAddressRegister.RegionDataMember = null;
            this.ctrlAddressRegister.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressRegister.TabIndex = 34;
            // 
            // ctrlAddressLive
            // 
            this.ctrlAddressLive.AddressDataMember = null;
            this.ctrlAddressLive.CityDataMember = null;
            this.ctrlAddressLive.CountryDataMember = null;
            this.ctrlAddressLive.DataMember = "";
            this.ctrlAddressLive.DataSource = null;
            this.ctrlAddressLive.Location = new System.Drawing.Point(152, 8);
            this.ctrlAddressLive.Name = "ctrlAddressLive";
            this.ctrlAddressLive.RegionDataMember = null;
            this.ctrlAddressLive.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLive.TabIndex = 33;
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlContacts.Location = new System.Drawing.Point(29, 184);
            this.ctrlContacts.MaximumSize = new System.Drawing.Size(625, 50);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(625, 50);
            this.ctrlContacts.TabIndex = 35;
            // 
            // pvPasport
            // 
            this.pvPasport.Controls.Add(this.radGroupBox3);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(134, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(861, 557);
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
            this.pvBank.Size = new System.Drawing.Size(861, 557);
            this.pvBank.Text = "Банківські реквізити";
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.DataSource = this.bsBankAccount;
            this.ctrlBankAccount.Location = new System.Drawing.Point(22, 6);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(409, 127);
            this.ctrlBankAccount.TabIndex = 0;
            // 
            // bsBankAccount
            // 
            this.bsBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            // 
            // pvAgreement
            // 
            this.pvAgreement.Controls.Add(this.ctrlAgreement);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(861, 557);
            this.pvAgreement.Text = "Договір";
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.Location = new System.Drawing.Point(22, 6);
            this.ctrlAgreement.MaximumSize = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.MinimumSize = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.TabIndex = 0;
            // 
            // pvTerms
            // 
            this.pvTerms.Controls.Add(this.ctrlConditions);
            this.pvTerms.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvTerms.Location = new System.Drawing.Point(134, 5);
            this.pvTerms.Name = "pvTerms";
            this.pvTerms.Size = new System.Drawing.Size(861, 557);
            this.pvTerms.Text = "Умои представника";
            // 
            // ctrlTabNavigation
            // 
            this.ctrlTabNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigation.Location = new System.Drawing.Point(0, 567);
            this.ctrlTabNavigation.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigation.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigation.Name = "ctrlTabNavigation";
            this.ctrlTabNavigation.Size = new System.Drawing.Size(1000, 31);
            this.ctrlTabNavigation.TabIndex = 11;
            // 
            // ctrlConditions
            // 
            this.ctrlConditions.AgreementAddPartnerDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlConditions.Location = new System.Drawing.Point(22, 6);
            this.ctrlConditions.Name = "ctrlConditions";
            this.ctrlConditions.Size = new System.Drawing.Size(702, 357);
            this.ctrlConditions.TabIndex = 0;
            // 
            // PartnerPhisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 598);
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.ctrlTabNavigation);
            this.Name = "PartnerPhisForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Анкета представника (фізична особа)";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
            this.pvContact.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).EndInit();
            this.pvAgreement.ResumeLayout(false);
            this.pvTerms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerName;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private Telerik.WinControls.UI.RadPageViewPage pvTerms;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvPasport;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private PassportControl ctrlInternalPassport;
        private PartnerControls.PartnerNameControl ctrlPartnerName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
        private AddressLetter ctrlAddressLetter;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private IpsAddressControl ctrlAddressRegister;
        private IpsAddressControl ctrlAddressLive;
        private DebugFormForControls.ContactsPersonControl ctrlContacts;
        private ConsumerControls.TabNavigationControl ctrlTabNavigation;
        private System.Windows.Forms.BindingSource bsBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private PartnerControls.AgreementPartnerControl ctrlAgreement;
        private PartnerControls.ConditionsControl ctrlConditions;
    }
}
