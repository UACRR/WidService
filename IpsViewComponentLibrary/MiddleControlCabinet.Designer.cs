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
            this.pvLicence = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlLicense = new IpsViewComponentLibrary.MiddleControlCabinetLicenses();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlCalculation = new IpsViewComponentLibrary.MiddleControlCabinetCalculation();
            this.pvPayslips = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvRequest = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlRequest = new IpsViewComponentLibrary.MiddleControlCabinetReqRef();
            this.pvReference = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlReference = new IpsViewComponentLibrary.MiddleControlCabinetReqRef();
            this.pvGeneralAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlGeneralAgreement = new IpsViewComponentLibrary.MiddleControlCabinetGenAgreement();
            this.pvFiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlFiles = new IpsViewComponentLibrary.MiddleControlCabinetFiles();
            this.pvAgent = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgent = new IpsViewComponentLibrary.MiddleControlCabinetAgent();
            this.pvPays = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvAvances = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvContacts = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvLicence.SuspendLayout();
            this.pvCalculation.SuspendLayout();
            this.pvRequest.SuspendLayout();
            this.pvReference.SuspendLayout();
            this.pvGeneralAgreement.SuspendLayout();
            this.pvFiles.SuspendLayout();
            this.pvAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvGeneralAgreement);
            this.pageView.Controls.Add(this.pvLicence);
            this.pageView.Controls.Add(this.pvPayslips);
            this.pageView.Controls.Add(this.pvCalculation);
            this.pageView.Controls.Add(this.pvPays);
            this.pageView.Controls.Add(this.pvAvances);
            this.pageView.Controls.Add(this.pvRequest);
            this.pageView.Controls.Add(this.pvReference);
            this.pageView.Controls.Add(this.pvContacts);
            this.pageView.Controls.Add(this.pvFiles);
            this.pageView.Controls.Add(this.pvAgent);
            this.pageView.DefaultPage = this.pvGeneralAgreement;
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvGeneralAgreement;
            this.pageView.Size = new System.Drawing.Size(1146, 845);
            this.pageView.TabIndex = 0;
            this.pageView.ThemeName = "Office2013Light";
            this.pageView.SelectedPageChanged += new System.EventHandler(this.pageView_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ShowItemCloseButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight;
            // 
            // pvLicence
            // 
            this.pvLicence.Controls.Add(this.ctrlLicense);
            this.pvLicence.ItemSize = new System.Drawing.SizeF(58F, 27F);
            this.pvLicence.Location = new System.Drawing.Point(5, 31);
            this.pvLicence.Name = "pvLicence";
            this.pvLicence.Size = new System.Drawing.Size(1136, 809);
            this.pvLicence.Text = "Ліцензії";
            // 
            // ctrlLicense
            // 
            this.ctrlLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLicense.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicense.MinimumSize = new System.Drawing.Size(822, 538);
            this.ctrlLicense.Name = "ctrlLicense";
            this.ctrlLicense.Size = new System.Drawing.Size(1136, 809);
            this.ctrlLicense.TabIndex = 0;
            // 
            // pvCalculation
            // 
            this.pvCalculation.AutoScroll = true;
            this.pvCalculation.Controls.Add(this.ctrlCalculation);
            this.pvCalculation.ItemSize = new System.Drawing.SizeF(80F, 27F);
            this.pvCalculation.Location = new System.Drawing.Point(5, 31);
            this.pvCalculation.Name = "pvCalculation";
            this.pvCalculation.Size = new System.Drawing.Size(1136, 809);
            this.pvCalculation.Text = "Розрахунки";
            // 
            // ctrlCalculation
            // 
            this.ctrlCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCalculation.Location = new System.Drawing.Point(0, 0);
            this.ctrlCalculation.MinimumSize = new System.Drawing.Size(915, 773);
            this.ctrlCalculation.Name = "ctrlCalculation";
            this.ctrlCalculation.Size = new System.Drawing.Size(1136, 809);
            this.ctrlCalculation.TabIndex = 0;
            // 
            // pvPayslips
            // 
            this.pvPayslips.ItemSize = new System.Drawing.SizeF(35F, 27F);
            this.pvPayslips.Location = new System.Drawing.Point(5, 31);
            this.pvPayslips.Name = "pvPayslips";
            this.pvPayslips.Size = new System.Drawing.Size(1136, 809);
            this.pvPayslips.Text = "Р/Л";
            // 
            // pvRequest
            // 
            this.pvRequest.Controls.Add(this.ctrlRequest);
            this.pvRequest.ItemSize = new System.Drawing.SizeF(54F, 27F);
            this.pvRequest.Location = new System.Drawing.Point(5, 31);
            this.pvRequest.Name = "pvRequest";
            this.pvRequest.Size = new System.Drawing.Size(1136, 809);
            this.pvRequest.Text = "Заявки";
            // 
            // ctrlRequest
            // 
            this.ctrlRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRequest.Location = new System.Drawing.Point(0, 0);
            this.ctrlRequest.Name = "ctrlRequest";
            this.ctrlRequest.Size = new System.Drawing.Size(1136, 809);
            this.ctrlRequest.TabIndex = 0;
            this.ctrlRequest.TypeControl = IpsViewComponentLibrary.ControlRequestOrReferenceType.None;
            // 
            // pvReference
            // 
            this.pvReference.Controls.Add(this.ctrlReference);
            this.pvReference.ItemSize = new System.Drawing.SizeF(60F, 27F);
            this.pvReference.Location = new System.Drawing.Point(5, 31);
            this.pvReference.Name = "pvReference";
            this.pvReference.Size = new System.Drawing.Size(1136, 809);
            this.pvReference.Text = "Довідки";
            // 
            // ctrlReference
            // 
            this.ctrlReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlReference.Location = new System.Drawing.Point(0, 0);
            this.ctrlReference.Name = "ctrlReference";
            this.ctrlReference.Size = new System.Drawing.Size(1136, 809);
            this.ctrlReference.TabIndex = 0;
            this.ctrlReference.TypeControl = IpsViewComponentLibrary.ControlRequestOrReferenceType.None;
            // 
            // pvGeneralAgreement
            // 
            this.pvGeneralAgreement.Controls.Add(this.ctrlGeneralAgreement);
            this.pvGeneralAgreement.ItemSize = new System.Drawing.SizeF(71F, 27F);
            this.pvGeneralAgreement.Location = new System.Drawing.Point(5, 31);
            this.pvGeneralAgreement.Name = "pvGeneralAgreement";
            this.pvGeneralAgreement.Size = new System.Drawing.Size(1136, 809);
            this.pvGeneralAgreement.Text = "Ген. угода";
            // 
            // ctrlGeneralAgreement
            // 
            this.ctrlGeneralAgreement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGeneralAgreement.Location = new System.Drawing.Point(0, 0);
            this.ctrlGeneralAgreement.MinimumSize = new System.Drawing.Size(912, 300);
            this.ctrlGeneralAgreement.Name = "ctrlGeneralAgreement";
            this.ctrlGeneralAgreement.Size = new System.Drawing.Size(1136, 809);
            this.ctrlGeneralAgreement.TabIndex = 0;
            // 
            // pvFiles
            // 
            this.pvFiles.Controls.Add(this.ctrlFiles);
            this.pvFiles.ItemSize = new System.Drawing.SizeF(51F, 27F);
            this.pvFiles.Location = new System.Drawing.Point(5, 31);
            this.pvFiles.Name = "pvFiles";
            this.pvFiles.Size = new System.Drawing.Size(1136, 809);
            this.pvFiles.Text = "Файли";
            // 
            // ctrlFiles
            // 
            this.ctrlFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFiles.Location = new System.Drawing.Point(0, 0);
            this.ctrlFiles.MinimumSize = new System.Drawing.Size(913, 436);
            this.ctrlFiles.Name = "ctrlFiles";
            this.ctrlFiles.Size = new System.Drawing.Size(1136, 809);
            this.ctrlFiles.TabIndex = 0;
            // 
            // pvAgent
            // 
            this.pvAgent.Controls.Add(this.ctrlAgent);
            this.pvAgent.ItemSize = new System.Drawing.SizeF(88F, 27F);
            this.pvAgent.Location = new System.Drawing.Point(5, 31);
            this.pvAgent.Name = "pvAgent";
            this.pvAgent.Size = new System.Drawing.Size(1136, 809);
            this.pvAgent.Text = "Представник";
            // 
            // ctrlAgent
            // 
            this.ctrlAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAgent.Location = new System.Drawing.Point(0, 0);
            this.ctrlAgent.MinimumSize = new System.Drawing.Size(913, 527);
            this.ctrlAgent.Name = "ctrlAgent";
            this.ctrlAgent.Size = new System.Drawing.Size(1136, 809);
            this.ctrlAgent.TabIndex = 0;
            // 
            // pvPays
            // 
            this.pvPays.ItemSize = new System.Drawing.SizeF(60F, 27F);
            this.pvPays.Location = new System.Drawing.Point(5, 31);
            this.pvPays.Name = "pvPays";
            this.pvPays.Size = new System.Drawing.Size(1136, 809);
            this.pvPays.Text = "Платежі";
            // 
            // pvAvances
            // 
            this.pvAvances.ItemSize = new System.Drawing.SizeF(55F, 27F);
            this.pvAvances.Location = new System.Drawing.Point(5, 31);
            this.pvAvances.Name = "pvAvances";
            this.pvAvances.Size = new System.Drawing.Size(1136, 809);
            this.pvAvances.Text = "Аванси";
            // 
            // pvContacts
            // 
            this.pvContacts.ItemSize = new System.Drawing.SizeF(66F, 27F);
            this.pvContacts.Location = new System.Drawing.Point(5, 31);
            this.pvContacts.Name = "pvContacts";
            this.pvContacts.Size = new System.Drawing.Size(1136, 809);
            this.pvContacts.Text = "Контакти";
            // 
            // MiddleControlCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pageView);
            this.Name = "MiddleControlCabinet";
            this.Size = new System.Drawing.Size(1146, 845);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvLicence.ResumeLayout(false);
            this.pvCalculation.ResumeLayout(false);
            this.pvRequest.ResumeLayout(false);
            this.pvReference.ResumeLayout(false);
            this.pvGeneralAgreement.ResumeLayout(false);
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
        private MiddleControlCabinetCalculation ctrlCalculation;
        private Telerik.WinControls.UI.RadPageViewPage pvPays;
        private Telerik.WinControls.UI.RadPageViewPage pvAvances;
        private Telerik.WinControls.UI.RadPageViewPage pvContacts;
    }
}
