namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetGenAgreement
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ctrlHeaderInfo = new IpsViewComponentLibrary.InformationOfUserControl();
            this.gvGenAgrLicences = new Telerik.WinControls.UI.RadGridView();
            this.btnView = new Telerik.WinControls.UI.RadButton();
            this.btnAccept = new Telerik.WinControls.UI.RadButton();
            this.btnEditAgr = new Telerik.WinControls.UI.RadButton();
            this.ctrlFooterInfo = new IpsViewComponentLibrary.InformationFooterGenAgrBigRight();
            this.btnAgrClose = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgrClose)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlHeaderInfo
            // 
            this.ctrlHeaderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlHeaderInfo.Edrpou = "";
            this.ctrlHeaderInfo.EmailContactPerson = "";
            this.ctrlHeaderInfo.EmailManager = "";
            this.ctrlHeaderInfo.GroupOrHolding = "Копірайт";
            this.ctrlHeaderInfo.HoldingVisible = false;
            this.ctrlHeaderInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeaderInfo.MaximumSize = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.MinimumSize = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.Name = "ctrlHeaderInfo";
            this.ctrlHeaderInfo.NameInfo = "";
            this.ctrlHeaderInfo.OrganisationForm = "";
            this.ctrlHeaderInfo.OrganisationFormVisible = false;
            this.ctrlHeaderInfo.PhoneContactPerson = "";
            this.ctrlHeaderInfo.PhoneManager = "";
            this.ctrlHeaderInfo.PibContactPerson = "";
            this.ctrlHeaderInfo.PibManager = "";
            this.ctrlHeaderInfo.Size = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.TabIndex = 0;
            // 
            // gvGenAgrLicences
            // 
            this.gvGenAgrLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvGenAgrLicences.AutoSizeRows = true;
            this.gvGenAgrLicences.EnableCustomFiltering = true;
            this.gvGenAgrLicences.Location = new System.Drawing.Point(4, 215);
            // 
            // 
            // 
            this.gvGenAgrLicences.MasterTemplate.AllowAddNewRow = false;
            this.gvGenAgrLicences.MasterTemplate.AllowDeleteRow = false;
            this.gvGenAgrLicences.MasterTemplate.AllowDragToGroup = false;
            this.gvGenAgrLicences.MasterTemplate.AllowEditRow = false;
            this.gvGenAgrLicences.MasterTemplate.AutoGenerateColumns = false;
            this.gvGenAgrLicences.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "CustName";
            gridViewTextBoxColumn2.HeaderText = "Назва клієнта";
            gridViewTextBoxColumn2.MinWidth = 0;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "CustName";
            gridViewTextBoxColumn2.Width = 414;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "AgrNumber";
            gridViewTextBoxColumn3.HeaderText = "№ ген. договору";
            gridViewTextBoxColumn3.MinWidth = 0;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "AgrNumber";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "DateBegin";
            gridViewTextBoxColumn4.FormatString = "{0:d}";
            gridViewTextBoxColumn4.HeaderText = "Дата початку";
            gridViewTextBoxColumn4.MinWidth = 0;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "DateBegin";
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "DateEnd";
            gridViewTextBoxColumn5.FormatString = "{0:d}";
            gridViewTextBoxColumn5.HeaderText = "Дата завершення";
            gridViewTextBoxColumn5.MinWidth = 0;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "DateEnd";
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "StatusName";
            gridViewTextBoxColumn6.HeaderText = "Стан";
            gridViewTextBoxColumn6.MinWidth = 0;
            gridViewTextBoxColumn6.Name = "StatusName";
            gridViewTextBoxColumn6.Width = 120;
            this.gvGenAgrLicences.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gvGenAgrLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvGenAgrLicences.MasterTemplate.EnableFiltering = true;
            this.gvGenAgrLicences.MasterTemplate.EnableGrouping = false;
            this.gvGenAgrLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvGenAgrLicences.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvGenAgrLicences.Name = "gvGenAgrLicences";
            this.gvGenAgrLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvGenAgrLicences.Size = new System.Drawing.Size(906, 184);
            this.gvGenAgrLicences.TabIndex = 8;
            this.gvGenAgrLicences.ThemeName = "Office2013Light";
            this.gvGenAgrLicences.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvGenAgrLicences_CurrentRowChanged);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnView.Location = new System.Drawing.Point(4, 405);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(110, 24);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "Перегляд";
            this.btnView.ThemeName = "Office2013Light";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(236, 405);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Підтвердити";
            this.btnAccept.ThemeName = "Office2013Light";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnEditAgr
            // 
            this.btnEditAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditAgr.Enabled = false;
            this.btnEditAgr.Location = new System.Drawing.Point(120, 405);
            this.btnEditAgr.Name = "btnEditAgr";
            this.btnEditAgr.Size = new System.Drawing.Size(110, 24);
            this.btnEditAgr.TabIndex = 12;
            this.btnEditAgr.Text = "Редагувати";
            this.btnEditAgr.ThemeName = "Office2013Light";
            this.btnEditAgr.Click += new System.EventHandler(this.btnEditAgr_Click);
            // 
            // ctrlFooterInfo
            // 
            this.ctrlFooterInfo.DataSourceLicense = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            this.ctrlFooterInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlFooterInfo.Location = new System.Drawing.Point(0, 435);
            this.ctrlFooterInfo.MaximumSize = new System.Drawing.Size(912, 155);
            this.ctrlFooterInfo.MinimumSize = new System.Drawing.Size(912, 155);
            this.ctrlFooterInfo.Name = "ctrlFooterInfo";
            this.ctrlFooterInfo.Size = new System.Drawing.Size(912, 155);
            this.ctrlFooterInfo.TabIndex = 13;
            // 
            // btnAgrClose
            // 
            this.btnAgrClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgrClose.Enabled = false;
            this.btnAgrClose.Location = new System.Drawing.Point(786, 405);
            this.btnAgrClose.Name = "btnAgrClose";
            this.btnAgrClose.Size = new System.Drawing.Size(124, 24);
            this.btnAgrClose.TabIndex = 14;
            this.btnAgrClose.Text = "Закрити договір";
            this.btnAgrClose.ThemeName = "Office2013Light";
            this.btnAgrClose.Click += new System.EventHandler(this.btnAgrClose_Click);
            // 
            // MiddleControlCabinetGenAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAgrClose);
            this.Controls.Add(this.ctrlFooterInfo);
            this.Controls.Add(this.btnEditAgr);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.gvGenAgrLicences);
            this.Controls.Add(this.ctrlHeaderInfo);
            this.MinimumSize = new System.Drawing.Size(912, 300);
            this.Name = "MiddleControlCabinetGenAgreement";
            this.Size = new System.Drawing.Size(913, 590);
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgrClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private InformationOfUserControl ctrlHeaderInfo;
        private Telerik.WinControls.UI.RadGridView gvGenAgrLicences;
        private Telerik.WinControls.UI.RadButton btnView;
        private Telerik.WinControls.UI.RadButton btnAccept;
        private Telerik.WinControls.UI.RadButton btnEditAgr;
        private InformationFooterGenAgrBigRight ctrlFooterInfo;
        private Telerik.WinControls.UI.RadButton btnAgrClose;
    }
}
