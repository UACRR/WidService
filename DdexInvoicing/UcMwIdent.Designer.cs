namespace DdexInvoicing
{
    partial class UcMwIdent
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMwIdent));
            this.panelMain = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.ucReportMw = new DdexInvoicing.UcReportMw();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.tabControlBottomPanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucMwSearch = new DdexInvoicing.UcMwSearch();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucCisNetImport = new DdexInvoicing.UcCisNetImport();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucShareCalc = new DdexInvoicing.UcShareCalc();
            this.ilTabs = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            this.tabControlBottomPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitPanel1);
            this.panelMain.Controls.Add(this.splitPanel2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.panelMain.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.panelMain.Size = new System.Drawing.Size(968, 540);
            this.panelMain.TabIndex = 0;
            this.panelMain.TabStop = false;
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.ucReportMw);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(968, 211);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.1057692F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -44);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            // 
            // ucReportMw
            // 
            this.ucReportMw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportMw.Location = new System.Drawing.Point(0, 0);
            this.ucReportMw.Name = "ucReportMw";
            this.ucReportMw.Size = new System.Drawing.Size(968, 211);
            this.ucReportMw.TabIndex = 0;
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.tabControlBottomPanel);
            this.splitPanel2.Location = new System.Drawing.Point(0, 215);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(968, 325);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.1057692F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 44);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            // 
            // tabControlBottomPanel
            // 
            this.tabControlBottomPanel.Controls.Add(this.tabPage1);
            this.tabControlBottomPanel.Controls.Add(this.tabPage2);
            this.tabControlBottomPanel.Controls.Add(this.tabPage3);
            this.tabControlBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBottomPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabControlBottomPanel.ImageList = this.ilTabs;
            this.tabControlBottomPanel.Location = new System.Drawing.Point(0, 0);
            this.tabControlBottomPanel.Name = "tabControlBottomPanel";
            this.tabControlBottomPanel.SelectedIndex = 0;
            this.tabControlBottomPanel.Size = new System.Drawing.Size(968, 325);
            this.tabControlBottomPanel.TabIndex = 1;
            this.tabControlBottomPanel.SelectedIndexChanged += new System.EventHandler(this.tabControlBottomPanel_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucMwSearch);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(960, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Пошук Онлайн";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucMwSearch
            // 
            this.ucMwSearch.AutoSize = true;
            this.ucMwSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMwSearch.Location = new System.Drawing.Point(3, 3);
            this.ucMwSearch.Name = "ucMwSearch";
            this.ucMwSearch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ucMwSearch.Size = new System.Drawing.Size(954, 276);
            this.ucMwSearch.TabIndex = 0;
            this.ucMwSearch.Load += new System.EventHandler(this.ucMwSearch_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucCisNetImport);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(960, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Пошук в CISNet";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucCisNetImport
            // 
            this.ucCisNetImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCisNetImport.Location = new System.Drawing.Point(3, 3);
            this.ucCisNetImport.Name = "ucCisNetImport";
            this.ucCisNetImport.Size = new System.Drawing.Size(954, 276);
            this.ucCisNetImport.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucShareCalc);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(960, 282);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Заявлені Проценти";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucShareCalc
            // 
            this.ucShareCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShareCalc.Location = new System.Drawing.Point(0, 0);
            this.ucShareCalc.Name = "ucShareCalc";
            this.ucShareCalc.Size = new System.Drawing.Size(960, 282);
            this.ucShareCalc.TabIndex = 0;
            // 
            // ilTabs
            // 
            this.ilTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTabs.ImageStream")));
            this.ilTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTabs.Images.SetKeyName(0, "UACRR.png");
            this.ilTabs.Images.SetKeyName(1, "CISNet.png");
            this.ilTabs.Images.SetKeyName(2, "Icojam-Blue-Bits-Document-arrow-down.ico");
            // 
            // UcMwIdent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcMwIdent";
            this.Size = new System.Drawing.Size(968, 540);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            this.tabControlBottomPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSplitContainer panelMain;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private UcReportMw ucReportMw;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private UcMwSearch ucMwSearch;
        private System.Windows.Forms.TabControl tabControlBottomPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UcCisNetImport ucCisNetImport;
        private System.Windows.Forms.ImageList ilTabs;
        private System.Windows.Forms.TabPage tabPage3;
        private UcShareCalc ucShareCalc;
    }
}
