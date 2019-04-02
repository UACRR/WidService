namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityControl
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
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn1 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gvViewPartners = new Telerik.WinControls.UI.RadGridView();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.btnAddCommunity = new Telerik.WinControls.UI.RadButton();
            this.panelBottom = new Telerik.WinControls.UI.RadPanel();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            this.bsCommunityListView = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddCommunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunityListView)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewPartners
            // 
            this.gvViewPartners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewPartners.AutoScroll = true;
            this.gvViewPartners.AutoSizeRows = true;
            this.gvViewPartners.EnableCustomFiltering = true;
            this.gvViewPartners.Location = new System.Drawing.Point(3, 29);
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
            gridViewTextBoxColumn2.FieldName = "InnerCode";
            gridViewTextBoxColumn2.HeaderText = "Шифр";
            gridViewTextBoxColumn2.MaxWidth = 95;
            gridViewTextBoxColumn2.MinWidth = 95;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "InnerCode";
            gridViewTextBoxColumn2.Width = 95;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "InterCode";
            gridViewTextBoxColumn3.HeaderText = "IPI";
            gridViewTextBoxColumn3.MaxWidth = 95;
            gridViewTextBoxColumn3.MinWidth = 95;
            gridViewTextBoxColumn3.Name = "InterCode";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.HeaderText = "Назва товариства";
            gridViewTextBoxColumn4.MinWidth = 80;
            gridViewTextBoxColumn4.Name = "Name";
            gridViewTextBoxColumn4.Width = 540;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn5.FieldName = "RegistrDate";
            gridViewTextBoxColumn5.FormatString = "{0:d}";
            gridViewTextBoxColumn5.HeaderText = "Дата створення";
            gridViewTextBoxColumn5.MaxWidth = 80;
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "RegistrDate";
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewHyperlinkColumn1.DataType = typeof(System.Nullable<int>);
            gridViewHyperlinkColumn1.FieldName = "CountAuthors";
            gridViewHyperlinkColumn1.HeaderText = "К-сть авторів";
            gridViewHyperlinkColumn1.MaxWidth = 60;
            gridViewHyperlinkColumn1.MinWidth = 60;
            gridViewHyperlinkColumn1.Name = "CountAuthors";
            gridViewHyperlinkColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewHyperlinkColumn1.Width = 60;
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
            gridViewHyperlinkColumn1,
            gridViewCommandColumn1});
            this.gvViewPartners.MasterTemplate.DataSource = this.bsCommunityListView;
            this.gvViewPartners.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableGrouping = false;
            this.gvViewPartners.MasterTemplate.ShowFilteringRow = false;
            this.gvViewPartners.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewPartners.Name = "gvViewPartners";
            this.gvViewPartners.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewPartners.Size = new System.Drawing.Size(926, 437);
            this.gvViewPartners.TabIndex = 11;
            this.gvViewPartners.ThemeName = "Office2013Light";
            this.gvViewPartners.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewPartners_CellDoubleClick);
            this.gvViewPartners.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewPartners_CommandCellClick);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 3);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(479, 20);
            this.ctrlSearch.TabIndex = 12;
            // 
            // btnAddCommunity
            // 
            this.btnAddCommunity.Location = new System.Drawing.Point(488, 3);
            this.btnAddCommunity.Name = "btnAddCommunity";
            this.btnAddCommunity.Size = new System.Drawing.Size(164, 20);
            this.btnAddCommunity.TabIndex = 13;
            this.btnAddCommunity.Text = "Додати нове товариство";
            this.btnAddCommunity.ThemeName = "Office2013Light";
            this.btnAddCommunity.Click += new System.EventHandler(this.btnAddCommunity_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottom.Controls.Add(this.ctrlGridRowCount);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 467);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(932, 29);
            this.panelBottom.TabIndex = 16;
            this.panelBottom.ThemeName = "Office2013Light";
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(774, 1);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 0;
            // 
            // bsCommunityListView
            // 
            this.bsCommunityListView.DataSource = typeof(ipsFormsDesign.Interfaces.CommunityListView);
            // 
            // CommunityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.btnAddCommunity);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.gvViewPartners);
            this.Name = "CommunityControl";
            this.Size = new System.Drawing.Size(932, 496);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddCommunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunityListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadGridView gvViewPartners;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadButton btnAddCommunity;
        private Telerik.WinControls.UI.RadPanel panelBottom;
        private Common.GridRowCountControl ctrlGridRowCount;
        private System.Windows.Forms.BindingSource bsCommunityListView;
    }
}
