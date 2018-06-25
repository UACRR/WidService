namespace IpsViewComponentLibrary
{
    partial class MiddleControlAgreementProlPlacesType
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblTitleClientName = new Telerik.WinControls.UI.RadLabel();
            this.bindingSourceAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgrMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.bindingSourceAgr = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAgrSecond = new IpsViewComponentLibrary.ContractConsumerDetailControl();
            this.panel = new Telerik.WinControls.UI.RadPanel();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.lblTitleLicAgr = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.gvPlaces = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleLicAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(14, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 22);
            this.radLabel1.TabIndex = 22;
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
            this.lblTitleClientName.Location = new System.Drawing.Point(86, 3);
            this.lblTitleClientName.Name = "lblTitleClientName";
            this.lblTitleClientName.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.lblTitleClientName.Size = new System.Drawing.Size(826, 22);
            this.lblTitleClientName.TabIndex = 21;
            this.lblTitleClientName.Text = "Назва «Клієнта»";
            this.lblTitleClientName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bindingSourceAnketaCompany
            // 
            this.bindingSourceAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // ctrlAgrMain
            // 
            this.ctrlAgrMain.DataSource = this.bindingSourceAgr;
            this.ctrlAgrMain.Location = new System.Drawing.Point(14, 31);
            this.ctrlAgrMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.Name = "ctrlAgrMain";
            this.ctrlAgrMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.TabIndex = 23;
            // 
            // bindingSourceAgr
            // 
            this.bindingSourceAgr.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // ctrlAgrSecond
            // 
            this.ctrlAgrSecond.AutoprolongationPercent = null;
            this.ctrlAgrSecond.DataSourceBinding = null;
            this.ctrlAgrSecond.IsAutoprolongation = false;
            this.ctrlAgrSecond.Location = new System.Drawing.Point(3, 14);
            this.ctrlAgrSecond.MaximumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.MinimumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.MinPayment = null;
            this.ctrlAgrSecond.Name = "ctrlAgrSecond";
            this.ctrlAgrSecond.PercentPayment = null;
            this.ctrlAgrSecond.PeriodPaymentDataMember = null;
            this.ctrlAgrSecond.PeriodPaymentDataSource = null;
            this.ctrlAgrSecond.PeriodPaymentDisplayMember = "";
            this.ctrlAgrSecond.PeriodPaymentSelectedValue = null;
            this.ctrlAgrSecond.PeriodPaymentValueMember = "";
            this.ctrlAgrSecond.Size = new System.Drawing.Size(480, 105);
            this.ctrlAgrSecond.TabIndex = 17;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.btnPrint);
            this.panel.Controls.Add(this.ctrlAgrSecond);
            this.panel.Location = new System.Drawing.Point(4, 242);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(908, 123);
            this.panel.TabIndex = 26;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(783, 100);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 20);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Друкувати договір";
            this.btnPrint.ThemeName = "Office2007Silver";
            // 
            // lblTitleLicAgr
            // 
            this.lblTitleLicAgr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleLicAgr.AutoSize = false;
            this.lblTitleLicAgr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleLicAgr.Location = new System.Drawing.Point(4, 86);
            this.lblTitleLicAgr.Name = "lblTitleLicAgr";
            this.lblTitleLicAgr.Size = new System.Drawing.Size(908, 40);
            this.lblTitleLicAgr.TabIndex = 24;
            this.lblTitleLicAgr.Text = "license type ";
            this.lblTitleLicAgr.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(795, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 24);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Зберегти зміни";
            this.btnSave.ThemeName = "Office2007Silver";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(14, 232);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(116, 18);
            this.radLabel3.TabIndex = 25;
            this.radLabel3.Text = "Параметри договору";
            // 
            // gvPlaces
            // 
            this.gvPlaces.Location = new System.Drawing.Point(3, 133);
            // 
            // 
            // 
            this.gvPlaces.MasterTemplate.AllowAddNewRow = false;
            this.gvPlaces.MasterTemplate.AllowColumnReorder = false;
            this.gvPlaces.MasterTemplate.AllowDeleteRow = false;
            this.gvPlaces.MasterTemplate.AllowDragToGroup = false;
            this.gvPlaces.MasterTemplate.AllowEditRow = false;
            this.gvPlaces.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.HeaderText = "n/n";
            gridViewTextBoxColumn1.MaxWidth = 70;
            gridViewTextBoxColumn1.MinWidth = 70;
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 70;
            gridViewTextBoxColumn2.HeaderText = "Фактична адреса закладу";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 425;
            gridViewTextBoxColumn3.HeaderText = "Назва Закладу";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 261;
            gridViewTextBoxColumn4.HeaderText = "Сума";
            gridViewTextBoxColumn4.MaxWidth = 135;
            gridViewTextBoxColumn4.MinWidth = 120;
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.Width = 135;
            this.gvPlaces.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvPlaces.MasterTemplate.EnableGrouping = false;
            this.gvPlaces.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPlaces.Name = "gvPlaces";
            this.gvPlaces.ReadOnly = true;
            this.gvPlaces.Size = new System.Drawing.Size(909, 93);
            this.gvPlaces.TabIndex = 28;
            // 
            // MiddleControlAgreementProlWithoutPlacesType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvPlaces);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblTitleClientName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.ctrlAgrMain);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lblTitleLicAgr);
            this.Controls.Add(this.btnSave);
            this.Name = "MiddleControlAgreementProlWithoutPlacesType";
            this.Size = new System.Drawing.Size(915, 398);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAnketaCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleLicAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblTitleClientName;
        private System.Windows.Forms.BindingSource bindingSourceAnketaCompany;
        private ContractConsumerMainControl ctrlAgrMain;
        private System.Windows.Forms.BindingSource bindingSourceAgr;
        private ContractConsumerDetailControl ctrlAgrSecond;
        private Telerik.WinControls.UI.RadPanel panel;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadLabel lblTitleLicAgr;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView gvPlaces;
    }
}
