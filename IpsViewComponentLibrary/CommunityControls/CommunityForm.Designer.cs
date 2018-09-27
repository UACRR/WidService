namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityForm
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvCommunityName = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlContactPerson = new IpsViewComponentLibrary.IpsBossNameContactsControl();
            this.ctrlClientName = new IpsViewComponentLibrary.IpsAnketaCompanyControl();
            this.pvAddress = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAddressLe = new IpsViewComponentLibrary.CommunityControls.CommunityAddressLetterControl();
            this.btnCopyFromLiveToReg = new Telerik.WinControls.UI.RadButton();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.btnCopyFromRegToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToLett = new Telerik.WinControls.UI.RadButton();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.ctrlAddressFa = new IpsViewComponentLibrary.CommunityControls.CommunityAddressControl();
            this.ctrlAddressJu = new IpsViewComponentLibrary.CommunityControls.CommunityAddressControl();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.IpsBankAccountControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlTabNavigation = new IpsViewComponentLibrary.ConsumerControls.TabNavigationControl();
            this.ctrlAgreement = new IpsViewComponentLibrary.CommunityControls.CommunityAgreementControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvCommunityName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtSurName)).BeginInit();
            this.pvAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            this.pvBank.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvCommunityName);
            this.pageView.Controls.Add(this.pvAddress);
            this.pageView.Controls.Add(this.pvBank);
            this.pageView.Controls.Add(this.pvAgreement);
            this.pageView.DefaultPage = this.pvCommunityName;
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvCommunityName;
            this.pageView.Size = new System.Drawing.Size(1011, 508);
            this.pageView.TabIndex = 12;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvCommunityName
            // 
            this.pvCommunityName.Controls.Add(this.radLabel6);
            this.pvCommunityName.Controls.Add(this.ctrlContactPerson);
            this.pvCommunityName.Controls.Add(this.ctrlClientName);
            this.pvCommunityName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvCommunityName.Location = new System.Drawing.Point(134, 5);
            this.pvCommunityName.Name = "pvCommunityName";
            this.pvCommunityName.Size = new System.Drawing.Size(872, 498);
            this.pvCommunityName.Text = "Спільнота";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(24, 62);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(104, 19);
            this.radLabel6.TabIndex = 3;
            this.radLabel6.Text = "Контактна особа:";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.DataSource = typeof(ipsFormsDesign.Interfaces.IEmployee);
            this.ctrlContactPerson.Location = new System.Drawing.Point(21, 87);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.Size = new System.Drawing.Size(600, 56);
            this.ctrlContactPerson.TabIndex = 2;
            // 
            // 
            // 
            this.ctrlContactPerson.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlContactPerson.TxtEmail.Location = new System.Drawing.Point(425, 35);
            this.ctrlContactPerson.TxtEmail.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlContactPerson.TxtEmail.Name = "txtEmail";
            this.ctrlContactPerson.TxtEmail.NullText = "#####@####.##";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtEmail.RootElement.ControlBounds = new System.Drawing.Rectangle(425, 36, 175, 20);
            this.ctrlContactPerson.TxtEmail.RootElement.StretchVertically = true;
            this.ctrlContactPerson.TxtEmail.Size = new System.Drawing.Size(175, 21);
            this.ctrlContactPerson.TxtEmail.TabIndex = 4;
            this.ctrlContactPerson.TxtEmail.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlContactPerson.TxtFirstName.Location = new System.Drawing.Point(229, 3);
            this.ctrlContactPerson.TxtFirstName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlContactPerson.TxtFirstName.Name = "txtFirstName";
            this.ctrlContactPerson.TxtFirstName.NullText = "Ім\'я";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtFirstName.RootElement.ControlBounds = new System.Drawing.Rectangle(229, 4, 173, 20);
            this.ctrlContactPerson.TxtFirstName.RootElement.StretchVertically = true;
            this.ctrlContactPerson.TxtFirstName.Size = new System.Drawing.Size(173, 21);
            this.ctrlContactPerson.TxtFirstName.TabIndex = 1;
            this.ctrlContactPerson.TxtFirstName.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlContactPerson.TxtLastName.Location = new System.Drawing.Point(33, 3);
            this.ctrlContactPerson.TxtLastName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlContactPerson.TxtLastName.Name = "txtLastName";
            this.ctrlContactPerson.TxtLastName.NullText = "Прізвище";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtLastName.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 4, 173, 20);
            this.ctrlContactPerson.TxtLastName.RootElement.StretchVertically = true;
            this.ctrlContactPerson.TxtLastName.Size = new System.Drawing.Size(173, 21);
            this.ctrlContactPerson.TxtLastName.TabIndex = 0;
            this.ctrlContactPerson.TxtLastName.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.TxtPhone.AutoSize = false;
            this.ctrlContactPerson.TxtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlContactPerson.TxtPhone.Location = new System.Drawing.Point(33, 35);
            this.ctrlContactPerson.TxtPhone.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlContactPerson.TxtPhone.MaxLength = 13;
            this.ctrlContactPerson.TxtPhone.Name = "txtPhone";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtPhone.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 36, 173, 20);
            this.ctrlContactPerson.TxtPhone.RootElement.StretchVertically = false;
            this.ctrlContactPerson.TxtPhone.Size = new System.Drawing.Size(173, 20);
            this.ctrlContactPerson.TxtPhone.TabIndex = 3;
            this.ctrlContactPerson.TxtPhone.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtSurName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.TxtSurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlContactPerson.TxtSurName.Location = new System.Drawing.Point(425, 3);
            this.ctrlContactPerson.TxtSurName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlContactPerson.TxtSurName.Name = "txtSurName";
            this.ctrlContactPerson.TxtSurName.NullText = "По батькові";
            // 
            // 
            // 
            this.ctrlContactPerson.TxtSurName.RootElement.ControlBounds = new System.Drawing.Rectangle(425, 3, 175, 20);
            this.ctrlContactPerson.TxtSurName.RootElement.StretchVertically = true;
            this.ctrlContactPerson.TxtSurName.Size = new System.Drawing.Size(175, 21);
            this.ctrlContactPerson.TxtSurName.TabIndex = 2;
            this.ctrlContactPerson.TxtSurName.ThemeName = "Office2013Light";
            // 
            // ctrlClientName
            // 
            this.ctrlClientName.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            this.ctrlClientName.Location = new System.Drawing.Point(22, 6);
            this.ctrlClientName.MaximumSize = new System.Drawing.Size(900, 47);
            this.ctrlClientName.MinimumSize = new System.Drawing.Size(400, 47);
            this.ctrlClientName.Name = "ctrlClientName";
            this.ctrlClientName.Size = new System.Drawing.Size(452, 47);
            this.ctrlClientName.TabIndex = 0;
            // 
            // pvAddress
            // 
            this.pvAddress.Controls.Add(this.ctrlAddressLe);
            this.pvAddress.Controls.Add(this.btnCopyFromLiveToReg);
            this.pvAddress.Controls.Add(this.radLabel9);
            this.pvAddress.Controls.Add(this.radSeparator3);
            this.pvAddress.Controls.Add(this.radLabel8);
            this.pvAddress.Controls.Add(this.radSeparator2);
            this.pvAddress.Controls.Add(this.btnCopyFromRegToLett);
            this.pvAddress.Controls.Add(this.btnCopyFromLiveToLett);
            this.pvAddress.Controls.Add(this.radLabel7);
            this.pvAddress.Controls.Add(this.radSeparator1);
            this.pvAddress.Controls.Add(this.ctrlAddressFa);
            this.pvAddress.Controls.Add(this.ctrlAddressJu);
            this.pvAddress.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAddress.Location = new System.Drawing.Point(134, 5);
            this.pvAddress.Name = "pvAddress";
            this.pvAddress.Size = new System.Drawing.Size(872, 498);
            this.pvAddress.Text = "Адреса";
            // 
            // ctrlAddressLe
            // 
            this.ctrlAddressLe.AddressDataMember = null;
            this.ctrlAddressLe.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressLe.CityDataMember = null;
            this.ctrlAddressLe.CountryDataMember = "";
            this.ctrlAddressLe.Location = new System.Drawing.Point(140, 242);
            this.ctrlAddressLe.Name = "ctrlAddressLe";
            this.ctrlAddressLe.PostIndexDataMember = null;
            this.ctrlAddressLe.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressLe.TabIndex = 64;
            // 
            // btnCopyFromLiveToReg
            // 
            this.btnCopyFromLiveToReg.Location = new System.Drawing.Point(140, 112);
            this.btnCopyFromLiveToReg.Name = "btnCopyFromLiveToReg";
            this.btnCopyFromLiveToReg.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToReg.TabIndex = 57;
            this.btnCopyFromLiveToReg.Text = "Копіювати з юридичної адреси";
            this.btnCopyFromLiveToReg.ThemeName = "Office2013Light";
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(24, 191);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(114, 19);
            this.radLabel9.TabIndex = 63;
            this.radLabel9.Text = "Адреса листування";
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Location = new System.Drawing.Point(140, 191);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(503, 19);
            this.radSeparator3.TabIndex = 62;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(24, 87);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(103, 19);
            this.radLabel8.TabIndex = 61;
            this.radLabel8.Text = "Фактична адреса";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // radSeparator2
            // 
            this.radSeparator2.Location = new System.Drawing.Point(140, 87);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(503, 19);
            this.radSeparator2.TabIndex = 60;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // btnCopyFromRegToLett
            // 
            this.btnCopyFromRegToLett.Location = new System.Drawing.Point(341, 216);
            this.btnCopyFromRegToLett.Name = "btnCopyFromRegToLett";
            this.btnCopyFromRegToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromRegToLett.TabIndex = 59;
            this.btnCopyFromRegToLett.Text = "Копіювати з фактичної адреси";
            this.btnCopyFromRegToLett.ThemeName = "Office2013Light";
            // 
            // btnCopyFromLiveToLett
            // 
            this.btnCopyFromLiveToLett.Location = new System.Drawing.Point(140, 216);
            this.btnCopyFromLiveToLett.Name = "btnCopyFromLiveToLett";
            this.btnCopyFromLiveToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToLett.TabIndex = 58;
            this.btnCopyFromLiveToLett.Text = "Копіювати з юридичної адреси";
            this.btnCopyFromLiveToLett.ThemeName = "Office2013Light";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(24, 8);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(110, 19);
            this.radLabel7.TabIndex = 4;
            this.radLabel7.Text = "Юридична адреса";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(140, 8);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(503, 19);
            this.radSeparator1.TabIndex = 3;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // ctrlAddressFa
            // 
            this.ctrlAddressFa.AddressDataMember = null;
            this.ctrlAddressFa.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressFa.CityDataMember = null;
            this.ctrlAddressFa.CountryDataMember = "";
            this.ctrlAddressFa.Location = new System.Drawing.Point(140, 137);
            this.ctrlAddressFa.Name = "ctrlAddressFa";
            this.ctrlAddressFa.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressFa.TabIndex = 1;
            // 
            // ctrlAddressJu
            // 
            this.ctrlAddressJu.AddressDataMember = null;
            this.ctrlAddressJu.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressJu.CityDataMember = null;
            this.ctrlAddressJu.CountryDataMember = "";
            this.ctrlAddressJu.Location = new System.Drawing.Point(140, 33);
            this.ctrlAddressJu.Name = "ctrlAddressJu";
            this.ctrlAddressJu.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressJu.TabIndex = 0;
            // 
            // pvBank
            // 
            this.pvBank.Controls.Add(this.ctrlBankAccount);
            this.pvBank.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBank.Location = new System.Drawing.Point(134, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(872, 498);
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
            this.pvAgreement.Controls.Add(this.ctrlAgreement);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(872, 498);
            this.pvAgreement.Text = "Договір";
            // 
            // ctrlTabNavigation
            // 
            this.ctrlTabNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigation.Location = new System.Drawing.Point(0, 508);
            this.ctrlTabNavigation.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigation.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigation.Name = "ctrlTabNavigation";
            this.ctrlTabNavigation.Size = new System.Drawing.Size(1011, 31);
            this.ctrlTabNavigation.TabIndex = 13;
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddCommunity);
            this.ctrlAgreement.Location = new System.Drawing.Point(22, 6);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(641, 260);
            this.ctrlAgreement.TabIndex = 0;
            // 
            // CommunityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 539);
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.ctrlTabNavigation);
            this.Name = "CommunityForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Створити нову спільноту";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvCommunityName.ResumeLayout(false);
            this.pvCommunityName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtSurName)).EndInit();
            this.pvAddress.ResumeLayout(false);
            this.pvAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            this.pvBank.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvCommunityName;
        private Telerik.WinControls.UI.RadPageViewPage pvAddress;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private ConsumerControls.TabNavigationControl ctrlTabNavigation;
        private CommunityAddressControl ctrlAddressFa;
        private CommunityAddressControl ctrlAddressJu;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadButton btnCopyFromRegToLett;
        private Telerik.WinControls.UI.RadButton btnCopyFromLiveToLett;
        private Telerik.WinControls.UI.RadButton btnCopyFromLiveToReg;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadSeparator radSeparator3;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadSeparator radSeparator2;
        private CommunityAddressLetterControl ctrlAddressLe;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private IpsBossNameContactsControl ctrlContactPerson;
        private IpsAnketaCompanyControl ctrlClientName;
        private CommunityAgreementControl ctrlAgreement;
    }
}
