namespace IpsViewComponentLibrary
{
    partial class PassportControl
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
            this.rdtPickerPasportIssuedWhen = new Telerik.WinControls.UI.RadDateTimePicker();
            this.iAnketaPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxPasportSeries = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtBoxPasportNumber = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtBoxPasportIssuedWho = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerPasportIssuedWhen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPasportSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPasportNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPasportIssuedWho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // rdtPickerPasportIssuedWhen
            // 
            this.rdtPickerPasportIssuedWhen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "PUissuedWhen", true));
            this.rdtPickerPasportIssuedWhen.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iAnketaPersonBindingSource, "PUissuedWhen", true));
            this.rdtPickerPasportIssuedWhen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerPasportIssuedWhen.Location = new System.Drawing.Point(99, 71);
            this.rdtPickerPasportIssuedWhen.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.rdtPickerPasportIssuedWhen.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerPasportIssuedWhen.Name = "rdtPickerPasportIssuedWhen";
            this.rdtPickerPasportIssuedWhen.NullDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerPasportIssuedWhen.NullText = "Оберіть дату";
            this.rdtPickerPasportIssuedWhen.Size = new System.Drawing.Size(127, 20);
            this.rdtPickerPasportIssuedWhen.TabIndex = 3;
            this.rdtPickerPasportIssuedWhen.TabStop = false;
            this.rdtPickerPasportIssuedWhen.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // iAnketaPersonBindingSource
            // 
            this.iAnketaPersonBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 27);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(74, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "ким виданий";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(4, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Серія, номер:";
            // 
            // rtxtBoxPasportSeries
            // 
            this.rtxtBoxPasportSeries.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.rtxtBoxPasportSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "PUseries", true));
            this.rtxtBoxPasportSeries.Location = new System.Drawing.Point(99, 2);
            this.rtxtBoxPasportSeries.MaxLength = 2;
            this.rtxtBoxPasportSeries.Name = "rtxtBoxPasportSeries";
            this.rtxtBoxPasportSeries.Size = new System.Drawing.Size(40, 20);
            this.rtxtBoxPasportSeries.TabIndex = 0;
            // 
            // rtxtBoxPasportNumber
            // 
            this.rtxtBoxPasportNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "PUnumber", true));
            this.rtxtBoxPasportNumber.Location = new System.Drawing.Point(145, 2);
            this.rtxtBoxPasportNumber.MaxLength = 6;
            this.rtxtBoxPasportNumber.Name = "rtxtBoxPasportNumber";
            this.rtxtBoxPasportNumber.Size = new System.Drawing.Size(262, 20);
            this.rtxtBoxPasportNumber.TabIndex = 1;
            this.rtxtBoxPasportNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtBoxPasportNumber_KeyPress);
            // 
            // rtxtBoxPasportIssuedWho
            // 
            this.rtxtBoxPasportIssuedWho.AutoSize = false;
            this.rtxtBoxPasportIssuedWho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaPersonBindingSource, "PUissuedWho", true));
            this.rtxtBoxPasportIssuedWho.Location = new System.Drawing.Point(99, 26);
            this.rtxtBoxPasportIssuedWho.Multiline = true;
            this.rtxtBoxPasportIssuedWho.Name = "rtxtBoxPasportIssuedWho";
            this.rtxtBoxPasportIssuedWho.Size = new System.Drawing.Size(308, 40);
            this.rtxtBoxPasportIssuedWho.TabIndex = 2;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(4, 73);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(78, 18);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "коли виданий";
            // 
            // PassportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.rtxtBoxPasportIssuedWho);
            this.Controls.Add(this.rtxtBoxPasportNumber);
            this.Controls.Add(this.rtxtBoxPasportSeries);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.rdtPickerPasportIssuedWhen);
            this.MaximumSize = new System.Drawing.Size(410, 94);
            this.Name = "PassportControl";
            this.Size = new System.Drawing.Size(410, 94);
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerPasportIssuedWhen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPasportSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPasportNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxPasportIssuedWho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerPasportIssuedWhen;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxPasportSeries;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxPasportNumber;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxPasportIssuedWho;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.BindingSource iAnketaPersonBindingSource;
    }
}
