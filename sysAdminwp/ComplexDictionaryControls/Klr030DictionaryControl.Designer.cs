namespace sysAdminwp.ComplexDictionaryControls
{
    partial class Klr030DictionaryControl
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
            this.bsKlr = new System.Windows.Forms.BindingSource(this.components);
            this.bsCountry = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.bsKlr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsKlr
            // 
            this.bsKlr.DataSource = typeof(ipsFormsDesign.Model.KlR030);
            // 
            // bsCountry
            // 
            this.bsCountry.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CountryList";
            // 
            // radDropDownList1
            // 
            this.radDropDownList1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsKlr, "CountryCode", true));
            this.radDropDownList1.DataSource = this.bsCountry;
            this.radDropDownList1.DisplayMember = "CountryName";
            this.radDropDownList1.Location = new System.Drawing.Point(165, 4);
            this.radDropDownList1.Name = "radDropDownList1";
            this.radDropDownList1.Size = new System.Drawing.Size(1182, 21);
            this.radDropDownList1.TabIndex = 1;
            this.radDropDownList1.ThemeName = "Office2013Light";
            this.radDropDownList1.ValueMember = "CountryCode";
            // 
            // Klr030DictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radDropDownList1);
            this.Controls.Add(this.label1);
            this.Name = "Klr030DictionaryControl";
            this.Size = new System.Drawing.Size(1350, 28);
            ((System.ComponentModel.ISupportInitialize)(this.bsKlr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsKlr;
        private System.Windows.Forms.BindingSource bsCountry;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
    }
}
