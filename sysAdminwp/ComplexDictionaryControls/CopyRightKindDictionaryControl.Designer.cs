namespace sysAdminwp.ComplexDictionaryControls
{
    sealed partial class CopyRightKindDictionaryControl
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
            this.bsCopyrightKind = new System.Windows.Forms.BindingSource(this.components);
            this.ddlCrkindGroup = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCrkindGroup = new System.Windows.Forms.BindingSource(this.components);
            this.lbCrkindGroup = new Telerik.WinControls.UI.RadLabel();
            this.bsNameDescript = new System.Windows.Forms.BindingSource(this.components);
            this.ddlNameDescript = new Telerik.WinControls.UI.RadDropDownList();
            this.lbNameDescript = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNameDescript)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNameDescript)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNameDescript)).BeginInit();
            this.SuspendLayout();
            // 
            // bsCopyrightKind
            // 
            this.bsCopyrightKind.DataSource = typeof(ipsFormsDesign.Model.CopyrightKind);
            // 
            // ddlCrkindGroup
            // 
            this.ddlCrkindGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCrkindGroup.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCopyrightKind, "CrGroupCode", true));
            this.ddlCrkindGroup.DataSource = this.bsCrkindGroup;
            this.ddlCrkindGroup.DisplayMember = "Name";
            this.ddlCrkindGroup.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCrkindGroup.FormattingEnabled = false;
            this.ddlCrkindGroup.Location = new System.Drawing.Point(126, 3);
            this.ddlCrkindGroup.Name = "ddlCrkindGroup";
            this.ddlCrkindGroup.Size = new System.Drawing.Size(1086, 21);
            this.ddlCrkindGroup.TabIndex = 0;
            this.ddlCrkindGroup.ThemeName = "Office2013Light";
            this.ddlCrkindGroup.ValueMember = "CodeI";
            // 
            // bsCrkindGroup
            // 
            this.bsCrkindGroup.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // lbCrkindGroup
            // 
            this.lbCrkindGroup.Location = new System.Drawing.Point(3, 4);
            this.lbCrkindGroup.Name = "lbCrkindGroup";
            this.lbCrkindGroup.Size = new System.Drawing.Size(117, 18);
            this.lbCrkindGroup.TabIndex = 3;
            this.lbCrkindGroup.Text = "Спосіб використання";
            // 
            // bsNameDescript
            // 
            this.bsNameDescript.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // ddlNameDescript
            // 
            this.ddlNameDescript.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCopyrightKind, "CrGroupCode", true));
            this.ddlNameDescript.DataSource = this.bsNameDescript;
            this.ddlNameDescript.DisplayMember = "Name";
            this.ddlNameDescript.Location = new System.Drawing.Point(126, 31);
            this.ddlNameDescript.Name = "ddlNameDescript";
            this.ddlNameDescript.Size = new System.Drawing.Size(1086, 21);
            this.ddlNameDescript.TabIndex = 4;
            this.ddlNameDescript.ThemeName = "Office2013Light";
            this.ddlNameDescript.ValueMember = "CodeI";
            // 
            // lbNameDescript
            // 
            this.lbNameDescript.Location = new System.Drawing.Point(3, 32);
            this.lbNameDescript.Name = "lbNameDescript";
            this.lbNameDescript.Size = new System.Drawing.Size(117, 18);
            this.lbNameDescript.TabIndex = 4;
            this.lbNameDescript.Text = "Спосіб використання";
            // 
            // CopyRightKindDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbNameDescript);
            this.Controls.Add(this.ddlNameDescript);
            this.Controls.Add(this.lbCrkindGroup);
            this.Controls.Add(this.ddlCrkindGroup);
            this.Name = "CopyRightKindDictionaryControl";
            this.Size = new System.Drawing.Size(1215, 64);
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNameDescript)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNameDescript)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbNameDescript)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCopyrightKind;
        private Telerik.WinControls.UI.RadDropDownList ddlCrkindGroup;
        private System.Windows.Forms.BindingSource bsCrkindGroup;
        private Telerik.WinControls.UI.RadLabel lbCrkindGroup;
        private System.Windows.Forms.BindingSource bsNameDescript;
        private Telerik.WinControls.UI.RadDropDownList ddlNameDescript;
        private Telerik.WinControls.UI.RadLabel lbNameDescript;
    }
}
