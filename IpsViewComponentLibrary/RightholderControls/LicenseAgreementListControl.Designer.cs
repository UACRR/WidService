namespace IpsViewComponentLibrary.RightholderControls
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn4 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseAgreementListControl));
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.gvLicenseAgreementList = new Telerik.WinControls.UI.RadGridView();
            this.bsBigRightRequests = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chddlState = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.lblCountAgreements = new System.Windows.Forms.Label();
            this.lblCountTextAgreements = new System.Windows.Forms.Label();
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
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Name";
            gridViewTextBoxColumn8.HeaderText = "Споживач";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "Name";
            gridViewTextBoxColumn8.Width = 144;
            gridViewDecimalColumn3.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "Objid";
            gridViewDecimalColumn3.HeaderText = "Номер вистави";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "Objid";
            gridViewDecimalColumn3.Width = 52;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "ObjName";
            gridViewTextBoxColumn9.HeaderText = "Назва вистави";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "ObjName";
            gridViewTextBoxColumn9.Width = 123;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "LicNum";
            gridViewTextBoxColumn10.HeaderText = "№ ЛД";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.Name = "LicNum";
            gridViewTextBoxColumn10.Width = 61;
            gridViewDateTimeColumn3.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.FieldName = "LicDate";
            gridViewDateTimeColumn3.HeaderText = "Дата ЛД";
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.Name = "LicDate";
            gridViewDateTimeColumn3.Width = 46;
            gridViewDateTimeColumn4.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn4.EnableExpressionEditor = false;
            gridViewDateTimeColumn4.FieldName = "DatePremiere";
            gridViewDateTimeColumn4.HeaderText = "Дата прем\'єри";
            gridViewDateTimeColumn4.IsAutoGenerated = true;
            gridViewDateTimeColumn4.Name = "DatePremiere";
            gridViewDateTimeColumn4.Width = 52;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "LicTypeName";
            gridViewTextBoxColumn11.HeaderText = "Стан";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "LicTypeName";
            gridViewTextBoxColumn11.Width = 41;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "LicStatusName";
            gridViewTextBoxColumn12.HeaderText = "Статус";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "LicStatusName";
            gridViewTextBoxColumn12.Width = 41;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.HeaderText = "Код виду права";
            gridViewTextBoxColumn13.Name = "column1";
            gridViewTextBoxColumn13.Width = 25;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.HeaderText = "Хто прийняв";
            gridViewTextBoxColumn14.Name = "column2";
            gridViewTextBoxColumn14.Width = 108;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.DefaultText = "Показати об\'єкт права";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn3.Image")));
            gridViewCommandColumn3.MaxWidth = 30;
            gridViewCommandColumn3.MinWidth = 30;
            gridViewCommandColumn3.Name = "ShowObjectColumn";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.Width = 30;
            gridViewCommandColumn4.AllowResize = false;
            gridViewCommandColumn4.DefaultText = "Редагувати";
            gridViewCommandColumn4.EnableExpressionEditor = false;
            gridViewCommandColumn4.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn4.Image")));
            gridViewCommandColumn4.MaxWidth = 30;
            gridViewCommandColumn4.MinWidth = 30;
            gridViewCommandColumn4.Name = "EditColumn";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.Width = 30;
            gridViewDecimalColumn4.DataType = typeof(int);
            gridViewDecimalColumn4.FieldName = "LicId";
            gridViewDecimalColumn4.HeaderText = "LicId";
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "LicId";
            this.gvLicenseAgreementList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewDateTimeColumn3,
            gridViewDateTimeColumn4,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewCommandColumn3,
            gridViewCommandColumn4,
            gridViewDecimalColumn4});
            this.gvLicenseAgreementList.MasterTemplate.DataSource = this.bsBigRightRequests;
            this.gvLicenseAgreementList.MasterTemplate.EnableCustomFiltering = true;
            this.gvLicenseAgreementList.MasterTemplate.EnableFiltering = true;
            this.gvLicenseAgreementList.MasterTemplate.ShowFilteringRow = false;
            this.gvLicenseAgreementList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvLicenseAgreementList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvLicenseAgreementList.Name = "gvLicenseAgreementList";
            this.gvLicenseAgreementList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvLicenseAgreementList.ReadOnly = true;
            this.gvLicenseAgreementList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvLicenseAgreementList.ShowGroupPanel = false;
            this.gvLicenseAgreementList.Size = new System.Drawing.Size(744, 324);
            this.gvLicenseAgreementList.TabIndex = 38;
            this.gvLicenseAgreementList.ThemeName = "Office2013Light";
            this.gvLicenseAgreementList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvLicenseAgreementList_CellDoubleClick);
            this.gvLicenseAgreementList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvLicenseAgreementList_CommandCellClick);
            this.gvLicenseAgreementList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvLicenseAgreementList_CustomFiltering);
            this.gvLicenseAgreementList.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvLicenseAgreementList_ToolTipTextNeeded);
            // 
            // bsBigRightRequests
            // 
            this.bsBigRightRequests.DataSource = typeof(ipsFormsDesign.Interfaces.RequestsOrReferenceBigRightView);
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
            // lblCountAgreements
            // 
            this.lblCountAgreements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountAgreements.Location = new System.Drawing.Point(673, 382);
            this.lblCountAgreements.Name = "lblCountAgreements";
            this.lblCountAgreements.Size = new System.Drawing.Size(73, 13);
            this.lblCountAgreements.TabIndex = 45;
            this.lblCountAgreements.Text = "0";
            this.lblCountAgreements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCountTextAgreements
            // 
            this.lblCountTextAgreements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountTextAgreements.Location = new System.Drawing.Point(588, 382);
            this.lblCountTextAgreements.Name = "lblCountTextAgreements";
            this.lblCountTextAgreements.Size = new System.Drawing.Size(79, 13);
            this.lblCountTextAgreements.TabIndex = 46;
            this.lblCountTextAgreements.Text = "К-ть рядків";
            this.lblCountTextAgreements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LicenseAgreementListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCountTextAgreements);
            this.Controls.Add(this.lblCountAgreements);
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
        private System.Windows.Forms.Label lblCountAgreements;
        private System.Windows.Forms.Label lblCountTextAgreements;
    }
}
