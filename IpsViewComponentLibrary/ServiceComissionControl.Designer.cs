namespace IpsViewComponentLibrary
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
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementAddRhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCourt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(307, 34);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "відрахування, пов\'язані зі збором, розподілом та виплатою винагороди у розмірі";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(4, 47);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(307, 34);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "використання творів у порядку судового провадження становить";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // mtxtRateCommission
            // 
            this.mtxtRateCommission.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.agreementAddRhBindingSource, "RateCommiss", true));
            this.mtxtRateCommission.Location = new System.Drawing.Point(329, 11);
            this.mtxtRateCommission.Mask = "N";
            this.mtxtRateCommission.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mtxtRateCommission.Name = "mtxtRateCommission";
            this.mtxtRateCommission.PromptChar = '0';
            this.mtxtRateCommission.Size = new System.Drawing.Size(69, 21);
            this.mtxtRateCommission.TabIndex = 5;
            this.mtxtRateCommission.TabStop = false;
            this.mtxtRateCommission.Text = "0,00";
            this.mtxtRateCommission.ThemeName = "Office2013Light";
            // 
            // agreementAddRhBindingSource
            // 
            this.agreementAddRhBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAgreementAddRh);
            // 
            // mtxtRateCourt
            // 
            this.mtxtRateCourt.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.agreementAddRhBindingSource, "RateCourt", true));
            this.mtxtRateCourt.Location = new System.Drawing.Point(329, 53);
            this.mtxtRateCourt.Mask = "N";
            this.mtxtRateCourt.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mtxtRateCourt.Name = "mtxtRateCourt";
            this.mtxtRateCourt.PromptChar = '0';
            this.mtxtRateCourt.Size = new System.Drawing.Size(69, 21);
            this.mtxtRateCourt.TabIndex = 6;
            this.mtxtRateCourt.TabStop = false;
            this.mtxtRateCourt.Text = "0,00";
            this.mtxtRateCourt.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.Location = new System.Drawing.Point(402, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(289, 34);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "від сум, отриманих ДО УААСП для Автора";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.Location = new System.Drawing.Point(404, 47);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(285, 34);
            this.radLabel4.TabIndex = 4;
            this.radLabel4.Text = "від суми авторської винагороди, зібраної за таке використання";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // ServiceComissionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
