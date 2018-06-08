namespace ConsumerWorkplace_v_1._0
{
    partial class ConsumerCabinet
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
            this.office2007SilverTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.gcConsumerCabinet = new IpsViewComponentLibrary.GlobalControlConsumerCabinet();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gcConsumerCabinet
            // 
            this.gcConsumerCabinet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcConsumerCabinet.Location = new System.Drawing.Point(13, 13);
            this.gcConsumerCabinet.Name = "gcConsumerCabinet";
            this.gcConsumerCabinet.Size = new System.Drawing.Size(1372, 599);
            this.gcConsumerCabinet.TabIndex = 0;
            // 
            // ConsumerCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 624);
            this.Controls.Add(this.gcConsumerCabinet);
            this.Name = "ConsumerCabinet";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ConsumerCabinet";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme;
        private IpsViewComponentLibrary.GlobalControlConsumerCabinet gcConsumerCabinet;
    }
}
