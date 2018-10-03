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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn25 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn26 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn27 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn28 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn29 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn30 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn31 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn32 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn33 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewLicences = new Telerik.WinControls.UI.RadGridView();
            this.separator = new Telerik.WinControls.UI.RadSeparator();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadButton();
            this.btnToProlongation = new Telerik.WinControls.UI.RadButton();
            this.btnToAccept = new Telerik.WinControls.UI.RadButton();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvInformation = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvHistory = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.ctrlAgrDetailInfo = new IpsViewComponentLibrary.ConsumerControls.BigRight.AgrDetailInfoBr();
            this.ctrlAgrInfo = new IpsViewComponentLibrary.GeneralAgreementInfo();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewLicences
            // 
            this.gvViewLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewLicences.AutoSizeRows = true;
            this.gvViewLicences.EnableCustomFiltering = true;
            this.gvViewLicences.Location = new System.Drawing.Point(3, 133);
            // 
            // 
            // 
            this.gvViewLicences.MasterTemplate.AllowAddNewRow = false;
            this.gvViewLicences.MasterTemplate.AllowDeleteRow = false;
            this.gvViewLicences.MasterTemplate.AllowDragToGroup = false;
            this.gvViewLicences.MasterTemplate.AllowEditRow = false;
            this.gvViewLicences.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewLicences.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn23.DataType = typeof(int);
            gridViewTextBoxColumn23.FieldName = "CustId";
            gridViewTextBoxColumn23.HeaderText = "ID";
            gridViewTextBoxColumn23.IsVisible = false;
            gridViewTextBoxColumn23.Name = "CustId";
            gridViewTextBoxColumn24.FieldName = "AgrNumber";
            gridViewTextBoxColumn24.HeaderText = "Код вистави";
            gridViewTextBoxColumn24.MaxWidth = 75;
            gridViewTextBoxColumn24.MinWidth = 75;
            gridViewTextBoxColumn24.Multiline = true;
            gridViewTextBoxColumn24.Name = "AgrNumber";
            gridViewTextBoxColumn24.Width = 75;
            gridViewTextBoxColumn24.WrapText = true;
            gridViewTextBoxColumn25.FieldName = "ObjName";
            gridViewTextBoxColumn25.HeaderText = "Назва вистави";
            gridViewTextBoxColumn25.MinWidth = 0;
            gridViewTextBoxColumn25.Multiline = true;
            gridViewTextBoxColumn25.Name = "ObjName";
            gridViewTextBoxColumn25.Width = 228;
            gridViewTextBoxColumn25.WrapText = true;
            gridViewTextBoxColumn26.FieldName = "LicNum";
            gridViewTextBoxColumn26.HeaderText = "№ ліцензійного договору";
            gridViewTextBoxColumn26.MaxWidth = 100;
            gridViewTextBoxColumn26.MinWidth = 80;
            gridViewTextBoxColumn26.Multiline = true;
            gridViewTextBoxColumn26.Name = "LicNum";
            gridViewTextBoxColumn26.Width = 82;
            gridViewTextBoxColumn26.WrapText = true;
            gridViewTextBoxColumn27.FieldName = "LicDate";
            gridViewTextBoxColumn27.FormatString = "{0:d}";
            gridViewTextBoxColumn27.HeaderText = "Дата договору";
            gridViewTextBoxColumn27.MaxWidth = 75;
            gridViewTextBoxColumn27.MinWidth = 75;
            gridViewTextBoxColumn27.Multiline = true;
            gridViewTextBoxColumn27.Name = "LicDate";
            gridViewTextBoxColumn27.Width = 75;
            gridViewTextBoxColumn27.WrapText = true;
            gridViewTextBoxColumn28.FieldName = "Rate";
            gridViewTextBoxColumn28.HeaderText = "АВ%";
            gridViewTextBoxColumn28.MaxWidth = 45;
            gridViewTextBoxColumn28.MinWidth = 45;
            gridViewTextBoxColumn28.Multiline = true;
            gridViewTextBoxColumn28.Name = "Rate";
            gridViewTextBoxColumn28.Width = 45;
            gridViewTextBoxColumn28.WrapText = true;
            gridViewTextBoxColumn29.FieldName = "LicDateBegin";
            gridViewTextBoxColumn29.FormatString = "{0:d}";
            gridViewTextBoxColumn29.HeaderText = "Дата початку ліцензії";
            gridViewTextBoxColumn29.MaxWidth = 75;
            gridViewTextBoxColumn29.MinWidth = 75;
            gridViewTextBoxColumn29.Multiline = true;
            gridViewTextBoxColumn29.Name = "LicDateBegin";
            gridViewTextBoxColumn29.Width = 75;
            gridViewTextBoxColumn29.WrapText = true;
            gridViewTextBoxColumn30.FieldName = "LicDateEnd";
            gridViewTextBoxColumn30.FormatString = "{0:d}";
            gridViewTextBoxColumn30.HeaderText = "Дата закриття ліцензії";
            gridViewTextBoxColumn30.MaxWidth = 75;
            gridViewTextBoxColumn30.MinWidth = 75;
            gridViewTextBoxColumn30.Multiline = true;
            gridViewTextBoxColumn30.Name = "LicDateEnd";
            gridViewTextBoxColumn30.Width = 75;
            gridViewTextBoxColumn30.WrapText = true;
            gridViewTextBoxColumn31.FieldName = "Borg";
            gridViewTextBoxColumn31.HeaderText = "Заборгованість";
            gridViewTextBoxColumn31.MaxWidth = 95;
            gridViewTextBoxColumn31.MinWidth = 95;
            gridViewTextBoxColumn31.Name = "Borg";
            gridViewTextBoxColumn31.Width = 95;
            gridViewTextBoxColumn32.FieldName = "prepayAvans";
            gridViewTextBoxColumn32.HeaderText = "Аванс";
            gridViewTextBoxColumn32.MaxWidth = 95;
            gridViewTextBoxColumn32.MinWidth = 95;
            gridViewTextBoxColumn32.Multiline = true;
            gridViewTextBoxColumn32.Name = "prepayAvans";
            gridViewTextBoxColumn32.Width = 95;
            gridViewTextBoxColumn32.WrapText = true;
            gridViewTextBoxColumn33.FieldName = "LicStatusName";
            gridViewTextBoxColumn33.HeaderText = "Статус ліцензії";
            gridViewTextBoxColumn33.MaxWidth = 90;
            gridViewTextBoxColumn33.MinWidth = 90;
            gridViewTextBoxColumn33.Name = "LicStatusName";
            gridViewTextBoxColumn33.Width = 90;
            gridViewCommandColumn3.FieldName = "viewBtn";
            gridViewCommandColumn3.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.MaxWidth = 30;
            gridViewCommandColumn3.MinWidth = 30;
            gridViewCommandColumn3.Name = "viewBtn";
            gridViewCommandColumn3.Width = 30;
            this.gvViewLicences.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24,
            gridViewTextBoxColumn25,
            gridViewTextBoxColumn26,
            gridViewTextBoxColumn27,
            gridViewTextBoxColumn28,
            gridViewTextBoxColumn29,
            gridViewTextBoxColumn30,
            gridViewTextBoxColumn31,
            gridViewTextBoxColumn32,
            gridViewTextBoxColumn33,
            gridViewCommandColumn3});
            this.gvViewLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableGrouping = false;
            this.gvViewLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvViewLicences.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gvViewLicences.Name = "gvViewLicences";
            this.gvViewLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewLicences.Size = new System.Drawing.Size(987, 180);
            this.gvViewLicences.TabIndex = 7;
            this.gvViewLicences.ThemeName = "Office2013Light";
            this.gvViewLicences.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvViewLicences_CurrentRowChanged);
            this.gvViewLicences.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewLicences_CommandCellClick);
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.Location = new System.Drawing.Point(3, 88);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(987, 12);
            this.separator.TabIndex = 8;
            this.separator.ThemeName = "Office2013Light";
            // 
            // btnCloseAgr
            // 
            this.btnCloseAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAgr.Location = new System.Drawing.Point(812, 47);
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
            this.btnToProlongation.Location = new System.Drawing.Point(812, 0);
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
            this.btnToAccept.Location = new System.Drawing.Point(816, 103);
            this.btnToAccept.Name = "btnToAccept";
            this.btnToAccept.Size = new System.Drawing.Size(174, 24);
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
            this.pageView.Size = new System.Drawing.Size(993, 219);
            this.pageView.TabIndex = 13;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvInformation
            // 
            this.pvInformation.Controls.Add(this.btnPrint);
            this.pvInformation.Controls.Add(this.btnToProlongation);
            this.pvInformation.Controls.Add(this.btnCloseAgr);
            this.pvInformation.Controls.Add(this.ctrlAgrDetailInfo);
            this.pvInformation.ItemSize = new System.Drawing.SizeF(77F, 25F);
            this.pvInformation.Location = new System.Drawing.Point(81, 5);
            this.pvInformation.Name = "pvInformation";
            this.pvInformation.Size = new System.Drawing.Size(907, 209);
            this.pvInformation.Text = "Інформація";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(812, 93);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 40);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Друкувати ліцензію";
            this.btnPrint.TextWrap = true;
            this.btnPrint.ThemeName = "Office2013Light";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pvAgreement
            // 
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(77F, 25F);
            this.pvAgreement.Location = new System.Drawing.Point(83, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(917, 209);
            this.pvAgreement.Text = "Договір";
            // 
            // pvHistory
            // 
            this.pvHistory.ItemSize = new System.Drawing.SizeF(77F, 25F);
            this.pvHistory.Location = new System.Drawing.Point(83, 5);
            this.pvHistory.Name = "pvHistory";
            this.pvHistory.Size = new System.Drawing.Size(917, 209);
            this.pvHistory.Text = "Історія";
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 106);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 14;
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
            // ctrlAgrInfo
            // 
            this.ctrlAgrInfo.DataSource = typeof(ipsFormsDesign.Interfaces.MainGridConsumerBigRightView);
            this.ctrlAgrInfo.Location = new System.Drawing.Point(3, 3);
            this.ctrlAgrInfo.MaximumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.MinimumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.Name = "ctrlAgrInfo";
            this.ctrlAgrInfo.Size = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.TabIndex = 0;
            // 
            // MiddleControlCabinetLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.btnToAccept);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.gvViewLicences);
            this.Controls.Add(this.ctrlAgrInfo);
            this.MinimumSize = new System.Drawing.Size(993, 538);
            this.Name = "MiddleControlCabinetLicenses";
            this.Size = new System.Drawing.Size(993, 538);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Common.SearchTextBoxControl ctrlSearch;
    }
}
