namespace IpsViewComponentLibrary.CatalogControls
{
    partial class ctrlComment
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
            this.txtComm = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComm
            // 
            this.txtComm.AutoSize = false;
            this.txtComm.Location = new System.Drawing.Point(3, 3);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(81, 26);
            this.txtComm.TabIndex = 0;
            this.txtComm.Text = "Коментар";
            this.txtComm.ThemeName = "Office2013Light";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.Location = new System.Drawing.Point(0, 25);
            this.radTextBox1.MaxLength = 1024;
            this.radTextBox1.Multiline = true;
            this.radTextBox1.Name = "radTextBox1";
            // 
            // 
            // 
            this.radTextBox1.RootElement.StretchVertically = true;
            this.radTextBox1.Size = new System.Drawing.Size(622, 306);
            this.radTextBox1.TabIndex = 1;
            this.radTextBox1.ThemeName = "Office2013Light";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(399, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(515, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            // 
            // ctrlComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.txtComm);
            this.Name = "ctrlComment";
            this.Size = new System.Drawing.Size(625, 361);
            ((System.ComponentModel.ISupportInitialize)(this.txtComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel txtComm;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}
