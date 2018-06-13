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
            this.iAnketaPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCitizenship = new Telerik.WinControls.UI.RadLabel();
            this.rDropListCitizenship = new Telerik.WinControls.UI.RadDropDownList();
            this.rDropDownListResidency = new Telerik.WinControls.UI.RadDropDownList();
            this.lblResidency = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxIPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).BeginInit();
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
            this.lblipn.Size = new System.Drawing.Size(175, 18);
            this.lblipn.TabIndex = 0;
            this.lblipn.Text = "ІПН (якщо немає «0000000000»):";
            // 
            // rtxtBoxIPN
            // 
            this.rtxtBoxIPN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "Inn", true));
            this.rtxtBoxIPN.Location = new System.Drawing.Point(202, 2);
            this.rtxtBoxIPN.MaxLength = 10;
            this.rtxtBoxIPN.Name = "rtxtBoxIPN";
            this.rtxtBoxIPN.Size = new System.Drawing.Size(192, 20);
            this.rtxtBoxIPN.TabIndex = 0;
            this.rtxtBoxIPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtBoxIPN_KeyPress);
            // 
            // iAnketaPersonBindingSource
            // 
            this.iAnketaPersonBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // lblCitizenship
            // 
            this.lblCitizenship.Location = new System.Drawing.Point(3, 28);
            this.lblCitizenship.Name = "lblCitizenship";
            this.lblCitizenship.Size = new System.Drawing.Size(82, 18);
            this.lblCitizenship.TabIndex = 2;
            this.lblCitizenship.Text = "Громадянство:";
            // 
            // rDropListCitizenship
            // 
            this.rDropListCitizenship.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.iAnketaPersonBindingSource, "Citizenship", true));
            this.rDropListCitizenship.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rDropListCitizenship.Location = new System.Drawing.Point(91, 28);
            this.rDropListCitizenship.Name = "rDropListCitizenship";
            this.rDropListCitizenship.Size = new System.Drawing.Size(105, 20);
            this.rDropListCitizenship.TabIndex = 2;
            // 
            // rDropDownListResidency
            // 
            this.rDropDownListResidency.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rDropDownListResidency.Location = new System.Drawing.Point(289, 28);
            this.rDropDownListResidency.Name = "rDropDownListResidency";
            this.rDropDownListResidency.Size = new System.Drawing.Size(105, 20);
            this.rDropDownListResidency.TabIndex = 3;
            // 
            // lblResidency
            // 
            this.lblResidency.Location = new System.Drawing.Point(202, 28);
            this.lblResidency.Name = "lblResidency";
            this.lblResidency.Size = new System.Drawing.Size(81, 18);
            this.lblResidency.TabIndex = 3;
            this.lblResidency.Text = "Резидентність:";
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
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource iAnketaPersonBindingSource;
    }
}
