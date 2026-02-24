namespace WidSubmit
{
    partial class FormSubmissionRightHolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSubmissionRightHolders));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.panelOwnRightHolders = new System.Windows.Forms.TableLayoutPanel();
            this.lvOwnRightHolders = new System.Windows.Forms.ListView();
            this.panelMiddleLeftTop = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ilButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelSubmRightHolders = new System.Windows.Forms.TableLayoutPanel();
            this.lvSubmRightHolders = new System.Windows.Forms.ListView();
            this.panelMiddleRightTop = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelOwnRightHolders.SuspendLayout();
            this.panelMiddleLeftTop.SuspendLayout();
            this.panelSubmRightHolders.SuspendLayout();
            this.panelMiddleRightTop.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(3, 33);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.panelOwnRightHolders);
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.panelSubmRightHolders);
            this.panelMiddle.Size = new System.Drawing.Size(789, 373);
            this.panelMiddle.SplitterDistance = 314;
            this.panelMiddle.TabIndex = 0;
            // 
            // panelOwnRightHolders
            // 
            this.panelOwnRightHolders.ColumnCount = 2;
            this.panelOwnRightHolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelOwnRightHolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelOwnRightHolders.Controls.Add(this.lvOwnRightHolders, 0, 1);
            this.panelOwnRightHolders.Controls.Add(this.panelMiddleLeftTop, 0, 0);
            this.panelOwnRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOwnRightHolders.Location = new System.Drawing.Point(0, 0);
            this.panelOwnRightHolders.Name = "panelOwnRightHolders";
            this.panelOwnRightHolders.RowCount = 3;
            this.panelOwnRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelOwnRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelOwnRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelOwnRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelOwnRightHolders.Size = new System.Drawing.Size(314, 373);
            this.panelOwnRightHolders.TabIndex = 0;
            // 
            // lvOwnRightHolders
            // 
            this.lvOwnRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOwnRightHolders.HideSelection = false;
            this.lvOwnRightHolders.Location = new System.Drawing.Point(3, 33);
            this.lvOwnRightHolders.Name = "lvOwnRightHolders";
            this.lvOwnRightHolders.Size = new System.Drawing.Size(303, 332);
            this.lvOwnRightHolders.TabIndex = 0;
            this.lvOwnRightHolders.UseCompatibleStateImageBehavior = false;
            this.lvOwnRightHolders.SelectedIndexChanged += new System.EventHandler(this.lvOwnRightHolders_SelectedIndexChanged);
            this.lvOwnRightHolders.DoubleClick += new System.EventHandler(this.lvOwnRightHolders_DoubleClick);
            // 
            // panelMiddleLeftTop
            // 
            this.panelMiddleLeftTop.Controls.Add(this.label1);
            this.panelMiddleLeftTop.Controls.Add(this.label4);
            this.panelMiddleLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddleLeftTop.Location = new System.Drawing.Point(3, 3);
            this.panelMiddleLeftTop.Name = "panelMiddleLeftTop";
            this.panelMiddleLeftTop.Size = new System.Drawing.Size(303, 24);
            this.panelMiddleLeftTop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(148, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Правовласники товариства";
            // 
            // label4
            // 
            this.label4.ImageIndex = 1;
            this.label4.ImageList = this.ilButtonIcons;
            this.label4.Location = new System.Drawing.Point(157, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 23);
            this.label4.TabIndex = 5;
            this.toolTipHelp.SetToolTip(this.label4, "Для додавання або виключення правовласника\r\nіз переліку для передачі творів в WID" +
        "\r\nзробіть подвійний клік на відповідному рядку.");
            // 
            // ilButtonIcons
            // 
            this.ilButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilButtonIcons.ImageStream")));
            this.ilButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilButtonIcons.Images.SetKeyName(0, "angle-right-solid.ico");
            this.ilButtonIcons.Images.SetKeyName(1, "icons8-question.gif");
            // 
            // panelSubmRightHolders
            // 
            this.panelSubmRightHolders.ColumnCount = 2;
            this.panelSubmRightHolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSubmRightHolders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelSubmRightHolders.Controls.Add(this.lvSubmRightHolders, 0, 1);
            this.panelSubmRightHolders.Controls.Add(this.panelMiddleRightTop, 0, 0);
            this.panelSubmRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSubmRightHolders.Location = new System.Drawing.Point(0, 0);
            this.panelSubmRightHolders.Name = "panelSubmRightHolders";
            this.panelSubmRightHolders.RowCount = 3;
            this.panelSubmRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelSubmRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSubmRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelSubmRightHolders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSubmRightHolders.Size = new System.Drawing.Size(471, 373);
            this.panelSubmRightHolders.TabIndex = 0;
            // 
            // lvSubmRightHolders
            // 
            this.lvSubmRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubmRightHolders.HideSelection = false;
            this.lvSubmRightHolders.Location = new System.Drawing.Point(3, 33);
            this.lvSubmRightHolders.Name = "lvSubmRightHolders";
            this.lvSubmRightHolders.Size = new System.Drawing.Size(460, 332);
            this.lvSubmRightHolders.TabIndex = 0;
            this.lvSubmRightHolders.UseCompatibleStateImageBehavior = false;
            this.lvSubmRightHolders.SelectedIndexChanged += new System.EventHandler(this.lvSubmRightHolders_SelectedIndexChanged);
            this.lvSubmRightHolders.DoubleClick += new System.EventHandler(this.lvSubmRightHolders_DoubleClick);
            // 
            // panelMiddleRightTop
            // 
            this.panelMiddleRightTop.Controls.Add(this.label2);
            this.panelMiddleRightTop.Controls.Add(this.label5);
            this.panelMiddleRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddleRightTop.Location = new System.Drawing.Point(3, 3);
            this.panelMiddleRightTop.Name = "panelMiddleRightTop";
            this.panelMiddleRightTop.Size = new System.Drawing.Size(460, 24);
            this.panelMiddleRightTop.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(188, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Правовласники для передачі творів";
            // 
            // label5
            // 
            this.label5.ImageIndex = 1;
            this.label5.ImageList = this.ilButtonIcons;
            this.label5.Location = new System.Drawing.Point(197, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 23);
            this.label5.TabIndex = 5;
            this.toolTipHelp.SetToolTip(this.label5, "Для зміни значення \"Свій для WID\" на протилежне\r\nзробіть подвійний клік на відпов" +
        "ідному рядку.");
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(789, 24);
            this.panelTop.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(518, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Виберіть правовласників з переліку зліва, твори яких будуть розглянуті для поточн" +
    "ої передачі в WID";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnApply);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(3, 412);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(789, 30);
            this.panelBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(711, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Відмінити";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(618, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Застосувати";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
            // toolTipHelp
            // 
            this.toolTipHelp.AutoPopDelay = 32767;
            this.toolTipHelp.InitialDelay = 500;
            this.toolTipHelp.IsBalloon = true;
            this.toolTipHelp.ReshowDelay = 100;
            this.toolTipHelp.ShowAlways = true;
            // 
            // FormSubmissionRightHolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormSubmissionRightHolders";
            this.Text = "Правовласники для передачі творів";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSubmissionRightHolders_FormClosing);
            this.Load += new System.EventHandler(this.FormSubmissionRightHolders_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.panelOwnRightHolders.ResumeLayout(false);
            this.panelMiddleLeftTop.ResumeLayout(false);
            this.panelMiddleLeftTop.PerformLayout();
            this.panelSubmRightHolders.ResumeLayout(false);
            this.panelMiddleRightTop.ResumeLayout(false);
            this.panelMiddleRightTop.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.TableLayoutPanel panelOwnRightHolders;
        private System.Windows.Forms.TableLayoutPanel panelSubmRightHolders;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.ListView lvOwnRightHolders;
        private System.Windows.Forms.ListView lvSubmRightHolders;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel panelMiddleLeftTop;
        private System.Windows.Forms.FlowLayoutPanel panelMiddleRightTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList ilButtonIcons;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.Label label5;
    }
}