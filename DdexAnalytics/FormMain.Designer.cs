
namespace DdexAnalytics
{
    partial class FormMain
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
            this.ucDdexAnalyticReports = new DdexAnalytics.UcDdexAnalyticReports();
            this.SuspendLayout();
            // 
            // ucDdexAnalyticReports
            // 
            this.ucDdexAnalyticReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDdexAnalyticReports.Location = new System.Drawing.Point(0, 0);
            this.ucDdexAnalyticReports.Name = "ucDdexAnalyticReports";
            this.ucDdexAnalyticReports.Size = new System.Drawing.Size(1331, 631);
            this.ucDdexAnalyticReports.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 631);
            this.Controls.Add(this.ucDdexAnalyticReports);
            this.Name = "FormMain";
            this.Text = "Ddex Analytic Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private UcDdexAnalyticReports ucDdexAnalyticReports;
    }
}