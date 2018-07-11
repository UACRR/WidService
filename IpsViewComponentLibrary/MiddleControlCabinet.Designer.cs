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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pvLicence = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvCalculation = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvReports = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvRequest = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvReference = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvContacts = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvGeneralAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvFiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvAgent = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvLicence);
            this.pageView.Controls.Add(this.pvCalculation);
            this.pageView.Controls.Add(this.pvReports);
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
            this.pageView.Size = new System.Drawing.Size(846, 514);
            this.pageView.TabIndex = 0;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ShowItemCloseButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight;
            // 
            // pvLicence
            // 
            this.pvLicence.ItemSize = new System.Drawing.SizeF(58F, 27F);
            this.pvLicence.Location = new System.Drawing.Point(5, 31);
            this.pvLicence.Name = "pvLicence";
            this.pvLicence.Size = new System.Drawing.Size(836, 478);
            this.pvLicence.Text = "Ліцензії";
            // 
            // pvCalculation
            // 
            this.pvCalculation.ItemSize = new System.Drawing.SizeF(80F, 27F);
            this.pvCalculation.Location = new System.Drawing.Point(5, 31);
            this.pvCalculation.Name = "pvCalculation";
            this.pvCalculation.Size = new System.Drawing.Size(914, 518);
            this.pvCalculation.Text = "Розрахунки";
            // 
            // pvReports
            // 
            this.pvReports.ItemSize = new System.Drawing.SizeF(43F, 27F);
            this.pvReports.Location = new System.Drawing.Point(5, 31);
            this.pvReports.Name = "pvReports";
            this.pvReports.Size = new System.Drawing.Size(914, 518);
            this.pvReports.Text = "Звіти";
            // 
            // pvRequest
            // 
            this.pvRequest.ItemSize = new System.Drawing.SizeF(54F, 27F);
            this.pvRequest.Location = new System.Drawing.Point(5, 31);
            this.pvRequest.Name = "pvRequest";
            this.pvRequest.Size = new System.Drawing.Size(914, 518);
            this.pvRequest.Text = "Заявки";
            // 
            // pvReference
            // 
            this.pvReference.ItemSize = new System.Drawing.SizeF(60F, 27F);
            this.pvReference.Location = new System.Drawing.Point(5, 31);
            this.pvReference.Name = "pvReference";
            this.pvReference.Size = new System.Drawing.Size(914, 518);
            this.pvReference.Text = "Довідки";
            // 
            // pvContacts
            // 
            this.pvContacts.ItemSize = new System.Drawing.SizeF(66F, 27F);
            this.pvContacts.Location = new System.Drawing.Point(5, 31);
            this.pvContacts.Name = "pvContacts";
            this.pvContacts.Size = new System.Drawing.Size(914, 518);
            this.pvContacts.Text = "Контакти";
            // 
            // pvGeneralAgreement
            // 
            this.pvGeneralAgreement.ItemSize = new System.Drawing.SizeF(71F, 27F);
            this.pvGeneralAgreement.Location = new System.Drawing.Point(5, 31);
            this.pvGeneralAgreement.Name = "pvGeneralAgreement";
            this.pvGeneralAgreement.Size = new System.Drawing.Size(914, 518);
            this.pvGeneralAgreement.Text = "Ген. угода";
            // 
            // pvFiles
            // 
            this.pvFiles.ItemSize = new System.Drawing.SizeF(51F, 27F);
            this.pvFiles.Location = new System.Drawing.Point(5, 31);
            this.pvFiles.Name = "pvFiles";
            this.pvFiles.Size = new System.Drawing.Size(914, 518);
            this.pvFiles.Text = "Файли";
            // 
            // pvAgent
            // 
            this.pvAgent.ItemSize = new System.Drawing.SizeF(88F, 27F);
            this.pvAgent.Location = new System.Drawing.Point(5, 31);
            this.pvAgent.Name = "pvAgent";
            this.pvAgent.Size = new System.Drawing.Size(914, 518);
            this.pvAgent.Text = "Представник";
            // 
            // MiddleControlCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView);
            this.Name = "MiddleControlCabinet";
            this.Size = new System.Drawing.Size(846, 514);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvLicence;
        private Telerik.WinControls.UI.RadPageViewPage pvCalculation;
        private Telerik.WinControls.UI.RadPageViewPage pvReports;
        private Telerik.WinControls.UI.RadPageViewPage pvRequest;
        private Telerik.WinControls.UI.RadPageViewPage pvReference;
        private Telerik.WinControls.UI.RadPageViewPage pvContacts;
        private Telerik.WinControls.UI.RadPageViewPage pvGeneralAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvFiles;
        private Telerik.WinControls.UI.RadPageViewPage pvAgent;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
