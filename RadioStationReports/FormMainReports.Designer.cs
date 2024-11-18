
namespace RadioStationReports
{
    partial class FormMainReports
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
            panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            btnClose = new System.Windows.Forms.Button();
            btnShowReport = new System.Windows.Forms.Button();
            btnArhive = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnParams = new System.Windows.Forms.Button();
            btnRegisterReport = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            lvReports = new System.Windows.Forms.ListView();
            panelFilterArchived = new System.Windows.Forms.FlowLayoutPanel();
            radioFilterActive = new System.Windows.Forms.RadioButton();
            radioFilterArchived = new System.Windows.Forms.RadioButton();
            panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            cbFilterRadioStation = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cbFilterStartYear = new System.Windows.Forms.ComboBox();
            filterStartMonth = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            cbFilterEndYEar = new System.Windows.Forms.ComboBox();
            cbFilterEndMonth = new System.Windows.Forms.ComboBox();
            btnFilterApply = new System.Windows.Forms.Button();
            openFileDlg = new System.Windows.Forms.OpenFileDialog();
            panelMain.SuspendLayout();
            panelBottom.SuspendLayout();
            panelFilterArchived.SuspendLayout();
            panelFilter.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.Controls.Add(panelBottom, 0, 4);
            panelMain.Controls.Add(label1, 0, 0);
            panelMain.Controls.Add(lvReports, 0, 3);
            panelMain.Controls.Add(panelFilterArchived, 0, 1);
            panelMain.Controls.Add(panelFilter, 0, 2);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 6;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            panelMain.Size = new System.Drawing.Size(800, 450);
            panelMain.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnClose);
            panelBottom.Controls.Add(btnShowReport);
            panelBottom.Controls.Add(btnArhive);
            panelBottom.Controls.Add(btnDelete);
            panelBottom.Controls.Add(btnParams);
            panelBottom.Controls.Add(btnRegisterReport);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelBottom.Location = new System.Drawing.Point(3, 413);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(794, 26);
            panelBottom.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(735, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(56, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Вихід";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnShowReport
            // 
            btnShowReport.Location = new System.Drawing.Point(649, 3);
            btnShowReport.Name = "btnShowReport";
            btnShowReport.Size = new System.Drawing.Size(80, 23);
            btnShowReport.TabIndex = 0;
            btnShowReport.Text = "Показати";
            btnShowReport.UseVisualStyleBackColor = true;
            btnShowReport.Click += btnShowReport_Click;
            // 
            // btnArhive
            // 
            btnArhive.Location = new System.Drawing.Point(568, 3);
            btnArhive.Name = "btnArhive";
            btnArhive.Size = new System.Drawing.Size(75, 23);
            btnArhive.TabIndex = 1;
            btnArhive.Text = "До архіву";
            btnArhive.UseVisualStyleBackColor = true;
            btnArhive.Click += btnArhive_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(487, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(75, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnParams
            // 
            btnParams.Location = new System.Drawing.Point(398, 3);
            btnParams.Name = "btnParams";
            btnParams.Size = new System.Drawing.Size(83, 23);
            btnParams.TabIndex = 1;
            btnParams.Text = "Параметри";
            btnParams.UseVisualStyleBackColor = true;
            btnParams.Click += btnParams_Click;
            // 
            // btnRegisterReport
            // 
            btnRegisterReport.Location = new System.Drawing.Point(220, 3);
            btnRegisterReport.Name = "btnRegisterReport";
            btnRegisterReport.Size = new System.Drawing.Size(172, 23);
            btnRegisterReport.TabIndex = 0;
            btnRegisterReport.Text = "Зареєструвати новий звіт";
            btnRegisterReport.UseVisualStyleBackColor = true;
            btnRegisterReport.Click += btnRegisterReport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(5);
            label1.Size = new System.Drawing.Size(794, 30);
            label1.TabIndex = 1;
            label1.Text = "Зареєстровані в базі даних звіти";
            // 
            // lvReports
            // 
            lvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            lvReports.FullRowSelect = true;
            lvReports.GridLines = true;
            lvReports.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvReports.HideSelection = false;
            lvReports.Location = new System.Drawing.Point(3, 98);
            lvReports.MultiSelect = false;
            lvReports.Name = "lvReports";
            lvReports.Size = new System.Drawing.Size(794, 309);
            lvReports.TabIndex = 2;
            lvReports.UseCompatibleStateImageBehavior = false;
            lvReports.View = System.Windows.Forms.View.Details;
            lvReports.SelectedIndexChanged += lvReports_SelectedIndexChanged;
            lvReports.DoubleClick += lvReports_DoubleClick;
            // 
            // panelFilterArchived
            // 
            panelFilterArchived.Controls.Add(radioFilterActive);
            panelFilterArchived.Controls.Add(radioFilterArchived);
            panelFilterArchived.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFilterArchived.Location = new System.Drawing.Point(3, 33);
            panelFilterArchived.Name = "panelFilterArchived";
            panelFilterArchived.Size = new System.Drawing.Size(794, 24);
            panelFilterArchived.TabIndex = 3;
            // 
            // radioFilterActive
            // 
            radioFilterActive.AutoSize = true;
            radioFilterActive.Location = new System.Drawing.Point(3, 3);
            radioFilterActive.Name = "radioFilterActive";
            radioFilterActive.Size = new System.Drawing.Size(67, 19);
            radioFilterActive.TabIndex = 0;
            radioFilterActive.TabStop = true;
            radioFilterActive.Text = "Активні";
            radioFilterActive.UseVisualStyleBackColor = true;
            // 
            // radioFilterArchived
            // 
            radioFilterArchived.AutoSize = true;
            radioFilterArchived.Location = new System.Drawing.Point(76, 3);
            radioFilterArchived.Name = "radioFilterArchived";
            radioFilterArchived.Size = new System.Drawing.Size(65, 19);
            radioFilterArchived.TabIndex = 0;
            radioFilterArchived.TabStop = true;
            radioFilterArchived.Text = "В архіві";
            radioFilterArchived.UseVisualStyleBackColor = true;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(label2);
            panelFilter.Controls.Add(cbFilterRadioStation);
            panelFilter.Controls.Add(label3);
            panelFilter.Controls.Add(cbFilterStartYear);
            panelFilter.Controls.Add(filterStartMonth);
            panelFilter.Controls.Add(label4);
            panelFilter.Controls.Add(cbFilterEndYEar);
            panelFilter.Controls.Add(cbFilterEndMonth);
            panelFilter.Controls.Add(btnFilterApply);
            panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFilter.Location = new System.Drawing.Point(3, 63);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new System.Drawing.Size(794, 29);
            panelFilter.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label2.Size = new System.Drawing.Size(92, 21);
            label2.TabIndex = 0;
            label2.Text = "Від радіостанції";
            // 
            // cbFilterRadioStation
            // 
            cbFilterRadioStation.FormattingEnabled = true;
            cbFilterRadioStation.Location = new System.Drawing.Point(101, 3);
            cbFilterRadioStation.Name = "cbFilterRadioStation";
            cbFilterRadioStation.Size = new System.Drawing.Size(121, 23);
            cbFilterRadioStation.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(228, 0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label3.Size = new System.Drawing.Size(75, 21);
            label3.TabIndex = 0;
            label3.Text = "за період від";
            // 
            // cbFilterStartYear
            // 
            cbFilterStartYear.FormattingEnabled = true;
            cbFilterStartYear.Location = new System.Drawing.Point(309, 3);
            cbFilterStartYear.Name = "cbFilterStartYear";
            cbFilterStartYear.Size = new System.Drawing.Size(73, 23);
            cbFilterStartYear.TabIndex = 2;
            // 
            // filterStartMonth
            // 
            filterStartMonth.FormattingEnabled = true;
            filterStartMonth.Location = new System.Drawing.Point(388, 3);
            filterStartMonth.Name = "filterStartMonth";
            filterStartMonth.Size = new System.Drawing.Size(44, 23);
            filterStartMonth.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(438, 0);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label4.Size = new System.Drawing.Size(20, 21);
            label4.TabIndex = 0;
            label4.Text = "до";
            // 
            // cbFilterEndYEar
            // 
            cbFilterEndYEar.FormattingEnabled = true;
            cbFilterEndYEar.Location = new System.Drawing.Point(464, 3);
            cbFilterEndYEar.Name = "cbFilterEndYEar";
            cbFilterEndYEar.Size = new System.Drawing.Size(87, 23);
            cbFilterEndYEar.TabIndex = 2;
            // 
            // cbFilterEndMonth
            // 
            cbFilterEndMonth.FormattingEnabled = true;
            cbFilterEndMonth.Location = new System.Drawing.Point(557, 3);
            cbFilterEndMonth.Name = "cbFilterEndMonth";
            cbFilterEndMonth.Size = new System.Drawing.Size(60, 23);
            cbFilterEndMonth.TabIndex = 1;
            // 
            // btnFilterApply
            // 
            btnFilterApply.Location = new System.Drawing.Point(623, 3);
            btnFilterApply.Name = "btnFilterApply";
            btnFilterApply.Size = new System.Drawing.Size(88, 23);
            btnFilterApply.TabIndex = 3;
            btnFilterApply.Text = "Завтосувати";
            btnFilterApply.UseVisualStyleBackColor = true;
            // 
            // openFileDlg
            // 
            openFileDlg.FileName = "openFileDialog1";
            // 
            // FormMainReports
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panelMain);
            Name = "FormMainReports";
            Text = "Звіти радіо";
            Load += FormMainReports_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelFilterArchived.ResumeLayout(false);
            panelFilterArchived.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button btnRegisterReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.Button btnArhive;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnParams;
        private System.Windows.Forms.FlowLayoutPanel panelFilterArchived;
        private System.Windows.Forms.RadioButton radioFilterActive;
        private System.Windows.Forms.RadioButton radioFilterArchived;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFilterRadioStation;
        private System.Windows.Forms.ComboBox cbFilterStartYear;
        private System.Windows.Forms.ComboBox filterStartMonth;
        private System.Windows.Forms.ComboBox cbFilterEndYEar;
        private System.Windows.Forms.ComboBox cbFilterEndMonth;
        private System.Windows.Forms.Button btnFilterApply;
    }
}