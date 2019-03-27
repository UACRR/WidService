using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class PartnerCabinetAnketaPhisControl
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
            this.pageViewAnketa = new Telerik.WinControls.UI.RadPageView();
            this.pvPartnerName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPartnerName = new IpsViewComponentLibrary.PartnerControls.PartnerNameControl();
            this.pvContact = new Telerik.WinControls.UI.RadPageViewPage();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.btnCopyFromRegToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToReg = new Telerik.WinControls.UI.RadButton();
            this.ctrlAddressLetter = new IpsViewComponentLibrary.Shared.Controls.AddressLetter();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAddressRegister = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.ctrlAddressLive = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.ctrlContacts = new IpsViewComponentLibrary.Shared.Controls.ContactsPersonControl();
            this.pvPasport = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.ctrlInternalPassport = new IpsViewComponentLibrary.Shared.Controls.PassportControl();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.ctrlSaveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageViewAnketa)).BeginInit();
            this.pageViewAnketa.SuspendLayout();
            this.pvPartnerName.SuspendLayout();
            this.pvContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
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
            this.SuspendLayout();
            // 
            // pageViewAnketa
            // 
            this.pageViewAnketa.Controls.Add(this.pvPartnerName);
            this.pageViewAnketa.Controls.Add(this.pvContact);
            this.pageViewAnketa.Controls.Add(this.pvPasport);
            this.pageViewAnketa.Controls.Add(this.pvBank);
            this.pageViewAnketa.DefaultPage = this.pvPartnerName;
            this.pageViewAnketa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageViewAnketa.Location = new System.Drawing.Point(0, 0);
            this.pageViewAnketa.Name = "pageViewAnketa";
            this.pageViewAnketa.SelectedPage = this.pvPartnerName;
            this.pageViewAnketa.Size = new System.Drawing.Size(963, 463);
            this.pageViewAnketa.TabIndex = 12;
            this.pageViewAnketa.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvPartnerName
            // 
            this.pvPartnerName.Controls.Add(this.ctrlPartnerName);
            this.pvPartnerName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPartnerName.Location = new System.Drawing.Point(134, 5);
            this.pvPartnerName.Name = "pvPartnerName";
            this.pvPartnerName.Size = new System.Drawing.Size(824, 453);
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
            this.pvContact.Controls.Add(this.radSeparator3);
            this.pvContact.Controls.Add(this.radSeparator1);
            this.pvContact.Controls.Add(this.radSeparator2);
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
            this.pvContact.Size = new System.Drawing.Size(824, 453);
            this.pvContact.Text = "Контакти";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator3.Location = new System.Drawing.Point(152, 191);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(669, 19);
            this.radSeparator3.TabIndex = 46;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(150, 87);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(671, 19);
            this.radSeparator1.TabIndex = 45;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // radSeparator2
            // 
            this.radSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator2.Location = new System.Drawing.Point(152, 8);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(669, 19);
            this.radSeparator2.TabIndex = 44;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // btnCopyFromRegToLett
            // 
            this.btnCopyFromRegToLett.Location = new System.Drawing.Point(370, 216);
            this.btnCopyFromRegToLett.Name = "btnCopyFromRegToLett";
            this.btnCopyFromRegToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromRegToLett.TabIndex = 42;
            this.btnCopyFromRegToLett.Text = "Копіювати з адреси реєстрації";
            this.btnCopyFromRegToLett.ThemeName = "Office2013Light";
            this.btnCopyFromRegToLett.Click += new System.EventHandler(this.btnCopyFromRegToLett_Click);
            // 
            // btnCopyFromLiveToLett
            // 
            this.btnCopyFromLiveToLett.Location = new System.Drawing.Point(164, 216);
            this.btnCopyFromLiveToLett.Name = "btnCopyFromLiveToLett";
            this.btnCopyFromLiveToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToLett.TabIndex = 41;
            this.btnCopyFromLiveToLett.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToLett.ThemeName = "Office2013Light";
            this.btnCopyFromLiveToLett.Click += new System.EventHandler(this.btnCopyFromLiveToLett_Click);
            // 
            // btnCopyFromLiveToReg
            // 
            this.btnCopyFromLiveToReg.Location = new System.Drawing.Point(164, 112);
            this.btnCopyFromLiveToReg.Name = "btnCopyFromLiveToReg";
            this.btnCopyFromLiveToReg.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToReg.TabIndex = 40;
            this.btnCopyFromLiveToReg.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToReg.ThemeName = "Office2013Light";
            this.btnCopyFromLiveToReg.Click += new System.EventHandler(this.btnCopyFromLiveToReg_Click);
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
            this.ctrlAddressLetter.Location = new System.Drawing.Point(164, 241);
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
            this.radLabel3.Location = new System.Drawing.Point(24, 191);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(114, 19);
            this.radLabel3.TabIndex = 38;
            this.radLabel3.Text = "Адреса листування";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(24, 87);
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
            this.ctrlAddressRegister.Location = new System.Drawing.Point(164, 137);
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
            this.ctrlAddressLive.Location = new System.Drawing.Point(164, 33);
            this.ctrlAddressLive.Name = "ctrlAddressLive";
            this.ctrlAddressLive.RegionDataMember = null;
            this.ctrlAddressLive.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLive.TabIndex = 33;
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlContacts.Location = new System.Drawing.Point(41, 295);
            this.ctrlContacts.MaximumSize = new System.Drawing.Size(625, 50);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(625, 50);
            this.ctrlContacts.TabIndex = 35;
            // 
            // pvPasport
            // 
            this.pvPasport.Controls.Add(this.radGroupBox3);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(137, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(923, 469);
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
            this.pvBank.Location = new System.Drawing.Point(137, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(923, 469);
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
            // ctrlSaveCancel
            // 
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 463);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.Size = new System.Drawing.Size(963, 31);
            this.ctrlSaveCancel.TabIndex = 13;
            // 
            // PartnerCabinetAnketaPhisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageViewAnketa);
            this.Controls.Add(this.ctrlSaveCancel);
            this.Name = "PartnerCabinetAnketaPhisControl";
            this.Size = new System.Drawing.Size(963, 494);
            ((System.ComponentModel.ISupportInitialize)(this.pageViewAnketa)).EndInit();
            this.pageViewAnketa.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
            this.pvContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageViewAnketa;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerName;
        private PartnerNameControl ctrlPartnerName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
        private Telerik.WinControls.UI.RadSeparator radSeparator3;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadSeparator radSeparator2;
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
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
    }
}
