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
            this.pvAddress = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvPasport = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlContactPerson = new IpsViewComponentLibrary.IpsBossNameContactsControl();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsViewComponentLibrary.IpsBankAccountControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.txtCourtRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAgreement = new IpsViewComponentLibrary.PartnerControls.AgreementPartnerControl();
            this.ctrlTabNavigation = new IpsViewComponentLibrary.ConsumerControls.TabNavigationControl();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlClienName = new IpsViewComponentLibrary.MiddleControlClientName();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvCommunityName.SuspendLayout();
            this.pvPasport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtSurName)).BeginInit();
            this.pvBank.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCourtRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvCommunityName);
            this.pageView.Controls.Add(this.pvAddress);
            this.pageView.Controls.Add(this.pvPasport);
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
            this.pvCommunityName.Controls.Add(this.ctrlClienName);
            this.pvCommunityName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvCommunityName.Location = new System.Drawing.Point(134, 5);
            this.pvCommunityName.Name = "pvCommunityName";
            this.pvCommunityName.Size = new System.Drawing.Size(872, 498);
            this.pvCommunityName.Text = "Спільнота";
            // 
            // pvAddress
            // 
            this.pvAddress.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAddress.Location = new System.Drawing.Point(134, 5);
            this.pvAddress.Name = "pvAddress";
            this.pvAddress.Size = new System.Drawing.Size(872, 498);
            this.pvAddress.Text = "Адреса";
            // 
            // pvPasport
            // 
            this.pvPasport.Controls.Add(this.radLabel6);
            this.pvPasport.Controls.Add(this.ctrlContactPerson);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(134, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(872, 498);
            this.pvPasport.Text = "Керівники";
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.DataMember = "";
            this.ctrlContactPerson.DataSource = typeof(ipsFormsDesign.Interfaces.IEmployee);
            this.ctrlContactPerson.Location = new System.Drawing.Point(134, 7);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.Size = new System.Drawing.Size(600, 56);
            this.ctrlContactPerson.TabIndex = 0;
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
            this.ctrlContactPerson.TxtEmail.RootElement.ControlBounds = new System.Drawing.Rectangle(425, 242, 175, 20);
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
            this.ctrlContactPerson.TxtPhone.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 242, 173, 20);
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
            this.ctrlContactPerson.TxtSurName.RootElement.ControlBounds = new System.Drawing.Rectangle(425, 4, 175, 20);
            this.ctrlContactPerson.TxtSurName.RootElement.StretchVertically = true;
            this.ctrlContactPerson.TxtSurName.Size = new System.Drawing.Size(175, 21);
            this.ctrlContactPerson.TxtSurName.TabIndex = 2;
            this.ctrlContactPerson.TxtSurName.ThemeName = "Office2013Light";
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
            this.pvAgreement.Controls.Add(this.radLabel4);
            this.pvAgreement.Controls.Add(this.groupBox3);
            this.pvAgreement.Controls.Add(this.ctrlAgreement);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(872, 498);
            this.pvAgreement.Text = "Договір";
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel4.Location = new System.Drawing.Point(218, 152);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(217, 30);
            this.radLabel4.TabIndex = 50;
            this.radLabel4.Text = "Комісії обслуговування";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radLabel2);
            this.groupBox3.Controls.Add(this.radLabel3);
            this.groupBox3.Controls.Add(this.radTextBox1);
            this.groupBox3.Controls.Add(this.radLabel5);
            this.groupBox3.Controls.Add(this.radLabel1);
            this.groupBox3.Controls.Add(this.radLabel13);
            this.groupBox3.Controls.Add(this.txtCourtRate);
            this.groupBox3.Controls.Add(this.radLabel12);
            this.groupBox3.Location = new System.Drawing.Point(22, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 109);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(366, 68);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(291, 35);
            this.radLabel2.TabIndex = 10;
            this.radLabel2.Text = "від суми авторської винагороди, зібраної за таке використання";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel3.Location = new System.Drawing.Point(345, 78);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(15, 18);
            this.radLabel3.TabIndex = 9;
            this.radLabel3.Text = "%";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radTextBox1.Location = new System.Drawing.Point(285, 76);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(54, 21);
            this.radTextBox1.TabIndex = 8;
            this.radTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.radTextBox1.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel5.AutoSize = false;
            this.radLabel5.Location = new System.Drawing.Point(6, 68);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(273, 35);
            this.radLabel5.TabIndex = 7;
            this.radLabel5.Text = "Виеористання творів у порядку судового провадження становить";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(365, 27);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(291, 35);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "від сум, отриманих ДО УААСП для Автора";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel13
            // 
            this.radLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel13.Location = new System.Drawing.Point(344, 37);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(15, 18);
            this.radLabel13.TabIndex = 5;
            this.radLabel13.Text = "%";
            // 
            // txtCourtRate
            // 
            this.txtCourtRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCourtRate.Location = new System.Drawing.Point(284, 35);
            this.txtCourtRate.Name = "txtCourtRate";
            this.txtCourtRate.Size = new System.Drawing.Size(54, 21);
            this.txtCourtRate.TabIndex = 3;
            this.txtCourtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCourtRate.ThemeName = "Office2013Light";
            // 
            // radLabel12
            // 
            this.radLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel12.AutoSize = false;
            this.radLabel12.Location = new System.Drawing.Point(5, 27);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(273, 35);
            this.radLabel12.TabIndex = 2;
            this.radLabel12.Text = "Відрахування пов\'язані зі збором, розподілом та виплатою винагороди у розмірі";
            this.radLabel12.ThemeName = "Office2013Light";
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.Location = new System.Drawing.Point(22, 6);
            this.ctrlAgreement.MaximumSize = new System.Drawing.Size(504, 140);
            this.ctrlAgreement.MinimumSize = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(484, 140);
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
            this.ctrlTabNavigation.TabIndex = 13;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(24, 8);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(104, 19);
            this.radLabel6.TabIndex = 1;
            this.radLabel6.Text = "Контактна особа:";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // ctrlClienName
            // 
            this.ctrlClienName.CheckPlace = false;
            this.ctrlClienName.IsPlaceIn = false;
            this.ctrlClienName.Location = new System.Drawing.Point(22, 6);
            this.ctrlClienName.MaximumSize = new System.Drawing.Size(800, 194);
            this.ctrlClienName.MinimumSize = new System.Drawing.Size(607, 194);
            this.ctrlClienName.Name = "ctrlClienName";
            this.ctrlClienName.Size = new System.Drawing.Size(711, 194);
            this.ctrlClienName.TabIndex = 0;
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
            this.pvPasport.ResumeLayout(false);
            this.pvPasport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlContactPerson.TxtSurName)).EndInit();
            this.pvBank.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            this.pvAgreement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCourtRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvCommunityName;
        private Telerik.WinControls.UI.RadPageViewPage pvAddress;
        private Telerik.WinControls.UI.RadPageViewPage pvPasport;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private PartnerControls.AgreementPartnerControl ctrlAgreement;
        private ConsumerControls.TabNavigationControl ctrlTabNavigation;
        private IpsBossNameContactsControl ctrlContactPerson;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadTextBox txtCourtRate;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private MiddleControlClientName ctrlClienName;
        private Telerik.WinControls.UI.RadLabel radLabel6;
    }
}
