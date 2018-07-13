namespace IpsViewComponentLibrary
{
    partial class GlobalControlConsumerMainGrid
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewConsumers = new Telerik.WinControls.UI.RadGridView();
            this.btnNewConsumer = new Telerik.WinControls.UI.RadButton();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewConsumers
            // 
            this.gvViewConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewConsumers.EnableCustomFiltering = true;
            this.gvViewConsumers.Location = new System.Drawing.Point(3, 34);
            // 
            // 
            // 
            this.gvViewConsumers.MasterTemplate.AllowAddNewRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDeleteRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDragToGroup = false;
            this.gvViewConsumers.MasterTemplate.AllowEditRow = false;
            this.gvViewConsumers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "innokpo";
            gridViewTextBoxColumn1.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn1.Name = "Innokpo";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 137;
            gridViewTextBoxColumn2.FieldName = "name";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 563;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "countAgree";
            gridViewTextBoxColumn3.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn3.Name = "CountAgree";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 137;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(double);
            gridViewTextBoxColumn4.FieldName = "undistribamount";
            gridViewTextBoxColumn4.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn4.Name = "Undistribamount";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 155;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.DataType = typeof(int);
            gridViewTextBoxColumn5.FieldName = "custId";
            gridViewTextBoxColumn5.HeaderText = "ID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "CustId";
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "btnsEdit";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 25;
            gridViewCommandColumn1.MinWidth = 25;
            gridViewCommandColumn1.Name = "btnsEdit";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 25;
            this.gvViewConsumers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1});
            this.gvViewConsumers.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableGrouping = false;
            this.gvViewConsumers.MasterTemplate.ShowFilteringRow = false;
            this.gvViewConsumers.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewConsumers.Name = "gvViewConsumers";
            this.gvViewConsumers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewConsumers.Size = new System.Drawing.Size(1034, 547);
            this.gvViewConsumers.TabIndex = 3;
            this.gvViewConsumers.ThemeName = "Office2007Silver";
            this.gvViewConsumers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rGridViewConsumers_CommandCellClick);
            this.gvViewConsumers.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvViewConsumers_CustomFiltering);
            // 
            // btnNewConsumer
            // 
            this.btnNewConsumer.Location = new System.Drawing.Point(488, 4);
            this.btnNewConsumer.Name = "btnNewConsumer";
            this.btnNewConsumer.Size = new System.Drawing.Size(159, 24);
            this.btnNewConsumer.TabIndex = 4;
            this.btnNewConsumer.Text = "Новий споживач";
            this.btnNewConsumer.ThemeName = "Office2007Silver";
            this.btnNewConsumer.Click += new System.EventHandler(this.btnNewConsumer_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.Size = new System.Drawing.Size(479, 20);
            this.txtSearch.TabIndex = 5;
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
            // GlobalControlConsumerMainGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnNewConsumer);
            this.Controls.Add(this.gvViewConsumers);
            this.Name = "GlobalControlConsumerMainGrid";
            this.Size = new System.Drawing.Size(1040, 584);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvViewConsumers;
        private Telerik.WinControls.UI.RadButton btnNewConsumer;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
    }
}
