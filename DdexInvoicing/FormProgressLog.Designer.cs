namespace ExportImport
{
    partial class FormProgressLog
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.radTbLog = new Telerik.WinControls.UI.RadTextBox();
            this.radBtnClose = new Telerik.WinControls.UI.RadButton();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTbLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.radTbLog, 0, 1);
            this.panelMain.Controls.Add(this.radBtnClose, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // radTbLog
            // 
            this.radTbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTbLog.Location = new System.Drawing.Point(3, 25);
            this.radTbLog.Multiline = true;
            this.radTbLog.Name = "radTbLog";
            // 
            // 
            // 
            this.radTbLog.RootElement.StretchVertically = true;
            this.radTbLog.Size = new System.Drawing.Size(794, 391);
            this.radTbLog.TabIndex = 0;
            // 
            // radBtnClose
            // 
            this.radBtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.radBtnClose.Location = new System.Drawing.Point(687, 422);
            this.radBtnClose.Name = "radBtnClose";
            this.radBtnClose.Size = new System.Drawing.Size(110, 25);
            this.radBtnClose.TabIndex = 1;
            this.radBtnClose.Text = "Close";
            this.radBtnClose.Click += new System.EventHandler(this.radBtnClose_Click);
            // 
            // FormProgressLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProgressLog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Progress Log";
            this.Load += new System.EventHandler(this.FormProgressLog_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTbLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private Telerik.WinControls.UI.RadTextBox radTbLog;
        private Telerik.WinControls.UI.RadButton radBtnClose;
    }
}