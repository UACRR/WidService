namespace RightholderWorkplace
{
    partial class RightholderWorkplace
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
            this.MainPageView = new Telerik.WinControls.UI.RadPageView();
            this.mainPageRightholders = new Telerik.WinControls.UI.RadPageViewPage();
            this.rightholdersPageView = new Telerik.WinControls.UI.RadPageView();
            this.actualRightholdersPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.notAcceptedRightholdersPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.newRightholdersPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.newRightholdersPageView = new Telerik.WinControls.UI.RadPageView();
            this.newRightholdersListPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.newRightholdersCreatePage = new Telerik.WinControls.UI.RadPageViewPage();
            this.office2007SilverTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.aquaTheme = new Telerik.WinControls.Themes.AquaTheme();
            ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).BeginInit();
            this.MainPageView.SuspendLayout();
            this.mainPageRightholders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightholdersPageView)).BeginInit();
            this.rightholdersPageView.SuspendLayout();
            this.newRightholdersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newRightholdersPageView)).BeginInit();
            this.newRightholdersPageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPageView
            // 
            this.MainPageView.Controls.Add(this.mainPageRightholders);
            this.MainPageView.DefaultPage = this.mainPageRightholders;
            this.MainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageView.Location = new System.Drawing.Point(0, 0);
            this.MainPageView.Name = "MainPageView";
            this.MainPageView.SelectedPage = this.mainPageRightholders;
            this.MainPageView.Size = new System.Drawing.Size(1192, 668);
            this.MainPageView.TabIndex = 0;
            this.MainPageView.ThemeName = "Office2007Silver";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).ShowItemCloseButton = false;
            // 
            // mainPageRightholders
            // 
            this.mainPageRightholders.Controls.Add(this.rightholdersPageView);
            this.mainPageRightholders.ItemSize = new System.Drawing.SizeF(98F, 26F);
            this.mainPageRightholders.Location = new System.Drawing.Point(10, 35);
            this.mainPageRightholders.Name = "mainPageRightholders";
            this.mainPageRightholders.Size = new System.Drawing.Size(1171, 622);
            this.mainPageRightholders.Text = "Правовласники";
            // 
            // rightholdersPageView
            // 
            this.rightholdersPageView.Controls.Add(this.actualRightholdersPage);
            this.rightholdersPageView.Controls.Add(this.notAcceptedRightholdersPage);
            this.rightholdersPageView.Controls.Add(this.newRightholdersPage);
            this.rightholdersPageView.DefaultPage = this.actualRightholdersPage;
            this.rightholdersPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightholdersPageView.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            this.rightholdersPageView.Location = new System.Drawing.Point(0, 0);
            this.rightholdersPageView.Name = "rightholdersPageView";
            this.rightholdersPageView.SelectedPage = this.newRightholdersPage;
            this.rightholdersPageView.Size = new System.Drawing.Size(1171, 622);
            this.rightholdersPageView.TabIndex = 0;
            this.rightholdersPageView.ThemeName = "Office2007Silver";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rightholdersPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rightholdersPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rightholdersPageView.GetChildAt(0))).ItemSpacing = 0;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rightholdersPageView.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.rightholdersPageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // actualRightholdersPage
            // 
            this.actualRightholdersPage.ItemSize = new System.Drawing.SizeF(97F, 26F);
            this.actualRightholdersPage.Location = new System.Drawing.Point(106, 10);
            this.actualRightholdersPage.Name = "actualRightholdersPage";
            this.actualRightholdersPage.Size = new System.Drawing.Size(1054, 601);
            this.actualRightholdersPage.Text = "Діючі";
            // 
            // notAcceptedRightholdersPage
            // 
            this.notAcceptedRightholdersPage.ItemSize = new System.Drawing.SizeF(97F, 26F);
            this.notAcceptedRightholdersPage.Location = new System.Drawing.Point(106, 10);
            this.notAcceptedRightholdersPage.Name = "notAcceptedRightholdersPage";
            this.notAcceptedRightholdersPage.Size = new System.Drawing.Size(1054, 601);
            this.notAcceptedRightholdersPage.Text = "Не акцептовані";
            // 
            // newRightholdersPage
            // 
            this.newRightholdersPage.Controls.Add(this.newRightholdersPageView);
            this.newRightholdersPage.ItemSize = new System.Drawing.SizeF(97F, 26F);
            this.newRightholdersPage.Location = new System.Drawing.Point(106, 10);
            this.newRightholdersPage.Name = "newRightholdersPage";
            this.newRightholdersPage.Size = new System.Drawing.Size(1054, 601);
            this.newRightholdersPage.Text = "Нові";
            // 
            // newRightholdersPageView
            // 
            this.newRightholdersPageView.Controls.Add(this.newRightholdersListPage);
            this.newRightholdersPageView.Controls.Add(this.newRightholdersCreatePage);
            this.newRightholdersPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newRightholdersPageView.Location = new System.Drawing.Point(0, 0);
            this.newRightholdersPageView.Name = "newRightholdersPageView";
            this.newRightholdersPageView.SelectedPage = this.newRightholdersCreatePage;
            this.newRightholdersPageView.Size = new System.Drawing.Size(1054, 601);
            this.newRightholdersPageView.TabIndex = 1;
            this.newRightholdersPageView.ThemeName = "Office2007Silver";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.newRightholdersPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.newRightholdersPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.newRightholdersPageView.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // newRightholdersListPage
            // 
            this.newRightholdersListPage.Location = new System.Drawing.Point(10, 10);
            this.newRightholdersListPage.Name = "newRightholdersListPage";
            this.newRightholdersListPage.Size = new System.Drawing.Size(1033, 580);
            this.newRightholdersListPage.Text = "newRightholdersListPage";
            // 
            // newRightholdersCreatePage
            // 
            this.newRightholdersCreatePage.Location = new System.Drawing.Point(10, 10);
            this.newRightholdersCreatePage.Name = "newRightholdersCreatePage";
            this.newRightholdersCreatePage.Size = new System.Drawing.Size(1033, 580);
            this.newRightholdersCreatePage.Text = "newRightholdersCreatePage";
            // 
            // RightholderWorkplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 668);
            this.Controls.Add(this.MainPageView);
            this.Name = "RightholderWorkplace";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Робоче місце адмінстратора права";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).EndInit();
            this.MainPageView.ResumeLayout(false);
            this.mainPageRightholders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightholdersPageView)).EndInit();
            this.rightholdersPageView.ResumeLayout(false);
            this.newRightholdersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newRightholdersPageView)).EndInit();
            this.newRightholdersPageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView MainPageView;
        private Telerik.WinControls.UI.RadPageViewPage mainPageRightholders;
        private Telerik.WinControls.UI.RadPageView rightholdersPageView;
        private Telerik.WinControls.UI.RadPageViewPage actualRightholdersPage;
        private Telerik.WinControls.UI.RadPageViewPage notAcceptedRightholdersPage;
        private Telerik.WinControls.UI.RadPageViewPage newRightholdersPage;
        private Telerik.WinControls.UI.RadPageView newRightholdersPageView;
        private Telerik.WinControls.UI.RadPageViewPage newRightholdersListPage;
        private Telerik.WinControls.UI.RadPageViewPage newRightholdersCreatePage;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme;
        private Telerik.WinControls.Themes.AquaTheme aquaTheme;
    }
}