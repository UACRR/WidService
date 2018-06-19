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
            this.ipsBankAccountControl1 = new IpsViewComponentLibrary.IpsBankAccountControl();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtAccountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtMfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtMfoName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtMfoOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtTransitNumber)).BeginInit();
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
            // ipsBankAccountControl1
            // 
            this.ipsBankAccountControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl1.DataMember = "";
            this.ipsBankAccountControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IBankAccount);
            this.ipsBankAccountControl1.Location = new System.Drawing.Point(3, 32);
            this.ipsBankAccountControl1.Name = "ipsBankAccountControl1";
            this.ipsBankAccountControl1.Size = new System.Drawing.Size(402, 125);
            this.ipsBankAccountControl1.TabIndex = 10;
            // 
            // 
            // 
            this.ipsBankAccountControl1.TxtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl1.TxtAccountNumber.Location = new System.Drawing.Point(118, 103);
            this.ipsBankAccountControl1.TxtAccountNumber.Name = "txtAccountNumber";
            this.ipsBankAccountControl1.TxtAccountNumber.Size = new System.Drawing.Size(279, 20);
            this.ipsBankAccountControl1.TxtAccountNumber.TabIndex = 4;
            // 
            // 
            // 
            this.ipsBankAccountControl1.TxtMfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl1.TxtMfo.Location = new System.Drawing.Point(118, 28);
            this.ipsBankAccountControl1.TxtMfo.MaxLength = 6;
            this.ipsBankAccountControl1.TxtMfo.Name = "txtMfo";
            this.ipsBankAccountControl1.TxtMfo.Size = new System.Drawing.Size(279, 20);
            this.ipsBankAccountControl1.TxtMfo.TabIndex = 1;
            // 
            // 
            // 
            this.ipsBankAccountControl1.TxtMfoName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl1.TxtMfoName.Location = new System.Drawing.Point(118, 3);
            this.ipsBankAccountControl1.TxtMfoName.Name = "txtMfoName";
            this.ipsBankAccountControl1.TxtMfoName.Size = new System.Drawing.Size(279, 20);
            this.ipsBankAccountControl1.TxtMfoName.TabIndex = 0;
            // 
            // 
            // 
            this.ipsBankAccountControl1.TxtMfoOkpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl1.TxtMfoOkpo.Location = new System.Drawing.Point(118, 53);
            this.ipsBankAccountControl1.TxtMfoOkpo.MaxLength = 10;
            this.ipsBankAccountControl1.TxtMfoOkpo.Name = "txtMfoOkpo";
            this.ipsBankAccountControl1.TxtMfoOkpo.Size = new System.Drawing.Size(279, 20);
            this.ipsBankAccountControl1.TxtMfoOkpo.TabIndex = 2;
            // 
            // 
            // 
            this.ipsBankAccountControl1.TxtTransitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsBankAccountControl1.TxtTransitNumber.Location = new System.Drawing.Point(118, 78);
            this.ipsBankAccountControl1.TxtTransitNumber.Name = "txtTransitNumber";
            this.ipsBankAccountControl1.TxtTransitNumber.Size = new System.Drawing.Size(279, 20);
            this.ipsBankAccountControl1.TxtTransitNumber.TabIndex = 3;
            // 
            // MiddleControlBankRequisites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ipsBankAccountControl1);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(1300, 160);
            this.MinimumSize = new System.Drawing.Size(300, 160);
            this.Name = "MiddleControlBankRequisites";
            this.Size = new System.Drawing.Size(408, 160);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtAccountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtMfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtMfoName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtMfoOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsBankAccountControl1.TxtTransitNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private IpsBankAccountControl ipsBankAccountControl1;
    }
}
