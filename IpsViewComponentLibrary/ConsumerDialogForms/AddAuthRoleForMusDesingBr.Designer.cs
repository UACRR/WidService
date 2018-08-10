namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    partial class AddAuthRoleForMusDesingBr
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
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCreativeRole = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtAuthName = new Telerik.WinControls.UI.RadTextBox();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.gvAuthRole = new Telerik.WinControls.UI.RadGridView();
            this.bsRegisterItem = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictCreativeRole = new System.Windows.Forms.BindingSource(this.components);
            this.registerExtraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtCrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreativeRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCreativeRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerExtraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCrName
            // 
            this.txtCrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrName.Location = new System.Drawing.Point(93, 11);
            this.txtCrName.Name = "txtCrName";
            this.txtCrName.Size = new System.Drawing.Size(559, 21);
            this.txtCrName.TabIndex = 25;
            this.txtCrName.ThemeName = "Office2013Light";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(12, 12);
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
            this.ddlCreativeRole.Location = new System.Drawing.Point(12, 62);
            this.ddlCreativeRole.Name = "ddlCreativeRole";
            this.ddlCreativeRole.Size = new System.Drawing.Size(209, 21);
            this.ddlCreativeRole.TabIndex = 22;
            this.ddlCreativeRole.ThemeName = "Office2013Light";
            this.ddlCreativeRole.ValueMember = "CodeI";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 37);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(120, 19);
            this.radLabel2.TabIndex = 23;
            this.radLabel2.Text = "Творча роль автора";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(227, 38);
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
            this.txtAuthName.Location = new System.Drawing.Point(227, 62);
            this.txtAuthName.Name = "txtAuthName";
            this.txtAuthName.Size = new System.Drawing.Size(320, 21);
            this.txtAuthName.TabIndex = 27;
            this.txtAuthName.ThemeName = "Office2013Light";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(553, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 21);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Додати";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(542, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gvAuthRole
            // 
            this.gvAuthRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvAuthRole.AutoSizeRows = true;
            this.gvAuthRole.Location = new System.Drawing.Point(12, 89);
            // 
            // 
            // 
            this.gvAuthRole.MasterTemplate.AllowAddNewRow = false;
            this.gvAuthRole.MasterTemplate.AllowDeleteRow = false;
            this.gvAuthRole.MasterTemplate.AllowDragToGroup = false;
            this.gvAuthRole.MasterTemplate.AutoGenerateColumns = false;
            this.gvAuthRole.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "RoleName";
            gridViewTextBoxColumn1.HeaderText = "Творча роль";
            gridViewTextBoxColumn1.Name = "RoleName";
            gridViewTextBoxColumn1.Width = 301;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "ПІБ автора";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 285;
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
            this.gvAuthRole.Size = new System.Drawing.Size(640, 241);
            this.gvAuthRole.TabIndex = 31;
            this.gvAuthRole.ThemeName = "Office2013Light";
            this.gvAuthRole.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvAuthRole_CommandCellClick);
            // 
            // bsRegisterItem
            // 
            this.bsRegisterItem.DataSource = typeof(ipsFormsDesign.Model.RegisterItem);
            // 
            // bsDictCreativeRole
            // 
            this.bsDictCreativeRole.DataSource = typeof(ipsFormsDesign.Model.CreativeRoleType);
            // 
            // registerExtraBindingSource
            // 
            this.registerExtraBindingSource.DataSource = typeof(ipsFormsDesign.Model.RegisterExtra);
            // 
            // AddAuthRoleForMusDesingBr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(664, 372);
            this.Controls.Add(this.gvAuthRole);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtAuthName);
            this.Controls.Add(this.txtCrName);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.ddlCreativeRole);
            this.Controls.Add(this.radLabel2);
            this.Name = "AddAuthRoleForMusDesingBr";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Додавання твору";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.txtCrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCreativeRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuthName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAuthRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegisterItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCreativeRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerExtraBindingSource)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadGridView gvAuthRole;
        private System.Windows.Forms.BindingSource bsRegisterItem;
        private System.Windows.Forms.BindingSource bsDictCreativeRole;
        private System.Windows.Forms.BindingSource registerExtraBindingSource;
    }
}
