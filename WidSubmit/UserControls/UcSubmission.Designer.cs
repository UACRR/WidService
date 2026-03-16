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
            this.ucSubmWorks = new WidSubmit.UcSubmWorks();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 3;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.ucSubmProcessControl, 0, 0);
            this.panelMain.Controls.Add(this.ucSubmWorks, 1, 0);
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
            // ucSubmWorks
            // 
            this.ucSubmWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorks.Location = new System.Drawing.Point(261, 3);
            this.ucSubmWorks.Name = "ucSubmWorks";
            this.ucSubmWorks.Size = new System.Drawing.Size(502, 355);
            this.ucSubmWorks.TabIndex = 1;
            // 
            // UcSubmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcSubmission";
            this.Size = new System.Drawing.Size(771, 366);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private UcSubmProcessControl ucSubmProcessControl;
        private UcSubmWorks ucSubmWorks;
    }
}
