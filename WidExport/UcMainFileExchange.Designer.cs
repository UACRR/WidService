
namespace WidExport
{
    partial class UcMainFileExchange
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadResponces = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSendToFtp = new System.Windows.Forms.Button();
            this.btnShowGroup = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnShowRespFileInFolder = new System.Windows.Forms.Button();
            this.btnShowSubmFileInFolder = new System.Windows.Forms.Button();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.btnLoadResponces, 0, 0);
            this.panelMain.Controls.Add(this.panelButtons, 0, 2);
            this.panelMain.Controls.Add(this.lvFiles, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(1017, 493);
            this.panelMain.TabIndex = 0;
            // 
            // btnLoadResponces
            // 
            this.btnLoadResponces.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLoadResponces.AutoSize = true;
            this.btnLoadResponces.Location = new System.Drawing.Point(885, 3);
            this.btnLoadResponces.Name = "btnLoadResponces";
            this.btnLoadResponces.Size = new System.Drawing.Size(129, 26);
            this.btnLoadResponces.TabIndex = 0;
            this.btnLoadResponces.Text = "Завантажити відповіді";
            this.btnLoadResponces.UseVisualStyleBackColor = true;
            this.btnLoadResponces.Click += new System.EventHandler(this.btnLoadResponces_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSendToFtp);
            this.panelButtons.Controls.Add(this.btnShowGroup);
            this.panelButtons.Controls.Add(this.btnDeleteFile);
            this.panelButtons.Controls.Add(this.btnShowRespFileInFolder);
            this.panelButtons.Controls.Add(this.btnShowSubmFileInFolder);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(3, 450);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1011, 32);
            this.panelButtons.TabIndex = 0;
            // 
            // btnSendToFtp
            // 
            this.btnSendToFtp.Location = new System.Drawing.Point(891, 3);
            this.btnSendToFtp.Name = "btnSendToFtp";
            this.btnSendToFtp.Size = new System.Drawing.Size(117, 23);
            this.btnSendToFtp.TabIndex = 2;
            this.btnSendToFtp.Text = "Передати";
            this.btnSendToFtp.UseVisualStyleBackColor = true;
            this.btnSendToFtp.Click += new System.EventHandler(this.btnSendToFtp_Click);
            // 
            // btnShowGroup
            // 
            this.btnShowGroup.Location = new System.Drawing.Point(767, 3);
            this.btnShowGroup.Name = "btnShowGroup";
            this.btnShowGroup.Size = new System.Drawing.Size(118, 23);
            this.btnShowGroup.TabIndex = 1;
            this.btnShowGroup.Text = "Показати групу ...";
            this.btnShowGroup.UseVisualStyleBackColor = true;
            this.btnShowGroup.Click += new System.EventHandler(this.btnShowGroup_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.AutoSize = true;
            this.btnDeleteFile.Location = new System.Drawing.Point(632, 3);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(129, 23);
            this.btnDeleteFile.TabIndex = 0;
            this.btnDeleteFile.Text = "Видалити файл";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnShowRespFileInFolder
            // 
            this.btnShowRespFileInFolder.AutoSize = true;
            this.btnShowRespFileInFolder.Location = new System.Drawing.Point(472, 3);
            this.btnShowRespFileInFolder.Name = "btnShowRespFileInFolder";
            this.btnShowRespFileInFolder.Size = new System.Drawing.Size(154, 23);
            this.btnShowRespFileInFolder.TabIndex = 0;
            this.btnShowRespFileInFolder.Text = "Показати файл відповіді";
            this.btnShowRespFileInFolder.UseVisualStyleBackColor = true;
            this.btnShowRespFileInFolder.Click += new System.EventHandler(this.btnShowRespFileInFolder_Click);
            // 
            // btnShowSubmFileInFolder
            // 
            this.btnShowSubmFileInFolder.AutoSize = true;
            this.btnShowSubmFileInFolder.Location = new System.Drawing.Point(312, 3);
            this.btnShowSubmFileInFolder.Name = "btnShowSubmFileInFolder";
            this.btnShowSubmFileInFolder.Size = new System.Drawing.Size(154, 23);
            this.btnShowSubmFileInFolder.TabIndex = 0;
            this.btnShowSubmFileInFolder.Text = "Показати файл публікації";
            this.btnShowSubmFileInFolder.UseVisualStyleBackColor = true;
            this.btnShowSubmFileInFolder.Click += new System.EventHandler(this.btnShowSubmFileInFolder_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(3, 35);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(1011, 409);
            this.lvFiles.TabIndex = 1;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // UcMainFileExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcMainFileExchange";
            this.Size = new System.Drawing.Size(1017, 493);
            this.Load += new System.EventHandler(this.UcMainFileExchange_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnLoadResponces;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Button btnShowGroup;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnSendToFtp;
        private System.Windows.Forms.Button btnShowSubmFileInFolder;
        private System.Windows.Forms.Button btnShowRespFileInFolder;
    }
}
