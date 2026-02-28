namespace WidSubmit
{
    partial class UcSubmission
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.ucSubmProcessControl = new WidSubmit.UcSubmProcessControl();
            this.panelSubmWorks = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelSubmWorks.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 3;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.ucSubmProcessControl, 0, 0);
            this.panelMain.Controls.Add(this.panelSubmWorks, 1, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 2;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Size = new System.Drawing.Size(771, 366);
            this.panelMain.TabIndex = 0;
            // 
            // ucSubmProcessControl
            // 
            this.ucSubmProcessControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmProcessControl.Location = new System.Drawing.Point(3, 3);
            this.ucSubmProcessControl.Name = "ucSubmProcessControl";
            this.ucSubmProcessControl.Size = new System.Drawing.Size(252, 355);
            this.ucSubmProcessControl.TabIndex = 0;
            // 
            // panelSubmWorks
            // 
            this.panelSubmWorks.ColumnCount = 2;
            this.panelSubmWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSubmWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelSubmWorks.Controls.Add(this.label1, 0, 0);
            this.panelSubmWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSubmWorks.Location = new System.Drawing.Point(261, 3);
            this.panelSubmWorks.Name = "panelSubmWorks";
            this.panelSubmWorks.RowCount = 2;
            this.panelSubmWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelSubmWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSubmWorks.Size = new System.Drawing.Size(502, 355);
            this.panelSubmWorks.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // UcSubmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcSubmission";
            this.Size = new System.Drawing.Size(771, 366);
            this.panelMain.ResumeLayout(false);
            this.panelSubmWorks.ResumeLayout(false);
            this.panelSubmWorks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private UcSubmProcessControl ucSubmProcessControl;
        private System.Windows.Forms.TableLayoutPanel panelSubmWorks;
        private System.Windows.Forms.Label label1;
    }
}
