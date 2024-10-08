
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.btnRegisterReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvReports = new System.Windows.Forms.ListView();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelBottom, 0, 3);
            this.panelMain.Controls.Add(this.label1, 0, 0);
            this.panelMain.Controls.Add(this.lvReports, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 5;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.btnShowReport);
            this.panelBottom.Controls.Add(this.btnRegisterReport);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(3, 413);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(794, 26);
            this.panelBottom.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(679, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити Форму";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(509, 3);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(164, 23);
            this.btnShowReport.TabIndex = 0;
            this.btnShowReport.Text = "Показати вибраний звіт";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // btnRegisterReport
            // 
            this.btnRegisterReport.Location = new System.Drawing.Point(331, 3);
            this.btnRegisterReport.Name = "btnRegisterReport";
            this.btnRegisterReport.Size = new System.Drawing.Size(172, 23);
            this.btnRegisterReport.TabIndex = 0;
            this.btnRegisterReport.Text = "Зареєструвати новий звіт";
            this.btnRegisterReport.UseVisualStyleBackColor = true;
            this.btnRegisterReport.Click += new System.EventHandler(this.btnRegisterReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(794, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Зареєстровані в базі даних звіти";
            // 
            // lvReports
            // 
            this.lvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReports.FullRowSelect = true;
            this.lvReports.GridLines = true;
            this.lvReports.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReports.HideSelection = false;
            this.lvReports.Location = new System.Drawing.Point(3, 41);
            this.lvReports.MultiSelect = false;
            this.lvReports.Name = "lvReports";
            this.lvReports.Size = new System.Drawing.Size(794, 366);
            this.lvReports.TabIndex = 2;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            this.lvReports.View = System.Windows.Forms.View.Details;
            this.lvReports.SelectedIndexChanged += new System.EventHandler(this.lvReports_SelectedIndexChanged);
            this.lvReports.DoubleClick += new System.EventHandler(this.lvReports_DoubleClick);
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            // 
            // FormMainReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormMainReports";
            this.Text = "Звіти радіо";
            this.Load += new System.EventHandler(this.FormMainReports_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}