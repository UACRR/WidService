namespace IpsViewComponentLibrary.RightholderControls
{
    partial class RightholderListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rightholderMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.tvFilters = new Telerik.WinControls.UI.RadTreeView();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.txtSearchRightholder = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.gvRightholdersList = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRightholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
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
            this.radSplitContainer1.TabIndex = 29;
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
            this.tvFilters.SelectedNodeChanging += new Telerik.WinControls.UI.RadTreeView.RadTreeViewCancelEventHandler(this.tvFilters_SelectedNodeChanging);
            this.tvFilters.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.tvFilters_SelectedNodeChanged);
            this.tvFilters.NodeFormatting += new Telerik.WinControls.UI.TreeNodeFormattingEventHandler(this.tvFilters_NodeFormatting);
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.btnRefresh);
            this.splitPanel2.Controls.Add(this.txtSearchRightholder);
            this.splitPanel2.Controls.Add(this.radLabel1);
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 21);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.ThemeName = "Office2013Light";
            // 
            // txtSearchRightholder
            // 
            this.txtSearchRightholder.Location = new System.Drawing.Point(188, 3);
            this.txtSearchRightholder.Name = "txtSearchRightholder";
            this.txtSearchRightholder.Size = new System.Drawing.Size(464, 21);
            this.txtSearchRightholder.TabIndex = 30;
            this.txtSearchRightholder.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(136, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 19);
            this.radLabel1.TabIndex = 29;
            this.radLabel1.Text = "Пошук";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // gvRightholdersList
            // 
            this.gvRightholdersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightholdersList.EnableCustomFiltering = true;
            this.gvRightholdersList.Location = new System.Drawing.Point(3, 28);
            // 
            // 
            // 
            this.gvRightholdersList.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersList.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "CustId";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "InnerCode";
            gridViewTextBoxColumn2.HeaderText = "Шифр автора / правовласника";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "InnerCode";
            gridViewTextBoxColumn2.Width = 30;
            gridViewTextBoxColumn3.FieldName = "InterCode";
            gridViewTextBoxColumn3.HeaderText = "IPI";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "InterCode";
            gridViewTextBoxColumn3.Width = 30;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.HeaderText = "Правовласник";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Name";
            gridViewTextBoxColumn4.Width = 74;
            gridViewDateTimeColumn1.AllowResize = false;
            gridViewDateTimeColumn1.FieldName = "RegistrDate";
            gridViewDateTimeColumn1.FormatString = "{0:dd/MM/yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Дата народження / реєстрації";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.Name = "RegistrDate";
            gridViewDateTimeColumn1.Width = 92;
            gridViewDecimalColumn1.AllowResize = false;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "CntObj";
            gridViewDecimalColumn1.HeaderText = "К-ть об\'єктів";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "CntObj";
            gridViewDecimalColumn2.AllowResize = false;
            gridViewDecimalColumn2.FieldName = "YearProfit";
            gridViewDecimalColumn2.FormatString = "{0:N2}";
            gridViewDecimalColumn2.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "YearProfit";
            gridViewDecimalColumn2.Width = 94;
            gridViewTextBoxColumn5.FieldName = "Community_Name";
            gridViewTextBoxColumn5.HeaderText = "Cпільнота";
            gridViewTextBoxColumn5.Name = "Community_Name";
            gridViewTextBoxColumn5.Width = 46;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Зм. статус";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "SetStatusColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 80;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Об\'єкти";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "ObjectListColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 80;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.DefaultText = "Редагувати";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Name = "EditColumn";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 80;
            this.gvRightholdersList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3});
            this.gvRightholdersList.MasterTemplate.DataSource = this.rightholderMainViewBindingSource;
            this.gvRightholdersList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRightholdersList.MasterTemplate.EnableFiltering = true;
            this.gvRightholdersList.MasterTemplate.ShowFilteringRow = false;
            this.gvRightholdersList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvRightholdersList.Name = "gvRightholdersList";
            this.gvRightholdersList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvRightholdersList.ReadOnly = true;
            this.gvRightholdersList.ShowGroupPanel = false;
            this.gvRightholdersList.Size = new System.Drawing.Size(649, 369);
            this.gvRightholdersList.TabIndex = 28;
            this.gvRightholdersList.ThemeName = "Office2013Light";
            this.gvRightholdersList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersList_CellDoubleClick);
            this.gvRightholdersList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRightholdersList_CommandCellClick);
            this.gvRightholdersList.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvRightholdersList_ToolTipTextNeeded);
            // 
            // RightholderListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSplitContainer1);
            this.Name = "RightholderListControl";
            this.Size = new System.Drawing.Size(750, 400);
            this.Load += new System.EventHandler(this.RightholderListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            this.splitPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRightholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource rightholderMainViewBindingSource;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadGridView gvRightholdersList;
        private Telerik.WinControls.UI.RadTreeView tvFilters;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadTextBox txtSearchRightholder;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
