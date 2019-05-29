namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class PersonalAddressControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.btnCopyFromRegToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromLiveToReg = new Telerik.WinControls.UI.RadButton();
            this.ctrlAddressLetter = new IpsViewComponentLibrary.Shared.Controls.AddressLetter();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAddressRegister = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.ctrlAddressLive = new IpsViewComponentLibrary.Shared.Controls.IpsAddressControl();
            this.ctrlContacts = new IpsViewComponentLibrary.Shared.Controls.ContactsPersonControl();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // radSeparator2
            // 
            this.radSeparator2.Location = new System.Drawing.Point(131, 3);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(637, 18);
            this.radSeparator2.TabIndex = 83;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Location = new System.Drawing.Point(123, 185);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(645, 19);
            this.radSeparator3.TabIndex = 85;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(117, 81);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(651, 19);
            this.radSeparator1.TabIndex = 84;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // btnCopyFromRegToLett
            // 
            this.btnCopyFromRegToLett.Location = new System.Drawing.Point(339, 210);
            this.btnCopyFromRegToLett.Name = "btnCopyFromRegToLett";
            this.btnCopyFromRegToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromRegToLett.TabIndex = 82;
            this.btnCopyFromRegToLett.Text = "Копіювати з адреси реєстрації";
            this.btnCopyFromRegToLett.ThemeName = "Office2013Light";
            this.btnCopyFromRegToLett.Click += new System.EventHandler(this.btnCopyFromRegToLett_Click);
            // 
            // btnCopyFromLiveToLett
            // 
            this.btnCopyFromLiveToLett.Location = new System.Drawing.Point(133, 210);
            this.btnCopyFromLiveToLett.Name = "btnCopyFromLiveToLett";
            this.btnCopyFromLiveToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToLett.TabIndex = 81;
            this.btnCopyFromLiveToLett.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToLett.ThemeName = "Office2013Light";
            this.btnCopyFromLiveToLett.Click += new System.EventHandler(this.btnCopyFromLiveToLett_Click);
            // 
            // btnCopyFromLiveToReg
            // 
            this.btnCopyFromLiveToReg.Location = new System.Drawing.Point(133, 106);
            this.btnCopyFromLiveToReg.Name = "btnCopyFromLiveToReg";
            this.btnCopyFromLiveToReg.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromLiveToReg.TabIndex = 80;
            this.btnCopyFromLiveToReg.Text = "Копіювати з адреси проживання";
            this.btnCopyFromLiveToReg.ThemeName = "Office2013Light";
            this.btnCopyFromLiveToReg.Click += new System.EventHandler(this.btnCopyFromLiveToReg_Click);
            // 
            // ctrlAddressLetter
            // 
            this.ctrlAddressLetter.AddressDataMember = "LeAddress";
            this.ctrlAddressLetter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlAddressLetter.CityDataMember = "LeCity";
            this.ctrlAddressLetter.CountryDataMember = "LeCountry";
            this.ctrlAddressLetter.DataSource = this.bsAnketaPerson;
            this.ctrlAddressLetter.Location = new System.Drawing.Point(129, 235);
            this.ctrlAddressLetter.Name = "ctrlAddressLetter";
            this.ctrlAddressLetter.PostIndexDataMember = "LePostIndex";
            this.ctrlAddressLetter.RegionDataMember = "LeRegion";
            this.ctrlAddressLetter.Size = new System.Drawing.Size(616, 54);
            this.ctrlAddressLetter.TabIndex = 79;
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 185);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(114, 19);
            this.radLabel3.TabIndex = 78;
            this.radLabel3.Text = "Адреса листування";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 81);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(108, 19);
            this.radLabel2.TabIndex = 77;
            this.radLabel2.Text = "Адреса реєстрації";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(122, 19);
            this.radLabel1.TabIndex = 76;
            this.radLabel1.Text = "Адреса проживання";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ctrlAddressRegister
            // 
            this.ctrlAddressRegister.AddressDataMember = "ReAddress";
            this.ctrlAddressRegister.CityDataMember = "ReCity";
            this.ctrlAddressRegister.CountryDataMember = "ReCountry";
            this.ctrlAddressRegister.DataSource = this.bsAnketaPerson;
            this.ctrlAddressRegister.Location = new System.Drawing.Point(133, 131);
            this.ctrlAddressRegister.Name = "ctrlAddressRegister";
            this.ctrlAddressRegister.RegionDataMember = "ReRegion";
            this.ctrlAddressRegister.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressRegister.TabIndex = 74;
            // 
            // ctrlAddressLive
            // 
            this.ctrlAddressLive.AddressDataMember = "FaAddress";
            this.ctrlAddressLive.CityDataMember = "FaCity";
            this.ctrlAddressLive.CountryDataMember = "FaCountry";
            this.ctrlAddressLive.DataSource = this.bsAnketaPerson;
            this.ctrlAddressLive.Location = new System.Drawing.Point(133, 27);
            this.ctrlAddressLive.Name = "ctrlAddressLive";
            this.ctrlAddressLive.RegionDataMember = "FaRegion";
            this.ctrlAddressLive.Size = new System.Drawing.Size(612, 48);
            this.ctrlAddressLive.TabIndex = 73;
            // 
            // ctrlContacts
            // 
            this.ctrlContacts.DataSource = this.bsAnketaPerson;
            this.ctrlContacts.Location = new System.Drawing.Point(10, 294);
            this.ctrlContacts.MaximumSize = new System.Drawing.Size(625, 50);
            this.ctrlContacts.Name = "ctrlContacts";
            this.ctrlContacts.Size = new System.Drawing.Size(625, 50);
            this.ctrlContacts.TabIndex = 75;
            // 
            // PersonalAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSeparator2);
            this.Controls.Add(this.radSeparator3);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.btnCopyFromRegToLett);
            this.Controls.Add(this.btnCopyFromLiveToLett);
            this.Controls.Add(this.btnCopyFromLiveToReg);
            this.Controls.Add(this.ctrlAddressLetter);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ctrlAddressRegister);
            this.Controls.Add(this.ctrlAddressLive);
            this.Controls.Add(this.ctrlContacts);
            this.Name = "PersonalAddressControl";
            this.Size = new System.Drawing.Size(776, 351);
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromRegToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromLiveToReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
    }
}
