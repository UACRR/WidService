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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
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
            this.lblTextPartners = new System.Windows.Forms.Label();
            this.lblCountPartners = new System.Windows.Forms.Label();
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
            gridViewTextBoxColumn11.DataType = typeof(int);
            gridViewTextBoxColumn11.FieldName = "CustId";
            gridViewTextBoxColumn11.HeaderText = "ID";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "CustId";
            gridViewTextBoxColumn12.FieldName = "AgrId";
            gridViewTextBoxColumn12.HeaderText = "ID договору";
            gridViewTextBoxColumn12.MaxWidth = 95;
            gridViewTextBoxColumn12.MinWidth = 95;
            gridViewTextBoxColumn12.Multiline = true;
            gridViewTextBoxColumn12.Name = "AgrId";
            gridViewTextBoxColumn12.Width = 95;
            gridViewTextBoxColumn12.WrapText = true;
            gridViewTextBoxColumn13.DataType = typeof(int);
            gridViewTextBoxColumn13.FieldName = "Innokpo";
            gridViewTextBoxColumn13.HeaderText = "ОКПО/ІД";
            gridViewTextBoxColumn13.MaxWidth = 95;
            gridViewTextBoxColumn13.MinWidth = 95;
            gridViewTextBoxColumn13.Name = "Innokpo";
            gridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn13.Width = 95;
            gridViewTextBoxColumn14.Expression = "";
            gridViewTextBoxColumn14.FieldName = "IsMy";
            gridViewTextBoxColumn14.HeaderText = "Співробітник компанії";
            gridViewTextBoxColumn14.MaxWidth = 85;
            gridViewTextBoxColumn14.MinWidth = 85;
            gridViewTextBoxColumn14.Name = "IsMy";
            gridViewTextBoxColumn14.Width = 85;
            gridViewTextBoxColumn14.WrapText = true;
            gridViewTextBoxColumn15.FieldName = "Name";
            gridViewTextBoxColumn15.HeaderText = "Представник";
            gridViewTextBoxColumn15.MinWidth = 80;
            gridViewTextBoxColumn15.Name = "Name";
            gridViewTextBoxColumn15.Width = 294;
            gridViewTextBoxColumn16.FieldName = "AgrNumber";
            gridViewTextBoxColumn16.HeaderText = "№ договору";
            gridViewTextBoxColumn16.MaxWidth = 110;
            gridViewTextBoxColumn16.Name = "AgrNumber";
            gridViewTextBoxColumn16.Width = 104;
            gridViewTextBoxColumn17.FieldName = "AgrDate";
            gridViewTextBoxColumn17.FormatString = "{0:d}";
            gridViewTextBoxColumn17.HeaderText = "Дата договору";
            gridViewTextBoxColumn17.MaxWidth = 80;
            gridViewTextBoxColumn17.MinWidth = 80;
            gridViewTextBoxColumn17.Multiline = true;
            gridViewTextBoxColumn17.Name = "AgrDate";
            gridViewTextBoxColumn17.Width = 80;
            gridViewTextBoxColumn17.WrapText = true;
            gridViewTextBoxColumn18.FieldName = "JaCity";
            gridViewTextBoxColumn18.HeaderText = "Місто реєстрації";
            gridViewTextBoxColumn18.MinWidth = 0;
            gridViewTextBoxColumn18.Multiline = true;
            gridViewTextBoxColumn18.Name = "JaCity";
            gridViewTextBoxColumn18.Width = 37;
            gridViewTextBoxColumn18.WrapText = true;
            gridViewTextBoxColumn19.FieldName = "StatusName";
            gridViewTextBoxColumn19.HeaderText = "Статус договору";
            gridViewTextBoxColumn19.MaxWidth = 105;
            gridViewTextBoxColumn19.MinWidth = 105;
            gridViewTextBoxColumn19.Multiline = true;
            gridViewTextBoxColumn19.Name = "StatusName";
            gridViewTextBoxColumn19.Width = 105;
            gridViewTextBoxColumn19.WrapText = true;
            gridViewTextBoxColumn20.FieldName = "AgrCount";
            gridViewTextBoxColumn20.HeaderText = "К-сть договорів клієнтів";
            gridViewTextBoxColumn20.MaxWidth = 60;
            gridViewTextBoxColumn20.MinWidth = 60;
            gridViewTextBoxColumn20.Multiline = true;
            gridViewTextBoxColumn20.Name = "AgrCount";
            gridViewTextBoxColumn20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn20.Width = 60;
            gridViewTextBoxColumn20.WrapText = true;
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
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
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
            this.gvViewPartners.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewPartners_CellDoubleClick);
            this.gvViewPartners.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewPartners_CommandCellClick);
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
            // lblTextPartners
            // 
            this.lblTextPartners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextPartners.Location = new System.Drawing.Point(1088, 548);
            this.lblTextPartners.Name = "lblTextPartners";
            this.lblTextPartners.Size = new System.Drawing.Size(68, 14);
            this.lblTextPartners.TabIndex = 14;
            this.lblTextPartners.Text = "К-ть рядків";
            // 
            // lblCountPartners
            // 
            this.lblCountPartners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountPartners.Location = new System.Drawing.Point(1162, 548);
            this.lblCountPartners.Name = "lblCountPartners";
            this.lblCountPartners.Size = new System.Drawing.Size(64, 14);
            this.lblCountPartners.TabIndex = 15;
            this.lblCountPartners.Text = "0";
            this.lblCountPartners.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PartnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCountPartners);
            this.Controls.Add(this.lblTextPartners);
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
        private System.Windows.Forms.Label lblTextPartners;
        private System.Windows.Forms.Label lblCountPartners;
    }
}
