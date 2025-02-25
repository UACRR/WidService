namespace DdexInvoicing
{
    partial class FormDdexInvoicing
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDdexInvoicing));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.radPageViewMain = new Telerik.WinControls.UI.RadPageView();
            this.radPageReportInfo = new Telerik.WinControls.UI.RadPageViewPage();
            this.ucReportInfo = new DdexInvoicing.UcReportInfo();
            this.radPageReportLoad = new Telerik.WinControls.UI.RadPageViewPage();
            this.panelLoadReport = new System.Windows.Forms.TableLayoutPanel();
            this.ucDdexLoad = new DdexInvoicing.UcDdexLoad();
            this.radPageReconcile = new Telerik.WinControls.UI.RadPageViewPage();
            this.uсReconcile = new DdexInvoicing.UсReconcile();
            this.radPageMwIdent = new Telerik.WinControls.UI.RadPageViewPage();
            this.ucMwIdent = new DdexInvoicing.UcMwIdent();
            this.radPageInvoicing = new Telerik.WinControls.UI.RadPageViewPage();
            this.ucCcidInvoices = new DdexInvoicing.UcCcidInvoices();
            this.radPageAnalysis = new Telerik.WinControls.UI.RadPageViewPage();
            this.ucTraceRoyaltyCalc = new DdexInvoicing.UcTraceRoyaltyCalc();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewMain)).BeginInit();
            this.radPageViewMain.SuspendLayout();
            this.radPageReportInfo.SuspendLayout();
            this.radPageReportLoad.SuspendLayout();
            this.panelLoadReport.SuspendLayout();
            this.radPageReconcile.SuspendLayout();
            this.radPageMwIdent.SuspendLayout();
            this.radPageInvoicing.SuspendLayout();
            this.radPageAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.radPageViewMain, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 2;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1370, 618);
            this.panelMain.TabIndex = 2;
            // 
            // radPageViewMain
            // 
            this.radPageViewMain.Controls.Add(this.radPageReportInfo);
            this.radPageViewMain.Controls.Add(this.radPageReportLoad);
            this.radPageViewMain.Controls.Add(this.radPageReconcile);
            this.radPageViewMain.Controls.Add(this.radPageMwIdent);
            this.radPageViewMain.Controls.Add(this.radPageInvoicing);
            this.radPageViewMain.Controls.Add(this.radPageAnalysis);
            this.radPageViewMain.DefaultPage = this.radPageReportInfo;
            this.radPageViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageViewMain.Location = new System.Drawing.Point(3, 3);
            this.radPageViewMain.Name = "radPageViewMain";
            this.radPageViewMain.SelectedPage = this.radPageAnalysis;
            this.radPageViewMain.Size = new System.Drawing.Size(1364, 610);
            this.radPageViewMain.TabIndex = 15;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageViewMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageViewMain.GetChildAt(0))).ShowItemCloseButton = false;
            // 
            // radPageReportInfo
            // 
            this.radPageReportInfo.Controls.Add(this.ucReportInfo);
            this.radPageReportInfo.ItemSize = new System.Drawing.SizeF(76F, 28F);
            this.radPageReportInfo.Location = new System.Drawing.Point(10, 37);
            this.radPageReportInfo.Name = "radPageReportInfo";
            this.radPageReportInfo.Size = new System.Drawing.Size(1343, 562);
            this.radPageReportInfo.Text = "Інформація";
            // 
            // ucReportInfo
            // 
            this.ucReportInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportInfo.Location = new System.Drawing.Point(0, 0);
            this.ucReportInfo.Name = "ucReportInfo";
            this.ucReportInfo.Size = new System.Drawing.Size(1343, 562);
            this.ucReportInfo.TabIndex = 0;
            // 
            // radPageReportLoad
            // 
            this.radPageReportLoad.Controls.Add(this.panelLoadReport);
            this.radPageReportLoad.ItemSize = new System.Drawing.SizeF(90F, 28F);
            this.radPageReportLoad.Location = new System.Drawing.Point(10, 37);
            this.radPageReportLoad.Name = "radPageReportLoad";
            this.radPageReportLoad.Size = new System.Drawing.Size(1343, 562);
            this.radPageReportLoad.Text = "Завантаження";
            // 
            // panelLoadReport
            // 
            this.panelLoadReport.ColumnCount = 2;
            this.panelLoadReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLoadReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelLoadReport.Controls.Add(this.ucDdexLoad, 0, 0);
            this.panelLoadReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoadReport.Location = new System.Drawing.Point(0, 0);
            this.panelLoadReport.Name = "panelLoadReport";
            this.panelLoadReport.RowCount = 1;
            this.panelLoadReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLoadReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 562F));
            this.panelLoadReport.Size = new System.Drawing.Size(1343, 562);
            this.panelLoadReport.TabIndex = 0;
            // 
            // ucDdexLoad
            // 
            this.ucDdexLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDdexLoad.Location = new System.Drawing.Point(3, 3);
            this.ucDdexLoad.Name = "ucDdexLoad";
            this.ucDdexLoad.Size = new System.Drawing.Size(1328, 556);
            this.ucDdexLoad.TabIndex = 3;
            // 
            // radPageReconcile
            // 
            this.radPageReconcile.Controls.Add(this.uсReconcile);
            this.radPageReconcile.ItemSize = new System.Drawing.SizeF(226F, 28F);
            this.radPageReconcile.Location = new System.Drawing.Point(10, 37);
            this.radPageReconcile.Name = "radPageReconcile";
            this.radPageReconcile.Size = new System.Drawing.Size(1343, 562);
            this.radPageReconcile.Text = "Корегування автоматичної ідентифікації";
            // 
            // uсReconcile
            // 
            this.uсReconcile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uсReconcile.Location = new System.Drawing.Point(0, 0);
            this.uсReconcile.Name = "uсReconcile";
            this.uсReconcile.Size = new System.Drawing.Size(1343, 562);
            this.uсReconcile.TabIndex = 0;
            // 
            // radPageMwIdent
            // 
            this.radPageMwIdent.Controls.Add(this.ucMwIdent);
            this.radPageMwIdent.ItemSize = new System.Drawing.SizeF(122F, 28F);
            this.radPageMwIdent.Location = new System.Drawing.Point(10, 37);
            this.radPageMwIdent.Name = "radPageMwIdent";
            this.radPageMwIdent.Size = new System.Drawing.Size(1343, 562);
            this.radPageMwIdent.Text = "Ідентифікація творів";
            // 
            // ucMwIdent
            // 
            this.ucMwIdent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMwIdent.Location = new System.Drawing.Point(0, 0);
            this.ucMwIdent.Name = "ucMwIdent";
            this.ucMwIdent.Size = new System.Drawing.Size(1343, 562);
            this.ucMwIdent.TabIndex = 0;
            // 
            // radPageInvoicing
            // 
            this.radPageInvoicing.Controls.Add(this.ucCcidInvoices);
            this.radPageInvoicing.ItemSize = new System.Drawing.SizeF(58F, 28F);
            this.radPageInvoicing.Location = new System.Drawing.Point(10, 37);
            this.radPageInvoicing.Name = "radPageInvoicing";
            this.radPageInvoicing.Size = new System.Drawing.Size(1343, 562);
            this.radPageInvoicing.Text = "Рахунки";
            // 
            // ucCcidInvoices
            // 
            this.ucCcidInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCcidInvoices.Location = new System.Drawing.Point(0, 0);
            this.ucCcidInvoices.Name = "ucCcidInvoices";
            this.ucCcidInvoices.Size = new System.Drawing.Size(1343, 562);
            this.ucCcidInvoices.TabIndex = 0;
            // 
            // radPageAnalysis
            // 
            this.radPageAnalysis.Controls.Add(this.ucTraceRoyaltyCalc);
            this.radPageAnalysis.ItemSize = new System.Drawing.SizeF(67F, 28F);
            this.radPageAnalysis.Location = new System.Drawing.Point(10, 37);
            this.radPageAnalysis.Name = "radPageAnalysis";
            this.radPageAnalysis.Size = new System.Drawing.Size(1343, 562);
            this.radPageAnalysis.Text = "Аналітика";
            // 
            // ucTraceRoyaltyCalc
            // 
            this.ucTraceRoyaltyCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTraceRoyaltyCalc.Location = new System.Drawing.Point(0, 0);
            this.ucTraceRoyaltyCalc.Name = "ucTraceRoyaltyCalc";
            this.ucTraceRoyaltyCalc.Size = new System.Drawing.Size(1343, 562);
            this.ucTraceRoyaltyCalc.TabIndex = 0;
            // 
            // FormDdexInvoicing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 618);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDdexInvoicing";
            this.Text = "Обробка звітів від клієнтів";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewMain)).EndInit();
            this.radPageViewMain.ResumeLayout(false);
            this.radPageReportInfo.ResumeLayout(false);
            this.radPageReportLoad.ResumeLayout(false);
            this.panelLoadReport.ResumeLayout(false);
            this.radPageReconcile.ResumeLayout(false);
            this.radPageMwIdent.ResumeLayout(false);
            this.radPageInvoicing.ResumeLayout(false);
            this.radPageAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelLoadReport;
        private UcCcidInvoices ucCcidInvoices;
        private Telerik.WinControls.UI.RadPageView radPageViewMain;
        private Telerik.WinControls.UI.RadPageViewPage radPageReportInfo;
        private Telerik.WinControls.UI.RadPageViewPage radPageReportLoad;
        private Telerik.WinControls.UI.RadPageViewPage radPageMwIdent;
        private Telerik.WinControls.UI.RadPageViewPage radPageInvoicing;
        private UcReportInfo ucReportInfo;
        private UcDdexLoad ucDdexLoad;
        private Telerik.WinControls.UI.RadPageViewPage radPageReconcile;
        private UсReconcile uсReconcile;
        private UcMwIdent ucMwIdent;
        private Telerik.WinControls.UI.RadPageViewPage radPageAnalysis;
        private UcTraceRoyaltyCalc ucTraceRoyaltyCalc;
    }
}

