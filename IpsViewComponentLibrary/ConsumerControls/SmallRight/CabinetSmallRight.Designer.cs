using System.Drawing;
using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.ConsumerControls.Calculation;
using IpsViewComponentLibrary.ConsumerControls.Reports;
using IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel;

namespace IpsViewComponentLibrary.ConsumerControls.SmallRight
{
    partial class CabinetSmallRight
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pvAgent = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPartner = new IpsViewComponentLibrary.ConsumerControls.PartnerOfConsumerControl();
            this.pvFiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlFiles = new IpsViewComponentLibrary.MiddleControlCabinetFiles();
            this.pvContacts = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlHeaderInfo = new IpsViewComponentLibrary.ConsumerControls.ConsumerHeaderInfo();
            this.pvPayments = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPaysInfo1 = new IpsViewComponentLibrary.ConsumerControls.PaysInfo();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.calculationCtrl = new IpsViewComponentLibrary.ConsumerControls.Calculation.CalculationInfoControl();
            this.currentAgreementController1 = new IpsViewComponentLibrary.Utilities.CurrentAgreementController();
            this.pvReports = new Telerik.WinControls.UI.RadPageViewPage();
            this.reportsControl = new IpsViewComponentLibrary.ConsumerControls.Reports.ReportsControl();
            this.pvMoreAgreements = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlLicenseAgreementNotActive = new IpsViewComponentLibrary.ConsumerControls.SmallRight.LicenseAgreementNotActiveControl();
            this.pvActiveAgr = new Telerik.WinControls.UI.RadPageViewPage();
            this.gvLicenseAgr = new Telerik.WinControls.UI.RadGridView();
            this.bsGridLicenseAgreementView = new System.Windows.Forms.BindingSource(this.components);
            this.ipsPanel1 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.ctrlAgrDetailInfo = new IpsViewComponentLibrary.ConsumerControls.ConsumerAgrDetailInfo();
            this.btnAddAgreement = new Telerik.WinControls.UI.RadButton();
            this.btnActionOfAgr = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnProlongation = new Telerik.WinControls.UI.RadMenuItem();
            this.btnAddAgrNewVersion = new Telerik.WinControls.UI.RadMenuItem();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadButton();
            this.pvAnketa = new Telerik.WinControls.UI.RadPageViewPage();
            this.anketaPanel = new Telerik.WinControls.UI.RadPanel();
            this.ctrlTabNavigation = new IpsViewComponentLibrary.Common.TabNavigationControl();
            this.pvMain = new Telerik.WinControls.UI.RadPageView();
            this.pvClosedAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlClosedAgreements = new IpsViewComponentLibrary.ConsumerControls.ClosedAgreementsControl();
            this.pvReportWPF = new Telerik.WinControls.UI.RadPageViewPage();
            this.ehRegister = new System.Windows.Forms.Integration.ElementHost();
            this.pvAgent.SuspendLayout();
            this.pvFiles.SuspendLayout();
            this.pvContacts.SuspendLayout();
            this.pvPayments.SuspendLayout();
            this.pvCalculation.SuspendLayout();
            this.pvReports.SuspendLayout();
            this.pvMoreAgreements.SuspendLayout();
            this.pvActiveAgr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridLicenseAgreementView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).BeginInit();
            this.ipsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAgreement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActionOfAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).BeginInit();
            this.pvAnketa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anketaPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvMain)).BeginInit();
            this.pvMain.SuspendLayout();
            this.pvClosedAgreement.SuspendLayout();
            this.pvReportWPF.SuspendLayout();
            this.SuspendLayout();
            // 
            // pvAgent
            // 
            this.pvAgent.AutoScroll = true;
            this.pvAgent.Controls.Add(this.ctrlPartner);
            this.pvAgent.ItemSize = new System.Drawing.SizeF(88F, 27F);
            this.pvAgent.Location = new System.Drawing.Point(5, 41);
            this.pvAgent.Name = "pvAgent";
            this.pvAgent.Size = new System.Drawing.Size(985, 444);
            this.pvAgent.Text = "Представник";
            // 
            // ctrlPartner
            // 
            this.ctrlPartner.Location = new System.Drawing.Point(4, 4);
            this.ctrlPartner.Name = "ctrlPartner";
            this.ctrlPartner.Size = new System.Drawing.Size(655, 135);
            this.ctrlPartner.TabIndex = 0;
            // 
            // pvFiles
            // 
            this.pvFiles.AutoScroll = true;
            this.pvFiles.Controls.Add(this.ctrlFiles);
            this.pvFiles.ItemSize = new System.Drawing.SizeF(51F, 27F);
            this.pvFiles.Location = new System.Drawing.Point(5, 41);
            this.pvFiles.Name = "pvFiles";
            this.pvFiles.Size = new System.Drawing.Size(985, 444);
            this.pvFiles.Text = "Файли";
            // 
            // ctrlFiles
            // 
            this.ctrlFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFiles.Location = new System.Drawing.Point(0, 0);
            this.ctrlFiles.Name = "ctrlFiles";
            this.ctrlFiles.Size = new System.Drawing.Size(985, 444);
            this.ctrlFiles.TabIndex = 0;
            // 
            // pvContacts
            // 
            this.pvContacts.AutoScroll = true;
            this.pvContacts.Controls.Add(this.ctrlHeaderInfo);
            this.pvContacts.ItemSize = new System.Drawing.SizeF(66F, 27F);
            this.pvContacts.Location = new System.Drawing.Point(5, 41);
            this.pvContacts.Name = "pvContacts";
            this.pvContacts.Size = new System.Drawing.Size(985, 444);
            this.pvContacts.Text = "Контакти";
            // 
            // ctrlHeaderInfo
            // 
            this.ctrlHeaderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlHeaderInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeaderInfo.MaximumSize = new System.Drawing.Size(836, 178);
            this.ctrlHeaderInfo.MinimumSize = new System.Drawing.Size(836, 178);
            this.ctrlHeaderInfo.Name = "ctrlHeaderInfo";
            this.ctrlHeaderInfo.Size = new System.Drawing.Size(836, 178);
            this.ctrlHeaderInfo.TabIndex = 6;
            // 
            // pvPayments
            // 
            this.pvPayments.Controls.Add(this.ctrlPaysInfo1);
            this.pvPayments.ItemSize = new System.Drawing.SizeF(60F, 27F);
            this.pvPayments.Location = new System.Drawing.Point(5, 41);
            this.pvPayments.Name = "pvPayments";
            this.pvPayments.Size = new System.Drawing.Size(985, 444);
            this.pvPayments.Text = "Платежі";
            // 
            // ctrlPaysInfo1
            // 
            this.ctrlPaysInfo1.Customer = null;
            this.ctrlPaysInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPaysInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPaysInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlPaysInfo1.Name = "ctrlPaysInfo1";
            this.ctrlPaysInfo1.Size = new System.Drawing.Size(985, 444);
            this.ctrlPaysInfo1.TabIndex = 0;
            // 
            // pvCalculation
            // 
            this.pvCalculation.AutoScroll = true;
            this.pvCalculation.Controls.Add(this.calculationCtrl);
            this.pvCalculation.ItemSize = new System.Drawing.SizeF(80F, 27F);
            this.pvCalculation.Location = new System.Drawing.Point(5, 41);
            this.pvCalculation.Name = "pvCalculation";
            this.pvCalculation.Size = new System.Drawing.Size(985, 444);
            this.pvCalculation.Text = "Розрахунки";
            // 
            // calculationCtrl
            // 
            this.calculationCtrl.CurrentAgreementController = this.currentAgreementController1;
            this.calculationCtrl.Customer = null;
            this.calculationCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculationCtrl.Location = new System.Drawing.Point(0, 0);
            this.calculationCtrl.MaximumSize = new System.Drawing.Size(3000, 1000);
            this.calculationCtrl.Name = "calculationCtrl";
            this.calculationCtrl.Size = new System.Drawing.Size(985, 444);
            this.calculationCtrl.TabIndex = 0;
            this.calculationCtrl.TypeRights = ipsFormsDesign.Dictionary.TypeRights.All;
            // 
            // currentAgreementController1
            // 
            this.currentAgreementController1.CurrentLicenseAgreementChanged += new System.EventHandler<ipsFormsDesign.Model.LicenseAgreement>(this.currentAgreementController1_CurrentLicenseAgreementChanged);
            // 
            // pvReports
            // 
            this.pvReports.Controls.Add(this.reportsControl);
            this.pvReports.ItemSize = new System.Drawing.SizeF(43F, 27F);
            this.pvReports.Location = new System.Drawing.Point(5, 41);
            this.pvReports.Name = "pvReports";
            this.pvReports.Size = new System.Drawing.Size(985, 444);
            this.pvReports.Text = "Звіти";
            // 
            // reportsControl
            // 
            this.reportsControl.CurrentAgreementController = this.currentAgreementController1;
            this.reportsControl.Customer = null;
            this.reportsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportsControl.Location = new System.Drawing.Point(0, 0);
            this.reportsControl.Name = "reportsControl";
            this.reportsControl.Size = new System.Drawing.Size(985, 444);
            this.reportsControl.TabIndex = 0;
            this.reportsControl.TypeRights = ipsFormsDesign.Dictionary.TypeRights.All;
            // 
            // pvMoreAgreements
            // 
            this.pvMoreAgreements.Controls.Add(this.ctrlLicenseAgreementNotActive);
            this.pvMoreAgreements.ItemSize = new System.Drawing.SizeF(166F, 27F);
            this.pvMoreAgreements.Location = new System.Drawing.Point(5, 41);
            this.pvMoreAgreements.Name = "pvMoreAgreements";
            this.pvMoreAgreements.Size = new System.Drawing.Size(985, 444);
            this.pvMoreAgreements.Text = "Не підтверджені договори";
            // 
            // ctrlLicenseAgreementNotActive
            // 
            this.ctrlLicenseAgreementNotActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLicenseAgreementNotActive.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicenseAgreementNotActive.Name = "ctrlLicenseAgreementNotActive";
            this.ctrlLicenseAgreementNotActive.Size = new System.Drawing.Size(985, 444);
            this.ctrlLicenseAgreementNotActive.TabIndex = 0;
            // 
            // pvActiveAgr
            // 
            this.pvActiveAgr.Controls.Add(this.gvLicenseAgr);
            this.pvActiveAgr.Controls.Add(this.ipsPanel1);
            this.pvActiveAgr.ItemSize = new System.Drawing.SizeF(115F, 27F);
            this.pvActiveAgr.Location = new System.Drawing.Point(5, 41);
            this.pvActiveAgr.Name = "pvActiveAgr";
            this.pvActiveAgr.Size = new System.Drawing.Size(985, 444);
            this.pvActiveAgr.Text = "Активні договори";
            // 
            // gvLicenseAgr
            // 
            this.gvLicenseAgr.AutoScroll = true;
            this.gvLicenseAgr.AutoSizeRows = true;
            this.gvLicenseAgr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLicenseAgr.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvLicenseAgr.MasterTemplate.AllowAddNewRow = false;
            this.gvLicenseAgr.MasterTemplate.AllowDeleteRow = false;
            this.gvLicenseAgr.MasterTemplate.AllowDragToGroup = false;
            this.gvLicenseAgr.MasterTemplate.AllowEditRow = false;
            this.gvLicenseAgr.MasterTemplate.AutoGenerateColumns = false;
            this.gvLicenseAgr.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn11.DataType = typeof(int);
            gridViewTextBoxColumn11.FieldName = "Id";
            gridViewTextBoxColumn11.HeaderText = "Id";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "Id";
            gridViewTextBoxColumn11.Width = 48;
            gridViewTextBoxColumn12.FieldName = "License";
            gridViewTextBoxColumn12.HeaderText = "Ліцензія";
            gridViewTextBoxColumn12.MinWidth = 180;
            gridViewTextBoxColumn12.Name = "License";
            gridViewTextBoxColumn12.Width = 180;
            gridViewTextBoxColumn13.FieldName = "Series";
            gridViewTextBoxColumn13.HeaderText = "Серія";
            gridViewTextBoxColumn13.MinWidth = 80;
            gridViewTextBoxColumn13.Name = "Series";
            gridViewTextBoxColumn13.Width = 80;
            gridViewTextBoxColumn14.FieldName = "AgrNumber";
            gridViewTextBoxColumn14.HeaderText = "Номер договору";
            gridViewTextBoxColumn14.MinWidth = 105;
            gridViewTextBoxColumn14.Name = "AgrNumber";
            gridViewTextBoxColumn14.Width = 105;
            gridViewTextBoxColumn15.FieldName = "DateBegin";
            gridViewTextBoxColumn15.HeaderText = "Дата початку";
            gridViewTextBoxColumn15.MaxWidth = 80;
            gridViewTextBoxColumn15.MinWidth = 80;
            gridViewTextBoxColumn15.Name = "DateBegin";
            gridViewTextBoxColumn15.Width = 80;
            gridViewTextBoxColumn15.WrapText = true;
            gridViewTextBoxColumn16.FieldName = "DateEnd";
            gridViewTextBoxColumn16.HeaderText = "Дата завершення";
            gridViewTextBoxColumn16.MaxWidth = 80;
            gridViewTextBoxColumn16.MinWidth = 80;
            gridViewTextBoxColumn16.Name = "DateEnd";
            gridViewTextBoxColumn16.Width = 80;
            gridViewTextBoxColumn16.WrapText = true;
            gridViewTextBoxColumn17.DataType = typeof(decimal);
            gridViewTextBoxColumn17.FieldName = "MinRate";
            gridViewTextBoxColumn17.FormatString = "{0:##0.00}";
            gridViewTextBoxColumn17.HeaderText = "Тариф";
            gridViewTextBoxColumn17.MaxWidth = 90;
            gridViewTextBoxColumn17.MinWidth = 90;
            gridViewTextBoxColumn17.Name = "MinRate";
            gridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn17.Width = 90;
            gridViewTextBoxColumn17.WrapText = true;
            gridViewDecimalColumn2.FieldName = "MinAmount";
            gridViewDecimalColumn2.FormatString = "{0:### ### ##0.00}";
            gridViewDecimalColumn2.HeaderText = "Гарантійний платіж";
            gridViewDecimalColumn2.MinWidth = 90;
            gridViewDecimalColumn2.Name = "MinAmount";
            gridViewDecimalColumn2.Width = 90;
            gridViewDecimalColumn2.WrapText = true;
            gridViewTextBoxColumn18.FieldName = "State";
            gridViewTextBoxColumn18.HeaderText = "Статус";
            gridViewTextBoxColumn18.MaxWidth = 150;
            gridViewTextBoxColumn18.MinWidth = 100;
            gridViewTextBoxColumn18.Name = "State";
            gridViewTextBoxColumn18.Width = 100;
            gridViewTextBoxColumn19.FieldName = "PeriodPayment";
            gridViewTextBoxColumn19.HeaderText = "Періодичність оплати";
            gridViewTextBoxColumn19.MaxWidth = 115;
            gridViewTextBoxColumn19.MinWidth = 100;
            gridViewTextBoxColumn19.Name = "PeriodPayment";
            gridViewTextBoxColumn19.Width = 100;
            gridViewTextBoxColumn19.WrapText = true;
            gridViewTextBoxColumn20.FieldName = "DateLastPayment";
            gridViewTextBoxColumn20.HeaderText = "Дата останньої оплати";
            gridViewTextBoxColumn20.MaxWidth = 80;
            gridViewTextBoxColumn20.MinWidth = 80;
            gridViewTextBoxColumn20.Multiline = true;
            gridViewTextBoxColumn20.Name = "DateLastPayment";
            gridViewTextBoxColumn20.Width = 80;
            gridViewTextBoxColumn20.WrapText = true;
            gridViewCheckBoxColumn2.FieldName = "IsAutoprolog";
            gridViewCheckBoxColumn2.HeaderText = "а-п";
            gridViewCheckBoxColumn2.MaxWidth = 30;
            gridViewCheckBoxColumn2.MinWidth = 30;
            gridViewCheckBoxColumn2.Name = "IsAutoprolog";
            gridViewCheckBoxColumn2.Width = 30;
            gridViewCommandColumn2.FieldName = "printBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "printBtn";
            gridViewCommandColumn2.Width = 30;
            this.gvLicenseAgr.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewCheckBoxColumn2,
            gridViewCommandColumn2});
            this.gvLicenseAgr.MasterTemplate.DataSource = this.bsGridLicenseAgreementView;
            this.gvLicenseAgr.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvLicenseAgr.MinimumSize = new System.Drawing.Size(300, 100);
            this.gvLicenseAgr.Name = "gvLicenseAgr";
            this.gvLicenseAgr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvLicenseAgr.ReadOnly = true;
            // 
            // 
            // 
            this.gvLicenseAgr.RootElement.MinSize = new System.Drawing.Size(300, 100);
            this.gvLicenseAgr.ShowGroupPanel = false;
            this.gvLicenseAgr.Size = new System.Drawing.Size(985, 183);
            this.gvLicenseAgr.TabIndex = 0;
            this.gvLicenseAgr.ThemeName = "Office2013Light";
            this.gvLicenseAgr.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvLicenseAgr_CurrentRowChanged);
            this.gvLicenseAgr.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvLicenseAgr_CommandCellClick);
            // 
            // bsGridLicenseAgreementView
            // 
            this.bsGridLicenseAgreementView.DataSource = typeof(IpsViewComponentLibrary.ConsumerControls.SmallRight.InternalModel.GridLicenseAgreementView);
            // 
            // ipsPanel1
            // 
            this.ipsPanel1.BorderVisible = false;
            this.ipsPanel1.Controls.Add(this.ctrlAgrDetailInfo);
            this.ipsPanel1.Controls.Add(this.btnAddAgreement);
            this.ipsPanel1.Controls.Add(this.btnActionOfAgr);
            this.ipsPanel1.Controls.Add(this.btnCloseAgr);
            this.ipsPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipsPanel1.Location = new System.Drawing.Point(0, 183);
            this.ipsPanel1.Name = "ipsPanel1";
            this.ipsPanel1.Size = new System.Drawing.Size(985, 261);
            this.ipsPanel1.TabIndex = 1;
            this.ipsPanel1.ThemeName = "Office2013Light";
            // 
            // ctrlAgrDetailInfo
            // 
            this.ctrlAgrDetailInfo.Location = new System.Drawing.Point(3, 38);
            this.ctrlAgrDetailInfo.MinimumSize = new System.Drawing.Size(785, 220);
            this.ctrlAgrDetailInfo.Name = "ctrlAgrDetailInfo";
            this.ctrlAgrDetailInfo.Size = new System.Drawing.Size(785, 220);
            this.ctrlAgrDetailInfo.TabIndex = 3;
            // 
            // btnAddAgreement
            // 
            this.btnAddAgreement.Location = new System.Drawing.Point(3, 8);
            this.btnAddAgreement.Name = "btnAddAgreement";
            this.btnAddAgreement.Size = new System.Drawing.Size(140, 24);
            this.btnAddAgreement.TabIndex = 0;
            this.btnAddAgreement.Text = "Додати новий договір";
            this.btnAddAgreement.TextWrap = true;
            this.btnAddAgreement.ThemeName = "Office2013Light";
            this.btnAddAgreement.Click += new System.EventHandler(this.btnAddAgreement_Click);
            // 
            // btnActionOfAgr
            // 
            this.btnActionOfAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActionOfAgr.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnProlongation,
            this.btnAddAgrNewVersion});
            this.btnActionOfAgr.Location = new System.Drawing.Point(842, 8);
            this.btnActionOfAgr.Name = "btnActionOfAgr";
            this.btnActionOfAgr.Size = new System.Drawing.Size(140, 24);
            this.btnActionOfAgr.TabIndex = 2;
            this.btnActionOfAgr.Text = "Дії з договором";
            this.btnActionOfAgr.ThemeName = "Office2013Light";
            // 
            // btnProlongation
            // 
            this.btnProlongation.Name = "btnProlongation";
            this.btnProlongation.Text = "Пролонгувати договір";
            this.btnProlongation.Click += new System.EventHandler(this.btnProlongation_Click);
            // 
            // btnAddAgrNewVersion
            // 
            this.btnAddAgrNewVersion.Name = "btnAddAgrNewVersion";
            this.btnAddAgrNewVersion.Text = "Змінити договір";
            this.btnAddAgrNewVersion.Click += new System.EventHandler(this.btnChangeAgreement_Click);
            // 
            // btnCloseAgr
            // 
            this.btnCloseAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAgr.Location = new System.Drawing.Point(696, 8);
            this.btnCloseAgr.Name = "btnCloseAgr";
            this.btnCloseAgr.Size = new System.Drawing.Size(140, 24);
            this.btnCloseAgr.TabIndex = 1;
            this.btnCloseAgr.Text = "Закрити договір";
            this.btnCloseAgr.TextWrap = true;
            this.btnCloseAgr.ThemeName = "Office2013Light";
            this.btnCloseAgr.Click += new System.EventHandler(this.btnCloseAgr_Click);
            // 
            // pvAnketa
            // 
            this.pvAnketa.Controls.Add(this.anketaPanel);
            this.pvAnketa.Controls.Add(this.ctrlTabNavigation);
            this.pvAnketa.ItemSize = new System.Drawing.SizeF(54F, 27F);
            this.pvAnketa.Location = new System.Drawing.Point(5, 41);
            this.pvAnketa.Name = "pvAnketa";
            this.pvAnketa.Size = new System.Drawing.Size(985, 444);
            this.pvAnketa.Text = "Анкета";
            // 
            // anketaPanel
            // 
            this.anketaPanel.AutoScroll = true;
            this.anketaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anketaPanel.Location = new System.Drawing.Point(0, 0);
            this.anketaPanel.Name = "anketaPanel";
            this.anketaPanel.Size = new System.Drawing.Size(985, 413);
            this.anketaPanel.TabIndex = 17;
            this.anketaPanel.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPanelElement)(this.anketaPanel.GetChildAt(0))).BorderHighlightThickness = 1;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.anketaPanel.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // ctrlTabNavigation
            // 
            this.ctrlTabNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigation.Location = new System.Drawing.Point(0, 413);
            this.ctrlTabNavigation.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigation.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigation.Name = "ctrlTabNavigation";
            this.ctrlTabNavigation.Size = new System.Drawing.Size(985, 31);
            this.ctrlTabNavigation.TabIndex = 16;
            // 
            // pvMain
            // 
            this.pvMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pvMain.Controls.Add(this.pvAnketa);
            this.pvMain.Controls.Add(this.pvActiveAgr);
            this.pvMain.Controls.Add(this.pvMoreAgreements);
            this.pvMain.Controls.Add(this.pvClosedAgreement);
            this.pvMain.Controls.Add(this.pvReports);
            this.pvMain.Controls.Add(this.pvReportWPF);
            this.pvMain.Controls.Add(this.pvCalculation);
            this.pvMain.Controls.Add(this.pvPayments);
            this.pvMain.Controls.Add(this.pvContacts);
            this.pvMain.Controls.Add(this.pvFiles);
            this.pvMain.Controls.Add(this.pvAgent);
            this.pvMain.DefaultPage = this.pvActiveAgr;
            this.pvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvMain.Location = new System.Drawing.Point(0, 0);
            this.pvMain.Name = "pvMain";
            this.pvMain.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pvMain.PageBackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.pvMain.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.pvMain.SelectedPage = this.pvAnketa;
            this.pvMain.Size = new System.Drawing.Size(995, 490);
            this.pvMain.TabIndex = 4;
            this.pvMain.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).StripScrollingAnimation = Telerik.WinControls.RadEasingType.Linear;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).DrawText = true;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).DrawFill = true;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).DrawBorder = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).DrawBackgroundImage = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).DrawImage = true;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).EnableBorderHighlight = true;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).AutoSize = true;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.Auto;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            // 
            // pvClosedAgreement
            // 
            this.pvClosedAgreement.Controls.Add(this.ctrlClosedAgreements);
            this.pvClosedAgreement.ItemSize = new System.Drawing.SizeF(114F, 27F);
            this.pvClosedAgreement.Location = new System.Drawing.Point(5, 41);
            this.pvClosedAgreement.Name = "pvClosedAgreement";
            this.pvClosedAgreement.Size = new System.Drawing.Size(985, 444);
            this.pvClosedAgreement.Text = "Закриті договори";
            // 
            // ctrlClosedAgreements
            // 
            this.ctrlClosedAgreements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlClosedAgreements.Location = new System.Drawing.Point(0, 0);
            this.ctrlClosedAgreements.Name = "ctrlClosedAgreements";
            this.ctrlClosedAgreements.Size = new System.Drawing.Size(985, 444);
            this.ctrlClosedAgreements.TabIndex = 0;
            // 
            // pvReportWPF
            // 
            this.pvReportWPF.Controls.Add(this.ehRegister);
            this.pvReportWPF.ItemSize = new System.Drawing.SizeF(78F, 27F);
            this.pvReportWPF.Location = new System.Drawing.Point(5, 41);
            this.pvReportWPF.Name = "pvReportWPF";
            this.pvReportWPF.Size = new System.Drawing.Size(985, 444);
            this.pvReportWPF.Text = "Звіти (WPF)";
            // 
            // ehRegister
            // 
            this.ehRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ehRegister.Location = new System.Drawing.Point(0, 0);
            this.ehRegister.Name = "ehRegister";
            this.ehRegister.Size = new System.Drawing.Size(985, 444);
            this.ehRegister.TabIndex = 0;
            this.ehRegister.Child = null;
            // 
            // CabinetSmallRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(860, 470);
            this.Controls.Add(this.pvMain);
            this.Name = "CabinetSmallRight";
            this.Size = new System.Drawing.Size(995, 490);
            this.pvAgent.ResumeLayout(false);
            this.pvFiles.ResumeLayout(false);
            this.pvContacts.ResumeLayout(false);
            this.pvPayments.ResumeLayout(false);
            this.pvCalculation.ResumeLayout(false);
            this.pvReports.ResumeLayout(false);
            this.pvMoreAgreements.ResumeLayout(false);
            this.pvActiveAgr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGridLicenseAgreementView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).EndInit();
            this.ipsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAgreement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActionOfAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).EndInit();
            this.pvAnketa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.anketaPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvMain)).EndInit();
            this.pvMain.ResumeLayout(false);
            this.pvClosedAgreement.ResumeLayout(false);
            this.pvReportWPF.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Utilities.CurrentAgreementController currentAgreementController1;
        private Telerik.WinControls.UI.RadPageViewPage pvAgent;
        private Telerik.WinControls.UI.RadPageViewPage pvFiles;
        private Telerik.WinControls.UI.RadPageViewPage pvContacts;
        private Telerik.WinControls.UI.RadPageViewPage pvPayments;
        private ConsumerControls.PaysInfo ctrlPaysInfo1;
        private Telerik.WinControls.UI.RadPageViewPage pvCalculation;
        public CalculationInfoControl calculationCtrl;
        private Telerik.WinControls.UI.RadPageViewPage pvReports;
        public ReportsControl reportsControl;
        private Telerik.WinControls.UI.RadPageViewPage pvMoreAgreements;
        private Telerik.WinControls.UI.RadPageViewPage pvActiveAgr;
        private Telerik.WinControls.UI.RadGridView gvLicenseAgr;
        private Telerik.WinControls.UI.RadButton btnCloseAgr;
        private Telerik.WinControls.UI.RadButton btnAddAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvAnketa;
        private Telerik.WinControls.UI.RadPageView pvMain;
        private ConsumerControls.ConsumerHeaderInfo ctrlHeaderInfo;
        private Telerik.WinControls.UI.RadDropDownButton btnActionOfAgr;
        private Telerik.WinControls.UI.RadMenuItem btnProlongation;
        private Telerik.WinControls.UI.RadMenuItem btnAddAgrNewVersion;
        private PartnerOfConsumerControl ctrlPartner;
        private TabNavigationControl ctrlTabNavigation;
        private Telerik.WinControls.UI.RadPanel anketaPanel;
        private MiddleControlCabinetFiles ctrlFiles;
        private Telerik.WinControls.UI.RadPageViewPage pvClosedAgreement;
        private ClosedAgreementsControl ctrlClosedAgreements;
        private Common.Editors.IpsPanel ipsPanel1;
        private ConsumerAgrDetailInfo ctrlAgrDetailInfo;
        private System.Windows.Forms.BindingSource bsGridLicenseAgreementView;
        private LicenseAgreementNotActiveControl ctrlLicenseAgreementNotActive;
        private Telerik.WinControls.UI.RadPageViewPage pvReportWPF;
        private System.Windows.Forms.Integration.ElementHost ehRegister;
    }
}
