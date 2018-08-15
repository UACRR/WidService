namespace IpsViewComponentLibrary
{
    partial class LicenseAgreementListControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseAgreementListControl));
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.gvLicenseAgreementList = new Telerik.WinControls.UI.RadGridView();
            this.bsBigRightRequests = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chddlState = new Telerik.WinControls.UI.RadCheckedDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgreementList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgreementList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBigRightRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chddlState)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(141, 28);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(33, 19);
            this.radLabel3.TabIndex = 40;
            this.radLabel3.Text = "Стан";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 21);
            this.btnRefresh.TabIndex = 39;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.ThemeName = "Office2013Light";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gvLicenseAgreementList
            // 
            this.gvLicenseAgreementList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvLicenseAgreementList.BackColor = System.Drawing.SystemColors.Control;
            this.gvLicenseAgreementList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvLicenseAgreementList.EnableCustomFiltering = true;
            this.gvLicenseAgreementList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvLicenseAgreementList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gvLicenseAgreementList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvLicenseAgreementList.Location = new System.Drawing.Point(2, 55);
            // 
            // 
            // 
            this.gvLicenseAgreementList.MasterTemplate.AllowAddNewRow = false;
            this.gvLicenseAgreementList.MasterTemplate.AutoGenerateColumns = false;
            this.gvLicenseAgreementList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Name";
            gridViewTextBoxColumn1.HeaderText = "Споживач";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 144;
            gridViewDecimalColumn1.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "Objid";
            gridViewDecimalColumn1.HeaderText = "Номер вистави";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "Objid";
            gridViewDecimalColumn1.Width = 52;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ObjName";
            gridViewTextBoxColumn2.HeaderText = "Назва вистави";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "ObjName";
            gridViewTextBoxColumn2.Width = 123;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "LicNum";
            gridViewTextBoxColumn3.HeaderText = "№ ЛД";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "LicNum";
            gridViewTextBoxColumn3.Width = 61;
            gridViewDateTimeColumn1.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "LicDate";
            gridViewDateTimeColumn1.HeaderText = "Дата ЛД";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.Name = "LicDate";
            gridViewDateTimeColumn1.Width = 46;
            gridViewDateTimeColumn2.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "DatePremiere";
            gridViewDateTimeColumn2.HeaderText = "Дата прем\'єри";
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.Name = "DatePremiere";
            gridViewDateTimeColumn2.Width = 52;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "LicTypeName";
            gridViewTextBoxColumn4.HeaderText = "Стан";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "LicTypeName";
            gridViewTextBoxColumn4.Width = 41;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "LicStatusName";
            gridViewTextBoxColumn5.HeaderText = "Статус";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "LicStatusName";
            gridViewTextBoxColumn5.Width = 41;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Код виду права";
            gridViewTextBoxColumn6.Name = "column1";
            gridViewTextBoxColumn6.Width = 25;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Хто прийняв";
            gridViewTextBoxColumn7.Name = "column2";
            gridViewTextBoxColumn7.Width = 108;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Показати об\'єкт права";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "ShowObjectColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Редагувати";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "EditColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 30;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "LicId";
            gridViewDecimalColumn2.HeaderText = "LicId";
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Name = "LicId";
            this.gvLicenseAgreementList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewDecimalColumn2});
            this.gvLicenseAgreementList.MasterTemplate.DataSource = this.bsBigRightRequests;
            this.gvLicenseAgreementList.MasterTemplate.EnableCustomFiltering = true;
            this.gvLicenseAgreementList.MasterTemplate.EnableFiltering = true;
            this.gvLicenseAgreementList.MasterTemplate.ShowFilteringRow = false;
            this.gvLicenseAgreementList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvLicenseAgreementList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvLicenseAgreementList.Name = "gvLicenseAgreementList";
            this.gvLicenseAgreementList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvLicenseAgreementList.ReadOnly = true;
            this.gvLicenseAgreementList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvLicenseAgreementList.ShowGroupPanel = false;
            this.gvLicenseAgreementList.Size = new System.Drawing.Size(744, 342);
            this.gvLicenseAgreementList.TabIndex = 38;
            this.gvLicenseAgreementList.ThemeName = "Office2013Light";
            this.gvLicenseAgreementList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvLicenseAgreementList_CellDoubleClick);
            this.gvLicenseAgreementList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvLicenseAgreementList_CommandCellClick);
            this.gvLicenseAgreementList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvLicenseAgreementList_CustomFiltering);
            this.gvLicenseAgreementList.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvLicenseAgreementList_ToolTipTextNeeded);
            // 
            // bsBigRightRequests
            // 
            this.bsBigRightRequests.DataSource = typeof(ipsFormsDesign.Interfaces.BigRightRequests);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(188, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(558, 21);
            this.txtSearch.TabIndex = 37;
            this.txtSearch.ThemeName = "Office2013Light";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(136, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 19);
            this.radLabel1.TabIndex = 36;
            this.radLabel1.Text = "Пошук";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlStatus.Location = new System.Drawing.Point(543, 28);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(203, 21);
            this.ddlStatus.TabIndex = 43;
            this.ddlStatus.ThemeName = "Office2013Light";
            this.ddlStatus.SelectedValueChanged += new System.EventHandler(this.ddlStatus_SelectedValueChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(496, 28);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(42, 19);
            this.radLabel2.TabIndex = 42;
            this.radLabel2.Text = "Статус";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // chddlState
            // 
            this.chddlState.Location = new System.Drawing.Point(188, 28);
            this.chddlState.Name = "chddlState";
            this.chddlState.ShowCheckAllItems = true;
            this.chddlState.Size = new System.Drawing.Size(302, 21);
            this.chddlState.TabIndex = 44;
            this.chddlState.ThemeName = "Office2013Light";
            this.chddlState.PopupClosed += new Telerik.WinControls.UI.RadPopupClosedEventHandler(this.chddlState_PopupClosed);
            // 
            // LicenseAgreementListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chddlState);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gvLicenseAgreementList);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.radLabel1);
            this.Name = "LicenseAgreementListControl";
            this.Size = new System.Drawing.Size(749, 400);
            this.Load += new System.EventHandler(this.LicenseAgreementListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgreementList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgreementList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBigRightRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chddlState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadGridView gvLicenseAgreementList;
        private Telerik.WinControls.UI.RadTextBox txtSearch;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlStatus;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.BindingSource bsBigRightRequests;
        private Telerik.WinControls.UI.RadCheckedDropDownList chddlState;
    }
}
