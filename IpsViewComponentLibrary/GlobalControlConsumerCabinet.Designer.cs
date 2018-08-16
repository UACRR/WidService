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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvConsumerList = new Telerik.WinControls.UI.RadGridView();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnNewConsumer = new Telerik.WinControls.UI.RadButton();
            this.btnEditAgr = new Telerik.WinControls.UI.RadButton();
            this.mсInfoAgrCalc = new IpsViewComponentLibrary.MiddleControlInfoAgrCalc();
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
            gridViewTextBoxColumn6.DataType = typeof(int);
            gridViewTextBoxColumn6.FieldName = "innokpo";
            gridViewTextBoxColumn6.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "Innokpo";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 83;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "name";
            gridViewTextBoxColumn7.HeaderText = "Назва";
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "Name";
            gridViewTextBoxColumn7.Width = 198;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.DataType = typeof(int);
            gridViewTextBoxColumn8.FieldName = "countAgree";
            gridViewTextBoxColumn8.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "CountAgree";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 19;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.DataType = typeof(double);
            gridViewTextBoxColumn9.FieldName = "undistribamount";
            gridViewTextBoxColumn9.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "Undistribamount";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 24;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.DataType = typeof(int);
            gridViewTextBoxColumn10.FieldName = "CustId";
            gridViewTextBoxColumn10.HeaderText = "ID";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "CustId";
            gridViewTextBoxColumn10.Width = 42;
            gridViewTextBoxColumn10.WrapText = true;
            this.gvConsumerList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.gvConsumerList.MasterTemplate.EnableCustomFiltering = true;
            this.gvConsumerList.MasterTemplate.EnableFiltering = true;
            this.gvConsumerList.MasterTemplate.EnableGrouping = false;
            this.gvConsumerList.MasterTemplate.ShowFilteringRow = false;
            this.gvConsumerList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvConsumerList.Name = "gvConsumerList";
            this.gvConsumerList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvConsumerList.ReadOnly = true;
            this.gvConsumerList.Size = new System.Drawing.Size(306, 664);
            this.gvConsumerList.TabIndex = 4;
            this.gvConsumerList.ThemeName = "Office2013Light";
            this.gvConsumerList.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvConsumerList_CurrentRowChanged);
            this.gvConsumerList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvConsumerList_CustomFiltering);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1146, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(141, 20);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "До списку споживачів";
            this.btnBack.TextWrap = true;
            this.btnBack.ThemeName = "Office2013Light";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.Size = new System.Drawing.Size(306, 20);
            this.txtSearch.TabIndex = 6;
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
            // btnNewConsumer
            // 
            this.btnNewConsumer.Location = new System.Drawing.Point(531, 3);
            this.btnNewConsumer.Name = "btnNewConsumer";
            this.btnNewConsumer.Size = new System.Drawing.Size(210, 20);
            this.btnNewConsumer.TabIndex = 7;
            this.btnNewConsumer.Text = "Новий споживач";
            this.btnNewConsumer.TextWrap = true;
            this.btnNewConsumer.ThemeName = "Office2013Light";
            this.btnNewConsumer.Visible = false;
            this.btnNewConsumer.Click += new System.EventHandler(this.btnNewConsumer_Click);
            // 
            // btnEditAgr
            // 
            this.btnEditAgr.Location = new System.Drawing.Point(315, 3);
            this.btnEditAgr.Name = "btnEditAgr";
            this.btnEditAgr.Size = new System.Drawing.Size(210, 20);
            this.btnEditAgr.TabIndex = 8;
            this.btnEditAgr.Text = "Редагувати анкету споживача";
            this.btnEditAgr.TextWrap = true;
            this.btnEditAgr.ThemeName = "Office2013Light";
            this.btnEditAgr.Click += new System.EventHandler(this.btnEditAgr_Click);
            // 
            // mсInfoAgrCalc
            // 
            this.mсInfoAgrCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mсInfoAgrCalc.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.mсInfoAgrCalc.Location = new System.Drawing.Point(315, 29);
            this.mсInfoAgrCalc.MinimumSize = new System.Drawing.Size(500, 665);
            this.mсInfoAgrCalc.Name = "mсInfoAgrCalc";
            this.mсInfoAgrCalc.Rights = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.mсInfoAgrCalc.Size = new System.Drawing.Size(972, 665);
            this.mсInfoAgrCalc.TabIndex = 0;
            // 
            // GlobalControlConsumerCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.Controls.Add(this.btnEditAgr);
            this.Controls.Add(this.btnNewConsumer);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gvConsumerList);
            this.Controls.Add(this.mсInfoAgrCalc);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1290, 696);
            this.Name = "GlobalControlConsumerCabinet";
            this.Size = new System.Drawing.Size(1290, 696);
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
