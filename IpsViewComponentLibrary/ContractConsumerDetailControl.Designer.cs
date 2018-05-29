namespace IpsViewComponentLibrary
{
    partial class ContractConsumerDetailControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxAuthorPaymentPercent = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtBoxMinAuthorPayment = new Telerik.WinControls.UI.RadTextBox();
            this.rCheckBoxAutoprolongation = new Telerik.WinControls.UI.RadCheckBox();
            this.rtxtboxPercentAutoProl = new Telerik.WinControls.UI.RadTextBox();
            this.rddListPeriodPayment = new Telerik.WinControls.UI.RadDropDownList();
            this.rddListTypeAutoProl = new Telerik.WinControls.UI.RadDropDownList();
            this.iLicenseAgreementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxAuthorPaymentPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMinAuthorPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBoxAutoprolongation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtboxPercentAutoProl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListPeriodPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListTypeAutoProl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLicenseAgreementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(124, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Авторська винагорода";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(234, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(99, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "але не менше ніж";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(453, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(24, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "грн";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(4, 78);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(129, 18);
            this.radLabel4.TabIndex = 1;
            this.radLabel4.Text = "Періодичність платежів";
            // 
            // rtxtBoxAuthorPaymentPercent
            // 
            this.rtxtBoxAuthorPaymentPercent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iLicenseAgreementBindingSource, "RateAmount", true));
            this.rtxtBoxAuthorPaymentPercent.Location = new System.Drawing.Point(139, 3);
            this.rtxtBoxAuthorPaymentPercent.Name = "rtxtBoxAuthorPaymentPercent";
            this.rtxtBoxAuthorPaymentPercent.Size = new System.Drawing.Size(78, 20);
            this.rtxtBoxAuthorPaymentPercent.TabIndex = 3;
            // 
            // rtxtBoxMinAuthorPayment
            // 
            this.rtxtBoxMinAuthorPayment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iLicenseAgreementBindingSource, "MinAmount", true));
            this.rtxtBoxMinAuthorPayment.Location = new System.Drawing.Point(339, 3);
            this.rtxtBoxMinAuthorPayment.Name = "rtxtBoxMinAuthorPayment";
            this.rtxtBoxMinAuthorPayment.Size = new System.Drawing.Size(108, 20);
            this.rtxtBoxMinAuthorPayment.TabIndex = 4;
            // 
            // rCheckBoxAutoprolongation
            // 
            this.rCheckBoxAutoprolongation.Location = new System.Drawing.Point(4, 28);
            this.rCheckBoxAutoprolongation.Name = "rCheckBoxAutoprolongation";
            this.rCheckBoxAutoprolongation.Size = new System.Drawing.Size(109, 18);
            this.rCheckBoxAutoprolongation.TabIndex = 5;
            this.rCheckBoxAutoprolongation.Text = "Автопролонгація";
            this.rCheckBoxAutoprolongation.CheckStateChanged += new System.EventHandler(this.rCheckBoxAutoprolongation_CheckStateChanged);
            // 
            // rtxtboxPercentAutoProl
            // 
            this.rtxtboxPercentAutoProl.Location = new System.Drawing.Point(411, 52);
            this.rtxtboxPercentAutoProl.Name = "rtxtboxPercentAutoProl";
            this.rtxtboxPercentAutoProl.Size = new System.Drawing.Size(59, 20);
            this.rtxtboxPercentAutoProl.TabIndex = 6;
            // 
            // rddListPeriodPayment
            // 
            this.rddListPeriodPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rddListPeriodPayment.Location = new System.Drawing.Point(139, 78);
            this.rddListPeriodPayment.Name = "rddListPeriodPayment";
            this.rddListPeriodPayment.Size = new System.Drawing.Size(194, 20);
            this.rddListPeriodPayment.TabIndex = 7;
            // 
            // rddListTypeAutoProl
            // 
            this.rddListTypeAutoProl.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rddListTypeAutoProl.Location = new System.Drawing.Point(4, 52);
            this.rddListTypeAutoProl.Name = "rddListTypeAutoProl";
            this.rddListTypeAutoProl.Size = new System.Drawing.Size(401, 20);
            this.rddListTypeAutoProl.TabIndex = 8;
            // 
            // iLicenseAgreementBindingSource
            // 
            this.iLicenseAgreementBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.ILicenseAgreement);
            // 
            // ContractConsumerDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rddListTypeAutoProl);
            this.Controls.Add(this.rddListPeriodPayment);
            this.Controls.Add(this.rtxtboxPercentAutoProl);
            this.Controls.Add(this.rCheckBoxAutoprolongation);
            this.Controls.Add(this.rtxtBoxMinAuthorPayment);
            this.Controls.Add(this.rtxtBoxAuthorPaymentPercent);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(480, 105);
            this.MinimumSize = new System.Drawing.Size(480, 105);
            this.Name = "ContractConsumerDetailControl";
            this.Size = new System.Drawing.Size(480, 105);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxAuthorPaymentPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMinAuthorPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBoxAutoprolongation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtboxPercentAutoProl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListPeriodPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListTypeAutoProl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iLicenseAgreementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxAuthorPaymentPercent;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMinAuthorPayment;
        private Telerik.WinControls.UI.RadCheckBox rCheckBoxAutoprolongation;
        private Telerik.WinControls.UI.RadTextBox rtxtboxPercentAutoProl;
        private Telerik.WinControls.UI.RadDropDownList rddListPeriodPayment;
        private Telerik.WinControls.UI.RadDropDownList rddListTypeAutoProl;
        private System.Windows.Forms.BindingSource iLicenseAgreementBindingSource;
    }
}
