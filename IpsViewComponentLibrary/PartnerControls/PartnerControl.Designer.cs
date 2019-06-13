namespace IpsViewComponentLibrary.PartnerControls
{
    partial class PartnerControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn1 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.treeView = new Telerik.WinControls.UI.RadTreeView();
            this.gvViewPartners = new Telerik.WinControls.UI.RadGridView();
            this.bsPartnerView = new System.Windows.Forms.BindingSource(this.components);
            this.rddBtnNewPartner = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnNewPartnerJur = new Telerik.WinControls.UI.RadMenuItem();
            this.btnNewPartnerPhis = new Telerik.WinControls.UI.RadMenuItem();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartnerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddBtnNewPartner)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(4, 30);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(150, 543);
            this.treeView.TabIndex = 0;
            this.treeView.ThemeName = "Office2013Light";
            // 
            // gvViewPartners
            // 
            this.gvViewPartners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewPartners.AutoScroll = true;
            this.gvViewPartners.AutoSizeRows = true;
            this.gvViewPartners.EnableCustomFiltering = true;
            this.gvViewPartners.Location = new System.Drawing.Point(160, 30);
            // 
            // 
            // 
            this.gvViewPartners.MasterTemplate.AllowAddNewRow = false;
            this.gvViewPartners.MasterTemplate.AllowDeleteRow = false;
            this.gvViewPartners.MasterTemplate.AllowDragToGroup = false;
            this.gvViewPartners.MasterTemplate.AllowEditRow = false;
            this.gvViewPartners.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewPartners.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "custid";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "AgrId";
            gridViewTextBoxColumn2.HeaderText = "ID договору";
            gridViewTextBoxColumn2.MaxWidth = 95;
            gridViewTextBoxColumn2.MinWidth = 95;
            gridViewTextBoxColumn2.Name = "AgrId";
            gridViewTextBoxColumn2.Width = 95;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "Innokpo";
            gridViewTextBoxColumn3.HeaderText = "ОКПО/ІД";
            gridViewTextBoxColumn3.MaxWidth = 95;
            gridViewTextBoxColumn3.MinWidth = 95;
            gridViewTextBoxColumn3.Name = "Innokpo";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn4.Expression = "";
            gridViewTextBoxColumn4.FieldName = "IsMy";
            gridViewTextBoxColumn4.HeaderText = "Співробітник компанії";
            gridViewTextBoxColumn4.MaxWidth = 85;
            gridViewTextBoxColumn4.MinWidth = 85;
            gridViewTextBoxColumn4.Name = "IsMy";
            gridViewTextBoxColumn4.Width = 85;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "Name";
            gridViewTextBoxColumn5.HeaderText = "Представник";
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "Name";
            gridViewTextBoxColumn5.Width = 245;
            gridViewTextBoxColumn6.FieldName = "AgrNumber";
            gridViewTextBoxColumn6.HeaderText = "№ договору";
            gridViewTextBoxColumn6.MaxWidth = 110;
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Name = "AgrNumber";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn7.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn7.FieldName = "AgrDate";
            gridViewTextBoxColumn7.FormatString = "{0:d}";
            gridViewTextBoxColumn7.HeaderText = "Дата договору";
            gridViewTextBoxColumn7.MaxWidth = 80;
            gridViewTextBoxColumn7.MinWidth = 80;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "AgrDate";
            gridViewTextBoxColumn7.Width = 80;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "JaCity";
            gridViewTextBoxColumn8.HeaderText = "Місто реєстрації";
            gridViewTextBoxColumn8.MinWidth = 70;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "JaCity";
            gridViewTextBoxColumn8.Width = 70;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "StatusName";
            gridViewTextBoxColumn9.HeaderText = "Статус договору";
            gridViewTextBoxColumn9.MaxWidth = 105;
            gridViewTextBoxColumn9.MinWidth = 105;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "StatusName";
            gridViewTextBoxColumn9.Width = 105;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn10.FieldName = "AgrCount";
            gridViewTextBoxColumn10.HeaderText = "К-сть договорів користувачів";
            gridViewTextBoxColumn10.MaxWidth = 80;
            gridViewTextBoxColumn10.MinWidth = 80;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "AgrCount";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn10.Width = 80;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewHyperlinkColumn1.DataType = typeof(System.Nullable<int>);
            gridViewHyperlinkColumn1.FieldName = "ClnCount";
            gridViewHyperlinkColumn1.HeaderText = "К-сть користувачів";
            gridViewHyperlinkColumn1.MaxWidth = 80;
            gridViewHyperlinkColumn1.MinWidth = 80;
            gridViewHyperlinkColumn1.Name = "ClnCount";
            gridViewHyperlinkColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewHyperlinkColumn1.Width = 80;
            gridViewHyperlinkColumn1.WrapText = true;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "viewBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 35;
            gridViewCommandColumn1.MinWidth = 35;
            gridViewCommandColumn1.Name = "viewBtn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 35;
            this.gvViewPartners.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewHyperlinkColumn1,
            gridViewCommandColumn1});
            this.gvViewPartners.MasterTemplate.DataSource = this.bsPartnerView;
            this.gvViewPartners.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableGrouping = false;
            this.gvViewPartners.MasterTemplate.ShowFilteringRow = false;
            this.gvViewPartners.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewPartners.Name = "gvViewPartners";
            this.gvViewPartners.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewPartners.ShowGroupPanel = false;
            this.gvViewPartners.Size = new System.Drawing.Size(1066, 514);
            this.gvViewPartners.TabIndex = 9;
            this.gvViewPartners.ThemeName = "Office2013Light";
            this.gvViewPartners.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewPartners_CellDoubleClick);
            this.gvViewPartners.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewPartners_CommandCellClick);
            // 
            // bsPartnerView
            // 
            this.bsPartnerView.DataSource = typeof(ipsFormsDesign.Interfaces.PartnerView);
            // 
            // rddBtnNewPartner
            // 
            this.rddBtnNewPartner.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnNewPartnerJur,
            this.btnNewPartnerPhis});
            this.rddBtnNewPartner.Location = new System.Drawing.Point(715, 4);
            this.rddBtnNewPartner.Name = "rddBtnNewPartner";
            this.rddBtnNewPartner.Size = new System.Drawing.Size(220, 20);
            this.rddBtnNewPartner.TabIndex = 11;
            this.rddBtnNewPartner.Text = "Створити нового представника";
            this.rddBtnNewPartner.ThemeName = "Office2013Light";
            // 
            // btnNewPartnerJur
            // 
            this.btnNewPartnerJur.Name = "btnNewPartnerJur";
            this.btnNewPartnerJur.Text = "Юридична особа";
            this.btnNewPartnerJur.Click += new System.EventHandler(this.btnNewPartnerJur_Click);
            // 
            // btnNewPartnerPhis
            // 
            this.btnNewPartnerPhis.Name = "btnNewPartnerPhis";
            this.btnNewPartnerPhis.Text = "Фізична особа";
            this.btnNewPartnerPhis.Click += new System.EventHandler(this.btnNewPartnerPhis_Click);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(161, 4);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 13;
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(1071, 548);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 16;
            // 
            // PartnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlGridRowCount);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.rddBtnNewPartner);
            this.Controls.Add(this.gvViewPartners);
            this.Controls.Add(this.treeView);
            this.Name = "PartnerControl";
            this.Size = new System.Drawing.Size(1229, 576);
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartnerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddBtnNewPartner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadTreeView treeView;
        private Telerik.WinControls.UI.RadGridView gvViewPartners;
        private Telerik.WinControls.UI.RadDropDownButton rddBtnNewPartner;
        private Telerik.WinControls.UI.RadMenuItem btnNewPartnerJur;
        private Telerik.WinControls.UI.RadMenuItem btnNewPartnerPhis;
        private Common.SearchTextBoxControl ctrlSearch;
        private Common.GridRowCountControl ctrlGridRowCount;
        private System.Windows.Forms.BindingSource bsPartnerView;
    }
}
