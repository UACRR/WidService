namespace sysAdminwp.viewPageDictionaryControls
{
    partial class ComplexDictionaryControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn29 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn30 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn31 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn32 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            this.complexTreeView = new Telerik.WinControls.UI.RadTreeView();
            this.gvComplexDictionariesList = new Telerik.WinControls.UI.RadGridView();
            this.btnDeleteComplex = new Telerik.WinControls.UI.RadButton();
            this.btnAddComplex = new Telerik.WinControls.UI.RadButton();
            this.editPanel = new Telerik.WinControls.UI.RadPanel();
            this.txtNameRuComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtNameEnComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtNameUaComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtCodeComplex = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblCode = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLblSearch = new System.Windows.Forms.Label();
            this.txtSearchComplex = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.lbCommonNameKey = new Telerik.WinControls.UI.RadLabel();
            this.ddlCommonKeyData = new Telerik.WinControls.UI.RadDropDownList();
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanel)).BeginInit();
            this.editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRuComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEnComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUaComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCommonNameKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCommonKeyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // complexTreeView
            // 
            this.complexTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.complexTreeView.Location = new System.Drawing.Point(3, 3);
            this.complexTreeView.Name = "complexTreeView";
            this.complexTreeView.Size = new System.Drawing.Size(229, 560);
            this.complexTreeView.SpacingBetweenNodes = -1;
            this.complexTreeView.TabIndex = 5;
            this.complexTreeView.ThemeName = "Office2013Light";
            this.complexTreeView.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.complexTreeView_SelectedNodeChanged);
            // 
            // gvComplexDictionariesList
            // 
            this.gvComplexDictionariesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvComplexDictionariesList.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.Location = new System.Drawing.Point(253, 32);
            this.gvComplexDictionariesList.Margin = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.gvComplexDictionariesList.MasterTemplate.AllowAddNewRow = false;
            this.gvComplexDictionariesList.MasterTemplate.AllowColumnReorder = false;
            this.gvComplexDictionariesList.MasterTemplate.AllowDeleteRow = false;
            this.gvComplexDictionariesList.MasterTemplate.AllowDragToGroup = false;
            this.gvComplexDictionariesList.MasterTemplate.AllowEditRow = false;
            this.gvComplexDictionariesList.MasterTemplate.AutoGenerateColumns = false;
            this.gvComplexDictionariesList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn29.FieldName = "Code";
            gridViewTextBoxColumn29.HeaderText = "Код";
            gridViewTextBoxColumn29.Name = "Code";
            gridViewTextBoxColumn29.Width = 109;
            gridViewTextBoxColumn30.FieldName = "NameUk";
            gridViewTextBoxColumn30.HeaderText = "Назва";
            gridViewTextBoxColumn30.Name = "NameUk";
            gridViewTextBoxColumn30.Width = 325;
            gridViewTextBoxColumn31.FieldName = "NameRu";
            gridViewTextBoxColumn31.HeaderText = "Название";
            gridViewTextBoxColumn31.Name = "NameRu";
            gridViewTextBoxColumn31.Width = 325;
            gridViewTextBoxColumn32.FieldName = "NameEn";
            gridViewTextBoxColumn32.HeaderText = "Name";
            gridViewTextBoxColumn32.Name = "NameEn";
            gridViewTextBoxColumn32.Width = 394;
            this.gvComplexDictionariesList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn29,
            gridViewTextBoxColumn30,
            gridViewTextBoxColumn31,
            gridViewTextBoxColumn32});
            this.gvComplexDictionariesList.MasterTemplate.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.EnableFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.ShowFilteringRow = false;
            this.gvComplexDictionariesList.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.gvComplexDictionariesList.Name = "gvComplexDictionariesList";
            this.gvComplexDictionariesList.ReadOnly = true;
            this.gvComplexDictionariesList.ShowGroupPanel = false;
            this.gvComplexDictionariesList.Size = new System.Drawing.Size(1176, 316);
            this.gvComplexDictionariesList.TabIndex = 11;
            this.gvComplexDictionariesList.ThemeName = "Office2013Light";
            this.gvComplexDictionariesList.SelectionChanged += new System.EventHandler(this.gvComplexDictionariesList_SelectionChanged);
            this.gvComplexDictionariesList.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.gvComplexDictionariesList_DataBindingComplete);
            // 
            // btnDeleteComplex
            // 
            this.btnDeleteComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteComplex.Location = new System.Drawing.Point(392, 352);
            this.btnDeleteComplex.Name = "btnDeleteComplex";
            this.btnDeleteComplex.Size = new System.Drawing.Size(110, 24);
            this.btnDeleteComplex.TabIndex = 16;
            this.btnDeleteComplex.Text = "Видалити";
            this.btnDeleteComplex.ThemeName = "Office2013Light";
            this.btnDeleteComplex.Click += new System.EventHandler(this.btnDeleteComplex_Click);
            // 
            // btnAddComplex
            // 
            this.btnAddComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddComplex.Location = new System.Drawing.Point(253, 352);
            this.btnAddComplex.Name = "btnAddComplex";
            this.btnAddComplex.Size = new System.Drawing.Size(110, 24);
            this.btnAddComplex.TabIndex = 15;
            this.btnAddComplex.Text = "Додати";
            this.btnAddComplex.ThemeName = "Office2013Light";
            this.btnAddComplex.Click += new System.EventHandler(this.btnAddComplex_Click);
            // 
            // editPanel
            // 
            this.editPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editPanel.Controls.Add(this.txtNameRuComplex);
            this.editPanel.Controls.Add(this.txtNameEnComplex);
            this.editPanel.Controls.Add(this.txtNameUaComplex);
            this.editPanel.Controls.Add(this.txtCodeComplex);
            this.editPanel.Controls.Add(this.radLabel1);
            this.editPanel.Controls.Add(this.radLabel2);
            this.editPanel.Controls.Add(this.radLabel3);
            this.editPanel.Controls.Add(this.lblCode);
            this.editPanel.Controls.Add(this.btnCancel);
            this.editPanel.Controls.Add(this.btnSave);
            this.editPanel.Location = new System.Drawing.Point(253, 382);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(1176, 181);
            this.editPanel.TabIndex = 18;
            this.editPanel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.editPanel.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPanelElement)(this.editPanel.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanel.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanel.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.editPanel.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanel.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanel.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.editPanel.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNameRuComplex
            // 
            this.txtNameRuComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameRuComplex.Location = new System.Drawing.Point(162, 81);
            this.txtNameRuComplex.MaxLength = 500;
            this.txtNameRuComplex.Name = "txtNameRuComplex";
            this.txtNameRuComplex.Size = new System.Drawing.Size(996, 20);
            this.txtNameRuComplex.TabIndex = 9;
            this.txtNameRuComplex.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtCodeComplex_TextChanging);
            // 
            // txtNameEnComplex
            // 
            this.txtNameEnComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameEnComplex.Location = new System.Drawing.Point(162, 108);
            this.txtNameEnComplex.MaxLength = 500;
            this.txtNameEnComplex.Name = "txtNameEnComplex";
            this.txtNameEnComplex.Size = new System.Drawing.Size(996, 20);
            this.txtNameEnComplex.TabIndex = 8;
            this.txtNameEnComplex.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtCodeComplex_TextChanging);
            // 
            // txtNameUaComplex
            // 
            this.txtNameUaComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameUaComplex.Location = new System.Drawing.Point(162, 55);
            this.txtNameUaComplex.MaxLength = 500;
            this.txtNameUaComplex.Name = "txtNameUaComplex";
            this.txtNameUaComplex.Size = new System.Drawing.Size(996, 20);
            this.txtNameUaComplex.TabIndex = 7;
            this.txtNameUaComplex.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtCodeComplex_TextChanging);
            // 
            // txtCodeComplex
            // 
            this.txtCodeComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeComplex.Location = new System.Drawing.Point(162, 28);
            this.txtCodeComplex.MaxLength = 20;
            this.txtCodeComplex.Name = "txtCodeComplex";
            this.txtCodeComplex.Size = new System.Drawing.Size(996, 20);
            this.txtCodeComplex.TabIndex = 6;
            this.txtCodeComplex.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtCodeComplex_TextChanging);
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Location = new System.Drawing.Point(55, 82);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(90, 18);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "Название (RU):";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Location = new System.Drawing.Point(55, 109);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(90, 18);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "Name (EN):";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Location = new System.Drawing.Point(55, 55);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(90, 18);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "Назва (UA):";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = false;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(55, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(90, 18);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Код:";
            this.lblCode.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Відміна";
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
            // radLblSearch
            // 
            this.radLblSearch.AutoSize = true;
            this.radLblSearch.Location = new System.Drawing.Point(250, 5);
            this.radLblSearch.Name = "radLblSearch";
            this.radLblSearch.Size = new System.Drawing.Size(44, 13);
            this.radLblSearch.TabIndex = 7;
            this.radLblSearch.Text = "Search:";
            // 
            // txtSearchComplex
            // 
            this.txtSearchComplex.Location = new System.Drawing.Point(300, 2);
            this.txtSearchComplex.MaximumSize = new System.Drawing.Size(2000, 20);
            this.txtSearchComplex.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtSearchComplex.Name = "txtSearchComplex";
            this.txtSearchComplex.Size = new System.Drawing.Size(580, 20);
            this.txtSearchComplex.TabIndex = 10;
            // 
            // lbCommonNameKey
            // 
            this.lbCommonNameKey.AutoSize = false;
            this.lbCommonNameKey.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCommonNameKey.Location = new System.Drawing.Point(886, 5);
            this.lbCommonNameKey.Name = "lbCommonNameKey";
            this.lbCommonNameKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCommonNameKey.Size = new System.Drawing.Size(127, 18);
            this.lbCommonNameKey.TabIndex = 5;
            this.lbCommonNameKey.Text = "Спосіб використання";
            this.lbCommonNameKey.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCommonNameKey.ThemeName = "Office2013Light";
            this.lbCommonNameKey.Visible = false;
            // 
            // ddlCommonKeyData
            // 
            this.ddlCommonKeyData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCommonKeyData.DataSource = this.dictBaseTypeIBindingSource;
            this.ddlCommonKeyData.DisplayMember = "Name";
            this.ddlCommonKeyData.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCommonKeyData.FormattingEnabled = false;
            this.ddlCommonKeyData.Location = new System.Drawing.Point(1019, 3);
            this.ddlCommonKeyData.Name = "ddlCommonKeyData";
            this.ddlCommonKeyData.Size = new System.Drawing.Size(410, 21);
            this.ddlCommonKeyData.TabIndex = 6;
            this.ddlCommonKeyData.ThemeName = "Office2013Light";
            this.ddlCommonKeyData.ValueMember = "CodeI";
            this.ddlCommonKeyData.Visible = false;
            this.ddlCommonKeyData.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCrkindGroup_SelectedIndexChanged);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // ComplexDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlCommonKeyData);
            this.Controls.Add(this.lbCommonNameKey);
            this.Controls.Add(this.radLblSearch);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.btnDeleteComplex);
            this.Controls.Add(this.btnAddComplex);
            this.Controls.Add(this.gvComplexDictionariesList);
            this.Controls.Add(this.txtSearchComplex);
            this.Controls.Add(this.complexTreeView);
            this.Name = "ComplexDictionaryControl";
            this.Size = new System.Drawing.Size(1432, 566);
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanel)).EndInit();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRuComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEnComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUaComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCommonNameKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCommonKeyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView complexTreeView;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl txtSearchComplex;
        private Telerik.WinControls.UI.RadGridView gvComplexDictionariesList;
        private Telerik.WinControls.UI.RadButton btnDeleteComplex;
        private Telerik.WinControls.UI.RadButton btnAddComplex;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadTextBox txtNameRuComplex;
        private Telerik.WinControls.UI.RadTextBox txtNameEnComplex;
        private Telerik.WinControls.UI.RadTextBox txtNameUaComplex;
        private Telerik.WinControls.UI.RadTextBox txtCodeComplex;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblCode;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.Label radLblSearch;
        private Telerik.WinControls.UI.RadLabel lbCommonNameKey;
        private Telerik.WinControls.UI.RadDropDownList ddlCommonKeyData;
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
    }
}
