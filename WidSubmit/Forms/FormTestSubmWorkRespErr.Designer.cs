namespace WidSubmit
{
    partial class FormTestSubmWorkRespErr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestSubmWorkRespErr));
            this.ucSubmWorkRespErr = new WidSubmit.UcSubmWorkRespErr();
            this.SuspendLayout();
            // 
            // ucSubmWorkRespErr
            // 
            this.ucSubmWorkRespErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorkRespErr.Location = new System.Drawing.Point(0, 0);
            this.ucSubmWorkRespErr.Name = "ucSubmWorkRespErr";
            this.ucSubmWorkRespErr.Size = new System.Drawing.Size(800, 450);
            this.ucSubmWorkRespErr.TabIndex = 0;
            // 
            // FormTestSubmWorkRespErr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucSubmWorkRespErr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTestSubmWorkRespErr";
            this.Text = "FormTestSubmWorkRespErr";
            this.ResumeLayout(false);

        }

        #endregion

        private UcSubmWorkRespErr ucSubmWorkRespErr;
    }
}