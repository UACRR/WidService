namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class ContactsPersonControl
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
            this.lblMobPhone = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxMobPhone = new Telerik.WinControls.UI.RadTextBox();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.rtxtBoxMobPhoneSecond = new Telerik.WinControls.UI.RadTextBox();
            this.lblMobPhoneSecond = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxEmail = new Telerik.WinControls.UI.RadTextBox();
            this.lblEmail = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxHomePhone = new Telerik.WinControls.UI.RadTextBox();
            this.lblHomePhone = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMobPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMobPhoneSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobPhoneSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxHomePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHomePhone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMobPhone
            // 
            this.lblMobPhone.Location = new System.Drawing.Point(3, 3);
            this.lblMobPhone.Name = "lblMobPhone";
            this.lblMobPhone.Size = new System.Drawing.Size(123, 19);
            this.lblMobPhone.TabIndex = 0;
            this.lblMobPhone.Text = "Мобільний телефон:";
            this.lblMobPhone.ThemeName = "Office2013Light";
            // 
            // rtxtBoxMobPhone
            // 
            this.rtxtBoxMobPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "PhoneMobileMain", true));
            this.rtxtBoxMobPhone.Location = new System.Drawing.Point(122, 2);
            this.rtxtBoxMobPhone.Name = "rtxtBoxMobPhone";
            this.rtxtBoxMobPhone.Size = new System.Drawing.Size(150, 21);
            this.rtxtBoxMobPhone.TabIndex = 0;
            this.rtxtBoxMobPhone.ThemeName = "Office2013Light";
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // rtxtBoxMobPhoneSecond
            // 
            this.rtxtBoxMobPhoneSecond.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "PhoneMobileExtra", true));
            this.rtxtBoxMobPhoneSecond.Location = new System.Drawing.Point(415, 2);
            this.rtxtBoxMobPhoneSecond.Name = "rtxtBoxMobPhoneSecond";
            this.rtxtBoxMobPhoneSecond.Size = new System.Drawing.Size(150, 21);
            this.rtxtBoxMobPhoneSecond.TabIndex = 1;
            this.rtxtBoxMobPhoneSecond.ThemeName = "Office2013Light";
            // 
            // lblMobPhoneSecond
            // 
            this.lblMobPhoneSecond.Location = new System.Drawing.Point(287, 3);
            this.lblMobPhoneSecond.Name = "lblMobPhoneSecond";
            this.lblMobPhoneSecond.Size = new System.Drawing.Size(133, 19);
            this.lblMobPhoneSecond.TabIndex = 1;
            this.lblMobPhoneSecond.Text = "Мобільний телефон 2:";
            this.lblMobPhoneSecond.ThemeName = "Office2013Light";
            // 
            // rtxtBoxEmail
            // 
            this.rtxtBoxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "EMail", true));
            this.rtxtBoxEmail.Location = new System.Drawing.Point(415, 28);
            this.rtxtBoxEmail.Name = "rtxtBoxEmail";
            this.rtxtBoxEmail.Size = new System.Drawing.Size(206, 21);
            this.rtxtBoxEmail.TabIndex = 3;
            this.rtxtBoxEmail.ThemeName = "Office2013Light";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(287, 29);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(107, 19);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Елктронна пошта:";
            this.lblEmail.ThemeName = "Office2013Light";
            // 
            // rtxtBoxHomePhone
            // 
            this.rtxtBoxHomePhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "PhoneHome", true));
            this.rtxtBoxHomePhone.Location = new System.Drawing.Point(122, 28);
            this.rtxtBoxHomePhone.Name = "rtxtBoxHomePhone";
            this.rtxtBoxHomePhone.Size = new System.Drawing.Size(150, 21);
            this.rtxtBoxHomePhone.TabIndex = 2;
            this.rtxtBoxHomePhone.ThemeName = "Office2013Light";
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.Location = new System.Drawing.Point(3, 29);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(118, 19);
            this.lblHomePhone.TabIndex = 2;
            this.lblHomePhone.Text = "Домашній телефон:";
            this.lblHomePhone.ThemeName = "Office2013Light";
            // 
            // ContactsPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtxtBoxEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.rtxtBoxHomePhone);
            this.Controls.Add(this.lblHomePhone);
            this.Controls.Add(this.rtxtBoxMobPhoneSecond);
            this.Controls.Add(this.lblMobPhoneSecond);
            this.Controls.Add(this.rtxtBoxMobPhone);
            this.Controls.Add(this.lblMobPhone);
            this.MaximumSize = new System.Drawing.Size(625, 50);
            this.Name = "ContactsPersonControl";
            this.Size = new System.Drawing.Size(625, 50);
            ((System.ComponentModel.ISupportInitialize)(this.lblMobPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMobPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMobPhoneSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobPhoneSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxHomePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHomePhone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblMobPhone;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMobPhone;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMobPhoneSecond;
        private Telerik.WinControls.UI.RadLabel lblMobPhoneSecond;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxEmail;
        private Telerik.WinControls.UI.RadLabel lblEmail;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxHomePhone;
        private Telerik.WinControls.UI.RadLabel lblHomePhone;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
