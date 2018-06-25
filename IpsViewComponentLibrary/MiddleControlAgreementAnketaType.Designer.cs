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
            this.ctrlAgreementMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.ctrlAgreementSecond = new IpsViewComponentLibrary.ContractConsumerDetailControl();
            this.ddlLicType = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).BeginInit();
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
            // ctrlAgreementMain
            // 
            this.ctrlAgreementMain.Location = new System.Drawing.Point(3, 56);
            this.ctrlAgreementMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.Name = "ctrlAgreementMain";
            this.ctrlAgreementMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.TabIndex = 10;
            // 
            // ctrlAgreementSecond
            // 
            this.ctrlAgreementSecond.AutoprolongationPercent = null;
            this.ctrlAgreementSecond.DataSourceBinding = null;
            this.ctrlAgreementSecond.IsAutoprolongation = false;
            this.ctrlAgreementSecond.Location = new System.Drawing.Point(3, 111);
            this.ctrlAgreementSecond.MaximumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.MinimumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.MinPayment = null;
            this.ctrlAgreementSecond.Name = "ctrlAgreementSecond";
            this.ctrlAgreementSecond.PercentPayment = null;
            this.ctrlAgreementSecond.PeriodPaymentDataSource = null;
            this.ctrlAgreementSecond.PeriodPaymentDisplayMember = "";
            this.ctrlAgreementSecond.PeriodPaymentValueMember = "";
            this.ctrlAgreementSecond.Size = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.TabIndex = 11;
            // 
            // ddlLicType
            // 
            this.ddlLicType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlLicType.Location = new System.Drawing.Point(76, 30);
            this.ddlLicType.Name = "ddlLicType";
            this.ddlLicType.Size = new System.Drawing.Size(340, 20);
            this.ddlLicType.TabIndex = 12;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlLicType.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.ddlLicType.GetChildAt(0).GetChildAt(2))).TextWrap = true;
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
            this.Controls.Add(this.ddlLicType);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ctrlAgreementSecond);
            this.Controls.Add(this.ctrlAgreementMain);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(490, 218);
            this.MinimumSize = new System.Drawing.Size(490, 218);
            this.Name = "MiddleControlAgreementAnketaType";
            this.Size = new System.Drawing.Size(490, 218);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private ContractConsumerMainControl ctrlAgreementMain;
        private ContractConsumerDetailControl ctrlAgreementSecond;
        private Telerik.WinControls.UI.RadDropDownList ddlLicType;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
