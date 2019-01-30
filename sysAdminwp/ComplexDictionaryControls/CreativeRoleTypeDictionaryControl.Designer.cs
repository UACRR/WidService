namespace sysAdminwp.ComplexDictionaryControls
{
    sealed partial class CreativeRoleTypeDictionaryControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreativeRoleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlCategory
            // 
            this.ddlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCreativeRoleType, "CategoryCode", true));
            this.ddlCategory.DataSource = this.bsCategory;
            this.ddlCategory.DisplayMember = "Name";
            this.ddlCategory.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCategory.FormattingEnabled = false;
            this.ddlCategory.Location = new System.Drawing.Point(75, 4);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(464, 21);
            this.ddlCategory.TabIndex = 0;
            this.ddlCategory.ThemeName = "Office2013Light";
            this.ddlCategory.ValueMember = "CodeI";
            this.ddlCategory.Click += new System.EventHandler(this.ddlCategory_Click);
            // 
            // bsCreativeRoleType
            // 
            this.bsCreativeRoleType.DataSource = typeof(ipsFormsDesign.Model.CreativeRoleType);
            // 
            // bsCategory
            // 
            this.bsCategory.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // ddlCopyright
            // 
            this.ddlCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCopyright.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCreativeRoleType, "Crtype", true));
            this.ddlCopyright.DataSource = this.bsCopyrightType;
            this.ddlCopyright.DisplayMember = "Name";
            this.ddlCopyright.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCopyright.FormattingEnabled = false;
            this.ddlCopyright.Location = new System.Drawing.Point(75, 30);
            this.ddlCopyright.Name = "ddlCopyright";
            this.ddlCopyright.Size = new System.Drawing.Size(464, 21);
            this.ddlCopyright.TabIndex = 2;
            this.ddlCopyright.ThemeName = "Office2013Light";
            this.ddlCopyright.ValueMember = "CodeI";
            this.ddlCopyright.Click += new System.EventHandler(this.ddlCopyright_Click);
            // 
            // bsCopyrightType
            // 
            this.bsCopyrightType.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(60, 19);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "Категорія";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(64, 19);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "Вид права";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // CreativeRoleTypeDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlCopyright);
            this.Controls.Add(this.ddlCategory);
            this.Name = "CreativeRoleTypeDictionaryControl";
            this.Size = new System.Drawing.Size(542, 56);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreativeRoleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCopyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlCategory;
        private Telerik.WinControls.UI.RadDropDownList ddlCopyright;
        private System.Windows.Forms.BindingSource bsCreativeRoleType;
        private System.Windows.Forms.BindingSource bsCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsCopyrightType;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
