namespace UnitTestMediaPortal
{
    partial class TestGlobalcs
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
            this.testGlobalDic1 = new UnitTestMediaPortal.TestGlobalDic();
            this.SuspendLayout();
            // 
            // testGlobalDic1
            // 
            this.testGlobalDic1.Location = new System.Drawing.Point(3, 12);
            this.testGlobalDic1.Name = "testGlobalDic1";
            this.testGlobalDic1.Size = new System.Drawing.Size(639, 106);
            this.testGlobalDic1.TabIndex = 0;
            this.testGlobalDic1.Load += new System.EventHandler(this.testGlobalDic1_Load);
            // 
            // TestGlobalcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 138);
            this.Controls.Add(this.testGlobalDic1);
            this.Name = "TestGlobalcs";
            this.Text = "TestGlobalcs";
            this.ResumeLayout(false);

        }

        #endregion

        private TestGlobalDic testGlobalDic1;
    }
}