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
            this.lbCountryCode = new Telerik.WinControls.UI.RadLabel();
            this.lbCountryName = new Telerik.WinControls.UI.RadLabel();
            this.lbKodLit = new Telerik.WinControls.UI.RadLabel();
            this.lbShortChoice = new Telerik.WinControls.UI.RadLabel();
            this.lbOrderBy = new Telerik.WinControls.UI.RadLabel();
            this.tbCountryCode = new Telerik.WinControls.UI.RadTextBox();
            this.tbCountryName = new Telerik.WinControls.UI.RadTextBox();
            this.tbKod_lit = new Telerik.WinControls.UI.RadTextBox();
            this.tbShortChoice = new Telerik.WinControls.UI.RadTextBox();
            this.tbOrderBy = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKodLit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbShortChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOrderBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountryName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbKod_lit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShortChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrderBy)).BeginInit();
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
            this.ddlContinent.Size = new System.Drawing.Size(473, 21);
            this.ddlContinent.TabIndex = 0;
            this.ddlContinent.ThemeName = "Office2013Light";
            this.ddlContinent.ValueMember = "CodeI";
            this.ddlContinent.Click += new System.EventHandler(this.ddlContinent_Click);
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
            // lbCountryCode
            // 
            this.lbCountryCode.Location = new System.Drawing.Point(3, 34);
            this.lbCountryCode.Name = "lbCountryCode";
            this.lbCountryCode.Size = new System.Drawing.Size(76, 18);
            this.lbCountryCode.TabIndex = 6;
            this.lbCountryCode.Text = "Код Держави";
            // 
            // lbCountryName
            // 
            this.lbCountryName.Location = new System.Drawing.Point(3, 58);
            this.lbCountryName.Name = "lbCountryName";
            this.lbCountryName.Size = new System.Drawing.Size(87, 18);
            this.lbCountryName.TabIndex = 2;
            this.lbCountryName.Text = "Назва Держави";
            // 
            // lbKodLit
            // 
            this.lbKodLit.Location = new System.Drawing.Point(3, 83);
            this.lbKodLit.Name = "lbKodLit";
            this.lbKodLit.Size = new System.Drawing.Size(53, 18);
            this.lbKodLit.TabIndex = 2;
            this.lbKodLit.Text = "літерація";
            // 
            // lbShortChoice
            // 
            this.lbShortChoice.Location = new System.Drawing.Point(3, 111);
            this.lbShortChoice.Name = "lbShortChoice";
            this.lbShortChoice.Size = new System.Drawing.Size(88, 18);
            this.lbShortChoice.TabIndex = 2;
            this.lbShortChoice.Text = "Короткий вибір";
            // 
            // lbOrderBy
            // 
            this.lbOrderBy.Location = new System.Drawing.Point(3, 142);
            this.lbOrderBy.Name = "lbOrderBy";
            this.lbOrderBy.Size = new System.Drawing.Size(129, 18);
            this.lbOrderBy.TabIndex = 8;
            this.lbOrderBy.Text = "Порядок відображення";
            // 
            // tbCountryCode
            // 
            this.tbCountryCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountryCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCountry, "CountryCode", true));
            this.tbCountryCode.Location = new System.Drawing.Point(86, 34);
            this.tbCountryCode.Name = "tbCountryCode";
            this.tbCountryCode.Size = new System.Drawing.Size(457, 21);
            this.tbCountryCode.TabIndex = 9;
            this.tbCountryCode.ThemeName = "Office2013Light";
            this.tbCountryCode.Click += new System.EventHandler(this.tbCountryCode_Click);
            // 
            // tbCountryName
            // 
            this.tbCountryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountryName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCountry, "CountryName", true));
            this.tbCountryName.Location = new System.Drawing.Point(96, 60);
            this.tbCountryName.Name = "tbCountryName";
            this.tbCountryName.Size = new System.Drawing.Size(447, 21);
            this.tbCountryName.TabIndex = 10;
            this.tbCountryName.ThemeName = "Office2013Light";
            this.tbCountryName.Click += new System.EventHandler(this.tbCountryName_Click);
            // 
            // tbKod_lit
            // 
            this.tbKod_lit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKod_lit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCountry, "KOdLit", true));
            this.tbKod_lit.Location = new System.Drawing.Point(62, 86);
            this.tbKod_lit.Name = "tbKod_lit";
            this.tbKod_lit.Size = new System.Drawing.Size(481, 21);
            this.tbKod_lit.TabIndex = 11;
            this.tbKod_lit.ThemeName = "Office2013Light";
            this.tbKod_lit.Click += new System.EventHandler(this.tbKod_lit_Click);
            // 
            // tbShortChoice
            // 
            this.tbShortChoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbShortChoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCountry, "ShortChoise", true));
            this.tbShortChoice.Location = new System.Drawing.Point(97, 113);
            this.tbShortChoice.Name = "tbShortChoice";
            this.tbShortChoice.Size = new System.Drawing.Size(446, 21);
            this.tbShortChoice.TabIndex = 12;
            this.tbShortChoice.ThemeName = "Office2013Light";
            this.tbShortChoice.Click += new System.EventHandler(this.tbShortChoice_Click);
            // 
            // tbOrderBy
            // 
            this.tbOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOrderBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCountry, "OrderBy", true));
            this.tbOrderBy.Location = new System.Drawing.Point(138, 142);
            this.tbOrderBy.Name = "tbOrderBy";
            this.tbOrderBy.Size = new System.Drawing.Size(405, 21);
            this.tbOrderBy.TabIndex = 13;
            this.tbOrderBy.ThemeName = "Office2013Light";
            this.tbOrderBy.Click += new System.EventHandler(this.tbOrderBy_Click);
            // 
            // CountryDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbOrderBy);
            this.Controls.Add(this.tbShortChoice);
            this.Controls.Add(this.tbKod_lit);
            this.Controls.Add(this.tbCountryName);
            this.Controls.Add(this.tbCountryCode);
            this.Controls.Add(this.lbOrderBy);
            this.Controls.Add(this.lbShortChoice);
            this.Controls.Add(this.lbKodLit);
            this.Controls.Add(this.lbCountryName);
            this.Controls.Add(this.lbCountryCode);
            this.Controls.Add(this.lbContinent);
            this.Controls.Add(this.ddlContinent);
            this.Name = "CountryDictionaryControl";
            this.Size = new System.Drawing.Size(546, 167);
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKodLit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbShortChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOrderBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountryName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbKod_lit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShortChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrderBy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlContinent;
        private Telerik.WinControls.UI.RadLabel lbContinent;
        private System.Windows.Forms.BindingSource bsCountry;
        private System.Windows.Forms.BindingSource bsContinent;
        private Telerik.WinControls.UI.RadLabel lbCountryCode;
        private Telerik.WinControls.UI.RadLabel lbCountryName;
        private Telerik.WinControls.UI.RadLabel lbKodLit;
        private Telerik.WinControls.UI.RadLabel lbShortChoice;
        private Telerik.WinControls.UI.RadLabel lbOrderBy;
        private Telerik.WinControls.UI.RadTextBox tbCountryCode;
        private Telerik.WinControls.UI.RadTextBox tbCountryName;
        private Telerik.WinControls.UI.RadTextBox tbKod_lit;
        private Telerik.WinControls.UI.RadTextBox tbShortChoice;
        private Telerik.WinControls.UI.RadTextBox tbOrderBy;
    }
}
