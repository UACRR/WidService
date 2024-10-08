
namespace WidExport
{
    partial class UcMainStatistics
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
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshStatistics = new System.Windows.Forms.Button();
            this.lvStat = new System.Windows.Forms.ListView();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelButtons, 0, 2);
            this.panelMain.Controls.Add(this.lvStat, 0, 1);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(811, 359);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnRefreshStatistics);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(3, 316);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(805, 32);
            this.panelButtons.TabIndex = 0;
            // 
            // btnRefreshStatistics
            // 
            this.btnRefreshStatistics.Location = new System.Drawing.Point(684, 3);
            this.btnRefreshStatistics.Name = "btnRefreshStatistics";
            this.btnRefreshStatistics.Size = new System.Drawing.Size(118, 23);
            this.btnRefreshStatistics.TabIndex = 1;
            this.btnRefreshStatistics.Text = "Оновити статистику";
            this.btnRefreshStatistics.UseVisualStyleBackColor = true;
            this.btnRefreshStatistics.Click += new System.EventHandler(this.btnRefreshStatistics_Click);
            // 
            // lvStat
            // 
            this.lvStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStat.FullRowSelect = true;
            this.lvStat.HideSelection = false;
            this.lvStat.Location = new System.Drawing.Point(3, 11);
            this.lvStat.MultiSelect = false;
            this.lvStat.Name = "lvStat";
            this.lvStat.Size = new System.Drawing.Size(805, 299);
            this.lvStat.TabIndex = 1;
            this.lvStat.UseCompatibleStateImageBehavior = false;
            this.lvStat.View = System.Windows.Forms.View.Details;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(805, 2);
            this.panelTop.TabIndex = 2;
            // 
            // UcMainStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcMainStatistics";
            this.Size = new System.Drawing.Size(811, 359);
            this.Load += new System.EventHandler(this.UcMainWorks_Load);
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.ListView lvStat;
        private System.Windows.Forms.Button btnRefreshStatistics;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
    }
}
