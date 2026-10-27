namespace CwrTools
{
    partial class UcOutputFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcOutputFiles));
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tvPartners = new System.Windows.Forms.TreeView();
            this.panelPartnerActions = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAddPartner = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnPartnerSettings = new System.Windows.Forms.ToolStripButton();
            this.ucPartnerOutputFiles = new CwrTools.UcPartnerOutputFiles();
            this.ucGroupOutputFiles = new CwrTools.UcGroupOutputFiles();
            this.ilPartnerGroups = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.panelMain.Panel2.Controls.Add(this.ucPartnerOutputFiles);
            this.panelMain.Panel2.Controls.Add(this.ucGroupOutputFiles);
            this.panelMain.Size = new System.Drawing.Size(977, 441);
            this.panelMain.SplitterDistance = 193;
            this.panelMain.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.ColumnCount = 1;
            this.panelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.Controls.Add(this.label4, 0, 0);
            this.panelLeft.Controls.Add(this.tvPartners, 0, 2);
            this.panelLeft.Controls.Add(this.panelPartnerActions, 0, 3);
            this.panelLeft.Controls.Add(this.toolStrip1, 0, 1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RowCount = 5;
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelLeft.Size = new System.Drawing.Size(193, 441);
            this.panelLeft.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Групи файлів / партнери";
            // 
            // tvPartners
            // 
            this.tvPartners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPartners.Location = new System.Drawing.Point(3, 69);
            this.tvPartners.Name = "tvPartners";
            this.tvPartners.Size = new System.Drawing.Size(187, 326);
            this.tvPartners.TabIndex = 1;
            this.tvPartners.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvPartners_BeforeLabelEdit);
            this.tvPartners.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvPartners_AfterLabelEdit);
            this.tvPartners.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvPartners_ItemDrag);
            this.tvPartners.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPartners_AfterSelect);
            this.tvPartners.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvPartners_DragDrop);
            this.tvPartners.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvPartners_DragEnter);
            this.tvPartners.DragOver += new System.Windows.Forms.DragEventHandler(this.tvPartners_DragOver);
            // 
            // panelPartnerActions
            // 
            this.panelPartnerActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPartnerActions.Location = new System.Drawing.Point(3, 401);
            this.panelPartnerActions.Name = "panelPartnerActions";
            this.panelPartnerActions.Size = new System.Drawing.Size(187, 27);
            this.panelPartnerActions.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddGroup,
            this.tsbtnAddPartner,
            this.tsbtnDelete,
            this.toolStripSeparator1,
            this.tsBtnPartnerSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(193, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAddGroup
            // 
            this.tsbtnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddGroup.Image")));
            this.tsbtnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddGroup.Name = "tsbtnAddGroup";
            this.tsbtnAddGroup.Size = new System.Drawing.Size(35, 22);
            this.tsbtnAddGroup.Text = "+";
            this.tsbtnAddGroup.ToolTipText = "Додати групу";
            this.tsbtnAddGroup.Click += new System.EventHandler(this.tsbtnAddGroup_Click);
            // 
            // tsbtnAddPartner
            // 
            this.tsbtnAddPartner.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddPartner.Image")));
            this.tsbtnAddPartner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddPartner.Name = "tsbtnAddPartner";
            this.tsbtnAddPartner.Size = new System.Drawing.Size(35, 22);
            this.tsbtnAddPartner.Text = "+";
            this.tsbtnAddPartner.ToolTipText = "Додати партнера";
            this.tsbtnAddPartner.Click += new System.EventHandler(this.tsbtnAddPartner_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDelete.Text = "Видалити групу/партнера";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnPartnerSettings
            // 
            this.tsBtnPartnerSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPartnerSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPartnerSettings.Image")));
            this.tsBtnPartnerSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPartnerSettings.Name = "tsBtnPartnerSettings";
            this.tsBtnPartnerSettings.Size = new System.Drawing.Size(23, 22);
            this.tsBtnPartnerSettings.ToolTipText = "Налаштування";
            this.tsBtnPartnerSettings.Click += new System.EventHandler(this.tsBtnPartnerSettings_Click);
            // 
            // ucPartnerOutputFiles
            // 
            this.ucPartnerOutputFiles.Location = new System.Drawing.Point(36, 273);
            this.ucPartnerOutputFiles.Name = "ucPartnerOutputFiles";
            this.ucPartnerOutputFiles.Size = new System.Drawing.Size(619, 155);
            this.ucPartnerOutputFiles.TabIndex = 3;
            // 
            // ucGroupOutputFiles
            // 
            this.ucGroupOutputFiles.Location = new System.Drawing.Point(36, -3);
            this.ucGroupOutputFiles.Name = "ucGroupOutputFiles";
            this.ucGroupOutputFiles.Size = new System.Drawing.Size(536, 280);
            this.ucGroupOutputFiles.TabIndex = 2;
            // 
            // ilPartnerGroups
            // 
            this.ilPartnerGroups.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPartnerGroups.ImageStream")));
            this.ilPartnerGroups.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPartnerGroups.Images.SetKeyName(0, "icons8-meeting-room-16.png");
            this.ilPartnerGroups.Images.SetKeyName(1, "icons8-partner-16.png");
            // 
            // UcOutputFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcOutputFiles";
            this.Size = new System.Drawing.Size(977, 441);
            this.Load += new System.EventHandler(this.UcOutputFiles_Load);
            this.panelMain.Panel1.ResumeLayout(false);
            this.panelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.TableLayoutPanel panelLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvPartners;
        private System.Windows.Forms.FlowLayoutPanel panelPartnerActions;
        private System.Windows.Forms.ImageList ilPartnerGroups;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAddGroup;
        private System.Windows.Forms.ToolStripButton tsbtnAddPartner;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnPartnerSettings;
        private UcGroupOutputFiles ucGroupOutputFiles;
        private UcPartnerOutputFiles ucPartnerOutputFiles;
    }
}
