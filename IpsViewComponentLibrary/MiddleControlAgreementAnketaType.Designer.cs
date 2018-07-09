namespace IpsViewComponentLibrary
{
    partial class MiddleControlAgreementAnketaType
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAgreementMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.ctrlAgreementSecond = new IpsViewComponentLibrary.ContractConsumerDetailControl();
            this.ddlLicType = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.gvPlaces = new Telerik.WinControls.UI.RadGridView();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.panel = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(35, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 22);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Назва «Клієнта»";
            this.lblTitle.ThemeName = "Office2013Light";
            // 
            // ctrlAgreementMain
            // 
            this.ctrlAgreementMain.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgreementMain.Location = new System.Drawing.Point(3, 31);
            this.ctrlAgreementMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.Name = "ctrlAgreementMain";
            this.ctrlAgreementMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgreementMain.TabIndex = 10;
            // 
            // ctrlAgreementSecond
            // 
            this.ctrlAgreementSecond.AutoprolongationDataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgreementSecond.AutoprolongationPercent = null;
            this.ctrlAgreementSecond.DataSourceBinding = null;
            this.ctrlAgreementSecond.IsAutoprolongation = false;
            this.ctrlAgreementSecond.Location = new System.Drawing.Point(3, 17);
            this.ctrlAgreementSecond.MaximumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.MinimumSize = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.MinPayment = null;
            this.ctrlAgreementSecond.Name = "ctrlAgreementSecond";
            this.ctrlAgreementSecond.PercentPayment = null;
            this.ctrlAgreementSecond.PeriodPaymentDataMember = null;
            this.ctrlAgreementSecond.PeriodPaymentDataSource = null;
            this.ctrlAgreementSecond.PeriodPaymentDisplayMember = "";
            this.ctrlAgreementSecond.PeriodPaymentSelectedValue = null;
            this.ctrlAgreementSecond.PeriodPaymentValueMember = "";
            this.ctrlAgreementSecond.Size = new System.Drawing.Size(480, 105);
            this.ctrlAgreementSecond.TabIndex = 11;
            // 
            // ddlLicType
            // 
            this.ddlLicType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlLicType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlLicType.Location = new System.Drawing.Point(82, 86);
            this.ddlLicType.Name = "ddlLicType";
            this.ddlLicType.Size = new System.Drawing.Size(605, 21);
            this.ddlLicType.TabIndex = 12;
            this.ddlLicType.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlLicType.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.ddlLicType.GetChildAt(0).GetChildAt(2))).TextWrap = true;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 86);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(73, 19);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "Тип ліцензії";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // gvPlaces
            // 
            this.gvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPlaces.Location = new System.Drawing.Point(3, 110);
            // 
            // 
            // 
            this.gvPlaces.MasterTemplate.AllowAddNewRow = false;
            this.gvPlaces.MasterTemplate.AllowColumnReorder = false;
            this.gvPlaces.MasterTemplate.AllowDeleteRow = false;
            this.gvPlaces.MasterTemplate.AllowDragToGroup = false;
            this.gvPlaces.MasterTemplate.AutoGenerateColumns = false;
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
            this.gvPlaces.Size = new System.Drawing.Size(684, 150);
            this.gvPlaces.TabIndex = 31;
            this.gvPlaces.ThemeName = "Office2007Silver";
            this.gvPlaces.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvPlaces_CellValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel3.Location = new System.Drawing.Point(13, 266);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(116, 18);
            this.radLabel3.TabIndex = 29;
            this.radLabel3.Text = "Параметри договору";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel.Controls.Add(this.ctrlAgreementSecond);
            this.panel.Location = new System.Drawing.Point(3, 276);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(489, 125);
            this.panel.TabIndex = 30;
            // 
            // MiddleControlAgreementAnketaType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvPlaces);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.ddlLicType);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ctrlAgreementMain);
            this.Controls.Add(this.lblTitle);
            this.MinimumSize = new System.Drawing.Size(490, 218);
            this.Name = "MiddleControlAgreementAnketaType";
            this.Size = new System.Drawing.Size(690, 404);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private ContractConsumerMainControl ctrlAgreementMain;
        private ContractConsumerDetailControl ctrlAgreementSecond;
        private Telerik.WinControls.UI.RadDropDownList ddlLicType;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView gvPlaces;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadPanel panel;
    }
}
