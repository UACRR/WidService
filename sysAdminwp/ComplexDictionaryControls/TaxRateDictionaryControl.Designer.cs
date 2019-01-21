namespace sysAdminwp.ComplexDictionaryControls
{
    partial class TaxRateDictionaryControl
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
            this.bsTaxRate = new System.Windows.Forms.BindingSource(this.components);
            this.lbTaxRate = new System.Windows.Forms.Label();
            this.ddlTaxRate = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTaxRate)).BeginInit();
            this.SuspendLayout();
            // 
            // bsTaxRate
            // 
            this.bsTaxRate.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // lbTaxRate
            // 
            this.lbTaxRate.AutoSize = true;
            this.lbTaxRate.Location = new System.Drawing.Point(14, 24);
            this.lbTaxRate.Name = "lbTaxRate";
            this.lbTaxRate.Size = new System.Drawing.Size(48, 13);
            this.lbTaxRate.TabIndex = 0;
            this.lbTaxRate.Text = "TaxRate";
            // 
            // ddlTaxRate
            // 
            this.ddlTaxRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlTaxRate.DataSource = this.bsTaxRate;
            this.ddlTaxRate.DisplayMember = "Name";
            this.ddlTaxRate.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlTaxRate.FormattingEnabled = false;
            this.ddlTaxRate.Location = new System.Drawing.Point(69, 20);
            this.ddlTaxRate.Name = "ddlTaxRate";
            this.ddlTaxRate.Size = new System.Drawing.Size(440, 21);
            this.ddlTaxRate.TabIndex = 1;
            this.ddlTaxRate.ThemeName = "Office2013Light";
            this.ddlTaxRate.ValueMember = "CodeI";
            // 
            // TaxRateDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlTaxRate);
            this.Controls.Add(this.lbTaxRate);
            this.Name = "TaxRateDictionaryControl";
            this.Size = new System.Drawing.Size(512, 68);
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTaxRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsTaxRate;
        private System.Windows.Forms.Label lbTaxRate;
        private Telerik.WinControls.UI.RadDropDownList ddlTaxRate;
    }
}
