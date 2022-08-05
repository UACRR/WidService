namespace DdexInvoicing
{
    partial class UcDdexLoad
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Стадія");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Стан Виконання");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDdexLoad));
            this.panelLoadReport = new System.Windows.Forms.TableLayoutPanel();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.panelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radBtnLoadReport = new Telerik.WinControls.UI.RadButton();
            this.radLvActions = new Telerik.WinControls.UI.RadListView();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.panelThreshold = new System.Windows.Forms.FlowLayoutPanel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radTbThreshold = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.panelLoadReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnLoadReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLvActions)).BeginInit();
            this.panelThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLoadReport
            // 
            this.panelLoadReport.ColumnCount = 3;
            this.panelLoadReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 515F));
            this.panelLoadReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLoadReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.panelLoadReport.Controls.Add(this.tbLog, 1, 2);
            this.panelLoadReport.Controls.Add(this.radLabel2, 1, 1);
            this.panelLoadReport.Controls.Add(this.panelActions, 0, 1);
            this.panelLoadReport.Controls.Add(this.radLvActions, 0, 2);
            this.panelLoadReport.Controls.Add(this.panelThreshold, 0, 0);
            this.panelLoadReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoadReport.Location = new System.Drawing.Point(0, 0);
            this.panelLoadReport.Name = "panelLoadReport";
            this.panelLoadReport.RowCount = 3;
            this.panelLoadReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelLoadReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelLoadReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLoadReport.Size = new System.Drawing.Size(1309, 630);
            this.panelLoadReport.TabIndex = 1;
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(518, 77);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(775, 550);
            this.tbLog.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(518, 40);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(111, 24);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Хід виконання";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.radLabel1);
            this.panelActions.Controls.Add(this.radBtnLoadReport);
            this.panelActions.Location = new System.Drawing.Point(3, 40);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(509, 31);
            this.panelActions.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(111, 24);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Стадії завантаження";
            // 
            // radBtnLoadReport
            // 
            this.radBtnLoadReport.Location = new System.Drawing.Point(120, 3);
            this.radBtnLoadReport.Name = "radBtnLoadReport";
            this.radBtnLoadReport.Size = new System.Drawing.Size(99, 21);
            this.radBtnLoadReport.TabIndex = 1;
            this.radBtnLoadReport.Text = "Завантажити";
            this.radBtnLoadReport.Click += new System.EventHandler(this.radBtnLoadReport_Click);
            // 
            // radLvActions
            // 
            this.radLvActions.AllowColumnReorder = false;
            this.radLvActions.AllowColumnResize = false;
            this.radLvActions.AllowEdit = false;
            this.radLvActions.AllowRemove = false;
            listViewDetailColumn1.HeaderText = "Стадія";
            listViewDetailColumn1.Width = 400F;
            listViewDetailColumn2.HeaderText = "Стан Виконання";
            listViewDetailColumn2.Width = 100F;
            this.radLvActions.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2});
            this.radLvActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLvActions.EnableAnalytics = false;
            this.radLvActions.EnableGestures = false;
            this.radLvActions.EnableTheming = false;
            this.radLvActions.HotTracking = false;
            this.radLvActions.ImageList = this.ilMain;
            this.radLvActions.ItemSpacing = -1;
            this.radLvActions.Location = new System.Drawing.Point(3, 77);
            this.radLvActions.Name = "radLvActions";
            this.radLvActions.SelectLastAddedItem = false;
            this.radLvActions.Size = new System.Drawing.Size(509, 550);
            this.radLvActions.TabIndex = 2;
            this.radLvActions.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
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
            // panelThreshold
            // 
            this.panelThreshold.Controls.Add(this.radLabel3);
            this.panelThreshold.Controls.Add(this.radTbThreshold);
            this.panelThreshold.Controls.Add(this.radLabel4);
            this.panelThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelThreshold.Location = new System.Drawing.Point(3, 3);
            this.panelThreshold.Name = "panelThreshold";
            this.panelThreshold.Size = new System.Drawing.Size(509, 31);
            this.panelThreshold.TabIndex = 0;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 3);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(246, 18);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "Завантажувати позиції с прибутком не менше";
            // 
            // radTbThreshold
            // 
            this.radTbThreshold.Location = new System.Drawing.Point(255, 3);
            this.radTbThreshold.Name = "radTbThreshold";
            this.radTbThreshold.ReadOnly = true;
            this.radTbThreshold.Size = new System.Drawing.Size(100, 20);
            this.radTbThreshold.TabIndex = 2;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(361, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(31, 18);
            this.radLabel4.TabIndex = 0;
            this.radLabel4.Text = " USD";
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // UcDdexLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panelLoadReport);
            this.Name = "UcDdexLoad";
            this.Size = new System.Drawing.Size(1309, 630);
            this.panelLoadReport.ResumeLayout(false);
            this.panelLoadReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnLoadReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLvActions)).EndInit();
            this.panelThreshold.ResumeLayout(false);
            this.panelThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelLoadReport;
        private System.Windows.Forms.TextBox tbLog;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radBtnLoadReport;
        private Telerik.WinControls.UI.RadListView radLvActions;
        private System.Windows.Forms.ImageList ilMain;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.FlowLayoutPanel panelThreshold;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox radTbThreshold;
        private Telerik.WinControls.UI.RadLabel radLabel4;
    }
}
