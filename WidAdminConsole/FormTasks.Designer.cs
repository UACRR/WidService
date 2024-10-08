
namespace WidAdminConsole
{
    partial class FormTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTasks));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitMiddle = new System.Windows.Forms.SplitContainer();
            this.tvLeft = new System.Windows.Forms.TreeView();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvRight = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labTasksPath = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.labError = new System.Windows.Forms.Label();
            this.linkErrorDetails = new System.Windows.Forms.LinkLabel();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.labTitle = new System.Windows.Forms.Label();
            this.btnRefreshTasks = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).BeginInit();
            this.splitMiddle.Panel1.SuspendLayout();
            this.splitMiddle.Panel2.SuspendLayout();
            this.splitMiddle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.splitMiddle, 0, 1);
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.panelMain.Size = new System.Drawing.Size(1086, 542);
            this.panelMain.TabIndex = 0;
            // 
            // splitMiddle
            // 
            this.splitMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMiddle.Location = new System.Drawing.Point(3, 49);
            this.splitMiddle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitMiddle.Name = "splitMiddle";
            // 
            // splitMiddle.Panel1
            // 
            this.splitMiddle.Panel1.Controls.Add(this.tvLeft);
            // 
            // splitMiddle.Panel2
            // 
            this.splitMiddle.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitMiddle.Size = new System.Drawing.Size(1080, 440);
            this.splitMiddle.SplitterDistance = 276;
            this.splitMiddle.SplitterWidth = 5;
            this.splitMiddle.TabIndex = 0;
            // 
            // tvLeft
            // 
            this.tvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLeft.HideSelection = false;
            this.tvLeft.ImageIndex = 0;
            this.tvLeft.ImageList = this.ilStatuses;
            this.tvLeft.Location = new System.Drawing.Point(0, 0);
            this.tvLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tvLeft.Name = "tvLeft";
            this.tvLeft.SelectedImageIndex = 0;
            this.tvLeft.Size = new System.Drawing.Size(276, 440);
            this.tvLeft.TabIndex = 0;
            this.tvLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLeft_AfterSelect);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lvRight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labTasksPath, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(799, 440);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lvRight
            // 
            this.lvRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRight.FullRowSelect = true;
            this.lvRight.GridLines = true;
            this.lvRight.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRight.HideSelection = false;
            this.lvRight.LabelWrap = false;
            this.lvRight.Location = new System.Drawing.Point(3, 34);
            this.lvRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lvRight.Name = "lvRight";
            this.lvRight.Size = new System.Drawing.Size(793, 406);
            this.lvRight.SmallImageList = this.ilStatuses;
            this.lvRight.TabIndex = 0;
            this.lvRight.UseCompatibleStateImageBehavior = false;
            this.lvRight.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Назва задачі";
            this.columnHeader1.Width = 344;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Процент виконання";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 138;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Початок виконання";
            this.columnHeader3.Width = 149;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Закінчення виконання";
            this.columnHeader4.Width = 156;
            // 
            // labTasksPath
            // 
            this.labTasksPath.AutoSize = true;
            this.labTasksPath.Location = new System.Drawing.Point(3, 0);
            this.labTasksPath.Name = "labTasksPath";
            this.labTasksPath.Size = new System.Drawing.Size(0, 16);
            this.labTasksPath.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.ColumnCount = 6;
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelBottom.Controls.Add(this.btnClose, 4, 0);
            this.panelBottom.Controls.Add(this.labError, 1, 0);
            this.panelBottom.Controls.Add(this.linkErrorDetails, 2, 0);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 496);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.RowCount = 1;
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.Size = new System.Drawing.Size(1080, 43);
            this.panelBottom.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(992, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labError
            // 
            this.labError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labError.Image = ((System.Drawing.Image)(resources.GetObject("labError.Image")));
            this.labError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labError.Location = new System.Drawing.Point(11, 6);
            this.labError.Name = "labError";
            this.labError.Size = new System.Drawing.Size(294, 31);
            this.labError.TabIndex = 1;
            this.labError.Text = "Остання операція закінчилась з помилками";
            this.labError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labError.Visible = false;
            // 
            // linkErrorDetails
            // 
            this.linkErrorDetails.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkErrorDetails.AutoSize = true;
            this.linkErrorDetails.Location = new System.Drawing.Point(311, 13);
            this.linkErrorDetails.Name = "linkErrorDetails";
            this.linkErrorDetails.Size = new System.Drawing.Size(132, 16);
            this.linkErrorDetails.TabIndex = 2;
            this.linkErrorDetails.TabStop = true;
            this.linkErrorDetails.Text = "(переглянути деталі)";
            this.linkErrorDetails.Visible = false;
            this.linkErrorDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkErrorDetails_LinkClicked);
            // 
            // panelTop
            // 
            this.panelTop.ColumnCount = 3;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelTop.Controls.Add(this.labTitle, 0, 0);
            this.panelTop.Controls.Add(this.btnRefreshTasks, 1, 0);
            this.panelTop.Controls.Add(this.btnSettings, 2, 0);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 1;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(1080, 39);
            this.panelTop.TabIndex = 3;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labTitle.Location = new System.Drawing.Point(3, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(837, 39);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "Моніторинг задач реплікації інформації з WID";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefreshTasks
            // 
            this.btnRefreshTasks.FlatAppearance.BorderSize = 0;
            this.btnRefreshTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTasks.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshTasks.Image")));
            this.btnRefreshTasks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshTasks.Location = new System.Drawing.Point(846, 3);
            this.btnRefreshTasks.Name = "btnRefreshTasks";
            this.btnRefreshTasks.Size = new System.Drawing.Size(91, 27);
            this.btnRefreshTasks.TabIndex = 2;
            this.btnRefreshTasks.Text = "Оновити";
            this.btnRefreshTasks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshTasks.UseVisualStyleBackColor = true;
            this.btnRefreshTasks.Click += new System.EventHandler(this.btnRefreshTasks_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Enabled = false;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(946, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(131, 27);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Налаштування";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // FormTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 542);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTasks";
            this.Text = "Задачі";
            this.Load += new System.EventHandler(this.FormTasks_Load);
            this.panelMain.ResumeLayout(false);
            this.splitMiddle.Panel1.ResumeLayout(false);
            this.splitMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).EndInit();
            this.splitMiddle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer splitMiddle;
        private System.Windows.Forms.TreeView tvLeft;
        private System.Windows.Forms.ListView lvRight;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labTasksPath;
        private System.Windows.Forms.TableLayoutPanel panelBottom;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button btnRefreshTasks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labError;
        private System.Windows.Forms.LinkLabel linkErrorDetails;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer timerLoad;
    }
}