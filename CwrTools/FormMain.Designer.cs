namespace CwrTools
{
    partial class FormMain
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
            this.btnImportSpecs = new System.Windows.Forms.Button();
            this.btnCreateTables = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnCreateProcedures = new System.Windows.Forms.Button();
            this.btnCreateClasses = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnWriteFile = new System.Windows.Forms.Button();
            this.btnTestFile = new System.Windows.Forms.Button();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportSpecs
            // 
            this.btnImportSpecs.Enabled = false;
            this.btnImportSpecs.Location = new System.Drawing.Point(30, 12);
            this.btnImportSpecs.Name = "btnImportSpecs";
            this.btnImportSpecs.Size = new System.Drawing.Size(163, 23);
            this.btnImportSpecs.TabIndex = 0;
            this.btnImportSpecs.Text = "Імпортувати специфікації";
            this.btnImportSpecs.UseVisualStyleBackColor = true;
            this.btnImportSpecs.Click += new System.EventHandler(this.btnImportSpecs_Click);
            // 
            // btnCreateTables
            // 
            this.btnCreateTables.Enabled = false;
            this.btnCreateTables.Location = new System.Drawing.Point(199, 12);
            this.btnCreateTables.Name = "btnCreateTables";
            this.btnCreateTables.Size = new System.Drawing.Size(163, 23);
            this.btnCreateTables.TabIndex = 1;
            this.btnCreateTables.Text = "Створити таблиці";
            this.btnCreateTables.UseVisualStyleBackColor = true;
            this.btnCreateTables.Click += new System.EventHandler(this.btnCreateTables_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(30, 41);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(163, 23);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Завантажити файл";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnCreateProcedures
            // 
            this.btnCreateProcedures.Enabled = false;
            this.btnCreateProcedures.Location = new System.Drawing.Point(368, 12);
            this.btnCreateProcedures.Name = "btnCreateProcedures";
            this.btnCreateProcedures.Size = new System.Drawing.Size(159, 23);
            this.btnCreateProcedures.TabIndex = 3;
            this.btnCreateProcedures.Text = "Створити процедури";
            this.btnCreateProcedures.UseVisualStyleBackColor = true;
            this.btnCreateProcedures.Click += new System.EventHandler(this.btnCreateProcedures_Click);
            // 
            // btnCreateClasses
            // 
            this.btnCreateClasses.Enabled = false;
            this.btnCreateClasses.Location = new System.Drawing.Point(533, 12);
            this.btnCreateClasses.Name = "btnCreateClasses";
            this.btnCreateClasses.Size = new System.Drawing.Size(159, 23);
            this.btnCreateClasses.TabIndex = 4;
            this.btnCreateClasses.Text = "Створити класи";
            this.btnCreateClasses.UseVisualStyleBackColor = true;
            this.btnCreateClasses.Click += new System.EventHandler(this.btnCreateClasses_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Enabled = false;
            this.btnReadFile.Location = new System.Drawing.Point(199, 41);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(163, 23);
            this.btnReadFile.TabIndex = 5;
            this.btnReadFile.Text = "Зачитати файл";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnWriteFile
            // 
            this.btnWriteFile.Enabled = false;
            this.btnWriteFile.Location = new System.Drawing.Point(368, 41);
            this.btnWriteFile.Name = "btnWriteFile";
            this.btnWriteFile.Size = new System.Drawing.Size(159, 23);
            this.btnWriteFile.TabIndex = 6;
            this.btnWriteFile.Text = "Записати файл";
            this.btnWriteFile.UseVisualStyleBackColor = true;
            this.btnWriteFile.Click += new System.EventHandler(this.btnWriteFile_Click);
            // 
            // btnTestFile
            // 
            this.btnTestFile.Enabled = false;
            this.btnTestFile.Location = new System.Drawing.Point(533, 41);
            this.btnTestFile.Name = "btnTestFile";
            this.btnTestFile.Size = new System.Drawing.Size(159, 23);
            this.btnTestFile.TabIndex = 6;
            this.btnTestFile.Text = "Тестувати файл";
            this.btnTestFile.UseVisualStyleBackColor = true;
            this.btnTestFile.Click += new System.EventHandler(this.btnTestFile_Click);
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(34, 86);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(159, 23);
            this.btnCreateFile.TabIndex = 6;
            this.btnCreateFile.Text = "Створити файл";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(199, 86);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(159, 23);
            this.btnSendFile.TabIndex = 6;
            this.btnSendFile.Text = "Передати файл";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 127);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.btnTestFile);
            this.Controls.Add(this.btnWriteFile);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.btnCreateClasses);
            this.Controls.Add(this.btnCreateProcedures);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnCreateTables);
            this.Controls.Add(this.btnImportSpecs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Інструменти CWR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportSpecs;
        private System.Windows.Forms.Button btnCreateTables;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnCreateProcedures;
        private System.Windows.Forms.Button btnCreateClasses;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button btnWriteFile;
        private System.Windows.Forms.Button btnTestFile;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.Button btnSendFile;
    }
}

