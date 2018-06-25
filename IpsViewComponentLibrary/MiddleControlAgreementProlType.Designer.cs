namespace IpsViewComponentLibrary
{
    partial class MiddleControlAgreementProlType
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
            this.lblTitleClientName = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAgrMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.bindingSourceAgr = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgrSecond = new IpsViewComponentLibrary.ContractConsumerDetailControl();
            this.lblTitleLicAgr = new Telerik.WinControls.UI.RadLabel();
            this.panel = new Telerik.WinControls.UI.RadPanel();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.bindingSourceAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleLicAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(13, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 22);
            this.radLabel1.TabIndex = 15;
            this.radLabel1.Text = "Споживач";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleClientName
            // 
            this.lblTitleClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleClientName.AutoSize = false;
            this.lblTitleClientName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAnketaCompany, "Name", true));
            this.lblTitleClientName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleClientName.Location = new System.Drawing.Point(85, 3);
            this.lblTitleClientName.Name = "lblTitleClientName";
            this.lblTitleClientName.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.lblTitleClientName.Size = new System.Drawing.Size(543, 22);
            this.lblTitleClientName.TabIndex = 14;
            this.lblTitleClientName.Text = "Назва «Клієнта»";
            this.lblTitleClientName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlAgrMain
            // 
            this.ctrlAgrMain.DataSource = this.bindingSourceAgr;
            this.ctrlAgrMain.Location = new System.Drawing.Point(13, 31);
            this.ctrlAgrMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.Name = "ctrlAgrMain";
            this.ctrlAgrMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.TabIndex = 16;
            // 
            // bindingSourceAgr
            // 
            this.bindingSourceAgr.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // ctrlAgrSecond
            // 
            this.ctrlAgrSecond.AutoprolongationPercent = null;
            this.ctrlAgrSecond.IsAutoprolongation = false;
            this.ctrlAgrSecond.MinPayment = null;
            this.ctrlAgrSecond.PercentPayment = null;
            this.ctrlAgrSecond.Location = new System.Drawing.Point(3, 14);
            this.ctrlAgrSecond.MaximumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.MinimumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.Name = "ctrlAgrSecond";
            this.ctrlAgrSecond.Size = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.TabIndex = 17;
            // 
            // lblTitleLicAgr
            // 
            this.lblTitleLicAgr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleLicAgr.AutoSize = false;
            this.lblTitleLicAgr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleLicAgr.Location = new System.Drawing.Point(3, 86);
            this.lblTitleLicAgr.Name = "lblTitleLicAgr";
            this.lblTitleLicAgr.Size = new System.Drawing.Size(625, 40);
            this.lblTitleLicAgr.TabIndex = 18;
            this.lblTitleLicAgr.Text = "license type ";
            this.lblTitleLicAgr.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.btnPrint);
            this.panel.Controls.Add(this.ctrlAgrSecond);
            this.panel.Location = new System.Drawing.Point(3, 135);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(625, 131);
            this.panel.TabIndex = 19;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(500, 108);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 20);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Друкувати договір";
            this.btnPrint.ThemeName = "Office2007Silver";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(13, 125);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(116, 18);
            this.radLabel3.TabIndex = 18;
            this.radLabel3.Text = "Параметри договору";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(511, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 24);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Зберегти зміни";
            this.btnSave.ThemeName = "Office2007Silver";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bindingSourceAnketaCompany
            // 
            this.bindingSourceAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // MiddleControlAgreementProlVsPlacesType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.ctrlAgrMain);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblTitleClientName);
            this.Controls.Add(this.lblTitleLicAgr);
            this.MinimumSize = new System.Drawing.Size(502, 276);
            this.Name = "MiddleControlAgreementProlVsPlacesType";
            this.Size = new System.Drawing.Size(631, 299);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleLicAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblTitleClientName;
        private ContractConsumerMainControl ctrlAgrMain;
        private ContractConsumerDetailControl ctrlAgrSecond;
        private Telerik.WinControls.UI.RadLabel lblTitleLicAgr;
        private Telerik.WinControls.UI.RadPanel panel;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.BindingSource bindingSourceAgr;
        private System.Windows.Forms.BindingSource bindingSourceAnketaCompany;
    }
}
