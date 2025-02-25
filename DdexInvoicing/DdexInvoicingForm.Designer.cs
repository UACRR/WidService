namespace DdexInvoicing
{
    partial class DdexInvoicingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DdexInvoicingForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radBtnClose = new Telerik.WinControls.UI.RadButton();
            this.panelMain = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.ucDdexReports = new DdexInvoicing.UcDdexReports();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.ucExceptionSets = new DdexInvoicing.UcExceptionSets();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radBtnClose, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelMain, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1113, 567);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radBtnClose
            // 
            this.radBtnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radBtnClose.Location = new System.Drawing.Point(1000, 535);
            this.radBtnClose.Name = "radBtnClose";
            this.radBtnClose.Size = new System.Drawing.Size(110, 24);
            this.radBtnClose.TabIndex = 1;
            this.radBtnClose.Text = "Закрити";
            this.radBtnClose.Click += new System.EventHandler(this.radBtnClose_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.radPageViewPage1);
            this.panelMain.Controls.Add(this.radPageViewPage2);
            this.panelMain.DefaultPage = this.radPageViewPage1;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(3, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.SelectedPage = this.radPageViewPage1;
            this.panelMain.Size = new System.Drawing.Size(1107, 521);
            this.panelMain.TabIndex = 3;
            this.panelMain.SelectedPageChanged += new System.EventHandler(this.panelMain_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.panelMain.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.panelMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.panelMain.GetChildAt(0))).ShowItemCloseButton = false;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.ucDdexReports);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(42F, 28F);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(1086, 473);
            this.radPageViewPage1.Text = "Звіти";
            // 
            // ucDdexReports
            // 
            this.ucDdexReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDdexReports.Location = new System.Drawing.Point(0, 0);
            this.ucDdexReports.Name = "ucDdexReports";
            this.ucDdexReports.Size = new System.Drawing.Size(1086, 473);
            this.ucDdexReports.TabIndex = 2;
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.ucExceptionSets);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(81F, 28F);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(1086, 473);
            this.radPageViewPage2.Text = "Виключення";
            // 
            // ucExceptionSets
            // 
            this.ucExceptionSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExceptionSets.Location = new System.Drawing.Point(0, 0);
            this.ucExceptionSets.Name = "ucExceptionSets";
            this.ucExceptionSets.Size = new System.Drawing.Size(1086, 473);
            this.ucExceptionSets.TabIndex = 0;
            // 
            // DdexInvoicingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1113, 567);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DdexInvoicingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обробка електронних звітів";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton radBtnClose;
        private UcDdexReports ucDdexReports;
        private Telerik.WinControls.UI.RadPageView panelMain;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private UcExceptionSets ucExceptionSets;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
    }
}