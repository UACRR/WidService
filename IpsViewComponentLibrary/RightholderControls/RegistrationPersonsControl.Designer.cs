namespace IpsViewComponentLibrary.RightholderControls
{
    partial class RegistrationPersonsControl
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
            this.lblipn = new Telerik.WinControls.UI.RadLabel();
            this.txtIPN = new Telerik.WinControls.UI.RadTextBox();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.lblCitizenship = new Telerik.WinControls.UI.RadLabel();
            this.ddlCitizenship = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlResidency = new Telerik.WinControls.UI.RadDropDownList();
            this.lblResidency = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.lblINNPresent = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCitizenship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCitizenship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlResidency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResidency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblINNPresent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblipn
            // 
            this.lblipn.Location = new System.Drawing.Point(3, 3);
            this.lblipn.Name = "lblipn";
            this.lblipn.Size = new System.Drawing.Size(191, 19);
            this.lblipn.TabIndex = 0;
            this.lblipn.Text = "ІПН (якщо немає «0000000000»):";
            this.lblipn.ThemeName = "Office2013Light";
            // 
            // txtIPN
            // 
            this.txtIPN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "Inn", true));
            this.txtIPN.Location = new System.Drawing.Point(202, 2);
            this.txtIPN.MaxLength = 10;
            this.txtIPN.Name = "txtIPN";
            this.txtIPN.Size = new System.Drawing.Size(192, 21);
            this.txtIPN.TabIndex = 0;
            this.txtIPN.ThemeName = "Office2013Light";
            this.txtIPN.Leave += new System.EventHandler(this.txtIPN_Leave);
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // lblCitizenship
            // 
            this.lblCitizenship.Location = new System.Drawing.Point(3, 28);
            this.lblCitizenship.Name = "lblCitizenship";
            this.lblCitizenship.Size = new System.Drawing.Size(89, 19);
            this.lblCitizenship.TabIndex = 2;
            this.lblCitizenship.Text = "Громадянство:";
            this.lblCitizenship.ThemeName = "Office2013Light";
            // 
            // ddlCitizenship
            // 
            this.ddlCitizenship.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAnketaPerson, "Citizenship", true));
            this.ddlCitizenship.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCitizenship.Location = new System.Drawing.Point(91, 28);
            this.ddlCitizenship.Name = "ddlCitizenship";
            this.ddlCitizenship.Size = new System.Drawing.Size(105, 21);
            this.ddlCitizenship.TabIndex = 2;
            this.ddlCitizenship.ThemeName = "Office2013Light";
            // 
            // ddlResidency
            // 
            this.ddlResidency.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlResidency.Location = new System.Drawing.Point(289, 28);
            this.ddlResidency.Name = "ddlResidency";
            this.ddlResidency.Size = new System.Drawing.Size(105, 21);
            this.ddlResidency.TabIndex = 3;
            this.ddlResidency.ThemeName = "Office2013Light";
            // 
            // lblResidency
            // 
            this.lblResidency.Location = new System.Drawing.Point(202, 28);
            this.lblResidency.Name = "lblResidency";
            this.lblResidency.Size = new System.Drawing.Size(88, 19);
            this.lblResidency.TabIndex = 3;
            this.lblResidency.Text = "Резидентність:";
            this.lblResidency.ThemeName = "Office2013Light";
            // 
            // lblINNPresent
            // 
            this.lblINNPresent.ForeColor = System.Drawing.Color.Red;
            this.lblINNPresent.Location = new System.Drawing.Point(400, 4);
            this.lblINNPresent.Name = "lblINNPresent";
            this.lblINNPresent.Size = new System.Drawing.Size(77, 18);
            this.lblINNPresent.TabIndex = 4;
            this.lblINNPresent.Text = "ІПН вже існує";
            this.lblINNPresent.Visible = false;
            // 
            // RegistrationPersonsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblINNPresent);
            this.Controls.Add(this.ddlResidency);
            this.Controls.Add(this.lblResidency);
            this.Controls.Add(this.ddlCitizenship);
            this.Controls.Add(this.lblCitizenship);
            this.Controls.Add(this.txtIPN);
            this.Controls.Add(this.lblipn);
            this.Name = "RegistrationPersonsControl";
            this.Size = new System.Drawing.Size(479, 53);
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCitizenship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCitizenship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlResidency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResidency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblINNPresent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblipn;
        private Telerik.WinControls.UI.RadTextBox txtIPN;
        private Telerik.WinControls.UI.RadLabel lblCitizenship;
        private Telerik.WinControls.UI.RadDropDownList ddlCitizenship;
        private Telerik.WinControls.UI.RadDropDownList ddlResidency;
        private Telerik.WinControls.UI.RadLabel lblResidency;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadLabel lblINNPresent;
    }
}
