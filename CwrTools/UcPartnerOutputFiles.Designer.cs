
namespace CwrTools
{
    partial class UcPartnerOutputFiles
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
            this.labTitle = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.panelDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.tbBaseFileName = new System.Windows.Forms.TextBox();
            this.tbFileStatus = new System.Windows.Forms.TextBox();
            this.tbFileSentAt = new System.Windows.Forms.TextBox();
            this.tbFileAnsweredAt = new System.Windows.Forms.TextBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.btnApplyBaseFile = new System.Windows.Forms.Button();
            this.btnSetStatus = new System.Windows.Forms.Button();
            this.btnShowFile = new System.Windows.Forms.Button();
            this.btnShowBaseFile = new System.Windows.Forms.Button();
            this.btnSetCanceled = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditComment = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.labTitle, 0, 0);
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelMain.Size = new System.Drawing.Size(1039, 474);
            this.panelMain.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(3, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labTitle.Size = new System.Drawing.Size(114, 20);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Передача файлів для";
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMiddle.IsSplitterFixed = true;
            this.panelMiddle.Location = new System.Drawing.Point(3, 36);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.lvFiles);
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.panelDetails);
            this.panelMiddle.Size = new System.Drawing.Size(1033, 425);
            this.panelMiddle.SplitterDistance = 306;
            this.panelMiddle.TabIndex = 3;
            // 
            // lvFiles
            // 
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(306, 425);
            this.lvFiles.TabIndex = 2;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // panelDetails
            // 
            this.panelDetails.ColumnCount = 4;
            this.panelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.panelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.panelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.panelDetails.Controls.Add(this.label2, 0, 0);
            this.panelDetails.Controls.Add(this.label1, 0, 1);
            this.panelDetails.Controls.Add(this.label3, 0, 2);
            this.panelDetails.Controls.Add(this.label4, 0, 3);
            this.panelDetails.Controls.Add(this.tbFileName, 1, 0);
            this.panelDetails.Controls.Add(this.tbBaseFileName, 1, 1);
            this.panelDetails.Controls.Add(this.tbFileStatus, 1, 2);
            this.panelDetails.Controls.Add(this.tbFileSentAt, 1, 3);
            this.panelDetails.Controls.Add(this.tbFileAnsweredAt, 1, 4);
            this.panelDetails.Controls.Add(this.tbComment, 1, 5);
            this.panelDetails.Controls.Add(this.btnApplyBaseFile, 2, 1);
            this.panelDetails.Controls.Add(this.btnSetStatus, 2, 2);
            this.panelDetails.Controls.Add(this.btnShowFile, 2, 0);
            this.panelDetails.Controls.Add(this.btnShowBaseFile, 3, 1);
            this.panelDetails.Controls.Add(this.btnSetCanceled, 3, 2);
            this.panelDetails.Controls.Add(this.label6, 0, 4);
            this.panelDetails.Controls.Add(this.label5, 0, 5);
            this.panelDetails.Controls.Add(this.btnEditComment, 2, 5);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.RowCount = 7;
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelDetails.Size = new System.Drawing.Size(723, 425);
            this.panelDetails.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Файл для передачі";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Базовий файл";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(131, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Статус процесу передачі";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Дата передачі";
            // 
            // tbFileName
            // 
            this.tbFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFileName.Location = new System.Drawing.Point(142, 3);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(319, 20);
            this.tbFileName.TabIndex = 2;
            // 
            // tbBaseFileName
            // 
            this.tbBaseFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBaseFileName.Location = new System.Drawing.Point(142, 29);
            this.tbBaseFileName.Name = "tbBaseFileName";
            this.tbBaseFileName.ReadOnly = true;
            this.tbBaseFileName.Size = new System.Drawing.Size(319, 20);
            this.tbBaseFileName.TabIndex = 2;
            // 
            // tbFileStatus
            // 
            this.tbFileStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFileStatus.Location = new System.Drawing.Point(142, 55);
            this.tbFileStatus.Name = "tbFileStatus";
            this.tbFileStatus.ReadOnly = true;
            this.tbFileStatus.Size = new System.Drawing.Size(319, 20);
            this.tbFileStatus.TabIndex = 2;
            // 
            // tbFileSentAt
            // 
            this.tbFileSentAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFileSentAt.Location = new System.Drawing.Point(142, 81);
            this.tbFileSentAt.Name = "tbFileSentAt";
            this.tbFileSentAt.ReadOnly = true;
            this.tbFileSentAt.Size = new System.Drawing.Size(319, 20);
            this.tbFileSentAt.TabIndex = 2;
            // 
            // tbFileAnsweredAt
            // 
            this.tbFileAnsweredAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFileAnsweredAt.Location = new System.Drawing.Point(142, 107);
            this.tbFileAnsweredAt.Name = "tbFileAnsweredAt";
            this.tbFileAnsweredAt.ReadOnly = true;
            this.tbFileAnsweredAt.Size = new System.Drawing.Size(319, 20);
            this.tbFileAnsweredAt.TabIndex = 2;
            // 
            // tbComment
            // 
            this.tbComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbComment.Location = new System.Drawing.Point(142, 133);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ReadOnly = true;
            this.tbComment.Size = new System.Drawing.Size(319, 284);
            this.tbComment.TabIndex = 2;
            // 
            // btnApplyBaseFile
            // 
            this.btnApplyBaseFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApplyBaseFile.Location = new System.Drawing.Point(467, 29);
            this.btnApplyBaseFile.Name = "btnApplyBaseFile";
            this.btnApplyBaseFile.Size = new System.Drawing.Size(123, 20);
            this.btnApplyBaseFile.TabIndex = 4;
            this.btnApplyBaseFile.Text = "Обрати для передачі";
            this.btnApplyBaseFile.UseVisualStyleBackColor = true;
            this.btnApplyBaseFile.Click += new System.EventHandler(this.btnApplyBaseFile_Click);
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetStatus.Location = new System.Drawing.Point(467, 55);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(123, 20);
            this.btnSetStatus.TabIndex = 4;
            this.btnSetStatus.Text = "Надіслати";
            this.btnSetStatus.UseVisualStyleBackColor = true;
            this.btnSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // btnShowFile
            // 
            this.btnShowFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowFile.Location = new System.Drawing.Point(467, 3);
            this.btnShowFile.Name = "btnShowFile";
            this.btnShowFile.Size = new System.Drawing.Size(123, 20);
            this.btnShowFile.TabIndex = 3;
            this.btnShowFile.Text = "Показати в фолдері";
            this.btnShowFile.UseVisualStyleBackColor = true;
            this.btnShowFile.Click += new System.EventHandler(this.btnShowFile_Click);
            // 
            // btnShowBaseFile
            // 
            this.btnShowBaseFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowBaseFile.Location = new System.Drawing.Point(596, 29);
            this.btnShowBaseFile.Name = "btnShowBaseFile";
            this.btnShowBaseFile.Size = new System.Drawing.Size(124, 20);
            this.btnShowBaseFile.TabIndex = 3;
            this.btnShowBaseFile.Text = "Показати в фолдері";
            this.btnShowBaseFile.UseVisualStyleBackColor = true;
            this.btnShowBaseFile.Click += new System.EventHandler(this.btnShowBaseFile_Click);
            // 
            // btnSetCanceled
            // 
            this.btnSetCanceled.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetCanceled.Location = new System.Drawing.Point(596, 55);
            this.btnSetCanceled.Name = "btnSetCanceled";
            this.btnSetCanceled.Size = new System.Drawing.Size(124, 20);
            this.btnSetCanceled.TabIndex = 3;
            this.btnSetCanceled.Text = "Файл відхилено";
            this.btnSetCanceled.UseVisualStyleBackColor = true;
            this.btnSetCanceled.Click += new System.EventHandler(this.btnSetCanceled_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 104);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Дата відповіді";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 130);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Коментар із відповіді";
            // 
            // btnEditComment
            // 
            this.btnEditComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditComment.Location = new System.Drawing.Point(467, 133);
            this.btnEditComment.Name = "btnEditComment";
            this.btnEditComment.Size = new System.Drawing.Size(123, 20);
            this.btnEditComment.TabIndex = 4;
            this.btnEditComment.Text = "Редагувати";
            this.btnEditComment.UseVisualStyleBackColor = true;
            this.btnEditComment.Click += new System.EventHandler(this.btnEditComment_Click);
            // 
            // UcPartnerOutputFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcPartnerOutputFiles";
            this.Size = new System.Drawing.Size(1039, 474);
            this.Load += new System.EventHandler(this.UcPartnerOutputFiles_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.TableLayoutPanel panelDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.TextBox tbBaseFileName;
        private System.Windows.Forms.TextBox tbFileStatus;
        private System.Windows.Forms.TextBox tbFileSentAt;
        private System.Windows.Forms.TextBox tbFileAnsweredAt;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Button btnApplyBaseFile;
        private System.Windows.Forms.Button btnSetStatus;
        private System.Windows.Forms.Button btnShowFile;
        private System.Windows.Forms.Button btnShowBaseFile;
        private System.Windows.Forms.Button btnSetCanceled;
        private System.Windows.Forms.Button btnEditComment;
    }
}
