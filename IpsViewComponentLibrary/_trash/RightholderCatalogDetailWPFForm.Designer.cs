namespace IpsViewComponentLibrary.RightholderCatalogControls
{
    partial class RightholderCatalogDetailWPFForm
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
            this.components = new System.ComponentModel.Container();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bsPubCatalogItem = new System.Windows.Forms.BindingSource(this.components);
            this.btnGetExcel = new Telerik.WinControls.UI.RadButton();
            this.backgroundPanel = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.ctrlGridItemList_ = new System.Windows.Forms.Integration.ElementHost();
            this.ctrlGridItemList = new IPSViewComponentLibraryWPF.PubCatalogItemListControl();
            this.ctrlNavigatorPanel = new IpsViewComponentLibrary.Common.NavigatorPanelControl();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.bsCatalogFile = new System.Windows.Forms.BindingSource(this.components);
            this.btnAuditItems = new Telerik.WinControls.UI.RadButton();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.btnPerform = new Telerik.WinControls.UI.RadButton();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement2 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.bsPubCatalogItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPanel)).BeginInit();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatalogFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAuditItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPerform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.radLabel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // bsPubCatalogItem
            // 
            this.bsPubCatalogItem.DataSource = typeof(ipsFormsDesign.Model.PubCatalogItem);
            // 
            // btnGetExcel
            // 
            this.btnGetExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetExcel.Location = new System.Drawing.Point(123, 418);
            this.btnGetExcel.Name = "btnGetExcel";
            this.btnGetExcel.Size = new System.Drawing.Size(114, 24);
            this.btnGetExcel.TabIndex = 3;
            this.btnGetExcel.Text = "Експорт в Excel";
            this.btnGetExcel.ThemeName = "Office2013Light";
            this.btnGetExcel.Click += new System.EventHandler(this.btnGetExcel_Click);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BorderVisible = false;
            this.backgroundPanel.Controls.Add(this.ctrlGridItemList_);
            this.backgroundPanel.Controls.Add(this.ctrlNavigatorPanel);
            this.backgroundPanel.Controls.Add(this.radLabel15);
            this.backgroundPanel.Controls.Add(this.btnAuditItems);
            this.backgroundPanel.Controls.Add(this.radLabel14);
            this.backgroundPanel.Controls.Add(this.btnGetExcel);
            this.backgroundPanel.Controls.Add(this.radLabel13);
            this.backgroundPanel.Controls.Add(this.btnPerform);
            this.backgroundPanel.Controls.Add(this.radLabel12);
            this.backgroundPanel.Controls.Add(this.radLabel11);
            this.backgroundPanel.Controls.Add(this.radLabel1);
            this.backgroundPanel.Controls.Add(this.radLabel10);
            this.backgroundPanel.Controls.Add(this.radLabel3);
            this.backgroundPanel.Controls.Add(this.radLabel9);
            this.backgroundPanel.Controls.Add(this.radLabel2);
            this.backgroundPanel.Controls.Add(this.radLabel8);
            this.backgroundPanel.Controls.Add(this.radLabel5);
            this.backgroundPanel.Controls.Add(this.radLabel7);
            this.backgroundPanel.Controls.Add(this.radLabel6);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(822, 445);
            this.backgroundPanel.TabIndex = 16;
            // 
            // ctrlGridItemList_
            // 
            this.ctrlGridItemList_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridItemList_.Location = new System.Drawing.Point(3, 100);
            this.ctrlGridItemList_.Name = "ctrlGridItemList_";
            this.ctrlGridItemList_.Size = new System.Drawing.Size(816, 312);
            this.ctrlGridItemList_.TabIndex = 14;
            this.ctrlGridItemList_.Child = this.ctrlGridItemList;
            // 
            // ctrlNavigatorPanel
            // 
            this.ctrlNavigatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlNavigatorPanel.CurrentPage = 1;
            this.ctrlNavigatorPanel.Location = new System.Drawing.Point(469, 418);
            this.ctrlNavigatorPanel.Name = "ctrlNavigatorPanel";
            this.ctrlNavigatorPanel.PageSize = 200;
            this.ctrlNavigatorPanel.ReadOnlyPageSize = false;
            this.ctrlNavigatorPanel.Size = new System.Drawing.Size(350, 24);
            this.ctrlNavigatorPanel.TabIndex = 13;
            this.ctrlNavigatorPanel.TotalPages = 0;
            this.ctrlNavigatorPanel.Visible = false;
            // 
            // radLabel15
            // 
            this.radLabel15.AutoSize = false;
            this.radLabel15.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCatalogFile, "CountOk", true));
            this.radLabel15.Location = new System.Drawing.Point(444, 51);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(111, 18);
            this.radLabel15.TabIndex = 0;
            this.radLabel15.Text = "-";
            this.radLabel15.ThemeName = "Office2013Light";
            // 
            // bsCatalogFile
            // 
            this.bsCatalogFile.DataSource = typeof(ipsFormsDesign.Model.CatalogFile);
            // 
            // btnAuditItems
            // 
            this.btnAuditItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAuditItems.Location = new System.Drawing.Point(3, 418);
            this.btnAuditItems.Name = "btnAuditItems";
            this.btnAuditItems.Size = new System.Drawing.Size(114, 24);
            this.btnAuditItems.TabIndex = 4;
            this.btnAuditItems.Text = "Контроль";
            this.btnAuditItems.ThemeName = "Office2013Light";
            this.btnAuditItems.Click += new System.EventHandler(this.btnAuditItems_Click);
            // 
            // radLabel14
            // 
            this.radLabel14.AutoSize = false;
            this.radLabel14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCatalogFile, "CountErr", true));
            this.radLabel14.Location = new System.Drawing.Point(444, 27);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(111, 18);
            this.radLabel14.TabIndex = 0;
            this.radLabel14.Text = "-";
            this.radLabel14.ThemeName = "Office2013Light";
            // 
            // radLabel13
            // 
            this.radLabel13.AutoSize = false;
            this.radLabel13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCatalogFile, "CountZap", true));
            this.radLabel13.Location = new System.Drawing.Point(444, 3);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(111, 18);
            this.radLabel13.TabIndex = 0;
            this.radLabel13.Text = "-";
            this.radLabel13.ThemeName = "Office2013Light";
            // 
            // btnPerform
            // 
            this.btnPerform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPerform.Enabled = false;
            this.btnPerform.Location = new System.Drawing.Point(243, 418);
            this.btnPerform.Name = "btnPerform";
            this.btnPerform.Size = new System.Drawing.Size(114, 24);
            this.btnPerform.TabIndex = 3;
            this.btnPerform.Text = "Виконати";
            this.btnPerform.ThemeName = "Office2013Light";
            this.btnPerform.Click += new System.EventHandler(this.btnPerform_Click);
            // 
            // radLabel12
            // 
            this.radLabel12.AutoSize = false;
            this.radLabel12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCatalogFile, "CustName", true));
            this.radLabel12.Location = new System.Drawing.Point(126, 75);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(151, 18);
            this.radLabel12.TabIndex = 0;
            this.radLabel12.Text = "-";
            this.radLabel12.ThemeName = "Office2013Light";
            // 
            // radLabel11
            // 
            this.radLabel11.AutoSize = false;
            this.radLabel11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCatalogFile, "Comment", true));
            this.radLabel11.Location = new System.Drawing.Point(126, 51);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(151, 18);
            this.radLabel11.TabIndex = 0;
            this.radLabel11.Text = "-";
            this.radLabel11.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(117, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Дата завантаження";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel10
            // 
            this.radLabel10.AutoSize = false;
            this.radLabel10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCatalogFile, "Status", true));
            this.radLabel10.Location = new System.Drawing.Point(126, 27);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(151, 18);
            this.radLabel10.TabIndex = 0;
            this.radLabel10.Text = "-";
            this.radLabel10.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.Location = new System.Drawing.Point(283, 27);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(145, 18);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "К-ть відхилених записів";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel9
            // 
            this.radLabel9.AutoSize = false;
            this.radLabel9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCatalogFile, "CreateDate", true));
            this.radLabel9.Location = new System.Drawing.Point(126, 3);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(151, 18);
            this.radLabel9.TabIndex = 0;
            this.radLabel9.Text = "-";
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Controls.Add(this.radLabel4);
            this.radLabel2.Location = new System.Drawing.Point(283, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(131, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "К-ть записів всього";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.Location = new System.Drawing.Point(3, 24);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(55, 18);
            this.radLabel4.TabIndex = 7;
            this.radLabel4.Text = "radLabel4";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // radLabel8
            // 
            this.radLabel8.AutoSize = false;
            this.radLabel8.Location = new System.Drawing.Point(283, 51);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(155, 18);
            this.radLabel8.TabIndex = 0;
            this.radLabel8.Text = "К-ть оброблених записів";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.AutoSize = false;
            this.radLabel5.Location = new System.Drawing.Point(3, 75);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(114, 18);
            this.radLabel5.TabIndex = 0;
            this.radLabel5.Text = "Хто завантажив";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // radLabel7
            // 
            this.radLabel7.AutoSize = false;
            this.radLabel7.Location = new System.Drawing.Point(3, 27);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(114, 18);
            this.radLabel7.TabIndex = 0;
            this.radLabel7.Text = "Статус файлу";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.AutoSize = false;
            this.radLabel6.Location = new System.Drawing.Point(3, 51);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(114, 18);
            this.radLabel6.TabIndex = 0;
            this.radLabel6.Text = "Коментар";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // waitingBar
            // 
            this.waitingBar.AssociatedControl = this.backgroundPanel;
            this.waitingBar.Location = new System.Drawing.Point(376, 187);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 17;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.ThemeName = "Office2013Light";
            this.waitingBar.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement2);
            this.waitingBar.WaitingSpeed = 50;
            this.waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.waitingBar.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.waitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // lineRingWaitingBarIndicatorElement2
            // 
            this.lineRingWaitingBarIndicatorElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement2.Name = "lineRingWaitingBarIndicatorElement2";
            this.lineRingWaitingBarIndicatorElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement2.UseCompatibleTextRendering = false;
            // 
            // RightholderCatalogDetailWPFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(822, 445);
            this.Controls.Add(this.waitingBar);
            this.Controls.Add(this.backgroundPanel);
            this.Name = "RightholderCatalogDetailWPFForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CatalogDetailForm";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.bsPubCatalogItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPanel)).EndInit();
            this.backgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCatalogFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAuditItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPerform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.radLabel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsPubCatalogItem;
        private Telerik.WinControls.UI.RadButton btnGetExcel;
        private Common.Editors.IpsPanel backgroundPanel;
        private Common.NavigatorPanelControl ctrlNavigatorPanel;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private System.Windows.Forms.BindingSource bsCatalogFile;
        private Telerik.WinControls.UI.RadButton btnAuditItems;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadButton btnPerform;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private System.Windows.Forms.Integration.ElementHost ctrlGridItemList_;
        private IPSViewComponentLibraryWPF.PubCatalogItemListControl ctrlGridItemList;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement2;
    }
}
