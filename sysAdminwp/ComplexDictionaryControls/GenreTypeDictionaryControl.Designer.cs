namespace sysAdminwp.ComplexDictionaryControls
{
    partial class GenreTypeDictionaryControl
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
            this.bsGenreType = new System.Windows.Forms.BindingSource(this.components);
            this.bsCategory = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ddlCategory = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.bsGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // bsGenreType
            // 
            this.bsGenreType.DataSource = typeof(ipsFormsDesign.Model.GenreType);
            // 
            // bsCategory
            // 
            this.bsCategory.DataSource = typeof(ipsFormsDesign.Model.Category);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CategoryList";
            // 
            // ddlCategory
            // 
            this.ddlCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsGenreType, "CategoryCode", true));
            this.ddlCategory.DataSource = this.bsCategory;
            this.ddlCategory.DisplayMember = "Name";
            this.ddlCategory.Location = new System.Drawing.Point(144, 64);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(244, 20);
            this.ddlCategory.TabIndex = 1;
            this.ddlCategory.ThemeName = "Office2013Light";
            this.ddlCategory.ValueMember = "CodeI";
            // 
            // GenreTypeDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlCategory);
            this.Controls.Add(this.label1);
            this.Name = "GenreTypeDictionaryControl";
            this.Size = new System.Drawing.Size(567, 280);
            ((System.ComponentModel.ISupportInitialize)(this.bsGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsGenreType;
        private System.Windows.Forms.BindingSource bsCategory;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList ddlCategory;
    }
}
