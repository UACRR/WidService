namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    partial class PremisesControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rLblPremises = new Telerik.WinControls.UI.RadLabel();
            this.gvPremises = new Telerik.WinControls.UI.RadGridView();
            this.bsClnPlaceHoll = new System.Windows.Forms.BindingSource(this.components);
            this.rBtnAddPremises = new Telerik.WinControls.UI.RadButton();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.btnEditPremises = new Telerik.WinControls.UI.RadButton();
            this.btnDeletePremises = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rLblPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPremises.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePremises)).BeginInit();
            this.SuspendLayout();
            // 
            // rLblPremises
            // 
            this.rLblPremises.AutoSize = false;
            this.rLblPremises.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblPremises.Location = new System.Drawing.Point(3, 3);
            this.rLblPremises.Name = "rLblPremises";
            this.rLblPremises.Size = new System.Drawing.Size(205, 26);
            this.rLblPremises.TabIndex = 0;
            this.rLblPremises.Text = "Приміщення бізнес-точки";
            this.rLblPremises.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.rLblPremises.ThemeName = "Office2013Light";
            // 
            // gvPremises
            // 
            this.gvPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPremises.Location = new System.Drawing.Point(3, 35);
            // 
            // 
            // 
            this.gvPremises.MasterTemplate.AllowAddNewRow = false;
            this.gvPremises.MasterTemplate.AllowColumnReorder = false;
            this.gvPremises.MasterTemplate.AllowDragToGroup = false;
            this.gvPremises.MasterTemplate.AllowEditRow = false;
            this.gvPremises.MasterTemplate.AutoGenerateColumns = false;
            this.gvPremises.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "HollId";
            gridViewTextBoxColumn1.HeaderText = "IdItem";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "HollId";
            gridViewTextBoxColumn1.Width = 45;
            gridViewTextBoxColumn2.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn2.FieldName = "PlaceId";
            gridViewTextBoxColumn2.HeaderText = "PlaceId";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "PlaceId";
            gridViewTextBoxColumn2.Width = 46;
            gridViewTextBoxColumn3.FieldName = "HollName";
            gridViewTextBoxColumn3.HeaderText = "Тип приміщення";
            gridViewTextBoxColumn3.Name = "HollName";
            gridViewTextBoxColumn3.Width = 319;
            gridViewTextBoxColumn4.FieldName = "ValueAdd";
            gridViewTextBoxColumn4.HeaderText = "Додатковий параметр";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.MinWidth = 200;
            gridViewTextBoxColumn4.Name = "ValueAdd";
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "ValuePlace";
            gridViewTextBoxColumn5.HeaderText = "Місць";
            gridViewTextBoxColumn5.MinWidth = 100;
            gridViewTextBoxColumn5.Name = "ValuePlace";
            gridViewTextBoxColumn5.Width = 100;
            this.gvPremises.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvPremises.MasterTemplate.DataSource = this.bsClnPlaceHoll;
            this.gvPremises.MasterTemplate.EnableGrouping = false;
            this.gvPremises.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPremises.Name = "gvPremises";
            this.gvPremises.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPremises.ReadOnly = true;
            this.gvPremises.Size = new System.Drawing.Size(444, 132);
            this.gvPremises.TabIndex = 0;
            this.gvPremises.ThemeName = "Office2013Light";
            this.gvPremises.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvPremises_CellDoubleClick);
            // 
            // bsClnPlaceHoll
            // 
            this.bsClnPlaceHoll.DataSource = typeof(ipsFormsDesign.Model.ClnPlaceHoll);
            this.bsClnPlaceHoll.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsClnPlaceHoll_ListChanged);
            // 
            // rBtnAddPremises
            // 
            this.rBtnAddPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnAddPremises.Location = new System.Drawing.Point(3, 173);
            this.rBtnAddPremises.Name = "rBtnAddPremises";
            this.rBtnAddPremises.Size = new System.Drawing.Size(138, 24);
            this.rBtnAddPremises.TabIndex = 1;
            this.rBtnAddPremises.Text = "Додати приміщення";
            this.rBtnAddPremises.ThemeName = "Office2013Light";
            this.rBtnAddPremises.Click += new System.EventHandler(this.btnAddPremises_Click);
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(214, 9);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(233, 20);
            this.radSeparator1.TabIndex = 0;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // btnEditPremises
            // 
            this.btnEditPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditPremises.Location = new System.Drawing.Point(147, 173);
            this.btnEditPremises.Name = "btnEditPremises";
            this.btnEditPremises.Size = new System.Drawing.Size(144, 24);
            this.btnEditPremises.TabIndex = 2;
            this.btnEditPremises.Text = "Редагувати приміщення";
            this.btnEditPremises.ThemeName = "Office2013Light";
            this.btnEditPremises.Click += new System.EventHandler(this.btnEditPremises_Click);
            // 
            // btnDeletePremises
            // 
            this.btnDeletePremises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePremises.Location = new System.Drawing.Point(307, 173);
            this.btnDeletePremises.Name = "btnDeletePremises";
            this.btnDeletePremises.Size = new System.Drawing.Size(140, 24);
            this.btnDeletePremises.TabIndex = 3;
            this.btnDeletePremises.Text = "Видалити приміщення";
            this.btnDeletePremises.ThemeName = "Office2013Light";
            this.btnDeletePremises.Click += new System.EventHandler(this.btnDeletePremises_Click);
            // 
            // PremisesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeletePremises);
            this.Controls.Add(this.btnEditPremises);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.rBtnAddPremises);
            this.Controls.Add(this.gvPremises);
            this.Controls.Add(this.rLblPremises);
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "PremisesControl";
            this.Size = new System.Drawing.Size(450, 200);
            ((System.ComponentModel.ISupportInitialize)(this.rLblPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPremises.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePremises)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel rLblPremises;
        private Telerik.WinControls.UI.RadGridView gvPremises;
        private Telerik.WinControls.UI.RadButton rBtnAddPremises;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadButton btnEditPremises;
        private Telerik.WinControls.UI.RadButton btnDeletePremises;
        private System.Windows.Forms.BindingSource bsClnPlaceHoll;
    }
}
