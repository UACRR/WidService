namespace DdexInvoicing
{
    partial class UcDspResourceAnalyser
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
            this.labWorkPerformers = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.panelMainMiddle = new System.Windows.Forms.SplitContainer();
            this.panelMainMiddleLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvDspResources = new System.Windows.Forms.ListView();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.panelWorkDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labWorkDetails = new System.Windows.Forms.Label();
            this.labWorkName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelMainMiddleRight = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.wbResourceMetaData = new System.Windows.Forms.WebBrowser();
            this.panelMain.SuspendLayout();
            this.labWorkPerformers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMainMiddle)).BeginInit();
            this.panelMainMiddle.Panel1.SuspendLayout();
            this.panelMainMiddle.Panel2.SuspendLayout();
            this.panelMainMiddle.SuspendLayout();
            this.panelMainMiddleLeft.SuspendLayout();
            this.panelWorkDetails.SuspendLayout();
            this.panelMainMiddleRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.labWorkPerformers, 0, 0);
            this.panelMain.Controls.Add(this.panelMainMiddle, 0, 2);
            this.panelMain.Controls.Add(this.panelWorkDetails, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelMain.Size = new System.Drawing.Size(765, 493);
            this.panelMain.TabIndex = 0;
            // 
            // labWorkPerformers
            // 
            this.labWorkPerformers.Controls.Add(this.label1);
            this.labWorkPerformers.Controls.Add(this.tbFilter);
            this.labWorkPerformers.Controls.Add(this.btnApplyFilter);
            this.labWorkPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labWorkPerformers.Location = new System.Drawing.Point(3, 3);
            this.labWorkPerformers.Name = "labWorkPerformers";
            this.labWorkPerformers.Size = new System.Drawing.Size(759, 32);
            this.labWorkPerformers.TabIndex = 0;
            this.labWorkPerformers.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код твору:";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(69, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(242, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // panelMainMiddle
            // 
            this.panelMainMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMainMiddle.Location = new System.Drawing.Point(3, 120);
            this.panelMainMiddle.Name = "panelMainMiddle";
            // 
            // panelMainMiddle.Panel1
            // 
            this.panelMainMiddle.Panel1.Controls.Add(this.panelMainMiddleLeft);
            // 
            // panelMainMiddle.Panel2
            // 
            this.panelMainMiddle.Panel2.Controls.Add(this.panelMainMiddleRight);
            this.panelMainMiddle.Size = new System.Drawing.Size(759, 360);
            this.panelMainMiddle.SplitterDistance = 253;
            this.panelMainMiddle.TabIndex = 1;
            // 
            // panelMainMiddleLeft
            // 
            this.panelMainMiddleLeft.ColumnCount = 1;
            this.panelMainMiddleLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMainMiddleLeft.Controls.Add(this.label2, 0, 0);
            this.panelMainMiddleLeft.Controls.Add(this.lvDspResources, 0, 1);
            this.panelMainMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainMiddleLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMainMiddleLeft.Name = "panelMainMiddleLeft";
            this.panelMainMiddleLeft.RowCount = 3;
            this.panelMainMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelMainMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMainMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelMainMiddleLeft.Size = new System.Drawing.Size(253, 360);
            this.panelMainMiddleLeft.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ресурси цифрових майданчиків";
            // 
            // lvDspResources
            // 
            this.lvDspResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDspResources.HideSelection = false;
            this.lvDspResources.Location = new System.Drawing.Point(3, 35);
            this.lvDspResources.Name = "lvDspResources";
            this.lvDspResources.Size = new System.Drawing.Size(247, 312);
            this.lvDspResources.TabIndex = 1;
            this.lvDspResources.UseCompatibleStateImageBehavior = false;
            this.lvDspResources.SelectedIndexChanged += new System.EventHandler(this.lvDspResources_SelectedIndexChanged);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(317, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(89, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Показати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // panelWorkDetails
            // 
            this.panelWorkDetails.AutoSize = true;
            this.panelWorkDetails.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelWorkDetails.ColumnCount = 3;
            this.panelWorkDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.panelWorkDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelWorkDetails.Controls.Add(this.label3, 0, 0);
            this.panelWorkDetails.Controls.Add(this.label4, 0, 1);
            this.panelWorkDetails.Controls.Add(this.label5, 0, 2);
            this.panelWorkDetails.Controls.Add(this.labWorkDetails, 1, 1);
            this.panelWorkDetails.Controls.Add(this.labWorkName, 1, 0);
            this.panelWorkDetails.Controls.Add(this.label7, 1, 2);
            this.panelWorkDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkDetails.Location = new System.Drawing.Point(3, 41);
            this.panelWorkDetails.Name = "panelWorkDetails";
            this.panelWorkDetails.RowCount = 3;
            this.panelWorkDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelWorkDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelWorkDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelWorkDetails.Size = new System.Drawing.Size(759, 73);
            this.panelWorkDetails.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Назва твору:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 25);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Автори:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(4, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Виконавці:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labWorkDetails
            // 
            this.labWorkDetails.AutoSize = true;
            this.labWorkDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labWorkDetails.Location = new System.Drawing.Point(97, 25);
            this.labWorkDetails.Name = "labWorkDetails";
            this.labWorkDetails.Padding = new System.Windows.Forms.Padding(5);
            this.labWorkDetails.Size = new System.Drawing.Size(647, 23);
            this.labWorkDetails.TabIndex = 3;
            // 
            // labWorkName
            // 
            this.labWorkName.AutoSize = true;
            this.labWorkName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labWorkName.Location = new System.Drawing.Point(97, 1);
            this.labWorkName.Name = "labWorkName";
            this.labWorkName.Padding = new System.Windows.Forms.Padding(5);
            this.labWorkName.Size = new System.Drawing.Size(647, 23);
            this.labWorkName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(97, 49);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5);
            this.label7.Size = new System.Drawing.Size(647, 23);
            this.label7.TabIndex = 5;
            // 
            // panelMainMiddleRight
            // 
            this.panelMainMiddleRight.ColumnCount = 1;
            this.panelMainMiddleRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMainMiddleRight.Controls.Add(this.label6, 0, 0);
            this.panelMainMiddleRight.Controls.Add(this.wbResourceMetaData, 0, 1);
            this.panelMainMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainMiddleRight.Location = new System.Drawing.Point(0, 0);
            this.panelMainMiddleRight.Name = "panelMainMiddleRight";
            this.panelMainMiddleRight.RowCount = 3;
            this.panelMainMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMainMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMainMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelMainMiddleRight.Size = new System.Drawing.Size(502, 360);
            this.panelMainMiddleRight.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Означення творів в розрізі звітів";
            // 
            // wbResourceMetaData
            // 
            this.wbResourceMetaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbResourceMetaData.Location = new System.Drawing.Point(3, 36);
            this.wbResourceMetaData.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbResourceMetaData.Name = "wbResourceMetaData";
            this.wbResourceMetaData.Size = new System.Drawing.Size(496, 311);
            this.wbResourceMetaData.TabIndex = 1;
            // 
            // UcDspResourceAnalyser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcDspResourceAnalyser";
            this.Size = new System.Drawing.Size(765, 493);
            this.Load += new System.EventHandler(this.UcDspResourceAnalyser_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.labWorkPerformers.ResumeLayout(false);
            this.labWorkPerformers.PerformLayout();
            this.panelMainMiddle.Panel1.ResumeLayout(false);
            this.panelMainMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMainMiddle)).EndInit();
            this.panelMainMiddle.ResumeLayout(false);
            this.panelMainMiddleLeft.ResumeLayout(false);
            this.panelMainMiddleLeft.PerformLayout();
            this.panelWorkDetails.ResumeLayout(false);
            this.panelWorkDetails.PerformLayout();
            this.panelMainMiddleRight.ResumeLayout(false);
            this.panelMainMiddleRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel labWorkPerformers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.SplitContainer panelMainMiddle;
        private System.Windows.Forms.TableLayoutPanel panelMainMiddleLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvDspResources;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.TableLayoutPanel panelWorkDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labWorkDetails;
        private System.Windows.Forms.Label labWorkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel panelMainMiddleRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.WebBrowser wbResourceMetaData;
    }
}
