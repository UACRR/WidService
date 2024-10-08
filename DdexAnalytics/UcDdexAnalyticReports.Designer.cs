
namespace DdexAnalytics
{
    partial class UcDdexAnalyticReports
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
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.labReportList = new System.Windows.Forms.Label();
            this.lvReportList = new System.Windows.Forms.ListView();
            this.panelLeftBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.TableLayoutPanel();
            this.labReport = new System.Windows.Forms.Label();
            this.panelBottomRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCopyReport = new System.Windows.Forms.Button();
            this.panelReport = new System.Windows.Forms.TableLayoutPanel();
            this.lvReport = new System.Windows.Forms.ListView();
            this.panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.panelReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelLeft, 0, 0);
            this.panelMain.Controls.Add(this.panelRight, 1, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 1;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Size = new System.Drawing.Size(1035, 547);
            this.panelMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.ColumnCount = 1;
            this.panelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.Controls.Add(this.labReportList, 0, 0);
            this.panelLeft.Controls.Add(this.lvReportList, 0, 1);
            this.panelLeft.Controls.Add(this.panelLeftBottom, 0, 3);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(4, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RowCount = 5;
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLeft.Size = new System.Drawing.Size(253, 539);
            this.panelLeft.TabIndex = 0;
            // 
            // labReportList
            // 
            this.labReportList.AutoSize = true;
            this.labReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labReportList.Location = new System.Drawing.Point(3, 0);
            this.labReportList.Name = "labReportList";
            this.labReportList.Size = new System.Drawing.Size(247, 23);
            this.labReportList.TabIndex = 0;
            this.labReportList.Text = "Список звітів";
            this.labReportList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvReportList
            // 
            this.lvReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportList.HideSelection = false;
            this.lvReportList.Location = new System.Drawing.Point(3, 26);
            this.lvReportList.Name = "lvReportList";
            this.lvReportList.Size = new System.Drawing.Size(247, 455);
            this.lvReportList.TabIndex = 1;
            this.lvReportList.UseCompatibleStateImageBehavior = false;
            this.lvReportList.SelectedIndexChanged += new System.EventHandler(this.lvReportList_SelectedIndexChanged);
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.Controls.Add(this.btnShowReport);
            this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftBottom.Location = new System.Drawing.Point(3, 499);
            this.panelLeftBottom.Name = "panelLeftBottom";
            this.panelLeftBottom.Size = new System.Drawing.Size(247, 29);
            this.panelLeftBottom.TabIndex = 2;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(3, 3);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(141, 23);
            this.btnShowReport.TabIndex = 0;
            this.btnShowReport.Text = "Показати/оновити звіт";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // panelRight
            // 
            this.panelRight.ColumnCount = 1;
            this.panelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRight.Controls.Add(this.labReport, 0, 0);
            this.panelRight.Controls.Add(this.panelBottomRight, 0, 2);
            this.panelRight.Controls.Add(this.panelReport, 0, 1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(264, 4);
            this.panelRight.Name = "panelRight";
            this.panelRight.RowCount = 4;
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelRight.Size = new System.Drawing.Size(767, 539);
            this.panelRight.TabIndex = 1;
            // 
            // labReport
            // 
            this.labReport.AutoSize = true;
            this.labReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labReport.Location = new System.Drawing.Point(3, 0);
            this.labReport.Name = "labReport";
            this.labReport.Size = new System.Drawing.Size(761, 23);
            this.labReport.TabIndex = 1;
            this.labReport.Text = "Звіт";
            this.labReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.btnCopyReport);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(3, 498);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(761, 30);
            this.panelBottomRight.TabIndex = 0;
            // 
            // btnCopyReport
            // 
            this.btnCopyReport.Location = new System.Drawing.Point(3, 3);
            this.btnCopyReport.Name = "btnCopyReport";
            this.btnCopyReport.Size = new System.Drawing.Size(166, 23);
            this.btnCopyReport.TabIndex = 0;
            this.btnCopyReport.Text = "Занести в буфер обміну";
            this.btnCopyReport.UseVisualStyleBackColor = true;
            this.btnCopyReport.Click += new System.EventHandler(this.btnCopyReport_Click);
            // 
            // panelReport
            // 
            this.panelReport.ColumnCount = 1;
            this.panelReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReport.Controls.Add(this.lvReport, 0, 0);
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(3, 26);
            this.panelReport.Name = "panelReport";
            this.panelReport.RowCount = 2;
            this.panelReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReport.Size = new System.Drawing.Size(761, 466);
            this.panelReport.TabIndex = 2;
            // 
            // lvReport
            // 
            this.lvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReport.HideSelection = false;
            this.lvReport.Location = new System.Drawing.Point(3, 3);
            this.lvReport.Name = "lvReport";
            this.lvReport.Size = new System.Drawing.Size(755, 452);
            this.lvReport.TabIndex = 1;
            this.lvReport.UseCompatibleStateImageBehavior = false;
            // 
            // UcDdexAnalyticReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcDdexAnalyticReports";
            this.Size = new System.Drawing.Size(1035, 547);
            this.Load += new System.EventHandler(this.UcDdexAnalyticReports_Load);
            this.panelMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelLeftBottom.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelBottomRight.ResumeLayout(false);
            this.panelReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelLeft;
        private System.Windows.Forms.Label labReportList;
        private System.Windows.Forms.ListView lvReportList;
        private System.Windows.Forms.FlowLayoutPanel panelLeftBottom;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.TableLayoutPanel panelRight;
        private System.Windows.Forms.Label labReport;
        private System.Windows.Forms.FlowLayoutPanel panelBottomRight;
        private System.Windows.Forms.Button btnCopyReport;
        private System.Windows.Forms.TableLayoutPanel panelReport;
        private System.Windows.Forms.ListView lvReport;
    }
}
