namespace WidSubmit
{
    partial class UcRightHolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcRightHolders));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.panelMiddleLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lvRightHolders = new System.Windows.Forms.ListView();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labSearch = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.ilButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panelFilterOwnership = new System.Windows.Forms.FlowLayoutPanel();
            this.rbFilterOwn = new System.Windows.Forms.RadioButton();
            this.rbFilterForeign = new System.Windows.Forms.RadioButton();
            this.rbFilterOwnAndForeign = new System.Windows.Forms.RadioButton();
            this.panelFilterBySubmission = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBySubmission = new System.Windows.Forms.ComboBox();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdateRightHolders = new System.Windows.Forms.Button();
            this.btnChangeSubmRightHolders = new System.Windows.Forms.Button();
            this.panelMiddleRight = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvRightHolderHist = new System.Windows.Forms.ListView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelMiddleLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelFilterOwnership.SuspendLayout();
            this.panelFilterBySubmission.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMiddleRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Size = new System.Drawing.Size(1074, 562);
            this.panelMain.TabIndex = 0;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMiddle.Location = new System.Drawing.Point(3, 8);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.panelMiddleLeft);
            this.panelMiddle.Panel1MinSize = 200;
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.panelMiddleRight);
            this.panelMiddle.Size = new System.Drawing.Size(1063, 546);
            this.panelMiddle.SplitterDistance = 556;
            this.panelMiddle.TabIndex = 0;
            // 
            // panelMiddleLeft
            // 
            this.panelMiddleLeft.ColumnCount = 2;
            this.panelMiddleLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMiddleLeft.Controls.Add(this.lvRightHolders, 0, 3);
            this.panelMiddleLeft.Controls.Add(this.panelTop, 0, 2);
            this.panelMiddleLeft.Controls.Add(this.panelFilterOwnership, 0, 1);
            this.panelMiddleLeft.Controls.Add(this.panelFilterBySubmission, 0, 0);
            this.panelMiddleLeft.Controls.Add(this.panelBottom, 0, 4);
            this.panelMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddleLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMiddleLeft.Name = "panelMiddleLeft";
            this.panelMiddleLeft.RowCount = 6;
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelMiddleLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMiddleLeft.Size = new System.Drawing.Size(556, 546);
            this.panelMiddleLeft.TabIndex = 0;
            // 
            // lvRightHolders
            // 
            this.lvRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRightHolders.HideSelection = false;
            this.lvRightHolders.Location = new System.Drawing.Point(3, 102);
            this.lvRightHolders.Name = "lvRightHolders";
            this.lvRightHolders.Size = new System.Drawing.Size(545, 399);
            this.lvRightHolders.SmallImageList = this.ilStatuses;
            this.lvRightHolders.StateImageList = this.ilStatuses;
            this.lvRightHolders.TabIndex = 1;
            this.lvRightHolders.UseCompatibleStateImageBehavior = false;
            this.lvRightHolders.SelectedIndexChanged += new System.EventHandler(this.lvRightHolders_SelectedIndexChanged);
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
            // panelTop
            // 
            this.panelTop.AutoSize = true;
            this.panelTop.Controls.Add(this.labSearch);
            this.panelTop.Controls.Add(this.tbFilter);
            this.panelTop.Controls.Add(this.btnApplyFilter);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 67);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(545, 29);
            this.panelTop.TabIndex = 5;
            // 
            // labSearch
            // 
            this.labSearch.AutoSize = true;
            this.labSearch.Location = new System.Drawing.Point(3, 7);
            this.labSearch.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labSearch.Name = "labSearch";
            this.labSearch.Size = new System.Drawing.Size(106, 13);
            this.labSearch.TabIndex = 0;
            this.labSearch.Text = "Вибрати за умовою";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(115, 4);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(167, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.ImageIndex = 0;
            this.btnApplyFilter.ImageList = this.ilButtonIcons;
            this.btnApplyFilter.Location = new System.Drawing.Point(288, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(21, 23);
            this.btnApplyFilter.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnApplyFilter, "Застосувати фільтр");
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // ilButtonIcons
            // 
            this.ilButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilButtonIcons.ImageStream")));
            this.ilButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilButtonIcons.Images.SetKeyName(0, "angle-right-solid.ico");
            this.ilButtonIcons.Images.SetKeyName(1, "icons8-question.gif");
            // 
            // label3
            // 
            this.label3.ImageIndex = 1;
            this.label3.ImageList = this.ilButtonIcons;
            this.label3.Location = new System.Drawing.Point(315, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 23);
            this.label3.TabIndex = 4;
            this.toolTip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // panelFilterOwnership
            // 
            this.panelFilterOwnership.Controls.Add(this.rbFilterOwn);
            this.panelFilterOwnership.Controls.Add(this.rbFilterForeign);
            this.panelFilterOwnership.Controls.Add(this.rbFilterOwnAndForeign);
            this.panelFilterOwnership.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilterOwnership.Location = new System.Drawing.Point(3, 37);
            this.panelFilterOwnership.Name = "panelFilterOwnership";
            this.panelFilterOwnership.Size = new System.Drawing.Size(545, 24);
            this.panelFilterOwnership.TabIndex = 6;
            // 
            // rbFilterOwn
            // 
            this.rbFilterOwn.AutoSize = true;
            this.rbFilterOwn.Checked = true;
            this.rbFilterOwn.Location = new System.Drawing.Point(3, 3);
            this.rbFilterOwn.Name = "rbFilterOwn";
            this.rbFilterOwn.Size = new System.Drawing.Size(46, 17);
            this.rbFilterOwn.TabIndex = 0;
            this.rbFilterOwn.TabStop = true;
            this.rbFilterOwn.Text = "свої";
            this.rbFilterOwn.UseVisualStyleBackColor = true;
            this.rbFilterOwn.CheckedChanged += new System.EventHandler(this.rbFilterOwn_CheckedChanged);
            // 
            // rbFilterForeign
            // 
            this.rbFilterForeign.AutoSize = true;
            this.rbFilterForeign.Location = new System.Drawing.Point(55, 3);
            this.rbFilterForeign.Name = "rbFilterForeign";
            this.rbFilterForeign.Size = new System.Drawing.Size(68, 17);
            this.rbFilterForeign.TabIndex = 1;
            this.rbFilterForeign.Text = "сторонні";
            this.rbFilterForeign.UseVisualStyleBackColor = true;
            this.rbFilterForeign.CheckedChanged += new System.EventHandler(this.rbFilterForeign_CheckedChanged);
            // 
            // rbFilterOwnAndForeign
            // 
            this.rbFilterOwnAndForeign.AutoSize = true;
            this.rbFilterOwnAndForeign.Location = new System.Drawing.Point(129, 3);
            this.rbFilterOwnAndForeign.Name = "rbFilterOwnAndForeign";
            this.rbFilterOwnAndForeign.Size = new System.Drawing.Size(39, 17);
            this.rbFilterOwnAndForeign.TabIndex = 1;
            this.rbFilterOwnAndForeign.Text = "всі";
            this.rbFilterOwnAndForeign.UseVisualStyleBackColor = true;
            this.rbFilterOwnAndForeign.CheckedChanged += new System.EventHandler(this.rbFilterOwnAndForeign_CheckedChanged);
            // 
            // panelFilterBySubmission
            // 
            this.panelFilterBySubmission.Controls.Add(this.label1);
            this.panelFilterBySubmission.Controls.Add(this.cbFilterBySubmission);
            this.panelFilterBySubmission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilterBySubmission.Location = new System.Drawing.Point(3, 3);
            this.panelFilterBySubmission.Name = "panelFilterBySubmission";
            this.panelFilterBySubmission.Size = new System.Drawing.Size(545, 28);
            this.panelFilterBySubmission.TabIndex = 7;
            this.panelFilterBySubmission.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Правовласники";
            // 
            // cbFilterBySubmission
            // 
            this.cbFilterBySubmission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBySubmission.FormattingEnabled = true;
            this.cbFilterBySubmission.Location = new System.Drawing.Point(96, 3);
            this.cbFilterBySubmission.Name = "cbFilterBySubmission";
            this.cbFilterBySubmission.Size = new System.Drawing.Size(213, 21);
            this.cbFilterBySubmission.TabIndex = 1;
            this.cbFilterBySubmission.SelectedIndexChanged += new System.EventHandler(this.cbFilterBySubmission_SelectedIndexChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnUpdateRightHolders);
            this.panelBottom.Controls.Add(this.btnChangeSubmRightHolders);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(3, 507);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(545, 31);
            this.panelBottom.TabIndex = 8;
            // 
            // btnUpdateRightHolders
            // 
            this.btnUpdateRightHolders.AutoSize = true;
            this.btnUpdateRightHolders.Location = new System.Drawing.Point(341, 3);
            this.btnUpdateRightHolders.Name = "btnUpdateRightHolders";
            this.btnUpdateRightHolders.Size = new System.Drawing.Size(201, 23);
            this.btnUpdateRightHolders.TabIndex = 2;
            this.btnUpdateRightHolders.Text = "Оновити правовласників із СМАРТ";
            this.btnUpdateRightHolders.UseVisualStyleBackColor = true;
            this.btnUpdateRightHolders.Click += new System.EventHandler(this.btnUpdateRightHolders_Click);
            // 
            // btnChangeSubmRightHolders
            // 
            this.btnChangeSubmRightHolders.AutoSize = true;
            this.btnChangeSubmRightHolders.Location = new System.Drawing.Point(34, 3);
            this.btnChangeSubmRightHolders.Name = "btnChangeSubmRightHolders";
            this.btnChangeSubmRightHolders.Size = new System.Drawing.Size(301, 23);
            this.btnChangeSubmRightHolders.TabIndex = 2;
            this.btnChangeSubmRightHolders.Text = "Змінити перелік правовласників для поточної сесії";
            this.btnChangeSubmRightHolders.UseVisualStyleBackColor = true;
            this.btnChangeSubmRightHolders.Click += new System.EventHandler(this.btnChangeSubmRightHolders_Click);
            // 
            // panelMiddleRight
            // 
            this.panelMiddleRight.ColumnCount = 2;
            this.panelMiddleRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMiddleRight.Controls.Add(this.label2, 0, 0);
            this.panelMiddleRight.Controls.Add(this.lvRightHolderHist, 0, 1);
            this.panelMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddleRight.Location = new System.Drawing.Point(0, 0);
            this.panelMiddleRight.Name = "panelMiddleRight";
            this.panelMiddleRight.RowCount = 3;
            this.panelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddleRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMiddleRight.Size = new System.Drawing.Size(503, 546);
            this.panelMiddleRight.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Подробиці (параметри правовласника у проміжках часу)";
            // 
            // lvRightHolderHist
            // 
            this.lvRightHolderHist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRightHolderHist.HideSelection = false;
            this.lvRightHolderHist.Location = new System.Drawing.Point(3, 33);
            this.lvRightHolderHist.Name = "lvRightHolderHist";
            this.lvRightHolderHist.Size = new System.Drawing.Size(492, 505);
            this.lvRightHolderHist.SmallImageList = this.ilStatuses;
            this.lvRightHolderHist.StateImageList = this.ilStatuses;
            this.lvRightHolderHist.TabIndex = 1;
            this.lvRightHolderHist.UseCompatibleStateImageBehavior = false;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 32767;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // UcRightHolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcRightHolders";
            this.Size = new System.Drawing.Size(1074, 562);
            this.Load += new System.EventHandler(this.UcRightHolders_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.panelMiddleLeft.ResumeLayout(false);
            this.panelMiddleLeft.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFilterOwnership.ResumeLayout(false);
            this.panelFilterOwnership.PerformLayout();
            this.panelFilterBySubmission.ResumeLayout(false);
            this.panelFilterBySubmission.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelMiddleRight.ResumeLayout(false);
            this.panelMiddleRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.TableLayoutPanel panelMiddleLeft;
        private System.Windows.Forms.TableLayoutPanel panelMiddleRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvRightHolders;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label labSearch;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.ImageList ilButtonIcons;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvRightHolderHist;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.FlowLayoutPanel panelFilterOwnership;
        private System.Windows.Forms.RadioButton rbFilterOwn;
        private System.Windows.Forms.RadioButton rbFilterForeign;
        private System.Windows.Forms.RadioButton rbFilterOwnAndForeign;
        private System.Windows.Forms.FlowLayoutPanel panelFilterBySubmission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBySubmission;
        private System.Windows.Forms.Button btnUpdateRightHolders;
        private System.Windows.Forms.Button btnChangeSubmRightHolders;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
    }
}
