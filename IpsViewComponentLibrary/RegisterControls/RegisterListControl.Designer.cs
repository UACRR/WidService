namespace IpsViewComponentLibrary.RegisterControls
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn15 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn16 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn17 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn18 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn19 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn20 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn21 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.txtSearchRegister = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.gvRegisterList = new Telerik.WinControls.UI.RadGridView();
            this.registerListViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtCreateDateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.dtCreateDateTill = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnClearFrom = new Telerik.WinControls.UI.RadButton();
            this.btnClearTill = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.lblCountRegister = new System.Windows.Forms.Label();
            this.lblCountTextRegister = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerListViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateTill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearTill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchRegister
            // 
            this.txtSearchRegister.Location = new System.Drawing.Point(222, 28);
            this.txtSearchRegister.Name = "txtSearchRegister";
            this.txtSearchRegister.Size = new System.Drawing.Size(595, 21);
            this.txtSearchRegister.TabIndex = 26;
            this.txtSearchRegister.ThemeName = "Office2013Light";
            this.txtSearchRegister.TextChanged += new System.EventHandler(this.txtSearchRegister_TextChanged);
            // 
            // radLabel23
            // 
            this.radLabel23.Location = new System.Drawing.Point(123, 28);
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
            gridViewDecimalColumn15.DataType = typeof(int);
            gridViewDecimalColumn15.FieldName = "RegId";
            gridViewDecimalColumn15.HeaderText = "№ відомості";
            gridViewDecimalColumn15.IsAutoGenerated = true;
            gridViewDecimalColumn15.Name = "RegId";
            gridViewDecimalColumn15.Width = 41;
            gridViewTextBoxColumn11.FieldName = "PeriodName";
            gridViewTextBoxColumn11.HeaderText = "Період";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "PeriodName";
            gridViewTextBoxColumn11.Width = 90;
            gridViewDateTimeColumn3.FieldName = "CreateDate";
            gridViewDateTimeColumn3.HeaderText = "Дата створення";
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.Name = "CreateDate";
            gridViewDateTimeColumn3.Width = 103;
            gridViewTextBoxColumn12.FieldName = "UserWho";
            gridViewTextBoxColumn12.HeaderText = "Хто прийняв";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "UserWho";
            gridViewTextBoxColumn12.Width = 128;
            gridViewDecimalColumn16.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn16.FieldName = "CountItem";
            gridViewDecimalColumn16.HeaderText = "К-ть записів";
            gridViewDecimalColumn16.IsAutoGenerated = true;
            gridViewDecimalColumn16.Name = "CountItem";
            gridViewDecimalColumn16.Width = 45;
            gridViewDecimalColumn17.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn17.FieldName = "CountNoFound";
            gridViewDecimalColumn17.HeaderText = "К-ть не знайдених";
            gridViewDecimalColumn17.IsAutoGenerated = true;
            gridViewDecimalColumn17.Name = "CountNoFound";
            gridViewDecimalColumn17.Width = 45;
            gridViewDecimalColumn18.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn18.FieldName = "CRightCode";
            gridViewDecimalColumn18.HeaderText = "Код виду права";
            gridViewDecimalColumn18.IsAutoGenerated = true;
            gridViewDecimalColumn18.Name = "CRightCode";
            gridViewDecimalColumn18.Width = 45;
            gridViewTextBoxColumn13.FieldName = "RgStatusName";
            gridViewTextBoxColumn13.HeaderText = "Статус";
            gridViewTextBoxColumn13.IsAutoGenerated = true;
            gridViewTextBoxColumn13.Name = "RgStatusName";
            gridViewTextBoxColumn13.Width = 90;
            gridViewTextBoxColumn14.FieldName = "CustName";
            gridViewTextBoxColumn14.HeaderText = "Користувач";
            gridViewTextBoxColumn14.IsAutoGenerated = true;
            gridViewTextBoxColumn14.Name = "CustName";
            gridViewTextBoxColumn14.Width = 204;
            gridViewDecimalColumn19.DataType = typeof(int);
            gridViewDecimalColumn19.FieldName = "RgStatus";
            gridViewDecimalColumn19.HeaderText = "RgStatus";
            gridViewDecimalColumn19.IsAutoGenerated = true;
            gridViewDecimalColumn19.IsVisible = false;
            gridViewDecimalColumn19.Name = "RgStatus";
            gridViewDecimalColumn19.Width = 57;
            gridViewTextBoxColumn15.FieldName = "CRightName";
            gridViewTextBoxColumn15.HeaderText = "CRightName";
            gridViewTextBoxColumn15.IsAutoGenerated = true;
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "CRightName";
            gridViewTextBoxColumn15.Width = 52;
            gridViewDecimalColumn20.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn20.FieldName = "PeriodId";
            gridViewDecimalColumn20.HeaderText = "PeriodId";
            gridViewDecimalColumn20.IsAutoGenerated = true;
            gridViewDecimalColumn20.IsVisible = false;
            gridViewDecimalColumn20.Name = "PeriodId";
            gridViewDecimalColumn20.Width = 48;
            gridViewDecimalColumn21.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn21.FieldName = "CustId";
            gridViewDecimalColumn21.HeaderText = "CustId";
            gridViewDecimalColumn21.IsAutoGenerated = true;
            gridViewDecimalColumn21.IsVisible = false;
            gridViewDecimalColumn21.Name = "CustId";
            gridViewDecimalColumn21.Width = 63;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.DefaultText = "Редагувати";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn3.MaxWidth = 30;
            gridViewCommandColumn3.MinWidth = 30;
            gridViewCommandColumn3.Name = "EditColumn";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 30;
            this.gvRegisterList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn15,
            gridViewTextBoxColumn11,
            gridViewDateTimeColumn3,
            gridViewTextBoxColumn12,
            gridViewDecimalColumn16,
            gridViewDecimalColumn17,
            gridViewDecimalColumn18,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewDecimalColumn19,
            gridViewTextBoxColumn15,
            gridViewDecimalColumn20,
            gridViewDecimalColumn21,
            gridViewCommandColumn3});
            this.gvRegisterList.MasterTemplate.DataSource = this.registerListViewModelBindingSource;
            this.gvRegisterList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRegisterList.MasterTemplate.EnableFiltering = true;
            this.gvRegisterList.MasterTemplate.ShowFilteringRow = false;
            this.gvRegisterList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRegisterList.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gvRegisterList.Name = "gvRegisterList";
            this.gvRegisterList.ShowGroupPanel = false;
            this.gvRegisterList.Size = new System.Drawing.Size(814, 272);
            this.gvRegisterList.TabIndex = 27;
            this.gvRegisterList.ThemeName = "Office2013Light";
            this.gvRegisterList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRegisterList_CellDoubleClick);
            this.gvRegisterList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRegisterList_CommandCellClick);
            this.gvRegisterList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvRegisterList_CustomFiltering);
            this.gvRegisterList.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvRegisterList_ToolTipTextNeeded);
            // 
            // registerListViewModelBindingSource
            // 
            this.registerListViewModelBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterListViewModel);
            // 
            // dtCreateDateFrom
            // 
            this.dtCreateDateFrom.Culture = new System.Globalization.CultureInfo("uk-UA");
            this.dtCreateDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreateDateFrom.Location = new System.Drawing.Point(222, 4);
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
            this.radLabel1.Location = new System.Drawing.Point(124, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(95, 19);
            this.radLabel1.TabIndex = 29;
            this.radLabel1.Text = "Дата створення";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(350, 5);
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
            this.dtCreateDateTill.Location = new System.Drawing.Point(367, 4);
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
            this.btnClearFrom.Location = new System.Drawing.Point(321, 4);
            this.btnClearFrom.Name = "btnClearFrom";
            this.btnClearFrom.Size = new System.Drawing.Size(23, 21);
            this.btnClearFrom.TabIndex = 31;
            this.btnClearFrom.Text = "X";
            this.btnClearFrom.ThemeName = "Office2013Light";
            this.btnClearFrom.Click += new System.EventHandler(this.btnClearFrom_Click);
            // 
            // btnClearTill
            // 
            this.btnClearTill.Location = new System.Drawing.Point(466, 4);
            this.btnClearTill.Name = "btnClearTill";
            this.btnClearTill.Size = new System.Drawing.Size(23, 21);
            this.btnClearTill.TabIndex = 32;
            this.btnClearTill.Text = "X";
            this.btnClearTill.ThemeName = "Office2013Light";
            this.btnClearTill.Click += new System.EventHandler(this.btnClearTill_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(512, 5);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(42, 19);
            this.radLabel3.TabIndex = 30;
            this.radLabel3.Text = "Статус";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlStatus.Location = new System.Drawing.Point(560, 5);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(257, 21);
            this.ddlStatus.TabIndex = 33;
            this.ddlStatus.ThemeName = "Office2013Light";
            this.ddlStatus.SelectedValueChanged += new System.EventHandler(this.ddlStatus_SelectedValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 21);
            this.btnRefresh.TabIndex = 34;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.ThemeName = "Office2013Light";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCountRegister
            // 
            this.lblCountRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountRegister.Location = new System.Drawing.Point(745, 330);
            this.lblCountRegister.Name = "lblCountRegister";
            this.lblCountRegister.Size = new System.Drawing.Size(73, 13);
            this.lblCountRegister.TabIndex = 35;
            this.lblCountRegister.Text = "0";
            this.lblCountRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCountTextRegister
            // 
            this.lblCountTextRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountTextRegister.Location = new System.Drawing.Point(660, 330);
            this.lblCountTextRegister.Name = "lblCountTextRegister";
            this.lblCountTextRegister.Size = new System.Drawing.Size(79, 13);
            this.lblCountTextRegister.TabIndex = 36;
            this.lblCountTextRegister.Text = "К-ть рядків";
            this.lblCountTextRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RegisterListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCountTextRegister);
            this.Controls.Add(this.lblCountRegister);
            this.Controls.Add(this.btnRefresh);
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
            this.Size = new System.Drawing.Size(821, 350);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegisterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerListViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDateTill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearTill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private System.Windows.Forms.Label lblCountRegister;
        private System.Windows.Forms.Label lblCountTextRegister;
    }
}
