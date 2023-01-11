namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetFiles
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvListFiles = new Telerik.WinControls.UI.RadGridView();
            this.btnAddFile = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFile)).BeginInit();
            this.SuspendLayout();
            // 
            // gvListFiles
            // 
            this.gvListFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvListFiles.AutoScroll = true;
            this.gvListFiles.AutoSizeRows = true;
            this.gvListFiles.EnableCustomFiltering = true;
            this.gvListFiles.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gvListFiles.MasterTemplate.AllowAddNewRow = false;
            this.gvListFiles.MasterTemplate.AllowDeleteRow = false;
            this.gvListFiles.MasterTemplate.AllowDragToGroup = false;
            this.gvListFiles.MasterTemplate.AllowEditRow = false;
            this.gvListFiles.MasterTemplate.AutoGenerateColumns = false;
            this.gvListFiles.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "CustId";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn1.Width = 47;
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "DocId";
            gridViewTextBoxColumn2.HeaderText = "ID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "DocId";
            gridViewTextBoxColumn3.FieldName = "DocType";
            gridViewTextBoxColumn3.HeaderText = "DocType";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "DocType";
            gridViewTextBoxColumn3.Width = 48;
            gridViewTextBoxColumn4.FieldName = "DocTypeNavigation.Name";
            gridViewTextBoxColumn4.HeaderText = "Тип документу";
            gridViewTextBoxColumn4.Name = "DocTypeNavigation.Name";
            gridViewTextBoxColumn4.Width = 204;
            gridViewTextBoxColumn5.FieldName = "DocComment";
            gridViewTextBoxColumn5.HeaderText = "Коментар";
            gridViewTextBoxColumn5.MinWidth = 0;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "DocComment";
            gridViewTextBoxColumn5.Width = 379;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "DocFile";
            gridViewTextBoxColumn6.HeaderText = "Файл";
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "DocFile";
            gridViewTextBoxColumn6.Width = 232;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "viewBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 35;
            gridViewCommandColumn1.MinWidth = 35;
            gridViewCommandColumn1.Name = "viewBtn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 35;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.AllowSort = false;
            gridViewCommandColumn2.DefaultText = "Видалити";
            gridViewCommandColumn2.FieldName = "deleteBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.MaxWidth = 35;
            gridViewCommandColumn2.MinWidth = 35;
            gridViewCommandColumn2.Name = "deleteBtn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 35;
            this.gvListFiles.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvListFiles.MasterTemplate.EnableCustomFiltering = true;
            this.gvListFiles.MasterTemplate.EnableFiltering = true;
            this.gvListFiles.MasterTemplate.EnableGrouping = false;
            this.gvListFiles.MasterTemplate.ShowFilteringRow = false;
            this.gvListFiles.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvListFiles.Name = "gvListFiles";
            this.gvListFiles.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvListFiles.ReadOnly = true;
            this.gvListFiles.Size = new System.Drawing.Size(907, 400);
            this.gvListFiles.TabIndex = 7;
            this.gvListFiles.ThemeName = "Office2013Light";
            this.gvListFiles.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvListFiles_CommandCellClick);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFile.Location = new System.Drawing.Point(16, 409);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(110, 24);
            this.btnAddFile.TabIndex = 8;
            this.btnAddFile.Text = "Додати документ";
            this.btnAddFile.ThemeName = "Office2013Light";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // MiddleControlCabinetFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.gvListFiles);
            this.Name = "MiddleControlCabinetFiles";
            this.Size = new System.Drawing.Size(913, 436);
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView gvListFiles;
        private Telerik.WinControls.UI.RadButton btnAddFile;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
