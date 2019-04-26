namespace IpsViewComponentLibrary.CatalogControls
{
    partial class CatalogDetailForm
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
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlCatalogShowEdition = new IpsViewComponentLibrary.CatalogControls.CatalogShowEdition();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlCatalogShowEdition
            // 
            this.ctrlCatalogShowEdition.DataSource = typeof(ipsFormsDesign.Model.CatalogFile);
            this.ctrlCatalogShowEdition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCatalogShowEdition.Location = new System.Drawing.Point(0, 0);
            this.ctrlCatalogShowEdition.Name = "ctrlCatalogShowEdition";
            this.ctrlCatalogShowEdition.Size = new System.Drawing.Size(841, 399);
            this.ctrlCatalogShowEdition.TabIndex = 0;
            // 
            // CatalogDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 399);
            this.Controls.Add(this.ctrlCatalogShowEdition);
            this.Name = "CatalogDetailForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CatalogDetailForm";
            this.ThemeName = "Office2013Light";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private CatalogShowEdition ctrlCatalogShowEdition;
    }
}
