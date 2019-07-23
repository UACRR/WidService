using System.Windows.Forms;
using IpsViewComponentLibrary.ConsumerControls.Places;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class AnketaConsumer
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
            this.pageAnketaConsumer = new Telerik.WinControls.UI.RadPageView();
            this.pvClientName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlClientName = new IpsViewComponentLibrary.ConsumerControls.JuridicalClientNameControl();
            this.pvPlaces = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPlaces = new IpsViewComponentLibrary.ConsumerControls.Places.ConsumerPlacesControl();
            this.ctrlPlacesTitle = new Telerik.WinControls.UI.RadLabel();
            this.anketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pvAddress = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAddress = new IpsViewComponentLibrary.Shared.Controls.JuridicalAddressControl();
            this.pvBankRequisites = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankRequisites = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.pvManagers = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlManagers = new IpsViewComponentLibrary.ConsumerControls.ManagersControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.panelContainer = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.panelAgreement = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.ipsPanel1 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.btnLoadPdf = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).BeginInit();
            this.pageAnketaConsumer.SuspendLayout();
            this.pvClientName.SuspendLayout();
            this.pvPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPlacesTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).BeginInit();
            this.pvAddress.SuspendLayout();
            this.pvBankRequisites.SuspendLayout();
            this.pvManagers.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelAgreement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).BeginInit();
            this.ipsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // pageAnketaConsumer
            // 
            this.pageAnketaConsumer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pageAnketaConsumer.Controls.Add(this.pvClientName);
            this.pageAnketaConsumer.Controls.Add(this.pvPlaces);
            this.pageAnketaConsumer.Controls.Add(this.pvAddress);
            this.pageAnketaConsumer.Controls.Add(this.pvBankRequisites);
            this.pageAnketaConsumer.Controls.Add(this.pvManagers);
            this.pageAnketaConsumer.Controls.Add(this.pvAgreement);
            this.pageAnketaConsumer.DefaultPage = this.pvClientName;
            this.pageAnketaConsumer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageAnketaConsumer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pageAnketaConsumer.Location = new System.Drawing.Point(0, 0);
            this.pageAnketaConsumer.Name = "pageAnketaConsumer";
            // 
            // 
            // 
            this.pageAnketaConsumer.RootElement.FocusBorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pageAnketaConsumer.SelectedPage = this.pvClientName;
            this.pageAnketaConsumer.SelectionWrap = false;
            this.pageAnketaConsumer.Size = new System.Drawing.Size(922, 502);
            this.pageAnketaConsumer.TabIndex = 1;
            this.pageAnketaConsumer.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).ShadowColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).CustomFontStyle = System.Drawing.FontStyle.Bold;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Enabled = true;
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).ToolTipText = "Scroll Strip Right";
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Enabled = false;
            // 
            // pvClientName
            // 
            this.pvClientName.AutoScroll = true;
            this.pvClientName.Controls.Add(this.ctrlClientName);
            this.pvClientName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvClientName.Location = new System.Drawing.Point(134, 5);
            this.pvClientName.Name = "pvClientName";
            this.pvClientName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pvClientName.Size = new System.Drawing.Size(783, 492);
            this.pvClientName.TabStop = true;
            this.pvClientName.Text = "Користувач";
            // 
            // ctrlClientName
            // 
            this.ctrlClientName.Location = new System.Drawing.Point(19, 5);
            this.ctrlClientName.MaximumSize = new System.Drawing.Size(700, 274);
            this.ctrlClientName.MinimumSize = new System.Drawing.Size(700, 274);
            this.ctrlClientName.Name = "ctrlClientName";
            this.ctrlClientName.Size = new System.Drawing.Size(700, 274);
            this.ctrlClientName.TabIndex = 0;
            // 
            // pvPlaces
            // 
            this.pvPlaces.AutoScroll = true;
            this.pvPlaces.Controls.Add(this.ctrlPlaces);
            this.pvPlaces.Controls.Add(this.ctrlPlacesTitle);
            this.pvPlaces.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPlaces.Location = new System.Drawing.Point(134, 5);
            this.pvPlaces.Name = "pvPlaces";
            this.pvPlaces.Size = new System.Drawing.Size(783, 492);
            this.pvPlaces.Text = "Бізнес-точки";
            // 
            // ctrlPlaces
            // 
            this.ctrlPlaces.AutoSize = true;
            this.ctrlPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPlaces.Location = new System.Drawing.Point(0, 0);
            this.ctrlPlaces.Name = "ctrlPlaces";
            this.ctrlPlaces.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ctrlPlaces.Size = new System.Drawing.Size(783, 492);
            this.ctrlPlaces.TabIndex = 11;
            // 
            // ctrlPlacesTitle
            // 
            this.ctrlPlacesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPlacesTitle.AutoSize = false;
            this.ctrlPlacesTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "Name", true));
            this.ctrlPlacesTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlPlacesTitle.Location = new System.Drawing.Point(4, 35);
            this.ctrlPlacesTitle.Name = "ctrlPlacesTitle";
            this.ctrlPlacesTitle.Size = new System.Drawing.Size(777, 22);
            this.ctrlPlacesTitle.TabIndex = 10;
            this.ctrlPlacesTitle.Text = "Назва «Клієнта»";
            this.ctrlPlacesTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // anketaCompanyBindingSource
            // 
            this.anketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // pvAddress
            // 
            this.pvAddress.AutoScroll = true;
            this.pvAddress.Controls.Add(this.ctrlAddress);
            this.pvAddress.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAddress.Location = new System.Drawing.Point(134, 5);
            this.pvAddress.Name = "pvAddress";
            this.pvAddress.Size = new System.Drawing.Size(783, 492);
            this.pvAddress.Text = "Адреса";
            // 
            // ctrlAddress
            // 
            this.ctrlAddress.Location = new System.Drawing.Point(19, 5);
            this.ctrlAddress.MaximumSize = new System.Drawing.Size(738, 313);
            this.ctrlAddress.MinimumSize = new System.Drawing.Size(738, 313);
            this.ctrlAddress.Name = "ctrlAddress";
            this.ctrlAddress.Size = new System.Drawing.Size(738, 313);
            this.ctrlAddress.TabIndex = 0;
            // 
            // pvBankRequisites
            // 
            this.pvBankRequisites.Controls.Add(this.ctrlBankRequisites);
            this.pvBankRequisites.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBankRequisites.Location = new System.Drawing.Point(134, 5);
            this.pvBankRequisites.Name = "pvBankRequisites";
            this.pvBankRequisites.Size = new System.Drawing.Size(783, 492);
            this.pvBankRequisites.Text = "Банківські реквізити";
            // 
            // ctrlBankRequisites
            // 
            this.ctrlBankRequisites.AutoScroll = true;
            this.ctrlBankRequisites.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            this.ctrlBankRequisites.Location = new System.Drawing.Point(19, 5);
            this.ctrlBankRequisites.MaximumSize = new System.Drawing.Size(434, 127);
            this.ctrlBankRequisites.MinimumSize = new System.Drawing.Size(434, 127);
            this.ctrlBankRequisites.Name = "ctrlBankRequisites";
            this.ctrlBankRequisites.Size = new System.Drawing.Size(434, 127);
            this.ctrlBankRequisites.TabIndex = 0;
            // 
            // pvManagers
            // 
            this.pvManagers.AutoScroll = true;
            this.pvManagers.Controls.Add(this.ctrlManagers);
            this.pvManagers.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvManagers.Location = new System.Drawing.Point(134, 5);
            this.pvManagers.Name = "pvManagers";
            this.pvManagers.Size = new System.Drawing.Size(783, 492);
            this.pvManagers.Text = "Контакти";
            // 
            // ctrlManagers
            // 
            this.ctrlManagers.Location = new System.Drawing.Point(19, 5);
            this.ctrlManagers.Name = "ctrlManagers";
            this.ctrlManagers.Size = new System.Drawing.Size(750, 469);
            this.ctrlManagers.TabIndex = 0;
            // 
            // pvAgreement
            // 
            this.pvAgreement.Controls.Add(this.panelContainer);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(783, 492);
            this.pvAgreement.Text = "Договір";
            // 
            // panelContainer
            // 
            this.panelContainer.BorderVisible = false;
            this.panelContainer.Controls.Add(this.panelAgreement);
            this.panelContainer.Controls.Add(this.ipsPanel1);
            this.panelContainer.Location = new System.Drawing.Point(19, 5);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(590, 374);
            this.panelContainer.TabIndex = 6;
            // 
            // panelAgreement
            // 
            this.panelAgreement.BorderVisible = false;
            this.panelAgreement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgreement.Location = new System.Drawing.Point(0, 0);
            this.panelAgreement.Name = "panelAgreement";
            this.panelAgreement.Size = new System.Drawing.Size(590, 343);
            this.panelAgreement.TabIndex = 0;
            // 
            // ipsPanel1
            // 
            this.ipsPanel1.BorderVisible = false;
            this.ipsPanel1.Controls.Add(this.btnLoadPdf);
            this.ipsPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipsPanel1.Location = new System.Drawing.Point(0, 343);
            this.ipsPanel1.Name = "ipsPanel1";
            this.ipsPanel1.Size = new System.Drawing.Size(590, 31);
            this.ipsPanel1.TabIndex = 1;
            // 
            // btnLoadPdf
            // 
            this.btnLoadPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPdf.Location = new System.Drawing.Point(390, 4);
            this.btnLoadPdf.Name = "btnLoadPdf";
            this.btnLoadPdf.Size = new System.Drawing.Size(200, 24);
            this.btnLoadPdf.TabIndex = 5;
            this.btnLoadPdf.Text = "Сформувати документ договору";
            this.btnLoadPdf.ThemeName = "Office2013Light";
            this.btnLoadPdf.Click += new System.EventHandler(this.btnLoadPdf_Click);
            // 
            // AnketaConsumer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageAnketaConsumer);
            this.Name = "AnketaConsumer";
            this.Size = new System.Drawing.Size(922, 502);
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).EndInit();
            this.pageAnketaConsumer.ResumeLayout(false);
            this.pvClientName.ResumeLayout(false);
            this.pvPlaces.ResumeLayout(false);
            this.pvPlaces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPlacesTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).EndInit();
            this.pvAddress.ResumeLayout(false);
            this.pvBankRequisites.ResumeLayout(false);
            this.pvManagers.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelAgreement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).EndInit();
            this.ipsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageAnketaConsumer;
        private Telerik.WinControls.UI.RadPageViewPage pvClientName;
        private Telerik.WinControls.UI.RadPageViewPage pvAddress;
        private Telerik.WinControls.UI.RadPageViewPage pvManagers;
        private Telerik.WinControls.UI.RadPageViewPage pvPlaces;
        private Telerik.WinControls.UI.RadPageViewPage pvBankRequisites;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.UI.RadLabel ctrlPlacesTitle;
        private JuridicalAddressControl ctrlAddress;
        private ConsumerPlacesControl ctrlPlaces;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource anketaCompanyBindingSource;
        private ManagersControl ctrlManagers;
        public JuridicalClientNameControl ctrlClientName;
        private IpsBankAccountControl ctrlBankRequisites;
        private Telerik.WinControls.UI.RadButton btnLoadPdf;
        private Common.Editors.IpsPanel panelAgreement;
        private Common.Editors.IpsPanel panelContainer;
        private Common.Editors.IpsPanel ipsPanel1;
    }
}
