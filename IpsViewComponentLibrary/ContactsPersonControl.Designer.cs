namespace DebugFormForControls
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
            this.iAnketaPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rtxtBoxMobPhoneSecond = new Telerik.WinControls.UI.RadTextBox();
            this.lblMobPhoneSecond = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxEmail = new Telerik.WinControls.UI.RadTextBox();
            this.lblEmail = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxHomePhone = new Telerik.WinControls.UI.RadTextBox();
            this.lblHomePhone = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMobPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).BeginInit();
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
            this.lblMobPhone.Size = new System.Drawing.Size(113, 18);
            this.lblMobPhone.TabIndex = 0;
            this.lblMobPhone.Text = "Мобільний телефон:";
            // 
            // rtxtBoxMobPhone
            // 
            this.rtxtBoxMobPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "PhoneMobileMain", true));
            this.rtxtBoxMobPhone.Location = new System.Drawing.Point(122, 2);
            this.rtxtBoxMobPhone.Name = "rtxtBoxMobPhone";
            this.rtxtBoxMobPhone.Size = new System.Drawing.Size(150, 20);
            this.rtxtBoxMobPhone.TabIndex = 0;
            // 
            // iAnketaPersonBindingSource
            // 
            this.iAnketaPersonBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // rtxtBoxMobPhoneSecond
            // 
            this.rtxtBoxMobPhoneSecond.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "PhoneMobileExtra", true));
            this.rtxtBoxMobPhoneSecond.Location = new System.Drawing.Point(415, 2);
            this.rtxtBoxMobPhoneSecond.Name = "rtxtBoxMobPhoneSecond";
            this.rtxtBoxMobPhoneSecond.Size = new System.Drawing.Size(150, 20);
            this.rtxtBoxMobPhoneSecond.TabIndex = 1;
            // 
            // lblMobPhoneSecond
            // 
            this.lblMobPhoneSecond.Location = new System.Drawing.Point(287, 3);
            this.lblMobPhoneSecond.Name = "lblMobPhoneSecond";
            this.lblMobPhoneSecond.Size = new System.Drawing.Size(122, 18);
            this.lblMobPhoneSecond.TabIndex = 1;
            this.lblMobPhoneSecond.Text = "Мобільний телефон 2:";
            // 
            // rtxtBoxEmail
            // 
            this.rtxtBoxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "EMail", true));
            this.rtxtBoxEmail.Location = new System.Drawing.Point(415, 28);
            this.rtxtBoxEmail.Name = "rtxtBoxEmail";
            this.rtxtBoxEmail.Size = new System.Drawing.Size(206, 20);
            this.rtxtBoxEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(287, 29);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(98, 18);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Елктронна пошта:";
            // 
            // rtxtBoxHomePhone
            // 
            this.rtxtBoxHomePhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "PhoneHome", true));
            this.rtxtBoxHomePhone.Location = new System.Drawing.Point(122, 28);
            this.rtxtBoxHomePhone.Name = "rtxtBoxHomePhone";
            this.rtxtBoxHomePhone.Size = new System.Drawing.Size(150, 20);
            this.rtxtBoxHomePhone.TabIndex = 2;
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.Location = new System.Drawing.Point(3, 29);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(108, 18);
            this.lblHomePhone.TabIndex = 2;
            this.lblHomePhone.Text = "Домашній телефон:";
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
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource iAnketaPersonBindingSource;
    }
}
