namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinet
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvGeneralAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlGeneralAgreement = new IpsViewComponentLibrary.MiddleControlCabinetGenAgreement();
            this.pvLicence = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlLicense = new IpsViewComponentLibrary.MiddleControlCabinetLicenses();
            this.pvRequest = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlRequest = new IpsViewComponentLibrary.MiddleControlCabinetReqRef();
            this.pvReference = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlReference = new IpsViewComponentLibrary.MiddleControlCabinetReqRef();
            this.pvPayslips = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPayslips = new IpsViewComponentLibrary.MiddleControlCabinetPayslips();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlCalculation = new IpsViewComponentLibrary.CalculationInfoControl();
            this.pvPays = new Telerik.WinControls.UI.RadPageViewPage();
            this.middleControlCabinetPayments1 = new IpsViewComponentLibrary.MiddleControlCabinetPayments();
            this.pvAvances = new Telerik.WinControls.UI.RadPageViewPage();
            this.middleControlCabinetAvances1 = new IpsViewComponentLibrary.MiddleControlCabinetAvances();
            this.pvContacts = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlContactHeader = new IpsViewComponentLibrary.InformationOfUserControl();
            this.pvFiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlFiles = new IpsViewComponentLibrary.MiddleControlCabinetFiles();
            this.pvAgent = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgent = new IpsViewComponentLibrary.MiddleControlCabinetAgent();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvGeneralAgreement.SuspendLayout();
            this.pvLicence.SuspendLayout();
            this.pvRequest.SuspendLayout();
            this.pvReference.SuspendLayout();
            this.pvPayslips.SuspendLayout();
            this.pvCalculation.SuspendLayout();
            this.pvPays.SuspendLayout();
            this.pvAvances.SuspendLayout();
            this.pvContacts.SuspendLayout();
            this.pvFiles.SuspendLayout();
            this.pvAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvGeneralAgreement);
            this.pageView.Controls.Add(this.pvLicence);
            this.pageView.Controls.Add(this.pvRequest);
            this.pageView.Controls.Add(this.pvReference);
            this.pageView.Controls.Add(this.pvPayslips);
            this.pageView.Controls.Add(this.pvCalculation);
            this.pageView.Controls.Add(this.pvPays);
            this.pageView.Controls.Add(this.pvAvances);
            this.pageView.Controls.Add(this.pvContacts);
            this.pageView.Controls.Add(this.pvFiles);
            this.pageView.Controls.Add(this.pvAgent);
            this.pageView.DefaultPage = this.pvGeneralAgreement;
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Margin = new System.Windows.Forms.Padding(4);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvPayslips;
            this.pageView.Size = new System.Drawing.Size(1528, 763);
            this.pageView.TabIndex = 0;
            this.pageView.ThemeName = "Office2013Light";
            this.pageView.SelectedPageChanged += new System.EventHandler(this.pageView_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ShowItemCloseButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight;
            // 
            // pvGeneralAgreement
            // 
            this.pvGeneralAgreement.Controls.Add(this.ctrlGeneralAgreement);
            this.pvGeneralAgreement.ItemSize = new System.Drawing.SizeF(71F, 27F);
            this.pvGeneralAgreement.Location = new System.Drawing.Point(5, 31);
            this.pvGeneralAgreement.Margin = new System.Windows.Forms.Padding(4);
            this.pvGeneralAgreement.Name = "pvGeneralAgreement";
            this.pvGeneralAgreement.Size = new System.Drawing.Size(1518, 727);
            this.pvGeneralAgreement.Text = "Ген. угода";
            // 
            // ctrlGeneralAgreement
            // 
            this.ctrlGeneralAgreement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGeneralAgreement.Location = new System.Drawing.Point(0, 0);
            this.ctrlGeneralAgreement.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlGeneralAgreement.MinimumSize = new System.Drawing.Size(1216, 369);
            this.ctrlGeneralAgreement.Name = "ctrlGeneralAgreement";
            this.ctrlGeneralAgreement.Size = new System.Drawing.Size(1518, 727);
            this.ctrlGeneralAgreement.TabIndex = 0;
            // 
            // pvLicence
            // 
            this.pvLicence.Controls.Add(this.ctrlLicense);
            this.pvLicence.ItemSize = new System.Drawing.SizeF(58F, 27F);
            this.pvLicence.Location = new System.Drawing.Point(8, 39);
            this.pvLicence.Margin = new System.Windows.Forms.Padding(4);
            this.pvLicence.Name = "pvLicence";
            this.pvLicence.Size = new System.Drawing.Size(1512, 716);
            this.pvLicence.Text = "Ліцензії";
            // 
            // ctrlLicense
            // 
            this.ctrlLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLicense.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicense.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlLicense.MinimumSize = new System.Drawing.Size(1096, 662);
            this.ctrlLicense.Name = "ctrlLicense";
            this.ctrlLicense.Size = new System.Drawing.Size(1512, 716);
            this.ctrlLicense.TabIndex = 0;
            // 
            // pvRequest
            // 
            this.pvRequest.Controls.Add(this.ctrlRequest);
            this.pvRequest.ItemSize = new System.Drawing.SizeF(54F, 27F);
            this.pvRequest.Location = new System.Drawing.Point(7, 38);
            this.pvRequest.Margin = new System.Windows.Forms.Padding(4);
            this.pvRequest.Name = "pvRequest";
            this.pvRequest.Size = new System.Drawing.Size(1515, 719);
            this.pvRequest.Text = "Заявки";
            // 
            // ctrlRequest
            // 
            this.ctrlRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRequest.Location = new System.Drawing.Point(0, 0);
            this.ctrlRequest.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlRequest.Name = "ctrlRequest";
            this.ctrlRequest.Size = new System.Drawing.Size(1515, 719);
            this.ctrlRequest.TabIndex = 0;
            this.ctrlRequest.TypeControl = IpsViewComponentLibrary.ControlRequestOrReferenceType.None;
            // 
            // pvReference
            // 
            this.pvReference.Controls.Add(this.ctrlReference);
            this.pvReference.ItemSize = new System.Drawing.SizeF(60F, 27F);
            this.pvReference.Location = new System.Drawing.Point(7, 38);
            this.pvReference.Margin = new System.Windows.Forms.Padding(4);
            this.pvReference.Name = "pvReference";
            this.pvReference.Size = new System.Drawing.Size(1515, 719);
            this.pvReference.Text = "Довідки";
            // 
            // ctrlReference
            // 
            this.ctrlReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlReference.Location = new System.Drawing.Point(0, 0);
            this.ctrlReference.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlReference.Name = "ctrlReference";
            this.ctrlReference.Size = new System.Drawing.Size(1515, 719);
            this.ctrlReference.TabIndex = 0;
            this.ctrlReference.TypeControl = IpsViewComponentLibrary.ControlRequestOrReferenceType.None;
            // 
            // pvPayslips
            // 
            this.pvPayslips.Controls.Add(this.ctrlPayslips);
            this.pvPayslips.ItemSize = new System.Drawing.SizeF(35F, 27F);
            this.pvPayslips.Location = new System.Drawing.Point(5, 31);
            this.pvPayslips.Margin = new System.Windows.Forms.Padding(4);
            this.pvPayslips.Name = "pvPayslips";
            this.pvPayslips.Size = new System.Drawing.Size(1518, 727);
            this.pvPayslips.Text = "Р/Л";
            // 
            // ctrlPayslips
            // 
            this.ctrlPayslips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPayslips.Location = new System.Drawing.Point(0, 0);
            this.ctrlPayslips.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlPayslips.MusicDesing = null;
            this.ctrlPayslips.Name = "ctrlPayslips";
            this.ctrlPayslips.Size = new System.Drawing.Size(1518, 727);
            this.ctrlPayslips.TabIndex = 0;
            // 
            // pvCalculation
            // 
            this.pvCalculation.AutoScroll = true;
            this.pvCalculation.Controls.Add(this.ctrlCalculation);
            this.pvCalculation.ItemSize = new System.Drawing.SizeF(80F, 27F);
            this.pvCalculation.Location = new System.Drawing.Point(7, 38);
            this.pvCalculation.Margin = new System.Windows.Forms.Padding(4);
            this.pvCalculation.Name = "pvCalculation";
            this.pvCalculation.Size = new System.Drawing.Size(1515, 719);
            this.pvCalculation.Text = "Розрахунки";
            // 
            // ctrlCalculation
            // 
            this.ctrlCalculation.CurrentAgreementController = null;
            this.ctrlCalculation.Customer = null;
            this.ctrlCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCalculation.Location = new System.Drawing.Point(0, 0);
            this.ctrlCalculation.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlCalculation.MaximumSize = new System.Drawing.Size(4000, 1231);
            this.ctrlCalculation.MinimumSize = new System.Drawing.Size(533, 692);
            this.ctrlCalculation.Name = "ctrlCalculation";
            this.ctrlCalculation.Size = new System.Drawing.Size(1515, 719);
            this.ctrlCalculation.TabIndex = 0;
            this.ctrlCalculation.TypeRights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            // 
            // pvPays
            // 
            this.pvPays.Controls.Add(this.middleControlCabinetPayments1);
            this.pvPays.ItemSize = new System.Drawing.SizeF(60F, 27F);
            this.pvPays.Location = new System.Drawing.Point(7, 36);
            this.pvPays.Margin = new System.Windows.Forms.Padding(4);
            this.pvPays.Name = "pvPays";
            this.pvPays.Size = new System.Drawing.Size(1515, 721);
            this.pvPays.Text = "Платежі";
            // 
            // middleControlCabinetPayments1
            // 
            this.middleControlCabinetPayments1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleControlCabinetPayments1.Location = new System.Drawing.Point(0, 0);
            this.middleControlCabinetPayments1.Margin = new System.Windows.Forms.Padding(5);
            this.middleControlCabinetPayments1.Name = "middleControlCabinetPayments1";
            this.middleControlCabinetPayments1.Size = new System.Drawing.Size(1515, 721);
            this.middleControlCabinetPayments1.TabIndex = 0;
            // 
            // pvAvances
            // 
            this.pvAvances.Controls.Add(this.middleControlCabinetAvances1);
            this.pvAvances.ItemSize = new System.Drawing.SizeF(55F, 27F);
            this.pvAvances.Location = new System.Drawing.Point(7, 36);
            this.pvAvances.Margin = new System.Windows.Forms.Padding(4);
            this.pvAvances.Name = "pvAvances";
            this.pvAvances.Size = new System.Drawing.Size(1515, 721);
            this.pvAvances.Text = "Аванси";
            // 
            // middleControlCabinetAvances1
            // 
            this.middleControlCabinetAvances1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleControlCabinetAvances1.Location = new System.Drawing.Point(0, 0);
            this.middleControlCabinetAvances1.Margin = new System.Windows.Forms.Padding(5);
            this.middleControlCabinetAvances1.Name = "middleControlCabinetAvances1";
            this.middleControlCabinetAvances1.Size = new System.Drawing.Size(1515, 721);
            this.middleControlCabinetAvances1.TabIndex = 0;
            // 
            // pvContacts
            // 
            this.pvContacts.Controls.Add(this.ctrlContactHeader);
            this.pvContacts.ItemSize = new System.Drawing.SizeF(66F, 27F);
            this.pvContacts.Location = new System.Drawing.Point(7, 36);
            this.pvContacts.Margin = new System.Windows.Forms.Padding(4);
            this.pvContacts.Name = "pvContacts";
            this.pvContacts.Size = new System.Drawing.Size(1515, 721);
            this.pvContacts.Text = "Контакти";
            // 
            // ctrlContactHeader
            // 
            this.ctrlContactHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlContactHeader.Edrpou = "";
            this.ctrlContactHeader.EmailContactPerson = "";
            this.ctrlContactHeader.EmailManager = "";
            this.ctrlContactHeader.GroupOrHolding = "Копірайт";
            this.ctrlContactHeader.HoldingVisible = false;
            this.ctrlContactHeader.Location = new System.Drawing.Point(0, 0);
            this.ctrlContactHeader.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlContactHeader.MaximumSize = new System.Drawing.Size(1216, 257);
            this.ctrlContactHeader.MinimumSize = new System.Drawing.Size(1216, 257);
            this.ctrlContactHeader.Name = "ctrlContactHeader";
            this.ctrlContactHeader.NameInfo = "";
            this.ctrlContactHeader.OrganisationForm = "";
            this.ctrlContactHeader.OrganisationFormVisible = false;
            this.ctrlContactHeader.PhoneContactPerson = "";
            this.ctrlContactHeader.PhoneManager = "";
            this.ctrlContactHeader.PibContactPerson = "";
            this.ctrlContactHeader.PibManager = "";
            this.ctrlContactHeader.Size = new System.Drawing.Size(1216, 257);
            this.ctrlContactHeader.TabIndex = 1;
            // 
            // pvFiles
            // 
            this.pvFiles.Controls.Add(this.ctrlFiles);
            this.pvFiles.ItemSize = new System.Drawing.SizeF(51F, 27F);
            this.pvFiles.Location = new System.Drawing.Point(7, 38);
            this.pvFiles.Margin = new System.Windows.Forms.Padding(4);
            this.pvFiles.Name = "pvFiles";
            this.pvFiles.Size = new System.Drawing.Size(1515, 719);
            this.pvFiles.Text = "Файли";
            // 
            // ctrlFiles
            // 
            this.ctrlFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFiles.Location = new System.Drawing.Point(0, 0);
            this.ctrlFiles.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlFiles.MinimumSize = new System.Drawing.Size(1217, 537);
            this.ctrlFiles.Name = "ctrlFiles";
            this.ctrlFiles.Size = new System.Drawing.Size(1515, 719);
            this.ctrlFiles.TabIndex = 0;
            // 
            // pvAgent
            // 
            this.pvAgent.Controls.Add(this.ctrlAgent);
            this.pvAgent.ItemSize = new System.Drawing.SizeF(88F, 27F);
            this.pvAgent.Location = new System.Drawing.Point(7, 38);
            this.pvAgent.Margin = new System.Windows.Forms.Padding(4);
            this.pvAgent.Name = "pvAgent";
            this.pvAgent.Size = new System.Drawing.Size(1515, 719);
            this.pvAgent.Text = "Представник";
            // 
            // ctrlAgent
            // 
            this.ctrlAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAgent.Location = new System.Drawing.Point(0, 0);
            this.ctrlAgent.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlAgent.MinimumSize = new System.Drawing.Size(1217, 649);
            this.ctrlAgent.Name = "ctrlAgent";
            this.ctrlAgent.Size = new System.Drawing.Size(1515, 719);
            this.ctrlAgent.TabIndex = 0;
            // 
            // MiddleControlCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pageView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MiddleControlCabinet";
            this.Size = new System.Drawing.Size(1528, 763);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvGeneralAgreement.ResumeLayout(false);
            this.pvLicence.ResumeLayout(false);
            this.pvRequest.ResumeLayout(false);
            this.pvReference.ResumeLayout(false);
            this.pvPayslips.ResumeLayout(false);
            this.pvCalculation.ResumeLayout(false);
            this.pvPays.ResumeLayout(false);
            this.pvAvances.ResumeLayout(false);
            this.pvContacts.ResumeLayout(false);
            this.pvFiles.ResumeLayout(false);
            this.pvAgent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvLicence;
        private Telerik.WinControls.UI.RadPageViewPage pvCalculation;
        private Telerik.WinControls.UI.RadPageViewPage pvPayslips;
        private Telerik.WinControls.UI.RadPageViewPage pvRequest;
        private Telerik.WinControls.UI.RadPageViewPage pvReference;
        private Telerik.WinControls.UI.RadPageViewPage pvGeneralAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvFiles;
        private Telerik.WinControls.UI.RadPageViewPage pvAgent;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private MiddleControlCabinetLicenses ctrlLicense;
        private MiddleControlCabinetGenAgreement ctrlGeneralAgreement;
        private MiddleControlCabinetAgent ctrlAgent;
        private MiddleControlCabinetFiles ctrlFiles;
        private MiddleControlCabinetReqRef ctrlRequest;
        private MiddleControlCabinetReqRef ctrlReference;
        private Telerik.WinControls.UI.RadPageViewPage pvPays;
        private Telerik.WinControls.UI.RadPageViewPage pvAvances;
        private Telerik.WinControls.UI.RadPageViewPage pvContacts;
        private MiddleControlCabinetPayslips ctrlPayslips;
        private MiddleControlCabinetAvances middleControlCabinetAvances1;
        private MiddleControlCabinetPayments middleControlCabinetPayments1;
        private InformationOfUserControl ctrlContactHeader;
        public CalculationInfoControl ctrlCalculation;
    }
}
