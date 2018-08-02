namespace IpsViewComponentLibrary
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
            this.rtxtBoxIPN = new Telerik.WinControls.UI.RadTextBox();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.lblCitizenship = new Telerik.WinControls.UI.RadLabel();
            this.rDropListCitizenship = new Telerik.WinControls.UI.RadDropDownList();
            this.rDropDownListResidency = new Telerik.WinControls.UI.RadDropDownList();
            this.lblResidency = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxIPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCitizenship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropListCitizenship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownListResidency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResidency)).BeginInit();
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
            // rtxtBoxIPN
            // 
            this.rtxtBoxIPN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "Inn", true));
            this.rtxtBoxIPN.Location = new System.Drawing.Point(202, 2);
            this.rtxtBoxIPN.MaxLength = 10;
            this.rtxtBoxIPN.Name = "rtxtBoxIPN";
            this.rtxtBoxIPN.Size = new System.Drawing.Size(192, 21);
            this.rtxtBoxIPN.TabIndex = 0;
            this.rtxtBoxIPN.ThemeName = "Office2013Light";
            this.rtxtBoxIPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtBoxIPN_KeyPress);
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
            // rDropListCitizenship
            // 
            this.rDropListCitizenship.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAnketaPerson, "Citizenship", true));
            this.rDropListCitizenship.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rDropListCitizenship.Location = new System.Drawing.Point(91, 28);
            this.rDropListCitizenship.Name = "rDropListCitizenship";
            this.rDropListCitizenship.Size = new System.Drawing.Size(105, 21);
            this.rDropListCitizenship.TabIndex = 2;
            this.rDropListCitizenship.ThemeName = "Office2013Light";
            // 
            // rDropDownListResidency
            // 
            this.rDropDownListResidency.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rDropDownListResidency.Location = new System.Drawing.Point(289, 28);
            this.rDropDownListResidency.Name = "rDropDownListResidency";
            this.rDropDownListResidency.Size = new System.Drawing.Size(105, 21);
            this.rDropDownListResidency.TabIndex = 3;
            this.rDropDownListResidency.ThemeName = "Office2013Light";
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
            // RegistrationPersonsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rDropDownListResidency);
            this.Controls.Add(this.lblResidency);
            this.Controls.Add(this.rDropListCitizenship);
            this.Controls.Add(this.lblCitizenship);
            this.Controls.Add(this.rtxtBoxIPN);
            this.Controls.Add(this.lblipn);
            this.Name = "RegistrationPersonsControl";
            this.Size = new System.Drawing.Size(397, 53);
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxIPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCitizenship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropListCitizenship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownListResidency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResidency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblipn;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxIPN;
        private Telerik.WinControls.UI.RadLabel lblCitizenship;
        private Telerik.WinControls.UI.RadDropDownList rDropListCitizenship;
        private Telerik.WinControls.UI.RadDropDownList rDropDownListResidency;
        private Telerik.WinControls.UI.RadLabel lblResidency;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
