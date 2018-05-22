namespace ipsAnketaClient
{
    partial class AnketaClientView
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
            this.components = new System.ComponentModel.Container();
            this.consumerPlacesCtrl = new ipsAnketaClient.ConsumerPlacesControl();
            this.iClnBusinessPlaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iConsumerCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iClnBusinessPlaceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iConsumerCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // consumerPlacesCtrl
            // 
            this.consumerPlacesCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consumerPlacesCtrl.AutoSize = true;
            this.consumerPlacesCtrl.IdItemOfSelectRow = 0;
            this.consumerPlacesCtrl.Location = new System.Drawing.Point(13, 13);
            this.consumerPlacesCtrl.Name = "consumerPlacesCtrl";
            this.consumerPlacesCtrl.Size = new System.Drawing.Size(1129, 281);
            this.consumerPlacesCtrl.TabIndex = 0;
            // 
            // iClnBusinessPlaceBindingSource
            // 
            this.iClnBusinessPlaceBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IClnBusinessPlace);
            // 
            // iConsumerCompanyBindingSource
            // 
            this.iConsumerCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IConsumerCompany);
            // 
            // AnketaClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1154, 549);
            this.Controls.Add(this.consumerPlacesCtrl);
            this.Name = "AnketaClientView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.iClnBusinessPlaceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iConsumerCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource iClnBusinessPlaceBindingSource;
        private System.Windows.Forms.BindingSource iConsumerCompanyBindingSource;
        private ConsumerPlacesControl consumerPlacesCtrl;
    }
}