using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace sysAdminwp
{
    partial class RadForm1
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
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn1 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radBtnAdd = new Telerik.WinControls.UI.RadButton();
            this.radBtnRemove = new Telerik.WinControls.UI.RadButton();
            this.radTreeViewList = new Telerik.WinControls.UI.RadTreeView();
            this.radPanelChange = new Telerik.WinControls.UI.RadPanel();
            this.radTBNameRu = new Telerik.WinControls.UI.RadTextBox();
            this.radTBNameEn = new Telerik.WinControls.UI.RadTextBox();
            this.radTBNameUa = new Telerik.WinControls.UI.RadTextBox();
            this.radTBCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabelNameRu = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameEn = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameUa = new Telerik.WinControls.UI.RadLabel();
            this.radLabelCode = new Telerik.WinControls.UI.RadLabel();
            this.radBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.radBtnSave = new Telerik.WinControls.UI.RadButton();
            this.radTxtBoxFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radTxtBoxSearchData = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelChange)).BeginInit();
            this.radPanelChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTBNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTBNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTBNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTBCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtBoxFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtBoxSearchData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Location = new System.Drawing.Point(205, 93);
            this.radGridView1.Margin = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewMaskBoxColumn1.HeaderText = "Код";
            gridViewMaskBoxColumn1.Mask = "000-000-111";
            gridViewMaskBoxColumn1.Name = "column1";
            gridViewMaskBoxColumn1.Width = 815;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewMaskBoxColumn1});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(836, 311);
            this.radGridView1.TabIndex = 0;
            // 
            // radBtnAdd
            // 
            this.radBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnAdd.Location = new System.Drawing.Point(205, 408);
            this.radBtnAdd.Name = "radBtnAdd";
            this.radBtnAdd.Size = new System.Drawing.Size(110, 24);
            this.radBtnAdd.TabIndex = 1;
            this.radBtnAdd.Text = "Додати";
            this.radBtnAdd.Click += new System.EventHandler(this.radBtnAdd_Click);
            // 
            // radBtnRemove
            // 
            this.radBtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnRemove.Location = new System.Drawing.Point(335, 408);
            this.radBtnRemove.Name = "radBtnRemove";
            this.radBtnRemove.Size = new System.Drawing.Size(110, 24);
            this.radBtnRemove.TabIndex = 2;
            this.radBtnRemove.Text = "Видалити";
            this.radBtnRemove.Click += new System.EventHandler(this.radBtnRemove_Click);
            // 
            // radTreeViewList
            // 
            this.radTreeViewList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radTreeViewList.Location = new System.Drawing.Point(8, 64);
            this.radTreeViewList.Name = "radTreeViewList";
            this.radTreeViewList.Size = new System.Drawing.Size(187, 559);
            this.radTreeViewList.SpacingBetweenNodes = -1;
            this.radTreeViewList.TabIndex = 3;
            // 
            // radPanelChange
            // 
            this.radPanelChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanelChange.Controls.Add(this.radTBNameRu);
            this.radPanelChange.Controls.Add(this.radTBNameEn);
            this.radPanelChange.Controls.Add(this.radTBNameUa);
            this.radPanelChange.Controls.Add(this.radTBCode);
            this.radPanelChange.Controls.Add(this.radLabelNameRu);
            this.radPanelChange.Controls.Add(this.radLabelNameEn);
            this.radPanelChange.Controls.Add(this.radLabelNameUa);
            this.radPanelChange.Controls.Add(this.radLabelCode);
            this.radPanelChange.Controls.Add(this.radBtnCancel);
            this.radPanelChange.Controls.Add(this.radBtnSave);
            this.radPanelChange.Location = new System.Drawing.Point(205, 445);
            this.radPanelChange.Name = "radPanelChange";
            this.radPanelChange.Size = new System.Drawing.Size(836, 178);
            this.radPanelChange.TabIndex = 4;
            this.radPanelChange.Text = "Дані довідника";
            this.radPanelChange.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanelChange.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.radPanelChange.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radTBNameRu
            // 
            this.radTBNameRu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTBNameRu.Location = new System.Drawing.Point(162, 109);
            this.radTBNameRu.Name = "radTBNameRu";
            this.radTBNameRu.Size = new System.Drawing.Size(656, 20);
            this.radTBNameRu.TabIndex = 9;
            // 
            // radTBNameEn
            // 
            this.radTBNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTBNameEn.Location = new System.Drawing.Point(162, 82);
            this.radTBNameEn.Name = "radTBNameEn";
            this.radTBNameEn.Size = new System.Drawing.Size(656, 20);
            this.radTBNameEn.TabIndex = 8;
            // 
            // radTBNameUa
            // 
            this.radTBNameUa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTBNameUa.Location = new System.Drawing.Point(162, 55);
            this.radTBNameUa.Name = "radTBNameUa";
            this.radTBNameUa.Size = new System.Drawing.Size(656, 20);
            this.radTBNameUa.TabIndex = 7;
            // 
            // radTBCode
            // 
            this.radTBCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTBCode.Location = new System.Drawing.Point(162, 28);
            this.radTBCode.Name = "radTBCode";
            this.radTBCode.Size = new System.Drawing.Size(656, 20);
            this.radTBCode.TabIndex = 6;
            // 
            // radLabelNameRu
            // 
            this.radLabelNameRu.AutoSize = false;
            this.radLabelNameRu.BackColor = System.Drawing.Color.Transparent;
            this.radLabelNameRu.Location = new System.Drawing.Point(55, 103);
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
            this.radLabelNameEn.Location = new System.Drawing.Point(55, 78);
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
            this.radLabelNameUa.Location = new System.Drawing.Point(55, 53);
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
            // radBtnCancel
            // 
            this.radBtnCancel.Location = new System.Drawing.Point(278, 135);
            this.radBtnCancel.Name = "radBtnCancel";
            this.radBtnCancel.Size = new System.Drawing.Size(110, 24);
            this.radBtnCancel.TabIndex = 1;
            this.radBtnCancel.Text = "Відміна";
            this.radBtnCancel.Click += new System.EventHandler(this.radBtnCancel_Click);
            // 
            // radBtnSave
            // 
            this.radBtnSave.Location = new System.Drawing.Point(162, 135);
            this.radBtnSave.Name = "radBtnSave";
            this.radBtnSave.Size = new System.Drawing.Size(110, 24);
            this.radBtnSave.TabIndex = 0;
            this.radBtnSave.Text = "Зберегти";
            this.radBtnSave.Click += new System.EventHandler(this.radBtnSave_Click);
            // 
            // radTxtBoxFilter
            // 
            this.radTxtBoxFilter.Location = new System.Drawing.Point(8, 38);
            this.radTxtBoxFilter.Name = "radTxtBoxFilter";
            this.radTxtBoxFilter.NullText = "Фільтр";
            this.radTxtBoxFilter.Size = new System.Drawing.Size(187, 20);
            this.radTxtBoxFilter.TabIndex = 5;
            this.radTxtBoxFilter.TextChanged += new System.EventHandler(this.radTxtBoxFilter_TextChanged);
            // 
            // radTxtBoxSearchData
            // 
            this.radTxtBoxSearchData.Location = new System.Drawing.Point(205, 64);
            this.radTxtBoxSearchData.Name = "radTxtBoxSearchData";
            this.radTxtBoxSearchData.NullText = "Пошук";
            this.radTxtBoxSearchData.Size = new System.Drawing.Size(430, 20);
            this.radTxtBoxSearchData.TabIndex = 6;
            this.radTxtBoxSearchData.TextChanged += new System.EventHandler(this.radTxtBoxSearchData_TextChanged);
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 635);
            this.Controls.Add(this.radTxtBoxSearchData);
            this.Controls.Add(this.radTxtBoxFilter);
            this.Controls.Add(this.radPanelChange);
            this.Controls.Add(this.radTreeViewList);
            this.Controls.Add(this.radBtnRemove);
            this.Controls.Add(this.radBtnAdd);
            this.Controls.Add(this.radGridView1);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelChange)).EndInit();
            this.radPanelChange.ResumeLayout(false);
            this.radPanelChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTBNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTBNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTBNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTBCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtBoxFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtBoxSearchData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton radBtnAdd;
        private Telerik.WinControls.UI.RadButton radBtnRemove;
        private Telerik.WinControls.UI.RadTreeView radTreeViewList;
        private Telerik.WinControls.UI.RadPanel radPanelChange;
        private Telerik.WinControls.UI.RadButton radBtnSave;
        private Telerik.WinControls.UI.RadButton radBtnCancel;
        private Telerik.WinControls.UI.RadTextBox radTBCode;
        private Telerik.WinControls.UI.RadLabel radLabelNameRu;
        private Telerik.WinControls.UI.RadLabel radLabelNameEn;
        private Telerik.WinControls.UI.RadLabel radLabelNameUa;
        private Telerik.WinControls.UI.RadLabel radLabelCode;
        private Telerik.WinControls.UI.RadTextBox radTBNameRu;
        private Telerik.WinControls.UI.RadTextBox radTBNameEn;
        private Telerik.WinControls.UI.RadTextBox radTBNameUa;
        private RadTextBox radTxtBoxFilter;
        private RadTextBox radTxtBoxSearchData;
    }
}