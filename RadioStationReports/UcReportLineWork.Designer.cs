
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lvWorks = new System.Windows.Forms.ListView();
            this.panelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.labParamName = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.lvWorks, 0, 0);
            this.panelMain.Controls.Add(this.panelBottom, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(895, 431);
            this.panelMain.TabIndex = 0;
            // 
            // lvWorks
            // 
            this.lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorks.HideSelection = false;
            this.lvWorks.Location = new System.Drawing.Point(3, 3);
            this.lvWorks.Name = "lvWorks";
            this.lvWorks.Size = new System.Drawing.Size(889, 383);
            this.lvWorks.TabIndex = 0;
            this.lvWorks.UseCompatibleStateImageBehavior = false;
            this.lvWorks.SelectedIndexChanged += new System.EventHandler(this.lvWorks_SelectedIndexChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.ColumnCount = 4;
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelBottom.Controls.Add(this.btnApply, 2, 0);
            this.panelBottom.Controls.Add(this.tbValue, 1, 0);
            this.panelBottom.Controls.Add(this.labParamName, 0, 0);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 392);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.RowCount = 1;
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.Size = new System.Drawing.Size(889, 28);
            this.panelBottom.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Location = new System.Drawing.Point(809, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(69, 22);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Змінити";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tbValue
            // 
            this.tbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValue.Location = new System.Drawing.Point(209, 3);
            this.tbValue.Name = "tbValue";
            this.tbValue.ReadOnly = true;
            this.tbValue.Size = new System.Drawing.Size(594, 23);
            this.tbValue.TabIndex = 1;
            // 
            // labParamName
            // 
            this.labParamName.AutoSize = true;
            this.labParamName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labParamName.Location = new System.Drawing.Point(3, 0);
            this.labParamName.Name = "labParamName";
            this.labParamName.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.labParamName.Size = new System.Drawing.Size(200, 28);
            this.labParamName.TabIndex = 2;
            this.labParamName.Text = "Параметр";
            this.labParamName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UcReportLineWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcReportLineWork";
            this.Size = new System.Drawing.Size(895, 431);
            this.Load += new System.EventHandler(this.UcReportLineWork_Load);
            this.panelMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

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
