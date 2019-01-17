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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.complexTreeView = new Telerik.WinControls.UI.RadTreeView();
            this.txtSearchComplex = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.gvComplexDictionariesList = new Telerik.WinControls.UI.RadGridView();
            this.btnDeleteComplex = new Telerik.WinControls.UI.RadButton();
            this.btnAddComplex = new Telerik.WinControls.UI.RadButton();
            this.controlsParamPanel = new Telerik.WinControls.UI.RadPanel();
            this.editPanel = new Telerik.WinControls.UI.RadPanel();
            this.txtNameRuComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtNameEnComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtNameUaComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtCodeComplex = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlsParamPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanel)).BeginInit();
            this.editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRuComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEnComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUaComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // complexTreeView
            // 
            this.complexTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.complexTreeView.Location = new System.Drawing.Point(3, 3);
            this.complexTreeView.Name = "complexTreeView";
            this.complexTreeView.Size = new System.Drawing.Size(133, 744);
            this.complexTreeView.SpacingBetweenNodes = -1;
            this.complexTreeView.TabIndex = 5;
            this.complexTreeView.ThemeName = "Office2013Light";
            this.complexTreeView.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.complexTreeView_SelectedNodeChanged);
            // 
            // txtSearchComplex
            // 
            this.txtSearchComplex.Location = new System.Drawing.Point(142, 3);
            this.txtSearchComplex.MaximumSize = new System.Drawing.Size(2000, 20);
            this.txtSearchComplex.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtSearchComplex.Name = "txtSearchComplex";
            this.txtSearchComplex.Size = new System.Drawing.Size(534, 20);
            this.txtSearchComplex.TabIndex = 10;
            // 
            // gvComplexDictionariesList
            // 
            this.gvComplexDictionariesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvComplexDictionariesList.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.Location = new System.Drawing.Point(142, 27);
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
            gridViewTextBoxColumn5.FieldName = "Code";
            gridViewTextBoxColumn5.HeaderText = "Код";
            gridViewTextBoxColumn5.Name = "Code";
            gridViewTextBoxColumn5.Width = 119;
            gridViewTextBoxColumn6.FieldName = "NameUk";
            gridViewTextBoxColumn6.HeaderText = "Назва";
            gridViewTextBoxColumn6.Name = "NameUk";
            gridViewTextBoxColumn6.Width = 357;
            gridViewTextBoxColumn7.FieldName = "NameRu";
            gridViewTextBoxColumn7.HeaderText = "Название";
            gridViewTextBoxColumn7.Name = "NameRu";
            gridViewTextBoxColumn7.Width = 357;
            gridViewTextBoxColumn8.FieldName = "NameEn";
            gridViewTextBoxColumn8.HeaderText = "Name";
            gridViewTextBoxColumn8.Name = "NameEn";
            gridViewTextBoxColumn8.Width = 431;
            this.gvComplexDictionariesList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.gvComplexDictionariesList.MasterTemplate.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.EnableFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.ShowFilteringRow = false;
            this.gvComplexDictionariesList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvComplexDictionariesList.Name = "gvComplexDictionariesList";
            this.gvComplexDictionariesList.ReadOnly = true;
            this.gvComplexDictionariesList.ShowGroupPanel = false;
            this.gvComplexDictionariesList.Size = new System.Drawing.Size(1287, 373);
            this.gvComplexDictionariesList.TabIndex = 11;
            this.gvComplexDictionariesList.ThemeName = "Office2013Light";
            this.gvComplexDictionariesList.SelectionChanged += new System.EventHandler(this.gvComplexDictionariesList_SelectionChanged);
            this.gvComplexDictionariesList.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.gvComplexDictionariesList_DataBindingComplete);
            // 
            // btnDeleteComplex
            // 
            this.btnDeleteComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteComplex.Location = new System.Drawing.Point(272, 404);
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
            this.btnAddComplex.Location = new System.Drawing.Point(142, 404);
            this.btnAddComplex.Name = "btnAddComplex";
            this.btnAddComplex.Size = new System.Drawing.Size(110, 24);
            this.btnAddComplex.TabIndex = 15;
            this.btnAddComplex.Text = "Додати";
            this.btnAddComplex.ThemeName = "Office2013Light";
            this.btnAddComplex.Click += new System.EventHandler(this.btnAddComplex_Click);
            // 
            // controlsParamPanel
            // 
            this.controlsParamPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsParamPanel.Location = new System.Drawing.Point(142, 434);
            this.controlsParamPanel.Name = "controlsParamPanel";
            this.controlsParamPanel.Size = new System.Drawing.Size(1287, 70);
            this.controlsParamPanel.TabIndex = 17;
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
            this.editPanel.Controls.Add(this.radLabel4);
            this.editPanel.Controls.Add(this.btnCancel);
            this.editPanel.Controls.Add(this.btnSave);
            this.editPanel.Location = new System.Drawing.Point(142, 510);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(1287, 237);
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
            this.txtNameRuComplex.Name = "txtNameRuComplex";
            this.txtNameRuComplex.Size = new System.Drawing.Size(1107, 20);
            this.txtNameRuComplex.TabIndex = 9;
            this.txtNameRuComplex.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtCodeComplex_TextChanging);
            // 
            // txtNameEnComplex
            // 
            this.txtNameEnComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameEnComplex.Location = new System.Drawing.Point(162, 108);
            this.txtNameEnComplex.Name = "txtNameEnComplex";
            this.txtNameEnComplex.Size = new System.Drawing.Size(1107, 20);
            this.txtNameEnComplex.TabIndex = 8;
            this.txtNameEnComplex.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtCodeComplex_TextChanging);
            // 
            // txtNameUaComplex
            // 
            this.txtNameUaComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameUaComplex.Location = new System.Drawing.Point(162, 55);
            this.txtNameUaComplex.Name = "txtNameUaComplex";
            this.txtNameUaComplex.Size = new System.Drawing.Size(1107, 20);
            this.txtNameUaComplex.TabIndex = 7;
            this.txtNameUaComplex.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtCodeComplex_TextChanging);
            // 
            // txtCodeComplex
            // 
            this.txtCodeComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeComplex.Location = new System.Drawing.Point(162, 28);
            this.txtCodeComplex.Name = "txtCodeComplex";
            this.txtCodeComplex.Size = new System.Drawing.Size(1107, 20);
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
            // ComplexDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.controlsParamPanel);
            this.Controls.Add(this.btnDeleteComplex);
            this.Controls.Add(this.btnAddComplex);
            this.Controls.Add(this.gvComplexDictionariesList);
            this.Controls.Add(this.txtSearchComplex);
            this.Controls.Add(this.complexTreeView);
            this.Name = "ComplexDictionaryControl";
            this.Size = new System.Drawing.Size(1432, 750);
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlsParamPanel)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView complexTreeView;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl txtSearchComplex;
        private Telerik.WinControls.UI.RadGridView gvComplexDictionariesList;
        private Telerik.WinControls.UI.RadButton btnDeleteComplex;
        private Telerik.WinControls.UI.RadButton btnAddComplex;
        private Telerik.WinControls.UI.RadPanel controlsParamPanel;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadTextBox txtNameRuComplex;
        private Telerik.WinControls.UI.RadTextBox txtNameEnComplex;
        private Telerik.WinControls.UI.RadTextBox txtNameUaComplex;
        private Telerik.WinControls.UI.RadTextBox txtCodeComplex;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}
