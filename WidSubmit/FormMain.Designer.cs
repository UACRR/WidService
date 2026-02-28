namespace WidSubmit
{
    partial class FormMain
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
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMiddle = new System.Windows.Forms.TabControl();
            this.tabPageCurSubm = new System.Windows.Forms.TabPage();
            this.ucSubmission = new WidSubmit.UcSubmission();
            this.tabPageRightHolders = new System.Windows.Forms.TabPage();
            this.ucRightHolders = new WidSubmit.UcRightHolders();
            this.tabPageSubmHist = new System.Windows.Forms.TabPage();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.tabPageCurSubm.SuspendLayout();
            this.tabPageRightHolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Size = new System.Drawing.Size(1135, 561);
            this.panelMain.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 522);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelBottom.Size = new System.Drawing.Size(1124, 31);
            this.panelBottom.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1046, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.tabPageCurSubm);
            this.panelMiddle.Controls.Add(this.tabPageRightHolders);
            this.panelMiddle.Controls.Add(this.tabPageSubmHist);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(3, 15);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.SelectedIndex = 0;
            this.panelMiddle.Size = new System.Drawing.Size(1124, 501);
            this.panelMiddle.TabIndex = 1;
            this.panelMiddle.SelectedIndexChanged += new System.EventHandler(this.panelMiddle_SelectedIndexChanged);
            // 
            // tabPageCurSubm
            // 
            this.tabPageCurSubm.Controls.Add(this.ucSubmission);
            this.tabPageCurSubm.Location = new System.Drawing.Point(4, 22);
            this.tabPageCurSubm.Name = "tabPageCurSubm";
            this.tabPageCurSubm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurSubm.Size = new System.Drawing.Size(1116, 475);
            this.tabPageCurSubm.TabIndex = 1;
            this.tabPageCurSubm.Text = "Передача творів";
            this.tabPageCurSubm.UseVisualStyleBackColor = true;
            // 
            // ucSubmission
            // 
            this.ucSubmission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmission.Location = new System.Drawing.Point(3, 3);
            this.ucSubmission.Name = "ucSubmission";
            this.ucSubmission.Size = new System.Drawing.Size(1110, 469);
            this.ucSubmission.TabIndex = 0;
            // 
            // tabPageRightHolders
            // 
            this.tabPageRightHolders.Controls.Add(this.ucRightHolders);
            this.tabPageRightHolders.Location = new System.Drawing.Point(4, 22);
            this.tabPageRightHolders.Name = "tabPageRightHolders";
            this.tabPageRightHolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRightHolders.Size = new System.Drawing.Size(1119, 437);
            this.tabPageRightHolders.TabIndex = 0;
            this.tabPageRightHolders.Text = "Правовласники";
            this.tabPageRightHolders.UseVisualStyleBackColor = true;
            // 
            // ucRightHolders
            // 
            this.ucRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRightHolders.Location = new System.Drawing.Point(3, 3);
            this.ucRightHolders.Name = "ucRightHolders";
            this.ucRightHolders.Size = new System.Drawing.Size(1113, 431);
            this.ucRightHolders.TabIndex = 0;
            // 
            // tabPageSubmHist
            // 
            this.tabPageSubmHist.Location = new System.Drawing.Point(4, 22);
            this.tabPageSubmHist.Name = "tabPageSubmHist";
            this.tabPageSubmHist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSubmHist.Size = new System.Drawing.Size(1119, 437);
            this.tabPageSubmHist.TabIndex = 2;
            this.tabPageSubmHist.Text = "Історія передач";
            this.tabPageSubmHist.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 561);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(0, 600);
            this.Name = "FormMain";
            this.Text = "Публікація творів в WID";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.tabPageCurSubm.ResumeLayout(false);
            this.tabPageRightHolders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl panelMiddle;
        private System.Windows.Forms.TabPage tabPageRightHolders;
        private System.Windows.Forms.TabPage tabPageCurSubm;
        private UcRightHolders ucRightHolders;
        private System.Windows.Forms.TabPage tabPageSubmHist;
        private UcSubmission ucSubmission;
    }
}

