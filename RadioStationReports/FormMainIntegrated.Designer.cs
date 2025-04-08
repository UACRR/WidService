using System.Drawing;
using System.Windows.Forms;

namespace RadioStationReports
{
    partial class FormMainIntegrated
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
            panelMain = new TableLayoutPanel();
            panelCustomer = new TableLayoutPanel();
            label1 = new Label();
            btnSearchCustomer = new Button();
            cbCustomers = new ComboBox();
            panelReportsTitle = new TableLayoutPanel();
            label2 = new Label();
            lvReports = new ListView();
            panelReportActions = new TableLayoutPanel();
            btnShowReport = new Button();
            label3 = new Label();
            lvReportLines = new ListView();
            panelFormActions = new TableLayoutPanel();
            btnClose = new Button();
            panelMain.SuspendLayout();
            panelCustomer.SuspendLayout();
            panelReportsTitle.SuspendLayout();
            panelReportActions.SuspendLayout();
            panelFormActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            panelMain.Controls.Add(panelCustomer, 0, 0);
            panelMain.Controls.Add(panelReportsTitle, 0, 1);
            panelMain.Controls.Add(lvReports, 0, 2);
            panelMain.Controls.Add(panelReportActions, 0, 3);
            panelMain.Controls.Add(label3, 0, 4);
            panelMain.Controls.Add(lvReportLines, 0, 5);
            panelMain.Controls.Add(panelFormActions, 0, 6);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 8;
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            panelMain.Size = new Size(752, 481);
            panelMain.TabIndex = 0;
            // 
            // panelCustomer
            // 
            panelCustomer.ColumnCount = 4;
            panelCustomer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
            panelCustomer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelCustomer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            panelCustomer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            panelCustomer.Controls.Add(label1, 0, 0);
            panelCustomer.Controls.Add(btnSearchCustomer, 2, 0);
            panelCustomer.Controls.Add(cbCustomers, 1, 0);
            panelCustomer.Dock = DockStyle.Fill;
            panelCustomer.Location = new Point(3, 3);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.RowCount = 1;
            panelCustomer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelCustomer.Size = new Size(741, 30);
            panelCustomer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Margin = new Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Користувач:";
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Dock = DockStyle.Fill;
            btnSearchCustomer.Location = new Point(631, 3);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(102, 24);
            btnSearchCustomer.TabIndex = 2;
            btnSearchCustomer.Text = "Вибрати ...";
            btnSearchCustomer.UseVisualStyleBackColor = true;
            btnSearchCustomer.Click += btnSearchCustomer_Click;
            // 
            // cbCustomers
            // 
            cbCustomers.Dock = DockStyle.Fill;
            cbCustomers.FormattingEnabled = true;
            cbCustomers.Location = new Point(84, 3);
            cbCustomers.Name = "cbCustomers";
            cbCustomers.Size = new Size(541, 23);
            cbCustomers.TabIndex = 3;
            cbCustomers.SelectedIndexChanged += cbCustomers_SelectedIndexChanged;
            // 
            // panelReportsTitle
            // 
            panelReportsTitle.BackColor = SystemColors.GradientInactiveCaption;
            panelReportsTitle.ColumnCount = 5;
            panelReportsTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 172F));
            panelReportsTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 99F));
            panelReportsTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
            panelReportsTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelReportsTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            panelReportsTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panelReportsTitle.Controls.Add(label2, 0, 0);
            panelReportsTitle.Dock = DockStyle.Fill;
            panelReportsTitle.Location = new Point(3, 39);
            panelReportsTitle.Name = "panelReportsTitle";
            panelReportsTitle.RowCount = 1;
            panelReportsTitle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelReportsTitle.Size = new Size(741, 23);
            panelReportsTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 6);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 0;
            label2.Text = "Звіти користувача";
            // 
            // lvReports
            // 
            lvReports.Dock = DockStyle.Fill;
            lvReports.HideSelection = false;
            lvReports.Location = new Point(3, 68);
            lvReports.Name = "lvReports";
            lvReports.Size = new Size(741, 149);
            lvReports.TabIndex = 2;
            lvReports.UseCompatibleStateImageBehavior = false;
            lvReports.SelectedIndexChanged += lvReports_SelectedIndexChanged;
            // 
            // panelReportActions
            // 
            panelReportActions.ColumnCount = 3;
            panelReportActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelReportActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            panelReportActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            panelReportActions.Controls.Add(btnShowReport, 1, 0);
            panelReportActions.Dock = DockStyle.Fill;
            panelReportActions.Location = new Point(3, 223);
            panelReportActions.Name = "panelReportActions";
            panelReportActions.RowCount = 1;
            panelReportActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelReportActions.Size = new Size(741, 31);
            panelReportActions.TabIndex = 3;
            // 
            // btnShowReport
            // 
            btnShowReport.Location = new Point(641, 3);
            btnShowReport.Name = "btnShowReport";
            btnShowReport.Size = new Size(92, 23);
            btnShowReport.TabIndex = 0;
            btnShowReport.Text = "Показати звіт";
            btnShowReport.UseVisualStyleBackColor = true;
            btnShowReport.Click += btnShowReport_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 257);
            label3.Name = "label3";
            label3.Size = new Size(288, 21);
            label3.TabIndex = 4;
            label3.Text = "Рядки звіту (попередній перегляд, перші 100 рядків\r\n)";
            // 
            // lvReportLines
            // 
            lvReportLines.Dock = DockStyle.Fill;
            lvReportLines.HideSelection = false;
            lvReportLines.Location = new Point(3, 281);
            lvReportLines.Name = "lvReportLines";
            lvReportLines.Size = new Size(741, 149);
            lvReportLines.TabIndex = 5;
            lvReportLines.UseCompatibleStateImageBehavior = false;
            // 
            // panelFormActions
            // 
            panelFormActions.ColumnCount = 3;
            panelFormActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelFormActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
            panelFormActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            panelFormActions.Controls.Add(btnClose, 1, 0);
            panelFormActions.Dock = DockStyle.Fill;
            panelFormActions.Location = new Point(3, 436);
            panelFormActions.Name = "panelFormActions";
            panelFormActions.RowCount = 1;
            panelFormActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelFormActions.Size = new Size(741, 33);
            panelFormActions.TabIndex = 6;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Fill;
            btnClose.Location = new Point(647, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(86, 27);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FormMainIntegrated
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 481);
            Controls.Add(panelMain);
            Name = "FormMainIntegrated";
            Text = "Звіти користувачів";
            Load += FormMainIntegrated_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelCustomer.ResumeLayout(false);
            panelCustomer.PerformLayout();
            panelReportsTitle.ResumeLayout(false);
            panelReportsTitle.PerformLayout();
            panelReportActions.ResumeLayout(false);
            panelFormActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel panelMain;
        private TableLayoutPanel panelCustomer;
        private Label label1;
        private Button btnSearchCustomer;
        private TableLayoutPanel panelReportsTitle;
        private Label label2;
        private ListView lvReports;
        private TableLayoutPanel panelReportActions;
        private Button btnShowReport;
        private Label label3;
        private ListView lvReportLines;
        private TableLayoutPanel panelFormActions;
        private Button btnClose;

        #endregion

        private ComboBox cbCustomers;
    }
}