using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class PartnerAnketaJurControl
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
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvPartnerName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlClientName = new IpsViewComponentLibrary.PartnerControls.JurPersonName();
            this.pvContact = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAddress = new IpsViewComponentLibrary.Shared.Controls.JuridicalAddressControl();
            this.pvManager = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlManagers = new IpsViewComponentLibrary.Shared.Controls.JuridicalManagersControl();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgreement = new IpsViewComponentLibrary.PartnerControls.AgreementPartnerControl();
            this.pvTerms = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlConditions = new IpsViewComponentLibrary.PartnerControls.ConditionsControl();
            this.ctrlTabNavigationExpanded = new IpsViewComponentLibrary.Common.TabNavigationExpandedControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvPartnerName.SuspendLayout();
            this.pvContact.SuspendLayout();
            this.pvManager.SuspendLayout();
            this.pvBank.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            this.pvTerms.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvPartnerName);
            this.pageView.Controls.Add(this.pvContact);
            this.pageView.Controls.Add(this.pvManager);
            this.pageView.Controls.Add(this.pvBank);
            this.pageView.Controls.Add(this.pvAgreement);
            this.pageView.Controls.Add(this.pvTerms);
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvPartnerName;
            this.pageView.Size = new System.Drawing.Size(979, 564);
            this.pageView.TabIndex = 14;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvPartnerName
            // 
            this.pvPartnerName.Controls.Add(this.ctrlClientName);
            this.pvPartnerName.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvPartnerName.Location = new System.Drawing.Point(137, 5);
            this.pvPartnerName.Name = "pvPartnerName";
            this.pvPartnerName.Size = new System.Drawing.Size(837, 554);
            this.pvPartnerName.Text = "Представник";
            // 
            // ctrlClientName
            // 
            this.ctrlClientName.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlClientName.Location = new System.Drawing.Point(3, 26);
            this.ctrlClientName.MaximumSize = new System.Drawing.Size(711, 217);
            this.ctrlClientName.MinimumSize = new System.Drawing.Size(711, 217);
            this.ctrlClientName.Name = "ctrlClientName";
            this.ctrlClientName.Size = new System.Drawing.Size(711, 217);
            this.ctrlClientName.TabIndex = 0;
            // 
            // pvContact
            // 
            this.pvContact.Controls.Add(this.ctrlAddress);
            this.pvContact.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvContact.Location = new System.Drawing.Point(134, 5);
            this.pvContact.Name = "pvContact";
            this.pvContact.Size = new System.Drawing.Size(840, 554);
            this.pvContact.Text = "Адреса";
            // 
            // ctrlAddress
            // 
            this.ctrlAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddress.Location = new System.Drawing.Point(3, 3);
            this.ctrlAddress.MaximumSize = new System.Drawing.Size(1000, 313);
            this.ctrlAddress.MinimumSize = new System.Drawing.Size(727, 313);
            this.ctrlAddress.Name = "ctrlAddress";
            this.ctrlAddress.Size = new System.Drawing.Size(834, 313);
            this.ctrlAddress.TabIndex = 50;
            // 
            // pvManager
            // 
            this.pvManager.Controls.Add(this.ctrlManagers);
            this.pvManager.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvManager.Location = new System.Drawing.Point(134, 5);
            this.pvManager.Name = "pvManager";
            this.pvManager.Size = new System.Drawing.Size(840, 554);
            this.pvManager.Text = "Контакти";
            // 
            // ctrlManagers
            // 
            this.ctrlManagers.Location = new System.Drawing.Point(3, 3);
            this.ctrlManagers.MaximumSize = new System.Drawing.Size(1200, 343);
            this.ctrlManagers.MinimumSize = new System.Drawing.Size(600, 343);
            this.ctrlManagers.Name = "ctrlManagers";
            this.ctrlManagers.Size = new System.Drawing.Size(732, 343);
            this.ctrlManagers.TabIndex = 1;
            // 
            // pvBank
            // 
            this.pvBank.Controls.Add(this.ctrlBankAccount);
            this.pvBank.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvBank.Location = new System.Drawing.Point(134, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(840, 554);
            this.pvBank.Text = "Банківські реквізити";
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            this.ctrlBankAccount.Location = new System.Drawing.Point(5, 29);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(409, 127);
            this.ctrlBankAccount.TabIndex = 0;
            // 
            // pvAgreement
            // 
            this.pvAgreement.Controls.Add(this.ctrlAgreement);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(840, 554);
            this.pvAgreement.Text = "Договір";
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementCommunityDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.IsReadOnly = false;
            this.ctrlAgreement.Location = new System.Drawing.Point(4, 28);
            this.ctrlAgreement.MaximumSize = new System.Drawing.Size(504, 140);
            this.ctrlAgreement.MinimumSize = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(484, 140);
            this.ctrlAgreement.TabIndex = 0;
            // 
            // pvTerms
            // 
            this.pvTerms.Controls.Add(this.ctrlConditions);
            this.pvTerms.ItemSize = new System.Drawing.SizeF(133F, 27F);
            this.pvTerms.Location = new System.Drawing.Point(137, 5);
            this.pvTerms.Name = "pvTerms";
            this.pvTerms.Size = new System.Drawing.Size(837, 554);
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
            this.ctrlTabNavigationExpanded.Location = new System.Drawing.Point(0, 564);
            this.ctrlTabNavigationExpanded.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigationExpanded.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigationExpanded.Name = "ctrlTabNavigationExpanded";
            this.ctrlTabNavigationExpanded.Size = new System.Drawing.Size(979, 31);
            this.ctrlTabNavigationExpanded.TabIndex = 15;
            // 
            // PartnerAnketaJurControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.ctrlTabNavigationExpanded);
            this.Name = "PartnerAnketaJurControl";
            this.Size = new System.Drawing.Size(979, 595);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
            this.pvManager.ResumeLayout(false);
            this.pvBank.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            this.pvTerms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private AgreementPartnerControl ctrlAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvTerms;
        private ConditionsControl ctrlConditions;
        private TabNavigationExpandedControl ctrlTabNavigationExpanded;
        private Telerik.WinControls.UI.RadPageViewPage pvManager;
        private JuridicalAddressControl ctrlAddress;
        private JuridicalManagersControl ctrlManagers;
        private JurPersonName ctrlClientName;
    }
}
