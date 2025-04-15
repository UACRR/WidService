namespace RadioStationReports
{
    partial class UcMainIntegrated
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMainIntegrated));
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            panelCustomer = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            btnSearchCustomer = new System.Windows.Forms.Button();
            cbCustomers = new System.Windows.Forms.ComboBox();
            panelReportsTitle = new System.Windows.Forms.TableLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            lvReports = new System.Windows.Forms.ListView();
            panelReportActions = new System.Windows.Forms.TableLayoutPanel();
            btnShowReport = new System.Windows.Forms.Button();
            tabAdditionalInfo = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            lvReportLines = new System.Windows.Forms.ListView();
            tabPage2 = new System.Windows.Forms.TabPage();
            lvOtherCustomers = new System.Windows.Forms.ListView();
            ilReports = new System.Windows.Forms.ImageList(components);
            panelMain.SuspendLayout();
            panelCustomer.SuspendLayout();
            panelReportsTitle.SuspendLayout();
            panelReportActions.SuspendLayout();
            tabAdditionalInfo.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Controls.Add(panelCustomer, 0, 0);
            panelMain.Controls.Add(panelReportsTitle, 0, 1);
            panelMain.Controls.Add(lvReports, 0, 2);
            panelMain.Controls.Add(panelReportActions, 0, 3);
            panelMain.Controls.Add(tabAdditionalInfo, 0, 4);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 6;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Size = new System.Drawing.Size(1063, 487);
            panelMain.TabIndex = 1;
            // 
            // panelCustomer
            // 
            panelCustomer.ColumnCount = 4;
            panelCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            panelCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            panelCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelCustomer.Controls.Add(label1, 0, 0);
            panelCustomer.Controls.Add(btnSearchCustomer, 2, 0);
            panelCustomer.Controls.Add(cbCustomers, 1, 0);
            panelCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCustomer.Location = new System.Drawing.Point(3, 3);
            panelCustomer.Name = "panelCustomer";
            panelCustomer.RowCount = 1;
            panelCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelCustomer.Size = new System.Drawing.Size(1052, 30);
            panelCustomer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Користувач:";
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            btnSearchCustomer.Location = new System.Drawing.Point(942, 3);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new System.Drawing.Size(102, 24);
            btnSearchCustomer.TabIndex = 2;
            btnSearchCustomer.Text = "Вибрати ...";
            btnSearchCustomer.UseVisualStyleBackColor = true;
            btnSearchCustomer.Click += btnSearchCustomer_Click;
            // 
            // cbCustomers
            // 
            cbCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            cbCustomers.FormattingEnabled = true;
            cbCustomers.Location = new System.Drawing.Point(84, 3);
            cbCustomers.Name = "cbCustomers";
            cbCustomers.Size = new System.Drawing.Size(852, 23);
            cbCustomers.TabIndex = 3;
            cbCustomers.SelectedIndexChanged += cbCustomers_SelectedIndexChanged;
            // 
            // panelReportsTitle
            // 
            panelReportsTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panelReportsTitle.ColumnCount = 5;
            panelReportsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            panelReportsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            panelReportsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            panelReportsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelReportsTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelReportsTitle.Controls.Add(label2, 0, 0);
            panelReportsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReportsTitle.Location = new System.Drawing.Point(3, 39);
            panelReportsTitle.Name = "panelReportsTitle";
            panelReportsTitle.RowCount = 1;
            panelReportsTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportsTitle.Size = new System.Drawing.Size(1052, 23);
            panelReportsTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 6);
            label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(160, 15);
            label2.TabIndex = 0;
            label2.Text = "Звіти користувача в СМАРТ";
            // 
            // lvReports
            // 
            lvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            lvReports.HideSelection = false;
            lvReports.Location = new System.Drawing.Point(3, 68);
            lvReports.Name = "lvReports";
            lvReports.Size = new System.Drawing.Size(1052, 108);
            lvReports.TabIndex = 2;
            lvReports.UseCompatibleStateImageBehavior = false;
            lvReports.SelectedIndexChanged += lvReports_SelectedIndexChanged;
            // 
            // panelReportActions
            // 
            panelReportActions.ColumnCount = 3;
            panelReportActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            panelReportActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelReportActions.Controls.Add(btnShowReport, 1, 0);
            panelReportActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReportActions.Location = new System.Drawing.Point(3, 182);
            panelReportActions.Name = "panelReportActions";
            panelReportActions.RowCount = 1;
            panelReportActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelReportActions.Size = new System.Drawing.Size(1052, 31);
            panelReportActions.TabIndex = 3;
            // 
            // btnShowReport
            // 
            btnShowReport.Location = new System.Drawing.Point(902, 3);
            btnShowReport.Name = "btnShowReport";
            btnShowReport.Size = new System.Drawing.Size(142, 23);
            btnShowReport.TabIndex = 0;
            btnShowReport.Text = "Показати звіт";
            btnShowReport.UseVisualStyleBackColor = true;
            btnShowReport.Click += btnShowReport_Click;
            // 
            // tabAdditionalInfo
            // 
            tabAdditionalInfo.Controls.Add(tabPage1);
            tabAdditionalInfo.Controls.Add(tabPage2);
            tabAdditionalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            tabAdditionalInfo.Location = new System.Drawing.Point(3, 219);
            tabAdditionalInfo.Name = "tabAdditionalInfo";
            tabAdditionalInfo.SelectedIndex = 0;
            tabAdditionalInfo.Size = new System.Drawing.Size(1052, 260);
            tabAdditionalInfo.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lvReportLines);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1044, 232);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Рядки звіту (попередній перегляд, перші 100 рядків)";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvReportLines
            // 
            lvReportLines.Dock = System.Windows.Forms.DockStyle.Fill;
            lvReportLines.HideSelection = false;
            lvReportLines.Location = new System.Drawing.Point(3, 3);
            lvReportLines.Name = "lvReportLines";
            lvReportLines.Size = new System.Drawing.Size(1038, 226);
            lvReportLines.TabIndex = 5;
            lvReportLines.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lvOtherCustomers);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(1044, 232);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Інші кортистувачі звіту";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvOtherCustomers
            // 
            lvOtherCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            lvOtherCustomers.HideSelection = false;
            lvOtherCustomers.Location = new System.Drawing.Point(3, 3);
            lvOtherCustomers.Name = "lvOtherCustomers";
            lvOtherCustomers.Size = new System.Drawing.Size(1038, 226);
            lvOtherCustomers.TabIndex = 0;
            lvOtherCustomers.UseCompatibleStateImageBehavior = false;
            // 
            // ilReports
            // 
            ilReports.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilReports.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilReports.ImageStream");
            ilReports.TransparentColor = System.Drawing.Color.Transparent;
            ilReports.Images.SetKeyName(0, "Hopstarter-Sleek-Xp-Basic-Ok.ico");
            ilReports.Images.SetKeyName(1, "iconfinder_Error_132716.png");
            // 
            // UcMainIntegrated
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelMain);
            Name = "UcMainIntegrated";
            Size = new System.Drawing.Size(1063, 487);
            Load += UcMainIntegrated_Load;
            panelMain.ResumeLayout(false);
            panelCustomer.ResumeLayout(false);
            panelCustomer.PerformLayout();
            panelReportsTitle.ResumeLayout(false);
            panelReportsTitle.PerformLayout();
            panelReportActions.ResumeLayout(false);
            tabAdditionalInfo.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelReportsTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.TableLayoutPanel panelReportActions;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.ListView lvReportLines;
        private System.Windows.Forms.TableLayoutPanel panelCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.ImageList ilReports;
        private System.Windows.Forms.TabControl tabAdditionalInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvOtherCustomers;
    }
}
