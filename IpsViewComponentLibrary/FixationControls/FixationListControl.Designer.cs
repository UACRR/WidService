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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rightholderMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.tvFilters = new Telerik.WinControls.UI.RadTreeView();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.gvRightholdersList = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).BeginInit();
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
            this.tvFilters.NodeFormatting += new Telerik.WinControls.UI.TreeNodeFormattingEventHandler(this.tvFilters_NodeFormatting);
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 21);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.ThemeName = "Office2013Light";
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
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "CustId";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "InnerCode";
            gridViewTextBoxColumn2.HeaderText = "Шифр автора / правовласника";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "InnerCode";
            gridViewTextBoxColumn2.Width = 64;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "InterCode";
            gridViewTextBoxColumn3.HeaderText = "IPI";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "InterCode";
            gridViewTextBoxColumn3.Width = 64;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.HeaderText = "Правовласник";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Name";
            gridViewTextBoxColumn4.Width = 159;
            gridViewDateTimeColumn1.AllowResize = false;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "RegistrDate";
            gridViewDateTimeColumn1.FormatString = "{0:dd/MM/yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Дата народження / реєстрації";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.Name = "RegistrDate";
            gridViewDateTimeColumn1.Width = 92;
            gridViewDecimalColumn1.AllowResize = false;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "CntObj";
            gridViewDecimalColumn1.HeaderText = "К-ть об\'єктів";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "CntObj";
            gridViewDecimalColumn2.AllowResize = false;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "YearProfit";
            gridViewDecimalColumn2.FormatString = "{0:N2}";
            gridViewDecimalColumn2.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "YearProfit";
            gridViewDecimalColumn2.Width = 94;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Community_Name";
            gridViewTextBoxColumn5.HeaderText = "Cпільнота";
            gridViewTextBoxColumn5.Name = "Community_Name";
            gridViewTextBoxColumn5.Width = 101;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Редагувати";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "EditColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            this.gvRightholdersList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1});
            this.gvRightholdersList.MasterTemplate.DataSource = this.rightholderMainViewBindingSource;
            this.gvRightholdersList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRightholdersList.MasterTemplate.EnableFiltering = true;
            this.gvRightholdersList.MasterTemplate.ShowFilteringRow = false;
            this.gvRightholdersList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvRightholdersList.Name = "gvRightholdersList";
            this.gvRightholdersList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvRightholdersList.ReadOnly = true;
            this.gvRightholdersList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvRightholdersList.ShowGroupPanel = false;
            this.gvRightholdersList.Size = new System.Drawing.Size(649, 369);
            this.gvRightholdersList.TabIndex = 28;
            this.gvRightholdersList.ThemeName = "Office2013Light";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).EndInit();
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
