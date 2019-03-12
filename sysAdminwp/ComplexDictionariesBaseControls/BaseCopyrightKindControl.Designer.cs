namespace sysAdminwp.ComplexDictionariesBaseControls
{
    partial class BaseCopyrightKindControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.total = new Telerik.WinControls.UI.RadLabel();
            this.lbTotal = new Telerik.WinControls.UI.RadLabel();
            this.ddlCommonKeyData = new Telerik.WinControls.UI.RadDropDownList();
            this.lbCommonNameKey = new Telerik.WinControls.UI.RadLabel();
            this.radLblSearch = new System.Windows.Forms.Label();
            this.editPanel = new Telerik.WinControls.UI.RadPanel();
            this.ddlEditKeyField = new Telerik.WinControls.UI.RadDropDownList();
            this.txtNameRuComplex = new Telerik.WinControls.UI.RadTextBox();
            this.lbEditKeyField = new Telerik.WinControls.UI.RadLabel();
            this.txtNameEnComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtNameUaComplex = new Telerik.WinControls.UI.RadTextBox();
            this.txtCodeComplex = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblCode = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnDeleteComplex = new Telerik.WinControls.UI.RadButton();
            this.btnAddComplex = new Telerik.WinControls.UI.RadButton();
            this.gvComplexDictionariesList = new Telerik.WinControls.UI.RadGridView();
            this.txtSearchComplex = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCommonKeyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCommonNameKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanel)).BeginInit();
            this.editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEditKeyField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRuComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEditKeyField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEnComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUaComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddComplex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // total
            // 
            this.total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.total.Location = new System.Drawing.Point(1099, 346);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(29, 18);
            this.total.TabIndex = 30;
            this.total.Text = "dfgh";
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotal.AutoSize = false;
            this.lbTotal.Location = new System.Drawing.Point(996, 346);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(97, 18);
            this.lbTotal.TabIndex = 29;
            this.lbTotal.Text = "Всього записів";
            this.lbTotal.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddlCommonKeyData
            // 
            this.ddlCommonKeyData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCommonKeyData.DisplayMember = "Name";
            this.ddlCommonKeyData.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCommonKeyData.FormattingEnabled = false;
            this.ddlCommonKeyData.Location = new System.Drawing.Point(760, 2);
            this.ddlCommonKeyData.Name = "ddlCommonKeyData";
            this.ddlCommonKeyData.Size = new System.Drawing.Size(427, 21);
            this.ddlCommonKeyData.TabIndex = 22;
            this.ddlCommonKeyData.ThemeName = "Office2013Light";
            this.ddlCommonKeyData.ValueMember = "CodeI";
            // 
            // lbCommonNameKey
            // 
            this.lbCommonNameKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCommonNameKey.AutoSize = false;
            this.lbCommonNameKey.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCommonNameKey.Location = new System.Drawing.Point(627, 3);
            this.lbCommonNameKey.Name = "lbCommonNameKey";
            this.lbCommonNameKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCommonNameKey.Size = new System.Drawing.Size(127, 18);
            this.lbCommonNameKey.TabIndex = 21;
            this.lbCommonNameKey.Text = "Спосіб використання";
            this.lbCommonNameKey.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCommonNameKey.ThemeName = "Office2013Light";
            // 
            // radLblSearch
            // 
            this.radLblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radLblSearch.AutoSize = true;
            this.radLblSearch.Location = new System.Drawing.Point(3, 0);
            this.radLblSearch.Name = "radLblSearch";
            this.radLblSearch.Size = new System.Drawing.Size(43, 13);
            this.radLblSearch.TabIndex = 23;
            this.radLblSearch.Text = "Пошук:";
            // 
            // editPanel
            // 
            this.editPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editPanel.Controls.Add(this.ddlEditKeyField);
            this.editPanel.Controls.Add(this.txtNameRuComplex);
            this.editPanel.Controls.Add(this.lbEditKeyField);
            this.editPanel.Controls.Add(this.txtNameEnComplex);
            this.editPanel.Controls.Add(this.txtNameUaComplex);
            this.editPanel.Controls.Add(this.txtCodeComplex);
            this.editPanel.Controls.Add(this.radLabel1);
            this.editPanel.Controls.Add(this.radLabel2);
            this.editPanel.Controls.Add(this.radLabel3);
            this.editPanel.Controls.Add(this.lblCode);
            this.editPanel.Controls.Add(this.btnCancel);
            this.editPanel.Controls.Add(this.btnSave);
            this.editPanel.Location = new System.Drawing.Point(0, 370);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(1187, 202);
            this.editPanel.TabIndex = 28;
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
            // ddlEditKeyField
            // 
            this.ddlEditKeyField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlEditKeyField.DisplayMember = "Name";
            this.ddlEditKeyField.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlEditKeyField.Location = new System.Drawing.Point(783, 28);
            this.ddlEditKeyField.Name = "ddlEditKeyField";
            this.ddlEditKeyField.Size = new System.Drawing.Size(401, 21);
            this.ddlEditKeyField.TabIndex = 13;
            this.ddlEditKeyField.ThemeName = "Office2013Light";
            this.ddlEditKeyField.ValueMember = "CodeI";
            // 
            // txtNameRuComplex
            // 
            this.txtNameRuComplex.Location = new System.Drawing.Point(162, 81);
            this.txtNameRuComplex.MaxLength = 500;
            this.txtNameRuComplex.Name = "txtNameRuComplex";
            this.txtNameRuComplex.Size = new System.Drawing.Size(465, 20);
            this.txtNameRuComplex.TabIndex = 9;
            // 
            // lbEditKeyField
            // 
            this.lbEditKeyField.AutoSize = false;
            this.lbEditKeyField.Location = new System.Drawing.Point(633, 29);
            this.lbEditKeyField.Name = "lbEditKeyField";
            this.lbEditKeyField.Size = new System.Drawing.Size(144, 19);
            this.lbEditKeyField.TabIndex = 12;
            this.lbEditKeyField.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lbEditKeyField.ThemeName = "Office2013Light";
            // 
            // txtNameEnComplex
            // 
            this.txtNameEnComplex.Location = new System.Drawing.Point(162, 108);
            this.txtNameEnComplex.MaxLength = 500;
            this.txtNameEnComplex.Name = "txtNameEnComplex";
            this.txtNameEnComplex.Size = new System.Drawing.Size(465, 20);
            this.txtNameEnComplex.TabIndex = 8;
            // 
            // txtNameUaComplex
            // 
            this.txtNameUaComplex.Location = new System.Drawing.Point(162, 55);
            this.txtNameUaComplex.MaxLength = 500;
            this.txtNameUaComplex.Name = "txtNameUaComplex";
            this.txtNameUaComplex.Size = new System.Drawing.Size(465, 20);
            this.txtNameUaComplex.TabIndex = 7;
            // 
            // txtCodeComplex
            // 
            this.txtCodeComplex.Location = new System.Drawing.Point(162, 28);
            this.txtCodeComplex.MaxLength = 20;
            this.txtCodeComplex.Name = "txtCodeComplex";
            this.txtCodeComplex.Size = new System.Drawing.Size(465, 20);
            this.txtCodeComplex.TabIndex = 6;
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
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            // 
            // btnDeleteComplex
            // 
            this.btnDeleteComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteComplex.Location = new System.Drawing.Point(116, 340);
            this.btnDeleteComplex.Name = "btnDeleteComplex";
            this.btnDeleteComplex.Size = new System.Drawing.Size(110, 24);
            this.btnDeleteComplex.TabIndex = 27;
            this.btnDeleteComplex.Text = "Видалити";
            this.btnDeleteComplex.ThemeName = "Office2013Light";
            // 
            // btnAddComplex
            // 
            this.btnAddComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddComplex.Location = new System.Drawing.Point(0, 340);
            this.btnAddComplex.Name = "btnAddComplex";
            this.btnAddComplex.Size = new System.Drawing.Size(110, 24);
            this.btnAddComplex.TabIndex = 26;
            this.btnAddComplex.Text = "Додати";
            this.btnAddComplex.ThemeName = "Office2013Light";
            // 
            // gvComplexDictionariesList
            // 
            this.gvComplexDictionariesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvComplexDictionariesList.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.Location = new System.Drawing.Point(0, 27);
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
            gridViewTextBoxColumn1.FieldName = "Code";
            gridViewTextBoxColumn1.HeaderText = "Код";
            gridViewTextBoxColumn1.Name = "Code";
            gridViewTextBoxColumn1.Width = 105;
            gridViewTextBoxColumn2.FieldName = "NameUk";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Name = "NameUk";
            gridViewTextBoxColumn2.Width = 315;
            gridViewTextBoxColumn3.FieldName = "NameRu";
            gridViewTextBoxColumn3.HeaderText = "Название";
            gridViewTextBoxColumn3.Name = "NameRu";
            gridViewTextBoxColumn3.Width = 315;
            gridViewTextBoxColumn4.FieldName = "NameEn";
            gridViewTextBoxColumn4.HeaderText = "Name";
            gridViewTextBoxColumn4.Name = "NameEn";
            gridViewTextBoxColumn4.Width = 230;
            gridViewTextBoxColumn5.FieldName = "VariantUse";
            gridViewTextBoxColumn5.HeaderText = "Спосіб використання";
            gridViewTextBoxColumn5.MinWidth = 200;
            gridViewTextBoxColumn5.Name = "VariantUse";
            gridViewTextBoxColumn5.Width = 200;
            this.gvComplexDictionariesList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvComplexDictionariesList.MasterTemplate.EnableCustomFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.EnableFiltering = true;
            this.gvComplexDictionariesList.MasterTemplate.ShowFilteringRow = false;
            this.gvComplexDictionariesList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvComplexDictionariesList.Name = "gvComplexDictionariesList";
            this.gvComplexDictionariesList.ReadOnly = true;
            this.gvComplexDictionariesList.ShowGroupPanel = false;
            this.gvComplexDictionariesList.Size = new System.Drawing.Size(1187, 309);
            this.gvComplexDictionariesList.TabIndex = 25;
            this.gvComplexDictionariesList.ThemeName = "Office2013Light";
            // 
            // txtSearchComplex
            // 
            this.txtSearchComplex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchComplex.Location = new System.Drawing.Point(53, 0);
            this.txtSearchComplex.MaximumSize = new System.Drawing.Size(2000, 20);
            this.txtSearchComplex.MinimumSize = new System.Drawing.Size(20, 20);
            this.txtSearchComplex.Name = "txtSearchComplex";
            this.txtSearchComplex.Size = new System.Drawing.Size(568, 20);
            this.txtSearchComplex.TabIndex = 24;
            // 
            // BaseCopyrightKindControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.total);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.ddlCommonKeyData);
            this.Controls.Add(this.lbCommonNameKey);
            this.Controls.Add(this.radLblSearch);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.btnDeleteComplex);
            this.Controls.Add(this.btnAddComplex);
            this.Controls.Add(this.gvComplexDictionariesList);
            this.Controls.Add(this.txtSearchComplex);
            this.Name = "BaseCopyrightKindControl";
            this.Size = new System.Drawing.Size(1187, 572);
            ((System.ComponentModel.ISupportInitialize)(this.total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCommonKeyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCommonNameKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanel)).EndInit();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEditKeyField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameRuComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEditKeyField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameEnComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameUaComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodeComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddComplex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel total;
        private Telerik.WinControls.UI.RadLabel lbTotal;
        private Telerik.WinControls.UI.RadDropDownList ddlCommonKeyData;
        private Telerik.WinControls.UI.RadLabel lbCommonNameKey;
        private System.Windows.Forms.Label radLblSearch;
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
        private Telerik.WinControls.UI.RadButton btnDeleteComplex;
        private Telerik.WinControls.UI.RadButton btnAddComplex;
        private Telerik.WinControls.UI.RadGridView gvComplexDictionariesList;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl txtSearchComplex;
        private Telerik.WinControls.UI.RadDropDownList ddlEditKeyField;
        private Telerik.WinControls.UI.RadLabel lbEditKeyField;
    }
}
