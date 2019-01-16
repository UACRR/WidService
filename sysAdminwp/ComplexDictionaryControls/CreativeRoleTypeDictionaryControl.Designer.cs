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
            this.bsCreativeRoleType = new System.Windows.Forms.BindingSource(this.components);
            this.bsCategory = new System.Windows.Forms.BindingSource(this.components);
            this.ddlCopyright = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCopyrightType = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreativeRoleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightType)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlCategory
            // 
            this.ddlCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCreativeRoleType, "CategoryCode", true));
            this.ddlCategory.DataSource = this.bsCategory;
            this.ddlCategory.Location = new System.Drawing.Point(165, 47);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(190, 20);
            this.ddlCategory.TabIndex = 0;
            // 
            // bsCreativeRoleType
            // 
            this.bsCreativeRoleType.DataSource = typeof(ipsFormsDesign.Model.CreativeRoleType);
            // 
            // bsCategory
            // 
            this.bsCategory.DataSource = typeof(ipsFormsDesign.Model.Category);
            // 
            // ddlCopyright
            // 
            this.ddlCopyright.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCreativeRoleType, "Crtype", true));
            this.ddlCopyright.DataSource = this.bsCopyrightType;
            this.ddlCopyright.DisplayMember = "Name";
            this.ddlCopyright.Location = new System.Drawing.Point(165, 73);
            this.ddlCopyright.Name = "ddlCopyright";
            this.ddlCopyright.Size = new System.Drawing.Size(190, 20);
            this.ddlCopyright.TabIndex = 2;
            this.ddlCopyright.ValueMember = "CodeI";
            // 
            // bsCopyrightType
            // 
            this.bsCopyrightType.DataSource = typeof(ipsFormsDesign.Model.CopyrightType);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CategoryList";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CopyrightType";
            // 
            // CreativeRoleTypeDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlCopyright);
            this.Controls.Add(this.ddlCategory);
            this.Name = "CreativeRoleTypeDictionaryControl";
            this.Size = new System.Drawing.Size(551, 264);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreativeRoleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCopyright)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
