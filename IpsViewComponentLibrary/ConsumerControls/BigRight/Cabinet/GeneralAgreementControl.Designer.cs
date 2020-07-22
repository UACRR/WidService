namespace IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet
{
    partial class GeneralAgreementControl
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvGenAgrLicences = new Telerik.WinControls.UI.RadGridView();
            this.ctrlGeneralAgrDetailInfoBr = new IpsViewComponentLibrary.ConsumerControls.BigRight.GeneralAgrDetailInfoBr();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ddlActionOfGenAgr = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnProlongationGenAgr = new Telerik.WinControls.UI.RadMenuItem();
            this.btnChangeGenAgr = new Telerik.WinControls.UI.RadMenuItem();
            this.ddBtnStatusChangeGenAgr = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnStatusAcceptGenAgr = new Telerik.WinControls.UI.RadMenuItem();
            this.btnStatusClosedGenAgr = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlActionOfGenAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnStatusChangeGenAgr)).BeginInit();
            this.SuspendLayout();
            // 
            // gvGenAgrLicences
            // 
            this.gvGenAgrLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvGenAgrLicences.AutoSizeRows = true;
            this.gvGenAgrLicences.EnableCustomFiltering = true;
            this.gvGenAgrLicences.Location = new System.Drawing.Point(3, 3);
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
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.MinWidth = 0;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "CustName";
            gridViewTextBoxColumn2.Width = 385;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "AgrNumber";
            gridViewTextBoxColumn3.HeaderText = "№ Договору";
            gridViewTextBoxColumn3.MinWidth = 0;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "AgrNumber";
            gridViewTextBoxColumn3.Width = 140;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "DateBegin";
            gridViewTextBoxColumn4.FormatString = "{0:d}";
            gridViewTextBoxColumn4.HeaderText = "Дата початку";
            gridViewTextBoxColumn4.MinWidth = 0;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "DateBegin";
            gridViewTextBoxColumn4.Width = 93;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "DateEnd";
            gridViewTextBoxColumn5.FormatString = "{0:d}";
            gridViewTextBoxColumn5.HeaderText = "Дата завершення";
            gridViewTextBoxColumn5.MinWidth = 0;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "DateEnd";
            gridViewTextBoxColumn5.Width = 93;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "StatusName";
            gridViewTextBoxColumn6.HeaderText = "Стан";
            gridViewTextBoxColumn6.MinWidth = 0;
            gridViewTextBoxColumn6.Name = "StatusName";
            gridViewTextBoxColumn6.Width = 146;
            gridViewCommandColumn1.FieldName = "printBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "printBtn";
            gridViewCommandColumn1.Width = 30;
            this.gvGenAgrLicences.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1});
            this.gvGenAgrLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvGenAgrLicences.MasterTemplate.EnableFiltering = true;
            this.gvGenAgrLicences.MasterTemplate.EnableGrouping = false;
            this.gvGenAgrLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvGenAgrLicences.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvGenAgrLicences.Name = "gvGenAgrLicences";
            this.gvGenAgrLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvGenAgrLicences.Size = new System.Drawing.Size(908, 307);
            this.gvGenAgrLicences.TabIndex = 8;
            this.gvGenAgrLicences.ThemeName = "Office2013Light";
            this.gvGenAgrLicences.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvGenAgrLicences_CurrentRowChanged);
            this.gvGenAgrLicences.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvGenAgrLicences_CommandCellClick);
            // 
            // ctrlGeneralAgrDetailInfoBr
            // 
            this.ctrlGeneralAgrDetailInfoBr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlGeneralAgrDetailInfoBr.DataSourceLicense = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            this.ctrlGeneralAgrDetailInfoBr.Location = new System.Drawing.Point(3, 346);
            this.ctrlGeneralAgrDetailInfoBr.Name = "ctrlGeneralAgrDetailInfoBr";
            this.ctrlGeneralAgrDetailInfoBr.Size = new System.Drawing.Size(691, 110);
            this.ctrlGeneralAgrDetailInfoBr.TabIndex = 15;
            // 
            // ddlActionOfGenAgr
            // 
            this.ddlActionOfGenAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlActionOfGenAgr.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnProlongationGenAgr,
            this.btnChangeGenAgr});
            this.ddlActionOfGenAgr.Location = new System.Drawing.Point(771, 316);
            this.ddlActionOfGenAgr.Name = "ddlActionOfGenAgr";
            this.ddlActionOfGenAgr.Size = new System.Drawing.Size(140, 24);
            this.ddlActionOfGenAgr.TabIndex = 16;
            this.ddlActionOfGenAgr.Text = "Дії з договором";
            this.ddlActionOfGenAgr.ThemeName = "Office2013Light";
            // 
            // btnProlongationGenAgr
            // 
            this.btnProlongationGenAgr.Name = "btnProlongationGenAgr";
            this.btnProlongationGenAgr.Text = "Пролонгувати договір";
            this.btnProlongationGenAgr.Click += new System.EventHandler(this.btnProlongationGenAgr_Click);
            // 
            // btnChangeGenAgr
            // 
            this.btnChangeGenAgr.Name = "btnChangeGenAgr";
            this.btnChangeGenAgr.Text = "Змінити договір";
            this.btnChangeGenAgr.Click += new System.EventHandler(this.btnEditGenAgr_Click);
            // 
            // ddBtnStatusChangeGenAgr
            // 
            this.ddBtnStatusChangeGenAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddBtnStatusChangeGenAgr.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnStatusAcceptGenAgr,
            this.btnStatusClosedGenAgr});
            this.ddBtnStatusChangeGenAgr.Location = new System.Drawing.Point(625, 316);
            this.ddBtnStatusChangeGenAgr.Name = "ddBtnStatusChangeGenAgr";
            this.ddBtnStatusChangeGenAgr.Size = new System.Drawing.Size(140, 24);
            this.ddBtnStatusChangeGenAgr.TabIndex = 17;
            this.ddBtnStatusChangeGenAgr.Text = "Змінити статус";
            this.ddBtnStatusChangeGenAgr.ThemeName = "Office2013Light";
            // 
            // btnStatusAcceptGenAgr
            // 
            this.btnStatusAcceptGenAgr.Name = "btnStatusAcceptGenAgr";
            this.btnStatusAcceptGenAgr.Text = "Підтверджений";
            this.btnStatusAcceptGenAgr.UseCompatibleTextRendering = false;
            this.btnStatusAcceptGenAgr.Click += new System.EventHandler(this.btnStatusAcceptGenAgr_Click);
            // 
            // btnStatusClosedGenAgr
            // 
            this.btnStatusClosedGenAgr.Name = "btnStatusClosedGenAgr";
            this.btnStatusClosedGenAgr.Text = "Закритий";
            this.btnStatusClosedGenAgr.UseCompatibleTextRendering = false;
            this.btnStatusClosedGenAgr.Click += new System.EventHandler(this.btnStatusClosedGenAgr_Click);
            // 
            // GeneralAgreementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ddBtnStatusChangeGenAgr);
            this.Controls.Add(this.ddlActionOfGenAgr);
            this.Controls.Add(this.ctrlGeneralAgrDetailInfoBr);
            this.Controls.Add(this.gvGenAgrLicences);
            this.Name = "GeneralAgreementControl";
            this.Size = new System.Drawing.Size(915, 459);
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGenAgrLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlActionOfGenAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddBtnStatusChangeGenAgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView gvGenAgrLicences;
        private ConsumerControls.BigRight.GeneralAgrDetailInfoBr ctrlGeneralAgrDetailInfoBr;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadDropDownButton ddlActionOfGenAgr;
        private Telerik.WinControls.UI.RadMenuItem btnProlongationGenAgr;
        private Telerik.WinControls.UI.RadMenuItem btnChangeGenAgr;
        private Telerik.WinControls.UI.RadDropDownButton ddBtnStatusChangeGenAgr;
        private Telerik.WinControls.UI.RadMenuItem btnStatusAcceptGenAgr;
        private Telerik.WinControls.UI.RadMenuItem btnStatusClosedGenAgr;
    }
}
