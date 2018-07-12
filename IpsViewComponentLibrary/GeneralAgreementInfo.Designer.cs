namespace IpsViewComponentLibrary
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
            this.bsAgreementAddBR = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBR)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(38, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Клієнт";
            // 
            // txtClient
            // 
            this.txtClient.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "Name", true));
            this.txtClient.Location = new System.Drawing.Point(48, 3);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(424, 20);
            this.txtClient.TabIndex = 1;
            // 
            // txtAgrNumberBr
            // 
            this.txtAgrNumberBr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "AgrNumber", true));
            this.txtAgrNumberBr.Location = new System.Drawing.Point(578, 3);
            this.txtAgrNumberBr.Name = "txtAgrNumberBr";
            this.txtAgrNumberBr.ReadOnly = true;
            this.txtAgrNumberBr.Size = new System.Drawing.Size(124, 20);
            this.txtAgrNumberBr.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(478, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(94, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "№ Ген. договору";
            // 
            // txtDateBegin
            // 
            this.txtDateBegin.Location = new System.Drawing.Point(84, 29);
            this.txtDateBegin.Name = "txtDateBegin";
            this.txtDateBegin.ReadOnly = true;
            this.txtDateBegin.Size = new System.Drawing.Size(70, 20);
            this.txtDateBegin.TabIndex = 5;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(4, 30);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(74, 18);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Дата початку";
            // 
            // txtAvance
            // 
            this.txtAvance.Location = new System.Drawing.Point(603, 29);
            this.txtAvance.Name = "txtAvance";
            this.txtAvance.ReadOnly = true;
            this.txtAvance.Size = new System.Drawing.Size(99, 20);
            this.txtAvance.TabIndex = 7;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(560, 30);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(37, 18);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Аванс";
            // 
            // txtBorg
            // 
            this.txtBorg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "Borg", true));
            this.txtBorg.Location = new System.Drawing.Point(444, 29);
            this.txtBorg.Name = "txtBorg";
            this.txtBorg.ReadOnly = true;
            this.txtBorg.Size = new System.Drawing.Size(110, 20);
            this.txtBorg.TabIndex = 9;
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(352, 29);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(86, 18);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "Заборгованість";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Location = new System.Drawing.Point(227, 29);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.ReadOnly = true;
            this.txtDateEnd.Size = new System.Drawing.Size(70, 20);
            this.txtDateEnd.TabIndex = 11;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(160, 29);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(61, 18);
            this.radLabel6.TabIndex = 10;
            this.radLabel6.Text = "Дата кінця";
            // 
            // txtState
            // 
            this.txtState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "StatusName", true));
            this.txtState.Location = new System.Drawing.Point(40, 55);
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(137, 20);
            this.txtState.TabIndex = 13;
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(4, 56);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(30, 18);
            this.radLabel7.TabIndex = 12;
            this.radLabel7.Text = "Стан";
            // 
            // txtDateLastPay
            // 
            this.txtDateLastPay.Location = new System.Drawing.Point(312, 55);
            this.txtDateLastPay.Name = "txtDateLastPay";
            this.txtDateLastPay.ReadOnly = true;
            this.txtDateLastPay.Size = new System.Drawing.Size(70, 20);
            this.txtDateLastPay.TabIndex = 15;
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(183, 56);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(123, 18);
            this.radLabel8.TabIndex = 14;
            this.radLabel8.Text = "Дата останньої оплати";
            // 
            // txtAgent
            // 
            this.txtAgent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddBR, "PartnerName", true));
            this.txtAgent.Location = new System.Drawing.Point(467, 55);
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.ReadOnly = true;
            this.txtAgent.Size = new System.Drawing.Size(235, 20);
            this.txtAgent.TabIndex = 17;
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(388, 56);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(73, 18);
            this.radLabel9.TabIndex = 16;
            this.radLabel9.Text = "Представник";
            // 
            // bsAgreementAddBR
            // 
            this.bsAgreementAddBR.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
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
            this.Name = "GeneralAgreementInfo";
            this.Size = new System.Drawing.Size(705, 79);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddBR)).EndInit();
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
