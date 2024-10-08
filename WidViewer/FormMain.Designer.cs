
namespace WidViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.cbEntityType = new System.Windows.Forms.ComboBox();
            this.split = new System.Windows.Forms.SplitContainer();
            this.panelSplitLeft = new System.Windows.Forms.TableLayoutPanel();
            this.panelRowCount = new System.Windows.Forms.TableLayoutPanel();
            this.cbRowCount = new System.Windows.Forms.ComboBox();
            this.labelShow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.TableLayoutPanel();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.lvEntityList = new System.Windows.Forms.ListView();
            this.panelRefresh = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.SuspendLayout();
            this.panelSplitLeft.SuspendLayout();
            this.panelRowCount.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelRefresh.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.cbEntityType, 0, 1);
            this.panelMain.Controls.Add(this.split, 0, 2);
            this.panelMain.Controls.Add(this.panelBottom, 0, 3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(5);
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panelMain.Size = new System.Drawing.Size(1053, 479);
            this.panelMain.TabIndex = 0;
            // 
            // cbEntityType
            // 
            this.cbEntityType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntityType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbEntityType.FormattingEnabled = true;
            this.cbEntityType.Location = new System.Drawing.Point(8, 29);
            this.cbEntityType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbEntityType.Name = "cbEntityType";
            this.cbEntityType.Size = new System.Drawing.Size(1037, 27);
            this.cbEntityType.TabIndex = 0;
            this.cbEntityType.SelectedIndexChanged += new System.EventHandler(this.cbEntityType_SelectedIndexChanged);
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split.Location = new System.Drawing.Point(8, 66);
            this.split.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.panelSplitLeft);
            // 
            // split.Panel2
            // 
            this.split.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.split.Size = new System.Drawing.Size(1037, 344);
            this.split.SplitterDistance = 410;
            this.split.SplitterWidth = 5;
            this.split.TabIndex = 0;
            // 
            // panelSplitLeft
            // 
            this.panelSplitLeft.ColumnCount = 1;
            this.panelSplitLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSplitLeft.Controls.Add(this.panelRowCount, 0, 0);
            this.panelSplitLeft.Controls.Add(this.panelFilter, 0, 1);
            this.panelSplitLeft.Controls.Add(this.lvEntityList, 0, 2);
            this.panelSplitLeft.Controls.Add(this.panelRefresh, 0, 3);
            this.panelSplitLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitLeft.Location = new System.Drawing.Point(0, 0);
            this.panelSplitLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSplitLeft.Name = "panelSplitLeft";
            this.panelSplitLeft.RowCount = 5;
            this.panelSplitLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelSplitLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelSplitLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSplitLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.panelSplitLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.panelSplitLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSplitLeft.Size = new System.Drawing.Size(410, 344);
            this.panelSplitLeft.TabIndex = 0;
            // 
            // panelRowCount
            // 
            this.panelRowCount.ColumnCount = 3;
            this.panelRowCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.panelRowCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.panelRowCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRowCount.Controls.Add(this.cbRowCount, 1, 0);
            this.panelRowCount.Controls.Add(this.labelShow, 0, 0);
            this.panelRowCount.Controls.Add(this.label1, 2, 0);
            this.panelRowCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRowCount.Location = new System.Drawing.Point(3, 4);
            this.panelRowCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelRowCount.Name = "panelRowCount";
            this.panelRowCount.RowCount = 1;
            this.panelRowCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRowCount.Size = new System.Drawing.Size(404, 29);
            this.panelRowCount.TabIndex = 1;
            // 
            // cbRowCount
            // 
            this.cbRowCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRowCount.FormattingEnabled = true;
            this.cbRowCount.Location = new System.Drawing.Point(113, 4);
            this.cbRowCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRowCount.Name = "cbRowCount";
            this.cbRowCount.Size = new System.Drawing.Size(140, 24);
            this.cbRowCount.TabIndex = 0;
            // 
            // labelShow
            // 
            this.labelShow.AutoSize = true;
            this.labelShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelShow.Location = new System.Drawing.Point(3, 0);
            this.labelShow.Name = "labelShow";
            this.labelShow.Size = new System.Drawing.Size(104, 29);
            this.labelShow.TabIndex = 0;
            this.labelShow.Text = "Показати";
            this.labelShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(265, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "перших рядків";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            this.panelFilter.ColumnCount = 4;
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.panelFilter.Controls.Add(this.cbFilter, 1, 0);
            this.panelFilter.Controls.Add(this.label2, 0, 0);
            this.panelFilter.Controls.Add(this.tbFilter, 2, 0);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 41);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.RowCount = 1;
            this.panelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFilter.Size = new System.Drawing.Size(404, 29);
            this.panelFilter.TabIndex = 0;
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(114, 4);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(164, 24);
            this.cbFilter.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Знайти такі, що";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbFilter
            // 
            this.tbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFilter.Location = new System.Drawing.Point(285, 4);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(110, 23);
            this.tbFilter.TabIndex = 1;
            this.tbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyDown);
            // 
            // lvEntityList
            // 
            this.lvEntityList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEntityList.FullRowSelect = true;
            this.lvEntityList.GridLines = true;
            this.lvEntityList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvEntityList.HideSelection = false;
            this.lvEntityList.Location = new System.Drawing.Point(3, 78);
            this.lvEntityList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvEntityList.Name = "lvEntityList";
            this.lvEntityList.Size = new System.Drawing.Size(404, 210);
            this.lvEntityList.TabIndex = 2;
            this.lvEntityList.UseCompatibleStateImageBehavior = false;
            this.lvEntityList.View = System.Windows.Forms.View.Details;
            this.lvEntityList.SelectedIndexChanged += new System.EventHandler(this.lvEntityList_SelectedIndexChanged);
            // 
            // panelRefresh
            // 
            this.panelRefresh.ColumnCount = 3;
            this.panelRefresh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRefresh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.panelRefresh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.panelRefresh.Controls.Add(this.btnRefresh, 1, 0);
            this.panelRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRefresh.Location = new System.Drawing.Point(3, 296);
            this.panelRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelRefresh.Name = "panelRefresh";
            this.panelRefresh.RowCount = 1;
            this.panelRefresh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRefresh.Size = new System.Drawing.Size(404, 38);
            this.panelRefresh.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(298, 4);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 30);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.ColumnCount = 2;
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.panelBottom.Controls.Add(this.btnClose, 1, 0);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(8, 418);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.RowCount = 1;
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.Size = new System.Drawing.Size(1037, 52);
            this.panelBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(925, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 38);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 479);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "Огляд бази даних музичних творів";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelMain.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.panelSplitLeft.ResumeLayout(false);
            this.panelRowCount.ResumeLayout(false);
            this.panelRowCount.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelRefresh.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.TableLayoutPanel panelSplitLeft;
        private System.Windows.Forms.ComboBox cbEntityType;
        private System.Windows.Forms.TableLayoutPanel panelRowCount;
        private System.Windows.Forms.ComboBox cbRowCount;
        private System.Windows.Forms.Label labelShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ListView lvEntityList;
        private System.Windows.Forms.TableLayoutPanel panelRefresh;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnClose;
    }
}

