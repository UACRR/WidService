namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class ProlongationAgreementForm
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlProlongation
            // 
            this.ctrlProlongation.ClientName = "Назва «Клієнта»";
            this.ctrlProlongation.Dictionaties = null;
            this.ctrlProlongation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProlongation.IsAttached = false;
            this.ctrlProlongation.LicenseEnabled = true;
            this.ctrlProlongation.Location = new System.Drawing.Point(0, 0);
            this.ctrlProlongation.MinimumSize = new System.Drawing.Size(690, 390);
            this.ctrlProlongation.Name = "ctrlProlongation";
            this.ctrlProlongation.Rights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.ctrlProlongation.Size = new System.Drawing.Size(871, 515);
            this.ctrlProlongation.TabIndex = 0;
            // 
            // ProlongationWithPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 515);
            this.Controls.Add(this.ctrlProlongation);
            this.Name = "ProlongationWithPlaces";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Пролонгація договору";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MiddleControlAgreementProlPlacesType ctrlProlongation;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
