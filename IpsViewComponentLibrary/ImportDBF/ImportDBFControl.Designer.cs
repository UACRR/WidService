namespace IpsViewComponentLibrary.ImportDBF
{
    partial class ImportDBFControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lblFileName = new Telerik.WinControls.UI.RadLabel();
            this.btnChooseFile = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlGridRowCount = new IpsViewComponentLibrary.Common.GridRowCountControl();
            this.bindingExtrnPay = new System.Windows.Forms.BindingSource(this.components);
            this.ipsPanel1 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.ipsPanel2 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.gvUndistribPays = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingExtrnPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).BeginInit();
            this.ipsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel2)).BeginInit();
            this.ipsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.Controls.Add(this.lblFileName);
            this.radPanel1.Controls.Add(this.btnChooseFile);
            this.radPanel1.Location = new System.Drawing.Point(3, 12);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(976, 52);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = false;
            this.lblFileName.Location = new System.Drawing.Point(136, 18);
            this.lblFileName.MaximumSize = new System.Drawing.Size(160, 19);
            this.lblFileName.MinimumSize = new System.Drawing.Size(160, 19);
            this.lblFileName.Name = "lblFileName";
            // 
            // 
            // 
            this.lblFileName.RootElement.MaxSize = new System.Drawing.Size(160, 19);
            this.lblFileName.RootElement.MinSize = new System.Drawing.Size(160, 19);
            this.lblFileName.Size = new System.Drawing.Size(160, 19);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "Файл не вибраний";
            this.lblFileName.ThemeName = "Office2013Light";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(20, 16);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(110, 24);
            this.btnChooseFile.TabIndex = 0;
            this.btnChooseFile.Text = "Виберіть файл";
            this.btnChooseFile.ThemeName = "Office2013Light";
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(23, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(216, 19);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Завантаження та обробка файлу .dbf";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ctrlGridRowCount
            // 
            this.ctrlGridRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCount.Location = new System.Drawing.Point(818, 413);
            this.ctrlGridRowCount.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCount.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCount.Name = "ctrlGridRowCount";
            this.ctrlGridRowCount.RadGridViewDataSource = null;
            this.ctrlGridRowCount.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCount.TabIndex = 10;
            // 
            // bindingExtrnPay
            // 
            this.bindingExtrnPay.DataSource = typeof(ipsFormsDesign.Model.ExternalPay);
            // 
            // ipsPanel1
            // 
            this.ipsPanel1.BorderVisible = false;
            this.ipsPanel1.Controls.Add(this.radLabel1);
            this.ipsPanel1.Controls.Add(this.radPanel1);
            this.ipsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ipsPanel1.Location = new System.Drawing.Point(0, 0);
            this.ipsPanel1.Name = "ipsPanel1";
            this.ipsPanel1.Size = new System.Drawing.Size(982, 64);
            this.ipsPanel1.TabIndex = 4;
            this.ipsPanel1.ThemeName = "Office2013Light";
            // 
            // ipsPanel2
            // 
            this.ipsPanel2.BorderVisible = false;
            this.ipsPanel2.Controls.Add(this.radLabel3);
            this.ipsPanel2.Controls.Add(this.radPanel3);
            this.ipsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipsPanel2.Location = new System.Drawing.Point(0, 64);
            this.ipsPanel2.Name = "ipsPanel2";
            this.ipsPanel2.Size = new System.Drawing.Size(982, 459);
            this.ipsPanel2.TabIndex = 5;
            this.ipsPanel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(23, 6);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(187, 19);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Розбір не прив\'язаних платежів";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radPanel3
            // 
            this.radPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel3.Controls.Add(this.ctrlGridRowCount);
            this.radPanel3.Controls.Add(this.gvUndistribPays);
            this.radPanel3.Location = new System.Drawing.Point(3, 15);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(976, 441);
            this.radPanel3.TabIndex = 4;
            this.radPanel3.ThemeName = "Office2013Light";
            // 
            // gvUndistribPays
            // 
            this.gvUndistribPays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvUndistribPays.AutoScroll = true;
            this.gvUndistribPays.EnableCustomFiltering = true;
            this.gvUndistribPays.Location = new System.Drawing.Point(3, 16);
            // 
            // 
            // 
            this.gvUndistribPays.MasterTemplate.AllowAddNewRow = false;
            this.gvUndistribPays.MasterTemplate.AllowDeleteRow = false;
            this.gvUndistribPays.MasterTemplate.AllowDragToGroup = false;
            this.gvUndistribPays.MasterTemplate.AllowEditRow = false;
            this.gvUndistribPays.MasterTemplate.AutoGenerateColumns = false;
            this.gvUndistribPays.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn2.FieldName = "AccountCorr";
            gridViewTextBoxColumn2.HeaderText = "Номер рахунку";
            gridViewTextBoxColumn2.MaxWidth = 150;
            gridViewTextBoxColumn2.MinWidth = 110;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "AccountCorr";
            gridViewTextBoxColumn2.Width = 110;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Mfo";
            gridViewTextBoxColumn3.HeaderText = "МФО";
            gridViewTextBoxColumn3.MaxWidth = 100;
            gridViewTextBoxColumn3.MinWidth = 80;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "Mfo";
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(int);
            gridViewTextBoxColumn4.FieldName = "OkpoCorr";
            gridViewTextBoxColumn4.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn4.MaxWidth = 90;
            gridViewTextBoxColumn4.MinWidth = 90;
            gridViewTextBoxColumn4.Name = "OkpoCorr";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 90;
            gridViewTextBoxColumn5.FieldName = "NameCorr";
            gridViewTextBoxColumn5.HeaderText = "Назва користувача";
            gridViewTextBoxColumn5.MinWidth = 110;
            gridViewTextBoxColumn5.Name = "NameCorr";
            gridViewTextBoxColumn5.Width = 132;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "DocNum";
            gridViewTextBoxColumn6.HeaderText = "Номер платежу";
            gridViewTextBoxColumn6.MinWidth = 70;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "DocNum";
            gridViewTextBoxColumn6.Width = 85;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.DataType = typeof(System.Nullable<decimal>);
            gridViewTextBoxColumn7.FieldName = "SCredit";
            gridViewTextBoxColumn7.FormatString = "{0:### ### ##0.00}";
            gridViewTextBoxColumn7.HeaderText = "Сума";
            gridViewTextBoxColumn7.MinWidth = 80;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "SCredit";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 85;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "Nplat";
            gridViewTextBoxColumn8.HeaderText = "Призначення платежу";
            gridViewTextBoxColumn8.MinWidth = 180;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "Nplat";
            gridViewTextBoxColumn8.Width = 260;
            gridViewTextBoxColumn9.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn9.FieldName = "DocDate";
            gridViewTextBoxColumn9.FormatString = "{0:dd.MM.yyyy}";
            gridViewTextBoxColumn9.HeaderText = "Дата платежу";
            gridViewTextBoxColumn9.MaxWidth = 75;
            gridViewTextBoxColumn9.MinWidth = 75;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "DocDate";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 75;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "btnAttach";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.link_solid;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.link_solid;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 35;
            gridViewCommandColumn1.MinWidth = 35;
            gridViewCommandColumn1.Name = "btnAttach";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 35;
            this.gvUndistribPays.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewCommandColumn1});
            this.gvUndistribPays.MasterTemplate.DataSource = this.bindingExtrnPay;
            this.gvUndistribPays.MasterTemplate.EnableCustomFiltering = true;
            this.gvUndistribPays.MasterTemplate.EnableFiltering = true;
            this.gvUndistribPays.MasterTemplate.EnableGrouping = false;
            this.gvUndistribPays.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.gvUndistribPays.MasterTemplate.ShowFilteringRow = false;
            this.gvUndistribPays.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvUndistribPays.Name = "gvUndistribPays";
            this.gvUndistribPays.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvUndistribPays.ReadOnly = true;
            this.gvUndistribPays.Size = new System.Drawing.Size(970, 392);
            this.gvUndistribPays.TabIndex = 8;
            this.gvUndistribPays.ThemeName = "Office2013Light";
            this.gvUndistribPays.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvUndistribPays_CellDoubleClick);
            this.gvUndistribPays.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvUndistribPays_CommandCellClick);
            this.gvUndistribPays.ToolTipTextNeeded += new Telerik.WinControls.ToolTipTextNeededEventHandler(this.gvUndistribPays_ToolTipTextNeeded);
            // 
            // ImportDBFControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ipsPanel2);
            this.Controls.Add(this.ipsPanel1);
            this.Name = "ImportDBFControl";
            this.Size = new System.Drawing.Size(982, 523);
            this.Load += new System.EventHandler(this.ImportDBFControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingExtrnPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).EndInit();
            this.ipsPanel1.ResumeLayout(false);
            this.ipsPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel2)).EndInit();
            this.ipsPanel2.ResumeLayout(false);
            this.ipsPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel lblFileName;
        private Telerik.WinControls.UI.RadButton btnChooseFile;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.BindingSource bindingExtrnPay;
        private Common.GridRowCountControl ctrlGridRowCount;
        private Common.Editors.IpsPanel ipsPanel1;
        private Common.Editors.IpsPanel ipsPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadGridView gvUndistribPays;
    }
}
