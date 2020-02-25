namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    partial class AgreementBigRight
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ddlPeriodPayment = new Telerik.WinControls.UI.RadDropDownList();
            this.bsAgreementAddBr = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictPaidPeriod = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtDayForPay = new Telerik.WinControls.UI.RadTextBox();
            this.lblParam = new Telerik.WinControls.UI.RadLabel();
            this.panel = new Telerik.WinControls.UI.RadPanel();
            this.lblContrDo = new Telerik.WinControls.UI.RadLabel();
            this.rdtPickerDateEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrDoTo = new Telerik.WinControls.UI.RadLabel();
            this.rdtPickerDateBegin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrDoFrom = new Telerik.WinControls.UI.RadLabel();
            this.dtAgrDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrFrom = new Telerik.WinControls.UI.RadLabel();
            this.txtAgreementNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lblContrNumb = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgreementNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlPeriodPayment
            // 
            this.ddlPeriodPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlPeriodPayment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAgreementAddBr, "PeriodCode", true));
            this.ddlPeriodPayment.DataSource = this.bsDictPaidPeriod;
            this.ddlPeriodPayment.DisplayMember = "Name";
            this.ddlPeriodPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlPeriodPayment.Location = new System.Drawing.Point(164, 41);
            this.ddlPeriodPayment.Name = "ddlPeriodPayment";
            this.ddlPeriodPayment.Size = new System.Drawing.Size(194, 21);
            this.ddlPeriodPayment.TabIndex = 2;
            this.ddlPeriodPayment.ThemeName = "Office2013Light";
            this.ddlPeriodPayment.ValueMember = "CodeI";
            // 
            // bsAgreementAddBr
            // 
            this.bsAgreementAddBr.DataSource = typeof(ipsFormsDesign.Model.AgreementAddBr);
            // 
            // bsDictPaidPeriod
            // 
            this.bsDictPaidPeriod.DataSource = typeof(ipsFormsDesign.Model.Period);
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel2.Location = new System.Drawing.Point(3, 14);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(155, 19);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Останній день розрахунку";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel4.Location = new System.Drawing.Point(3, 41);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(139, 19);
            this.radLabel4.TabIndex = 0;
            this.radLabel4.Text = "Періодичність звітності";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // txtDayForPay
            // 
            this.txtDayForPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDayForPay.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBr, "DayForPay", true));
            this.txtDayForPay.Location = new System.Drawing.Point(164, 14);
            this.txtDayForPay.Name = "txtDayForPay";
            this.txtDayForPay.Size = new System.Drawing.Size(48, 21);
            this.txtDayForPay.TabIndex = 1;
            this.txtDayForPay.ThemeName = "Office2013Light";
            // 
            // lblParam
            // 
            this.lblParam.Location = new System.Drawing.Point(13, 60);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(116, 18);
            this.lblParam.TabIndex = 0;
            this.lblParam.Text = "Параметри договору";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.radLabel2);
            this.panel.Controls.Add(this.radLabel4);
            this.panel.Controls.Add(this.txtDayForPay);
            this.panel.Controls.Add(this.ddlPeriodPayment);
            this.panel.Location = new System.Drawing.Point(3, 70);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(474, 69);
            this.panel.TabIndex = 5;
            this.panel.ThemeName = "Office2013Light";
            // 
            // lblContrDo
            // 
            this.lblContrDo.Location = new System.Drawing.Point(6, 30);
            this.lblContrDo.Name = "lblContrDo";
            this.lblContrDo.Size = new System.Drawing.Size(81, 19);
            this.lblContrDo.TabIndex = 0;
            this.lblContrDo.Text = "Дія договору";
            this.lblContrDo.ThemeName = "Office2013Light";
            // 
            // rdtPickerDateEnd
            // 
            this.rdtPickerDateEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddBr, "DateEnd", true));
            this.rdtPickerDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerDateEnd.Location = new System.Drawing.Point(359, 27);
            this.rdtPickerDateEnd.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateEnd.Name = "rdtPickerDateEnd";
            this.rdtPickerDateEnd.NullText = "Оберіть дату";
            this.rdtPickerDateEnd.Size = new System.Drawing.Size(118, 21);
            this.rdtPickerDateEnd.TabIndex = 4;
            this.rdtPickerDateEnd.TabStop = false;
            this.rdtPickerDateEnd.ThemeName = "Office2013Light";
            this.rdtPickerDateEnd.Value = new System.DateTime(((long)(0)));
            // 
            // lblContrDoTo
            // 
            this.lblContrDoTo.Location = new System.Drawing.Point(332, 29);
            this.lblContrDoTo.Name = "lblContrDoTo";
            this.lblContrDoTo.Size = new System.Drawing.Size(21, 19);
            this.lblContrDoTo.TabIndex = 0;
            this.lblContrDoTo.Text = "до";
            this.lblContrDoTo.ThemeName = "Office2013Light";
            // 
            // rdtPickerDateBegin
            // 
            this.rdtPickerDateBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddBr, "DateBegin", true));
            this.rdtPickerDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerDateBegin.Location = new System.Drawing.Point(167, 28);
            this.rdtPickerDateBegin.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateBegin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateBegin.Name = "rdtPickerDateBegin";
            this.rdtPickerDateBegin.NullText = "Оберіть дату";
            this.rdtPickerDateBegin.Size = new System.Drawing.Size(112, 21);
            this.rdtPickerDateBegin.TabIndex = 3;
            this.rdtPickerDateBegin.TabStop = false;
            this.rdtPickerDateBegin.ThemeName = "Office2013Light";
            this.rdtPickerDateBegin.Value = new System.DateTime(((long)(0)));
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.rdtPickerDateBegin.GetChildAt(0))).Text = "";
            // 
            // lblContrDoFrom
            // 
            this.lblContrDoFrom.Location = new System.Drawing.Point(136, 30);
            this.lblContrDoFrom.Name = "lblContrDoFrom";
            this.lblContrDoFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrDoFrom.TabIndex = 0;
            this.lblContrDoFrom.Text = "від";
            this.lblContrDoFrom.ThemeName = "Office2013Light";
            // 
            // dtAgrDate
            // 
            this.dtAgrDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddBr, "AgrDate", true));
            this.dtAgrDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAgrDate.Location = new System.Drawing.Point(359, 3);
            this.dtAgrDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtAgrDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtAgrDate.Name = "dtAgrDate";
            this.dtAgrDate.NullText = "Оберіть дату";
            this.dtAgrDate.Size = new System.Drawing.Size(118, 21);
            this.dtAgrDate.TabIndex = 2;
            this.dtAgrDate.TabStop = false;
            this.dtAgrDate.ThemeName = "Office2013Light";
            this.dtAgrDate.Value = new System.DateTime(((long)(0)));
            // 
            // lblContrFrom
            // 
            this.lblContrFrom.Location = new System.Drawing.Point(330, 5);
            this.lblContrFrom.Name = "lblContrFrom";
            this.lblContrFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrFrom.TabIndex = 0;
            this.lblContrFrom.Text = "від";
            this.lblContrFrom.ThemeName = "Office2013Light";
            // 
            // txtAgreementNumber
            // 
            this.txtAgreementNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBr, "AgrNumber", true));
            this.txtAgreementNumber.Location = new System.Drawing.Point(167, 4);
            this.txtAgreementNumber.Name = "txtAgreementNumber";
            this.txtAgreementNumber.NullText = "Номер договору";
            this.txtAgreementNumber.Size = new System.Drawing.Size(157, 21);
            this.txtAgreementNumber.TabIndex = 1;
            this.txtAgreementNumber.ThemeName = "Office2013Light";
            // 
            // lblContrNumb
            // 
            this.lblContrNumb.Location = new System.Drawing.Point(6, 5);
            this.lblContrNumb.Name = "lblContrNumb";
            this.lblContrNumb.Size = new System.Drawing.Size(157, 19);
            this.lblContrNumb.TabIndex = 0;
            this.lblContrNumb.Text = "Договір про співпрацю №";
            this.lblContrNumb.ThemeName = "Office2013Light";
            // 
            // AgreementBigRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContrDo);
            this.Controls.Add(this.rdtPickerDateEnd);
            this.Controls.Add(this.lblContrDoTo);
            this.Controls.Add(this.rdtPickerDateBegin);
            this.Controls.Add(this.lblContrDoFrom);
            this.Controls.Add(this.dtAgrDate);
            this.Controls.Add(this.lblContrFrom);
            this.Controls.Add(this.txtAgreementNumber);
            this.Controls.Add(this.lblContrNumb);
            this.Controls.Add(this.lblParam);
            this.Controls.Add(this.panel);
            this.Name = "AgreementBigRight";
            this.Size = new System.Drawing.Size(481, 145);
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgreementNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadDropDownList ddlPeriodPayment;
        private System.Windows.Forms.BindingSource bsAgreementAddBr;
        private System.Windows.Forms.BindingSource bsDictPaidPeriod;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtDayForPay;
        private Telerik.WinControls.UI.RadLabel lblParam;
        private Telerik.WinControls.UI.RadPanel panel;
        private Telerik.WinControls.UI.RadLabel lblContrDo;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerDateEnd;
        private Telerik.WinControls.UI.RadLabel lblContrDoTo;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerDateBegin;
        private Telerik.WinControls.UI.RadLabel lblContrDoFrom;
        private Telerik.WinControls.UI.RadDateTimePicker dtAgrDate;
        private Telerik.WinControls.UI.RadLabel lblContrFrom;
        private Telerik.WinControls.UI.RadTextBox txtAgreementNumber;
        private Telerik.WinControls.UI.RadLabel lblContrNumb;
    }
}
