namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetAgent
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnEditAgr = new Telerik.WinControls.UI.RadButton();
            this.btnAccept = new Telerik.WinControls.UI.RadButton();
            this.btnCreateNewAgr = new Telerik.WinControls.UI.RadButton();
            this.btnView = new Telerik.WinControls.UI.RadButton();
            this.gvGenAgrLicences = new Telerik.WinControls.UI.RadGridView();
            this.ctrlHeaderInfo = new IpsViewComponentLibrary.InformationOfUserControl();
            this.ctrlFooterInfo = new IpsViewComponentLibrary.AgentFooterBR();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditAgr
            // 
            this.btnEditAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAgr.Location = new System.Drawing.Point(684, 360);
            this.btnEditAgr.Name = "btnEditAgr";
            this.btnEditAgr.Size = new System.Drawing.Size(110, 24);
            this.btnEditAgr.TabIndex = 17;
            this.btnEditAgr.Text = "Редагувати";
            this.btnEditAgr.ThemeName = "Office2013Light";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(800, 360);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.Text = "Підтвердити";
            this.btnAccept.ThemeName = "Office2013Light";
            // 
            // btnCreateNewAgr
            // 
            this.btnCreateNewAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewAgr.Location = new System.Drawing.Point(568, 360);
            this.btnCreateNewAgr.Name = "btnCreateNewAgr";
            this.btnCreateNewAgr.Size = new System.Drawing.Size(110, 24);
            this.btnCreateNewAgr.TabIndex = 15;
            this.btnCreateNewAgr.Text = "Новий договір";
            this.btnCreateNewAgr.ThemeName = "Office2013Light";
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnView.Location = new System.Drawing.Point(3, 360);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(110, 24);
            this.btnView.TabIndex = 14;
            this.btnView.Text = "Перегляд";
            this.btnView.ThemeName = "Office2013Light";
            // 
            // gvGenAgrLicences
            // 
            this.gvGenAgrLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvGenAgrLicences.AutoSizeRows = true;
            this.gvGenAgrLicences.EnableCustomFiltering = true;
            this.gvGenAgrLicences.Location = new System.Drawing.Point(3, 215);
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
            gridViewTextBoxColumn3.Width = 151;
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
            this.gvGenAgrLicences.Size = new System.Drawing.Size(907, 139);
            this.gvGenAgrLicences.TabIndex = 13;
            this.gvGenAgrLicences.ThemeName = "Office2013Light";
            // 
            // ctrlHeaderInfo
            // 
            this.ctrlHeaderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlHeaderInfo.Edrpou = "";
            this.ctrlHeaderInfo.EmailContactPerson = "";
            this.ctrlHeaderInfo.EmailManager = "";
            this.ctrlHeaderInfo.GroupOrHolding = "";
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
            // ctrlFooterInfo
            // 
            this.ctrlFooterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlFooterInfo.Location = new System.Drawing.Point(3, 406);
            this.ctrlFooterInfo.MaximumSize = new System.Drawing.Size(625, 174);
            this.ctrlFooterInfo.MinimumSize = new System.Drawing.Size(625, 174);
            this.ctrlFooterInfo.Name = "ctrlFooterInfo";
            this.ctrlFooterInfo.Size = new System.Drawing.Size(625, 174);
            this.ctrlFooterInfo.TabIndex = 18;
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(3, 390);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(907, 10);
            this.radSeparator1.TabIndex = 19;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // MiddleControlCabinetAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.ctrlFooterInfo);
            this.Controls.Add(this.btnEditAgr);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCreateNewAgr);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.gvGenAgrLicences);
            this.Controls.Add(this.ctrlHeaderInfo);
            this.MinimumSize = new System.Drawing.Size(913, 527);
            this.Name = "MiddleControlCabinetAgent";
            this.Size = new System.Drawing.Size(913, 583);
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private InformationOfUserControl ctrlHeaderInfo;
        private Telerik.WinControls.UI.RadButton btnEditAgr;
        private Telerik.WinControls.UI.RadButton btnAccept;
        private Telerik.WinControls.UI.RadButton btnCreateNewAgr;
        private Telerik.WinControls.UI.RadButton btnView;
        private Telerik.WinControls.UI.RadGridView gvGenAgrLicences;
        private AgentFooterBR ctrlFooterInfo;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
    }
}
