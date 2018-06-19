namespace IpsViewComponentLibrary
{
    partial class IpsPremisesTypeControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rLblPremises = new Telerik.WinControls.UI.RadLabel();
            this.rGridViewPremises = new Telerik.WinControls.UI.RadGridView();
            this.rBtnAddPremises = new Telerik.WinControls.UI.RadButton();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.rBtnEditPremises = new Telerik.WinControls.UI.RadButton();
            this.radBtnDeletePremises = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rLblPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnEditPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnDeletePremises)).BeginInit();
            this.SuspendLayout();
            // 
            // rLblPremises
            // 
            this.rLblPremises.AutoSize = false;
            this.rLblPremises.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblPremises.Location = new System.Drawing.Point(3, 3);
            this.rLblPremises.Name = "rLblPremises";
            this.rLblPremises.Size = new System.Drawing.Size(170, 26);
            this.rLblPremises.TabIndex = 0;
            this.rLblPremises.Text = "Приміщення закладу";
            this.rLblPremises.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // rGridViewPremises
            // 
            this.rGridViewPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridViewPremises.Location = new System.Drawing.Point(17, 35);
            // 
            // 
            // 
            this.rGridViewPremises.MasterTemplate.AllowAddNewRow = false;
            this.rGridViewPremises.MasterTemplate.AllowColumnReorder = false;
            this.rGridViewPremises.MasterTemplate.AllowDragToGroup = false;
            this.rGridViewPremises.MasterTemplate.AllowEditRow = false;
            this.rGridViewPremises.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "IdItem";
            gridViewTextBoxColumn1.HeaderText = "IdItem";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "IdItem";
            gridViewTextBoxColumn1.Width = 45;
            gridViewTextBoxColumn2.FieldName = "TypePremisesName";
            gridViewTextBoxColumn2.HeaderText = "Тип приміщення";
            gridViewTextBoxColumn2.Name = "TypePremisesName";
            gridViewTextBoxColumn2.Width = 377;
            gridViewTextBoxColumn3.FieldName = "CountPlace";
            gridViewTextBoxColumn3.HeaderText = "Місць";
            gridViewTextBoxColumn3.Name = "CountPlace";
            gridViewTextBoxColumn3.Width = 76;
            gridViewTextBoxColumn4.FieldName = "Meterage";
            gridViewTextBoxColumn4.HeaderText = "Метраж";
            gridViewTextBoxColumn4.Name = "Meterage";
            gridViewTextBoxColumn4.UseDataTypeConverterWhenSorting = true;
            gridViewTextBoxColumn4.Width = 76;
            this.rGridViewPremises.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rGridViewPremises.MasterTemplate.EnableGrouping = false;
            this.rGridViewPremises.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rGridViewPremises.Name = "rGridViewPremises";
            this.rGridViewPremises.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.rGridViewPremises.ReadOnly = true;
            this.rGridViewPremises.Size = new System.Drawing.Size(548, 185);
            this.rGridViewPremises.TabIndex = 0;
            this.rGridViewPremises.ThemeName = "Office2007Silver";
            // 
            // rBtnAddPremises
            // 
            this.rBtnAddPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnAddPremises.Location = new System.Drawing.Point(17, 226);
            this.rBtnAddPremises.Name = "rBtnAddPremises";
            this.rBtnAddPremises.Size = new System.Drawing.Size(138, 24);
            this.rBtnAddPremises.TabIndex = 1;
            this.rBtnAddPremises.Text = "Додати приміщення";
            this.rBtnAddPremises.ThemeName = "Office2007Silver";
            this.rBtnAddPremises.Click += new System.EventHandler(this.rBtnAddPremises_Click);
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(179, 9);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(386, 20);
            this.radSeparator1.TabIndex = 0;
            this.radSeparator1.ThemeName = "Office2007Silver";
            // 
            // rBtnEditPremises
            // 
            this.rBtnEditPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnEditPremises.Location = new System.Drawing.Point(162, 226);
            this.rBtnEditPremises.Name = "rBtnEditPremises";
            this.rBtnEditPremises.Size = new System.Drawing.Size(138, 24);
            this.rBtnEditPremises.TabIndex = 2;
            this.rBtnEditPremises.Text = "Редагувати приміщення";
            this.rBtnEditPremises.ThemeName = "Office2007Silver";
            this.rBtnEditPremises.Click += new System.EventHandler(this.rBtnEditPremises_Click);
            // 
            // radBtnDeletePremises
            // 
            this.radBtnDeletePremises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnDeletePremises.Location = new System.Drawing.Point(440, 226);
            this.radBtnDeletePremises.Name = "radBtnDeletePremises";
            this.radBtnDeletePremises.Size = new System.Drawing.Size(125, 24);
            this.radBtnDeletePremises.TabIndex = 3;
            this.radBtnDeletePremises.Text = "Видалити приміщення";
            this.radBtnDeletePremises.ThemeName = "Office2007Silver";
            this.radBtnDeletePremises.Click += new System.EventHandler(this.radBtnDeletePremises_Click);
            // 
            // IpsPremisesTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radBtnDeletePremises);
            this.Controls.Add(this.rBtnEditPremises);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.rBtnAddPremises);
            this.Controls.Add(this.rGridViewPremises);
            this.Controls.Add(this.rLblPremises);
            this.MinimumSize = new System.Drawing.Size(450, 253);
            this.Name = "IpsPremisesTypeControl";
            this.Size = new System.Drawing.Size(568, 253);
            ((System.ComponentModel.ISupportInitialize)(this.rLblPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnEditPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnDeletePremises)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel rLblPremises;
        private Telerik.WinControls.UI.RadGridView rGridViewPremises;
        private Telerik.WinControls.UI.RadButton rBtnAddPremises;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadButton rBtnEditPremises;
        private Telerik.WinControls.UI.RadButton radBtnDeletePremises;
    }
}
