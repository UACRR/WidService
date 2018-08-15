namespace IpsViewComponentLibrary.ObjectRightControls
{
    partial class ObjectRightListControl
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.txtSearchObject = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.gvObjectsRightsList = new Telerik.WinControls.UI.RadGridView();
            this.objectRightMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdateList = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchObject
            // 
            this.txtSearchObject.Location = new System.Drawing.Point(199, 3);
            this.txtSearchObject.Name = "txtSearchObject";
            this.txtSearchObject.Size = new System.Drawing.Size(497, 21);
            this.txtSearchObject.TabIndex = 24;
            this.txtSearchObject.ThemeName = "Office2013Light";
            this.txtSearchObject.TextChanged += new System.EventHandler(this.txtSearchObject_TextChanged);
            // 
            // radLabel23
            // 
            this.radLabel23.Location = new System.Drawing.Point(144, 3);
            this.radLabel23.Name = "radLabel23";
            this.radLabel23.Size = new System.Drawing.Size(47, 19);
            this.radLabel23.TabIndex = 23;
            this.radLabel23.Text = "Пошук:";
            this.radLabel23.ThemeName = "Office2013Light";
            // 
            // gvObjectsRightsList
            // 
            this.gvObjectsRightsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvObjectsRightsList.EnableCustomFiltering = true;
            this.gvObjectsRightsList.Location = new System.Drawing.Point(3, 30);
            // 
            // 
            // 
            this.gvObjectsRightsList.MasterTemplate.AllowAddNewRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowDeleteRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowEditRow = false;
            this.gvObjectsRightsList.MasterTemplate.AutoGenerateColumns = false;
            this.gvObjectsRightsList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn5.DataType = typeof(int);
            gridViewDecimalColumn5.FieldName = "ObjId";
            gridViewDecimalColumn5.HeaderText = "Шифр твору";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "ObjId";
            gridViewDecimalColumn5.Width = 64;
            gridViewTextBoxColumn6.FieldName = "Name";
            gridViewTextBoxColumn6.HeaderText = "Назва твору";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "Name";
            gridViewTextBoxColumn6.Width = 140;
            gridViewTextBoxColumn7.FieldName = "Category";
            gridViewTextBoxColumn7.HeaderText = "В/М";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "Category";
            gridViewTextBoxColumn7.Width = 35;
            gridViewTextBoxColumn8.FieldName = "GenreName";
            gridViewTextBoxColumn8.HeaderText = "Жанр";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "GenreName";
            gridViewTextBoxColumn8.Width = 71;
            gridViewDecimalColumn6.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewDecimalColumn6.FieldName = "Duration";
            gridViewDecimalColumn6.HeaderText = "Час";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.Name = "Duration";
            gridViewDecimalColumn6.Width = 51;
            gridViewTextBoxColumn9.FieldName = "SpecName";
            gridViewTextBoxColumn9.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "SpecName";
            gridViewTextBoxColumn9.Width = 71;
            gridViewDecimalColumn7.DataType = typeof(double);
            gridViewDecimalColumn7.FieldName = "RateTotal";
            gridViewDecimalColumn7.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.Name = "RateTotal";
            gridViewDecimalColumn7.Width = 52;
            gridViewTextBoxColumn10.FieldName = "Performer";
            gridViewTextBoxColumn10.HeaderText = "Виконавець";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.Name = "Performer";
            gridViewTextBoxColumn10.Width = 71;
            gridViewDecimalColumn8.DataType = typeof(double);
            gridViewDecimalColumn8.FieldName = "Profit";
            gridViewDecimalColumn8.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.Name = "Profit";
            gridViewDecimalColumn8.Width = 64;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Редагувати";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "EditColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 81;
            this.gvObjectsRightsList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewDecimalColumn6,
            gridViewTextBoxColumn9,
            gridViewDecimalColumn7,
            gridViewTextBoxColumn10,
            gridViewDecimalColumn8,
            gridViewCommandColumn2});
            this.gvObjectsRightsList.MasterTemplate.DataSource = this.objectRightMainViewBindingSource;
            this.gvObjectsRightsList.MasterTemplate.EnableCustomFiltering = true;
            this.gvObjectsRightsList.MasterTemplate.EnableFiltering = true;
            this.gvObjectsRightsList.MasterTemplate.ShowFilteringRow = false;
            this.gvObjectsRightsList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvObjectsRightsList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvObjectsRightsList.Name = "gvObjectsRightsList";
            this.gvObjectsRightsList.ShowGroupPanel = false;
            this.gvObjectsRightsList.Size = new System.Drawing.Size(693, 346);
            this.gvObjectsRightsList.TabIndex = 22;
            this.gvObjectsRightsList.ThemeName = "Office2013Light";
            this.gvObjectsRightsList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvObjectsRightsList_CellDoubleClick);
            this.gvObjectsRightsList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvObjectsRightsList_CommandCellClick);
            this.gvObjectsRightsList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvObjectsRightsList_CustomFiltering);
            // 
            // objectRightMainViewBindingSource
            // 
            this.objectRightMainViewBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectRightMainView);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Location = new System.Drawing.Point(3, 3);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(110, 21);
            this.btnUpdateList.TabIndex = 25;
            this.btnUpdateList.Text = "Оновити";
            this.btnUpdateList.ThemeName = "Office2013Light";
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // ObjectRightListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.txtSearchObject);
            this.Controls.Add(this.radLabel23);
            this.Controls.Add(this.gvObjectsRightsList);
            this.Name = "ObjectRightListControl";
            this.Size = new System.Drawing.Size(699, 379);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightMainViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtSearchObject;
        private Telerik.WinControls.UI.RadLabel radLabel23;
        private Telerik.WinControls.UI.RadGridView gvObjectsRightsList;
        private System.Windows.Forms.BindingSource objectRightMainViewBindingSource;
        private Telerik.WinControls.UI.RadButton btnUpdateList;
    }
}
