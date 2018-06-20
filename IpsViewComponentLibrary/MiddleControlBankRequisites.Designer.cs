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
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.ctrlBankAccount = new IpsViewComponentLibrary.IpsBankAccountControl();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtAccountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtMfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtMfoName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtMfoOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtTransitNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
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
            // 
            // 
            this.ctrlBankAccount.TxtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBankAccount.TxtAccountNumber.Location = new System.Drawing.Point(118, 103);
            this.ctrlBankAccount.TxtAccountNumber.Name = "txtAccountNumber";
            // 
            // 
            // 
            this.ctrlBankAccount.TxtAccountNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 103, 286, 0);
            this.ctrlBankAccount.TxtAccountNumber.RootElement.StretchVertically = true;
            this.ctrlBankAccount.TxtAccountNumber.Size = new System.Drawing.Size(279, 20);
            this.ctrlBankAccount.TxtAccountNumber.TabIndex = 4;
            // 
            // 
            // 
            this.ctrlBankAccount.TxtMfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBankAccount.TxtMfo.Location = new System.Drawing.Point(118, 28);
            this.ctrlBankAccount.TxtMfo.MaxLength = 6;
            this.ctrlBankAccount.TxtMfo.Name = "txtMfo";
            // 
            // 
            // 
            this.ctrlBankAccount.TxtMfo.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 28, 286, 0);
            this.ctrlBankAccount.TxtMfo.RootElement.StretchVertically = true;
            this.ctrlBankAccount.TxtMfo.Size = new System.Drawing.Size(279, 20);
            this.ctrlBankAccount.TxtMfo.TabIndex = 1;
            // 
            // 
            // 
            this.ctrlBankAccount.TxtMfoName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBankAccount.TxtMfoName.Location = new System.Drawing.Point(118, 3);
            this.ctrlBankAccount.TxtMfoName.Name = "txtMfoName";
            // 
            // 
            // 
            this.ctrlBankAccount.TxtMfoName.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 3, 286, 0);
            this.ctrlBankAccount.TxtMfoName.RootElement.StretchVertically = true;
            this.ctrlBankAccount.TxtMfoName.Size = new System.Drawing.Size(279, 20);
            this.ctrlBankAccount.TxtMfoName.TabIndex = 0;
            // 
            // 
            // 
            this.ctrlBankAccount.TxtMfoOkpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBankAccount.TxtMfoOkpo.Location = new System.Drawing.Point(118, 53);
            this.ctrlBankAccount.TxtMfoOkpo.MaxLength = 10;
            this.ctrlBankAccount.TxtMfoOkpo.Name = "txtMfoOkpo";
            // 
            // 
            // 
            this.ctrlBankAccount.TxtMfoOkpo.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 53, 286, 0);
            this.ctrlBankAccount.TxtMfoOkpo.RootElement.StretchVertically = true;
            this.ctrlBankAccount.TxtMfoOkpo.Size = new System.Drawing.Size(279, 20);
            this.ctrlBankAccount.TxtMfoOkpo.TabIndex = 2;
            // 
            // 
            // 
            this.ctrlBankAccount.TxtTransitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBankAccount.TxtTransitNumber.Location = new System.Drawing.Point(118, 78);
            this.ctrlBankAccount.TxtTransitNumber.Name = "txtTransitNumber";
            // 
            // 
            // 
            this.ctrlBankAccount.TxtTransitNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(118, 78, 286, 0);
            this.ctrlBankAccount.TxtTransitNumber.RootElement.StretchVertically = true;
            this.ctrlBankAccount.TxtTransitNumber.Size = new System.Drawing.Size(279, 20);
            this.ctrlBankAccount.TxtTransitNumber.TabIndex = 3;
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
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtAccountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtMfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtMfoName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtMfoOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBankAccount.TxtTransitNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private IpsBankAccountControl ctrlBankAccount;
    }
}
