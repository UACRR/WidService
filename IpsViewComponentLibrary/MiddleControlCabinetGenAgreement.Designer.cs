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
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.gvGenAgrLicences = new Telerik.WinControls.UI.RadGridView();
            this.btnView = new Telerik.WinControls.UI.RadButton();
            this.btnCreateNewAgr = new Telerik.WinControls.UI.RadButton();
            this.btnAccept = new Telerik.WinControls.UI.RadButton();
            this.btnEditAgr = new Telerik.WinControls.UI.RadButton();
            this.ctrlFooterInfo = new IpsViewComponentLibrary.InformationFooterGenAgrBigRight();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).BeginInit();
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
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(4, 210);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(906, 10);
            this.radSeparator1.TabIndex = 1;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // gvGenAgrLicences
            // 
            this.gvGenAgrLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvGenAgrLicences.AutoSizeRows = true;
            this.gvGenAgrLicences.EnableCustomFiltering = true;
            this.gvGenAgrLicences.Location = new System.Drawing.Point(4, 226);
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
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Назва клієнта";
            gridViewTextBoxColumn2.MinWidth = 0;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 414;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "JaCity";
            gridViewTextBoxColumn3.HeaderText = "№ ген. договору";
            gridViewTextBoxColumn3.MinWidth = 0;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "JaCity";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "CountLic2Active";
            gridViewTextBoxColumn4.HeaderText = "Дата початку";
            gridViewTextBoxColumn4.MaxWidth = 100;
            gridViewTextBoxColumn4.MinWidth = 100;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "CountLic2Active";
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "CountLic3Active";
            gridViewTextBoxColumn5.HeaderText = "Дата завершення";
            gridViewTextBoxColumn5.MaxWidth = 100;
            gridViewTextBoxColumn5.MinWidth = 100;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "CountLic3Active";
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "PartnerName";
            gridViewTextBoxColumn6.HeaderText = "Стан";
            gridViewTextBoxColumn6.MaxWidth = 120;
            gridViewTextBoxColumn6.MinWidth = 120;
            gridViewTextBoxColumn6.Name = "PartnerName";
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
            this.gvGenAgrLicences.Size = new System.Drawing.Size(906, 173);
            this.gvGenAgrLicences.TabIndex = 8;
            this.gvGenAgrLicences.ThemeName = "Office2013Light";
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
            // 
            // btnCreateNewAgr
            // 
            this.btnCreateNewAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewAgr.Location = new System.Drawing.Point(568, 405);
            this.btnCreateNewAgr.Name = "btnCreateNewAgr";
            this.btnCreateNewAgr.Size = new System.Drawing.Size(110, 24);
            this.btnCreateNewAgr.TabIndex = 10;
            this.btnCreateNewAgr.Text = "Новий договір";
            this.btnCreateNewAgr.ThemeName = "Office2013Light";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(800, 405);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Підтвердити";
            this.btnAccept.ThemeName = "Office2013Light";
            // 
            // btnEditAgr
            // 
            this.btnEditAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAgr.Location = new System.Drawing.Point(684, 405);
            this.btnEditAgr.Name = "btnEditAgr";
            this.btnEditAgr.Size = new System.Drawing.Size(110, 24);
            this.btnEditAgr.TabIndex = 12;
            this.btnEditAgr.Text = "Редагувати";
            this.btnEditAgr.ThemeName = "Office2013Light";
            // 
            // ctrlFooterInfo
            // 
            this.ctrlFooterInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlFooterInfo.Location = new System.Drawing.Point(0, 435);
            this.ctrlFooterInfo.MaximumSize = new System.Drawing.Size(912, 155);
            this.ctrlFooterInfo.MinimumSize = new System.Drawing.Size(912, 155);
            this.ctrlFooterInfo.Name = "ctrlFooterInfo";
            this.ctrlFooterInfo.Size = new System.Drawing.Size(912, 155);
            this.ctrlFooterInfo.TabIndex = 13;
            // 
            // MiddleControlCabinetGenAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlFooterInfo);
            this.Controls.Add(this.btnEditAgr);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCreateNewAgr);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.gvGenAgrLicences);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.ctrlHeaderInfo);
            this.MinimumSize = new System.Drawing.Size(912, 300);
            this.Name = "MiddleControlCabinetGenAgreement";
            this.Size = new System.Drawing.Size(913, 590);
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private InformationOfUserControl ctrlHeaderInfo;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadGridView gvGenAgrLicences;
        private Telerik.WinControls.UI.RadButton btnView;
        private Telerik.WinControls.UI.RadButton btnCreateNewAgr;
        private Telerik.WinControls.UI.RadButton btnAccept;
        private Telerik.WinControls.UI.RadButton btnEditAgr;
        private InformationFooterGenAgrBigRight ctrlFooterInfo;
    }
}
