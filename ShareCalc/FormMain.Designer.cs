namespace ShareCalc
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
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.panelWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvWorks = new System.Windows.Forms.ListView();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ucShareCalc = new ShareCalc.UcShareCalc();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelWorks.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelMiddle, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 2;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(899, 552);
            this.panelMain.TabIndex = 1;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMiddle.Location = new System.Drawing.Point(3, 3);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.panelWorks);
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.ucShareCalc);
            this.panelMiddle.Size = new System.Drawing.Size(893, 511);
            this.panelMiddle.SplitterDistance = 297;
            this.panelMiddle.TabIndex = 0;
            // 
            // panelWorks
            // 
            this.panelWorks.ColumnCount = 1;
            this.panelWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorks.Controls.Add(this.lvWorks, 0, 1);
            this.panelWorks.Controls.Add(this.panelFilter, 0, 0);
            this.panelWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorks.Location = new System.Drawing.Point(0, 0);
            this.panelWorks.Name = "panelWorks";
            this.panelWorks.RowCount = 3;
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelWorks.Size = new System.Drawing.Size(297, 511);
            this.panelWorks.TabIndex = 0;
            // 
            // lvWorks
            // 
            this.lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorks.HideSelection = false;
            this.lvWorks.Location = new System.Drawing.Point(3, 38);
            this.lvWorks.Name = "lvWorks";
            this.lvWorks.Size = new System.Drawing.Size(291, 465);
            this.lvWorks.TabIndex = 0;
            this.lvWorks.UseCompatibleStateImageBehavior = false;
            this.lvWorks.SelectedIndexChanged += new System.EventHandler(this.lvWorks_SelectedIndexChanged);
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.tbFilter);
            this.panelFilter.Controls.Add(this.btnSearch);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(291, 29);
            this.panelFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Твори";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(47, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(166, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(219, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Шукати";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucShareCalc
            // 
            this.ucShareCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShareCalc.Location = new System.Drawing.Point(0, 0);
            this.ucShareCalc.Name = "ucShareCalc";
            this.ucShareCalc.Size = new System.Drawing.Size(592, 511);
            this.ucShareCalc.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 552);
            this.Controls.Add(this.panelMain);
            this.Name = "FormMain";
            this.Text = "Розрахунок процентів правовласників";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.panelWorks.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UcShareCalc ucShareCalc;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.TableLayoutPanel panelWorks;
        private System.Windows.Forms.ListView lvWorks;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnSearch;
    }
}

