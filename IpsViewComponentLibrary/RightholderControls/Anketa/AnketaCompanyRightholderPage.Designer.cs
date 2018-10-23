namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    partial class AnketaCompanyRightholderPage
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
            this.ddlRightholderType = new Telerik.WinControls.UI.RadDropDownList();
            this.bsRightHolder = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlRegistrationsCompany = new IpsViewComponentLibrary.IpsRegistrationsCompanyControl();
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAnketaCompany = new IpsViewComponentLibrary.IpsAnketaCompanyControl();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRightholderType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.DtRegisterDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtNumberVat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtRegisterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtRegisterWho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlRightholderType
            // 
            this.ddlRightholderType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRightHolder, "RHolderType", true));
            this.ddlRightholderType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRightholderType.Location = new System.Drawing.Point(122, 64);
            this.ddlRightholderType.Name = "ddlRightholderType";
            this.ddlRightholderType.Size = new System.Drawing.Size(218, 21);
            this.ddlRightholderType.TabIndex = 19;
            this.ddlRightholderType.ThemeName = "Office2013Light";
            // 
            // bsRightHolder
            // 
            this.bsRightHolder.DataSource = typeof(ipsFormsDesign.Model.RightHolder);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(6, 64);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(117, 19);
            this.radLabel2.TabIndex = 18;
            this.radLabel2.Text = "Тип правовласника";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // ctrlRegistrationsCompany
            // 
            this.ctrlRegistrationsCompany.DataMember = "";
            this.ctrlRegistrationsCompany.DataSource = this.bsAnketaCompany;
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.DtRegisterDate.CalendarSize = new System.Drawing.Size(220, 180);
            this.ctrlRegistrationsCompany.DtRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ctrlRegistrationsCompany.DtRegisterDate.Location = new System.Drawing.Point(278, 43);
            this.ctrlRegistrationsCompany.DtRegisterDate.MaxDate = new System.DateTime(2018, 7, 2, 0, 0, 0, 0);
            this.ctrlRegistrationsCompany.DtRegisterDate.Name = "dtRegisterDate";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.DtRegisterDate.RootElement.ControlBounds = new System.Drawing.Rectangle(278, 43, 164, 20);
            this.ctrlRegistrationsCompany.DtRegisterDate.RootElement.StretchVertically = true;
            this.ctrlRegistrationsCompany.DtRegisterDate.Size = new System.Drawing.Size(92, 21);
            this.ctrlRegistrationsCompany.DtRegisterDate.TabIndex = 2;
            this.ctrlRegistrationsCompany.DtRegisterDate.TabStop = false;
            this.ctrlRegistrationsCompany.DtRegisterDate.ThemeName = "Office2013Light";
            this.ctrlRegistrationsCompany.DtRegisterDate.Value = new System.DateTime(((long)(0)));
            this.ctrlRegistrationsCompany.Location = new System.Drawing.Point(14, 113);
            this.ctrlRegistrationsCompany.Name = "ctrlRegistrationsCompany";
            this.ctrlRegistrationsCompany.NumberVatDataMember = "NumberVat";
            this.ctrlRegistrationsCompany.OkpoDataMember = "Okpo";
            this.ctrlRegistrationsCompany.RegisterDateDataMember = "RegistrDate";
            this.ctrlRegistrationsCompany.RegisterNumberDataMember = "RegistrNumber";
            this.ctrlRegistrationsCompany.RegisterWhoDataMember = "RegistrWho";
            this.ctrlRegistrationsCompany.Size = new System.Drawing.Size(654, 110);
            this.ctrlRegistrationsCompany.TabIndex = 17;
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtNumberVat.Enabled = false;
            this.ctrlRegistrationsCompany.TxtNumberVat.Location = new System.Drawing.Point(436, 85);
            this.ctrlRegistrationsCompany.TxtNumberVat.MaxLength = 12;
            this.ctrlRegistrationsCompany.TxtNumberVat.Name = "txtNumberVat";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtNumberVat.RootElement.ControlBounds = new System.Drawing.Rectangle(436, 85, 100, 20);
            this.ctrlRegistrationsCompany.TxtNumberVat.RootElement.Enabled = false;
            this.ctrlRegistrationsCompany.TxtNumberVat.RootElement.StretchVertically = true;
            this.ctrlRegistrationsCompany.TxtNumberVat.Size = new System.Drawing.Size(161, 21);
            this.ctrlRegistrationsCompany.TxtNumberVat.TabIndex = 5;
            this.ctrlRegistrationsCompany.TxtNumberVat.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtOkpo.Location = new System.Drawing.Point(106, 2);
            this.ctrlRegistrationsCompany.TxtOkpo.MaxLength = 10;
            this.ctrlRegistrationsCompany.TxtOkpo.Name = "txtOkpo";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtOkpo.RootElement.ControlBounds = new System.Drawing.Rectangle(106, 2, 100, 20);
            this.ctrlRegistrationsCompany.TxtOkpo.RootElement.StretchVertically = true;
            this.ctrlRegistrationsCompany.TxtOkpo.Size = new System.Drawing.Size(134, 21);
            this.ctrlRegistrationsCompany.TxtOkpo.TabIndex = 0;
            this.ctrlRegistrationsCompany.TxtOkpo.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtRegisterNumber.Location = new System.Drawing.Point(106, 43);
            this.ctrlRegistrationsCompany.TxtRegisterNumber.Name = "txtRegisterNumber";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtRegisterNumber.RootElement.ControlBounds = new System.Drawing.Rectangle(106, 43, 100, 20);
            this.ctrlRegistrationsCompany.TxtRegisterNumber.RootElement.StretchVertically = true;
            this.ctrlRegistrationsCompany.TxtRegisterNumber.Size = new System.Drawing.Size(134, 21);
            this.ctrlRegistrationsCompany.TxtRegisterNumber.TabIndex = 1;
            this.ctrlRegistrationsCompany.TxtRegisterNumber.ThemeName = "Office2013Light";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtRegisterWho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegistrationsCompany.TxtRegisterWho.Location = new System.Drawing.Point(436, 43);
            this.ctrlRegistrationsCompany.TxtRegisterWho.Name = "txtRegisterWho";
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.TxtRegisterWho.RootElement.ControlBounds = new System.Drawing.Rectangle(436, 43, 100, 20);
            this.ctrlRegistrationsCompany.TxtRegisterWho.RootElement.StretchVertically = true;
            this.ctrlRegistrationsCompany.TxtRegisterWho.Size = new System.Drawing.Size(215, 21);
            this.ctrlRegistrationsCompany.TxtRegisterWho.TabIndex = 3;
            this.ctrlRegistrationsCompany.TxtRegisterWho.ThemeName = "Office2013Light";
            this.ctrlRegistrationsCompany.TypeVatDataMember = "TypeVat";
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // ctrlAnketaCompany
            // 
            this.ctrlAnketaCompany.DataSource = this.bsAnketaCompany;
            this.ctrlAnketaCompany.Location = new System.Drawing.Point(3, 3);
            this.ctrlAnketaCompany.MaximumSize = new System.Drawing.Size(900, 47);
            this.ctrlAnketaCompany.MinimumSize = new System.Drawing.Size(400, 47);
            this.ctrlAnketaCompany.Name = "ctrlAnketaCompany";
            this.ctrlAnketaCompany.Size = new System.Drawing.Size(452, 47);
            this.ctrlAnketaCompany.TabIndex = 16;
            // 
            // AnketaCompanyRightholderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlRightholderType);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ctrlRegistrationsCompany);
            this.Controls.Add(this.ctrlAnketaCompany);
            this.Name = "AnketaCompanyRightholderControl";
            this.Size = new System.Drawing.Size(670, 226);
            ((System.ComponentModel.ISupportInitialize)(this.ddlRightholderType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.DtRegisterDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtNumberVat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtRegisterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlRegistrationsCompany.TxtRegisterWho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlRightholderType;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private IpsRegistrationsCompanyControl ctrlRegistrationsCompany;
        private IpsAnketaCompanyControl ctrlAnketaCompany;
        private System.Windows.Forms.BindingSource bsRightHolder;
        private System.Windows.Forms.BindingSource bsAnketaCompany;
    }
}
