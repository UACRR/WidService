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
            label2 = new System.Windows.Forms.Label();
            panelWorkData = new System.Windows.Forms.FlowLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            tbWorkName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tbWorkIswc = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tbCisNetCode = new System.Windows.Forms.TextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            btnPaste = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            lvShares = new System.Windows.Forms.ListView();
            label6 = new System.Windows.Forms.Label();
            lvAltNames = new System.Windows.Forms.ListView();
            label7 = new System.Windows.Forms.Label();
            lvPerformers = new System.Windows.Forms.ListView();
            panelMain.SuspendLayout();
            panelWorkData.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.Controls.Add(label2, 0, 2);
            panelMain.Controls.Add(panelWorkData, 0, 1);
            panelMain.Controls.Add(tableLayoutPanel1, 0, 0);
            panelMain.Controls.Add(lvShares, 0, 3);
            panelMain.Controls.Add(label6, 0, 4);
            panelMain.Controls.Add(lvAltNames, 0, 5);
            panelMain.Controls.Add(label7, 0, 6);
            panelMain.Controls.Add(lvPerformers, 0, 7);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 9;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelMain.Size = new System.Drawing.Size(837, 475);
            panelMain.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(4, 79);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label2.Size = new System.Drawing.Size(829, 27);
            label2.TabIndex = 0;
            label2.Text = "Правовласники";
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
            tbCisNetCode.Size = new System.Drawing.Size(159, 23);
            tbCisNetCode.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            tableLayoutPanel1.Controls.Add(btnPaste, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(829, 32);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnPaste
            // 
            btnPaste.Location = new System.Drawing.Point(702, 3);
            btnPaste.Name = "btnPaste";
            btnPaste.Size = new System.Drawing.Size(124, 23);
            btnPaste.TabIndex = 0;
            btnPaste.Text = "Вставити з CisNet";
            btnPaste.UseVisualStyleBackColor = true;
            btnPaste.Click += btnPaste_Click;
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
            // lvShares
            // 
            lvShares.Dock = System.Windows.Forms.DockStyle.Fill;
            lvShares.Location = new System.Drawing.Point(4, 110);
            lvShares.Name = "lvShares";
            lvShares.Size = new System.Drawing.Size(829, 148);
            lvShares.TabIndex = 5;
            lvShares.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(4, 262);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(829, 25);
            label6.TabIndex = 6;
            label6.Text = "Всі назви";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvAltNames
            // 
            lvAltNames.Dock = System.Windows.Forms.DockStyle.Fill;
            lvAltNames.Location = new System.Drawing.Point(4, 291);
            lvAltNames.MultiSelect = false;
            lvAltNames.Name = "lvAltNames";
            lvAltNames.Size = new System.Drawing.Size(829, 72);
            lvAltNames.TabIndex = 7;
            lvAltNames.UseCompatibleStateImageBehavior = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(4, 367);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(829, 29);
            label7.TabIndex = 6;
            label7.Text = "Виконавці";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvPerformers
            // 
            lvPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            lvPerformers.Location = new System.Drawing.Point(4, 400);
            lvPerformers.Name = "lvPerformers";
            lvPerformers.Size = new System.Drawing.Size(829, 65);
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
            panelMain.PerformLayout();
            panelWorkData.ResumeLayout(false);
            panelWorkData.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPaste;
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
    }
}
