namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    partial class PublisherAndSubpublisherControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvPublishers = new Telerik.WinControls.UI.RadGridView();
            this.bsPublisherAndSubpublisherView = new System.Windows.Forms.BindingSource(this.components);
            this.bottomPanel = new Telerik.WinControls.UI.RadPanel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            this.ipsPanel1 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPublisherAndSubpublisherView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).BeginInit();
            this.ipsPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvPublishers
            // 
            this.gvPublishers.AutoScroll = true;
            this.gvPublishers.AutoSizeRows = true;
            this.gvPublishers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPublishers.EnableCustomFiltering = true;
            this.gvPublishers.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvPublishers.MasterTemplate.AllowAddNewRow = false;
            this.gvPublishers.MasterTemplate.AllowDeleteRow = false;
            this.gvPublishers.MasterTemplate.AllowDragToGroup = false;
            this.gvPublishers.MasterTemplate.AllowEditRow = false;
            this.gvPublishers.MasterTemplate.AutoGenerateColumns = false;
            this.gvPublishers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustIdPub";
            gridViewTextBoxColumn1.HeaderText = "CustIdPub";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustIdPub";
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "CustIdSub";
            gridViewTextBoxColumn2.HeaderText = "CustIdSub";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "CustIdSub";
            gridViewTextBoxColumn2.Width = 47;
            gridViewTextBoxColumn3.FieldName = "PubName";
            gridViewTextBoxColumn3.HeaderText = "Назва Автора/Оригінального видавництва";
            gridViewTextBoxColumn3.MinWidth = 150;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "PubName";
            gridViewTextBoxColumn3.Width = 323;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "SubName";
            gridViewTextBoxColumn4.HeaderText = "Назва Уповноваж. Видавництва/Субвидавництва";
            gridViewTextBoxColumn4.MinWidth = 150;
            gridViewTextBoxColumn4.Name = "SubName";
            gridViewTextBoxColumn4.Width = 336;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn5.FieldName = "DateBegin";
            gridViewTextBoxColumn5.FormatString = "{0:d}";
            gridViewTextBoxColumn5.HeaderText = "Дата з";
            gridViewTextBoxColumn5.MaxWidth = 90;
            gridViewTextBoxColumn5.MinWidth = 90;
            gridViewTextBoxColumn5.Name = "DateBegin";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 90;
            gridViewTextBoxColumn6.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn6.FieldName = "DateEnd";
            gridViewTextBoxColumn6.FormatString = "{0:d}";
            gridViewTextBoxColumn6.HeaderText = "Дата по";
            gridViewTextBoxColumn6.MaxWidth = 90;
            gridViewTextBoxColumn6.MinWidth = 90;
            gridViewTextBoxColumn6.Name = "DateEnd";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 90;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "btnsView";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "btnsView";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            this.gvPublishers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1});
            this.gvPublishers.MasterTemplate.DataSource = this.bsPublisherAndSubpublisherView;
            this.gvPublishers.MasterTemplate.EnableCustomFiltering = true;
            this.gvPublishers.MasterTemplate.EnableFiltering = true;
            this.gvPublishers.MasterTemplate.EnableGrouping = false;
            this.gvPublishers.MasterTemplate.ShowFilteringRow = false;
            this.gvPublishers.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPublishers.Name = "gvPublishers";
            this.gvPublishers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPublishers.Size = new System.Drawing.Size(891, 343);
            this.gvPublishers.TabIndex = 7;
            this.gvPublishers.ThemeName = "Office2013Light";
            this.gvPublishers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvConsumers_CommandCellClick);
            // 
            // bsPublisherAndSubpublisherView
            // 
            this.bsPublisherAndSubpublisherView.DataSource = typeof(ipsFormsDesign.ViewModels.Other.PublisherAndSubpublisherView);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomPanel.Controls.Add(this.btnAdd);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 373);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(891, 30);
            this.bottomPanel.TabIndex = 8;
            this.bottomPanel.ThemeName = "Office2013Light";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Додати";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(733, 2);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 1;
            // 
            // ipsPanel1
            // 
            this.ipsPanel1.BorderVisible = false;
            this.ipsPanel1.Controls.Add(this.ctrlGridRowCount);
            this.ipsPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipsPanel1.Location = new System.Drawing.Point(0, 343);
            this.ipsPanel1.Name = "ipsPanel1";
            this.ipsPanel1.Size = new System.Drawing.Size(891, 30);
            this.ipsPanel1.TabIndex = 10;
            // 
            // PublisherAndSubpublisherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gvPublishers);
            this.Controls.Add(this.ipsPanel1);
            this.Controls.Add(this.bottomPanel);
            this.Name = "PublisherAndSubpublisherControl";
            this.Size = new System.Drawing.Size(891, 403);
            this.Load += new System.EventHandler(this.PublisherAndSubpublisherControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPublisherAndSubpublisherView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).EndInit();
            this.ipsPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvPublishers;
        private Telerik.WinControls.UI.RadPanel bottomPanel;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsPublisherAndSubpublisherView;
        private Common.GridRowCountControl ctrlGridRowCount;
        private Common.Editors.IpsPanel ipsPanel1;
    }
}
