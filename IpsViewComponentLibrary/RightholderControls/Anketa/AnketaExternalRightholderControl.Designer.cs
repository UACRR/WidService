namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    partial class AnketaExternalRightholderControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rhName = new Telerik.WinControls.UI.RadTextBox();
            this.bsAnketaExternal = new System.Windows.Forms.BindingSource(this.components);
            this.txtIPI = new Telerik.WinControls.UI.RadTextBox();
            this.bsRightHolder = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictCountry = new System.Windows.Forms.BindingSource(this.components);
            this.txtCustIdCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtInnOkpo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaExternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustIdCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInnOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(183, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Найменування правовласника:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // rhName
            // 
            this.rhName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rhName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaExternal, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.rhName.Location = new System.Drawing.Point(192, 3);
            this.rhName.Name = "rhName";
            this.rhName.Size = new System.Drawing.Size(332, 21);
            this.rhName.TabIndex = 1;
            this.rhName.ThemeName = "Office2013Light";
            // 
            // bsAnketaExternal
            // 
            this.bsAnketaExternal.DataSource = typeof(ipsFormsDesign.Model.AnketaExternal);
            // 
            // txtIPI
            // 
            this.txtIPI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRightHolder, "InterCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtIPI.Location = new System.Drawing.Point(192, 56);
            this.txtIPI.Name = "txtIPI";
            this.txtIPI.Size = new System.Drawing.Size(205, 21);
            this.txtIPI.TabIndex = 3;
            this.txtIPI.ThemeName = "Office2013Light";
            // 
            // bsRightHolder
            // 
            this.bsRightHolder.DataSource = typeof(ipsFormsDesign.Model.RightHolder);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 57);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(23, 19);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "IPI:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 110);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(136, 19);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Країна правовласника:";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // ddlCountry
            // 
            this.ddlCountry.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAnketaExternal, "CountryCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlCountry.DataSource = this.bsDictCountry;
            this.ddlCountry.DisplayMember = "CountryName";
            this.ddlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountry.Location = new System.Drawing.Point(192, 110);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.NullText = "Країна";
            this.ddlCountry.Size = new System.Drawing.Size(205, 21);
            this.ddlCountry.TabIndex = 5;
            this.ddlCountry.ThemeName = "Office2013Light";
            this.ddlCountry.ValueMember = "CountryCode";
            // 
            // bsDictCountry
            // 
            this.bsDictCountry.DataSource = typeof(ipsFormsDesign.Model.Country);
            // 
            // txtCustIdCode
            // 
            this.txtCustIdCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaExternal, "CustId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtCustIdCode.Enabled = false;
            this.txtCustIdCode.Location = new System.Drawing.Point(192, 29);
            this.txtCustIdCode.Name = "txtCustIdCode";
            this.txtCustIdCode.NullText = "Автоматично згенерується";
            this.txtCustIdCode.Size = new System.Drawing.Size(205, 21);
            this.txtCustIdCode.TabIndex = 7;
            this.txtCustIdCode.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(3, 30);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(140, 19);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Шифр (внутрішній код):";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // txtInnOkpo
            // 
            this.txtInnOkpo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaExternal, "InnOkpo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtInnOkpo.Location = new System.Drawing.Point(192, 83);
            this.txtInnOkpo.Name = "txtInnOkpo";
            this.txtInnOkpo.Size = new System.Drawing.Size(205, 21);
            this.txtInnOkpo.TabIndex = 9;
            this.txtInnOkpo.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(3, 84);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(107, 19);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "ЄДРПОУ (якщо є):";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // AnketaExternalRightholderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtInnOkpo);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txtCustIdCode);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.ddlCountry);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtIPI);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.rhName);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(700, 136);
            this.MinimumSize = new System.Drawing.Size(400, 136);
            this.Name = "AnketaExternalRightholderControl";
            this.Size = new System.Drawing.Size(527, 136);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rhName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaExternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustIdCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInnOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox rhName;
        private Telerik.WinControls.UI.RadTextBox txtIPI;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
        private Telerik.WinControls.UI.RadTextBox txtCustIdCode;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtInnOkpo;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private System.Windows.Forms.BindingSource bsAnketaExternal;
        private System.Windows.Forms.BindingSource bsRightHolder;
        private System.Windows.Forms.BindingSource bsDictCountry;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
