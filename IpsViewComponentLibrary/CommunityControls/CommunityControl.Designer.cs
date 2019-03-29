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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn2 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gvViewPartners = new Telerik.WinControls.UI.RadGridView();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.btnAddCommunity = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountPartners = new System.Windows.Forms.Label();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddCommunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
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
            gridViewTextBoxColumn6.DataType = typeof(int);
            gridViewTextBoxColumn6.FieldName = "CustId";
            gridViewTextBoxColumn6.HeaderText = "ID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "CustId";
            gridViewTextBoxColumn7.FieldName = "InnerCode";
            gridViewTextBoxColumn7.HeaderText = "Шифр";
            gridViewTextBoxColumn7.MaxWidth = 95;
            gridViewTextBoxColumn7.MinWidth = 95;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "InnerCode";
            gridViewTextBoxColumn7.Width = 95;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.DataType = typeof(int);
            gridViewTextBoxColumn8.FieldName = "InterCode";
            gridViewTextBoxColumn8.HeaderText = "IPI";
            gridViewTextBoxColumn8.MaxWidth = 95;
            gridViewTextBoxColumn8.MinWidth = 95;
            gridViewTextBoxColumn8.Name = "InterCode";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 95;
            gridViewTextBoxColumn9.FieldName = "Name";
            gridViewTextBoxColumn9.HeaderText = "Назва товариства";
            gridViewTextBoxColumn9.MinWidth = 80;
            gridViewTextBoxColumn9.Name = "Name";
            gridViewTextBoxColumn9.Width = 540;
            gridViewTextBoxColumn10.FieldName = "RegistrDate";
            gridViewTextBoxColumn10.FormatString = "{0:d}";
            gridViewTextBoxColumn10.HeaderText = "Дата створення";
            gridViewTextBoxColumn10.MaxWidth = 80;
            gridViewTextBoxColumn10.MinWidth = 80;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "RegistrDate";
            gridViewTextBoxColumn10.Width = 80;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewHyperlinkColumn2.FieldName = "CountAuthors";
            gridViewHyperlinkColumn2.HeaderText = "К-сть авторів";
            gridViewHyperlinkColumn2.MaxWidth = 60;
            gridViewHyperlinkColumn2.MinWidth = 60;
            gridViewHyperlinkColumn2.Name = "CountAuthors";
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
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewHyperlinkColumn2,
            gridViewCommandColumn2});
            this.gvViewPartners.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableFiltering = true;
            this.gvViewPartners.MasterTemplate.EnableGrouping = false;
            this.gvViewPartners.MasterTemplate.ShowFilteringRow = false;
            this.gvViewPartners.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvViewPartners.Name = "gvViewPartners";
            this.gvViewPartners.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewPartners.Size = new System.Drawing.Size(926, 438);
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(796, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "К-ть рядків";
            // 
            // lblCountPartners
            // 
            this.lblCountPartners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountPartners.BackColor = System.Drawing.Color.Silver;
            this.lblCountPartners.Location = new System.Drawing.Point(868, 475);
            this.lblCountPartners.Name = "lblCountPartners";
            this.lblCountPartners.Size = new System.Drawing.Size(54, 17);
            this.lblCountPartners.TabIndex = 15;
            this.lblCountPartners.Text = "0";
            this.lblCountPartners.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 469);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(932, 27);
            this.radPanel1.TabIndex = 16;
            // 
            // CommunityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCountPartners);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.btnAddCommunity);
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.gvViewPartners);
            this.Name = "CommunityControl";
            this.Size = new System.Drawing.Size(932, 496);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewPartners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddCommunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadGridView gvViewPartners;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadButton btnAddCommunity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCountPartners;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
