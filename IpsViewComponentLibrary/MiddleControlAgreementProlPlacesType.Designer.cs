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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
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
            this.btnAddPlace = new Telerik.WinControls.UI.RadButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPlace)).BeginInit();
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
            this.lblTitleClientName.Size = new System.Drawing.Size(601, 22);
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
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.btnPrint);
            this.panel.Controls.Add(this.ctrlAgrSecond);
            this.panel.Location = new System.Drawing.Point(4, 285);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(683, 125);
            this.panel.TabIndex = 26;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(558, 102);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 20);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Друкувати договір";
            this.btnPrint.ThemeName = "Office2007Silver";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblTitleLicAgr
            // 
            this.lblTitleLicAgr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleLicAgr.AutoSize = false;
            this.lblTitleLicAgr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleLicAgr.Location = new System.Drawing.Point(4, 86);
            this.lblTitleLicAgr.Name = "lblTitleLicAgr";
            this.lblTitleLicAgr.Size = new System.Drawing.Size(683, 40);
            this.lblTitleLicAgr.TabIndex = 24;
            this.lblTitleLicAgr.Text = "license type ";
            this.lblTitleLicAgr.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(570, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 24);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Зберегти зміни";
            this.btnSave.ThemeName = "Office2007Silver";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel3.Location = new System.Drawing.Point(14, 275);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(116, 18);
            this.radLabel3.TabIndex = 25;
            this.radLabel3.Text = "Параметри договору";
            // 
            // gvPlaces
            // 
            this.gvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPlaces.Location = new System.Drawing.Point(3, 133);
            // 
            // 
            // 
            this.gvPlaces.MasterTemplate.AllowAddNewRow = false;
            this.gvPlaces.MasterTemplate.AllowColumnReorder = false;
            this.gvPlaces.MasterTemplate.AllowDeleteRow = false;
            this.gvPlaces.MasterTemplate.AllowDragToGroup = false;
            this.gvPlaces.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "PlaceId";
            gridViewTextBoxColumn1.HeaderText = "n/n";
            gridViewTextBoxColumn1.MaxWidth = 70;
            gridViewTextBoxColumn1.MinWidth = 70;
            gridViewTextBoxColumn1.Name = "PlaceId";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 70;
            gridViewTextBoxColumn2.FieldName = "PlaceAddress";
            gridViewTextBoxColumn2.HeaderText = "Фактична адреса закладу";
            gridViewTextBoxColumn2.Name = "PlaceAddress";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 296;
            gridViewTextBoxColumn3.FieldName = "PlaceName";
            gridViewTextBoxColumn3.HeaderText = "Назва Закладу";
            gridViewTextBoxColumn3.Name = "PlaceName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 147;
            gridViewTextBoxColumn4.FieldName = "PlCode";
            gridViewTextBoxColumn4.HeaderText = "Сума";
            gridViewTextBoxColumn4.MaxWidth = 135;
            gridViewTextBoxColumn4.MinWidth = 120;
            gridViewTextBoxColumn4.Name = "PlCode";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 120;
            gridViewCheckBoxColumn1.Checked = Telerik.WinControls.Enumerations.ToggleState.On;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = true;
            gridViewCheckBoxColumn1.FieldName = "CheckIn";
            gridViewCheckBoxColumn1.HeaderText = "";
            gridViewCheckBoxColumn1.Name = "CheckIn";
            gridViewCheckBoxColumn1.Width = 34;
            this.gvPlaces.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn1});
            this.gvPlaces.MasterTemplate.EnableGrouping = false;
            this.gvPlaces.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPlaces.Name = "gvPlaces";
            this.gvPlaces.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPlaces.Size = new System.Drawing.Size(684, 108);
            this.gvPlaces.TabIndex = 28;
            this.gvPlaces.ThemeName = "Office2007Silver";
            this.gvPlaces.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvPlaces_CellValueChanged);
            // 
            // btnAddPlace
            // 
            this.btnAddPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPlace.Location = new System.Drawing.Point(7, 247);
            this.btnAddPlace.Name = "btnAddPlace";
            this.btnAddPlace.Size = new System.Drawing.Size(122, 22);
            this.btnAddPlace.TabIndex = 29;
            this.btnAddPlace.Text = "Додати заклад";
            this.btnAddPlace.ThemeName = "Office2007Silver";
            this.btnAddPlace.Click += new System.EventHandler(this.btnAddPlace_Click);
            // 
            // MiddleControlAgreementProlPlacesType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddPlace);
            this.Controls.Add(this.gvPlaces);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lblTitleClientName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.ctrlAgrMain);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.lblTitleLicAgr);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(690, 390);
            this.Name = "MiddleControlAgreementProlPlacesType";
            this.Size = new System.Drawing.Size(690, 443);
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
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPlace)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnAddPlace;
    }
}
