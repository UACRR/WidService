
namespace WidExport
{
    partial class UcWidSubmWorks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcWidSubmWorks));
            this.ilState = new System.Windows.Forms.ImageList(this.components);
            this.cbFilterStatus = new System.Windows.Forms.ComboBox();
            this.cbFilterSubmit = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitWorks = new System.Windows.Forms.SplitContainer();
            this.panelWorks = new System.Windows.Forms.TableLayoutPanel();
            this.panelWorkTitle = new System.Windows.Forms.TableLayoutPanel();
            this.labStatus = new System.Windows.Forms.Label();
            this.menuStripWorkActions = new System.Windows.Forms.MenuStrip();
            this.mnuActions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateFromMs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSubmit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoNotSubmit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUpdateAllFromMs = new System.Windows.Forms.ToolStripMenuItem();
            this.lvWorks = new System.Windows.Forms.ListView();
            this.panelAuthors = new System.Windows.Forms.TableLayoutPanel();
            this.tabMwInfo = new System.Windows.Forms.TabControl();
            this.tabPageShares = new System.Windows.Forms.TabPage();
            this.tabPageMwNames = new System.Windows.Forms.TabPage();
            this.tabPagePerformers = new System.Windows.Forms.TabPage();
            this.tabPageDaignostics = new System.Windows.Forms.TabPage();
            this.tabPageResp = new System.Windows.Forms.TabPage();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.labFilter = new System.Windows.Forms.Label();
            this.labResubmit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ucWidSubmShares = new WidExport.UcWidSubmWorkShares();
            this.ucWidSubmNames = new WidExport.UcWidSubmWorkNames();
            this.ucWidSubmPerformers = new WidExport.UcWidSubmWorkPerformers();
            this.ucWidSubmWorkCheckList = new WidExport.UcWidSubmWorkCheckList();
            this.ucWidSubmWorkResp = new WidExport.UcWidSubmWorkResp();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.cbFilterSubmType = new System.Windows.Forms.ComboBox();
            this.tbFilterName = new System.Windows.Forms.TextBox();
            this.tbFilterObjId = new System.Windows.Forms.TextBox();
            this.tbFilterPerformer = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitWorks)).BeginInit();
            this.splitWorks.Panel1.SuspendLayout();
            this.splitWorks.Panel2.SuspendLayout();
            this.splitWorks.SuspendLayout();
            this.panelWorks.SuspendLayout();
            this.panelWorkTitle.SuspendLayout();
            this.menuStripWorkActions.SuspendLayout();
            this.panelAuthors.SuspendLayout();
            this.tabMwInfo.SuspendLayout();
            this.tabPageShares.SuspendLayout();
            this.tabPageMwNames.SuspendLayout();
            this.tabPagePerformers.SuspendLayout();
            this.tabPageDaignostics.SuspendLayout();
            this.tabPageResp.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilState
            // 
            this.ilState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilState.ImageStream")));
            this.ilState.TransparentColor = System.Drawing.Color.Transparent;
            this.ilState.Images.SetKeyName(0, "pending");
            this.ilState.Images.SetKeyName(1, "inprogress");
            this.ilState.Images.SetKeyName(2, "completed");
            this.ilState.Images.SetKeyName(3, "failed");
            // 
            // cbFilterStatus
            // 
            this.cbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterStatus.FormattingEnabled = true;
            this.cbFilterStatus.Location = new System.Drawing.Point(50, 3);
            this.cbFilterStatus.Name = "cbFilterStatus";
            this.cbFilterStatus.Size = new System.Drawing.Size(120, 21);
            this.cbFilterStatus.TabIndex = 1;
            this.cbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cbFilterStatus_SelectedIndexChanged);
            // 
            // cbFilterSubmit
            // 
            this.cbFilterSubmit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterSubmit.FormattingEnabled = true;
            this.cbFilterSubmit.Location = new System.Drawing.Point(238, 3);
            this.cbFilterSubmit.Name = "cbFilterSubmit";
            this.cbFilterSubmit.Size = new System.Drawing.Size(78, 21);
            this.cbFilterSubmit.TabIndex = 3;
            this.cbFilterSubmit.SelectedIndexChanged += new System.EventHandler(this.cbResubmit_SelectedIndexChanged);
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.splitWorks, 0, 2);
            this.panelMain.Controls.Add(this.panelFilter, 0, 1);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(1172, 590);
            this.panelMain.TabIndex = 1;
            // 
            // splitWorks
            // 
            this.splitWorks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitWorks.Location = new System.Drawing.Point(3, 73);
            this.splitWorks.Name = "splitWorks";
            this.splitWorks.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitWorks.Panel1
            // 
            this.splitWorks.Panel1.Controls.Add(this.panelWorks);
            // 
            // splitWorks.Panel2
            // 
            this.splitWorks.Panel2.Controls.Add(this.panelAuthors);
            this.splitWorks.Size = new System.Drawing.Size(1166, 506);
            this.splitWorks.SplitterDistance = 187;
            this.splitWorks.TabIndex = 1;
            // 
            // panelWorks
            // 
            this.panelWorks.ColumnCount = 1;
            this.panelWorks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorks.Controls.Add(this.panelWorkTitle, 0, 1);
            this.panelWorks.Controls.Add(this.lvWorks, 0, 0);
            this.panelWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorks.Location = new System.Drawing.Point(0, 0);
            this.panelWorks.Name = "panelWorks";
            this.panelWorks.RowCount = 3;
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelWorks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelWorks.Size = new System.Drawing.Size(1164, 185);
            this.panelWorks.TabIndex = 0;
            // 
            // panelWorkTitle
            // 
            this.panelWorkTitle.ColumnCount = 4;
            this.panelWorkTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.panelWorkTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.panelWorkTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelWorkTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelWorkTitle.Controls.Add(this.labStatus, 0, 0);
            this.panelWorkTitle.Controls.Add(this.menuStripWorkActions, 2, 0);
            this.panelWorkTitle.Location = new System.Drawing.Point(3, 148);
            this.panelWorkTitle.Name = "panelWorkTitle";
            this.panelWorkTitle.RowCount = 1;
            this.panelWorkTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWorkTitle.Size = new System.Drawing.Size(1158, 26);
            this.panelWorkTitle.TabIndex = 2;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labStatus.ForeColor = System.Drawing.Color.SeaGreen;
            this.labStatus.Location = new System.Drawing.Point(8, 0);
            this.labStatus.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(248, 26);
            this.labStatus.TabIndex = 3;
            this.labStatus.Text = "Готовий до експорту";
            this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStripWorkActions
            // 
            this.menuStripWorkActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuActions});
            this.menuStripWorkActions.Location = new System.Drawing.Point(982, 0);
            this.menuStripWorkActions.Name = "menuStripWorkActions";
            this.menuStripWorkActions.Size = new System.Drawing.Size(156, 24);
            this.menuStripWorkActions.TabIndex = 4;
            this.menuStripWorkActions.Text = "menuStrip1";
            // 
            // mnuActions
            // 
            this.mnuActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUpdateFromMs,
            this.toolStripMenuItem1,
            this.mnuSubmit,
            this.mnuDoNotSubmit,
            this.toolStripSeparator1,
            this.mnuUpdateAllFromMs});
            this.mnuActions.Name = "mnuActions";
            this.mnuActions.Size = new System.Drawing.Size(91, 20);
            this.mnuActions.Text = "Дії з творами";
            // 
            // mnuUpdateFromMs
            // 
            this.mnuUpdateFromMs.Name = "mnuUpdateFromMs";
            this.mnuUpdateFromMs.Size = new System.Drawing.Size(363, 22);
            this.mnuUpdateFromMs.Text = "Оновити інформацію для  твору";
            this.mnuUpdateFromMs.Click += new System.EventHandler(this.mnuUpdateFromMs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(360, 6);
            // 
            // mnuSubmit
            // 
            this.mnuSubmit.Name = "mnuSubmit";
            this.mnuSubmit.Size = new System.Drawing.Size(363, 22);
            this.mnuSubmit.Text = "До передачі";
            this.mnuSubmit.Click += new System.EventHandler(this.ReSubmit_Click);
            // 
            // mnuDoNotSubmit
            // 
            this.mnuDoNotSubmit.Name = "mnuDoNotSubmit";
            this.mnuDoNotSubmit.Size = new System.Drawing.Size(363, 22);
            this.mnuDoNotSubmit.Text = "Не передавати";
            this.mnuDoNotSubmit.Click += new System.EventHandler(this.DoNotPublish_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(360, 6);
            // 
            // mnuUpdateAllFromMs
            // 
            this.mnuUpdateAllFromMs.Name = "mnuUpdateAllFromMs";
            this.mnuUpdateAllFromMs.Size = new System.Drawing.Size(363, 22);
            this.mnuUpdateAllFromMs.Text = "Оновити інформацію для не переданих творів групи";
            this.mnuUpdateAllFromMs.Click += new System.EventHandler(this.mnuUpdateAllFromMs_Click);
            // 
            // lvWorks
            // 
            this.lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorks.FullRowSelect = true;
            this.lvWorks.GridLines = true;
            this.lvWorks.HideSelection = false;
            this.lvWorks.Location = new System.Drawing.Point(3, 3);
            this.lvWorks.MultiSelect = false;
            this.lvWorks.Name = "lvWorks";
            this.lvWorks.Size = new System.Drawing.Size(1158, 139);
            this.lvWorks.TabIndex = 0;
            this.lvWorks.UseCompatibleStateImageBehavior = false;
            this.lvWorks.View = System.Windows.Forms.View.Details;
            this.lvWorks.SelectedIndexChanged += new System.EventHandler(this.lvWorks_SelectedIndexChanged);
            // 
            // panelAuthors
            // 
            this.panelAuthors.ColumnCount = 1;
            this.panelAuthors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAuthors.Controls.Add(this.tabMwInfo, 0, 0);
            this.panelAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuthors.Location = new System.Drawing.Point(0, 0);
            this.panelAuthors.Name = "panelAuthors";
            this.panelAuthors.RowCount = 1;
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.panelAuthors.Size = new System.Drawing.Size(1164, 313);
            this.panelAuthors.TabIndex = 0;
            // 
            // tabMwInfo
            // 
            this.tabMwInfo.Controls.Add(this.tabPageShares);
            this.tabMwInfo.Controls.Add(this.tabPageMwNames);
            this.tabMwInfo.Controls.Add(this.tabPagePerformers);
            this.tabMwInfo.Controls.Add(this.tabPageDaignostics);
            this.tabMwInfo.Controls.Add(this.tabPageResp);
            this.tabMwInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMwInfo.ImageList = this.ilState;
            this.tabMwInfo.Location = new System.Drawing.Point(3, 3);
            this.tabMwInfo.Name = "tabMwInfo";
            this.tabMwInfo.SelectedIndex = 0;
            this.tabMwInfo.Size = new System.Drawing.Size(1158, 307);
            this.tabMwInfo.TabIndex = 5;
            this.tabMwInfo.SelectedIndexChanged += new System.EventHandler(this.tabMwInfo_SelectedIndexChanged);
            // 
            // tabPageShares
            // 
            this.tabPageShares.Controls.Add(this.ucWidSubmShares);
            this.tabPageShares.ImageIndex = 2;
            this.tabPageShares.Location = new System.Drawing.Point(4, 23);
            this.tabPageShares.Name = "tabPageShares";
            this.tabPageShares.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShares.Size = new System.Drawing.Size(1150, 280);
            this.tabPageShares.TabIndex = 0;
            this.tabPageShares.Text = "Розподіл процентів";
            this.tabPageShares.UseVisualStyleBackColor = true;
            // 
            // tabPageMwNames
            // 
            this.tabPageMwNames.Controls.Add(this.ucWidSubmNames);
            this.tabPageMwNames.Location = new System.Drawing.Point(4, 23);
            this.tabPageMwNames.Name = "tabPageMwNames";
            this.tabPageMwNames.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMwNames.Size = new System.Drawing.Size(1150, 279);
            this.tabPageMwNames.TabIndex = 1;
            this.tabPageMwNames.Text = "Назви твору";
            this.tabPageMwNames.UseVisualStyleBackColor = true;
            // 
            // tabPagePerformers
            // 
            this.tabPagePerformers.Controls.Add(this.ucWidSubmPerformers);
            this.tabPagePerformers.Location = new System.Drawing.Point(4, 23);
            this.tabPagePerformers.Name = "tabPagePerformers";
            this.tabPagePerformers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePerformers.Size = new System.Drawing.Size(1150, 279);
            this.tabPagePerformers.TabIndex = 2;
            this.tabPagePerformers.Text = "Виконавці";
            this.tabPagePerformers.UseVisualStyleBackColor = true;
            // 
            // tabPageDaignostics
            // 
            this.tabPageDaignostics.Controls.Add(this.ucWidSubmWorkCheckList);
            this.tabPageDaignostics.Location = new System.Drawing.Point(4, 23);
            this.tabPageDaignostics.Name = "tabPageDaignostics";
            this.tabPageDaignostics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDaignostics.Size = new System.Drawing.Size(1150, 279);
            this.tabPageDaignostics.TabIndex = 3;
            this.tabPageDaignostics.Text = "Діагностика";
            this.tabPageDaignostics.UseVisualStyleBackColor = true;
            // 
            // tabPageResp
            // 
            this.tabPageResp.Controls.Add(this.ucWidSubmWorkResp);
            this.tabPageResp.Location = new System.Drawing.Point(4, 23);
            this.tabPageResp.Name = "tabPageResp";
            this.tabPageResp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResp.Size = new System.Drawing.Size(1150, 279);
            this.tabPageResp.TabIndex = 4;
            this.tabPageResp.Text = "Відповідь WID";
            this.tabPageResp.UseVisualStyleBackColor = true;
            // 
            // panelFilter
            // 
            this.panelFilter.AutoSize = true;
            this.panelFilter.Controls.Add(this.labFilter);
            this.panelFilter.Controls.Add(this.cbFilterStatus);
            this.panelFilter.Controls.Add(this.labResubmit);
            this.panelFilter.Controls.Add(this.cbFilterSubmit);
            this.panelFilter.Controls.Add(this.label3);
            this.panelFilter.Controls.Add(this.cbFilterSubmType);
            this.panelFilter.Controls.Add(this.label4);
            this.panelFilter.Controls.Add(this.tbFilterName);
            this.panelFilter.Controls.Add(this.label5);
            this.panelFilter.Controls.Add(this.tbFilterPerformer);
            this.panelFilter.Controls.Add(this.label6);
            this.panelFilter.Controls.Add(this.tbFilterObjId);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Controls.Add(this.btnResetFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 38);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1166, 29);
            this.panelFilter.TabIndex = 2;
            // 
            // labFilter
            // 
            this.labFilter.AutoSize = true;
            this.labFilter.Location = new System.Drawing.Point(3, 7);
            this.labFilter.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labFilter.Name = "labFilter";
            this.labFilter.Size = new System.Drawing.Size(41, 13);
            this.labFilter.TabIndex = 0;
            this.labFilter.Text = "Статус";
            // 
            // labResubmit
            // 
            this.labResubmit.AutoSize = true;
            this.labResubmit.Location = new System.Drawing.Point(176, 7);
            this.labResubmit.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labResubmit.Name = "labResubmit";
            this.labResubmit.Size = new System.Drawing.Size(56, 13);
            this.labResubmit.TabIndex = 1;
            this.labResubmit.Text = "Передати";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Тип передачі";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Назва ";
            // 
            // ucWidSubmShares
            // 
            this.ucWidSubmShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWidSubmShares.Location = new System.Drawing.Point(3, 3);
            this.ucWidSubmShares.Name = "ucWidSubmShares";
            this.ucWidSubmShares.Size = new System.Drawing.Size(1144, 274);
            this.ucWidSubmShares.TabIndex = 0;
            // 
            // ucWidSubmNames
            // 
            this.ucWidSubmNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWidSubmNames.Location = new System.Drawing.Point(3, 3);
            this.ucWidSubmNames.Name = "ucWidSubmNames";
            this.ucWidSubmNames.Size = new System.Drawing.Size(1144, 273);
            this.ucWidSubmNames.TabIndex = 0;
            // 
            // ucWidSubmPerformers
            // 
            this.ucWidSubmPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWidSubmPerformers.Location = new System.Drawing.Point(3, 3);
            this.ucWidSubmPerformers.Name = "ucWidSubmPerformers";
            this.ucWidSubmPerformers.Size = new System.Drawing.Size(1144, 273);
            this.ucWidSubmPerformers.TabIndex = 0;
            // 
            // ucWidSubmWorkCheckList
            // 
            this.ucWidSubmWorkCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWidSubmWorkCheckList.Location = new System.Drawing.Point(3, 3);
            this.ucWidSubmWorkCheckList.Name = "ucWidSubmWorkCheckList";
            this.ucWidSubmWorkCheckList.Size = new System.Drawing.Size(1144, 273);
            this.ucWidSubmWorkCheckList.TabIndex = 0;
            // 
            // ucWidSubmWorkResp
            // 
            this.ucWidSubmWorkResp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWidSubmWorkResp.Location = new System.Drawing.Point(3, 3);
            this.ucWidSubmWorkResp.Name = "ucWidSubmWorkResp";
            this.ucWidSubmWorkResp.Size = new System.Drawing.Size(1144, 273);
            this.ucWidSubmWorkResp.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Виконавець";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(758, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "ObjId";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(876, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(93, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Застосувати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // cbFilterSubmType
            // 
            this.cbFilterSubmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterSubmType.FormattingEnabled = true;
            this.cbFilterSubmType.Location = new System.Drawing.Point(400, 3);
            this.cbFilterSubmType.Name = "cbFilterSubmType";
            this.cbFilterSubmType.Size = new System.Drawing.Size(56, 21);
            this.cbFilterSubmType.TabIndex = 4;
            this.cbFilterSubmType.SelectedIndexChanged += new System.EventHandler(this.cbFilterSubmType_SelectedIndexChanged);
            // 
            // tbFilterName
            // 
            this.tbFilterName.Location = new System.Drawing.Point(510, 3);
            this.tbFilterName.Name = "tbFilterName";
            this.tbFilterName.Size = new System.Drawing.Size(82, 20);
            this.tbFilterName.TabIndex = 5;
            this.tbFilterName.TextChanged += new System.EventHandler(this.tbFilterName_TextChanged);
            // 
            // tbFilterObjId
            // 
            this.tbFilterObjId.Location = new System.Drawing.Point(796, 3);
            this.tbFilterObjId.Name = "tbFilterObjId";
            this.tbFilterObjId.Size = new System.Drawing.Size(74, 20);
            this.tbFilterObjId.TabIndex = 5;
            this.tbFilterObjId.TextChanged += new System.EventHandler(this.tbFilterObjId_TextChanged);
            // 
            // tbFilterPerformer
            // 
            this.tbFilterPerformer.Location = new System.Drawing.Point(672, 3);
            this.tbFilterPerformer.Name = "tbFilterPerformer";
            this.tbFilterPerformer.Size = new System.Drawing.Size(80, 20);
            this.tbFilterPerformer.TabIndex = 5;
            this.tbFilterPerformer.TextChanged += new System.EventHandler(this.tbFilterPerformer_TextChanged);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label7);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1166, 29);
            this.panelTop.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(450, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Вибрати твори за наступними значеннями (Назва і Виконавець за входженням тексту)";
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(975, 3);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(122, 23);
            this.btnResetFilter.TabIndex = 2;
            this.btnResetFilter.Text = "Скасувати фільтр";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // UcWidSubmWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcWidSubmWorks";
            this.Size = new System.Drawing.Size(1172, 590);
            this.Load += new System.EventHandler(this.UcWidSubmWorks_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.splitWorks.Panel1.ResumeLayout(false);
            this.splitWorks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitWorks)).EndInit();
            this.splitWorks.ResumeLayout(false);
            this.panelWorks.ResumeLayout(false);
            this.panelWorkTitle.ResumeLayout(false);
            this.panelWorkTitle.PerformLayout();
            this.menuStripWorkActions.ResumeLayout(false);
            this.menuStripWorkActions.PerformLayout();
            this.panelAuthors.ResumeLayout(false);
            this.tabMwInfo.ResumeLayout(false);
            this.tabPageShares.ResumeLayout(false);
            this.tabPageMwNames.ResumeLayout(false);
            this.tabPagePerformers.ResumeLayout(false);
            this.tabPageDaignostics.ResumeLayout(false);
            this.tabPageResp.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.TableLayoutPanel panelAuthors;
        private System.Windows.Forms.TableLayoutPanel panelWorkTitle;
        private System.Windows.Forms.SplitContainer splitWorks;
        private System.Windows.Forms.ListView lvWorks;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TabControl tabMwInfo;
        private System.Windows.Forms.TabPage tabPageShares;
        private System.Windows.Forms.TabPage tabPageMwNames;
        private System.Windows.Forms.TabPage tabPagePerformers;
        private System.Windows.Forms.TabPage tabPageDaignostics;
        private UcWidSubmWorkNames ucWidSubmNames;
        private UcWidSubmWorkPerformers ucWidSubmPerformers;
        private UcWidSubmWorkCheckList ucWidSubmWorkCheckList;
        private UcWidSubmWorkShares ucWidSubmShares;
        private System.Windows.Forms.ImageList ilState;
        private System.Windows.Forms.MenuStrip menuStripWorkActions;
        private System.Windows.Forms.ToolStripMenuItem mnuActions;
        private System.Windows.Forms.TableLayoutPanel panelWorks;
        private System.Windows.Forms.ComboBox cbFilterStatus;
        private System.Windows.Forms.TabPage tabPageResp;
        private UcWidSubmWorkResp ucWidSubmWorkResp;
        private System.Windows.Forms.ToolStripMenuItem mnuSubmit;
        private System.Windows.Forms.ToolStripMenuItem mnuDoNotSubmit;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateFromMs;
        private System.Windows.Forms.ComboBox cbFilterSubmit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateAllFromMs;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label labFilter;
        private System.Windows.Forms.Label labResubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.ComboBox cbFilterSubmType;
        private System.Windows.Forms.TextBox tbFilterName;
        private System.Windows.Forms.TextBox tbFilterObjId;
        private System.Windows.Forms.TextBox tbFilterPerformer;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnResetFilter;
    }
}
