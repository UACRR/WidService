namespace CwrTools
{
    partial class UcGroupOutputFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcGroupOutputFiles));
            this.panelFiles = new System.Windows.Forms.TableLayoutPanel();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.labTitle = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbtnCreateFile = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteFile = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowFile = new System.Windows.Forms.ToolStripButton();
            this.ilPartnerGroups = new System.Windows.Forms.ImageList(this.components);
            this.panelFiles.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFiles
            // 
            this.panelFiles.ColumnCount = 1;
            this.panelFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFiles.Controls.Add(this.lvFiles, 0, 2);
            this.panelFiles.Controls.Add(this.panelTop, 0, 0);
            this.panelFiles.Controls.Add(this.toolStrip, 0, 1);
            this.panelFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFiles.Location = new System.Drawing.Point(0, 0);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.RowCount = 4;
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelFiles.Size = new System.Drawing.Size(977, 441);
            this.panelFiles.TabIndex = 1;
            // 
            // lvFiles
            // 
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(3, 73);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(971, 356);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // panelTop
            // 
            this.panelTop.ColumnCount = 2;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.panelTop.Controls.Add(this.labTitle, 0, 0);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 1;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(971, 32);
            this.panelTop.TabIndex = 3;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(3, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labTitle.Size = new System.Drawing.Size(178, 20);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Файли для передачі товариствам";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCreateFile,
            this.tsbtnDeleteFile,
            this.tsbtnShowFile});
            this.toolStrip.Location = new System.Drawing.Point(0, 38);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(977, 32);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbtnCreateFile
            // 
            this.tsbtnCreateFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCreateFile.Image")));
            this.tsbtnCreateFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreateFile.Name = "tsbtnCreateFile";
            this.tsbtnCreateFile.Size = new System.Drawing.Size(119, 29);
            this.tsbtnCreateFile.Text = "Створити файл";
            this.tsbtnCreateFile.ToolTipText = "Створити файл або оновити останній";
            this.tsbtnCreateFile.Click += new System.EventHandler(this.tsbtnCreateFile_Click);
            // 
            // tsbtnDeleteFile
            // 
            this.tsbtnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteFile.Image")));
            this.tsbtnDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteFile.Name = "tsbtnDeleteFile";
            this.tsbtnDeleteFile.Size = new System.Drawing.Size(119, 29);
            this.tsbtnDeleteFile.Text = "Видалити файл";
            this.tsbtnDeleteFile.ToolTipText = "Видалити файл";
            this.tsbtnDeleteFile.Click += new System.EventHandler(this.tsbtnDeleteFile_Click);
            // 
            // tsbtnShowFile
            // 
            this.tsbtnShowFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnShowFile.Image")));
            this.tsbtnShowFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowFile.Name = "tsbtnShowFile";
            this.tsbtnShowFile.Size = new System.Drawing.Size(143, 29);
            this.tsbtnShowFile.Text = "Показати в фолдері";
            this.tsbtnShowFile.ToolTipText = "Показати файл в фолдері";
            this.tsbtnShowFile.Click += new System.EventHandler(this.tsbtnShowFile_Click);
            // 
            // ilPartnerGroups
            // 
            this.ilPartnerGroups.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPartnerGroups.ImageStream")));
            this.ilPartnerGroups.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPartnerGroups.Images.SetKeyName(0, "icons8-meeting-room-16.png");
            this.ilPartnerGroups.Images.SetKeyName(1, "icons8-partner-16.png");
            // 
            // UcGroupOutputFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFiles);
            this.Name = "UcGroupOutputFiles";
            this.Size = new System.Drawing.Size(977, 441);
            this.Load += new System.EventHandler(this.UcOutputFiles_Load);
            this.panelFiles.ResumeLayout(false);
            this.panelFiles.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelFiles;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.ImageList ilPartnerGroups;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbtnCreateFile;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteFile;
        private System.Windows.Forms.ToolStripButton tsbtnShowFile;
    }
}
