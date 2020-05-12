namespace DdexInvoicing
{
    partial class FormArchiver
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Операція");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Параметри");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Стан виконання");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArchiver));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radBtnRun = new Telerik.WinControls.UI.RadButton();
            this.radBtnClose = new Telerik.WinControls.UI.RadButton();
            this.radLvOperations = new Telerik.WinControls.UI.RadListView();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLvOperations)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radBtnClose, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radLvOperations, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(919, 507);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radBtnRun, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(913, 30);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(800, 24);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Операції";
            // 
            // radBtnRun
            // 
            this.radBtnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radBtnRun.Location = new System.Drawing.Point(809, 3);
            this.radBtnRun.Name = "radBtnRun";
            this.radBtnRun.Size = new System.Drawing.Size(79, 24);
            this.radBtnRun.TabIndex = 1;
            this.radBtnRun.Text = "Виконати";
            this.radBtnRun.Click += new System.EventHandler(this.radBtnRun_Click);
            // 
            // radBtnClose
            // 
            this.radBtnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radBtnClose.Location = new System.Drawing.Point(806, 476);
            this.radBtnClose.Name = "radBtnClose";
            this.radBtnClose.Size = new System.Drawing.Size(110, 24);
            this.radBtnClose.TabIndex = 1;
            this.radBtnClose.Text = "Закрити";
            this.radBtnClose.Click += new System.EventHandler(this.radBtnClose_Click);
            // 
            // radLvOperations
            // 
            this.radLvOperations.AllowColumnReorder = false;
            this.radLvOperations.AllowEdit = false;
            this.radLvOperations.AllowRemove = false;
            listViewDetailColumn1.HeaderText = "Операція";
            listViewDetailColumn1.Width = 230F;
            listViewDetailColumn2.HeaderText = "Параметри";
            listViewDetailColumn2.Width = 400F;
            listViewDetailColumn3.HeaderText = "Стан виконання";
            listViewDetailColumn3.Width = 100F;
            this.radLvOperations.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3});
            this.radLvOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLvOperations.ImageList = this.ilMain;
            this.radLvOperations.ItemSpacing = -1;
            this.radLvOperations.Location = new System.Drawing.Point(3, 39);
            this.radLvOperations.Name = "radLvOperations";
            this.radLvOperations.SelectLastAddedItem = false;
            this.radLvOperations.ShowGridLines = true;
            this.radLvOperations.Size = new System.Drawing.Size(913, 427);
            this.radLvOperations.TabIndex = 2;
            this.radLvOperations.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.radLvOperations.SelectedItemChanging += new Telerik.WinControls.UI.ListViewItemCancelEventHandler(this.radLvOperations_SelectedItemChanging);
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
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // FormArchiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(919, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormArchiver";
            this.Text = "Архівація звітів";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormArchiver_FormClosing);
            this.Load += new System.EventHandler(this.FormArchiver_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLvOperations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radBtnRun;
        private Telerik.WinControls.UI.RadButton radBtnClose;
        private Telerik.WinControls.UI.RadListView radLvOperations;
        private System.Windows.Forms.ImageList ilMain;
        private System.ComponentModel.BackgroundWorker bw;
    }
}

