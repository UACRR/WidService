namespace IpsViewComponentLibrary.ConsumerControls.SmallRight.Reports
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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.bsDictCreativeRole = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.txtCrName = new Telerik.WinControls.UI.RadTextBox();
            this.bsRegisterItem = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCreativeRole = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictGenreType = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.gvAuthRole = new Telerik.WinControls.UI.RadGridView();
            this.bsRegisterExtra = new System.Windows.Forms.BindingSource(this.components);
            this.nudCountUse = new System.Windows.Forms.NumericUpDown();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlSaveCancelButtons = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCreativeRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreativeRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterExtra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCountUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDictCreativeRole
            // 
            this.bsDictCreativeRole.DataSource = typeof(ipsFormsDesign.Model.CreativeRoleType);
            // 
            // txtCrName
            // 
            this.txtCrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRegisterItem, "ItemName", true));
            this.txtCrName.Location = new System.Drawing.Point(84, 3);
            this.txtCrName.Name = "txtCrName";
            this.txtCrName.Size = new System.Drawing.Size(339, 21);
            this.txtCrName.TabIndex = 25;
            this.txtCrName.ThemeName = "Office2013Light";
            // 
            // bsRegisterItem
            // 
            this.bsRegisterItem.DataSource = typeof(ipsFormsDesign.Model.RegisterItem);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(3, 3);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(75, 19);
            this.radLabel7.TabIndex = 24;
            this.radLabel7.Text = "Назва твору";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // ddlCreativeRole
            // 
            this.ddlCreativeRole.DataSource = this.bsDictGenreType;
            this.ddlCreativeRole.DisplayMember = "Name";
            this.ddlCreativeRole.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCreativeRole.Location = new System.Drawing.Point(84, 29);
            this.ddlCreativeRole.Name = "ddlCreativeRole";
            this.ddlCreativeRole.Size = new System.Drawing.Size(395, 21);
            this.ddlCreativeRole.TabIndex = 22;
            this.ddlCreativeRole.ThemeName = "Office2013Light";
            this.ddlCreativeRole.ValueMember = "CodeI";
            // 
            // bsDictGenreType
            // 
            this.bsDictGenreType.DataSource = typeof(ipsFormsDesign.Model.GenreType);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 29);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(73, 19);
            this.radLabel2.TabIndex = 23;
            this.radLabel2.Text = "Жарн твору";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(0, 318);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 21);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Додати автора";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvAuthRole
            // 
            this.gvAuthRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvAuthRole.AutoSizeRows = true;
            this.gvAuthRole.Location = new System.Drawing.Point(0, 62);
            // 
            // 
            // 
            this.gvAuthRole.MasterTemplate.AllowAddNewRow = false;
            this.gvAuthRole.MasterTemplate.AllowDeleteRow = false;
            this.gvAuthRole.MasterTemplate.AllowDragToGroup = false;
            this.gvAuthRole.MasterTemplate.AutoGenerateColumns = false;
            this.gvAuthRole.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewComboBoxColumn1.DataSource = this.bsDictCreativeRole;
            gridViewComboBoxColumn1.DataType = typeof(int);
            gridViewComboBoxColumn1.DisplayMember = "Name";
            gridViewComboBoxColumn1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewComboBoxColumn1.FieldName = "RoleCode";
            gridViewComboBoxColumn1.HeaderText = "Творча роль автора";
            gridViewComboBoxColumn1.MinWidth = 200;
            gridViewComboBoxColumn1.Name = "RoleCode";
            gridViewComboBoxColumn1.ValueMember = "CodeI";
            gridViewComboBoxColumn1.Width = 236;
            gridViewTextBoxColumn1.FieldName = "Name";
            gridViewTextBoxColumn1.HeaderText = "ПІБ автора";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.MinWidth = 300;
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 330;
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
            gridViewTextBoxColumn2.DataType = typeof(ipsFormsDesign.Model.RegisterItem);
            gridViewTextBoxColumn2.FieldName = "RegI";
            gridViewTextBoxColumn2.HeaderText = "RegI";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "RegI";
            gridViewTextBoxColumn2.Width = 37;
            gridViewTextBoxColumn3.DataType = typeof(ipsFormsDesign.Model.CreativeRoleType);
            gridViewTextBoxColumn3.FieldName = "RoleCodeNavigation";
            gridViewTextBoxColumn3.HeaderText = "RoleCodeNavigation";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "RoleCodeNavigation";
            gridViewTextBoxColumn3.Width = 27;
            this.gvAuthRole.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewCommandColumn1,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.gvAuthRole.MasterTemplate.DataSource = this.bsRegisterExtra;
            this.gvAuthRole.MasterTemplate.EnableGrouping = false;
            this.gvAuthRole.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvAuthRole.Name = "gvAuthRole";
            this.gvAuthRole.ShowGroupPanel = false;
            this.gvAuthRole.Size = new System.Drawing.Size(620, 250);
            this.gvAuthRole.TabIndex = 31;
            this.gvAuthRole.ThemeName = "Office2013Light";
            this.gvAuthRole.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvAuthRole_CommandCellClick);
            // 
            // bsRegisterExtra
            // 
            this.bsRegisterExtra.DataSource = typeof(ipsFormsDesign.Model.RegisterExtra);
            // 
            // nudCountUse
            // 
            this.nudCountUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCountUse.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRegisterItem, "CountUse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "1"));
            this.nudCountUse.Location = new System.Drawing.Point(549, 3);
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
            this.radLabel1.Location = new System.Drawing.Point(429, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(114, 19);
            this.radLabel1.TabIndex = 34;
            this.radLabel1.Text = "К-сть використань:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ctrlSaveCancelButtons
            // 
            this.ctrlSaveCancelButtons.ButtonSaveDialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrlSaveCancelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancelButtons.Location = new System.Drawing.Point(0, 345);
            this.ctrlSaveCancelButtons.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancelButtons.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancelButtons.Name = "ctrlSaveCancelButtons";
            this.ctrlSaveCancelButtons.SaveButtonEnabled = true;
            this.ctrlSaveCancelButtons.Size = new System.Drawing.Size(620, 31);
            this.ctrlSaveCancelButtons.TabIndex = 35;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radLabel7);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.ddlCreativeRole);
            this.radPanel1.Controls.Add(this.nudCountUse);
            this.radPanel1.Controls.Add(this.txtCrName);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(620, 56);
            this.radPanel1.TabIndex = 36;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // CompositionOfReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(600, 300);
            this.ClientSize = new System.Drawing.Size(620, 376);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.ctrlSaveCancelButtons);
            this.Controls.Add(this.gvAuthRole);
            this.Controls.Add(this.btnAdd);
            this.Name = "CompositionOfReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Додавання твору";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCreativeRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreativeRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterExtra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCountUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadTextBox txtCrName;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadDropDownList ddlCreativeRole;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView gvAuthRole;
        private System.Windows.Forms.BindingSource bsRegisterItem;
        private System.Windows.Forms.BindingSource bsDictCreativeRole;
        private System.Windows.Forms.BindingSource bsRegisterExtra;
        private System.Windows.Forms.NumericUpDown nudCountUse;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Common.SaveCancelButtonsControl ctrlSaveCancelButtons;
        private System.Windows.Forms.BindingSource bsDictGenreType;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
