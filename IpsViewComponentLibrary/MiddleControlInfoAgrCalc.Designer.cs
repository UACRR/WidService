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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.pvMain = new Telerik.WinControls.UI.RadPageView();
            this.pvActiveAgr = new Telerik.WinControls.UI.RadPageViewPage();
            this.gvLicenseAgr = new Telerik.WinControls.UI.RadGridView();
            this.pvSecond = new Telerik.WinControls.UI.RadPageView();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.agreementInfoCtrl = new IpsViewComponentLibrary.InformationAboutTheContractTitleControl();
            this.pvHistory = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.calculationCtrl = new IpsViewComponentLibrary.CalculationInfoControl();
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
            this.SuspendLayout();
            // 
            // pvMain
            // 
            this.pvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pvMain.Controls.Add(this.pvActiveAgr);
            this.pvMain.Controls.Add(this.pvCalculation);
            this.pvMain.DefaultPage = this.pvActiveAgr;
            this.pvMain.Location = new System.Drawing.Point(3, 253);
            this.pvMain.Name = "pvMain";
            this.pvMain.SelectedPage = this.pvCalculation;
            this.pvMain.Size = new System.Drawing.Size(1082, 285);
            this.pvMain.TabIndex = 4;
            this.pvMain.ThemeName = "Office2007Silver";
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
            gridViewTextBoxColumn1.FieldName = "License";
            gridViewTextBoxColumn1.HeaderText = "Ліцензія";
            gridViewTextBoxColumn1.Name = "License";
            gridViewTextBoxColumn1.Width = 188;
            gridViewTextBoxColumn2.FieldName = "Series";
            gridViewTextBoxColumn2.HeaderText = "Серія";
            gridViewTextBoxColumn2.Name = "Series";
            gridViewTextBoxColumn2.Width = 53;
            gridViewTextBoxColumn3.FieldName = "AgrNumber";
            gridViewTextBoxColumn3.HeaderText = "Номер договору";
            gridViewTextBoxColumn3.Name = "AgrNumber";
            gridViewTextBoxColumn3.Width = 129;
            gridViewTextBoxColumn4.FieldName = "DateBegin";
            gridViewTextBoxColumn4.HeaderText = "Дата початку";
            gridViewTextBoxColumn4.Name = "DateBegin";
            gridViewTextBoxColumn4.Width = 104;
            gridViewTextBoxColumn5.FieldName = "DateEnd";
            gridViewTextBoxColumn5.HeaderText = "Дата кінця";
            gridViewTextBoxColumn5.Name = "DateEnd";
            gridViewTextBoxColumn5.Width = 104;
            gridViewDecimalColumn1.FieldName = "Amount";
            gridViewDecimalColumn1.HeaderText = "Сума";
            gridViewDecimalColumn1.Name = "Amount";
            gridViewDecimalColumn1.Width = 93;
            gridViewTextBoxColumn6.FieldName = "State";
            gridViewTextBoxColumn6.HeaderText = "Стан";
            gridViewTextBoxColumn6.Name = "State";
            gridViewTextBoxColumn6.Width = 93;
            gridViewTextBoxColumn7.FieldName = "PeriodPayment";
            gridViewTextBoxColumn7.HeaderText = "Періодичність оплати";
            gridViewTextBoxColumn7.Name = "PeriodPayment";
            gridViewTextBoxColumn7.Width = 133;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "DateLastPayment";
            gridViewTextBoxColumn8.HeaderText = "Дата останньої оплати";
            gridViewTextBoxColumn8.Name = "DateLastPayment";
            gridViewTextBoxColumn8.Width = 148;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "Id";
            gridViewTextBoxColumn9.HeaderText = "Id";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "Id";
            gridViewTextBoxColumn9.Width = 48;
            this.gvLicenseAgr.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.gvLicenseAgr.MasterTemplate.ViewDefinition = tableViewDefinition1;
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
            this.calculationCtrl.Location = new System.Drawing.Point(0, 3);
            this.calculationCtrl.MaximumSize = new System.Drawing.Size(1237, 1000);
            this.calculationCtrl.MinimumSize = new System.Drawing.Size(400, 562);
            this.calculationCtrl.Name = "calculationCtrl";
            this.calculationCtrl.Size = new System.Drawing.Size(1031, 580);
            this.calculationCtrl.TabIndex = 0;
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
    }
}
