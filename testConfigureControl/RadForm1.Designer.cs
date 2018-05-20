namespace testConfigureControl
{
    partial class RadForm1
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
            this.iAnketaPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.anketaPersonControl1 = new DebugFormForControls.AnketaPersonControl();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // iAnketaPersonBindingSource
            // 
            this.iAnketaPersonBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // anketaPersonControl1
            // 
            this.anketaPersonControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            this.anketaPersonControl1.DataSourceDropList = 0;
            this.anketaPersonControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.anketaPersonControl1.Location = new System.Drawing.Point(13, -1);
            this.anketaPersonControl1.Margin = new System.Windows.Forms.Padding(4);
            this.anketaPersonControl1.MaximumSize = new System.Drawing.Size(1200, 129);
            this.anketaPersonControl1.Name = "anketaPersonControl1";
            this.anketaPersonControl1.Size = new System.Drawing.Size(1074, 129);
            this.anketaPersonControl1.TabIndex = 0;
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 270);
            this.Controls.Add(this.anketaPersonControl1);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource iAnketaPersonBindingSource;
        private DebugFormForControls.AnketaPersonControl anketaPersonControl1;
    }
}