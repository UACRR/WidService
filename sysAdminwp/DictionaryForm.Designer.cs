using System.Drawing;
using System.Windows.Forms;
using sysAdminwp;
using sysAdminwp.DictionaryControls;
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemSaveConfig = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemsSetDefaultSett = new Telerik.WinControls.UI.RadMenuItem();
            this.gvDictionariesList = new Telerik.WinControls.UI.RadGridView();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvSimpleDictionary = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlSimpleDictionary = new sysAdminwp.DictionaryControls.SimpleDictionaryControl();
            this.pvComplexDictionary = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlComplexDictionary = new sysAdminwp.DictionaryControls.ComplexDictionaryControl();
            this.pvSimpleOld = new Telerik.WinControls.UI.RadPageViewPage();
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionariesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDictionariesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvSimpleDictionary.SuspendLayout();
            this.pvComplexDictionary.SuspendLayout();
            this.pvSimpleOld.SuspendLayout();
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
            this.radMenu1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.radMenu1.Size = new System.Drawing.Size(1105, 27);
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
            this.radMenuItemSaveConfig.Enabled = false;
            this.radMenuItemSaveConfig.Name = "radMenuItemSaveConfig";
            this.radMenuItemSaveConfig.Text = "Зберегти поточну конфігурацію";
            this.radMenuItemSaveConfig.Click += new System.EventHandler(this.radMenuItemSaveConfig_Click);
            // 
            // radMenuItemsSetDefaultSett
            // 
            this.radMenuItemsSetDefaultSett.Enabled = false;
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
            this.gvDictionariesList.Enabled = false;
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
            gridViewTextBoxColumn1.FieldName = "Code";
            gridViewTextBoxColumn1.HeaderText = "Код";
            gridViewTextBoxColumn1.Name = "Code";
            gridViewTextBoxColumn1.Width = 77;
            gridViewTextBoxColumn2.FieldName = "NameUk";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Name = "NameUk";
            gridViewTextBoxColumn2.Width = 231;
            gridViewTextBoxColumn3.FieldName = "NameRu";
            gridViewTextBoxColumn3.HeaderText = "Название";
            gridViewTextBoxColumn3.Name = "NameRu";
            gridViewTextBoxColumn3.Width = 231;
            gridViewTextBoxColumn4.FieldName = "NameEn";
            gridViewTextBoxColumn4.HeaderText = "Name";
            gridViewTextBoxColumn4.Name = "NameEn";
            gridViewTextBoxColumn4.Width = 279;
            this.gvDictionariesList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvDictionariesList.MasterTemplate.EnableCustomFiltering = true;
            this.gvDictionariesList.MasterTemplate.EnableFiltering = true;
            this.gvDictionariesList.MasterTemplate.ShowFilteringRow = false;
            this.gvDictionariesList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvDictionariesList.Name = "gvDictionariesList";
            this.gvDictionariesList.ReadOnly = true;
            this.gvDictionariesList.ShowGroupPanel = false;
            this.gvDictionariesList.Size = new System.Drawing.Size(841, 203);
            this.gvDictionariesList.TabIndex = 0;
            this.gvDictionariesList.ThemeName = "Office2013Light";
            this.gvDictionariesList.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.RadGridView1_CurrentRowChanged);
            this.gvDictionariesList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.RadGridView1_CustomFiltering);
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvSimpleDictionary);
            this.pageView.Controls.Add(this.pvComplexDictionary);
            this.pageView.Controls.Add(this.pvSimpleOld);
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 27);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvSimpleDictionary;
            this.pageView.Size = new System.Drawing.Size(1105, 514);
            this.pageView.TabIndex = 1;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pvSimpleDictionary
            // 
            this.pvSimpleDictionary.Controls.Add(this.ctrlSimpleDictionary);
            this.pvSimpleDictionary.ItemSize = new System.Drawing.SizeF(113F, 27F);
            this.pvSimpleDictionary.Location = new System.Drawing.Point(5, 31);
            this.pvSimpleDictionary.Name = "pvSimpleDictionary";
            this.pvSimpleDictionary.Size = new System.Drawing.Size(1095, 478);
            this.pvSimpleDictionary.Text = "Прості довідники";
            // 
            // ctrlSimpleDictionary
            // 
            this.ctrlSimpleDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSimpleDictionary.IsEditMode = false;
            this.ctrlSimpleDictionary.Location = new System.Drawing.Point(0, 0);
            this.ctrlSimpleDictionary.Name = "ctrlSimpleDictionary";
            this.ctrlSimpleDictionary.Size = new System.Drawing.Size(1095, 478);
            this.ctrlSimpleDictionary.TabIndex = 0;
            // 
            // pvComplexDictionary
            // 
            this.pvComplexDictionary.Controls.Add(this.ctrlComplexDictionary);
            this.pvComplexDictionary.ItemSize = new System.Drawing.SizeF(119F, 27F);
            this.pvComplexDictionary.Location = new System.Drawing.Point(5, 31);
            this.pvComplexDictionary.Name = "pvComplexDictionary";
            this.pvComplexDictionary.Size = new System.Drawing.Size(1095, 478);
            this.pvComplexDictionary.Text = "Складні довідники";
            // 
            // ctrlComplexDictionary
            // 
            this.ctrlComplexDictionary.ComplexDictionaryList = null;
            this.ctrlComplexDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlComplexDictionary.Location = new System.Drawing.Point(0, 0);
            this.ctrlComplexDictionary.Name = "ctrlComplexDictionary";
            this.ctrlComplexDictionary.Size = new System.Drawing.Size(1095, 478);
            this.ctrlComplexDictionary.TabIndex = 0;
            // 
            // pvSimpleOld
            // 
            this.pvSimpleOld.Controls.Add(this.treeViewList);
            this.pvSimpleOld.Controls.Add(this.txtTreeFilter);
            this.pvSimpleOld.Controls.Add(this.radPanelChange);
            this.pvSimpleOld.Controls.Add(this.txtSearchData);
            this.pvSimpleOld.Controls.Add(this.btnRemove);
            this.pvSimpleOld.Controls.Add(this.radLblSearch);
            this.pvSimpleOld.Controls.Add(this.btnAdd);
            this.pvSimpleOld.Controls.Add(this.gvDictionariesList);
            this.pvSimpleOld.ItemSize = new System.Drawing.SizeF(113F, 27F);
            this.pvSimpleOld.Location = new System.Drawing.Point(5, 31);
            this.pvSimpleOld.Name = "pvSimpleOld";
            this.pvSimpleOld.Size = new System.Drawing.Size(1095, 478);
            this.pvSimpleOld.Text = "Прості довідники";
            // 
            // treeViewList
            // 
            this.treeViewList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewList.Location = new System.Drawing.Point(3, 28);
            this.treeViewList.Name = "treeViewList";
            this.treeViewList.Size = new System.Drawing.Size(229, 447);
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
            this.radPanelChange.Enabled = false;
            this.radPanelChange.Location = new System.Drawing.Point(253, 269);
            this.radPanelChange.Name = "radPanelChange";
            this.radPanelChange.Size = new System.Drawing.Size(839, 206);
            this.radPanelChange.TabIndex = 4;
            this.radPanelChange.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radPanelChange.ThemeName = "Office2013Light";
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
            this.txtNameRu.Size = new System.Drawing.Size(659, 0);
            this.txtNameRu.TabIndex = 8;
            this.txtNameRu.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.TextBox_TextChanging);
            // 
            // txtNameEn
            // 
            this.txtNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameEn.Location = new System.Drawing.Point(162, 108);
            this.txtNameEn.Name = "txtNameEn";
            this.txtNameEn.Size = new System.Drawing.Size(659, 0);
            this.txtNameEn.TabIndex = 9;
            this.txtNameEn.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.TextBox_TextChanging);
            // 
            // txtNameUa
            // 
            this.txtNameUa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameUa.Location = new System.Drawing.Point(162, 55);
            this.txtNameUa.Name = "txtNameUa";
            this.txtNameUa.Size = new System.Drawing.Size(659, 0);
            this.txtNameUa.TabIndex = 7;
            this.txtNameUa.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.TextBox_TextChanging);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(162, 28);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(659, 0);
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
            this.btnSave.Click += new System.EventHandler(this.radBtnSave_Click);
            // 
            // txtSearchData
            // 
            this.txtSearchData.Enabled = false;
            this.txtSearchData.Location = new System.Drawing.Point(300, 2);
            this.txtSearchData.Name = "txtSearchData";
            this.txtSearchData.Size = new System.Drawing.Size(580, 21);
            this.txtSearchData.TabIndex = 6;
            this.txtSearchData.TabStop = false;
            this.txtSearchData.ThemeName = "Office2013Light";
            this.txtSearchData.TextChanged += new System.EventHandler(this.RadTxtBoxSearchData_TextChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(383, 239);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(110, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Видалити";
            this.btnRemove.ThemeName = "Office2013Light";
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
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(253, 239);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Додати";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.radBtnAdd_Click);
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1105, 541);
            this.Controls.Add(this.pageView);
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
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvSimpleDictionary.ResumeLayout(false);
            this.pvComplexDictionary.ResumeLayout(false);
            this.pvSimpleOld.ResumeLayout(false);
            this.pvSimpleOld.PerformLayout();
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
        private RadPageView pageView;
        private RadPageViewPage pvSimpleOld;
        private RadPageViewPage pvComplexDictionary;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private ComplexDictionaryControl ctrlComplexDictionary;
        private RadPageViewPage pvSimpleDictionary;
        private SimpleDictionaryControl ctrlSimpleDictionary;
    }
}