namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class JuridicalManagersControl
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
            this.txtOnBasicsIfHeadBoss = new Telerik.WinControls.UI.RadTextBox();
            this.bsRelEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator5 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator4 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlHeadBoss = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.ctrlBookkeeper = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.ctrlContactPerson = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOnBasicsIfHeadBoss
            // 
            this.txtOnBasicsIfHeadBoss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOnBasicsIfHeadBoss.AutoSize = false;
            this.txtOnBasicsIfHeadBoss.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRelEmployee, "RelDocument", true));
            this.txtOnBasicsIfHeadBoss.Location = new System.Drawing.Point(153, 30);
            this.txtOnBasicsIfHeadBoss.Multiline = true;
            this.txtOnBasicsIfHeadBoss.Name = "txtOnBasicsIfHeadBoss";
            this.txtOnBasicsIfHeadBoss.NullText = "(статуту, положення, довіреності, свідоцтва про реєстрацію, виписки з ЄДР)";
            this.txtOnBasicsIfHeadBoss.Size = new System.Drawing.Size(594, 20);
            this.txtOnBasicsIfHeadBoss.TabIndex = 18;
            this.txtOnBasicsIfHeadBoss.ThemeName = "Office2013Light";
            // 
            // bsRelEmployee
            // 
            this.bsRelEmployee.DataSource = typeof(ipsFormsDesign.Model.RelEmployee);
            // 
            // radLabel8
            // 
            this.radLabel8.AutoSize = false;
            this.radLabel8.Location = new System.Drawing.Point(54, 30);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(93, 20);
            this.radLabel8.TabIndex = 10;
            this.radLabel8.Text = "Діє на підставі:";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // radSeparator5
            // 
            this.radSeparator5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator5.Location = new System.Drawing.Point(141, 207);
            this.radSeparator5.Name = "radSeparator5";
            this.radSeparator5.Size = new System.Drawing.Size(595, 21);
            this.radSeparator5.TabIndex = 12;
            this.radSeparator5.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel6.Location = new System.Drawing.Point(3, 207);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(109, 21);
            this.radLabel6.TabIndex = 13;
            this.radLabel6.Text = "Контактна особа";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // radSeparator4
            // 
            this.radSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator4.Location = new System.Drawing.Point(95, 118);
            this.radSeparator4.Name = "radSeparator4";
            this.radSeparator4.Size = new System.Drawing.Size(641, 21);
            this.radSeparator4.TabIndex = 14;
            this.radSeparator4.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel5.Location = new System.Drawing.Point(3, 118);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(66, 21);
            this.radLabel5.TabIndex = 15;
            this.radLabel5.Text = "Бухгалтер";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator3.Location = new System.Drawing.Point(95, 3);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(641, 21);
            this.radSeparator3.TabIndex = 16;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel4.Location = new System.Drawing.Point(3, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(62, 21);
            this.radLabel4.TabIndex = 17;
            this.radLabel4.Text = "Керівник";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // ctrlHeadBoss
            // 
            this.ctrlHeadBoss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlHeadBoss.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlHeadBoss.Location = new System.Drawing.Point(54, 56);
            this.ctrlHeadBoss.Name = "ctrlHeadBoss";
            this.ctrlHeadBoss.OutsidePhone = false;
            this.ctrlHeadBoss.PhoneNullText = "+380## ### ## ##";
            this.ctrlHeadBoss.Size = new System.Drawing.Size(693, 56);
            this.ctrlHeadBoss.TabIndex = 19;
            // 
            // ctrlBookkeeper
            // 
            this.ctrlBookkeeper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBookkeeper.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlBookkeeper.Location = new System.Drawing.Point(54, 145);
            this.ctrlBookkeeper.Name = "ctrlBookkeeper";
            this.ctrlBookkeeper.OutsidePhone = false;
            this.ctrlBookkeeper.PhoneNullText = "+380## ### ## ##";
            this.ctrlBookkeeper.Size = new System.Drawing.Size(693, 56);
            this.ctrlBookkeeper.TabIndex = 21;
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlContactPerson.Location = new System.Drawing.Point(54, 234);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.OutsidePhone = false;
            this.ctrlContactPerson.PhoneNullText = "+380## ### ## ##";
            this.ctrlContactPerson.Size = new System.Drawing.Size(693, 56);
            this.ctrlContactPerson.TabIndex = 22;
            // 
            // JuridicalManagersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlContactPerson);
            this.Controls.Add(this.ctrlBookkeeper);
            this.Controls.Add(this.txtOnBasicsIfHeadBoss);
            this.Controls.Add(this.ctrlHeadBoss);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radSeparator5);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radSeparator4);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radSeparator3);
            this.Controls.Add(this.radLabel4);
            this.MaximumSize = new System.Drawing.Size(1200, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "JuridicalManagersControl";
            this.Size = new System.Drawing.Size(751, 300);
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox txtOnBasicsIfHeadBoss;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadSeparator radSeparator5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadSeparator radSeparator4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadSeparator radSeparator3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private IpsBossNameContactsControl ctrlHeadBoss;
        private IpsBossNameContactsControl ctrlBookkeeper;
        private IpsBossNameContactsControl ctrlContactPerson;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsRelEmployee;
    }
}
