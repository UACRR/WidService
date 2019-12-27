namespace IpsViewComponentLibrary.RightholderControls
{
    partial class RightholdersObjectsRightsControl
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.objectRightForRightholderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlRightholderSelector = new IpsViewComponentLibrary.RightholderControls.RightholderSelectorControl();
            this.bottomPanel = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.navigatorPanel = new IpsViewComponentLibrary.Common.NavigatorPanelControl();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            this.gvRightholdersObjectsRights = new Telerik.WinControls.UI.RadGridView();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.backgroundPanel = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.ctrlRightholderSelectorSecondary = new IpsViewComponentLibrary.RightholderControls.RightholderSelectorControl();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).BeginInit();
            this.gvRightholdersObjectsRights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPanel)).BeginInit();
            this.backgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectRightForRightholderBindingSource
            // 
            this.objectRightForRightholderBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.ObjectRightForRightholder);
            // 
            // ctrlRightholderSelector
            // 
            this.ctrlRightholderSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlRightholderSelector.Location = new System.Drawing.Point(0, 0);
            this.ctrlRightholderSelector.MinimumSize = new System.Drawing.Size(880, 35);
            this.ctrlRightholderSelector.Name = "ctrlRightholderSelector";
            this.ctrlRightholderSelector.Rightholder = null;
            this.ctrlRightholderSelector.RightholderPrimarily = IpsViewComponentLibrary.RightholderControls.RightholderPrimarily.Primary;
            this.ctrlRightholderSelector.Size = new System.Drawing.Size(909, 35);
            this.ctrlRightholderSelector.TabIndex = 0;
            this.ctrlRightholderSelector.RightholderChanged += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelector_RightholderChanged);
            this.ctrlRightholderSelector.ShowAnketaCommandExecuted += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelector_ShowAnketaCommandExecuted);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomPanel.BorderVisible = false;
            this.bottomPanel.Controls.Add(this.navigatorPanel);
            this.bottomPanel.Controls.Add(this.ctrlGridRowCount);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 373);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(909, 34);
            this.bottomPanel.TabIndex = 7;
            // 
            // navigatorPanel
            // 
            this.navigatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.navigatorPanel.CurrentPage = 1;
            this.navigatorPanel.Location = new System.Drawing.Point(395, 3);
            this.navigatorPanel.Name = "navigatorPanel";
            this.navigatorPanel.PageSize = 100;
            this.navigatorPanel.ReadOnlyPageSize = false;
            this.navigatorPanel.Size = new System.Drawing.Size(350, 28);
            this.navigatorPanel.TabIndex = 2;
            this.navigatorPanel.TotalPages = 0;
            this.navigatorPanel.CurrentPageChanged += new System.EventHandler(this.navigatorPanel_CurrentPageChanged);
            this.navigatorPanel.PageSizeChanged += new System.EventHandler(this.navigatorPanel_PageSizeChanged);
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(751, 3);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 0;
            // 
            // gvRightholdersObjectsRights
            // 
            this.gvRightholdersObjectsRights.Controls.Add(this.waitingBar);
            this.gvRightholdersObjectsRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRightholdersObjectsRights.Location = new System.Drawing.Point(0, 70);
            // 
            // 
            // 
            this.gvRightholdersObjectsRights.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersObjectsRights.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = true;
            gridViewCheckBoxColumn1.HeaderText = "";
            gridViewCheckBoxColumn1.MaxWidth = 30;
            gridViewCheckBoxColumn1.MinWidth = 30;
            gridViewCheckBoxColumn1.Name = "IsSelected";
            gridViewCheckBoxColumn1.Width = 30;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "CustId";
            gridViewDecimalColumn1.HeaderText = "CustId";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "CustId";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewDecimalColumn1.Width = 32;
            gridViewTextBoxColumn1.FieldName = "NameClient";
            gridViewTextBoxColumn1.HeaderText = "NameClient";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "NameClient";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 100;
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "ObjId";
            gridViewDecimalColumn2.HeaderText = "Шифр твору";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "ObjId";
            gridViewDecimalColumn2.ReadOnly = true;
            gridViewDecimalColumn2.Width = 63;
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Назва твору";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 130;
            gridViewTextBoxColumn3.FieldName = "Category";
            gridViewTextBoxColumn3.HeaderText = "В/М";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "Category";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 45;
            gridViewTextBoxColumn4.FieldName = "GenreName";
            gridViewTextBoxColumn4.HeaderText = "Жанр";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "GenreName";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 85;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.TimeSpan>);
            gridViewTextBoxColumn5.FieldName = "Duration";
            gridViewTextBoxColumn5.HeaderText = "Час";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Duration";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 63;
            gridViewTextBoxColumn6.FieldName = "RoleName";
            gridViewTextBoxColumn6.HeaderText = "Творчий профіль";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "RoleName";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 83;
            gridViewTextBoxColumn7.FieldName = "SpecName";
            gridViewTextBoxColumn7.HeaderText = "Переклад / обробка / оригінал";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "SpecName";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 77;
            gridViewDecimalColumn3.DataType = typeof(double);
            gridViewDecimalColumn3.FieldName = "RateTotal";
            gridViewDecimalColumn3.FormatString = "{0:N2}";
            gridViewDecimalColumn3.HeaderText = "Спільний % володіння";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "RateTotal";
            gridViewDecimalColumn3.ReadOnly = true;
            gridViewDecimalColumn3.Width = 63;
            gridViewDecimalColumn4.DataType = typeof(System.Nullable<decimal>);
            gridViewDecimalColumn4.FieldName = "RateRh";
            gridViewDecimalColumn4.FormatString = "{0:N2}";
            gridViewDecimalColumn4.HeaderText = "Його % володіння";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "RateRh";
            gridViewDecimalColumn4.ReadOnly = true;
            gridViewDecimalColumn4.Width = 63;
            gridViewTextBoxColumn8.FieldName = "Performer";
            gridViewTextBoxColumn8.HeaderText = "Виконавець";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "Performer";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 89;
            gridViewDecimalColumn5.DataType = typeof(double);
            gridViewDecimalColumn5.FieldName = "Profit";
            gridViewDecimalColumn5.FormatString = "{0:N2}";
            gridViewDecimalColumn5.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "Profit";
            gridViewDecimalColumn5.ReadOnly = true;
            gridViewDecimalColumn5.Width = 98;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Редагувати";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "EditColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 30;
            this.gvRightholdersObjectsRights.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn8,
            gridViewDecimalColumn5,
            gridViewCommandColumn1});
            this.gvRightholdersObjectsRights.MasterTemplate.DataSource = this.objectRightForRightholderBindingSource;
            this.gvRightholdersObjectsRights.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersObjectsRights.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvRightholdersObjectsRights.Name = "gvRightholdersObjectsRights";
            this.gvRightholdersObjectsRights.ShowGroupPanel = false;
            this.gvRightholdersObjectsRights.Size = new System.Drawing.Size(909, 303);
            this.gvRightholdersObjectsRights.TabIndex = 8;
            this.gvRightholdersObjectsRights.ThemeName = "Office2013Light";
            this.gvRightholdersObjectsRights.ValueChanged += new System.EventHandler(this.gvRightholdersObjectsRights_ValueChanged);
            this.gvRightholdersObjectsRights.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersObjectsRights_CellDoubleClick);
            this.gvRightholdersObjectsRights.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersObjectsRights_CellValueChanged);
            this.gvRightholdersObjectsRights.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRightholdersObjectsRights_CommandCellClick);
            this.gvRightholdersObjectsRights.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvRightholdersObjectsRights_ToolTipTextNeeded);
            // 
            // waitingBar
            // 
            this.waitingBar.AssociatedControl = this.backgroundPanel;
            this.waitingBar.Location = new System.Drawing.Point(419, 116);
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
            // backgroundPanel
            // 
            this.backgroundPanel.BorderVisible = false;
            this.backgroundPanel.Controls.Add(this.gvRightholdersObjectsRights);
            this.backgroundPanel.Controls.Add(this.bottomPanel);
            this.backgroundPanel.Controls.Add(this.ctrlRightholderSelectorSecondary);
            this.backgroundPanel.Controls.Add(this.ctrlRightholderSelector);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(909, 407);
            this.backgroundPanel.TabIndex = 10;
            // 
            // ctrlRightholderSelectorSecondary
            // 
            this.ctrlRightholderSelectorSecondary.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlRightholderSelectorSecondary.Location = new System.Drawing.Point(0, 35);
            this.ctrlRightholderSelectorSecondary.MinimumSize = new System.Drawing.Size(880, 35);
            this.ctrlRightholderSelectorSecondary.Name = "ctrlRightholderSelectorSecondary";
            this.ctrlRightholderSelectorSecondary.Rightholder = null;
            this.ctrlRightholderSelectorSecondary.RightholderPrimarily = IpsViewComponentLibrary.RightholderControls.RightholderPrimarily.Secondary;
            this.ctrlRightholderSelectorSecondary.Size = new System.Drawing.Size(909, 35);
            this.ctrlRightholderSelectorSecondary.TabIndex = 9;
            this.ctrlRightholderSelectorSecondary.RightholderChanged += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelectorSecondary_RightholderChanged);
            this.ctrlRightholderSelectorSecondary.ShowAnketaCommandExecuted += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderSelector_ShowAnketaCommandExecuted);
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // RightholdersObjectsRightsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backgroundPanel);
            this.Name = "RightholdersObjectsRightsControl";
            this.Size = new System.Drawing.Size(909, 407);
            ((System.ComponentModel.ISupportInitialize)(this.objectRightForRightholderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersObjectsRights)).EndInit();
            this.gvRightholdersObjectsRights.ResumeLayout(false);
            this.gvRightholdersObjectsRights.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPanel)).EndInit();
            this.backgroundPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private RightholderSelectorControl ctrlRightholderSelector;
        private System.Windows.Forms.BindingSource objectRightForRightholderBindingSource;
        private Common.Editors.IpsPanel bottomPanel;
        private Common.GridRowCountControl ctrlGridRowCount;
        private Telerik.WinControls.UI.RadGridView gvRightholdersObjectsRights;
        private RightholderSelectorControl ctrlRightholderSelectorSecondary;
        private Common.NavigatorPanelControl navigatorPanel;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Common.Editors.IpsPanel backgroundPanel;
    }
}
