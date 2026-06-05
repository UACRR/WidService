namespace RadioStationReports
{
    partial class FormCisNetImport
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
            ucCisNetImport = new UcCisNetImport();
            SuspendLayout();
            // 
            // ucCisNetImport
            // 
            ucCisNetImport.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCisNetImport.Location = new System.Drawing.Point(0, 0);
            ucCisNetImport.Name = "ucCisNetImport";
            ucCisNetImport.Size = new System.Drawing.Size(800, 450);
            ucCisNetImport.TabIndex = 0;
            // 
            // FormCisNetImport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(ucCisNetImport);
            Name = "FormCisNetImport";
            Text = "FormCisNetImport";
            ResumeLayout(false);
        }

        #endregion

        private UcCisNetImport ucCisNetImport;
    }
}