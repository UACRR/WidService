namespace sysAdminwp.ComplexDictionaryControls
{
    sealed partial class Klr030DictionaryControl
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
            this.lbKlr = new System.Windows.Forms.Label();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.bsKlr = new System.Windows.Forms.BindingSource(this.components);
            this.bsCountry = new System.Windows.Forms.BindingSource(this.components);
            this.ddlKlr031 = new Telerik.WinControls.UI.RadDropDownList();
            this.bsKlr031 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKlr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKlr031)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKlr031)).BeginInit();
            this.SuspendLayout();
            // 
            // lbKlr
            // 
            this.lbKlr.AutoSize = true;
            this.lbKlr.Location = new System.Drawing.Point(3, 6);
            this.lbKlr.Name = "lbKlr";
            this.lbKlr.Size = new System.Drawing.Size(35, 13);
            this.lbKlr.TabIndex = 0;
            this.lbKlr.Text = "Місто";
            // 
            // ddlCountry
            // 
            this.ddlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCountry.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsKlr, "CountryCode", true));
            this.ddlCountry.DataSource = this.bsCountry;
            this.ddlCountry.DisplayMember = "Name";
            this.ddlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountry.FormattingEnabled = false;
            this.ddlCountry.Location = new System.Drawing.Point(44, 4);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(434, 21);
            this.ddlCountry.TabIndex = 1;
            this.ddlCountry.ThemeName = "Office2013Light";
            this.ddlCountry.ValueMember = "CodeI";
            this.ddlCountry.Click += new System.EventHandler(this.ddlCountry_Click);
            // 
            // bsKlr
            // 
            this.bsKlr.DataSource = typeof(ipsFormsDesign.Model.KlR030);
            // 
            // bsCountry
            // 
            this.bsCountry.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // ddlKlr031
            // 
            this.ddlKlr031.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlKlr031.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsKlr, "R031Navigation", true));
            this.ddlKlr031.DataSource = this.bsKlr031;
            this.ddlKlr031.DisplayMember = "Name";
            this.ddlKlr031.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlKlr031.FormattingEnabled = false;
            this.ddlKlr031.Location = new System.Drawing.Point(67, 31);
            this.ddlKlr031.Name = "ddlKlr031";
            this.ddlKlr031.Size = new System.Drawing.Size(411, 21);
            this.ddlKlr031.TabIndex = 2;
            this.ddlKlr031.ThemeName = "Office2013Light";
            this.ddlKlr031.ValueMember = "CodeI";
            this.ddlKlr031.Click += new System.EventHandler(this.ddlKlr031_Click);
            // 
            // bsKlr031
            // 
            this.bsKlr031.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Навігация";
            // 
            // Klr030DictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlKlr031);
            this.Controls.Add(this.ddlCountry);
            this.Controls.Add(this.lbKlr);
            this.Name = "Klr030DictionaryControl";
            this.Size = new System.Drawing.Size(481, 54);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKlr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKlr031)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKlr031)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsKlr;
        private System.Windows.Forms.BindingSource bsCountry;
        private System.Windows.Forms.Label lbKlr;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
        private System.Windows.Forms.BindingSource bsKlr031;
        private Telerik.WinControls.UI.RadDropDownList ddlKlr031;
        private System.Windows.Forms.Label label1;
    }
}
