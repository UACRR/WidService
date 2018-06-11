namespace IpsViewComponentLibrary
{
    partial class MiddleControlInfoAgrCalc
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn25 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn26 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn27 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pvMain = new Telerik.WinControls.UI.RadPageView();
            this.pvActiveAgr = new Telerik.WinControls.UI.RadPageViewPage();
            this.gvLicenseAgr = new Telerik.WinControls.UI.RadGridView();
            this.pvSecond = new Telerik.WinControls.UI.RadPageView();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.agreementInfoCtrl = new IpsViewComponentLibrary.InformationAboutTheContractTitleControl();
            this.pvHistory = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.calculationCtrl = new IpsViewComponentLibrary.CalculationInfoControl();
            this.pvReports = new Telerik.WinControls.UI.RadPageViewPage();
            this.reportsControl = new IpsViewComponentLibrary.ReportsControl();
            this.userInfoCtrl = new IpsViewComponentLibrary.InformationOfUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.pvMain)).BeginInit();
            this.pvMain.SuspendLayout();
            this.pvActiveAgr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSecond)).BeginInit();
            this.pvSecond.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            this.pvCalculation.SuspendLayout();
            this.pvReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // pvMain
            // 
            this.pvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pvMain.Controls.Add(this.pvActiveAgr);
            this.pvMain.Controls.Add(this.pvCalculation);
            this.pvMain.Controls.Add(this.pvReports);
            this.pvMain.DefaultPage = this.pvActiveAgr;
            this.pvMain.Location = new System.Drawing.Point(3, 253);
            this.pvMain.Name = "pvMain";
            this.pvMain.SelectedPage = this.pvReports;
            this.pvMain.Size = new System.Drawing.Size(1082, 285);
            this.pvMain.TabIndex = 4;
            this.pvMain.ThemeName = "Office2007Silver";
            this.pvMain.SelectedPageChanged += new System.EventHandler(this.pvMain_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pvActiveAgr
            // 
            this.pvActiveAgr.Controls.Add(this.gvLicenseAgr);
            this.pvActiveAgr.Controls.Add(this.pvSecond);
            this.pvActiveAgr.ItemSize = new System.Drawing.SizeF(107F, 26F);
            this.pvActiveAgr.Location = new System.Drawing.Point(10, 35);
            this.pvActiveAgr.Name = "pvActiveAgr";
            this.pvActiveAgr.Size = new System.Drawing.Size(1061, 239);
            this.pvActiveAgr.Text = "Активні договора";
            // 
            // gvLicenseAgr
            // 
            this.gvLicenseAgr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvLicenseAgr.AutoScroll = true;
            this.gvLicenseAgr.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gvLicenseAgr.MasterTemplate.AllowAddNewRow = false;
            this.gvLicenseAgr.MasterTemplate.AllowDeleteRow = false;
            this.gvLicenseAgr.MasterTemplate.AllowDragToGroup = false;
            this.gvLicenseAgr.MasterTemplate.AllowEditRow = false;
            this.gvLicenseAgr.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn19.FieldName = "License";
            gridViewTextBoxColumn19.HeaderText = "Ліцензія";
            gridViewTextBoxColumn19.Name = "License";
            gridViewTextBoxColumn19.Width = 188;
            gridViewTextBoxColumn20.FieldName = "Series";
            gridViewTextBoxColumn20.HeaderText = "Серія";
            gridViewTextBoxColumn20.Name = "Series";
            gridViewTextBoxColumn20.Width = 53;
            gridViewTextBoxColumn21.FieldName = "AgrNumber";
            gridViewTextBoxColumn21.HeaderText = "Номер договору";
            gridViewTextBoxColumn21.Name = "AgrNumber";
            gridViewTextBoxColumn21.Width = 129;
            gridViewTextBoxColumn22.FieldName = "DateBegin";
            gridViewTextBoxColumn22.HeaderText = "Дата початку";
            gridViewTextBoxColumn22.Name = "DateBegin";
            gridViewTextBoxColumn22.Width = 104;
            gridViewTextBoxColumn23.FieldName = "DateEnd";
            gridViewTextBoxColumn23.HeaderText = "Дата кінця";
            gridViewTextBoxColumn23.Name = "DateEnd";
            gridViewTextBoxColumn23.Width = 104;
            gridViewDecimalColumn3.FieldName = "Amount";
            gridViewDecimalColumn3.HeaderText = "Сума";
            gridViewDecimalColumn3.Name = "Amount";
            gridViewDecimalColumn3.Width = 93;
            gridViewTextBoxColumn24.FieldName = "State";
            gridViewTextBoxColumn24.HeaderText = "Стан";
            gridViewTextBoxColumn24.Name = "State";
            gridViewTextBoxColumn24.Width = 93;
            gridViewTextBoxColumn25.FieldName = "PeriodPayment";
            gridViewTextBoxColumn25.HeaderText = "Періодичність оплати";
            gridViewTextBoxColumn25.Name = "PeriodPayment";
            gridViewTextBoxColumn25.Width = 133;
            gridViewTextBoxColumn25.WrapText = true;
            gridViewTextBoxColumn26.FieldName = "DateLastPayment";
            gridViewTextBoxColumn26.HeaderText = "Дата останньої оплати";
            gridViewTextBoxColumn26.Name = "DateLastPayment";
            gridViewTextBoxColumn26.Width = 148;
            gridViewTextBoxColumn26.WrapText = true;
            gridViewTextBoxColumn27.FieldName = "Id";
            gridViewTextBoxColumn27.HeaderText = "Id";
            gridViewTextBoxColumn27.IsVisible = false;
            gridViewTextBoxColumn27.Name = "Id";
            gridViewTextBoxColumn27.Width = 48;
            this.gvLicenseAgr.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn24,
            gridViewTextBoxColumn25,
            gridViewTextBoxColumn26,
            gridViewTextBoxColumn27});
            this.gvLicenseAgr.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gvLicenseAgr.Name = "gvLicenseAgr";
            this.gvLicenseAgr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvLicenseAgr.ReadOnly = true;
            this.gvLicenseAgr.ShowGroupPanel = false;
            this.gvLicenseAgr.Size = new System.Drawing.Size(1058, 131);
            this.gvLicenseAgr.TabIndex = 11;
            this.gvLicenseAgr.ThemeName = "Office2007Silver";
            this.gvLicenseAgr.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvLicenseAgr_CurrentRowChanged);
            // 
            // pvSecond
            // 
            this.pvSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pvSecond.Controls.Add(this.pvAgreement);
            this.pvSecond.Controls.Add(this.pvHistory);
            this.pvSecond.DefaultPage = this.pvAgreement;
            this.pvSecond.Location = new System.Drawing.Point(2, 140);
            this.pvSecond.Name = "pvSecond";
            this.pvSecond.SelectedPage = this.pvAgreement;
            this.pvSecond.Size = new System.Drawing.Size(1059, 105);
            this.pvSecond.TabIndex = 2;
            this.pvSecond.ThemeName = "Office2007Silver";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvSecond.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvSecond.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pvSecond.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvAgreement
            // 
            this.pvAgreement.AutoScroll = true;
            this.pvAgreement.Controls.Add(this.agreementInfoCtrl);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(57F, 26F);
            this.pvAgreement.Location = new System.Drawing.Point(66, 10);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(982, 84);
            this.pvAgreement.Text = "Договір";
            // 
            // agreementInfoCtrl
            // 
            this.agreementInfoCtrl.Agent = "";
            this.agreementInfoCtrl.Amount = "94500";
            this.agreementInfoCtrl.Bank = "960";
            this.agreementInfoCtrl.DateAgr = "12.12.2020";
            this.agreementInfoCtrl.DateBegin = "10.10.1010";
            this.agreementInfoCtrl.DateEnd = "10.10.1010";
            this.agreementInfoCtrl.DistributedAmount = "640";
            this.agreementInfoCtrl.Implementation = "Немає акту";
            this.agreementInfoCtrl.IsAttach = false;
            this.agreementInfoCtrl.IsPaid = false;
            this.agreementInfoCtrl.IsProlongation = false;
            this.agreementInfoCtrl.IsState = false;
            this.agreementInfoCtrl.Location = new System.Drawing.Point(3, 3);
            this.agreementInfoCtrl.MaximumSize = new System.Drawing.Size(788, 277);
            this.agreementInfoCtrl.MinimumSize = new System.Drawing.Size(788, 277);
            this.agreementInfoCtrl.MinPayment = "14799.50";
            this.agreementInfoCtrl.Name = "agreementInfoCtrl";
            this.agreementInfoCtrl.Notation = "";
            this.agreementInfoCtrl.NumberAgr = "КБЦКП - 95/87845-45а";
            this.agreementInfoCtrl.Percent = "3";
            this.agreementInfoCtrl.PeriodReportind = "Щоночі";
            this.agreementInfoCtrl.Size = new System.Drawing.Size(788, 277);
            this.agreementInfoCtrl.State = "Не дійсний";
            this.agreementInfoCtrl.TabIndex = 0;
            // 
            // pvHistory
            // 
            this.pvHistory.ItemSize = new System.Drawing.SizeF(57F, 26F);
            this.pvHistory.Location = new System.Drawing.Point(66, 10);
            this.pvHistory.Name = "pvHistory";
            this.pvHistory.Size = new System.Drawing.Size(973, 116);
            this.pvHistory.Text = "Історія";
            // 
            // pvCalculation
            // 
            this.pvCalculation.AutoScroll = true;
            this.pvCalculation.Controls.Add(this.calculationCtrl);
            this.pvCalculation.ItemSize = new System.Drawing.SizeF(78F, 26F);
            this.pvCalculation.Location = new System.Drawing.Point(10, 35);
            this.pvCalculation.Name = "pvCalculation";
            this.pvCalculation.Size = new System.Drawing.Size(1061, 239);
            this.pvCalculation.Text = "Розрахунки";
            // 
            // calculationCtrl
            // 
            this.calculationCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calculationCtrl.Location = new System.Drawing.Point(0, 3);
            this.calculationCtrl.MaximumSize = new System.Drawing.Size(1237, 1000);
            this.calculationCtrl.MinimumSize = new System.Drawing.Size(400, 562);
            this.calculationCtrl.Name = "calculationCtrl";
            this.calculationCtrl.Size = new System.Drawing.Size(980, 580);
            this.calculationCtrl.TabIndex = 0;
            // 
            // pvReports
            // 
            this.pvReports.AutoScroll = true;
            this.pvReports.Controls.Add(this.reportsControl);
            this.pvReports.ItemSize = new System.Drawing.SizeF(43F, 26F);
            this.pvReports.Location = new System.Drawing.Point(10, 35);
            this.pvReports.Name = "pvReports";
            this.pvReports.Size = new System.Drawing.Size(1061, 239);
            this.pvReports.Text = "Звіти";
            // 
            // reportsControl
            // 
            this.reportsControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportsControl.Location = new System.Drawing.Point(4, 4);
            this.reportsControl.Name = "reportsControl";
            this.reportsControl.Size = new System.Drawing.Size(1020, 470);
            this.reportsControl.TabIndex = 0;
            // 
            // userInfoCtrl
            // 
            this.userInfoCtrl.Edrpou = "46546545";
            this.userInfoCtrl.EmailContactPerson = "qwerty@qwer.ty";
            this.userInfoCtrl.FaksContactPerson = "0999999999";
            this.userInfoCtrl.GroupOrHolding = "Копірайт";
            this.userInfoCtrl.Location = new System.Drawing.Point(3, 3);
            this.userInfoCtrl.MaximumSize = new System.Drawing.Size(912, 242);
            this.userInfoCtrl.MinimumSize = new System.Drawing.Size(912, 242);
            this.userInfoCtrl.MobilePnoneContactPerson = "+380999999999";
            this.userInfoCtrl.Name = "userInfoCtrl";
            this.userInfoCtrl.NameInfo = "ррррр";
            this.userInfoCtrl.OrganisationForm = "ТОВ";
            this.userInfoCtrl.PhoneContactPerson = "+380999999999";
            this.userInfoCtrl.PhoneManager = "+380999999999";
            this.userInfoCtrl.PibContactPerson = "Прізвище Ім\'я Побатькові";
            this.userInfoCtrl.PibManager = "Прізвище КапецьякевеличезнеІм\'я Побатькові";
            this.userInfoCtrl.Size = new System.Drawing.Size(912, 242);
            this.userInfoCtrl.TabIndex = 3;
            this.userInfoCtrl.WorkPositionContactPerson = "Президент";
            this.userInfoCtrl.WorkPositionManager = "Президент";
            // 
            // MiddleControlInfoAgrCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pvMain);
            this.Controls.Add(this.userInfoCtrl);
            this.Name = "MiddleControlInfoAgrCalc";
            this.Size = new System.Drawing.Size(1088, 541);
            ((System.ComponentModel.ISupportInitialize)(this.pvMain)).EndInit();
            this.pvMain.ResumeLayout(false);
            this.pvActiveAgr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSecond)).EndInit();
            this.pvSecond.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            this.pvCalculation.ResumeLayout(false);
            this.pvReports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pvMain;
        private Telerik.WinControls.UI.RadPageViewPage pvActiveAgr;
        private Telerik.WinControls.UI.RadGridView gvLicenseAgr;
        private Telerik.WinControls.UI.RadPageView pvSecond;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private InformationAboutTheContractTitleControl agreementInfoCtrl;
        private Telerik.WinControls.UI.RadPageViewPage pvHistory;
        private Telerik.WinControls.UI.RadPageViewPage pvCalculation;
        private CalculationInfoControl calculationCtrl;
        private InformationOfUserControl userInfoCtrl;
        private Telerik.WinControls.UI.RadPageViewPage pvReports;
        private ReportsControl reportsControl;
    }
}
