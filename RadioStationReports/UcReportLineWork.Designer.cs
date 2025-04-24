
namespace RadioStationReports
{
    partial class UcReportLineWork
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            lvInfo = new System.Windows.Forms.ListView();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.Controls.Add(lvInfo, 0, 0);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 2;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelMain.Size = new System.Drawing.Size(1069, 460);
            panelMain.TabIndex = 0;
            // 
            // toolStripMenuItemCopy
            // 
            toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            toolStripMenuItemCopy.Size = new System.Drawing.Size(32, 19);
            // 
            // lvInfo
            // 
            lvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            lvInfo.HideSelection = false;
            lvInfo.Location = new System.Drawing.Point(3, 3);
            lvInfo.Name = "lvInfo";
            lvInfo.Size = new System.Drawing.Size(1063, 446);
            lvInfo.TabIndex = 0;
            lvInfo.UseCompatibleStateImageBehavior = false;
            // 
            // UcReportLineWork
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelMain);
            Name = "UcReportLineWork";
            Size = new System.Drawing.Size(1069, 460);
            Load += UcReportLineWork_Load;
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ListView lvInfo;
    }
}
