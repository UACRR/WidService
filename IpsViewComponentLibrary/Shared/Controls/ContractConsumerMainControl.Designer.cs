using System.Windows.Forms;

namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class ContractConsumerMainControl
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
            this.rdtPickerAgrDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.bsLicenseAgrParam = new System.Windows.Forms.BindingSource(this.components);
            this.lblContrFrom = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxContrNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lblContrNumb = new Telerik.WinControls.UI.RadLabel();
            this.dtDateBegin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdtPickerDateEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrDoFrom = new Telerik.WinControls.UI.RadLabel();
            this.lblContrDoTo = new Telerik.WinControls.UI.RadLabel();
            this.lblContrDo = new Telerik.WinControls.UI.RadLabel();
            this.bsAgreementAddBr = new System.Windows.Forms.BindingSource(this.components);
            this.bsLicenseAgrParamBr = new System.Windows.Forms.BindingSource(this.components);
            this.bsAgreementAddRh = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerAgrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicenseAgrParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxContrNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicenseAgrParamBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddRh)).BeginInit();
            this.SuspendLayout();
            // 
            // rdtPickerAgrDate
            // 
            this.rdtPickerAgrDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdtPickerAgrDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerAgrDate.Location = new System.Drawing.Point(356, 1);
            this.rdtPickerAgrDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.rdtPickerAgrDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerAgrDate.Name = "rdtPickerAgrDate";
            this.rdtPickerAgrDate.NullText = "Оберіть дату";
            this.rdtPickerAgrDate.Size = new System.Drawing.Size(118, 21);
            this.rdtPickerAgrDate.TabIndex = 1;
            this.rdtPickerAgrDate.TabStop = false;
            this.rdtPickerAgrDate.ThemeName = "Office2013Light";
            this.rdtPickerAgrDate.Value = new System.DateTime(((long)(0)));
            // 
            // bsLicenseAgrParam
            // 
            this.bsLicenseAgrParam.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // lblContrFrom
            // 
            this.lblContrFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrFrom.Location = new System.Drawing.Point(327, 3);
            this.lblContrFrom.Name = "lblContrFrom";
            this.lblContrFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrFrom.TabIndex = 1;
            this.lblContrFrom.Text = "від";
            this.lblContrFrom.ThemeName = "Office2013Light";
            // 
            // rtxtBoxContrNumber
            // 
            this.rtxtBoxContrNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxContrNumber.Location = new System.Drawing.Point(169, 2);
            this.rtxtBoxContrNumber.Name = "rtxtBoxContrNumber";
            this.rtxtBoxContrNumber.NullText = "Номер договору";
            this.rtxtBoxContrNumber.Size = new System.Drawing.Size(152, 21);
            this.rtxtBoxContrNumber.TabIndex = 0;
            this.rtxtBoxContrNumber.ThemeName = "Office2013Light";
            // 
            // lblContrNumb
            // 
            this.lblContrNumb.Location = new System.Drawing.Point(3, 3);
            this.lblContrNumb.Name = "lblContrNumb";
            this.lblContrNumb.Size = new System.Drawing.Size(160, 19);
            this.lblContrNumb.TabIndex = 0;
            this.lblContrNumb.Text = "ЛІЦЕНЗІЙНИЙ ДОГОВІР №";
            this.lblContrNumb.ThemeName = "Office2013Light";
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateBegin.Location = new System.Drawing.Point(169, 26);
            this.dtDateBegin.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dtDateBegin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDateBegin.Name = "dtDateBegin";
            this.dtDateBegin.NullText = "Оберіть дату";
            this.dtDateBegin.Size = new System.Drawing.Size(107, 21);
            this.dtDateBegin.TabIndex = 2;
            this.dtDateBegin.TabStop = false;
            this.dtDateBegin.ThemeName = "Office2013Light";
            this.dtDateBegin.Value = new System.DateTime(((long)(0)));
            this.dtDateBegin.Leave += new System.EventHandler(this.dtDateBegin_Leave);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtDateBegin.GetChildAt(0))).Text = "";
            // 
            // rdtPickerDateEnd
            // 
            this.rdtPickerDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdtPickerDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerDateEnd.Location = new System.Drawing.Point(356, 25);
            this.rdtPickerDateEnd.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateEnd.Name = "rdtPickerDateEnd";
            this.rdtPickerDateEnd.NullText = "Оберіть дату";
            this.rdtPickerDateEnd.Size = new System.Drawing.Size(118, 21);
            this.rdtPickerDateEnd.TabIndex = 3;
            this.rdtPickerDateEnd.TabStop = false;
            this.rdtPickerDateEnd.ThemeName = "Office2013Light";
            this.rdtPickerDateEnd.Value = new System.DateTime(((long)(0)));
            // 
            // lblContrDoFrom
            // 
            this.lblContrDoFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrDoFrom.Location = new System.Drawing.Point(140, 28);
            this.lblContrDoFrom.Name = "lblContrDoFrom";
            this.lblContrDoFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrDoFrom.TabIndex = 2;
            this.lblContrDoFrom.Text = "від";
            this.lblContrDoFrom.ThemeName = "Office2013Light";
            // 
            // lblContrDoTo
            // 
            this.lblContrDoTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrDoTo.Location = new System.Drawing.Point(329, 27);
            this.lblContrDoTo.Name = "lblContrDoTo";
            this.lblContrDoTo.Size = new System.Drawing.Size(21, 19);
            this.lblContrDoTo.TabIndex = 3;
            this.lblContrDoTo.Text = "до";
            this.lblContrDoTo.ThemeName = "Office2013Light";
            // 
            // lblContrDo
            // 
            this.lblContrDo.Location = new System.Drawing.Point(3, 28);
            this.lblContrDo.Name = "lblContrDo";
            this.lblContrDo.Size = new System.Drawing.Size(92, 19);
            this.lblContrDo.TabIndex = 2;
            this.lblContrDo.Text = "ДІЯ ДОГОВОРУ";
            this.lblContrDo.ThemeName = "Office2013Light";
            // 
            // bsAgreementAddBr
            // 
            this.bsAgreementAddBr.DataSource = typeof(ipsFormsDesign.Model.AgreementAddBr);
            // 
            // bsLicenseAgrParamBr
            // 
            this.bsLicenseAgrParamBr.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // bsAgreementAddRh
            // 
            this.bsAgreementAddRh.DataSource = typeof(ipsFormsDesign.Model.AgreementAddRh);
            // 
            // ContractConsumerMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContrDo);
            this.Controls.Add(this.rdtPickerDateEnd);
            this.Controls.Add(this.lblContrDoTo);
            this.Controls.Add(this.dtDateBegin);
            this.Controls.Add(this.lblContrDoFrom);
            this.Controls.Add(this.rdtPickerAgrDate);
            this.Controls.Add(this.lblContrFrom);
            this.Controls.Add(this.rtxtBoxContrNumber);
            this.Controls.Add(this.lblContrNumb);
            this.MaximumSize = new System.Drawing.Size(477, 49);
            this.Name = "ContractConsumerMainControl";
            this.Size = new System.Drawing.Size(477, 49);
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerAgrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicenseAgrParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxContrNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicenseAgrParamBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddRh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerAgrDate;
        private Telerik.WinControls.UI.RadLabel lblContrFrom;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxContrNumber;
        private Telerik.WinControls.UI.RadLabel lblContrNumb;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateBegin;
        private Telerik.WinControls.UI.RadLabel lblContrDoFrom;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerDateEnd;
        private Telerik.WinControls.UI.RadLabel lblContrDoTo;
        private Telerik.WinControls.UI.RadLabel lblContrDo;
        private BindingSource bsLicenseAgrParam;
        private BindingSource bsAgreementAddBr;
        private BindingSource bsLicenseAgrParamBr;
        private BindingSource bsAgreementAddRh;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
