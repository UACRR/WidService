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
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.controlsParamPanel = new Telerik.WinControls.UI.RadPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlsParamPanel)).BeginInit();
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
            this.SuspendLayout();
            // 
            // complexTreeView
            // 
            this.complexTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.complexTreeView.Location = new System.Drawing.Point(3, 3);
            this.complexTreeView.Name = "complexTreeView";
            this.complexTreeView.Size = new System.Drawing.Size(133, 481);
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
            gridViewTextBoxColumn5.Width = 81;
            gridViewTextBoxColumn6.FieldName = "NameUk";
            gridViewTextBoxColumn6.HeaderText = "Назва";
            gridViewTextBoxColumn6.Name = "NameUk";
            gridViewTextBoxColumn6.Width = 242;
            gridViewTextBoxColumn7.FieldName = "NameRu";
            gridViewTextBoxColumn7.HeaderText = "Название";
            gridViewTextBoxColumn7.Name = "NameRu";
            gridViewTextBoxColumn7.Width = 242;
            gridViewTextBoxColumn8.FieldName = "NameEn";
            gridViewTextBoxColumn8.HeaderText = "Name";
            gridViewTextBoxColumn8.Name = "NameEn";
            gridViewTextBoxColumn8.Width = 292;
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
            this.gvComplexDictionariesList.Size = new System.Drawing.Size(880, 110);
            this.gvComplexDictionariesList.TabIndex = 11;
            this.gvComplexDictionariesList.ThemeName = "Office2013Light";
            this.gvComplexDictionariesList.SelectionChanged += new System.EventHandler(this.gvComplexDictionariesList_SelectionChanged);
            // 
            // radButton3
            // 
            this.radButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton3.Location = new System.Drawing.Point(272, 141);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(110, 24);
            this.radButton3.TabIndex = 16;
            this.radButton3.Text = "Видалити";
            this.radButton3.ThemeName = "Office2013Light";
            // 
            // radButton4
            // 
            this.radButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton4.Location = new System.Drawing.Point(142, 141);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(110, 24);
            this.radButton4.TabIndex = 15;
            this.radButton4.Text = "Додати";
            this.radButton4.ThemeName = "Office2013Light";
            // 
            // controlsParamPanel
            // 
            this.controlsParamPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsParamPanel.Location = new System.Drawing.Point(142, 171);
            this.controlsParamPanel.Name = "controlsParamPanel";
            this.controlsParamPanel.Size = new System.Drawing.Size(880, 70);
            this.controlsParamPanel.TabIndex = 17;
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
            this.radPanel2.Location = new System.Drawing.Point(142, 247);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(880, 237);
            this.radPanel2.TabIndex = 18;
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
            this.radTextBox1.Size = new System.Drawing.Size(700, 20);
            this.radTextBox1.TabIndex = 9;
            // 
            // radTextBox2
            // 
            this.radTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox2.Location = new System.Drawing.Point(162, 108);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(700, 20);
            this.radTextBox2.TabIndex = 8;
            // 
            // radTextBox3
            // 
            this.radTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox3.Location = new System.Drawing.Point(162, 55);
            this.radTextBox3.Name = "radTextBox3";
            this.radTextBox3.Size = new System.Drawing.Size(700, 20);
            this.radTextBox3.TabIndex = 7;
            // 
            // radTextBox4
            // 
            this.radTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox4.Location = new System.Drawing.Point(162, 28);
            this.radTextBox4.Name = "radTextBox4";
            this.radTextBox4.Size = new System.Drawing.Size(700, 20);
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
            // ComplexDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.controlsParamPanel);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton4);
            this.Controls.Add(this.gvComplexDictionariesList);
            this.Controls.Add(this.txtSearchComplex);
            this.Controls.Add(this.complexTreeView);
            this.Name = "ComplexDictionaryControl";
            this.Size = new System.Drawing.Size(1025, 487);
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComplexDictionariesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlsParamPanel)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView complexTreeView;
        private IpsViewComponentLibrary.Common.SearchTextBoxControl txtSearchComplex;
        private Telerik.WinControls.UI.RadGridView gvComplexDictionariesList;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadPanel controlsParamPanel;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadTextBox radTextBox3;
        private Telerik.WinControls.UI.RadTextBox radTextBox4;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
    }
}
