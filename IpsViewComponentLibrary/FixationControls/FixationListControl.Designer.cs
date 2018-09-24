namespace IpsViewComponentLibrary.FixationControls
{
    partial class FixationListControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rightholderMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.tvFilters = new Telerik.WinControls.UI.RadTreeView();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.gvRightholdersList = new Telerik.WinControls.UI.RadGridView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightholderMainViewBindingSource
            // 
            this.rightholderMainViewBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.RightholderMainView);
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.EnableCollapsing = true;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(750, 400);
            this.radSplitContainer1.SplitterWidth = 10;
            this.radSplitContainer1.TabIndex = 31;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.ThemeName = "Office2013Light";
            this.radSplitContainer1.UseSplitterButtons = true;
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.tvFilters);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(85, 400);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.3851351F, 0F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-240, 0);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            this.splitPanel1.ThemeName = "Office2013Light";
            // 
            // tvFilters
            // 
            this.tvFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFilters.Location = new System.Drawing.Point(0, 0);
            this.tvFilters.Name = "tvFilters";
            this.tvFilters.ShowExpandCollapse = false;
            this.tvFilters.Size = new System.Drawing.Size(85, 400);
            this.tvFilters.TabIndex = 0;
            this.tvFilters.ThemeName = "Office2013Light";
            this.tvFilters.ToggleMode = Telerik.WinControls.UI.ToggleMode.None;
            // 
            // waitingBar
            // 
            this.waitingBar.AssociatedControl = this.splitPanel2;
            this.waitingBar.Location = new System.Drawing.Point(286, 160);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 30;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.ThemeName = "Office2013Light";
            this.waitingBar.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.waitingBar.WaitingSpeed = 50;
            this.waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // gvRightholdersList
            // 
            this.gvRightholdersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightholdersList.BackColor = System.Drawing.SystemColors.Control;
            this.gvRightholdersList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvRightholdersList.EnableCustomFiltering = true;
            this.gvRightholdersList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gvRightholdersList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gvRightholdersList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvRightholdersList.Location = new System.Drawing.Point(3, 28);
            // 
            // 
            // 
            this.gvRightholdersList.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersList.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn6.DataType = typeof(int);
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "CustId";
            gridViewTextBoxColumn6.HeaderText = "CustId";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "CustId";
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "InnerCode";
            gridViewTextBoxColumn7.HeaderText = "Шифр автора / правовласника";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "InnerCode";
            gridViewTextBoxColumn7.Width = 64;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "InterCode";
            gridViewTextBoxColumn8.HeaderText = "IPI";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "InterCode";
            gridViewTextBoxColumn8.Width = 64;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Name";
            gridViewTextBoxColumn9.HeaderText = "Правовласник";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "Name";
            gridViewTextBoxColumn9.Width = 159;
            gridViewDateTimeColumn2.AllowResize = false;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "RegistrDate";
            gridViewDateTimeColumn2.FormatString = "{0:dd/MM/yyyy}";
            gridViewDateTimeColumn2.HeaderText = "Дата народження / реєстрації";
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.Name = "RegistrDate";
            gridViewDateTimeColumn2.Width = 92;
            gridViewDecimalColumn3.AllowResize = false;
            gridViewDecimalColumn3.DataType = typeof(int);
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "CntObj";
            gridViewDecimalColumn3.HeaderText = "К-ть об\'єктів";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "CntObj";
            gridViewDecimalColumn4.AllowResize = false;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "YearProfit";
            gridViewDecimalColumn4.FormatString = "{0:N2}";
            gridViewDecimalColumn4.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "YearProfit";
            gridViewDecimalColumn4.Width = 94;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "Community_Name";
            gridViewTextBoxColumn10.HeaderText = "Cпільнота";
            gridViewTextBoxColumn10.Name = "Community_Name";
            gridViewTextBoxColumn10.Width = 101;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Редагувати";
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "EditColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 30;
            this.gvRightholdersList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewDateTimeColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn10,
            gridViewCommandColumn2});
            this.gvRightholdersList.MasterTemplate.DataSource = this.rightholderMainViewBindingSource;
            this.gvRightholdersList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRightholdersList.MasterTemplate.EnableFiltering = true;
            this.gvRightholdersList.MasterTemplate.ShowFilteringRow = false;
            this.gvRightholdersList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvRightholdersList.Name = "gvRightholdersList";
            this.gvRightholdersList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvRightholdersList.ReadOnly = true;
            this.gvRightholdersList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvRightholdersList.ShowGroupPanel = false;
            this.gvRightholdersList.Size = new System.Drawing.Size(649, 369);
            this.gvRightholdersList.TabIndex = 28;
            this.gvRightholdersList.ThemeName = "Office2013Light";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 21);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.ThemeName = "Office2013Light";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(130, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Пошук";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 32;
            this.txtSearch.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).Image = global::IpsViewComponentLibrary.Properties.Resources.search;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.None;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.TextBoxViewElement)(this.txtSearch.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txtSearch.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.waitingBar);
            this.splitPanel2.Controls.Add(this.txtSearch);
            this.splitPanel2.Controls.Add(this.btnRefresh);
            this.splitPanel2.Controls.Add(this.gvRightholdersList);
            this.splitPanel2.Location = new System.Drawing.Point(95, 0);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(655, 400);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.3851351F, 0F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(240, 0);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.ThemeName = "Office2013Light";
            // 
            // FixationListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSplitContainer1);
            this.Name = "FixationListControl";
            this.Size = new System.Drawing.Size(750, 400);
            this.Load += new System.EventHandler(this.FixationListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource rightholderMainViewBindingSource;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.RadTreeView tvFilters;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadTextBoxControl txtSearch;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadGridView gvRightholdersList;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
