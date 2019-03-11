using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class AnketaConsumerPhisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnketaConsumerPhisForm));
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pageAnketaConsumer = new Telerik.WinControls.UI.RadPageView();
            this.pvClientName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlConsumerName = new IpsViewComponentLibrary.PartnerControls.PartnerNameControl();
            this.pvContacts = new Telerik.WinControls.UI.RadPageViewPage();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.btnCopyFromRegToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToReg = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAddressLetter = new AddressLetter();
            this.ctrlAddressRegister = new IpsAddressControl();
            this.ctrlAddressLive = new IpsAddressControl();
            this.ctrlContacts = new ContactsPersonControl();
            this.pvPasport = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.ctrlConsumerPassport = new PassportControl();
            this.pvPlaces = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPlaces = new IpsViewComponentLibrary.ConsumerControls.Places.ConsumerPlacesControl();
            this.pvBankRequisites = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankAccount = new IpsBankAccountControl();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAgreementPhis = new IpsViewComponentLibrary.ConsumerControls.AgreementWithPlacesControl();
            this.pvPrint = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnLoadPdf = new Telerik.WinControls.UI.RadButton();
            this.radPdfViewerNavigator = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.radPdfViewer = new Telerik.WinControls.UI.RadPdfViewer();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.ctrlTabNavigationExpanded = new TabNavigationExpandedControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).BeginInit();
            this.pageAnketaConsumer.SuspendLayout();
            this.pvClientName.SuspendLayout();
            this.pvContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtPostIndex)).BeginInit();
            this.pvPasport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            this.pvPlaces.SuspendLayout();
            this.pvBankRequisites.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            this.pvPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer)).BeginInit();
            this.radPdfViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageAnketaConsumer
            // 
            this.pageAnketaConsumer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pageAnketaConsumer.Controls.Add(this.pvClientName);
            this.pageAnketaConsumer.Controls.Add(this.pvContacts);
            this.pageAnketaConsumer.Controls.Add(this.pvPasport);
            this.pageAnketaConsumer.Controls.Add(this.pvPlaces);
            this.pageAnketaConsumer.Controls.Add(this.pvBankRequisites);
            this.pageAnketaConsumer.Controls.Add(this.pvAgreement);
            this.pageAnketaConsumer.Controls.Add(this.pvPrint);
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
            this.pageAnketaConsumer.Size = new System.Drawing.Size(1192, 671);
            this.pageAnketaConsumer.TabIndex = 2;
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
            this.pvClientName.Controls.Add(this.ctrlConsumerName);
            this.pvClientName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvClientName.Location = new System.Drawing.Point(134, 5);
            this.pvClientName.Name = "pvClientName";
            this.pvClientName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pvClientName.Size = new System.Drawing.Size(1053, 661);
            this.pvClientName.TabStop = true;
            this.pvClientName.Text = "Споживач";
            // 
            // ctrlConsumerName
            // 
            this.ctrlConsumerName.DataSourceAnketa = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlConsumerName.Location = new System.Drawing.Point(20, 5);
            this.ctrlConsumerName.Name = "ctrlConsumerName";
            this.ctrlConsumerName.Size = new System.Drawing.Size(689, 157);
            this.ctrlConsumerName.TabIndex = 34;
            // 
            // pvContacts
            // 
            this.pvContacts.Controls.Add(this.radSeparator2);
            this.pvContacts.Controls.Add(this.radSeparator3);
            this.pvContacts.Controls.Add(this.radSeparator1);
            this.pvContacts.Controls.Add(this.btnCopyFromRegToLett);
            this.pvContacts.Controls.Add(this.btnCopyFromLiveToLett);
            this.pvContacts.Controls.Add(this.btnCopyFromLiveToReg);
            this.pvContacts.Controls.Add(this.radLabel3);
            this.pvContacts.Controls.Add(this.radLabel2);
            this.pvContacts.Controls.Add(this.radLabel1);
            this.pvContacts.Controls.Add(this.ctrlAddressLetter);
            this.pvContacts.Controls.Add(this.ctrlAddressRegister);
            this.pvContacts.Controls.Add(this.ctrlAddressLive);
            this.pvContacts.Controls.Add(this.ctrlContacts);
            this.pvContacts.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvContacts.Location = new System.Drawing.Point(134, 5);
            this.pvContacts.Name = "pvContacts";
            this.pvContacts.Size = new System.Drawing.Size(963, 536);
            this.pvContacts.Text = "Контакти";
            // 
            // radSeparator2
            // 
            this.radSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator2.Location = new System.Drawing.Point(151, 7);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(636, 18);
            this.radSeparator2.TabIndex = 70;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator3.Location = new System.Drawing.Point(143, 189);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(644, 19);
            this.radSeparator3.TabIndex = 72;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(137, 85);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(650, 19);
            this.radSeparator1.TabIndex = 71;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // btnCopyFromRegToLett
            // 
            this.btnCopyFromRegToLett.Location = new System.Drawing.Point(359, 214);
            this.btnCopyFromRegToLett.Name = "btnCopyFromRegToLett";
            this.btnCopyFromRegToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromRegToLett.TabIndex = 69;
            this.btnCopyFromRegToLett.Text = "Копіювати з адреси реєстрації";
            this.btnCopyFromRegToLett.ThemeName = "Office2013Light";
            // 
            // btnCopyFromLiveToLett
            // 
            this.btnCopyFromLiveToLett.Location = new System.Drawing.Point(153, 214);
            this.btnCopyFromLiveToLett.Name = "btnCopyFromLiveToLett";
            this.btnCopyFromLiveToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToLett.TabIndex = 68;
            this.btnCopyFromLiveToLett.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToLett.ThemeName = "Office2013Light";
            // 
            // btnCopyFromLiveToReg
            // 
            this.btnCopyFromLiveToReg.Location = new System.Drawing.Point(153, 110);
            this.btnCopyFromLiveToReg.Name = "btnCopyFromLiveToReg";
            this.btnCopyFromLiveToReg.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToReg.TabIndex = 67;
            this.btnCopyFromLiveToReg.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToReg.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(23, 189);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(114, 19);
            this.radLabel3.TabIndex = 65;
            this.radLabel3.Text = "Адреса листування";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(23, 85);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(108, 19);
            this.radLabel2.TabIndex = 64;
            this.radLabel2.Text = "Адреса реєстрації";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(23, 7);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(122, 19);
            this.radLabel1.TabIndex = 63;
            this.radLabel1.Text = "Адреса проживання";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ctrlAddressLetter
            // 
            this.ctrlAddressLetter.AddressDataMember = null;
            this.ctrlAddressLetter.CityDataMember = null;
            this.ctrlAddressLetter.CountriesDataMember = "";
            this.ctrlAddressLetter.CountriesDataSource = null;
            this.ctrlAddressLetter.CountriesDisplayMember = "";
            this.ctrlAddressLetter.CountriesValueMember = "";
            this.ctrlAddressLetter.CountryDataMember = null;
            this.ctrlAddressLetter.DataMember = "";
            this.ctrlAddressLetter.DataSource = null;
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddressLetter.DdlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ctrlAddressLetter.DdlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ctrlAddressLetter.DdlCountry.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddressLetter.DdlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.DdlCountry.Name = "ddlCountry";
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 234, 20);
            this.ctrlAddressLetter.DdlCountry.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.DdlCountry.Size = new System.Drawing.Size(190, 20);
            this.ctrlAddressLetter.DdlCountry.TabIndex = 0;
            this.ctrlAddressLetter.DdlCountry.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddressLetter.DdlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ctrlAddressLetter.DdlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ctrlAddressLetter.DdlRegion.Location = new System.Drawing.Point(210, 0);
            this.ctrlAddressLetter.DdlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.DdlRegion.Name = "ddlRegion";
            // 
            // 
            // 
            this.ctrlAddressLetter.DdlRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(254, 0, 234, 20);
            this.ctrlAddressLetter.DdlRegion.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.DdlRegion.Size = new System.Drawing.Size(190, 20);
            this.ctrlAddressLetter.DdlRegion.TabIndex = 1;
            this.ctrlAddressLetter.DdlRegion.ThemeName = "Office2013Light";
            this.ctrlAddressLetter.Location = new System.Drawing.Point(153, 239);
            this.ctrlAddressLetter.Name = "ctrlAddressLetter";
            this.ctrlAddressLetter.PostIndexDataMember = null;
            this.ctrlAddressLetter.RegionDataMember = null;
            this.ctrlAddressLetter.RegionsDataMember = "";
            this.ctrlAddressLetter.RegionsDataSource = null;
            this.ctrlAddressLetter.RegionsDisplayMember = "";
            this.ctrlAddressLetter.RegionsValueMember = "";
            this.ctrlAddressLetter.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLetter.TabIndex = 66;
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtAddress.Location = new System.Drawing.Point(0, 25);
            this.ctrlAddressLetter.TxtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.TxtAddress.Name = "txtAddress";
            this.ctrlAddressLetter.TxtAddress.NullText = "Адреса";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 100, 14);
            this.ctrlAddressLetter.TxtAddress.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.TxtAddress.Size = new System.Drawing.Size(400, 20);
            this.ctrlAddressLetter.TxtAddress.TabIndex = 5;
            this.ctrlAddressLetter.TxtAddress.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddressLetter.TxtCity.Location = new System.Drawing.Point(420, 0);
            this.ctrlAddressLetter.TxtCity.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.TxtCity.Name = "txtCity";
            this.ctrlAddressLetter.TxtCity.NullText = "Місто";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtCity.RootElement.ControlBounds = new System.Drawing.Rectangle(420, 0, 192, 20);
            this.ctrlAddressLetter.TxtCity.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.TxtCity.Size = new System.Drawing.Size(192, 20);
            this.ctrlAddressLetter.TxtCity.TabIndex = 2;
            this.ctrlAddressLetter.TxtCity.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtPostIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddressLetter.TxtPostIndex.Location = new System.Drawing.Point(420, 25);
            this.ctrlAddressLetter.TxtPostIndex.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlAddressLetter.TxtPostIndex.Name = "txtPostIndex";
            this.ctrlAddressLetter.TxtPostIndex.NullText = "Поштовий індекс";
            // 
            // 
            // 
            this.ctrlAddressLetter.TxtPostIndex.RootElement.ControlBounds = new System.Drawing.Rectangle(420, 25, 192, 20);
            this.ctrlAddressLetter.TxtPostIndex.RootElement.StretchVertically = true;
            this.ctrlAddressLetter.TxtPostIndex.Size = new System.Drawing.Size(192, 20);
            this.ctrlAddressLetter.TxtPostIndex.TabIndex = 4;
            this.ctrlAddressLetter.TxtPostIndex.ThemeName = "Office2013Light";
            // 
            // ctrlAddressRegister
            // 
            this.ctrlAddressRegister.AddressDataMember = null;
            this.ctrlAddressRegister.CityDataMember = null;
            this.ctrlAddressRegister.CountryDataMember = null;
            this.ctrlAddressRegister.DataMember = "";
            this.ctrlAddressRegister.DataSource = null;
            this.ctrlAddressRegister.Location = new System.Drawing.Point(153, 135);
            this.ctrlAddressRegister.Name = "ctrlAddressRegister";
            this.ctrlAddressRegister.RegionDataMember = null;
            this.ctrlAddressRegister.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressRegister.TabIndex = 61;
            // 
            // ctrlAddressLive
            // 
            this.ctrlAddressLive.AddressDataMember = null;
            this.ctrlAddressLive.CityDataMember = null;
            this.ctrlAddressLive.CountryDataMember = null;
            this.ctrlAddressLive.DataMember = "";
            this.ctrlAddressLive.DataSource = null;
            this.ctrlAddressLive.Location = new System.Drawing.Point(153, 31);
            this.ctrlAddressLive.Name = "ctrlAddressLive";
            this.ctrlAddressLive.RegionDataMember = null;
            this.ctrlAddressLive.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLive.TabIndex = 60;
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlContacts.Location = new System.Drawing.Point(30, 293);
            this.ctrlContacts.MaximumSize = new System.Drawing.Size(625, 50);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(625, 50);
            this.ctrlContacts.TabIndex = 62;
            // 
            // pvPasport
            // 
            this.pvPasport.Controls.Add(this.radGroupBox3);
            this.pvPasport.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPasport.Location = new System.Drawing.Point(134, 5);
            this.pvPasport.Name = "pvPasport";
            this.pvPasport.Size = new System.Drawing.Size(963, 536);
            this.pvPasport.Text = "Паспортні дані";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.ctrlConsumerPassport);
            this.radGroupBox3.HeaderText = "Паспорт";
            this.radGroupBox3.Location = new System.Drawing.Point(26, 7);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(420, 120);
            this.radGroupBox3.TabIndex = 38;
            this.radGroupBox3.Text = "Паспорт";
            this.radGroupBox3.ThemeName = "Office2013Light";
            // 
            // ctrlConsumerPassport
            // 
            this.ctrlConsumerPassport.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            this.ctrlConsumerPassport.Location = new System.Drawing.Point(5, 21);
            this.ctrlConsumerPassport.MaximumSize = new System.Drawing.Size(410, 94);
            this.ctrlConsumerPassport.Name = "ctrlConsumerPassport";
            this.ctrlConsumerPassport.Size = new System.Drawing.Size(410, 94);
            this.ctrlConsumerPassport.TabIndex = 24;
            // 
            // pvPlaces
            // 
            this.pvPlaces.AutoScroll = true;
            this.pvPlaces.Controls.Add(this.ctrlPlaces);
            this.pvPlaces.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPlaces.Location = new System.Drawing.Point(134, 5);
            this.pvPlaces.Name = "pvPlaces";
            this.pvPlaces.Size = new System.Drawing.Size(963, 536);
            this.pvPlaces.Text = "Бізнес-точки";
            // 
            // ctrlPlaces
            // 
            this.ctrlPlaces.AutoSize = true;
            this.ctrlPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPlaces.Location = new System.Drawing.Point(0, 0);
            this.ctrlPlaces.Name = "ctrlPlaces";
            this.ctrlPlaces.Size = new System.Drawing.Size(963, 536);
            this.ctrlPlaces.TabIndex = 11;
            // 
            // pvBankRequisites
            // 
            this.pvBankRequisites.AutoScroll = true;
            this.pvBankRequisites.Controls.Add(this.ctrlBankAccount);
            this.pvBankRequisites.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBankRequisites.Location = new System.Drawing.Point(134, 5);
            this.pvBankRequisites.Name = "pvBankRequisites";
            this.pvBankRequisites.Size = new System.Drawing.Size(963, 536);
            this.pvBankRequisites.Text = "Банківські реквізити";
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            this.ctrlBankAccount.Location = new System.Drawing.Point(20, 5);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(434, 127);
            this.ctrlBankAccount.TabIndex = 1;
            // 
            // pvAgreement
            // 
            this.pvAgreement.Controls.Add(this.ctrlAgreementPhis);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(963, 536);
            this.pvAgreement.Text = "Договір";
            // 
            // ctrlAgreementPhis
            // 
            this.ctrlAgreementPhis.IsAttached = false;
            this.ctrlAgreementPhis.LicenseEnabled = true;
            this.ctrlAgreementPhis.Location = new System.Drawing.Point(20, 5);
            this.ctrlAgreementPhis.MinimumSize = new System.Drawing.Size(690, 390);
            this.ctrlAgreementPhis.Name = "ctrlAgreementPhis";
            this.ctrlAgreementPhis.Rights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.ctrlAgreementPhis.Size = new System.Drawing.Size(690, 390);
            this.ctrlAgreementPhis.TabIndex = 2;
            // 
            // pvPrint
            // 
            this.pvPrint.Controls.Add(this.btnLoadPdf);
            this.pvPrint.Controls.Add(this.radPdfViewerNavigator);
            this.pvPrint.Controls.Add(this.radPdfViewer);
            this.pvPrint.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPrint.Location = new System.Drawing.Point(134, 5);
            this.pvPrint.Name = "pvPrint";
            this.pvPrint.Size = new System.Drawing.Size(963, 536);
            this.pvPrint.Text = "Друк";
            // 
            // btnLoadPdf
            // 
            this.btnLoadPdf.Location = new System.Drawing.Point(3, 3);
            this.btnLoadPdf.Name = "btnLoadPdf";
            this.btnLoadPdf.Size = new System.Drawing.Size(176, 24);
            this.btnLoadPdf.TabIndex = 4;
            this.btnLoadPdf.Text = "Завантажити PDF договору";
            this.btnLoadPdf.ThemeName = "Office2013Light";
            this.btnLoadPdf.Click += new System.EventHandler(this.btnLoadPdf_Click);
            // 
            // radPdfViewerNavigator
            // 
            this.radPdfViewerNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPdfViewerNavigator.AssociatedViewer = this.radPdfViewer;
            this.radPdfViewerNavigator.Location = new System.Drawing.Point(3, 38);
            this.radPdfViewerNavigator.Name = "radPdfViewerNavigator";
            this.radPdfViewerNavigator.Size = new System.Drawing.Size(957, 0);
            this.radPdfViewerNavigator.TabIndex = 2;
            this.radPdfViewerNavigator.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadCommandBarElement)(this.radPdfViewerNavigator.GetChildAt(0))).Enabled = true;
            ((Telerik.WinControls.Layouts.StackLayoutPanel)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.CommandBarRowElement)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Text = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).ToolTipText = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Text = "Signature Panel";
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).ToolTipText = "Signature Panel";
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Enabled = true;
            ((Telerik.WinControls.UI.CommandBarToggleButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(27))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.radPdfViewerNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // radPdfViewer
            // 
            this.radPdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPdfViewer.Controls.Add(this.radWaitingBar1);
            this.radPdfViewer.EnableThumbnails = false;
            this.radPdfViewer.Location = new System.Drawing.Point(3, 82);
            this.radPdfViewer.Name = "radPdfViewer";
            this.radPdfViewer.Size = new System.Drawing.Size(957, 409);
            this.radPdfViewer.TabIndex = 3;
            this.radPdfViewer.ThemeName = "Office2013Light";
            this.radPdfViewer.ThumbnailsScaleFactor = 0.15F;
            ((Telerik.WinControls.UI.RadPdfViewerContainer)(this.radPdfViewer.GetChildAt(0))).MinimumThumbWidth = 34;
            ((Telerik.WinControls.UI.RadPdfViewerContainer)(this.radPdfViewer.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadPdfViewerContainer)(this.radPdfViewer.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.ThumbnailListElement)(this.radPdfViewer.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.AssociatedControl = this.radPdfViewer;
            this.radWaitingBar1.BackColor = System.Drawing.Color.Transparent;
            this.radWaitingBar1.Location = new System.Drawing.Point(464, 211);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(70, 70);
            this.radWaitingBar1.TabIndex = 0;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.Visible = false;
            this.radWaitingBar1.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingSpeed = 50;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // ctrlTabNavigationExpanded
            // 
            this.ctrlTabNavigationExpanded.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigationExpanded.Location = new System.Drawing.Point(0, 671);
            this.ctrlTabNavigationExpanded.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigationExpanded.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigationExpanded.Name = "ctrlTabNavigationExpanded";
            this.ctrlTabNavigationExpanded.Size = new System.Drawing.Size(1192, 31);
            this.ctrlTabNavigationExpanded.TabIndex = 14;
            // 
            // AnketaConsumerPhisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 702);
            this.Controls.Add(this.pageAnketaConsumer);
            this.Controls.Add(this.ctrlTabNavigationExpanded);
            this.Name = "AnketaConsumerPhisForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Анкета користувача [фізична особа]";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).EndInit();
            this.pageAnketaConsumer.ResumeLayout(false);
            this.pvClientName.ResumeLayout(false);
            this.pvContacts.ResumeLayout(false);
            this.pvContacts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.DdlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlAddressLetter.TxtPostIndex)).EndInit();
            this.pvPasport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.pvPlaces.ResumeLayout(false);
            this.pvPlaces.PerformLayout();
            this.pvBankRequisites.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            this.pvPrint.ResumeLayout(false);
            this.pvPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer)).EndInit();
            this.radPdfViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView pageAnketaConsumer;
        private Telerik.WinControls.UI.RadPageViewPage pvClientName;
        private Telerik.WinControls.UI.RadPageViewPage pvContacts;
        private Telerik.WinControls.UI.RadPageViewPage pvPasport;
        private Telerik.WinControls.UI.RadPageViewPage pvPlaces;
        private ConsumerControls.Places.ConsumerPlacesControl ctrlPlaces;
        private Telerik.WinControls.UI.RadPageViewPage pvBankRequisites;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvPrint;
        private Telerik.WinControls.UI.RadButton btnLoadPdf;
        private Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigator;
        private Telerik.WinControls.UI.RadPdfViewer radPdfViewer;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private PartnerControls.PartnerNameControl ctrlConsumerName;
        private Telerik.WinControls.UI.RadSeparator radSeparator2;
        private Telerik.WinControls.UI.RadSeparator radSeparator3;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadButton btnCopyFromRegToLett;
        private Telerik.WinControls.UI.RadButton btnCopyFromLiveToLett;
        private Telerik.WinControls.UI.RadButton btnCopyFromLiveToReg;
        private AddressLetter ctrlAddressLetter;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private IpsAddressControl ctrlAddressRegister;
        private IpsAddressControl ctrlAddressLive;
        private ContactsPersonControl ctrlContacts;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private PassportControl ctrlConsumerPassport;
        private IpsBankAccountControl ctrlBankAccount;
        private TabNavigationExpandedControl ctrlTabNavigationExpanded;
        private ConsumerControls.AgreementWithPlacesControl ctrlAgreementPhis;
    }
}