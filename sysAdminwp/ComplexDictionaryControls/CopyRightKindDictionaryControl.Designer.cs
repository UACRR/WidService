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
            this.bsPortalSupportRights = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPortalSupportRights)).BeginInit();
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
            this.ddlCrkindGroup.Size = new System.Drawing.Size(409, 21);
            this.ddlCrkindGroup.TabIndex = 0;
            this.ddlCrkindGroup.ThemeName = "Office2013Light";
            this.ddlCrkindGroup.ValueMember = "CodeI";
            this.ddlCrkindGroup.Click += new System.EventHandler(this.ddlCrkindGroup_Click);
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
            // bsPortalSupportRights
            // 
            this.bsPortalSupportRights.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // CopyRightKindDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbCrkindGroup);
            this.Controls.Add(this.ddlCrkindGroup);
            this.Name = "CopyRightKindDictionaryControl";
            this.Size = new System.Drawing.Size(538, 25);
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPortalSupportRights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCopyrightKind;
        private Telerik.WinControls.UI.RadDropDownList ddlCrkindGroup;
        private System.Windows.Forms.BindingSource bsCrkindGroup;
        private Telerik.WinControls.UI.RadLabel lbCrkindGroup;
        private System.Windows.Forms.BindingSource bsPortalSupportRights;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
    }
}
