namespace IpsViewComponentLibrary
{
    partial class ProlongationWithoutPlaces
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
            this.ctrlProlongation = new IpsViewComponentLibrary.MiddleControlAgreementProlType();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlProlongation
            // 
            this.ctrlProlongation.DataSourceAgreement = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlProlongation.DataSourceAnketaCompany = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlProlongation.Dictionaties = null;
            this.ctrlProlongation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProlongation.LicenseName = "license type ";
            this.ctrlProlongation.Location = new System.Drawing.Point(0, 0);
            this.ctrlProlongation.MinimumSize = new System.Drawing.Size(502, 276);
            this.ctrlProlongation.Name = "ctrlProlongation";
            this.ctrlProlongation.Size = new System.Drawing.Size(650, 299);
            this.ctrlProlongation.TabIndex = 0;
            // 
            // ProlongationWithPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 299);
            this.Controls.Add(this.ctrlProlongation);
            this.MaximumSize = new System.Drawing.Size(929, 331);
            this.MinimumSize = new System.Drawing.Size(645, 331);
            this.Name = "ProlongationWithPlaces";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(929, 331);
            this.Text = "Пролонгація договору";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MiddleControlAgreementProlType ctrlProlongation;
    }
}
