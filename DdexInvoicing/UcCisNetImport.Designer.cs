namespace DdexInvoicing
{
    partial class UcCisNetImport
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
            this.panelWorkData = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWorkName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWorkIswc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCisNetCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.SplitContainer();
            this.panelShares = new System.Windows.Forms.TableLayoutPanel();
            this.lvShares = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelNamesPerformers = new System.Windows.Forms.SplitContainer();
            this.panelNames = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lvAltNames = new System.Windows.Forms.ListView();
            this.panelPerformers = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lvPerformers = new System.Windows.Forms.ListView();
            this.panelTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGetWork = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelWorkData.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDetails)).BeginInit();
            this.panelDetails.Panel1.SuspendLayout();
            this.panelDetails.Panel2.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelShares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelNamesPerformers)).BeginInit();
            this.panelNamesPerformers.Panel1.SuspendLayout();
            this.panelNamesPerformers.Panel2.SuspendLayout();
            this.panelNamesPerformers.SuspendLayout();
            this.panelNames.SuspendLayout();
            this.panelPerformers.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelWorkData, 0, 2);
            this.panelMain.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.panelMain.Controls.Add(this.panelDetails, 0, 3);
            this.panelMain.Controls.Add(this.panelTitle, 0, 0);
            this.panelMain.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 6;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.panelMain.Size = new System.Drawing.Size(717, 412);
            this.panelMain.TabIndex = 0;
            // 
            // panelWorkData
            // 
            this.panelWorkData.Controls.Add(this.label3);
            this.panelWorkData.Controls.Add(this.tbWorkName);
            this.panelWorkData.Controls.Add(this.label4);
            this.panelWorkData.Controls.Add(this.tbWorkIswc);
            this.panelWorkData.Controls.Add(this.label5);
            this.panelWorkData.Controls.Add(this.tbCisNetCode);
            this.panelWorkData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkData.Location = new System.Drawing.Point(4, 72);
            this.panelWorkData.Name = "panelWorkData";
            this.panelWorkData.Size = new System.Drawing.Size(709, 27);
            this.panelWorkData.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Назва твору";
            // 
            // tbWorkName
            // 
            this.tbWorkName.Location = new System.Drawing.Point(79, 3);
            this.tbWorkName.Name = "tbWorkName";
            this.tbWorkName.ReadOnly = true;
            this.tbWorkName.Size = new System.Drawing.Size(191, 20);
            this.tbWorkName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Код ISWC";
            // 
            // tbWorkIswc
            // 
            this.tbWorkIswc.Location = new System.Drawing.Point(339, 3);
            this.tbWorkIswc.Name = "tbWorkIswc";
            this.tbWorkIswc.ReadOnly = true;
            this.tbWorkIswc.Size = new System.Drawing.Size(86, 20);
            this.tbWorkIswc.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Код CisNet";
            // 
            // tbCisNetCode
            // 
            this.tbCisNetCode.Location = new System.Drawing.Point(497, 3);
            this.tbCisNetCode.Name = "tbCisNetCode";
            this.tbCisNetCode.ReadOnly = true;
            this.tbCisNetCode.Size = new System.Drawing.Size(137, 20);
            this.tbCisNetCode.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(709, 27);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Size = new System.Drawing.Size(30, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Твір";
            // 
            // panelDetails
            // 
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(4, 106);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelDetails.Panel1
            // 
            this.panelDetails.Panel1.Controls.Add(this.panelShares);
            // 
            // panelDetails.Panel2
            // 
            this.panelDetails.Panel2.Controls.Add(this.panelNamesPerformers);
            this.panelDetails.Size = new System.Drawing.Size(709, 263);
            this.panelDetails.SplitterDistance = 159;
            this.panelDetails.SplitterWidth = 3;
            this.panelDetails.TabIndex = 9;
            // 
            // panelShares
            // 
            this.panelShares.ColumnCount = 1;
            this.panelShares.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelShares.Controls.Add(this.lvShares, 0, 1);
            this.panelShares.Controls.Add(this.label2, 0, 0);
            this.panelShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShares.Location = new System.Drawing.Point(0, 0);
            this.panelShares.Name = "panelShares";
            this.panelShares.RowCount = 2;
            this.panelShares.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelShares.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelShares.Size = new System.Drawing.Size(709, 159);
            this.panelShares.TabIndex = 0;
            // 
            // lvShares
            // 
            this.lvShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShares.HideSelection = false;
            this.lvShares.Location = new System.Drawing.Point(3, 33);
            this.lvShares.Name = "lvShares";
            this.lvShares.Size = new System.Drawing.Size(703, 123);
            this.lvShares.TabIndex = 5;
            this.lvShares.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label2.Size = new System.Drawing.Size(703, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Правовласники";
            // 
            // panelNamesPerformers
            // 
            this.panelNamesPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNamesPerformers.Location = new System.Drawing.Point(0, 0);
            this.panelNamesPerformers.Name = "panelNamesPerformers";
            // 
            // panelNamesPerformers.Panel1
            // 
            this.panelNamesPerformers.Panel1.Controls.Add(this.panelNames);
            // 
            // panelNamesPerformers.Panel2
            // 
            this.panelNamesPerformers.Panel2.Controls.Add(this.panelPerformers);
            this.panelNamesPerformers.Size = new System.Drawing.Size(709, 101);
            this.panelNamesPerformers.SplitterDistance = 323;
            this.panelNamesPerformers.SplitterWidth = 3;
            this.panelNamesPerformers.TabIndex = 0;
            // 
            // panelNames
            // 
            this.panelNames.ColumnCount = 1;
            this.panelNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.panelNames.Controls.Add(this.label6, 0, 0);
            this.panelNames.Controls.Add(this.lvAltNames, 0, 1);
            this.panelNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNames.Location = new System.Drawing.Point(0, 0);
            this.panelNames.Name = "panelNames";
            this.panelNames.RowCount = 2;
            this.panelNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelNames.Size = new System.Drawing.Size(323, 101);
            this.panelNames.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(317, 30);
            this.label6.TabIndex = 6;
            this.label6.Text = "Всі назви";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvAltNames
            // 
            this.lvAltNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAltNames.HideSelection = false;
            this.lvAltNames.Location = new System.Drawing.Point(3, 33);
            this.lvAltNames.MultiSelect = false;
            this.lvAltNames.Name = "lvAltNames";
            this.lvAltNames.Size = new System.Drawing.Size(317, 65);
            this.lvAltNames.TabIndex = 7;
            this.lvAltNames.UseCompatibleStateImageBehavior = false;
            // 
            // panelPerformers
            // 
            this.panelPerformers.ColumnCount = 1;
            this.panelPerformers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPerformers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.panelPerformers.Controls.Add(this.label7, 0, 0);
            this.panelPerformers.Controls.Add(this.lvPerformers, 0, 1);
            this.panelPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPerformers.Location = new System.Drawing.Point(0, 0);
            this.panelPerformers.Name = "panelPerformers";
            this.panelPerformers.RowCount = 2;
            this.panelPerformers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelPerformers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPerformers.Size = new System.Drawing.Size(383, 101);
            this.panelPerformers.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(377, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "Виконавці";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvPerformers
            // 
            this.lvPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPerformers.HideSelection = false;
            this.lvPerformers.Location = new System.Drawing.Point(3, 33);
            this.lvPerformers.Name = "lvPerformers";
            this.lvPerformers.Size = new System.Drawing.Size(377, 65);
            this.lvPerformers.TabIndex = 8;
            this.lvPerformers.UseCompatibleStateImageBehavior = false;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Linen;
            this.panelTitle.Controls.Add(this.label8);
            this.panelTitle.Controls.Add(this.btnGetWork);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitle.Location = new System.Drawing.Point(4, 4);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(709, 27);
            this.panelTitle.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label8.Size = new System.Drawing.Size(227, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Імпортуйте твір з додатку CisNet і натисніть";
            // 
            // btnGetWork
            // 
            this.btnGetWork.Location = new System.Drawing.Point(236, 3);
            this.btnGetWork.Name = "btnGetWork";
            this.btnGetWork.Size = new System.Drawing.Size(104, 23);
            this.btnGetWork.TabIndex = 1;
            this.btnGetWork.Text = "Отримати твір";
            this.btnGetWork.UseVisualStyleBackColor = true;
            this.btnGetWork.Click += new System.EventHandler(this.btnGetWork_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Linen;
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.btnApply);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 376);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(709, 27);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label9.Size = new System.Drawing.Size(226, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Якщо твір відповідає рядку звіту натисніть ";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(235, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(104, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Застосувати";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // UcCisNetImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcCisNetImport";
            this.Size = new System.Drawing.Size(717, 412);
            this.Load += new System.EventHandler(this.UcCisNetImport_Load);
            this.panelMain.ResumeLayout(false);
            this.panelWorkData.ResumeLayout(false);
            this.panelWorkData.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelDetails.Panel1.ResumeLayout(false);
            this.panelDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelDetails)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelShares.ResumeLayout(false);
            this.panelShares.PerformLayout();
            this.panelNamesPerformers.Panel1.ResumeLayout(false);
            this.panelNamesPerformers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelNamesPerformers)).EndInit();
            this.panelNamesPerformers.ResumeLayout(false);
            this.panelNames.ResumeLayout(false);
            this.panelNames.PerformLayout();
            this.panelPerformers.ResumeLayout(false);
            this.panelPerformers.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel panelWorkData;
        private System.Windows.Forms.TextBox tbWorkName;
        private System.Windows.Forms.TextBox tbWorkIswc;
        private System.Windows.Forms.TextBox tbCisNetCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvShares;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvAltNames;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvPerformers;
        private System.Windows.Forms.SplitContainer panelDetails;
        private System.Windows.Forms.TableLayoutPanel panelShares;
        private System.Windows.Forms.SplitContainer panelNamesPerformers;
        private System.Windows.Forms.TableLayoutPanel panelNames;
        private System.Windows.Forms.TableLayoutPanel panelPerformers;
        private System.Windows.Forms.FlowLayoutPanel panelTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGetWork;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnApply;
    }
}
