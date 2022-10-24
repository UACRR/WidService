using IpsViewComponentLibrary.ConsumerControls.SmallRight;

namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class CabinetSmallRightForm
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.cabinet = new IpsViewComponentLibrary.ConsumerControls.SmallRight.CabinetSmallRight();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cabinet
            // 
            this.cabinet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cabinet.Location = new System.Drawing.Point(0, 0);
            this.cabinet.Name = "cabinet";
            this.cabinet.Rights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.cabinet.Size = new System.Drawing.Size(1070, 774);
            this.cabinet.TabIndex = 0;
            // 
            // CabinetSmallRightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1070, 774);
            this.Controls.Add(this.cabinet);
            this.Name = "CabinetSmallRightForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Кабінет користувача";
            this.ThemeName = "Office2013Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CabinetSmallRightForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        public CabinetSmallRight cabinet;
    }
}
