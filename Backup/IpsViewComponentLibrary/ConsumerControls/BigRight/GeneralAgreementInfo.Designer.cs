using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    partial class GeneralAgreementInfo
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtClient = new Telerik.WinControls.UI.RadTextBox();
            this.bsAgreementAddBR = new System.Windows.Forms.BindingSource(this.components);
            this.txtAgrNumberBr = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDateBegin = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtAvance = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtBorg = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtDateEnd = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.txtState = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtDateLastPay = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.txtAgent = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumberBr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateLastPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(72, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Користувач";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // txtClient
            // 
            this.txtClient.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "Name", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtClient.Enabled = false;
            this.txtClient.Location = new System.Drawing.Point(82, 3);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(390, 21);
            this.txtClient.TabIndex = 1;
            this.txtClient.ThemeName = "Office2013Light";
            // 
            // bsAgreementAddBR
            // 
            this.bsAgreementAddBR.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            // 
            // txtAgrNumberBr
            // 
            this.txtAgrNumberBr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "AgrNumber", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtAgrNumberBr.Enabled = false;
            this.txtAgrNumberBr.Location = new System.Drawing.Point(563, 3);
            this.txtAgrNumberBr.Name = "txtAgrNumberBr";
            this.txtAgrNumberBr.ReadOnly = true;
            this.txtAgrNumberBr.Size = new System.Drawing.Size(139, 21);
            this.txtAgrNumberBr.TabIndex = 3;
            this.txtAgrNumberBr.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(478, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(79, 19);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "№ Договору";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // txtDateBegin
            // 
            this.txtDateBegin.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "DateBegin", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtDateBegin.Enabled = false;
            this.txtDateBegin.Location = new System.Drawing.Point(84, 29);
            this.txtDateBegin.Name = "txtDateBegin";
            this.txtDateBegin.ReadOnly = true;
            this.txtDateBegin.Size = new System.Drawing.Size(70, 21);
            this.txtDateBegin.TabIndex = 5;
            this.txtDateBegin.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(4, 30);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(81, 19);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Дата початку";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // txtAvance
            // 
            this.txtAvance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "PrePayRest", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtAvance.Enabled = false;
            this.txtAvance.Location = new System.Drawing.Point(603, 29);
            this.txtAvance.Name = "txtAvance";
            this.txtAvance.ReadOnly = true;
            this.txtAvance.Size = new System.Drawing.Size(99, 21);
            this.txtAvance.TabIndex = 7;
            this.txtAvance.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(560, 30);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(40, 19);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Аванс";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // txtBorg
            // 
            this.txtBorg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "Borg", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtBorg.Enabled = false;
            this.txtBorg.Location = new System.Drawing.Point(444, 29);
            this.txtBorg.Name = "txtBorg";
            this.txtBorg.ReadOnly = true;
            this.txtBorg.Size = new System.Drawing.Size(110, 21);
            this.txtBorg.TabIndex = 9;
            this.txtBorg.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(352, 29);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(93, 19);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "Заборгованість";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "DateEnd", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtDateEnd.Enabled = false;
            this.txtDateEnd.Location = new System.Drawing.Point(227, 29);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.ReadOnly = true;
            this.txtDateEnd.Size = new System.Drawing.Size(70, 21);
            this.txtDateEnd.TabIndex = 11;
            this.txtDateEnd.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(160, 29);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(66, 19);
            this.radLabel6.TabIndex = 10;
            this.radLabel6.Text = "Дата кінця";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // txtState
            // 
            this.txtState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "StatusName", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtState.Enabled = false;
            this.txtState.Location = new System.Drawing.Point(40, 55);
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(137, 21);
            this.txtState.TabIndex = 13;
            this.txtState.ThemeName = "Office2013Light";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(4, 56);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(33, 19);
            this.radLabel7.TabIndex = 12;
            this.radLabel7.Text = "Стан";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // txtDateLastPay
            // 
            this.txtDateLastPay.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "DatePayLast", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtDateLastPay.Enabled = false;
            this.txtDateLastPay.Location = new System.Drawing.Point(312, 55);
            this.txtDateLastPay.Name = "txtDateLastPay";
            this.txtDateLastPay.ReadOnly = true;
            this.txtDateLastPay.Size = new System.Drawing.Size(70, 21);
            this.txtDateLastPay.TabIndex = 15;
            this.txtDateLastPay.ThemeName = "Office2013Light";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(183, 56);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(134, 19);
            this.radLabel8.TabIndex = 14;
            this.radLabel8.Text = "Дата останньої оплати";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // txtAgent
            // 
            this.txtAgent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "PartnerName", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtAgent.Enabled = false;
            this.txtAgent.Location = new System.Drawing.Point(467, 55);
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.ReadOnly = true;
            this.txtAgent.Size = new System.Drawing.Size(235, 21);
            this.txtAgent.TabIndex = 17;
            this.txtAgent.ThemeName = "Office2013Light";
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(388, 56);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(80, 19);
            this.radLabel9.TabIndex = 16;
            this.radLabel9.Text = "Представник";
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // GeneralAgreementInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAgent);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.txtDateLastPay);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.txtDateEnd);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.txtBorg);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txtAvance);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtDateBegin);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtAgrNumberBr);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(705, 79);
            this.MinimumSize = new System.Drawing.Size(705, 79);
            this.Name = "GeneralAgreementInfo";
            this.Size = new System.Drawing.Size(705, 79);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrNumberBr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateLastPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtClient;
        private Telerik.WinControls.UI.RadTextBox txtAgrNumberBr;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtDateBegin;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtAvance;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtBorg;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtDateEnd;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTextBox txtState;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadTextBox txtDateLastPay;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadTextBox txtAgent;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private System.Windows.Forms.BindingSource bsAgreementAddBR;
    }
}
