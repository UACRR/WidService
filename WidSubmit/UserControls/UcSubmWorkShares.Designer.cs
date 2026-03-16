namespace WidSubmit
{
    partial class UcSubmWorkShares
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSubmWorkShares));
            this.lvSubmWorkShares = new System.Windows.Forms.ListView();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvDetails = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSubmWorkShares
            // 
            this.lvSubmWorkShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubmWorkShares.HideSelection = false;
            this.lvSubmWorkShares.Location = new System.Drawing.Point(3, 26);
            this.lvSubmWorkShares.Name = "lvSubmWorkShares";
            this.lvSubmWorkShares.Size = new System.Drawing.Size(488, 316);
            this.lvSubmWorkShares.SmallImageList = this.ilStatuses;
            this.lvSubmWorkShares.TabIndex = 0;
            this.lvSubmWorkShares.UseCompatibleStateImageBehavior = false;
            this.lvSubmWorkShares.SelectedIndexChanged += new System.EventHandler(this.lvSubmWorkShares_SelectedIndexChanged);
            this.lvSubmWorkShares.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvSubmWorkShares_MouseDown);
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
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            // 
            // panelMain.Panel1
            // 
            this.panelMain.Panel1.Controls.Add(this.panelLeft);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.Controls.Add(this.panelRight);
            this.panelMain.Size = new System.Drawing.Size(644, 350);
            this.panelMain.SplitterDistance = 494;
            this.panelMain.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.ColumnCount = 1;
            this.panelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.Controls.Add(this.lvSubmWorkShares, 0, 1);
            this.panelLeft.Controls.Add(this.label1, 0, 0);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RowCount = 3;
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelLeft.Size = new System.Drawing.Size(494, 350);
            this.panelLeft.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(137, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Проценти правовласника";
            // 
            // panelRight
            // 
            this.panelRight.ColumnCount = 1;
            this.panelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelRight.Controls.Add(this.label2, 0, 0);
            this.panelRight.Controls.Add(this.lvDetails, 0, 1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.RowCount = 3;
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelRight.Size = new System.Drawing.Size(146, 350);
            this.panelRight.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Подробиці";
            // 
            // lvDetails
            // 
            this.lvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetails.HideSelection = false;
            this.lvDetails.Location = new System.Drawing.Point(3, 27);
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(140, 315);
            this.lvDetails.StateImageList = this.ilStatuses;
            this.lvDetails.TabIndex = 1;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvDetails_MouseDown);
            // 
            // UcSubmWorkShares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelMain);
            this.Name = "UcSubmWorkShares";
            this.Size = new System.Drawing.Size(644, 350);
            this.Load += new System.EventHandler(this.UcSubmWorkShares_Load);
            this.panelMain.Panel1.ResumeLayout(false);
            this.panelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvSubmWorkShares;
        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.TableLayoutPanel panelLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.ImageList ilStatuses;
    }
}
