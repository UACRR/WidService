namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    partial class SelectClient
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewFreeClientList = new Telerik.WinControls.UI.RadGridView();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewFreeClientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewFreeClientList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewFreeClientList
            // 
            this.gvViewFreeClientList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewFreeClientList.AutoScroll = true;
            this.gvViewFreeClientList.EnableCustomFiltering = true;
            this.gvViewFreeClientList.Location = new System.Drawing.Point(0, 38);
            // 
            // 
            // 
            this.gvViewFreeClientList.MasterTemplate.AllowAddNewRow = false;
            this.gvViewFreeClientList.MasterTemplate.AllowDeleteRow = false;
            this.gvViewFreeClientList.MasterTemplate.AllowDragToGroup = false;
            this.gvViewFreeClientList.MasterTemplate.AllowEditRow = false;
            this.gvViewFreeClientList.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewFreeClientList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "ClCustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ClCustId";
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "Innokpo";
            gridViewTextBoxColumn2.HeaderText = "ОКПО";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 80;
            gridViewTextBoxColumn2.Name = "Innokpo";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 94;
            gridViewTextBoxColumn3.FieldName = "ClientName";
            gridViewTextBoxColumn3.HeaderText = "Назва користувача";
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "ClientName";
            gridViewTextBoxColumn3.Width = 437;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "RegionName";
            gridViewTextBoxColumn4.HeaderText = "Регіон";
            gridViewTextBoxColumn4.MinWidth = 110;
            gridViewTextBoxColumn4.Name = "RegionName";
            gridViewTextBoxColumn4.Width = 110;
            gridViewTextBoxColumn5.FieldName = "AgrCount";
            gridViewTextBoxColumn5.HeaderText = "К-сть договорів";
            gridViewTextBoxColumn5.MaxWidth = 80;
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "AgrCount";
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "Jacity";
            gridViewTextBoxColumn6.HeaderText = "Місто";
            gridViewTextBoxColumn6.MinWidth = 100;
            gridViewTextBoxColumn6.Name = "Jacity";
            gridViewTextBoxColumn6.Width = 103;
            this.gvViewFreeClientList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gvViewFreeClientList.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewFreeClientList.MasterTemplate.EnableFiltering = true;
            this.gvViewFreeClientList.MasterTemplate.EnableGrouping = false;
            this.gvViewFreeClientList.MasterTemplate.ShowFilteringRow = false;
            this.gvViewFreeClientList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewFreeClientList.Name = "gvViewFreeClientList";
            this.gvViewFreeClientList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewFreeClientList.Size = new System.Drawing.Size(846, 414);
            this.gvViewFreeClientList.TabIndex = 36;
            this.gvViewFreeClientList.ThemeName = "Office2013Light";
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(0, 12);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(579, 20);
            this.ctrlSearch.TabIndex = 35;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radPanel1.Location = new System.Drawing.Point(0, 454);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(846, 31);
            this.radPanel1.TabIndex = 37;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(595, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 24);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Обрати";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(722, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // SelectClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(846, 485);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.gvViewFreeClientList);
            this.Controls.Add(this.ctrlSearch);
            this.Name = "SelectClient";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Вибір користувача";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.gvViewFreeClientList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewFreeClientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvViewFreeClientList;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
