namespace IpsViewComponentLibrary
{
    partial class ProlongationWithPlaces
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
            this.ctrlProlongation = new IpsViewComponentLibrary.MiddleControlAgreementProlPlacesType();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlProlongation
            // 
            this.ctrlProlongation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProlongation.Location = new System.Drawing.Point(0, 0);
            this.ctrlProlongation.MinimumSize = new System.Drawing.Size(690, 390);
            this.ctrlProlongation.Name = "ctrlProlongation";
            this.ctrlProlongation.Size = new System.Drawing.Size(871, 515);
            this.ctrlProlongation.TabIndex = 0;
            // 
            // ProlongationWithoutPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 515);
            this.Controls.Add(this.ctrlProlongation);
            this.Name = "ProlongationWithoutPlaces";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Пролонгація договору";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MiddleControlAgreementProlPlacesType ctrlProlongation;
    }
}
