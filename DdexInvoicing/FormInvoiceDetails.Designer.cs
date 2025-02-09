namespace DdexInvoicing
{
    partial class FormInvoiceDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoiceDetails));
            this.panelFormMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelPageHead = new System.Windows.Forms.TableLayoutPanel();
            this.radLabelTotalAmount = new Telerik.WinControls.UI.RadLabel();
            this.radTbTotalAmount = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radTbExceptionSet = new Telerik.WinControls.UI.RadTextBox();
            this.radTbExceptionSetDate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucInvoiceDetails = new DdexInvoicing.UcInvoiceDetails();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucCcidInvoiceTestResults = new DdexInvoicing.UcCcidInvoiceTestResults();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucCcidInvoiceExpectedDist = new DdexInvoicing.UcCcidInvoiceExpectedDist();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ucCcidInvoiceWrongIpBaseNr = new DdexInvoicing.UcCcidInvoiceWrongIpBaseNr();
            this.panelFormMain.SuspendLayout();
            this.panelPageHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbExceptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbExceptionSetDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormMain
            // 
            this.panelFormMain.ColumnCount = 1;
            this.panelFormMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFormMain.Controls.Add(this.panelPageHead, 0, 0);
            this.panelFormMain.Controls.Add(this.tabControlMain, 0, 1);
            this.panelFormMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormMain.Location = new System.Drawing.Point(0, 0);
            this.panelFormMain.Name = "panelFormMain";
            this.panelFormMain.RowCount = 3;
            this.panelFormMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelFormMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFormMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelFormMain.Size = new System.Drawing.Size(937, 533);
            this.panelFormMain.TabIndex = 2;
            // 
            // panelPageHead
            // 
            this.panelPageHead.ColumnCount = 8;
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.panelPageHead.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.panelPageHead.Controls.Add(this.radLabelTotalAmount, 0, 0);
            this.panelPageHead.Controls.Add(this.radTbTotalAmount, 1, 0);
            this.panelPageHead.Controls.Add(this.radLabel1, 2, 0);
            this.panelPageHead.Controls.Add(this.radTbExceptionSet, 3, 0);
            this.panelPageHead.Controls.Add(this.radTbExceptionSetDate, 6, 0);
            this.panelPageHead.Controls.Add(this.radLabel2, 4, 0);
            this.panelPageHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPageHead.Location = new System.Drawing.Point(3, 3);
            this.panelPageHead.Name = "panelPageHead";
            this.panelPageHead.RowCount = 1;
            this.panelPageHead.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPageHead.Size = new System.Drawing.Size(931, 26);
            this.panelPageHead.TabIndex = 2;
            // 
            // radLabelTotalAmount
            // 
            this.radLabelTotalAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelTotalAmount.Location = new System.Drawing.Point(3, 3);
            this.radLabelTotalAmount.Name = "radLabelTotalAmount";
            this.radLabelTotalAmount.Size = new System.Drawing.Size(86, 20);
            this.radLabelTotalAmount.TabIndex = 0;
            this.radLabelTotalAmount.Text = "Заявлена сума:";
            // 
            // radTbTotalAmount
            // 
            this.radTbTotalAmount.Location = new System.Drawing.Point(95, 3);
            this.radTbTotalAmount.Name = "radTbTotalAmount";
            this.radTbTotalAmount.ReadOnly = true;
            this.radTbTotalAmount.Size = new System.Drawing.Size(137, 20);
            this.radTbTotalAmount.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Location = new System.Drawing.Point(238, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(137, 20);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Застосовані виключення:";
            // 
            // radTbExceptionSet
            // 
            this.radTbExceptionSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTbExceptionSet.Location = new System.Drawing.Point(381, 3);
            this.radTbExceptionSet.Name = "radTbExceptionSet";
            this.radTbExceptionSet.ReadOnly = true;
            this.radTbExceptionSet.Size = new System.Drawing.Size(201, 20);
            this.radTbExceptionSet.TabIndex = 1;
            // 
            // radTbExceptionSetDate
            // 
            this.radTbExceptionSetDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radTbExceptionSetDate.Location = new System.Drawing.Point(688, 3);
            this.radTbExceptionSetDate.Name = "radTbExceptionSetDate";
            this.radTbExceptionSetDate.ReadOnly = true;
            this.radTbExceptionSetDate.Size = new System.Drawing.Size(129, 20);
            this.radTbExceptionSetDate.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel2.Location = new System.Drawing.Point(588, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(95, 20);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Дата виключень:";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabPage3);
            this.tabControlMain.Controls.Add(this.tabPage4);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(3, 35);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(931, 487);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucInvoiceDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Рядки Продажів";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucInvoiceDetails
            // 
            this.ucInvoiceDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ucInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInvoiceDetails.Location = new System.Drawing.Point(3, 3);
            this.ucInvoiceDetails.Name = "ucInvoiceDetails";
            this.ucInvoiceDetails.Size = new System.Drawing.Size(917, 455);
            this.ucInvoiceDetails.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucCcidInvoiceTestResults);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Результати тестування";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucCcidInvoiceTestResults
            // 
            this.ucCcidInvoiceTestResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCcidInvoiceTestResults.Location = new System.Drawing.Point(3, 3);
            this.ucCcidInvoiceTestResults.Name = "ucCcidInvoiceTestResults";
            this.ucCcidInvoiceTestResults.Size = new System.Drawing.Size(917, 455);
            this.ucCcidInvoiceTestResults.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucCcidInvoiceExpectedDist);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(923, 461);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Очікуваний розподіл";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucCcidInvoiceExpectedDist
            // 
            this.ucCcidInvoiceExpectedDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCcidInvoiceExpectedDist.Location = new System.Drawing.Point(0, 0);
            this.ucCcidInvoiceExpectedDist.Name = "ucCcidInvoiceExpectedDist";
            this.ucCcidInvoiceExpectedDist.Size = new System.Drawing.Size(923, 461);
            this.ucCcidInvoiceExpectedDist.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucCcidInvoiceWrongIpBaseNr);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(923, 461);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Проблемні міжнародні коди";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ucCcidInvoiceWrongIpBaseNr
            // 
            this.ucCcidInvoiceWrongIpBaseNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCcidInvoiceWrongIpBaseNr.Location = new System.Drawing.Point(0, 0);
            this.ucCcidInvoiceWrongIpBaseNr.Name = "ucCcidInvoiceWrongIpBaseNr";
            this.ucCcidInvoiceWrongIpBaseNr.Size = new System.Drawing.Size(923, 461);
            this.ucCcidInvoiceWrongIpBaseNr.TabIndex = 0;
            // 
            // FormInvoiceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(937, 533);
            this.Controls.Add(this.panelFormMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInvoiceDetails";
            this.Text = "Рахунок-фактура";
            this.Load += new System.EventHandler(this.FormInvoiceDetails_Load);
            this.panelFormMain.ResumeLayout(false);
            this.panelPageHead.ResumeLayout(false);
            this.panelPageHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbExceptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbExceptionSetDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelFormMain;
        private System.Windows.Forms.TableLayoutPanel panelPageHead;
        private Telerik.WinControls.UI.RadLabel radLabelTotalAmount;
        private Telerik.WinControls.UI.RadTextBox radTbTotalAmount;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private UcInvoiceDetails ucInvoiceDetails;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private UcCcidInvoiceTestResults ucCcidInvoiceTestResults;
        private UcCcidInvoiceExpectedDist ucCcidInvoiceExpectedDist;
        private UcCcidInvoiceWrongIpBaseNr ucCcidInvoiceWrongIpBaseNr;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox radTbExceptionSet;
        private Telerik.WinControls.UI.RadTextBox radTbExceptionSetDate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}