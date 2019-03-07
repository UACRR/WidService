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
            this.ctrlClientName = new IpsViewComponentLibrary.JurPersonName();
            this.pvContact = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAddress = new IpsViewComponentLibrary.MiddleControlAddress();
            this.pvManager = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlManagers = new IpsViewComponentLibrary.MiddleControlManagers();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsBankAccountControl();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvPartnerName.SuspendLayout();
            this.pvContact.SuspendLayout();
            this.pvManager.SuspendLayout();
            this.pvBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
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
            this.ctrlClientName.Location = new System.Drawing.Point(3, 26);
            this.ctrlClientName.MaximumSize = new System.Drawing.Size(711, 172);
            this.ctrlClientName.MinimumSize = new System.Drawing.Size(711, 172);
            this.ctrlClientName.Name = "ctrlClientName";
            this.ctrlClientName.Size = new System.Drawing.Size(711, 172);
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
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radPanel1.Location = new System.Drawing.Point(0, 512);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(990, 31);
            this.radPanel1.TabIndex = 24;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(739, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 24);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Зберегти зміни";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(866, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Скасувати зміни";
            this.btnCancel.ThemeName = "Office2013Light";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PartnerCabinetAnketaJurControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.radPanel1);
            this.Name = "PartnerCabinetAnketaJurControl";
            this.Size = new System.Drawing.Size(990, 543);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
            this.pvManager.ResumeLayout(false);
            this.pvBank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerName;
        private JurPersonName ctrlClientName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
        private MiddleControlAddress ctrlAddress;
        private Telerik.WinControls.UI.RadPageViewPage pvManager;
        private MiddleControlManagers ctrlManagers;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
