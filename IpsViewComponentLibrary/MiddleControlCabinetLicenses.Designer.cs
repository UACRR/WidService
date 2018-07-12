namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetLicenses
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
            this.ctrlAgrInfo = new IpsViewComponentLibrary.GeneralAgreementInfo();
            this.SuspendLayout();
            // 
            // ctrlAgrInfo
            // 
            this.ctrlAgrInfo.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            this.ctrlAgrInfo.Location = new System.Drawing.Point(4, 4);
            this.ctrlAgrInfo.Name = "ctrlAgrInfo";
            this.ctrlAgrInfo.Size = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.TabIndex = 0;
            // 
            // MiddleControlCabinetLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlAgrInfo);
            this.Name = "MiddleControlCabinetLicenses";
            this.Size = new System.Drawing.Size(965, 423);
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralAgreementInfo ctrlAgrInfo;
    }
}
