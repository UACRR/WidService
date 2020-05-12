namespace DdexInvoicing
{
    partial class FormLongOperation
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
            this.radTbMessage = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radTbMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // radTbMessage
            // 
            this.radTbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTbMessage.Location = new System.Drawing.Point(0, 0);
            this.radTbMessage.Multiline = true;
            this.radTbMessage.Name = "radTbMessage";
            this.radTbMessage.ReadOnly = true;
            // 
            // 
            // 
            this.radTbMessage.RootElement.StretchVertically = true;
            this.radTbMessage.Size = new System.Drawing.Size(295, 100);
            this.radTbMessage.TabIndex = 0;
            // 
            // FormLongOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(295, 100);
            this.ControlBox = false;
            this.Controls.Add(this.radTbMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLongOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Тривала операція";
            ((System.ComponentModel.ISupportInitialize)(this.radTbMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox radTbMessage;
    }
}