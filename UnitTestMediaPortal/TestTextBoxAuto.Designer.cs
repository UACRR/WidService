namespace UnitTestMediaPortal
{
    partial class TestTextBoxAuto
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
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBoxAuto1 = new UnitTestMediaPortal.RadTextBoxAuto();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxAuto1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.radButton1.Location = new System.Drawing.Point(13, 105);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(137, 30);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Ok";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.radLabel1.Location = new System.Drawing.Point(13, 53);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(104, 33);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "radLabel1";
            // 
            // radTextBoxAuto1
            // 
            this.radTextBoxAuto1.AcceptAuto = null;
            this.radTextBoxAuto1.Location = new System.Drawing.Point(13, 13);
            this.radTextBoxAuto1.Name = "radTextBoxAuto1";
            this.radTextBoxAuto1.Size = new System.Drawing.Size(697, 25);
            this.radTextBoxAuto1.TabIndex = 3;
            // 
            // radButton2
            // 
            this.radButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton2.Location = new System.Drawing.Point(156, 105);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(137, 30);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "Error";
            // 
            // TestTextBoxAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 147);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radTextBoxAuto1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radButton1);
            this.Name = "TestTextBoxAuto";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "TestTextBoxAuto";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxAuto1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private RadTextBoxAuto radTextBoxAuto1;
        private Telerik.WinControls.UI.RadButton radButton2;
    }
}
