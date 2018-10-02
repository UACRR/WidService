namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityAddAutorForm
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

        #region Windows Form Designer generated code

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
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn2 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gvViewAutors = new Telerik.WinControls.UI.RadGridView();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.gvRightLimitations = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightLimitations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightLimitations.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewAutors
            // 
            this.gvViewAutors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewAutors.AutoScroll = true;
            this.gvViewAutors.AutoSizeRows = true;
            this.gvViewAutors.EnableCustomFiltering = true;
            this.gvViewAutors.Location = new System.Drawing.Point(0, 38);
            // 
            // 
            // 
            this.gvViewAutors.MasterTemplate.AllowAddNewRow = false;
            this.gvViewAutors.MasterTemplate.AllowDeleteRow = false;
            this.gvViewAutors.MasterTemplate.AllowDragToGroup = false;
            this.gvViewAutors.MasterTemplate.AllowEditRow = false;
            this.gvViewAutors.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewAutors.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn10.DataType = typeof(int);
            gridViewTextBoxColumn10.FieldName = "CustId";
            gridViewTextBoxColumn10.HeaderText = "ID";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "CustId";
            gridViewTextBoxColumn11.FieldName = "CmCustId";
            gridViewTextBoxColumn11.HeaderText = "cmID";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "CmCustId";
            gridViewTextBoxColumn11.Width = 25;
            gridViewTextBoxColumn12.FieldName = "InnerCode";
            gridViewTextBoxColumn12.HeaderText = "Шифр";
            gridViewTextBoxColumn12.MaxWidth = 95;
            gridViewTextBoxColumn12.MinWidth = 95;
            gridViewTextBoxColumn12.Multiline = true;
            gridViewTextBoxColumn12.Name = "InnerCode";
            gridViewTextBoxColumn12.Width = 95;
            gridViewTextBoxColumn12.WrapText = true;
            gridViewTextBoxColumn13.DataType = typeof(int);
            gridViewTextBoxColumn13.FieldName = "InterCode";
            gridViewTextBoxColumn13.HeaderText = "IPI";
            gridViewTextBoxColumn13.MaxWidth = 95;
            gridViewTextBoxColumn13.MinWidth = 95;
            gridViewTextBoxColumn13.Name = "InterCode";
            gridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn13.Width = 95;
            gridViewTextBoxColumn14.FieldName = "Name";
            gridViewTextBoxColumn14.HeaderText = "Правовласник";
            gridViewTextBoxColumn14.MinWidth = 80;
            gridViewTextBoxColumn14.Name = "Name";
            gridViewTextBoxColumn14.Width = 425;
            gridViewTextBoxColumn15.FieldName = "RegistrDate";
            gridViewTextBoxColumn15.FormatString = "{0:d}";
            gridViewTextBoxColumn15.HeaderText = "Дата народження/ Дата створення";
            gridViewTextBoxColumn15.MaxWidth = 120;
            gridViewTextBoxColumn15.MinWidth = 120;
            gridViewTextBoxColumn15.Multiline = true;
            gridViewTextBoxColumn15.Name = "RegistrDate";
            gridViewTextBoxColumn15.Width = 120;
            gridViewTextBoxColumn15.WrapText = true;
            gridViewHyperlinkColumn2.FieldName = "CntObj";
            gridViewHyperlinkColumn2.HeaderText = "К-сть об\'єктів";
            gridViewHyperlinkColumn2.MaxWidth = 60;
            gridViewHyperlinkColumn2.MinWidth = 60;
            gridViewHyperlinkColumn2.Name = "CntObj";
            gridViewHyperlinkColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewHyperlinkColumn2.Width = 60;
            gridViewHyperlinkColumn2.WrapText = true;
            gridViewTextBoxColumn16.FieldName = "YearProfit";
            gridViewTextBoxColumn16.HeaderText = "Дохід з початку року";
            gridViewTextBoxColumn16.MaxWidth = 90;
            gridViewTextBoxColumn16.MinWidth = 90;
            gridViewTextBoxColumn16.Name = "YearProfit";
            gridViewTextBoxColumn16.Width = 90;
            gridViewTextBoxColumn16.WrapText = true;
            this.gvViewAutors.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewHyperlinkColumn2,
            gridViewTextBoxColumn16});
            this.gvViewAutors.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableGrouping = false;
            this.gvViewAutors.MasterTemplate.ShowFilteringRow = false;
            this.gvViewAutors.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gvViewAutors.Name = "gvViewAutors";
            this.gvViewAutors.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewAutors.Size = new System.Drawing.Size(906, 235);
            this.gvViewAutors.TabIndex = 14;
            this.gvViewAutors.ThemeName = "Office2013Light";
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(0, 12);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 13;
            // 
            // gvRightLimitations
            // 
            this.gvRightLimitations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightLimitations.Location = new System.Drawing.Point(0, 279);
            // 
            // 
            // 
            this.gvRightLimitations.MasterTemplate.AllowAddNewRow = false;
            this.gvRightLimitations.MasterTemplate.AllowColumnReorder = false;
            this.gvRightLimitations.MasterTemplate.AutoExpandGroups = true;
            this.gvRightLimitations.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightLimitations.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "GroupCode";
            gridViewDecimalColumn2.HeaderText = "GroupCode";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Name = "GroupCode";
            gridViewDecimalColumn2.ReadOnly = true;
            gridViewDecimalColumn2.Width = 62;
            gridViewTextBoxColumn17.FieldName = "Name";
            gridViewTextBoxColumn17.HeaderText = "Вид права";
            gridViewTextBoxColumn17.IsAutoGenerated = true;
            gridViewTextBoxColumn17.Name = "Name";
            gridViewTextBoxColumn17.ReadOnly = true;
            gridViewTextBoxColumn17.Width = 500;
            gridViewTextBoxColumn18.FieldName = "GroupName";
            gridViewTextBoxColumn18.HeaderText = "GroupName";
            gridViewTextBoxColumn18.IsAutoGenerated = true;
            gridViewTextBoxColumn18.IsVisible = false;
            gridViewTextBoxColumn18.Name = "GroupName";
            gridViewTextBoxColumn18.ReadOnly = true;
            gridViewTextBoxColumn18.Width = 62;
            gridViewComboBoxColumn2.DataType = typeof(int);
            gridViewComboBoxColumn2.DisplayMember = "Name";
            gridViewComboBoxColumn2.FieldName = "CommunityCustId";
            gridViewComboBoxColumn2.HeaderText = "Спільнота";
            gridViewComboBoxColumn2.Name = "CommunityCustId";
            gridViewComboBoxColumn2.ValueMember = "CustId";
            gridViewComboBoxColumn2.Width = 300;
            gridViewCheckBoxColumn2.FieldName = "OurService";
            gridViewCheckBoxColumn2.HeaderText = "Відмітити";
            gridViewCheckBoxColumn2.IsAutoGenerated = true;
            gridViewCheckBoxColumn2.Name = "OurService";
            gridViewCheckBoxColumn2.Width = 107;
            this.gvRightLimitations.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn2,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewComboBoxColumn2,
            gridViewCheckBoxColumn2});
            this.gvRightLimitations.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightLimitations.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.gvRightLimitations.Name = "gvRightLimitations";
            this.gvRightLimitations.ShowGroupPanel = false;
            this.gvRightLimitations.Size = new System.Drawing.Size(906, 239);
            this.gvRightLimitations.TabIndex = 15;
            this.gvRightLimitations.ThemeName = "Office2013Light";
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radPanel1.Location = new System.Drawing.Point(0, 524);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(906, 31);
            this.radPanel1.TabIndex = 22;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 24);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(782, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // CommunityAddAutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 555);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.gvRightLimitations);
            this.Controls.Add(this.gvViewAutors);
            this.Controls.Add(this.ctrlSearch);
            this.Name = "CommunityAddAutorForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Додати автора";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightLimitations.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightLimitations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadGridView gvViewAutors;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadGridView gvRightLimitations;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
