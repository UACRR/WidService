namespace DebugFormForControls
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
            this.lblMidleName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.lblFirstName = new Telerik.WinControls.UI.RadLabel();
            this.rdtPickerBirth = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rtxtBoxLastName = new Telerik.WinControls.UI.RadTextBox();
            this.lblLastName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxPseudonym = new Telerik.WinControls.UI.RadTextBox();
            this.lblPseudonym = new Telerik.WinControls.UI.RadLabel();
            this.rBtnMoreLastName = new Telerik.WinControls.UI.RadButton();
            this.rBtnMoreName = new Telerik.WinControls.UI.RadButton();
            this.rBtnMoreSurName = new Telerik.WinControls.UI.RadButton();
            this.rBtnMorePseudonym = new Telerik.WinControls.UI.RadButton();
            this.radDropDownListSex = new Telerik.WinControls.UI.RadDropDownList();
            this.iAnketaPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPseudonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPseudonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMoreLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMoreName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMoreSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMorePseudonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(271, 104);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(36, 18);
            this.lblSex.TabIndex = 9;
            this.lblSex.Text = "Стать:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Location = new System.Drawing.Point(3, 105);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(101, 18);
            this.lblBirthDate.TabIndex = 8;
            this.lblBirthDate.Text = "Дата народження:";
            // 
            // rtxtBoxMidleName
            // 
            this.rtxtBoxMidleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxMidleName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "SurName", true));
            this.rtxtBoxMidleName.Location = new System.Drawing.Point(115, 52);
            this.rtxtBoxMidleName.Name = "rtxtBoxMidleName";
            this.rtxtBoxMidleName.Size = new System.Drawing.Size(434, 20);
            this.rtxtBoxMidleName.TabIndex = 4;
            // 
            // lblMidleName
            // 
            this.lblMidleName.Location = new System.Drawing.Point(3, 51);
            this.lblMidleName.Name = "lblMidleName";
            this.lblMidleName.Size = new System.Drawing.Size(72, 18);
            this.lblMidleName.TabIndex = 4;
            this.lblMidleName.Text = "По-батькові:";
            // 
            // rtxtBoxFirstName
            // 
            this.rtxtBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "FirstName", true));
            this.rtxtBoxFirstName.Location = new System.Drawing.Point(115, 27);
            this.rtxtBoxFirstName.Name = "rtxtBoxFirstName";
            this.rtxtBoxFirstName.Size = new System.Drawing.Size(434, 20);
            this.rtxtBoxFirstName.TabIndex = 2;
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
            this.rdtPickerBirth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iAnketaPersonBindingSource, "BirthDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, new System.DateTime(1900, 1, 1, 0, 0, 0, 0)));
            this.rdtPickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerBirth.Location = new System.Drawing.Point(115, 104);
            this.rdtPickerBirth.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.rdtPickerBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.Name = "rdtPickerBirth";
            this.rdtPickerBirth.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.NullText = "Оберіть дату";
            this.rdtPickerBirth.Size = new System.Drawing.Size(122, 20);
            this.rdtPickerBirth.TabIndex = 8;
            this.rdtPickerBirth.TabStop = false;
            this.rdtPickerBirth.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.ValueChanged += new System.EventHandler(this.rdtPickerBirth_ValueChanged);
            // 
            // rtxtBoxLastName
            // 
            this.rtxtBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "LastName", true));
            this.rtxtBoxLastName.Location = new System.Drawing.Point(115, 2);
            this.rtxtBoxLastName.Name = "rtxtBoxLastName";
            this.rtxtBoxLastName.Size = new System.Drawing.Size(434, 20);
            this.rtxtBoxLastName.TabIndex = 0;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(3, 3);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(59, 18);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Прізвище:";
            // 
            // rtxtBoxPseudonym
            // 
            this.rtxtBoxPseudonym.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxPseudonym.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "NikName", true));
            this.rtxtBoxPseudonym.Location = new System.Drawing.Point(115, 78);
            this.rtxtBoxPseudonym.Name = "rtxtBoxPseudonym";
            this.rtxtBoxPseudonym.Size = new System.Drawing.Size(434, 20);
            this.rtxtBoxPseudonym.TabIndex = 6;
            // 
            // lblPseudonym
            // 
            this.lblPseudonym.AutoSize = false;
            this.lblPseudonym.Location = new System.Drawing.Point(3, 67);
            this.lblPseudonym.Name = "lblPseudonym";
            this.lblPseudonym.Size = new System.Drawing.Size(101, 38);
            this.lblPseudonym.TabIndex = 6;
            this.lblPseudonym.Text = "Псевдонім (сценічне ім\'я):";
            // 
            // rBtnMoreLastName
            // 
            this.rBtnMoreLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnMoreLastName.Location = new System.Drawing.Point(555, 2);
            this.rBtnMoreLastName.Name = "rBtnMoreLastName";
            this.rBtnMoreLastName.Size = new System.Drawing.Size(87, 20);
            this.rBtnMoreLastName.TabIndex = 1;
            this.rBtnMoreLastName.Text = "Ще, інша мова";
            this.rBtnMoreLastName.Click += new System.EventHandler(this.rBtnMoreLastName_Click);
            // 
            // rBtnMoreName
            // 
            this.rBtnMoreName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnMoreName.Location = new System.Drawing.Point(555, 27);
            this.rBtnMoreName.Name = "rBtnMoreName";
            this.rBtnMoreName.Size = new System.Drawing.Size(87, 20);
            this.rBtnMoreName.TabIndex = 3;
            this.rBtnMoreName.Text = "Ще, інша мова";
            this.rBtnMoreName.Click += new System.EventHandler(this.rBtnMoreName_Click);
            // 
            // rBtnMoreSurName
            // 
            this.rBtnMoreSurName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnMoreSurName.Location = new System.Drawing.Point(555, 52);
            this.rBtnMoreSurName.Name = "rBtnMoreSurName";
            this.rBtnMoreSurName.Size = new System.Drawing.Size(87, 20);
            this.rBtnMoreSurName.TabIndex = 5;
            this.rBtnMoreSurName.Text = "Ще, інша мова";
            this.rBtnMoreSurName.Click += new System.EventHandler(this.rBtnMoreSurName_Click);
            // 
            // rBtnMorePseudonym
            // 
            this.rBtnMorePseudonym.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnMorePseudonym.Location = new System.Drawing.Point(555, 78);
            this.rBtnMorePseudonym.Name = "rBtnMorePseudonym";
            this.rBtnMorePseudonym.Size = new System.Drawing.Size(87, 20);
            this.rBtnMorePseudonym.TabIndex = 7;
            this.rBtnMorePseudonym.Text = "Ще, інша мова";
            this.rBtnMorePseudonym.Click += new System.EventHandler(this.rBtnMorePseudonym_Click);
            // 
            // radDropDownListSex
            // 
            this.radDropDownListSex.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.iAnketaPersonBindingSource, "Sex", true));
            this.radDropDownListSex.Location = new System.Drawing.Point(313, 105);
            this.radDropDownListSex.Name = "radDropDownListSex";
            this.radDropDownListSex.Size = new System.Drawing.Size(125, 20);
            this.radDropDownListSex.TabIndex = 9;
            // 
            // iAnketaPersonBindingSource
            // 
            this.iAnketaPersonBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // AnketaPersonRightHolderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radDropDownListSex);
            this.Controls.Add(this.rBtnMorePseudonym);
            this.Controls.Add(this.rBtnMoreSurName);
            this.Controls.Add(this.rBtnMoreName);
            this.Controls.Add(this.rBtnMoreLastName);
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
            this.Size = new System.Drawing.Size(645, 128);
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPseudonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPseudonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMoreLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMoreName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMoreSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnMorePseudonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).EndInit();
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
        private Telerik.WinControls.UI.RadButton rBtnMoreLastName;
        private Telerik.WinControls.UI.RadButton rBtnMoreName;
        private Telerik.WinControls.UI.RadButton rBtnMoreSurName;
        private Telerik.WinControls.UI.RadButton rBtnMorePseudonym;
        private System.Windows.Forms.BindingSource iAnketaPersonBindingSource;
        private Telerik.WinControls.UI.RadDropDownList radDropDownListSex;
    }
}
