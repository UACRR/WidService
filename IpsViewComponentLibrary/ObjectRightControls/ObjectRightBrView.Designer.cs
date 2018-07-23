namespace IpsViewComponentLibrary.ObjectRightControls
{
    partial class ObjectRightBrView
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
            this.ctrlObjectRightInfo = new IpsViewComponentLibrary.ObjectRightControls.ObjectRightBrInfoControl();
            this.ctrlAuthorRightholderList = new IpsViewComponentLibrary.ObjectRightControls.AuthorRightholderBrListControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlObjectRightInfo
            // 
            this.ctrlObjectRightInfo.LicenseBigRDataSource = typeof(ipsFormsDesign.Model.LicenseBigR);
            this.ctrlObjectRightInfo.Location = new System.Drawing.Point(0, 1);
            this.ctrlObjectRightInfo.Name = "ctrlObjectRightInfo";
            this.ctrlObjectRightInfo.ObjectRightDataSource = typeof(ipsFormsDesign.Model.ObjectRight);
            this.ctrlObjectRightInfo.Size = new System.Drawing.Size(469, 110);
            this.ctrlObjectRightInfo.TabIndex = 0;
            // 
            // ctrlAuthorRightholderList
            // 
            this.ctrlAuthorRightholderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAuthorRightholderList.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectAuthorRightholderBrViewModel);
            this.ctrlAuthorRightholderList.ListMode = IpsViewComponentLibrary.ObjectRightControls.AuthorRightholderBrListMode.Full;
            this.ctrlAuthorRightholderList.Location = new System.Drawing.Point(0, 117);
            this.ctrlAuthorRightholderList.Name = "ctrlAuthorRightholderList";
            this.ctrlAuthorRightholderList.SelectedAuthorRightholder = null;
            this.ctrlAuthorRightholderList.Size = new System.Drawing.Size(960, 351);
            this.ctrlAuthorRightholderList.TabIndex = 1;
            // 
            // ObjectRightBrView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 515);
            this.Controls.Add(this.ctrlAuthorRightholderList);
            this.Controls.Add(this.ctrlObjectRightInfo);
            this.Name = "ObjectRightBrView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Об\'єкт права";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private ObjectRightBrInfoControl ctrlObjectRightInfo;
        private AuthorRightholderBrListControl ctrlAuthorRightholderList;
    }
}
