using IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    partial class LicenseAgreementNotActiveControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvMoreLicenseAgr = new Telerik.WinControls.UI.RadGridView();
            this.bsGridLicenseAgreementViewNotActive = new System.Windows.Forms.BindingSource(this.components);
            this.ipsPanel2 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.btnAddNewAgrMore = new Telerik.WinControls.UI.RadButton();
            this.ddBtnChangeStatusMore = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnAccept = new Telerik.WinControls.UI.RadMenuItem();
            this.btnDenied = new Telerik.WinControls.UI.RadMenuItem();
            this.ctrlAgrDetailInfoMore = new IpsViewComponentLibrary.ConsumerControls.ConsumerAgrDetailInfo();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoreLicenseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoreLicenseAgr.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridLicenseAgreementViewNotActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel2)).BeginInit();
            this.ipsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewAgrMore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnChangeStatusMore)).BeginInit();
            this.SuspendLayout();
            // 
            // gvMoreLicenseAgr
            // 
            this.gvMoreLicenseAgr.AutoScroll = true;
            this.gvMoreLicenseAgr.AutoSizeRows = true;
            this.gvMoreLicenseAgr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMoreLicenseAgr.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvMoreLicenseAgr.MasterTemplate.AllowAddNewRow = false;
            this.gvMoreLicenseAgr.MasterTemplate.AllowDeleteRow = false;
            this.gvMoreLicenseAgr.MasterTemplate.AllowDragToGroup = false;
            this.gvMoreLicenseAgr.MasterTemplate.AllowEditRow = false;
            this.gvMoreLicenseAgr.MasterTemplate.AutoGenerateColumns = false;
            this.gvMoreLicenseAgr.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 48;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.FieldName = "License";
            gridViewTextBoxColumn2.HeaderText = "Ліцензія";
            gridViewTextBoxColumn2.MinWidth = 180;
            gridViewTextBoxColumn2.Name = "License";
            gridViewTextBoxColumn2.Width = 180;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Series";
            gridViewTextBoxColumn3.HeaderText = "Серія";
            gridViewTextBoxColumn3.MinWidth = 80;
            gridViewTextBoxColumn3.Name = "Series";
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "AgrMasterNumber";
            gridViewTextBoxColumn4.HeaderText = "Номер майстер договору";
            gridViewTextBoxColumn4.MinWidth = 105;
            gridViewTextBoxColumn4.Name = "AgrMasterNumber";
            gridViewTextBoxColumn4.Width = 105;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "AgrNumber";
            gridViewTextBoxColumn5.HeaderText = "Номер договору-версії";
            gridViewTextBoxColumn5.MinWidth = 105;
            gridViewTextBoxColumn5.Name = "AgrNumber";
            gridViewTextBoxColumn5.Width = 105;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "DateBegin";
            gridViewTextBoxColumn6.HeaderText = "Дата початку";
            gridViewTextBoxColumn6.MaxWidth = 80;
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Name = "DateBegin";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "DateEnd";
            gridViewTextBoxColumn7.HeaderText = "Дата завершення";
            gridViewTextBoxColumn7.MaxWidth = 80;
            gridViewTextBoxColumn7.MinWidth = 80;
            gridViewTextBoxColumn7.Name = "DateEnd";
            gridViewTextBoxColumn7.Width = 80;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.DataType = typeof(decimal);
            gridViewTextBoxColumn8.FieldName = "MinRate";
            gridViewTextBoxColumn8.FormatString = "{0:##0.00}";
            gridViewTextBoxColumn8.HeaderText = "Тариф";
            gridViewTextBoxColumn8.MaxWidth = 90;
            gridViewTextBoxColumn8.MinWidth = 90;
            gridViewTextBoxColumn8.Name = "MinRate";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 90;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.DataType = typeof(decimal);
            gridViewTextBoxColumn9.FieldName = "MinAmount";
            gridViewTextBoxColumn9.FormatString = "{0:### ### ##0.00}";
            gridViewTextBoxColumn9.HeaderText = "Гарантійний платіж";
            gridViewTextBoxColumn9.MaxWidth = 100;
            gridViewTextBoxColumn9.MinWidth = 90;
            gridViewTextBoxColumn9.Name = "MinAmount";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn9.Width = 90;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.FieldName = "PeriodPayment";
            gridViewTextBoxColumn10.HeaderText = "Періодичність звітності";
            gridViewTextBoxColumn10.MaxWidth = 100;
            gridViewTextBoxColumn10.MinWidth = 100;
            gridViewTextBoxColumn10.Name = "PeriodPayment";
            gridViewTextBoxColumn10.Width = 100;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewTextBoxColumn11.FieldName = "State";
            gridViewTextBoxColumn11.HeaderText = "Статус";
            gridViewTextBoxColumn11.MaxWidth = 150;
            gridViewTextBoxColumn11.MinWidth = 100;
            gridViewTextBoxColumn11.Name = "State";
            gridViewTextBoxColumn11.Width = 100;
            gridViewTextBoxColumn11.WrapText = true;
            gridViewCheckBoxColumn1.FieldName = "IsAutoprolog";
            gridViewCheckBoxColumn1.HeaderText = "а-п";
            gridViewCheckBoxColumn1.MaxWidth = 30;
            gridViewCheckBoxColumn1.MinWidth = 30;
            gridViewCheckBoxColumn1.Name = "IsAutoprolog";
            gridViewCheckBoxColumn1.Width = 30;
            gridViewCommandColumn1.FieldName = "printBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "printBtn";
            gridViewCommandColumn1.Width = 30;
            gridViewCommandColumn2.FieldName = "editBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "editBtn";
            gridViewCommandColumn2.Width = 30;
            gridViewCommandColumn3.FieldName = "deleteBtn";
            gridViewCommandColumn3.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.MaxWidth = 30;
            gridViewCommandColumn3.MinWidth = 30;
            gridViewCommandColumn3.Name = "deleteBtn";
            gridViewCommandColumn3.Width = 30;
            this.gvMoreLicenseAgr.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewCheckBoxColumn1,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3});
            this.gvMoreLicenseAgr.MasterTemplate.DataSource = this.bsGridLicenseAgreementViewNotActive;
            this.gvMoreLicenseAgr.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvMoreLicenseAgr.MinimumSize = new System.Drawing.Size(300, 100);
            this.gvMoreLicenseAgr.Name = "gvMoreLicenseAgr";
            this.gvMoreLicenseAgr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvMoreLicenseAgr.ReadOnly = true;
            // 
            // 
            // 
            this.gvMoreLicenseAgr.RootElement.MinSize = new System.Drawing.Size(300, 100);
            this.gvMoreLicenseAgr.ShowGroupPanel = false;
            this.gvMoreLicenseAgr.Size = new System.Drawing.Size(924, 239);
            this.gvMoreLicenseAgr.TabIndex = 2;
            this.gvMoreLicenseAgr.ThemeName = "Office2013Light";
            this.gvMoreLicenseAgr.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvMoreLicenseAgr_CurrentRowChanged);
            this.gvMoreLicenseAgr.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvMoreLicenseAgr_CommandCellClick);
            // 
            // bsGridLicenseAgreementViewNotActive
            // 
            this.bsGridLicenseAgreementViewNotActive.DataSource = typeof(IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel.GridLicenseAgreementView);
            // 
            // ipsPanel2
            // 
            this.ipsPanel2.BorderVisible = false;
            this.ipsPanel2.Controls.Add(this.btnAddNewAgrMore);
            this.ipsPanel2.Controls.Add(this.ddBtnChangeStatusMore);
            this.ipsPanel2.Controls.Add(this.ctrlAgrDetailInfoMore);
            this.ipsPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipsPanel2.Location = new System.Drawing.Point(0, 239);
            this.ipsPanel2.Name = "ipsPanel2";
            this.ipsPanel2.Size = new System.Drawing.Size(924, 261);
            this.ipsPanel2.TabIndex = 3;
            this.ipsPanel2.ThemeName = "Office2013Light";
            // 
            // btnAddNewAgrMore
            // 
            this.btnAddNewAgrMore.Location = new System.Drawing.Point(3, 8);
            this.btnAddNewAgrMore.Name = "btnAddNewAgrMore";
            this.btnAddNewAgrMore.Size = new System.Drawing.Size(140, 24);
            this.btnAddNewAgrMore.TabIndex = 0;
            this.btnAddNewAgrMore.Text = "Додати новий договір";
            this.btnAddNewAgrMore.TextWrap = true;
            this.btnAddNewAgrMore.ThemeName = "Office2013Light";
            this.btnAddNewAgrMore.Click += new System.EventHandler(this.btnAddNewAgrMore_Click);
            // 
            // ddBtnChangeStatusMore
            // 
            this.ddBtnChangeStatusMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddBtnChangeStatusMore.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAccept,
            this.btnDenied});
            this.ddBtnChangeStatusMore.Location = new System.Drawing.Point(781, 8);
            this.ddBtnChangeStatusMore.Name = "ddBtnChangeStatusMore";
            this.ddBtnChangeStatusMore.Size = new System.Drawing.Size(140, 24);
            this.ddBtnChangeStatusMore.TabIndex = 1;
            this.ddBtnChangeStatusMore.Text = "Змінити статус";
            this.ddBtnChangeStatusMore.ThemeName = "Office2013Light";
            // 
            // btnAccept
            // 
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Text = "Підтвердити договір";
            this.btnAccept.UseCompatibleTextRendering = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDenied
            // 
            this.btnDenied.Name = "btnDenied";
            this.btnDenied.Text = "Відхилити договір";
            this.btnDenied.UseCompatibleTextRendering = false;
            this.btnDenied.Click += new System.EventHandler(this.btnDenied_Click);
            // 
            // ctrlAgrDetailInfoMore
            // 
            this.ctrlAgrDetailInfoMore.Location = new System.Drawing.Point(3, 38);
            this.ctrlAgrDetailInfoMore.MinimumSize = new System.Drawing.Size(785, 220);
            this.ctrlAgrDetailInfoMore.Name = "ctrlAgrDetailInfoMore";
            this.ctrlAgrDetailInfoMore.Size = new System.Drawing.Size(785, 220);
            this.ctrlAgrDetailInfoMore.TabIndex = 2;
            // 
            // LicenseAgreementNotActiveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvMoreLicenseAgr);
            this.Controls.Add(this.ipsPanel2);
            this.Name = "LicenseAgreementNotActiveControl";
            this.Size = new System.Drawing.Size(924, 500);
            ((System.ComponentModel.ISupportInitialize)(this.gvMoreLicenseAgr.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoreLicenseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridLicenseAgreementViewNotActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel2)).EndInit();
            this.ipsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewAgrMore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnChangeStatusMore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvMoreLicenseAgr;
        private Common.Editors.IpsPanel ipsPanel2;
        private Telerik.WinControls.UI.RadButton btnAddNewAgrMore;
        private Telerik.WinControls.UI.RadDropDownButton ddBtnChangeStatusMore;
        private Telerik.WinControls.UI.RadMenuItem btnAccept;
        private Telerik.WinControls.UI.RadMenuItem btnDenied;
        private ConsumerAgrDetailInfo ctrlAgrDetailInfoMore;
        private System.Windows.Forms.BindingSource bsGridLicenseAgreementViewNotActive;
    }
}
