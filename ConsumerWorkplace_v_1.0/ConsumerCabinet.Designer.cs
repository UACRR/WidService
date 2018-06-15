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
            this.dtTetsDate = new Telerik.WinControls.UI.RadDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtTetsDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gcConsumerCabinet
            // 
            this.gcConsumerCabinet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcConsumerCabinet.Location = new System.Drawing.Point(13, 39);
            this.gcConsumerCabinet.Name = "gcConsumerCabinet";
            this.gcConsumerCabinet.Size = new System.Drawing.Size(1372, 531);
            this.gcConsumerCabinet.TabIndex = 0;
            // 
            // dtTetsDate
            // 
            this.dtTetsDate.Checked = true;
            this.dtTetsDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTetsDate.Location = new System.Drawing.Point(13, 13);
            this.dtTetsDate.Name = "dtTetsDate";
            this.dtTetsDate.Size = new System.Drawing.Size(164, 20);
            this.dtTetsDate.TabIndex = 2;
            this.dtTetsDate.TabStop = false;
            this.dtTetsDate.Text = "13.06.2018";
            this.dtTetsDate.ThemeName = "Office2007Silver";
            this.dtTetsDate.Value = new System.DateTime(2018, 6, 13, 16, 9, 59, 184);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtTetsDate.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtTetsDate.GetChildAt(0))).EnableBorderHighlight = true;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtTetsDate.GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtTetsDate.GetChildAt(0))).Enabled = true;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtTetsDate.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtTetsDate.GetChildAt(0))).ClickMode = Telerik.WinControls.ClickMode.Release;
            // 
            // ConsumerCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 624);
            this.Controls.Add(this.dtTetsDate);
            this.Controls.Add(this.gcConsumerCabinet);
            this.Name = "ConsumerCabinet";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ConsumerCabinet";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.dtTetsDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme;
        private IpsViewComponentLibrary.GlobalControlConsumerCabinet gcConsumerCabinet;
        private Telerik.WinControls.UI.RadDateTimePicker dtTetsDate;
    }
}
