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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
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
            this.gvRightholdersObjectsRights = new Telerik.WinControls.UI.RadGridView();
            this.objectRightForRightholderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.ctrlRightholderSelector = new IpsViewComponentLibrary.RightholderControls.RightholderSelectorControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvRightholdersObjectsRights
            // 
            this.gvRightholdersObjectsRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRightholdersObjectsRights.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvRightholdersObjectsRights.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = true;
            gridViewCheckBoxColumn1.HeaderText = "";
            gridViewCheckBoxColumn1.MaxWidth = 30;
            gridViewCheckBoxColumn1.MinWidth = 30;
            gridViewCheckBoxColumn1.Name = "IsSelected";
            gridViewCheckBoxColumn1.Width = 30;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "CustId";
            gridViewDecimalColumn1.HeaderText = "CustId";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "CustId";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewDecimalColumn1.Width = 32;
            gridViewTextBoxColumn1.FieldName = "NameClient";
            gridViewTextBoxColumn1.HeaderText = "NameClient";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "NameClient";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 100;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "ObjId";
            gridViewDecimalColumn2.HeaderText = "Шифр твору";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "ObjId";
            gridViewDecimalColumn2.ReadOnly = true;
            gridViewDecimalColumn2.Width = 62;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Назва твору";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 127;
            gridViewTextBoxColumn3.FieldName = "Category";
            gridViewTextBoxColumn3.HeaderText = "В/М";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "Category";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 44;
            gridViewTextBoxColumn4.FieldName = "GenreName";
            gridViewTextBoxColumn4.HeaderText = "Жанр";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "GenreName";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 83;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn5.FieldName = "Duration";
            gridViewTextBoxColumn5.HeaderText = "Час";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Duration";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 62;
            gridViewTextBoxColumn6.FieldName = "RoleName";
            gridViewTextBoxColumn6.HeaderText = "Творчий профіль";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "RoleName";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 82;
            gridViewTextBoxColumn7.FieldName = "SpecName";
            gridViewTextBoxColumn7.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "SpecName";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 75;
            gridViewDecimalColumn3.DataType = typeof(double);
            gridViewDecimalColumn3.FieldName = "RateTotal";
            gridViewDecimalColumn3.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "RateTotal";
            gridViewDecimalColumn3.ReadOnly = true;
            gridViewDecimalColumn3.Width = 62;
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn4.FieldName = "RateRh";
            gridViewDecimalColumn4.HeaderText = "Його % володіння";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "RateRh";
            gridViewDecimalColumn4.ReadOnly = true;
            gridViewDecimalColumn4.Width = 62;
            gridViewTextBoxColumn8.FieldName = "Performer";
            gridViewTextBoxColumn8.HeaderText = "Виконавець";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "Performer";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 87;
            gridViewDecimalColumn5.DataType = typeof(double);
            gridViewDecimalColumn5.FieldName = "Profit";
            gridViewDecimalColumn5.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "Profit";
            gridViewDecimalColumn5.ReadOnly = true;
            gridViewDecimalColumn5.Width = 93;
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
            gridViewCheckBoxColumn1,
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
            this.gvRightholdersObjectsRights.Size = new System.Drawing.Size(889, 501);
            this.gvRightholdersObjectsRights.TabIndex = 2;
            this.gvRightholdersObjectsRights.ThemeName = "Office2013Light";
            this.gvRightholdersObjectsRights.ValueChanged += new System.EventHandler(this.gvRightholdersObjectsRights_ValueChanged);
            this.gvRightholdersObjectsRights.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersObjectsRights_CellDoubleClick);
            this.gvRightholdersObjectsRights.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersObjectsRights_CellValueChanged);
            this.gvRightholdersObjectsRights.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRightholdersObjectsRights_CommandCellClick);
            this.gvRightholdersObjectsRights.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvRightholdersObjectsRights_ToolTipTextNeeded);
            // 
            // objectRightForRightholderBindingSource
            // 
            this.objectRightForRightholderBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectRightForRightholder);
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.radPanel2.Controls.Add(this.gvRightholdersObjectsRights);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 29);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(889, 501);
            this.radPanel2.TabIndex = 4;
            this.radPanel2.ThemeName = "Office2013Light";
            // 
            // ctrlRightholderSelector
            // 
            this.ctrlRightholderSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlRightholderSelector.Location = new System.Drawing.Point(0, 0);
            this.ctrlRightholderSelector.Name = "ctrlRightholderSelector";
            this.ctrlRightholderSelector.Rightholder = null;
            this.ctrlRightholderSelector.Size = new System.Drawing.Size(889, 29);
            this.ctrlRightholderSelector.TabIndex = 0;
            this.ctrlRightholderSelector.RightholderChanged += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelector_RightholderChanged);
            this.ctrlRightholderSelector.ShowAnketaCommandExecuted += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelector_ShowAnketaCommandExecuted);
            // 
            // RightholdersObjectsRightsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.ctrlRightholderSelector);
            this.Name = "RightholdersObjectsRightsControl";
            this.Size = new System.Drawing.Size(889, 530);
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private RightholderSelectorControl ctrlRightholderSelector;
        private Telerik.WinControls.UI.RadGridView gvRightholdersObjectsRights;
        private System.Windows.Forms.BindingSource objectRightForRightholderBindingSource;
        private Telerik.WinControls.UI.RadPanel radPanel2;
    }
}
