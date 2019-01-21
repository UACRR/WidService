namespace sysAdminwp.ComplexDictionaryControls
{
    sealed partial class CountryDictionaryControl
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
            this.ddlContinent = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCountry = new System.Windows.Forms.BindingSource(this.components);
            this.bsContinent = new System.Windows.Forms.BindingSource(this.components);
            this.lbContinent = new Telerik.WinControls.UI.RadLabel();
            this.ddlCountryCode = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCountryCode = new System.Windows.Forms.BindingSource(this.components);
            this.ddlCountryName = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCountryName = new System.Windows.Forms.BindingSource(this.components);
            this.bsKodLit = new System.Windows.Forms.BindingSource(this.components);
            this.ddlKodLit = new Telerik.WinControls.UI.RadDropDownList();
            this.bsShortChoice = new System.Windows.Forms.BindingSource(this.components);
            this.ddlShortChoice = new Telerik.WinControls.UI.RadDropDownList();
            this.lbCountryCode = new Telerik.WinControls.UI.RadLabel();
            this.lbCountryName = new Telerik.WinControls.UI.RadLabel();
            this.lbKodLit = new Telerik.WinControls.UI.RadLabel();
            this.lbShortChoice = new Telerik.WinControls.UI.RadLabel();
            this.ddlOrderBy = new Telerik.WinControls.UI.RadDropDownList();
            this.bsOrderBy = new System.Windows.Forms.BindingSource(this.components);
            this.lbOrderBy = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountryName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountryName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKodLit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKodLit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsShortChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShortChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKodLit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbShortChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrderBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrderBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOrderBy)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlContinent
            // 
            this.ddlContinent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlContinent.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCountry, "ContinentCode", true));
            this.ddlContinent.DataSource = this.bsContinent;
            this.ddlContinent.DisplayMember = "Name";
            this.ddlContinent.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlContinent.FormattingEnabled = false;
            this.ddlContinent.Location = new System.Drawing.Point(70, 3);
            this.ddlContinent.Name = "ddlContinent";
            this.ddlContinent.Size = new System.Drawing.Size(1261, 21);
            this.ddlContinent.TabIndex = 0;
            this.ddlContinent.ThemeName = "Office2013Light";
            this.ddlContinent.ValueMember = "CodeI";
            // 
            // bsCountry
            // 
            this.bsCountry.DataSource = typeof(ipsFormsDesign.Model.Country);
            // 
            // bsContinent
            // 
            this.bsContinent.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // lbContinent
            // 
            this.lbContinent.Location = new System.Drawing.Point(3, 6);
            this.lbContinent.Name = "lbContinent";
            this.lbContinent.Size = new System.Drawing.Size(61, 18);
            this.lbContinent.TabIndex = 1;
            this.lbContinent.Text = "Континент";
            // 
            // ddlCountryCode
            // 
            this.ddlCountryCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCountry, "CountryCode", true));
            this.ddlCountryCode.DataSource = this.bsCountryCode;
            this.ddlCountryCode.DisplayMember = "Name";
            this.ddlCountryCode.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountryCode.FormattingEnabled = false;
            this.ddlCountryCode.Location = new System.Drawing.Point(70, 31);
            this.ddlCountryCode.Name = "ddlCountryCode";
            this.ddlCountryCode.Size = new System.Drawing.Size(1261, 21);
            this.ddlCountryCode.TabIndex = 2;
            this.ddlCountryCode.ThemeName = "Office2013Light";
            this.ddlCountryCode.ValueMember = "CodeI";
            // 
            // bsCountryCode
            // 
            this.bsCountryCode.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // ddlCountryName
            // 
            this.ddlCountryName.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCountry, "CountryName", true));
            this.ddlCountryName.DataSource = this.bsCountryName;
            this.ddlCountryName.DisplayMember = "Name";
            this.ddlCountryName.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountryName.FormattingEnabled = false;
            this.ddlCountryName.Location = new System.Drawing.Point(70, 57);
            this.ddlCountryName.Name = "ddlCountryName";
            this.ddlCountryName.Size = new System.Drawing.Size(1261, 21);
            this.ddlCountryName.TabIndex = 3;
            this.ddlCountryName.ThemeName = "Office2013Light";
            this.ddlCountryName.ValueMember = "CodeI";
            // 
            // bsCountryName
            // 
            this.bsCountryName.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // bsKodLit
            // 
            this.bsKodLit.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // ddlKodLit
            // 
            this.ddlKodLit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCountry, "KOdLit", true));
            this.ddlKodLit.DataSource = this.bsKodLit;
            this.ddlKodLit.DisplayMember = "Name";
            this.ddlKodLit.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlKodLit.FormattingEnabled = false;
            this.ddlKodLit.Location = new System.Drawing.Point(70, 84);
            this.ddlKodLit.Name = "ddlKodLit";
            this.ddlKodLit.Size = new System.Drawing.Size(1261, 21);
            this.ddlKodLit.TabIndex = 4;
            this.ddlKodLit.ThemeName = "Office2013Light";
            this.ddlKodLit.ValueMember = "CodeI";
            // 
            // bsShortChoice
            // 
            this.bsShortChoice.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // ddlShortChoice
            // 
            this.ddlShortChoice.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCountry, "ShortChoise", true));
            this.ddlShortChoice.DataSource = this.bsShortChoice;
            this.ddlShortChoice.DisplayMember = "Name";
            this.ddlShortChoice.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlShortChoice.FormattingEnabled = false;
            this.ddlShortChoice.Location = new System.Drawing.Point(70, 111);
            this.ddlShortChoice.Name = "ddlShortChoice";
            this.ddlShortChoice.Size = new System.Drawing.Size(1261, 21);
            this.ddlShortChoice.TabIndex = 5;
            this.ddlShortChoice.ThemeName = "Office2013Light";
            this.ddlShortChoice.ValueMember = "CodeI";
            // 
            // lbCountryCode
            // 
            this.lbCountryCode.Location = new System.Drawing.Point(3, 34);
            this.lbCountryCode.Name = "lbCountryCode";
            this.lbCountryCode.Size = new System.Drawing.Size(61, 18);
            this.lbCountryCode.TabIndex = 6;
            this.lbCountryCode.Text = "Континент";
            // 
            // lbCountryName
            // 
            this.lbCountryName.Location = new System.Drawing.Point(3, 58);
            this.lbCountryName.Name = "lbCountryName";
            this.lbCountryName.Size = new System.Drawing.Size(61, 18);
            this.lbCountryName.TabIndex = 2;
            this.lbCountryName.Text = "Континент";
            // 
            // lbKodLit
            // 
            this.lbKodLit.Location = new System.Drawing.Point(3, 81);
            this.lbKodLit.Name = "lbKodLit";
            this.lbKodLit.Size = new System.Drawing.Size(61, 18);
            this.lbKodLit.TabIndex = 2;
            this.lbKodLit.Text = "Континент";
            // 
            // lbShortChoice
            // 
            this.lbShortChoice.Location = new System.Drawing.Point(3, 111);
            this.lbShortChoice.Name = "lbShortChoice";
            this.lbShortChoice.Size = new System.Drawing.Size(61, 18);
            this.lbShortChoice.TabIndex = 2;
            this.lbShortChoice.Text = "Континент";
            // 
            // ddlOrderBy
            // 
            this.ddlOrderBy.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCountry, "OrderBy", true));
            this.ddlOrderBy.DataSource = this.bsOrderBy;
            this.ddlOrderBy.DisplayMember = "Name";
            this.ddlOrderBy.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlOrderBy.FormattingEnabled = false;
            this.ddlOrderBy.Location = new System.Drawing.Point(70, 139);
            this.ddlOrderBy.Name = "ddlOrderBy";
            this.ddlOrderBy.Size = new System.Drawing.Size(1261, 21);
            this.ddlOrderBy.TabIndex = 7;
            this.ddlOrderBy.ThemeName = "Office2013Light";
            this.ddlOrderBy.ValueMember = "CodeI";
            // 
            // bsOrderBy
            // 
            this.bsOrderBy.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // lbOrderBy
            // 
            this.lbOrderBy.Location = new System.Drawing.Point(3, 142);
            this.lbOrderBy.Name = "lbOrderBy";
            this.lbOrderBy.Size = new System.Drawing.Size(61, 18);
            this.lbOrderBy.TabIndex = 8;
            this.lbOrderBy.Text = "Континент";
            // 
            // CountryDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbOrderBy);
            this.Controls.Add(this.ddlOrderBy);
            this.Controls.Add(this.lbShortChoice);
            this.Controls.Add(this.lbKodLit);
            this.Controls.Add(this.lbCountryName);
            this.Controls.Add(this.lbCountryCode);
            this.Controls.Add(this.ddlShortChoice);
            this.Controls.Add(this.ddlKodLit);
            this.Controls.Add(this.ddlCountryName);
            this.Controls.Add(this.ddlCountryCode);
            this.Controls.Add(this.lbContinent);
            this.Controls.Add(this.ddlContinent);
            this.Name = "CountryDictionaryControl";
            this.Size = new System.Drawing.Size(1334, 177);
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountryName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountryName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKodLit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKodLit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsShortChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlShortChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKodLit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbShortChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrderBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrderBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOrderBy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlContinent;
        private Telerik.WinControls.UI.RadLabel lbContinent;
        private System.Windows.Forms.BindingSource bsCountry;
        private System.Windows.Forms.BindingSource bsContinent;
        private Telerik.WinControls.UI.RadDropDownList ddlCountryCode;
        private System.Windows.Forms.BindingSource bsCountryCode;
        private Telerik.WinControls.UI.RadDropDownList ddlCountryName;
        private System.Windows.Forms.BindingSource bsCountryName;
        private System.Windows.Forms.BindingSource bsKodLit;
        private Telerik.WinControls.UI.RadDropDownList ddlKodLit;
        private System.Windows.Forms.BindingSource bsShortChoice;
        private Telerik.WinControls.UI.RadDropDownList ddlShortChoice;
        private Telerik.WinControls.UI.RadLabel lbCountryCode;
        private Telerik.WinControls.UI.RadLabel lbCountryName;
        private Telerik.WinControls.UI.RadLabel lbKodLit;
        private Telerik.WinControls.UI.RadLabel lbShortChoice;
        private Telerik.WinControls.UI.RadDropDownList ddlOrderBy;
        private Telerik.WinControls.UI.RadLabel lbOrderBy;
        private System.Windows.Forms.BindingSource bsOrderBy;
    }
}
