namespace CustomerWizards
{
    partial class WizardCustomerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardCustomerView));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radWizard = new Telerik.WinControls.UI.RadWizard();
            this.wizardCompletionPage1 = new Telerik.WinControls.UI.WizardCompletionPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BankAccountSource = new System.Windows.Forms.BindingSource(this.components);
            this.wizardPage1 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage2 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage3 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage4 = new Telerik.WinControls.UI.WizardPage();
            this.AnketaCompanySource = new System.Windows.Forms.BindingSource(this.components);
            this.ipsBankAccountControl = new IpsViewComponentLibrary.IpsBankAccountControl();
            this.ipsExclusionsLimitations = new IpsViewComponentLibrary.IpsExclusionsLimitationsControl();
            ((System.ComponentModel.ISupportInitialize)(this.radWizard)).BeginInit();
            this.radWizard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BankAccountSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnketaCompanySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtAccountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtTransitNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsExclusionsLimitations.GridExclusionsLimitations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsExclusionsLimitations.GridExclusionsLimitations.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radWizard
            // 
            this.radWizard.CompletionPage = this.wizardCompletionPage1;
            this.radWizard.Controls.Add(this.panel2);
            this.radWizard.Controls.Add(this.panel1);
            this.radWizard.Controls.Add(this.panel3);
            this.radWizard.Controls.Add(this.panel4);
            this.radWizard.Controls.Add(this.panel5);
            this.radWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radWizard.Location = new System.Drawing.Point(0, 0);
            this.radWizard.Name = "radWizard";
            this.radWizard.PageHeaderIcon = ((System.Drawing.Image)(resources.GetObject("radWizard.PageHeaderIcon")));
            this.radWizard.Pages.Add(this.wizardPage1);
            this.radWizard.Pages.Add(this.wizardPage2);
            this.radWizard.Pages.Add(this.wizardPage3);
            this.radWizard.Pages.Add(this.wizardPage4);
            this.radWizard.Pages.Add(this.wizardCompletionPage1);
            this.radWizard.Size = new System.Drawing.Size(692, 604);
            this.radWizard.TabIndex = 0;
            this.radWizard.WelcomePage = null;
            ((Telerik.WinControls.UI.Wizard97CommandArea)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3))).IsWelcomePage = false;
            ((Telerik.WinControls.UI.Wizard97CommandArea)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3))).IsCompletionPage = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).Text = "Відміна";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).Text = "Зберегти";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).IsFocusedWizardButton = true;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).Text = "Далі   >";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Text = "<   Назад";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Enabled = true;
            // 
            // wizardCompletionPage1
            // 
            this.wizardCompletionPage1.ContentArea = this.panel3;
            this.wizardCompletionPage1.Name = "wizardCompletionPage1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(150, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 609);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 475);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ipsExclusionsLimitations);
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 475);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(0, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(692, 475);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.ipsBankAccountControl);
            this.panel5.Location = new System.Drawing.Point(0, 81);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(692, 475);
            this.panel5.TabIndex = 5;
            // 
            // BankAccountSource
            // 
            this.BankAccountSource.DataSource = typeof(ipsFormsDesign.Interfaces.IBankAccount);
            // 
            // wizardPage1
            // 
            this.wizardPage1.ContentArea = this.panel2;
            this.wizardPage1.Header = "Анкета правовласника (юридична особа)";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Title = "Анкета";
            // 
            // wizardPage2
            // 
            this.wizardPage2.ContentArea = this.panel1;
            this.wizardPage2.Header = "Page header ...";
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Title = "Виключення та обмеження";
            // 
            // wizardPage3
            // 
            this.wizardPage3.ContentArea = this.panel4;
            this.wizardPage3.Header = "Page header ...";
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Title = "Комісії обслуговування";
            // 
            // wizardPage4
            // 
            this.wizardPage4.ContentArea = this.panel5;
            this.wizardPage4.Header = "Page header ...";
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.Title = "Банківські реквізити";
            // 
            // AnketaCompanySource
            // 
            this.AnketaCompanySource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            // 
            // ipsBankAccountControl
            // 
            this.ipsBankAccountControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.Location = new System.Drawing.Point(13, 4);
            this.ipsBankAccountControl.Name = "ipsBankAccountControl";
            this.ipsBankAccountControl.Size = new System.Drawing.Size(667, 127);
            this.ipsBankAccountControl.TabIndex = 0;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountSource, "AccountNumber", true));
            this.ipsBankAccountControl.TxtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipsBankAccountControl.TxtAccountNumber.Location = new System.Drawing.Point(118, 103);
            this.ipsBankAccountControl.TxtAccountNumber.Name = "txtAccountNumber";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtAccountNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 103, 100, 20);
            this.ipsBankAccountControl.TxtAccountNumber.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtAccountNumber.Size = new System.Drawing.Size(544, 20);
            this.ipsBankAccountControl.TxtAccountNumber.TabIndex = 5;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtMfo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountSource, "Mfo", true));
            this.ipsBankAccountControl.TxtMfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipsBankAccountControl.TxtMfo.Location = new System.Drawing.Point(118, 28);
            this.ipsBankAccountControl.TxtMfo.Name = "txtMfo";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfo.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 28, 100, 20);
            this.ipsBankAccountControl.TxtMfo.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtMfo.Size = new System.Drawing.Size(544, 20);
            this.ipsBankAccountControl.TxtMfo.TabIndex = 8;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtMfoName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountSource, "MfoName", true));
            this.ipsBankAccountControl.TxtMfoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipsBankAccountControl.TxtMfoName.Location = new System.Drawing.Point(118, 3);
            this.ipsBankAccountControl.TxtMfoName.Name = "txtMfoName";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoName.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 3, 100, 20);
            this.ipsBankAccountControl.TxtMfoName.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtMfoName.Size = new System.Drawing.Size(544, 20);
            this.ipsBankAccountControl.TxtMfoName.TabIndex = 9;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoOkpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtMfoOkpo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountSource, "MfoOkpo", true));
            this.ipsBankAccountControl.TxtMfoOkpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipsBankAccountControl.TxtMfoOkpo.Location = new System.Drawing.Point(118, 53);
            this.ipsBankAccountControl.TxtMfoOkpo.Name = "txtMfoOkpo";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtMfoOkpo.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 53, 100, 20);
            this.ipsBankAccountControl.TxtMfoOkpo.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtMfoOkpo.Size = new System.Drawing.Size(544, 20);
            this.ipsBankAccountControl.TxtMfoOkpo.TabIndex = 7;
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtTransitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl.TxtTransitNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountSource, "TransitNumber", true));
            this.ipsBankAccountControl.TxtTransitNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipsBankAccountControl.TxtTransitNumber.Location = new System.Drawing.Point(118, 78);
            this.ipsBankAccountControl.TxtTransitNumber.Name = "txtTransitNumber";
            // 
            // 
            // 
            this.ipsBankAccountControl.TxtTransitNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 78, 100, 20);
            this.ipsBankAccountControl.TxtTransitNumber.RootElement.StretchVertically = true;
            this.ipsBankAccountControl.TxtTransitNumber.Size = new System.Drawing.Size(544, 20);
            this.ipsBankAccountControl.TxtTransitNumber.TabIndex = 6;
            // 
            // ipsExclusionsLimitations
            // 
            // 
            // 
            // 
            this.ipsExclusionsLimitations.GridExclusionsLimitations.BackColor = System.Drawing.SystemColors.Control;
            this.ipsExclusionsLimitations.GridExclusionsLimitations.Cursor = System.Windows.Forms.Cursors.Default;
            this.ipsExclusionsLimitations.GridExclusionsLimitations.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ipsExclusionsLimitations.GridExclusionsLimitations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ipsExclusionsLimitations.GridExclusionsLimitations.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ipsExclusionsLimitations.GridExclusionsLimitations.Location = new System.Drawing.Point(28, 30);
            // 
            // 
            // 
            this.ipsExclusionsLimitations.GridExclusionsLimitations.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.ipsExclusionsLimitations.GridExclusionsLimitations.Name = "gvExlusionsLimitations";
            this.ipsExclusionsLimitations.GridExclusionsLimitations.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ipsExclusionsLimitations.GridExclusionsLimitations.Size = new System.Drawing.Size(509, 414);
            this.ipsExclusionsLimitations.GridExclusionsLimitations.TabIndex = 0;
            this.ipsExclusionsLimitations.Location = new System.Drawing.Point(12, 0);
            this.ipsExclusionsLimitations.Name = "ipsExclusionsLimitations";
            this.ipsExclusionsLimitations.Size = new System.Drawing.Size(563, 469);
            this.ipsExclusionsLimitations.TabIndex = 0;
            // 
            // WizardCustomerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 604);
            this.Controls.Add(this.radWizard);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "WizardCustomerView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Wizard Rightholder";
            ((System.ComponentModel.ISupportInitialize)(this.radWizard)).EndInit();
            this.radWizard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BankAccountSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnketaCompanySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtAccountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtMfoOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl.TxtTransitNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsExclusionsLimitations.GridExclusionsLimitations.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsExclusionsLimitations.GridExclusionsLimitations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadWizard radWizard;
        private Telerik.WinControls.UI.WizardCompletionPage wizardCompletionPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.WizardPage wizardPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Telerik.WinControls.UI.WizardPage wizardPage2;
        private Telerik.WinControls.UI.WizardPage wizardPage3;
        private Telerik.WinControls.UI.WizardPage wizardPage4;
        private System.Windows.Forms.BindingSource AnketaCompanySource;
        private IpsViewComponentLibrary.IpsBankAccountControl ipsBankAccountControl;
        private System.Windows.Forms.BindingSource BankAccountSource;
        private IpsViewComponentLibrary.IpsExclusionsLimitationsControl ipsExclusionsLimitations;
    }
}