namespace IpsViewComponentLibrary
{
    partial class MiddleControlAddress
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
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.addressFactual = new IpsViewComponentLibrary.IpsAddressControl();
            this.addressLegal = new IpsViewComponentLibrary.IpsAddressControl();
            this.btnCopyFromJaToLe = new Telerik.WinControls.UI.RadButton();
            this.radSeparator6 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.btnCopyFromJaToFa = new Telerik.WinControls.UI.RadButton();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.addressLetter = new IpsViewComponentLibrary.AddressLetter();
            this.btnCopyFromFaToLe = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.DdlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.DdlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.TxtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.TxtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.DdlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.DdlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.TxtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.TxtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToFa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.DdlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.DdlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.TxtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.TxtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.TxtPostIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromFaToLe)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(35, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 22);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Назва «Клієнта»";
            // 
            // addressFactual
            // 
            this.addressFactual.AddressDataMember = null;
            this.addressFactual.CityDataMember = null;
            this.addressFactual.CountriesDataMember = "";
            this.addressFactual.CountriesDataSource = null;
            this.addressFactual.CountriesDisplayMember = "";
            this.addressFactual.CountriesValueMember = "";
            this.addressFactual.CountryDataMember = null;
            this.addressFactual.DataMember = "";
            this.addressFactual.DataSource = null;
            // 
            // 
            // 
            this.addressFactual.DdlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressFactual.DdlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.addressFactual.DdlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.addressFactual.DdlCountry.Location = new System.Drawing.Point(0, 0);
            this.addressFactual.DdlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.addressFactual.DdlCountry.Name = "ddlCountry";
            // 
            // 
            // 
            this.addressFactual.DdlCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 351, 20);
            this.addressFactual.DdlCountry.RootElement.StretchVertically = true;
            this.addressFactual.DdlCountry.Size = new System.Drawing.Size(220, 20);
            this.addressFactual.DdlCountry.TabIndex = 0;
            // 
            // 
            // 
            this.addressFactual.DdlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressFactual.DdlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.addressFactual.DdlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.addressFactual.DdlRegion.Location = new System.Drawing.Point(240, 0);
            this.addressFactual.DdlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.addressFactual.DdlRegion.Name = "ddlRegion";
            // 
            // 
            // 
            this.addressFactual.DdlRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(358, 0, 338, 20);
            this.addressFactual.DdlRegion.RootElement.StretchVertically = true;
            this.addressFactual.DdlRegion.Size = new System.Drawing.Size(220, 20);
            this.addressFactual.DdlRegion.TabIndex = 1;
            this.addressFactual.Location = new System.Drawing.Point(20, 161);
            this.addressFactual.Name = "addressFactual";
            this.addressFactual.RegionDataMember = null;
            this.addressFactual.RegionsDataMember = "";
            this.addressFactual.RegionsDataSource = null;
            this.addressFactual.RegionsDisplayMember = "";
            this.addressFactual.RegionsValueMember = "";
            this.addressFactual.Size = new System.Drawing.Size(700, 45);
            this.addressFactual.TabIndex = 32;
            // 
            // 
            // 
            this.addressFactual.TxtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressFactual.TxtAddress.Location = new System.Drawing.Point(0, 25);
            this.addressFactual.TxtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.addressFactual.TxtAddress.Name = "txtAddress";
            this.addressFactual.TxtAddress.NullText = "Адреса";
            // 
            // 
            // 
            this.addressFactual.TxtAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 700, 20);
            this.addressFactual.TxtAddress.RootElement.StretchVertically = true;
            this.addressFactual.TxtAddress.Size = new System.Drawing.Size(700, 20);
            this.addressFactual.TxtAddress.TabIndex = 3;
            // 
            // 
            // 
            this.addressFactual.TxtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressFactual.TxtCity.Location = new System.Drawing.Point(480, 0);
            this.addressFactual.TxtCity.Margin = new System.Windows.Forms.Padding(0);
            this.addressFactual.TxtCity.Name = "txtCity";
            this.addressFactual.TxtCity.NullText = "Місто";
            // 
            // 
            // 
            this.addressFactual.TxtCity.RootElement.ControlBounds = new System.Drawing.Rectangle(480, 0, 220, 20);
            this.addressFactual.TxtCity.RootElement.StretchVertically = true;
            this.addressFactual.TxtCity.Size = new System.Drawing.Size(220, 20);
            this.addressFactual.TxtCity.TabIndex = 2;
            // 
            // addressLegal
            // 
            this.addressLegal.AddressDataMember = null;
            this.addressLegal.CityDataMember = null;
            this.addressLegal.CountriesDataMember = "";
            this.addressLegal.CountriesDataSource = null;
            this.addressLegal.CountriesDisplayMember = "";
            this.addressLegal.CountriesValueMember = "";
            this.addressLegal.CountryDataMember = null;
            this.addressLegal.DataMember = "";
            this.addressLegal.DataSource = null;
            // 
            // 
            // 
            this.addressLegal.DdlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLegal.DdlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.addressLegal.DdlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.addressLegal.DdlCountry.Location = new System.Drawing.Point(0, 0);
            this.addressLegal.DdlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.addressLegal.DdlCountry.Name = "ddlCountry";
            // 
            // 
            // 
            this.addressLegal.DdlCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 351, 20);
            this.addressLegal.DdlCountry.RootElement.StretchVertically = true;
            this.addressLegal.DdlCountry.Size = new System.Drawing.Size(220, 20);
            this.addressLegal.DdlCountry.TabIndex = 0;
            // 
            // 
            // 
            this.addressLegal.DdlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLegal.DdlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.addressLegal.DdlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.addressLegal.DdlRegion.Location = new System.Drawing.Point(240, 0);
            this.addressLegal.DdlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.addressLegal.DdlRegion.Name = "ddlRegion";
            // 
            // 
            // 
            this.addressLegal.DdlRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(358, 0, 338, 20);
            this.addressLegal.DdlRegion.RootElement.StretchVertically = true;
            this.addressLegal.DdlRegion.Size = new System.Drawing.Size(220, 20);
            this.addressLegal.DdlRegion.TabIndex = 1;
            this.addressLegal.Location = new System.Drawing.Point(20, 58);
            this.addressLegal.Name = "addressLegal";
            this.addressLegal.RegionDataMember = null;
            this.addressLegal.RegionsDataMember = "";
            this.addressLegal.RegionsDataSource = null;
            this.addressLegal.RegionsDisplayMember = "";
            this.addressLegal.RegionsValueMember = "";
            this.addressLegal.Size = new System.Drawing.Size(700, 45);
            this.addressLegal.TabIndex = 31;
            // 
            // 
            // 
            this.addressLegal.TxtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLegal.TxtAddress.Location = new System.Drawing.Point(0, 25);
            this.addressLegal.TxtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.addressLegal.TxtAddress.Name = "txtAddress";
            this.addressLegal.TxtAddress.NullText = "Адреса";
            // 
            // 
            // 
            this.addressLegal.TxtAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 700, 20);
            this.addressLegal.TxtAddress.RootElement.StretchVertically = true;
            this.addressLegal.TxtAddress.Size = new System.Drawing.Size(700, 20);
            this.addressLegal.TxtAddress.TabIndex = 3;
            // 
            // 
            // 
            this.addressLegal.TxtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressLegal.TxtCity.Location = new System.Drawing.Point(480, 0);
            this.addressLegal.TxtCity.Margin = new System.Windows.Forms.Padding(0);
            this.addressLegal.TxtCity.Name = "txtCity";
            this.addressLegal.TxtCity.NullText = "Місто";
            // 
            // 
            // 
            this.addressLegal.TxtCity.RootElement.ControlBounds = new System.Drawing.Rectangle(480, 0, 220, 20);
            this.addressLegal.TxtCity.RootElement.StretchVertically = true;
            this.addressLegal.TxtCity.Size = new System.Drawing.Size(220, 20);
            this.addressLegal.TxtCity.TabIndex = 2;
            // 
            // btnCopyFromJaToLe
            // 
            this.btnCopyFromJaToLe.Location = new System.Drawing.Point(20, 239);
            this.btnCopyFromJaToLe.Name = "btnCopyFromJaToLe";
            this.btnCopyFromJaToLe.Size = new System.Drawing.Size(153, 19);
            this.btnCopyFromJaToLe.TabIndex = 30;
            this.btnCopyFromJaToLe.Text = "Вставити з юридичної";
            this.btnCopyFromJaToLe.Click += new System.EventHandler(this.btnCopyFromJaToLe_Click);
            // 
            // radSeparator6
            // 
            this.radSeparator6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator6.Location = new System.Drawing.Point(128, 212);
            this.radSeparator6.Name = "radSeparator6";
            this.radSeparator6.Size = new System.Drawing.Size(613, 21);
            this.radSeparator6.TabIndex = 29;
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel9.Location = new System.Drawing.Point(3, 212);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(108, 21);
            this.radLabel9.TabIndex = 28;
            this.radLabel9.Text = "Поштова адреса";
            // 
            // btnCopyFromJaToFa
            // 
            this.btnCopyFromJaToFa.Location = new System.Drawing.Point(20, 136);
            this.btnCopyFromJaToFa.Name = "btnCopyFromJaToFa";
            this.btnCopyFromJaToFa.Size = new System.Drawing.Size(153, 19);
            this.btnCopyFromJaToFa.TabIndex = 27;
            this.btnCopyFromJaToFa.Text = "Вставити з юридичної";
            this.btnCopyFromJaToFa.Click += new System.EventHandler(this.btnCopyFromJaToFa_Click);
            // 
            // radSeparator2
            // 
            this.radSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator2.Location = new System.Drawing.Point(128, 109);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(613, 21);
            this.radSeparator2.TabIndex = 26;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel3.Location = new System.Drawing.Point(3, 109);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(111, 21);
            this.radLabel3.TabIndex = 25;
            this.radLabel3.Text = "Фактична адреса";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(128, 31);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(613, 21);
            this.radSeparator1.TabIndex = 24;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(3, 31);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(119, 21);
            this.radLabel2.TabIndex = 23;
            this.radLabel2.Text = "Юридична адреса";
            // 
            // addressLetter
            // 
            this.addressLetter.AddressDataMember = null;
            this.addressLetter.CityDataMember = null;
            this.addressLetter.CountriesDataMember = "";
            this.addressLetter.CountriesDataSource = null;
            this.addressLetter.CountriesDisplayMember = "";
            this.addressLetter.CountriesValueMember = "";
            this.addressLetter.CountryDataMember = null;
            this.addressLetter.DataMember = "";
            this.addressLetter.DataSource = null;
            // 
            // 
            // 
            this.addressLetter.DdlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLetter.DdlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.addressLetter.DdlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.addressLetter.DdlCountry.Location = new System.Drawing.Point(0, 0);
            this.addressLetter.DdlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.addressLetter.DdlCountry.Name = "ddlCountry";
            // 
            // 
            // 
            this.addressLetter.DdlCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 234, 20);
            this.addressLetter.DdlCountry.RootElement.StretchVertically = true;
            this.addressLetter.DdlCountry.Size = new System.Drawing.Size(220, 20);
            this.addressLetter.DdlCountry.TabIndex = 0;
            // 
            // 
            // 
            this.addressLetter.DdlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLetter.DdlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.addressLetter.DdlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.addressLetter.DdlRegion.Location = new System.Drawing.Point(240, 0);
            this.addressLetter.DdlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.addressLetter.DdlRegion.Name = "ddlRegion";
            // 
            // 
            // 
            this.addressLetter.DdlRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(254, 0, 234, 20);
            this.addressLetter.DdlRegion.RootElement.StretchVertically = true;
            this.addressLetter.DdlRegion.Size = new System.Drawing.Size(220, 20);
            this.addressLetter.DdlRegion.TabIndex = 1;
            this.addressLetter.Location = new System.Drawing.Point(20, 265);
            this.addressLetter.MaximumSize = new System.Drawing.Size(700, 45);
            this.addressLetter.MinimumSize = new System.Drawing.Size(700, 45);
            this.addressLetter.Name = "addressLetter";
            this.addressLetter.PostIndexDataMember = null;
            this.addressLetter.RegionDataMember = null;
            this.addressLetter.RegionsDataMember = "";
            this.addressLetter.RegionsDataSource = null;
            this.addressLetter.RegionsDisplayMember = "";
            this.addressLetter.RegionsValueMember = "";
            this.addressLetter.Size = new System.Drawing.Size(700, 45);
            this.addressLetter.TabIndex = 33;
            // 
            // 
            // 
            this.addressLetter.TxtAddress.Location = new System.Drawing.Point(0, 25);
            this.addressLetter.TxtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.addressLetter.TxtAddress.MinimumSize = new System.Drawing.Size(460, 20);
            this.addressLetter.TxtAddress.Name = "txtAddress";
            this.addressLetter.TxtAddress.NullText = "Адреса";
            // 
            // 
            // 
            this.addressLetter.TxtAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 422, 20);
            this.addressLetter.TxtAddress.RootElement.MinSize = new System.Drawing.Size(460, 20);
            this.addressLetter.TxtAddress.RootElement.StretchVertically = true;
            this.addressLetter.TxtAddress.Size = new System.Drawing.Size(460, 20);
            this.addressLetter.TxtAddress.TabIndex = 5;
            // 
            // 
            // 
            this.addressLetter.TxtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressLetter.TxtCity.Location = new System.Drawing.Point(480, 0);
            this.addressLetter.TxtCity.Margin = new System.Windows.Forms.Padding(0);
            this.addressLetter.TxtCity.Name = "txtCity";
            this.addressLetter.TxtCity.NullText = "Місто";
            // 
            // 
            // 
            this.addressLetter.TxtCity.RootElement.ControlBounds = new System.Drawing.Rectangle(480, 0, 220, 20);
            this.addressLetter.TxtCity.RootElement.StretchVertically = true;
            this.addressLetter.TxtCity.Size = new System.Drawing.Size(220, 20);
            this.addressLetter.TxtCity.TabIndex = 2;
            // 
            // 
            // 
            this.addressLetter.TxtPostIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLetter.TxtPostIndex.Location = new System.Drawing.Point(480, 25);
            this.addressLetter.TxtPostIndex.Margin = new System.Windows.Forms.Padding(0);
            this.addressLetter.TxtPostIndex.Name = "txtPostIndex";
            this.addressLetter.TxtPostIndex.NullText = "Поштовий індекс";
            // 
            // 
            // 
            this.addressLetter.TxtPostIndex.RootElement.ControlBounds = new System.Drawing.Rectangle(480, 25, 220, 20);
            this.addressLetter.TxtPostIndex.RootElement.StretchVertically = true;
            this.addressLetter.TxtPostIndex.Size = new System.Drawing.Size(220, 20);
            this.addressLetter.TxtPostIndex.TabIndex = 4;
            // 
            // btnCopyFromFaToLe
            // 
            this.btnCopyFromFaToLe.Location = new System.Drawing.Point(179, 240);
            this.btnCopyFromFaToLe.Name = "btnCopyFromFaToLe";
            this.btnCopyFromFaToLe.Size = new System.Drawing.Size(153, 19);
            this.btnCopyFromFaToLe.TabIndex = 34;
            this.btnCopyFromFaToLe.Text = "Вставити з фактичної";
            this.btnCopyFromFaToLe.Click += new System.EventHandler(this.btnCopyFromFaToLe_Click);
            // 
            // MiddleControlAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCopyFromFaToLe);
            this.Controls.Add(this.addressLetter);
            this.Controls.Add(this.addressFactual);
            this.Controls.Add(this.addressLegal);
            this.Controls.Add(this.btnCopyFromJaToLe);
            this.Controls.Add(this.radSeparator6);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.btnCopyFromJaToFa);
            this.Controls.Add(this.radSeparator2);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(1000, 313);
            this.MinimumSize = new System.Drawing.Size(727, 313);
            this.Name = "MiddleControlAddress";
            this.Size = new System.Drawing.Size(744, 313);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.DdlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.DdlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.TxtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressFactual.TxtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.DdlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.DdlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.TxtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLegal.TxtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToFa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.DdlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.DdlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.TxtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.TxtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressLetter.TxtPostIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromFaToLe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private IpsAddressControl addressFactual;
        private IpsAddressControl addressLegal;
        private Telerik.WinControls.UI.RadButton btnCopyFromJaToLe;
        private Telerik.WinControls.UI.RadSeparator radSeparator6;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadButton btnCopyFromJaToFa;
        private Telerik.WinControls.UI.RadSeparator radSeparator2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private AddressLetter addressLetter;
        private Telerik.WinControls.UI.RadButton btnCopyFromFaToLe;
    }
}
