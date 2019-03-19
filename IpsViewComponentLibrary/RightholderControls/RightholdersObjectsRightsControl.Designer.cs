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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn9 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn10 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gvRightholdersObjectsRights = new Telerik.WinControls.UI.RadGridView();
            this.objectRightForRightholderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelRightsControl = new Telerik.WinControls.UI.RadPanel();
            this.lblTxtCount = new System.Windows.Forms.Label();
            this.lblCountObjectsRight = new System.Windows.Forms.Label();
            this.ctrlRightholderSelector = new IpsViewComponentLibrary.RightholderControls.RightholderSelectorControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRightsControl)).BeginInit();
            this.panelRightsControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvRightholdersObjectsRights
            // 
            this.gvRightholdersObjectsRights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightholdersObjectsRights.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvRightholdersObjectsRights.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn2.EnableHeaderCheckBox = true;
            gridViewCheckBoxColumn2.HeaderText = "";
            gridViewCheckBoxColumn2.MaxWidth = 30;
            gridViewCheckBoxColumn2.MinWidth = 30;
            gridViewCheckBoxColumn2.Name = "IsSelected";
            gridViewCheckBoxColumn2.Width = 30;
            gridViewDecimalColumn6.DataType = typeof(int);
            gridViewDecimalColumn6.FieldName = "CustId";
            gridViewDecimalColumn6.HeaderText = "CustId";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.IsVisible = false;
            gridViewDecimalColumn6.Name = "CustId";
            gridViewDecimalColumn6.ReadOnly = true;
            gridViewDecimalColumn6.Width = 32;
            gridViewTextBoxColumn9.FieldName = "NameClient";
            gridViewTextBoxColumn9.HeaderText = "NameClient";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "NameClient";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 100;
            gridViewDecimalColumn7.DataType = typeof(int);
            gridViewDecimalColumn7.FieldName = "ObjId";
            gridViewDecimalColumn7.HeaderText = "Шифр твору";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.Name = "ObjId";
            gridViewDecimalColumn7.ReadOnly = true;
            gridViewDecimalColumn7.Width = 62;
            gridViewTextBoxColumn10.FieldName = "Name";
            gridViewTextBoxColumn10.HeaderText = "Назва твору";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.Name = "Name";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 127;
            gridViewTextBoxColumn11.FieldName = "Category";
            gridViewTextBoxColumn11.HeaderText = "В/М";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "Category";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 44;
            gridViewTextBoxColumn12.FieldName = "GenreName";
            gridViewTextBoxColumn12.HeaderText = "Жанр";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "GenreName";
            gridViewTextBoxColumn12.ReadOnly = true;
            gridViewTextBoxColumn12.Width = 83;
            gridViewTextBoxColumn13.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn13.FieldName = "Duration";
            gridViewTextBoxColumn13.HeaderText = "Час";
            gridViewTextBoxColumn13.IsAutoGenerated = true;
            gridViewTextBoxColumn13.Name = "Duration";
            gridViewTextBoxColumn13.ReadOnly = true;
            gridViewTextBoxColumn13.Width = 62;
            gridViewTextBoxColumn14.FieldName = "RoleName";
            gridViewTextBoxColumn14.HeaderText = "Творчий профіль";
            gridViewTextBoxColumn14.IsAutoGenerated = true;
            gridViewTextBoxColumn14.Name = "RoleName";
            gridViewTextBoxColumn14.ReadOnly = true;
            gridViewTextBoxColumn14.Width = 82;
            gridViewTextBoxColumn15.FieldName = "SpecName";
            gridViewTextBoxColumn15.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn15.IsAutoGenerated = true;
            gridViewTextBoxColumn15.Name = "SpecName";
            gridViewTextBoxColumn15.ReadOnly = true;
            gridViewTextBoxColumn15.Width = 75;
            gridViewDecimalColumn8.DataType = typeof(double);
            gridViewDecimalColumn8.FieldName = "RateTotal";
            gridViewDecimalColumn8.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.Name = "RateTotal";
            gridViewDecimalColumn8.ReadOnly = true;
            gridViewDecimalColumn8.Width = 62;
            gridViewDecimalColumn9.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn9.FieldName = "RateRh";
            gridViewDecimalColumn9.HeaderText = "Його % володіння";
            gridViewDecimalColumn9.IsAutoGenerated = true;
            gridViewDecimalColumn9.Name = "RateRh";
            gridViewDecimalColumn9.ReadOnly = true;
            gridViewDecimalColumn9.Width = 62;
            gridViewTextBoxColumn16.FieldName = "Performer";
            gridViewTextBoxColumn16.HeaderText = "Виконавець";
            gridViewTextBoxColumn16.IsAutoGenerated = true;
            gridViewTextBoxColumn16.Name = "Performer";
            gridViewTextBoxColumn16.ReadOnly = true;
            gridViewTextBoxColumn16.Width = 87;
            gridViewDecimalColumn10.DataType = typeof(double);
            gridViewDecimalColumn10.FieldName = "Profit";
            gridViewDecimalColumn10.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn10.IsAutoGenerated = true;
            gridViewDecimalColumn10.Name = "Profit";
            gridViewDecimalColumn10.ReadOnly = true;
            gridViewDecimalColumn10.Width = 93;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Редагувати";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "EditColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 30;
            this.gvRightholdersObjectsRights.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn2,
            gridViewDecimalColumn6,
            gridViewTextBoxColumn9,
            gridViewDecimalColumn7,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewDecimalColumn8,
            gridViewDecimalColumn9,
            gridViewTextBoxColumn16,
            gridViewDecimalColumn10,
            gridViewCommandColumn2});
            this.gvRightholdersObjectsRights.MasterTemplate.DataSource = this.objectRightForRightholderBindingSource;
            this.gvRightholdersObjectsRights.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersObjectsRights.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvRightholdersObjectsRights.Name = "gvRightholdersObjectsRights";
            this.gvRightholdersObjectsRights.ShowGroupPanel = false;
            this.gvRightholdersObjectsRights.Size = new System.Drawing.Size(889, 475);
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
            // panelRightsControl
            // 
            this.panelRightsControl.BackColor = System.Drawing.Color.Transparent;
            this.panelRightsControl.Controls.Add(this.lblTxtCount);
            this.panelRightsControl.Controls.Add(this.lblCountObjectsRight);
            this.panelRightsControl.Controls.Add(this.gvRightholdersObjectsRights);
            this.panelRightsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightsControl.Location = new System.Drawing.Point(0, 29);
            this.panelRightsControl.Name = "panelRightsControl";
            this.panelRightsControl.Size = new System.Drawing.Size(889, 501);
            this.panelRightsControl.TabIndex = 4;
            this.panelRightsControl.ThemeName = "Office2013Light";
            // 
            // lblTxtCount
            // 
            this.lblTxtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTxtCount.Location = new System.Drawing.Point(740, 478);
            this.lblTxtCount.Name = "lblTxtCount";
            this.lblTxtCount.Size = new System.Drawing.Size(79, 13);
            this.lblTxtCount.TabIndex = 4;
            this.lblTxtCount.Text = "К-ть рядків";
            // 
            // lblCountObjectsRight
            // 
            this.lblCountObjectsRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountObjectsRight.Location = new System.Drawing.Point(825, 478);
            this.lblCountObjectsRight.Name = "lblCountObjectsRight";
            this.lblCountObjectsRight.Size = new System.Drawing.Size(61, 13);
            this.lblCountObjectsRight.TabIndex = 3;
            this.lblCountObjectsRight.Text = "0";
            this.lblCountObjectsRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Controls.Add(this.panelRightsControl);
            this.Controls.Add(this.ctrlRightholderSelector);
            this.Name = "RightholdersObjectsRightsControl";
            this.Size = new System.Drawing.Size(889, 530);
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRightsControl)).EndInit();
            this.panelRightsControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private RightholderSelectorControl ctrlRightholderSelector;
        private Telerik.WinControls.UI.RadGridView gvRightholdersObjectsRights;
        private System.Windows.Forms.BindingSource objectRightForRightholderBindingSource;
        private Telerik.WinControls.UI.RadPanel panelRightsControl;
        private System.Windows.Forms.Label lblCountObjectsRight;
        private System.Windows.Forms.Label lblTxtCount;
    }
}
