namespace sysAdminwp.ComplexDictionaryControls
{
    partial class CopyRightKindDictionaryControl
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
            this.ddlKindShototam = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCrkindGroup = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKindShototam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsCopyrightKind
            // 
            this.bsCopyrightKind.DataSource = typeof(ipsFormsDesign.Model.CopyrightKind);
            // 
            // ddlKindShototam
            // 
            this.ddlKindShototam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlKindShototam.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCopyrightKind, "CrGroupCode", true));
            this.ddlKindShototam.DataSource = this.bsCrkindGroup;
            this.ddlKindShototam.DisplayMember = "Name";
            this.ddlKindShototam.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlKindShototam.Location = new System.Drawing.Point(126, 3);
            this.ddlKindShototam.Name = "ddlKindShototam";
            this.ddlKindShototam.Size = new System.Drawing.Size(273, 20);
            this.ddlKindShototam.TabIndex = 0;
            this.ddlKindShototam.ThemeName = "Office2013Light";
            this.ddlKindShototam.ValueMember = "CodeI";
            // 
            // bsCrkindGroup
            // 
            this.bsCrkindGroup.DataSource = typeof(ipsFormsDesign.Model.CrkindGroup);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(117, 18);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "Спосіб використання";
            // 
            // CopyRightKindDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlKindShototam);
            this.Name = "CopyRightKindDictionaryControl";
            this.Size = new System.Drawing.Size(402, 146);
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKindShototam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCopyrightKind;
        private Telerik.WinControls.UI.RadDropDownList ddlKindShototam;
        private System.Windows.Forms.BindingSource bsCrkindGroup;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
