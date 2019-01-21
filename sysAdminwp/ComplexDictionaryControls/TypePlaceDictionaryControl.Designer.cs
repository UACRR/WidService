namespace sysAdminwp.ComplexDictionaryControls
{
    partial class TypePlaceDictionaryControl
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
            this.lbTypePlace = new System.Windows.Forms.Label();
            this.ddlTypePlace = new Telerik.WinControls.UI.RadDropDownList();
            this.bsTypePlace = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlace)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTypePlace
            // 
            this.lbTypePlace.AutoSize = true;
            this.lbTypePlace.Location = new System.Drawing.Point(14, 21);
            this.lbTypePlace.Name = "lbTypePlace";
            this.lbTypePlace.Size = new System.Drawing.Size(58, 13);
            this.lbTypePlace.TabIndex = 0;
            this.lbTypePlace.Text = "TypePlace";
            // 
            // ddlTypePlace
            // 
            this.ddlTypePlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlTypePlace.Location = new System.Drawing.Point(78, 20);
            this.ddlTypePlace.Name = "ddlTypePlace";
            this.ddlTypePlace.Size = new System.Drawing.Size(427, 21);
            this.ddlTypePlace.TabIndex = 1;
            this.ddlTypePlace.ThemeName = "Office2013Light";
            // 
            // bsTypePlace
            // 
            this.bsTypePlace.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // TypePlaceDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlTypePlace);
            this.Controls.Add(this.lbTypePlace);
            this.Name = "TypePlaceDictionaryControl";
            this.Size = new System.Drawing.Size(508, 180);
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTypePlace;
        private Telerik.WinControls.UI.RadDropDownList ddlTypePlace;
        private System.Windows.Forms.BindingSource bsTypePlace;
    }
}
