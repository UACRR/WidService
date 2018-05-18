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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            this.lblipn = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxIPN = new Telerik.WinControls.UI.RadTextBox();
            this.lblCitizenship = new Telerik.WinControls.UI.RadLabel();
            this.rDropListCitizenship = new Telerik.WinControls.UI.RadDropDownList();
            this.rDropDownListResidency = new Telerik.WinControls.UI.RadDropDownList();
            this.lblResidency = new Telerik.WinControls.UI.RadLabel();
            this.iAnketaPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblipn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxIPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCitizenship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropListCitizenship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownListResidency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResidency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblipn
            // 
            this.lblipn.Location = new System.Drawing.Point(3, 3);
            this.lblipn.Name = "lblipn";
            this.lblipn.Size = new System.Drawing.Size(170, 18);
            this.lblipn.TabIndex = 0;
            this.lblipn.Text = "ІПН (якщо нема «0000000000»):";
            // 
            // rtxtBoxIPN
            // 
            this.rtxtBoxIPN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "Inn", true));
            this.rtxtBoxIPN.Location = new System.Drawing.Point(174, 2);
            this.rtxtBoxIPN.MaxLength = 10;
            this.rtxtBoxIPN.Name = "rtxtBoxIPN";
            this.rtxtBoxIPN.Size = new System.Drawing.Size(220, 20);
            this.rtxtBoxIPN.TabIndex = 1;
            this.rtxtBoxIPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtBoxIPN_KeyPress);
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
            this.rDropListCitizenship.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.iAnketaPersonBindingSource, "Citizenship", true));
            this.rDropListCitizenship.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem2.Tag = "804";
            radListDataItem2.Text = "Україна";
            radListDataItem3.Tag = "null";
            radListDataItem3.Text = "не Україна";
            this.rDropListCitizenship.Items.Add(radListDataItem1);
            this.rDropListCitizenship.Items.Add(radListDataItem2);
            this.rDropListCitizenship.Items.Add(radListDataItem3);
            this.rDropListCitizenship.Location = new System.Drawing.Point(91, 28);
            this.rDropListCitizenship.Name = "rDropListCitizenship";
            this.rDropListCitizenship.Size = new System.Drawing.Size(105, 20);
            this.rDropListCitizenship.TabIndex = 3;
            this.rDropListCitizenship.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rDropListCitizenship_SelectedIndexChanged);
            // 
            // rDropDownListResidency
            // 
            this.rDropDownListResidency.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.iAnketaPersonBindingSource, "Residency", true));
            this.rDropDownListResidency.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem5.Text = "Резидент";
            radListDataItem6.Text = "Не резидент";
            this.rDropDownListResidency.Items.Add(radListDataItem4);
            this.rDropDownListResidency.Items.Add(radListDataItem5);
            this.rDropDownListResidency.Items.Add(radListDataItem6);
            this.rDropDownListResidency.Location = new System.Drawing.Point(289, 28);
            this.rDropDownListResidency.Name = "rDropDownListResidency";
            this.rDropDownListResidency.Size = new System.Drawing.Size(105, 20);
            this.rDropDownListResidency.TabIndex = 5;
            this.rDropDownListResidency.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rDropDownListResidency_SelectedIndexChanged);
            // 
            // lblResidency
            // 
            this.lblResidency.Location = new System.Drawing.Point(202, 28);
            this.lblResidency.Name = "lblResidency";
            this.lblResidency.Size = new System.Drawing.Size(81, 18);
            this.lblResidency.TabIndex = 4;
            this.lblResidency.Text = "Резидентність:";
            // 
            // iAnketaPersonBindingSource
            // 
            this.iAnketaPersonBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
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
            ((System.ComponentModel.ISupportInitialize)(this.lblCitizenship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropListCitizenship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownListResidency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResidency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).EndInit();
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
