using System.Drawing;
using System.Windows.Forms;
using sysAdminwp;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace sysAdminwp
{
    partial class DictionaryForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition5 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition6 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemSaveConfig = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemsSetDefaultSett = new Telerik.WinControls.UI.RadMenuItem();
            this.gvDictionariesList = new Telerik.WinControls.UI.RadGridView();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.treeViewList = new Telerik.WinControls.UI.RadTreeView();
            this.txtTreeFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radPanelChange = new Telerik.WinControls.UI.RadPanel();
            this.txtNameRu = new Telerik.WinControls.UI.RadTextBox();
            this.txtNameEn = new Telerik.WinControls.UI.RadTextBox();
            this.txtNameUa = new Telerik.WinControls.UI.RadTextBox();
            this.txtCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabelNameRu = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameEn = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameUa = new Telerik.WinControls.UI.RadLabel();
            this.radLabelCode = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.txtSearchData = new Telerik.WinControls.UI.RadTextBox();
            this.btnRemove = new Telerik.WinControls.UI.RadButton();
            this.radLblSearch = new System.Windows.Forms.Label();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox3 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox4 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.gvComplexDictionariesList = new Telerik.WinControls.UI.RadGridView();
            this.txtSearchComplex = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionariesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionariesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTreeFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelChange)).BeginInit();
            this.radPanelChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.radMenu1.Size = new System.Drawing.Size(985, 39);
            this.radMenu1.TabIndex = 8;
            this.radMenu1.ThemeName = "Office2013Light";
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Файл";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemSaveConfig,
            this.radMenuItemsSetDefaultSett});
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Конфігурація";
            // 
            // radMenuItemSaveConfig
            // 
            this.radMenuItemSaveConfig.Name = "radMenuItemSaveConfig";
            this.radMenuItemSaveConfig.Text = "Зберегти поточну конфігурацію";
            this.radMenuItemSaveConfig.Click += new System.EventHandler(this.radMenuItemSaveConfig_Click);
            // 
            // radMenuItemsSetDefaultSett
            // 
            this.radMenuItemsSetDefaultSett.Name = "radMenuItemsSetDefaultSett";
            this.radMenuItemsSetDefaultSett.Text = "Відновити початкові налаштуавння";
            this.radMenuItemsSetDefaultSett.Click += new System.EventHandler(this.radMenuItemsSetDefaultSett_Click);
            // 
            // gvDictionariesList
            // 
            this.gvDictionariesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDictionariesList.EnableCustomFiltering = true;
            this.gvDictionariesList.Location = new System.Drawing.Point(253, 32);
            this.gvDictionariesList.Margin = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.gvDictionariesList.MasterTemplate.AllowAddNewRow = false;
            this.gvDictionariesList.MasterTemplate.AllowColumnReorder = false;
            this.gvDictionariesList.MasterTemplate.AllowDeleteRow = false;
            this.gvDictionariesList.MasterTemplate.AllowDragToGroup = false;
            this.gvDictionariesList.MasterTemplate.AllowEditRow = false;
            this.gvDictionariesList.MasterTemplate.AutoGenerateColumns = false;
            this.gvDictionariesList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn17.FieldName = "Code";
            gridViewTextBoxColumn17.HeaderText = "Код";
            gridViewTextBoxColumn17.Name = "Code";
            gridViewTextBoxColumn17.Width = 66;
            gridViewTextBoxColumn18.FieldName = "NameUk";
            gridViewTextBoxColumn18.HeaderText = "Назва";
            gridViewTextBoxColumn18.Name = "NameUk";
            gridViewTextBoxColumn18.Width = 197;
            gridViewTextBoxColumn19.FieldName = "NameRu";
            gridViewTextBoxColumn19.HeaderText = "Название";
            gridViewTextBoxColumn19.Name = "NameRu";
            gridViewTextBoxColumn19.Width = 197;
            gridViewTextBoxColumn20.FieldName = "NameEn";
            gridViewTextBoxColumn20.HeaderText = "Name";
            gridViewTextBoxColumn20.Name = "NameEn";
            gridViewTextBoxColumn20.Width = 238;
            this.gvDictionariesList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20});
            this.gvDictionariesList.MasterTemplate.EnableCustomFiltering = true;
            this.gvDictionariesList.MasterTemplate.EnableFiltering = true;
            this.gvDictionariesList.MasterTemplate.ShowFilteringRow = false;
            this.gvDictionariesList.MasterTemplate.ViewDefinition = tableViewDefinition5;
            this.gvDictionariesList.Name = "gvDictionariesList";
            this.gvDictionariesList.ReadOnly = true;
            this.gvDictionariesList.ShowGroupPanel = false;
            this.gvDictionariesList.Size = new System.Drawing.Size(721, 232);
            this.gvDictionariesList.TabIndex = 0;
            this.gvDictionariesList.ThemeName = "Office2013Light";
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 39);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage2;
            this.radPageView1.Size = new System.Drawing.Size(985, 543);
            this.radPageView1.TabIndex = 1;
            this.radPageView1.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.treeViewList);
            this.radPageViewPage1.Controls.Add(this.txtTreeFilter);
            this.radPageViewPage1.Controls.Add(this.radPanelChange);
            this.radPageViewPage1.Controls.Add(this.txtSearchData);
            this.radPageViewPage1.Controls.Add(this.btnRemove);
            this.radPageViewPage1.Controls.Add(this.radLblSearch);
            this.radPageViewPage1.Controls.Add(this.btnAdd);
            this.radPageViewPage1.Controls.Add(this.gvDictionariesList);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(46F, 27F);
            this.radPageViewPage1.Location = new System.Drawing.Point(5, 31);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(975, 507);
            this.radPageViewPage1.Text = "prosti";
            // 
            // treeViewList
            // 
            this.treeViewList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewList.Location = new System.Drawing.Point(3, 28);
            this.treeViewList.Name = "treeViewList";
            this.treeViewList.Size = new System.Drawing.Size(229, 476);
            this.treeViewList.SpacingBetweenNodes = -1;
            this.treeViewList.TabIndex = 3;
            this.treeViewList.ThemeName = "Office2013Light";
            this.treeViewList.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.radTreeViewList_SelectedNodeChanged);
            // 
            // txtTreeFilter
            // 
            this.txtTreeFilter.Location = new System.Drawing.Point(3, 3);
            this.txtTreeFilter.Name = "txtTreeFilter";
            this.txtTreeFilter.NullText = "Фільтр";
            this.txtTreeFilter.Size = new System.Drawing.Size(229, 21);
            this.txtTreeFilter.TabIndex = 5;
            this.txtTreeFilter.ThemeName = "Office2013Light";
            this.txtTreeFilter.TextChanged += new System.EventHandler(this.radTxtBoxFilter_TextChanged);
            // 
            // radPanelChange
            // 
            this.radPanelChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanelChange.Controls.Add(this.txtNameRu);
            this.radPanelChange.Controls.Add(this.txtNameEn);
            this.radPanelChange.Controls.Add(this.txtNameUa);
            this.radPanelChange.Controls.Add(this.txtCode);
            this.radPanelChange.Controls.Add(this.radLabelNameRu);
            this.radPanelChange.Controls.Add(this.radLabelNameEn);
            this.radPanelChange.Controls.Add(this.radLabelNameUa);
            this.radPanelChange.Controls.Add(this.radLabelCode);
            this.radPanelChange.Controls.Add(this.btnCancel);
            this.radPanelChange.Controls.Add(this.btnSave);
            this.radPanelChange.Location = new System.Drawing.Point(260, 326);
            this.radPanelChange.Name = "radPanelChange";
            this.radPanelChange.Size = new System.Drawing.Size(712, 178);
            this.radPanelChange.TabIndex = 4;
            this.radPanelChange.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radPanelChange.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radBtnSave_Click);
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanelChange.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNameRu
            // 
            this.txtNameRu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameRu.Location = new System.Drawing.Point(162, 81);
            this.txtNameRu.Name = "txtNameRu";
            this.txtNameRu.Size = new System.Drawing.Size(532, 20);
            this.txtNameRu.TabIndex = 9;
            this.txtNameRu.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.TextBox_TextChanging);
            // 
            // txtNameEn
            // 
            this.txtNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameEn.Location = new System.Drawing.Point(162, 108);
            this.txtNameEn.Name = "txtNameEn";
            this.txtNameEn.Size = new System.Drawing.Size(532, 20);
            this.txtNameEn.TabIndex = 8;
            this.txtNameEn.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.TextBox_TextChanging);
            // 
            // txtNameUa
            // 
            this.txtNameUa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameUa.Location = new System.Drawing.Point(162, 55);
            this.txtNameUa.Name = "txtNameUa";
            this.txtNameUa.Size = new System.Drawing.Size(532, 20);
            this.txtNameUa.TabIndex = 7;
            this.txtNameUa.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.TextBox_TextChanging);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(162, 28);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(532, 20);
            this.txtCode.TabIndex = 6;
            this.txtCode.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.TextBox_TextChanging);
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
            this.btnCancel.Text = "Відміна";
            this.btnCancel.Click += new System.EventHandler(this.radBtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Зберегти";
            this.btnSave.Click += new System.EventHandler(this.radBtnSave_Click);
            // 
            // txtSearchData
            // 
            this.txtSearchData.Location = new System.Drawing.Point(300, 2);
            this.txtSearchData.Name = "txtSearchData";
            this.txtSearchData.Size = new System.Drawing.Size(580, 21);
            this.txtSearchData.TabIndex = 6;
            this.txtSearchData.TabStop = false;
            this.txtSearchData.ThemeName = "Office2013Light";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(383, 268);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(110, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Видалити";
            this.btnRemove.Click += new System.EventHandler(this.radBtnRemove_Click);
            // 
            // radLblSearch
            // 
            this.radLblSearch.AutoSize = true;
            this.radLblSearch.Location = new System.Drawing.Point(250, 5);
            this.radLblSearch.Name = "radLblSearch";
            this.radLblSearch.Size = new System.Drawing.Size(45, 15);
            this.radLblSearch.TabIndex = 7;
            this.radLblSearch.Text = "Search:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(253, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Додати";
            this.btnAdd.Click += new System.EventHandler(this.radBtnAdd_Click);
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.radButton3);
            this.radPageViewPage2.Controls.Add(this.radButton4);
            this.radPageViewPage2.Controls.Add(this.radPanel2);
            this.radPageViewPage2.Controls.Add(this.radPanel1);
            this.radPageViewPage2.Controls.Add(this.gvComplexDictionariesList);
            this.radPageViewPage2.Controls.Add(this.txtSearchComplex);
            this.radPageViewPage2.Controls.Add(this.radTreeView1);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(119F, 27F);
            this.radPageViewPage2.Location = new System.Drawing.Point(5, 31);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(975, 507);
            this.radPageViewPage2.Text = "radPageViewPage2";
            // 
            // radButton3
            // 
            this.radButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton3.Location = new System.Drawing.Point(509, 222);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(96, 24);
            this.radButton3.TabIndex = 14;
            this.radButton3.Text = "Видалити";
            this.radButton3.ThemeName = "Office2013Light";
            // 
            // radButton4
            // 
            this.radButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton4.Location = new System.Drawing.Point(379, 222);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(88, 24);
            this.radButton4.TabIndex = 13;
            this.radButton4.Text = "Додати";
            this.radButton4.ThemeName = "Office2013Light";
            // 
            // radPanel2
            // 
            this.radPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel2.Controls.Add(this.radTextBox1);
            this.radPanel2.Controls.Add(this.radTextBox2);
            this.radPanel2.Controls.Add(this.radTextBox3);
            this.radPanel2.Controls.Add(this.radTextBox4);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.radLabel2);
            this.radPanel2.Controls.Add(this.radLabel3);
            this.radPanel2.Controls.Add(this.radLabel4);
            this.radPanel2.Controls.Add(this.radButton1);
            this.radPanel2.Controls.Add(this.radButton2);
            this.radPanel2.Location = new System.Drawing.Point(379, 328);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(589, 172);
            this.radPanel2.TabIndex = 12;
            this.radPanel2.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radPanel2.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel2.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanel2.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.Location = new System.Drawing.Point(162, 81);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(409, 20);
            this.radTextBox1.TabIndex = 9;
            // 
            // radTextBox2
            // 
            this.radTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox2.Location = new System.Drawing.Point(162, 108);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(409, 20);
            this.radTextBox2.TabIndex = 8;
            // 
            // radTextBox3
            // 
            this.radTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox3.Location = new System.Drawing.Point(162, 55);
            this.radTextBox3.Name = "radTextBox3";
            this.radTextBox3.Size = new System.Drawing.Size(409, 20);
            this.radTextBox3.TabIndex = 7;
            // 
            // radTextBox4
            // 
            this.radTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox4.Location = new System.Drawing.Point(162, 28);
            this.radTextBox4.Name = "radTextBox4";
            this.radTextBox4.Size = new System.Drawing.Size(409, 20);
            this.radTextBox4.TabIndex = 6;
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
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.BackColor = System.Drawing.Color.Transparent;
            this.radLabel4.Location = new System.Drawing.Point(55, 28);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(90, 18);
            this.radLabel4.TabIndex = 2;
            this.radLabel4.Text = "Код:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(278, 135);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Відміна";
            this.radButton1.ThemeName = "Office2013Light";
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(162, 135);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 0;
            this.radButton2.Text = "Зберегти";
            this.radButton2.ThemeName = "Office2013Light";
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.Location = new System.Drawing.Point(379, 252);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(589, 70);
            this.radPanel1.TabIndex = 11;
            // 
            // gvComplexDictionariesList
            // 
            this.gvComplexDictionariesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvComplexDictionariesList.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.Location = new System.Drawing.Point(379, 27);
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
            gridViewTextBoxColumn21.FieldName = "Code";
            gridViewTextBoxColumn21.HeaderText = "Код";
            gridViewTextBoxColumn21.Name = "Code";
            gridViewTextBoxColumn21.Width = 54;
            gridViewTextBoxColumn22.FieldName = "NameUk";
            gridViewTextBoxColumn22.HeaderText = "Назва";
            gridViewTextBoxColumn22.Name = "NameUk";
            gridViewTextBoxColumn22.Width = 160;
            gridViewTextBoxColumn23.FieldName = "NameRu";
            gridViewTextBoxColumn23.HeaderText = "Название";
            gridViewTextBoxColumn23.Name = "NameRu";
            gridViewTextBoxColumn23.Width = 160;
            gridViewTextBoxColumn24.FieldName = "NameEn";
            gridViewTextBoxColumn24.HeaderText = "Name";
            gridViewTextBoxColumn24.Name = "NameEn";
            gridViewTextBoxColumn24.Width = 192;
            this.gvComplexDictionariesList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24});
            this.gvComplexDictionariesList.MasterTemplate.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.EnableFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.ShowFilteringRow = false;
            this.gvComplexDictionariesList.MasterTemplate.ViewDefinition = tableViewDefinition6;
            this.gvComplexDictionariesList.Name = "gvComplexDictionariesList";
            this.gvComplexDictionariesList.ReadOnly = true;
            this.gvComplexDictionariesList.ShowGroupPanel = false;
            this.gvComplexDictionariesList.Size = new System.Drawing.Size(589, 191);
            this.gvComplexDictionariesList.TabIndex = 10;
            this.gvComplexDictionariesList.ThemeName = "Office2013Light";
            this.gvComplexDictionariesList.SelectionChanged += new System.EventHandler(this.gvComplexDictionariesList_SelectionChanged);
            // 
            // txtSearchComplex
            // 
            this.txtSearchComplex.Location = new System.Drawing.Point(379, 3);
            this.txtSearchComplex.MaximumSize = new System.Drawing.Size(2000, 20);
            this.txtSearchComplex.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtSearchComplex.Name = "txtSearchComplex";
            this.txtSearchComplex.Size = new System.Drawing.Size(407, 20);
            this.txtSearchComplex.TabIndex = 9;
            // 
            // radTreeView1
            // 
            this.radTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radTreeView1.Location = new System.Drawing.Point(49, 244);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(195, 260);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 4;
            this.radTreeView1.ThemeName = "Office2013Light";
            this.radTreeView1.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.changesWhenSelectComplexDictionary);
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 582);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.radMenu1);
            this.Name = "DictionaryForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Довідники";
            this.ThemeName = "Office2013Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionariesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionariesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTreeFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelChange)).EndInit();
            this.radPanelChange.ResumeLayout(false);
            this.radPanelChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RadMenu radMenu1;
        private RadMenuItem radMenuItem1;
        private RadMenuItem radMenuItem2;
        private RadMenuItem radMenuItemSaveConfig;
        private RadMenuItem radMenuItemsSetDefaultSett;
        private RadGridView gvDictionariesList;
        private RadButton btnAdd;
        private RadButton btnRemove;
        private RadTreeView treeViewList;
        private RadButton btnSave;
        private RadButton btnCancel;
        private RadLabel radLabelCode;
        private RadLabel radLabelNameUa;
        private RadLabel radLabelNameEn;
        private RadLabel radLabelNameRu;
        private RadTextBox txtCode;
        private RadTextBox txtNameUa;
        private RadTextBox txtNameEn;
        private RadTextBox txtNameRu;
        private RadPanel radPanelChange;
        private RadTextBox txtTreeFilter;
        private RadTextBox txtSearchData;
        private Label radLblSearch;
        private RadPageView radPageView1;
        private RadPageViewPage radPageViewPage1;
        private RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private RadTreeView radTreeView1;
        private RadPanel radPanel1;
        private RadGridView gvComplexDictionariesList;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl txtSearchComplex;
        private RadPanel radPanel2;
        private RadTextBox radTextBox1;
        private RadTextBox radTextBox2;
        private RadTextBox radTextBox3;
        private RadTextBox radTextBox4;
        private RadLabel radLabel1;
        private RadLabel radLabel2;
        private RadLabel radLabel3;
        private RadLabel radLabel4;
        private RadButton radButton1;
        private RadButton radButton2;
        private RadButton radButton3;
        private RadButton radButton4;
    }
}