
namespace WidExport
{
    partial class UcWidSubmWorksChanges
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
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshData = new System.Windows.Forms.Button();
            this.btnSaveHtml = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labTitle = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.splitMiddle = new System.Windows.Forms.SplitContainer();
            this.lvWorks = new System.Windows.Forms.ListView();
            this.panelDetails = new System.Windows.Forms.TableLayoutPanel();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.labDetails = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.timerFillWCtrl = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).BeginInit();
            this.splitMiddle.Panel1.SuspendLayout();
            this.splitMiddle.Panel2.SuspendLayout();
            this.splitMiddle.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Controls.Add(this.splitMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.Size = new System.Drawing.Size(1201, 563);
            this.panelMain.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnRefreshData);
            this.panelBottom.Controls.Add(this.btnSaveHtml);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 533);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1195, 27);
            this.panelBottom.TabIndex = 0;
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(144, 23);
            this.btnRefreshData.TabIndex = 1;
            this.btnRefreshData.Text = "Оновити інформацію";
            this.btnRefreshData.UseVisualStyleBackColor = true;
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // btnSaveHtml
            // 
            this.btnSaveHtml.Location = new System.Drawing.Point(153, 3);
            this.btnSaveHtml.Name = "btnSaveHtml";
            this.btnSaveHtml.Size = new System.Drawing.Size(182, 23);
            this.btnSaveHtml.TabIndex = 0;
            this.btnSaveHtml.Text = "Записати в HTML файл";
            this.btnSaveHtml.UseVisualStyleBackColor = true;
            this.btnSaveHtml.Click += new System.EventHandler(this.btnSaveHtml_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labTitle);
            this.panelTop.Controls.Add(this.cbFilter);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1195, 27);
            this.panelTop.TabIndex = 2;
            // 
            // labTitle
            // 
            this.labTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(3, 9);
            this.labTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(189, 13);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Перегляд змін творів закритих груп";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(198, 3);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(229, 21);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // splitMiddle
            // 
            this.splitMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMiddle.Location = new System.Drawing.Point(3, 36);
            this.splitMiddle.Name = "splitMiddle";
            this.splitMiddle.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMiddle.Panel1
            // 
            this.splitMiddle.Panel1.Controls.Add(this.lvWorks);
            // 
            // splitMiddle.Panel2
            // 
            this.splitMiddle.Panel2.Controls.Add(this.panelDetails);
            this.splitMiddle.Size = new System.Drawing.Size(1195, 491);
            this.splitMiddle.SplitterDistance = 148;
            this.splitMiddle.TabIndex = 3;
            // 
            // lvWorks
            // 
            this.lvWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWorks.FullRowSelect = true;
            this.lvWorks.GridLines = true;
            this.lvWorks.HideSelection = false;
            this.lvWorks.Location = new System.Drawing.Point(0, 0);
            this.lvWorks.MultiSelect = false;
            this.lvWorks.Name = "lvWorks";
            this.lvWorks.Size = new System.Drawing.Size(1195, 148);
            this.lvWorks.TabIndex = 0;
            this.lvWorks.UseCompatibleStateImageBehavior = false;
            this.lvWorks.View = System.Windows.Forms.View.Details;
            this.lvWorks.SelectedIndexChanged += new System.EventHandler(this.lvWorks_SelectedIndexChanged);
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelDetails.ColumnCount = 1;
            this.panelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDetails.Controls.Add(this.wb, 0, 1);
            this.panelDetails.Controls.Add(this.labDetails, 0, 0);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.RowCount = 2;
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDetails.Size = new System.Drawing.Size(1195, 339);
            this.panelDetails.TabIndex = 0;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(3, 27);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(1189, 309);
            this.wb.TabIndex = 1;
            // 
            // labDetails
            // 
            this.labDetails.AutoSize = true;
            this.labDetails.Location = new System.Drawing.Point(3, 4);
            this.labDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.labDetails.Name = "labDetails";
            this.labDetails.Size = new System.Drawing.Size(122, 13);
            this.labDetails.TabIndex = 2;
            this.labDetails.Text = "Деталі обраного твору";
            // 
            // timerFillWCtrl
            // 
            this.timerFillWCtrl.Tick += new System.EventHandler(this.timerFillWCtrl_Tick);
            // 
            // UcWidSubmWorksChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcWidSubmWorksChanges";
            this.Size = new System.Drawing.Size(1201, 563);
            this.Load += new System.EventHandler(this.UcWidSubmWorksChanges_Load);
            this.panelMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitMiddle.Panel1.ResumeLayout(false);
            this.splitMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).EndInit();
            this.splitMiddle.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.SplitContainer splitMiddle;
        private System.Windows.Forms.ListView lvWorks;
        private System.Windows.Forms.TableLayoutPanel panelDetails;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Label labDetails;
        private System.Windows.Forms.Button btnSaveHtml;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnRefreshData;
        private System.Windows.Forms.Timer timerFillWCtrl;
    }
}
