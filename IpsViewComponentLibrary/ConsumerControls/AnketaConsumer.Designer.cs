namespace IpsViewComponentLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnketaConsumer));
            this.pageAnketaConsumer = new Telerik.WinControls.UI.RadPageView();
            this.pvClientName = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlClientName = new IpsViewComponentLibrary.MiddleControlClientName();
            this.pvAddress = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlAddress = new IpsViewComponentLibrary.MiddleControlAddress();
            this.pvManagers = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlManagers = new IpsViewComponentLibrary.MiddleControlManagers();
            this.pvPlaces = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPlaces = new ipsAnketaClient.ConsumerPlacesControl();
            this.ctrlPlacesTitle = new Telerik.WinControls.UI.RadLabel();
            this.anketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pvBankRequisites = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlBankRequisites = new IpsViewComponentLibrary.MiddleControlBankRequisites();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvPrint = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnLoadPdf = new Telerik.WinControls.UI.RadButton();
            this.radPdfViewerNavigator = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.radPdfViewer = new Telerik.WinControls.UI.RadPdfViewer();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.btnNext = new Telerik.WinControls.UI.RadButton();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).BeginInit();
            this.pageAnketaConsumer.SuspendLayout();
            this.pvClientName.SuspendLayout();
            this.pvAddress.SuspendLayout();
            this.pvManagers.SuspendLayout();
            this.pvPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPlacesTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).BeginInit();
            this.pvBankRequisites.SuspendLayout();
            this.pvPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer)).BeginInit();
            this.radPdfViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // pageAnketaConsumer
            // 
            this.pageAnketaConsumer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pageAnketaConsumer.Controls.Add(this.pvClientName);
            this.pageAnketaConsumer.Controls.Add(this.pvAddress);
            this.pageAnketaConsumer.Controls.Add(this.pvManagers);
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
            this.pageAnketaConsumer.Size = new System.Drawing.Size(1149, 664);
            this.pageAnketaConsumer.TabIndex = 1;
            this.pageAnketaConsumer.ThemeName = "Office2013Light";
            this.pageAnketaConsumer.SelectedPageChanging += new System.EventHandler<Telerik.WinControls.UI.RadPageViewCancelEventArgs>(this.pageAnketaConsumer_SelectedPageChanging);
            this.pageAnketaConsumer.SelectedPageChanged += new System.EventHandler(this.pageAnketaConsumer_SelectedPageChanged);
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
            this.pvClientName.Controls.Add(this.ctrlClientName);
            this.pvClientName.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvClientName.Location = new System.Drawing.Point(134, 5);
            this.pvClientName.Name = "pvClientName";
            this.pvClientName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pvClientName.Size = new System.Drawing.Size(1010, 654);
            this.pvClientName.TabStop = true;
            this.pvClientName.Text = "Споживач";
            // 
            // ctrlClientName
            // 
            this.ctrlClientName.CheckPlace = false;
            this.ctrlClientName.IsPlaceIn = false;
            this.ctrlClientName.Location = new System.Drawing.Point(4, 35);
            this.ctrlClientName.MaximumSize = new System.Drawing.Size(800, 194);
            this.ctrlClientName.MinimumSize = new System.Drawing.Size(607, 194);
            this.ctrlClientName.Name = "ctrlClientName";
            this.ctrlClientName.Size = new System.Drawing.Size(666, 194);
            this.ctrlClientName.TabIndex = 0;
            // 
            // pvAddress
            // 
            this.pvAddress.Controls.Add(this.ctrlAddress);
            this.pvAddress.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAddress.Location = new System.Drawing.Point(134, 5);
            this.pvAddress.Name = "pvAddress";
            this.pvAddress.Size = new System.Drawing.Size(1010, 654);
            this.pvAddress.Text = "Адреса";
            // 
            // ctrlAddress
            // 
            this.ctrlAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAddress.Location = new System.Drawing.Point(4, 35);
            this.ctrlAddress.MaximumSize = new System.Drawing.Size(1000, 313);
            this.ctrlAddress.MinimumSize = new System.Drawing.Size(727, 313);
            this.ctrlAddress.Name = "ctrlAddress";
            this.ctrlAddress.Size = new System.Drawing.Size(1000, 313);
            this.ctrlAddress.TabIndex = 0;
            // 
            // pvManagers
            // 
            this.pvManagers.Controls.Add(this.ctrlManagers);
            this.pvManagers.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvManagers.Location = new System.Drawing.Point(134, 5);
            this.pvManagers.Name = "pvManagers";
            this.pvManagers.Size = new System.Drawing.Size(1010, 654);
            this.pvManagers.Text = "Керівники";
            // 
            // ctrlManagers
            // 
            this.ctrlManagers.Location = new System.Drawing.Point(4, 35);
            this.ctrlManagers.MaximumSize = new System.Drawing.Size(1200, 343);
            this.ctrlManagers.MinimumSize = new System.Drawing.Size(600, 343);
            this.ctrlManagers.Name = "ctrlManagers";
            this.ctrlManagers.Size = new System.Drawing.Size(952, 343);
            this.ctrlManagers.TabIndex = 0;
            // 
            // pvPlaces
            // 
            this.pvPlaces.AutoScroll = true;
            this.pvPlaces.Controls.Add(this.ctrlPlaces);
            this.pvPlaces.Controls.Add(this.ctrlPlacesTitle);
            this.pvPlaces.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPlaces.Location = new System.Drawing.Point(134, 5);
            this.pvPlaces.Name = "pvPlaces";
            this.pvPlaces.Size = new System.Drawing.Size(1010, 654);
            this.pvPlaces.Text = "Майданчики";
            // 
            // ctrlPlaces
            // 
            this.ctrlPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPlaces.AutoSize = true;
            this.ctrlPlaces.Location = new System.Drawing.Point(4, 64);
            this.ctrlPlaces.MinimumSize = new System.Drawing.Size(800, 512);
            this.ctrlPlaces.Name = "ctrlPlaces";
            this.ctrlPlaces.Size = new System.Drawing.Size(1005, 512);
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
            this.ctrlPlacesTitle.Size = new System.Drawing.Size(1004, 22);
            this.ctrlPlacesTitle.TabIndex = 10;
            this.ctrlPlacesTitle.Text = "Назва «Клієнта»";
            this.ctrlPlacesTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // anketaCompanyBindingSource
            // 
            this.anketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // pvBankRequisites
            // 
            this.pvBankRequisites.AutoScroll = true;
            this.pvBankRequisites.Controls.Add(this.ctrlBankRequisites);
            this.pvBankRequisites.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvBankRequisites.Location = new System.Drawing.Point(134, 5);
            this.pvBankRequisites.Name = "pvBankRequisites";
            this.pvBankRequisites.Size = new System.Drawing.Size(1010, 654);
            this.pvBankRequisites.Text = "Банківські реквізити";
            // 
            // ctrlBankRequisites
            // 
            this.ctrlBankRequisites.Location = new System.Drawing.Point(4, 35);
            this.ctrlBankRequisites.MaximumSize = new System.Drawing.Size(1300, 160);
            this.ctrlBankRequisites.MinimumSize = new System.Drawing.Size(300, 160);
            this.ctrlBankRequisites.Name = "ctrlBankRequisites";
            this.ctrlBankRequisites.Size = new System.Drawing.Size(522, 160);
            this.ctrlBankRequisites.TabIndex = 0;
            // 
            // pvAgreement
            // 
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(134, 5);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(1010, 654);
            this.pvAgreement.Text = "Договір";
            // 
            // pvPrint
            // 
            this.pvPrint.Controls.Add(this.btnLoadPdf);
            this.pvPrint.Controls.Add(this.radPdfViewerNavigator);
            this.pvPrint.Controls.Add(this.radPdfViewer);
            this.pvPrint.ItemSize = new System.Drawing.SizeF(130F, 27F);
            this.pvPrint.Location = new System.Drawing.Point(134, 5);
            this.pvPrint.Name = "pvPrint";
            this.pvPrint.Size = new System.Drawing.Size(1010, 654);
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
            this.radPdfViewerNavigator.Size = new System.Drawing.Size(1004, 0);
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
            this.radPdfViewer.Size = new System.Drawing.Size(1004, 527);
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
            this.radWaitingBar1.WaitingStarted += new System.EventHandler(this.radWaitingBar1_WaitingStarted);
            this.radWaitingBar1.WaitingStopped += new System.EventHandler(this.radWaitingBar1_WaitingStopped);
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(960, 627);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(175, 24);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "вперед";
            this.btnNext.ThemeName = "Office2013Light";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(779, 627);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 24);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "назад";
            this.btnBack.ThemeName = "Office2013Light";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AnketaConsumer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pageAnketaConsumer);
            this.Name = "AnketaConsumer";
            this.Size = new System.Drawing.Size(1149, 664);
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).EndInit();
            this.pageAnketaConsumer.ResumeLayout(false);
            this.pvClientName.ResumeLayout(false);
            this.pvAddress.ResumeLayout(false);
            this.pvManagers.ResumeLayout(false);
            this.pvPlaces.ResumeLayout(false);
            this.pvPlaces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPlacesTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).EndInit();
            this.pvBankRequisites.ResumeLayout(false);
            this.pvPrint.ResumeLayout(false);
            this.pvPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer)).EndInit();
            this.radPdfViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
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
        private Telerik.WinControls.UI.RadPageViewPage pvPrint;
        private Telerik.WinControls.UI.RadButton btnNext;
        private Telerik.WinControls.UI.RadButton btnBack;
        private Telerik.WinControls.UI.RadLabel ctrlPlacesTitle;
        private Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigator;
        private Telerik.WinControls.UI.RadPdfViewer radPdfViewer;
        private MiddleControlClientName ctrlClientName;
        private MiddleControlAddress ctrlAddress;
        private MiddleControlManagers ctrlManagers;
        private MiddleControlBankRequisites ctrlBankRequisites;
        private ipsAnketaClient.ConsumerPlacesControl ctrlPlaces;
        private Telerik.WinControls.UI.RadButton btnLoadPdf;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource anketaCompanyBindingSource;
    }
}
