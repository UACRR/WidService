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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn34 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn35 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn36 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn37 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn38 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn39 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn40 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn41 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn42 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn43 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn44 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewLicences = new Telerik.WinControls.UI.RadGridView();
            this.separator = new Telerik.WinControls.UI.RadSeparator();
            this.ctrlAgrInfo = new IpsViewComponentLibrary.GeneralAgreementInfo();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadButton();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnToProlongation = new Telerik.WinControls.UI.RadButton();
            this.btnToAccept = new Telerik.WinControls.UI.RadButton();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvInformation = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlInformation = new IpsViewComponentLibrary.InformationAgrBR();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvHistory = new Telerik.WinControls.UI.RadPageViewPage();
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
            this.gvViewLicences.Location = new System.Drawing.Point(4, 133);
            // 
            // 
            // 
            this.gvViewLicences.MasterTemplate.AllowAddNewRow = false;
            this.gvViewLicences.MasterTemplate.AllowDeleteRow = false;
            this.gvViewLicences.MasterTemplate.AllowDragToGroup = false;
            this.gvViewLicences.MasterTemplate.AllowEditRow = false;
            this.gvViewLicences.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewLicences.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn34.DataType = typeof(int);
            gridViewTextBoxColumn34.FieldName = "CustId";
            gridViewTextBoxColumn34.HeaderText = "ID";
            gridViewTextBoxColumn34.IsVisible = false;
            gridViewTextBoxColumn34.Name = "CustId";
            gridViewTextBoxColumn35.FieldName = "AgrNumber";
            gridViewTextBoxColumn35.HeaderText = "Код вистави";
            gridViewTextBoxColumn35.MaxWidth = 75;
            gridViewTextBoxColumn35.MinWidth = 75;
            gridViewTextBoxColumn35.Multiline = true;
            gridViewTextBoxColumn35.Name = "AgrNumber";
            gridViewTextBoxColumn35.Width = 75;
            gridViewTextBoxColumn35.WrapText = true;
            gridViewTextBoxColumn36.FieldName = "Name";
            gridViewTextBoxColumn36.HeaderText = "Назва вистави";
            gridViewTextBoxColumn36.MinWidth = 0;
            gridViewTextBoxColumn36.Multiline = true;
            gridViewTextBoxColumn36.Name = "Name";
            gridViewTextBoxColumn36.Width = 223;
            gridViewTextBoxColumn36.WrapText = true;
            gridViewTextBoxColumn37.FieldName = "JaCity";
            gridViewTextBoxColumn37.HeaderText = "№ ліцензійного договору";
            gridViewTextBoxColumn37.MaxWidth = 100;
            gridViewTextBoxColumn37.MinWidth = 80;
            gridViewTextBoxColumn37.Multiline = true;
            gridViewTextBoxColumn37.Name = "JaCity";
            gridViewTextBoxColumn37.Width = 100;
            gridViewTextBoxColumn37.WrapText = true;
            gridViewTextBoxColumn38.FieldName = "StatusName";
            gridViewTextBoxColumn38.HeaderText = "Дата договору";
            gridViewTextBoxColumn38.MaxWidth = 75;
            gridViewTextBoxColumn38.MinWidth = 75;
            gridViewTextBoxColumn38.Multiline = true;
            gridViewTextBoxColumn38.Name = "StatusName";
            gridViewTextBoxColumn38.Width = 75;
            gridViewTextBoxColumn38.WrapText = true;
            gridViewTextBoxColumn39.FieldName = "CountLic1Active";
            gridViewTextBoxColumn39.HeaderText = "АВ%";
            gridViewTextBoxColumn39.MaxWidth = 45;
            gridViewTextBoxColumn39.MinWidth = 45;
            gridViewTextBoxColumn39.Multiline = true;
            gridViewTextBoxColumn39.Name = "CountLic1Active";
            gridViewTextBoxColumn39.Width = 45;
            gridViewTextBoxColumn39.WrapText = true;
            gridViewTextBoxColumn40.FieldName = "CountLic2Active";
            gridViewTextBoxColumn40.HeaderText = "Дата початку ліцензії";
            gridViewTextBoxColumn40.MaxWidth = 75;
            gridViewTextBoxColumn40.MinWidth = 75;
            gridViewTextBoxColumn40.Multiline = true;
            gridViewTextBoxColumn40.Name = "CountLic2Active";
            gridViewTextBoxColumn40.Width = 75;
            gridViewTextBoxColumn40.WrapText = true;
            gridViewTextBoxColumn41.FieldName = "CountLic3Active";
            gridViewTextBoxColumn41.HeaderText = "Дата закриття ліцензії";
            gridViewTextBoxColumn41.MaxWidth = 75;
            gridViewTextBoxColumn41.MinWidth = 75;
            gridViewTextBoxColumn41.Multiline = true;
            gridViewTextBoxColumn41.Name = "CountLic3Active";
            gridViewTextBoxColumn41.Width = 75;
            gridViewTextBoxColumn41.WrapText = true;
            gridViewTextBoxColumn42.FieldName = "Borg";
            gridViewTextBoxColumn42.HeaderText = "Заборгованість";
            gridViewTextBoxColumn42.MaxWidth = 95;
            gridViewTextBoxColumn42.MinWidth = 95;
            gridViewTextBoxColumn42.Name = "Borg";
            gridViewTextBoxColumn42.Width = 95;
            gridViewTextBoxColumn43.HeaderText = "Аванс";
            gridViewTextBoxColumn43.MaxWidth = 95;
            gridViewTextBoxColumn43.MinWidth = 95;
            gridViewTextBoxColumn43.Multiline = true;
            gridViewTextBoxColumn43.Name = "avance";
            gridViewTextBoxColumn43.Width = 95;
            gridViewTextBoxColumn43.WrapText = true;
            gridViewTextBoxColumn44.FieldName = "PartnerName";
            gridViewTextBoxColumn44.HeaderText = "Статус ліцензії";
            gridViewTextBoxColumn44.MaxWidth = 90;
            gridViewTextBoxColumn44.MinWidth = 90;
            gridViewTextBoxColumn44.Name = "PartnerName";
            gridViewTextBoxColumn44.Width = 90;
            gridViewCommandColumn4.AllowResize = false;
            gridViewCommandColumn4.AllowSort = false;
            gridViewCommandColumn4.DefaultText = "Файли";
            gridViewCommandColumn4.FieldName = "btnsDelete";
            gridViewCommandColumn4.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn4.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn4.MaxWidth = 35;
            gridViewCommandColumn4.MinWidth = 35;
            gridViewCommandColumn4.Name = "btnsDelete";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewCommandColumn4.Width = 35;
            this.gvViewLicences.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn34,
            gridViewTextBoxColumn35,
            gridViewTextBoxColumn36,
            gridViewTextBoxColumn37,
            gridViewTextBoxColumn38,
            gridViewTextBoxColumn39,
            gridViewTextBoxColumn40,
            gridViewTextBoxColumn41,
            gridViewTextBoxColumn42,
            gridViewTextBoxColumn43,
            gridViewTextBoxColumn44,
            gridViewCommandColumn4});
            this.gvViewLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableGrouping = false;
            this.gvViewLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvViewLicences.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.gvViewLicences.Name = "gvViewLicences";
            this.gvViewLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewLicences.Size = new System.Drawing.Size(999, 242);
            this.gvViewLicences.TabIndex = 7;
            this.gvViewLicences.ThemeName = "Office2013Light";
            this.gvViewLicences.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvViewConsumers_CurrentRowChanged);
            this.gvViewLicences.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewLicences_CommandCellClick);
            this.gvViewLicences.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvViewConsumers_CustomFiltering);
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.Location = new System.Drawing.Point(4, 90);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(999, 10);
            this.separator.TabIndex = 8;
            this.separator.ThemeName = "Office2013Light";
            // 
            // ctrlAgrInfo
            // 
            this.ctrlAgrInfo.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            this.ctrlAgrInfo.Location = new System.Drawing.Point(4, 4);
            this.ctrlAgrInfo.MaximumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.MinimumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.Name = "ctrlAgrInfo";
            this.ctrlAgrInfo.Size = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.TabIndex = 0;
            // 
            // btnCloseAgr
            // 
            this.btnCloseAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAgr.Location = new System.Drawing.Point(910, 103);
            this.btnCloseAgr.Name = "btnCloseAgr";
            this.btnCloseAgr.Size = new System.Drawing.Size(93, 24);
            this.btnCloseAgr.TabIndex = 9;
            this.btnCloseAgr.Text = "Закрити";
            this.btnCloseAgr.ThemeName = "Office2013Light";
            this.btnCloseAgr.Click += new System.EventHandler(this.btnCloseAgr_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(4, 107);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.Size = new System.Drawing.Size(479, 20);
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
            this.btnToProlongation.Location = new System.Drawing.Point(811, 103);
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
            this.btnToAccept.Location = new System.Drawing.Point(712, 103);
            this.btnToAccept.Name = "btnToAccept";
            this.btnToAccept.Size = new System.Drawing.Size(93, 24);
            this.btnToAccept.TabIndex = 12;
            this.btnToAccept.Text = "На акцепт";
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
            this.pageView.Location = new System.Drawing.Point(4, 381);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvInformation;
            this.pageView.Size = new System.Drawing.Size(999, 247);
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
            this.pvInformation.Size = new System.Drawing.Size(911, 237);
            this.pvInformation.Text = "Інформація";
            // 
            // ctrlInformation
            // 
            this.ctrlInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlInformation.CommentDataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlInformation.InfoDataSource = null;
            this.ctrlInformation.Location = new System.Drawing.Point(0, 0);
            this.ctrlInformation.MaximumSize = new System.Drawing.Size(788, 500);
            this.ctrlInformation.MinimumSize = new System.Drawing.Size(503, 188);
            this.ctrlInformation.Name = "ctrlInformation";
            this.ctrlInformation.Size = new System.Drawing.Size(631, 237);
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
            this.Size = new System.Drawing.Size(1006, 631);
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
