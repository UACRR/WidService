namespace DdexInvoicing
{
    partial class FormTraceRoyaltyCalc
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
            this.ucTraceRoyaltyCalc = new DdexInvoicing.UcTraceRoyaltyCalc();
            this.SuspendLayout();
            // 
            // ucTraceRoyaltyCalc
            // 
            this.ucTraceRoyaltyCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTraceRoyaltyCalc.Location = new System.Drawing.Point(10, 0);
            this.ucTraceRoyaltyCalc.Name = "ucTraceRoyaltyCalc";
            this.ucTraceRoyaltyCalc.Size = new System.Drawing.Size(780, 450);
            this.ucTraceRoyaltyCalc.TabIndex = 0;
            // 
            // FormTraceRoyaltyCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucTraceRoyaltyCalc);
            this.Name = "FormTraceRoyaltyCalc";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Text = "FormTraceRoyaltyCalc";
            this.Load += new System.EventHandler(this.FormTraceRoyaltyCalc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UcTraceRoyaltyCalc ucTraceRoyaltyCalc;
    }
}