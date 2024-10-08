
namespace SmartWorkSearch
{
    partial class FormFoundWorks
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.dgvFoundWorks = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemShowReports = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoundWorks)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.dgvFoundWorks, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // dgvFoundWorks
            // 
            this.dgvFoundWorks.AllowUserToAddRows = false;
            this.dgvFoundWorks.AllowUserToDeleteRows = false;
            this.dgvFoundWorks.AllowUserToResizeRows = false;
            this.dgvFoundWorks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoundWorks.ContextMenuStrip = this.contextMenu;
            this.dgvFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFoundWorks.Location = new System.Drawing.Point(3, 23);
            this.dgvFoundWorks.MultiSelect = false;
            this.dgvFoundWorks.Name = "dgvFoundWorks";
            this.dgvFoundWorks.ReadOnly = true;
            this.dgvFoundWorks.RowHeadersVisible = false;
            this.dgvFoundWorks.Size = new System.Drawing.Size(794, 384);
            this.dgvFoundWorks.TabIndex = 0;
            this.dgvFoundWorks.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFoundWorks_CellMouseDown);
            this.dgvFoundWorks.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvFoundWorks_RowPrePaint);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemShowReports});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(155, 26);
            // 
            // mnuItemShowReports
            // 
            this.mnuItemShowReports.Name = "mnuItemShowReports";
            this.mnuItemShowReports.Size = new System.Drawing.Size(180, 22);
            this.mnuItemShowReports.Text = "Показати звіти";
            this.mnuItemShowReports.Click += new System.EventHandler(this.mnuItemShowReports_Click);
            // 
            // FormFoundWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormFoundWorks";
            this.Text = "FormFoundWorks";
            this.Load += new System.EventHandler(this.FormFoundWorks_Load);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoundWorks)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.DataGridView dgvFoundWorks;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuItemShowReports;
    }
}