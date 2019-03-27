namespace workReport
{
    partial class WorkReportForm
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.registerListControl1 = new IpsViewComponentLibrary.RegisterControls.RegisterListControl();
            this.licenseAgreementListControl1 = new IpsViewComponentLibrary.RightholderControls.LicenseAgreementListControl();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Location = new System.Drawing.Point(-1, 3);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(1109, 554);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.ThemeName = "Office2013Light";
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.registerListControl1);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(64F, 25F);
            this.radPageViewPage1.Location = new System.Drawing.Point(5, 29);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(1099, 520);
            this.radPageViewPage1.Text = "Звіти МП";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.licenseAgreementListControl1);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(121F, 25F);
            this.radPageViewPage2.Location = new System.Drawing.Point(5, 31);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(1099, 557);
            this.radPageViewPage2.Text = "Заявки/Довідки ВП";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(993, 563);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Вихід";
            this.radButton1.ThemeName = "Office2013Light";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // registerListControl1
            // 
            this.registerListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerListControl1.Location = new System.Drawing.Point(0, 0);
            this.registerListControl1.Name = "registerListControl1";
            this.registerListControl1.SelectedRegister = null;
            this.registerListControl1.Size = new System.Drawing.Size(1099, 520);
            this.registerListControl1.TabIndex = 0;
            // 
            // licenseAgreementListControl1
            // 
            this.licenseAgreementListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licenseAgreementListControl1.Location = new System.Drawing.Point(0, 0);
            this.licenseAgreementListControl1.Name = "licenseAgreementListControl1";
            this.licenseAgreementListControl1.SelectedLicenseAgreement = null;
            this.licenseAgreementListControl1.Size = new System.Drawing.Size(1099, 557);
            this.licenseAgreementListControl1.TabIndex = 0;
            // 
            // WorkReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 593);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radPageView1);
            this.Name = "WorkReportForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Управління розподілу АВ";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private IpsViewComponentLibrary.RegisterControls.RegisterListControl registerListControl1;
        private IpsViewComponentLibrary.RightholderControls.LicenseAgreementListControl licenseAgreementListControl1;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}