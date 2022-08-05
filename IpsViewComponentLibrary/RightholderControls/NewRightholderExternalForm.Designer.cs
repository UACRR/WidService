namespace IpsViewComponentLibrary.RightholderControls
{
    partial class NewRightholderExternalForm
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
            this.pageViewExternalRightholder = new Telerik.WinControls.UI.RadPageView();
            this.pvRightHolder = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAnketaExternalRightholder = new IpsViewComponentLibrary.RightholderControls.Anketa.AnketaExternalRightholderControl();
            this.pvRightExclude = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctelRightLimitationsExternal = new IpsViewComponentLibrary.RightholderControls.Anketa.RightLimitationsControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlTabNavigation = new IpsViewComponentLibrary.Common.TabNavigationControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageViewExternalRightholder)).BeginInit();
            this.pageViewExternalRightholder.SuspendLayout();
            this.pvRightHolder.SuspendLayout();
            this.pvRightExclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageViewExternalRightholder
            // 
            this.pageViewExternalRightholder.Controls.Add(this.pvRightHolder);
            this.pageViewExternalRightholder.Controls.Add(this.pvRightExclude);
            this.pageViewExternalRightholder.DefaultPage = this.pvRightHolder;
            this.pageViewExternalRightholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageViewExternalRightholder.Location = new System.Drawing.Point(0, 0);
            this.pageViewExternalRightholder.Name = "pageViewExternalRightholder";
            this.pageViewExternalRightholder.SelectedPage = this.pvRightHolder;
            this.pageViewExternalRightholder.Size = new System.Drawing.Size(1087, 457);
            this.pageViewExternalRightholder.TabIndex = 4;
            this.pageViewExternalRightholder.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewExternalRightholder.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewExternalRightholder.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewExternalRightholder.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvRightHolder
            // 
            this.pvRightHolder.Controls.Add(this.ctrlAnketaExternalRightholder);
            this.pvRightHolder.ItemSize = new System.Drawing.SizeF(113F, 27F);
            this.pvRightHolder.Location = new System.Drawing.Point(117, 5);
            this.pvRightHolder.Name = "pvRightHolder";
            this.pvRightHolder.Size = new System.Drawing.Size(965, 447);
            this.pvRightHolder.Text = "Правовласник";
            // 
            // ctrlAnketaExternalRightholder
            // 
            this.ctrlAnketaExternalRightholder.DataSourceAnketaExternal = typeof(ipsFormsDesign.Model.AnketaExternal);
            this.ctrlAnketaExternalRightholder.DataSourceRightHolder = typeof(ipsFormsDesign.Model.RightHolder);
            this.ctrlAnketaExternalRightholder.Location = new System.Drawing.Point(3, 3);
            this.ctrlAnketaExternalRightholder.MaximumSize = new System.Drawing.Size(700, 136);
            this.ctrlAnketaExternalRightholder.MinimumSize = new System.Drawing.Size(400, 136);
            this.ctrlAnketaExternalRightholder.Name = "ctrlAnketaExternalRightholder";
            this.ctrlAnketaExternalRightholder.Size = new System.Drawing.Size(527, 136);
            this.ctrlAnketaExternalRightholder.TabIndex = 0;
            // 
            // pvRightExclude
            // 
            this.pvRightExclude.Controls.Add(this.ctelRightLimitationsExternal);
            this.pvRightExclude.ItemSize = new System.Drawing.SizeF(113F, 27F);
            this.pvRightExclude.Location = new System.Drawing.Point(117, 5);
            this.pvRightExclude.Name = "pvRightExclude";
            this.pvRightExclude.Size = new System.Drawing.Size(965, 447);
            this.pvRightExclude.Text = "Обмеження прав";
            // 
            // ctelRightLimitationsExternal
            // 
            this.ctelRightLimitationsExternal.DataSource = typeof(ipsFormsDesign.Dictionary.TermsOfServiceWrapper);
            this.ctelRightLimitationsExternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctelRightLimitationsExternal.IsExternalRightHolder = false;
            this.ctelRightLimitationsExternal.Location = new System.Drawing.Point(0, 0);
            this.ctelRightLimitationsExternal.Name = "ctelRightLimitationsExternal";
            this.ctelRightLimitationsExternal.Size = new System.Drawing.Size(965, 447);
            this.ctelRightLimitationsExternal.TabIndex = 0;
            // 
            // ctrlTabNavigation
            // 
            this.ctrlTabNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigation.Location = new System.Drawing.Point(0, 457);
            this.ctrlTabNavigation.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigation.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigation.Name = "ctrlTabNavigation";
            this.ctrlTabNavigation.Size = new System.Drawing.Size(1087, 31);
            this.ctrlTabNavigation.TabIndex = 5;
            // 
            // NewRightholderExternalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1087, 488);
            this.Controls.Add(this.pageViewExternalRightholder);
            this.Controls.Add(this.ctrlTabNavigation);
            this.Name = "NewRightholderExternalForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "(Новий) - Анкета зовнішнього правовласника";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageViewExternalRightholder)).EndInit();
            this.pageViewExternalRightholder.ResumeLayout(false);
            this.pvRightHolder.ResumeLayout(false);
            this.pvRightExclude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageViewExternalRightholder;
        private Telerik.WinControls.UI.RadPageViewPage pvRightHolder;
        private Anketa.AnketaExternalRightholderControl ctrlAnketaExternalRightholder;
        private Telerik.WinControls.UI.RadPageViewPage pvRightExclude;
        private Anketa.RightLimitationsControl ctelRightLimitationsExternal;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Common.TabNavigationControl ctrlTabNavigation;
    }
}