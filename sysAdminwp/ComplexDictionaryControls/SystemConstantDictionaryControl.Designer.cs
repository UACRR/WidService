namespace sysAdminwp.ComplexDictionaryControls
{
    partial class SystemConstantDictionaryControl
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
            this.bsSysCon = new System.Windows.Forms.BindingSource(this.components);
            this.bsSystemConstant = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.bsSysCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSystemConstant)).BeginInit();
            this.SuspendLayout();
            // 
            // bsSysCon
            // 
            this.bsSysCon.DataSource = typeof(ipsFormsDesign.Model.SystemConstant);
            // 
            // bsSystemConstant
            // 
            this.bsSystemConstant.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // SystemConstantDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SystemConstantDictionaryControl";
            this.Size = new System.Drawing.Size(440, 31);
            ((System.ComponentModel.ISupportInitialize)(this.bsSysCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSystemConstant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsSystemConstant;
        private System.Windows.Forms.BindingSource bsSysCon;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
