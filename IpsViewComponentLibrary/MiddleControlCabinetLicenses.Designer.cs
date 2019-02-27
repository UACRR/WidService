using System.Drawing;

namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetLicenses
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewLicences = new Telerik.WinControls.UI.RadGridView();
            this.separator = new Telerik.WinControls.UI.RadSeparator();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadButton();
            this.btnToProlongation = new Telerik.WinControls.UI.RadButton();
            this.btnToAccept = new Telerik.WinControls.UI.RadButton();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.ctrlAgrDetailInfo = new IpsViewComponentLibrary.ConsumerControls.BigRight.AgrDetailInfoBr();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.ctrlAgrInfo = new IpsViewComponentLibrary.GeneralAgreementInfo();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewLicences
            // 
            this.gvViewLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewLicences.AutoSizeRows = true;
            this.gvViewLicences.EnableCustomFiltering = true;
            this.gvViewLicences.Location = new System.Drawing.Point(3, 131);
            // 
            // 
            // 
            this.gvViewLicences.MasterTemplate.AllowAddNewRow = false;
            this.gvViewLicences.MasterTemplate.AllowDeleteRow = false;
            this.gvViewLicences.MasterTemplate.AllowDragToGroup = false;
            this.gvViewLicences.MasterTemplate.AllowEditRow = false;
            this.gvViewLicences.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewLicences.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "Objid";
            gridViewTextBoxColumn2.HeaderText = "Код вистави";
            gridViewTextBoxColumn2.MaxWidth = 75;
            gridViewTextBoxColumn2.MinWidth = 75;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Objid";
            gridViewTextBoxColumn2.Width = 75;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "ObjName";
            gridViewTextBoxColumn3.HeaderText = "Назва вистави";
            gridViewTextBoxColumn3.MinWidth = 0;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "ObjName";
            gridViewTextBoxColumn3.Width = 194;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "LicNum";
            gridViewTextBoxColumn4.HeaderText = "№ ліцензійного договору";
            gridViewTextBoxColumn4.MaxWidth = 100;
            gridViewTextBoxColumn4.MinWidth = 80;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "LicNum";
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "LicDate";
            gridViewTextBoxColumn5.FormatString = "{0:d}";
            gridViewTextBoxColumn5.HeaderText = "Дата договору";
            gridViewTextBoxColumn5.MaxWidth = 75;
            gridViewTextBoxColumn5.MinWidth = 75;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "LicDate";
            gridViewTextBoxColumn5.Width = 75;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "Rate";
            gridViewTextBoxColumn6.HeaderText = "АВ%";
            gridViewTextBoxColumn6.MaxWidth = 45;
            gridViewTextBoxColumn6.MinWidth = 45;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "Rate";
            gridViewTextBoxColumn6.Width = 45;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "LicDateBegin";
            gridViewTextBoxColumn7.FormatString = "{0:d}";
            gridViewTextBoxColumn7.HeaderText = "Дата початку ліцензії";
            gridViewTextBoxColumn7.MaxWidth = 75;
            gridViewTextBoxColumn7.MinWidth = 75;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "LicDateBegin";
            gridViewTextBoxColumn7.Width = 75;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "LicDateEnd";
            gridViewTextBoxColumn8.FormatString = "{0:d}";
            gridViewTextBoxColumn8.HeaderText = "Дата закриття ліцензії";
            gridViewTextBoxColumn8.MaxWidth = 75;
            gridViewTextBoxColumn8.MinWidth = 75;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "LicDateEnd";
            gridViewTextBoxColumn8.Width = 75;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "Borg";
            gridViewTextBoxColumn9.HeaderText = "Заборгованість";
            gridViewTextBoxColumn9.MaxWidth = 95;
            gridViewTextBoxColumn9.MinWidth = 95;
            gridViewTextBoxColumn9.Name = "Borg";
            gridViewTextBoxColumn9.Width = 95;
            gridViewTextBoxColumn10.FieldName = "prepayAvans";
            gridViewTextBoxColumn10.HeaderText = "Аванс";
            gridViewTextBoxColumn10.MaxWidth = 95;
            gridViewTextBoxColumn10.MinWidth = 95;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "prepayAvans";
            gridViewTextBoxColumn10.Width = 95;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewTextBoxColumn11.FieldName = "LicStatusName";
            gridViewTextBoxColumn11.HeaderText = "Статус ліцензії";
            gridViewTextBoxColumn11.MaxWidth = 90;
            gridViewTextBoxColumn11.MinWidth = 90;
            gridViewTextBoxColumn11.Name = "LicStatusName";
            gridViewTextBoxColumn11.Width = 90;
            gridViewCommandColumn1.FieldName = "viewBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "viewBtn";
            gridViewCommandColumn1.Width = 30;
            gridViewCommandColumn2.FieldName = "printBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "printBtn";
            gridViewCommandColumn2.Width = 30;
            this.gvViewLicences.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvViewLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableGrouping = false;
            this.gvViewLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvViewLicences.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewLicences.Name = "gvViewLicences";
            this.gvViewLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewLicences.Size = new System.Drawing.Size(994, 182);
            this.gvViewLicences.TabIndex = 7;
            this.gvViewLicences.ThemeName = "Office2013Light";
            this.gvViewLicences.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvViewLicences_CurrentRowChanged);
            this.gvViewLicences.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewLicences_CommandCellClick);
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.Location = new System.Drawing.Point(3, 85);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(994, 14);
            this.separator.TabIndex = 8;
            this.separator.ThemeName = "Office2013Light";
            // 
            // btnCloseAgr
            // 
            this.btnCloseAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAgr.Location = new System.Drawing.Point(902, 366);
            this.btnCloseAgr.Name = "btnCloseAgr";
            this.btnCloseAgr.Size = new System.Drawing.Size(95, 40);
            this.btnCloseAgr.TabIndex = 9;
            this.btnCloseAgr.Text = "Закрити ліцензію";
            this.btnCloseAgr.TextWrap = true;
            this.btnCloseAgr.ThemeName = "Office2013Light";
            this.btnCloseAgr.Click += new System.EventHandler(this.btnCloseAgr_Click);
            // 
            // btnToProlongation
            // 
            this.btnToProlongation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToProlongation.Location = new System.Drawing.Point(902, 319);
            this.btnToProlongation.Name = "btnToProlongation";
            this.btnToProlongation.Size = new System.Drawing.Size(95, 40);
            this.btnToProlongation.TabIndex = 11;
            this.btnToProlongation.Text = "Пролонгувати ліцензію";
            this.btnToProlongation.TextWrap = true;
            this.btnToProlongation.ThemeName = "Office2013Light";
            this.btnToProlongation.Click += new System.EventHandler(this.btnToProlongation_Click);
            // 
            // btnToAccept
            // 
            this.btnToAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToAccept.Enabled = false;
            this.btnToAccept.Location = new System.Drawing.Point(821, 105);
            this.btnToAccept.Name = "btnToAccept";
            this.btnToAccept.Size = new System.Drawing.Size(174, 20);
            this.btnToAccept.TabIndex = 12;
            this.btnToAccept.Text = "Відправити на погодження";
            this.btnToAccept.ThemeName = "Office2013Light";
            this.btnToAccept.Click += new System.EventHandler(this.btnToAccept_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(887, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 24);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Оновити дані";
            this.btnUpdate.ThemeName = "Office2013Light";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ctrlAgrDetailInfo
            // 
            this.ctrlAgrDetailInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlAgrDetailInfo.Location = new System.Drawing.Point(3, 319);
            this.ctrlAgrDetailInfo.MinimumSize = new System.Drawing.Size(795, 170);
            this.ctrlAgrDetailInfo.Name = "ctrlAgrDetailInfo";
            this.ctrlAgrDetailInfo.Size = new System.Drawing.Size(800, 216);
            this.ctrlAgrDetailInfo.TabIndex = 0;
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 105);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 14;
            // 
            // ctrlAgrInfo
            // 
            this.ctrlAgrInfo.DataSource = typeof(ipsFormsDesign.Interfaces.MainGridConsumerBigRightView);
            this.ctrlAgrInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlAgrInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrlAgrInfo.MaximumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.MinimumSize = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.Name = "ctrlAgrInfo";
            this.ctrlAgrInfo.Size = new System.Drawing.Size(705, 79);
            this.ctrlAgrInfo.TabIndex = 0;
            // 
            // MiddleControlCabinetLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlAgrDetailInfo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnToProlongation);
            this.Controls.Add(this.btnCloseAgr);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.btnToAccept);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.gvViewLicences);
            this.Controls.Add(this.ctrlAgrInfo);
            this.MinimumSize = new System.Drawing.Size(993, 538);
            this.Name = "MiddleControlCabinetLicenses";
            this.Size = new System.Drawing.Size(1000, 538);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToProlongation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralAgreementInfo ctrlAgrInfo;
        private Telerik.WinControls.UI.RadGridView gvViewLicences;
        private Telerik.WinControls.UI.RadSeparator separator;
        private Telerik.WinControls.UI.RadButton btnCloseAgr;
        private Telerik.WinControls.UI.RadButton btnToProlongation;
        private Telerik.WinControls.UI.RadButton btnToAccept;
        private ConsumerControls.BigRight.AgrDetailInfoBr ctrlAgrDetailInfo;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadButton btnUpdate;
    }
}
