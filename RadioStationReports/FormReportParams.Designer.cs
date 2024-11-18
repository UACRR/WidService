namespace RadioStationReports
{
    partial class FormReportParams
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panelEnd = new System.Windows.Forms.FlowLayoutPanel();
            label4 = new System.Windows.Forms.Label();
            tbEndYear = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tbEndMonth = new System.Windows.Forms.TextBox();
            panelStart = new System.Windows.Forms.FlowLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            tbStartYear = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            tbStartMonth = new System.Windows.Forms.TextBox();
            panelRadioStation = new System.Windows.Forms.FlowLayoutPanel();
            cbRadioStation = new System.Windows.Forms.ComboBox();
            btnNewRadioStation = new System.Windows.Forms.Button();
            btnAddRadioStation = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            panelActions = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            tbFileName = new System.Windows.Forms.TextBox();
            panelMain.SuspendLayout();
            panelEnd.SuspendLayout();
            panelStart.SuspendLayout();
            panelRadioStation.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.8341961F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.1658F));
            panelMain.Controls.Add(label1, 0, 1);
            panelMain.Controls.Add(label2, 0, 2);
            panelMain.Controls.Add(label3, 0, 3);
            panelMain.Controls.Add(panelEnd, 1, 3);
            panelMain.Controls.Add(panelStart, 1, 2);
            panelMain.Controls.Add(panelRadioStation, 1, 1);
            panelMain.Controls.Add(panelActions, 1, 4);
            panelMain.Controls.Add(label8, 0, 0);
            panelMain.Controls.Add(tbFileName, 1, 0);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 6;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            panelMain.Size = new System.Drawing.Size(386, 183);
            panelMain.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(3, 30);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            label1.Size = new System.Drawing.Size(79, 23);
            label1.TabIndex = 0;
            label1.Text = "Радіостанція";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(3, 68);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            label2.Size = new System.Drawing.Size(58, 36);
            label2.TabIndex = 0;
            label2.Text = "Початок звітності";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(3, 104);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            label3.Size = new System.Drawing.Size(75, 36);
            label3.TabIndex = 0;
            label3.Text = "Закінчення звітності";
            // 
            // panelEnd
            // 
            panelEnd.Controls.Add(label4);
            panelEnd.Controls.Add(tbEndYear);
            panelEnd.Controls.Add(label5);
            panelEnd.Controls.Add(tbEndMonth);
            panelEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            panelEnd.Location = new System.Drawing.Point(95, 107);
            panelEnd.Name = "panelEnd";
            panelEnd.Size = new System.Drawing.Size(288, 30);
            panelEnd.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 0);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label4.Size = new System.Drawing.Size(23, 21);
            label4.TabIndex = 0;
            label4.Text = "Рік";
            // 
            // tbEndYear
            // 
            tbEndYear.Location = new System.Drawing.Point(32, 3);
            tbEndYear.Name = "tbEndYear";
            tbEndYear.Size = new System.Drawing.Size(49, 23);
            tbEndYear.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(87, 0);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label5.Size = new System.Drawing.Size(46, 21);
            label5.TabIndex = 0;
            label5.Text = "Місяць";
            // 
            // tbEndMonth
            // 
            tbEndMonth.Location = new System.Drawing.Point(139, 3);
            tbEndMonth.Name = "tbEndMonth";
            tbEndMonth.Size = new System.Drawing.Size(24, 23);
            tbEndMonth.TabIndex = 1;
            // 
            // panelStart
            // 
            panelStart.Controls.Add(label6);
            panelStart.Controls.Add(tbStartYear);
            panelStart.Controls.Add(label7);
            panelStart.Controls.Add(tbStartMonth);
            panelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            panelStart.Location = new System.Drawing.Point(95, 71);
            panelStart.Name = "panelStart";
            panelStart.Size = new System.Drawing.Size(288, 30);
            panelStart.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 0);
            label6.Name = "label6";
            label6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label6.Size = new System.Drawing.Size(23, 21);
            label6.TabIndex = 0;
            label6.Text = "Рік";
            // 
            // tbStartYear
            // 
            tbStartYear.Location = new System.Drawing.Point(32, 3);
            tbStartYear.Name = "tbStartYear";
            tbStartYear.Size = new System.Drawing.Size(49, 23);
            tbStartYear.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(87, 0);
            label7.Name = "label7";
            label7.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label7.Size = new System.Drawing.Size(46, 21);
            label7.TabIndex = 0;
            label7.Text = "Місяць";
            // 
            // tbStartMonth
            // 
            tbStartMonth.Location = new System.Drawing.Point(139, 3);
            tbStartMonth.Name = "tbStartMonth";
            tbStartMonth.Size = new System.Drawing.Size(24, 23);
            tbStartMonth.TabIndex = 1;
            // 
            // panelRadioStation
            // 
            panelRadioStation.Controls.Add(cbRadioStation);
            panelRadioStation.Controls.Add(btnNewRadioStation);
            panelRadioStation.Controls.Add(btnAddRadioStation);
            panelRadioStation.Controls.Add(button1);
            panelRadioStation.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRadioStation.Location = new System.Drawing.Point(95, 33);
            panelRadioStation.Name = "panelRadioStation";
            panelRadioStation.Size = new System.Drawing.Size(288, 32);
            panelRadioStation.TabIndex = 1;
            // 
            // cbRadioStation
            // 
            cbRadioStation.DisplayMember = "Name";
            cbRadioStation.FormattingEnabled = true;
            cbRadioStation.Location = new System.Drawing.Point(3, 3);
            cbRadioStation.Name = "cbRadioStation";
            cbRadioStation.Size = new System.Drawing.Size(181, 23);
            cbRadioStation.TabIndex = 0;
            cbRadioStation.SelectedIndexChanged += cbRadioStation_SelectedIndexChanged;
            cbRadioStation.TextUpdate += cbRadioStation_TextUpdate;
            // 
            // btnNewRadioStation
            // 
            btnNewRadioStation.Location = new System.Drawing.Point(190, 3);
            btnNewRadioStation.Name = "btnNewRadioStation";
            btnNewRadioStation.Size = new System.Drawing.Size(75, 23);
            btnNewRadioStation.TabIndex = 3;
            btnNewRadioStation.Text = "Створити";
            btnNewRadioStation.UseVisualStyleBackColor = true;
            // 
            // btnAddRadioStation
            // 
            btnAddRadioStation.Location = new System.Drawing.Point(3, 32);
            btnAddRadioStation.Name = "btnAddRadioStation";
            btnAddRadioStation.Size = new System.Drawing.Size(100, 23);
            btnAddRadioStation.TabIndex = 1;
            btnAddRadioStation.Text = "Додати нову";
            btnAddRadioStation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(109, 32);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 52);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnCancel);
            panelActions.Controls.Add(btnApply);
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelActions.Location = new System.Drawing.Point(95, 143);
            panelActions.Name = "panelActions";
            panelActions.Size = new System.Drawing.Size(288, 31);
            panelActions.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(210, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Відмінити";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new System.Drawing.Point(119, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(85, 23);
            btnApply.TabIndex = 0;
            btnApply.Text = "Застосувати";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(3, 0);
            label8.Name = "label8";
            label8.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            label8.Size = new System.Drawing.Size(80, 23);
            label8.TabIndex = 3;
            label8.Text = "Назва файлу";
            // 
            // tbFileName
            // 
            tbFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbFileName.Location = new System.Drawing.Point(95, 3);
            tbFileName.Name = "tbFileName";
            tbFileName.ReadOnly = true;
            tbFileName.Size = new System.Drawing.Size(288, 23);
            tbFileName.TabIndex = 4;
            // 
            // FormReportParams
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(386, 183);
            ControlBox = false;
            Controls.Add(panelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormReportParams";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Параметри звіту";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelEnd.ResumeLayout(false);
            panelEnd.PerformLayout();
            panelStart.ResumeLayout(false);
            panelStart.PerformLayout();
            panelRadioStation.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel panelEnd;
        private System.Windows.Forms.FlowLayoutPanel panelStart;
        private System.Windows.Forms.FlowLayoutPanel panelRadioStation;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbRadioStation;
        private System.Windows.Forms.Button btnAddRadioStation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEndYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEndMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbStartYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbStartMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnNewRadioStation;
        private System.Windows.Forms.Button button1;
    }
}