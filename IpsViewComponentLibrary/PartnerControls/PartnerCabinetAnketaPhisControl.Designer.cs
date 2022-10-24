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
            this.ctrlPartnerName = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaPersonControl();
            this.pvContact = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlContacts = new IpsViewComponentLibrary.Shared.Controls.PersonalAddressControl();
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
            this.pageViewAnketa.SelectedPage = this.pvBank;
            this.pageViewAnketa.Size = new System.Drawing.Size(963, 463);
            this.pageViewAnketa.TabIndex = 12;
            this.pageViewAnketa.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvPartnerName
            // 
            this.pvPartnerName.AutoScroll = true;
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
            this.pvContact.AutoScroll = true;
            this.pvContact.Controls.Add(this.ctrlContacts);
            this.pvContact.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvContact.Location = new System.Drawing.Point(134, 5);
            this.pvContact.Name = "pvContact";
            this.pvContact.Size = new System.Drawing.Size(824, 453);
            this.pvContact.Text = "Контакти";
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.Location = new System.Drawing.Point(22, 6);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(776, 351);
            this.ctrlContacts.TabIndex = 47;
            // 
            // pvPasport
            // 
            this.pvPasport.AutoScroll = true;
            this.pvPasport.Controls.Add(this.radGroupBox3);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(134, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(824, 453);
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
            this.pvBank.Size = new System.Drawing.Size(824, 453);
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
            this.ctrlSaveCancel.ButtonSaveDialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 463);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.SaveButtonEnabled = true;
            this.ctrlSaveCancel.Size = new System.Drawing.Size(963, 31);
            this.ctrlSaveCancel.TabIndex = 13;
            // 
            // PartnerCabinetAnketaPhisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pageViewAnketa);
            this.Controls.Add(this.ctrlSaveCancel);
            this.Name = "PartnerCabinetAnketaPhisControl";
            this.Size = new System.Drawing.Size(963, 494);
            ((System.ComponentModel.ISupportInitialize)(this.pageViewAnketa)).EndInit();
            this.pageViewAnketa.ResumeLayout(false);
            this.pvPartnerName.ResumeLayout(false);
            this.pvContact.ResumeLayout(false);
            this.pvPasport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.pvBank.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageViewAnketa;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerName;
        private IpsAnketaPersonControl ctrlPartnerName;
        private Telerik.WinControls.UI.RadPageViewPage pvContact;
        private Telerik.WinControls.UI.RadPageViewPage pvPasport;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private PassportControl ctrlInternalPassport;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
        private PersonalAddressControl ctrlContacts;
    }
}
