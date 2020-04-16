namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    partial class AnketaPersonRightholderPage
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.txtInnerCode = new Telerik.WinControls.UI.RadTextBox();
            this.bsRightHolder = new System.Windows.Forms.BindingSource(this.components);
            this.txtInterCode = new Telerik.WinControls.UI.RadTextBox();
            this.ctrlAnketaPerson = new IpsViewComponentLibrary.RightholderControls.Anketa.AnketaPersonRightHolderControl();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.bsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlRegistrationsPerson = new IpsViewComponentLibrary.RightholderControls.RegistrationPersonsControl();
            this.lblIPIExists = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIPIExists)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(7, 143);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 19);
            this.radLabel1.TabIndex = 26;
            this.radLabel1.Text = "Шифр:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel12
            // 
            this.radLabel12.Location = new System.Drawing.Point(7, 168);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(23, 19);
            this.radLabel12.TabIndex = 27;
            this.radLabel12.Text = "IPI:";
            this.radLabel12.ThemeName = "Office2013Light";
            // 
            // txtInnerCode
            // 
            this.txtInnerCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRightHolder, "InnerCode", true));
            this.txtInnerCode.Location = new System.Drawing.Point(118, 142);
            this.txtInnerCode.Name = "txtInnerCode";
            this.txtInnerCode.Size = new System.Drawing.Size(283, 21);
            this.txtInnerCode.TabIndex = 28;
            this.txtInnerCode.ThemeName = "Office2013Light";
            // 
            // bsRightHolder
            // 
            this.bsRightHolder.DataSource = typeof(ipsFormsDesign.Model.RightHolder);
            // 
            // txtInterCode
            // 
            this.txtInterCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRightHolder, "InterCode", true));
            this.txtInterCode.Location = new System.Drawing.Point(118, 167);
            this.txtInterCode.Name = "txtInterCode";
            this.txtInterCode.Size = new System.Drawing.Size(283, 21);
            this.txtInterCode.TabIndex = 29;
            this.txtInterCode.ThemeName = "Office2013Light";
            this.txtInterCode.Leave += new System.EventHandler(this.txtInterCode_Leave);
            // 
            // ctrlAnketaPerson
            // 
            this.ctrlAnketaPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAnketaPerson.DataSourceAnketa = this.bsAnketaPerson;
            this.ctrlAnketaPerson.DataSourceCustomer = this.bsCustomer;
            this.ctrlAnketaPerson.Location = new System.Drawing.Point(3, 3);
            this.ctrlAnketaPerson.MaximumSize = new System.Drawing.Size(900, 128);
            this.ctrlAnketaPerson.Name = "ctrlAnketaPerson";
            this.ctrlAnketaPerson.Size = new System.Drawing.Size(895, 128);
            this.ctrlAnketaPerson.TabIndex = 25;
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // bsCustomer
            // 
            this.bsCustomer.DataSource = typeof(ipsFormsDesign.Model.Customer);
            // 
            // ctrlRegistrationsPerson
            // 
            this.ctrlRegistrationsPerson.DataSource = this.bsAnketaPerson;
            this.ctrlRegistrationsPerson.Location = new System.Drawing.Point(5, 194);
            this.ctrlRegistrationsPerson.Name = "ctrlRegistrationsPerson";
            this.ctrlRegistrationsPerson.Size = new System.Drawing.Size(403, 53);
            this.ctrlRegistrationsPerson.TabIndex = 30;
            // 
            // lblIPIExists
            // 
            this.lblIPIExists.ForeColor = System.Drawing.Color.Red;
            this.lblIPIExists.Location = new System.Drawing.Point(408, 169);
            this.lblIPIExists.Name = "lblIPIExists";
            this.lblIPIExists.Size = new System.Drawing.Size(70, 18);
            this.lblIPIExists.TabIndex = 31;
            this.lblIPIExists.Text = "IPI вже існує";
            this.lblIPIExists.Visible = false;
            // 
            // AnketaPersonRightholderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblIPIExists);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel12);
            this.Controls.Add(this.txtInnerCode);
            this.Controls.Add(this.txtInterCode);
            this.Controls.Add(this.ctrlAnketaPerson);
            this.Controls.Add(this.ctrlRegistrationsPerson);
            this.Name = "AnketaPersonRightholderPage";
            this.Size = new System.Drawing.Size(900, 252);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRightHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIPIExists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private Telerik.WinControls.UI.RadTextBox txtInnerCode;
        private Telerik.WinControls.UI.RadTextBox txtInterCode;
        private AnketaPersonRightHolderControl ctrlAnketaPerson;
        private RegistrationPersonsControl ctrlRegistrationsPerson;
        private System.Windows.Forms.BindingSource bsRightHolder;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private System.Windows.Forms.BindingSource bsCustomer;
        private Telerik.WinControls.UI.RadLabel lblIPIExists;
    }
}
