namespace RadioStationReports
{
    partial class FormJoinObjIdToWic
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
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            panelActions = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            panelCodes = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            tbObjId = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tbWic = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tbIswc = new System.Windows.Forms.TextBox();
            btnCompareWorks = new System.Windows.Forms.Button();
            panelWorkInfo = new System.Windows.Forms.TableLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            labNameMs = new System.Windows.Forms.Label();
            labNameWid = new System.Windows.Forms.Label();
            labAuthorsMs = new System.Windows.Forms.Label();
            labAuthorsWid = new System.Windows.Forms.Label();
            labPerformersMs = new System.Windows.Forms.Label();
            labPerformersWid = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            panelMain.SuspendLayout();
            panelActions.SuspendLayout();
            panelCodes.SuspendLayout();
            panelWorkInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Controls.Add(panelActions, 0, 3);
            panelMain.Controls.Add(label1, 0, 0);
            panelMain.Controls.Add(panelCodes, 0, 1);
            panelMain.Controls.Add(panelWorkInfo, 0, 2);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 4;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            panelMain.Size = new System.Drawing.Size(800, 450);
            panelMain.TabIndex = 0;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnCancel);
            panelActions.Controls.Add(btnApply);
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelActions.Location = new System.Drawing.Point(3, 416);
            panelActions.Name = "panelActions";
            panelActions.Size = new System.Drawing.Size(789, 31);
            panelActions.TabIndex = 1;
            panelActions.WrapContents = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(711, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Відмінтити";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new System.Drawing.Point(619, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(86, 23);
            btnApply.TabIndex = 1;
            btnApply.Text = "Застосувати";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label1.Size = new System.Drawing.Size(789, 26);
            label1.TabIndex = 2;
            label1.Text = "Введіть код WIC або ISWC, що відповідає коду в СМАРТ, порівняйте інформацію і в разі узгодженості натисніть Застосувати";
            // 
            // panelCodes
            // 
            panelCodes.Controls.Add(label2);
            panelCodes.Controls.Add(tbObjId);
            panelCodes.Controls.Add(label3);
            panelCodes.Controls.Add(tbWic);
            panelCodes.Controls.Add(label4);
            panelCodes.Controls.Add(tbIswc);
            panelCodes.Controls.Add(btnCompareWorks);
            panelCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCodes.Location = new System.Drawing.Point(3, 29);
            panelCodes.Name = "panelCodes";
            panelCodes.Size = new System.Drawing.Size(789, 29);
            panelCodes.TabIndex = 3;
            panelCodes.WrapContents = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 7);
            label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 15);
            label2.TabIndex = 0;
            label2.Text = "Код СМАРТ";
            // 
            // tbObjId
            // 
            tbObjId.Location = new System.Drawing.Point(80, 3);
            tbObjId.Name = "tbObjId";
            tbObjId.ReadOnly = true;
            tbObjId.Size = new System.Drawing.Size(124, 23);
            tbObjId.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(210, 7);
            label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 15);
            label3.TabIndex = 1;
            label3.Text = "Код WIC";
            // 
            // tbWic
            // 
            tbWic.Location = new System.Drawing.Point(268, 3);
            tbWic.Name = "tbWic";
            tbWic.Size = new System.Drawing.Size(125, 23);
            tbWic.TabIndex = 3;
            tbWic.TextChanged += tbWic_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(399, 7);
            label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 15);
            label4.TabIndex = 2;
            label4.Text = "Код ISWC";
            // 
            // tbIswc
            // 
            tbIswc.Location = new System.Drawing.Point(463, 3);
            tbIswc.Name = "tbIswc";
            tbIswc.Size = new System.Drawing.Size(126, 23);
            tbIswc.TabIndex = 3;
            tbIswc.TextChanged += tbIswc_TextChanged;
            // 
            // btnCompareWorks
            // 
            btnCompareWorks.Location = new System.Drawing.Point(595, 3);
            btnCompareWorks.Name = "btnCompareWorks";
            btnCompareWorks.Size = new System.Drawing.Size(110, 23);
            btnCompareWorks.TabIndex = 4;
            btnCompareWorks.Text = "Порівняти твори";
            btnCompareWorks.UseVisualStyleBackColor = true;
            btnCompareWorks.Click += btnCompareWorks_Click;
            // 
            // panelWorkInfo
            // 
            panelWorkInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            panelWorkInfo.ColumnCount = 4;
            panelWorkInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            panelWorkInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelWorkInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelWorkInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            panelWorkInfo.Controls.Add(label5, 1, 0);
            panelWorkInfo.Controls.Add(label6, 2, 0);
            panelWorkInfo.Controls.Add(labNameMs, 1, 1);
            panelWorkInfo.Controls.Add(labNameWid, 2, 1);
            panelWorkInfo.Controls.Add(labAuthorsMs, 1, 2);
            panelWorkInfo.Controls.Add(labAuthorsWid, 2, 2);
            panelWorkInfo.Controls.Add(labPerformersMs, 1, 3);
            panelWorkInfo.Controls.Add(labPerformersWid, 2, 3);
            panelWorkInfo.Controls.Add(label13, 0, 1);
            panelWorkInfo.Controls.Add(label14, 0, 2);
            panelWorkInfo.Controls.Add(label15, 0, 3);
            panelWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            panelWorkInfo.Location = new System.Drawing.Point(3, 64);
            panelWorkInfo.Name = "panelWorkInfo";
            panelWorkInfo.RowCount = 4;
            panelWorkInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            panelWorkInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelWorkInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelWorkInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelWorkInfo.Size = new System.Drawing.Size(789, 346);
            panelWorkInfo.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(89, 1);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(332, 24);
            label5.TabIndex = 0;
            label5.Text = "Значення в СМАРТ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(428, 1);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(332, 24);
            label6.TabIndex = 0;
            label6.Text = "Значення в WID";
            // 
            // labNameMs
            // 
            labNameMs.AutoSize = true;
            labNameMs.Location = new System.Drawing.Point(89, 26);
            labNameMs.Name = "labNameMs";
            labNameMs.Size = new System.Drawing.Size(38, 15);
            labNameMs.TabIndex = 0;
            labNameMs.Text = "label5";
            // 
            // labNameWid
            // 
            labNameWid.AutoSize = true;
            labNameWid.Location = new System.Drawing.Point(428, 26);
            labNameWid.Name = "labNameWid";
            labNameWid.Size = new System.Drawing.Size(38, 15);
            labNameWid.TabIndex = 0;
            labNameWid.Text = "label5";
            // 
            // labAuthorsMs
            // 
            labAuthorsMs.AutoSize = true;
            labAuthorsMs.Location = new System.Drawing.Point(89, 42);
            labAuthorsMs.Name = "labAuthorsMs";
            labAuthorsMs.Size = new System.Drawing.Size(38, 15);
            labAuthorsMs.TabIndex = 0;
            labAuthorsMs.Text = "label5";
            // 
            // labAuthorsWid
            // 
            labAuthorsWid.AutoSize = true;
            labAuthorsWid.Location = new System.Drawing.Point(428, 42);
            labAuthorsWid.Name = "labAuthorsWid";
            labAuthorsWid.Size = new System.Drawing.Size(38, 15);
            labAuthorsWid.TabIndex = 0;
            labAuthorsWid.Text = "label5";
            // 
            // labPerformersMs
            // 
            labPerformersMs.AutoSize = true;
            labPerformersMs.Location = new System.Drawing.Point(89, 58);
            labPerformersMs.Name = "labPerformersMs";
            labPerformersMs.Size = new System.Drawing.Size(38, 15);
            labPerformersMs.TabIndex = 0;
            labPerformersMs.Text = "label5";
            // 
            // labPerformersWid
            // 
            labPerformersWid.AutoSize = true;
            labPerformersWid.Location = new System.Drawing.Point(428, 58);
            labPerformersWid.Name = "labPerformersWid";
            labPerformersWid.Size = new System.Drawing.Size(38, 15);
            labPerformersWid.TabIndex = 0;
            labPerformersWid.Text = "label5";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(4, 26);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(41, 15);
            label13.TabIndex = 0;
            label13.Text = "Назва";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label14.Location = new System.Drawing.Point(4, 42);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(49, 15);
            label14.TabIndex = 0;
            label14.Text = "Автори";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label15.Location = new System.Drawing.Point(4, 58);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(68, 15);
            label15.TabIndex = 0;
            label15.Text = "Виконавці";
            // 
            // FormJoinObjIdToWic
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panelMain);
            Name = "FormJoinObjIdToWic";
            Text = "Поєднання коду СМАРТ з кодом WID";
            Load += FormJoinObjIdToWic_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelActions.ResumeLayout(false);
            panelCodes.ResumeLayout(false);
            panelCodes.PerformLayout();
            panelWorkInfo.ResumeLayout(false);
            panelWorkInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panelCodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbObjId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIswc;
        private System.Windows.Forms.Button btnCompareWorks;
        private System.Windows.Forms.TableLayoutPanel panelWorkInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labNameMs;
        private System.Windows.Forms.Label labNameWid;
        private System.Windows.Forms.Label labAuthorsMs;
        private System.Windows.Forms.Label labAuthorsWid;
        private System.Windows.Forms.Label labPerformersMs;
        private System.Windows.Forms.Label labPerformersWid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}