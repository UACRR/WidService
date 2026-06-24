namespace RadioStationReports
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
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            panelWorkData = new System.Windows.Forms.FlowLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            tbWorkName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tbWorkIswc = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tbCisNetCode = new System.Windows.Forms.TextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            panelDetails = new System.Windows.Forms.SplitContainer();
            panelShares = new System.Windows.Forms.TableLayoutPanel();
            lvShares = new System.Windows.Forms.ListView();
            label2 = new System.Windows.Forms.Label();
            panelNamesPerformers = new System.Windows.Forms.SplitContainer();
            panelNames = new System.Windows.Forms.TableLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            lvAltNames = new System.Windows.Forms.ListView();
            panelPerformers = new System.Windows.Forms.TableLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            lvPerformers = new System.Windows.Forms.ListView();
            panelMain.SuspendLayout();
            panelWorkData.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelDetails).BeginInit();
            panelDetails.Panel1.SuspendLayout();
            panelDetails.Panel2.SuspendLayout();
            panelDetails.SuspendLayout();
            panelShares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelNamesPerformers).BeginInit();
            panelNamesPerformers.Panel1.SuspendLayout();
            panelNamesPerformers.Panel2.SuspendLayout();
            panelNamesPerformers.SuspendLayout();
            panelNames.SuspendLayout();
            panelPerformers.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.Controls.Add(panelWorkData, 0, 1);
            panelMain.Controls.Add(tableLayoutPanel1, 0, 0);
            panelMain.Controls.Add(panelDetails, 0, 2);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 4;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Size = new System.Drawing.Size(837, 475);
            panelMain.TabIndex = 0;
            // 
            // panelWorkData
            // 
            panelWorkData.Controls.Add(label3);
            panelWorkData.Controls.Add(tbWorkName);
            panelWorkData.Controls.Add(label4);
            panelWorkData.Controls.Add(tbWorkIswc);
            panelWorkData.Controls.Add(label5);
            panelWorkData.Controls.Add(tbCisNetCode);
            panelWorkData.Dock = System.Windows.Forms.DockStyle.Fill;
            panelWorkData.Location = new System.Drawing.Point(4, 43);
            panelWorkData.Name = "panelWorkData";
            panelWorkData.Size = new System.Drawing.Size(829, 32);
            panelWorkData.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label3.Size = new System.Drawing.Size(73, 22);
            label3.TabIndex = 0;
            label3.Text = "Назва твору";
            // 
            // tbWorkName
            // 
            tbWorkName.Location = new System.Drawing.Point(82, 3);
            tbWorkName.Name = "tbWorkName";
            tbWorkName.ReadOnly = true;
            tbWorkName.Size = new System.Drawing.Size(222, 23);
            tbWorkName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(310, 0);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label4.Size = new System.Drawing.Size(58, 22);
            label4.TabIndex = 0;
            label4.Text = "Код ISWC";
            // 
            // tbWorkIswc
            // 
            tbWorkIswc.Location = new System.Drawing.Point(374, 3);
            tbWorkIswc.Name = "tbWorkIswc";
            tbWorkIswc.ReadOnly = true;
            tbWorkIswc.Size = new System.Drawing.Size(100, 23);
            tbWorkIswc.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(480, 0);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label5.Size = new System.Drawing.Size(65, 22);
            label5.TabIndex = 0;
            label5.Text = "Код CisNet";
            // 
            // tbCisNetCode
            // 
            tbCisNetCode.Location = new System.Drawing.Point(551, 3);
            tbCisNetCode.Name = "tbCisNetCode";
            tbCisNetCode.ReadOnly = true;
            tbCisNetCode.Size = new System.Drawing.Size(159, 23);
            tbCisNetCode.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(829, 32);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label1.Size = new System.Drawing.Size(30, 22);
            label1.TabIndex = 0;
            label1.Text = "Твір";
            // 
            // panelDetails
            // 
            panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            panelDetails.Location = new System.Drawing.Point(4, 82);
            panelDetails.Name = "panelDetails";
            panelDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelDetails.Panel1
            // 
            panelDetails.Panel1.Controls.Add(panelShares);
            // 
            // panelDetails.Panel2
            // 
            panelDetails.Panel2.Controls.Add(panelNamesPerformers);
            panelDetails.Size = new System.Drawing.Size(829, 383);
            panelDetails.SplitterDistance = 233;
            panelDetails.TabIndex = 9;
            // 
            // panelShares
            // 
            panelShares.ColumnCount = 1;
            panelShares.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelShares.Controls.Add(lvShares, 0, 1);
            panelShares.Controls.Add(label2, 0, 0);
            panelShares.Dock = System.Windows.Forms.DockStyle.Fill;
            panelShares.Location = new System.Drawing.Point(0, 0);
            panelShares.Name = "panelShares";
            panelShares.RowCount = 2;
            panelShares.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelShares.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelShares.Size = new System.Drawing.Size(829, 233);
            panelShares.TabIndex = 0;
            // 
            // lvShares
            // 
            lvShares.Dock = System.Windows.Forms.DockStyle.Fill;
            lvShares.Location = new System.Drawing.Point(3, 38);
            lvShares.Name = "lvShares";
            lvShares.Size = new System.Drawing.Size(823, 192);
            lvShares.TabIndex = 5;
            lvShares.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label2.Size = new System.Drawing.Size(823, 35);
            label2.TabIndex = 0;
            label2.Text = "Правовласники";
            // 
            // panelNamesPerformers
            // 
            panelNamesPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            panelNamesPerformers.Location = new System.Drawing.Point(0, 0);
            panelNamesPerformers.Name = "panelNamesPerformers";
            // 
            // panelNamesPerformers.Panel1
            // 
            panelNamesPerformers.Panel1.Controls.Add(panelNames);
            // 
            // panelNamesPerformers.Panel2
            // 
            panelNamesPerformers.Panel2.Controls.Add(panelPerformers);
            panelNamesPerformers.Size = new System.Drawing.Size(829, 146);
            panelNamesPerformers.SplitterDistance = 378;
            panelNamesPerformers.TabIndex = 0;
            // 
            // panelNames
            // 
            panelNames.ColumnCount = 1;
            panelNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelNames.Controls.Add(label6, 0, 0);
            panelNames.Controls.Add(lvAltNames, 0, 1);
            panelNames.Dock = System.Windows.Forms.DockStyle.Fill;
            panelNames.Location = new System.Drawing.Point(0, 0);
            panelNames.Name = "panelNames";
            panelNames.RowCount = 2;
            panelNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelNames.Size = new System.Drawing.Size(378, 146);
            panelNames.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(372, 35);
            label6.TabIndex = 6;
            label6.Text = "Всі назви";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvAltNames
            // 
            lvAltNames.Dock = System.Windows.Forms.DockStyle.Fill;
            lvAltNames.Location = new System.Drawing.Point(3, 38);
            lvAltNames.MultiSelect = false;
            lvAltNames.Name = "lvAltNames";
            lvAltNames.Size = new System.Drawing.Size(372, 105);
            lvAltNames.TabIndex = 7;
            lvAltNames.UseCompatibleStateImageBehavior = false;
            // 
            // panelPerformers
            // 
            panelPerformers.ColumnCount = 1;
            panelPerformers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelPerformers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelPerformers.Controls.Add(label7, 0, 0);
            panelPerformers.Controls.Add(lvPerformers, 0, 1);
            panelPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            panelPerformers.Location = new System.Drawing.Point(0, 0);
            panelPerformers.Name = "panelPerformers";
            panelPerformers.RowCount = 2;
            panelPerformers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelPerformers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelPerformers.Size = new System.Drawing.Size(447, 146);
            panelPerformers.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(441, 35);
            label7.TabIndex = 6;
            label7.Text = "Виконавці";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvPerformers
            // 
            lvPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            lvPerformers.Location = new System.Drawing.Point(3, 38);
            lvPerformers.Name = "lvPerformers";
            lvPerformers.Size = new System.Drawing.Size(441, 105);
            lvPerformers.TabIndex = 8;
            lvPerformers.UseCompatibleStateImageBehavior = false;
            // 
            // UcCisNetImport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelMain);
            Name = "UcCisNetImport";
            Size = new System.Drawing.Size(837, 475);
            Load += UcCisNetImport_Load;
            panelMain.ResumeLayout(false);
            panelWorkData.ResumeLayout(false);
            panelWorkData.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelDetails.Panel1.ResumeLayout(false);
            panelDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelDetails).EndInit();
            panelDetails.ResumeLayout(false);
            panelShares.ResumeLayout(false);
            panelShares.PerformLayout();
            panelNamesPerformers.Panel1.ResumeLayout(false);
            panelNamesPerformers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelNamesPerformers).EndInit();
            panelNamesPerformers.ResumeLayout(false);
            panelNames.ResumeLayout(false);
            panelNames.PerformLayout();
            panelPerformers.ResumeLayout(false);
            panelPerformers.PerformLayout();
            ResumeLayout(false);
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
    }
}
