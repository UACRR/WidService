namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class ConsumersViewSmallRightControl
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
            this.ddbtnAddConsumer = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnAddJurConsumer = new Telerik.WinControls.UI.RadMenuItem();
            this.btnAddPhisConsumer = new Telerik.WinControls.UI.RadMenuItem();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.lblTextConsumers = new System.Windows.Forms.Label();
            this.lblCountConsumers = new System.Windows.Forms.Label();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnAddConsumer)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewConsumers
            // 
            this.gvViewConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewConsumers.EnableCustomFiltering = true;
            this.gvViewConsumers.Location = new System.Drawing.Point(3, 30);
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
            gridViewTextBoxColumn1.Width = 153;
            gridViewTextBoxColumn2.FieldName = "name";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 625;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "countAgree";
            gridViewTextBoxColumn3.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn3.Name = "CountAgree";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 153;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(double);
            gridViewTextBoxColumn4.FieldName = "undistribamount";
            gridViewTextBoxColumn4.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn4.Name = "Undistribamount";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 170;
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
            this.gvViewConsumers.Size = new System.Drawing.Size(1148, 536);
            this.gvViewConsumers.TabIndex = 3;
            this.gvViewConsumers.ThemeName = "Office2013Light";
            this.gvViewConsumers.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewConsumers_CellDoubleClick);
            this.gvViewConsumers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.rGridViewConsumers_CommandCellClick);
            // 
            // ddbtnAddConsumer
            // 
            this.ddbtnAddConsumer.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAddJurConsumer,
            this.btnAddPhisConsumer});
            this.ddbtnAddConsumer.Location = new System.Drawing.Point(488, 3);
            this.ddbtnAddConsumer.Name = "ddbtnAddConsumer";
            this.ddbtnAddConsumer.Size = new System.Drawing.Size(164, 20);
            this.ddbtnAddConsumer.TabIndex = 7;
            this.ddbtnAddConsumer.Text = "Новий користувач";
            this.ddbtnAddConsumer.ThemeName = "Office2013Light";
            // 
            // btnAddJurConsumer
            // 
            this.btnAddJurConsumer.Name = "btnAddJurConsumer";
            this.btnAddJurConsumer.Text = "Юридична особа";
            this.btnAddJurConsumer.Click += new System.EventHandler(this.btnAddJurConsumer_Click);
            // 
            // btnAddPhisConsumer
            // 
            this.btnAddPhisConsumer.Name = "btnAddPhisConsumer";
            this.btnAddPhisConsumer.Text = "Фізична особа";
            this.btnAddPhisConsumer.Click += new System.EventHandler(this.btnAddPhisConsumer_Click);
            // 
            // lblTextConsumers
            // 
            this.lblTextConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextConsumers.Location = new System.Drawing.Point(1013, 569);
            this.lblTextConsumers.Name = "lblTextConsumers";
            this.lblTextConsumers.Size = new System.Drawing.Size(68, 13);
            this.lblTextConsumers.TabIndex = 8;
            this.lblTextConsumers.Text = "К-ть рядків";
            // 
            // lblCountConsumers
            // 
            this.lblCountConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountConsumers.Location = new System.Drawing.Point(1087, 569);
            this.lblCountConsumers.Name = "lblCountConsumers";
            this.lblCountConsumers.Size = new System.Drawing.Size(64, 16);
            this.lblCountConsumers.TabIndex = 9;
            this.lblCountConsumers.Text = "0";
            this.lblCountConsumers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 3);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(479, 20);
            this.ctrlSearch.TabIndex = 6;
            // 
            // ConsumersViewSmallRightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblCountConsumers);
            this.Controls.Add(this.lblTextConsumers);
            this.Controls.Add(this.ddbtnAddConsumer);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.gvViewConsumers);
            this.Name = "ConsumersViewSmallRightControl";
            this.Size = new System.Drawing.Size(1154, 588);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnAddConsumer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvViewConsumers;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadDropDownButton ddbtnAddConsumer;
        private Telerik.WinControls.UI.RadMenuItem btnAddJurConsumer;
        private Telerik.WinControls.UI.RadMenuItem btnAddPhisConsumer;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.Label lblTextConsumers;
        private System.Windows.Forms.Label lblCountConsumers;
    }
}
