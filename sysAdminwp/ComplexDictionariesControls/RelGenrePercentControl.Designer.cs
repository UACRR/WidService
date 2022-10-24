namespace sysAdminwp.ComplexDictionariesControls
{
    sealed partial class RelGenrePercentControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvCopyrightKindList = new Telerik.WinControls.UI.RadGridView();
            this.bsViewTable = new System.Windows.Forms.BindingSource(this.components);
            this.searchCopyrightKind = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.lblObjAct = new Telerik.WinControls.UI.RadLabel();
            this.ddlObjAct = new Telerik.WinControls.UI.RadDropDownList();
            this.bsRelGenrePercent = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictObjAct = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlGenre = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictGenreType = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtRate = new Telerik.WinControls.UI.RadTextBoxControl();
            this.editPanelCopyrightKind = new Telerik.WinControls.UI.RadPanel();
            this.btnCancelCopyrightKind = new Telerik.WinControls.UI.RadButton();
            this.btnSaveCopyrightKind = new Telerik.WinControls.UI.RadButton();
            this.btnDeleteCopyrightKind = new Telerik.WinControls.UI.RadButton();
            this.btnAddCopyrightKind = new Telerik.WinControls.UI.RadButton();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvCopyrightKindList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCopyrightKindList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViewTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblObjAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlObjAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelGenrePercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictObjAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGenre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanelCopyrightKind)).BeginInit();
            this.editPanelCopyrightKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelCopyrightKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveCopyrightKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteCopyrightKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddCopyrightKind)).BeginInit();
            this.SuspendLayout();
            // 
            // gvCopyrightKindList
            // 
            this.gvCopyrightKindList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvCopyrightKindList.EnableCustomFiltering = true;
            this.gvCopyrightKindList.Location = new System.Drawing.Point(3, 27);
            this.gvCopyrightKindList.Margin = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.gvCopyrightKindList.MasterTemplate.AllowAddNewRow = false;
            this.gvCopyrightKindList.MasterTemplate.AllowColumnReorder = false;
            this.gvCopyrightKindList.MasterTemplate.AllowDeleteRow = false;
            this.gvCopyrightKindList.MasterTemplate.AllowDragToGroup = false;
            this.gvCopyrightKindList.MasterTemplate.AllowEditRow = false;
            this.gvCopyrightKindList.MasterTemplate.AutoGenerateColumns = false;
            this.gvCopyrightKindList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn10.FieldName = "ObjActName";
            gridViewTextBoxColumn10.HeaderText = "Кількість частин/актів";
            gridViewTextBoxColumn10.Name = "ObjActName";
            gridViewTextBoxColumn10.Width = 307;
            gridViewTextBoxColumn11.FieldName = "GenreName";
            gridViewTextBoxColumn11.HeaderText = "Жанр";
            gridViewTextBoxColumn11.Name = "GenreName";
            gridViewTextBoxColumn11.Width = 307;
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn4.FieldName = "Rate";
            gridViewDecimalColumn4.FormatString = "{0:##0.00}";
            gridViewDecimalColumn4.HeaderText = "Процент для жанру, %";
            gridViewDecimalColumn4.Name = "Rate";
            gridViewDecimalColumn4.Width = 205;
            gridViewTextBoxColumn12.HeaderText = "";
            gridViewTextBoxColumn12.MinWidth = 150;
            gridViewTextBoxColumn12.Name = "emptyColumn";
            gridViewTextBoxColumn12.Width = 150;
            this.gvCopyrightKindList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn12});
            this.gvCopyrightKindList.MasterTemplate.DataSource = this.bsViewTable;
            this.gvCopyrightKindList.MasterTemplate.EnableCustomFiltering = true;
            this.gvCopyrightKindList.MasterTemplate.EnableFiltering = true;
            this.gvCopyrightKindList.MasterTemplate.ShowFilteringRow = false;
            this.gvCopyrightKindList.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.gvCopyrightKindList.Name = "gvCopyrightKindList";
            this.gvCopyrightKindList.ReadOnly = true;
            this.gvCopyrightKindList.ShowGroupPanel = false;
            this.gvCopyrightKindList.Size = new System.Drawing.Size(992, 272);
            this.gvCopyrightKindList.TabIndex = 5;
            this.gvCopyrightKindList.ThemeName = "Office2013Light";
            this.gvCopyrightKindList.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvCopyrightKindList_CurrentRowChanged);
            // 
            // bsViewTable
            // 
            this.bsViewTable.DataSource = typeof(sysAdminwp.Model.RelGenrePercentViewTable);
            // 
            // searchCopyrightKind
            // 
            this.searchCopyrightKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchCopyrightKind.Location = new System.Drawing.Point(3, 3);
            this.searchCopyrightKind.MaximumSize = new System.Drawing.Size(2000, 20);
            this.searchCopyrightKind.MinimumSize = new System.Drawing.Size(20, 20);
            this.searchCopyrightKind.Name = "searchCopyrightKind";
            this.searchCopyrightKind.Size = new System.Drawing.Size(544, 20);
            this.searchCopyrightKind.TabIndex = 4;
            // 
            // lblObjAct
            // 
            this.lblObjAct.BackColor = System.Drawing.Color.Transparent;
            this.lblObjAct.Location = new System.Drawing.Point(17, 30);
            this.lblObjAct.Name = "lblObjAct";
            this.lblObjAct.Size = new System.Drawing.Size(132, 19);
            this.lblObjAct.TabIndex = 6;
            this.lblObjAct.Text = "Кількість частин/актів:";
            this.lblObjAct.ThemeName = "Office2013Light";
            // 
            // ddlObjAct
            // 
            this.ddlObjAct.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRelGenrePercent, "ActCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlObjAct.DataSource = this.bsDictObjAct;
            this.ddlObjAct.DisplayMember = "Name";
            this.ddlObjAct.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlObjAct.Enabled = false;
            this.ddlObjAct.Location = new System.Drawing.Point(155, 30);
            this.ddlObjAct.Name = "ddlObjAct";
            this.ddlObjAct.Size = new System.Drawing.Size(226, 21);
            this.ddlObjAct.TabIndex = 7;
            this.ddlObjAct.ThemeName = "Office2013Light";
            this.ddlObjAct.ValueMember = "CodeI";
            // 
            // bsRelGenrePercent
            // 
            this.bsRelGenrePercent.DataSource = typeof(ipsFormsDesign.Model.RelGenrePercent);
            // 
            // bsDictObjAct
            // 
            this.bsDictObjAct.DataSource = typeof(ipsFormsDesign.Model.ObjAct);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(108, 57);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(41, 19);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "Жанр:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ddlGenre
            // 
            this.ddlGenre.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRelGenrePercent, "GenreType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlGenre.DataSource = this.bsDictGenreType;
            this.ddlGenre.DisplayMember = "Name";
            this.ddlGenre.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlGenre.Enabled = false;
            this.ddlGenre.Location = new System.Drawing.Point(155, 57);
            this.ddlGenre.Name = "ddlGenre";
            this.ddlGenre.Size = new System.Drawing.Size(315, 21);
            this.ddlGenre.TabIndex = 9;
            this.ddlGenre.ThemeName = "Office2013Light";
            this.ddlGenre.ValueMember = "CodeI";
            // 
            // bsDictGenreType
            // 
            this.bsDictGenreType.DataSource = typeof(ipsFormsDesign.Model.GenreType);
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Location = new System.Drawing.Point(28, 84);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(121, 19);
            this.radLabel2.TabIndex = 10;
            this.radLabel2.Text = "Процент для жанру:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // txtRate
            // 
            this.txtRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRelGenrePercent, "Rate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.txtRate.Location = new System.Drawing.Point(155, 84);
            this.txtRate.MaxLength = 5;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(81, 20);
            this.txtRate.TabIndex = 11;
            this.txtRate.ThemeName = "Office2013Light";
            this.txtRate.WordWrap = false;
            // 
            // editPanelCopyrightKind
            // 
            this.editPanelCopyrightKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editPanelCopyrightKind.Controls.Add(this.btnCancelCopyrightKind);
            this.editPanelCopyrightKind.Controls.Add(this.txtRate);
            this.editPanelCopyrightKind.Controls.Add(this.btnSaveCopyrightKind);
            this.editPanelCopyrightKind.Controls.Add(this.radLabel2);
            this.editPanelCopyrightKind.Controls.Add(this.lblObjAct);
            this.editPanelCopyrightKind.Controls.Add(this.radLabel1);
            this.editPanelCopyrightKind.Controls.Add(this.ddlObjAct);
            this.editPanelCopyrightKind.Controls.Add(this.ddlGenre);
            this.editPanelCopyrightKind.Location = new System.Drawing.Point(0, 333);
            this.editPanelCopyrightKind.Name = "editPanelCopyrightKind";
            this.editPanelCopyrightKind.Size = new System.Drawing.Size(996, 151);
            this.editPanelCopyrightKind.TabIndex = 12;
            this.editPanelCopyrightKind.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.editPanelCopyrightKind.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPanelElement)(this.editPanelCopyrightKind.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanelCopyrightKind.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanelCopyrightKind.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanelCopyrightKind.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanelCopyrightKind.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanelCopyrightKind.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanelCopyrightKind.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancelCopyrightKind
            // 
            this.btnCancelCopyrightKind.Location = new System.Drawing.Point(271, 110);
            this.btnCancelCopyrightKind.Name = "btnCancelCopyrightKind";
            this.btnCancelCopyrightKind.Size = new System.Drawing.Size(110, 24);
            this.btnCancelCopyrightKind.TabIndex = 10;
            this.btnCancelCopyrightKind.Text = "Скасувати";
            this.btnCancelCopyrightKind.ThemeName = "Office2013Light";
            this.btnCancelCopyrightKind.Click += new System.EventHandler(this.btnCancelCopyrightKind_Click);
            // 
            // btnSaveCopyrightKind
            // 
            this.btnSaveCopyrightKind.Location = new System.Drawing.Point(155, 110);
            this.btnSaveCopyrightKind.Name = "btnSaveCopyrightKind";
            this.btnSaveCopyrightKind.Size = new System.Drawing.Size(110, 24);
            this.btnSaveCopyrightKind.TabIndex = 9;
            this.btnSaveCopyrightKind.Text = "Зберегти";
            this.btnSaveCopyrightKind.ThemeName = "Office2013Light";
            this.btnSaveCopyrightKind.Click += new System.EventHandler(this.btnSaveCopyrightKind_Click);
            // 
            // btnDeleteCopyrightKind
            // 
            this.btnDeleteCopyrightKind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteCopyrightKind.Location = new System.Drawing.Point(119, 303);
            this.btnDeleteCopyrightKind.Name = "btnDeleteCopyrightKind";
            this.btnDeleteCopyrightKind.Size = new System.Drawing.Size(110, 24);
            this.btnDeleteCopyrightKind.TabIndex = 14;
            this.btnDeleteCopyrightKind.Text = "Видалити";
            this.btnDeleteCopyrightKind.ThemeName = "Office2013Light";
            this.btnDeleteCopyrightKind.Click += new System.EventHandler(this.btnDeleteCopyrightKind_Click);
            // 
            // btnAddCopyrightKind
            // 
            this.btnAddCopyrightKind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCopyrightKind.Location = new System.Drawing.Point(3, 303);
            this.btnAddCopyrightKind.Name = "btnAddCopyrightKind";
            this.btnAddCopyrightKind.Size = new System.Drawing.Size(110, 24);
            this.btnAddCopyrightKind.TabIndex = 13;
            this.btnAddCopyrightKind.Text = "Додати";
            this.btnAddCopyrightKind.ThemeName = "Office2013Light";
            this.btnAddCopyrightKind.Click += new System.EventHandler(this.btnAddCopyrightKind_Click);
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(838, 302);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 15;
            // 
            // RelGenrePercentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ctrlGridRowCount);
            this.Controls.Add(this.btnDeleteCopyrightKind);
            this.Controls.Add(this.btnAddCopyrightKind);
            this.Controls.Add(this.editPanelCopyrightKind);
            this.Controls.Add(this.gvCopyrightKindList);
            this.Controls.Add(this.searchCopyrightKind);
            this.Name = "RelGenrePercentControl";
            this.Size = new System.Drawing.Size(996, 484);
            ((System.ComponentModel.ISupportInitialize)(this.gvCopyrightKindList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCopyrightKindList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsViewTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblObjAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlObjAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelGenrePercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictObjAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGenre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanelCopyrightKind)).EndInit();
            this.editPanelCopyrightKind.ResumeLayout(false);
            this.editPanelCopyrightKind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelCopyrightKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveCopyrightKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteCopyrightKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddCopyrightKind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvCopyrightKindList;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl searchCopyrightKind;
        private System.Windows.Forms.BindingSource bsViewTable;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadLabel lblObjAct;
        private Telerik.WinControls.UI.RadDropDownList ddlObjAct;
        private System.Windows.Forms.BindingSource bsRelGenrePercent;
        private System.Windows.Forms.BindingSource bsDictObjAct;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlGenre;
        private System.Windows.Forms.BindingSource bsDictGenreType;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBoxControl txtRate;
        private Telerik.WinControls.UI.RadPanel editPanelCopyrightKind;
        private Telerik.WinControls.UI.RadButton btnCancelCopyrightKind;
        private Telerik.WinControls.UI.RadButton btnSaveCopyrightKind;
        private Telerik.WinControls.UI.RadButton btnDeleteCopyrightKind;
        private Telerik.WinControls.UI.RadButton btnAddCopyrightKind;
        private IpsViewComponentLibrary.Common.GridRowCountControl ctrlGridRowCount;
    }
}
