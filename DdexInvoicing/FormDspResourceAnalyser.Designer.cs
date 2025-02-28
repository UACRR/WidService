namespace DdexInvoicing
{
    partial class FormDspResourceAnalyser
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
            this.ucDspResourceAnalyser = new DdexInvoicing.UcDspResourceAnalyser();
            this.SuspendLayout();
            // 
            // ucDspResourceAnalyser
            // 
            this.ucDspResourceAnalyser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDspResourceAnalyser.Location = new System.Drawing.Point(0, 0);
            this.ucDspResourceAnalyser.Name = "ucDspResourceAnalyser";
            this.ucDspResourceAnalyser.Size = new System.Drawing.Size(800, 450);
            this.ucDspResourceAnalyser.TabIndex = 0;
            // 
            // FormDspResourceAnalyser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucDspResourceAnalyser);
            this.Name = "FormDspResourceAnalyser";
            this.Text = "FormDspResourceAnalyser";
            this.ResumeLayout(false);

        }

        #endregion

        private UcDspResourceAnalyser ucDspResourceAnalyser;
    }
}