namespace IpsViewComponentLibrary
{
    partial class RegisterListControl
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.txtSearchRegister = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.gvRegisterList = new Telerik.WinControls.UI.RadGridView();
            this.registerListViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerListViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchRegister
            // 
            this.txtSearchRegister.Location = new System.Drawing.Point(56, 3);
            this.txtSearchRegister.Name = "txtSearchRegister";
            this.txtSearchRegister.Size = new System.Drawing.Size(641, 21);
            this.txtSearchRegister.TabIndex = 26;
            this.txtSearchRegister.ThemeName = "Office2013Light";
            this.txtSearchRegister.TextChanged += new System.EventHandler(this.txtSearchRegister_TextChanged);
            // 
            // radLabel23
            // 
            this.radLabel23.Location = new System.Drawing.Point(3, 3);
            this.radLabel23.Name = "radLabel23";
            this.radLabel23.Size = new System.Drawing.Size(47, 19);
            this.radLabel23.TabIndex = 25;
            this.radLabel23.Text = "Пошук:";
            this.radLabel23.ThemeName = "Office2013Light";
            // 
            // gvRegisterList
            // 
            this.gvRegisterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRegisterList.EnableCustomFiltering = true;
            this.gvRegisterList.Location = new System.Drawing.Point(4, 30);
            // 
            // 
            // 
            this.gvRegisterList.MasterTemplate.AllowAddNewRow = false;
            this.gvRegisterList.MasterTemplate.AllowDeleteRow = false;
            this.gvRegisterList.MasterTemplate.AllowEditRow = false;
            this.gvRegisterList.MasterTemplate.AutoGenerateColumns = false;
            this.gvRegisterList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "RegId";
            gridViewDecimalColumn1.HeaderText = "№ відомості";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "RegId";
            gridViewDecimalColumn1.Width = 32;
            gridViewTextBoxColumn1.FieldName = "PeriodName";
            gridViewTextBoxColumn1.HeaderText = "Період";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "PeriodName";
            gridViewTextBoxColumn1.Width = 70;
            gridViewDateTimeColumn1.FieldName = "CreateDate";
            gridViewDateTimeColumn1.HeaderText = "Дата створення";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.Name = "CreateDate";
            gridViewDateTimeColumn1.Width = 80;
            gridViewTextBoxColumn2.FieldName = "UserWho";
            gridViewTextBoxColumn2.HeaderText = "Хто прийняв";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "UserWho";
            gridViewTextBoxColumn2.Width = 100;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "CountItem";
            gridViewDecimalColumn2.HeaderText = "К-ть записів";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "CountItem";
            gridViewDecimalColumn2.Width = 35;
            gridViewDecimalColumn3.DataType = typeof(int);
            gridViewDecimalColumn3.FieldName = "CountNoFound";
            gridViewDecimalColumn3.HeaderText = "К-ть не знайдених";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "CountNoFound";
            gridViewDecimalColumn3.Width = 35;
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn4.FieldName = "CRightCode";
            gridViewDecimalColumn4.HeaderText = "Код виду права";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "CRightCode";
            gridViewDecimalColumn4.Width = 35;
            gridViewTextBoxColumn3.FieldName = "RgStatusName";
            gridViewTextBoxColumn3.HeaderText = "Статус";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "RgStatusName";
            gridViewTextBoxColumn3.Width = 70;
            gridViewTextBoxColumn4.FieldName = "CustName";
            gridViewTextBoxColumn4.HeaderText = "Користувач";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "CustName";
            gridViewTextBoxColumn4.Width = 162;
            gridViewDecimalColumn5.DataType = typeof(int);
            gridViewDecimalColumn5.FieldName = "RgStatus";
            gridViewDecimalColumn5.HeaderText = "RgStatus";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.IsVisible = false;
            gridViewDecimalColumn5.Name = "RgStatus";
            gridViewDecimalColumn5.Width = 57;
            gridViewTextBoxColumn5.FieldName = "CRightName";
            gridViewTextBoxColumn5.HeaderText = "CRightName";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "CRightName";
            gridViewTextBoxColumn5.Width = 52;
            gridViewDecimalColumn6.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn6.FieldName = "PeriodId";
            gridViewDecimalColumn6.HeaderText = "PeriodId";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.IsVisible = false;
            gridViewDecimalColumn6.Name = "PeriodId";
            gridViewDecimalColumn6.Width = 48;
            gridViewDecimalColumn7.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn7.FieldName = "CustId";
            gridViewDecimalColumn7.HeaderText = "CustId";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.IsVisible = false;
            gridViewDecimalColumn7.Name = "CustId";
            gridViewDecimalColumn7.Width = 63;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Редагувати";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "EditColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 81;
            this.gvRegisterList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn5,
            gridViewTextBoxColumn5,
            gridViewDecimalColumn6,
            gridViewDecimalColumn7,
            gridViewCommandColumn1});
            this.gvRegisterList.MasterTemplate.DataSource = this.registerListViewModelBindingSource;
            this.gvRegisterList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRegisterList.MasterTemplate.EnableFiltering = true;
            this.gvRegisterList.MasterTemplate.ShowFilteringRow = false;
            this.gvRegisterList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRegisterList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvRegisterList.Name = "gvRegisterList";
            this.gvRegisterList.ShowGroupPanel = false;
            this.gvRegisterList.Size = new System.Drawing.Size(693, 318);
            this.gvRegisterList.TabIndex = 27;
            this.gvRegisterList.ThemeName = "Office2013Light";
            this.gvRegisterList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRegisterList_CellDoubleClick);
            this.gvRegisterList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRegisterList_CommandCellClick);
            this.gvRegisterList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvRegisterList_CustomFiltering);
            // 
            // registerListViewModelBindingSource
            // 
            this.registerListViewModelBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterListViewModel);
            // 
            // RegisterListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvRegisterList);
            this.Controls.Add(this.txtSearchRegister);
            this.Controls.Add(this.radLabel23);
            this.Name = "RegisterListControl";
            this.Size = new System.Drawing.Size(700, 350);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerListViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadTextBox txtSearchRegister;
        private Telerik.WinControls.UI.RadLabel radLabel23;
        private Telerik.WinControls.UI.RadGridView gvRegisterList;
        private System.Windows.Forms.BindingSource registerListViewModelBindingSource;
    }
}
