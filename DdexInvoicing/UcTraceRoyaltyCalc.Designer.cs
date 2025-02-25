namespace DdexInvoicing
{
    partial class UcTraceRoyaltyCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcTraceRoyaltyCalc));
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.labTopPanelTitle = new System.Windows.Forms.Label();
            this.panelTopFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lvReportWorks = new System.Windows.Forms.ListView();
            this.panelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.panelTotalPercent = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPerShrTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMecShrTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelSplitBottom = new System.Windows.Forms.SplitContainer();
            this.panelBottomLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tvCheckPlan = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.panelSplitBottomRight = new System.Windows.Forms.SplitContainer();
            this.panelBottomRightTop = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lvDetails = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTopFilter.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTotalPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitBottom)).BeginInit();
            this.panelSplitBottom.Panel1.SuspendLayout();
            this.panelSplitBottom.Panel2.SuspendLayout();
            this.panelSplitBottom.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitBottomRight)).BeginInit();
            this.panelSplitBottomRight.Panel1.SuspendLayout();
            this.panelSplitBottomRight.SuspendLayout();
            this.panelBottomRightTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelMain.Panel1
            // 
            this.panelMain.Panel1.Controls.Add(this.panelTop);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.Controls.Add(this.panelBottom);
            this.panelMain.Size = new System.Drawing.Size(751, 484);
            this.panelMain.SplitterDistance = 228;
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.ColumnCount = 1;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Controls.Add(this.labTopPanelTitle, 0, 0);
            this.panelTop.Controls.Add(this.panelTopFilter, 0, 1);
            this.panelTop.Controls.Add(this.lvReportWorks, 0, 2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 3;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(751, 228);
            this.panelTop.TabIndex = 0;
            // 
            // labTopPanelTitle
            // 
            this.labTopPanelTitle.AutoSize = true;
            this.labTopPanelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labTopPanelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTopPanelTitle.Location = new System.Drawing.Point(3, 0);
            this.labTopPanelTitle.Name = "labTopPanelTitle";
            this.labTopPanelTitle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labTopPanelTitle.Size = new System.Drawing.Size(745, 25);
            this.labTopPanelTitle.TabIndex = 0;
            this.labTopPanelTitle.Text = "Знайдені твори звіту";
            // 
            // panelTopFilter
            // 
            this.panelTopFilter.Controls.Add(this.label1);
            this.panelTopFilter.Controls.Add(this.tbFilter);
            this.panelTopFilter.Controls.Add(this.btnApplyFilter);
            this.panelTopFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopFilter.Location = new System.Drawing.Point(3, 28);
            this.panelTopFilter.Name = "panelTopFilter";
            this.panelTopFilter.Size = new System.Drawing.Size(745, 33);
            this.panelTopFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вибрати за кодом або шаблоном назви (перші 100 творів)";
            // 
            // tbFilter
            // 
            this.tbFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.tbFilter.Location = new System.Drawing.Point(309, 5);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(148, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(463, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(92, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Застосувати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // lvReportWorks
            // 
            this.lvReportWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReportWorks.HideSelection = false;
            this.lvReportWorks.Location = new System.Drawing.Point(3, 67);
            this.lvReportWorks.Name = "lvReportWorks";
            this.lvReportWorks.Size = new System.Drawing.Size(745, 158);
            this.lvReportWorks.TabIndex = 2;
            this.lvReportWorks.UseCompatibleStateImageBehavior = false;
            this.lvReportWorks.SelectedIndexChanged += new System.EventHandler(this.lvReportWorks_SelectedIndexChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.ColumnCount = 1;
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.Controls.Add(this.panelTotalPercent, 0, 2);
            this.panelBottom.Controls.Add(this.label5, 0, 0);
            this.panelBottom.Controls.Add(this.panelSplitBottom, 0, 1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.RowCount = 4;
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelBottom.Size = new System.Drawing.Size(751, 252);
            this.panelBottom.TabIndex = 0;
            // 
            // panelTotalPercent
            // 
            this.panelTotalPercent.Controls.Add(this.label2);
            this.panelTotalPercent.Controls.Add(this.tbPerShrTotal);
            this.panelTotalPercent.Controls.Add(this.label4);
            this.panelTotalPercent.Controls.Add(this.tbMecShrTotal);
            this.panelTotalPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalPercent.Location = new System.Drawing.Point(3, 215);
            this.panelTotalPercent.Name = "panelTotalPercent";
            this.panelTotalPercent.Size = new System.Drawing.Size(745, 26);
            this.panelTotalPercent.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Для твору загалом проценти за використання Публічне:";
            // 
            // tbPerShrTotal
            // 
            this.tbPerShrTotal.Location = new System.Drawing.Point(303, 3);
            this.tbPerShrTotal.Name = "tbPerShrTotal";
            this.tbPerShrTotal.ReadOnly = true;
            this.tbPerShrTotal.Size = new System.Drawing.Size(100, 20);
            this.tbPerShrTotal.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Механічне:";
            // 
            // tbMecShrTotal
            // 
            this.tbMecShrTotal.Location = new System.Drawing.Point(476, 3);
            this.tbMecShrTotal.Name = "tbMecShrTotal";
            this.tbMecShrTotal.ReadOnly = true;
            this.tbMecShrTotal.Size = new System.Drawing.Size(100, 20);
            this.tbMecShrTotal.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(745, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Розрахунок процентів";
            // 
            // panelSplitBottom
            // 
            this.panelSplitBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitBottom.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelSplitBottom.Location = new System.Drawing.Point(3, 27);
            this.panelSplitBottom.Name = "panelSplitBottom";
            // 
            // panelSplitBottom.Panel1
            // 
            this.panelSplitBottom.Panel1.Controls.Add(this.panelBottomLeft);
            // 
            // panelSplitBottom.Panel2
            // 
            this.panelSplitBottom.Panel2.Controls.Add(this.panelSplitBottomRight);
            this.panelSplitBottom.Size = new System.Drawing.Size(745, 182);
            this.panelSplitBottom.SplitterDistance = 258;
            this.panelSplitBottom.TabIndex = 2;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.ColumnCount = 1;
            this.panelBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottomLeft.Controls.Add(this.tvCheckPlan, 0, 1);
            this.panelBottomLeft.Controls.Add(this.label8, 0, 0);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.RowCount = 2;
            this.panelBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.panelBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottomLeft.Size = new System.Drawing.Size(258, 182);
            this.panelBottomLeft.TabIndex = 0;
            // 
            // tvCheckPlan
            // 
            this.tvCheckPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCheckPlan.ImageIndex = 0;
            this.tvCheckPlan.ImageList = this.imageList1;
            this.tvCheckPlan.Location = new System.Drawing.Point(3, 19);
            this.tvCheckPlan.Name = "tvCheckPlan";
            this.tvCheckPlan.SelectedImageIndex = 0;
            this.tvCheckPlan.Size = new System.Drawing.Size(252, 160);
            this.tvCheckPlan.TabIndex = 0;
            this.tvCheckPlan.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCheckPlan_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Hopstarter-Sleek-Xp-Basic-Ok.ico");
            this.imageList1.Images.SetKeyName(1, "Paomedia-Small-N-Flat-Sign-warning.ico");
            this.imageList1.Images.SetKeyName(2, "Oxygen-Icons.org-Oxygen-Actions-edit-delete.ico");
            this.imageList1.Images.SetKeyName(3, "Collapsed.ico");
            this.imageList1.Images.SetKeyName(4, "Expanded.ico");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Групи перевірок";
            // 
            // panelSplitBottomRight
            // 
            this.panelSplitBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitBottomRight.Location = new System.Drawing.Point(0, 0);
            this.panelSplitBottomRight.Name = "panelSplitBottomRight";
            this.panelSplitBottomRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelSplitBottomRight.Panel1
            // 
            this.panelSplitBottomRight.Panel1.Controls.Add(this.panelBottomRightTop);
            this.panelSplitBottomRight.Panel2Collapsed = true;
            this.panelSplitBottomRight.Size = new System.Drawing.Size(483, 182);
            this.panelSplitBottomRight.SplitterDistance = 142;
            this.panelSplitBottomRight.TabIndex = 0;
            // 
            // panelBottomRightTop
            // 
            this.panelBottomRightTop.ColumnCount = 1;
            this.panelBottomRightTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottomRightTop.Controls.Add(this.label6, 0, 0);
            this.panelBottomRightTop.Controls.Add(this.lvDetails, 0, 1);
            this.panelBottomRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRightTop.Location = new System.Drawing.Point(0, 0);
            this.panelBottomRightTop.Name = "panelBottomRightTop";
            this.panelBottomRightTop.RowCount = 2;
            this.panelBottomRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.panelBottomRightTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottomRightTop.Size = new System.Drawing.Size(483, 182);
            this.panelBottomRightTop.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Параметри для перевірки";
            // 
            // lvDetails
            // 
            this.lvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetails.HideSelection = false;
            this.lvDetails.Location = new System.Drawing.Point(3, 19);
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(477, 160);
            this.lvDetails.SmallImageList = this.imageList1;
            this.lvDetails.TabIndex = 1;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.Click += new System.EventHandler(this.lvDetails_Click);
            this.lvDetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDetails_MouseDoubleClick);
            // 
            // UcTraceRoyaltyCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcTraceRoyaltyCalc";
            this.Size = new System.Drawing.Size(751, 484);
            this.Load += new System.EventHandler(this.UcTraceRoyaltyCalc_Load);
            this.panelMain.Panel1.ResumeLayout(false);
            this.panelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTopFilter.ResumeLayout(false);
            this.panelTopFilter.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTotalPercent.ResumeLayout(false);
            this.panelTotalPercent.PerformLayout();
            this.panelSplitBottom.Panel1.ResumeLayout(false);
            this.panelSplitBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitBottom)).EndInit();
            this.panelSplitBottom.ResumeLayout(false);
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomLeft.PerformLayout();
            this.panelSplitBottomRight.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitBottomRight)).EndInit();
            this.panelSplitBottomRight.ResumeLayout(false);
            this.panelBottomRightTop.ResumeLayout(false);
            this.panelBottomRightTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.Label labTopPanelTitle;
        private System.Windows.Forms.FlowLayoutPanel panelTopFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.ListView lvReportWorks;
        private System.Windows.Forms.TableLayoutPanel panelBottom;
        private System.Windows.Forms.FlowLayoutPanel panelTotalPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPerShrTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMecShrTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer panelSplitBottom;
        private System.Windows.Forms.TreeView tvCheckPlan;
        private System.Windows.Forms.SplitContainer panelSplitBottomRight;
        private System.Windows.Forms.TableLayoutPanel panelBottomRightTop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel panelBottomLeft;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.ImageList imageList1;
    }
}
