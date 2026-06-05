namespace CisNetImporter
{
    partial class formCisNetWork
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
            this.ucCisNetImporter = new CisNetImporter.UcCisNetImporter();
            this.SuspendLayout();
            // 
            // ucCisNetImporter
            // 
            this.ucCisNetImporter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCisNetImporter.Location = new System.Drawing.Point(0, 0);
            this.ucCisNetImporter.Name = "ucCisNetImporter";
            this.ucCisNetImporter.Size = new System.Drawing.Size(1005, 561);
            this.ucCisNetImporter.TabIndex = 0;
            // 
            // formCisNetWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 561);
            this.Controls.Add(this.ucCisNetImporter);
            this.Name = "formCisNetWork";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UcCisNetImporter ucCisNetImporter;
    }
}

