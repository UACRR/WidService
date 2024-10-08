
namespace DdexPreSearch
{
    partial class FormMainRadio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitMiddle = new System.Windows.Forms.SplitContainer();
            this.panelMiddleLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lvReportWorks = new System.Windows.Forms.ListView();
            this.panelReportWorksHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbReport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBlock = new System.Windows.Forms.ComboBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbReportWorksFilter = new System.Windows.Forms.ComboBox();
            this.panelMiddleRight = new System.Windows.Forms.TableLayoutPanel();
            this.lvFoundWorks = new System.Windows.Forms.ListView();
            this.panelFoundMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.labFoundMatches = new System.Windows.Forms.Label();
            this.tbFoundMarches = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFoundWorksFilter = new System.Windows.Forms.ComboBox();
            this.panelTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).BeginInit();
            this.splitMiddle.Panel1.SuspendLayout();
            this.splitMiddle.Panel2.SuspendLayout();
            this.splitMiddle.SuspendLayout();
            this.panelMiddleLeft.SuspendLayout();
            this.panelReportWorksHeader.SuspendLayout();
            this.panelMiddleRight.SuspendLayout();
            this.panelFoundMatches.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.splitMiddle, 0, 1);
            this.panelMain.Controls.Add(this.panelTitle, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.221006F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.77899F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1091, 478);
            this.panelMain.TabIndex = 0;
            // 
            // splitMiddle
            // 
            this.splitMiddle.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMiddle.Location = new System.Drawing.Point(3, 36);
            this.splitMiddle.Name = "splitMiddle";
            this.splitMiddle.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMiddle.Panel1
            // 
            this.splitMiddle.Panel1.Controls.Add(this.panelMiddleLeft);
            // 
            // splitMiddle.Panel2
            // 
            this.splitMiddle.Panel2.Controls.Add(this.panelMiddleRight);
            this.splitMiddle.Size = new System.Drawing.Size(1085, 418);
            this.splitMiddle.SplitterDistance = 205;
            this.splitMiddle.TabIndex = 0;
            // 
            // panelMiddleLeft
            // 
            this.panelMiddleLeft.BackColor = System.Drawing.SystemColors.Window;
            this.panelMiddleLeft.ColumnCount = 1;
            this.panelMiddleLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleLeft.Controls.Add(this.lvReportWorks, 0, 1);
            this.panelMiddleLeft.Controls.Add(this.panelReportWorksHeader, 0, 0);
            this.panelMiddleLeft.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddleLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMiddleLeft.Name = "panelMiddleLeft";
            this.panelMiddleLeft.RowCount = 3;
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMiddleLeft.Size = new System.Drawing.Size(1085, 205);
            this.panelMiddleLeft.TabIndex = 0;
            // 
            // lvReportWorks
            // 
            this.lvReportWorks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportWorks.FullRowSelect = true;
            this.lvReportWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReportWorks.HideSelection = false;
            this.lvReportWorks.Location = new System.Drawing.Point(3, 38);
            this.lvReportWorks.MultiSelect = false;
            this.lvReportWorks.Name = "lvReportWorks";
            this.lvReportWorks.Size = new System.Drawing.Size(1079, 144);
            this.lvReportWorks.TabIndex = 0;
            this.lvReportWorks.UseCompatibleStateImageBehavior = false;
            this.lvReportWorks.View = System.Windows.Forms.View.Details;
            this.lvReportWorks.SelectedIndexChanged += new System.EventHandler(this.lvReportWorks_SelectedIndexChanged);
            // 
            // panelReportWorksHeader
            // 
            this.panelReportWorksHeader.Controls.Add(this.label1);
            this.panelReportWorksHeader.Controls.Add(this.cbReport);
            this.panelReportWorksHeader.Controls.Add(this.btnLoadFromFile);
            this.panelReportWorksHeader.Controls.Add(this.label2);
            this.panelReportWorksHeader.Controls.Add(this.cbBlock);
            this.panelReportWorksHeader.Controls.Add(this.btnLoadData);
            this.panelReportWorksHeader.Controls.Add(this.label3);
            this.panelReportWorksHeader.Controls.Add(this.cbReportWorksFilter);
            this.panelReportWorksHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorksHeader.Location = new System.Drawing.Point(3, 3);
            this.panelReportWorksHeader.Name = "panelReportWorksHeader";
            this.panelReportWorksHeader.Size = new System.Drawing.Size(1079, 29);
            this.panelReportWorksHeader.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Звіт";
            // 
            // cbReport
            // 
            this.cbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport.FormattingEnabled = true;
            this.cbReport.Location = new System.Drawing.Point(37, 3);
            this.cbReport.Name = "cbReport";
            this.cbReport.Size = new System.Drawing.Size(257, 23);
            this.cbReport.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Блок";
            // 
            // cbBlock
            // 
            this.cbBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlock.FormattingEnabled = true;
            this.cbBlock.Location = new System.Drawing.Point(485, 3);
            this.cbBlock.Name = "cbBlock";
            this.cbBlock.Size = new System.Drawing.Size(131, 23);
            this.cbBlock.TabIndex = 1;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(622, 3);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(116, 23);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Завантажити дані";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(744, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Фільтр";
            // 
            // cbReportWorksFilter
            // 
            this.cbReportWorksFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReportWorksFilter.FormattingEnabled = true;
            this.cbReportWorksFilter.Location = new System.Drawing.Point(794, 3);
            this.cbReportWorksFilter.Name = "cbReportWorksFilter";
            this.cbReportWorksFilter.Size = new System.Drawing.Size(257, 23);
            this.cbReportWorksFilter.TabIndex = 1;
            this.cbReportWorksFilter.SelectedIndexChanged += new System.EventHandler(this.cbReportWorksFilter_SelectedIndexChanged);
            // 
            // panelMiddleRight
            // 
            this.panelMiddleRight.BackColor = System.Drawing.SystemColors.Window;
            this.panelMiddleRight.ColumnCount = 1;
            this.panelMiddleRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleRight.Controls.Add(this.lvFoundWorks, 0, 1);
            this.panelMiddleRight.Controls.Add(this.panelFoundMatches, 0, 0);
            this.panelMiddleRight.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddleRight.Location = new System.Drawing.Point(0, 0);
            this.panelMiddleRight.Name = "panelMiddleRight";
            this.panelMiddleRight.RowCount = 3;
            this.panelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMiddleRight.Size = new System.Drawing.Size(1085, 209);
            this.panelMiddleRight.TabIndex = 0;
            // 
            // lvFoundWorks
            // 
            this.lvFoundWorks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFoundWorks.FullRowSelect = true;
            this.lvFoundWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFoundWorks.HideSelection = false;
            this.lvFoundWorks.Location = new System.Drawing.Point(3, 42);
            this.lvFoundWorks.MultiSelect = false;
            this.lvFoundWorks.Name = "lvFoundWorks";
            this.lvFoundWorks.Size = new System.Drawing.Size(1079, 144);
            this.lvFoundWorks.TabIndex = 0;
            this.lvFoundWorks.UseCompatibleStateImageBehavior = false;
            this.lvFoundWorks.View = System.Windows.Forms.View.Details;
            // 
            // panelFoundMatches
            // 
            this.panelFoundMatches.Controls.Add(this.labFoundMatches);
            this.panelFoundMatches.Controls.Add(this.tbFoundMarches);
            this.panelFoundMatches.Controls.Add(this.label4);
            this.panelFoundMatches.Controls.Add(this.cbFoundWorksFilter);
            this.panelFoundMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoundMatches.Location = new System.Drawing.Point(3, 3);
            this.panelFoundMatches.Name = "panelFoundMatches";
            this.panelFoundMatches.Size = new System.Drawing.Size(1079, 33);
            this.panelFoundMatches.TabIndex = 1;
            // 
            // labFoundMatches
            // 
            this.labFoundMatches.AutoSize = true;
            this.labFoundMatches.Location = new System.Drawing.Point(3, 7);
            this.labFoundMatches.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labFoundMatches.Name = "labFoundMatches";
            this.labFoundMatches.Size = new System.Drawing.Size(203, 15);
            this.labFoundMatches.TabIndex = 0;
            this.labFoundMatches.Text = "Знайдено серед авторів/виконавців";
            // 
            // tbFoundMarches
            // 
            this.tbFoundMarches.Location = new System.Drawing.Point(212, 3);
            this.tbFoundMarches.Name = "tbFoundMarches";
            this.tbFoundMarches.Size = new System.Drawing.Size(39, 23);
            this.tbFoundMarches.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Фільтр";
            // 
            // cbFoundWorksFilter
            // 
            this.cbFoundWorksFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFoundWorksFilter.FormattingEnabled = true;
            this.cbFoundWorksFilter.Location = new System.Drawing.Point(307, 3);
            this.cbFoundWorksFilter.Name = "cbFoundWorksFilter";
            this.cbFoundWorksFilter.Size = new System.Drawing.Size(257, 23);
            this.cbFoundWorksFilter.TabIndex = 1;
            this.cbFoundWorksFilter.SelectedIndexChanged += new System.EventHandler(this.cbFoundWorksFilter_SelectedIndexChanged);
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.label5);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitle.Location = new System.Drawing.Point(3, 3);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1085, 27);
            this.panelTitle.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(386, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Пошук творів на основі попередньої обробки даних";
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(300, 3);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(139, 23);
            this.btnLoadFromFile.TabIndex = 3;
            this.btnLoadFromFile.Text = "Завантажити файл";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // FormMainRadio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 478);
            this.Controls.Add(this.panelMain);
            this.Name = "FormMainRadio";
            this.Text = "DdexPreSearch";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.splitMiddle.Panel1.ResumeLayout(false);
            this.splitMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).EndInit();
            this.splitMiddle.ResumeLayout(false);
            this.panelMiddleLeft.ResumeLayout(false);
            this.panelReportWorksHeader.ResumeLayout(false);
            this.panelReportWorksHeader.PerformLayout();
            this.panelMiddleRight.ResumeLayout(false);
            this.panelFoundMatches.ResumeLayout(false);
            this.panelFoundMatches.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer splitMiddle;
        private System.Windows.Forms.TableLayoutPanel panelMiddleLeft;
        private System.Windows.Forms.TableLayoutPanel panelMiddleRight;
        private System.Windows.Forms.ListView lvReportWorks;
        private System.Windows.Forms.ListView lvFoundWorks;
        private System.Windows.Forms.FlowLayoutPanel panelFoundMatches;
        private System.Windows.Forms.Label labFoundMatches;
        private System.Windows.Forms.TextBox tbFoundMarches;
        private System.Windows.Forms.FlowLayoutPanel panelReportWorksHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBlock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbReportWorksFilter;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.ComboBox cbFoundWorksFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel panelTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
    }
}

