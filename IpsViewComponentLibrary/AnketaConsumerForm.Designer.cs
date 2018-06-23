namespace IpsViewComponentLibrary
{
    partial class AnketaConsumerForm
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
            this.ctrlConsumerAnketa = new IpsViewComponentLibrary.GlobalControlConsumerAnketa();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlConsumerAnketa
            // 
            this.ctrlConsumerAnketa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlConsumerAnketa.IsContainPlaces = false;
            this.ctrlConsumerAnketa.Location = new System.Drawing.Point(0, 0);
            this.ctrlConsumerAnketa.Name = "ctrlConsumerAnketa";
            this.ctrlConsumerAnketa.Size = new System.Drawing.Size(1267, 702);
            this.ctrlConsumerAnketa.TabIndex = 0;
            // 
            // AnketaCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 702);
            this.Controls.Add(this.ctrlConsumerAnketa);
            this.Name = "AnketaCustomerForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Анкета нового споживача";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GlobalControlConsumerAnketa ctrlConsumerAnketa;
    }
}
