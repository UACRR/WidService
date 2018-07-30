namespace IpsViewComponentLibrary.RegisterControls
{
    partial class SearchObjectView
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.ctrlRegisterItemList = new IpsViewComponentLibrary.RegisterControls.RegisterItemListControl();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.gvFoundedObjectList = new Telerik.WinControls.UI.RadGridView();
            this.registerSearchObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoundedObjectList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoundedObjectList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerSearchObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(1201, 623);
            this.radSplitContainer1.SplitterWidth = 5;
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.ThemeName = "Office2013Light";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.btnSearch);
            this.splitPanel1.Controls.Add(this.ctrlRegisterItemList);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(1201, 296);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.0210356F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -13);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            this.splitPanel1.ThemeName = "Office2013Light";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(7, 266);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Шукати";
            this.btnSearch.ThemeName = "Office2013Light";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrlRegisterItemList
            // 
            this.ctrlRegisterItemList.AllowCreateObjectCommand = true;
            this.ctrlRegisterItemList.AllowFindCommand = false;
            this.ctrlRegisterItemList.AllowLinkCommand = true;
            this.ctrlRegisterItemList.AllowShowObjectCommand = true;
            this.ctrlRegisterItemList.AllowUnlinkCommand = true;
            this.ctrlRegisterItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegisterItemList.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterItemViewModel);
            this.ctrlRegisterItemList.Location = new System.Drawing.Point(4, 4);
            this.ctrlRegisterItemList.MultiSelect = false;
            this.ctrlRegisterItemList.Name = "ctrlRegisterItemList";
            this.ctrlRegisterItemList.SelectedRegisterItem = null;
            this.ctrlRegisterItemList.Size = new System.Drawing.Size(1191, 256);
            this.ctrlRegisterItemList.TabIndex = 1;
            this.ctrlRegisterItemList.SelectedRegisterItemChanged += new System.EventHandler(this.ctrlRegisterItemList_SelectedRegisterItemChanged);
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.radLabel17);
            this.splitPanel2.Controls.Add(this.btnOk);
            this.splitPanel2.Controls.Add(this.btnCancel);
            this.splitPanel2.Controls.Add(this.gvFoundedObjectList);
            this.splitPanel2.Location = new System.Drawing.Point(0, 301);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(1201, 322);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.0210356F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 13);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.ThemeName = "Office2013Light";
            // 
            // radLabel17
            // 
            this.radLabel17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel17.Location = new System.Drawing.Point(4, 4);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(150, 25);
            this.radLabel17.TabIndex = 73;
            this.radLabel17.Text = "Результати пошуку";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(1014, 289);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(175, 24);
            this.btnOk.TabIndex = 30;
            this.btnOk.Text = "OK";
            this.btnOk.ThemeName = "Office2013Light";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(7, 289);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 24);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // gvFoundedObjectList
            // 
            this.gvFoundedObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFoundedObjectList.EnableCustomFiltering = true;
            this.gvFoundedObjectList.Location = new System.Drawing.Point(7, 35);
            // 
            // 
            // 
            this.gvFoundedObjectList.MasterTemplate.AllowAddNewRow = false;
            this.gvFoundedObjectList.MasterTemplate.AllowDeleteRow = false;
            this.gvFoundedObjectList.MasterTemplate.AllowEditRow = false;
            this.gvFoundedObjectList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "ObjId";
            gridViewDecimalColumn1.HeaderText = "Шифр об\'єкта";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "ObjId";
            gridViewDecimalColumn1.Width = 184;
            gridViewTextBoxColumn1.FieldName = "Name";
            gridViewTextBoxColumn1.HeaderText = "Назва";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 184;
            gridViewTextBoxColumn2.FieldName = "Performer";
            gridViewTextBoxColumn2.HeaderText = "Виконавець";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Performer";
            gridViewTextBoxColumn2.Width = 184;
            gridViewTextBoxColumn3.FieldName = "Author";
            gridViewTextBoxColumn3.HeaderText = "Автор";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "Author";
            gridViewTextBoxColumn3.Width = 184;
            gridViewTextBoxColumn4.FieldName = "Genre";
            gridViewTextBoxColumn4.HeaderText = "Жанр";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Genre";
            gridViewTextBoxColumn4.Width = 184;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn5.FieldName = "Duration";
            gridViewTextBoxColumn5.HeaderText = "Тривалість звучання";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Duration";
            gridViewTextBoxColumn5.Width = 185;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Прив\'язати";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "LinkColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 81;
            this.gvFoundedObjectList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1});
            this.gvFoundedObjectList.MasterTemplate.DataSource = this.registerSearchObjectBindingSource;
            this.gvFoundedObjectList.MasterTemplate.EnableCustomFiltering = true;
            this.gvFoundedObjectList.MasterTemplate.EnableFiltering = true;
            this.gvFoundedObjectList.MasterTemplate.ShowFilteringRow = false;
            this.gvFoundedObjectList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvFoundedObjectList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvFoundedObjectList.Name = "gvFoundedObjectList";
            this.gvFoundedObjectList.ShowGroupPanel = false;
            this.gvFoundedObjectList.Size = new System.Drawing.Size(1182, 248);
            this.gvFoundedObjectList.TabIndex = 28;
            this.gvFoundedObjectList.ThemeName = "Office2013Light";
            this.gvFoundedObjectList.RowsChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(this.gvFoundedObjectList_RowsChanged);
            this.gvFoundedObjectList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvFoundedObjectList_CommandCellClick);
            // 
            // registerSearchObjectBindingSource
            // 
            this.registerSearchObjectBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterSearchObject);
            // 
            // SearchObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 623);
            this.Controls.Add(this.radSplitContainer1);
            this.Name = "SearchObjectView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Пошук і прив\'язка об\'єктів права";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            this.splitPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoundedObjectList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoundedObjectList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerSearchObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private RegisterItemListControl ctrlRegisterItemList;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private System.Windows.Forms.BindingSource registerSearchObjectBindingSource;
        private Telerik.WinControls.UI.RadGridView gvFoundedObjectList;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadLabel radLabel17;
    }
}
