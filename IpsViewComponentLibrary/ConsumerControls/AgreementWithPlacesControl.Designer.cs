using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class AgreementWithPlacesControl
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
            this.bindingSourceAgr = new System.Windows.Forms.BindingSource(this.components);
            this.panel = new Telerik.WinControls.UI.RadPanel();
            this.checkAttach = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.gvPlaces = new Telerik.WinControls.UI.RadGridView();
            this.ddlLicType = new Telerik.WinControls.UI.RadDropDownList();
            this.licenseAgreementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDictionary = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtSeries = new Telerik.WinControls.UI.RadTextBox();
            this.ctrlAgrMain = new IpsViewComponentLibrary.Shared.Controls.ContractConsumerMainControl();
            this.ctrlAgrSecond = new IpsViewComponentLibrary.Shared.Controls.ContractConsumerDetailControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSourceAgr
            // 
            this.bindingSourceAgr.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.checkAttach);
            this.panel.Controls.Add(this.ctrlAgrSecond);
            this.panel.Location = new System.Drawing.Point(3, 237);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(684, 150);
            this.panel.TabIndex = 3;
            this.panel.ThemeName = "Office2013Light";
            // 
            // checkAttach
            // 
            this.checkAttach.AutoSize = false;
            this.checkAttach.Location = new System.Drawing.Point(6, 125);
            this.checkAttach.Name = "checkAttach";
            this.checkAttach.Size = new System.Drawing.Size(308, 19);
            this.checkAttach.TabIndex = 1;
            this.checkAttach.Text = "Закріпляти, навіть якщо прострочений";
            this.checkAttach.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel3.Location = new System.Drawing.Point(13, 227);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(116, 18);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "Параметри договору";
            // 
            // gvPlaces
            // 
            this.gvPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPlaces.Location = new System.Drawing.Point(3, 86);
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
            gridViewTextBoxColumn2.Width = 299;
            gridViewTextBoxColumn3.FieldName = "PlaceName";
            gridViewTextBoxColumn3.HeaderText = "Назва Закладу";
            gridViewTextBoxColumn3.Name = "PlaceName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 258;
            gridViewTextBoxColumn4.FieldName = "Amount";
            gridViewTextBoxColumn4.HeaderText = "Сума";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.MinWidth = 20;
            gridViewTextBoxColumn4.Name = "Amount";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 120;
            gridViewCheckBoxColumn1.Checked = Telerik.WinControls.Enumerations.ToggleState.On;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = true;
            gridViewCheckBoxColumn1.FieldName = "CheckIn";
            gridViewCheckBoxColumn1.HeaderText = "";
            gridViewCheckBoxColumn1.MaxWidth = 35;
            gridViewCheckBoxColumn1.MinWidth = 35;
            gridViewCheckBoxColumn1.Name = "CheckIn";
            gridViewCheckBoxColumn1.Width = 35;
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
            this.gvPlaces.Size = new System.Drawing.Size(684, 135);
            this.gvPlaces.TabIndex = 0;
            this.gvPlaces.ThemeName = "Office2013Light";
            // 
            // ddlLicType
            // 
            this.ddlLicType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlLicType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.licenseAgreementBindingSource, "LicCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlLicType.DataSource = this.bindingSourceDictionary;
            this.ddlLicType.DisplayMember = "Name";
            this.ddlLicType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlLicType.Location = new System.Drawing.Point(96, 60);
            this.ddlLicType.Name = "ddlLicType";
            this.ddlLicType.Size = new System.Drawing.Size(468, 21);
            this.ddlLicType.TabIndex = 1;
            this.ddlLicType.ThemeName = "Office2013Light";
            this.ddlLicType.ValueMember = "CodeI";
            this.ddlLicType.SelectedIndexChanging += new Telerik.WinControls.UI.Data.PositionChangingEventHandler(this.ddlLicType_SelectedIndexChanging);
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlLicType.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.UI.StackLayoutElement)(this.ddlLicType.GetChildAt(0).GetChildAt(2))).TextWrap = true;
            // 
            // licenseAgreementBindingSource
            // 
            this.licenseAgreementBindingSource.DataSource = typeof(ipsFormsDesign.Model.LicenseAgreement);
            // 
            // bindingSourceDictionary
            // 
            this.bindingSourceDictionary.DataSource = typeof(ipsFormsDesign.Model.AgrLicenseType);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(17, 60);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(73, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Тип ліцензії";
            // 
            // radLabel4
            // 
            this.radLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel4.AutoSize = false;
            this.radLabel4.Location = new System.Drawing.Point(570, 62);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(37, 18);
            this.radLabel4.TabIndex = 0;
            this.radLabel4.Text = "Серія";
            // 
            // txtSeries
            // 
            this.txtSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDictionary, "Series", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtSeries.Location = new System.Drawing.Point(614, 60);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.ReadOnly = true;
            this.txtSeries.Size = new System.Drawing.Size(73, 21);
            this.txtSeries.TabIndex = 2;
            this.txtSeries.ThemeName = "Office2013Light";
            // 
            // ctrlAgrMain
            // 
            this.ctrlAgrMain.AgreementLabelType = ipsFormsDesign.Dictionary.TypeRights.SmallRights;
            this.ctrlAgrMain.AgreementName = "";
            this.ctrlAgrMain.DateEndNullDate = new System.DateTime(((long)(0)));
            this.ctrlAgrMain.DateEndNullText = "";
            this.ctrlAgrMain.DateTimeType = IpsViewComponentLibrary.Extensions.ConsumerAgreementInitType.None;
            this.ctrlAgrMain.Location = new System.Drawing.Point(14, 3);
            this.ctrlAgrMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.Name = "ctrlAgrMain";
            this.ctrlAgrMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.TabIndex = 0;
            // 
            // ctrlAgrSecond
            // 
            this.ctrlAgrSecond.AutoprolongationDataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
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
            this.ctrlAgrSecond.TabIndex = 0;
            // 
            // AgreementWithPlacesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSeries);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.ddlLicType);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.gvPlaces);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.ctrlAgrMain);
            this.Controls.Add(this.panel);
            this.MinimumSize = new System.Drawing.Size(690, 390);
            this.Name = "AgreementWithPlacesControl";
            this.Size = new System.Drawing.Size(690, 390);
            this.Load += new System.EventHandler(this.AgreementWithPlacesControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AgreementWithPlacesControl_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLicType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private ContractConsumerMainControl ctrlAgrMain;
        private System.Windows.Forms.BindingSource bindingSourceAgr;
        private ContractConsumerDetailControl ctrlAgrSecond;
        private Telerik.WinControls.UI.RadPanel panel;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView gvPlaces;
        private Telerik.WinControls.UI.RadDropDownList ddlLicType;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.BindingSource licenseAgreementBindingSource;
        private System.Windows.Forms.BindingSource bindingSourceDictionary;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadCheckBox checkAttach;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtSeries;
    }
}
