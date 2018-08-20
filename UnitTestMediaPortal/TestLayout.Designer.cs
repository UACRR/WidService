namespace UnitTestMediaPortal
{
    partial class TestLayout
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
            this.radLayoutControl1 = new Telerik.WinControls.UI.RadLayoutControl();
            this.layoutControlGroupItem3 = new Telerik.WinControls.UI.LayoutControlGroupItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.layoutControlItem1 = new Telerik.WinControls.UI.LayoutControlItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.layoutControlItem2 = new Telerik.WinControls.UI.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.radLayoutControl1)).BeginInit();
            this.radLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLayoutControl1
            // 
            this.radLayoutControl1.Controls.Add(this.textBox1);
            this.radLayoutControl1.Controls.Add(this.textBox2);
            this.radLayoutControl1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.layoutControlGroupItem3,
            this.layoutControlItem2});
            this.radLayoutControl1.Location = new System.Drawing.Point(13, 13);
            this.radLayoutControl1.Name = "radLayoutControl1";
            this.radLayoutControl1.Size = new System.Drawing.Size(1091, 423);
            this.radLayoutControl1.TabIndex = 0;
            // 
            // layoutControlGroupItem3
            // 
            this.layoutControlGroupItem3.Bounds = new System.Drawing.Rectangle(0, 0, 1091, 28);
            this.layoutControlGroupItem3.IsExpanded = false;
            this.layoutControlGroupItem3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.layoutControlItem1});
            this.layoutControlGroupItem3.Name = "layoutControlGroupItem3";
            this.layoutControlGroupItem3.Text = "layoutControlGroupItem3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1077, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "sawrqwrwerwerw";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AssociatedControl = this.textBox1;
            this.layoutControlItem1.Bounds = new System.Drawing.Rectangle(0, 0, 1083, 167);
            this.layoutControlItem1.ControlVerticalAlignment = Telerik.WinControls.UI.RadVerticalAlignment.Center;
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Text = "layoutControlItem1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(3, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1085, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "2312312312312";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AssociatedControl = this.textBox2;
            this.layoutControlItem2.Bounds = new System.Drawing.Rectangle(0, 28, 1091, 395);
            this.layoutControlItem2.ControlVerticalAlignment = Telerik.WinControls.UI.RadVerticalAlignment.Top;
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Text = "layoutControlItem2";
            // 
            // TestLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 448);
            this.Controls.Add(this.radLayoutControl1);
            this.Name = "TestLayout";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "TestLayout";
            ((System.ComponentModel.ISupportInitialize)(this.radLayoutControl1)).EndInit();
            this.radLayoutControl1.ResumeLayout(false);
            this.radLayoutControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLayoutControl radLayoutControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Telerik.WinControls.UI.LayoutControlGroupItem layoutControlGroupItem3;
        private Telerik.WinControls.UI.LayoutControlItem layoutControlItem1;
        private Telerik.WinControls.UI.LayoutControlItem layoutControlItem2;
    }
}
