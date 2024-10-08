
namespace WidExport
{
    partial class UcMainWorks
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
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowGroup = new System.Windows.Forms.Button();
            this.lvWorks = new System.Windows.Forms.ListView();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.bntInfo = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelButtons, 0, 2);
            this.panelMain.Controls.Add(this.lvWorks, 0, 1);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(811, 359);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnShowGroup);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(3, 316);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(805, 32);
            this.panelButtons.TabIndex = 0;
            // 
            // btnShowGroup
            // 
            this.btnShowGroup.Location = new System.Drawing.Point(684, 3);
            this.btnShowGroup.Name = "btnShowGroup";
            this.btnShowGroup.Size = new System.Drawing.Size(118, 23);
            this.btnShowGroup.TabIndex = 1;
            this.btnShowGroup.Text = "Показати групу ...";
            this.btnShowGroup.UseVisualStyleBackColor = true;
            this.btnShowGroup.Click += new System.EventHandler(this.btnShowGroup_Click);
            // 
            // lvWorks
            // 
            this.lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorks.FullRowSelect = true;
            this.lvWorks.HideSelection = false;
            this.lvWorks.Location = new System.Drawing.Point(3, 42);
            this.lvWorks.MultiSelect = false;
            this.lvWorks.Name = "lvWorks";
            this.lvWorks.Size = new System.Drawing.Size(805, 268);
            this.lvWorks.TabIndex = 1;
            this.lvWorks.UseCompatibleStateImageBehavior = false;
            this.lvWorks.View = System.Windows.Forms.View.Details;
            this.lvWorks.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labSearch);
            this.panelTop.Controls.Add(this.tbSearch);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.bntInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(805, 33);
            this.panelTop.TabIndex = 2;
            // 
            // labSearch
            // 
            this.labSearch.AutoSize = true;
            this.labSearch.Location = new System.Drawing.Point(3, 7);
            this.labSearch.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labSearch.Name = "labSearch";
            this.labSearch.Size = new System.Drawing.Size(270, 13);
            this.labSearch.TabIndex = 0;
            this.labSearch.Text = "Показати перші 100 творів, які задовільняють умові";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(279, 4);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(313, 20);
            this.tbSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(598, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Показати";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bntInfo
            // 
            this.bntInfo.Location = new System.Drawing.Point(679, 3);
            this.bntInfo.Name = "bntInfo";
            this.bntInfo.Size = new System.Drawing.Size(75, 23);
            this.bntInfo.TabIndex = 3;
            this.bntInfo.Text = "Довідка";
            this.bntInfo.UseVisualStyleBackColor = true;
            this.bntInfo.Click += new System.EventHandler(this.bntInfo_Click);
            // 
            // UcMainWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcMainWorks";
            this.Size = new System.Drawing.Size(811, 359);
            this.Load += new System.EventHandler(this.UcMainWorks_Load);
            this.panelMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.ListView lvWorks;
        private System.Windows.Forms.Button btnShowGroup;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label labSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button bntInfo;
    }
}
