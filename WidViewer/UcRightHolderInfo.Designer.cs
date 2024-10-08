
namespace WidViewer
{
    partial class UcRightHolderInfo
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labTitle = new System.Windows.Forms.Label();
            this.panelMusicWorks = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.labTitle, 0, 0);
            this.panelMain.Controls.Add(this.panelMusicWorks, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 2;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelMain.Size = new System.Drawing.Size(792, 394);
            this.panelMain.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle.Location = new System.Drawing.Point(3, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(786, 30);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Музичні твори правовласника";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMusicWorks
            // 
            this.panelMusicWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMusicWorks.Location = new System.Drawing.Point(3, 33);
            this.panelMusicWorks.Name = "panelMusicWorks";
            this.panelMusicWorks.Size = new System.Drawing.Size(786, 358);
            this.panelMusicWorks.TabIndex = 1;
            // 
            // UcRightHolderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcRightHolderInfo";
            this.Size = new System.Drawing.Size(792, 394);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.FlowLayoutPanel panelMusicWorks;
    }
}
