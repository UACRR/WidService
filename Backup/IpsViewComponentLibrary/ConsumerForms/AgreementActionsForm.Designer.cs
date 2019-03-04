using IpsViewComponentLibrary.ConsumerControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class AgreementActionsForm
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
            this.ctrlProlongation = new AgreementWithPlacesControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlSaveCancelButtons = new IpsViewComponentLibrary.ExtensionControls.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlProlongation
            // 
            this.ctrlProlongation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProlongation.IsAttached = false;
            this.ctrlProlongation.LicenseEnabled = true;
            this.ctrlProlongation.Location = new System.Drawing.Point(0, 0);
            this.ctrlProlongation.MinimumSize = new System.Drawing.Size(690, 390);
            this.ctrlProlongation.Name = "ctrlProlongation";
            this.ctrlProlongation.Rights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.ctrlProlongation.Size = new System.Drawing.Size(871, 484);
            this.ctrlProlongation.TabIndex = 0;
            // 
            // ctrlSaveCancelButtons
            // 
            this.ctrlSaveCancelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancelButtons.Location = new System.Drawing.Point(0, 484);
            this.ctrlSaveCancelButtons.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancelButtons.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancelButtons.Name = "ctrlSaveCancelButtons";
            this.ctrlSaveCancelButtons.Size = new System.Drawing.Size(871, 31);
            this.ctrlSaveCancelButtons.TabIndex = 1;
            // 
            // ProlongationAgreementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 515);
            this.Controls.Add(this.ctrlProlongation);
            this.Controls.Add(this.ctrlSaveCancelButtons);
            this.Name = "ProlongationAgreementForm";
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

        private AgreementWithPlacesControl ctrlProlongation;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private ExtensionControls.SaveCancelButtonsControl ctrlSaveCancelButtons;
    }
}
