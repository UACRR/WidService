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
            this.anketaPersonControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.anketaPersonControl1.Name = "anketaPersonControl1";
            this.anketaPersonControl1.Size = new System.Drawing.Size(594, 122);
            this.anketaPersonControl1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // FormBinding1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 209);
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

        private DebugFormForControls.AnketaPersonControl anketaPersonControl1;
        public System.Windows.Forms.BindingSource bindingSource1;
    }
}
