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
            this.panelMain = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.ucReportMw = new DdexInvoicing.UcReportMw();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.ucMwSearch = new DdexInvoicing.UcMwSearch();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
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
            this.panelMain.Size = new System.Drawing.Size(762, 420);
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
            this.splitPanel1.Size = new System.Drawing.Size(762, 164);
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
            this.ucReportMw.Size = new System.Drawing.Size(762, 164);
            this.ucReportMw.TabIndex = 0;
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.ucMwSearch);
            this.splitPanel2.Location = new System.Drawing.Point(0, 168);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(762, 252);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.1057692F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 44);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            // 
            // ucMwSearch
            // 
            this.ucMwSearch.AutoSize = true;
            this.ucMwSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMwSearch.Location = new System.Drawing.Point(0, 0);
            this.ucMwSearch.Name = "ucMwSearch";
            this.ucMwSearch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ucMwSearch.Size = new System.Drawing.Size(762, 252);
            this.ucMwSearch.TabIndex = 0;
            // 
            // UcMwIdent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcMwIdent";
            this.Size = new System.Drawing.Size(762, 420);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            this.splitPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadSplitContainer panelMain;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private UcReportMw ucReportMw;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private UcMwSearch ucMwSearch;
    }
}
