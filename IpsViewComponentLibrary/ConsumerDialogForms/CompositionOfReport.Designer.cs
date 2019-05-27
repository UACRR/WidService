namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    partial class CompositionOfReport
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.txtCrName = new Telerik.WinControls.UI.RadTextBox();
            this.bsRegisterItem = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCreativeRole = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictCreativeRole = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtAuthName = new Telerik.WinControls.UI.RadTextBox();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.gvAuthRole = new Telerik.WinControls.UI.RadGridView();
            this.registerExtraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nudCountUse = new System.Windows.Forms.NumericUpDown();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlSaveCancelButtons = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreativeRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCreativeRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerExtraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCountUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCrName
            // 
            this.txtCrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRegisterItem, "ItemName", true));
            this.txtCrName.Location = new System.Drawing.Point(81, 11);
            this.txtCrName.Name = "txtCrName";
            this.txtCrName.Size = new System.Drawing.Size(441, 21);
            this.txtCrName.TabIndex = 25;
            this.txtCrName.ThemeName = "Office2013Light";
            // 
            // bsRegisterItem
            // 
            this.bsRegisterItem.DataSource = typeof(ipsFormsDesign.Model.RegisterItem);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(0, 12);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(75, 19);
            this.radLabel7.TabIndex = 24;
            this.radLabel7.Text = "Назва твору";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // ddlCreativeRole
            // 
            this.ddlCreativeRole.DataSource = this.bsDictCreativeRole;
            this.ddlCreativeRole.DisplayMember = "Name";
            this.ddlCreativeRole.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCreativeRole.Location = new System.Drawing.Point(0, 62);
            this.ddlCreativeRole.Name = "ddlCreativeRole";
            this.ddlCreativeRole.Size = new System.Drawing.Size(209, 21);
            this.ddlCreativeRole.TabIndex = 22;
            this.ddlCreativeRole.ThemeName = "Office2013Light";
            this.ddlCreativeRole.ValueMember = "CodeI";
            // 
            // bsDictCreativeRole
            // 
            this.bsDictCreativeRole.DataSource = typeof(ipsFormsDesign.Model.CreativeRoleType);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(0, 37);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(120, 19);
            this.radLabel2.TabIndex = 23;
            this.radLabel2.Text = "Творча роль автора";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(215, 38);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(68, 19);
            this.radLabel3.TabIndex = 26;
            this.radLabel3.Text = "ПІБ автора";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // txtAuthName
            // 
            this.txtAuthName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthName.Location = new System.Drawing.Point(215, 62);
            this.txtAuthName.Name = "txtAuthName";
            this.txtAuthName.Size = new System.Drawing.Size(396, 21);
            this.txtAuthName.TabIndex = 27;
            this.txtAuthName.ThemeName = "Office2013Light";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(617, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 21);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Додати";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvAuthRole
            // 
            this.gvAuthRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvAuthRole.AutoSizeRows = true;
            this.gvAuthRole.Location = new System.Drawing.Point(0, 89);
            // 
            // 
            // 
            this.gvAuthRole.MasterTemplate.AllowAddNewRow = false;
            this.gvAuthRole.MasterTemplate.AllowDeleteRow = false;
            this.gvAuthRole.MasterTemplate.AllowDragToGroup = false;
            this.gvAuthRole.MasterTemplate.AutoGenerateColumns = false;
            this.gvAuthRole.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "RoleCodeNavigation.Name";
            gridViewTextBoxColumn1.HeaderText = "Творча роль";
            gridViewTextBoxColumn1.Name = "RoleName";
            gridViewTextBoxColumn1.Width = 339;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "ПІБ автора";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 323;
            gridViewCommandColumn1.FieldName = "btnsDelete";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "btnsDelete";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            gridViewCommandColumn1.Width = 30;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "RegExtraId";
            gridViewDecimalColumn1.HeaderText = "RegExtraId";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "RegExtraId";
            gridViewDecimalColumn1.Width = 30;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "RegId";
            gridViewDecimalColumn2.HeaderText = "RegId";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Name = "RegId";
            gridViewDecimalColumn2.Width = 31;
            gridViewDecimalColumn3.DataType = typeof(int);
            gridViewDecimalColumn3.FieldName = "RegIitemId";
            gridViewDecimalColumn3.HeaderText = "RegIitemId";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.IsVisible = false;
            gridViewDecimalColumn3.Name = "RegIitemId";
            gridViewDecimalColumn3.Width = 33;
            gridViewDecimalColumn4.DataType = typeof(int);
            gridViewDecimalColumn4.FieldName = "RoleCode";
            gridViewDecimalColumn4.HeaderText = "RoleCode";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "RoleCode";
            gridViewDecimalColumn4.Width = 35;
            gridViewTextBoxColumn3.DataType = typeof(ipsFormsDesign.Model.RegisterItem);
            gridViewTextBoxColumn3.FieldName = "RegI";
            gridViewTextBoxColumn3.HeaderText = "RegI";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "RegI";
            gridViewTextBoxColumn3.Width = 37;
            gridViewTextBoxColumn4.DataType = typeof(ipsFormsDesign.Model.CreativeRoleType);
            gridViewTextBoxColumn4.FieldName = "RoleCodeNavigation";
            gridViewTextBoxColumn4.HeaderText = "RoleCodeNavigation";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "RoleCodeNavigation";
            gridViewTextBoxColumn4.Width = 27;
            this.gvAuthRole.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvAuthRole.MasterTemplate.DataSource = this.registerExtraBindingSource;
            this.gvAuthRole.MasterTemplate.EnableGrouping = false;
            this.gvAuthRole.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvAuthRole.Name = "gvAuthRole";
            this.gvAuthRole.ReadOnly = true;
            this.gvAuthRole.ShowGroupPanel = false;
            this.gvAuthRole.Size = new System.Drawing.Size(716, 271);
            this.gvAuthRole.TabIndex = 31;
            this.gvAuthRole.ThemeName = "Office2013Light";
            this.gvAuthRole.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvAuthRole_CommandCellClick);
            // 
            // registerExtraBindingSource
            // 
            this.registerExtraBindingSource.DataMember = "RegisterExtra";
            this.registerExtraBindingSource.DataSource = this.bsRegisterItem;
            // 
            // nudCountUse
            // 
            this.nudCountUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCountUse.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRegisterItem, "CountUse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "1"));
            this.nudCountUse.Location = new System.Drawing.Point(648, 12);
            this.nudCountUse.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCountUse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCountUse.Name = "nudCountUse";
            this.nudCountUse.Size = new System.Drawing.Size(68, 20);
            this.nudCountUse.TabIndex = 33;
            this.nudCountUse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Location = new System.Drawing.Point(528, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(114, 19);
            this.radLabel1.TabIndex = 34;
            this.radLabel1.Text = "К-сть використань:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ctrlSaveCancelButtons
            // 
            this.ctrlSaveCancelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancelButtons.Location = new System.Drawing.Point(0, 366);
            this.ctrlSaveCancelButtons.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancelButtons.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancelButtons.Name = "ctrlSaveCancelButtons";
            this.ctrlSaveCancelButtons.SaveButtonEnabled = true;
            this.ctrlSaveCancelButtons.Size = new System.Drawing.Size(716, 31);
            this.ctrlSaveCancelButtons.TabIndex = 35;
            // 
            // CompositionOfReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(530, 300);
            this.ClientSize = new System.Drawing.Size(716, 397);
            this.Controls.Add(this.ctrlSaveCancelButtons);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.nudCountUse);
            this.Controls.Add(this.gvAuthRole);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtAuthName);
            this.Controls.Add(this.txtCrName);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.ddlCreativeRole);
            this.Controls.Add(this.radLabel2);
            this.Name = "CompositionOfReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Додавання твору";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.txtCrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreativeRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCreativeRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerExtraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCountUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadTextBox txtCrName;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadDropDownList ddlCreativeRole;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtAuthName;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView gvAuthRole;
        private System.Windows.Forms.BindingSource bsRegisterItem;
        private System.Windows.Forms.BindingSource bsDictCreativeRole;
        private System.Windows.Forms.BindingSource registerExtraBindingSource;
        private System.Windows.Forms.NumericUpDown nudCountUse;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Common.SaveCancelButtonsControl ctrlSaveCancelButtons;
    }
}
