namespace IpsViewComponentLibrary.ImportDBF
{
    partial class ImportParseResultForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.fileNameTitle = new Telerik.WinControls.UI.RadLabel();
            this.lblFileName = new Telerik.WinControls.UI.RadLabel();
            this.gvPaysFromFile = new Telerik.WinControls.UI.RadGridView();
            this.btnAcceptData = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.footerPanel = new Telerik.WinControls.UI.RadPanel();
            this.headerPanel = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaysFromFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaysFromFile.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAcceptData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // fileNameTitle
            // 
            this.fileNameTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameTitle.Location = new System.Drawing.Point(3, 3);
            this.fileNameTitle.Name = "fileNameTitle";
            this.fileNameTitle.Size = new System.Drawing.Size(91, 21);
            this.fileNameTitle.TabIndex = 1;
            this.fileNameTitle.Text = "Назва файлу: ";
            this.fileNameTitle.ThemeName = "Office2013Light";
            // 
            // lblFileName
            // 
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileName.Location = new System.Drawing.Point(100, 3);
            this.lblFileName.Name = "lblFileName";
            // 
            // 
            // 
            this.lblFileName.RootElement.MaxSize = new System.Drawing.Size(0, 0);
            this.lblFileName.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.lblFileName.Size = new System.Drawing.Size(63, 21);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "file_name";
            this.lblFileName.ThemeName = "Office2013Light";
            // 
            // gvPaysFromFile
            // 
            this.gvPaysFromFile.AutoScroll = true;
            this.gvPaysFromFile.AutoSizeRows = true;
            this.gvPaysFromFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPaysFromFile.EnableCustomFiltering = true;
            this.gvPaysFromFile.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gvPaysFromFile.MasterTemplate.AllowAddNewRow = false;
            this.gvPaysFromFile.MasterTemplate.AllowCellContextMenu = false;
            this.gvPaysFromFile.MasterTemplate.AllowColumnChooser = false;
            this.gvPaysFromFile.MasterTemplate.AllowDeleteRow = false;
            this.gvPaysFromFile.MasterTemplate.AllowDragToGroup = false;
            this.gvPaysFromFile.MasterTemplate.AllowEditRow = false;
            this.gvPaysFromFile.MasterTemplate.AutoGenerateColumns = false;
            this.gvPaysFromFile.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "AgrNumber";
            gridViewTextBoxColumn2.HeaderText = "Номер рахунку";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 80;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "AgrNumber";
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "mfo";
            gridViewTextBoxColumn3.HeaderText = "МФО";
            gridViewTextBoxColumn3.MaxWidth = 70;
            gridViewTextBoxColumn3.MinWidth = 70;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "mfo";
            gridViewTextBoxColumn3.Width = 70;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(int);
            gridViewTextBoxColumn4.FieldName = "Innokpo";
            gridViewTextBoxColumn4.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn4.MaxWidth = 85;
            gridViewTextBoxColumn4.MinWidth = 85;
            gridViewTextBoxColumn4.Name = "Innokpo";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 85;
            gridViewTextBoxColumn5.FieldName = "JaCity";
            gridViewTextBoxColumn5.HeaderText = "Назва Споживача";
            gridViewTextBoxColumn5.MinWidth = 110;
            gridViewTextBoxColumn5.Name = "JaCity";
            gridViewTextBoxColumn5.Width = 115;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "StatusName";
            gridViewTextBoxColumn6.HeaderText = "Банк";
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "StatusName";
            gridViewTextBoxColumn6.Width = 85;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "CountLic1Active";
            gridViewTextBoxColumn7.HeaderText = "Номер платежу";
            gridViewTextBoxColumn7.MinWidth = 70;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "CountLic1Active";
            gridViewTextBoxColumn7.Width = 74;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "CountLic2Active";
            gridViewTextBoxColumn8.HeaderText = "Сума";
            gridViewTextBoxColumn8.MinWidth = 70;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "CountLic2Active";
            gridViewTextBoxColumn8.Width = 70;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "CountLic3Active";
            gridViewTextBoxColumn9.HeaderText = "Призначення платежу";
            gridViewTextBoxColumn9.MinWidth = 180;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "CountLic3Active";
            gridViewTextBoxColumn9.Width = 180;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.DataType = typeof(double);
            gridViewTextBoxColumn10.FieldName = "UndistribAmount";
            gridViewTextBoxColumn10.HeaderText = "Дата платежу";
            gridViewTextBoxColumn10.MaxWidth = 75;
            gridViewTextBoxColumn10.MinWidth = 75;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "UndistribAmount";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn10.Width = 75;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewTextBoxColumn11.HeaderText = "Статус обробки";
            gridViewTextBoxColumn11.MinWidth = 80;
            gridViewTextBoxColumn11.Name = "column1";
            gridViewTextBoxColumn11.Width = 80;
            gridViewTextBoxColumn11.WrapText = true;
            gridViewTextBoxColumn12.HeaderText = "Статус прив\'язки";
            gridViewTextBoxColumn12.MinWidth = 120;
            gridViewTextBoxColumn12.Name = "column2";
            gridViewTextBoxColumn12.Width = 120;
            gridViewTextBoxColumn12.WrapText = true;
            this.gvPaysFromFile.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.gvPaysFromFile.MasterTemplate.EnableCustomFiltering = true;
            this.gvPaysFromFile.MasterTemplate.EnableFiltering = true;
            this.gvPaysFromFile.MasterTemplate.EnableGrouping = false;
            this.gvPaysFromFile.MasterTemplate.ShowFilteringRow = false;
            this.gvPaysFromFile.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPaysFromFile.Name = "gvPaysFromFile";
            this.gvPaysFromFile.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPaysFromFile.Size = new System.Drawing.Size(1050, 403);
            this.gvPaysFromFile.TabIndex = 2;
            this.gvPaysFromFile.ThemeName = "Office2013Light";
            // 
            // btnAcceptData
            // 
            this.btnAcceptData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptData.Enabled = false;
            this.btnAcceptData.Location = new System.Drawing.Point(789, 3);
            this.btnAcceptData.Name = "btnAcceptData";
            this.btnAcceptData.Size = new System.Drawing.Size(120, 24);
            this.btnAcceptData.TabIndex = 3;
            this.btnAcceptData.Text = "Прийняти дані";
            this.btnAcceptData.ThemeName = "Office2013Light";
            this.btnAcceptData.Click += new System.EventHandler(this.btnAcceptData_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(927, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Silver;
            this.footerPanel.Controls.Add(this.btnCancel);
            this.footerPanel.Controls.Add(this.btnAcceptData);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 436);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1050, 30);
            this.footerPanel.TabIndex = 1;
            this.footerPanel.ThemeName = "Office2013Light";
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.fileNameTitle);
            this.headerPanel.Controls.Add(this.lblFileName);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1050, 33);
            this.headerPanel.TabIndex = 1;
            this.headerPanel.ThemeName = "Office2013Light";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.headerPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // ImportParseResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1050, 466);
            this.Controls.Add(this.gvPaysFromFile);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.footerPanel);
            this.Name = "ImportParseResultForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Результат обробки файлу";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.fileNameTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaysFromFile.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaysFromFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAcceptData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadLabel fileNameTitle;
        private Telerik.WinControls.UI.RadLabel lblFileName;
        private Telerik.WinControls.UI.RadGridView gvPaysFromFile;
        private Telerik.WinControls.UI.RadButton btnAcceptData;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadPanel footerPanel;
        private Telerik.WinControls.UI.RadPanel headerPanel;
    }
}