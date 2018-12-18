using System.Drawing;

namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetLicenses
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewLicences = new Telerik.WinControls.UI.RadGridView();
            this.separator = new Telerik.WinControls.UI.RadSeparator();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadButton();
            this.btnToProlongation = new Telerik.WinControls.UI.RadButton();
            this.btnToAccept = new Telerik.WinControls.UI.RadButton();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvInformation = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgrDetailInfo = new IpsViewComponentLibrary.ConsumerControls.BigRight.AgrDetailInfoBr();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvHistory = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.ctrlAgrInfo = new IpsViewComponentLibrary.GeneralAgreementInfo();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewLicences
            // 
            this.gvViewLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewLicences.AutoSizeRows = true;
            this.gvViewLicences.EnableCustomFiltering = true;
            this.gvViewLicences.Location = new System.Drawing.Point(3, 131);
            // 
            // 
            // 
            this.gvViewLicences.MasterTemplate.AllowAddNewRow = false;
            this.gvViewLicences.MasterTemplate.AllowDeleteRow = false;
            this.gvViewLicences.MasterTemplate.AllowDragToGroup = false;
            this.gvViewLicences.MasterTemplate.AllowEditRow = false;
            this.gvViewLicences.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewLicences.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn12.DataType = typeof(int);
            gridViewTextBoxColumn12.FieldName = "CustId";
            gridViewTextBoxColumn12.HeaderText = "ID";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "CustId";
            gridViewTextBoxColumn13.FieldName = "AgrNumber";
            gridViewTextBoxColumn13.HeaderText = "Код вистави";
            gridViewTextBoxColumn13.MaxWidth = 75;
            gridViewTextBoxColumn13.MinWidth = 75;
            gridViewTextBoxColumn13.Multiline = true;
            gridViewTextBoxColumn13.Name = "AgrNumber";
            gridViewTextBoxColumn13.Width = 75;
            gridViewTextBoxColumn13.WrapText = true;
            gridViewTextBoxColumn14.FieldName = "ObjName";
            gridViewTextBoxColumn14.HeaderText = "Назва вистави";
            gridViewTextBoxColumn14.MinWidth = 0;
            gridViewTextBoxColumn14.Multiline = true;
            gridViewTextBoxColumn14.Name = "ObjName";
            gridViewTextBoxColumn14.Width = 194;
            gridViewTextBoxColumn14.WrapText = true;
            gridViewTextBoxColumn15.FieldName = "LicNum";
            gridViewTextBoxColumn15.HeaderText = "№ ліцензійного договору";
            gridViewTextBoxColumn15.MaxWidth = 100;
            gridViewTextBoxColumn15.MinWidth = 80;
            gridViewTextBoxColumn15.Multiline = true;
            gridViewTextBoxColumn15.Name = "LicNum";
            gridViewTextBoxColumn15.Width = 100;
            gridViewTextBoxColumn15.WrapText = true;
            gridViewTextBoxColumn16.FieldName = "LicDate";
            gridViewTextBoxColumn16.FormatString = "{0:d}";
            gridViewTextBoxColumn16.HeaderText = "Дата договору";
            gridViewTextBoxColumn16.MaxWidth = 75;
            gridViewTextBoxColumn16.MinWidth = 75;
            gridViewTextBoxColumn16.Multiline = true;
            gridViewTextBoxColumn16.Name = "LicDate";
            gridViewTextBoxColumn16.Width = 75;
            gridViewTextBoxColumn16.WrapText = true;
            gridViewTextBoxColumn17.FieldName = "Rate";
            gridViewTextBoxColumn17.HeaderText = "АВ%";
            gridViewTextBoxColumn17.MaxWidth = 45;
            gridViewTextBoxColumn17.MinWidth = 45;
            gridViewTextBoxColumn17.Multiline = true;
            gridViewTextBoxColumn17.Name = "Rate";
            gridViewTextBoxColumn17.Width = 45;
            gridViewTextBoxColumn17.WrapText = true;
            gridViewTextBoxColumn18.FieldName = "LicDateBegin";
            gridViewTextBoxColumn18.FormatString = "{0:d}";
            gridViewTextBoxColumn18.HeaderText = "Дата початку ліцензії";
            gridViewTextBoxColumn18.MaxWidth = 75;
            gridViewTextBoxColumn18.MinWidth = 75;
            gridViewTextBoxColumn18.Multiline = true;
            gridViewTextBoxColumn18.Name = "LicDateBegin";
            gridViewTextBoxColumn18.Width = 75;
            gridViewTextBoxColumn18.WrapText = true;
            gridViewTextBoxColumn19.FieldName = "LicDateEnd";
            gridViewTextBoxColumn19.FormatString = "{0:d}";
            gridViewTextBoxColumn19.HeaderText = "Дата закриття ліцензії";
            gridViewTextBoxColumn19.MaxWidth = 75;
            gridViewTextBoxColumn19.MinWidth = 75;
            gridViewTextBoxColumn19.Multiline = true;
            gridViewTextBoxColumn19.Name = "LicDateEnd";
            gridViewTextBoxColumn19.Width = 75;
            gridViewTextBoxColumn19.WrapText = true;
            gridViewTextBoxColumn20.FieldName = "Borg";
            gridViewTextBoxColumn20.HeaderText = "Заборгованість";
            gridViewTextBoxColumn20.MaxWidth = 95;
            gridViewTextBoxColumn20.MinWidth = 95;
            gridViewTextBoxColumn20.Name = "Borg";
            gridViewTextBoxColumn20.Width = 95;
            gridViewTextBoxColumn21.FieldName = "prepayAvans";
            gridViewTextBoxColumn21.HeaderText = "Аванс";
            gridViewTextBoxColumn21.MaxWidth = 95;
            gridViewTextBoxColumn21.MinWidth = 95;
            gridViewTextBoxColumn21.Multiline = true;
            gridViewTextBoxColumn21.Name = "prepayAvans";
            gridViewTextBoxColumn21.Width = 95;
            gridViewTextBoxColumn21.WrapText = true;
            gridViewTextBoxColumn22.FieldName = "LicStatusName";
            gridViewTextBoxColumn22.HeaderText = "Статус ліцензії";
            gridViewTextBoxColumn22.MaxWidth = 90;
            gridViewTextBoxColumn22.MinWidth = 90;
            gridViewTextBoxColumn22.Name = "LicStatusName";
            gridViewTextBoxColumn22.Width = 90;
            gridViewCommandColumn3.FieldName = "viewBtn";
            gridViewCommandColumn3.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.MaxWidth = 30;
            gridViewCommandColumn3.MinWidth = 30;
            gridViewCommandColumn3.Name = "viewBtn";
            gridViewCommandColumn3.Width = 30;
            gridViewCommandColumn4.FieldName = "printBtn";
            gridViewCommandColumn4.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Image = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn4.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.MaxWidth = 30;
            gridViewCommandColumn4.MinWidth = 30;
            gridViewCommandColumn4.Name = "printBtn";
            gridViewCommandColumn4.Width = 30;
            this.gvViewLicences.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.gvViewLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableGrouping = false;
            this.gvViewLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvViewLicences.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvViewLicences.Name = "gvViewLicences";
            this.gvViewLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewLicences.Size = new System.Drawing.Size(994, 182);
            this.gvViewLicences.TabIndex = 7;
            this.gvViewLicences.ThemeName = "Office2013Light";
            this.gvViewLicences.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvViewLicences_CurrentRowChanged);
            this.gvViewLicences.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewLicences_CommandCellClick);
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.Location = new System.Drawing.Point(3, 85);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(994, 14);
            this.separator.TabIndex = 8;
            this.separator.ThemeName = "Office2013Light";
            // 
            // btnCloseAgr
            // 
            this.btnCloseAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAgr.Location = new System.Drawing.Point(819, 47);
            this.btnCloseAgr.Name = "btnCloseAgr";
            this.btnCloseAgr.Size = new System.Drawing.Size(95, 40);
            this.btnCloseAgr.TabIndex = 9;
            this.btnCloseAgr.Text = "Закрити ліцензію";
            this.btnCloseAgr.TextWrap = true;
            this.btnCloseAgr.ThemeName = "Office2013Light";
            this.btnCloseAgr.Click += new System.EventHandler(this.btnCloseAgr_Click);
            // 
            // btnToProlongation
            // 
            this.btnToProlongation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToProlongation.Location = new System.Drawing.Point(819, 0);
            this.btnToProlongation.Name = "btnToProlongation";
            this.btnToProlongation.Size = new System.Drawing.Size(95, 40);
            this.btnToProlongation.TabIndex = 11;
            this.btnToProlongation.Text = "Пролонгувати ліцензію";
            this.btnToProlongation.TextWrap = true;
            this.btnToProlongation.ThemeName = "Office2013Light";
            this.btnToProlongation.Click += new System.EventHandler(this.btnToProlongation_Click);
            // 
            // btnToAccept
            // 
            this.btnToAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToAccept.Enabled = false;
            this.btnToAccept.Location = new System.Drawing.Point(821, 105);
            this.btnToAccept.Name = "btnToAccept";
            this.btnToAccept.Size = new System.Drawing.Size(174, 20);
            this.btnToAccept.TabIndex = 12;
            this.btnToAccept.Text = "Відправити на погодження";
            this.btnToAccept.ThemeName = "Office2013Light";
            this.btnToAccept.Click += new System.EventHandler(this.btnToAccept_Click);
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvInformation);
            this.pageView.Controls.Add(this.pvAgreement);
            this.pageView.Controls.Add(this.pvHistory);
            this.pageView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView.Location = new System.Drawing.Point(0, 319);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvInformation;
            this.pageView.Size = new System.Drawing.Size(1000, 219);
            this.pageView.TabIndex = 13;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvInformation
            // 
            this.pvInformation.Controls.Add(this.ctrlAgrDetailInfo);
            this.pvInformation.Controls.Add(this.btnToProlongation);
            this.pvInformation.Controls.Add(this.btnCloseAgr);
            this.pvInformation.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.pvInformation.Location = new System.Drawing.Point(83, 5);
            this.pvInformation.Name = "pvInformation";
            this.pvInformation.Size = new System.Drawing.Size(912, 209);
            this.pvInformation.Text = "Інформація";
            // 
            // ctrlAgrDetailInfo
            // 
            this.ctrlAgrDetailInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlAgrDetailInfo.Location = new System.Drawing.Point(4, 4);
            this.ctrlAgrDetailInfo.MinimumSize = new System.Drawing.Size(795, 170);
            this.ctrlAgrDetailInfo.Name = "ctrlAgrDetailInfo";
            this.ctrlAgrDetailInfo.Size = new System.Drawing.Size(795, 202);
            this.ctrlAgrDetailInfo.TabIndex = 0;
            // 
            // pvAgreement
            // 
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(83, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(905, 209);
            this.pvAgreement.Text = "Договір";
            // 
            // pvHistory
            // 
            this.pvHistory.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.pvHistory.Location = new System.Drawing.Point(83, 5);
            this.pvHistory.Name = "pvHistory";
            this.pvHistory.Size = new System.Drawing.Size(905, 209);
            this.pvHistory.Text = "Історія";
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 105);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 14;
            // 
            // ctrlAgrInfo
            // 
            this.ctrlAgrInfo.DataSource = typeof(ipsFormsDesign.Interfaces.MainGridConsumerBigRightView);
            this.ctrlAgrInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlAgrInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrlAgrInfo.MaximumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.MinimumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.Name = "ctrlAgrInfo";
            this.ctrlAgrInfo.Size = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(887, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 24);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Оновити дані";
            this.btnUpdate.ThemeName = "Office2013Light";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // MiddleControlCabinetLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.btnToAccept);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.gvViewLicences);
            this.Controls.Add(this.ctrlAgrInfo);
            this.MinimumSize = new System.Drawing.Size(993, 538);
            this.Name = "MiddleControlCabinetLicenses";
            this.Size = new System.Drawing.Size(1000, 538);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralAgreementInfo ctrlAgrInfo;
        private Telerik.WinControls.UI.RadGridView gvViewLicences;
        private Telerik.WinControls.UI.RadSeparator separator;
        private Telerik.WinControls.UI.RadButton btnCloseAgr;
        private Telerik.WinControls.UI.RadButton btnToProlongation;
        private Telerik.WinControls.UI.RadButton btnToAccept;
        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvInformation;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvHistory;
        private ConsumerControls.BigRight.AgrDetailInfoBr ctrlAgrDetailInfo;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadButton btnUpdate;
    }
}
