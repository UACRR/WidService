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
            this.rRadioBtnSexFemale = new Telerik.WinControls.UI.RadRadioButton();
            this.lblSex = new Telerik.WinControls.UI.RadLabel();
            this.lblBirthDate = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxMidleName = new Telerik.WinControls.UI.RadTextBox();
            this.lblMidleName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.lblFirstName = new Telerik.WinControls.UI.RadLabel();
            this.rdtPickerBirth = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rRadioBtnSexMale = new Telerik.WinControls.UI.RadRadioButton();
            this.rtxtBoxLastName = new Telerik.WinControls.UI.RadTextBox();
            this.lblLastName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxPseudonym = new Telerik.WinControls.UI.RadTextBox();
            this.lblPseudonym = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rRadioBtnSexFemale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rRadioBtnSexMale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPseudonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPseudonym)).BeginInit();
            this.SuspendLayout();
            // 
            // rRadioBtnSexFemale
            // 
            this.rRadioBtnSexFemale.Location = new System.Drawing.Point(381, 104);
            this.rRadioBtnSexFemale.Name = "rRadioBtnSexFemale";
            this.rRadioBtnSexFemale.Size = new System.Drawing.Size(42, 18);
            this.rRadioBtnSexFemale.TabIndex = 22;
            this.rRadioBtnSexFemale.Text = "Жін.";
            this.rRadioBtnSexFemale.CheckStateChanged += new System.EventHandler(this.rRadioBtnSexFemale_CheckStateChanged);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(271, 104);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(36, 18);
            this.lblSex.TabIndex = 21;
            this.lblSex.Text = "Стать:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Location = new System.Drawing.Point(3, 105);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(101, 18);
            this.lblBirthDate.TabIndex = 20;
            this.lblBirthDate.Text = "Дата народження:";
            // 
            // rtxtBoxMidleName
            // 
            this.rtxtBoxMidleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxMidleName.Location = new System.Drawing.Point(109, 52);
            this.rtxtBoxMidleName.Name = "rtxtBoxMidleName";
            this.rtxtBoxMidleName.Size = new System.Drawing.Size(513, 20);
            this.rtxtBoxMidleName.TabIndex = 19;
            // 
            // lblMidleName
            // 
            this.lblMidleName.Location = new System.Drawing.Point(3, 51);
            this.lblMidleName.Name = "lblMidleName";
            this.lblMidleName.Size = new System.Drawing.Size(72, 18);
            this.lblMidleName.TabIndex = 18;
            this.lblMidleName.Text = "По-батькові:";
            // 
            // rtxtBoxFirstName
            // 
            this.rtxtBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxFirstName.Location = new System.Drawing.Point(109, 27);
            this.rtxtBoxFirstName.Name = "rtxtBoxFirstName";
            this.rtxtBoxFirstName.Size = new System.Drawing.Size(513, 20);
            this.rtxtBoxFirstName.TabIndex = 17;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(3, 27);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(28, 18);
            this.lblFirstName.TabIndex = 16;
            this.lblFirstName.Text = "Ім\'я:";
            // 
            // rdtPickerBirth
            // 
            this.rdtPickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerBirth.Location = new System.Drawing.Point(109, 104);
            this.rdtPickerBirth.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.rdtPickerBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.Name = "rdtPickerBirth";
            this.rdtPickerBirth.NullDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.NullText = "Оберіть дату";
            this.rdtPickerBirth.Size = new System.Drawing.Size(127, 20);
            this.rdtPickerBirth.TabIndex = 15;
            this.rdtPickerBirth.TabStop = false;
            this.rdtPickerBirth.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.ValueChanged += new System.EventHandler(this.rdtPickerBirth_ValueChanged);
            // 
            // rRadioBtnSexMale
            // 
            this.rRadioBtnSexMale.Location = new System.Drawing.Point(332, 104);
            this.rRadioBtnSexMale.Name = "rRadioBtnSexMale";
            this.rRadioBtnSexMale.Size = new System.Drawing.Size(43, 18);
            this.rRadioBtnSexMale.TabIndex = 14;
            this.rRadioBtnSexMale.Text = "Чол.";
            this.rRadioBtnSexMale.CheckStateChanged += new System.EventHandler(this.rRadioBtnSexMale_CheckStateChanged);
            // 
            // rtxtBoxLastName
            // 
            this.rtxtBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxLastName.Location = new System.Drawing.Point(109, 2);
            this.rtxtBoxLastName.Name = "rtxtBoxLastName";
            this.rtxtBoxLastName.Size = new System.Drawing.Size(513, 20);
            this.rtxtBoxLastName.TabIndex = 13;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(3, 3);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(59, 18);
            this.lblLastName.TabIndex = 12;
            this.lblLastName.Text = "Прізвище:";
            // 
            // rtxtBoxPseudonym
            // 
            this.rtxtBoxPseudonym.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxPseudonym.Location = new System.Drawing.Point(109, 78);
            this.rtxtBoxPseudonym.Name = "rtxtBoxPseudonym";
            this.rtxtBoxPseudonym.Size = new System.Drawing.Size(513, 20);
            this.rtxtBoxPseudonym.TabIndex = 24;
            // 
            // lblPseudonym
            // 
            this.lblPseudonym.AutoSize = false;
            this.lblPseudonym.Location = new System.Drawing.Point(3, 67);
            this.lblPseudonym.Name = "lblPseudonym";
            this.lblPseudonym.Size = new System.Drawing.Size(88, 38);
            this.lblPseudonym.TabIndex = 23;
            this.lblPseudonym.Text = "Псевдонім (сценічне ім\'я):";
            // 
            // AnketaPersonRightHolderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtxtBoxPseudonym);
            this.Controls.Add(this.lblPseudonym);
            this.Controls.Add(this.rRadioBtnSexFemale);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.rtxtBoxMidleName);
            this.Controls.Add(this.lblMidleName);
            this.Controls.Add(this.rtxtBoxFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.rdtPickerBirth);
            this.Controls.Add(this.rRadioBtnSexMale);
            this.Controls.Add(this.rtxtBoxLastName);
            this.Controls.Add(this.lblLastName);
            this.MaximumSize = new System.Drawing.Size(900, 128);
            this.Name = "AnketaPersonRightHolderControl";
            this.Size = new System.Drawing.Size(625, 128);
            ((System.ComponentModel.ISupportInitialize)(this.rRadioBtnSexFemale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rRadioBtnSexMale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPseudonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPseudonym)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRadioButton rRadioBtnSexFemale;
        private Telerik.WinControls.UI.RadLabel lblSex;
        private Telerik.WinControls.UI.RadLabel lblBirthDate;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMidleName;
        private Telerik.WinControls.UI.RadLabel lblMidleName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxFirstName;
        private Telerik.WinControls.UI.RadLabel lblFirstName;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerBirth;
        private Telerik.WinControls.UI.RadRadioButton rRadioBtnSexMale;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxLastName;
        private Telerik.WinControls.UI.RadLabel lblLastName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxPseudonym;
        private Telerik.WinControls.UI.RadLabel lblPseudonym;
    }
}
