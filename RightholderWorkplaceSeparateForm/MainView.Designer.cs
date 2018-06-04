namespace RightholderWorkplaceSeparateForm
{
    partial class MainView
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
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.mainPageRightholders = new Telerik.WinControls.UI.RadPageViewPage();
            this.mainPageRightsObjects = new Telerik.WinControls.UI.RadPageViewPage();
            this.mainPageDistributionList = new Telerik.WinControls.UI.RadPageViewPage();
            this.rightholderPanel = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.mainPageRightholders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPageView
            // 
            this.mainPageView.Controls.Add(this.mainPageRightholders);
            this.mainPageView.Controls.Add(this.mainPageRightsObjects);
            this.mainPageView.Controls.Add(this.mainPageDistributionList);
            this.mainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPageView.Location = new System.Drawing.Point(0, 0);
            this.mainPageView.Name = "mainPageView";
            this.mainPageView.SelectedPage = this.mainPageDistributionList;
            this.mainPageView.Size = new System.Drawing.Size(1192, 670);
            this.mainPageView.TabIndex = 0;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.mainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // mainPageRightholders
            // 
            this.mainPageRightholders.Controls.Add(this.rightholderPanel);
            this.mainPageRightholders.ItemSize = new System.Drawing.SizeF(98F, 28F);
            this.mainPageRightholders.Location = new System.Drawing.Point(10, 37);
            this.mainPageRightholders.Name = "mainPageRightholders";
            this.mainPageRightholders.Size = new System.Drawing.Size(1171, 622);
            this.mainPageRightholders.Text = "Правовласники";
            // 
            // mainPageRightsObjects
            // 
            this.mainPageRightsObjects.ItemSize = new System.Drawing.SizeF(90F, 28F);
            this.mainPageRightsObjects.Location = new System.Drawing.Point(10, 37);
            this.mainPageRightsObjects.Name = "mainPageRightsObjects";
            this.mainPageRightsObjects.Size = new System.Drawing.Size(1171, 622);
            this.mainPageRightsObjects.Text = "Об\'єкти права";
            // 
            // mainPageDistributionList
            // 
            this.mainPageDistributionList.ItemSize = new System.Drawing.SizeF(120F, 28F);
            this.mainPageDistributionList.Location = new System.Drawing.Point(10, 37);
            this.mainPageDistributionList.Name = "mainPageDistributionList";
            this.mainPageDistributionList.Size = new System.Drawing.Size(1171, 622);
            this.mainPageDistributionList.Text = "Відомості розподілу";
            // 
            // rightholderPanel
            // 
            this.rightholderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightholderPanel.Location = new System.Drawing.Point(0, 0);
            this.rightholderPanel.Name = "rightholderPanel";
            this.rightholderPanel.Size = new System.Drawing.Size(1171, 622);
            this.rightholderPanel.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 670);
            this.Controls.Add(this.mainPageView);
            this.Name = "MainView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Робоче місце адміністратора права";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).EndInit();
            this.mainPageView.ResumeLayout(false);
            this.mainPageRightholders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightholderPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView mainPageView;
        private Telerik.WinControls.UI.RadPageViewPage mainPageRightholders;
        private Telerik.WinControls.UI.RadPageViewPage mainPageRightsObjects;
        private Telerik.WinControls.UI.RadPageViewPage mainPageDistributionList;
        private Telerik.WinControls.UI.RadPanel rightholderPanel;
    }
}