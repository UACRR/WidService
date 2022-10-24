using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class PartnerCabinetAnketaJurControl
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
            this.ctrlSaveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvPartnerName.SuspendLayout();
            this.pvContact.SuspendLayout();
            this.pvManager.SuspendLayout();
            this.pvBank.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvPartnerName);
            this.pageView.Controls.Add(this.pvContact);
            this.pageView.Controls.Add(this.pvManager);
            this.pageView.Controls.Add(this.pvBank);
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvPartnerName;
            this.pageView.Size = new System.Drawing.Size(990, 512);
            this.pageView.TabIndex = 15;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvPartnerName
            // 
            this.pvPartnerName.Controls.Add(this.ctrlClientName);
            this.pvPartnerName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPartnerName.Location = new System.Drawing.Point(134, 5);
            this.pvPartnerName.Name = "pvPartnerName";
            this.pvPartnerName.Size = new System.Drawing.Size(851, 502);
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
            this.pvContact.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvContact.Location = new System.Drawing.Point(134, 5);
            this.pvContact.Name = "pvContact";
            this.pvContact.Size = new System.Drawing.Size(851, 502);
            this.pvContact.Text = "Контакти";
            // 
            // ctrlAddress
            // 
            this.ctrlAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddress.Location = new System.Drawing.Point(3, 3);
            this.ctrlAddress.MaximumSize = new System.Drawing.Size(1000, 313);
            this.ctrlAddress.MinimumSize = new System.Drawing.Size(727, 313);
            this.ctrlAddress.Name = "ctrlAddress";
            this.ctrlAddress.Size = new System.Drawing.Size(845, 313);
            this.ctrlAddress.TabIndex = 50;
            // 
            // pvManager
            // 
            this.pvManager.Controls.Add(this.ctrlManagers);
            this.pvManager.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvManager.Location = new System.Drawing.Point(134, 5);
            this.pvManager.Name = "pvManager";
            this.pvManager.Size = new System.Drawing.Size(851, 502);
            this.pvManager.Text = "Керівники";
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
            this.pvBank.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBank.Location = new System.Drawing.Point(134, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(851, 502);
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
            // ctrlSaveCancel
            // 
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 512);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.SaveButtonEnabled = true;
            this.ctrlSaveCancel.Size = new System.Drawing.Size(990, 31);
            this.ctrlSaveCancel.TabIndex = 25;
            // 
            // PartnerCabinetAnketaJurControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.ctrlSaveCancel);
            this.Name = "PartnerCabinetAnketaJurControl";
            this.Size = new System.Drawing.Size(990, 543);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
            this.pvManager.ResumeLayout(false);
            this.pvBank.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerName;
        private JurPersonName ctrlClientName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
        private JuridicalAddressControl ctrlAddress;
        private Telerik.WinControls.UI.RadPageViewPage pvManager;
        private JuridicalManagersControl ctrlManagers;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
    }
}
