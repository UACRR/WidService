namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    partial class SubPublisherInUkraineControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSubPublisherInUkraine = new IpsViewComponentLibrary.Common.Editors.IpsTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubPublisherInUkraine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSubPublisherInUkraine
            // 
            this.txtSubPublisherInUkraine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubPublisherInUkraine.Location = new System.Drawing.Point(229, 3);
            this.txtSubPublisherInUkraine.Name = "txtSubPublisherInUkraine";
            this.txtSubPublisherInUkraine.ReadOnly = true;
            this.txtSubPublisherInUkraine.Size = new System.Drawing.Size(237, 21);
            this.txtSubPublisherInUkraine.TabIndex = 4;
            this.txtSubPublisherInUkraine.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(3, 4);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(220, 19);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Субвидавництво на території України";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // SubPublisherInUkraineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtSubPublisherInUkraine);
            this.Controls.Add(this.radLabel4);
            this.MaximumSize = new System.Drawing.Size(1000, 27);
            this.MinimumSize = new System.Drawing.Size(340, 27);
            this.Name = "SubPublisherInUkraineControl";
            this.Size = new System.Drawing.Size(469, 27);
            ((System.ComponentModel.ISupportInitialize)(this.txtSubPublisherInUkraine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Editors.IpsTextBox txtSubPublisherInUkraine;
        private Telerik.WinControls.UI.RadLabel radLabel4;
    }
}
