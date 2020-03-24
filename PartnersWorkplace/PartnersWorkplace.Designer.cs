namespace PartnersWorkplace
{
    partial class PartnersWorkplace
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
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvPartnerRegister = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPartners = new IpsViewComponentLibrary.PartnerControls.PartnerControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvPartnerRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvPartnerRegister);
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvPartnerRegister;
            this.pageView.Size = new System.Drawing.Size(1092, 500);
            this.pageView.TabIndex = 0;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
            // 
            // pvPartnerRegister
            // 
            this.pvPartnerRegister.Controls.Add(this.ctrlPartners);
            this.pvPartnerRegister.ItemSize = new System.Drawing.SizeF(138F, 27F);
            this.pvPartnerRegister.Location = new System.Drawing.Point(5, 31);
            this.pvPartnerRegister.Name = "pvPartnerRegister";
            this.pvPartnerRegister.Size = new System.Drawing.Size(1082, 464);
            this.pvPartnerRegister.Text = "Реєстр Представників";
            // 
            // ctrlPartners
            // 
            this.ctrlPartners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPartners.Location = new System.Drawing.Point(0, 0);
            this.ctrlPartners.Name = "ctrlPartners";
            this.ctrlPartners.Size = new System.Drawing.Size(1082, 464);
            this.ctrlPartners.TabIndex = 0;
            // 
            // PartnersWorkplace
            // 
            this.AccessibleDescription = "Represent";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1092, 500);
            this.Controls.Add(this.pageView);
            this.Name = "PartnersWorkplace";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Представники";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvPartnerRegister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvPartnerRegister;
        private IpsViewComponentLibrary.PartnerControls.PartnerControl ctrlPartners;
    }
}