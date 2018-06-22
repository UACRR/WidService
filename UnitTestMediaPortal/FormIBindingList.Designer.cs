namespace UnitTestMediaPortal
{
    partial class FormIBindingList
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
            this.bindingSourceClient = new System.Windows.Forms.BindingSource(this.components);
            this.calculationInfoNewControl1 = new IpsViewComponentLibrary.CalculationInfoNewControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClient)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSourceClient
            // 
            this.bindingSourceClient.DataSource = typeof(ipsFormsDesign.Model.Client);
            // 
            // calculationInfoNewControl1
            // 
            this.calculationInfoNewControl1.DataMember = "";
            this.calculationInfoNewControl1.DataSource = this.bindingSourceClient;
            this.calculationInfoNewControl1.Location = new System.Drawing.Point(13, 13);
            this.calculationInfoNewControl1.MaximumSize = new System.Drawing.Size(3000, 1000);
            this.calculationInfoNewControl1.MinimumSize = new System.Drawing.Size(400, 562);
            this.calculationInfoNewControl1.Name = "calculationInfoNewControl1";
            this.calculationInfoNewControl1.Size = new System.Drawing.Size(1032, 580);
            this.calculationInfoNewControl1.TabIndex = 0;
            // 
            // FormIBindingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 709);
            this.Controls.Add(this.calculationInfoNewControl1);
            this.Name = "FormIBindingList";
            this.Text = "FormIBindingList";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public IpsViewComponentLibrary.CalculationInfoNewControl calculationInfoNewControl1;
        private System.Windows.Forms.BindingSource bindingSourceClient;
    }
}