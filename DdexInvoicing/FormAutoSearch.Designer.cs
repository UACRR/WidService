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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSplitStepsAndResults = new System.Windows.Forms.SplitContainer();
            this.panelSteps = new System.Windows.Forms.TableLayoutPanel();
            this.panelResults = new System.Windows.Forms.TableLayoutPanel();
            this.lvSteps = new System.Windows.Forms.ListView();
            this.lvResult = new System.Windows.Forms.ListView();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitStepsAndResults)).BeginInit();
            this.panelSplitStepsAndResults.Panel1.SuspendLayout();
            this.panelSplitStepsAndResults.Panel2.SuspendLayout();
            this.panelSplitStepsAndResults.SuspendLayout();
            this.panelSteps.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.panelMain.Controls.Add(this.panelSplitStepsAndResults, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
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
            this.panelSplitStepsAndResults.Size = new System.Drawing.Size(788, 384);
            this.panelSplitStepsAndResults.SplitterDistance = 210;
            this.panelSplitStepsAndResults.TabIndex = 0;
            // 
            // panelSteps
            // 
            this.panelSteps.ColumnCount = 2;
            this.panelSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelSteps.Controls.Add(this.lvSteps, 0, 1);
            this.panelSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSteps.Location = new System.Drawing.Point(0, 0);
            this.panelSteps.Name = "panelSteps";
            this.panelSteps.RowCount = 2;
            this.panelSteps.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelSteps.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSteps.Size = new System.Drawing.Size(788, 210);
            this.panelSteps.TabIndex = 0;
            // 
            // panelResults
            // 
            this.panelResults.ColumnCount = 2;
            this.panelResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelResults.Controls.Add(this.lvResult, 0, 1);
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResults.Location = new System.Drawing.Point(0, 0);
            this.panelResults.Name = "panelResults";
            this.panelResults.RowCount = 2;
            this.panelResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelResults.Size = new System.Drawing.Size(788, 170);
            this.panelResults.TabIndex = 0;
            // 
            // lvSteps
            // 
            this.lvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSteps.HideSelection = false;
            this.lvSteps.Location = new System.Drawing.Point(3, 33);
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(774, 174);
            this.lvSteps.TabIndex = 0;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            // 
            // lvResult
            // 
            this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResult.HideSelection = false;
            this.lvResult.Location = new System.Drawing.Point(3, 33);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(774, 134);
            this.lvResult.TabIndex = 0;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            // 
            // FormAutoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormAutoSearch";
            this.Text = "Пошук творів із звіту";
            this.Load += new System.EventHandler(this.FormAutoSearch_Load);
            this.panelMain.ResumeLayout(false);
            this.panelSplitStepsAndResults.Panel1.ResumeLayout(false);
            this.panelSplitStepsAndResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitStepsAndResults)).EndInit();
            this.panelSplitStepsAndResults.ResumeLayout(false);
            this.panelSteps.ResumeLayout(false);
            this.panelResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer panelSplitStepsAndResults;
        private System.Windows.Forms.TableLayoutPanel panelSteps;
        private System.Windows.Forms.TableLayoutPanel panelResults;
        private System.Windows.Forms.ListView lvSteps;
        private System.Windows.Forms.ListView lvResult;
    }
}