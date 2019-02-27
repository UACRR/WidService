namespace DebugFormForControls
{
    partial class ContractControl
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
            this.lblNumber = new Telerik.WinControls.UI.RadLabel();
            this.txtAgrNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lblFromDate = new Telerik.WinControls.UI.RadLabel();
            this.dtAgrDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.agreementMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementMasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(5, 5);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(19, 18);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "№";
            // 
            // txtAgrNumber
            // 
            this.txtAgrNumber.Location = new System.Drawing.Point(32, 3);
            this.txtAgrNumber.Name = "txtAgrNumber";
            this.txtAgrNumber.Size = new System.Drawing.Size(75, 20);
            this.txtAgrNumber.TabIndex = 0;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(113, 5);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(21, 18);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "від";
            // 
            // dtAgrDate
            // 
            this.dtAgrDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAgrDate.Location = new System.Drawing.Point(140, 3);
            this.dtAgrDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtAgrDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtAgrDate.Name = "dtAgrDate";
            this.dtAgrDate.NullDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtAgrDate.NullText = "Оберіть дату";
            this.dtAgrDate.Size = new System.Drawing.Size(127, 20);
            this.dtAgrDate.TabIndex = 1;
            this.dtAgrDate.TabStop = false;
            this.dtAgrDate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // agreementMasterBindingSource
            // 
            this.agreementMasterBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAgreementMaster);
            // 
            // ContractControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtAgrDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.txtAgrNumber);
            this.Controls.Add(this.lblNumber);
            this.MaximumSize = new System.Drawing.Size(274, 27);
            this.Name = "ContractControl";
            this.Size = new System.Drawing.Size(274, 27);
            ((System.ComponentModel.ISupportInitialize)(this.lblNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agreementMasterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblNumber;
        private Telerik.WinControls.UI.RadTextBox txtAgrNumber;
        private Telerik.WinControls.UI.RadLabel lblFromDate;
        private Telerik.WinControls.UI.RadDateTimePicker dtAgrDate;
        private System.Windows.Forms.BindingSource agreementMasterBindingSource;
    }
}
