namespace UnitTestMediaPortal
{
    partial class FormBinding1
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
            this.anketaPersonControl1 = new DebugFormForControls.AnketaPersonControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.singleShowInformationControl1 = new IpsViewComponentLibrary.SingleShowInformationControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // anketaPersonControl1
            // 
            this.anketaPersonControl1.DataSource = this.bindingSource1;
            this.anketaPersonControl1.DataSourceDropList = 0;
            this.anketaPersonControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.anketaPersonControl1.Location = new System.Drawing.Point(44, 13);
            this.anketaPersonControl1.Margin = new System.Windows.Forms.Padding(4);
            this.anketaPersonControl1.MaximumSize = new System.Drawing.Size(900, 105);
            this.anketaPersonControl1.Name = "anketaPersonControl1";
            this.anketaPersonControl1.Size = new System.Drawing.Size(652, 105);
            this.anketaPersonControl1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // singleShowInformationControl1
            // 
            this.singleShowInformationControl1.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.singleShowInformationControl1.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.singleShowInformationControl1.Location = new System.Drawing.Point(44, 155);
            this.singleShowInformationControl1.MaximumSize = new System.Drawing.Size(1000, 28);
            this.singleShowInformationControl1.MinimumSize = new System.Drawing.Size(150, 25);
            this.singleShowInformationControl1.Name = "singleShowInformationControl1";
            this.singleShowInformationControl1.Size = new System.Drawing.Size(328, 28);
            this.singleShowInformationControl1.SplitterRatio = 91;
            this.singleShowInformationControl1.TabIndex = 1;
            this.singleShowInformationControl1.TextTitle = "Титул текст";
            this.singleShowInformationControl1.TextValue = "Рр 0123456789";
            // 
            // FormBinding1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 209);
            this.Controls.Add(this.singleShowInformationControl1);
            this.Controls.Add(this.anketaPersonControl1);
            this.Name = "FormBinding1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FormBinding1";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.BindingSource bindingSource1;
        public DebugFormForControls.AnketaPersonControl anketaPersonControl1;
        private IpsViewComponentLibrary.SingleShowInformationControl singleShowInformationControl1;
    }
}
