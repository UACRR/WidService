namespace WidSubmit.UserControls
{
    partial class UcSubmWorksHist
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
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSubmissions = new System.Windows.Forms.ComboBox();
            this.ucSubmWorks = new WidSubmit.UcSubmWorks();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.ucSubmWorks, 0, 1);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1138, 551);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.cbSubmissions);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1127, 29);
            this.panelTop.TabIndex = 2;
            this.panelTop.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сеанс для розгляду";
            // 
            // cbSubmissions
            // 
            this.cbSubmissions.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbSubmissions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubmissions.FormattingEnabled = true;
            this.cbSubmissions.Location = new System.Drawing.Point(135, 3);
            this.cbSubmissions.Name = "cbSubmissions";
            this.cbSubmissions.Size = new System.Drawing.Size(279, 21);
            this.cbSubmissions.TabIndex = 1;
            this.cbSubmissions.SelectedIndexChanged += new System.EventHandler(this.cbSubmissions_SelectedIndexChanged);
            // 
            // ucSubmWorks
            // 
            this.ucSubmWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorks.Location = new System.Drawing.Point(3, 38);
            this.ucSubmWorks.Name = "ucSubmWorks";
            this.ucSubmWorks.Size = new System.Drawing.Size(1127, 505);
            this.ucSubmWorks.TabIndex = 1;
            // 
            // UcSubmWorksHist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcSubmWorksHist";
            this.Size = new System.Drawing.Size(1138, 551);
            this.Load += new System.EventHandler(this.UcSubmWorksHist_Load);
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private UcSubmWorks ucSubmWorks;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.ComboBox cbSubmissions;
    }
}
