namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityAddAuthorForm
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn1 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gvViewAutors = new Telerik.WinControls.UI.RadGridView();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.parentGridPanel = new Telerik.WinControls.UI.RadPanel();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.bsCommunityAuthorsView = new System.Windows.Forms.BindingSource(this.components);
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.ctrlRightLimitation = new IpsViewComponentLibrary.CommunityControls.CommunityRightLimitationControl();
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            this.navigatorPanel = new IpsViewComponentLibrary.Common.NavigatorPanelControl();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).BeginInit();
            this.gvViewAutors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parentGridPanel)).BeginInit();
            this.parentGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunityAuthorsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewAutors
            // 
            this.gvViewAutors.AutoScroll = true;
            this.gvViewAutors.AutoSizeRows = true;
            this.gvViewAutors.Controls.Add(this.waitingBar);
            this.gvViewAutors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvViewAutors.EnableCustomFiltering = true;
            this.gvViewAutors.Location = new System.Drawing.Point(0, 0);
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
            gridViewTextBoxColumn2.DataType = typeof(System.Nullable<int>);
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
            gridViewTextBoxColumn5.Width = 502;
            gridViewTextBoxColumn6.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn6.FieldName = "RegistrDate";
            gridViewTextBoxColumn6.FormatString = "{0:d}";
            gridViewTextBoxColumn6.HeaderText = "Дата народження/ Дата створення";
            gridViewTextBoxColumn6.MaxWidth = 120;
            gridViewTextBoxColumn6.MinWidth = 120;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "RegistrDate";
            gridViewTextBoxColumn6.Width = 120;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewHyperlinkColumn1.DataType = typeof(int);
            gridViewHyperlinkColumn1.FieldName = "CntObj";
            gridViewHyperlinkColumn1.HeaderText = "К-сть об\'єктів";
            gridViewHyperlinkColumn1.MaxWidth = 60;
            gridViewHyperlinkColumn1.MinWidth = 60;
            gridViewHyperlinkColumn1.Name = "CntObj";
            gridViewHyperlinkColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewHyperlinkColumn1.Width = 60;
            gridViewHyperlinkColumn1.WrapText = true;
            gridViewTextBoxColumn7.DataType = typeof(decimal);
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
            this.gvViewAutors.MasterTemplate.DataSource = this.bsCommunityAuthorsView;
            this.gvViewAutors.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableGrouping = false;
            this.gvViewAutors.MasterTemplate.ShowFilteringRow = false;
            this.gvViewAutors.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewAutors.Name = "gvViewAutors";
            this.gvViewAutors.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewAutors.Size = new System.Drawing.Size(983, 213);
            this.gvViewAutors.TabIndex = 14;
            this.gvViewAutors.ThemeName = "Office2013Light";
            this.gvViewAutors.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvViewAutors_CurrentRowChanged);
            // 
            // waitingBar
            // 
            this.waitingBar.AssociatedControl = this.parentGridPanel;
            this.waitingBar.Location = new System.Drawing.Point(456, 71);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 2;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.ThemeName = "Office2013Light";
            this.waitingBar.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.waitingBar.WaitingSpeed = 50;
            this.waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.waitingBar.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.waitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // parentGridPanel
            // 
            this.parentGridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parentGridPanel.Controls.Add(this.gvViewAutors);
            this.parentGridPanel.Location = new System.Drawing.Point(0, 38);
            this.parentGridPanel.Name = "parentGridPanel";
            this.parentGridPanel.Size = new System.Drawing.Size(983, 213);
            this.parentGridPanel.TabIndex = 35;
            this.parentGridPanel.ThemeName = "Office2013Light";
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // bsCommunityAuthorsView
            // 
            this.bsCommunityAuthorsView.DataSource = typeof(ipsFormsDesign.Interfaces.CommunityAuthorsView);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radPanel1.Location = new System.Drawing.Point(0, 536);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(983, 31);
            this.radPanel1.TabIndex = 22;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(859, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // ctrlRightLimitation
            // 
            this.ctrlRightLimitation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRightLimitation.Location = new System.Drawing.Point(0, 291);
            this.ctrlRightLimitation.Name = "ctrlRightLimitation";
            this.ctrlRightLimitation.Size = new System.Drawing.Size(983, 242);
            this.ctrlRightLimitation.TabIndex = 23;
            // 
            // timerSearch
            // 
            this.timerSearch.Interval = 300;
            this.timerSearch.Tick += new System.EventHandler(this.timerSearch_Tick);
            // 
            // navigatorPanel
            // 
            this.navigatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.navigatorPanel.CurrentPage = 1;
            this.navigatorPanel.Location = new System.Drawing.Point(0, 257);
            this.navigatorPanel.Name = "navigatorPanel";
            this.navigatorPanel.PageSize = 200;
            this.navigatorPanel.ReadOnlyPageSize = true;
            this.navigatorPanel.Size = new System.Drawing.Size(350, 28);
            this.navigatorPanel.TabIndex = 24;
            this.navigatorPanel.TotalPages = 0;
            this.navigatorPanel.CurrentPageChanged += new System.EventHandler(this.navigatorPanel_CurrentPageChanged);
            this.navigatorPanel.PageSizeChanged += new System.EventHandler(this.navigatorPanel_PageSizeChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(515, 20);
            this.txtSearch.TabIndex = 34;
            this.txtSearch.ThemeName = "Office2013Light";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).Image = global::IpsViewComponentLibrary.Properties.Resources.search;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            // 
            // CommunityAddAuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(983, 567);
            this.Controls.Add(this.parentGridPanel);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.navigatorPanel);
            this.Controls.Add(this.ctrlRightLimitation);
            this.Controls.Add(this.radPanel1);
            this.Name = "CommunityAddAuthorForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Додати автора";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).EndInit();
            this.gvViewAutors.ResumeLayout(false);
            this.gvViewAutors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parentGridPanel)).EndInit();
            this.parentGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunityAuthorsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadGridView gvViewAutors;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private CommunityRightLimitationControl ctrlRightLimitation;
        private System.Windows.Forms.BindingSource bsCommunityAuthorsView;
        private System.Windows.Forms.Timer timerSearch;
        private Common.NavigatorPanelControl navigatorPanel;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadPanel parentGridPanel;
    }
}
