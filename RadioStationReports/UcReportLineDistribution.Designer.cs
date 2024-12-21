namespace RadioStationReports
{
    partial class UcReportLineDistribution
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
            components = new System.ComponentModel.Container();
            lvDistribution = new System.Windows.Forms.ListView();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lvDistribution
            // 
            lvDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            lvDistribution.FullRowSelect = true;
            lvDistribution.GridLines = true;
            lvDistribution.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvDistribution.HideSelection = false;
            lvDistribution.Location = new System.Drawing.Point(0, 0);
            lvDistribution.MultiSelect = false;
            lvDistribution.Name = "lvDistribution";
            lvDistribution.Size = new System.Drawing.Size(1004, 445);
            lvDistribution.TabIndex = 0;
            lvDistribution.UseCompatibleStateImageBehavior = false;
            lvDistribution.View = System.Windows.Forms.View.Details;
            lvDistribution.MouseDown += lvDistribution_MouseDown;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemCopy });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(181, 48);
            contextMenuStrip.ItemClicked += contextMenuStrip_ItemClicked;
            // 
            // toolStripMenuItemCopy
            // 
            toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            toolStripMenuItemCopy.Size = new System.Drawing.Size(180, 22);
            toolStripMenuItemCopy.Text = "Копіювати";
            // 
            // UcReportLineDistribution
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lvDistribution);
            Name = "UcReportLineDistribution";
            Size = new System.Drawing.Size(1004, 445);
            Load += UcReportLineDistribution_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView lvDistribution;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
    }
}
