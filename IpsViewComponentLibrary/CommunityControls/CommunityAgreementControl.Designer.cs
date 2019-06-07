using System.Windows.Forms;

namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityAgreementControl
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
            this.txtAgrNumber = new Telerik.WinControls.UI.RadTextBox();
            this.bsAgreementAddCommunity = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDayForPay = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ddlPeriodPayment = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictPaidPeriod = new System.Windows.Forms.BindingSource(this.components);
            this.checkForever = new Telerik.WinControls.UI.RadCheckBox();
            this.lblContrDo = new Telerik.WinControls.UI.RadLabel();
            this.dtDateEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrDoTo = new Telerik.WinControls.UI.RadLabel();
            this.dtDateBegin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtAgrDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrFrom = new Telerik.WinControls.UI.RadLabel();
            this.lblContrNumb = new Telerik.WinControls.UI.RadLabel();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtRateCommis = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.txtRateCourt = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddCommunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkForever)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateCommis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateCourt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAgrNumber
            // 
            this.txtAgrNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddCommunity, "AgrNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtAgrNumber.Location = new System.Drawing.Point(86, 2);
            this.txtAgrNumber.Name = "txtAgrNumber";
            this.txtAgrNumber.NullText = "Номер договору";
            this.txtAgrNumber.Size = new System.Drawing.Size(152, 21);
            this.txtAgrNumber.TabIndex = 1;
            this.txtAgrNumber.ThemeName = "Office2013Light";
            // 
            // bsAgreementAddCommunity
            // 
            this.bsAgreementAddCommunity.DataSource = typeof(ipsFormsDesign.Model.AgreementAddCommunity);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(6, 19);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(155, 19);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Останній день розрахунку";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // txtDayForPay
            // 
            this.txtDayForPay.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddCommunity, "DayForPay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtDayForPay.Location = new System.Drawing.Point(167, 19);
            this.txtDayForPay.Name = "txtDayForPay";
            this.txtDayForPay.Size = new System.Drawing.Size(48, 21);
            this.txtDayForPay.TabIndex = 1;
            this.txtDayForPay.ThemeName = "Office2013Light";
            this.txtDayForPay.TextChanged += new System.EventHandler(this.txtDayForPay_TextChanged);
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(6, 46);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(155, 19);
            this.radLabel4.TabIndex = 0;
            this.radLabel4.Text = "Періодичність розрахунку";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // ddlPeriodPayment
            // 
            this.ddlPeriodPayment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAgreementAddCommunity, "PeriodCode", true));
            this.ddlPeriodPayment.DataSource = this.bsDictPaidPeriod;
            this.ddlPeriodPayment.DisplayMember = "Name";
            this.ddlPeriodPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlPeriodPayment.Location = new System.Drawing.Point(167, 46);
            this.ddlPeriodPayment.Name = "ddlPeriodPayment";
            this.ddlPeriodPayment.Size = new System.Drawing.Size(194, 21);
            this.ddlPeriodPayment.TabIndex = 2;
            this.ddlPeriodPayment.ThemeName = "Office2013Light";
            this.ddlPeriodPayment.ValueMember = "CodeI";
            // 
            // bsDictPaidPeriod
            // 
            this.bsDictPaidPeriod.DataSource = typeof(ipsFormsDesign.Model.Period);
            // 
            // checkForever
            // 
            this.checkForever.Location = new System.Drawing.Point(397, 28);
            this.checkForever.Name = "checkForever";
            this.checkForever.Size = new System.Drawing.Size(80, 19);
            this.checkForever.TabIndex = 5;
            this.checkForever.Text = "Назавжди";
            this.checkForever.ThemeName = "Office2013Light";
            this.checkForever.CheckStateChanged += new System.EventHandler(this.checkForever_CheckStateChanged);
            // 
            // lblContrDo
            // 
            this.lblContrDo.Location = new System.Drawing.Point(12, 28);
            this.lblContrDo.Name = "lblContrDo";
            this.lblContrDo.Size = new System.Drawing.Size(100, 19);
            this.lblContrDo.TabIndex = 0;
            this.lblContrDo.Text = "Дія договору від";
            this.lblContrDo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblContrDo.ThemeName = "Office2013Light";
            // 
            // dtDateEnd
            // 
            this.dtDateEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddCommunity, "DateEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEnd.Location = new System.Drawing.Point(273, 27);
            this.dtDateEnd.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dtDateEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDateEnd.Name = "dtDateEnd";
            this.dtDateEnd.NullText = "Оберіть дату";
            this.dtDateEnd.Size = new System.Drawing.Size(118, 21);
            this.dtDateEnd.TabIndex = 4;
            this.dtDateEnd.TabStop = false;
            this.dtDateEnd.ThemeName = "Office2013Light";
            this.dtDateEnd.Value = new System.DateTime(((long)(0)));
            // 
            // lblContrDoTo
            // 
            this.lblContrDoTo.Location = new System.Drawing.Point(246, 28);
            this.lblContrDoTo.Name = "lblContrDoTo";
            this.lblContrDoTo.Size = new System.Drawing.Size(21, 19);
            this.lblContrDoTo.TabIndex = 0;
            this.lblContrDoTo.Text = "до";
            this.lblContrDoTo.ThemeName = "Office2013Light";
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddCommunity, "DateBegin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateBegin.Location = new System.Drawing.Point(118, 27);
            this.dtDateBegin.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dtDateBegin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDateBegin.Name = "dtDateBegin";
            this.dtDateBegin.NullText = "Оберіть дату";
            this.dtDateBegin.Size = new System.Drawing.Size(120, 21);
            this.dtDateBegin.TabIndex = 3;
            this.dtDateBegin.TabStop = false;
            this.dtDateBegin.ThemeName = "Office2013Light";
            this.dtDateBegin.Value = new System.DateTime(((long)(0)));
            this.dtDateBegin.ValueChanged += new System.EventHandler(this.dtDateBegin_ValueChanged);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dtDateBegin.GetChildAt(0))).Text = "";
            // 
            // dtAgrDate
            // 
            this.dtAgrDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAgreementAddCommunity, "AgrDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtAgrDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAgrDate.Location = new System.Drawing.Point(273, 2);
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
            this.lblContrFrom.Location = new System.Drawing.Point(244, 3);
            this.lblContrFrom.Name = "lblContrFrom";
            this.lblContrFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrFrom.TabIndex = 0;
            this.lblContrFrom.Text = "від";
            this.lblContrFrom.ThemeName = "Office2013Light";
            // 
            // lblContrNumb
            // 
            this.lblContrNumb.Location = new System.Drawing.Point(12, 3);
            this.lblContrNumb.Name = "lblContrNumb";
            this.lblContrNumb.Size = new System.Drawing.Size(68, 19);
            this.lblContrNumb.TabIndex = 0;
            this.lblContrNumb.Text = "Договір №";
            this.lblContrNumb.ThemeName = "Office2013Light";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.radLabel2);
            this.groupBox.Controls.Add(this.ddlPeriodPayment);
            this.groupBox.Controls.Add(this.txtDayForPay);
            this.groupBox.Controls.Add(this.radLabel4);
            this.groupBox.Location = new System.Drawing.Point(3, 54);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(367, 75);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Параметри договору";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(199, 135);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(217, 30);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Комісії обслуговування";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radLabel3);
            this.groupBox3.Controls.Add(this.radLabel5);
            this.groupBox3.Controls.Add(this.txtRateCommis);
            this.groupBox3.Controls.Add(this.radLabel6);
            this.groupBox3.Controls.Add(this.radLabel7);
            this.groupBox3.Controls.Add(this.radLabel13);
            this.groupBox3.Controls.Add(this.txtRateCourt);
            this.groupBox3.Controls.Add(this.radLabel12);
            this.groupBox3.Location = new System.Drawing.Point(3, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(632, 109);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel3.AutoSize = false;
            this.radLabel3.Location = new System.Drawing.Point(366, 68);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(260, 35);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "від суми авторської винагороди, зібраної за таке використання";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel5.Location = new System.Drawing.Point(345, 78);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(15, 18);
            this.radLabel5.TabIndex = 0;
            this.radLabel5.Text = "%";
            // 
            // txtRateCommis
            // 
            this.txtRateCommis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRateCommis.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddCommunity, "RateCommiss", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtRateCommis.Location = new System.Drawing.Point(285, 76);
            this.txtRateCommis.Name = "txtRateCommis";
            this.txtRateCommis.Size = new System.Drawing.Size(54, 21);
            this.txtRateCommis.TabIndex = 2;
            this.txtRateCommis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRateCommis.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel6.AutoSize = false;
            this.radLabel6.Location = new System.Drawing.Point(6, 68);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(273, 35);
            this.radLabel6.TabIndex = 0;
            this.radLabel6.Text = "Використання творів у порядку судового провадження становить";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // radLabel7
            // 
            this.radLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel7.AutoSize = false;
            this.radLabel7.Location = new System.Drawing.Point(365, 27);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(261, 35);
            this.radLabel7.TabIndex = 0;
            this.radLabel7.Text = "від сум, отриманих Підприємством для Автора";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // radLabel13
            // 
            this.radLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel13.Location = new System.Drawing.Point(344, 37);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(15, 18);
            this.radLabel13.TabIndex = 0;
            this.radLabel13.Text = "%";
            // 
            // txtRateCourt
            // 
            this.txtRateCourt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRateCourt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddCommunity, "RateCourt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtRateCourt.Location = new System.Drawing.Point(284, 35);
            this.txtRateCourt.Name = "txtRateCourt";
            this.txtRateCourt.Size = new System.Drawing.Size(54, 21);
            this.txtRateCourt.TabIndex = 1;
            this.txtRateCourt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRateCourt.ThemeName = "Office2013Light";
            // 
            // radLabel12
            // 
            this.radLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel12.AutoSize = false;
            this.radLabel12.Location = new System.Drawing.Point(5, 27);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(273, 35);
            this.radLabel12.TabIndex = 0;
            this.radLabel12.Text = "Відрахування пов\'язані зі збором, розподілом та виплатою винагороди у розмірі";
            this.radLabel12.ThemeName = "Office2013Light";
            // 
            // CommunityAgreementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtAgrNumber);
            this.Controls.Add(this.checkForever);
            this.Controls.Add(this.lblContrDo);
            this.Controls.Add(this.dtDateEnd);
            this.Controls.Add(this.lblContrDoTo);
            this.Controls.Add(this.dtDateBegin);
            this.Controls.Add(this.dtAgrDate);
            this.Controls.Add(this.lblContrFrom);
            this.Controls.Add(this.lblContrNumb);
            this.Controls.Add(this.groupBox);
            this.Name = "CommunityAgreementControl";
            this.Size = new System.Drawing.Size(641, 260);
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddCommunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkForever)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAgrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateCommis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateCourt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtAgrNumber;
        private System.Windows.Forms.BindingSource bsAgreementAddCommunity;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtDayForPay;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList ddlPeriodPayment;
        private System.Windows.Forms.BindingSource bsDictPaidPeriod;
        private Telerik.WinControls.UI.RadCheckBox checkForever;
        private Telerik.WinControls.UI.RadLabel lblContrDo;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateEnd;
        private Telerik.WinControls.UI.RadLabel lblContrDoTo;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateBegin;
        private Telerik.WinControls.UI.RadDateTimePicker dtAgrDate;
        private Telerik.WinControls.UI.RadLabel lblContrFrom;
        private Telerik.WinControls.UI.RadLabel lblContrNumb;
        private System.Windows.Forms.GroupBox groupBox;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtRateCommis;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadTextBox txtRateCourt;
        private Telerik.WinControls.UI.RadLabel radLabel12;
    }
}
