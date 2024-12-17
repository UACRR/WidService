namespace DdexInvoicing
{
    partial class UcRoyaltyDistribution
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
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFilterTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelReportsSplit = new System.Windows.Forms.SplitContainer();
            this.panelReports = new System.Windows.Forms.TableLayoutPanel();
            this.lvReports = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelReportDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelDistributionParameters = new System.Windows.Forms.TableLayoutPanel();
            this.btnDestribute = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbExchangeRateOld = new System.Windows.Forms.TextBox();
            this.tbExchangeRateNew = new System.Windows.Forms.TextBox();
            this.tbPaidIdOld = new System.Windows.Forms.TextBox();
            this.tbPaidIdNew = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbGoalInvoiceOld = new System.Windows.Forms.TextBox();
            this.tbDateInvoiceOld = new System.Windows.Forms.TextBox();
            this.tbGoalInvoiceNew = new System.Windows.Forms.TextBox();
            this.tbDateInvoiceNew = new System.Windows.Forms.TextBox();
            this.tbAmountReceivedTotalOld = new System.Windows.Forms.TextBox();
            this.tbAmountReceivedPeriodOld = new System.Windows.Forms.TextBox();
            this.tbAmountReceivedPeriodNew = new System.Windows.Forms.TextBox();
            this.tbAmountReceivedTotalNew = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbRegIdOld = new System.Windows.Forms.TextBox();
            this.tbPeriodIdOld = new System.Windows.Forms.TextBox();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.cbFilterStatus = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbFilterService = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbFilterYear = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbFilterQuarter = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelMain.SuspendLayout();
            this.panelFilterTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelReportsSplit)).BeginInit();
            this.panelReportsSplit.Panel1.SuspendLayout();
            this.panelReportsSplit.Panel2.SuspendLayout();
            this.panelReportsSplit.SuspendLayout();
            this.panelReports.SuspendLayout();
            this.panelReportDetails.SuspendLayout();
            this.panelDistributionParameters.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.label1, 0, 0);
            this.panelMain.Controls.Add(this.panelFilterTitle, 0, 1);
            this.panelMain.Controls.Add(this.panelReportsSplit, 0, 3);
            this.panelMain.Controls.Add(this.panelFilter, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Size = new System.Drawing.Size(1131, 603);
            this.panelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Автоматичний розподіл і оплата звітів";
            // 
            // panelFilterTitle
            // 
            this.panelFilterTitle.Controls.Add(this.label2);
            this.panelFilterTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilterTitle.Location = new System.Drawing.Point(3, 23);
            this.panelFilterTitle.Name = "panelFilterTitle";
            this.panelFilterTitle.Size = new System.Drawing.Size(1125, 28);
            this.panelFilterTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Вибір звітів";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelReportsSplit
            // 
            this.panelReportsSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportsSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelReportsSplit.Location = new System.Drawing.Point(3, 91);
            this.panelReportsSplit.Name = "panelReportsSplit";
            // 
            // panelReportsSplit.Panel1
            // 
            this.panelReportsSplit.Panel1.Controls.Add(this.panelReports);
            // 
            // panelReportsSplit.Panel2
            // 
            this.panelReportsSplit.Panel2.Controls.Add(this.panelReportDetails);
            this.panelReportsSplit.Size = new System.Drawing.Size(1125, 509);
            this.panelReportsSplit.SplitterDistance = 443;
            this.panelReportsSplit.TabIndex = 2;
            // 
            // panelReports
            // 
            this.panelReports.ColumnCount = 1;
            this.panelReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReports.Controls.Add(this.lvReports, 0, 1);
            this.panelReports.Controls.Add(this.label3, 0, 0);
            this.panelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReports.Location = new System.Drawing.Point(0, 0);
            this.panelReports.Name = "panelReports";
            this.panelReports.RowCount = 3;
            this.panelReports.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReports.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReports.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReports.Size = new System.Drawing.Size(443, 509);
            this.panelReports.TabIndex = 0;
            // 
            // lvReports
            // 
            this.lvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReports.HideSelection = false;
            this.lvReports.Location = new System.Drawing.Point(3, 23);
            this.lvReports.Name = "lvReports";
            this.lvReports.Size = new System.Drawing.Size(437, 475);
            this.lvReports.TabIndex = 0;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            this.lvReports.SelectedIndexChanged += new System.EventHandler(this.lvReports_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(437, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Звіти";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelReportDetails
            // 
            this.panelReportDetails.ColumnCount = 1;
            this.panelReportDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportDetails.Controls.Add(this.label4, 0, 0);
            this.panelReportDetails.Controls.Add(this.panelDistributionParameters, 0, 1);
            this.panelReportDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportDetails.Location = new System.Drawing.Point(0, 0);
            this.panelReportDetails.Name = "panelReportDetails";
            this.panelReportDetails.RowCount = 4;
            this.panelReportDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 286F));
            this.panelReportDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReportDetails.Size = new System.Drawing.Size(678, 509);
            this.panelReportDetails.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(672, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Параметри розподілу і оплати";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDistributionParameters
            // 
            this.panelDistributionParameters.ColumnCount = 4;
            this.panelDistributionParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.panelDistributionParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.panelDistributionParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.panelDistributionParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDistributionParameters.Controls.Add(this.btnDestribute, 2, 9);
            this.panelDistributionParameters.Controls.Add(this.label5, 0, 0);
            this.panelDistributionParameters.Controls.Add(this.label6, 1, 0);
            this.panelDistributionParameters.Controls.Add(this.label7, 2, 0);
            this.panelDistributionParameters.Controls.Add(this.tbExchangeRateOld, 1, 3);
            this.panelDistributionParameters.Controls.Add(this.tbExchangeRateNew, 2, 3);
            this.panelDistributionParameters.Controls.Add(this.tbPaidIdOld, 1, 4);
            this.panelDistributionParameters.Controls.Add(this.tbPaidIdNew, 2, 4);
            this.panelDistributionParameters.Controls.Add(this.label8, 0, 3);
            this.panelDistributionParameters.Controls.Add(this.label9, 0, 4);
            this.panelDistributionParameters.Controls.Add(this.label10, 0, 5);
            this.panelDistributionParameters.Controls.Add(this.label11, 0, 6);
            this.panelDistributionParameters.Controls.Add(this.label12, 0, 7);
            this.panelDistributionParameters.Controls.Add(this.label13, 0, 8);
            this.panelDistributionParameters.Controls.Add(this.tbGoalInvoiceOld, 1, 5);
            this.panelDistributionParameters.Controls.Add(this.tbDateInvoiceOld, 1, 6);
            this.panelDistributionParameters.Controls.Add(this.tbGoalInvoiceNew, 2, 5);
            this.panelDistributionParameters.Controls.Add(this.tbDateInvoiceNew, 2, 6);
            this.panelDistributionParameters.Controls.Add(this.tbAmountReceivedTotalOld, 1, 7);
            this.panelDistributionParameters.Controls.Add(this.tbAmountReceivedPeriodOld, 1, 8);
            this.panelDistributionParameters.Controls.Add(this.tbAmountReceivedPeriodNew, 2, 8);
            this.panelDistributionParameters.Controls.Add(this.tbAmountReceivedTotalNew, 2, 7);
            this.panelDistributionParameters.Controls.Add(this.label14, 0, 1);
            this.panelDistributionParameters.Controls.Add(this.label15, 0, 2);
            this.panelDistributionParameters.Controls.Add(this.tbRegIdOld, 1, 1);
            this.panelDistributionParameters.Controls.Add(this.tbPeriodIdOld, 1, 2);
            this.panelDistributionParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistributionParameters.Location = new System.Drawing.Point(3, 23);
            this.panelDistributionParameters.Name = "panelDistributionParameters";
            this.panelDistributionParameters.RowCount = 11;
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelDistributionParameters.Size = new System.Drawing.Size(672, 280);
            this.panelDistributionParameters.TabIndex = 3;
            // 
            // btnDestribute
            // 
            this.btnDestribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDestribute.Location = new System.Drawing.Point(363, 249);
            this.btnDestribute.Name = "btnDestribute";
            this.btnDestribute.Size = new System.Drawing.Size(194, 22);
            this.btnDestribute.TabIndex = 1;
            this.btnDestribute.Text = "Виконати розподіл і оплату";
            this.btnDestribute.UseVisualStyleBackColor = true;
            this.btnDestribute.Click += new System.EventHandler(this.btnDestribute_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Параметр";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(163, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Поточне значення";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(363, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "Нове значення";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbExchangeRateOld
            // 
            this.tbExchangeRateOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbExchangeRateOld.Location = new System.Drawing.Point(163, 81);
            this.tbExchangeRateOld.Name = "tbExchangeRateOld";
            this.tbExchangeRateOld.ReadOnly = true;
            this.tbExchangeRateOld.Size = new System.Drawing.Size(194, 20);
            this.tbExchangeRateOld.TabIndex = 2;
            // 
            // tbExchangeRateNew
            // 
            this.tbExchangeRateNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbExchangeRateNew.Location = new System.Drawing.Point(363, 81);
            this.tbExchangeRateNew.Name = "tbExchangeRateNew";
            this.tbExchangeRateNew.Size = new System.Drawing.Size(194, 20);
            this.tbExchangeRateNew.TabIndex = 2;
            // 
            // tbPaidIdOld
            // 
            this.tbPaidIdOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPaidIdOld.Location = new System.Drawing.Point(163, 109);
            this.tbPaidIdOld.Name = "tbPaidIdOld";
            this.tbPaidIdOld.ReadOnly = true;
            this.tbPaidIdOld.Size = new System.Drawing.Size(194, 20);
            this.tbPaidIdOld.TabIndex = 2;
            // 
            // tbPaidIdNew
            // 
            this.tbPaidIdNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPaidIdNew.Location = new System.Drawing.Point(363, 109);
            this.tbPaidIdNew.Name = "tbPaidIdNew";
            this.tbPaidIdNew.Size = new System.Drawing.Size(194, 20);
            this.tbPaidIdNew.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "Курс обміну";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "Код платежу";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 28);
            this.label10.TabIndex = 0;
            this.label10.Text = "Призначення платежу";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 28);
            this.label11.TabIndex = 0;
            this.label11.Text = "Дата платежу";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 28);
            this.label12.TabIndex = 0;
            this.label12.Text = "Сума платежу";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 28);
            this.label13.TabIndex = 0;
            this.label13.Text = "Сума в платежі за звіті";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbGoalInvoiceOld
            // 
            this.tbGoalInvoiceOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGoalInvoiceOld.Location = new System.Drawing.Point(163, 137);
            this.tbGoalInvoiceOld.Name = "tbGoalInvoiceOld";
            this.tbGoalInvoiceOld.ReadOnly = true;
            this.tbGoalInvoiceOld.Size = new System.Drawing.Size(194, 20);
            this.tbGoalInvoiceOld.TabIndex = 2;
            // 
            // tbDateInvoiceOld
            // 
            this.tbDateInvoiceOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDateInvoiceOld.Location = new System.Drawing.Point(163, 165);
            this.tbDateInvoiceOld.Name = "tbDateInvoiceOld";
            this.tbDateInvoiceOld.ReadOnly = true;
            this.tbDateInvoiceOld.Size = new System.Drawing.Size(194, 20);
            this.tbDateInvoiceOld.TabIndex = 2;
            // 
            // tbGoalInvoiceNew
            // 
            this.tbGoalInvoiceNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGoalInvoiceNew.Location = new System.Drawing.Point(363, 137);
            this.tbGoalInvoiceNew.Name = "tbGoalInvoiceNew";
            this.tbGoalInvoiceNew.Size = new System.Drawing.Size(194, 20);
            this.tbGoalInvoiceNew.TabIndex = 2;
            // 
            // tbDateInvoiceNew
            // 
            this.tbDateInvoiceNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDateInvoiceNew.Location = new System.Drawing.Point(363, 165);
            this.tbDateInvoiceNew.Name = "tbDateInvoiceNew";
            this.tbDateInvoiceNew.Size = new System.Drawing.Size(194, 20);
            this.tbDateInvoiceNew.TabIndex = 2;
            // 
            // tbAmountReceivedTotalOld
            // 
            this.tbAmountReceivedTotalOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAmountReceivedTotalOld.Location = new System.Drawing.Point(163, 193);
            this.tbAmountReceivedTotalOld.Name = "tbAmountReceivedTotalOld";
            this.tbAmountReceivedTotalOld.ReadOnly = true;
            this.tbAmountReceivedTotalOld.Size = new System.Drawing.Size(194, 20);
            this.tbAmountReceivedTotalOld.TabIndex = 2;
            // 
            // tbAmountReceivedPeriodOld
            // 
            this.tbAmountReceivedPeriodOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAmountReceivedPeriodOld.Location = new System.Drawing.Point(163, 221);
            this.tbAmountReceivedPeriodOld.Name = "tbAmountReceivedPeriodOld";
            this.tbAmountReceivedPeriodOld.ReadOnly = true;
            this.tbAmountReceivedPeriodOld.Size = new System.Drawing.Size(194, 20);
            this.tbAmountReceivedPeriodOld.TabIndex = 2;
            // 
            // tbAmountReceivedPeriodNew
            // 
            this.tbAmountReceivedPeriodNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAmountReceivedPeriodNew.Location = new System.Drawing.Point(363, 221);
            this.tbAmountReceivedPeriodNew.Name = "tbAmountReceivedPeriodNew";
            this.tbAmountReceivedPeriodNew.Size = new System.Drawing.Size(194, 20);
            this.tbAmountReceivedPeriodNew.TabIndex = 2;
            // 
            // tbAmountReceivedTotalNew
            // 
            this.tbAmountReceivedTotalNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAmountReceivedTotalNew.Location = new System.Drawing.Point(363, 193);
            this.tbAmountReceivedTotalNew.Name = "tbAmountReceivedTotalNew";
            this.tbAmountReceivedTotalNew.Size = new System.Drawing.Size(194, 20);
            this.tbAmountReceivedTotalNew.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 28);
            this.label14.TabIndex = 3;
            this.label14.Text = "Код звіту в СМАРТ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 28);
            this.label15.TabIndex = 3;
            this.label15.Text = "Код періоду звіту в СМАРТ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbRegIdOld
            // 
            this.tbRegIdOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRegIdOld.Location = new System.Drawing.Point(163, 25);
            this.tbRegIdOld.Name = "tbRegIdOld";
            this.tbRegIdOld.ReadOnly = true;
            this.tbRegIdOld.Size = new System.Drawing.Size(194, 20);
            this.tbRegIdOld.TabIndex = 4;
            // 
            // tbPeriodIdOld
            // 
            this.tbPeriodIdOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPeriodIdOld.Location = new System.Drawing.Point(163, 53);
            this.tbPeriodIdOld.Name = "tbPeriodIdOld";
            this.tbPeriodIdOld.ReadOnly = true;
            this.tbPeriodIdOld.Size = new System.Drawing.Size(194, 20);
            this.tbPeriodIdOld.TabIndex = 4;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label17);
            this.panelFilter.Controls.Add(this.cbFilterStatus);
            this.panelFilter.Controls.Add(this.label18);
            this.panelFilter.Controls.Add(this.cbFilterService);
            this.panelFilter.Controls.Add(this.label19);
            this.panelFilter.Controls.Add(this.cbFilterYear);
            this.panelFilter.Controls.Add(this.label20);
            this.panelFilter.Controls.Add(this.cbFilterQuarter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 57);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1125, 28);
            this.panelFilter.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label17.Size = new System.Drawing.Size(83, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Стан розподілу";
            // 
            // cbFilterStatus
            // 
            this.cbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterStatus.FormattingEnabled = true;
            this.cbFilterStatus.Location = new System.Drawing.Point(92, 3);
            this.cbFilterStatus.Name = "cbFilterStatus";
            this.cbFilterStatus.Size = new System.Drawing.Size(121, 21);
            this.cbFilterStatus.TabIndex = 1;
            this.cbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(219, 0);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label18.Size = new System.Drawing.Size(40, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Сервіс";
            // 
            // cbFilterService
            // 
            this.cbFilterService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterService.FormattingEnabled = true;
            this.cbFilterService.Location = new System.Drawing.Point(265, 3);
            this.cbFilterService.Name = "cbFilterService";
            this.cbFilterService.Size = new System.Drawing.Size(121, 21);
            this.cbFilterService.TabIndex = 2;
            this.cbFilterService.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(392, 0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label19.Size = new System.Drawing.Size(22, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "Рік";
            // 
            // cbFilterYear
            // 
            this.cbFilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterYear.FormattingEnabled = true;
            this.cbFilterYear.Location = new System.Drawing.Point(420, 3);
            this.cbFilterYear.Name = "cbFilterYear";
            this.cbFilterYear.Size = new System.Drawing.Size(121, 21);
            this.cbFilterYear.TabIndex = 2;
            this.cbFilterYear.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(547, 0);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label20.Size = new System.Drawing.Size(49, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "Квартал";
            // 
            // cbFilterQuarter
            // 
            this.cbFilterQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterQuarter.FormattingEnabled = true;
            this.cbFilterQuarter.Location = new System.Drawing.Point(602, 3);
            this.cbFilterQuarter.Name = "cbFilterQuarter";
            this.cbFilterQuarter.Size = new System.Drawing.Size(121, 21);
            this.cbFilterQuarter.TabIndex = 2;
            this.cbFilterQuarter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // UcRoyaltyDistribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcRoyaltyDistribution";
            this.Size = new System.Drawing.Size(1131, 603);
            this.Load += new System.EventHandler(this.UcRoyaltyDistribution_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelFilterTitle.ResumeLayout(false);
            this.panelFilterTitle.PerformLayout();
            this.panelReportsSplit.Panel1.ResumeLayout(false);
            this.panelReportsSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelReportsSplit)).EndInit();
            this.panelReportsSplit.ResumeLayout(false);
            this.panelReports.ResumeLayout(false);
            this.panelReports.PerformLayout();
            this.panelReportDetails.ResumeLayout(false);
            this.panelReportDetails.PerformLayout();
            this.panelDistributionParameters.ResumeLayout(false);
            this.panelDistributionParameters.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panelFilterTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer panelReportsSplit;
        private System.Windows.Forms.TableLayoutPanel panelReports;
        private System.Windows.Forms.TableLayoutPanel panelReportDetails;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.Button btnDestribute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel panelDistributionParameters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbExchangeRateOld;
        private System.Windows.Forms.TextBox tbExchangeRateNew;
        private System.Windows.Forms.TextBox tbPaidIdOld;
        private System.Windows.Forms.TextBox tbPaidIdNew;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbGoalInvoiceOld;
        private System.Windows.Forms.TextBox tbDateInvoiceOld;
        private System.Windows.Forms.TextBox tbGoalInvoiceNew;
        private System.Windows.Forms.TextBox tbDateInvoiceNew;
        private System.Windows.Forms.TextBox tbAmountReceivedTotalOld;
        private System.Windows.Forms.TextBox tbAmountReceivedPeriodOld;
        private System.Windows.Forms.TextBox tbAmountReceivedPeriodNew;
        private System.Windows.Forms.TextBox tbAmountReceivedTotalNew;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbRegIdOld;
        private System.Windows.Forms.TextBox tbPeriodIdOld;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbFilterStatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbFilterService;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbFilterYear;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbFilterQuarter;
    }
}
