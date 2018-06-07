namespace ConsumerWorkplace_v_1._0
{
    partial class ConsumerCabinet
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2007SilverTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.gvConsumerList = new Telerik.WinControls.UI.RadGridView();
            this.userInfoCtrl = new IpsViewComponentLibrary.InformationOfUserControl();
            this.pvMain = new Telerik.WinControls.UI.RadPageView();
            this.pvActiveAgr = new Telerik.WinControls.UI.RadPageViewPage();
            this.gvLicenseAgr = new Telerik.WinControls.UI.RadGridView();
            this.pvSecond = new Telerik.WinControls.UI.RadPageView();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.agreementInfoCtrl = new IpsViewComponentLibrary.InformationAboutTheContractTitleControl();
            this.pvHistory = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.calculationCtrl = new IpsViewComponentLibrary.CalculationInfoControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvMain)).BeginInit();
            this.pvMain.SuspendLayout();
            this.pvActiveAgr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSecond)).BeginInit();
            this.pvSecond.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            this.pvCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvConsumerList
            // 
            this.gvConsumerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gvConsumerList.EnableGestures = false;
            this.gvConsumerList.Location = new System.Drawing.Point(13, 13);
            // 
            // 
            // 
            this.gvConsumerList.MasterTemplate.AllowAddNewRow = false;
            this.gvConsumerList.MasterTemplate.AllowColumnReorder = false;
            this.gvConsumerList.MasterTemplate.AllowDeleteRow = false;
            this.gvConsumerList.MasterTemplate.AllowDragToGroup = false;
            this.gvConsumerList.MasterTemplate.AllowEditRow = false;
            this.gvConsumerList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "innokpo";
            gridViewTextBoxColumn1.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn1.Name = "innokpo";
            gridViewTextBoxColumn1.Width = 56;
            gridViewTextBoxColumn2.FieldName = "name";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Name = "name";
            gridViewTextBoxColumn2.Width = 144;
            this.gvConsumerList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.gvConsumerList.MasterTemplate.EnableGrouping = false;
            this.gvConsumerList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvConsumerList.Name = "gvConsumerList";
            this.gvConsumerList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvConsumerList.ReadOnly = true;
            this.gvConsumerList.ShowGroupPanel = false;
            this.gvConsumerList.ShowGroupPanelScrollbars = false;
            this.gvConsumerList.Size = new System.Drawing.Size(220, 570);
            this.gvConsumerList.TabIndex = 0;
            this.gvConsumerList.ThemeName = "Office2007Silver";
            this.gvConsumerList.SelectionChanged += new System.EventHandler(this.gvConsumerList_SelectionChanged);
            // 
            // userInfoCtrl
            // 
            this.userInfoCtrl.Edrpou = "46546545";
            this.userInfoCtrl.EmailContactPerson = "qwerty@qwer.ty";
            this.userInfoCtrl.FaksContactPerson = "0999999999";
            this.userInfoCtrl.GroupOrHolding = "Копірайт";
            this.userInfoCtrl.Location = new System.Drawing.Point(241, 13);
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
            this.userInfoCtrl.TabIndex = 1;
            this.userInfoCtrl.WorkPositionContactPerson = "Президент";
            this.userInfoCtrl.WorkPositionManager = "Президент";
            // 
            // pvMain
            // 
            this.pvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pvMain.Controls.Add(this.pvActiveAgr);
            this.pvMain.Controls.Add(this.pvCalculation);
            this.pvMain.Location = new System.Drawing.Point(241, 262);
            this.pvMain.Name = "pvMain";
            this.pvMain.SelectedPage = this.pvCalculation;
            this.pvMain.Size = new System.Drawing.Size(1081, 321);
            this.pvMain.TabIndex = 2;
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
            this.pvActiveAgr.Size = new System.Drawing.Size(1060, 275);
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
            this.gvLicenseAgr.MasterTemplate.AllowColumnReorder = false;
            this.gvLicenseAgr.MasterTemplate.AllowDeleteRow = false;
            this.gvLicenseAgr.MasterTemplate.AllowDragToGroup = false;
            this.gvLicenseAgr.MasterTemplate.AllowEditRow = false;
            this.gvLicenseAgr.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn3.FieldName = "License";
            gridViewTextBoxColumn3.HeaderText = "Ліцензія";
            gridViewTextBoxColumn3.Name = "License";
            gridViewTextBoxColumn3.Width = 175;
            gridViewTextBoxColumn4.FieldName = "Series";
            gridViewTextBoxColumn4.HeaderText = "Серія";
            gridViewTextBoxColumn4.Name = "Series";
            gridViewTextBoxColumn5.FieldName = "NumberAgr";
            gridViewTextBoxColumn5.HeaderText = "Номер договору";
            gridViewTextBoxColumn5.Name = "NumberAgr";
            gridViewTextBoxColumn5.Width = 121;
            gridViewTextBoxColumn6.FieldName = "DateBegin";
            gridViewTextBoxColumn6.HeaderText = "Дата початку";
            gridViewTextBoxColumn6.Name = "DateBegin";
            gridViewTextBoxColumn6.Width = 97;
            gridViewTextBoxColumn7.FieldName = "DateEnd";
            gridViewTextBoxColumn7.HeaderText = "Дата кінця";
            gridViewTextBoxColumn7.Name = "DateEnd";
            gridViewTextBoxColumn7.Width = 97;
            gridViewDecimalColumn1.FieldName = "Amount";
            gridViewDecimalColumn1.HeaderText = "Сума";
            gridViewDecimalColumn1.Name = "Amount";
            gridViewDecimalColumn1.Width = 87;
            gridViewTextBoxColumn8.FieldName = "Type";
            gridViewTextBoxColumn8.HeaderText = "Тип";
            gridViewTextBoxColumn8.Name = "Type";
            gridViewTextBoxColumn8.Width = 67;
            gridViewTextBoxColumn9.FieldName = "State";
            gridViewTextBoxColumn9.HeaderText = "Стан";
            gridViewTextBoxColumn9.Name = "State";
            gridViewTextBoxColumn9.Width = 87;
            gridViewTextBoxColumn10.FieldName = "PeriodPayment";
            gridViewTextBoxColumn10.HeaderText = "Періодичність оплати";
            gridViewTextBoxColumn10.Name = "PeriodPayment";
            gridViewTextBoxColumn10.Width = 125;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewTextBoxColumn11.FieldName = "LastPayDate";
            gridViewTextBoxColumn11.HeaderText = "Дата останньої оплати";
            gridViewTextBoxColumn11.Name = "LastPayDate";
            gridViewTextBoxColumn11.Width = 139;
            gridViewTextBoxColumn11.WrapText = true;
            this.gvLicenseAgr.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11});
            this.gvLicenseAgr.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvLicenseAgr.Name = "gvLicenseAgr";
            this.gvLicenseAgr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvLicenseAgr.ReadOnly = true;
            this.gvLicenseAgr.ShowGroupPanel = false;
            this.gvLicenseAgr.Size = new System.Drawing.Size(1057, 131);
            this.gvLicenseAgr.TabIndex = 11;
            this.gvLicenseAgr.ThemeName = "Office2007Silver";
            // 
            // pvSecond
            // 
            this.pvSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pvSecond.Controls.Add(this.pvAgreement);
            this.pvSecond.Controls.Add(this.pvHistory);
            this.pvSecond.Location = new System.Drawing.Point(2, 140);
            this.pvSecond.Name = "pvSecond";
            this.pvSecond.SelectedPage = this.pvAgreement;
            this.pvSecond.Size = new System.Drawing.Size(1058, 137);
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
            this.pvAgreement.Size = new System.Drawing.Size(981, 116);
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
            this.agreementInfoCtrl.FixedPayment = "99100.25";
            this.agreementInfoCtrl.Implementation = "Немає акту";
            this.agreementInfoCtrl.IsAttach = false;
            this.agreementInfoCtrl.IsPaid = false;
            this.agreementInfoCtrl.IsProlongation = false;
            this.agreementInfoCtrl.IsState = false;
            this.agreementInfoCtrl.IsTorn = false;
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
            this.pvHistory.Size = new System.Drawing.Size(981, 116);
            this.pvHistory.Text = "Історія";
            // 
            // pvCalculation
            // 
            this.pvCalculation.AutoScroll = true;
            this.pvCalculation.Controls.Add(this.calculationCtrl);
            this.pvCalculation.ItemSize = new System.Drawing.SizeF(78F, 26F);
            this.pvCalculation.Location = new System.Drawing.Point(10, 35);
            this.pvCalculation.Name = "pvCalculation";
            this.pvCalculation.Size = new System.Drawing.Size(1060, 275);
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
            // ConsumerCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 595);
            this.Controls.Add(this.pvMain);
            this.Controls.Add(this.userInfoCtrl);
            this.Controls.Add(this.gvConsumerList);
            this.Name = "ConsumerCabinet";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ConsumerCabinet";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvMain)).EndInit();
            this.pvMain.ResumeLayout(false);
            this.pvActiveAgr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLicenseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pvSecond)).EndInit();
            this.pvSecond.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            this.pvCalculation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme;
        private Telerik.WinControls.UI.RadGridView gvConsumerList;
        private IpsViewComponentLibrary.InformationOfUserControl userInfoCtrl;
        private Telerik.WinControls.UI.RadPageView pvMain;
        private Telerik.WinControls.UI.RadPageViewPage pvActiveAgr;
        private Telerik.WinControls.UI.RadPageViewPage pvCalculation;
        private Telerik.WinControls.UI.RadPageView pvSecond;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvHistory;
        private IpsViewComponentLibrary.InformationAboutTheContractTitleControl agreementInfoCtrl;
        private Telerik.WinControls.UI.RadGridView gvLicenseAgr;
        private IpsViewComponentLibrary.CalculationInfoControl calculationCtrl;
    }
}
