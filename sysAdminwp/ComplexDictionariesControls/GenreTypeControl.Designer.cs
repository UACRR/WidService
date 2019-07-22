namespace sysAdminwp.ComplexDictionariesControls
{
    sealed partial class GenreTypeControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ddlFilterCategory = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictFilterCategory = new System.Windows.Forms.BindingSource(this.components);
            this.lbFilterCategory = new Telerik.WinControls.UI.RadLabel();
            this.editPanelGenreType = new Telerik.WinControls.UI.RadPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCategory = new Telerik.WinControls.UI.RadDropDownList();
            this.bsGenreType = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictCategory = new System.Windows.Forms.BindingSource(this.components);
            this.txtRuGenreType = new Telerik.WinControls.UI.RadTextBox();
            this.bsRuLangGenreType = new System.Windows.Forms.BindingSource(this.components);
            this.txtEnGenreType = new Telerik.WinControls.UI.RadTextBox();
            this.bsEnLangGenreType = new System.Windows.Forms.BindingSource(this.components);
            this.txtUkGenreType = new Telerik.WinControls.UI.RadTextBox();
            this.bsUkLangGenreType = new System.Windows.Forms.BindingSource(this.components);
            this.txtCodeGenreType = new Telerik.WinControls.UI.RadTextBox();
            this.lblRuLangGenreType = new Telerik.WinControls.UI.RadLabel();
            this.lblEnLangGenreType = new Telerik.WinControls.UI.RadLabel();
            this.lblUkLangGenreType = new Telerik.WinControls.UI.RadLabel();
            this.lblCodeGenreType = new Telerik.WinControls.UI.RadLabel();
            this.btnCancelGenreType = new Telerik.WinControls.UI.RadButton();
            this.btnSaveGenreType = new Telerik.WinControls.UI.RadButton();
            this.btnDeleteGenreType = new Telerik.WinControls.UI.RadButton();
            this.btnAddGenreType = new Telerik.WinControls.UI.RadButton();
            this.gvGenreType = new Telerik.WinControls.UI.RadGridView();
            this.bsViewTable = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFilterCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictFilterCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbFilterCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanelGenreType)).BeginInit();
            this.editPanelGenreType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRuLangGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEnLangGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUkGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUkLangGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuLangGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnLangGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUkLangGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodeGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenreType.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlFilterCategory
            // 
            this.ddlFilterCategory.DataSource = this.bsDictFilterCategory;
            this.ddlFilterCategory.DisplayMember = "Name";
            this.ddlFilterCategory.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlFilterCategory.FormattingEnabled = false;
            this.ddlFilterCategory.Location = new System.Drawing.Point(72, 29);
            this.ddlFilterCategory.Name = "ddlFilterCategory";
            this.ddlFilterCategory.Size = new System.Drawing.Size(446, 21);
            this.ddlFilterCategory.TabIndex = 22;
            this.ddlFilterCategory.ThemeName = "Office2013Light";
            this.ddlFilterCategory.ValueMember = "CodeI";
            // 
            // bsDictFilterCategory
            // 
            this.bsDictFilterCategory.DataSource = typeof(ipsFormsDesign.Model.Category);
            // 
            // lbFilterCategory
            // 
            this.lbFilterCategory.Location = new System.Drawing.Point(3, 29);
            this.lbFilterCategory.Name = "lbFilterCategory";
            this.lbFilterCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbFilterCategory.Size = new System.Drawing.Size(63, 19);
            this.lbFilterCategory.TabIndex = 21;
            this.lbFilterCategory.Text = "Категорія:";
            this.lbFilterCategory.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbFilterCategory.ThemeName = "Office2013Light";
            // 
            // editPanelGenreType
            // 
            this.editPanelGenreType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editPanelGenreType.Controls.Add(this.radLabel1);
            this.editPanelGenreType.Controls.Add(this.ddlCategory);
            this.editPanelGenreType.Controls.Add(this.txtRuGenreType);
            this.editPanelGenreType.Controls.Add(this.txtEnGenreType);
            this.editPanelGenreType.Controls.Add(this.txtUkGenreType);
            this.editPanelGenreType.Controls.Add(this.txtCodeGenreType);
            this.editPanelGenreType.Controls.Add(this.lblRuLangGenreType);
            this.editPanelGenreType.Controls.Add(this.lblEnLangGenreType);
            this.editPanelGenreType.Controls.Add(this.lblUkLangGenreType);
            this.editPanelGenreType.Controls.Add(this.lblCodeGenreType);
            this.editPanelGenreType.Controls.Add(this.btnCancelGenreType);
            this.editPanelGenreType.Controls.Add(this.btnSaveGenreType);
            this.editPanelGenreType.Location = new System.Drawing.Point(0, 259);
            this.editPanelGenreType.Name = "editPanelGenreType";
            this.editPanelGenreType.Size = new System.Drawing.Size(998, 202);
            this.editPanelGenreType.TabIndex = 28;
            this.editPanelGenreType.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.editPanelGenreType.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPanelElement)(this.editPanelGenreType.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanelGenreType.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanelGenreType.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanelGenreType.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanelGenreType.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanelGenreType.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanelGenreType.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(85, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radLabel1.Size = new System.Drawing.Size(63, 19);
            this.radLabel1.TabIndex = 22;
            this.radLabel1.Text = "Категорія:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ddlCategory
            // 
            this.ddlCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsGenreType, "CategoryCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlCategory.DataSource = this.bsDictCategory;
            this.ddlCategory.DisplayMember = "Name";
            this.ddlCategory.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCategory.Enabled = false;
            this.ddlCategory.Location = new System.Drawing.Point(162, 29);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(465, 21);
            this.ddlCategory.TabIndex = 13;
            this.ddlCategory.ThemeName = "Office2013Light";
            this.ddlCategory.ValueMember = "CodeI";
            // 
            // bsGenreType
            // 
            this.bsGenreType.DataSource = typeof(ipsFormsDesign.Model.GenreType);
            // 
            // bsDictCategory
            // 
            this.bsDictCategory.DataSource = typeof(ipsFormsDesign.Model.Category);
            // 
            // txtRuGenreType
            // 
            this.txtRuGenreType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRuLangGenreType, "Name", true));
            this.txtRuGenreType.Location = new System.Drawing.Point(162, 109);
            this.txtRuGenreType.MaxLength = 500;
            this.txtRuGenreType.Name = "txtRuGenreType";
            this.txtRuGenreType.Size = new System.Drawing.Size(465, 21);
            this.txtRuGenreType.TabIndex = 8;
            this.txtRuGenreType.ThemeName = "Office2013Light";
            // 
            // bsRuLangGenreType
            // 
            this.bsRuLangGenreType.DataSource = typeof(ipsFormsDesign.Model.CopyrightKindTr);
            // 
            // txtEnGenreType
            // 
            this.txtEnGenreType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEnLangGenreType, "Name", true));
            this.txtEnGenreType.Location = new System.Drawing.Point(162, 136);
            this.txtEnGenreType.MaxLength = 500;
            this.txtEnGenreType.Name = "txtEnGenreType";
            this.txtEnGenreType.Size = new System.Drawing.Size(465, 21);
            this.txtEnGenreType.TabIndex = 9;
            this.txtEnGenreType.ThemeName = "Office2013Light";
            // 
            // bsEnLangGenreType
            // 
            this.bsEnLangGenreType.DataSource = typeof(ipsFormsDesign.Model.CopyrightKindTr);
            // 
            // txtUkGenreType
            // 
            this.txtUkGenreType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsUkLangGenreType, "Name", true));
            this.txtUkGenreType.Location = new System.Drawing.Point(162, 83);
            this.txtUkGenreType.MaxLength = 500;
            this.txtUkGenreType.Name = "txtUkGenreType";
            this.txtUkGenreType.Size = new System.Drawing.Size(465, 21);
            this.txtUkGenreType.TabIndex = 7;
            this.txtUkGenreType.ThemeName = "Office2013Light";
            // 
            // bsUkLangGenreType
            // 
            this.bsUkLangGenreType.DataSource = typeof(ipsFormsDesign.Model.CopyrightKindTr);
            // 
            // txtCodeGenreType
            // 
            this.txtCodeGenreType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsGenreType, "CodeI", true));
            this.txtCodeGenreType.Location = new System.Drawing.Point(162, 56);
            this.txtCodeGenreType.MaxLength = 5;
            this.txtCodeGenreType.Name = "txtCodeGenreType";
            this.txtCodeGenreType.ReadOnly = true;
            this.txtCodeGenreType.Size = new System.Drawing.Size(465, 21);
            this.txtCodeGenreType.TabIndex = 6;
            this.txtCodeGenreType.ThemeName = "Office2013Light";
            // 
            // lblRuLangGenreType
            // 
            this.lblRuLangGenreType.AutoSize = false;
            this.lblRuLangGenreType.BackColor = System.Drawing.Color.Transparent;
            this.lblRuLangGenreType.Location = new System.Drawing.Point(55, 110);
            this.lblRuLangGenreType.Name = "lblRuLangGenreType";
            this.lblRuLangGenreType.Size = new System.Drawing.Size(90, 18);
            this.lblRuLangGenreType.TabIndex = 5;
            this.lblRuLangGenreType.Text = "Название (RU):";
            this.lblRuLangGenreType.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEnLangGenreType
            // 
            this.lblEnLangGenreType.AutoSize = false;
            this.lblEnLangGenreType.BackColor = System.Drawing.Color.Transparent;
            this.lblEnLangGenreType.Location = new System.Drawing.Point(55, 137);
            this.lblEnLangGenreType.Name = "lblEnLangGenreType";
            this.lblEnLangGenreType.Size = new System.Drawing.Size(90, 18);
            this.lblEnLangGenreType.TabIndex = 4;
            this.lblEnLangGenreType.Text = "Name (EN):";
            this.lblEnLangGenreType.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUkLangGenreType
            // 
            this.lblUkLangGenreType.AutoSize = false;
            this.lblUkLangGenreType.BackColor = System.Drawing.Color.Transparent;
            this.lblUkLangGenreType.Location = new System.Drawing.Point(55, 83);
            this.lblUkLangGenreType.Name = "lblUkLangGenreType";
            this.lblUkLangGenreType.Size = new System.Drawing.Size(90, 18);
            this.lblUkLangGenreType.TabIndex = 3;
            this.lblUkLangGenreType.Text = "Назва (UA):";
            this.lblUkLangGenreType.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCodeGenreType
            // 
            this.lblCodeGenreType.AutoSize = false;
            this.lblCodeGenreType.BackColor = System.Drawing.Color.Transparent;
            this.lblCodeGenreType.Location = new System.Drawing.Point(55, 56);
            this.lblCodeGenreType.Name = "lblCodeGenreType";
            this.lblCodeGenreType.Size = new System.Drawing.Size(90, 18);
            this.lblCodeGenreType.TabIndex = 2;
            this.lblCodeGenreType.Text = "Код:";
            this.lblCodeGenreType.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancelGenreType
            // 
            this.btnCancelGenreType.Location = new System.Drawing.Point(278, 163);
            this.btnCancelGenreType.Name = "btnCancelGenreType";
            this.btnCancelGenreType.Size = new System.Drawing.Size(110, 24);
            this.btnCancelGenreType.TabIndex = 1;
            this.btnCancelGenreType.Text = "Скасувати";
            this.btnCancelGenreType.ThemeName = "Office2013Light";
            this.btnCancelGenreType.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveGenreType
            // 
            this.btnSaveGenreType.Location = new System.Drawing.Point(162, 163);
            this.btnSaveGenreType.Name = "btnSaveGenreType";
            this.btnSaveGenreType.Size = new System.Drawing.Size(110, 24);
            this.btnSaveGenreType.TabIndex = 0;
            this.btnSaveGenreType.Text = "Зберегти";
            this.btnSaveGenreType.ThemeName = "Office2013Light";
            this.btnSaveGenreType.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteGenreType
            // 
            this.btnDeleteGenreType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteGenreType.Location = new System.Drawing.Point(119, 229);
            this.btnDeleteGenreType.Name = "btnDeleteGenreType";
            this.btnDeleteGenreType.Size = new System.Drawing.Size(110, 24);
            this.btnDeleteGenreType.TabIndex = 27;
            this.btnDeleteGenreType.Text = "Видалити";
            this.btnDeleteGenreType.ThemeName = "Office2013Light";
            this.btnDeleteGenreType.Click += new System.EventHandler(this.btnDeleteComplex_Click);
            // 
            // btnAddGenreType
            // 
            this.btnAddGenreType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddGenreType.Location = new System.Drawing.Point(3, 229);
            this.btnAddGenreType.Name = "btnAddGenreType";
            this.btnAddGenreType.Size = new System.Drawing.Size(110, 24);
            this.btnAddGenreType.TabIndex = 26;
            this.btnAddGenreType.Text = "Додати";
            this.btnAddGenreType.ThemeName = "Office2013Light";
            this.btnAddGenreType.Click += new System.EventHandler(this.btnAddComplex_Click);
            // 
            // gvGenreType
            // 
            this.gvGenreType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvGenreType.EnableCustomFiltering = true;
            this.gvGenreType.Location = new System.Drawing.Point(0, 54);
            this.gvGenreType.Margin = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.gvGenreType.MasterTemplate.AllowAddNewRow = false;
            this.gvGenreType.MasterTemplate.AllowColumnReorder = false;
            this.gvGenreType.MasterTemplate.AllowDeleteRow = false;
            this.gvGenreType.MasterTemplate.AllowDragToGroup = false;
            this.gvGenreType.MasterTemplate.AllowEditRow = false;
            this.gvGenreType.MasterTemplate.AutoGenerateColumns = false;
            this.gvGenreType.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Code";
            gridViewTextBoxColumn1.HeaderText = "Код";
            gridViewTextBoxColumn1.Name = "Code";
            gridViewTextBoxColumn1.Width = 108;
            gridViewTextBoxColumn2.FieldName = "NameUk";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Name = "NameUk";
            gridViewTextBoxColumn2.Width = 294;
            gridViewTextBoxColumn3.FieldName = "NameRu";
            gridViewTextBoxColumn3.HeaderText = "Название";
            gridViewTextBoxColumn3.Name = "NameRu";
            gridViewTextBoxColumn3.Width = 298;
            gridViewTextBoxColumn4.FieldName = "NameEn";
            gridViewTextBoxColumn4.HeaderText = "Name";
            gridViewTextBoxColumn4.Name = "NameEn";
            gridViewTextBoxColumn4.Width = 275;
            this.gvGenreType.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvGenreType.MasterTemplate.DataSource = this.bsViewTable;
            this.gvGenreType.MasterTemplate.EnableCustomFiltering = true;
            this.gvGenreType.MasterTemplate.EnableFiltering = true;
            this.gvGenreType.MasterTemplate.ShowFilteringRow = false;
            this.gvGenreType.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvGenreType.Name = "gvGenreType";
            this.gvGenreType.ReadOnly = true;
            this.gvGenreType.ShowGroupPanel = false;
            this.gvGenreType.Size = new System.Drawing.Size(998, 171);
            this.gvGenreType.TabIndex = 25;
            this.gvGenreType.ThemeName = "Office2013Light";
            this.gvGenreType.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvGenreType_CurrentRowChanged);
            // 
            // bsViewTable
            // 
            this.bsViewTable.DataSource = typeof(sysAdminwp.Model.ViewTable);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 3);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(404, 20);
            this.ctrlSearch.TabIndex = 32;
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(840, 229);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 33;
            // 
            // BaseGenreTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlGridRowCount);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.ddlFilterCategory);
            this.Controls.Add(this.lbFilterCategory);
            this.Controls.Add(this.editPanelGenreType);
            this.Controls.Add(this.btnDeleteGenreType);
            this.Controls.Add(this.btnAddGenreType);
            this.Controls.Add(this.gvGenreType);
            this.Name = "BaseGenreTypeControl";
            this.Size = new System.Drawing.Size(998, 461);
            ((System.ComponentModel.ISupportInitialize)(this.ddlFilterCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictFilterCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbFilterCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanelGenreType)).EndInit();
            this.editPanelGenreType.ResumeLayout(false);
            this.editPanelGenreType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRuLangGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEnLangGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUkGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUkLangGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRuLangGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnLangGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUkLangGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodeGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenreType.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadDropDownList ddlFilterCategory;
        private Telerik.WinControls.UI.RadLabel lbFilterCategory;
        private Telerik.WinControls.UI.RadPanel editPanelGenreType;
        private Telerik.WinControls.UI.RadTextBox txtRuGenreType;
        private Telerik.WinControls.UI.RadTextBox txtEnGenreType;
        private Telerik.WinControls.UI.RadTextBox txtUkGenreType;
        private Telerik.WinControls.UI.RadTextBox txtCodeGenreType;
        private Telerik.WinControls.UI.RadLabel lblRuLangGenreType;
        private Telerik.WinControls.UI.RadLabel lblEnLangGenreType;
        private Telerik.WinControls.UI.RadLabel lblUkLangGenreType;
        private Telerik.WinControls.UI.RadLabel lblCodeGenreType;
        private Telerik.WinControls.UI.RadButton btnCancelGenreType;
        private Telerik.WinControls.UI.RadButton btnSaveGenreType;
        private Telerik.WinControls.UI.RadButton btnDeleteGenreType;
        private Telerik.WinControls.UI.RadButton btnAddGenreType;
        private Telerik.WinControls.UI.RadGridView gvGenreType;
        private Telerik.WinControls.UI.RadDropDownList ddlCategory;
        private System.Windows.Forms.BindingSource bsGenreType;
        private System.Windows.Forms.BindingSource bsDictFilterCategory;
        private System.Windows.Forms.BindingSource bsRuLangGenreType;
        private System.Windows.Forms.BindingSource bsEnLangGenreType;
        private System.Windows.Forms.BindingSource bsUkLangGenreType;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsViewTable;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl ctrlSearch;
        private System.Windows.Forms.BindingSource bsDictCategory;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private IpsViewComponentLibrary.Common.GridRowCountControl ctrlGridRowCount;
    }
}
