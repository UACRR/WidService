using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    partial class ContractConsumerDetailControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxAuthorPaymentPercent = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtBoxMinAuthorPayment = new Telerik.WinControls.UI.RadTextBox();
            this.rCheckBoxAutoprolongation = new Telerik.WinControls.UI.RadCheckBox();
            this.bsCheckedProlongation = new System.Windows.Forms.BindingSource(this.components);
            this.txtPercentAutoProl = new Telerik.WinControls.UI.RadTextBox();
            this.rddListPeriodPayment = new Telerik.WinControls.UI.RadDropDownList();
            this.rddListTypeAutoProl = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxAuthorPaymentPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMinAuthorPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBoxAutoprolongation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheckedProlongation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentAutoProl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListPeriodPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListTypeAutoProl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(135, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Авторська винагорода";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(234, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(107, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "але не менше ніж";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(453, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(26, 19);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "грн";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(4, 78);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(141, 19);
            this.radLabel4.TabIndex = 5;
            this.radLabel4.Text = "Періодичність платежів";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // rtxtBoxAuthorPaymentPercent
            // 
            this.rtxtBoxAuthorPaymentPercent.Location = new System.Drawing.Point(145, 3);
            this.rtxtBoxAuthorPaymentPercent.Name = "rtxtBoxAuthorPaymentPercent";
            this.rtxtBoxAuthorPaymentPercent.NullText = "  %";
            this.rtxtBoxAuthorPaymentPercent.Size = new System.Drawing.Size(83, 21);
            this.rtxtBoxAuthorPaymentPercent.TabIndex = 0;
            this.rtxtBoxAuthorPaymentPercent.ThemeName = "Office2013Light";
            // 
            // rtxtBoxMinAuthorPayment
            // 
            this.rtxtBoxMinAuthorPayment.Location = new System.Drawing.Point(347, 3);
            this.rtxtBoxMinAuthorPayment.Name = "rtxtBoxMinAuthorPayment";
            this.rtxtBoxMinAuthorPayment.Size = new System.Drawing.Size(100, 21);
            this.rtxtBoxMinAuthorPayment.TabIndex = 1;
            this.rtxtBoxMinAuthorPayment.ThemeName = "Office2013Light";
            this.rtxtBoxMinAuthorPayment.TextChanged += new System.EventHandler(this.rtxtBoxMinAuthorPayment_TextChanged);
            // 
            // rCheckBoxAutoprolongation
            // 
            this.rCheckBoxAutoprolongation.DataBindings.Add(new System.Windows.Forms.Binding("IsChecked", this.bsCheckedProlongation, "IsAutoprolog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, false));
            this.rCheckBoxAutoprolongation.Location = new System.Drawing.Point(4, 28);
            this.rCheckBoxAutoprolongation.Name = "rCheckBoxAutoprolongation";
            this.rCheckBoxAutoprolongation.Size = new System.Drawing.Size(121, 19);
            this.rCheckBoxAutoprolongation.TabIndex = 2;
            this.rCheckBoxAutoprolongation.Text = "Автопролонгація";
            this.rCheckBoxAutoprolongation.ThemeName = "Office2013Light";
            this.rCheckBoxAutoprolongation.CheckStateChanged += new System.EventHandler(this.rCheckBoxAutoprolongation_CheckStateChanged);
            // 
            // bsCheckedProlongation
            // 
            this.bsCheckedProlongation.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // txtPercentAutoProl
            // 
            this.txtPercentAutoProl.Location = new System.Drawing.Point(411, 52);
            this.txtPercentAutoProl.Name = "txtPercentAutoProl";
            this.txtPercentAutoProl.Size = new System.Drawing.Size(43, 21);
            this.txtPercentAutoProl.TabIndex = 4;
            this.txtPercentAutoProl.ThemeName = "Office2013Light";
            // 
            // rddListPeriodPayment
            // 
            this.rddListPeriodPayment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.rddListPeriodPayment.Location = new System.Drawing.Point(147, 78);
            this.rddListPeriodPayment.Name = "rddListPeriodPayment";
            this.rddListPeriodPayment.Size = new System.Drawing.Size(194, 21);
            this.rddListPeriodPayment.TabIndex = 5;
            this.rddListPeriodPayment.ThemeName = "Office2013Light";
            // 
            // rddListTypeAutoProl
            // 
            this.rddListTypeAutoProl.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "з підвищенням авторської винагороди за попередній рік";
            radListDataItem2.Text = "індекс інфляції";
            this.rddListTypeAutoProl.Items.Add(radListDataItem1);
            this.rddListTypeAutoProl.Items.Add(radListDataItem2);
            this.rddListTypeAutoProl.Location = new System.Drawing.Point(4, 52);
            this.rddListTypeAutoProl.Name = "rddListTypeAutoProl";
            this.rddListTypeAutoProl.Size = new System.Drawing.Size(401, 21);
            this.rddListTypeAutoProl.TabIndex = 3;
            this.rddListTypeAutoProl.ThemeName = "Office2013Light";
            this.rddListTypeAutoProl.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rddListTypeAutoProl_SelectedIndexChanged);
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(459, 52);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(17, 19);
            this.radLabel5.TabIndex = 6;
            this.radLabel5.Text = "%";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // ContractConsumerDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.rddListTypeAutoProl);
            this.Controls.Add(this.rddListPeriodPayment);
            this.Controls.Add(this.txtPercentAutoProl);
            this.Controls.Add(this.rCheckBoxAutoprolongation);
            this.Controls.Add(this.rtxtBoxMinAuthorPayment);
            this.Controls.Add(this.rtxtBoxAuthorPaymentPercent);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(480, 105);
            this.MinimumSize = new System.Drawing.Size(480, 105);
            this.Name = "ContractConsumerDetailControl";
            this.Size = new System.Drawing.Size(480, 105);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxAuthorPaymentPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMinAuthorPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCheckBoxAutoprolongation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheckedProlongation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentAutoProl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListPeriodPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddListTypeAutoProl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxAuthorPaymentPercent;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMinAuthorPayment;
        private Telerik.WinControls.UI.RadCheckBox rCheckBoxAutoprolongation;
        private Telerik.WinControls.UI.RadTextBox txtPercentAutoProl;
        private Telerik.WinControls.UI.RadDropDownList rddListPeriodPayment;
        private Telerik.WinControls.UI.RadDropDownList rddListTypeAutoProl;
        private System.Windows.Forms.BindingSource bsCheckedProlongation;
        private Telerik.WinControls.UI.RadLabel radLabel5;
    }
}
