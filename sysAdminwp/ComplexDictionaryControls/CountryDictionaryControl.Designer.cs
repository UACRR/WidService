namespace sysAdminwp.ComplexDictionaryControls
{
    partial class CountryDictionaryControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
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
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Континент";
            // 
            // CountryDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlContinent);
            this.Name = "CountryDictionaryControl";
            this.Size = new System.Drawing.Size(1334, 28);
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlContinent;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.BindingSource bsCountry;
        private System.Windows.Forms.BindingSource bsContinent;
    }
}
