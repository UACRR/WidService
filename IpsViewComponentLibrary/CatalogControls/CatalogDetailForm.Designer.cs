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
            this.catalogShowEdition1 = new IpsViewComponentLibrary.CatalogControls.CatalogShowEdition();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // catalogShowEdition1
            // 
            this.catalogShowEdition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogShowEdition1.Location = new System.Drawing.Point(0, 0);
            this.catalogShowEdition1.Name = "catalogShowEdition1";
            this.catalogShowEdition1.Size = new System.Drawing.Size(841, 399);
            this.catalogShowEdition1.TabIndex = 0;
            // 
            // CatalogDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 399);
            this.Controls.Add(this.catalogShowEdition1);
            this.Name = "CatalogDetailForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CatalogDetailForm";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CatalogShowEdition catalogShowEdition1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
    }
}
