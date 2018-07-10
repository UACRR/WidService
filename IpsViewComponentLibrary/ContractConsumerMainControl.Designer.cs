using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    partial class ContractConsumerMainControl
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
            this.rdtPickerAgrDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrFrom = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxContrNumber = new Telerik.WinControls.UI.RadTextBox();
            this.lblContrNumb = new Telerik.WinControls.UI.RadLabel();
            this.rdtPickerDateBegin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdtPickerDateEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblContrDoFrom = new Telerik.WinControls.UI.RadLabel();
            this.lblContrDoTo = new Telerik.WinControls.UI.RadLabel();
            this.lblContrDo = new Telerik.WinControls.UI.RadLabel();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerAgrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxContrNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rdtPickerAgrDate
            // 
            this.rdtPickerAgrDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "LicDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rdtPickerAgrDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerAgrDate.Location = new System.Drawing.Point(356, 1);
            this.rdtPickerAgrDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.rdtPickerAgrDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerAgrDate.Name = "rdtPickerAgrDate";
            this.rdtPickerAgrDate.NullText = "Оберіть дату";
            this.rdtPickerAgrDate.Size = new System.Drawing.Size(118, 21);
            this.rdtPickerAgrDate.TabIndex = 1;
            this.rdtPickerAgrDate.TabStop = false;
            this.rdtPickerAgrDate.Text = "09.07.2018";
            this.rdtPickerAgrDate.ThemeName = "Office2013Light";
            this.rdtPickerAgrDate.Value = new System.DateTime(2018, 7, 9, 17, 20, 27, 342);
            // 
            // lblContrFrom
            // 
            this.lblContrFrom.Location = new System.Drawing.Point(327, 3);
            this.lblContrFrom.Name = "lblContrFrom";
            this.lblContrFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrFrom.TabIndex = 1;
            this.lblContrFrom.Text = "від";
            this.lblContrFrom.ThemeName = "Office2013Light";
            // 
            // rtxtBoxContrNumber
            // 
            this.rtxtBoxContrNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "LicNum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.rtxtBoxContrNumber.Location = new System.Drawing.Point(169, 2);
            this.rtxtBoxContrNumber.Name = "rtxtBoxContrNumber";
            this.rtxtBoxContrNumber.NullText = "Номер договору";
            this.rtxtBoxContrNumber.Size = new System.Drawing.Size(152, 21);
            this.rtxtBoxContrNumber.TabIndex = 0;
            this.rtxtBoxContrNumber.ThemeName = "Office2013Light";
            // 
            // lblContrNumb
            // 
            this.lblContrNumb.Location = new System.Drawing.Point(3, 3);
            this.lblContrNumb.Name = "lblContrNumb";
            this.lblContrNumb.Size = new System.Drawing.Size(160, 19);
            this.lblContrNumb.TabIndex = 0;
            this.lblContrNumb.Text = "ЛІЦЕНЗІЙНИЙ ДОГОВІР №";
            this.lblContrNumb.ThemeName = "Office2013Light";
            // 
            // rdtPickerDateBegin
            // 
            this.rdtPickerDateBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "DateBegin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rdtPickerDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerDateBegin.Location = new System.Drawing.Point(169, 26);
            this.rdtPickerDateBegin.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateBegin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateBegin.Name = "rdtPickerDateBegin";
            this.rdtPickerDateBegin.NullText = "Оберіть дату";
            this.rdtPickerDateBegin.Size = new System.Drawing.Size(107, 21);
            this.rdtPickerDateBegin.TabIndex = 2;
            this.rdtPickerDateBegin.TabStop = false;
            this.rdtPickerDateBegin.Text = "09.07.2018";
            this.rdtPickerDateBegin.ThemeName = "Office2013Light";
            this.rdtPickerDateBegin.Value = new System.DateTime(2018, 7, 9, 17, 20, 27, 422);
            this.rdtPickerDateBegin.ValueChanged += new System.EventHandler(this.rdtPickerDateBegin_ValueChanged);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.rdtPickerDateBegin.GetChildAt(0))).Text = "";
            // 
            // rdtPickerDateEnd
            // 
            this.rdtPickerDateEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "DateEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rdtPickerDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rdtPickerDateEnd.Location = new System.Drawing.Point(356, 25);
            this.rdtPickerDateEnd.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.rdtPickerDateEnd.Name = "rdtPickerDateEnd";
            this.rdtPickerDateEnd.NullText = "Оберіть дату";
            this.rdtPickerDateEnd.Size = new System.Drawing.Size(118, 21);
            this.rdtPickerDateEnd.TabIndex = 3;
            this.rdtPickerDateEnd.TabStop = false;
            this.rdtPickerDateEnd.Text = "09.07.2018";
            this.rdtPickerDateEnd.ThemeName = "Office2013Light";
            this.rdtPickerDateEnd.Value = new System.DateTime(2018, 7, 9, 17, 32, 51, 0);
            // 
            // lblContrDoFrom
            // 
            this.lblContrDoFrom.Location = new System.Drawing.Point(140, 28);
            this.lblContrDoFrom.Name = "lblContrDoFrom";
            this.lblContrDoFrom.Size = new System.Drawing.Size(23, 19);
            this.lblContrDoFrom.TabIndex = 2;
            this.lblContrDoFrom.Text = "від";
            this.lblContrDoFrom.ThemeName = "Office2013Light";
            // 
            // lblContrDoTo
            // 
            this.lblContrDoTo.Location = new System.Drawing.Point(329, 27);
            this.lblContrDoTo.Name = "lblContrDoTo";
            this.lblContrDoTo.Size = new System.Drawing.Size(21, 19);
            this.lblContrDoTo.TabIndex = 3;
            this.lblContrDoTo.Text = "до";
            this.lblContrDoTo.ThemeName = "Office2013Light";
            // 
            // lblContrDo
            // 
            this.lblContrDo.Location = new System.Drawing.Point(3, 28);
            this.lblContrDo.Name = "lblContrDo";
            this.lblContrDo.Size = new System.Drawing.Size(92, 19);
            this.lblContrDo.TabIndex = 2;
            this.lblContrDo.Text = "ДІЯ ДОГОВОРУ";
            this.lblContrDo.ThemeName = "Office2013Light";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // ContractConsumerMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContrDo);
            this.Controls.Add(this.rdtPickerDateEnd);
            this.Controls.Add(this.lblContrDoTo);
            this.Controls.Add(this.rdtPickerDateBegin);
            this.Controls.Add(this.lblContrDoFrom);
            this.Controls.Add(this.rdtPickerAgrDate);
            this.Controls.Add(this.lblContrFrom);
            this.Controls.Add(this.rtxtBoxContrNumber);
            this.Controls.Add(this.lblContrNumb);
            this.MaximumSize = new System.Drawing.Size(477, 49);
            this.Name = "ContractConsumerMainControl";
            this.Size = new System.Drawing.Size(477, 49);
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerAgrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxContrNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrNumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtPickerDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDoTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerAgrDate;
        private Telerik.WinControls.UI.RadLabel lblContrFrom;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxContrNumber;
        private Telerik.WinControls.UI.RadLabel lblContrNumb;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerDateBegin;
        private Telerik.WinControls.UI.RadLabel lblContrDoFrom;
        private Telerik.WinControls.UI.RadDateTimePicker rdtPickerDateEnd;
        private Telerik.WinControls.UI.RadLabel lblContrDoTo;
        private Telerik.WinControls.UI.RadLabel lblContrDo;
        private BindingSource bindingSource;
    }
}
