namespace DdexInvoicing
{
    partial class FormMainOld
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainOld));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelPeriodWorkFlowButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbReports = new System.Windows.Forms.ComboBox();
            this.btnAutoRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.panelReportWorkFlowButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labReportingPeriod = new System.Windows.Forms.Label();
            this.btnRegisterReports = new System.Windows.Forms.Button();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.cbReportingPeriods = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.bwAutoRunner = new System.ComponentModel.BackgroundWorker();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelPeriodWorkFlowButtons, 0, 5);
            this.panelMain.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.panelMain.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.panelMain.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.panelMain.Controls.Add(this.label2, 0, 4);
            this.panelMain.Controls.Add(this.label3, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 6;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.panelMain.Size = new System.Drawing.Size(1057, 495);
            this.panelMain.TabIndex = 2;
            // 
            // panelPeriodWorkFlowButtons
            // 
            this.panelPeriodWorkFlowButtons.ColumnCount = 1;
            this.panelPeriodWorkFlowButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1051F));
            this.panelPeriodWorkFlowButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPeriodWorkFlowButtons.Location = new System.Drawing.Point(3, 416);
            this.panelPeriodWorkFlowButtons.Name = "panelPeriodWorkFlowButtons";
            this.panelPeriodWorkFlowButtons.RowCount = 1;
            this.panelPeriodWorkFlowButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPeriodWorkFlowButtons.Size = new System.Drawing.Size(1051, 76);
            this.panelPeriodWorkFlowButtons.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 578F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbReports, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAutoRun, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1051, 27);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Звіт:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbReports
            // 
            this.cbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReports.FormattingEnabled = true;
            this.cbReports.Location = new System.Drawing.Point(51, 3);
            this.cbReports.Name = "cbReports";
            this.cbReports.Size = new System.Drawing.Size(572, 21);
            this.cbReports.TabIndex = 1;
            this.cbReports.SelectedIndexChanged += new System.EventHandler(this.cbReports_SelectedIndexChanged);
            // 
            // btnAutoRun
            // 
            this.btnAutoRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutoRun.Location = new System.Drawing.Point(629, 3);
            this.btnAutoRun.Name = "btnAutoRun";
            this.btnAutoRun.Size = new System.Drawing.Size(243, 21);
            this.btnAutoRun.TabIndex = 2;
            this.btnAutoRun.Text = "Виконати дії в автоматичному режимі";
            this.btnAutoRun.UseVisualStyleBackColor = true;
            this.btnAutoRun.Click += new System.EventHandler(this.btnAutoRun_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tbLog, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelReportWorkFlowButtons, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1051, 330);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 3);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(753, 324);
            this.tbLog.TabIndex = 1;
            // 
            // panelReportWorkFlowButtons
            // 
            this.panelReportWorkFlowButtons.ColumnCount = 1;
            this.panelReportWorkFlowButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelReportWorkFlowButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorkFlowButtons.Location = new System.Drawing.Point(762, 3);
            this.panelReportWorkFlowButtons.Name = "panelReportWorkFlowButtons";
            this.panelReportWorkFlowButtons.RowCount = 1;
            this.panelReportWorkFlowButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelReportWorkFlowButtons.Size = new System.Drawing.Size(286, 324);
            this.panelReportWorkFlowButtons.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 313F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tableLayoutPanel3.Controls.Add(this.labReportingPeriod, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnRegisterReports, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbReportingPeriods, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1051, 30);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // labReportingPeriod
            // 
            this.labReportingPeriod.AutoSize = true;
            this.labReportingPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labReportingPeriod.Location = new System.Drawing.Point(3, 0);
            this.labReportingPeriod.Name = "labReportingPeriod";
            this.labReportingPeriod.Size = new System.Drawing.Size(86, 30);
            this.labReportingPeriod.TabIndex = 0;
            this.labReportingPeriod.Text = "Звітний період:";
            this.labReportingPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRegisterReports
            // 
            this.btnRegisterReports.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRegisterReports.ImageList = this.ilMain;
            this.btnRegisterReports.Location = new System.Drawing.Point(408, 3);
            this.btnRegisterReports.Name = "btnRegisterReports";
            this.btnRegisterReports.Size = new System.Drawing.Size(134, 24);
            this.btnRegisterReports.TabIndex = 6;
            this.btnRegisterReports.Text = "Зарейеструвати звіти";
            this.btnRegisterReports.UseVisualStyleBackColor = true;
            this.btnRegisterReports.Click += new System.EventHandler(this.btnRegisterReports_Click);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "iconfinder_OK_132710.png");
            this.ilMain.Images.SetKeyName(1, "iconfinder_Forward_132664.png");
            this.ilMain.Images.SetKeyName(2, "iconfinder_Error_132716.png");
            this.ilMain.Images.SetKeyName(3, "iconfinder_History_132755.png");
            // 
            // cbReportingPeriods
            // 
            this.cbReportingPeriods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbReportingPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReportingPeriods.FormattingEnabled = true;
            this.cbReportingPeriods.Location = new System.Drawing.Point(95, 3);
            this.cbReportingPeriods.Name = "cbReportingPeriods";
            this.cbReportingPeriods.Size = new System.Drawing.Size(307, 21);
            this.cbReportingPeriods.TabIndex = 1;
            this.cbReportingPeriods.SelectedIndexChanged += new System.EventHandler(this.cbReportingPeriods_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1051, 4);
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1051, 4);
            this.label3.TabIndex = 13;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // bwAutoRunner
            // 
            this.bwAutoRunner.WorkerReportsProgress = true;
            this.bwAutoRunner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwAutoRunner_DoWork);
            this.bwAutoRunner.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwAutoRunner_ProgressChanged);
            this.bwAutoRunner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwAutoRunner_RunWorkerCompleted);
            // 
            // FormMainOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 495);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainOld";
            this.Text = "Обробка звітів від клієнтів";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TextBox tbLog;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbReports;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel panelReportWorkFlowButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labReportingPeriod;
        private System.Windows.Forms.ComboBox cbReportingPeriods;
        private System.Windows.Forms.TableLayoutPanel panelPeriodWorkFlowButtons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegisterReports;
        private System.Windows.Forms.Button btnAutoRun;
        private System.ComponentModel.BackgroundWorker bwAutoRunner;
    }
}

