using System.Drawing;
using System.Windows.Forms;

namespace IpiReplSvcMonitor
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelMain = new TableLayoutPanel();
            panel1 = new FlowLayoutPanel();
            label1 = new Label();
            tbIpiStartDate = new TextBox();
            panel2 = new FlowLayoutPanel();
            label3 = new Label();
            btnRefreshJobs = new Button();
            ilActionIcons = new ImageList(components);
            panel4 = new FlowLayoutPanel();
            btnClose = new Button();
            panelTaskStepsSplit = new SplitContainer();
            panelTasks = new TableLayoutPanel();
            panel211 = new FlowLayoutPanel();
            label4 = new Label();
            rbFilterNext = new RadioButton();
            rbFilterFinished = new RadioButton();
            btnRefreshTasks = new Button();
            lvTasks = new ListView();
            panelSteps = new TableLayoutPanel();
            panel212 = new FlowLayoutPanel();
            label5 = new Label();
            btnRefreshSteps = new Button();
            lvSteps = new ListView();
            lvJobs = new ListView();
            labErrorText = new Label();
            ilEntityTypes = new ImageList(components);
            ilStatuses = new ImageList(components);
            panelMain.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelTaskStepsSplit).BeginInit();
            panelTaskStepsSplit.Panel1.SuspendLayout();
            panelTaskStepsSplit.Panel2.SuspendLayout();
            panelTaskStepsSplit.SuspendLayout();
            panelTasks.SuspendLayout();
            panel211.SuspendLayout();
            panelSteps.SuspendLayout();
            panel212.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelMain.Controls.Add(panel1, 0, 0);
            panelMain.Controls.Add(panel2, 0, 1);
            panelMain.Controls.Add(panel4, 0, 5);
            panelMain.Controls.Add(panelTaskStepsSplit, 0, 3);
            panelMain.Controls.Add(lvJobs, 0, 2);
            panelMain.Controls.Add(labErrorText, 0, 4);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 6;
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new RowStyle());
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            panelMain.Size = new Size(856, 636);
            panelMain.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tbIpiStartDate);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(850, 27);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 5, 0, 0);
            label1.Size = new Size(290, 20);
            label1.TabIndex = 0;
            label1.Text = "Дата повної копії, початкова інформація станом на";
            // 
            // tbIpiStartDate
            // 
            tbIpiStartDate.Location = new Point(299, 3);
            tbIpiStartDate.Name = "tbIpiStartDate";
            tbIpiStartDate.ReadOnly = true;
            tbIpiStartDate.Size = new Size(113, 23);
            tbIpiStartDate.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnRefreshJobs);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 36);
            panel2.Name = "panel2";
            panel2.Size = new Size(850, 27);
            panel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 5, 0, 0);
            label3.Size = new Size(58, 20);
            label3.TabIndex = 0;
            label3.Text = "Завдання";
            // 
            // btnRefreshJobs
            // 
            btnRefreshJobs.FlatAppearance.BorderSize = 0;
            btnRefreshJobs.FlatStyle = FlatStyle.Flat;
            btnRefreshJobs.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshJobs.ImageIndex = 0;
            btnRefreshJobs.ImageList = ilActionIcons;
            btnRefreshJobs.Location = new Point(67, 3);
            btnRefreshJobs.Name = "btnRefreshJobs";
            btnRefreshJobs.Padding = new Padding(0, 0, 0, 4);
            btnRefreshJobs.Size = new Size(28, 23);
            btnRefreshJobs.TabIndex = 1;
            btnRefreshJobs.UseVisualStyleBackColor = true;
            btnRefreshJobs.Click += btnRefreshJobs_Click;
            // 
            // ilActionIcons
            // 
            ilActionIcons.ColorDepth = ColorDepth.Depth8Bit;
            ilActionIcons.ImageStream = (ImageListStreamer)resources.GetObject("ilActionIcons.ImageStream");
            ilActionIcons.TransparentColor = Color.Transparent;
            ilActionIcons.Images.SetKeyName(0, "icons8-refresh-16.png");
            // 
            // panel4
            // 
            panel4.Controls.Add(btnClose);
            panel4.Dock = DockStyle.Fill;
            panel4.FlowDirection = FlowDirection.RightToLeft;
            panel4.Location = new Point(3, 606);
            panel4.Name = "panel4";
            panel4.Size = new Size(850, 27);
            panel4.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(772, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Вийти";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panelTaskStepsSplit
            // 
            panelTaskStepsSplit.Dock = DockStyle.Fill;
            panelTaskStepsSplit.FixedPanel = FixedPanel.Panel2;
            panelTaskStepsSplit.Location = new Point(3, 163);
            panelTaskStepsSplit.Name = "panelTaskStepsSplit";
            panelTaskStepsSplit.Orientation = Orientation.Horizontal;
            // 
            // panelTaskStepsSplit.Panel1
            // 
            panelTaskStepsSplit.Panel1.Controls.Add(panelTasks);
            // 
            // panelTaskStepsSplit.Panel2
            // 
            panelTaskStepsSplit.Panel2.Controls.Add(panelSteps);
            panelTaskStepsSplit.Size = new Size(850, 416);
            panelTaskStepsSplit.SplitterDistance = 220;
            panelTaskStepsSplit.TabIndex = 1;
            // 
            // panelTasks
            // 
            panelTasks.ColumnCount = 1;
            panelTasks.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelTasks.Controls.Add(panel211, 0, 0);
            panelTasks.Controls.Add(lvTasks, 0, 1);
            panelTasks.Dock = DockStyle.Fill;
            panelTasks.Location = new Point(0, 0);
            panelTasks.Name = "panelTasks";
            panelTasks.RowCount = 2;
            panelTasks.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            panelTasks.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelTasks.Size = new Size(850, 220);
            panelTasks.TabIndex = 0;
            // 
            // panel211
            // 
            panel211.Controls.Add(label4);
            panel211.Controls.Add(rbFilterNext);
            panel211.Controls.Add(rbFilterFinished);
            panel211.Controls.Add(btnRefreshTasks);
            panel211.Dock = DockStyle.Fill;
            panel211.Location = new Point(3, 3);
            panel211.Name = "panel211";
            panel211.Size = new Size(844, 27);
            panel211.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 5, 0, 0);
            label4.Size = new Size(126, 20);
            label4.TabIndex = 0;
            label4.Text = "Опрацювання файлів";
            // 
            // rbFilterNext
            // 
            rbFilterNext.AutoSize = true;
            rbFilterNext.Checked = true;
            rbFilterNext.Location = new Point(135, 3);
            rbFilterNext.Name = "rbFilterNext";
            rbFilterNext.Size = new Size(74, 19);
            rbFilterNext.TabIndex = 1;
            rbFilterNext.TabStop = true;
            rbFilterNext.Text = "Наступні";
            rbFilterNext.UseVisualStyleBackColor = true;
            rbFilterNext.CheckedChanged += rbFilterNext_CheckedChanged;
            // 
            // rbFilterFinished
            // 
            rbFilterFinished.AutoSize = true;
            rbFilterFinished.Location = new Point(215, 3);
            rbFilterFinished.Name = "rbFilterFinished";
            rbFilterFinished.Size = new Size(84, 19);
            rbFilterFinished.TabIndex = 1;
            rbFilterFinished.Text = "Завершені";
            rbFilterFinished.UseVisualStyleBackColor = true;
            rbFilterFinished.CheckedChanged += rbFilterFinished_CheckedChanged;
            // 
            // btnRefreshTasks
            // 
            btnRefreshTasks.FlatAppearance.BorderSize = 0;
            btnRefreshTasks.FlatStyle = FlatStyle.Flat;
            btnRefreshTasks.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshTasks.ImageIndex = 0;
            btnRefreshTasks.ImageList = ilActionIcons;
            btnRefreshTasks.Location = new Point(305, 3);
            btnRefreshTasks.Name = "btnRefreshTasks";
            btnRefreshTasks.Padding = new Padding(0, 0, 0, 4);
            btnRefreshTasks.Size = new Size(28, 23);
            btnRefreshTasks.TabIndex = 1;
            btnRefreshTasks.UseVisualStyleBackColor = true;
            btnRefreshTasks.Click += btnRefreshTasks_Click;
            // 
            // lvTasks
            // 
            lvTasks.Dock = DockStyle.Fill;
            lvTasks.HideSelection = false;
            lvTasks.Location = new Point(3, 36);
            lvTasks.Name = "lvTasks";
            lvTasks.Size = new Size(844, 181);
            lvTasks.TabIndex = 2;
            lvTasks.UseCompatibleStateImageBehavior = false;
            lvTasks.SelectedIndexChanged += lvTasks_SelectedIndexChanged;
            // 
            // panelSteps
            // 
            panelSteps.ColumnCount = 1;
            panelSteps.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelSteps.Controls.Add(panel212, 0, 0);
            panelSteps.Controls.Add(lvSteps, 0, 1);
            panelSteps.Dock = DockStyle.Fill;
            panelSteps.Location = new Point(0, 0);
            panelSteps.Name = "panelSteps";
            panelSteps.RowCount = 2;
            panelSteps.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            panelSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelSteps.Size = new Size(850, 192);
            panelSteps.TabIndex = 0;
            // 
            // panel212
            // 
            panel212.Controls.Add(label5);
            panel212.Controls.Add(btnRefreshSteps);
            panel212.Dock = DockStyle.Fill;
            panel212.Location = new Point(3, 3);
            panel212.Name = "panel212";
            panel212.Size = new Size(844, 27);
            panel212.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 5, 0, 0);
            label5.Size = new Size(103, 20);
            label5.TabIndex = 0;
            label5.Text = "Кроки виконання";
            // 
            // btnRefreshSteps
            // 
            btnRefreshSteps.FlatAppearance.BorderSize = 0;
            btnRefreshSteps.FlatStyle = FlatStyle.Flat;
            btnRefreshSteps.ImageAlign = ContentAlignment.MiddleLeft;
            btnRefreshSteps.ImageIndex = 0;
            btnRefreshSteps.ImageList = ilActionIcons;
            btnRefreshSteps.Location = new Point(112, 3);
            btnRefreshSteps.Name = "btnRefreshSteps";
            btnRefreshSteps.Padding = new Padding(0, 0, 0, 4);
            btnRefreshSteps.Size = new Size(28, 23);
            btnRefreshSteps.TabIndex = 1;
            btnRefreshSteps.UseVisualStyleBackColor = true;
            btnRefreshSteps.Click += btnRefreshSteps_Click;
            // 
            // lvSteps
            // 
            lvSteps.Dock = DockStyle.Fill;
            lvSteps.HideSelection = false;
            lvSteps.Location = new Point(3, 36);
            lvSteps.Name = "lvSteps";
            lvSteps.Size = new Size(844, 153);
            lvSteps.TabIndex = 2;
            lvSteps.UseCompatibleStateImageBehavior = false;
            // 
            // lvJobs
            // 
            lvJobs.Dock = DockStyle.Fill;
            lvJobs.HideSelection = false;
            lvJobs.Location = new Point(3, 69);
            lvJobs.Name = "lvJobs";
            lvJobs.Size = new Size(850, 88);
            lvJobs.TabIndex = 2;
            lvJobs.UseCompatibleStateImageBehavior = false;
            lvJobs.SelectedIndexChanged += lvJobs_SelectedIndexChanged;
            // 
            // labErrorText
            // 
            labErrorText.AutoSize = true;
            labErrorText.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labErrorText.ForeColor = Color.IndianRed;
            labErrorText.Location = new Point(3, 582);
            labErrorText.Name = "labErrorText";
            labErrorText.Size = new Size(83, 21);
            labErrorText.TabIndex = 3;
            labErrorText.Text = "Error Text";
            // 
            // ilEntityTypes
            // 
            ilEntityTypes.ColorDepth = ColorDepth.Depth8Bit;
            ilEntityTypes.ImageStream = (ImageListStreamer)resources.GetObject("ilEntityTypes.ImageStream");
            ilEntityTypes.TransparentColor = Color.Transparent;
            ilEntityTypes.Images.SetKeyName(0, "icons8-tasks-16.png");
            ilEntityTypes.Images.SetKeyName(1, "icons8-task-16.png");
            ilEntityTypes.Images.SetKeyName(2, "icons8-step-16.png");
            // 
            // ilStatuses
            // 
            ilStatuses.ColorDepth = ColorDepth.Depth8Bit;
            ilStatuses.ImageStream = (ImageListStreamer)resources.GetObject("ilStatuses.ImageStream");
            ilStatuses.TransparentColor = Color.Transparent;
            ilStatuses.Images.SetKeyName(0, "icons8-in-progress-16.png");
            ilStatuses.Images.SetKeyName(1, "icons8-task-completed-16.png");
            ilStatuses.Images.SetKeyName(2, "icons8-cancel-16.png");
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 636);
            Controls.Add(panelMain);
            Name = "FormMain";
            Text = "Монітор процесу реплікації IP";
            Load += FormMain_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panelTaskStepsSplit.Panel1.ResumeLayout(false);
            panelTaskStepsSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panelTaskStepsSplit).EndInit();
            panelTaskStepsSplit.ResumeLayout(false);
            panelTasks.ResumeLayout(false);
            panel211.ResumeLayout(false);
            panel211.PerformLayout();
            panelSteps.ResumeLayout(false);
            panel212.ResumeLayout(false);
            panel212.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel panelMain;
        private FlowLayoutPanel panel1;
        private Label label1;
        private FlowLayoutPanel panel2;
        private Label label3;
        private FlowLayoutPanel panel4;
        private SplitContainer panelTaskStepsSplit;
        private TableLayoutPanel panelTasks;
        private TableLayoutPanel panelSteps;
        private Button btnClose;
        private FlowLayoutPanel panel211;
        private Label label4;
        private FlowLayoutPanel panel212;
        private Label label5;
        private ListView lvTasks;
        private ListView lvSteps;
        private ListView lvJobs;
        private TextBox tbIpiStartDate;
        private ImageList ilEntityTypes;
        private ImageList ilStatuses;
        private RadioButton rbFilterNext;
        private RadioButton rbFilterFinished;
        private Label labErrorText;
        private Button btnRefreshSteps;
        private ImageList ilActionIcons;
        private Button btnRefreshJobs;
        private Button btnRefreshTasks;
    }
}
