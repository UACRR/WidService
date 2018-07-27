namespace UnitTestMediaPortal
{
    partial class TestCalculation
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
            this.reportsControl1 = new IpsViewComponentLibrary.ReportsControl();
            this.SuspendLayout();
            // 
            // reportsControl1
            // 
            this.reportsControl1.Customer = null;
            this.reportsControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportsControl1.Location = new System.Drawing.Point(0, 0);
            this.reportsControl1.MinimumSize = new System.Drawing.Size(700, 470);
            this.reportsControl1.Name = "reportsControl1";
            this.reportsControl1.Size = new System.Drawing.Size(1034, 470);
            this.reportsControl1.TabIndex = 0;
            // 
            // TestCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1051, 450);
            this.Controls.Add(this.reportsControl1);
            this.Name = "TestCalculation";
            this.Text = "TestCalculation";
            this.ResumeLayout(false);

        }

        #endregion

        private IpsViewComponentLibrary.ReportsControl reportsControl1;
    }
}