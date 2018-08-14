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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewLicences = new Telerik.WinControls.UI.RadGridView();
            this.separator = new Telerik.WinControls.UI.RadSeparator();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadButton();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnToProlongation = new Telerik.WinControls.UI.RadButton();
            this.btnToAccept = new Telerik.WinControls.UI.RadButton();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvInformation = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlInformation = new IpsViewComponentLibrary.InformationAgrBR();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvHistory = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgrInfo = new IpsViewComponentLibrary.GeneralAgreementInfo();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvInformation.SuspendLayout();
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
            gridViewTextBoxColumn14.Width = 257;
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
            gridViewTextBoxColumn22});
            this.gvViewLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableGrouping = false;
            this.gvViewLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvViewLicences.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvViewLicences.Name = "gvViewLicences";
            this.gvViewLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewLicences.Size = new System.Drawing.Size(999, 237);
            this.gvViewLicences.TabIndex = 7;
            this.gvViewLicences.ThemeName = "Office2013Light";
            this.gvViewLicences.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvViewLicences_CurrentRowChanged);
            this.gvViewLicences.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvViewConsumers_CustomFiltering);
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.Location = new System.Drawing.Point(3, 88);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(999, 12);
            this.separator.TabIndex = 8;
            this.separator.ThemeName = "Office2013Light";
            // 
            // btnCloseAgr
            // 
            this.btnCloseAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAgr.Location = new System.Drawing.Point(909, 103);
            this.btnCloseAgr.Name = "btnCloseAgr";
            this.btnCloseAgr.Size = new System.Drawing.Size(93, 24);
            this.btnCloseAgr.TabIndex = 9;
            this.btnCloseAgr.Text = "Закрити";
            this.btnCloseAgr.ThemeName = "Office2013Light";
            this.btnCloseAgr.Click += new System.EventHandler(this.btnCloseAgr_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 107);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.Size = new System.Drawing.Size(480, 20);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.ThemeName = "Office2013Light";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).BackgroundImage = null;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).Image = global::IpsViewComponentLibrary.Properties.Resources.search;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).HorizontalLineWidth = 0;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).RightToLeft = false;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ScaleTransform = new System.Drawing.SizeF(1F, 1F);
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            // 
            // btnToProlongation
            // 
            this.btnToProlongation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToProlongation.Location = new System.Drawing.Point(810, 103);
            this.btnToProlongation.Name = "btnToProlongation";
            this.btnToProlongation.Size = new System.Drawing.Size(93, 24);
            this.btnToProlongation.TabIndex = 11;
            this.btnToProlongation.Text = "Пролонгувати";
            this.btnToProlongation.ThemeName = "Office2013Light";
            this.btnToProlongation.Click += new System.EventHandler(this.btnToProlongation_Click);
            // 
            // btnToAccept
            // 
            this.btnToAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToAccept.Enabled = false;
            this.btnToAccept.Location = new System.Drawing.Point(701, 103);
            this.btnToAccept.Name = "btnToAccept";
            this.btnToAccept.Size = new System.Drawing.Size(103, 24);
            this.btnToAccept.TabIndex = 12;
            this.btnToAccept.Text = "На погодження";
            this.btnToAccept.ThemeName = "Office2013Light";
            this.btnToAccept.Click += new System.EventHandler(this.btnToAccept_Click);
            // 
            // pageView
            // 
            this.pageView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageView.Controls.Add(this.pvInformation);
            this.pageView.Controls.Add(this.pvAgreement);
            this.pageView.Controls.Add(this.pvHistory);
            this.pageView.Location = new System.Drawing.Point(4, 376);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvInformation;
            this.pageView.Size = new System.Drawing.Size(998, 219);
            this.pageView.TabIndex = 13;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvInformation
            // 
            this.pvInformation.Controls.Add(this.ctrlInformation);
            this.pvInformation.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.pvInformation.Location = new System.Drawing.Point(83, 5);
            this.pvInformation.Name = "pvInformation";
            this.pvInformation.Size = new System.Drawing.Size(910, 209);
            this.pvInformation.Text = "Інформація";
            // 
            // ctrlInformation
            // 
            this.ctrlInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlInformation.InfoDataSource = typeof(ipsFormsDesign.Interfaces.VbrLicense);
            this.ctrlInformation.Location = new System.Drawing.Point(0, 0);
            this.ctrlInformation.MaximumSize = new System.Drawing.Size(900, 500);
            this.ctrlInformation.MinimumSize = new System.Drawing.Size(503, 188);
            this.ctrlInformation.Name = "ctrlInformation";
            this.ctrlInformation.Size = new System.Drawing.Size(854, 209);
            this.ctrlInformation.TabIndex = 0;
            // 
            // pvAgreement
            // 
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(83, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(860, 237);
            this.pvAgreement.Text = "Договір";
            // 
            // pvHistory
            // 
            this.pvHistory.ItemSize = new System.Drawing.SizeF(79F, 27F);
            this.pvHistory.Location = new System.Drawing.Point(83, 5);
            this.pvHistory.Name = "pvHistory";
            this.pvHistory.Size = new System.Drawing.Size(864, 237);
            this.pvHistory.Text = "Історія";
            // 
            // ctrlAgrInfo
            // 
            this.ctrlAgrInfo.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
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
            this.Controls.Add(this.pageView);
            this.Controls.Add(this.btnToAccept);
            this.Controls.Add(this.btnToProlongation);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnCloseAgr);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.gvViewLicences);
            this.Controls.Add(this.ctrlAgrInfo);
            this.MinimumSize = new System.Drawing.Size(822, 538);
            this.Name = "MiddleControlCabinetLicenses";
            this.Size = new System.Drawing.Size(1005, 598);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralAgreementInfo ctrlAgrInfo;
        private Telerik.WinControls.UI.RadGridView gvViewLicences;
        private Telerik.WinControls.UI.RadSeparator separator;
        private Telerik.WinControls.UI.RadButton btnCloseAgr;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private Telerik.WinControls.UI.RadButton btnToProlongation;
        private Telerik.WinControls.UI.RadButton btnToAccept;
        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvInformation;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvHistory;
        private InformationAgrBR ctrlInformation;
    }
}
