namespace sysAdminwp.DictionaryControls
{
    partial class SimpleDictionaryControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.treeViewList = new Telerik.WinControls.UI.RadTreeView();
            this.txtTreeFilter = new Telerik.WinControls.UI.RadTextBox();
            this.bottomPanel = new Telerik.WinControls.UI.RadPanel();
            this.txtNameRu = new Telerik.WinControls.UI.RadTextBox();
            this.bsTrRu = new System.Windows.Forms.BindingSource(this.components);
            this.txtNameEn = new Telerik.WinControls.UI.RadTextBox();
            this.bsTrEn = new System.Windows.Forms.BindingSource(this.components);
            this.txtNameUa = new Telerik.WinControls.UI.RadTextBox();
            this.bsTrUk = new System.Windows.Forms.BindingSource(this.components);
            this.txtCode = new Telerik.WinControls.UI.RadTextBox();
            this.bsDictionary = new System.Windows.Forms.BindingSource(this.components);
            this.radLabelNameRu = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameEn = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameUa = new Telerik.WinControls.UI.RadLabel();
            this.radLabelCode = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.gvDictionaries = new Telerik.WinControls.UI.RadGridView();
            this.bsViewTable = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTreeFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrUk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionaries.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewList
            // 
            this.treeViewList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewList.Location = new System.Drawing.Point(3, 27);
            this.treeViewList.Name = "treeViewList";
            this.treeViewList.Size = new System.Drawing.Size(229, 486);
            this.treeViewList.SpacingBetweenNodes = -1;
            this.treeViewList.TabIndex = 11;
            this.treeViewList.ThemeName = "Office2013Light";
            this.treeViewList.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.treeViewList_SelectedNodeChanged);
            // 
            // txtTreeFilter
            // 
            this.txtTreeFilter.Location = new System.Drawing.Point(3, 3);
            this.txtTreeFilter.Multiline = true;
            this.txtTreeFilter.Name = "txtTreeFilter";
            this.txtTreeFilter.NullText = "Фільтр";
            // 
            // 
            // 
            this.txtTreeFilter.RootElement.StretchVertically = true;
            this.txtTreeFilter.Size = new System.Drawing.Size(229, 20);
            this.txtTreeFilter.TabIndex = 13;
            this.txtTreeFilter.ThemeName = "Office2013Light";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.Controls.Add(this.txtNameRu);
            this.bottomPanel.Controls.Add(this.txtNameEn);
            this.bottomPanel.Controls.Add(this.txtNameUa);
            this.bottomPanel.Controls.Add(this.txtCode);
            this.bottomPanel.Controls.Add(this.radLabelNameRu);
            this.bottomPanel.Controls.Add(this.radLabelNameEn);
            this.bottomPanel.Controls.Add(this.radLabelNameUa);
            this.bottomPanel.Controls.Add(this.radLabelCode);
            this.bottomPanel.Controls.Add(this.btnCancel);
            this.bottomPanel.Controls.Add(this.btnSave);
            this.bottomPanel.Location = new System.Drawing.Point(236, 307);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(875, 206);
            this.bottomPanel.TabIndex = 12;
            this.bottomPanel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bottomPanel.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPanelElement)(this.bottomPanel.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.bottomPanel.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.bottomPanel.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.bottomPanel.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.bottomPanel.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.bottomPanel.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.bottomPanel.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNameRu
            // 
            this.txtNameRu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameRu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrRu, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNameRu.Location = new System.Drawing.Point(162, 81);
            this.txtNameRu.Name = "txtNameRu";
            this.txtNameRu.Size = new System.Drawing.Size(695, 21);
            this.txtNameRu.TabIndex = 8;
            this.txtNameRu.ThemeName = "Office2013Light";
            // 
            // bsTrRu
            // 
            this.bsTrRu.DataSource = typeof(ipsFormsDesign.Dictionary.DictTrI);
            // 
            // txtNameEn
            // 
            this.txtNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameEn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrEn, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNameEn.Location = new System.Drawing.Point(162, 108);
            this.txtNameEn.Name = "txtNameEn";
            this.txtNameEn.Size = new System.Drawing.Size(695, 21);
            this.txtNameEn.TabIndex = 9;
            this.txtNameEn.ThemeName = "Office2013Light";
            // 
            // bsTrEn
            // 
            this.bsTrEn.DataSource = typeof(ipsFormsDesign.Dictionary.DictTrI);
            // 
            // txtNameUa
            // 
            this.txtNameUa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameUa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTrUk, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNameUa.Location = new System.Drawing.Point(162, 55);
            this.txtNameUa.Name = "txtNameUa";
            this.txtNameUa.Size = new System.Drawing.Size(695, 21);
            this.txtNameUa.TabIndex = 7;
            this.txtNameUa.ThemeName = "Office2013Light";
            // 
            // bsTrUk
            // 
            this.bsTrUk.DataSource = typeof(ipsFormsDesign.Dictionary.DictTrI);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDictionary, "CodeI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCode.Location = new System.Drawing.Point(162, 28);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(695, 21);
            this.txtCode.TabIndex = 6;
            this.txtCode.ThemeName = "Office2013Light";
            // 
            // bsDictionary
            // 
            this.bsDictionary.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // radLabelNameRu
            // 
            this.radLabelNameRu.AutoSize = false;
            this.radLabelNameRu.BackColor = System.Drawing.Color.Transparent;
            this.radLabelNameRu.Location = new System.Drawing.Point(55, 82);
            this.radLabelNameRu.Name = "radLabelNameRu";
            this.radLabelNameRu.Size = new System.Drawing.Size(90, 18);
            this.radLabelNameRu.TabIndex = 5;
            this.radLabelNameRu.Text = "Название (RU):";
            this.radLabelNameRu.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabelNameEn
            // 
            this.radLabelNameEn.AutoSize = false;
            this.radLabelNameEn.BackColor = System.Drawing.Color.Transparent;
            this.radLabelNameEn.Location = new System.Drawing.Point(55, 109);
            this.radLabelNameEn.Name = "radLabelNameEn";
            this.radLabelNameEn.Size = new System.Drawing.Size(90, 18);
            this.radLabelNameEn.TabIndex = 4;
            this.radLabelNameEn.Text = "Name (EN):";
            this.radLabelNameEn.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabelNameUa
            // 
            this.radLabelNameUa.AutoSize = false;
            this.radLabelNameUa.BackColor = System.Drawing.Color.Transparent;
            this.radLabelNameUa.Location = new System.Drawing.Point(55, 55);
            this.radLabelNameUa.Name = "radLabelNameUa";
            this.radLabelNameUa.Size = new System.Drawing.Size(90, 18);
            this.radLabelNameUa.TabIndex = 3;
            this.radLabelNameUa.Text = "Назва (UA):";
            this.radLabelNameUa.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabelCode
            // 
            this.radLabelCode.AutoSize = false;
            this.radLabelCode.BackColor = System.Drawing.Color.Transparent;
            this.radLabelCode.Location = new System.Drawing.Point(55, 28);
            this.radLabelCode.Name = "radLabelCode";
            this.radLabelCode.Size = new System.Drawing.Size(90, 18);
            this.radLabelCode.TabIndex = 2;
            this.radLabelCode.Text = "Код:";
            this.radLabelCode.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(354, 276);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 24);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.ThemeName = "Office2013Light";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(238, 276);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Додати";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvDictionaries
            // 
            this.gvDictionaries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDictionaries.EnableCustomFiltering = true;
            this.gvDictionaries.Enabled = false;
            this.gvDictionaries.Location = new System.Drawing.Point(236, 27);
            this.gvDictionaries.Margin = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.gvDictionaries.MasterTemplate.AllowAddNewRow = false;
            this.gvDictionaries.MasterTemplate.AllowColumnReorder = false;
            this.gvDictionaries.MasterTemplate.AllowDeleteRow = false;
            this.gvDictionaries.MasterTemplate.AllowDragToGroup = false;
            this.gvDictionaries.MasterTemplate.AllowEditRow = false;
            this.gvDictionaries.MasterTemplate.AutoGenerateColumns = false;
            this.gvDictionaries.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Code";
            gridViewTextBoxColumn1.HeaderText = "Код";
            gridViewTextBoxColumn1.Name = "Code";
            gridViewTextBoxColumn1.Width = 80;
            gridViewTextBoxColumn2.FieldName = "NameUk";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Name = "NameUk";
            gridViewTextBoxColumn2.Width = 240;
            gridViewTextBoxColumn3.FieldName = "NameRu";
            gridViewTextBoxColumn3.HeaderText = "Название";
            gridViewTextBoxColumn3.Name = "NameRu";
            gridViewTextBoxColumn3.Width = 240;
            gridViewTextBoxColumn4.FieldName = "NameEn";
            gridViewTextBoxColumn4.HeaderText = "Name";
            gridViewTextBoxColumn4.Name = "NameEn";
            gridViewTextBoxColumn4.Width = 292;
            this.gvDictionaries.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvDictionaries.MasterTemplate.DataSource = this.bsViewTable;
            this.gvDictionaries.MasterTemplate.EnableCustomFiltering = true;
            this.gvDictionaries.MasterTemplate.EnableFiltering = true;
            this.gvDictionaries.MasterTemplate.ShowFilteringRow = false;
            this.gvDictionaries.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvDictionaries.Name = "gvDictionaries";
            this.gvDictionaries.ReadOnly = true;
            this.gvDictionaries.ShowGroupPanel = false;
            this.gvDictionaries.Size = new System.Drawing.Size(875, 245);
            this.gvDictionaries.TabIndex = 8;
            this.gvDictionaries.ThemeName = "Office2013Light";
            // 
            // bsViewTable
            // 
            this.bsViewTable.DataSource = typeof(sysAdminwp.Model.ViewTable);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(238, 3);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 14;
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(953, 276);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 15;
            // 
            // SimpleDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ctrlGridRowCount);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.treeViewList);
            this.Controls.Add(this.txtTreeFilter);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvDictionaries);
            this.Name = "SimpleDictionaryControl";
            this.Size = new System.Drawing.Size(1114, 516);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTreeFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrUk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionaries.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView treeViewList;
        private Telerik.WinControls.UI.RadTextBox txtTreeFilter;
        private Telerik.WinControls.UI.RadPanel bottomPanel;
        private Telerik.WinControls.UI.RadTextBox txtNameRu;
        private Telerik.WinControls.UI.RadTextBox txtNameEn;
        private Telerik.WinControls.UI.RadTextBox txtNameUa;
        private Telerik.WinControls.UI.RadTextBox txtCode;
        private Telerik.WinControls.UI.RadLabel radLabelNameRu;
        private Telerik.WinControls.UI.RadLabel radLabelNameEn;
        private Telerik.WinControls.UI.RadLabel radLabelNameUa;
        private Telerik.WinControls.UI.RadLabel radLabelCode;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView gvDictionaries;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl ctrlSearch;
        private IpsViewComponentLibrary.Common.GridRowCountControl ctrlGridRowCount;
        private System.Windows.Forms.BindingSource bsViewTable;
        private System.Windows.Forms.BindingSource bsTrUk;
        private System.Windows.Forms.BindingSource bsTrRu;
        private System.Windows.Forms.BindingSource bsTrEn;
        private System.Windows.Forms.BindingSource bsDictionary;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
