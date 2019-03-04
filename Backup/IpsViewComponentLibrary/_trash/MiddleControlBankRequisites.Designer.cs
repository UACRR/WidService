namespace IpsViewComponentLibrary
{
    partial class MiddleControlBankRequisites
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
            this.ctrlBankAccount = new IpsViewComponentLibrary.IpsBankAccountControl();
            this.SuspendLayout();
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlBankAccount.Location = new System.Drawing.Point(0, 0);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(445, 134);
            this.ctrlBankAccount.TabIndex = 10;
            // 
            // MiddleControlBankRequisites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlBankAccount);
            this.MaximumSize = new System.Drawing.Size(1300, 150);
            this.MinimumSize = new System.Drawing.Size(445, 134);
            this.Name = "MiddleControlBankRequisites";
            this.Size = new System.Drawing.Size(445, 134);
            this.ResumeLayout(false);

        }

        #endregion
        private IpsBankAccountControl ctrlBankAccount;
    }
}
