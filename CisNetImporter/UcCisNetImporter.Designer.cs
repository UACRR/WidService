namespace CisNetImporter
{
    partial class UcCisNetImporter
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
            this.splitPanelImage = new System.Windows.Forms.SplitContainer();
            this.panelImage = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelScrollImage = new System.Windows.Forms.Panel();
            this.pbScreenFragment = new System.Windows.Forms.PictureBox();
            this.splitPanelText = new System.Windows.Forms.SplitContainer();
            this.panelRawText = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRawText = new System.Windows.Forms.TextBox();
            this.panelProcessedData = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelWorkInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWorkName = new System.Windows.Forms.TextBox();
            this.tbWorkIswc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvRightHolders = new System.Windows.Forms.ListView();
            this.panelActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnPasteFragment = new System.Windows.Forms.Button();
            this.btnProcessFragment = new System.Windows.Forms.Button();
            this.btnProcessText = new System.Windows.Forms.Button();
            this.btnImportToMs = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelImage)).BeginInit();
            this.splitPanelImage.Panel1.SuspendLayout();
            this.splitPanelImage.Panel2.SuspendLayout();
            this.splitPanelImage.SuspendLayout();
            this.panelImage.SuspendLayout();
            this.panelScrollImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenFragment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelText)).BeginInit();
            this.splitPanelText.Panel1.SuspendLayout();
            this.splitPanelText.Panel2.SuspendLayout();
            this.splitPanelText.SuspendLayout();
            this.panelRawText.SuspendLayout();
            this.panelProcessedData.SuspendLayout();
            this.panelWorkInfo.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.panelMain.Controls.Add(this.splitPanelImage, 0, 0);
            this.panelMain.Controls.Add(this.panelActions, 1, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 1;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1070, 628);
            this.panelMain.TabIndex = 0;
            // 
            // splitPanelImage
            // 
            this.splitPanelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanelImage.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitPanelImage.Location = new System.Drawing.Point(3, 3);
            this.splitPanelImage.Name = "splitPanelImage";
            this.splitPanelImage.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitPanelImage.Panel1
            // 
            this.splitPanelImage.Panel1.Controls.Add(this.panelImage);
            // 
            // splitPanelImage.Panel2
            // 
            this.splitPanelImage.Panel2.Controls.Add(this.splitPanelText);
            this.splitPanelImage.Size = new System.Drawing.Size(905, 622);
            this.splitPanelImage.SplitterDistance = 182;
            this.splitPanelImage.TabIndex = 0;
            // 
            // panelImage
            // 
            this.panelImage.ColumnCount = 1;
            this.panelImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelImage.Controls.Add(this.label1, 0, 0);
            this.panelImage.Controls.Add(this.panelScrollImage, 0, 1);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage.Location = new System.Drawing.Point(0, 0);
            this.panelImage.Name = "panelImage";
            this.panelImage.RowCount = 2;
            this.panelImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelImage.Size = new System.Drawing.Size(905, 182);
            this.panelImage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(899, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фрагмент екрану";
            // 
            // panelScrollImage
            // 
            this.panelScrollImage.AutoScroll = true;
            this.panelScrollImage.Controls.Add(this.pbScreenFragment);
            this.panelScrollImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScrollImage.Location = new System.Drawing.Point(3, 33);
            this.panelScrollImage.Name = "panelScrollImage";
            this.panelScrollImage.Size = new System.Drawing.Size(899, 146);
            this.panelScrollImage.TabIndex = 1;
            // 
            // pbScreenFragment
            // 
            this.pbScreenFragment.Location = new System.Drawing.Point(3, 13);
            this.pbScreenFragment.Name = "pbScreenFragment";
            this.pbScreenFragment.Size = new System.Drawing.Size(871, 130);
            this.pbScreenFragment.TabIndex = 1;
            this.pbScreenFragment.TabStop = false;
            // 
            // splitPanelText
            // 
            this.splitPanelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPanelText.Location = new System.Drawing.Point(0, 0);
            this.splitPanelText.Name = "splitPanelText";
            this.splitPanelText.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitPanelText.Panel1
            // 
            this.splitPanelText.Panel1.Controls.Add(this.panelRawText);
            // 
            // splitPanelText.Panel2
            // 
            this.splitPanelText.Panel2.Controls.Add(this.panelProcessedData);
            this.splitPanelText.Size = new System.Drawing.Size(905, 436);
            this.splitPanelText.SplitterDistance = 219;
            this.splitPanelText.TabIndex = 0;
            // 
            // panelRawText
            // 
            this.panelRawText.ColumnCount = 1;
            this.panelRawText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRawText.Controls.Add(this.label2, 0, 0);
            this.panelRawText.Controls.Add(this.tbRawText, 0, 1);
            this.panelRawText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRawText.Location = new System.Drawing.Point(0, 0);
            this.panelRawText.Name = "panelRawText";
            this.panelRawText.RowCount = 2;
            this.panelRawText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelRawText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRawText.Size = new System.Drawing.Size(905, 219);
            this.panelRawText.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(899, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Текст з фрагменту екрану";
            // 
            // tbRawText
            // 
            this.tbRawText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRawText.Location = new System.Drawing.Point(3, 33);
            this.tbRawText.Multiline = true;
            this.tbRawText.Name = "tbRawText";
            this.tbRawText.ReadOnly = true;
            this.tbRawText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRawText.Size = new System.Drawing.Size(899, 183);
            this.tbRawText.TabIndex = 1;
            // 
            // panelProcessedData
            // 
            this.panelProcessedData.ColumnCount = 1;
            this.panelProcessedData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelProcessedData.Controls.Add(this.label3, 0, 0);
            this.panelProcessedData.Controls.Add(this.panelWorkInfo, 0, 1);
            this.panelProcessedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProcessedData.Location = new System.Drawing.Point(0, 0);
            this.panelProcessedData.Name = "panelProcessedData";
            this.panelProcessedData.RowCount = 2;
            this.panelProcessedData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelProcessedData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelProcessedData.Size = new System.Drawing.Size(905, 213);
            this.panelProcessedData.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(899, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Інформація для передачі в СМАРТ";
            // 
            // panelWorkInfo
            // 
            this.panelWorkInfo.ColumnCount = 3;
            this.panelWorkInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.panelWorkInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.panelWorkInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkInfo.Controls.Add(this.label4, 0, 0);
            this.panelWorkInfo.Controls.Add(this.label5, 0, 1);
            this.panelWorkInfo.Controls.Add(this.tbWorkName, 1, 0);
            this.panelWorkInfo.Controls.Add(this.tbWorkIswc, 1, 1);
            this.panelWorkInfo.Controls.Add(this.label6, 0, 2);
            this.panelWorkInfo.Controls.Add(this.lvRightHolders, 1, 2);
            this.panelWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkInfo.Location = new System.Drawing.Point(3, 33);
            this.panelWorkInfo.Name = "panelWorkInfo";
            this.panelWorkInfo.RowCount = 3;
            this.panelWorkInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelWorkInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.panelWorkInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkInfo.Size = new System.Drawing.Size(899, 177);
            this.panelWorkInfo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Назва твору";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 28);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Код ISWC";
            // 
            // tbWorkName
            // 
            this.tbWorkName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWorkName.Location = new System.Drawing.Point(96, 3);
            this.tbWorkName.Name = "tbWorkName";
            this.tbWorkName.ReadOnly = true;
            this.tbWorkName.Size = new System.Drawing.Size(264, 20);
            this.tbWorkName.TabIndex = 2;
            // 
            // tbWorkIswc
            // 
            this.tbWorkIswc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWorkIswc.Location = new System.Drawing.Point(96, 31);
            this.tbWorkIswc.Name = "tbWorkIswc";
            this.tbWorkIswc.ReadOnly = true;
            this.tbWorkIswc.Size = new System.Drawing.Size(264, 20);
            this.tbWorkIswc.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Правовласники";
            // 
            // lvRightHolders
            // 
            this.panelWorkInfo.SetColumnSpan(this.lvRightHolders, 2);
            this.lvRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRightHolders.HideSelection = false;
            this.lvRightHolders.Location = new System.Drawing.Point(96, 58);
            this.lvRightHolders.Name = "lvRightHolders";
            this.lvRightHolders.Size = new System.Drawing.Size(800, 116);
            this.lvRightHolders.TabIndex = 3;
            this.lvRightHolders.UseCompatibleStateImageBehavior = false;
            // 
            // panelActions
            // 
            this.panelActions.ColumnCount = 1;
            this.panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelActions.Controls.Add(this.btnPasteFragment, 0, 0);
            this.panelActions.Controls.Add(this.btnProcessFragment, 0, 1);
            this.panelActions.Controls.Add(this.btnProcessText, 0, 2);
            this.panelActions.Controls.Add(this.btnImportToMs, 0, 3);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActions.Location = new System.Drawing.Point(914, 3);
            this.panelActions.Name = "panelActions";
            this.panelActions.RowCount = 5;
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.panelActions.Size = new System.Drawing.Size(153, 622);
            this.panelActions.TabIndex = 1;
            // 
            // btnPasteFragment
            // 
            this.btnPasteFragment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPasteFragment.Location = new System.Drawing.Point(3, 3);
            this.btnPasteFragment.Name = "btnPasteFragment";
            this.btnPasteFragment.Size = new System.Drawing.Size(147, 24);
            this.btnPasteFragment.TabIndex = 0;
            this.btnPasteFragment.Text = "Вставити фрагмент";
            this.btnPasteFragment.UseVisualStyleBackColor = true;
            this.btnPasteFragment.Click += new System.EventHandler(this.btnPasteFragment_Click);
            // 
            // btnProcessFragment
            // 
            this.btnProcessFragment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcessFragment.Location = new System.Drawing.Point(3, 33);
            this.btnProcessFragment.Name = "btnProcessFragment";
            this.btnProcessFragment.Size = new System.Drawing.Size(147, 24);
            this.btnProcessFragment.TabIndex = 1;
            this.btnProcessFragment.Text = "Знайти текст";
            this.btnProcessFragment.UseVisualStyleBackColor = true;
            this.btnProcessFragment.Click += new System.EventHandler(this.btnProcessFragment_Click);
            // 
            // btnProcessText
            // 
            this.btnProcessText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcessText.Location = new System.Drawing.Point(3, 63);
            this.btnProcessText.Name = "btnProcessText";
            this.btnProcessText.Size = new System.Drawing.Size(147, 24);
            this.btnProcessText.TabIndex = 1;
            this.btnProcessText.Text = "Обробити текст";
            this.btnProcessText.UseVisualStyleBackColor = true;
            this.btnProcessText.Click += new System.EventHandler(this.btnProcessText_Click);
            // 
            // btnImportToMs
            // 
            this.btnImportToMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportToMs.Location = new System.Drawing.Point(3, 93);
            this.btnImportToMs.Name = "btnImportToMs";
            this.btnImportToMs.Size = new System.Drawing.Size(147, 24);
            this.btnImportToMs.TabIndex = 1;
            this.btnImportToMs.Text = "Передати в СМАРТ";
            this.btnImportToMs.UseVisualStyleBackColor = true;
            // 
            // UcCisNetImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcCisNetImporter";
            this.Size = new System.Drawing.Size(1070, 628);
            this.panelMain.ResumeLayout(false);
            this.splitPanelImage.Panel1.ResumeLayout(false);
            this.splitPanelImage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelImage)).EndInit();
            this.splitPanelImage.ResumeLayout(false);
            this.panelImage.ResumeLayout(false);
            this.panelImage.PerformLayout();
            this.panelScrollImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenFragment)).EndInit();
            this.splitPanelText.Panel1.ResumeLayout(false);
            this.splitPanelText.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelText)).EndInit();
            this.splitPanelText.ResumeLayout(false);
            this.panelRawText.ResumeLayout(false);
            this.panelRawText.PerformLayout();
            this.panelProcessedData.ResumeLayout(false);
            this.panelProcessedData.PerformLayout();
            this.panelWorkInfo.ResumeLayout(false);
            this.panelWorkInfo.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer splitPanelImage;
        private System.Windows.Forms.SplitContainer splitPanelText;
        private System.Windows.Forms.TableLayoutPanel panelImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelRawText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel panelProcessedData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbScreenFragment;
        private System.Windows.Forms.TextBox tbRawText;
        private System.Windows.Forms.TableLayoutPanel panelActions;
        private System.Windows.Forms.Button btnPasteFragment;
        private System.Windows.Forms.Button btnProcessFragment;
        private System.Windows.Forms.Button btnProcessText;
        private System.Windows.Forms.Button btnImportToMs;
        private System.Windows.Forms.Panel panelScrollImage;
        private System.Windows.Forms.TableLayoutPanel panelWorkInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbWorkName;
        private System.Windows.Forms.TextBox tbWorkIswc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvRightHolders;
    }
}
