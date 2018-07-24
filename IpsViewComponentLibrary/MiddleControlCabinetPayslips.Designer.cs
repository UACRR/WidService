namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetPayslips
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewRl = new Telerik.WinControls.UI.RadGridView();
            this.btnAddNewRl = new Telerik.WinControls.UI.RadButton();
            this.btnToAccept = new Telerik.WinControls.UI.RadButton();
            this.btnDeleteRl = new Telerik.WinControls.UI.RadButton();
            this.ctrlHeaderInfo = new IpsViewComponentLibrary.GeneralAgreementInfo();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewRl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewRl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewRl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteRl)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewRl
            // 
            this.gvViewRl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewRl.AutoScroll = true;
            this.gvViewRl.AutoSizeRows = true;
            this.gvViewRl.EnableCustomFiltering = true;
            this.gvViewRl.Location = new System.Drawing.Point(4, 89);
            // 
            // 
            // 
            this.gvViewRl.MasterTemplate.AllowAddNewRow = false;
            this.gvViewRl.MasterTemplate.AllowDeleteRow = false;
            this.gvViewRl.MasterTemplate.AllowDragToGroup = false;
            this.gvViewRl.MasterTemplate.AllowEditRow = false;
            this.gvViewRl.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewRl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "PeriodName";
            gridViewTextBoxColumn2.HeaderText = "Назва періоду";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 80;
            gridViewTextBoxColumn2.Name = "PeriodName";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 81;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "CreateDate";
            gridViewTextBoxColumn3.FormatString = "{0:d}";
            gridViewTextBoxColumn3.HeaderText = "Дата Р/Л";
            gridViewTextBoxColumn3.MaxWidth = 95;
            gridViewTextBoxColumn3.MinWidth = 95;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "CreateDate";
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "FullAmount";
            gridViewTextBoxColumn4.HeaderText = "Сума збору";
            gridViewTextBoxColumn4.MinWidth = 100;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "FullAmount";
            gridViewTextBoxColumn4.Width = 102;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "RAmount";
            gridViewTextBoxColumn5.HeaderText = "Сума авторського гонорару";
            gridViewTextBoxColumn5.MinWidth = 100;
            gridViewTextBoxColumn5.Name = "RAmount";
            gridViewTextBoxColumn5.Width = 102;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "PaidAmount";
            gridViewTextBoxColumn6.HeaderText = "Сума закріплених платежів";
            gridViewTextBoxColumn6.MinWidth = 100;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "PaidAmount";
            gridViewTextBoxColumn6.Width = 102;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "DistribAmount";
            gridViewTextBoxColumn7.HeaderText = "Розподілено коштів на об\'єкти права";
            gridViewTextBoxColumn7.MinWidth = 100;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "DistribAmount";
            gridViewTextBoxColumn7.Width = 102;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "Borg";
            gridViewTextBoxColumn8.HeaderText = "Борг";
            gridViewTextBoxColumn8.MinWidth = 100;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "Borg";
            gridViewTextBoxColumn8.Width = 102;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "PrepaySum";
            gridViewTextBoxColumn9.HeaderText = "За рахунок авансу";
            gridViewTextBoxColumn9.MinWidth = 100;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "PrepaySum";
            gridViewTextBoxColumn9.Width = 102;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.DataType = typeof(double);
            gridViewTextBoxColumn10.FieldName = "StatusName";
            gridViewTextBoxColumn10.HeaderText = "Статус";
            gridViewTextBoxColumn10.MinWidth = 100;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "StatusName";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn10.Width = 102;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Файли";
            gridViewCommandColumn1.FieldName = "btnsView";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 35;
            gridViewCommandColumn1.MinWidth = 35;
            gridViewCommandColumn1.Name = "btnsView";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewCommandColumn1.Width = 35;
            gridViewCommandColumn1.WrapText = true;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.AllowSort = false;
            gridViewCommandColumn2.DefaultText = "Відкрити";
            gridViewCommandColumn2.FieldName = "btnsEdit";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.MaxWidth = 35;
            gridViewCommandColumn2.MinWidth = 35;
            gridViewCommandColumn2.Name = "btnsEdit";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 35;
            gridViewCommandColumn2.WrapText = true;
            this.gvViewRl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvViewRl.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewRl.MasterTemplate.EnableFiltering = true;
            this.gvViewRl.MasterTemplate.EnableGrouping = false;
            this.gvViewRl.MasterTemplate.ShowFilteringRow = false;
            this.gvViewRl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewRl.Name = "gvViewRl";
            this.gvViewRl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewRl.Size = new System.Drawing.Size(976, 346);
            this.gvViewRl.TabIndex = 7;
            this.gvViewRl.ThemeName = "Office2013Light";
            this.gvViewRl.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewRl_CommandCellClick);
            // 
            // btnAddNewRl
            // 
            this.btnAddNewRl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNewRl.Location = new System.Drawing.Point(4, 441);
            this.btnAddNewRl.Name = "btnAddNewRl";
            this.btnAddNewRl.Size = new System.Drawing.Size(130, 24);
            this.btnAddNewRl.TabIndex = 8;
            this.btnAddNewRl.Text = "Додати новий Р/Л";
            this.btnAddNewRl.ThemeName = "Office2013Light";
            this.btnAddNewRl.Click += new System.EventHandler(this.btnAddNewRl_Click);
            // 
            // btnToAccept
            // 
            this.btnToAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToAccept.Location = new System.Drawing.Point(140, 441);
            this.btnToAccept.Name = "btnToAccept";
            this.btnToAccept.Size = new System.Drawing.Size(130, 24);
            this.btnToAccept.TabIndex = 9;
            this.btnToAccept.Text = "Направити на акцепт";
            this.btnToAccept.ThemeName = "Office2013Light";
            this.btnToAccept.Click += new System.EventHandler(this.btnToAccept_Click);
            // 
            // btnDeleteRl
            // 
            this.btnDeleteRl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteRl.Location = new System.Drawing.Point(276, 441);
            this.btnDeleteRl.Name = "btnDeleteRl";
            this.btnDeleteRl.Size = new System.Drawing.Size(130, 24);
            this.btnDeleteRl.TabIndex = 10;
            this.btnDeleteRl.Text = "Вилучити Р/Л";
            this.btnDeleteRl.ThemeName = "Office2013Light";
            this.btnDeleteRl.Click += new System.EventHandler(this.btnDeleteRl_Click);
            // 
            // ctrlHeaderInfo
            // 
            this.ctrlHeaderInfo.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            this.ctrlHeaderInfo.Location = new System.Drawing.Point(4, 4);
            this.ctrlHeaderInfo.MaximumSize = new System.Drawing.Size(705, 79);
            this.ctrlHeaderInfo.MinimumSize = new System.Drawing.Size(705, 79);
            this.ctrlHeaderInfo.Name = "ctrlHeaderInfo";
            this.ctrlHeaderInfo.Size = new System.Drawing.Size(705, 79);
            this.ctrlHeaderInfo.TabIndex = 0;
            // 
            // MiddleControlCabinetPayslips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteRl);
            this.Controls.Add(this.btnToAccept);
            this.Controls.Add(this.btnAddNewRl);
            this.Controls.Add(this.gvViewRl);
            this.Controls.Add(this.ctrlHeaderInfo);
            this.Name = "MiddleControlCabinetPayslips";
            this.Size = new System.Drawing.Size(983, 468);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewRl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewRl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewRl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteRl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralAgreementInfo ctrlHeaderInfo;
        private Telerik.WinControls.UI.RadGridView gvViewRl;
        private Telerik.WinControls.UI.RadButton btnAddNewRl;
        private Telerik.WinControls.UI.RadButton btnToAccept;
        private Telerik.WinControls.UI.RadButton btnDeleteRl;
    }
}
