
namespace WidExport
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ucMainWorkGroups = new WidExport.UcMainWorkGroups();
            this.ucFileExchange = new WidExport.UcMainFileExchange();
            this.ucAuthors = new WidExport.UcMainAuthors();
            this.ucWorks = new WidExport.UcMainWorks();
            this.ucPublishedWorks = new WidExport.UcMainPublishedWorks();
            this.ucStatistics = new WidExport.UcMainStatistics();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ucWidSubmWorksChanges = new WidExport.UcWidSubmWorksChanges();
            this.panelMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.tabMain, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1057, 494);
            this.panelMain.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage7);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage5);
            this.tabMain.Controls.Add(this.tabPage6);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 23);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1051, 428);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucMainWorkGroups);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1043, 402);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "Групи творів";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucFileExchange);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1043, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Файли обміну";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucAuthors);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1043, 402);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Пошук груп для правовласників";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucWorks);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1043, 402);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Пошук груп для творів";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ucPublishedWorks);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1043, 402);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Опубліковані твори";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ucStatistics);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1043, 402);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Статистика";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ucMainWorkGroups
            // 
            this.ucMainWorkGroups._selectedGroup = null;
            this.ucMainWorkGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMainWorkGroups.Location = new System.Drawing.Point(0, 0);
            this.ucMainWorkGroups.Name = "ucMainWorkGroups";
            this.ucMainWorkGroups.Size = new System.Drawing.Size(1043, 402);
            this.ucMainWorkGroups.TabIndex = 0;
            // 
            // ucFileExchange
            // 
            this.ucFileExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFileExchange.Location = new System.Drawing.Point(3, 3);
            this.ucFileExchange.Name = "ucFileExchange";
            this.ucFileExchange.Size = new System.Drawing.Size(1037, 396);
            this.ucFileExchange.TabIndex = 0;
            // 
            // ucAuthors
            // 
            this.ucAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAuthors.Location = new System.Drawing.Point(3, 3);
            this.ucAuthors.Name = "ucAuthors";
            this.ucAuthors.Size = new System.Drawing.Size(1037, 396);
            this.ucAuthors.TabIndex = 0;
            // 
            // ucWorks
            // 
            this.ucWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorks.Location = new System.Drawing.Point(3, 3);
            this.ucWorks.Name = "ucWorks";
            this.ucWorks.Size = new System.Drawing.Size(1037, 396);
            this.ucWorks.TabIndex = 0;
            // 
            // ucPublishedWorks
            // 
            this.ucPublishedWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPublishedWorks.Location = new System.Drawing.Point(3, 3);
            this.ucPublishedWorks.Name = "ucPublishedWorks";
            this.ucPublishedWorks.Size = new System.Drawing.Size(1037, 396);
            this.ucPublishedWorks.TabIndex = 0;
            // 
            // ucStatistics
            // 
            this.ucStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatistics.Location = new System.Drawing.Point(3, 3);
            this.ucStatistics.Name = "ucStatistics";
            this.ucStatistics.Size = new System.Drawing.Size(1037, 396);
            this.ucStatistics.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ucWidSubmWorksChanges);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1043, 402);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Зміни творів";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ucWidSubmWorksChanges
            // 
            this.ucWidSubmWorksChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWidSubmWorksChanges.Location = new System.Drawing.Point(3, 3);
            this.ucWidSubmWorksChanges.Name = "ucWidSubmWorksChanges";
            this.ucWidSubmWorksChanges.Size = new System.Drawing.Size(1037, 396);
            this.ucWidSubmWorksChanges.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 494);
            this.Controls.Add(this.panelMain);
            this.Name = "FormMain";
            this.Text = "Публікація творів в WID";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private UcMainFileExchange ucFileExchange;
        private System.Windows.Forms.TabPage tabPage1;
        private UcMainWorkGroups ucMainWorkGroups;
        private UcMainAuthors ucAuthors;
        private UcMainWorks ucWorks;
        private UcMainPublishedWorks ucPublishedWorks;
        private UcMainStatistics ucStatistics;
        private System.Windows.Forms.TabPage tabPage7;
        private UcWidSubmWorksChanges ucWidSubmWorksChanges;
    }
}

