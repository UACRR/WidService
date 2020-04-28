namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class IpsAnketaPersonControl
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
            this.bsSexType = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.lblSex = new Telerik.WinControls.UI.RadLabel();
            this.lblMidleName = new Telerik.WinControls.UI.RadLabel();
            this.txtFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.lblFirstName = new Telerik.WinControls.UI.RadLabel();
            this.lblLastName = new Telerik.WinControls.UI.RadLabel();
            this.lblBirthDate = new Telerik.WinControls.UI.RadLabel();
            this.txtSurName = new Telerik.WinControls.UI.RadTextBox();
            this.dtBirthDay = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtLastName = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtBoxIPN = new Telerik.WinControls.UI.RadTextBox();
            this.lblipn = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSexType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxIPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlSexType
            // 
            this.ddlSexType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAnketaPerson, "Sex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlSexType.DataSource = this.bsSexType;
            this.ddlSexType.DisplayMember = "Name";
            this.ddlSexType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlSexType.Location = new System.Drawing.Point(313, 80);
            this.ddlSexType.Name = "ddlSexType";
            this.ddlSexType.Size = new System.Drawing.Size(125, 21);
            this.ddlSexType.TabIndex = 23;
            this.ddlSexType.ThemeName = "Office2013Light";
            this.ddlSexType.ValueMember = "CodeI";
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // bsSexType
            // 
            this.bsSexType.DataSource = typeof(ipsFormsDesign.Model.SexType);
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
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "FirstName", true));
            this.txtFirstName.Location = new System.Drawing.Point(115, 27);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(324, 21);
            this.txtFirstName.TabIndex = 12;
            this.txtFirstName.ThemeName = "Office2013Light";
            this.txtFirstName.Leave += new System.EventHandler(this.Name_Leave);
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
            // txtSurName
            // 
            this.txtSurName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSurName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "SurName", true));
            this.txtSurName.Location = new System.Drawing.Point(115, 52);
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.Size = new System.Drawing.Size(324, 21);
            this.txtSurName.TabIndex = 14;
            this.txtSurName.ThemeName = "Office2013Light";
            this.txtSurName.Leave += new System.EventHandler(this.Name_Leave);
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
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "LastName", true));
            this.txtLastName.Location = new System.Drawing.Point(115, 2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(324, 21);
            this.txtLastName.TabIndex = 11;
            this.txtLastName.ThemeName = "Office2013Light";
            this.txtLastName.Leave += new System.EventHandler(this.Name_Leave);
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
            // IpsAnketaPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.rtxtBoxIPN);
            this.Controls.Add(this.lblipn);
            this.Controls.Add(this.ddlSexType);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblMidleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.txtSurName);
            this.Controls.Add(this.dtBirthDay);
            this.Controls.Add(this.txtLastName);
            this.Name = "IpsAnketaPersonControl";
            this.Size = new System.Drawing.Size(443, 131);
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSexType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox txtFirstName;
        private Telerik.WinControls.UI.RadLabel lblFirstName;
        private Telerik.WinControls.UI.RadLabel lblLastName;
        private Telerik.WinControls.UI.RadLabel lblBirthDate;
        private Telerik.WinControls.UI.RadTextBox txtSurName;
        private Telerik.WinControls.UI.RadDateTimePicker dtBirthDay;
        private Telerik.WinControls.UI.RadTextBox txtLastName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxIPN;
        private Telerik.WinControls.UI.RadLabel lblipn;
        private System.Windows.Forms.BindingSource bsSexType;
    }
}
