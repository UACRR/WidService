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
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.ctrlAuthorRightholderList = new IpsViewComponentLibrary.ObjectRightControls.AuthorRightholderBrListControl();
            this.ctrlObjectRightInfo = new IpsViewComponentLibrary.ObjectRightControls.ObjectRightBrInfoControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(782, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(601, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 24);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radPanel1.Location = new System.Drawing.Point(0, 484);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(960, 31);
            this.radPanel1.TabIndex = 18;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // ctrlAuthorRightholderList
            // 
            this.ctrlAuthorRightholderList.AllowEditList = false;
            this.ctrlAuthorRightholderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAuthorRightholderList.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectAuthorRightholderBrViewModel);
            this.ctrlAuthorRightholderList.ListMode = IpsViewComponentLibrary.ObjectRightControls.AuthorRightholderBrListMode.Full;
            this.ctrlAuthorRightholderList.Location = new System.Drawing.Point(0, 117);
            this.ctrlAuthorRightholderList.Name = "ctrlAuthorRightholderList";
            this.ctrlAuthorRightholderList.SelectedAuthorRightholder = null;
            this.ctrlAuthorRightholderList.Size = new System.Drawing.Size(960, 361);
            this.ctrlAuthorRightholderList.TabIndex = 1;
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
            // ObjectRightBrView
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(960, 515);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.ctrlAuthorRightholderList);
            this.Controls.Add(this.ctrlObjectRightInfo);
            this.Name = "ObjectRightBrView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Об\'єкт права";
            this.ThemeName = "Office2013Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ObjectRightBrView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private ObjectRightBrInfoControl ctrlObjectRightInfo;
        private AuthorRightholderBrListControl ctrlAuthorRightholderList;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
