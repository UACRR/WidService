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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn1 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
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
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "CmCustId";
            gridViewTextBoxColumn2.HeaderText = "cmID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "CmCustId";
            gridViewTextBoxColumn2.Width = 25;
            gridViewTextBoxColumn3.FieldName = "InnerCode";
            gridViewTextBoxColumn3.HeaderText = "Шифр";
            gridViewTextBoxColumn3.MaxWidth = 95;
            gridViewTextBoxColumn3.MinWidth = 95;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "InnerCode";
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(int);
            gridViewTextBoxColumn4.FieldName = "InterCode";
            gridViewTextBoxColumn4.HeaderText = "IPI";
            gridViewTextBoxColumn4.MaxWidth = 95;
            gridViewTextBoxColumn4.MinWidth = 95;
            gridViewTextBoxColumn4.Name = "InterCode";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 95;
            gridViewTextBoxColumn5.FieldName = "Name";
            gridViewTextBoxColumn5.HeaderText = "Правовласник";
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "Name";
            gridViewTextBoxColumn5.Width = 425;
            gridViewTextBoxColumn6.FieldName = "RegistrDate";
            gridViewTextBoxColumn6.FormatString = "{0:d}";
            gridViewTextBoxColumn6.HeaderText = "Дата народження/ Дата створення";
            gridViewTextBoxColumn6.MaxWidth = 120;
            gridViewTextBoxColumn6.MinWidth = 120;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "RegistrDate";
            gridViewTextBoxColumn6.Width = 120;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewHyperlinkColumn1.FieldName = "CntObj";
            gridViewHyperlinkColumn1.HeaderText = "К-сть об\'єктів";
            gridViewHyperlinkColumn1.MaxWidth = 60;
            gridViewHyperlinkColumn1.MinWidth = 60;
            gridViewHyperlinkColumn1.Name = "CntObj";
            gridViewHyperlinkColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewHyperlinkColumn1.Width = 60;
            gridViewHyperlinkColumn1.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "YearProfit";
            gridViewTextBoxColumn7.HeaderText = "Дохід з початку року";
            gridViewTextBoxColumn7.MaxWidth = 90;
            gridViewTextBoxColumn7.MinWidth = 90;
            gridViewTextBoxColumn7.Name = "YearProfit";
            gridViewTextBoxColumn7.Width = 90;
            gridViewTextBoxColumn7.WrapText = true;
            this.gvViewAutors.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewHyperlinkColumn1,
            gridViewTextBoxColumn7});
            this.gvViewAutors.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableGrouping = false;
            this.gvViewAutors.MasterTemplate.ShowFilteringRow = false;
            this.gvViewAutors.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewAutors.Name = "gvViewAutors";
            this.gvViewAutors.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewAutors.Size = new System.Drawing.Size(906, 235);
            this.gvViewAutors.TabIndex = 14;
            this.gvViewAutors.ThemeName = "Office2013Light";
            this.gvViewAutors.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvViewAutors_CurrentRowChanged);
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
            gridViewTextBoxColumn8.FieldName = "CustId";
            gridViewTextBoxColumn8.HeaderText = "CustId";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "CustId";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 47;
            gridViewTextBoxColumn9.FieldName = "CmCustId";
            gridViewTextBoxColumn9.HeaderText = "CmCustId";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "CmCustId";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 48;
            gridViewTextBoxColumn10.FieldName = "KindCode";
            gridViewTextBoxColumn10.HeaderText = "KindCode";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "KindCode";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 47;
            gridViewTextBoxColumn11.FieldName = "KindName";
            gridViewTextBoxColumn11.HeaderText = "Вид права";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "KindName";
            gridViewTextBoxColumn11.ReadOnly = true;
            gridViewTextBoxColumn11.Width = 449;
            gridViewComboBoxColumn1.DataType = typeof(int);
            gridViewComboBoxColumn1.DisplayMember = "Name";
            gridViewComboBoxColumn1.FieldName = "CommunityName";
            gridViewComboBoxColumn1.HeaderText = "Спільнота";
            gridViewComboBoxColumn1.Name = "CommunityName";
            gridViewComboBoxColumn1.ReadOnly = true;
            gridViewComboBoxColumn1.ValueMember = "CustId";
            gridViewComboBoxColumn1.Width = 163;
            gridViewCheckBoxColumn1.FieldName = "Check";
            gridViewCheckBoxColumn1.HeaderText = "Відмітити";
            gridViewCheckBoxColumn1.IsAutoGenerated = true;
            gridViewCheckBoxColumn1.Name = "Check";
            gridViewCheckBoxColumn1.Width = 97;
            gridViewDateTimeColumn1.CustomFormat = "dd/MM/yyyy";
            gridViewDateTimeColumn1.FieldName = "DateBegin";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatString = "{0:dd/MM/yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Дата початку";
            gridViewDateTimeColumn1.MinWidth = 100;
            gridViewDateTimeColumn1.Name = "DateBegin";
            gridViewDateTimeColumn1.Width = 100;
            gridViewDateTimeColumn1.WrapText = true;
            gridViewDateTimeColumn2.CustomFormat = "dd/MM/yyyy";
            gridViewDateTimeColumn2.FieldName = "DateEnd";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn2.FormatString = "{0:dd/MM/yyyy}";
            gridViewDateTimeColumn2.HeaderText = "Дата завершення";
            gridViewDateTimeColumn2.MinWidth = 100;
            gridViewDateTimeColumn2.Name = "DateEnd";
            gridViewDateTimeColumn2.Width = 100;
            gridViewDateTimeColumn2.WrapText = true;
            this.gvRightLimitations.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewComboBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2});
            this.gvRightLimitations.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightLimitations.MasterTemplate.ViewDefinition = tableViewDefinition2;
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
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
