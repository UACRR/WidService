namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    partial class ProlongationGeneralAgreement
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.lblParam = new Telerik.WinControls.UI.RadLabel();
            this.panel = new Telerik.WinControls.UI.RadPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtDayForPay = new Telerik.WinControls.UI.RadTextBox();
            this.ddlPeriodPayment = new Telerik.WinControls.UI.RadDropDownList();
            this.ctrlAgreementMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.bsAgreementAddBr = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictPaidPeriod = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblParam
            // 
            this.lblParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblParam.Location = new System.Drawing.Point(22, 100);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(116, 18);
            this.lblParam.TabIndex = 46;
            this.lblParam.Text = "Параметри договору";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel.Controls.Add(this.radLabel2);
            this.panel.Controls.Add(this.radLabel4);
            this.panel.Controls.Add(this.txtDayForPay);
            this.panel.Controls.Add(this.ddlPeriodPayment);
            this.panel.Location = new System.Drawing.Point(12, 110);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(474, 69);
            this.panel.TabIndex = 47;
            this.panel.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel2.Location = new System.Drawing.Point(3, 14);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(155, 19);
            this.radLabel2.TabIndex = 40;
            this.radLabel2.Text = "Останній день розрахунку";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel4.Location = new System.Drawing.Point(3, 41);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(141, 19);
            this.radLabel4.TabIndex = 39;
            this.radLabel4.Text = "Періодичність платежів";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // txtDayForPay
            // 
            this.txtDayForPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDayForPay.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBr, "DayForPay", true));
            this.txtDayForPay.Location = new System.Drawing.Point(164, 14);
            this.txtDayForPay.Name = "txtDayForPay";
            this.txtDayForPay.Size = new System.Drawing.Size(48, 21);
            this.txtDayForPay.TabIndex = 41;
            this.txtDayForPay.ThemeName = "Office2013Light";
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
            this.ddlPeriodPayment.TabIndex = 38;
            this.ddlPeriodPayment.ThemeName = "Office2013Light";
            this.ddlPeriodPayment.ValueMember = "CodeI";
            // 
            // ctrlAgreementMain
            // 
            this.ctrlAgreementMain.AgreementLabelType = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.ctrlAgreementMain.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgreementMain.DataSourceBr = typeof(ipsFormsDesign.Model.AgreementAddBr);
            this.ctrlAgreementMain.DateEndNullDate = new System.DateTime(((long)(0)));
            this.ctrlAgreementMain.DateTimeType = IpsViewComponentLibrary.ConsumerAgreementInitType.None;
            this.ctrlAgreementMain.Location = new System.Drawing.Point(12, 40);
            this.ctrlAgreementMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.Name = "ctrlAgreementMain";
            this.ctrlAgreementMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.TabIndex = 45;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(44, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(49, 22);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "назва";
            this.lblTitle.ThemeName = "Office2013Light";
            // 
            // bsAgreementAddBr
            // 
            this.bsAgreementAddBr.DataSource = typeof(ipsFormsDesign.Model.AgreementAddBr);
            // 
            // bsDictPaidPeriod
            // 
            this.bsDictPaidPeriod.DataSource = typeof(ipsFormsDesign.Model.Period);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(386, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 24);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProlongationGeneralAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(504, 221);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblParam);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.ctrlAgreementMain);
            this.Controls.Add(this.lblTitle);
            this.MaximumSize = new System.Drawing.Size(512, 400);
            this.MinimumSize = new System.Drawing.Size(512, 220);
            this.Name = "ProlongationGeneralAgreement";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Пролонгація генерального договору";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.lblParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDayForPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriodPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictPaidPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadLabel lblParam;
        private Telerik.WinControls.UI.RadPanel panel;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtDayForPay;
        private Telerik.WinControls.UI.RadDropDownList ddlPeriodPayment;
        private ContractConsumerMainControl ctrlAgreementMain;
        private Telerik.WinControls.UI.RadLabel lblTitle;
        private System.Windows.Forms.BindingSource bsAgreementAddBr;
        private System.Windows.Forms.BindingSource bsDictPaidPeriod;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}
