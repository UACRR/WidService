namespace IpsViewComponentLibrary.RightholderControls.Anketa
{
    partial class AnketaPersonRightHolderControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSex = new Telerik.WinControls.UI.RadLabel();
            this.lblBirthDate = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxMidleName = new Telerik.WinControls.UI.RadTextBox();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.lblMidleName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.lblFirstName = new Telerik.WinControls.UI.RadLabel();
            this.rdtPickerBirth = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rtxtBoxLastName = new Telerik.WinControls.UI.RadTextBox();
            this.lblLastName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxPseudonym = new Telerik.WinControls.UI.RadTextBox();
            this.lblPseudonym = new Telerik.WinControls.UI.RadLabel();
            this.btnMoreSurName = new Telerik.WinControls.UI.RadButton();
            this.btnMorePseudonym = new Telerik.WinControls.UI.RadButton();
            this.ddlSexType = new Telerik.WinControls.UI.RadDropDownList();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bsCustomer = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPseudonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPseudonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoreSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMorePseudonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(271, 104);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(39, 19);
            this.lblSex.TabIndex = 9;
            this.lblSex.Text = "Стать:";
            this.lblSex.ThemeName = "Office2013Light";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Location = new System.Drawing.Point(3, 105);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(110, 19);
            this.lblBirthDate.TabIndex = 8;
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
            this.rtxtBoxMidleName.TabIndex = 4;
            this.rtxtBoxMidleName.ThemeName = "Office2013Light";
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // lblMidleName
            // 
            this.lblMidleName.Location = new System.Drawing.Point(3, 51);
            this.lblMidleName.Name = "lblMidleName";
            this.lblMidleName.Size = new System.Drawing.Size(78, 19);
            this.lblMidleName.TabIndex = 4;
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
            this.rtxtBoxFirstName.TabIndex = 2;
            this.rtxtBoxFirstName.ThemeName = "Office2013Light";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(3, 27);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(28, 18);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Ім\'я:";
            // 
            // rdtPickerBirth
            // 
            this.rdtPickerBirth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAnketaPerson, "BirthDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, new System.DateTime(1900, 1, 1, 0, 0, 0, 0)));
            this.rdtPickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerBirth.Location = new System.Drawing.Point(115, 104);
            this.rdtPickerBirth.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.rdtPickerBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.Name = "rdtPickerBirth";
            this.rdtPickerBirth.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.NullText = "Оберіть дату";
            this.rdtPickerBirth.Size = new System.Drawing.Size(122, 21);
            this.rdtPickerBirth.TabIndex = 8;
            this.rdtPickerBirth.TabStop = false;
            this.rdtPickerBirth.ThemeName = "Office2013Light";
            this.rdtPickerBirth.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.ValueChanged += new System.EventHandler(this.dtPickerBirth_ValueChanged);
            // 
            // rtxtBoxLastName
            // 
            this.rtxtBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "LastName", true));
            this.rtxtBoxLastName.Location = new System.Drawing.Point(115, 2);
            this.rtxtBoxLastName.Name = "rtxtBoxLastName";
            this.rtxtBoxLastName.Size = new System.Drawing.Size(324, 21);
            this.rtxtBoxLastName.TabIndex = 0;
            this.rtxtBoxLastName.ThemeName = "Office2013Light";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(3, 3);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 19);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Прізвище:";
            this.lblLastName.ThemeName = "Office2013Light";
            // 
            // rtxtBoxPseudonym
            // 
            this.rtxtBoxPseudonym.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxPseudonym.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "NikName", true));
            this.rtxtBoxPseudonym.Location = new System.Drawing.Point(115, 78);
            this.rtxtBoxPseudonym.Name = "rtxtBoxPseudonym";
            this.rtxtBoxPseudonym.Size = new System.Drawing.Size(324, 21);
            this.rtxtBoxPseudonym.TabIndex = 6;
            this.rtxtBoxPseudonym.ThemeName = "Office2013Light";
            // 
            // lblPseudonym
            // 
            this.lblPseudonym.AutoSize = false;
            this.lblPseudonym.Location = new System.Drawing.Point(3, 67);
            this.lblPseudonym.Name = "lblPseudonym";
            this.lblPseudonym.Size = new System.Drawing.Size(101, 38);
            this.lblPseudonym.TabIndex = 6;
            this.lblPseudonym.Text = "Псевдонім (сценічне ім\'я):";
            this.lblPseudonym.ThemeName = "Office2013Light";
            // 
            // btnMoreSurName
            // 
            this.btnMoreSurName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoreSurName.Location = new System.Drawing.Point(445, 52);
            this.btnMoreSurName.Name = "btnMoreSurName";
            this.btnMoreSurName.Size = new System.Drawing.Size(104, 20);
            this.btnMoreSurName.TabIndex = 5;
            this.btnMoreSurName.Text = "Ще, інша мова";
            this.btnMoreSurName.ThemeName = "Office2013Light";
            this.btnMoreSurName.Click += new System.EventHandler(this.btnMoreSurName_Click);
            // 
            // btnMorePseudonym
            // 
            this.btnMorePseudonym.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMorePseudonym.Location = new System.Drawing.Point(445, 78);
            this.btnMorePseudonym.Name = "btnMorePseudonym";
            this.btnMorePseudonym.Size = new System.Drawing.Size(104, 20);
            this.btnMorePseudonym.TabIndex = 7;
            this.btnMorePseudonym.Text = "Ще";
            this.btnMorePseudonym.ThemeName = "Office2013Light";
            this.btnMorePseudonym.Click += new System.EventHandler(this.btnMorePseudonym_Click);
            // 
            // ddlSexType
            // 
            this.ddlSexType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAnketaPerson, "Sex", true));
            this.ddlSexType.Location = new System.Drawing.Point(313, 105);
            this.ddlSexType.Name = "ddlSexType";
            this.ddlSexType.Size = new System.Drawing.Size(125, 21);
            this.ddlSexType.TabIndex = 9;
            this.ddlSexType.ThemeName = "Office2013Light";
            // 
            // bsCustomer
            // 
            this.bsCustomer.DataSource = typeof(ipsFormsDesign.Interfaces.ICustomer);
            // 
            // AnketaPersonRightHolderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlSexType);
            this.Controls.Add(this.btnMorePseudonym);
            this.Controls.Add(this.btnMoreSurName);
            this.Controls.Add(this.rtxtBoxPseudonym);
            this.Controls.Add(this.lblPseudonym);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.rtxtBoxMidleName);
            this.Controls.Add(this.lblMidleName);
            this.Controls.Add(this.rtxtBoxFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.rdtPickerBirth);
            this.Controls.Add(this.rtxtBoxLastName);
            this.Controls.Add(this.lblLastName);
            this.MaximumSize = new System.Drawing.Size(900, 128);
            this.Name = "AnketaPersonRightHolderControl";
            this.Size = new System.Drawing.Size(552, 128);
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPseudonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPseudonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoreSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMorePseudonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSexType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel lblSex;
        private Telerik.WinControls.UI.RadLabel lblBirthDate;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMidleName;
        private Telerik.WinControls.UI.RadLabel lblMidleName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxFirstName;
        private Telerik.WinControls.UI.RadLabel lblFirstName;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerBirth;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxLastName;
        private Telerik.WinControls.UI.RadLabel lblLastName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxPseudonym;
        private Telerik.WinControls.UI.RadLabel lblPseudonym;
        private Telerik.WinControls.UI.RadButton btnMoreSurName;
        private Telerik.WinControls.UI.RadButton btnMorePseudonym;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private Telerik.WinControls.UI.RadDropDownList ddlSexType;
        private System.Windows.Forms.BindingSource bsCustomer;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
