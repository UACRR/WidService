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
            this.radWizard = new Telerik.WinControls.UI.RadWizard();
            this.wizardCompletionPage1 = new Telerik.WinControls.UI.WizardCompletionPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.wizardPage1 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage2 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage3 = new Telerik.WinControls.UI.WizardPage();
            this.wizardPage4 = new Telerik.WinControls.UI.WizardPage();
            this.AnketaCompanySource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radWizard)).BeginInit();
            this.radWizard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnketaCompanySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radWizard
            // 
            this.radWizard.CompletionPage = this.wizardCompletionPage1;
            this.radWizard.Controls.Add(this.panel2);
            this.radWizard.Controls.Add(this.panel3);
            this.radWizard.Controls.Add(this.panel1);
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
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).IsFocusedWizardButton = true;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).Text = "Відміна";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).Text = "Зберегти";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).Text = "Далі   >";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Text = "<   Назад";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Enabled = false;
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
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 584);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(0, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(692, 584);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(0, 81);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(692, 584);
            this.panel5.TabIndex = 5;
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
            ((System.ComponentModel.ISupportInitialize)(this.AnketaCompanySource)).EndInit();
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
    }
}