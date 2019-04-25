namespace IpsViewComponentLibrary.CatalogControls
{
    partial class changeComment
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
            this.ctrlComment1 = new IpsViewComponentLibrary.CatalogControls.ctrlComment();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlComment1
            // 
            this.ctrlComment1.BackColor = System.Drawing.Color.White;
            this.ctrlComment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlComment1.Location = new System.Drawing.Point(0, 0);
            this.ctrlComment1.Name = "ctrlComment1";
            this.ctrlComment1.Size = new System.Drawing.Size(659, 409);
            this.ctrlComment1.TabIndex = 0;
            // 
            // changeComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 409);
            this.Controls.Add(this.ctrlComment1);
            this.Name = "changeComment";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "changeComment";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlComment ctrlComment1;
    }
}
