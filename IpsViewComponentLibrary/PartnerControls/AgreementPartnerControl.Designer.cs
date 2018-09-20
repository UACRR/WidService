using System.Windows.Forms;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class AgreementPartnerControl
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtDayForPay = new Telerik.WinControls.UI.RadTextBox();
            this.bsAgreementAddPartner = new System.Windows.Forms.BindingSource(this.components);
            this.ddlPeriodPayment = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictPaidPeriod = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblContrDo = new Telerik.WinControls.UI.RadLabel();
            this.dtDateEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrDoTo = new Telerik.WinControls.UI.RadLabel();
            this.dtDateBegin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtAgrDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrFrom = new Telerik.WinControls.UI.RadLabel();
            this.txtAgrNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lblContrNumb = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(6, 19);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(155, 19);
            this.radLabel2.TabIndex = 45;
            this.radLabel2.Text = "Останній день розрахунку";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(6, 46);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(155, 19);
            this.radLabel4.TabIndex = 44;
            this.radLabel4.Text = "Періодичність розрахунку";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // txtDayForPay
            // 
            this.txtDayForPay.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "DayForPay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDayForPay.Location = new System.Drawing.Point(167, 19);
            this.txtDayForPay.Name = "txtDayForPay";
            this.txtDayForPay.Size = new System.Drawing.Size(48, 21);
            this.txtDayForPay.TabIndex = 46;
            this.txtDayForPay.ThemeName = "Office2013Light";
            this.txtDayForPay.TextChanged += new System.EventHandler(this.txtDayForPay_TextChanged);
            // 
            // bsAgreementAddPartner
            // 
            this.bsAgreementAddPartner.DataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            // 
            // ddlPeriodPayment
            // 
            this.ddlPeriodPayment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAgreementAddPartner, "PeriodCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlPeriodPayment.DataSource = this.bsDictPaidPeriod;
            this.ddlPeriodPayment.DisplayMember = "Name";
            this.ddlPeriodPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlPeriodPayment.Location = new System.Drawing.Point(167, 46);
            this.ddlPeriodPayment.Name = "ddlPeriodPayment";
            this.ddlPeriodPayment.Size = new System.Drawing.Size(194, 21);
            this.ddlPeriodPayment.TabIndex = 43;
            this.ddlPeriodPayment.ThemeName = "Office2013Light";
            this.ddlPeriodPayment.ValueMember = "CodeI";
            // 
            // bsDictPaidPeriod
            // 
            this.bsDictPaidPeriod.DataSource = typeof(ipsFormsDesign.Model.Period);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox.Controls.Add(this.radLabel2);
            this.groupBox.Controls.Add(this.ddlPeriodPayment);
            this.groupBox.Controls.Add(this.txtDayForPay);
            this.groupBox.Controls.Add(this.radLabel4);
            this.groupBox.Location = new System.Drawing.Point(3, 62);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(367, 75);
            this.groupBox.TabIndex = 47;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Параметри договору";
            // 
            // lblContrDo
            // 
            this.lblContrDo.Location = new System.Drawing.Point(9, 28);
            this.lblContrDo.Name = "lblContrDo";
            this.lblContrDo.Size = new System.Drawing.Size(100, 19);
            this.lblContrDo.TabIndex = 52;
            this.lblContrDo.Text = "Дія договору від";
            this.lblContrDo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblContrDo.ThemeName = "Office2013Light";
            // 
            // dtDateEnd
            // 
            this.dtDateEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddPartner, "DateEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEnd.Location = new System.Drawing.Point(270, 27);
            this.dtDateEnd.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dtDateEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDateEnd.Name = "dtDateEnd";
            this.dtDateEnd.NullText = "Оберіть дату";
            this.dtDateEnd.Size = new System.Drawing.Size(118, 21);
            this.dtDateEnd.TabIndex = 55;
            this.dtDateEnd.TabStop = false;
            this.dtDateEnd.ThemeName = "Office2013Light";
            this.dtDateEnd.Value = new System.DateTime(((long)(0)));
            // 
            // lblContrDoTo
            // 
            this.lblContrDoTo.Location = new System.Drawing.Point(243, 28);
            this.lblContrDoTo.Name = "lblContrDoTo";
            this.lblContrDoTo.Size = new System.Drawing.Size(21, 19);
            this.lblContrDoTo.TabIndex = 56;
            this.lblContrDoTo.Text = "до";
            this.lblContrDoTo.ThemeName = "Office2013Light";
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddPartner, "DateBegin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateBegin.Location = new System.Drawing.Point(115, 27);
            this.dtDateBegin.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dtDateBegin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDateBegin.Name = "dtDateBegin";
            this.dtDateBegin.NullText = "Оберіть дату";
            this.dtDateBegin.Size = new System.Drawing.Size(120, 21);
            this.dtDateBegin.TabIndex = 53;
            this.dtDateBegin.TabStop = false;
            this.dtDateBegin.ThemeName = "Office2013Light";
            this.dtDateBegin.Value = new System.DateTime(((long)(0)));
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtDateBegin.GetChildAt(0))).Text = "";
            // 
            // dtAgrDate
            // 
            this.dtAgrDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddPartner, "AgrDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtAgrDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAgrDate.Location = new System.Drawing.Point(270, 2);
            this.dtAgrDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtAgrDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtAgrDate.Name = "dtAgrDate";
            this.dtAgrDate.NullText = "Оберіть дату";
            this.dtAgrDate.Size = new System.Drawing.Size(118, 21);
            this.dtAgrDate.TabIndex = 50;
            this.dtAgrDate.TabStop = false;
            this.dtAgrDate.ThemeName = "Office2013Light";
            this.dtAgrDate.Value = new System.DateTime(((long)(0)));
            // 
            // lblContrFrom
            // 
            this.lblContrFrom.Location = new System.Drawing.Point(241, 3);
            this.lblContrFrom.Name = "lblContrFrom";
            this.lblContrFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrFrom.TabIndex = 51;
            this.lblContrFrom.Text = "від";
            this.lblContrFrom.ThemeName = "Office2013Light";
            // 
            // txtAgrNumber
            // 
            this.txtAgrNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "AgrNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAgrNumber.Location = new System.Drawing.Point(83, 2);
            this.txtAgrNumber.Name = "txtAgrNumber";
            this.txtAgrNumber.NullText = "Номер договору";
            this.txtAgrNumber.Size = new System.Drawing.Size(152, 21);
            this.txtAgrNumber.TabIndex = 48;
            this.txtAgrNumber.ThemeName = "Office2013Light";
            // 
            // lblContrNumb
            // 
            this.lblContrNumb.Location = new System.Drawing.Point(9, 3);
            this.lblContrNumb.Name = "lblContrNumb";
            this.lblContrNumb.Size = new System.Drawing.Size(68, 19);
            this.lblContrNumb.TabIndex = 49;
            this.lblContrNumb.Text = "Договір №";
            this.lblContrNumb.ThemeName = "Office2013Light";
            // 
            // AgreementWithPartnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContrDo);
            this.Controls.Add(this.dtDateEnd);
            this.Controls.Add(this.lblContrDoTo);
            this.Controls.Add(this.dtDateBegin);
            this.Controls.Add(this.dtAgrDate);
            this.Controls.Add(this.lblContrFrom);
            this.Controls.Add(this.txtAgrNumber);
            this.Controls.Add(this.lblContrNumb);
            this.Controls.Add(this.groupBox);
            this.MaximumSize = new System.Drawing.Size(394, 140);
            this.MinimumSize = new System.Drawing.Size(394, 140);
            this.Name = "AgreementWithPartnerControl";
            this.Size = new System.Drawing.Size(394, 140);
            this.Load += new System.EventHandler(this.AgreementWithPartnerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtDayForPay;
        private Telerik.WinControls.UI.RadDropDownList ddlPeriodPayment;
        private System.Windows.Forms.GroupBox groupBox;
        private Telerik.WinControls.UI.RadLabel lblContrDo;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateEnd;
        private Telerik.WinControls.UI.RadLabel lblContrDoTo;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateBegin;
        private System.Windows.Forms.BindingSource bsAgreementAddPartner;
        private Telerik.WinControls.UI.RadDateTimePicker dtAgrDate;
        private Telerik.WinControls.UI.RadLabel lblContrFrom;
        private Telerik.WinControls.UI.RadTextBox txtAgrNumber;
        private Telerik.WinControls.UI.RadLabel lblContrNumb;
        private System.Windows.Forms.BindingSource bsDictPaidPeriod;
    }
}
