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
            this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
            this.bsCrkindGroup = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsCopyrightKind
            // 
            this.bsCopyrightKind.DataSource = typeof(ipsFormsDesign.Model.CopyrightKind);
            // 
            // radDropDownList1
            // 
            this.radDropDownList1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCopyrightKind, "CrGroupCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0"));
            this.radDropDownList1.DataSource = this.bsCrkindGroup;
            this.radDropDownList1.DisplayMember = "Name";
            this.radDropDownList1.Location = new System.Drawing.Point(172, 23);
            this.radDropDownList1.Name = "radDropDownList1";
            this.radDropDownList1.Size = new System.Drawing.Size(266, 20);
            this.radDropDownList1.TabIndex = 0;
            this.radDropDownList1.ValueMember = "CodeI";
            // 
            // bsCrkindGroup
            // 
            this.bsCrkindGroup.DataSource = typeof(ipsFormsDesign.Model.CrkindGroup);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(27, 23);
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
            this.Controls.Add(this.radDropDownList1);
            this.Name = "CopyRightKindDictionaryControl";
            this.Size = new System.Drawing.Size(585, 273);
            ((System.ComponentModel.ISupportInitialize)(this.bsCopyrightKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCopyrightKind;
        private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
        private System.Windows.Forms.BindingSource bsCrkindGroup;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
