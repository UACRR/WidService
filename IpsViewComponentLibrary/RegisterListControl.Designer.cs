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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn9 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn10 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn11 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn12 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn13 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn14 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.txtSearchRegister = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.gvRegisterList = new Telerik.WinControls.UI.RadGridView();
            this.dtCreateDateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.dtCreateDateTill = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnClearFrom = new Telerik.WinControls.UI.RadButton();
            this.btnClearTill = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.registerListViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateTill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearTill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerListViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchRegister
            // 
            this.txtSearchRegister.Location = new System.Drawing.Point(102, 28);
            this.txtSearchRegister.Name = "txtSearchRegister";
            this.txtSearchRegister.Size = new System.Drawing.Size(595, 21);
            this.txtSearchRegister.TabIndex = 26;
            this.txtSearchRegister.ThemeName = "Office2013Light";
            this.txtSearchRegister.TextChanged += new System.EventHandler(this.txtSearchRegister_TextChanged);
            // 
            // radLabel23
            // 
            this.radLabel23.Location = new System.Drawing.Point(3, 28);
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
            this.gvRegisterList.Location = new System.Drawing.Point(4, 55);
            // 
            // 
            // 
            this.gvRegisterList.MasterTemplate.AllowAddNewRow = false;
            this.gvRegisterList.MasterTemplate.AllowDeleteRow = false;
            this.gvRegisterList.MasterTemplate.AllowEditRow = false;
            this.gvRegisterList.MasterTemplate.AutoGenerateColumns = false;
            this.gvRegisterList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn8.DataType = typeof(int);
            gridViewDecimalColumn8.FieldName = "RegId";
            gridViewDecimalColumn8.HeaderText = "№ відомості";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.Name = "RegId";
            gridViewDecimalColumn8.Width = 32;
            gridViewTextBoxColumn6.FieldName = "PeriodName";
            gridViewTextBoxColumn6.HeaderText = "Період";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "PeriodName";
            gridViewTextBoxColumn6.Width = 69;
            gridViewDateTimeColumn2.FieldName = "CreateDate";
            gridViewDateTimeColumn2.HeaderText = "Дата створення";
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.Name = "CreateDate";
            gridViewDateTimeColumn2.Width = 79;
            gridViewTextBoxColumn7.FieldName = "UserWho";
            gridViewTextBoxColumn7.HeaderText = "Хто прийняв";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "UserWho";
            gridViewTextBoxColumn7.Width = 99;
            gridViewDecimalColumn9.DataType = typeof(int);
            gridViewDecimalColumn9.FieldName = "CountItem";
            gridViewDecimalColumn9.HeaderText = "К-ть записів";
            gridViewDecimalColumn9.IsAutoGenerated = true;
            gridViewDecimalColumn9.Name = "CountItem";
            gridViewDecimalColumn9.Width = 34;
            gridViewDecimalColumn10.DataType = typeof(int);
            gridViewDecimalColumn10.FieldName = "CountNoFound";
            gridViewDecimalColumn10.HeaderText = "К-ть не знайдених";
            gridViewDecimalColumn10.IsAutoGenerated = true;
            gridViewDecimalColumn10.Name = "CountNoFound";
            gridViewDecimalColumn10.Width = 34;
            gridViewDecimalColumn11.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn11.FieldName = "CRightCode";
            gridViewDecimalColumn11.HeaderText = "Код виду права";
            gridViewDecimalColumn11.IsAutoGenerated = true;
            gridViewDecimalColumn11.Name = "CRightCode";
            gridViewDecimalColumn11.Width = 34;
            gridViewTextBoxColumn8.FieldName = "RgStatusName";
            gridViewTextBoxColumn8.HeaderText = "Статус";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "RgStatusName";
            gridViewTextBoxColumn8.Width = 69;
            gridViewTextBoxColumn9.FieldName = "CustName";
            gridViewTextBoxColumn9.HeaderText = "Користувач";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "CustName";
            gridViewTextBoxColumn9.Width = 160;
            gridViewDecimalColumn12.DataType = typeof(int);
            gridViewDecimalColumn12.FieldName = "RgStatus";
            gridViewDecimalColumn12.HeaderText = "RgStatus";
            gridViewDecimalColumn12.IsAutoGenerated = true;
            gridViewDecimalColumn12.IsVisible = false;
            gridViewDecimalColumn12.Name = "RgStatus";
            gridViewDecimalColumn12.Width = 57;
            gridViewTextBoxColumn10.FieldName = "CRightName";
            gridViewTextBoxColumn10.HeaderText = "CRightName";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "CRightName";
            gridViewTextBoxColumn10.Width = 52;
            gridViewDecimalColumn13.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn13.FieldName = "PeriodId";
            gridViewDecimalColumn13.HeaderText = "PeriodId";
            gridViewDecimalColumn13.IsAutoGenerated = true;
            gridViewDecimalColumn13.IsVisible = false;
            gridViewDecimalColumn13.Name = "PeriodId";
            gridViewDecimalColumn13.Width = 48;
            gridViewDecimalColumn14.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn14.FieldName = "CustId";
            gridViewDecimalColumn14.HeaderText = "CustId";
            gridViewDecimalColumn14.IsAutoGenerated = true;
            gridViewDecimalColumn14.IsVisible = false;
            gridViewDecimalColumn14.Name = "CustId";
            gridViewDecimalColumn14.Width = 63;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Редагувати";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "EditColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 81;
            this.gvRegisterList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn8,
            gridViewTextBoxColumn6,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn7,
            gridViewDecimalColumn9,
            gridViewDecimalColumn10,
            gridViewDecimalColumn11,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewDecimalColumn12,
            gridViewTextBoxColumn10,
            gridViewDecimalColumn13,
            gridViewDecimalColumn14,
            gridViewCommandColumn2});
            this.gvRegisterList.MasterTemplate.DataSource = this.registerListViewModelBindingSource;
            this.gvRegisterList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRegisterList.MasterTemplate.EnableFiltering = true;
            this.gvRegisterList.MasterTemplate.ShowFilteringRow = false;
            this.gvRegisterList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRegisterList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvRegisterList.Name = "gvRegisterList";
            this.gvRegisterList.ShowGroupPanel = false;
            this.gvRegisterList.Size = new System.Drawing.Size(693, 293);
            this.gvRegisterList.TabIndex = 27;
            this.gvRegisterList.ThemeName = "Office2013Light";
            this.gvRegisterList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRegisterList_CellDoubleClick);
            this.gvRegisterList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRegisterList_CommandCellClick);
            this.gvRegisterList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvRegisterList_CustomFiltering);
            // 
            // dtCreateDateFrom
            // 
            this.dtCreateDateFrom.Culture = new System.Globalization.CultureInfo("uk-UA");
            this.dtCreateDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreateDateFrom.Location = new System.Drawing.Point(102, 4);
            this.dtCreateDateFrom.Name = "dtCreateDateFrom";
            this.dtCreateDateFrom.Size = new System.Drawing.Size(100, 21);
            this.dtCreateDateFrom.TabIndex = 28;
            this.dtCreateDateFrom.TabStop = false;
            this.dtCreateDateFrom.ThemeName = "Office2013Light";
            this.dtCreateDateFrom.Value = new System.DateTime(((long)(0)));
            this.dtCreateDateFrom.ValueChanged += new System.EventHandler(this.dtCreateDateFrom_ValueChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(95, 19);
            this.radLabel1.TabIndex = 29;
            this.radLabel1.Text = "Дата створення";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(230, 5);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(11, 19);
            this.radLabel2.TabIndex = 30;
            this.radLabel2.Text = "-";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // dtCreateDateTill
            // 
            this.dtCreateDateTill.Culture = new System.Globalization.CultureInfo("uk-UA");
            this.dtCreateDateTill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreateDateTill.Location = new System.Drawing.Point(247, 4);
            this.dtCreateDateTill.Name = "dtCreateDateTill";
            this.dtCreateDateTill.Size = new System.Drawing.Size(100, 21);
            this.dtCreateDateTill.TabIndex = 29;
            this.dtCreateDateTill.TabStop = false;
            this.dtCreateDateTill.ThemeName = "Office2013Light";
            this.dtCreateDateTill.Value = new System.DateTime(((long)(0)));
            this.dtCreateDateTill.ValueChanged += new System.EventHandler(this.dtCreateDateTill_ValueChanged);
            // 
            // btnClearFrom
            // 
            this.btnClearFrom.Location = new System.Drawing.Point(201, 4);
            this.btnClearFrom.Name = "btnClearFrom";
            this.btnClearFrom.Size = new System.Drawing.Size(23, 21);
            this.btnClearFrom.TabIndex = 31;
            this.btnClearFrom.Text = "X";
            this.btnClearFrom.ThemeName = "Office2013Light";
            this.btnClearFrom.Click += new System.EventHandler(this.btnClearFrom_Click);
            // 
            // btnClearTill
            // 
            this.btnClearTill.Location = new System.Drawing.Point(346, 4);
            this.btnClearTill.Name = "btnClearTill";
            this.btnClearTill.Size = new System.Drawing.Size(23, 21);
            this.btnClearTill.TabIndex = 32;
            this.btnClearTill.Text = "X";
            this.btnClearTill.ThemeName = "Office2013Light";
            this.btnClearTill.Click += new System.EventHandler(this.btnClearTill_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(392, 5);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(42, 19);
            this.radLabel3.TabIndex = 30;
            this.radLabel3.Text = "Статус";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlStatus.Location = new System.Drawing.Point(440, 5);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(257, 21);
            this.ddlStatus.TabIndex = 33;
            this.ddlStatus.ThemeName = "Office2013Light";
            this.ddlStatus.SelectedValueChanged += new System.EventHandler(this.ddlStatus_SelectedValueChanged);
            // 
            // registerListViewModelBindingSource
            // 
            this.registerListViewModelBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterListViewModel);
            // 
            // RegisterListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnClearTill);
            this.Controls.Add(this.btnClearFrom);
            this.Controls.Add(this.dtCreateDateTill);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dtCreateDateFrom);
            this.Controls.Add(this.gvRegisterList);
            this.Controls.Add(this.txtSearchRegister);
            this.Controls.Add(this.radLabel23);
            this.Name = "RegisterListControl";
            this.Size = new System.Drawing.Size(700, 350);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateTill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearTill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
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
        private Telerik.WinControls.UI.RadDateTimePicker dtCreateDateFrom;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDateTimePicker dtCreateDateTill;
        private Telerik.WinControls.UI.RadButton btnClearFrom;
        private Telerik.WinControls.UI.RadButton btnClearTill;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList ddlStatus;
    }
}
