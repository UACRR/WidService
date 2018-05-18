namespace IpsViewComponentLibrary
{
    partial class IpsServiceComissionControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.mtxtRateCommission = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.mtxtRateCourt = new Telerik.WinControls.UI.RadMaskedEditBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCourt)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(250, 33);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "відрахування, пов\'язані зі збором, розподілом та виплатою винагороди у розмірі";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(4, 43);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(250, 33);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "використання творів у порядку судового провадження становить";
            // 
            // mtxtRateCommission
            // 
            this.mtxtRateCommission.Location = new System.Drawing.Point(270, 18);
            this.mtxtRateCommission.Mask = "00.00 %";
            this.mtxtRateCommission.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.mtxtRateCommission.Name = "mtxtRateCommission";
            this.mtxtRateCommission.PromptChar = '0';
            this.mtxtRateCommission.Size = new System.Drawing.Size(69, 20);
            this.mtxtRateCommission.TabIndex = 5;
            this.mtxtRateCommission.TabStop = false;
            this.mtxtRateCommission.Text = "00,00 %";
            // 
            // mtxtRateCourt
            // 
            this.mtxtRateCourt.Location = new System.Drawing.Point(270, 57);
            this.mtxtRateCourt.Mask = "00.00 %";
            this.mtxtRateCourt.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.mtxtRateCourt.Name = "mtxtRateCourt";
            this.mtxtRateCourt.PromptChar = '0';
            this.mtxtRateCourt.Size = new System.Drawing.Size(69, 20);
            this.mtxtRateCourt.TabIndex = 6;
            this.mtxtRateCourt.TabStop = false;
            this.mtxtRateCourt.Text = "00,00 %";
            // 
            // IpsServiceComissionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mtxtRateCourt);
            this.Controls.Add(this.mtxtRateCommission);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "IpsServiceComissionControl";
            this.Size = new System.Drawing.Size(342, 80);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRateCourt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMaskedEditBox mtxtRateCommission;
        private Telerik.WinControls.UI.RadMaskedEditBox mtxtRateCourt;
    }
}
