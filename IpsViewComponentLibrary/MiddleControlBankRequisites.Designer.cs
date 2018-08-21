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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.ctrlBankAccount = new IpsViewComponentLibrary.IpsBankAccountControl();
            this.anketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "Name", true));
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(35, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 22);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Назва «Клієнта»";
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBankAccount.DataMember = "";
            this.ctrlBankAccount.DataSource = typeof(ipsFormsDesign.Interfaces.IBankAccount);
            this.ctrlBankAccount.Location = new System.Drawing.Point(3, 32);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(402, 125);
            this.ctrlBankAccount.TabIndex = 10;
            // 
            // anketaCompanyBindingSource
            // 
            this.anketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // MiddleControlBankRequisites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlBankAccount);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(1300, 160);
            this.MinimumSize = new System.Drawing.Size(300, 160);
            this.Name = "MiddleControlBankRequisites";
            this.Size = new System.Drawing.Size(408, 160);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private IpsBankAccountControl ctrlBankAccount;
        private System.Windows.Forms.BindingSource anketaCompanyBindingSource;
    }
}
