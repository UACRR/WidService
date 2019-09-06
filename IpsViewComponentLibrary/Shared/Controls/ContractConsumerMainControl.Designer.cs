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
            this.dtAgreementDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.bsLicenseAgrParam = new System.Windows.Forms.BindingSource(this.components);
            this.lblContrFrom = new Telerik.WinControls.UI.RadLabel();
            this.txtAgreementNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lblContrNumb = new Telerik.WinControls.UI.RadLabel();
            this.dtDateBegin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtDateEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrDoFrom = new Telerik.WinControls.UI.RadLabel();
            this.lblContrDoTo = new Telerik.WinControls.UI.RadLabel();
            this.lblContrDo = new Telerik.WinControls.UI.RadLabel();
            this.bsAgreementAddBr = new System.Windows.Forms.BindingSource(this.components);
            this.bsLicenseAgrParamBr = new System.Windows.Forms.BindingSource(this.components);
            this.bsAgreementAddRh = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgreementDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicenseAgrParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgreementNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicenseAgrParamBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddRh)).BeginInit();
            this.SuspendLayout();
            // 
            // dtAgreementDate
            // 
            this.dtAgreementDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtAgreementDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAgreementDate.Location = new System.Drawing.Point(356, 1);
            this.dtAgreementDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtAgreementDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtAgreementDate.Name = "dtAgreementDate";
            this.dtAgreementDate.NullText = "Оберіть дату";
            this.dtAgreementDate.Size = new System.Drawing.Size(118, 21);
            this.dtAgreementDate.TabIndex = 1;
            this.dtAgreementDate.TabStop = false;
            this.dtAgreementDate.ThemeName = "Office2013Light";
            this.dtAgreementDate.Value = new System.DateTime(((long)(0)));
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
            // txtAgreementNumber
            // 
            this.txtAgreementNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgreementNumber.Location = new System.Drawing.Point(169, 2);
            this.txtAgreementNumber.Name = "txtAgreementNumber";
            this.txtAgreementNumber.NullText = "Номер договору";
            this.txtAgreementNumber.Size = new System.Drawing.Size(152, 21);
            this.txtAgreementNumber.TabIndex = 0;
            this.txtAgreementNumber.ThemeName = "Office2013Light";
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
            // dtDateEnd
            // 
            this.dtDateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEnd.Location = new System.Drawing.Point(356, 25);
            this.dtDateEnd.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dtDateEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDateEnd.Name = "dtDateEnd";
            this.dtDateEnd.NullText = "Оберіть дату";
            this.dtDateEnd.Size = new System.Drawing.Size(118, 21);
            this.dtDateEnd.TabIndex = 3;
            this.dtDateEnd.TabStop = false;
            this.dtDateEnd.ThemeName = "Office2013Light";
            this.dtDateEnd.Value = new System.DateTime(((long)(0)));
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
            this.Controls.Add(this.dtDateEnd);
            this.Controls.Add(this.lblContrDoTo);
            this.Controls.Add(this.dtDateBegin);
            this.Controls.Add(this.lblContrDoFrom);
            this.Controls.Add(this.dtAgreementDate);
            this.Controls.Add(this.lblContrFrom);
            this.Controls.Add(this.txtAgreementNumber);
            this.Controls.Add(this.lblContrNumb);
            this.MaximumSize = new System.Drawing.Size(477, 49);
            this.Name = "ContractConsumerMainControl";
            this.Size = new System.Drawing.Size(477, 49);
            ((System.ComponentModel.ISupportInitialize)(this.dtAgreementDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLicenseAgrParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgreementNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).EndInit();
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

        private Telerik.WinControls.UI.RadDateTimePicker dtAgreementDate;
        private Telerik.WinControls.UI.RadLabel lblContrFrom;
        private Telerik.WinControls.UI.RadTextBox txtAgreementNumber;
        private Telerik.WinControls.UI.RadLabel lblContrNumb;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateBegin;
        private Telerik.WinControls.UI.RadLabel lblContrDoFrom;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateEnd;
        private Telerik.WinControls.UI.RadLabel lblContrDoTo;
        private Telerik.WinControls.UI.RadLabel lblContrDo;
        private BindingSource bsLicenseAgrParam;
        private BindingSource bsAgreementAddBr;
        private BindingSource bsLicenseAgrParamBr;
        private BindingSource bsAgreementAddRh;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
