namespace IpsViewComponentLibrary
{
    partial class MiddleControlAgreementAnketaType
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
            this.contractConsumerMainControl1 = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.contractConsumerDetailControl1 = new IpsViewComponentLibrary.ContractConsumerDetailControl();
            this.licenseTypeDropListLicType = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseTypeDropListLicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
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
            // contractConsumerMainControl1
            // 
            this.contractConsumerMainControl1.AgrDateDataMember = null;
            this.contractConsumerMainControl1.BeginDateDataMember = null;
            this.contractConsumerMainControl1.ContrNumber = null;
            this.contractConsumerMainControl1.DataSource = null;
            this.contractConsumerMainControl1.DateDataSource = null;
            this.contractConsumerMainControl1.EndDateDataMember = null;
            this.contractConsumerMainControl1.Location = new System.Drawing.Point(3, 56);
            this.contractConsumerMainControl1.MaximumSize = new System.Drawing.Size(477, 49);
            this.contractConsumerMainControl1.Name = "contractConsumerMainControl1";
            this.contractConsumerMainControl1.Size = new System.Drawing.Size(477, 49);
            this.contractConsumerMainControl1.TabIndex = 10;
            // 
            // contractConsumerDetailControl1
            // 
            this.contractConsumerDetailControl1.AutoprolongationPercent = null;
            this.contractConsumerDetailControl1.DataSourceBinding = null;
            this.contractConsumerDetailControl1.IsAutoprolongation = false;
            this.contractConsumerDetailControl1.Location = new System.Drawing.Point(3, 111);
            this.contractConsumerDetailControl1.MaximumSize = new System.Drawing.Size(480, 105);
            this.contractConsumerDetailControl1.MinimumSize = new System.Drawing.Size(480, 105);
            this.contractConsumerDetailControl1.MinPayment = null;
            this.contractConsumerDetailControl1.Name = "contractConsumerDetailControl1";
            this.contractConsumerDetailControl1.PercentPayment = null;
            this.contractConsumerDetailControl1.PeriodPaymentDataSource = null;
            this.contractConsumerDetailControl1.PeriodPaymentDisplayMember = "";
            this.contractConsumerDetailControl1.PeriodPaymentValueMember = "";
            this.contractConsumerDetailControl1.Size = new System.Drawing.Size(480, 105);
            this.contractConsumerDetailControl1.TabIndex = 11;
            // 
            // licenseTypeDropListLicType
            // 
            this.licenseTypeDropListLicType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.licenseTypeDropListLicType.Location = new System.Drawing.Point(76, 30);
            this.licenseTypeDropListLicType.Name = "licenseTypeDropListLicType";
            this.licenseTypeDropListLicType.Size = new System.Drawing.Size(340, 20);
            this.licenseTypeDropListLicType.TabIndex = 12;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.licenseTypeDropListLicType.GetChildAt(0).GetChildAt(2))).TextWrap = true;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 30);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(67, 18);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "Тип ліцензії";
            // 
            // MiddleControlAgreementAnketaType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.licenseTypeDropListLicType);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.contractConsumerDetailControl1);
            this.Controls.Add(this.contractConsumerMainControl1);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(490, 218);
            this.MinimumSize = new System.Drawing.Size(490, 218);
            this.Name = "MiddleControlAgreementAnketaType";
            this.Size = new System.Drawing.Size(490, 218);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseTypeDropListLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private ContractConsumerMainControl contractConsumerMainControl1;
        private ContractConsumerDetailControl contractConsumerDetailControl1;
        private Telerik.WinControls.UI.RadDropDownList licenseTypeDropListLicType;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
