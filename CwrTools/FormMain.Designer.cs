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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ilTabIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucOutputFiles = new CwrTools.UcOutputFiles();
            this.ucInputFiles = new CwrTools.UcInputFiles();
            this.ucProblemWorks = new CwrTools.UcProblemWorks();
            this.ucTools = new CwrTools.UcTools();
            this.tabMain.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ImageList = this.ilTabIcons;
            this.tabMain.Location = new System.Drawing.Point(3, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1202, 596);
            this.tabMain.TabIndex = 7;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucOutputFiles);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1194, 561);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Вихідні файли";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucInputFiles);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1194, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вхідні файли";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucProblemWorks);
            this.tabPage4.ImageIndex = 2;
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1194, 561);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Проблемні твори";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ilTabIcons
            // 
            this.ilTabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTabIcons.ImageStream")));
            this.ilTabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTabIcons.Images.SetKeyName(0, "InputFiles-16.png");
            this.ilTabIcons.Images.SetKeyName(1, "OutputFiles-16.png");
            this.ilTabIcons.Images.SetKeyName(2, "ProblemWorks-16.png");
            this.ilTabIcons.Images.SetKeyName(3, "Other-16.png");
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.tabMain, 0, 1);
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(1208, 655);
            this.panelMain.TabIndex = 8;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(3, 614);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1202, 30);
            this.panelBottom.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1124, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucTools);
            this.tabPage3.ImageIndex = 3;
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1194, 561);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Інше";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucOutputFiles
            // 
            this.ucOutputFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOutputFiles.Location = new System.Drawing.Point(3, 3);
            this.ucOutputFiles.Name = "ucOutputFiles";
            this.ucOutputFiles.Size = new System.Drawing.Size(1188, 555);
            this.ucOutputFiles.TabIndex = 0;
            // 
            // ucInputFiles
            // 
            this.ucInputFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInputFiles.Location = new System.Drawing.Point(3, 3);
            this.ucInputFiles.Name = "ucInputFiles";
            this.ucInputFiles.Size = new System.Drawing.Size(1188, 555);
            this.ucInputFiles.TabIndex = 0;
            // 
            // ucProblemWorks
            // 
            this.ucProblemWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProblemWorks.Location = new System.Drawing.Point(0, 0);
            this.ucProblemWorks.Name = "ucProblemWorks";
            this.ucProblemWorks.Size = new System.Drawing.Size(1194, 561);
            this.ucProblemWorks.TabIndex = 0;
            // 
            // ucTools
            // 
            this.ucTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTools.Location = new System.Drawing.Point(3, 3);
            this.ucTools.Name = "ucTools";
            this.ucTools.Size = new System.Drawing.Size(1188, 555);
            this.ucTools.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 655);
            this.Controls.Add(this.panelMain);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Інструменти CWR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnClose;
        private UcInputFiles ucInputFiles;
        private UcOutputFiles ucOutputFiles;
        private System.Windows.Forms.TabPage tabPage4;
        private UcProblemWorks ucProblemWorks;
        private System.Windows.Forms.ImageList ilTabIcons;
        private System.Windows.Forms.TabPage tabPage3;
        private UcTools ucTools;
    }
}

