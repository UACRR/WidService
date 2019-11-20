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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.registerControl1 = new IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.RegisterControl();
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
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 48;
            gridViewTextBoxColumn2.FieldName = "License";
            gridViewTextBoxColumn2.HeaderText = "Ліцензія";
            gridViewTextBoxColumn2.MinWidth = 180;
            gridViewTextBoxColumn2.Name = "License";
            gridViewTextBoxColumn2.Width = 180;
            gridViewTextBoxColumn3.FieldName = "Series";
            gridViewTextBoxColumn3.HeaderText = "Серія";
            gridViewTextBoxColumn3.MinWidth = 80;
            gridViewTextBoxColumn3.Name = "Series";
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn4.FieldName = "AgrNumber";
            gridViewTextBoxColumn4.HeaderText = "Номер договору";
            gridViewTextBoxColumn4.MinWidth = 105;
            gridViewTextBoxColumn4.Name = "AgrNumber";
            gridViewTextBoxColumn4.Width = 105;
            gridViewTextBoxColumn5.FieldName = "DateBegin";
            gridViewTextBoxColumn5.HeaderText = "Дата початку";
            gridViewTextBoxColumn5.MaxWidth = 80;
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "DateBegin";
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "DateEnd";
            gridViewTextBoxColumn6.HeaderText = "Дата завершення";
            gridViewTextBoxColumn6.MaxWidth = 80;
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Name = "DateEnd";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.DataType = typeof(decimal);
            gridViewTextBoxColumn7.FieldName = "MinRate";
            gridViewTextBoxColumn7.FormatString = "{0:##0.00}";
            gridViewTextBoxColumn7.HeaderText = "Тариф";
            gridViewTextBoxColumn7.MaxWidth = 90;
            gridViewTextBoxColumn7.MinWidth = 90;
            gridViewTextBoxColumn7.Name = "MinRate";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 90;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewDecimalColumn1.FieldName = "MinAmount";
            gridViewDecimalColumn1.FormatString = "{0:### ### ##0.00}";
            gridViewDecimalColumn1.HeaderText = "Гарантійний платіж";
            gridViewDecimalColumn1.MinWidth = 90;
            gridViewDecimalColumn1.Name = "MinAmount";
            gridViewDecimalColumn1.Width = 90;
            gridViewDecimalColumn1.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "State";
            gridViewTextBoxColumn8.HeaderText = "Статус";
            gridViewTextBoxColumn8.MaxWidth = 150;
            gridViewTextBoxColumn8.MinWidth = 100;
            gridViewTextBoxColumn8.Name = "State";
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.FieldName = "PeriodPayment";
            gridViewTextBoxColumn9.HeaderText = "Періодичність оплати";
            gridViewTextBoxColumn9.MaxWidth = 115;
            gridViewTextBoxColumn9.MinWidth = 100;
            gridViewTextBoxColumn9.Name = "PeriodPayment";
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.FieldName = "DateLastPayment";
            gridViewTextBoxColumn10.HeaderText = "Дата останньої оплати";
            gridViewTextBoxColumn10.MaxWidth = 80;
            gridViewTextBoxColumn10.MinWidth = 80;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "DateLastPayment";
            gridViewTextBoxColumn10.Width = 80;
            gridViewTextBoxColumn10.WrapText = true;
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
            this.gvLicenseAgr.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewCheckBoxColumn1,
            gridViewCommandColumn1});
            this.gvLicenseAgr.MasterTemplate.DataSource = this.bsGridLicenseAgreementView;
            this.gvLicenseAgr.MasterTemplate.ViewDefinition = tableViewDefinition1;
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
            this.pvMain.SelectedPage = this.pvActiveAgr;
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
            this.pvReportWPF.Controls.Add(this.elementHost1);
            this.pvReportWPF.ItemSize = new System.Drawing.SizeF(78F, 27F);
            this.pvReportWPF.Location = new System.Drawing.Point(5, 41);
            this.pvReportWPF.Name = "pvReportWPF";
            this.pvReportWPF.Size = new System.Drawing.Size(985, 444);
            this.pvReportWPF.Text = "Звіти (WPF)";
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(985, 444);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.registerControl1;
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
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.RegisterControl registerControl1;
    }
}
