namespace IpsViewComponentLibrary.Shared.Controls
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
            this.dtPasportIssuedWhen = new Telerik.WinControls.UI.RadDateTimePicker();
            this.bsAnketaPerson = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtPasportSeries = new Telerik.WinControls.UI.RadTextBox();
            this.txtPasportNumber = new Telerik.WinControls.UI.RadTextBox();
            this.txtPasportIssuedWho = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.dtPasportIssuedWhen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasportSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasportNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasportIssuedWho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPasportIssuedWhen
            // 
            this.dtPasportIssuedWhen.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAnketaPerson, "PUissuedWhen", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, new System.DateTime(1900, 1, 1, 0, 0, 0, 0)));
            this.dtPasportIssuedWhen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPasportIssuedWhen.Location = new System.Drawing.Point(99, 71);
            this.dtPasportIssuedWhen.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtPasportIssuedWhen.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtPasportIssuedWhen.Name = "dtPasportIssuedWhen";
            this.dtPasportIssuedWhen.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtPasportIssuedWhen.NullText = "Оберіть дату";
            this.dtPasportIssuedWhen.Size = new System.Drawing.Size(127, 21);
            this.dtPasportIssuedWhen.TabIndex = 3;
            this.dtPasportIssuedWhen.TabStop = false;
            this.dtPasportIssuedWhen.ThemeName = "Office2013Light";
            this.dtPasportIssuedWhen.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // bsAnketaPerson
            // 
            this.bsAnketaPerson.DataSource = typeof(ipsFormsDesign.Model.AnketaPerson);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 27);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(80, 19);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "ким виданий";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(4, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(83, 19);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Серія, номер:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // txtPasportSeries
            // 
            this.txtPasportSeries.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPasportSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "PUseries", true));
            this.txtPasportSeries.Location = new System.Drawing.Point(99, 2);
            this.txtPasportSeries.MaxLength = 2;
            this.txtPasportSeries.Name = "txtPasportSeries";
            this.txtPasportSeries.Size = new System.Drawing.Size(40, 21);
            this.txtPasportSeries.TabIndex = 0;
            this.txtPasportSeries.ThemeName = "Office2013Light";
            // 
            // txtPasportNumber
            // 
            this.txtPasportNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "PUnumber", true));
            this.txtPasportNumber.Location = new System.Drawing.Point(145, 2);
            this.txtPasportNumber.MaxLength = 254;
            this.txtPasportNumber.Name = "txtPasportNumber";
            this.txtPasportNumber.Size = new System.Drawing.Size(262, 21);
            this.txtPasportNumber.TabIndex = 1;
            this.txtPasportNumber.ThemeName = "Office2013Light";
            // 
            // txtPasportIssuedWho
            // 
            this.txtPasportIssuedWho.AutoSize = false;
            this.txtPasportIssuedWho.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAnketaPerson, "PUissuedWho", true));
            this.txtPasportIssuedWho.Location = new System.Drawing.Point(99, 26);
            this.txtPasportIssuedWho.MaxLength = 254;
            this.txtPasportIssuedWho.Multiline = true;
            this.txtPasportIssuedWho.Name = "txtPasportIssuedWho";
            this.txtPasportIssuedWho.Size = new System.Drawing.Size(308, 40);
            this.txtPasportIssuedWho.TabIndex = 2;
            this.txtPasportIssuedWho.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(4, 73);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(85, 19);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "коли виданий";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // PassportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtPasportIssuedWho);
            this.Controls.Add(this.txtPasportNumber);
            this.Controls.Add(this.txtPasportSeries);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dtPasportIssuedWhen);
            this.MaximumSize = new System.Drawing.Size(410, 94);
            this.Name = "PassportControl";
            this.Size = new System.Drawing.Size(410, 94);
            ((System.ComponentModel.ISupportInitialize)(this.dtPasportIssuedWhen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasportSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasportNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasportIssuedWho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDateTimePicker dtPasportIssuedWhen;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtPasportSeries;
        private Telerik.WinControls.UI.RadTextBox txtPasportNumber;
        private Telerik.WinControls.UI.RadTextBox txtPasportIssuedWho;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.BindingSource bsAnketaPerson;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
