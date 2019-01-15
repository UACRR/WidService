namespace sysAdminwp.ComplexDictionaryControls
{
    partial class CreativeRoleTypeDictionaryControl
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
            this.ddlCategory = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlCopyright = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCreativeRoleType = new System.Windows.Forms.BindingSource(this.components);
            this.bsCategory = new System.Windows.Forms.BindingSource(this.components);
            this.bsCopyrightType = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreativeRoleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightType)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlCategory
            // 
            this.ddlCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCreativeRoleType, "CategoryCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlCategory.DataSource = this.bsCategory;
            this.ddlCategory.DisplayMember = "Name";
            this.ddlCategory.Location = new System.Drawing.Point(165, 47);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(190, 21);
            this.ddlCategory.TabIndex = 0;
            this.ddlCategory.ThemeName = "Office2013Light";
            this.ddlCategory.ValueMember = "CodeI";
            // 
            // ddlCopyright
            // 
            this.ddlCopyright.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCreativeRoleType, "Crtype", true));
            this.ddlCopyright.DataSource = this.bsCopyrightType;
            this.ddlCopyright.DisplayMember = "Name";
            this.ddlCopyright.Location = new System.Drawing.Point(165, 73);
            this.ddlCopyright.Name = "ddlCopyright";
            this.ddlCopyright.Size = new System.Drawing.Size(190, 21);
            this.ddlCopyright.TabIndex = 2;
            this.ddlCopyright.ThemeName = "Office2013Light";
            this.ddlCopyright.ValueMember = "CodeI";
            // 
            // bsCreativeRoleType
            // 
            this.bsCreativeRoleType.DataSource = typeof(ipsFormsDesign.Model.CreativeRoleType);
            // 
            // bsCategory
            // 
            this.bsCategory.DataSource = typeof(ipsFormsDesign.Model.Category);
            // 
            // bsCopyrightType
            // 
            this.bsCopyrightType.DataSource = typeof(ipsFormsDesign.Model.CopyrightType);
            // 
            // CreativeRoleTypeDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlCopyright);
            this.Controls.Add(this.ddlCategory);
            this.Name = "CreativeRoleTypeDictionaryControl";
            this.Size = new System.Drawing.Size(551, 264);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCopyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreativeRoleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlCategory;
        private Telerik.WinControls.UI.RadDropDownList ddlCopyright;
        private System.Windows.Forms.BindingSource bsCreativeRoleType;
        private System.Windows.Forms.BindingSource bsCategory;
        private System.Windows.Forms.BindingSource bsCopyrightType;
    }
}
