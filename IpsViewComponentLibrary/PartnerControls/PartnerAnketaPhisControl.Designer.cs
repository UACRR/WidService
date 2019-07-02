using IpsViewComponentLibrary.Common;
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
            this.ctrlPartnerName = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaPersonControl();
            this.pvContact = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlContacts = new IpsViewComponentLibrary.Shared.Controls.PersonalAddressControl();
            this.pvPasport = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.ctrlInternalPassport = new IpsViewComponentLibrary.Shared.Controls.PassportControl();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.checkPartnerInternal = new Telerik.WinControls.UI.RadCheckBox();
            this.bsPartner = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgreement = new IpsViewComponentLibrary.PartnerControls.AgreementPartnerControl();
            this.pvTerms = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlConditions = new IpsViewComponentLibrary.PartnerControls.ConditionsControl();
            this.ctrlTabNavigationExpanded = new IpsViewComponentLibrary.Common.TabNavigationExpandedControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvPartnerName.SuspendLayout();
            this.pvContact.SuspendLayout();
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
            this.pageView.Size = new System.Drawing.Size(956, 556);
            this.pageView.TabIndex = 12;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvPartnerName
            // 
            this.pvPartnerName.AutoScroll = true;
            this.pvPartnerName.Controls.Add(this.ctrlPartnerName);
            this.pvPartnerName.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvPartnerName.Location = new System.Drawing.Point(137, 5);
            this.pvPartnerName.Name = "pvPartnerName";
            this.pvPartnerName.Size = new System.Drawing.Size(814, 546);
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
            this.pvContact.AutoScroll = true;
            this.pvContact.Controls.Add(this.ctrlContacts);
            this.pvContact.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvContact.Location = new System.Drawing.Point(134, 5);
            this.pvContact.Name = "pvContact";
            this.pvContact.Size = new System.Drawing.Size(817, 546);
            this.pvContact.Text = "Контакти";
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.Location = new System.Drawing.Point(22, 6);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(776, 351);
            this.ctrlContacts.TabIndex = 0;
            // 
            // pvPasport
            // 
            this.pvPasport.AutoScroll = true;
            this.pvPasport.Controls.Add(this.radGroupBox3);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(134, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(817, 546);
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
            this.pvBank.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvBank.Location = new System.Drawing.Point(134, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(817, 546);
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
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(817, 546);
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
            this.ctrlAgreement.IsReadOnly = false;
            this.ctrlAgreement.Location = new System.Drawing.Point(22, 6);
            this.ctrlAgreement.MaximumSize = new System.Drawing.Size(504, 140);
            this.ctrlAgreement.MinimumSize = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(484, 140);
            this.ctrlAgreement.TabIndex = 0;
            // 
            // pvTerms
            // 
            this.pvTerms.AutoScroll = true;
            this.pvTerms.Controls.Add(this.ctrlConditions);
            this.pvTerms.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvTerms.Location = new System.Drawing.Point(134, 5);
            this.pvTerms.Name = "pvTerms";
            this.pvTerms.Size = new System.Drawing.Size(817, 546);
            this.pvTerms.Text = "Умови представника";
            // 
            // ctrlConditions
            // 
            this.ctrlConditions.AgreementAddPartnerDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlConditions.IsReadOnly = false;
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
            this.ctrlTabNavigationExpanded.Size = new System.Drawing.Size(956, 31);
            this.ctrlTabNavigationExpanded.TabIndex = 13;
            // 
            // PartnerAnketaPhisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.ctrlTabNavigationExpanded);
            this.Name = "PartnerAnketaPhisControl";
            this.Size = new System.Drawing.Size(956, 587);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
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
        private IpsAnketaPersonControl ctrlPartnerName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
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
        private PersonalAddressControl ctrlContacts;
    }
}
