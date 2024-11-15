
namespace RadioStationReports
{
    partial class UcReportLineWork
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
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            lvWorks = new System.Windows.Forms.ListView();
            panelBottom = new System.Windows.Forms.TableLayoutPanel();
            btnApply = new System.Windows.Forms.Button();
            tbValue = new System.Windows.Forms.TextBox();
            labParamName = new System.Windows.Forms.Label();
            panelMain.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.Controls.Add(lvWorks, 0, 0);
            panelMain.Controls.Add(panelBottom, 0, 1);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 3;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            panelMain.Size = new System.Drawing.Size(895, 431);
            panelMain.TabIndex = 0;
            // 
            // lvWorks
            // 
            lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            lvWorks.HideSelection = false;
            lvWorks.Location = new System.Drawing.Point(3, 3);
            lvWorks.Name = "lvWorks";
            lvWorks.Size = new System.Drawing.Size(889, 383);
            lvWorks.TabIndex = 0;
            lvWorks.UseCompatibleStateImageBehavior = false;
            lvWorks.SelectedIndexChanged += lvWorks_SelectedIndexChanged;
            // 
            // panelBottom
            // 
            panelBottom.ColumnCount = 4;
            panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            panelBottom.Controls.Add(btnApply, 2, 0);
            panelBottom.Controls.Add(tbValue, 1, 0);
            panelBottom.Controls.Add(labParamName, 0, 0);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBottom.Location = new System.Drawing.Point(3, 392);
            panelBottom.Name = "panelBottom";
            panelBottom.RowCount = 1;
            panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelBottom.Size = new System.Drawing.Size(889, 28);
            panelBottom.TabIndex = 1;
            // 
            // btnApply
            // 
            btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            btnApply.Location = new System.Drawing.Point(809, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(69, 22);
            btnApply.TabIndex = 0;
            btnApply.Text = "Змінити";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // tbValue
            // 
            tbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            tbValue.Location = new System.Drawing.Point(209, 3);
            tbValue.Name = "tbValue";
            tbValue.ReadOnly = true;
            tbValue.Size = new System.Drawing.Size(594, 23);
            tbValue.TabIndex = 1;
            // 
            // labParamName
            // 
            labParamName.AutoSize = true;
            labParamName.Dock = System.Windows.Forms.DockStyle.Fill;
            labParamName.Location = new System.Drawing.Point(3, 0);
            labParamName.Name = "labParamName";
            labParamName.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            labParamName.Size = new System.Drawing.Size(200, 28);
            labParamName.TabIndex = 2;
            labParamName.Text = "Параметр";
            labParamName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UcReportLineWork
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelMain);
            Name = "UcReportLineWork";
            Size = new System.Drawing.Size(895, 431);
            Load += UcReportLineWork_Load;
            panelMain.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.ListView lvWorks;
        private System.Windows.Forms.TableLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label labParamName;
    }
}
