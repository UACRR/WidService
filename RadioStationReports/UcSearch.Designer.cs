using System.Windows.Forms;

namespace RadioStationReports
{
    partial class UcSearch
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
            panelMain = new TableLayoutPanel();
            panelFilterName = new FlowLayoutPanel();
            labFilterName = new Label();
            tbFilterName = new TextBox();
            btnSearchName = new Button();
            cbSerachUsingLike = new CheckBox();
            wvFoundWorks = new WebBrowser();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            panelFilterSelected = new TableLayoutPanel();
            label3 = new Label();
            rbShowAll = new RadioButton();
            rbShowSelected = new RadioButton();
            panelFilterPerformers = new TableLayoutPanel();
            label2 = new Label();
            tbFilterTextFragment = new TextBox();
            btnSelectByTextFragnemts = new Button();
            panelReportInfo = new TableLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            tbReportWorkName = new TextBox();
            tbReportWorkPerformers = new TextBox();
            timerLoad = new Timer(components);
            panelMain.SuspendLayout();
            panelFilterName.SuspendLayout();
            panelFilterSelected.SuspendLayout();
            panelFilterPerformers.SuspendLayout();
            panelReportInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelMain.Controls.Add(panelFilterName, 0, 3);
            panelMain.Controls.Add(wvFoundWorks, 0, 7);
            panelMain.Controls.Add(label1, 0, 4);
            panelMain.Controls.Add(label4, 0, 2);
            panelMain.Controls.Add(label5, 0, 0);
            panelMain.Controls.Add(panelFilterSelected, 0, 6);
            panelMain.Controls.Add(panelFilterPerformers, 0, 5);
            panelMain.Controls.Add(panelReportInfo, 0, 1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 9;
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            panelMain.Size = new System.Drawing.Size(858, 437);
            panelMain.TabIndex = 0;
            // 
            // panelFilterName
            // 
            panelFilterName.Controls.Add(labFilterName);
            panelFilterName.Controls.Add(tbFilterName);
            panelFilterName.Controls.Add(btnSearchName);
            panelFilterName.Controls.Add(cbSerachUsingLike);
            panelFilterName.Dock = DockStyle.Fill;
            panelFilterName.Location = new System.Drawing.Point(3, 97);
            panelFilterName.Name = "panelFilterName";
            panelFilterName.Size = new System.Drawing.Size(852, 29);
            panelFilterName.TabIndex = 0;
            // 
            // labFilterName
            // 
            labFilterName.AutoSize = true;
            labFilterName.Location = new System.Drawing.Point(3, 6);
            labFilterName.Margin = new Padding(3, 6, 3, 0);
            labFilterName.Name = "labFilterName";
            labFilterName.Size = new System.Drawing.Size(76, 15);
            labFilterName.TabIndex = 0;
            labFilterName.Text = "Назва твору:";
            // 
            // tbFilterName
            // 
            tbFilterName.Location = new System.Drawing.Point(85, 3);
            tbFilterName.Name = "tbFilterName";
            tbFilterName.Size = new System.Drawing.Size(210, 23);
            tbFilterName.TabIndex = 1;
            // 
            // btnSearchName
            // 
            btnSearchName.Location = new System.Drawing.Point(301, 3);
            btnSearchName.Name = "btnSearchName";
            btnSearchName.Size = new System.Drawing.Size(75, 23);
            btnSearchName.TabIndex = 2;
            btnSearchName.Text = "Шукати";
            btnSearchName.UseVisualStyleBackColor = true;
            btnSearchName.Click += btnSearchName_Click;
            // 
            // cbSerachUsingLike
            // 
            cbSerachUsingLike.AutoSize = true;
            cbSerachUsingLike.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            cbSerachUsingLike.Location = new System.Drawing.Point(382, 3);
            cbSerachUsingLike.Name = "cbSerachUsingLike";
            cbSerachUsingLike.Padding = new Padding(0, 3, 0, 0);
            cbSerachUsingLike.Size = new System.Drawing.Size(179, 22);
            cbSerachUsingLike.TabIndex = 3;
            cbSerachUsingLike.Text = "Шукати за подібністю назви";
            cbSerachUsingLike.UseVisualStyleBackColor = true;
            // 
            // wvFoundWorks
            // 
            wvFoundWorks.Dock = DockStyle.Fill;
            wvFoundWorks.Location = new System.Drawing.Point(3, 229);
            wvFoundWorks.Name = "wvFoundWorks";
            wvFoundWorks.Size = new System.Drawing.Size(852, 195);
            wvFoundWorks.TabIndex = 4;
            wvFoundWorks.DocumentCompleted += wvFoundWorks_DocumentCompleted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label1.Dock = DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 135);
            label1.Margin = new Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 3, 0, 0);
            label1.Size = new System.Drawing.Size(852, 23);
            label1.TabIndex = 1;
            label1.Text = "Знайдені твори";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label4.Dock = DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 72);
            label4.Margin = new Padding(3, 6, 3, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 3, 0, 0);
            label4.Size = new System.Drawing.Size(852, 22);
            label4.TabIndex = 1;
            label4.Text = "Пошук творів";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            label5.Dock = DockStyle.Fill;
            label5.Location = new System.Drawing.Point(3, 6);
            label5.Margin = new Padding(3, 6, 3, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(5, 3, 0, 0);
            label5.Size = new System.Drawing.Size(852, 23);
            label5.TabIndex = 1;
            label5.Text = "Інформація із звіту";
            // 
            // panelFilterSelected
            // 
            panelFilterSelected.ColumnCount = 4;
            panelFilterSelected.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
            panelFilterSelected.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 113F));
            panelFilterSelected.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            panelFilterSelected.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelFilterSelected.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panelFilterSelected.Controls.Add(label3, 0, 0);
            panelFilterSelected.Controls.Add(rbShowAll, 1, 0);
            panelFilterSelected.Controls.Add(rbShowSelected, 2, 0);
            panelFilterSelected.Dock = DockStyle.Fill;
            panelFilterSelected.Location = new System.Drawing.Point(3, 198);
            panelFilterSelected.Name = "panelFilterSelected";
            panelFilterSelected.RowCount = 1;
            panelFilterSelected.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelFilterSelected.Size = new System.Drawing.Size(852, 25);
            panelFilterSelected.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 5);
            label3.Margin = new Padding(3, 5, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(58, 15);
            label3.TabIndex = 0;
            label3.Text = "Показати";
            // 
            // rbShowAll
            // 
            rbShowAll.AutoSize = true;
            rbShowAll.Location = new System.Drawing.Point(81, 3);
            rbShowAll.Name = "rbShowAll";
            rbShowAll.Size = new System.Drawing.Size(91, 19);
            rbShowAll.TabIndex = 1;
            rbShowAll.Text = "Всі знайдені";
            rbShowAll.UseVisualStyleBackColor = true;
            rbShowAll.CheckedChanged += rbShowAll_CheckedChanged;
            // 
            // rbShowSelected
            // 
            rbShowSelected.AutoSize = true;
            rbShowSelected.Checked = true;
            rbShowSelected.Location = new System.Drawing.Point(194, 3);
            rbShowSelected.Name = "rbShowSelected";
            rbShowSelected.Size = new System.Drawing.Size(101, 19);
            rbShowSelected.TabIndex = 1;
            rbShowSelected.TabStop = true;
            rbShowSelected.Text = "Тільки обрані";
            rbShowSelected.UseVisualStyleBackColor = true;
            rbShowSelected.CheckedChanged += rbShowSelected_CheckedChanged;
            // 
            // panelFilterPerformers
            // 
            panelFilterPerformers.ColumnCount = 4;
            panelFilterPerformers.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 289F));
            panelFilterPerformers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelFilterPerformers.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
            panelFilterPerformers.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            panelFilterPerformers.Controls.Add(label2, 0, 0);
            panelFilterPerformers.Controls.Add(tbFilterTextFragment, 1, 0);
            panelFilterPerformers.Controls.Add(btnSelectByTextFragnemts, 2, 0);
            panelFilterPerformers.Dock = DockStyle.Fill;
            panelFilterPerformers.Location = new System.Drawing.Point(3, 161);
            panelFilterPerformers.Name = "panelFilterPerformers";
            panelFilterPerformers.RowCount = 1;
            panelFilterPerformers.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelFilterPerformers.Size = new System.Drawing.Size(852, 31);
            panelFilterPerformers.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 6);
            label2.Margin = new Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(283, 25);
            label2.TabIndex = 0;
            label2.Text = "Вибір серед знайдених творів (фрагменти тексту):";
            // 
            // tbFilterTextFragment
            // 
            tbFilterTextFragment.Dock = DockStyle.Fill;
            tbFilterTextFragment.Location = new System.Drawing.Point(292, 3);
            tbFilterTextFragment.Name = "tbFilterTextFragment";
            tbFilterTextFragment.Size = new System.Drawing.Size(474, 23);
            tbFilterTextFragment.TabIndex = 1;
            // 
            // btnSelectByTextFragnemts
            // 
            btnSelectByTextFragnemts.Location = new System.Drawing.Point(772, 3);
            btnSelectByTextFragnemts.Name = "btnSelectByTextFragnemts";
            btnSelectByTextFragnemts.Size = new System.Drawing.Size(72, 23);
            btnSelectByTextFragnemts.TabIndex = 2;
            btnSelectByTextFragnemts.Text = "Вибрати";
            btnSelectByTextFragnemts.UseVisualStyleBackColor = true;
            btnSelectByTextFragnemts.Click += btnSelectByTextFragnemts_Click;
            // 
            // panelReportInfo
            // 
            panelReportInfo.ColumnCount = 5;
            panelReportInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            panelReportInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelReportInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            panelReportInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelReportInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 6F));
            panelReportInfo.Controls.Add(label6, 0, 0);
            panelReportInfo.Controls.Add(label7, 2, 0);
            panelReportInfo.Controls.Add(tbReportWorkName, 1, 0);
            panelReportInfo.Controls.Add(tbReportWorkPerformers, 3, 0);
            panelReportInfo.Dock = DockStyle.Fill;
            panelReportInfo.Location = new System.Drawing.Point(3, 32);
            panelReportInfo.Name = "panelReportInfo";
            panelReportInfo.RowCount = 1;
            panelReportInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelReportInfo.Size = new System.Drawing.Size(852, 31);
            panelReportInfo.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 6);
            label6.Margin = new Padding(3, 6, 3, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(76, 15);
            label6.TabIndex = 0;
            label6.Text = "Назва твору:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(435, 6);
            label7.Margin = new Padding(3, 6, 3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(66, 15);
            label7.TabIndex = 0;
            label7.Text = "Виконавці:";
            // 
            // tbReportWorkName
            // 
            tbReportWorkName.Dock = DockStyle.Fill;
            tbReportWorkName.Location = new System.Drawing.Point(98, 3);
            tbReportWorkName.Name = "tbReportWorkName";
            tbReportWorkName.ReadOnly = true;
            tbReportWorkName.Size = new System.Drawing.Size(331, 23);
            tbReportWorkName.TabIndex = 1;
            // 
            // tbReportWorkPerformers
            // 
            tbReportWorkPerformers.Dock = DockStyle.Fill;
            tbReportWorkPerformers.Location = new System.Drawing.Point(512, 3);
            tbReportWorkPerformers.Name = "tbReportWorkPerformers";
            tbReportWorkPerformers.ReadOnly = true;
            tbReportWorkPerformers.Size = new System.Drawing.Size(331, 23);
            tbReportWorkPerformers.TabIndex = 1;
            // 
            // timerLoad
            // 
            timerLoad.Tick += timerLoad_Tick;
            // 
            // UcSearch
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Name = "UcSearch";
            Size = new System.Drawing.Size(858, 437);
            Load += UcSearch_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelFilterName.ResumeLayout(false);
            panelFilterName.PerformLayout();
            panelFilterSelected.ResumeLayout(false);
            panelFilterSelected.PerformLayout();
            panelFilterPerformers.ResumeLayout(false);
            panelFilterPerformers.PerformLayout();
            panelReportInfo.ResumeLayout(false);
            panelReportInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelFilterName;
        private System.Windows.Forms.Label labFilterName;
        private System.Windows.Forms.TextBox tbFilterName;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel panelFilterPerformers;
        private System.Windows.Forms.TextBox tbFilterTextFragment;
        private System.Windows.Forms.Button btnSelectByTextFragnemts;
        private System.Windows.Forms.TableLayoutPanel panelFilterSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbShowAll;
        private System.Windows.Forms.RadioButton rbShowSelected;
        private WebBrowser wvFoundWorks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel panelReportInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbReportWorkName;
        private System.Windows.Forms.TextBox tbReportWorkPerformers;
        private Timer timerLoad;
        private CheckBox cbSerachUsingLike;
    }
}
