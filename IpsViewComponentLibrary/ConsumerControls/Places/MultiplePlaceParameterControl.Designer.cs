namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    partial class MultiplePlaceParameterControl
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
            this.components = new System.ComponentModel.Container();
            this.bsDictRegion = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictTypePlace = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsDictRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDictRegion
            // 
            this.bsDictRegion.DataSource = typeof(ipsFormsDesign.Model.Region);
            // 
            // bsDictTypePlace
            // 
            this.bsDictTypePlace.DataSource = typeof(ipsFormsDesign.Model.TypePlace);
            // 
            // MultiplePlaceParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MultiplePlaceParameterControl";
            this.Size = new System.Drawing.Size(632, 222);
            ((System.ComponentModel.ISupportInitialize)(this.bsDictRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDictRegion;
        private System.Windows.Forms.BindingSource bsDictTypePlace;
    }
}
