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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.fileNameTitle = new Telerik.WinControls.UI.RadLabel();
            this.lblFileName = new Telerik.WinControls.UI.RadLabel();
            this.gvPaysFromFile = new Telerik.WinControls.UI.RadGridView();
            this.bsCheckParamPays = new System.Windows.Forms.BindingSource(this.components);
            this.btnAcceptData = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.footerPanel = new Telerik.WinControls.UI.RadPanel();
            this.headerPanel = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaysFromFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaysFromFile.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheckParamPays)).BeginInit();
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
            gridViewTextBoxColumn1.FieldName = "CheckId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CheckId";
            gridViewTextBoxColumn2.FieldName = "AccountCorr";
            gridViewTextBoxColumn2.HeaderText = "Номер рахунку";
            gridViewTextBoxColumn2.MaxWidth = 120;
            gridViewTextBoxColumn2.MinWidth = 100;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "AccountCorr";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "MfoCorr";
            gridViewTextBoxColumn3.HeaderText = "МФО";
            gridViewTextBoxColumn3.MaxWidth = 70;
            gridViewTextBoxColumn3.MinWidth = 70;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "MfoCorr";
            gridViewTextBoxColumn3.Width = 70;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(int);
            gridViewTextBoxColumn4.FieldName = "OkpoCorr";
            gridViewTextBoxColumn4.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn4.MaxWidth = 85;
            gridViewTextBoxColumn4.MinWidth = 85;
            gridViewTextBoxColumn4.Name = "OkpoCorr";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 85;
            gridViewTextBoxColumn5.FieldName = "DocNum";
            gridViewTextBoxColumn5.HeaderText = "Номер платежу";
            gridViewTextBoxColumn5.MinWidth = 70;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "DocNum";
            gridViewTextBoxColumn5.Width = 92;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.DataType = typeof(decimal);
            gridViewTextBoxColumn6.FieldName = "SCredit";
            gridViewTextBoxColumn6.FormatString = "{0:### ### ### ##0.00}";
            gridViewTextBoxColumn6.HeaderText = "Сума";
            gridViewTextBoxColumn6.MinWidth = 100;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "SCredit";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 100;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "Nplat";
            gridViewTextBoxColumn7.HeaderText = "Призначення платежу";
            gridViewTextBoxColumn7.MinWidth = 180;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "Nplat";
            gridViewTextBoxColumn7.Width = 270;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn8.FieldName = "DocDate";
            gridViewTextBoxColumn8.FormatString = "{0:dd.MM.yyyy}";
            gridViewTextBoxColumn8.HeaderText = "Дата платежу";
            gridViewTextBoxColumn8.MaxWidth = 75;
            gridViewTextBoxColumn8.MinWidth = 75;
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "DocDate";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 75;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.DataType = typeof(int);
            gridViewTextBoxColumn9.FieldName = "InputStatus";
            gridViewTextBoxColumn9.HeaderText = "Статус обробки";
            gridViewTextBoxColumn9.MaxWidth = 120;
            gridViewTextBoxColumn9.MinWidth = 120;
            gridViewTextBoxColumn9.Name = "InputStatus";
            gridViewTextBoxColumn9.Width = 120;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.DataType = typeof(int);
            gridViewTextBoxColumn10.FieldName = "LinkStatus";
            gridViewTextBoxColumn10.HeaderText = "Статус прив\'язки";
            gridViewTextBoxColumn10.MaxWidth = 120;
            gridViewTextBoxColumn10.MinWidth = 120;
            gridViewTextBoxColumn10.Name = "LinkStatus";
            gridViewTextBoxColumn10.Width = 120;
            gridViewTextBoxColumn10.WrapText = true;
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
            gridViewTextBoxColumn10});
            this.gvPaysFromFile.MasterTemplate.DataSource = this.bsCheckParamPays;
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
            // bsCheckParamPays
            // 
            this.bsCheckParamPays.DataSource = typeof(ipsFormsDesign.Model.CheckParamPays);
            // 
            // btnAcceptData
            // 
            this.btnAcceptData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            ((System.ComponentModel.ISupportInitialize)(this.bsCheckParamPays)).EndInit();
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
        private System.Windows.Forms.BindingSource bsCheckParamPays;
    }
}