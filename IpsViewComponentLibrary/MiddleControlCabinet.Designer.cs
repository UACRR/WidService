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
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvLicence = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlLicense = new IpsViewComponentLibrary.MiddleControlCabinetLicenses();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvPayslips = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvRequest = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvReference = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvContacts = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvGeneralAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlGeneralAgreement = new IpsViewComponentLibrary.MiddleControlCabinetGenAgreement();
            this.pvFiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvAgent = new Telerik.WinControls.UI.RadPageViewPage();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvLicence.SuspendLayout();
            this.pvGeneralAgreement.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvLicence);
            this.pageView.Controls.Add(this.pvCalculation);
            this.pageView.Controls.Add(this.pvPayslips);
            this.pageView.Controls.Add(this.pvRequest);
            this.pageView.Controls.Add(this.pvReference);
            this.pageView.Controls.Add(this.pvContacts);
            this.pageView.Controls.Add(this.pvGeneralAgreement);
            this.pageView.Controls.Add(this.pvFiles);
            this.pageView.Controls.Add(this.pvAgent);
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvLicence;
            this.pageView.Size = new System.Drawing.Size(1026, 634);
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
            this.pvLicence.Size = new System.Drawing.Size(1016, 598);
            this.pvLicence.Text = "Ліцензії";
            // 
            // ctrlLicense
            // 
            this.ctrlLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLicense.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicense.MinimumSize = new System.Drawing.Size(822, 538);
            this.ctrlLicense.Name = "ctrlLicense";
            this.ctrlLicense.Size = new System.Drawing.Size(1016, 598);
            this.ctrlLicense.TabIndex = 0;
            // 
            // pvCalculation
            // 
            this.pvCalculation.ItemSize = new System.Drawing.SizeF(80F, 27F);
            this.pvCalculation.Location = new System.Drawing.Point(5, 31);
            this.pvCalculation.Name = "pvCalculation";
            this.pvCalculation.Size = new System.Drawing.Size(836, 478);
            this.pvCalculation.Text = "Розрахунки";
            // 
            // pvPayslips
            // 
            this.pvPayslips.ItemSize = new System.Drawing.SizeF(35F, 27F);
            this.pvPayslips.Location = new System.Drawing.Point(5, 31);
            this.pvPayslips.Name = "pvPayslips";
            this.pvPayslips.Size = new System.Drawing.Size(836, 478);
            this.pvPayslips.Text = "Р/Л";
            // 
            // pvRequest
            // 
            this.pvRequest.ItemSize = new System.Drawing.SizeF(54F, 27F);
            this.pvRequest.Location = new System.Drawing.Point(5, 31);
            this.pvRequest.Name = "pvRequest";
            this.pvRequest.Size = new System.Drawing.Size(836, 478);
            this.pvRequest.Text = "Заявки";
            // 
            // pvReference
            // 
            this.pvReference.ItemSize = new System.Drawing.SizeF(60F, 27F);
            this.pvReference.Location = new System.Drawing.Point(5, 31);
            this.pvReference.Name = "pvReference";
            this.pvReference.Size = new System.Drawing.Size(1016, 598);
            this.pvReference.Text = "Довідки";
            // 
            // pvContacts
            // 
            this.pvContacts.ItemSize = new System.Drawing.SizeF(66F, 27F);
            this.pvContacts.Location = new System.Drawing.Point(5, 31);
            this.pvContacts.Name = "pvContacts";
            this.pvContacts.Size = new System.Drawing.Size(836, 478);
            this.pvContacts.Text = "Контакти";
            // 
            // pvGeneralAgreement
            // 
            this.pvGeneralAgreement.Controls.Add(this.ctrlGeneralAgreement);
            this.pvGeneralAgreement.ItemSize = new System.Drawing.SizeF(71F, 27F);
            this.pvGeneralAgreement.Location = new System.Drawing.Point(5, 31);
            this.pvGeneralAgreement.Name = "pvGeneralAgreement";
            this.pvGeneralAgreement.Size = new System.Drawing.Size(1016, 598);
            this.pvGeneralAgreement.Text = "Ген. угода";
            // 
            // ctrlGeneralAgreement
            // 
            this.ctrlGeneralAgreement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGeneralAgreement.Location = new System.Drawing.Point(0, 0);
            this.ctrlGeneralAgreement.MinimumSize = new System.Drawing.Size(912, 300);
            this.ctrlGeneralAgreement.Name = "ctrlGeneralAgreement";
            this.ctrlGeneralAgreement.Size = new System.Drawing.Size(1016, 598);
            this.ctrlGeneralAgreement.TabIndex = 0;
            // 
            // pvFiles
            // 
            this.pvFiles.ItemSize = new System.Drawing.SizeF(51F, 27F);
            this.pvFiles.Location = new System.Drawing.Point(5, 31);
            this.pvFiles.Name = "pvFiles";
            this.pvFiles.Size = new System.Drawing.Size(836, 478);
            this.pvFiles.Text = "Файли";
            // 
            // pvAgent
            // 
            this.pvAgent.ItemSize = new System.Drawing.SizeF(88F, 27F);
            this.pvAgent.Location = new System.Drawing.Point(5, 31);
            this.pvAgent.Name = "pvAgent";
            this.pvAgent.Size = new System.Drawing.Size(836, 478);
            this.pvAgent.Text = "Представник";
            // 
            // MiddleControlCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView);
            this.Name = "MiddleControlCabinet";
            this.Size = new System.Drawing.Size(1026, 634);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvLicence.ResumeLayout(false);
            this.pvGeneralAgreement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvLicence;
        private Telerik.WinControls.UI.RadPageViewPage pvCalculation;
        private Telerik.WinControls.UI.RadPageViewPage pvPayslips;
        private Telerik.WinControls.UI.RadPageViewPage pvRequest;
        private Telerik.WinControls.UI.RadPageViewPage pvReference;
        private Telerik.WinControls.UI.RadPageViewPage pvContacts;
        private Telerik.WinControls.UI.RadPageViewPage pvGeneralAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvFiles;
        private Telerik.WinControls.UI.RadPageViewPage pvAgent;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private MiddleControlCabinetLicenses ctrlLicense;
        private MiddleControlCabinetGenAgreement ctrlGeneralAgreement;
    }
}
