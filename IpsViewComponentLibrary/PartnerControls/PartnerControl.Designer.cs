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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.treeView = new Telerik.WinControls.UI.RadTreeView();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.gvViewPartners = new Telerik.WinControls.UI.RadGridView();
            this.rddBtnNewPartner = new Telerik.WinControls.UI.RadDropDownButton();
            this.btnNewPartnerJur = new Telerik.WinControls.UI.RadMenuItem();
            this.btnNewPartnerPhis = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
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
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(160, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.Size = new System.Drawing.Size(479, 20);
            this.txtSearch.TabIndex = 10;
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
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "AgrId";
            gridViewTextBoxColumn2.HeaderText = "ID договору";
            gridViewTextBoxColumn2.MaxWidth = 95;
            gridViewTextBoxColumn2.MinWidth = 95;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "AgrId";
            gridViewTextBoxColumn2.Width = 95;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "Innokpo";
            gridViewTextBoxColumn3.HeaderText = "ОКПО/ІД";
            gridViewTextBoxColumn3.MaxWidth = 95;
            gridViewTextBoxColumn3.MinWidth = 95;
            gridViewTextBoxColumn3.Name = "Innokpo";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.HeaderText = "Представник";
            gridViewTextBoxColumn4.MinWidth = 80;
            gridViewTextBoxColumn4.Name = "Name";
            gridViewTextBoxColumn4.Width = 313;
            gridViewTextBoxColumn5.FieldName = "AgrNumber";
            gridViewTextBoxColumn5.HeaderText = "№ договору";
            gridViewTextBoxColumn5.MaxWidth = 110;
            gridViewTextBoxColumn5.Name = "AgrNumber";
            gridViewTextBoxColumn5.Width = 110;
            gridViewTextBoxColumn6.FieldName = "AgrDate";
            gridViewTextBoxColumn6.FormatString = "{0:d}";
            gridViewTextBoxColumn6.HeaderText = "Дата договору";
            gridViewTextBoxColumn6.MaxWidth = 80;
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "AgrDate";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "JaCity";
            gridViewTextBoxColumn7.HeaderText = "Місто реєстрації";
            gridViewTextBoxColumn7.MinWidth = 0;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "JaCity";
            gridViewTextBoxColumn7.Width = 104;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "StatusName";
            gridViewTextBoxColumn8.HeaderText = "Статус договору";
            gridViewTextBoxColumn8.MinWidth = 0;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "StatusName";
            gridViewTextBoxColumn8.Width = 122;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "ClnCount";
            gridViewTextBoxColumn9.HeaderText = "К-сть клієнтів";
            gridViewTextBoxColumn9.MaxWidth = 60;
            gridViewTextBoxColumn9.MinWidth = 60;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "ClnCount";
            gridViewTextBoxColumn9.Width = 60;
            gridViewTextBoxColumn9.WrapText = true;
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
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.AllowSort = false;
            gridViewCommandColumn2.DefaultText = "Файли";
            gridViewCommandColumn2.FieldName = "deleteBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn2.MaxWidth = 35;
            gridViewCommandColumn2.MinWidth = 35;
            gridViewCommandColumn2.Name = "deleteBtn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewCommandColumn2.Width = 35;
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
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvViewPartners.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableGrouping = false;
            this.gvViewPartners.MasterTemplate.ShowFilteringRow = false;
            this.gvViewPartners.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewPartners.Name = "gvViewPartners";
            this.gvViewPartners.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewPartners.Size = new System.Drawing.Size(1066, 512);
            this.gvViewPartners.TabIndex = 9;
            this.gvViewPartners.ThemeName = "Office2013Light";
            this.gvViewPartners.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewPartners_CommandCellClick);
            this.gvViewPartners.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvViewConsumers_CustomFiltering);
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
            // PartnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rddBtnNewPartner);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gvViewPartners);
            this.Controls.Add(this.treeView);
            this.Name = "PartnerControl";
            this.Size = new System.Drawing.Size(1229, 576);
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddBtnNewPartner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadTreeView treeView;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private Telerik.WinControls.UI.RadGridView gvViewPartners;
        private Telerik.WinControls.UI.RadDropDownButton rddBtnNewPartner;
        private Telerik.WinControls.UI.RadMenuItem btnNewPartnerJur;
        private Telerik.WinControls.UI.RadMenuItem btnNewPartnerPhis;
    }
}
