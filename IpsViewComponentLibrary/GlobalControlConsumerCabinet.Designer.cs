namespace IpsViewComponentLibrary
{
    partial class GlobalControlConsumerCabinet
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvConsumerList = new Telerik.WinControls.UI.RadGridView();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnNewConsumer = new Telerik.WinControls.UI.RadButton();
            this.mсInfoAgrCalc = new IpsViewComponentLibrary.MiddleControlInfoAgrCalc();
            this.btnEditAgr = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).BeginInit();
            this.SuspendLayout();
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
            this.gvConsumerList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "innokpo";
            gridViewTextBoxColumn1.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn1.Multiline = true;
            gridViewTextBoxColumn1.Name = "Innokpo";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 85;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.FieldName = "name";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 201;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "countAgree";
            gridViewTextBoxColumn3.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "CountAgree";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 19;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(double);
            gridViewTextBoxColumn4.FieldName = "undistribamount";
            gridViewTextBoxColumn4.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "Undistribamount";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 24;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.DataType = typeof(int);
            gridViewTextBoxColumn5.FieldName = "CustId";
            gridViewTextBoxColumn5.HeaderText = "ID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "CustId";
            gridViewTextBoxColumn5.Width = 42;
            gridViewTextBoxColumn5.WrapText = true;
            this.gvConsumerList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvConsumerList.MasterTemplate.EnableCustomFiltering = true;
            this.gvConsumerList.MasterTemplate.EnableFiltering = true;
            this.gvConsumerList.MasterTemplate.EnableGrouping = false;
            this.gvConsumerList.MasterTemplate.ShowFilteringRow = false;
            this.gvConsumerList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvConsumerList.Name = "gvConsumerList";
            this.gvConsumerList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvConsumerList.ReadOnly = true;
            this.gvConsumerList.Size = new System.Drawing.Size(306, 664);
            this.gvConsumerList.TabIndex = 4;
            this.gvConsumerList.ThemeName = "Office2007Silver";
            this.gvConsumerList.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvConsumerList_CurrentRowChanged);
            this.gvConsumerList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvConsumerList_CustomFiltering);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1243, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(141, 20);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "До списку споживачів";
            this.btnBack.TextWrap = true;
            this.btnBack.ThemeName = "Office2007Silver";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.Size = new System.Drawing.Size(306, 20);
            this.txtSearch.TabIndex = 6;
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
            // btnNewConsumer
            // 
            this.btnNewConsumer.Location = new System.Drawing.Point(531, 3);
            this.btnNewConsumer.Name = "btnNewConsumer";
            this.btnNewConsumer.Size = new System.Drawing.Size(210, 20);
            this.btnNewConsumer.TabIndex = 7;
            this.btnNewConsumer.Text = "Новий споживач";
            this.btnNewConsumer.TextWrap = true;
            this.btnNewConsumer.ThemeName = "Office2007Silver";
            this.btnNewConsumer.Visible = false;
            this.btnNewConsumer.Click += new System.EventHandler(this.btnNewConsumer_Click);
            // 
            // mсInfoAgrCalc
            // 
            this.mсInfoAgrCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mсInfoAgrCalc.AutoScroll = true;
            this.mсInfoAgrCalc.Location = new System.Drawing.Point(315, 29);
            this.mсInfoAgrCalc.MinimumSize = new System.Drawing.Size(500, 665);
            this.mсInfoAgrCalc.Name = "mсInfoAgrCalc";
            this.mсInfoAgrCalc.Rights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.mсInfoAgrCalc.Size = new System.Drawing.Size(1069, 665);
            this.mсInfoAgrCalc.TabIndex = 0;
            // 
            // btnEditAgr
            // 
            this.btnEditAgr.Location = new System.Drawing.Point(315, 3);
            this.btnEditAgr.Name = "btnEditAgr";
            this.btnEditAgr.Size = new System.Drawing.Size(210, 20);
            this.btnEditAgr.TabIndex = 8;
            this.btnEditAgr.Text = "Редагувати анкету споживача";
            this.btnEditAgr.TextWrap = true;
            this.btnEditAgr.ThemeName = "Office2007Silver";
            this.btnEditAgr.Click += new System.EventHandler(this.btnEditAgr_Click);
            // 
            // GlobalControlConsumerCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditAgr);
            this.Controls.Add(this.btnNewConsumer);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gvConsumerList);
            this.Controls.Add(this.mсInfoAgrCalc);
            this.Name = "GlobalControlConsumerCabinet";
            this.Size = new System.Drawing.Size(1387, 696);
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView gvConsumerList;
        private Telerik.WinControls.UI.RadButton btnBack;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private Telerik.WinControls.UI.RadButton btnNewConsumer;
        private Telerik.WinControls.UI.RadButton btnEditAgr;
        public MiddleControlInfoAgrCalc mсInfoAgrCalc;
    }
}
