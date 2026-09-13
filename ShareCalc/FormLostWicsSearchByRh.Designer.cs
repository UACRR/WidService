namespace ShareCalc
{
    partial class FormLostWicsSearchByRh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLostWicsSearchByRh));
            this.panelTblMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSplitMain = new System.Windows.Forms.SplitContainer();
            this.lvRh = new System.Windows.Forms.ListView();
            this.panelSplitWorks = new System.Windows.Forms.SplitContainer();
            this.panelTblWorksWid = new System.Windows.Forms.TableLayoutPanel();
            this.lvWorksWid = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFlowRhWidWorksFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.rbShowAllWidWorks = new System.Windows.Forms.RadioButton();
            this.rbShowUnmatchedWidWorks = new System.Windows.Forms.RadioButton();
            this.panelTblWorksMs = new System.Windows.Forms.TableLayoutPanel();
            this.lvWorksMs = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFlowMsRhFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMsRhFilter = new System.Windows.Forms.TextBox();
            this.btnApplyMsRhFilter = new System.Windows.Forms.Button();
            this.panelFlowMsWorkFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMsWorkFilter = new System.Windows.Forms.TextBox();
            this.rbMsWorkFilterStarts = new System.Windows.Forms.RadioButton();
            this.rbMsWorkFilterContains = new System.Windows.Forms.RadioButton();
            this.panelFlowLetterReplce = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbWorkFilterLetterChange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFlowRhWidFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRhWidFilter = new System.Windows.Forms.TextBox();
            this.panelFlowRhWidFilter1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.rbRhWidFilterAll = new System.Windows.Forms.RadioButton();
            this.rbRhWidFilterUnprocessed = new System.Windows.Forms.RadioButton();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.panelTblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitMain)).BeginInit();
            this.panelSplitMain.Panel1.SuspendLayout();
            this.panelSplitMain.Panel2.SuspendLayout();
            this.panelSplitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitWorks)).BeginInit();
            this.panelSplitWorks.Panel1.SuspendLayout();
            this.panelSplitWorks.Panel2.SuspendLayout();
            this.panelSplitWorks.SuspendLayout();
            this.panelTblWorksWid.SuspendLayout();
            this.panelFlowRhWidWorksFilter.SuspendLayout();
            this.panelTblWorksMs.SuspendLayout();
            this.panelFlowMsRhFilter.SuspendLayout();
            this.panelFlowMsWorkFilter.SuspendLayout();
            this.panelFlowLetterReplce.SuspendLayout();
            this.panelFlowRhWidFilter.SuspendLayout();
            this.panelFlowRhWidFilter1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTblMain
            // 
            this.panelTblMain.ColumnCount = 1;
            this.panelTblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.Controls.Add(this.panelSplitMain, 0, 3);
            this.panelTblMain.Controls.Add(this.label1, 0, 0);
            this.panelTblMain.Controls.Add(this.panelFlowRhWidFilter, 0, 1);
            this.panelTblMain.Controls.Add(this.panelFlowRhWidFilter1, 0, 2);
            this.panelTblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblMain.Location = new System.Drawing.Point(0, 0);
            this.panelTblMain.Name = "panelTblMain";
            this.panelTblMain.RowCount = 5;
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelTblMain.Size = new System.Drawing.Size(1044, 565);
            this.panelTblMain.TabIndex = 0;
            // 
            // panelSplitMain
            // 
            this.panelSplitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitMain.Location = new System.Drawing.Point(3, 102);
            this.panelSplitMain.Name = "panelSplitMain";
            this.panelSplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelSplitMain.Panel1
            // 
            this.panelSplitMain.Panel1.Controls.Add(this.lvRh);
            // 
            // panelSplitMain.Panel2
            // 
            this.panelSplitMain.Panel2.Controls.Add(this.panelSplitWorks);
            this.panelSplitMain.Size = new System.Drawing.Size(1038, 430);
            this.panelSplitMain.SplitterDistance = 181;
            this.panelSplitMain.TabIndex = 0;
            // 
            // lvRh
            // 
            this.lvRh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRh.HideSelection = false;
            this.lvRh.Location = new System.Drawing.Point(0, 0);
            this.lvRh.Name = "lvRh";
            this.lvRh.Size = new System.Drawing.Size(1038, 181);
            this.lvRh.TabIndex = 0;
            this.lvRh.UseCompatibleStateImageBehavior = false;
            this.lvRh.SelectedIndexChanged += new System.EventHandler(this.lvRh_SelectedIndexChanged);
            this.lvRh.DoubleClick += new System.EventHandler(this.lvRh_DoubleClick);
            // 
            // panelSplitWorks
            // 
            this.panelSplitWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitWorks.Location = new System.Drawing.Point(0, 0);
            this.panelSplitWorks.Name = "panelSplitWorks";
            // 
            // panelSplitWorks.Panel1
            // 
            this.panelSplitWorks.Panel1.Controls.Add(this.panelTblWorksWid);
            // 
            // panelSplitWorks.Panel2
            // 
            this.panelSplitWorks.Panel2.Controls.Add(this.panelTblWorksMs);
            this.panelSplitWorks.Size = new System.Drawing.Size(1038, 245);
            this.panelSplitWorks.SplitterDistance = 485;
            this.panelSplitWorks.TabIndex = 0;
            // 
            // panelTblWorksWid
            // 
            this.panelTblWorksWid.ColumnCount = 1;
            this.panelTblWorksWid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblWorksWid.Controls.Add(this.lvWorksWid, 0, 2);
            this.panelTblWorksWid.Controls.Add(this.label2, 0, 0);
            this.panelTblWorksWid.Controls.Add(this.panelFlowRhWidWorksFilter, 0, 1);
            this.panelTblWorksWid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblWorksWid.Location = new System.Drawing.Point(0, 0);
            this.panelTblWorksWid.Name = "panelTblWorksWid";
            this.panelTblWorksWid.RowCount = 3;
            this.panelTblWorksWid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelTblWorksWid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelTblWorksWid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblWorksWid.Size = new System.Drawing.Size(485, 245);
            this.panelTblWorksWid.TabIndex = 0;
            // 
            // lvWorksWid
            // 
            this.lvWorksWid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorksWid.HideSelection = false;
            this.lvWorksWid.Location = new System.Drawing.Point(3, 63);
            this.lvWorksWid.Name = "lvWorksWid";
            this.lvWorksWid.Size = new System.Drawing.Size(479, 179);
            this.lvWorksWid.TabIndex = 0;
            this.lvWorksWid.UseCompatibleStateImageBehavior = false;
            this.lvWorksWid.SelectedIndexChanged += new System.EventHandler(this.lvWorksWid_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(253, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Загублені твори обраного правовласника в WID";
            // 
            // panelFlowRhWidWorksFilter
            // 
            this.panelFlowRhWidWorksFilter.Controls.Add(this.rbShowAllWidWorks);
            this.panelFlowRhWidWorksFilter.Controls.Add(this.rbShowUnmatchedWidWorks);
            this.panelFlowRhWidWorksFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowRhWidWorksFilter.Location = new System.Drawing.Point(3, 33);
            this.panelFlowRhWidWorksFilter.Name = "panelFlowRhWidWorksFilter";
            this.panelFlowRhWidWorksFilter.Size = new System.Drawing.Size(479, 24);
            this.panelFlowRhWidWorksFilter.TabIndex = 2;
            // 
            // rbShowAllWidWorks
            // 
            this.rbShowAllWidWorks.AutoSize = true;
            this.rbShowAllWidWorks.Location = new System.Drawing.Point(3, 3);
            this.rbShowAllWidWorks.Name = "rbShowAllWidWorks";
            this.rbShowAllWidWorks.Size = new System.Drawing.Size(40, 17);
            this.rbShowAllWidWorks.TabIndex = 0;
            this.rbShowAllWidWorks.Text = "Всі";
            this.rbShowAllWidWorks.UseVisualStyleBackColor = true;
            this.rbShowAllWidWorks.CheckedChanged += new System.EventHandler(this.rbShowAllWidWorks_CheckedChanged);
            // 
            // rbShowUnmatchedWidWorks
            // 
            this.rbShowUnmatchedWidWorks.AutoSize = true;
            this.rbShowUnmatchedWidWorks.Checked = true;
            this.rbShowUnmatchedWidWorks.Location = new System.Drawing.Point(49, 3);
            this.rbShowUnmatchedWidWorks.Name = "rbShowUnmatchedWidWorks";
            this.rbShowUnmatchedWidWorks.Size = new System.Drawing.Size(261, 17);
            this.rbShowUnmatchedWidWorks.TabIndex = 0;
            this.rbShowUnmatchedWidWorks.TabStop = true;
            this.rbShowUnmatchedWidWorks.Text = "У яких не встановлена відповідність із СМАРТ";
            this.rbShowUnmatchedWidWorks.UseVisualStyleBackColor = true;
            this.rbShowUnmatchedWidWorks.CheckedChanged += new System.EventHandler(this.rbShowUnmatchedWidWorks_CheckedChanged);
            // 
            // panelTblWorksMs
            // 
            this.panelTblWorksMs.ColumnCount = 1;
            this.panelTblWorksMs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblWorksMs.Controls.Add(this.lvWorksMs, 0, 4);
            this.panelTblWorksMs.Controls.Add(this.label3, 0, 0);
            this.panelTblWorksMs.Controls.Add(this.panelFlowMsRhFilter, 0, 1);
            this.panelTblWorksMs.Controls.Add(this.panelFlowMsWorkFilter, 0, 2);
            this.panelTblWorksMs.Controls.Add(this.panelFlowLetterReplce, 0, 3);
            this.panelTblWorksMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblWorksMs.Location = new System.Drawing.Point(0, 0);
            this.panelTblWorksMs.Name = "panelTblWorksMs";
            this.panelTblWorksMs.RowCount = 5;
            this.panelTblWorksMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelTblWorksMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelTblWorksMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelTblWorksMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelTblWorksMs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblWorksMs.Size = new System.Drawing.Size(549, 245);
            this.panelTblWorksMs.TabIndex = 0;
            // 
            // lvWorksMs
            // 
            this.lvWorksMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorksMs.HideSelection = false;
            this.lvWorksMs.Location = new System.Drawing.Point(3, 137);
            this.lvWorksMs.Name = "lvWorksMs";
            this.lvWorksMs.Size = new System.Drawing.Size(543, 105);
            this.lvWorksMs.TabIndex = 0;
            this.lvWorksMs.UseCompatibleStateImageBehavior = false;
            this.lvWorksMs.DoubleClick += new System.EventHandler(this.lvWorksMs_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(186, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Пошук відповідного твору в СМАРТ";
            // 
            // panelFlowMsRhFilter
            // 
            this.panelFlowMsRhFilter.Controls.Add(this.label4);
            this.panelFlowMsRhFilter.Controls.Add(this.tbMsRhFilter);
            this.panelFlowMsRhFilter.Controls.Add(this.btnApplyMsRhFilter);
            this.panelFlowMsRhFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowMsRhFilter.Location = new System.Drawing.Point(3, 33);
            this.panelFlowMsRhFilter.Name = "panelFlowMsRhFilter";
            this.panelFlowMsRhFilter.Size = new System.Drawing.Size(543, 28);
            this.panelFlowMsRhFilter.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(181, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Частина прізвища правовласника";
            // 
            // tbMsRhFilter
            // 
            this.tbMsRhFilter.Location = new System.Drawing.Point(190, 3);
            this.tbMsRhFilter.Name = "tbMsRhFilter";
            this.tbMsRhFilter.Size = new System.Drawing.Size(156, 20);
            this.tbMsRhFilter.TabIndex = 1;
            // 
            // btnApplyMsRhFilter
            // 
            this.btnApplyMsRhFilter.Location = new System.Drawing.Point(352, 3);
            this.btnApplyMsRhFilter.Name = "btnApplyMsRhFilter";
            this.btnApplyMsRhFilter.Size = new System.Drawing.Size(162, 23);
            this.btnApplyMsRhFilter.TabIndex = 2;
            this.btnApplyMsRhFilter.Text = "Показати твори";
            this.btnApplyMsRhFilter.UseVisualStyleBackColor = true;
            this.btnApplyMsRhFilter.Click += new System.EventHandler(this.btnApplyMsRhFilter_Click);
            // 
            // panelFlowMsWorkFilter
            // 
            this.panelFlowMsWorkFilter.Controls.Add(this.label5);
            this.panelFlowMsWorkFilter.Controls.Add(this.tbMsWorkFilter);
            this.panelFlowMsWorkFilter.Controls.Add(this.rbMsWorkFilterStarts);
            this.panelFlowMsWorkFilter.Controls.Add(this.rbMsWorkFilterContains);
            this.panelFlowMsWorkFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowMsWorkFilter.Location = new System.Drawing.Point(3, 67);
            this.panelFlowMsWorkFilter.Name = "panelFlowMsWorkFilter";
            this.panelFlowMsWorkFilter.Size = new System.Drawing.Size(543, 30);
            this.panelFlowMsWorkFilter.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Назва твору";
            // 
            // tbMsWorkFilter
            // 
            this.tbMsWorkFilter.Location = new System.Drawing.Point(79, 3);
            this.tbMsWorkFilter.Name = "tbMsWorkFilter";
            this.tbMsWorkFilter.Size = new System.Drawing.Size(100, 20);
            this.tbMsWorkFilter.TabIndex = 1;
            this.tbMsWorkFilter.TextChanged += new System.EventHandler(this.tbMsWorkFilter_TextChanged);
            // 
            // rbMsWorkFilterStarts
            // 
            this.rbMsWorkFilterStarts.AutoSize = true;
            this.rbMsWorkFilterStarts.Location = new System.Drawing.Point(185, 3);
            this.rbMsWorkFilterStarts.Name = "rbMsWorkFilterStarts";
            this.rbMsWorkFilterStarts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbMsWorkFilterStarts.Size = new System.Drawing.Size(151, 17);
            this.rbMsWorkFilterStarts.TabIndex = 2;
            this.rbMsWorkFilterStarts.TabStop = true;
            this.rbMsWorkFilterStarts.Text = "містить текст на початку";
            this.rbMsWorkFilterStarts.UseVisualStyleBackColor = true;
            // 
            // rbMsWorkFilterContains
            // 
            this.rbMsWorkFilterContains.AutoSize = true;
            this.rbMsWorkFilterContains.Location = new System.Drawing.Point(342, 3);
            this.rbMsWorkFilterContains.Name = "rbMsWorkFilterContains";
            this.rbMsWorkFilterContains.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbMsWorkFilterContains.Size = new System.Drawing.Size(63, 17);
            this.rbMsWorkFilterContains.TabIndex = 2;
            this.rbMsWorkFilterContains.TabStop = true;
            this.rbMsWorkFilterContains.Text = "будь де";
            this.rbMsWorkFilterContains.UseVisualStyleBackColor = true;
            // 
            // panelFlowLetterReplce
            // 
            this.panelFlowLetterReplce.Controls.Add(this.label7);
            this.panelFlowLetterReplce.Controls.Add(this.cbWorkFilterLetterChange);
            this.panelFlowLetterReplce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowLetterReplce.Location = new System.Drawing.Point(3, 103);
            this.panelFlowLetterReplce.Name = "panelFlowLetterReplce";
            this.panelFlowLetterReplce.Size = new System.Drawing.Size(543, 28);
            this.panelFlowLetterReplce.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Заміна тексту";
            // 
            // cbWorkFilterLetterChange
            // 
            this.cbWorkFilterLetterChange.FormattingEnabled = true;
            this.cbWorkFilterLetterChange.Location = new System.Drawing.Point(87, 3);
            this.cbWorkFilterLetterChange.Name = "cbWorkFilterLetterChange";
            this.cbWorkFilterLetterChange.Size = new System.Drawing.Size(167, 21);
            this.cbWorkFilterLetterChange.TabIndex = 1;
            this.cbWorkFilterLetterChange.SelectedValueChanged += new System.EventHandler(this.cbWorkFilterLetterChange_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Правовласники загублених творів";
            // 
            // panelFlowRhWidFilter
            // 
            this.panelFlowRhWidFilter.Controls.Add(this.label6);
            this.panelFlowRhWidFilter.Controls.Add(this.tbRhWidFilter);
            this.panelFlowRhWidFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowRhWidFilter.Location = new System.Drawing.Point(3, 33);
            this.panelFlowRhWidFilter.Name = "panelFlowRhWidFilter";
            this.panelFlowRhWidFilter.Size = new System.Drawing.Size(1038, 30);
            this.panelFlowRhWidFilter.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label6.Size = new System.Drawing.Size(232, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Показати за входженням тексту в прізвище";
            // 
            // tbRhWidFilter
            // 
            this.tbRhWidFilter.Location = new System.Drawing.Point(241, 3);
            this.tbRhWidFilter.Name = "tbRhWidFilter";
            this.tbRhWidFilter.Size = new System.Drawing.Size(100, 20);
            this.tbRhWidFilter.TabIndex = 1;
            this.tbRhWidFilter.TextChanged += new System.EventHandler(this.tbRhWidFilter_TextChanged);
            // 
            // panelFlowRhWidFilter1
            // 
            this.panelFlowRhWidFilter1.Controls.Add(this.label8);
            this.panelFlowRhWidFilter1.Controls.Add(this.rbRhWidFilterAll);
            this.panelFlowRhWidFilter1.Controls.Add(this.rbRhWidFilterUnprocessed);
            this.panelFlowRhWidFilter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlowRhWidFilter1.Location = new System.Drawing.Point(3, 69);
            this.panelFlowRhWidFilter1.Name = "panelFlowRhWidFilter1";
            this.panelFlowRhWidFilter1.Size = new System.Drawing.Size(1038, 27);
            this.panelFlowRhWidFilter1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label8.Size = new System.Drawing.Size(105, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "За станом обробки";
            // 
            // rbRhWidFilterAll
            // 
            this.rbRhWidFilterAll.AutoSize = true;
            this.rbRhWidFilterAll.Location = new System.Drawing.Point(114, 3);
            this.rbRhWidFilterAll.Name = "rbRhWidFilterAll";
            this.rbRhWidFilterAll.Size = new System.Drawing.Size(40, 17);
            this.rbRhWidFilterAll.TabIndex = 1;
            this.rbRhWidFilterAll.Text = "Всі";
            this.rbRhWidFilterAll.UseVisualStyleBackColor = true;
            this.rbRhWidFilterAll.CheckedChanged += new System.EventHandler(this.rbRhWidFilterAll_CheckedChanged);
            // 
            // rbRhWidFilterUnprocessed
            // 
            this.rbRhWidFilterUnprocessed.AutoSize = true;
            this.rbRhWidFilterUnprocessed.Checked = true;
            this.rbRhWidFilterUnprocessed.Location = new System.Drawing.Point(160, 3);
            this.rbRhWidFilterUnprocessed.Name = "rbRhWidFilterUnprocessed";
            this.rbRhWidFilterUnprocessed.Size = new System.Drawing.Size(89, 17);
            this.rbRhWidFilterUnprocessed.TabIndex = 1;
            this.rbRhWidFilterUnprocessed.TabStop = true;
            this.rbRhWidFilterUnprocessed.Text = "Необроблені";
            this.rbRhWidFilterUnprocessed.UseVisualStyleBackColor = true;
            this.rbRhWidFilterUnprocessed.CheckedChanged += new System.EventHandler(this.rbRhWidFilterUnprocessed_CheckedChanged);
            // 
            // ilStatuses
            // 
            this.ilStatuses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStatuses.ImageStream")));
            this.ilStatuses.TransparentColor = System.Drawing.Color.Transparent;
            this.ilStatuses.Images.SetKeyName(0, "angle-right-solid.ico");
            this.ilStatuses.Images.SetKeyName(1, "inprogress");
            this.ilStatuses.Images.SetKeyName(2, "completed");
            this.ilStatuses.Images.SetKeyName(3, "failed");
            this.ilStatuses.Images.SetKeyName(4, "pending");
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 565);
            this.Controls.Add(this.panelTblMain);
            this.Name = "Form";
            this.Text = "FormLostWicsSearchByRh";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelTblMain.ResumeLayout(false);
            this.panelTblMain.PerformLayout();
            this.panelSplitMain.Panel1.ResumeLayout(false);
            this.panelSplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitMain)).EndInit();
            this.panelSplitMain.ResumeLayout(false);
            this.panelSplitWorks.Panel1.ResumeLayout(false);
            this.panelSplitWorks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitWorks)).EndInit();
            this.panelSplitWorks.ResumeLayout(false);
            this.panelTblWorksWid.ResumeLayout(false);
            this.panelTblWorksWid.PerformLayout();
            this.panelFlowRhWidWorksFilter.ResumeLayout(false);
            this.panelFlowRhWidWorksFilter.PerformLayout();
            this.panelTblWorksMs.ResumeLayout(false);
            this.panelTblWorksMs.PerformLayout();
            this.panelFlowMsRhFilter.ResumeLayout(false);
            this.panelFlowMsRhFilter.PerformLayout();
            this.panelFlowMsWorkFilter.ResumeLayout(false);
            this.panelFlowMsWorkFilter.PerformLayout();
            this.panelFlowLetterReplce.ResumeLayout(false);
            this.panelFlowLetterReplce.PerformLayout();
            this.panelFlowRhWidFilter.ResumeLayout(false);
            this.panelFlowRhWidFilter.PerformLayout();
            this.panelFlowRhWidFilter1.ResumeLayout(false);
            this.panelFlowRhWidFilter1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelTblMain;
        private System.Windows.Forms.SplitContainer panelSplitMain;
        private System.Windows.Forms.SplitContainer panelSplitWorks;
        private System.Windows.Forms.TableLayoutPanel panelTblWorksWid;
        private System.Windows.Forms.TableLayoutPanel panelTblWorksMs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvRh;
        private System.Windows.Forms.ListView lvWorksWid;
        private System.Windows.Forms.ListView lvWorksMs;
        private System.Windows.Forms.FlowLayoutPanel panelFlowMsRhFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMsRhFilter;
        private System.Windows.Forms.Button btnApplyMsRhFilter;
        private System.Windows.Forms.FlowLayoutPanel panelFlowMsWorkFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMsWorkFilter;
        private System.Windows.Forms.RadioButton rbMsWorkFilterStarts;
        private System.Windows.Forms.RadioButton rbMsWorkFilterContains;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.FlowLayoutPanel panelFlowRhWidWorksFilter;
        private System.Windows.Forms.RadioButton rbShowAllWidWorks;
        private System.Windows.Forms.RadioButton rbShowUnmatchedWidWorks;
        private System.Windows.Forms.FlowLayoutPanel panelFlowRhWidFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRhWidFilter;
        private System.Windows.Forms.FlowLayoutPanel panelFlowLetterReplce;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbWorkFilterLetterChange;
        private System.Windows.Forms.FlowLayoutPanel panelFlowRhWidFilter1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbRhWidFilterAll;
        private System.Windows.Forms.RadioButton rbRhWidFilterUnprocessed;
    }
}