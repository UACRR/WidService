namespace DdexInvoicing
{
    partial class FormAutoSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutoSearch));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSplitStepsAndResults = new System.Windows.Forms.SplitContainer();
            this.panelSteps = new System.Windows.Forms.TableLayoutPanel();
            this.lvSteps = new System.Windows.Forms.ListView();
            this.panelStepsTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelResults = new System.Windows.Forms.TableLayoutPanel();
            this.lvResult = new System.Windows.Forms.ListView();
            this.btnDoSearch = new System.Windows.Forms.Button();
            this.panelFormTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFoundWorks = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFormFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.btnCopy = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitStepsAndResults)).BeginInit();
            this.panelSplitStepsAndResults.Panel1.SuspendLayout();
            this.panelSplitStepsAndResults.Panel2.SuspendLayout();
            this.panelSplitStepsAndResults.SuspendLayout();
            this.panelSteps.SuspendLayout();
            this.panelStepsTitle.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.panelFormTitle.SuspendLayout();
            this.panelFoundWorks.SuspendLayout();
            this.panelFormFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.panelMain.Controls.Add(this.panelSplitStepsAndResults, 0, 1);
            this.panelMain.Controls.Add(this.panelFormTitle, 0, 0);
            this.panelMain.Controls.Add(this.panelFormFooter, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // panelSplitStepsAndResults
            // 
            this.panelSplitStepsAndResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitStepsAndResults.Location = new System.Drawing.Point(3, 33);
            this.panelSplitStepsAndResults.Name = "panelSplitStepsAndResults";
            this.panelSplitStepsAndResults.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelSplitStepsAndResults.Panel1
            // 
            this.panelSplitStepsAndResults.Panel1.Controls.Add(this.panelSteps);
            // 
            // panelSplitStepsAndResults.Panel2
            // 
            this.panelSplitStepsAndResults.Panel2.Controls.Add(this.panelResults);
            this.panelSplitStepsAndResults.Size = new System.Drawing.Size(788, 370);
            this.panelSplitStepsAndResults.SplitterDistance = 202;
            this.panelSplitStepsAndResults.TabIndex = 0;
            // 
            // panelSteps
            // 
            this.panelSteps.ColumnCount = 2;
            this.panelSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelSteps.Controls.Add(this.lvSteps, 0, 1);
            this.panelSteps.Controls.Add(this.panelStepsTitle, 0, 0);
            this.panelSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSteps.Location = new System.Drawing.Point(0, 0);
            this.panelSteps.Name = "panelSteps";
            this.panelSteps.RowCount = 2;
            this.panelSteps.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelSteps.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSteps.Size = new System.Drawing.Size(788, 202);
            this.panelSteps.TabIndex = 0;
            // 
            // lvSteps
            // 
            this.lvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSteps.HideSelection = false;
            this.lvSteps.Location = new System.Drawing.Point(3, 42);
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(774, 157);
            this.lvSteps.TabIndex = 0;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            // 
            // panelStepsTitle
            // 
            this.panelStepsTitle.Controls.Add(this.label1);
            this.panelStepsTitle.Controls.Add(this.btnDoSearch);
            this.panelStepsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStepsTitle.Location = new System.Drawing.Point(3, 3);
            this.panelStepsTitle.Name = "panelStepsTitle";
            this.panelStepsTitle.Size = new System.Drawing.Size(774, 33);
            this.panelStepsTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дії, які виконуються в процесі пошуку";
            // 
            // panelResults
            // 
            this.panelResults.ColumnCount = 2;
            this.panelResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelResults.Controls.Add(this.lvResult, 0, 1);
            this.panelResults.Controls.Add(this.panelFoundWorks, 0, 0);
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResults.Location = new System.Drawing.Point(0, 0);
            this.panelResults.Name = "panelResults";
            this.panelResults.RowCount = 2;
            this.panelResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelResults.Size = new System.Drawing.Size(788, 164);
            this.panelResults.TabIndex = 0;
            // 
            // lvResult
            // 
            this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResult.HideSelection = false;
            this.lvResult.Location = new System.Drawing.Point(3, 39);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(774, 122);
            this.lvResult.TabIndex = 0;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Location = new System.Drawing.Point(208, 3);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(75, 23);
            this.btnDoSearch.TabIndex = 1;
            this.btnDoSearch.Text = "Щукати";
            this.btnDoSearch.UseVisualStyleBackColor = true;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // panelFormTitle
            // 
            this.panelFormTitle.Controls.Add(this.label2);
            this.panelFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormTitle.Location = new System.Drawing.Point(3, 3);
            this.panelFormTitle.Name = "panelFormTitle";
            this.panelFormTitle.Size = new System.Drawing.Size(788, 24);
            this.panelFormTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ПОШУК ТВОРІВ ІЗ ЗВІТУ";
            // 
            // panelFoundWorks
            // 
            this.panelFoundWorks.Controls.Add(this.label3);
            this.panelFoundWorks.Controls.Add(this.btnCopy);
            this.panelFoundWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoundWorks.Location = new System.Drawing.Point(3, 3);
            this.panelFoundWorks.Name = "panelFoundWorks";
            this.panelFoundWorks.Size = new System.Drawing.Size(774, 30);
            this.panelFoundWorks.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Знайдені твори";
            // 
            // panelFormFooter
            // 
            this.panelFormFooter.Controls.Add(this.btnClose);
            this.panelFormFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelFormFooter.Location = new System.Drawing.Point(3, 409);
            this.panelFormFooter.Name = "panelFormFooter";
            this.panelFormFooter.Size = new System.Drawing.Size(788, 38);
            this.panelFormFooter.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(710, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerMonitor
            // 
            this.timerMonitor.Interval = 500;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "iconfinder_OK_132710.png");
            this.ilMain.Images.SetKeyName(1, "iconfinder_Forward_132664.png");
            this.ilMain.Images.SetKeyName(2, "iconfinder_Error_132716.png");
            this.ilMain.Images.SetKeyName(3, "iconfinder_History_132755.png");
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(93, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(179, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Копіювати в буфер обміну";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FormAutoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Name = "FormAutoSearch";
            this.Text = "Пошук творів із звіту";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutoSearch_FormClosing);
            this.Load += new System.EventHandler(this.FormAutoSearch_Load);
            this.panelMain.ResumeLayout(false);
            this.panelSplitStepsAndResults.Panel1.ResumeLayout(false);
            this.panelSplitStepsAndResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitStepsAndResults)).EndInit();
            this.panelSplitStepsAndResults.ResumeLayout(false);
            this.panelSteps.ResumeLayout(false);
            this.panelStepsTitle.ResumeLayout(false);
            this.panelStepsTitle.PerformLayout();
            this.panelResults.ResumeLayout(false);
            this.panelFormTitle.ResumeLayout(false);
            this.panelFormTitle.PerformLayout();
            this.panelFoundWorks.ResumeLayout(false);
            this.panelFoundWorks.PerformLayout();
            this.panelFormFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer panelSplitStepsAndResults;
        private System.Windows.Forms.TableLayoutPanel panelSteps;
        private System.Windows.Forms.TableLayoutPanel panelResults;
        private System.Windows.Forms.ListView lvSteps;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.FlowLayoutPanel panelStepsTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDoSearch;
        private System.Windows.Forms.FlowLayoutPanel panelFoundWorks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel panelFormTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panelFormFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.Button btnCopy;
    }
}