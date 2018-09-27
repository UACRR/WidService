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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn2 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.treeView = new Telerik.WinControls.UI.RadTreeView();
            this.gvViewPartners = new Telerik.WinControls.UI.RadGridView();
            this.rddBtnNewPartner = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnNewPartnerJur = new Telerik.WinControls.UI.RadMenuItem();
            this.btnNewPartnerPhis = new Telerik.WinControls.UI.RadMenuItem();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).BeginInit();
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
            gridViewTextBoxColumn10.DataType = typeof(int);
            gridViewTextBoxColumn10.FieldName = "CustId";
            gridViewTextBoxColumn10.HeaderText = "ID";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "CustId";
            gridViewTextBoxColumn11.FieldName = "AgrId";
            gridViewTextBoxColumn11.HeaderText = "ID договору";
            gridViewTextBoxColumn11.MaxWidth = 95;
            gridViewTextBoxColumn11.MinWidth = 95;
            gridViewTextBoxColumn11.Multiline = true;
            gridViewTextBoxColumn11.Name = "AgrId";
            gridViewTextBoxColumn11.Width = 95;
            gridViewTextBoxColumn11.WrapText = true;
            gridViewTextBoxColumn12.DataType = typeof(int);
            gridViewTextBoxColumn12.FieldName = "Innokpo";
            gridViewTextBoxColumn12.HeaderText = "ОКПО/ІД";
            gridViewTextBoxColumn12.MaxWidth = 95;
            gridViewTextBoxColumn12.MinWidth = 95;
            gridViewTextBoxColumn12.Name = "Innokpo";
            gridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn12.Width = 95;
            gridViewTextBoxColumn13.FieldName = "Name";
            gridViewTextBoxColumn13.HeaderText = "Представник";
            gridViewTextBoxColumn13.MinWidth = 80;
            gridViewTextBoxColumn13.Name = "Name";
            gridViewTextBoxColumn13.Width = 308;
            gridViewTextBoxColumn14.FieldName = "AgrNumber";
            gridViewTextBoxColumn14.HeaderText = "№ договору";
            gridViewTextBoxColumn14.MaxWidth = 110;
            gridViewTextBoxColumn14.Name = "AgrNumber";
            gridViewTextBoxColumn14.Width = 109;
            gridViewTextBoxColumn15.FieldName = "AgrDate";
            gridViewTextBoxColumn15.FormatString = "{0:d}";
            gridViewTextBoxColumn15.HeaderText = "Дата договору";
            gridViewTextBoxColumn15.MaxWidth = 80;
            gridViewTextBoxColumn15.MinWidth = 80;
            gridViewTextBoxColumn15.Multiline = true;
            gridViewTextBoxColumn15.Name = "AgrDate";
            gridViewTextBoxColumn15.Width = 80;
            gridViewTextBoxColumn15.WrapText = true;
            gridViewTextBoxColumn16.FieldName = "JaCity";
            gridViewTextBoxColumn16.HeaderText = "Місто реєстрації";
            gridViewTextBoxColumn16.MinWidth = 0;
            gridViewTextBoxColumn16.Multiline = true;
            gridViewTextBoxColumn16.Name = "JaCity";
            gridViewTextBoxColumn16.Width = 102;
            gridViewTextBoxColumn16.WrapText = true;
            gridViewTextBoxColumn17.FieldName = "StatusName";
            gridViewTextBoxColumn17.HeaderText = "Статус договору";
            gridViewTextBoxColumn17.MinWidth = 0;
            gridViewTextBoxColumn17.Multiline = true;
            gridViewTextBoxColumn17.Name = "StatusName";
            gridViewTextBoxColumn17.Width = 105;
            gridViewTextBoxColumn17.WrapText = true;
            gridViewTextBoxColumn18.FieldName = "AgrCount";
            gridViewTextBoxColumn18.HeaderText = "К-сть договорів клієнтів";
            gridViewTextBoxColumn18.MaxWidth = 60;
            gridViewTextBoxColumn18.MinWidth = 60;
            gridViewTextBoxColumn18.Multiline = true;
            gridViewTextBoxColumn18.Name = "AgrCount";
            gridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn18.Width = 60;
            gridViewTextBoxColumn18.WrapText = true;
            gridViewHyperlinkColumn2.FieldName = "ClnCount";
            gridViewHyperlinkColumn2.HeaderText = "К-сть клієнтів";
            gridViewHyperlinkColumn2.MaxWidth = 60;
            gridViewHyperlinkColumn2.MinWidth = 60;
            gridViewHyperlinkColumn2.Name = "ClnCount";
            gridViewHyperlinkColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewHyperlinkColumn2.Width = 60;
            gridViewHyperlinkColumn2.WrapText = true;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.AllowSort = false;
            gridViewCommandColumn2.DefaultText = "Відкрити";
            gridViewCommandColumn2.FieldName = "viewBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.MaxWidth = 35;
            gridViewCommandColumn2.MinWidth = 35;
            gridViewCommandColumn2.Name = "viewBtn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 35;
            this.gvViewPartners.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewHyperlinkColumn2,
            gridViewCommandColumn2});
            this.gvViewPartners.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableGrouping = false;
            this.gvViewPartners.MasterTemplate.ShowFilteringRow = false;
            this.gvViewPartners.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvViewPartners.Name = "gvViewPartners";
            this.gvViewPartners.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewPartners.Size = new System.Drawing.Size(1066, 512);
            this.gvViewPartners.TabIndex = 9;
            this.gvViewPartners.ThemeName = "Office2013Light";
            this.gvViewPartners.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewPartners_CommandCellClick);
            this.gvViewPartners.HyperlinkOpening += new Telerik.WinControls.UI.HyperlinkOpeningEventHandler(this.gvViewPartners_HyperlinkOpening);
            // 
            // rddBtnNewPartner
            // 
            this.rddBtnNewPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rddBtnNewPartner.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnNewPartnerJur,
            this.btnNewPartnerPhis});
            this.rddBtnNewPartner.Location = new System.Drawing.Point(161, 548);
            this.rddBtnNewPartner.Name = "rddBtnNewPartner";
            this.rddBtnNewPartner.Size = new System.Drawing.Size(220, 24);
            this.rddBtnNewPartner.TabIndex = 11;
            this.rddBtnNewPartner.Text = "Створити нового представника";
            this.rddBtnNewPartner.ThemeName = "Office2013Light";
            // 
            // btnNewPartnerJur
            // 
            this.btnNewPartnerJur.Enabled = false;
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
            // PartnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.rddBtnNewPartner);
            this.Controls.Add(this.gvViewPartners);
            this.Controls.Add(this.treeView);
            this.Name = "PartnerControl";
            this.Size = new System.Drawing.Size(1229, 576);
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).EndInit();
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
    }
}
