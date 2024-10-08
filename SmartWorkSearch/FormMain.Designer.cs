
namespace SmartWorkSearch
{
    partial class FormMain
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitTop = new System.Windows.Forms.SplitContainer();
            this.panelLocalWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvLocalWorks = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLocalWorksFilter = new System.Windows.Forms.TableLayoutPanel();
            this.labLocalWorksAuthor = new System.Windows.Forms.Label();
            this.tbLocalWorksAuthor = new System.Windows.Forms.TextBox();
            this.btnLocalWorksAuthorSearch = new System.Windows.Forms.Button();
            this.panelReportWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvReportWorks = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelReportWorksFilter = new System.Windows.Forms.TableLayoutPanel();
            this.btnReportWorksSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReportFilterPerformer = new System.Windows.Forms.TextBox();
            this.tbReportFilterAuthor = new System.Windows.Forms.TextBox();
            this.tbReportFilterName = new System.Windows.Forms.TextBox();
            this.panelFoundWorks = new System.Windows.Forms.TableLayoutPanel();
            this.lvFoundWorks = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTop)).BeginInit();
            this.splitTop.Panel1.SuspendLayout();
            this.splitTop.Panel2.SuspendLayout();
            this.splitTop.SuspendLayout();
            this.panelLocalWorks.SuspendLayout();
            this.panelLocalWorksFilter.SuspendLayout();
            this.panelReportWorks.SuspendLayout();
            this.panelReportWorksFilter.SuspendLayout();
            this.panelFoundWorks.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.splitMain, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1049, 496);
            this.panelMain.TabIndex = 0;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(4, 25);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitTop);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.panelFoundWorks);
            this.splitMain.Size = new System.Drawing.Size(1041, 446);
            this.splitMain.SplitterDistance = 289;
            this.splitMain.TabIndex = 0;
            // 
            // splitTop
            // 
            this.splitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTop.Location = new System.Drawing.Point(0, 0);
            this.splitTop.Name = "splitTop";
            // 
            // splitTop.Panel1
            // 
            this.splitTop.Panel1.Controls.Add(this.panelLocalWorks);
            // 
            // splitTop.Panel2
            // 
            this.splitTop.Panel2.Controls.Add(this.panelReportWorks);
            this.splitTop.Size = new System.Drawing.Size(1041, 289);
            this.splitTop.SplitterDistance = 508;
            this.splitTop.TabIndex = 0;
            // 
            // panelLocalWorks
            // 
            this.panelLocalWorks.ColumnCount = 1;
            this.panelLocalWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorks.Controls.Add(this.lvLocalWorks, 0, 2);
            this.panelLocalWorks.Controls.Add(this.label1, 0, 0);
            this.panelLocalWorks.Controls.Add(this.panelLocalWorksFilter, 0, 1);
            this.panelLocalWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocalWorks.Location = new System.Drawing.Point(0, 0);
            this.panelLocalWorks.Name = "panelLocalWorks";
            this.panelLocalWorks.RowCount = 5;
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalWorks.Size = new System.Drawing.Size(508, 289);
            this.panelLocalWorks.TabIndex = 0;
            // 
            // lvLocalWorks
            // 
            this.lvLocalWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocalWorks.FullRowSelect = true;
            this.lvLocalWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLocalWorks.HideSelection = false;
            this.lvLocalWorks.Location = new System.Drawing.Point(3, 56);
            this.lvLocalWorks.MultiSelect = false;
            this.lvLocalWorks.Name = "lvLocalWorks";
            this.lvLocalWorks.ShowItemToolTips = true;
            this.lvLocalWorks.Size = new System.Drawing.Size(502, 214);
            this.lvLocalWorks.TabIndex = 0;
            this.lvLocalWorks.UseCompatibleStateImageBehavior = false;
            this.lvLocalWorks.View = System.Windows.Forms.View.Details;
            this.lvLocalWorks.DoubleClick += new System.EventHandler(this.lvLocalWorks_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Локальні твори";
            // 
            // panelLocalWorksFilter
            // 
            this.panelLocalWorksFilter.ColumnCount = 4;
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.panelLocalWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLocalWorksFilter.Controls.Add(this.labLocalWorksAuthor, 0, 0);
            this.panelLocalWorksFilter.Controls.Add(this.tbLocalWorksAuthor, 1, 0);
            this.panelLocalWorksFilter.Controls.Add(this.btnLocalWorksAuthorSearch, 2, 0);
            this.panelLocalWorksFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocalWorksFilter.Location = new System.Drawing.Point(3, 23);
            this.panelLocalWorksFilter.Name = "panelLocalWorksFilter";
            this.panelLocalWorksFilter.RowCount = 1;
            this.panelLocalWorksFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLocalWorksFilter.Size = new System.Drawing.Size(502, 27);
            this.panelLocalWorksFilter.TabIndex = 2;
            // 
            // labLocalWorksAuthor
            // 
            this.labLocalWorksAuthor.AutoSize = true;
            this.labLocalWorksAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labLocalWorksAuthor.Location = new System.Drawing.Point(3, 0);
            this.labLocalWorksAuthor.Name = "labLocalWorksAuthor";
            this.labLocalWorksAuthor.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labLocalWorksAuthor.Size = new System.Drawing.Size(80, 27);
            this.labLocalWorksAuthor.TabIndex = 0;
            this.labLocalWorksAuthor.Text = "Твори автора";
            // 
            // tbLocalWorksAuthor
            // 
            this.tbLocalWorksAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocalWorksAuthor.Location = new System.Drawing.Point(89, 3);
            this.tbLocalWorksAuthor.Name = "tbLocalWorksAuthor";
            this.tbLocalWorksAuthor.Size = new System.Drawing.Size(318, 20);
            this.tbLocalWorksAuthor.TabIndex = 1;
            // 
            // btnLocalWorksAuthorSearch
            // 
            this.btnLocalWorksAuthorSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocalWorksAuthorSearch.Location = new System.Drawing.Point(413, 3);
            this.btnLocalWorksAuthorSearch.Name = "btnLocalWorksAuthorSearch";
            this.btnLocalWorksAuthorSearch.Size = new System.Drawing.Size(78, 21);
            this.btnLocalWorksAuthorSearch.TabIndex = 2;
            this.btnLocalWorksAuthorSearch.Text = "Шукати";
            this.btnLocalWorksAuthorSearch.UseVisualStyleBackColor = true;
            this.btnLocalWorksAuthorSearch.Click += new System.EventHandler(this.btnLocalWorksAuthorSearch_Click);
            // 
            // panelReportWorks
            // 
            this.panelReportWorks.ColumnCount = 1;
            this.panelReportWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorks.Controls.Add(this.lvReportWorks, 0, 2);
            this.panelReportWorks.Controls.Add(this.label2, 0, 0);
            this.panelReportWorks.Controls.Add(this.panelReportWorksFilter, 0, 1);
            this.panelReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorks.Location = new System.Drawing.Point(0, 0);
            this.panelReportWorks.Name = "panelReportWorks";
            this.panelReportWorks.RowCount = 5;
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReportWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReportWorks.Size = new System.Drawing.Size(529, 289);
            this.panelReportWorks.TabIndex = 0;
            // 
            // lvReportWorks
            // 
            this.lvReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportWorks.FullRowSelect = true;
            this.lvReportWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReportWorks.HideSelection = false;
            this.lvReportWorks.Location = new System.Drawing.Point(3, 55);
            this.lvReportWorks.MultiSelect = false;
            this.lvReportWorks.Name = "lvReportWorks";
            this.lvReportWorks.Size = new System.Drawing.Size(523, 215);
            this.lvReportWorks.TabIndex = 0;
            this.lvReportWorks.UseCompatibleStateImageBehavior = false;
            this.lvReportWorks.View = System.Windows.Forms.View.Details;
            this.lvReportWorks.DoubleClick += new System.EventHandler(this.lvReportWorks_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Твори звіту";
            // 
            // panelReportWorksFilter
            // 
            this.panelReportWorksFilter.ColumnCount = 8;
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.panelReportWorksFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelReportWorksFilter.Controls.Add(this.btnReportWorksSearch, 6, 0);
            this.panelReportWorksFilter.Controls.Add(this.label4, 0, 0);
            this.panelReportWorksFilter.Controls.Add(this.label5, 2, 0);
            this.panelReportWorksFilter.Controls.Add(this.label6, 4, 0);
            this.panelReportWorksFilter.Controls.Add(this.tbReportFilterPerformer, 5, 0);
            this.panelReportWorksFilter.Controls.Add(this.tbReportFilterAuthor, 3, 0);
            this.panelReportWorksFilter.Controls.Add(this.tbReportFilterName, 1, 0);
            this.panelReportWorksFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportWorksFilter.Location = new System.Drawing.Point(3, 23);
            this.panelReportWorksFilter.Name = "panelReportWorksFilter";
            this.panelReportWorksFilter.RowCount = 1;
            this.panelReportWorksFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelReportWorksFilter.Size = new System.Drawing.Size(523, 26);
            this.panelReportWorksFilter.TabIndex = 2;
            // 
            // btnReportWorksSearch
            // 
            this.btnReportWorksSearch.Location = new System.Drawing.Point(446, 3);
            this.btnReportWorksSearch.Name = "btnReportWorksSearch";
            this.btnReportWorksSearch.Size = new System.Drawing.Size(66, 20);
            this.btnReportWorksSearch.TabIndex = 0;
            this.btnReportWorksSearch.Text = "Шукати";
            this.btnReportWorksSearch.UseVisualStyleBackColor = true;
            this.btnReportWorksSearch.Click += new System.EventHandler(this.btnReportWorksSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label4.Size = new System.Drawing.Size(42, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Назва";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(141, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label5.Size = new System.Drawing.Size(41, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "Автор";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(278, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label6.Size = new System.Drawing.Size(72, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "Виконавець";
            // 
            // tbReportFilterPerformer
            // 
            this.tbReportFilterPerformer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReportFilterPerformer.Location = new System.Drawing.Point(356, 3);
            this.tbReportFilterPerformer.Name = "tbReportFilterPerformer";
            this.tbReportFilterPerformer.Size = new System.Drawing.Size(84, 20);
            this.tbReportFilterPerformer.TabIndex = 2;
            // 
            // tbReportFilterAuthor
            // 
            this.tbReportFilterAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReportFilterAuthor.Location = new System.Drawing.Point(188, 3);
            this.tbReportFilterAuthor.Name = "tbReportFilterAuthor";
            this.tbReportFilterAuthor.Size = new System.Drawing.Size(84, 20);
            this.tbReportFilterAuthor.TabIndex = 2;
            // 
            // tbReportFilterName
            // 
            this.tbReportFilterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReportFilterName.Location = new System.Drawing.Point(51, 3);
            this.tbReportFilterName.Name = "tbReportFilterName";
            this.tbReportFilterName.Size = new System.Drawing.Size(84, 20);
            this.tbReportFilterName.TabIndex = 2;
            // 
            // panelFoundWorks
            // 
            this.panelFoundWorks.ColumnCount = 1;
            this.panelFoundWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFoundWorks.Controls.Add(this.lvFoundWorks, 0, 1);
            this.panelFoundWorks.Controls.Add(this.label3, 0, 0);
            this.panelFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoundWorks.Location = new System.Drawing.Point(0, 0);
            this.panelFoundWorks.Name = "panelFoundWorks";
            this.panelFoundWorks.RowCount = 4;
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelFoundWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelFoundWorks.Size = new System.Drawing.Size(1041, 153);
            this.panelFoundWorks.TabIndex = 0;
            // 
            // lvFoundWorks
            // 
            this.lvFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFoundWorks.FullRowSelect = true;
            this.lvFoundWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvFoundWorks.HideSelection = false;
            this.lvFoundWorks.Location = new System.Drawing.Point(3, 23);
            this.lvFoundWorks.MultiSelect = false;
            this.lvFoundWorks.Name = "lvFoundWorks";
            this.lvFoundWorks.Size = new System.Drawing.Size(1035, 111);
            this.lvFoundWorks.TabIndex = 0;
            this.lvFoundWorks.UseCompatibleStateImageBehavior = false;
            this.lvFoundWorks.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Знайдені твори";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 496);
            this.Controls.Add(this.panelMain);
            this.Name = "FormMain";
            this.Text = "Пошук творів у звітах";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitTop.Panel1.ResumeLayout(false);
            this.splitTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTop)).EndInit();
            this.splitTop.ResumeLayout(false);
            this.panelLocalWorks.ResumeLayout(false);
            this.panelLocalWorks.PerformLayout();
            this.panelLocalWorksFilter.ResumeLayout(false);
            this.panelLocalWorksFilter.PerformLayout();
            this.panelReportWorks.ResumeLayout(false);
            this.panelReportWorks.PerformLayout();
            this.panelReportWorksFilter.ResumeLayout(false);
            this.panelReportWorksFilter.PerformLayout();
            this.panelFoundWorks.ResumeLayout(false);
            this.panelFoundWorks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitTop;
        private System.Windows.Forms.TableLayoutPanel panelLocalWorks;
        private System.Windows.Forms.ListView lvLocalWorks;
        private System.Windows.Forms.TableLayoutPanel panelReportWorks;
        private System.Windows.Forms.ListView lvReportWorks;
        private System.Windows.Forms.TableLayoutPanel panelFoundWorks;
        private System.Windows.Forms.ListView lvFoundWorks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel panelLocalWorksFilter;
        private System.Windows.Forms.Label labLocalWorksAuthor;
        private System.Windows.Forms.TextBox tbLocalWorksAuthor;
        private System.Windows.Forms.Button btnLocalWorksAuthorSearch;
        private System.Windows.Forms.TableLayoutPanel panelReportWorksFilter;
        private System.Windows.Forms.Button btnReportWorksSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReportFilterPerformer;
        private System.Windows.Forms.TextBox tbReportFilterAuthor;
        private System.Windows.Forms.TextBox tbReportFilterName;
    }
}

