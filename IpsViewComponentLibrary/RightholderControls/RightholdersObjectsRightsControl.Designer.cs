namespace IpsViewComponentLibrary.RightholderControls
{
    partial class RightholdersObjectsRightsControl
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlRightholderSelector = new IpsViewComponentLibrary.RightholderControls.RightholderSelectorControl();
            this.gvRightholdersObjectsRights = new Telerik.WinControls.UI.RadGridView();
            this.objectRightForRightholderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlRightholderSelector
            // 
            this.ctrlRightholderSelector.Location = new System.Drawing.Point(3, 3);
            this.ctrlRightholderSelector.Name = "ctrlRightholderSelector";
            this.ctrlRightholderSelector.Rightholder = null;
            this.ctrlRightholderSelector.Size = new System.Drawing.Size(889, 29);
            this.ctrlRightholderSelector.TabIndex = 0;
            this.ctrlRightholderSelector.RightholderChanged += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelector_RightholderChanged);
            this.ctrlRightholderSelector.ShowAnketaCommandExecuted += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelector_ShowAnketaCommandExecuted);
            // 
            // gvRightholdersObjectsRights
            // 
            this.gvRightholdersObjectsRights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightholdersObjectsRights.Location = new System.Drawing.Point(3, 38);
            // 
            // 
            // 
            this.gvRightholdersObjectsRights.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AllowDeleteRow = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AllowEditRow = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "CustId";
            gridViewDecimalColumn1.HeaderText = "CustId";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "CustId";
            gridViewDecimalColumn1.Width = 32;
            gridViewTextBoxColumn1.FieldName = "NameClient";
            gridViewTextBoxColumn1.HeaderText = "NameClient";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "NameClient";
            gridViewTextBoxColumn1.Width = 100;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "ObjId";
            gridViewDecimalColumn2.HeaderText = "Шифр твору";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "ObjId";
            gridViewDecimalColumn2.Width = 66;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Назва твору";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 134;
            gridViewTextBoxColumn3.FieldName = "Category";
            gridViewTextBoxColumn3.HeaderText = "В/М";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "Category";
            gridViewTextBoxColumn3.Width = 46;
            gridViewTextBoxColumn4.FieldName = "GenreName";
            gridViewTextBoxColumn4.HeaderText = "Жанр";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "GenreName";
            gridViewTextBoxColumn4.Width = 88;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn5.FieldName = "Duration";
            gridViewTextBoxColumn5.HeaderText = "Час";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Duration";
            gridViewTextBoxColumn5.Width = 66;
            gridViewTextBoxColumn6.FieldName = "RoleName";
            gridViewTextBoxColumn6.HeaderText = "Творчий профіль";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "RoleName";
            gridViewTextBoxColumn6.Width = 86;
            gridViewTextBoxColumn7.FieldName = "SpecName";
            gridViewTextBoxColumn7.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "SpecName";
            gridViewTextBoxColumn7.Width = 79;
            gridViewDecimalColumn3.DataType = typeof(double);
            gridViewDecimalColumn3.FieldName = "RateTotal";
            gridViewDecimalColumn3.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "RateTotal";
            gridViewDecimalColumn3.Width = 66;
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<double>);
            gridViewDecimalColumn4.FieldName = "RateRh";
            gridViewDecimalColumn4.HeaderText = "Його % володіння";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "RateRh";
            gridViewDecimalColumn4.Width = 66;
            gridViewTextBoxColumn8.FieldName = "Performer";
            gridViewTextBoxColumn8.HeaderText = "Виконавець";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "Performer";
            gridViewTextBoxColumn8.Width = 91;
            gridViewDecimalColumn5.DataType = typeof(double);
            gridViewDecimalColumn5.FieldName = "Profit";
            gridViewDecimalColumn5.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "Profit";
            gridViewDecimalColumn5.Width = 76;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Редагувати";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "EditColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            this.gvRightholdersObjectsRights.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn8,
            gridViewDecimalColumn5,
            gridViewCommandColumn1});
            this.gvRightholdersObjectsRights.MasterTemplate.DataSource = this.objectRightForRightholderBindingSource;
            this.gvRightholdersObjectsRights.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersObjectsRights.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvRightholdersObjectsRights.Name = "gvRightholdersObjectsRights";
            this.gvRightholdersObjectsRights.ShowGroupPanel = false;
            this.gvRightholdersObjectsRights.Size = new System.Drawing.Size(885, 493);
            this.gvRightholdersObjectsRights.TabIndex = 2;
            this.gvRightholdersObjectsRights.ThemeName = "Office2013Light";
            this.gvRightholdersObjectsRights.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersObjectsRights_CellDoubleClick);
            this.gvRightholdersObjectsRights.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRightholdersObjectsRights_CommandCellClick);
            this.gvRightholdersObjectsRights.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvRightholdersObjectsRights_ToolTipTextNeeded);
            // 
            // objectRightForRightholderBindingSource
            // 
            this.objectRightForRightholderBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectRightForRightholder);
            // 
            // RightholdersObjectsRightsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvRightholdersObjectsRights);
            this.Controls.Add(this.ctrlRightholderSelector);
            this.Name = "RightholdersObjectsRightsControl";
            this.Size = new System.Drawing.Size(891, 534);
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private RightholderSelectorControl ctrlRightholderSelector;
        private Telerik.WinControls.UI.RadGridView gvRightholdersObjectsRights;
        private System.Windows.Forms.BindingSource objectRightForRightholderBindingSource;
    }
}
