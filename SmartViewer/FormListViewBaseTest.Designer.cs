namespace SmartViewer
{
    partial class FormListViewBaseTest
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.ucListViewBase = new SmartViewer.UcListViewBase();
            this.ucShareDetailsMs1 = new SmartViewer.UcShareDetailsMs();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.ucListViewBase, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 1;
            // 
            // ucListViewBase
            // 
            this.ucListViewBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucListViewBase.Location = new System.Drawing.Point(3, 33);
            this.ucListViewBase.Name = "ucListViewBase";
            this.ucListViewBase.Size = new System.Drawing.Size(794, 384);
            this.ucListViewBase.TabIndex = 0;
            // 
            // ucShareDetailsMs1
            // 
            this.ucShareDetailsMs1.Location = new System.Drawing.Point(402, 254);
            this.ucShareDetailsMs1.Name = "ucShareDetailsMs1";
            this.ucShareDetailsMs1.Size = new System.Drawing.Size(8, 8);
            this.ucShareDetailsMs1.TabIndex = 2;
            // 
            // FormListViewBaseTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucShareDetailsMs1);
            this.Controls.Add(this.panelMain);
            this.Name = "FormListViewBaseTest";
            this.Text = "FormListViewBaseTest";
            this.Load += new System.EventHandler(this.FormListViewBaseTest_Load);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private UcListViewBase ucListViewBase;
        private UcShareDetailsMs ucShareDetailsMs1;
    }
}