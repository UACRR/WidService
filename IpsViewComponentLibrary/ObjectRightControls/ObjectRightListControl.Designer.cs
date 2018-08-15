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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn13 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn14 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn15 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn16 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.txtSearchObject = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.gvObjectsRightsList = new Telerik.WinControls.UI.RadGridView();
            this.objectRightMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnUpdateList = new Telerik.WinControls.UI.RadButton();
            this.ddlState = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlCategory = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlGenre = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectsRightsList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGenre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
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
            this.gvObjectsRightsList.Location = new System.Drawing.Point(3, 57);
            // 
            // 
            // 
            this.gvObjectsRightsList.MasterTemplate.AllowAddNewRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowDeleteRow = false;
            this.gvObjectsRightsList.MasterTemplate.AllowEditRow = false;
            this.gvObjectsRightsList.MasterTemplate.AutoGenerateColumns = false;
            this.gvObjectsRightsList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn13.DataType = typeof(int);
            gridViewDecimalColumn13.FieldName = "ObjId";
            gridViewDecimalColumn13.HeaderText = "Шифр твору";
            gridViewDecimalColumn13.IsAutoGenerated = true;
            gridViewDecimalColumn13.Name = "ObjId";
            gridViewDecimalColumn13.Width = 64;
            gridViewTextBoxColumn16.FieldName = "Name";
            gridViewTextBoxColumn16.HeaderText = "Назва твору";
            gridViewTextBoxColumn16.IsAutoGenerated = true;
            gridViewTextBoxColumn16.Name = "Name";
            gridViewTextBoxColumn16.Width = 140;
            gridViewTextBoxColumn17.FieldName = "Category";
            gridViewTextBoxColumn17.HeaderText = "В/М";
            gridViewTextBoxColumn17.IsAutoGenerated = true;
            gridViewTextBoxColumn17.Name = "Category";
            gridViewTextBoxColumn17.Width = 35;
            gridViewTextBoxColumn18.FieldName = "GenreName";
            gridViewTextBoxColumn18.HeaderText = "Жанр";
            gridViewTextBoxColumn18.IsAutoGenerated = true;
            gridViewTextBoxColumn18.Name = "GenreName";
            gridViewTextBoxColumn18.Width = 71;
            gridViewDecimalColumn14.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewDecimalColumn14.FieldName = "Duration";
            gridViewDecimalColumn14.HeaderText = "Час";
            gridViewDecimalColumn14.IsAutoGenerated = true;
            gridViewDecimalColumn14.Name = "Duration";
            gridViewDecimalColumn14.Width = 51;
            gridViewTextBoxColumn19.FieldName = "SpecName";
            gridViewTextBoxColumn19.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn19.IsAutoGenerated = true;
            gridViewTextBoxColumn19.Name = "SpecName";
            gridViewTextBoxColumn19.Width = 71;
            gridViewDecimalColumn15.DataType = typeof(double);
            gridViewDecimalColumn15.FieldName = "RateTotal";
            gridViewDecimalColumn15.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn15.IsAutoGenerated = true;
            gridViewDecimalColumn15.Name = "RateTotal";
            gridViewDecimalColumn15.Width = 52;
            gridViewTextBoxColumn20.FieldName = "Performer";
            gridViewTextBoxColumn20.HeaderText = "Виконавець";
            gridViewTextBoxColumn20.IsAutoGenerated = true;
            gridViewTextBoxColumn20.Name = "Performer";
            gridViewTextBoxColumn20.Width = 71;
            gridViewDecimalColumn16.DataType = typeof(double);
            gridViewDecimalColumn16.FieldName = "Profit";
            gridViewDecimalColumn16.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn16.IsAutoGenerated = true;
            gridViewDecimalColumn16.Name = "Profit";
            gridViewDecimalColumn16.Width = 64;
            gridViewCommandColumn4.AllowResize = false;
            gridViewCommandColumn4.DefaultText = "Редагувати";
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Name = "EditColumn";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.UseDefaultText = true;
            gridViewCommandColumn4.Width = 81;
            this.gvObjectsRightsList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn13,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewDecimalColumn14,
            gridViewTextBoxColumn19,
            gridViewDecimalColumn15,
            gridViewTextBoxColumn20,
            gridViewDecimalColumn16,
            gridViewCommandColumn4});
            this.gvObjectsRightsList.MasterTemplate.DataSource = this.objectRightMainViewBindingSource;
            this.gvObjectsRightsList.MasterTemplate.EnableCustomFiltering = true;
            this.gvObjectsRightsList.MasterTemplate.EnableFiltering = true;
            this.gvObjectsRightsList.MasterTemplate.ShowFilteringRow = false;
            this.gvObjectsRightsList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvObjectsRightsList.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.gvObjectsRightsList.Name = "gvObjectsRightsList";
            this.gvObjectsRightsList.ShowGroupPanel = false;
            this.gvObjectsRightsList.Size = new System.Drawing.Size(693, 319);
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
            // ddlState
            // 
            this.ddlState.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlState.Location = new System.Drawing.Point(199, 30);
            this.ddlState.Name = "ddlState";
            this.ddlState.Size = new System.Drawing.Size(125, 21);
            this.ddlState.TabIndex = 26;
            this.ddlState.ThemeName = "Office2013Light";
            this.ddlState.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlState_SelectedIndexChanged);
            // 
            // ddlCategory
            // 
            this.ddlCategory.Location = new System.Drawing.Point(399, 30);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(125, 21);
            this.ddlCategory.TabIndex = 27;
            this.ddlCategory.ThemeName = "Office2013Light";
            // 
            // ddlGenre
            // 
            this.ddlGenre.Location = new System.Drawing.Point(577, 30);
            this.ddlGenre.Name = "ddlGenre";
            this.ddlGenre.Size = new System.Drawing.Size(119, 21);
            this.ddlGenre.TabIndex = 28;
            this.ddlGenre.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(148, 30);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(35, 19);
            this.radLabel1.TabIndex = 29;
            this.radLabel1.Text = "Стан:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(330, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(63, 19);
            this.radLabel2.TabIndex = 30;
            this.radLabel2.Text = "Категорія:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(530, 30);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(41, 19);
            this.radLabel3.TabIndex = 30;
            this.radLabel3.Text = "Жанр:";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // ObjectRightListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlGenre);
            this.Controls.Add(this.ddlCategory);
            this.Controls.Add(this.ddlState);
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
            ((System.ComponentModel.ISupportInitialize)(this.ddlState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGenre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtSearchObject;
        private Telerik.WinControls.UI.RadLabel radLabel23;
        private Telerik.WinControls.UI.RadGridView gvObjectsRightsList;
        private System.Windows.Forms.BindingSource objectRightMainViewBindingSource;
        private Telerik.WinControls.UI.RadButton btnUpdateList;
        private Telerik.WinControls.UI.RadDropDownList ddlState;
        private Telerik.WinControls.UI.RadDropDownList ddlCategory;
        private Telerik.WinControls.UI.RadDropDownList ddlGenre;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
