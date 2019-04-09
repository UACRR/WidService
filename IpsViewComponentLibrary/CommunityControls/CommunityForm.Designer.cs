using System.Windows.Forms;
using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.Shared.Controls;

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
            this.components = new System.ComponentModel.Container();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvCommunityName = new Telerik.WinControls.UI.RadPageViewPage();
            this.radSeparator4 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator5 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtOnBasicsIfHeadBoss = new Telerik.WinControls.UI.RadTextBox();
            this.bsRelEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlHeadBoss = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.txtIpi = new Telerik.WinControls.UI.RadTextBox();
            this.bsCommunity = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlContactPerson = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.ctrlClientName = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaCompanyControl();
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
            this.ctrlBankAccount = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgreement = new IpsViewComponentLibrary.CommunityControls.CommunityAgreementControl();
            this.ctrlTabNavigation = new IpsViewComponentLibrary.Common.TabNavigationControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvCommunityName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
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
            this.pageView.Size = new System.Drawing.Size(1011, 539);
            this.pageView.TabIndex = 0;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvCommunityName
            // 
            this.pvCommunityName.Controls.Add(this.radSeparator4);
            this.pvCommunityName.Controls.Add(this.radSeparator5);
            this.pvCommunityName.Controls.Add(this.radLabel10);
            this.pvCommunityName.Controls.Add(this.txtOnBasicsIfHeadBoss);
            this.pvCommunityName.Controls.Add(this.radLabel4);
            this.pvCommunityName.Controls.Add(this.ctrlHeadBoss);
            this.pvCommunityName.Controls.Add(this.txtIpi);
            this.pvCommunityName.Controls.Add(this.radLabel1);
            this.pvCommunityName.Controls.Add(this.radLabel6);
            this.pvCommunityName.Controls.Add(this.ctrlContactPerson);
            this.pvCommunityName.Controls.Add(this.ctrlClientName);
            this.pvCommunityName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvCommunityName.Location = new System.Drawing.Point(134, 5);
            this.pvCommunityName.Name = "pvCommunityName";
            this.pvCommunityName.Size = new System.Drawing.Size(872, 529);
            this.pvCommunityName.Text = "Товариство";
            // 
            // radSeparator4
            // 
            this.radSeparator4.Location = new System.Drawing.Point(132, 197);
            this.radSeparator4.Name = "radSeparator4";
            this.radSeparator4.Size = new System.Drawing.Size(487, 19);
            this.radSeparator4.TabIndex = 0;
            this.radSeparator4.ThemeName = "Office2013Light";
            // 
            // radSeparator5
            // 
            this.radSeparator5.Location = new System.Drawing.Point(92, 84);
            this.radSeparator5.Name = "radSeparator5";
            this.radSeparator5.Size = new System.Drawing.Size(527, 19);
            this.radSeparator5.TabIndex = 0;
            this.radSeparator5.ThemeName = "Office2013Light";
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(22, 84);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(64, 19);
            this.radLabel10.TabIndex = 0;
            this.radLabel10.Text = "Директор:";
            this.radLabel10.ThemeName = "Office2013Light";
            // 
            // txtOnBasicsIfHeadBoss
            // 
            this.txtOnBasicsIfHeadBoss.AutoSize = false;
            this.txtOnBasicsIfHeadBoss.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRelEmployee, "RelDocument", true));
            this.txtOnBasicsIfHeadBoss.Location = new System.Drawing.Point(121, 109);
            this.txtOnBasicsIfHeadBoss.Multiline = true;
            this.txtOnBasicsIfHeadBoss.Name = "txtOnBasicsIfHeadBoss";
            this.txtOnBasicsIfHeadBoss.NullText = "(статуту, положення, довіреності, свідоцтва про реєстрацію, виписки з ЄДР)";
            this.txtOnBasicsIfHeadBoss.Size = new System.Drawing.Size(498, 20);
            this.txtOnBasicsIfHeadBoss.TabIndex = 2;
            this.txtOnBasicsIfHeadBoss.ThemeName = "Office2013Light";
            // 
            // bsRelEmployee
            // 
            this.bsRelEmployee.DataSource = typeof(ipsFormsDesign.Model.RelEmployee);
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.Location = new System.Drawing.Point(22, 109);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(93, 20);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "Діє на підставі:";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // ctrlHeadBoss
            // 
            this.ctrlHeadBoss.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlHeadBoss.Location = new System.Drawing.Point(22, 135);
            this.ctrlHeadBoss.Name = "ctrlHeadBoss";
            this.ctrlHeadBoss.OutsidePhone = false;
            this.ctrlHeadBoss.PhoneNullText = "+380## ### ## ##";
            this.ctrlHeadBoss.Size = new System.Drawing.Size(597, 56);
            this.ctrlHeadBoss.TabIndex = 3;
            // 
            // txtIpi
            // 
            this.txtIpi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCommunity, "InterCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtIpi.Location = new System.Drawing.Point(231, 57);
            this.txtIpi.Name = "txtIpi";
            this.txtIpi.Size = new System.Drawing.Size(243, 21);
            this.txtIpi.TabIndex = 1;
            this.txtIpi.ThemeName = "Office2013Light";
            // 
            // bsCommunity
            // 
            this.bsCommunity.DataSource = typeof(ipsFormsDesign.Model.Community);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(22, 59);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(203, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Міжнародний код товариства (IPI):";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(22, 197);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(104, 19);
            this.radLabel6.TabIndex = 0;
            this.radLabel6.Text = "Контактна особа:";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlContactPerson.Location = new System.Drawing.Point(19, 222);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.OutsidePhone = false;
            this.ctrlContactPerson.PhoneNullText = "+380## ### ## ##";
            this.ctrlContactPerson.Size = new System.Drawing.Size(600, 56);
            this.ctrlContactPerson.TabIndex = 4;
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
            this.ctrlAddressLe.TabIndex = 6;
            // 
            // btnCopyFromLiveToReg
            // 
            this.btnCopyFromLiveToReg.Location = new System.Drawing.Point(140, 112);
            this.btnCopyFromLiveToReg.Name = "btnCopyFromLiveToReg";
            this.btnCopyFromLiveToReg.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToReg.TabIndex = 2;
            this.btnCopyFromLiveToReg.Text = "Копіювати з юридичної адреси";
            this.btnCopyFromLiveToReg.ThemeName = "Office2013Light";
            this.btnCopyFromLiveToReg.Click += new System.EventHandler(this.btnCopyFromLiveToReg_Click);
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(24, 191);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(114, 19);
            this.radLabel9.TabIndex = 0;
            this.radLabel9.Text = "Адреса листування";
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Location = new System.Drawing.Point(140, 191);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(503, 19);
            this.radSeparator3.TabIndex = 0;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(24, 87);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(103, 19);
            this.radLabel8.TabIndex = 0;
            this.radLabel8.Text = "Фактична адреса";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // radSeparator2
            // 
            this.radSeparator2.Location = new System.Drawing.Point(140, 87);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(503, 19);
            this.radSeparator2.TabIndex = 0;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // btnCopyFromRegToLett
            // 
            this.btnCopyFromRegToLett.Location = new System.Drawing.Point(341, 216);
            this.btnCopyFromRegToLett.Name = "btnCopyFromRegToLett";
            this.btnCopyFromRegToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromRegToLett.TabIndex = 5;
            this.btnCopyFromRegToLett.Text = "Копіювати з фактичної адреси";
            this.btnCopyFromRegToLett.ThemeName = "Office2013Light";
            this.btnCopyFromRegToLett.Click += new System.EventHandler(this.btnCopyFromRegToLett_Click);
            // 
            // btnCopyFromLiveToLett
            // 
            this.btnCopyFromLiveToLett.Location = new System.Drawing.Point(140, 216);
            this.btnCopyFromLiveToLett.Name = "btnCopyFromLiveToLett";
            this.btnCopyFromLiveToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToLett.TabIndex = 4;
            this.btnCopyFromLiveToLett.Text = "Копіювати з юридичної адреси";
            this.btnCopyFromLiveToLett.ThemeName = "Office2013Light";
            this.btnCopyFromLiveToLett.Click += new System.EventHandler(this.btnCopyFromLiveToLett_Click);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(24, 8);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(110, 19);
            this.radLabel7.TabIndex = 0;
            this.radLabel7.Text = "Юридична адреса";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(140, 8);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(503, 19);
            this.radSeparator1.TabIndex = 0;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // ctrlAddressFa
            // 
            this.ctrlAddressFa.AddressDataMember = "";
            this.ctrlAddressFa.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressFa.CityDataMember = "";
            this.ctrlAddressFa.CountryDataMember = "";
            this.ctrlAddressFa.Location = new System.Drawing.Point(140, 137);
            this.ctrlAddressFa.Name = "ctrlAddressFa";
            this.ctrlAddressFa.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressFa.TabIndex = 3;
            // 
            // ctrlAddressJu
            // 
            this.ctrlAddressJu.AddressDataMember = "";
            this.ctrlAddressJu.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressJu.CityDataMember = "";
            this.ctrlAddressJu.CountryDataMember = "";
            this.ctrlAddressJu.Location = new System.Drawing.Point(140, 33);
            this.ctrlAddressJu.Name = "ctrlAddressJu";
            this.ctrlAddressJu.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressJu.TabIndex = 1;
            // 
            // pvBank
            // 
            this.pvBank.Controls.Add(this.ctrlBankAccount);
            this.pvBank.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBank.Location = new System.Drawing.Point(134, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(872, 529);
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
            this.pvAgreement.Size = new System.Drawing.Size(872, 529);
            this.pvAgreement.Text = "Договір";
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddCommunity);
            this.ctrlAgreement.Location = new System.Drawing.Point(22, 6);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(641, 260);
            this.ctrlAgreement.TabIndex = 0;
            // 
            // ctrlTabNavigation
            // 
            this.ctrlTabNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigation.Location = new System.Drawing.Point(0, 508);
            this.ctrlTabNavigation.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigation.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigation.Name = "ctrlTabNavigation";
            this.ctrlTabNavigation.Size = new System.Drawing.Size(1011, 31);
            this.ctrlTabNavigation.TabIndex = 1;
            // 
            // CommunityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 539);
            this.Controls.Add(this.ctrlTabNavigation);
            this.Controls.Add(this.pageView);
            this.Name = "CommunityForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Створити нове товариство";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvCommunityName.ResumeLayout(false);
            this.pvCommunityName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
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
        private TabNavigationControl ctrlTabNavigation;
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
        private Telerik.WinControls.UI.RadTextBox txtIpi;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.BindingSource bsCommunity;
        private Telerik.WinControls.UI.RadSeparator radSeparator5;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadTextBox txtOnBasicsIfHeadBoss;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private IpsBossNameContactsControl ctrlHeadBoss;
        private Telerik.WinControls.UI.RadSeparator radSeparator4;
        private BindingSource bsRelEmployee;
    }
}
