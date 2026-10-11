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
            this.panelFiles = new System.Windows.Forms.TableLayoutPanel();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowInFolder = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNewFileFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tvPartners = new System.Windows.Forms.TreeView();
            this.panelPartnerActions = new System.Windows.Forms.FlowLayoutPanel();
            this.ilPartnerGroups = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAddPartner = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.panelFiles.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFiles
            // 
            this.panelFiles.ColumnCount = 1;
            this.panelFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFiles.Controls.Add(this.lvFiles, 0, 3);
            this.panelFiles.Controls.Add(this.panelBottom, 0, 4);
            this.panelFiles.Controls.Add(this.panelTop, 0, 0);
            this.panelFiles.Controls.Add(this.panel2, 0, 1);
            this.panelFiles.Controls.Add(this.label2, 0, 2);
            this.panelFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFiles.Location = new System.Drawing.Point(0, 0);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.RowCount = 6;
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelFiles.Size = new System.Drawing.Size(649, 441);
            this.panelFiles.TabIndex = 1;
            // 
            // lvFiles
            // 
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(3, 102);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(643, 291);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnShowInFolder);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(3, 399);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(643, 30);
            this.panelBottom.TabIndex = 2;
            // 
            // btnShowInFolder
            // 
            this.btnShowInFolder.Location = new System.Drawing.Point(502, 3);
            this.btnShowInFolder.Name = "btnShowInFolder";
            this.btnShowInFolder.Size = new System.Drawing.Size(138, 23);
            this.btnShowInFolder.TabIndex = 0;
            this.btnShowInFolder.Text = "Показати в фолдері";
            this.btnShowInFolder.UseVisualStyleBackColor = true;
            this.btnShowInFolder.Click += new System.EventHandler(this.btnShowInFolder_Click);
            // 
            // panelTop
            // 
            this.panelTop.ColumnCount = 2;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.panelTop.Controls.Add(this.label1, 0, 0);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 1;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(643, 32);
            this.panelTop.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файли для передачі товариствам";
            // 
            // panel2
            // 
            this.panel2.ColumnCount = 5;
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panel2.Controls.Add(this.btnCreateFile, 2, 0);
            this.panel2.Controls.Add(this.btnChangeStatus, 3, 0);
            this.panel2.Controls.Add(this.label3, 0, 0);
            this.panel2.Controls.Add(this.tbNewFileFullName, 1, 0);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 41);
            this.panel2.Name = "panel2";
            this.panel2.RowCount = 1;
            this.panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel2.Size = new System.Drawing.Size(643, 31);
            this.panel2.TabIndex = 4;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(315, 3);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(162, 23);
            this.btnCreateFile.TabIndex = 1;
            this.btnCreateFile.Text = "Створити/оновити файл";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(483, 3);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(147, 23);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "До передачі";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Новий файл";
            // 
            // tbNewFileFullName
            // 
            this.tbNewFileFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNewFileFullName.Location = new System.Drawing.Point(83, 5);
            this.tbNewFileFullName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbNewFileFullName.Name = "tbNewFileFullName";
            this.tbNewFileFullName.ReadOnly = true;
            this.tbNewFileFullName.Size = new System.Drawing.Size(226, 20);
            this.tbNewFileFullName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Попередні файли";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            // 
            // panelMain.Panel1
            // 
            this.panelMain.Panel1.Controls.Add(this.panelLeft);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.Controls.Add(this.panelFiles);
            this.panelMain.Size = new System.Drawing.Size(977, 441);
            this.panelMain.SplitterDistance = 324;
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
            this.panelLeft.Size = new System.Drawing.Size(324, 441);
            this.panelLeft.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Групи файлів";
            // 
            // tvPartners
            // 
            this.tvPartners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPartners.Location = new System.Drawing.Point(3, 69);
            this.tvPartners.Name = "tvPartners";
            this.tvPartners.Size = new System.Drawing.Size(318, 326);
            this.tvPartners.TabIndex = 1;
            this.tvPartners.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvPartners_BeforeLabelEdit);
            this.tvPartners.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvPartners_AfterLabelEdit);
            this.tvPartners.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvPartners_ItemDrag);
            this.tvPartners.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvPartners_DragDrop);
            this.tvPartners.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvPartners_DragEnter);
            this.tvPartners.DragOver += new System.Windows.Forms.DragEventHandler(this.tvPartners_DragOver);
            // 
            // panelPartnerActions
            // 
            this.panelPartnerActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPartnerActions.Location = new System.Drawing.Point(3, 401);
            this.panelPartnerActions.Name = "panelPartnerActions";
            this.panelPartnerActions.Size = new System.Drawing.Size(318, 27);
            this.panelPartnerActions.TabIndex = 2;
            // 
            // ilPartnerGroups
            // 
            this.ilPartnerGroups.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPartnerGroups.ImageStream")));
            this.ilPartnerGroups.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPartnerGroups.Images.SetKeyName(0, "icons8-meeting-room-16.png");
            this.ilPartnerGroups.Images.SetKeyName(1, "icons8-partner-16.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddGroup,
            this.tsbtnAddPartner,
            this.tsbtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(324, 25);
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
            // UcOutputFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcOutputFiles";
            this.Size = new System.Drawing.Size(977, 441);
            this.Load += new System.EventHandler(this.UcOutputFiles_Load);
            this.panelFiles.ResumeLayout(false);
            this.panelFiles.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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

        private System.Windows.Forms.TableLayoutPanel panelFiles;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnShowInFolder;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.TableLayoutPanel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNewFileFullName;
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
    }
}
