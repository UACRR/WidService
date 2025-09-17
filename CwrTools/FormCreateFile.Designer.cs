namespace CwrTools
{
    partial class FormCreateFile
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFolderFullName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.labResult = new System.Windows.Forms.Label();
            this.btnShowInFolder = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panel1, 0, 0);
            this.panelMain.Controls.Add(this.panel2, 0, 1);
            this.panelMain.Controls.Add(this.panel3, 0, 2);
            this.panelMain.Controls.Add(this.panel4, 0, 3);
            this.panelMain.Controls.Add(this.panel5, 0, 4);
            this.panelMain.Controls.Add(this.panel6, 0, 5);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 7;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Size = new System.Drawing.Size(545, 222);
            this.panelMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel1.Size = new System.Drawing.Size(537, 34);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва файлу (згідно вимогам)";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(198, 7);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(240, 20);
            this.tbFileName.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbFolderFullName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 45);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel2.Size = new System.Drawing.Size(537, 33);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Розташування файлу ";
            // 
            // tbFolderFullName
            // 
            this.tbFolderFullName.Location = new System.Drawing.Point(145, 7);
            this.tbFolderFullName.Name = "tbFolderFullName";
            this.tbFolderFullName.Size = new System.Drawing.Size(376, 20);
            this.tbFolderFullName.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCreateFile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panel3.Location = new System.Drawing.Point(4, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 28);
            this.panel3.TabIndex = 0;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(419, 3);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(115, 23);
            this.btnCreateFile.TabIndex = 0;
            this.btnCreateFile.Text = "Створити файл";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 120);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(537, 23);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labResult);
            this.panel5.Controls.Add(this.btnShowInFolder);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 150);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(537, 29);
            this.panel5.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnCLose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panel6.Location = new System.Drawing.Point(4, 186);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel6.Size = new System.Drawing.Size(537, 61);
            this.panel6.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Результат";
            // 
            // labResult
            // 
            this.labResult.Location = new System.Drawing.Point(3, 6);
            this.labResult.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(387, 20);
            this.labResult.TabIndex = 0;
            this.labResult.Text = "Файл успішно створений";
            // 
            // btnShowInFolder
            // 
            this.btnShowInFolder.Location = new System.Drawing.Point(396, 3);
            this.btnShowInFolder.Name = "btnShowInFolder";
            this.btnShowInFolder.Size = new System.Drawing.Size(128, 23);
            this.btnShowInFolder.TabIndex = 1;
            this.btnShowInFolder.Text = "Показати в фолдері";
            this.btnShowInFolder.UseVisualStyleBackColor = true;
            this.btnShowInFolder.Click += new System.EventHandler(this.btnShowInFolder_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.Location = new System.Drawing.Point(459, 7);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(75, 23);
            this.btnCLose.TabIndex = 0;
            this.btnCLose.Text = "Закрити";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // FormCreateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 222);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCreateFile";
            this.Text = "Створення файлу";
            this.Load += new System.EventHandler(this.FormCreateFile_Load);
            this.panelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.FlowLayoutPanel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFolderFullName;
        private System.Windows.Forms.FlowLayoutPanel panel3;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.FlowLayoutPanel panel4;
        private System.Windows.Forms.FlowLayoutPanel panel5;
        private System.Windows.Forms.FlowLayoutPanel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.Button btnShowInFolder;
        private System.Windows.Forms.Button btnCLose;
    }
}