using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class AnketaConsumerPhis
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
            this.pageAnketaConsumer = new Telerik.WinControls.UI.RadPageView();
            this.pvClientName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlClientGroupBrand = new IpsViewComponentLibrary.Shared.Controls.IpsClientGroupBrandControl();
            this.bsClient = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlConsumerName = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaPersonControl();
            this.pvPlaces = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPlaces = new IpsViewComponentLibrary.ConsumerControls.Places.ConsumerPlacesControl();
            this.pvPasport = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.ctrlConsumerPassport = new IpsViewComponentLibrary.Shared.Controls.PassportControl();
            this.pvBankRequisites = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.pvContacts = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlContacts = new IpsViewComponentLibrary.Shared.Controls.PersonalAddressControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnLoadPdf = new Telerik.WinControls.UI.RadButton();
            this.ctrlAgreementPhis = new IpsViewComponentLibrary.ConsumerControls.AgreementWithPlacesControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).BeginInit();
            this.pageAnketaConsumer.SuspendLayout();
            this.pvClientName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsClient)).BeginInit();
            this.pvPlaces.SuspendLayout();
            this.pvPasport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            this.pvBankRequisites.SuspendLayout();
            this.pvContacts.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // pageAnketaConsumer
            // 
            this.pageAnketaConsumer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pageAnketaConsumer.Controls.Add(this.pvClientName);
            this.pageAnketaConsumer.Controls.Add(this.pvPlaces);
            this.pageAnketaConsumer.Controls.Add(this.pvPasport);
            this.pageAnketaConsumer.Controls.Add(this.pvBankRequisites);
            this.pageAnketaConsumer.Controls.Add(this.pvContacts);
            this.pageAnketaConsumer.Controls.Add(this.pvAgreement);
            this.pageAnketaConsumer.DefaultPage = this.pvClientName;
            this.pageAnketaConsumer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageAnketaConsumer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pageAnketaConsumer.Location = new System.Drawing.Point(0, 0);
            this.pageAnketaConsumer.Name = "pageAnketaConsumer";
            // 
            // 
            // 
            this.pageAnketaConsumer.RootElement.FocusBorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pageAnketaConsumer.SelectedPage = this.pvClientName;
            this.pageAnketaConsumer.SelectionWrap = false;
            this.pageAnketaConsumer.Size = new System.Drawing.Size(987, 551);
            this.pageAnketaConsumer.TabIndex = 3;
            this.pageAnketaConsumer.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).ShadowColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).CustomFontStyle = System.Drawing.FontStyle.Bold;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Enabled = true;
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).ToolTipText = "Scroll Strip Right";
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Enabled = false;
            // 
            // pvClientName
            // 
            this.pvClientName.AutoScroll = true;
            this.pvClientName.Controls.Add(this.ctrlClientGroupBrand);
            this.pvClientName.Controls.Add(this.ctrlConsumerName);
            this.pvClientName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvClientName.Location = new System.Drawing.Point(134, 5);
            this.pvClientName.Name = "pvClientName";
            this.pvClientName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pvClientName.Size = new System.Drawing.Size(848, 541);
            this.pvClientName.TabStop = true;
            this.pvClientName.Text = "Користувач";
            // 
            // ctrlClientGroupBrand
            // 
            this.ctrlClientGroupBrand.DataSource = this.bsClient;
            this.ctrlClientGroupBrand.Location = new System.Drawing.Point(19, 145);
            this.ctrlClientGroupBrand.MaximumSize = new System.Drawing.Size(1000, 54);
            this.ctrlClientGroupBrand.MinimumSize = new System.Drawing.Size(100, 54);
            this.ctrlClientGroupBrand.Name = "ctrlClientGroupBrand";
            this.ctrlClientGroupBrand.Size = new System.Drawing.Size(586, 54);
            this.ctrlClientGroupBrand.TabIndex = 35;
            // 
            // bsClient
            // 
            this.bsClient.DataSource = typeof(ipsFormsDesign.Model.Client);
            // 
            // ctrlConsumerName
            // 
            this.ctrlConsumerName.DataSourceAnketa = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlConsumerName.Location = new System.Drawing.Point(19, 7);
            this.ctrlConsumerName.MaximumSize = new System.Drawing.Size(586, 132);
            this.ctrlConsumerName.MinimumSize = new System.Drawing.Size(586, 132);
            this.ctrlConsumerName.Name = "ctrlConsumerName";
            this.ctrlConsumerName.Size = new System.Drawing.Size(586, 132);
            this.ctrlConsumerName.TabIndex = 34;
            // 
            // pvPlaces
            // 
            this.pvPlaces.AutoScroll = true;
            this.pvPlaces.Controls.Add(this.ctrlPlaces);
            this.pvPlaces.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPlaces.Location = new System.Drawing.Point(134, 5);
            this.pvPlaces.Name = "pvPlaces";
            this.pvPlaces.Size = new System.Drawing.Size(933, 503);
            this.pvPlaces.Text = "Бізнес-точки";
            // 
            // ctrlPlaces
            // 
            this.ctrlPlaces.AutoSize = true;
            this.ctrlPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPlaces.Location = new System.Drawing.Point(0, 0);
            this.ctrlPlaces.Name = "ctrlPlaces";
            this.ctrlPlaces.Size = new System.Drawing.Size(933, 503);
            this.ctrlPlaces.TabIndex = 11;
            // 
            // pvPasport
            // 
            this.pvPasport.Controls.Add(this.radGroupBox3);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(134, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(933, 503);
            this.pvPasport.Text = "Паспортні дані";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.ctrlConsumerPassport);
            this.radGroupBox3.HeaderText = "Паспорт";
            this.radGroupBox3.Location = new System.Drawing.Point(26, 7);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(420, 120);
            this.radGroupBox3.TabIndex = 38;
            this.radGroupBox3.Text = "Паспорт";
            this.radGroupBox3.ThemeName = "Office2013Light";
            // 
            // ctrlConsumerPassport
            // 
            this.ctrlConsumerPassport.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlConsumerPassport.Location = new System.Drawing.Point(5, 21);
            this.ctrlConsumerPassport.MaximumSize = new System.Drawing.Size(410, 94);
            this.ctrlConsumerPassport.MinimumSize = new System.Drawing.Size(410, 94);
            this.ctrlConsumerPassport.Name = "ctrlConsumerPassport";
            this.ctrlConsumerPassport.Size = new System.Drawing.Size(410, 94);
            this.ctrlConsumerPassport.TabIndex = 24;
            // 
            // pvBankRequisites
            // 
            this.pvBankRequisites.Controls.Add(this.ctrlBankAccount);
            this.pvBankRequisites.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBankRequisites.Location = new System.Drawing.Point(134, 5);
            this.pvBankRequisites.Name = "pvBankRequisites";
            this.pvBankRequisites.Size = new System.Drawing.Size(933, 503);
            this.pvBankRequisites.Text = "Банківські реквізити";
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            this.ctrlBankAccount.Location = new System.Drawing.Point(30, 3);
            this.ctrlBankAccount.MaximumSize = new System.Drawing.Size(434, 127);
            this.ctrlBankAccount.MinimumSize = new System.Drawing.Size(434, 127);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(434, 127);
            this.ctrlBankAccount.TabIndex = 1;
            // 
            // pvContacts
            // 
            this.pvContacts.AutoScroll = true;
            this.pvContacts.Controls.Add(this.ctrlContacts);
            this.pvContacts.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvContacts.Location = new System.Drawing.Point(134, 5);
            this.pvContacts.Name = "pvContacts";
            this.pvContacts.Size = new System.Drawing.Size(933, 503);
            this.pvContacts.Text = "Контакти";
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.Location = new System.Drawing.Point(30, 3);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(776, 351);
            this.ctrlContacts.TabIndex = 73;
            // 
            // pvAgreement
            // 
            this.pvAgreement.AutoScroll = true;
            this.pvAgreement.Controls.Add(this.btnLoadPdf);
            this.pvAgreement.Controls.Add(this.ctrlAgreementPhis);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(848, 541);
            this.pvAgreement.Text = "Договір";
            // 
            // btnLoadPdf
            // 
            this.btnLoadPdf.Location = new System.Drawing.Point(517, 400);
            this.btnLoadPdf.Name = "btnLoadPdf";
            this.btnLoadPdf.Size = new System.Drawing.Size(200, 24);
            this.btnLoadPdf.TabIndex = 5;
            this.btnLoadPdf.Text = "Сформувати документ договору";
            this.btnLoadPdf.ThemeName = "Office2013Light";
            this.btnLoadPdf.Click += new System.EventHandler(this.btnLoadPdf_Click);
            // 
            // ctrlAgreementPhis
            // 
            this.ctrlAgreementPhis.IsAttached = false;
            this.ctrlAgreementPhis.LicenseEnabled = true;
            this.ctrlAgreementPhis.Location = new System.Drawing.Point(30, 4);
            this.ctrlAgreementPhis.MinimumSize = new System.Drawing.Size(690, 390);
            this.ctrlAgreementPhis.Name = "ctrlAgreementPhis";
            this.ctrlAgreementPhis.Rights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.ctrlAgreementPhis.Size = new System.Drawing.Size(690, 390);
            this.ctrlAgreementPhis.TabIndex = 1;
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // AnketaConsumerPhis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pageAnketaConsumer);
            this.Name = "AnketaConsumerPhis";
            this.Size = new System.Drawing.Size(987, 551);
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).EndInit();
            this.pageAnketaConsumer.ResumeLayout(false);
            this.pvClientName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsClient)).EndInit();
            this.pvPlaces.ResumeLayout(false);
            this.pvPlaces.PerformLayout();
            this.pvPasport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.pvBankRequisites.ResumeLayout(false);
            this.pvContacts.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageAnketaConsumer;
        private Telerik.WinControls.UI.RadPageViewPage pvClientName;
        private IpsAnketaPersonControl ctrlConsumerName;
        private Telerik.WinControls.UI.RadPageViewPage pvContacts;
        private Telerik.WinControls.UI.RadPageViewPage pvPasport;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private PassportControl ctrlConsumerPassport;
        private Telerik.WinControls.UI.RadPageViewPage pvPlaces;
        private Places.ConsumerPlacesControl ctrlPlaces;
        private Telerik.WinControls.UI.RadPageViewPage pvBankRequisites;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private AgreementWithPlacesControl ctrlAgreementPhis;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private PersonalAddressControl ctrlContacts;
        private IpsClientGroupBrandControl ctrlClientGroupBrand;
        private System.Windows.Forms.BindingSource bsClient;
        private Telerik.WinControls.UI.RadButton btnLoadPdf;
    }
}
