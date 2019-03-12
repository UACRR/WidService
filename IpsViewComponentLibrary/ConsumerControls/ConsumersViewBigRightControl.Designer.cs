namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class ConsumersViewBigRightControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewConsumers = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnNewConsumer = new Telerik.WinControls.UI.RadButton();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewConsumers
            // 
            this.gvViewConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewConsumers.AutoScroll = true;
            this.gvViewConsumers.AutoSizeRows = true;
            this.gvViewConsumers.EnableCustomFiltering = true;
            this.gvViewConsumers.Location = new System.Drawing.Point(3, 29);
            // 
            // 
            // 
            this.gvViewConsumers.MasterTemplate.AllowAddNewRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDeleteRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDragToGroup = false;
            this.gvViewConsumers.MasterTemplate.AllowEditRow = false;
            this.gvViewConsumers.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewConsumers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "Innokpo";
            gridViewTextBoxColumn2.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 80;
            gridViewTextBoxColumn2.Name = "Innokpo";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 85;
            gridViewTextBoxColumn3.FieldName = "AgrNumber";
            gridViewTextBoxColumn3.HeaderText = "№ Ген. договору";
            gridViewTextBoxColumn3.MaxWidth = 100;
            gridViewTextBoxColumn3.MinWidth = 78;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "AgrNumber";
            gridViewTextBoxColumn3.Width = 82;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.HeaderText = "Назва";
            gridViewTextBoxColumn4.MinWidth = 150;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "Name";
            gridViewTextBoxColumn4.Width = 183;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "JaCity";
            gridViewTextBoxColumn5.HeaderText = "Місто";
            gridViewTextBoxColumn5.MinWidth = 60;
            gridViewTextBoxColumn5.Name = "JaCity";
            gridViewTextBoxColumn5.StretchVertically = false;
            gridViewTextBoxColumn5.Width = 63;
            gridViewTextBoxColumn6.FieldName = "StatusName";
            gridViewTextBoxColumn6.HeaderText = "Статус Угоди";
            gridViewTextBoxColumn6.MaxWidth = 115;
            gridViewTextBoxColumn6.MinWidth = 115;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "StatusName";
            gridViewTextBoxColumn6.Width = 115;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "CountLic1Active";
            gridViewTextBoxColumn7.HeaderText = "К-сть ліцензій";
            gridViewTextBoxColumn7.MaxWidth = 55;
            gridViewTextBoxColumn7.MinWidth = 55;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "CountLic1Active";
            gridViewTextBoxColumn7.Width = 55;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "CountLic2Active";
            gridViewTextBoxColumn8.HeaderText = "К-сть заявок";
            gridViewTextBoxColumn8.MaxWidth = 55;
            gridViewTextBoxColumn8.MinWidth = 55;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "CountLic2Active";
            gridViewTextBoxColumn8.Width = 55;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "CountLic3Active";
            gridViewTextBoxColumn9.HeaderText = "К-сть довідок";
            gridViewTextBoxColumn9.MaxWidth = 55;
            gridViewTextBoxColumn9.MinWidth = 55;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "CountLic3Active";
            gridViewTextBoxColumn9.Width = 55;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.DataType = typeof(double);
            gridViewTextBoxColumn10.FieldName = "UndistribAmount";
            gridViewTextBoxColumn10.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn10.MinWidth = 100;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "UndistribAmount";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn10.Width = 105;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewTextBoxColumn11.FieldName = "UnattachAmount";
            gridViewTextBoxColumn11.HeaderText = "Незакріплені кошти";
            gridViewTextBoxColumn11.MinWidth = 100;
            gridViewTextBoxColumn11.Multiline = true;
            gridViewTextBoxColumn11.Name = "UnattachAmount";
            gridViewTextBoxColumn11.Width = 105;
            gridViewTextBoxColumn11.WrapText = true;
            gridViewTextBoxColumn12.FieldName = "Borg";
            gridViewTextBoxColumn12.HeaderText = "Борг";
            gridViewTextBoxColumn12.MaxWidth = 100;
            gridViewTextBoxColumn12.MinWidth = 100;
            gridViewTextBoxColumn12.Name = "Borg";
            gridViewTextBoxColumn12.Width = 100;
            gridViewTextBoxColumn13.FieldName = "PartnerName";
            gridViewTextBoxColumn13.HeaderText = "Представник";
            gridViewTextBoxColumn13.MinWidth = 80;
            gridViewTextBoxColumn13.Name = "PartnerName";
            gridViewTextBoxColumn13.Width = 96;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "btnsView";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 35;
            gridViewCommandColumn1.MinWidth = 35;
            gridViewCommandColumn1.Name = "btnsView";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 35;
            this.gvViewConsumers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewCommandColumn1});
            this.gvViewConsumers.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableGrouping = false;
            this.gvViewConsumers.MasterTemplate.ShowFilteringRow = false;
            this.gvViewConsumers.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewConsumers.Name = "gvViewConsumers";
            this.gvViewConsumers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewConsumers.Size = new System.Drawing.Size(1148, 556);
            this.gvViewConsumers.TabIndex = 6;
            this.gvViewConsumers.ThemeName = "Office2013Light";
            this.gvViewConsumers.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewConsumers_CellDoubleClick);
            this.gvViewConsumers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewConsumers_CommandCellClick);
            // 
            // btnNewConsumer
            // 
            this.btnNewConsumer.Location = new System.Drawing.Point(488, 3);
            this.btnNewConsumer.Name = "btnNewConsumer";
            this.btnNewConsumer.Size = new System.Drawing.Size(164, 20);
            this.btnNewConsumer.TabIndex = 10;
            this.btnNewConsumer.Text = "Новий користувач";
            this.btnNewConsumer.ThemeName = "Office2013Light";
            this.btnNewConsumer.Click += new System.EventHandler(this.btnNewConsumer_Click);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 3);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(479, 20);
            this.ctrlSearch.TabIndex = 11;
            // 
            // ConsumersViewBigRightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.btnNewConsumer);
            this.Controls.Add(this.gvViewConsumers);
            this.Name = "ConsumersViewBigRightControl";
            this.Size = new System.Drawing.Size(1154, 588);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView gvViewConsumers;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnNewConsumer;
        private Common.SearchTextBoxControl ctrlSearch;
    }
}
