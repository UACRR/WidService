
namespace WidExport
{
    partial class UcWidGroupStatistics
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
            this.lvStatistics = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvStatistics
            // 
            this.lvStatistics.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStatistics.FullRowSelect = true;
            this.lvStatistics.GridLines = true;
            this.lvStatistics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStatistics.HideSelection = false;
            this.lvStatistics.Location = new System.Drawing.Point(0, 0);
            this.lvStatistics.MultiSelect = false;
            this.lvStatistics.Name = "lvStatistics";
            this.lvStatistics.Size = new System.Drawing.Size(839, 352);
            this.lvStatistics.TabIndex = 0;
            this.lvStatistics.UseCompatibleStateImageBehavior = false;
            this.lvStatistics.View = System.Windows.Forms.View.Details;
            // 
            // UcWidGroupStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvStatistics);
            this.Name = "UcWidGroupStatistics";
            this.Size = new System.Drawing.Size(839, 352);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvStatistics;
    }
}
