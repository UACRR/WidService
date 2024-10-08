
namespace WidExport
{
    partial class FormWidWorkSearch
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
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIswc = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lvWorks = new System.Windows.Forms.ListView();
            this.btnApplyIswc = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Controls.Add(this.lvWorks, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelMain.Size = new System.Drawing.Size(755, 393);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.tbIswc);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(749, 33);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код ISWC";
            // 
            // tbIswc
            // 
            this.tbIswc.Location = new System.Drawing.Point(66, 5);
            this.tbIswc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbIswc.Name = "tbIswc";
            this.tbIswc.Size = new System.Drawing.Size(136, 20);
            this.tbIswc.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Шукати";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnApply);
            this.panelBottom.Controls.Add(this.btnApplyIswc);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(3, 350);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(749, 31);
            this.panelBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(671, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Відмінити";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(480, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(185, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Запам\'ятати і не відправляти";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lvWorks
            // 
            this.lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorks.FullRowSelect = true;
            this.lvWorks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvWorks.HideSelection = false;
            this.lvWorks.Location = new System.Drawing.Point(3, 42);
            this.lvWorks.MultiSelect = false;
            this.lvWorks.Name = "lvWorks";
            this.lvWorks.Size = new System.Drawing.Size(749, 302);
            this.lvWorks.TabIndex = 2;
            this.lvWorks.UseCompatibleStateImageBehavior = false;
            this.lvWorks.View = System.Windows.Forms.View.Details;
            this.lvWorks.SelectedIndexChanged += new System.EventHandler(this.lvWorks_SelectedIndexChanged);
            // 
            // btnApplyIswc
            // 
            this.btnApplyIswc.Location = new System.Drawing.Point(289, 3);
            this.btnApplyIswc.Name = "btnApplyIswc";
            this.btnApplyIswc.Size = new System.Drawing.Size(185, 23);
            this.btnApplyIswc.TabIndex = 0;
            this.btnApplyIswc.Text = "Запам\'ятати ISWC і відправити";
            this.btnApplyIswc.UseVisualStyleBackColor = true;
            this.btnApplyIswc.Click += new System.EventHandler(this.btnApplyIswc_Click);
            // 
            // FormWidWorkSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 393);
            this.Controls.Add(this.panelMain);
            this.Name = "FormWidWorkSearch";
            this.Text = "Пошук в WID";
            this.Load += new System.EventHandler(this.FormWidWorkSearch_Load);
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIswc;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ListView lvWorks;
        private System.Windows.Forms.Button btnApplyIswc;
    }
}