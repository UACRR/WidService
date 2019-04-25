using System.Drawing;

namespace IpsViewComponentLibrary.CatalogControls
{
    partial class CatalogControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridCatalogFiles = new Telerik.WinControls.UI.RadGridView();
            this.bsGridData = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoadFile = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadFile)).BeginInit();
            this.SuspendLayout();
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
            gridViewTextBoxColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gridViewTextBoxColumn1.Name = "number";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 62;
            gridViewTextBoxColumn2.FieldName = "FileName";
            gridViewTextBoxColumn2.HeaderText = "Назва файлу";
            gridViewTextBoxColumn2.Name = "fileName";
            gridViewTextBoxColumn2.Width = 166;
            gridViewTextBoxColumn3.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn3.FieldName = "CreateDate";
            gridViewTextBoxColumn3.FormatString = "{0:d}";
            gridViewTextBoxColumn3.HeaderText = "Дата завантаження";
            gridViewTextBoxColumn3.MaxWidth = 88;
            gridViewTextBoxColumn3.MinWidth = 88;
            gridViewTextBoxColumn3.Name = "dateDownload";
            gridViewTextBoxColumn3.Width = 88;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn4.FieldName = "CountZap";
            gridViewTextBoxColumn4.HeaderText = "К-ть записів всього";
            gridViewTextBoxColumn4.MinWidth = 75;
            gridViewTextBoxColumn4.Name = "countFiles";
            gridViewTextBoxColumn4.Width = 75;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn5.FieldName = "CountErr";
            gridViewTextBoxColumn5.HeaderText = "К-ть відкинутих записів";
            gridViewTextBoxColumn5.MinWidth = 75;
            gridViewTextBoxColumn5.Name = "countLeaveFiles";
            gridViewTextBoxColumn5.Width = 78;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "StatusNavigation.Name";
            gridViewTextBoxColumn6.HeaderText = "Статус файлу";
            gridViewTextBoxColumn6.MinWidth = 100;
            gridViewTextBoxColumn6.Name = "StatusNavigation";
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn7.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn7.FieldName = "Status";
            gridViewTextBoxColumn7.HeaderText = "status";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "Status";
            gridViewTextBoxColumn7.Width = 51;
            gridViewTextBoxColumn8.FieldName = "Comment";
            gridViewTextBoxColumn8.HeaderText = "Коментар";
            gridViewTextBoxColumn8.Name = "comment";
            gridViewTextBoxColumn8.Width = 55;
            gridViewTextBoxColumn9.FieldName = "UserId";
            gridViewTextBoxColumn9.HeaderText = "Хто завантажив";
            gridViewTextBoxColumn9.Name = "downloadFace";
            gridViewTextBoxColumn9.Width = 71;
            gridViewCommandColumn1.FieldName = "editBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "editBtn";
            gridViewCommandColumn1.Width = 30;
            gridViewCommandColumn2.FieldName = "deleteBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "deleteBtn";
            gridViewCommandColumn2.Width = 30;
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
            gridViewCommandColumn2});
            this.gridCatalogFiles.MasterTemplate.DataSource = this.bsGridData;
            this.gridCatalogFiles.MasterTemplate.EnableCustomFiltering = true;
            this.gridCatalogFiles.MasterTemplate.EnableFiltering = true;
            this.gridCatalogFiles.MasterTemplate.ShowFilteringRow = false;
            this.gridCatalogFiles.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridCatalogFiles.Name = "gridCatalogFiles";
            this.gridCatalogFiles.ReadOnly = true;
            this.gridCatalogFiles.ShowGroupPanel = false;
            this.gridCatalogFiles.Size = new System.Drawing.Size(772, 295);
            this.gridCatalogFiles.TabIndex = 1;
            this.gridCatalogFiles.ThemeName = "Office2013Light";
            this.gridCatalogFiles.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gridCatalogFiles_CommandCellClick);
            // 
            // bsGridData
            // 
            this.bsGridData.DataSource = typeof(ipsFormsDesign.Model.CatalogFile);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadFile.Location = new System.Drawing.Point(3, 304);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(219, 24);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Завантажити каталог";
            this.btnLoadFile.ThemeName = "Office2013Light";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // CatalogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.gridCatalogFiles);
            this.Name = "CatalogControl";
            this.Size = new System.Drawing.Size(778, 331);
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCatalogFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView gridCatalogFiles;
        private Telerik.WinControls.UI.RadButton btnLoadFile;
        private System.Windows.Forms.BindingSource bsGridData;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
