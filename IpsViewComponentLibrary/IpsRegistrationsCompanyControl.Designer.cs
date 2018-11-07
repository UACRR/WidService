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
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
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
            this.bsDictTypeVat = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypeVat)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumberVat
            // 
            this.txtNumberVat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaCompany, "NumberVat", true));
            this.txtNumberVat.Enabled = false;
            this.txtNumberVat.Location = new System.Drawing.Point(436, 85);
            this.txtNumberVat.MaxLength = 12;
            this.txtNumberVat.Name = "txtNumberVat";
            this.txtNumberVat.Size = new System.Drawing.Size(161, 21);
            this.txtNumberVat.TabIndex = 5;
            this.txtNumberVat.ThemeName = "Office2013Light";
            this.txtNumberVat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberVat_KeyPress);
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // txtRegisterNumber
            // 
            this.txtRegisterNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaCompany, "RegistrNumber", true));
            this.txtRegisterNumber.Location = new System.Drawing.Point(106, 43);
            this.txtRegisterNumber.Name = "txtRegisterNumber";
            this.txtRegisterNumber.Size = new System.Drawing.Size(134, 21);
            this.txtRegisterNumber.TabIndex = 1;
            this.txtRegisterNumber.ThemeName = "Office2013Light";
            // 
            // txtRegisterWho
            // 
            this.txtRegisterWho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegisterWho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaCompany, "RegistrWho", true));
            this.txtRegisterWho.Location = new System.Drawing.Point(436, 43);
            this.txtRegisterWho.Name = "txtRegisterWho";
            this.txtRegisterWho.Size = new System.Drawing.Size(215, 21);
            this.txtRegisterWho.TabIndex = 3;
            this.txtRegisterWho.ThemeName = "Office2013Light";
            // 
            // dtRegisterDate
            // 
            this.dtRegisterDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAnketaCompany, "RegistrDate", true));
            this.dtRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRegisterDate.Location = new System.Drawing.Point(278, 43);
            this.dtRegisterDate.MaxDate = new System.DateTime(2018, 7, 2, 0, 0, 0, 0);
            this.dtRegisterDate.Name = "dtRegisterDate";
            this.dtRegisterDate.Size = new System.Drawing.Size(92, 21);
            this.dtRegisterDate.TabIndex = 2;
            this.dtRegisterDate.TabStop = false;
            this.dtRegisterDate.ThemeName = "Office2013Light";
            this.dtRegisterDate.Value = new System.DateTime(((long)(0)));
            // 
            // txtOkpo
            // 
            this.txtOkpo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaCompany, "Okpo", true));
            this.txtOkpo.Location = new System.Drawing.Point(106, 2);
            this.txtOkpo.MaxLength = 10;
            this.txtOkpo.Name = "txtOkpo";
            this.txtOkpo.Size = new System.Drawing.Size(134, 21);
            this.txtOkpo.TabIndex = 0;
            this.txtOkpo.ThemeName = "Office2013Light";
            this.txtOkpo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOkpo_KeyPress);
            // 
            // lblIssuedBy
            // 
            this.lblIssuedBy.Location = new System.Drawing.Point(376, 44);
            this.lblIssuedBy.Name = "lblIssuedBy";
            this.lblIssuedBy.Size = new System.Drawing.Size(57, 19);
            this.lblIssuedBy.TabIndex = 3;
            this.lblIssuedBy.Text = "виданий:";
            this.lblIssuedBy.ThemeName = "Office2013Light";
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.Location = new System.Drawing.Point(247, 44);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(25, 19);
            this.lblDateBegin.TabIndex = 2;
            this.lblDateBegin.Text = "від:";
            this.lblDateBegin.ThemeName = "Office2013Light";
            // 
            // lblIPN
            // 
            this.lblIPN.Location = new System.Drawing.Point(305, 85);
            this.lblIPN.Name = "lblIPN";
            this.lblIPN.Size = new System.Drawing.Size(128, 19);
            this.lblIPN.TabIndex = 5;
            this.lblIPN.Text = "Номер платника ПДВ";
            this.lblIPN.ThemeName = "Office2013Light";
            // 
            // lblSvidoctvo
            // 
            this.lblSvidoctvo.AutoSize = false;
            this.lblSvidoctvo.Location = new System.Drawing.Point(3, 24);
            this.lblSvidoctvo.Name = "lblSvidoctvo";
            this.lblSvidoctvo.Size = new System.Drawing.Size(97, 52);
            this.lblSvidoctvo.TabIndex = 1;
            this.lblSvidoctvo.Text = "Свідоцтво про державну реєстрацію №:";
            this.lblSvidoctvo.ThemeName = "Office2013Light";
            // 
            // lbledrpou
            // 
            this.lbledrpou.Location = new System.Drawing.Point(3, 3);
            this.lbledrpou.Name = "lbledrpou";
            this.lbledrpou.Size = new System.Drawing.Size(57, 19);
            this.lbledrpou.TabIndex = 0;
            this.lbledrpou.Text = "ЄДРПОУ:";
            this.lbledrpou.ThemeName = "Office2013Light";
            // 
            // lblTypeTaxpayer
            // 
            this.lblTypeTaxpayer.AutoSize = false;
            this.lblTypeTaxpayer.Location = new System.Drawing.Point(3, 76);
            this.lblTypeTaxpayer.Name = "lblTypeTaxpayer";
            this.lblTypeTaxpayer.Size = new System.Drawing.Size(97, 35);
            this.lblTypeTaxpayer.TabIndex = 4;
            this.lblTypeTaxpayer.Text = "Тип платника податків:";
            this.lblTypeTaxpayer.ThemeName = "Office2013Light";
            // 
            // ddlTypeVat
            // 
            this.ddlTypeVat.AutoScroll = true;
            this.ddlTypeVat.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAnketaCompany, "TypeVat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.ddlTypeVat.DataSource = this.bsDictTypeVat;
            this.ddlTypeVat.DefaultItemsCountInDropDown = 5;
            this.ddlTypeVat.DisplayMember = "Name";
            this.ddlTypeVat.DropDownMaxSize = new System.Drawing.Size(300, 120);
            this.ddlTypeVat.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlTypeVat.Location = new System.Drawing.Point(106, 85);
            this.ddlTypeVat.Name = "ddlTypeVat";
            this.ddlTypeVat.Size = new System.Drawing.Size(134, 21);
            this.ddlTypeVat.TabIndex = 4;
            this.ddlTypeVat.ThemeName = "Office2013Light";
            this.ddlTypeVat.ValueMember = "CodeI";
            this.ddlTypeVat.SelectedValueChanged += new System.EventHandler(this.ddlTypeVat_SelectedValueChanged);
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlTypeVat.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlTypeVat.GetChildAt(0))).AutoSize = true;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlTypeVat.GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            // 
            // bsDictTypeVat
            // 
            this.bsDictTypeVat.DataSource = typeof(ipsFormsDesign.Model.TypeVat);
            // 
            // IpsRegistrationsCompanyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
            this.Name = "IpsRegistrationsCompanyControl";
            this.Size = new System.Drawing.Size(654, 110);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypeVat)).EndInit();
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
        private System.Windows.Forms.BindingSource bsAnketaCompany;
        private System.Windows.Forms.BindingSource bsDictTypeVat;
    }
}
