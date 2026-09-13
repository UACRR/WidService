namespace ShareCalc
{
    partial class FormIpiRhSearch
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
            this.panelTblMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSplitMain = new System.Windows.Forms.SplitContainer();
            this.panelTblRhMs = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lvRhMs = new System.Windows.Forms.ListView();
            this.panelTblRhFound = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvRhIpi = new System.Windows.Forms.ListView();
            this.panelFlowFilterRhIpi = new System.Windows.Forms.FlowLayoutPanel();
            this.tbRhIpiFilterName = new System.Windows.Forms.TextBox();
            this.tbRhIpiFilterFstName = new System.Windows.Forms.TextBox();
            this.tbRhIpiFilterSurName = new System.Windows.Forms.TextBox();
            this.btnRhIpiSearch = new System.Windows.Forms.Button();
            this.panelFlowRhMsFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panelTblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitMain)).BeginInit();
            this.panelSplitMain.Panel1.SuspendLayout();
            this.panelSplitMain.Panel2.SuspendLayout();
            this.panelSplitMain.SuspendLayout();
            this.panelTblRhMs.SuspendLayout();
            this.panelTblRhFound.SuspendLayout();
            this.panelFlowFilterRhIpi.SuspendLayout();
            this.panelFlowRhMsFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTblMain
            // 
            this.panelTblMain.ColumnCount = 1;
            this.panelTblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.Controls.Add(this.panelSplitMain, 0, 0);
            this.panelTblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblMain.Location = new System.Drawing.Point(0, 0);
            this.panelTblMain.Name = "panelTblMain";
            this.panelTblMain.RowCount = 2;
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelTblMain.Size = new System.Drawing.Size(800, 450);
            this.panelTblMain.TabIndex = 0;
            // 
            // panelSplitMain
            // 
            this.panelSplitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitMain.Location = new System.Drawing.Point(3, 3);
            this.panelSplitMain.Name = "panelSplitMain";
            this.panelSplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelSplitMain.Panel1
            // 
            this.panelSplitMain.Panel1.Controls.Add(this.panelTblRhMs);
            // 
            // panelSplitMain.Panel2
            // 
            this.panelSplitMain.Panel2.Controls.Add(this.panelTblRhFound);
            this.panelSplitMain.Size = new System.Drawing.Size(794, 409);
            this.panelSplitMain.SplitterDistance = 199;
            this.panelSplitMain.TabIndex = 0;
            // 
            // panelTblRhMs
            // 
            this.panelTblRhMs.ColumnCount = 1;
            this.panelTblRhMs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblRhMs.Controls.Add(this.label1, 0, 0);
            this.panelTblRhMs.Controls.Add(this.lvRhMs, 0, 2);
            this.panelTblRhMs.Controls.Add(this.panelFlowRhMsFilter, 0, 1);
            this.panelTblRhMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblRhMs.Location = new System.Drawing.Point(0, 0);
            this.panelTblRhMs.Name = "panelTblRhMs";
            this.panelTblRhMs.RowCount = 3;
            this.panelTblRhMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelTblRhMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblRhMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblRhMs.Size = new System.Drawing.Size(794, 199);
            this.panelTblRhMs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(321, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Правовласники СМАРТ, для яких не вказані міжнародні кодм";
            // 
            // lvRhMs
            // 
            this.lvRhMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRhMs.HideSelection = false;
            this.lvRhMs.Location = new System.Drawing.Point(3, 68);
            this.lvRhMs.Name = "lvRhMs";
            this.lvRhMs.Size = new System.Drawing.Size(788, 128);
            this.lvRhMs.TabIndex = 1;
            this.lvRhMs.UseCompatibleStateImageBehavior = false;
            this.lvRhMs.SelectedIndexChanged += new System.EventHandler(this.lvRhMs_SelectedIndexChanged);
            // 
            // panelTblRhFound
            // 
            this.panelTblRhFound.ColumnCount = 1;
            this.panelTblRhFound.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblRhFound.Controls.Add(this.label2, 0, 0);
            this.panelTblRhFound.Controls.Add(this.lvRhIpi, 0, 2);
            this.panelTblRhFound.Controls.Add(this.panelFlowFilterRhIpi, 0, 1);
            this.panelTblRhFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblRhFound.Location = new System.Drawing.Point(0, 0);
            this.panelTblRhFound.Name = "panelTblRhFound";
            this.panelTblRhFound.RowCount = 3;
            this.panelTblRhFound.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelTblRhFound.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelTblRhFound.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblRhFound.Size = new System.Drawing.Size(794, 206);
            this.panelTblRhFound.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(158, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Знайдені правовласники в IPI";
            // 
            // lvRhIpi
            // 
            this.lvRhIpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRhIpi.HideSelection = false;
            this.lvRhIpi.Location = new System.Drawing.Point(3, 68);
            this.lvRhIpi.Name = "lvRhIpi";
            this.lvRhIpi.Size = new System.Drawing.Size(788, 135);
            this.lvRhIpi.TabIndex = 1;
            this.lvRhIpi.UseCompatibleStateImageBehavior = false;
            // 
            // panelFlowFilterRhIpi
            // 
            this.panelFlowFilterRhIpi.Controls.Add(this.tbRhIpiFilterName);
            this.panelFlowFilterRhIpi.Controls.Add(this.tbRhIpiFilterFstName);
            this.panelFlowFilterRhIpi.Controls.Add(this.tbRhIpiFilterSurName);
            this.panelFlowFilterRhIpi.Controls.Add(this.btnRhIpiSearch);
            this.panelFlowFilterRhIpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowFilterRhIpi.Location = new System.Drawing.Point(3, 33);
            this.panelFlowFilterRhIpi.Name = "panelFlowFilterRhIpi";
            this.panelFlowFilterRhIpi.Size = new System.Drawing.Size(788, 29);
            this.panelFlowFilterRhIpi.TabIndex = 2;
            // 
            // tbRhIpiFilterName
            // 
            this.tbRhIpiFilterName.Location = new System.Drawing.Point(3, 3);
            this.tbRhIpiFilterName.Name = "tbRhIpiFilterName";
            this.tbRhIpiFilterName.Size = new System.Drawing.Size(134, 20);
            this.tbRhIpiFilterName.TabIndex = 0;
            // 
            // tbRhIpiFilterFstName
            // 
            this.tbRhIpiFilterFstName.Location = new System.Drawing.Point(143, 3);
            this.tbRhIpiFilterFstName.Name = "tbRhIpiFilterFstName";
            this.tbRhIpiFilterFstName.Size = new System.Drawing.Size(140, 20);
            this.tbRhIpiFilterFstName.TabIndex = 0;
            // 
            // tbRhIpiFilterSurName
            // 
            this.tbRhIpiFilterSurName.Location = new System.Drawing.Point(289, 3);
            this.tbRhIpiFilterSurName.Name = "tbRhIpiFilterSurName";
            this.tbRhIpiFilterSurName.Size = new System.Drawing.Size(140, 20);
            this.tbRhIpiFilterSurName.TabIndex = 0;
            // 
            // btnRhIpiSearch
            // 
            this.btnRhIpiSearch.Location = new System.Drawing.Point(435, 3);
            this.btnRhIpiSearch.Name = "btnRhIpiSearch";
            this.btnRhIpiSearch.Size = new System.Drawing.Size(113, 23);
            this.btnRhIpiSearch.TabIndex = 1;
            this.btnRhIpiSearch.Text = "Шукати";
            this.btnRhIpiSearch.UseVisualStyleBackColor = true;
            this.btnRhIpiSearch.Click += new System.EventHandler(this.btnRhIpiSearch_Click);
            // 
            // panelFlowRhMsFilter
            // 
            this.panelFlowRhMsFilter.Controls.Add(this.label3);
            this.panelFlowRhMsFilter.Controls.Add(this.comboBox2);
            this.panelFlowRhMsFilter.Controls.Add(this.label4);
            this.panelFlowRhMsFilter.Controls.Add(this.comboBox1);
            this.panelFlowRhMsFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowRhMsFilter.Location = new System.Drawing.Point(3, 33);
            this.panelFlowRhMsFilter.Name = "panelFlowRhMsFilter";
            this.panelFlowRhMsFilter.Size = new System.Drawing.Size(788, 29);
            this.panelFlowRhMsFilter.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(238, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Показа правовласників із статусом договору";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "і поширенням на";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(471, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(247, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // FormIpiRhSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTblMain);
            this.Name = "FormIpiRhSearch";
            this.Text = "Пошук міжнародних кодів правовласників";
            this.Load += new System.EventHandler(this.FormIpiRhSearch_Load);
            this.panelTblMain.ResumeLayout(false);
            this.panelSplitMain.Panel1.ResumeLayout(false);
            this.panelSplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitMain)).EndInit();
            this.panelSplitMain.ResumeLayout(false);
            this.panelTblRhMs.ResumeLayout(false);
            this.panelTblRhMs.PerformLayout();
            this.panelTblRhFound.ResumeLayout(false);
            this.panelTblRhFound.PerformLayout();
            this.panelFlowFilterRhIpi.ResumeLayout(false);
            this.panelFlowFilterRhIpi.PerformLayout();
            this.panelFlowRhMsFilter.ResumeLayout(false);
            this.panelFlowRhMsFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelTblMain;
        private System.Windows.Forms.SplitContainer panelSplitMain;
        private System.Windows.Forms.TableLayoutPanel panelTblRhMs;
        private System.Windows.Forms.TableLayoutPanel panelTblRhFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvRhMs;
        private System.Windows.Forms.ListView lvRhIpi;
        private System.Windows.Forms.FlowLayoutPanel panelFlowFilterRhIpi;
        private System.Windows.Forms.TextBox tbRhIpiFilterName;
        private System.Windows.Forms.TextBox tbRhIpiFilterFstName;
        private System.Windows.Forms.Button btnRhIpiSearch;
        private System.Windows.Forms.TextBox tbRhIpiFilterSurName;
        private System.Windows.Forms.FlowLayoutPanel panelFlowRhMsFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}