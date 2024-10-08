
namespace WidAdminConsole
{
    partial class FormParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParameters));
            this.ucParameters1 = new WidAdminConsole.UcParameters();
            this.SuspendLayout();
            // 
            // ucParameters1
            // 
            this.ucParameters1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucParameters1.Location = new System.Drawing.Point(0, 0);
            this.ucParameters1.Name = "ucParameters1";
            this.ucParameters1.Size = new System.Drawing.Size(800, 450);
            this.ucParameters1.TabIndex = 0;
            // 
            // FormParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucParameters1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormParameters";
            this.Text = "Налаштування";
            this.ResumeLayout(false);

        }

        #endregion

        private UcParameters ucParameters1;
    }
}