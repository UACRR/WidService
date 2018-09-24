namespace IpsViewComponentLibrary.PartnerControls
{
    partial class PartnerNameControl
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
            this.ddlSexType = new Telerik.WinControls.UI.RadDropDownList();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.lblSex = new Telerik.WinControls.UI.RadLabel();
            this.lblMidleName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.lblFirstName = new Telerik.WinControls.UI.RadLabel();
            this.lblLastName = new Telerik.WinControls.UI.RadLabel();
            this.lblBirthDate = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxMidleName = new Telerik.WinControls.UI.RadTextBox();
            this.dtBirthDay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rtxtBoxLastName = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtBoxIPN = new Telerik.WinControls.UI.RadTextBox();
            this.lblipn = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxIPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlSexType
            // 
            this.ddlSexType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAnketaPerson, "Sex", true));
            this.ddlSexType.Location = new System.Drawing.Point(313, 80);
            this.ddlSexType.Name = "ddlSexType";
            this.ddlSexType.Size = new System.Drawing.Size(125, 21);
            this.ddlSexType.TabIndex = 23;
            this.ddlSexType.ThemeName = "Office2013Light";
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(271, 79);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(39, 19);
            this.lblSex.TabIndex = 22;
            this.lblSex.Text = "Стать:";
            this.lblSex.ThemeName = "Office2013Light";
            // 
            // lblMidleName
            // 
            this.lblMidleName.Location = new System.Drawing.Point(3, 53);
            this.lblMidleName.Name = "lblMidleName";
            this.lblMidleName.Size = new System.Drawing.Size(78, 19);
            this.lblMidleName.TabIndex = 15;
            this.lblMidleName.Text = "По-батькові:";
            this.lblMidleName.ThemeName = "Office2013Light";
            // 
            // rtxtBoxFirstName
            // 
            this.rtxtBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "FirstName", true));
            this.rtxtBoxFirstName.Location = new System.Drawing.Point(115, 27);
            this.rtxtBoxFirstName.Name = "rtxtBoxFirstName";
            this.rtxtBoxFirstName.Size = new System.Drawing.Size(324, 21);
            this.rtxtBoxFirstName.TabIndex = 12;
            this.rtxtBoxFirstName.ThemeName = "Office2013Light";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(3, 29);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(28, 18);
            this.lblFirstName.TabIndex = 13;
            this.lblFirstName.Text = "Ім\'я:";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(3, 3);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 19);
            this.lblLastName.TabIndex = 10;
            this.lblLastName.Text = "Прізвище:";
            this.lblLastName.ThemeName = "Office2013Light";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Location = new System.Drawing.Point(3, 80);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(110, 19);
            this.lblBirthDate.TabIndex = 21;
            this.lblBirthDate.Text = "Дата народження:";
            this.lblBirthDate.ThemeName = "Office2013Light";
            // 
            // rtxtBoxMidleName
            // 
            this.rtxtBoxMidleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxMidleName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "SurName", true));
            this.rtxtBoxMidleName.Location = new System.Drawing.Point(115, 52);
            this.rtxtBoxMidleName.Name = "rtxtBoxMidleName";
            this.rtxtBoxMidleName.Size = new System.Drawing.Size(324, 21);
            this.rtxtBoxMidleName.TabIndex = 14;
            this.rtxtBoxMidleName.ThemeName = "Office2013Light";
            // 
            // dtBirthDay
            // 
            this.dtBirthDay.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAnketaPerson, "BirthDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, new System.DateTime(1900, 1, 1, 0, 0, 0, 0)));
            this.dtBirthDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBirthDay.Location = new System.Drawing.Point(115, 79);
            this.dtBirthDay.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtBirthDay.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBirthDay.Name = "dtBirthDay";
            this.dtBirthDay.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBirthDay.NullText = "Оберіть дату";
            this.dtBirthDay.Size = new System.Drawing.Size(122, 21);
            this.dtBirthDay.TabIndex = 20;
            this.dtBirthDay.TabStop = false;
            this.dtBirthDay.ThemeName = "Office2013Light";
            this.dtBirthDay.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // rtxtBoxLastName
            // 
            this.rtxtBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "LastName", true));
            this.rtxtBoxLastName.Location = new System.Drawing.Point(115, 2);
            this.rtxtBoxLastName.Name = "rtxtBoxLastName";
            this.rtxtBoxLastName.Size = new System.Drawing.Size(324, 21);
            this.rtxtBoxLastName.TabIndex = 11;
            this.rtxtBoxLastName.ThemeName = "Office2013Light";
            // 
            // rtxtBoxIPN
            // 
            this.rtxtBoxIPN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "Inn", true));
            this.rtxtBoxIPN.Location = new System.Drawing.Point(202, 105);
            this.rtxtBoxIPN.MaxLength = 10;
            this.rtxtBoxIPN.Name = "rtxtBoxIPN";
            this.rtxtBoxIPN.Size = new System.Drawing.Size(236, 21);
            this.rtxtBoxIPN.TabIndex = 24;
            this.rtxtBoxIPN.ThemeName = "Office2013Light";
            // 
            // lblipn
            // 
            this.lblipn.Location = new System.Drawing.Point(3, 106);
            this.lblipn.Name = "lblipn";
            this.lblipn.Size = new System.Drawing.Size(191, 19);
            this.lblipn.TabIndex = 25;
            this.lblipn.Text = "ІПН (якщо немає «0000000000»):";
            this.lblipn.ThemeName = "Office2013Light";
            // 
            // PartnerNameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtxtBoxIPN);
            this.Controls.Add(this.lblipn);
            this.Controls.Add(this.ddlSexType);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblMidleName);
            this.Controls.Add(this.rtxtBoxFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.rtxtBoxMidleName);
            this.Controls.Add(this.dtBirthDay);
            this.Controls.Add(this.rtxtBoxLastName);
            this.Name = "PartnerNameControl";
            this.Size = new System.Drawing.Size(443, 131);
            this.Load += new System.EventHandler(this.PartnerNameControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxIPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadDropDownList ddlSexType;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadLabel lblSex;
        private Telerik.WinControls.UI.RadLabel lblMidleName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxFirstName;
        private Telerik.WinControls.UI.RadLabel lblFirstName;
        private Telerik.WinControls.UI.RadLabel lblLastName;
        private Telerik.WinControls.UI.RadLabel lblBirthDate;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMidleName;
        private Telerik.WinControls.UI.RadDateTimePicker dtBirthDay;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxLastName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxIPN;
        private Telerik.WinControls.UI.RadLabel lblipn;
    }
}
