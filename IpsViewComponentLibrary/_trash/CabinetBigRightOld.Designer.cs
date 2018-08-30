namespace IpsViewComponentLibrary
{
    partial class GlobalControlConsumerCabinetBR
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
            this.btnEditAgr = new Telerik.WinControls.UI.RadButton();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlCabinet = new IpsViewComponentLibrary.CabinetBigRight();
            this.ctrlHeaderInfo = new IpsViewComponentLibrary.ConsumerControls.ConsumerHeaderInfo();
            this.btnNewConsumer = new Telerik.WinControls.UI.RadButton();
            this.gvConsumerList = new Telerik.WinControls.UI.RadGridView();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditAgr
            // 
            this.btnEditAgr.Location = new System.Drawing.Point(315, 3);
            this.btnEditAgr.Name = "btnEditAgr";
            this.btnEditAgr.Size = new System.Drawing.Size(210, 20);
            this.btnEditAgr.TabIndex = 13;
            this.btnEditAgr.Text = "Редагувати анкету споживача";
            this.btnEditAgr.TextWrap = true;
            this.btnEditAgr.ThemeName = "Office2013Light";
            this.btnEditAgr.Click += new System.EventHandler(this.btnEditAgr_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1193, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(141, 20);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "До списку споживачів";
            this.btnBack.TextWrap = true;
            this.btnBack.ThemeName = "Office2013Light";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ctrlCabinet
            // 
            this.ctrlCabinet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlCabinet.AutoScroll = true;
            this.ctrlCabinet.CurentTab = IpsViewComponentLibrary.CabinetTabType.GeneralAgreement;
            this.ctrlCabinet.Location = new System.Drawing.Point(315, 214);
            this.ctrlCabinet.MusicDesignDelegate = null;
            this.ctrlCabinet.Name = "ctrlCabinet";
            this.ctrlCabinet.Size = new System.Drawing.Size(1019, 432);
            this.ctrlCabinet.TabIndex = 14;
            // 
            // ctrlHeaderInfo
            // 
            this.ctrlHeaderInfo.Location = new System.Drawing.Point(316, 30);
            this.ctrlHeaderInfo.MaximumSize = new System.Drawing.Size(836, 178);
            this.ctrlHeaderInfo.MinimumSize = new System.Drawing.Size(836, 178);
            this.ctrlHeaderInfo.Name = "ctrlHeaderInfo";
            this.ctrlHeaderInfo.Size = new System.Drawing.Size(836, 178);
            this.ctrlHeaderInfo.TabIndex = 15;
            // 
            // btnNewConsumer
            // 
            this.btnNewConsumer.Location = new System.Drawing.Point(531, 3);
            this.btnNewConsumer.Name = "btnNewConsumer";
            this.btnNewConsumer.Size = new System.Drawing.Size(210, 20);
            this.btnNewConsumer.TabIndex = 12;
            this.btnNewConsumer.Text = "Новий споживач";
            this.btnNewConsumer.TextWrap = true;
            this.btnNewConsumer.ThemeName = "Office2013Light";
            this.btnNewConsumer.Visible = false;
            this.btnNewConsumer.Click += new System.EventHandler(this.btnNewConsumer_Click);
            // 
            // gvConsumerList
            // 
            this.gvConsumerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gvConsumerList.AutoSizeRows = true;
            this.gvConsumerList.EnableCustomFiltering = true;
            this.gvConsumerList.Location = new System.Drawing.Point(3, 29);
            // 
            // 
            // 
            this.gvConsumerList.MasterTemplate.AllowAddNewRow = false;
            this.gvConsumerList.MasterTemplate.AllowDeleteRow = false;
            this.gvConsumerList.MasterTemplate.AllowDragToGroup = false;
            this.gvConsumerList.MasterTemplate.AllowEditRow = false;
            this.gvConsumerList.MasterTemplate.AutoGenerateColumns = false;
            this.gvConsumerList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "AgrNumber";
            gridViewTextBoxColumn1.HeaderText = "№ Ген. угоди";
            gridViewTextBoxColumn1.MaxWidth = 100;
            gridViewTextBoxColumn1.MinWidth = 100;
            gridViewTextBoxColumn1.Name = "AgrNumber";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "innokpo";
            gridViewTextBoxColumn2.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Innokpo";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 84;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "name";
            gridViewTextBoxColumn3.HeaderText = "Назва";
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "Name";
            gridViewTextBoxColumn3.Width = 181;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(int);
            gridViewTextBoxColumn4.FieldName = "countAgree";
            gridViewTextBoxColumn4.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "CountAgree";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 19;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.DataType = typeof(double);
            gridViewTextBoxColumn5.FieldName = "undistribamount";
            gridViewTextBoxColumn5.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "Undistribamount";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 24;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.DataType = typeof(int);
            gridViewTextBoxColumn6.FieldName = "CustId";
            gridViewTextBoxColumn6.HeaderText = "ID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "CustId";
            gridViewTextBoxColumn6.Width = 42;
            gridViewTextBoxColumn6.WrapText = true;
            this.gvConsumerList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gvConsumerList.MasterTemplate.EnableCustomFiltering = true;
            this.gvConsumerList.MasterTemplate.EnableFiltering = true;
            this.gvConsumerList.MasterTemplate.EnableGrouping = false;
            this.gvConsumerList.MasterTemplate.ShowFilteringRow = false;
            this.gvConsumerList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvConsumerList.Name = "gvConsumerList";
            this.gvConsumerList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvConsumerList.ReadOnly = true;
            this.gvConsumerList.Size = new System.Drawing.Size(306, 617);
            this.gvConsumerList.TabIndex = 9;
            this.gvConsumerList.ThemeName = "Office2013Light";
            this.gvConsumerList.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvConsumerList_CurrentRowChanged);
            this.gvConsumerList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvConsumerList_CustomFiltering);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.Size = new System.Drawing.Size(306, 20);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.ThemeName = "Office2013Light";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).BackgroundImage = null;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).Image = global::IpsViewComponentLibrary.Properties.Resources.search;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).HorizontalLineWidth = 0;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).RightToLeft = false;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ScaleTransform = new System.Drawing.SizeF(1F, 1F);
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Image = null;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).PositionOffset = new System.Drawing.SizeF(0F, 0F);
            // 
            // GlobalControlConsumerCabinetBR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlHeaderInfo);
            this.Controls.Add(this.ctrlCabinet);
            this.Controls.Add(this.btnEditAgr);
            this.Controls.Add(this.btnNewConsumer);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gvConsumerList);
            this.Name = "GlobalControlConsumerCabinetBR";
            this.Size = new System.Drawing.Size(1337, 649);
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnEditAgr;
        private Telerik.WinControls.UI.RadButton btnBack;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        public CabinetBigRight ctrlCabinet;
        private ConsumerControls.ConsumerHeaderInfo ctrlHeaderInfo;
        private Telerik.WinControls.UI.RadButton btnNewConsumer;
        private Telerik.WinControls.UI.RadGridView gvConsumerList;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
    }
}
