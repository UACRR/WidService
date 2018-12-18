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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnChooseFile = new Telerik.WinControls.UI.RadButton();
            this.lblFileName = new Telerik.WinControls.UI.RadLabel();
            this.btnLoadFile = new Telerik.WinControls.UI.RadButton();
            this.gvUndistribPays = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel1.Controls.Add(this.btnLoadFile);
            this.radPanel1.Controls.Add(this.lblFileName);
            this.radPanel1.Controls.Add(this.btnChooseFile);
            this.radPanel1.Location = new System.Drawing.Point(3, 12);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(894, 50);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.ThemeName = "Office2013Light";
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
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(23, 68);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(187, 19);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Розбір не прив\'язаних платежів";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radPanel2
            // 
            this.radPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPanel2.Controls.Add(this.gvUndistribPays);
            this.radPanel2.Location = new System.Drawing.Point(3, 77);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(894, 396);
            this.radPanel2.TabIndex = 2;
            this.radPanel2.ThemeName = "Office2013Light";
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
            // btnLoadFile
            // 
            this.btnLoadFile.Enabled = false;
            this.btnLoadFile.Location = new System.Drawing.Point(302, 16);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(168, 24);
            this.btnLoadFile.TabIndex = 3;
            this.btnLoadFile.Text = "Завантажити та обробити";
            this.btnLoadFile.ThemeName = "Office2013Light";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // gvUndistribPays
            // 
            this.gvUndistribPays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvUndistribPays.AutoScroll = true;
            this.gvUndistribPays.AutoSizeRows = true;
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
            gridViewTextBoxColumn2.FieldName = "AgrNumber";
            gridViewTextBoxColumn2.HeaderText = "Номер рахунку";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 80;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "AgrNumber";
            gridViewTextBoxColumn2.Width = 95;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Name";
            gridViewTextBoxColumn3.HeaderText = "МФО";
            gridViewTextBoxColumn3.MaxWidth = 70;
            gridViewTextBoxColumn3.MinWidth = 70;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "Name";
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
            gridViewTextBoxColumn5.Width = 110;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "StatusName";
            gridViewTextBoxColumn6.HeaderText = "Банк";
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "StatusName";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "CountLic1Active";
            gridViewTextBoxColumn7.HeaderText = "Номер платежу";
            gridViewTextBoxColumn7.MinWidth = 70;
            gridViewTextBoxColumn7.Multiline = true;
            gridViewTextBoxColumn7.Name = "CountLic1Active";
            gridViewTextBoxColumn7.Width = 70;
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
            gridViewTextBoxColumn9.Width = 181;
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
            gridViewTextBoxColumn10,
            gridViewCommandColumn1});
            this.gvUndistribPays.MasterTemplate.EnableCustomFiltering = true;
            this.gvUndistribPays.MasterTemplate.EnableFiltering = true;
            this.gvUndistribPays.MasterTemplate.EnableGrouping = false;
            this.gvUndistribPays.MasterTemplate.ShowFilteringRow = false;
            this.gvUndistribPays.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvUndistribPays.Name = "gvUndistribPays";
            this.gvUndistribPays.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvUndistribPays.Size = new System.Drawing.Size(888, 377);
            this.gvUndistribPays.TabIndex = 7;
            this.gvUndistribPays.ThemeName = "Office2013Light";
            this.gvUndistribPays.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvUndistribPays_CommandCellClick);
            // 
            // ImportDBFControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanel1);
            this.Name = "ImportDBFControl";
            this.Size = new System.Drawing.Size(900, 476);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUndistribPays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnLoadFile;
        private Telerik.WinControls.UI.RadLabel lblFileName;
        private Telerik.WinControls.UI.RadButton btnChooseFile;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView gvUndistribPays;
    }
}
