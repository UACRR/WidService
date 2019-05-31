namespace IpsViewComponentLibrary.RightholderRegisterControls
{
    partial class RightholderRegisterControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnLoadFile = new Telerik.WinControls.UI.RadButton();
            this.gridCatalogFiles = new Telerik.WinControls.UI.RadGridView();
            this.bsGridData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadFile.Location = new System.Drawing.Point(3, 431);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(219, 24);
            this.btnLoadFile.TabIndex = 4;
            this.btnLoadFile.Text = "Завантажити каталог";
            this.btnLoadFile.ThemeName = "Office2013Light";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // gridCatalogFiles
            // 
            this.gridCatalogFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCatalogFiles.EnableCustomFiltering = true;
            this.gridCatalogFiles.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gridCatalogFiles.MasterTemplate.AllowAddNewRow = false;
            this.gridCatalogFiles.MasterTemplate.AllowColumnReorder = false;
            this.gridCatalogFiles.MasterTemplate.AllowDeleteRow = false;
            this.gridCatalogFiles.MasterTemplate.AllowDragToGroup = false;
            this.gridCatalogFiles.MasterTemplate.AllowEditRow = false;
            this.gridCatalogFiles.MasterTemplate.AutoGenerateColumns = false;
            this.gridCatalogFiles.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "FileId";
            gridViewTextBoxColumn1.HeaderText = "№п/п";
            gridViewTextBoxColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewTextBoxColumn1.MinWidth = 50;
            gridViewTextBoxColumn1.Name = "number";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.FieldName = "FileName";
            gridViewTextBoxColumn2.HeaderText = "Назва файлу";
            gridViewTextBoxColumn2.MinWidth = 175;
            gridViewTextBoxColumn2.Name = "fileName";
            gridViewTextBoxColumn2.Width = 175;
            gridViewTextBoxColumn3.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn3.FieldName = "CreateDate";
            gridViewTextBoxColumn3.FormatString = "{0:dd.MM.yyyy HH:mm:ss}";
            gridViewTextBoxColumn3.HeaderText = "Дата завантаження";
            gridViewTextBoxColumn3.MaxWidth = 125;
            gridViewTextBoxColumn3.MinWidth = 125;
            gridViewTextBoxColumn3.Name = "dateDownload";
            gridViewTextBoxColumn3.Width = 125;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn4.FieldName = "CountZap";
            gridViewTextBoxColumn4.HeaderText = "К-ть записів всього";
            gridViewTextBoxColumn4.MinWidth = 95;
            gridViewTextBoxColumn4.Name = "countFiles";
            gridViewTextBoxColumn4.Width = 95;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn5.FieldName = "CountErr";
            gridViewTextBoxColumn5.HeaderText = "К-ть відкинутих записів";
            gridViewTextBoxColumn5.MinWidth = 95;
            gridViewTextBoxColumn5.Name = "countLeaveFiles";
            gridViewTextBoxColumn5.Width = 95;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn6.FieldName = "Status";
            gridViewTextBoxColumn6.HeaderText = "status";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "statusFile";
            gridViewTextBoxColumn6.Width = 48;
            gridViewTextBoxColumn7.FieldName = "StatusNavigation.Name";
            gridViewTextBoxColumn7.HeaderText = "Статус файлу";
            gridViewTextBoxColumn7.MinWidth = 90;
            gridViewTextBoxColumn7.Name = "StatusNavigation";
            gridViewTextBoxColumn7.Width = 90;
            gridViewTextBoxColumn8.FieldName = "Comment";
            gridViewTextBoxColumn8.HeaderText = "Коментар";
            gridViewTextBoxColumn8.MinWidth = 130;
            gridViewTextBoxColumn8.Name = "comment";
            gridViewTextBoxColumn8.Width = 130;
            gridViewTextBoxColumn9.FieldName = "UserId";
            gridViewTextBoxColumn9.HeaderText = "Хто завантажив";
            gridViewTextBoxColumn9.MinWidth = 100;
            gridViewTextBoxColumn9.Name = "downloadFace";
            gridViewTextBoxColumn9.Width = 100;
            gridViewCommandColumn1.FieldName = "infoBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "infoBtn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            gridViewCommandColumn2.FieldName = "editBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "editBtn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 30;
            gridViewCommandColumn2.WrapText = true;
            gridViewCommandColumn3.FieldName = "deleteBtn";
            gridViewCommandColumn3.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn3.MaxWidth = 30;
            gridViewCommandColumn3.MinWidth = 30;
            gridViewCommandColumn3.Name = "deleteBtn";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 30;
            this.gridCatalogFiles.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3});
            this.gridCatalogFiles.MasterTemplate.DataSource = this.bsGridData;
            this.gridCatalogFiles.MasterTemplate.EnableCustomFiltering = true;
            this.gridCatalogFiles.MasterTemplate.EnableFiltering = true;
            this.gridCatalogFiles.MasterTemplate.ShowFilteringRow = false;
            this.gridCatalogFiles.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridCatalogFiles.Name = "gridCatalogFiles";
            this.gridCatalogFiles.ReadOnly = true;
            this.gridCatalogFiles.ShowGroupPanel = false;
            this.gridCatalogFiles.Size = new System.Drawing.Size(808, 422);
            this.gridCatalogFiles.TabIndex = 3;
            this.gridCatalogFiles.ThemeName = "Office2013Light";
            this.gridCatalogFiles.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridCatalogFiles_CommandCellClick);
            this.gridCatalogFiles.DoubleClick += new System.EventHandler(this.gridCatalogFiles_DoubleClick);
            // 
            // bsGridData
            // 
            this.bsGridData.DataSource = typeof(ipsFormsDesign.Model.CatalogFile);
            // 
            // RightholderRegisterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.gridCatalogFiles);
            this.Name = "RightholderRegisterControl";
            this.Size = new System.Drawing.Size(814, 458);
            this.Load += new System.EventHandler(this.RightholderRegisterControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnLoadFile;
        private Telerik.WinControls.UI.RadGridView gridCatalogFiles;
        private System.Windows.Forms.BindingSource bsGridData;
    }
}
