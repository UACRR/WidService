namespace IpsViewComponentLibrary.CatalogControls
{
    partial class ChangeCommentForm
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
            this.ctrlComment = new IpsViewComponentLibrary.CatalogControls.CommentControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlComment
            // 
            this.ctrlComment.DataSource = typeof(ipsFormsDesign.Model.CatalogFile);
            this.ctrlComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlComment.Location = new System.Drawing.Point(0, 0);
            this.ctrlComment.Name = "ctrlComment";
            this.ctrlComment.Size = new System.Drawing.Size(566, 251);
            this.ctrlComment.TabIndex = 0;
            // 
            // ChangeCommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 251);
            this.Controls.Add(this.ctrlComment);
            this.Name = "ChangeCommentForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Коментар";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommentControl ctrlComment;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
