using System;

namespace IpsViewComponentLibrary
{
    partial class IpsRegistrationsCompanyControl
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
            this.txtNumberVat = new Telerik.WinControls.UI.RadTextBox();
            this.txtRegisterNumber = new Telerik.WinControls.UI.RadTextBox();
            this.txtRegisterWho = new Telerik.WinControls.UI.RadTextBox();
            this.dtRegisterDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtOkpo = new Telerik.WinControls.UI.RadTextBox();
            this.lblIssuedBy = new Telerik.WinControls.UI.RadLabel();
            this.lblDateBegin = new Telerik.WinControls.UI.RadLabel();
            this.lblIPN = new Telerik.WinControls.UI.RadLabel();
            this.lblSvidoctvo = new Telerik.WinControls.UI.RadLabel();
            this.lbledrpou = new Telerik.WinControls.UI.RadLabel();
            this.lblTypeTaxpayer = new Telerik.WinControls.UI.RadLabel();
            this.ddlTypeVat = new Telerik.WinControls.UI.RadDropDownList();
            this.bindingSourceAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterWho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegisterDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIssuedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSvidoctvo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbledrpou)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypeTaxpayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypeVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumberVat
            // 
            this.txtNumberVat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAnketaCompany, "NumberVat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty ));
            this.txtNumberVat.Location = new System.Drawing.Point(581, 82);
            this.txtNumberVat.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumberVat.Name = "txtNumberVat";
            this.txtNumberVat.Size = new System.Drawing.Size(219, 24);
            this.txtNumberVat.TabIndex = 11;
            // 
            // txtRegisterNumber
            // 
            this.txtRegisterNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAnketaCompany, "RegistrNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty ));
            this.txtRegisterNumber.Location = new System.Drawing.Point(160, 40);
            this.txtRegisterNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtRegisterNumber.Name = "txtRegisterNumber";
            this.txtRegisterNumber.Size = new System.Drawing.Size(160, 24);
            this.txtRegisterNumber.TabIndex = 3;
            // 
            // txtRegisterWho
            // 
            this.txtRegisterWho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegisterWho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAnketaCompany, "RegistrWho", true));
            this.txtRegisterWho.Location = new System.Drawing.Point(581, 40);
            this.txtRegisterWho.Margin = new System.Windows.Forms.Padding(4);
            this.txtRegisterWho.Name = "txtRegisterWho";
            this.txtRegisterWho.Size = new System.Drawing.Size(406, 24);
            this.txtRegisterWho.TabIndex = 7;
            // 
            // dtRegisterDate
            // 
            this.dtRegisterDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceAnketaCompany, "RegistrDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, DateTime.Today));
            this.dtRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRegisterDate.Location = new System.Drawing.Point(371, 40);
            this.dtRegisterDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtRegisterDate.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dtRegisterDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtRegisterDate.Name = "dtRegisterDate";
            this.dtRegisterDate.Size = new System.Drawing.Size(123, 24);
            this.dtRegisterDate.TabIndex = 5;
            this.dtRegisterDate.TabStop = false;
            this.dtRegisterDate.Value = new System.DateTime(((long)(0)));
            // 
            // txtOkpo
            // 
            this.txtOkpo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAnketaCompany, "Okpo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty ));
            this.txtOkpo.Location = new System.Drawing.Point(160, 1);
            this.txtOkpo.Margin = new System.Windows.Forms.Padding(4);
            this.txtOkpo.Name = "txtOkpo";
            this.txtOkpo.Size = new System.Drawing.Size(160, 24);
            this.txtOkpo.TabIndex = 1;
            // 
            // lblIssuedBy
            // 
            this.lblIssuedBy.Location = new System.Drawing.Point(501, 41);
            this.lblIssuedBy.Margin = new System.Windows.Forms.Padding(4);
            this.lblIssuedBy.Name = "lblIssuedBy";
            this.lblIssuedBy.Size = new System.Drawing.Size(53, 18);
            this.lblIssuedBy.TabIndex = 6;
            this.lblIssuedBy.Text = "виданий:";
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.Location = new System.Drawing.Point(329, 41);
            this.lblDateBegin.Margin = new System.Windows.Forms.Padding(4);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(24, 18);
            this.lblDateBegin.TabIndex = 4;
            this.lblDateBegin.Text = "від:";
            // 
            // lblIPN
            // 
            this.lblIPN.Location = new System.Drawing.Point(415, 85);
            this.lblIPN.Margin = new System.Windows.Forms.Padding(4);
            this.lblIPN.Name = "lblIPN";
            this.lblIPN.Size = new System.Drawing.Size(118, 18);
            this.lblIPN.TabIndex = 10;
            this.lblIPN.Text = "Індивід. подактов. №:";
            // 
            // lblSvidoctvo
            // 
            this.lblSvidoctvo.AutoSize = false;
            this.lblSvidoctvo.Location = new System.Drawing.Point(4, 23);
            this.lblSvidoctvo.Margin = new System.Windows.Forms.Padding(4);
            this.lblSvidoctvo.Name = "lblSvidoctvo";
            this.lblSvidoctvo.Size = new System.Drawing.Size(129, 59);
            this.lblSvidoctvo.TabIndex = 2;
            this.lblSvidoctvo.Text = "Свідоцтво про державну реєстрацію №:";
            // 
            // lbledrpou
            // 
            this.lbledrpou.Location = new System.Drawing.Point(4, 4);
            this.lbledrpou.Margin = new System.Windows.Forms.Padding(4);
            this.lbledrpou.Name = "lbledrpou";
            this.lbledrpou.Size = new System.Drawing.Size(53, 18);
            this.lbledrpou.TabIndex = 0;
            this.lbledrpou.Text = "ЄДРПОУ:";
            // 
            // lblTypeTaxpayer
            // 
            this.lblTypeTaxpayer.AutoSize = false;
            this.lblTypeTaxpayer.Location = new System.Drawing.Point(4, 74);
            this.lblTypeTaxpayer.Margin = new System.Windows.Forms.Padding(4);
            this.lblTypeTaxpayer.Name = "lblTypeTaxpayer";
            this.lblTypeTaxpayer.Size = new System.Drawing.Size(129, 41);
            this.lblTypeTaxpayer.TabIndex = 8;
            this.lblTypeTaxpayer.Text = "Тип платника податків:";
            // 
            // ddlTypeVat
            // 
            this.ddlTypeVat.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceAnketaCompany, "TypeVat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0 ));
            this.ddlTypeVat.DropDownHeight = 141;
            this.ddlTypeVat.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlTypeVat.Location = new System.Drawing.Point(160, 82);
            this.ddlTypeVat.Margin = new System.Windows.Forms.Padding(4);
            this.ddlTypeVat.Name = "ddlTypeVat";
            this.ddlTypeVat.Size = new System.Drawing.Size(193, 24);
            this.ddlTypeVat.TabIndex = 9;
            // 
            // bindingSourceAnketaCompany
            // 
            this.bindingSourceAnketaCompany.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            // 
            // IpsRegistrationsCompanyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlTypeVat);
            this.Controls.Add(this.lblTypeTaxpayer);
            this.Controls.Add(this.txtNumberVat);
            this.Controls.Add(this.txtRegisterNumber);
            this.Controls.Add(this.txtRegisterWho);
            this.Controls.Add(this.dtRegisterDate);
            this.Controls.Add(this.txtOkpo);
            this.Controls.Add(this.lblIssuedBy);
            this.Controls.Add(this.lblDateBegin);
            this.Controls.Add(this.lblIPN);
            this.Controls.Add(this.lblSvidoctvo);
            this.Controls.Add(this.lbledrpou);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IpsRegistrationsCompanyControl";
            this.Size = new System.Drawing.Size(987, 119);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterWho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegisterDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIssuedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSvidoctvo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbledrpou)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypeTaxpayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypeVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtNumberVat;
        private Telerik.WinControls.UI.RadTextBox txtRegisterNumber;
        private Telerik.WinControls.UI.RadTextBox txtRegisterWho;
        private Telerik.WinControls.UI.RadDateTimePicker dtRegisterDate;
        private Telerik.WinControls.UI.RadTextBox txtOkpo;
        private Telerik.WinControls.UI.RadLabel lblIssuedBy;
        private Telerik.WinControls.UI.RadLabel lblDateBegin;
        private Telerik.WinControls.UI.RadLabel lblIPN;
        private Telerik.WinControls.UI.RadLabel lblSvidoctvo;
        private Telerik.WinControls.UI.RadLabel lbledrpou;
        private Telerik.WinControls.UI.RadLabel lblTypeTaxpayer;
        private Telerik.WinControls.UI.RadDropDownList ddlTypeVat;
        private System.Windows.Forms.BindingSource bindingSourceAnketaCompany;
    }
}
