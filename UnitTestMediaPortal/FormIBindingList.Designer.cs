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
            this.calculationInfoNewControl1.DataSource = typeof(ipsFormsDesign.Model.Client);
            this.calculationInfoNewControl1.Location = new System.Drawing.Point(13, 13);
            this.calculationInfoNewControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculationInfoNewControl1.MaximumSize = new System.Drawing.Size(4500, 1538);
            this.calculationInfoNewControl1.MinimumSize = new System.Drawing.Size(600, 865);
            this.calculationInfoNewControl1.Name = "calculationInfoNewControl1";
            this.calculationInfoNewControl1.Size = new System.Drawing.Size(1548, 892);
            this.calculationInfoNewControl1.TabIndex = 0;
            // 
            // FormIBindingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 1091);
            this.Controls.Add(this.calculationInfoNewControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormIBindingList";
            this.Text = "FormIBindingList";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSourceClient;
        private IpsViewComponentLibrary.CalculationInfoNewControl calculationInfoNewControl1;
    }
}