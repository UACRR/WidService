namespace WidSubmit
{
    partial class UcSubmWorks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSubmWorks));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.panelWorks = new System.Windows.Forms.SplitContainer();
            this.panelWorkList = new System.Windows.Forms.TableLayoutPanel();
            this.lvSubmWorks = new System.Windows.Forms.ListView();
            this.ilSubmWorkStatuses = new System.Windows.Forms.ImageList(this.components);
            this.ilSubmWorkSubStatuses = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panelFilterBySubmResult = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.rbFilterSubmittedNo = new System.Windows.Forms.RadioButton();
            this.rbFilterSubmittedYes = new System.Windows.Forms.RadioButton();
            this.rbFilterSubmittedAll = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.panelSubmWorkCount = new System.Windows.Forms.FlowLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSubmWorkCntTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSubmWorkCntSelected = new System.Windows.Forms.TextBox();
            this.panelFilterByStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFilterByStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSubmWorkExFilter = new System.Windows.Forms.TextBox();
            this.btnSubmWorkApplyExFilter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ilButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelWorkDetails = new System.Windows.Forms.TabControl();
            this.tabRightHolders = new System.Windows.Forms.TabPage();
            this.tabAltNames = new System.Windows.Forms.TabPage();
            this.tabPerformers = new System.Windows.Forms.TabPage();
            this.tabSubmProblems = new System.Windows.Forms.TabPage();
            this.tabRespProblems = new System.Windows.Forms.TabPage();
            this.tabRghtHoldersDiff = new System.Windows.Forms.TabPage();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timerUpdateContent = new System.Windows.Forms.Timer(this.components);
            this.ucSubmRightHolders = new WidSubmit.UcSubmRightHolders();
            this.ucSubmWorkShares = new WidSubmit.UcSubmWorkShares();
            this.ucSubmWorkAltNames = new WidSubmit.UcSubmWorkAltNames();
            this.ucSubmWorkPerformers = new WidSubmit.UcSubmWorkPerformers();
            this.ucSubmWorkCheckList = new WidSubmit.UcSubmWorkCheckList();
            this.ucSubmWorkRespErr = new WidSubmit.UcSubmWorkRespErr();
            this.ucSubmWorkSharesDiff = new WidSubmit.UcSubmWorkSharesDiff();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelWorks)).BeginInit();
            this.panelWorks.Panel1.SuspendLayout();
            this.panelWorks.Panel2.SuspendLayout();
            this.panelWorks.SuspendLayout();
            this.panelWorkList.SuspendLayout();
            this.panelFilterBySubmResult.SuspendLayout();
            this.panelSubmWorkCount.SuspendLayout();
            this.panelFilterByStatus.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelWorkDetails.SuspendLayout();
            this.tabRightHolders.SuspendLayout();
            this.tabAltNames.SuspendLayout();
            this.tabPerformers.SuspendLayout();
            this.tabSubmProblems.SuspendLayout();
            this.tabRespProblems.SuspendLayout();
            this.tabRghtHoldersDiff.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Controls.Add(this.label1, 0, 0);
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Size = new System.Drawing.Size(1139, 538);
            this.panelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(1128, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Опрацювання творів для публікації";
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMiddle.Location = new System.Drawing.Point(3, 29);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.ucSubmRightHolders);
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.panelWorks);
            this.panelMiddle.Size = new System.Drawing.Size(1128, 501);
            this.panelMiddle.SplitterDistance = 379;
            this.panelMiddle.TabIndex = 1;
            // 
            // panelWorks
            // 
            this.panelWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorks.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelWorks.Location = new System.Drawing.Point(0, 0);
            this.panelWorks.Name = "panelWorks";
            this.panelWorks.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelWorks.Panel1
            // 
            this.panelWorks.Panel1.Controls.Add(this.panelWorkList);
            // 
            // panelWorks.Panel2
            // 
            this.panelWorks.Panel2.Controls.Add(this.panelWorkDetails);
            this.panelWorks.Size = new System.Drawing.Size(745, 501);
            this.panelWorks.SplitterDistance = 262;
            this.panelWorks.TabIndex = 0;
            // 
            // panelWorkList
            // 
            this.panelWorkList.ColumnCount = 2;
            this.panelWorkList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelWorkList.Controls.Add(this.lvSubmWorks, 0, 4);
            this.panelWorkList.Controls.Add(this.label3, 0, 0);
            this.panelWorkList.Controls.Add(this.panelFilterBySubmResult, 0, 1);
            this.panelWorkList.Controls.Add(this.panelSubmWorkCount, 0, 6);
            this.panelWorkList.Controls.Add(this.panelFilterByStatus, 0, 2);
            this.panelWorkList.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.panelWorkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkList.Location = new System.Drawing.Point(0, 0);
            this.panelWorkList.Name = "panelWorkList";
            this.panelWorkList.RowCount = 7;
            this.panelWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.panelWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.panelWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.panelWorkList.Size = new System.Drawing.Size(745, 262);
            this.panelWorkList.TabIndex = 0;
            // 
            // lvSubmWorks
            // 
            this.lvSubmWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubmWorks.HideSelection = false;
            this.lvSubmWorks.Location = new System.Drawing.Point(3, 118);
            this.lvSubmWorks.Name = "lvSubmWorks";
            this.lvSubmWorks.Size = new System.Drawing.Size(734, 89);
            this.lvSubmWorks.SmallImageList = this.ilSubmWorkStatuses;
            this.lvSubmWorks.StateImageList = this.ilSubmWorkSubStatuses;
            this.lvSubmWorks.TabIndex = 0;
            this.lvSubmWorks.UseCompatibleStateImageBehavior = false;
            this.lvSubmWorks.SelectedIndexChanged += new System.EventHandler(this.lvSubmWorks_SelectedIndexChanged);
            this.lvSubmWorks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvSubmWorks_MouseDown);
            // 
            // ilSubmWorkStatuses
            // 
            this.ilSubmWorkStatuses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSubmWorkStatuses.ImageStream")));
            this.ilSubmWorkStatuses.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSubmWorkStatuses.Images.SetKeyName(0, "STATUS_NOT_READY.png");
            this.ilSubmWorkStatuses.Images.SetKeyName(1, "STATUS_READY.png");
            this.ilSubmWorkStatuses.Images.SetKeyName(2, "STATUS_SUBMITTED.png");
            this.ilSubmWorkStatuses.Images.SetKeyName(3, "STATUS_ACCEPTED.png");
            this.ilSubmWorkStatuses.Images.SetKeyName(4, "STATUS_ACCEPTED_WARNINGS.png");
            this.ilSubmWorkStatuses.Images.SetKeyName(5, "STATUS_REJECTED.png");
            this.ilSubmWorkStatuses.Images.SetKeyName(6, "STATUS_APPLIED.png");
            this.ilSubmWorkStatuses.Images.SetKeyName(7, "STATUS_COMPLETED.png");
            // 
            // ilSubmWorkSubStatuses
            // 
            this.ilSubmWorkSubStatuses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSubmWorkSubStatuses.ImageStream")));
            this.ilSubmWorkSubStatuses.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSubmWorkSubStatuses.Images.SetKeyName(0, "NEW.png");
            this.ilSubmWorkSubStatuses.Images.SetKeyName(1, "CHANGED.png");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(304, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Твори для публікації (вибрати за умовами нижче)\r\n";
            // 
            // panelFilterBySubmResult
            // 
            this.panelFilterBySubmResult.Controls.Add(this.label5);
            this.panelFilterBySubmResult.Controls.Add(this.rbFilterSubmittedNo);
            this.panelFilterBySubmResult.Controls.Add(this.rbFilterSubmittedYes);
            this.panelFilterBySubmResult.Controls.Add(this.rbFilterSubmittedAll);
            this.panelFilterBySubmResult.Controls.Add(this.label10);
            this.panelFilterBySubmResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilterBySubmResult.Location = new System.Drawing.Point(3, 26);
            this.panelFilterBySubmResult.Name = "panelFilterBySubmResult";
            this.panelFilterBySubmResult.Size = new System.Drawing.Size(734, 22);
            this.panelFilterBySubmResult.TabIndex = 2;
            this.panelFilterBySubmResult.WrapContents = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label5.Size = new System.Drawing.Size(200, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "За результатом попередніх публікацій";
            // 
            // rbFilterSubmittedNo
            // 
            this.rbFilterSubmittedNo.AutoSize = true;
            this.rbFilterSubmittedNo.Location = new System.Drawing.Point(209, 3);
            this.rbFilterSubmittedNo.Name = "rbFilterSubmittedNo";
            this.rbFilterSubmittedNo.Size = new System.Drawing.Size(47, 17);
            this.rbFilterSubmittedNo.TabIndex = 1;
            this.rbFilterSubmittedNo.Text = "Нові";
            this.rbFilterSubmittedNo.UseVisualStyleBackColor = true;
            this.rbFilterSubmittedNo.CheckedChanged += new System.EventHandler(this.rbFilterSubmittedNo_CheckedChanged);
            // 
            // rbFilterSubmittedYes
            // 
            this.rbFilterSubmittedYes.AutoSize = true;
            this.rbFilterSubmittedYes.Location = new System.Drawing.Point(262, 3);
            this.rbFilterSubmittedYes.Name = "rbFilterSubmittedYes";
            this.rbFilterSubmittedYes.Size = new System.Drawing.Size(62, 17);
            this.rbFilterSubmittedYes.TabIndex = 1;
            this.rbFilterSubmittedYes.Text = "Змінені";
            this.rbFilterSubmittedYes.UseVisualStyleBackColor = true;
            this.rbFilterSubmittedYes.CheckedChanged += new System.EventHandler(this.rbFilterSubmittedYes_CheckedChanged);
            // 
            // rbFilterSubmittedAll
            // 
            this.rbFilterSubmittedAll.AutoSize = true;
            this.rbFilterSubmittedAll.Checked = true;
            this.rbFilterSubmittedAll.Location = new System.Drawing.Point(330, 3);
            this.rbFilterSubmittedAll.Name = "rbFilterSubmittedAll";
            this.rbFilterSubmittedAll.Size = new System.Drawing.Size(40, 17);
            this.rbFilterSubmittedAll.TabIndex = 1;
            this.rbFilterSubmittedAll.TabStop = true;
            this.rbFilterSubmittedAll.Text = "Всі";
            this.rbFilterSubmittedAll.UseVisualStyleBackColor = true;
            this.rbFilterSubmittedAll.CheckedChanged += new System.EventHandler(this.rbFilterSubmittedAll_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(376, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label10.Size = new System.Drawing.Size(132, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "(застосовується одразу)";
            // 
            // panelSubmWorkCount
            // 
            this.panelSubmWorkCount.Controls.Add(this.label13);
            this.panelSubmWorkCount.Controls.Add(this.tbSubmWorkCntTotal);
            this.panelSubmWorkCount.Controls.Add(this.label14);
            this.panelSubmWorkCount.Controls.Add(this.tbSubmWorkCntSelected);
            this.panelSubmWorkCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSubmWorkCount.Location = new System.Drawing.Point(3, 218);
            this.panelSubmWorkCount.Name = "panelSubmWorkCount";
            this.panelSubmWorkCount.Size = new System.Drawing.Size(734, 41);
            this.panelSubmWorkCount.TabIndex = 3;
            this.panelSubmWorkCount.WrapContents = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label13.Size = new System.Drawing.Size(86, 19);
            this.label13.TabIndex = 0;
            this.label13.Text = "Творів загалом";
            // 
            // tbSubmWorkCntTotal
            // 
            this.tbSubmWorkCntTotal.Location = new System.Drawing.Point(95, 3);
            this.tbSubmWorkCntTotal.Name = "tbSubmWorkCntTotal";
            this.tbSubmWorkCntTotal.ReadOnly = true;
            this.tbSubmWorkCntTotal.Size = new System.Drawing.Size(56, 20);
            this.tbSubmWorkCntTotal.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(157, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label14.Size = new System.Drawing.Size(43, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "обрано";
            // 
            // tbSubmWorkCntSelected
            // 
            this.tbSubmWorkCntSelected.Location = new System.Drawing.Point(206, 3);
            this.tbSubmWorkCntSelected.Name = "tbSubmWorkCntSelected";
            this.tbSubmWorkCntSelected.ReadOnly = true;
            this.tbSubmWorkCntSelected.Size = new System.Drawing.Size(62, 20);
            this.tbSubmWorkCntSelected.TabIndex = 1;
            // 
            // panelFilterByStatus
            // 
            this.panelFilterByStatus.Controls.Add(this.label6);
            this.panelFilterByStatus.Controls.Add(this.cbFilterByStatus);
            this.panelFilterByStatus.Controls.Add(this.label9);
            this.panelFilterByStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilterByStatus.Location = new System.Drawing.Point(3, 54);
            this.panelFilterByStatus.Name = "panelFilterByStatus";
            this.panelFilterByStatus.Size = new System.Drawing.Size(734, 26);
            this.panelFilterByStatus.TabIndex = 2;
            this.panelFilterByStatus.WrapContents = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(165, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "За станом в поточній публікації";
            // 
            // cbFilterByStatus
            // 
            this.cbFilterByStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterByStatus.FormattingEnabled = true;
            this.cbFilterByStatus.Location = new System.Drawing.Point(174, 3);
            this.cbFilterByStatus.Name = "cbFilterByStatus";
            this.cbFilterByStatus.Size = new System.Drawing.Size(201, 21);
            this.cbFilterByStatus.TabIndex = 1;
            this.cbFilterByStatus.SelectedIndexChanged += new System.EventHandler(this.cbFilterByStatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(381, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label9.Size = new System.Drawing.Size(132, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "(застосовується одразу)";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.tbSubmWorkExFilter);
            this.flowLayoutPanel1.Controls.Add(this.btnSubmWorkApplyExFilter);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 86);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(734, 26);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label7.Size = new System.Drawing.Size(138, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "За додатковими умовами";
            // 
            // tbSubmWorkExFilter
            // 
            this.tbSubmWorkExFilter.Location = new System.Drawing.Point(147, 3);
            this.tbSubmWorkExFilter.Name = "tbSubmWorkExFilter";
            this.tbSubmWorkExFilter.Size = new System.Drawing.Size(142, 20);
            this.tbSubmWorkExFilter.TabIndex = 1;
            this.tbSubmWorkExFilter.TextChanged += new System.EventHandler(this.tbSubmWorkExFilter_TextChanged);
            // 
            // btnSubmWorkApplyExFilter
            // 
            this.btnSubmWorkApplyExFilter.Enabled = false;
            this.btnSubmWorkApplyExFilter.Location = new System.Drawing.Point(295, 3);
            this.btnSubmWorkApplyExFilter.Name = "btnSubmWorkApplyExFilter";
            this.btnSubmWorkApplyExFilter.Size = new System.Drawing.Size(80, 23);
            this.btnSubmWorkApplyExFilter.TabIndex = 2;
            this.btnSubmWorkApplyExFilter.Text = "Застосувати";
            this.btnSubmWorkApplyExFilter.UseVisualStyleBackColor = true;
            this.btnSubmWorkApplyExFilter.Click += new System.EventHandler(this.btnSubmWorkApplyExFilter_Click);
            // 
            // label8
            // 
            this.label8.ImageIndex = 1;
            this.label8.ImageList = this.ilButtonIcons;
            this.label8.Location = new System.Drawing.Point(381, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 23);
            this.label8.TabIndex = 8;
            this.toolTip.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // ilButtonIcons
            // 
            this.ilButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilButtonIcons.ImageStream")));
            this.ilButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilButtonIcons.Images.SetKeyName(0, "angle-right-solid.ico");
            this.ilButtonIcons.Images.SetKeyName(1, "icons8-question.gif");
            // 
            // panelWorkDetails
            // 
            this.panelWorkDetails.Controls.Add(this.tabRightHolders);
            this.panelWorkDetails.Controls.Add(this.tabAltNames);
            this.panelWorkDetails.Controls.Add(this.tabPerformers);
            this.panelWorkDetails.Controls.Add(this.tabSubmProblems);
            this.panelWorkDetails.Controls.Add(this.tabRespProblems);
            this.panelWorkDetails.Controls.Add(this.tabRghtHoldersDiff);
            this.panelWorkDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkDetails.ImageList = this.ilStatuses;
            this.panelWorkDetails.Location = new System.Drawing.Point(0, 0);
            this.panelWorkDetails.Name = "panelWorkDetails";
            this.panelWorkDetails.SelectedIndex = 0;
            this.panelWorkDetails.Size = new System.Drawing.Size(745, 235);
            this.panelWorkDetails.TabIndex = 0;
            this.panelWorkDetails.SelectedIndexChanged += new System.EventHandler(this.panelWorkDetails_SelectedIndexChanged);
            // 
            // tabRightHolders
            // 
            this.tabRightHolders.Controls.Add(this.ucSubmWorkShares);
            this.tabRightHolders.ImageIndex = 5;
            this.tabRightHolders.Location = new System.Drawing.Point(4, 23);
            this.tabRightHolders.Name = "tabRightHolders";
            this.tabRightHolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabRightHolders.Size = new System.Drawing.Size(737, 208);
            this.tabRightHolders.TabIndex = 0;
            this.tabRightHolders.Text = "Проценти правовласників";
            this.tabRightHolders.UseVisualStyleBackColor = true;
            // 
            // tabAltNames
            // 
            this.tabAltNames.Controls.Add(this.ucSubmWorkAltNames);
            this.tabAltNames.Location = new System.Drawing.Point(4, 23);
            this.tabAltNames.Name = "tabAltNames";
            this.tabAltNames.Padding = new System.Windows.Forms.Padding(3);
            this.tabAltNames.Size = new System.Drawing.Size(737, 208);
            this.tabAltNames.TabIndex = 1;
            this.tabAltNames.Text = "Альтернативні назви";
            this.tabAltNames.UseVisualStyleBackColor = true;
            // 
            // tabPerformers
            // 
            this.tabPerformers.Controls.Add(this.ucSubmWorkPerformers);
            this.tabPerformers.Location = new System.Drawing.Point(4, 23);
            this.tabPerformers.Name = "tabPerformers";
            this.tabPerformers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerformers.Size = new System.Drawing.Size(737, 208);
            this.tabPerformers.TabIndex = 2;
            this.tabPerformers.Text = "Виконавці";
            this.tabPerformers.UseVisualStyleBackColor = true;
            // 
            // tabSubmProblems
            // 
            this.tabSubmProblems.Controls.Add(this.ucSubmWorkCheckList);
            this.tabSubmProblems.Location = new System.Drawing.Point(4, 23);
            this.tabSubmProblems.Name = "tabSubmProblems";
            this.tabSubmProblems.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubmProblems.Size = new System.Drawing.Size(737, 208);
            this.tabSubmProblems.TabIndex = 3;
            this.tabSubmProblems.Text = "Проблеми для передачі";
            this.tabSubmProblems.UseVisualStyleBackColor = true;
            // 
            // tabRespProblems
            // 
            this.tabRespProblems.Controls.Add(this.ucSubmWorkRespErr);
            this.tabRespProblems.Location = new System.Drawing.Point(4, 23);
            this.tabRespProblems.Name = "tabRespProblems";
            this.tabRespProblems.Padding = new System.Windows.Forms.Padding(3);
            this.tabRespProblems.Size = new System.Drawing.Size(737, 208);
            this.tabRespProblems.TabIndex = 4;
            this.tabRespProblems.Text = "Проблеми із відповіді";
            this.tabRespProblems.UseVisualStyleBackColor = true;
            // 
            // tabRghtHoldersDiff
            // 
            this.tabRghtHoldersDiff.Controls.Add(this.ucSubmWorkSharesDiff);
            this.tabRghtHoldersDiff.ImageIndex = 5;
            this.tabRghtHoldersDiff.Location = new System.Drawing.Point(4, 23);
            this.tabRghtHoldersDiff.Name = "tabRghtHoldersDiff";
            this.tabRghtHoldersDiff.Size = new System.Drawing.Size(737, 208);
            this.tabRghtHoldersDiff.TabIndex = 5;
            this.tabRghtHoldersDiff.Text = "Зміни";
            this.tabRghtHoldersDiff.UseVisualStyleBackColor = true;
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
            this.ilStatuses.Images.SetKeyName(5, "icons8-equals-16.png");
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 32767;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // timerUpdateContent
            // 
            this.timerUpdateContent.Interval = 1;
            this.timerUpdateContent.Tick += new System.EventHandler(this.timerUpdateContent_Tick);
            // 
            // ucSubmRightHolders
            // 
            this.ucSubmRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmRightHolders.Location = new System.Drawing.Point(0, 0);
            this.ucSubmRightHolders.Name = "ucSubmRightHolders";
            this.ucSubmRightHolders.Size = new System.Drawing.Size(379, 501);
            this.ucSubmRightHolders.TabIndex = 2;
            // 
            // ucSubmWorkShares
            // 
            this.ucSubmWorkShares.AutoScroll = true;
            this.ucSubmWorkShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorkShares.Location = new System.Drawing.Point(3, 3);
            this.ucSubmWorkShares.Name = "ucSubmWorkShares";
            this.ucSubmWorkShares.Size = new System.Drawing.Size(731, 202);
            this.ucSubmWorkShares.TabIndex = 0;
            // 
            // ucSubmWorkAltNames
            // 
            this.ucSubmWorkAltNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorkAltNames.Location = new System.Drawing.Point(3, 3);
            this.ucSubmWorkAltNames.Name = "ucSubmWorkAltNames";
            this.ucSubmWorkAltNames.Size = new System.Drawing.Size(731, 202);
            this.ucSubmWorkAltNames.TabIndex = 0;
            // 
            // ucSubmWorkPerformers
            // 
            this.ucSubmWorkPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorkPerformers.Location = new System.Drawing.Point(3, 3);
            this.ucSubmWorkPerformers.Name = "ucSubmWorkPerformers";
            this.ucSubmWorkPerformers.Size = new System.Drawing.Size(731, 202);
            this.ucSubmWorkPerformers.TabIndex = 0;
            // 
            // ucSubmWorkCheckList
            // 
            this.ucSubmWorkCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorkCheckList.Location = new System.Drawing.Point(3, 3);
            this.ucSubmWorkCheckList.Name = "ucSubmWorkCheckList";
            this.ucSubmWorkCheckList.Size = new System.Drawing.Size(731, 202);
            this.ucSubmWorkCheckList.TabIndex = 0;
            // 
            // ucSubmWorkRespErr
            // 
            this.ucSubmWorkRespErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorkRespErr.Location = new System.Drawing.Point(3, 3);
            this.ucSubmWorkRespErr.Name = "ucSubmWorkRespErr";
            this.ucSubmWorkRespErr.Size = new System.Drawing.Size(731, 202);
            this.ucSubmWorkRespErr.TabIndex = 0;
            // 
            // ucSubmWorkSharesDiff
            // 
            this.ucSubmWorkSharesDiff.AutoScroll = true;
            this.ucSubmWorkSharesDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmWorkSharesDiff.Location = new System.Drawing.Point(0, 0);
            this.ucSubmWorkSharesDiff.Name = "ucSubmWorkSharesDiff";
            this.ucSubmWorkSharesDiff.Size = new System.Drawing.Size(737, 208);
            this.ucSubmWorkSharesDiff.TabIndex = 0;
            // 
            // UcSubmWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcSubmWorks";
            this.Size = new System.Drawing.Size(1139, 538);
            this.Load += new System.EventHandler(this.UcSubmWorks_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.panelWorks.Panel1.ResumeLayout(false);
            this.panelWorks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelWorks)).EndInit();
            this.panelWorks.ResumeLayout(false);
            this.panelWorkList.ResumeLayout(false);
            this.panelWorkList.PerformLayout();
            this.panelFilterBySubmResult.ResumeLayout(false);
            this.panelFilterBySubmResult.PerformLayout();
            this.panelSubmWorkCount.ResumeLayout(false);
            this.panelSubmWorkCount.PerformLayout();
            this.panelFilterByStatus.ResumeLayout(false);
            this.panelFilterByStatus.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelWorkDetails.ResumeLayout(false);
            this.tabRightHolders.ResumeLayout(false);
            this.tabAltNames.ResumeLayout(false);
            this.tabPerformers.ResumeLayout(false);
            this.tabSubmProblems.ResumeLayout(false);
            this.tabRespProblems.ResumeLayout(false);
            this.tabRghtHoldersDiff.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.SplitContainer panelWorks;
        private System.Windows.Forms.TableLayoutPanel panelWorkList;
        private System.Windows.Forms.ListView lvSubmWorks;
        private System.Windows.Forms.TabControl panelWorkDetails;
        private System.Windows.Forms.TabPage tabRightHolders;
        private System.Windows.Forms.TabPage tabAltNames;
        private System.Windows.Forms.TabPage tabPerformers;
        private System.Windows.Forms.TabPage tabSubmProblems;
        private System.Windows.Forms.TabPage tabRespProblems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList ilButtonIcons;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.FlowLayoutPanel panelFilterBySubmResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbFilterSubmittedYes;
        private System.Windows.Forms.RadioButton rbFilterSubmittedNo;
        private System.Windows.Forms.RadioButton rbFilterSubmittedAll;
        private System.Windows.Forms.FlowLayoutPanel panelFilterByStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFilterByStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSubmWorkExFilter;
        private System.Windows.Forms.Button btnSubmWorkApplyExFilter;
        private System.Windows.Forms.Label label8;
        private UcSubmWorkShares ucSubmWorkShares;
        private UcSubmWorkCheckList ucSubmWorkCheckList;
        private UcSubmWorkAltNames ucSubmWorkAltNames;
        private UcSubmWorkPerformers ucSubmWorkPerformers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ImageList ilSubmWorkStatuses;
        private System.Windows.Forms.ImageList ilSubmWorkSubStatuses;
        private System.Windows.Forms.FlowLayoutPanel panelSubmWorkCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbSubmWorkCntTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSubmWorkCntSelected;
        private System.Windows.Forms.Timer timerUpdateContent;
        private System.Windows.Forms.TabPage tabRghtHoldersDiff;
        private UcSubmWorkSharesDiff ucSubmWorkSharesDiff;
        private UcSubmRightHolders ucSubmRightHolders;
        private UcSubmWorkRespErr ucSubmWorkRespErr;
    }
}
