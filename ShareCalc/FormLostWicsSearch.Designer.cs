namespace ShareCalc
{
    partial class FormLostWicsSearch
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
            this.panelTblMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSplitMain = new System.Windows.Forms.SplitContainer();
            this.panelTblWid = new System.Windows.Forms.TableLayoutPanel();
            this.lvWid = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTblMs = new System.Windows.Forms.TableLayoutPanel();
            this.lvMs = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFlowSearchByName = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSearchName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFlowSearchByAuthor = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSearchAuthor = new System.Windows.Forms.TextBox();
            this.panelTblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitMain)).BeginInit();
            this.panelSplitMain.Panel1.SuspendLayout();
            this.panelSplitMain.Panel2.SuspendLayout();
            this.panelSplitMain.SuspendLayout();
            this.panelTblWid.SuspendLayout();
            this.panelTblMs.SuspendLayout();
            this.panelFlowSearchByName.SuspendLayout();
            this.panelFlowSearchByAuthor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTblMain
            // 
            this.panelTblMain.ColumnCount = 1;
            this.panelTblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.Controls.Add(this.panelSplitMain, 0, 1);
            this.panelTblMain.Controls.Add(this.label2, 0, 0);
            this.panelTblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblMain.Location = new System.Drawing.Point(0, 0);
            this.panelTblMain.Name = "panelTblMain";
            this.panelTblMain.RowCount = 3;
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblMain.Size = new System.Drawing.Size(800, 450);
            this.panelTblMain.TabIndex = 0;
            // 
            // panelSplitMain
            // 
            this.panelSplitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitMain.Location = new System.Drawing.Point(3, 38);
            this.panelSplitMain.Name = "panelSplitMain";
            this.panelSplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelSplitMain.Panel1
            // 
            this.panelSplitMain.Panel1.Controls.Add(this.panelTblWid);
            // 
            // panelSplitMain.Panel2
            // 
            this.panelSplitMain.Panel2.Controls.Add(this.panelTblMs);
            this.panelSplitMain.Size = new System.Drawing.Size(794, 374);
            this.panelSplitMain.SplitterDistance = 171;
            this.panelSplitMain.TabIndex = 0;
            // 
            // panelTblWid
            // 
            this.panelTblWid.ColumnCount = 1;
            this.panelTblWid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblWid.Controls.Add(this.lvWid, 0, 1);
            this.panelTblWid.Controls.Add(this.label1, 0, 0);
            this.panelTblWid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblWid.Location = new System.Drawing.Point(0, 0);
            this.panelTblWid.Name = "panelTblWid";
            this.panelTblWid.RowCount = 2;
            this.panelTblWid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblWid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblWid.Size = new System.Drawing.Size(794, 171);
            this.panelTblWid.TabIndex = 0;
            // 
            // lvWid
            // 
            this.lvWid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWid.HideSelection = false;
            this.lvWid.Location = new System.Drawing.Point(3, 38);
            this.lvWid.Name = "lvWid";
            this.lvWid.Size = new System.Drawing.Size(788, 130);
            this.lvWid.TabIndex = 0;
            this.lvWid.UseCompatibleStateImageBehavior = false;
            this.lvWid.SelectedIndexChanged += new System.EventHandler(this.lvWid_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Твори WID";
            // 
            // panelTblMs
            // 
            this.panelTblMs.ColumnCount = 1;
            this.panelTblMs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMs.Controls.Add(this.lvMs, 0, 3);
            this.panelTblMs.Controls.Add(this.label3, 0, 0);
            this.panelTblMs.Controls.Add(this.panelFlowSearchByName, 0, 1);
            this.panelTblMs.Controls.Add(this.panelFlowSearchByAuthor, 0, 2);
            this.panelTblMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblMs.Location = new System.Drawing.Point(0, 0);
            this.panelTblMs.Name = "panelTblMs";
            this.panelTblMs.RowCount = 4;
            this.panelTblMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMs.Size = new System.Drawing.Size(794, 199);
            this.panelTblMs.TabIndex = 0;
            // 
            // lvMs
            // 
            this.lvMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMs.HideSelection = false;
            this.lvMs.Location = new System.Drawing.Point(3, 108);
            this.lvMs.Name = "lvMs";
            this.lvMs.Size = new System.Drawing.Size(788, 88);
            this.lvMs.TabIndex = 0;
            this.lvMs.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Пошук у СМАРТ";
            // 
            // panelFlowSearchByName
            // 
            this.panelFlowSearchByName.Controls.Add(this.label4);
            this.panelFlowSearchByName.Controls.Add(this.tbSearchName);
            this.panelFlowSearchByName.Controls.Add(this.btnSearch);
            this.panelFlowSearchByName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowSearchByName.Location = new System.Drawing.Point(3, 38);
            this.panelFlowSearchByName.Name = "panelFlowSearchByName";
            this.panelFlowSearchByName.Size = new System.Drawing.Size(788, 29);
            this.panelFlowSearchByName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Назва твору";
            // 
            // tbSearchName
            // 
            this.tbSearchName.Location = new System.Drawing.Point(79, 3);
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.Size = new System.Drawing.Size(172, 20);
            this.tbSearchName.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(257, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Шукати";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пошук творів";
            // 
            // panelFlowSearchByAuthor
            // 
            this.panelFlowSearchByAuthor.Controls.Add(this.label5);
            this.panelFlowSearchByAuthor.Controls.Add(this.tbSearchAuthor);
            this.panelFlowSearchByAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowSearchByAuthor.Location = new System.Drawing.Point(3, 73);
            this.panelFlowSearchByAuthor.Name = "panelFlowSearchByAuthor";
            this.panelFlowSearchByAuthor.Size = new System.Drawing.Size(788, 29);
            this.panelFlowSearchByAuthor.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Автор";
            // 
            // tbSearchAuthor
            // 
            this.tbSearchAuthor.Location = new System.Drawing.Point(46, 3);
            this.tbSearchAuthor.Name = "tbSearchAuthor";
            this.tbSearchAuthor.Size = new System.Drawing.Size(205, 20);
            this.tbSearchAuthor.TabIndex = 1;
            this.tbSearchAuthor.TextChanged += new System.EventHandler(this.tbSearchAuthor_TextChanged);
            // 
            // FormLostWicsSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTblMain);
            this.Name = "FormLostWicsSearch";
            this.Text = "Пошук втрачених творів товриства в WID";
            this.Load += new System.EventHandler(this.FormLostWicsSearch_Load);
            this.panelTblMain.ResumeLayout(false);
            this.panelTblMain.PerformLayout();
            this.panelSplitMain.Panel1.ResumeLayout(false);
            this.panelSplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitMain)).EndInit();
            this.panelSplitMain.ResumeLayout(false);
            this.panelTblWid.ResumeLayout(false);
            this.panelTblWid.PerformLayout();
            this.panelTblMs.ResumeLayout(false);
            this.panelTblMs.PerformLayout();
            this.panelFlowSearchByName.ResumeLayout(false);
            this.panelFlowSearchByName.PerformLayout();
            this.panelFlowSearchByAuthor.ResumeLayout(false);
            this.panelFlowSearchByAuthor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelTblMain;
        private System.Windows.Forms.SplitContainer panelSplitMain;
        private System.Windows.Forms.TableLayoutPanel panelTblWid;
        private System.Windows.Forms.ListView lvWid;
        private System.Windows.Forms.TableLayoutPanel panelTblMs;
        private System.Windows.Forms.ListView lvMs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panelFlowSearchByName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearchName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel panelFlowSearchByAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearchAuthor;
    }
}