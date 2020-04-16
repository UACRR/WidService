namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    partial class ServiceComissionControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.mtxtRateCommission = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.agreementAddRhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mtxtRateCourt = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementAddRhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCourt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(319, 34);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "збір за управління, необхідний для покриття витрат на забезпечення діяльності Під" +
    "приємства";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(4, 47);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(319, 34);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "у випадку стягнення у порядку судового провадження за бездоговірне (позаліцензійн" +
    "е) використання";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // mtxtRateCommission
            // 
            this.mtxtRateCommission.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agreementAddRhBindingSource, "RateCommiss", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.mtxtRateCommission.Location = new System.Drawing.Point(329, 11);
            this.mtxtRateCommission.Mask = "N0";
            this.mtxtRateCommission.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mtxtRateCommission.Name = "mtxtRateCommission";
            this.mtxtRateCommission.PromptChar = '0';
            this.mtxtRateCommission.Size = new System.Drawing.Size(69, 21);
            this.mtxtRateCommission.TabIndex = 5;
            this.mtxtRateCommission.TabStop = false;
            this.mtxtRateCommission.Text = "0";
            this.mtxtRateCommission.ThemeName = "Office2013Light";
            this.mtxtRateCommission.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtRateCommission_Validating);
            // 
            // agreementAddRhBindingSource
            // 
            this.agreementAddRhBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAgreementAddRh);
            // 
            // mtxtRateCourt
            // 
            this.mtxtRateCourt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agreementAddRhBindingSource, "RateCourt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.mtxtRateCourt.Location = new System.Drawing.Point(329, 53);
            this.mtxtRateCourt.Mask = "N0";
            this.mtxtRateCourt.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mtxtRateCourt.Name = "mtxtRateCourt";
            this.mtxtRateCourt.PromptChar = '0';
            this.mtxtRateCourt.Size = new System.Drawing.Size(69, 21);
            this.mtxtRateCourt.TabIndex = 6;
            this.mtxtRateCourt.TabStop = false;
            this.mtxtRateCourt.Text = "0";
            this.mtxtRateCourt.ThemeName = "Office2013Light";
            this.mtxtRateCourt.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtRateCourt_Validating);
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.Location = new System.Drawing.Point(404, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(287, 34);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "від сум, зібраних Підприємством для Правовласника";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.Location = new System.Drawing.Point(404, 47);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(285, 34);
            this.radLabel4.TabIndex = 4;
            this.radLabel4.Text = "від суми, зібраної (стягнутої)  авторської винагороди (компенсації)";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // ServiceComissionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.mtxtRateCourt);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.mtxtRateCommission);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "ServiceComissionControl";
            this.Size = new System.Drawing.Size(693, 85);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementAddRhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCourt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMaskedEditBox mtxtRateCommission;
        private Telerik.WinControls.UI.RadMaskedEditBox mtxtRateCourt;
        private System.Windows.Forms.BindingSource agreementAddRhBindingSource;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
