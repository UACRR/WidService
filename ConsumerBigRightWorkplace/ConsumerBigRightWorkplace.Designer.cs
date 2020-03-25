namespace ConsumerBigRightWorkplace
{
    partial class ConsumerBigRightWorkplace
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
            this.pageParentConsumers = new Telerik.WinControls.UI.RadPageView();
            this.pvConsumers = new Telerik.WinControls.UI.RadPageViewPage();
            this.mainGridBigRight = new IpsViewComponentLibrary.ConsumerControls.ConsumersViewBigRightControl();
            this.treeViewBigRight = new Telerik.WinControls.UI.RadTreeView();
            this.pvPays = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlImportDBF = new IpsViewComponentLibrary.ImportDBF.ImportDBFControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.pageParentConsumers)).BeginInit();
            this.pageParentConsumers.SuspendLayout();
            this.pvConsumers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewBigRight)).BeginInit();
            this.pvPays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageParentConsumers
            // 
            this.pageParentConsumers.Controls.Add(this.pvConsumers);
            this.pageParentConsumers.Controls.Add(this.pvPays);
            this.pageParentConsumers.DefaultPage = this.pvConsumers;
            this.pageParentConsumers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageParentConsumers.Location = new System.Drawing.Point(0, 0);
            this.pageParentConsumers.Margin = new System.Windows.Forms.Padding(0);
            this.pageParentConsumers.Name = "pageParentConsumers";
            this.pageParentConsumers.SelectedPage = this.pvConsumers;
            this.pageParentConsumers.Size = new System.Drawing.Size(1318, 567);
            this.pageParentConsumers.TabIndex = 1;
            this.pageParentConsumers.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageParentConsumers.GetChildAt(0))).StripScrollingAnimation = Telerik.WinControls.RadEasingType.Linear;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageParentConsumers.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageParentConsumers.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageParentConsumers.GetChildAt(0))).Margin = new System.Windows.Forms.Padding(0);
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageParentConsumers.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageParentConsumers.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(2);
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageParentConsumers.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // pvConsumers
            // 
            this.pvConsumers.Controls.Add(this.mainGridBigRight);
            this.pvConsumers.Controls.Add(this.treeViewBigRight);
            this.pvConsumers.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvConsumers.Location = new System.Drawing.Point(10, 32);
            this.pvConsumers.Name = "pvConsumers";
            this.pvConsumers.Size = new System.Drawing.Size(1302, 529);
            this.pvConsumers.Text = "Реєстр Користувачів";
            // 
            // mainGridBigRight
            // 
            this.mainGridBigRight.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            this.mainGridBigRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGridBigRight.Location = new System.Drawing.Point(199, 0);
            this.mainGridBigRight.Margin = new System.Windows.Forms.Padding(4);
            this.mainGridBigRight.Name = "mainGridBigRight";
            this.mainGridBigRight.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.mainGridBigRight.Size = new System.Drawing.Size(1103, 529);
            this.mainGridBigRight.TabIndex = 3;
            // 
            // treeViewBigRight
            // 
            this.treeViewBigRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewBigRight.HotTracking = false;
            this.treeViewBigRight.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Dash;
            this.treeViewBigRight.Location = new System.Drawing.Point(0, 0);
            this.treeViewBigRight.Name = "treeViewBigRight";
            this.treeViewBigRight.Size = new System.Drawing.Size(199, 529);
            this.treeViewBigRight.SpacingBetweenNodes = -1;
            this.treeViewBigRight.TabIndex = 2;
            this.treeViewBigRight.ThemeName = "Office2013Light";
            // 
            // pvPays
            // 
            this.pvPays.Controls.Add(this.ctrlImportDBF);
            this.pvPays.ItemSize = new System.Drawing.SizeF(105F, 27F);
            this.pvPays.Location = new System.Drawing.Point(10, 32);
            this.pvPays.Name = "pvPays";
            this.pvPays.Size = new System.Drawing.Size(1302, 529);
            this.pvPays.Text = "Розбір платежів";
            // 
            // ctrlImportDBF
            // 
            this.ctrlImportDBF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlImportDBF.Location = new System.Drawing.Point(0, 0);
            this.ctrlImportDBF.Name = "ctrlImportDBF";
            this.ctrlImportDBF.Size = new System.Drawing.Size(1302, 529);
            this.ctrlImportDBF.TabIndex = 1;
            this.ctrlImportDBF.TypeRights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            // 
            // ConsumerBigRightWorkplace
            // 
            this.AccessibleDescription = "Consum(BR)";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1318, 567);
            this.Controls.Add(this.pageParentConsumers);
            this.Name = "ConsumerBigRightWorkplace";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Великі права";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageParentConsumers)).EndInit();
            this.pageParentConsumers.ResumeLayout(false);
            this.pvConsumers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewBigRight)).EndInit();
            this.pvPays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageParentConsumers;
        private Telerik.WinControls.UI.RadPageViewPage pvConsumers;
        private IpsViewComponentLibrary.ConsumerControls.ConsumersViewBigRightControl mainGridBigRight;
        private Telerik.WinControls.UI.RadTreeView treeViewBigRight;
        private Telerik.WinControls.UI.RadPageViewPage pvPays;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private IpsViewComponentLibrary.ImportDBF.ImportDBFControl ctrlImportDBF;
    }
}