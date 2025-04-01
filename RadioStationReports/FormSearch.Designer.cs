namespace RadioStationReports
{
    partial class FormSearch
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
            ucSearch = new UcSearch();
            SuspendLayout();
            // 
            // ucSearch
            // 
            ucSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSearch.Location = new System.Drawing.Point(0, 0);
            ucSearch.Name = "ucSearch";
            ucSearch.Padding = new System.Windows.Forms.Padding(5);
            ucSearch.Size = new System.Drawing.Size(800, 450);
            ucSearch.TabIndex = 0;
            ucSearch.Load += ucSearch_Load;
            // 
            // FormSearch
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(ucSearch);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Name = "FormSearch";
            Text = "Пошук твору із звіту";
            Load += FormSearch_Load;
            ResumeLayout(false);
        }

        #endregion

        private UcSearch ucSearch;
    }
}