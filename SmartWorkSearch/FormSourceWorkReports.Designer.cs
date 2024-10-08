
namespace SmartWorkSearch
{
    partial class FormSourceWorkReports
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
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.wbReportRecords = new System.Windows.Forms.WebBrowser();
            this.panelSourceWork = new System.Windows.Forms.TableLayoutPanel();
            this.labSourceName = new System.Windows.Forms.Label();
            this.labSourceAuthors = new System.Windows.Forms.Label();
            this.labSourcePerformers = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAuthors = new System.Windows.Forms.TextBox();
            this.tbPerformers = new System.Windows.Forms.TextBox();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panelSourceWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.wbReportRecords, 0, 2);
            this.panelMain.Controls.Add(this.panelSourceWork, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 5;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // wbReportRecords
            // 
            this.wbReportRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbReportRecords.Location = new System.Drawing.Point(3, 95);
            this.wbReportRecords.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbReportRecords.Name = "wbReportRecords";
            this.wbReportRecords.Size = new System.Drawing.Size(794, 312);
            this.wbReportRecords.TabIndex = 0;
            // 
            // panelSourceWork
            // 
            this.panelSourceWork.ColumnCount = 3;
            this.panelSourceWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.panelSourceWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSourceWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelSourceWork.Controls.Add(this.labSourceName, 0, 0);
            this.panelSourceWork.Controls.Add(this.labSourceAuthors, 0, 1);
            this.panelSourceWork.Controls.Add(this.labSourcePerformers, 0, 2);
            this.panelSourceWork.Controls.Add(this.tbName, 1, 0);
            this.panelSourceWork.Controls.Add(this.tbAuthors, 1, 1);
            this.panelSourceWork.Controls.Add(this.tbPerformers, 1, 2);
            this.panelSourceWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSourceWork.Location = new System.Drawing.Point(3, 14);
            this.panelSourceWork.Name = "panelSourceWork";
            this.panelSourceWork.RowCount = 4;
            this.panelSourceWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panelSourceWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.panelSourceWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelSourceWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSourceWork.Size = new System.Drawing.Size(794, 75);
            this.panelSourceWork.TabIndex = 1;
            // 
            // labSourceName
            // 
            this.labSourceName.AutoSize = true;
            this.labSourceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSourceName.Location = new System.Drawing.Point(3, 0);
            this.labSourceName.Name = "labSourceName";
            this.labSourceName.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.labSourceName.Size = new System.Drawing.Size(72, 24);
            this.labSourceName.TabIndex = 0;
            this.labSourceName.Text = "Назва";
            // 
            // labSourceAuthors
            // 
            this.labSourceAuthors.AutoSize = true;
            this.labSourceAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSourceAuthors.Location = new System.Drawing.Point(3, 24);
            this.labSourceAuthors.Name = "labSourceAuthors";
            this.labSourceAuthors.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.labSourceAuthors.Size = new System.Drawing.Size(72, 22);
            this.labSourceAuthors.TabIndex = 0;
            this.labSourceAuthors.Text = "Автори";
            // 
            // labSourcePerformers
            // 
            this.labSourcePerformers.AutoSize = true;
            this.labSourcePerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSourcePerformers.Location = new System.Drawing.Point(3, 46);
            this.labSourcePerformers.Name = "labSourcePerformers";
            this.labSourcePerformers.Padding = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.labSourcePerformers.Size = new System.Drawing.Size(72, 25);
            this.labSourcePerformers.TabIndex = 0;
            this.labSourcePerformers.Text = "Виконавці";
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(81, 3);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(702, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbAuthors
            // 
            this.tbAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAuthors.Location = new System.Drawing.Point(81, 27);
            this.tbAuthors.Name = "tbAuthors";
            this.tbAuthors.ReadOnly = true;
            this.tbAuthors.Size = new System.Drawing.Size(702, 20);
            this.tbAuthors.TabIndex = 1;
            // 
            // tbPerformers
            // 
            this.tbPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPerformers.Location = new System.Drawing.Point(81, 49);
            this.tbPerformers.Name = "tbPerformers";
            this.tbPerformers.ReadOnly = true;
            this.tbPerformers.Size = new System.Drawing.Size(702, 20);
            this.tbPerformers.TabIndex = 1;
            // 
            // timerLoad
            // 
            this.timerLoad.Enabled = true;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // FormSourceWorkReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormSourceWorkReports";
            this.Text = "FormSourceWorkReports";
            this.Load += new System.EventHandler(this.FormSourceWorkReports_Load);
            this.panelMain.ResumeLayout(false);
            this.panelSourceWork.ResumeLayout(false);
            this.panelSourceWork.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.WebBrowser wbReportRecords;
        private System.Windows.Forms.TableLayoutPanel panelSourceWork;
        private System.Windows.Forms.Label labSourceName;
        private System.Windows.Forms.Label labSourceAuthors;
        private System.Windows.Forms.Label labSourcePerformers;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAuthors;
        private System.Windows.Forms.TextBox tbPerformers;
        private System.Windows.Forms.Timer timerLoad;
    }
}