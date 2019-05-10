namespace ConsumerSmallRightWorkplace
{
    partial class ConsumerSmallRightWorkplace
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
            this.pageParentConsumers = new Telerik.WinControls.UI.RadPageView();
            this.pvConsumers = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlConsumersViewSmallRight = new IpsViewComponentLibrary.ConsumerControls.ConsumersViewSmallRightControl();
            this.treeViewSmallRight = new Telerik.WinControls.UI.RadTreeView();
            this.pvPays = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlImportDBF = new IpsViewComponentLibrary.ImportDBF.ImportDBFControl();
            this.ipsPanel1 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pageParentConsumers)).BeginInit();
            this.pageParentConsumers.SuspendLayout();
            this.pvConsumers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewSmallRight)).BeginInit();
            this.pvPays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).BeginInit();
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
            this.pageParentConsumers.Size = new System.Drawing.Size(1247, 501);
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
            this.pvConsumers.Controls.Add(this.ctrlConsumersViewSmallRight);
            this.pvConsumers.Controls.Add(this.ipsPanel1);
            this.pvConsumers.Controls.Add(this.treeViewSmallRight);
            this.pvConsumers.ItemSize = new System.Drawing.SizeF(129F, 27F);
            this.pvConsumers.Location = new System.Drawing.Point(10, 32);
            this.pvConsumers.Name = "pvConsumers";
            this.pvConsumers.Size = new System.Drawing.Size(1231, 463);
            this.pvConsumers.Text = "Реєстр користувачів";
            // 
            // ctrlConsumersViewSmallRight
            // 
            this.ctrlConsumersViewSmallRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlConsumersViewSmallRight.Location = new System.Drawing.Point(205, 0);
            this.ctrlConsumersViewSmallRight.Name = "ctrlConsumersViewSmallRight";
            this.ctrlConsumersViewSmallRight.Size = new System.Drawing.Size(1026, 463);
            this.ctrlConsumersViewSmallRight.TabIndex = 1;
            // 
            // treeViewSmallRight
            // 
            this.treeViewSmallRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewSmallRight.ExpandAnimation = Telerik.WinControls.UI.ExpandAnimation.None;
            this.treeViewSmallRight.HotTracking = false;
            this.treeViewSmallRight.Location = new System.Drawing.Point(0, 0);
            this.treeViewSmallRight.Name = "treeViewSmallRight";
            this.treeViewSmallRight.Padding = new System.Windows.Forms.Padding(8);
            this.treeViewSmallRight.Size = new System.Drawing.Size(199, 463);
            this.treeViewSmallRight.SpacingBetweenNodes = -1;
            this.treeViewSmallRight.TabIndex = 0;
            this.treeViewSmallRight.ThemeName = "Office2013Light";
            // 
            // pvPays
            // 
            this.pvPays.Controls.Add(this.ctrlImportDBF);
            this.pvPays.ItemSize = new System.Drawing.SizeF(105F, 27F);
            this.pvPays.Location = new System.Drawing.Point(10, 32);
            this.pvPays.Name = "pvPays";
            this.pvPays.Size = new System.Drawing.Size(1231, 463);
            this.pvPays.Text = "Розбір платежів";
            // 
            // ctrlImportDBF
            // 
            this.ctrlImportDBF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlImportDBF.Location = new System.Drawing.Point(0, 0);
            this.ctrlImportDBF.Name = "ctrlImportDBF";
            this.ctrlImportDBF.Size = new System.Drawing.Size(1231, 463);
            this.ctrlImportDBF.TabIndex = 0;
            this.ctrlImportDBF.TypeRights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            // 
            // ipsPanel1
            // 
            this.ipsPanel1.BorderVisible = false;
            this.ipsPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ipsPanel1.Location = new System.Drawing.Point(199, 0);
            this.ipsPanel1.Name = "ipsPanel1";
            this.ipsPanel1.Size = new System.Drawing.Size(6, 463);
            this.ipsPanel1.TabIndex = 2;
            this.ipsPanel1.ThemeName = "Office2013Light";
            // 
            // ConsumerSmallRightWorkplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 501);
            this.Controls.Add(this.pageParentConsumers);
            this.Name = "ConsumerSmallRightWorkplace";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Малі права";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageParentConsumers)).EndInit();
            this.pageParentConsumers.ResumeLayout(false);
            this.pvConsumers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewSmallRight)).EndInit();
            this.pvPays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView pageParentConsumers;
        private Telerik.WinControls.UI.RadPageViewPage pvPays;
        private Telerik.WinControls.UI.RadPageViewPage pvConsumers;
        private Telerik.WinControls.UI.RadTreeView treeViewSmallRight;
        private IpsViewComponentLibrary.ConsumerControls.ConsumersViewSmallRightControl ctrlConsumersViewSmallRight;
        private IpsViewComponentLibrary.ImportDBF.ImportDBFControl ctrlImportDBF;
        private IpsViewComponentLibrary.Common.Editors.IpsPanel ipsPanel1;
    }
}