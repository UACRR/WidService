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
            this.lbContinent = new Telerik.WinControls.UI.RadLabel();
            this.lbCountryCode = new Telerik.WinControls.UI.RadLabel();
            this.lbCountryName = new Telerik.WinControls.UI.RadLabel();
            this.lbKodLit = new Telerik.WinControls.UI.RadLabel();
            this.lbShortChoice = new Telerik.WinControls.UI.RadLabel();
            this.lbOrderBy = new Telerik.WinControls.UI.RadLabel();
            this.bsCountry = new System.Windows.Forms.BindingSource(this.components);
            this.bsContinent = new System.Windows.Forms.BindingSource(this.components);
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox3 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox4 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox5 = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKodLit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbShortChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOrderBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).BeginInit();
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
            this.ddlContinent.ValueMember = "ContinentCode";
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
            // bsCountry
            // 
            this.bsCountry.DataSource = typeof(ipsFormsDesign.Model.Country);
            // 
            // bsContinent
            // 
            this.bsContinent.DataSource = typeof(ipsFormsDesign.Model.Country);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.Location = new System.Drawing.Point(86, 34);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(457, 21);
            this.radTextBox1.TabIndex = 9;
            this.radTextBox1.ThemeName = "Office2013Light";
            this.radTextBox1.TextChanged += new System.EventHandler(this.radTextBox1_TextChanged);
            // 
            // radTextBox2
            // 
            this.radTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox2.Location = new System.Drawing.Point(96, 60);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(447, 21);
            this.radTextBox2.TabIndex = 10;
            this.radTextBox2.ThemeName = "Office2013Light";
            this.radTextBox2.TextChanged += new System.EventHandler(this.radTextBox2_TextChanged);
            // 
            // radTextBox3
            // 
            this.radTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox3.Location = new System.Drawing.Point(62, 86);
            this.radTextBox3.Name = "radTextBox3";
            this.radTextBox3.Size = new System.Drawing.Size(481, 21);
            this.radTextBox3.TabIndex = 11;
            this.radTextBox3.ThemeName = "Office2013Light";
            this.radTextBox3.TextChanged += new System.EventHandler(this.radTextBox3_TextChanged);
            // 
            // radTextBox4
            // 
            this.radTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox4.Location = new System.Drawing.Point(97, 113);
            this.radTextBox4.Name = "radTextBox4";
            this.radTextBox4.Size = new System.Drawing.Size(446, 21);
            this.radTextBox4.TabIndex = 12;
            this.radTextBox4.ThemeName = "Office2013Light";
            this.radTextBox4.TextChanged += new System.EventHandler(this.radTextBox4_TextChanged);
            // 
            // radTextBox5
            // 
            this.radTextBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox5.Location = new System.Drawing.Point(138, 142);
            this.radTextBox5.Name = "radTextBox5";
            this.radTextBox5.Size = new System.Drawing.Size(405, 21);
            this.radTextBox5.TabIndex = 13;
            this.radTextBox5.ThemeName = "Office2013Light";
            this.radTextBox5.TextChanged += new System.EventHandler(this.radTextBox5_TextChanged);
            // 
            // CountryDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radTextBox5);
            this.Controls.Add(this.radTextBox4);
            this.Controls.Add(this.radTextBox3);
            this.Controls.Add(this.radTextBox2);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.lbOrderBy);
            this.Controls.Add(this.lbShortChoice);
            this.Controls.Add(this.lbKodLit);
            this.Controls.Add(this.lbCountryName);
            this.Controls.Add(this.lbCountryCode);
            this.Controls.Add(this.lbContinent);
            this.Controls.Add(this.ddlContinent);
            this.Name = "CountryDictionaryControl";
            this.Size = new System.Drawing.Size(546, 177);
            this.Load += new System.EventHandler(this.CountryDictionaryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCountryName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbKodLit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbShortChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOrderBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadTextBox radTextBox3;
        private Telerik.WinControls.UI.RadTextBox radTextBox4;
        private Telerik.WinControls.UI.RadTextBox radTextBox5;
    }
}
