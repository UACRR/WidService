namespace IpsViewComponentLibrary.RightholderControls
{
    partial class PassportInternationalControl
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
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtBoxPasportNumber = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.dtIssuedDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtValidityDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxPasportNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIssuedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidityDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 54);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(70, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Дійсний до";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 30);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(86, 19);
            this.radLabel3.TabIndex = 7;
            this.radLabel3.Text = "Коли виданий";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // txtBoxPasportNumber
            // 
            this.txtBoxPasportNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "PFnumber", true));
            this.txtBoxPasportNumber.Location = new System.Drawing.Point(98, 2);
            this.txtBoxPasportNumber.MaxLength = 0;
            this.txtBoxPasportNumber.Name = "txtBoxPasportNumber";
            this.txtBoxPasportNumber.Size = new System.Drawing.Size(276, 21);
            this.txtBoxPasportNumber.TabIndex = 6;
            this.txtBoxPasportNumber.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(45, 19);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Номер";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // dtIssuedDate
            // 
            this.dtIssuedDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAnketaPerson, "PFissuedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, new System.DateTime(1900, 1, 1, 0, 0, 0, 0)));
            this.dtIssuedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIssuedDate.Location = new System.Drawing.Point(98, 28);
            this.dtIssuedDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtIssuedDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtIssuedDate.Name = "dtIssuedDate";
            this.dtIssuedDate.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtIssuedDate.NullText = "Оберіть дату";
            this.dtIssuedDate.Size = new System.Drawing.Size(127, 21);
            this.dtIssuedDate.TabIndex = 8;
            this.dtIssuedDate.TabStop = false;
            this.dtIssuedDate.ThemeName = "Office2013Light";
            this.dtIssuedDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // dtValidityDate
            // 
            this.dtValidityDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAnketaPerson, "PFvalidity", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, new System.DateTime(1900, 1, 1, 0, 0, 0, 0)));
            this.dtValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtValidityDate.Location = new System.Drawing.Point(98, 54);
            this.dtValidityDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtValidityDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtValidityDate.Name = "dtValidityDate";
            this.dtValidityDate.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtValidityDate.NullText = "Оберіть дату";
            this.dtValidityDate.Size = new System.Drawing.Size(127, 21);
            this.dtValidityDate.TabIndex = 9;
            this.dtValidityDate.TabStop = false;
            this.dtValidityDate.ThemeName = "Office2013Light";
            this.dtValidityDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // PassportInternationalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtValidityDate);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtBoxPasportNumber);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.dtIssuedDate);
            this.Controls.Add(this.radLabel1);
            this.Name = "PassportInternationalControl";
            this.Size = new System.Drawing.Size(376, 78);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxPasportNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIssuedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidityDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtBoxPasportNumber;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDateTimePicker dtIssuedDate;
        private Telerik.WinControls.UI.RadDateTimePicker dtValidityDate;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
