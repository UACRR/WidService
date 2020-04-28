namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class JuridicalAddressControl
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
            this.addressFactual = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            this.addressLegal = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.btnCopyFromJaToLe = new Telerik.WinControls.UI.RadButton();
            this.radSeparator6 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.btnCopyFromJaToFa = new Telerik.WinControls.UI.RadButton();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnCopyFromFaToLe = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.addressLetter = new IpsViewComponentLibrary.Shared.Controls.AddressLetter();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToFa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromFaToLe)).BeginInit();
            this.SuspendLayout();
            // 
            // addressFactual
            // 
            this.addressFactual.AddressDataMember = "FaAddress";
            this.addressFactual.CityDataMember = "FaCity";
            this.addressFactual.CountryDataMember = "FaCountry";
            this.addressFactual.DataSource = this.bsAnketaCompany;
            this.addressFactual.Location = new System.Drawing.Point(20, 133);
            this.addressFactual.Name = "addressFactual";
            this.addressFactual.RegionDataMember = "FaRegion";
            this.addressFactual.Size = new System.Drawing.Size(700, 53);
            this.addressFactual.TabIndex = 32;
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // addressLegal
            // 
            this.addressLegal.AddressDataMember = "JaAddress";
            this.addressLegal.CityDataMember = "JaCity";
            this.addressLegal.CountryDataMember = "JaCountry";
            this.addressLegal.DataSource = this.bsAnketaCompany;
            this.addressLegal.Location = new System.Drawing.Point(20, 30);
            this.addressLegal.Name = "addressLegal";
            this.addressLegal.RegionDataMember = "JaRegion";
            this.addressLegal.Size = new System.Drawing.Size(700, 52);
            this.addressLegal.TabIndex = 31;
            // 
            // btnCopyFromJaToLe
            // 
            this.btnCopyFromJaToLe.Location = new System.Drawing.Point(20, 211);
            this.btnCopyFromJaToLe.Name = "btnCopyFromJaToLe";
            this.btnCopyFromJaToLe.Size = new System.Drawing.Size(153, 19);
            this.btnCopyFromJaToLe.TabIndex = 30;
            this.btnCopyFromJaToLe.Text = "Вставити з юридичної";
            this.btnCopyFromJaToLe.ThemeName = "Office2013Light";
            this.btnCopyFromJaToLe.Click += new System.EventHandler(this.btnCopyFromJaToLe_Click);
            // 
            // radSeparator6
            // 
            this.radSeparator6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator6.Location = new System.Drawing.Point(128, 184);
            this.radSeparator6.Name = "radSeparator6";
            this.radSeparator6.Size = new System.Drawing.Size(613, 21);
            this.radSeparator6.TabIndex = 29;
            this.radSeparator6.ThemeName = "Office2013Light";
            // 
            // radLabel9
            // 
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel9.Location = new System.Drawing.Point(3, 184);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(108, 21);
            this.radLabel9.TabIndex = 28;
            this.radLabel9.Text = "Поштова адреса";
            // 
            // btnCopyFromJaToFa
            // 
            this.btnCopyFromJaToFa.Location = new System.Drawing.Point(20, 108);
            this.btnCopyFromJaToFa.Name = "btnCopyFromJaToFa";
            this.btnCopyFromJaToFa.Size = new System.Drawing.Size(153, 19);
            this.btnCopyFromJaToFa.TabIndex = 27;
            this.btnCopyFromJaToFa.Text = "Вставити з юридичної";
            this.btnCopyFromJaToFa.ThemeName = "Office2013Light";
            this.btnCopyFromJaToFa.Click += new System.EventHandler(this.btnCopyFromJaToFa_Click);
            // 
            // radSeparator2
            // 
            this.radSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator2.Location = new System.Drawing.Point(128, 81);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(613, 21);
            this.radSeparator2.TabIndex = 26;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel3.Location = new System.Drawing.Point(3, 81);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(111, 21);
            this.radLabel3.TabIndex = 25;
            this.radLabel3.Text = "Фактична адреса";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(128, 3);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(613, 21);
            this.radSeparator1.TabIndex = 24;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(3, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(119, 21);
            this.radLabel2.TabIndex = 23;
            this.radLabel2.Text = "Юридична адреса";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // btnCopyFromFaToLe
            // 
            this.btnCopyFromFaToLe.Location = new System.Drawing.Point(179, 211);
            this.btnCopyFromFaToLe.Name = "btnCopyFromFaToLe";
            this.btnCopyFromFaToLe.Size = new System.Drawing.Size(153, 19);
            this.btnCopyFromFaToLe.TabIndex = 34;
            this.btnCopyFromFaToLe.Text = "Вставити з фактичної";
            this.btnCopyFromFaToLe.ThemeName = "Office2013Light";
            this.btnCopyFromFaToLe.Click += new System.EventHandler(this.btnCopyFromFaToLe_Click);
            // 
            // addressLetter
            // 
            this.addressLetter.AddressDataMember = "LeAddress";
            this.addressLetter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addressLetter.CityDataMember = "LeCity";
            this.addressLetter.CountryDataMember = "LeCountry";
            this.addressLetter.DataSource = this.bsAnketaCompany;
            this.addressLetter.Location = new System.Drawing.Point(20, 237);
            this.addressLetter.Name = "addressLetter";
            this.addressLetter.PostIndexDataMember = "LePostIndex";
            this.addressLetter.RegionDataMember = "LeRegion";
            this.addressLetter.Size = new System.Drawing.Size(700, 54);
            this.addressLetter.TabIndex = 35;
            // 
            // JuridicalAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.addressLetter);
            this.Controls.Add(this.btnCopyFromFaToLe);
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
            this.MaximumSize = new System.Drawing.Size(1000, 295);
            this.MinimumSize = new System.Drawing.Size(727, 295);
            this.Name = "JuridicalAddressControl";
            this.Size = new System.Drawing.Size(744, 295);
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJaToFa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromFaToLe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private Telerik.WinControls.UI.RadButton btnCopyFromFaToLe;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsAnketaCompany;
        private AddressLetter addressLetter;
    }
}
