using IpsViewComponentLibrary.Shared.Controls;

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
            this.ctrlRegistrationsCompany = new IpsViewComponentLibrary.Shared.Controls.IpsRegistrationsCompanyControl();
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAnketaCompany = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaCompanyControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.txtInnerCode = new Telerik.WinControls.UI.RadTextBox();
            this.txtInterCode = new Telerik.WinControls.UI.RadTextBox();
            this.lblIPIExists = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRightholderType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIPIExists)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlRightholderType
            // 
            this.ddlRightholderType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRightHolder, "RHolderType", true));
            this.ddlRightholderType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRightholderType.Enabled = false;
            this.ddlRightholderType.Location = new System.Drawing.Point(131, 95);
            this.ddlRightholderType.Name = "ddlRightholderType";
            this.ddlRightholderType.Size = new System.Drawing.Size(270, 21);
            this.ddlRightholderType.TabIndex = 19;
            this.ddlRightholderType.ThemeName = "Office2013Light";
            // 
            // bsRightHolder
            // 
            this.bsRightHolder.DataSource = typeof(ipsFormsDesign.Model.RightHolder);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(5, 95);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(120, 19);
            this.radLabel2.TabIndex = 18;
            this.radLabel2.Text = "Тип правовласника:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // ctrlRegistrationsCompany
            // 
            this.ctrlRegistrationsCompany.DataSource = this.bsAnketaCompany;
            this.ctrlRegistrationsCompany.Location = new System.Drawing.Point(3, 173);
            this.ctrlRegistrationsCompany.MaxDate = new System.DateTime(2018, 7, 2, 0, 0, 0, 0);
            this.ctrlRegistrationsCompany.MinimumSize = new System.Drawing.Size(550, 108);
            this.ctrlRegistrationsCompany.Name = "ctrlRegistrationsCompany";
            this.ctrlRegistrationsCompany.Size = new System.Drawing.Size(664, 110);
            this.ctrlRegistrationsCompany.TabIndex = 17;
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // ctrlAnketaCompany
            // 
            this.ctrlAnketaCompany.DataSource = this.bsAnketaCompany;
            this.ctrlAnketaCompany.Location = new System.Drawing.Point(3, 3);
            this.ctrlAnketaCompany.MaximumSize = new System.Drawing.Size(800, 86);
            this.ctrlAnketaCompany.MinimumSize = new System.Drawing.Size(400, 86);
            this.ctrlAnketaCompany.Name = "ctrlAnketaCompany";
            this.ctrlAnketaCompany.Size = new System.Drawing.Size(664, 86);
            this.ctrlAnketaCompany.TabIndex = 16;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(5, 120);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 19);
            this.radLabel1.TabIndex = 30;
            this.radLabel1.Text = "Шифр:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel12
            // 
            this.radLabel12.Location = new System.Drawing.Point(5, 147);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(23, 19);
            this.radLabel12.TabIndex = 31;
            this.radLabel12.Text = "IPI:";
            this.radLabel12.ThemeName = "Office2013Light";
            // 
            // txtInnerCode
            // 
            this.txtInnerCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRightHolder, "InnerCode", true));
            this.txtInnerCode.Location = new System.Drawing.Point(118, 119);
            this.txtInnerCode.Name = "txtInnerCode";
            this.txtInnerCode.Size = new System.Drawing.Size(283, 21);
            this.txtInnerCode.TabIndex = 32;
            this.txtInnerCode.ThemeName = "Office2013Light";
            // 
            // txtInterCode
            // 
            this.txtInterCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRightHolder, "InterCode", true));
            this.txtInterCode.Location = new System.Drawing.Point(118, 146);
            this.txtInterCode.Name = "txtInterCode";
            this.txtInterCode.Size = new System.Drawing.Size(283, 21);
            this.txtInterCode.TabIndex = 33;
            this.txtInterCode.ThemeName = "Office2013Light";
            this.txtInterCode.Leave += new System.EventHandler(this.txtInterCode_Leave);
            // 
            // lblIPIExists
            // 
            this.lblIPIExists.ForeColor = System.Drawing.Color.Red;
            this.lblIPIExists.Location = new System.Drawing.Point(408, 148);
            this.lblIPIExists.Name = "lblIPIExists";
            this.lblIPIExists.Size = new System.Drawing.Size(70, 18);
            this.lblIPIExists.TabIndex = 34;
            this.lblIPIExists.Text = "IPI вже існує";
            this.lblIPIExists.Visible = false;
            // 
            // AnketaCompanyRightholderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblIPIExists);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel12);
            this.Controls.Add(this.txtInnerCode);
            this.Controls.Add(this.txtInterCode);
            this.Controls.Add(this.ddlRightholderType);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ctrlRegistrationsCompany);
            this.Controls.Add(this.ctrlAnketaCompany);
            this.Name = "AnketaCompanyRightholderPage";
            this.Size = new System.Drawing.Size(670, 287);
            ((System.ComponentModel.ISupportInitialize)(this.ddlRightholderType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIPIExists)).EndInit();
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
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private Telerik.WinControls.UI.RadTextBox txtInnerCode;
        private Telerik.WinControls.UI.RadTextBox txtInterCode;
        private Telerik.WinControls.UI.RadLabel lblIPIExists;
    }
}
