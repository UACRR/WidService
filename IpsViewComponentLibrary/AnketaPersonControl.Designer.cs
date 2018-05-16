namespace DebugFormForControls
{
    partial class AnketaPersonControl
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
            this.lblLastName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxLastName = new Telerik.WinControls.UI.RadTextBox();
            this.iAnketaPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rdtPickerBirth = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rtxtBoxFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.lblFirstName = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxMidleName = new Telerik.WinControls.UI.RadTextBox();
            this.lblMidleName = new Telerik.WinControls.UI.RadLabel();
            this.lblBirthDate = new Telerik.WinControls.UI.RadLabel();
            this.lblSex = new Telerik.WinControls.UI.RadLabel();
            this.radDropDownListSex = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListSex)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(4, 4);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(59, 18);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Прізвище:";
            // 
            // rtxtBoxLastName
            // 
            this.rtxtBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "LastName", true));
            this.rtxtBoxLastName.Location = new System.Drawing.Point(110, 3);
            this.rtxtBoxLastName.Name = "rtxtBoxLastName";
            this.rtxtBoxLastName.Size = new System.Drawing.Size(464, 20);
            this.rtxtBoxLastName.TabIndex = 1;
            // 
            // iAnketaPersonBindingSource
            // 
            this.iAnketaPersonBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // rdtPickerBirth
            // 
            this.rdtPickerBirth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "BirthDate", true));
            this.rdtPickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerBirth.Location = new System.Drawing.Point(110, 75);
            this.rdtPickerBirth.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.rdtPickerBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.Name = "rdtPickerBirth";
            this.rdtPickerBirth.NullDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.NullText = "Оберіть дату";
            this.rdtPickerBirth.Size = new System.Drawing.Size(127, 20);
            this.rdtPickerBirth.TabIndex = 4;
            this.rdtPickerBirth.TabStop = false;
            this.rdtPickerBirth.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerBirth.ValueChanged += new System.EventHandler(this.rdtPickerBirth_ValueChanged);
            // 
            // rtxtBoxFirstName
            // 
            this.rtxtBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "FirstName", true));
            this.rtxtBoxFirstName.Location = new System.Drawing.Point(110, 27);
            this.rtxtBoxFirstName.Name = "rtxtBoxFirstName";
            this.rtxtBoxFirstName.Size = new System.Drawing.Size(464, 20);
            this.rtxtBoxFirstName.TabIndex = 6;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(4, 28);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(28, 18);
            this.lblFirstName.TabIndex = 5;
            this.lblFirstName.Text = "Ім\'я:";
            // 
            // rtxtBoxMidleName
            // 
            this.rtxtBoxMidleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxMidleName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "SurName", true));
            this.rtxtBoxMidleName.Location = new System.Drawing.Point(110, 51);
            this.rtxtBoxMidleName.Name = "rtxtBoxMidleName";
            this.rtxtBoxMidleName.Size = new System.Drawing.Size(464, 20);
            this.rtxtBoxMidleName.TabIndex = 8;
            // 
            // lblMidleName
            // 
            this.lblMidleName.Location = new System.Drawing.Point(4, 52);
            this.lblMidleName.Name = "lblMidleName";
            this.lblMidleName.Size = new System.Drawing.Size(72, 18);
            this.lblMidleName.TabIndex = 7;
            this.lblMidleName.Text = "По-батькові:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Location = new System.Drawing.Point(4, 76);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(101, 18);
            this.lblBirthDate.TabIndex = 9;
            this.lblBirthDate.Text = "Дата народження:";
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(272, 76);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(36, 18);
            this.lblSex.TabIndex = 10;
            this.lblSex.Text = "Стать:";
            // 
            // radDropDownListSex
            // 
            this.radDropDownListSex.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.iAnketaPersonBindingSource, "Sex", true));
            this.radDropDownListSex.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radDropDownListSex.Location = new System.Drawing.Point(315, 76);
            this.radDropDownListSex.Name = "radDropDownListSex";
            this.radDropDownListSex.Size = new System.Drawing.Size(125, 20);
            this.radDropDownListSex.TabIndex = 11;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.radDropDownListSex.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // AnketaPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radDropDownListSex);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.rtxtBoxMidleName);
            this.Controls.Add(this.lblMidleName);
            this.Controls.Add(this.rtxtBoxFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.rdtPickerBirth);
            this.Controls.Add(this.rtxtBoxLastName);
            this.Controls.Add(this.lblLastName);
            this.MaximumSize = new System.Drawing.Size(900, 105);
            this.Name = "AnketaPersonControl";
            this.Size = new System.Drawing.Size(577, 105);
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMidleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListSex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblLastName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxLastName;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerBirth;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxFirstName;
        private Telerik.WinControls.UI.RadLabel lblFirstName;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMidleName;
        private Telerik.WinControls.UI.RadLabel lblMidleName;
        private Telerik.WinControls.UI.RadLabel lblBirthDate;
        private Telerik.WinControls.UI.RadLabel lblSex;
        private System.Windows.Forms.BindingSource iAnketaPersonBindingSource;
        private Telerik.WinControls.UI.RadDropDownList radDropDownListSex;
    }
}
