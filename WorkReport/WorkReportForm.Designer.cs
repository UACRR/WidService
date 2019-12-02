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
            this.ctrlRegisterList = new IpsViewComponentLibrary.RegisterControls.RegisterListControl();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlLicenseAgreementList = new IpsViewComponentLibrary.RightholderControls.LicenseAgreementListControl();
            this.pvExternalReport = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlExternalRegisterList = new IpsViewComponentLibrary.RegisterControls.RegisterListControl();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            this.pvExternalReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.pvExternalReport);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Location = new System.Drawing.Point(-1, 3);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(1109, 588);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.ctrlRegisterList);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(66F, 27F);
            this.radPageViewPage1.Location = new System.Drawing.Point(5, 31);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(1099, 552);
            this.radPageViewPage1.Text = "Звіти МП";
            // 
            // ctrlRegisterList
            // 
            this.ctrlRegisterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRegisterList.Location = new System.Drawing.Point(0, 0);
            this.ctrlRegisterList.Name = "ctrlRegisterList";
            this.ctrlRegisterList.SelectedRegister = null;
            this.ctrlRegisterList.Size = new System.Drawing.Size(1099, 552);
            this.ctrlRegisterList.TabIndex = 0;
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.ctrlLicenseAgreementList);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(123F, 27F);
            this.radPageViewPage2.Location = new System.Drawing.Point(5, 31);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(1099, 552);
            this.radPageViewPage2.Text = "Заявки/Довідки ВП";
            // 
            // ctrlLicenseAgreementList
            // 
            this.ctrlLicenseAgreementList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLicenseAgreementList.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicenseAgreementList.Name = "ctrlLicenseAgreementList";
            this.ctrlLicenseAgreementList.SelectedLicenseAgreement = null;
            this.ctrlLicenseAgreementList.Size = new System.Drawing.Size(1099, 552);
            this.ctrlLicenseAgreementList.TabIndex = 0;
            // 
            // pvExternalReport
            // 
            this.pvExternalReport.Controls.Add(this.ctrlExternalRegisterList);
            this.pvExternalReport.ItemSize = new System.Drawing.SizeF(138F, 27F);
            this.pvExternalReport.Location = new System.Drawing.Point(5, 31);
            this.pvExternalReport.Name = "pvExternalReport";
            this.pvExternalReport.Size = new System.Drawing.Size(1099, 552);
            this.pvExternalReport.Text = "Звіти онлайн-ресурси";
            // 
            // ctrlExternalRegisterList
            // 
            this.ctrlExternalRegisterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlExternalRegisterList.Location = new System.Drawing.Point(0, 0);
            this.ctrlExternalRegisterList.Name = "ctrlExternalRegisterList";
            this.ctrlExternalRegisterList.SelectedRegister = null;
            this.ctrlExternalRegisterList.Size = new System.Drawing.Size(1099, 552);
            this.ctrlExternalRegisterList.TabIndex = 1;
            // 
            // WorkReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1109, 593);
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
            this.pvExternalReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private IpsViewComponentLibrary.RegisterControls.RegisterListControl ctrlRegisterList;
        private IpsViewComponentLibrary.RightholderControls.LicenseAgreementListControl ctrlLicenseAgreementList;
        private Telerik.WinControls.UI.RadPageViewPage pvExternalReport;
        private IpsViewComponentLibrary.RegisterControls.RegisterListControl ctrlExternalRegisterList;
    }
}