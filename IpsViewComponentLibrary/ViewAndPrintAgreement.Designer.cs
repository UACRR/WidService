namespace IpsViewComponentLibrary
{
    partial class ViewAndPrintAgreement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAndPrintAgreement));
            this.office2007SilverTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.radPdfViewerNavigator = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.radPdfViewer = new Telerik.WinControls.UI.RadPdfViewer();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPdfViewerNavigator
            // 
            this.radPdfViewerNavigator.AssociatedViewer = this.radPdfViewer;
            this.radPdfViewerNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPdfViewerNavigator.Location = new System.Drawing.Point(0, 0);
            this.radPdfViewerNavigator.Name = "radPdfViewerNavigator";
            this.radPdfViewerNavigator.Size = new System.Drawing.Size(1157, 38);
            this.radPdfViewerNavigator.TabIndex = 2;
            this.radPdfViewerNavigator.ThemeName = "Office2007Silver";
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radPdfViewerNavigator.GetChildAt(0))).Enabled = true;
            ((Telerik.WinControls.Layouts.StackLayoutPanel)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.CommandBarRowElement)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Text = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).ToolTipText = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).Text = "Save As";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).ToolTipText = "Save As";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(4))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Text = "Signature Panel";
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).ToolTipText = "Signature Panel";
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Enabled = true;
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radPdfViewer
            // 
            this.radPdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPdfViewer.EnableThumbnails = false;
            this.radPdfViewer.Location = new System.Drawing.Point(0, 44);
            this.radPdfViewer.Name = "radPdfViewer";
            this.radPdfViewer.Size = new System.Drawing.Size(1157, 515);
            this.radPdfViewer.TabIndex = 3;
            this.radPdfViewer.ThemeName = "Office2007Silver";
            this.radPdfViewer.ThumbnailsScaleFactor = 0.15F;
            ((Telerik.WinControls.UI.RadPdfViewerContainer)(this.radPdfViewer.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadPdfViewerContainer)(this.radPdfViewer.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.ThumbnailListElement)(this.radPdfViewer.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // ViewAndPrintAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 560);
            this.Controls.Add(this.radPdfViewerNavigator);
            this.Controls.Add(this.radPdfViewer);
            this.Name = "ViewAndPrintAgreement";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ViewAndPrintAgreement";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme;
        private Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigator;
        private Telerik.WinControls.UI.RadPdfViewer radPdfViewer;
    }
}
