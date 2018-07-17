namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetFiles
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ctrlHeaderInfo = new IpsViewComponentLibrary.InformationOfUserControl();
            this.agentEmail = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agentPhone = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agentPib = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.gvListFiles = new Telerik.WinControls.UI.RadGridView();
            this.btnAddFile = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFile)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlHeaderInfo
            // 
            this.ctrlHeaderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlHeaderInfo.Edrpou = "46546545";
            this.ctrlHeaderInfo.EmailContactPerson = "qwerty@qwer.ty";
            this.ctrlHeaderInfo.EmailManager = "qwerty@qwer.ty";
            this.ctrlHeaderInfo.GroupOrHolding = "Копірайт";
            this.ctrlHeaderInfo.HoldingVisible = false;
            this.ctrlHeaderInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeaderInfo.MaximumSize = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.MinimumSize = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.Name = "ctrlHeaderInfo";
            this.ctrlHeaderInfo.NameInfo = "ррррр";
            this.ctrlHeaderInfo.OrganisationForm = "ТОВ";
            this.ctrlHeaderInfo.OrganisationFormVisible = false;
            this.ctrlHeaderInfo.PhoneContactPerson = "+380999999999";
            this.ctrlHeaderInfo.PhoneManager = "+380999999999";
            this.ctrlHeaderInfo.PibContactPerson = "Прізвище Ім\'я Побатькові";
            this.ctrlHeaderInfo.PibManager = "Прізвище КапецьякевеличезнеІм\'я Побатькові";
            this.ctrlHeaderInfo.Size = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.TabIndex = 0;
            // 
            // agentEmail
            // 
            this.agentEmail.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentEmail.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentEmail.Location = new System.Drawing.Point(161, 39);
            this.agentEmail.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agentEmail.MinimumSize = new System.Drawing.Size(150, 25);
            this.agentEmail.Name = "agentEmail";
            this.agentEmail.Size = new System.Drawing.Size(264, 28);
            this.agentEmail.SplitterRatio = 41;
            this.agentEmail.StringFormat = "";
            this.agentEmail.TabIndex = 3;
            this.agentEmail.TextTitle = "Email";
            this.agentEmail.TextValue = "";
            this.agentEmail.ValueDataMemger = "";
            this.agentEmail.ValueDataSource = null;
            // 
            // agentPhone
            // 
            this.agentPhone.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPhone.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPhone.Location = new System.Drawing.Point(3, 39);
            this.agentPhone.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agentPhone.MinimumSize = new System.Drawing.Size(150, 25);
            this.agentPhone.Name = "agentPhone";
            this.agentPhone.Size = new System.Drawing.Size(152, 28);
            this.agentPhone.SplitterRatio = 35;
            this.agentPhone.StringFormat = "";
            this.agentPhone.TabIndex = 2;
            this.agentPhone.TextTitle = "Тел.";
            this.agentPhone.TextValue = "";
            this.agentPhone.ValueDataMemger = "";
            this.agentPhone.ValueDataSource = null;
            // 
            // agentPib
            // 
            this.agentPib.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPib.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPib.Location = new System.Drawing.Point(3, 10);
            this.agentPib.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agentPib.MinimumSize = new System.Drawing.Size(150, 25);
            this.agentPib.Name = "agentPib";
            this.agentPib.Size = new System.Drawing.Size(422, 28);
            this.agentPib.SplitterRatio = 35;
            this.agentPib.StringFormat = "";
            this.agentPib.TabIndex = 1;
            this.agentPib.TextTitle = "ПІБ";
            this.agentPib.TextValue = "";
            this.agentPib.ValueDataMemger = "";
            this.agentPib.ValueDataSource = null;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(16, 215);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(73, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Представник";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.agentEmail);
            this.radPanel1.Controls.Add(this.agentPhone);
            this.radPanel1.Controls.Add(this.agentPib);
            this.radPanel1.Location = new System.Drawing.Point(3, 224);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(428, 74);
            this.radPanel1.TabIndex = 3;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // gvListFiles
            // 
            this.gvListFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvListFiles.AutoScroll = true;
            this.gvListFiles.AutoSizeRows = true;
            this.gvListFiles.EnableCustomFiltering = true;
            this.gvListFiles.Location = new System.Drawing.Point(3, 304);
            // 
            // 
            // 
            this.gvListFiles.MasterTemplate.AllowAddNewRow = false;
            this.gvListFiles.MasterTemplate.AllowDeleteRow = false;
            this.gvListFiles.MasterTemplate.AllowDragToGroup = false;
            this.gvListFiles.MasterTemplate.AllowEditRow = false;
            this.gvListFiles.MasterTemplate.AutoGenerateColumns = false;
            this.gvListFiles.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "DocId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "DocId";
            gridViewTextBoxColumn2.FieldName = "DocTypeInt";
            gridViewTextBoxColumn2.HeaderText = "IdDocType";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "DocTypeInt";
            gridViewTextBoxColumn2.Width = 48;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "DocType";
            gridViewTextBoxColumn3.HeaderText = "Тип документу";
            gridViewTextBoxColumn3.MinWidth = 0;
            gridViewTextBoxColumn3.Name = "DocType";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 254;
            gridViewTextBoxColumn4.FieldName = "DocComment";
            gridViewTextBoxColumn4.HeaderText = "Коментар";
            gridViewTextBoxColumn4.MinWidth = 0;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "DocComment";
            gridViewTextBoxColumn4.Width = 309;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "DocFile";
            gridViewTextBoxColumn5.HeaderText = "Файл";
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "DocFile";
            gridViewTextBoxColumn5.Width = 286;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.AllowSort = false;
            gridViewCommandColumn1.DefaultText = "Відкрити";
            gridViewCommandColumn1.FieldName = "btnsView";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 35;
            gridViewCommandColumn1.MinWidth = 35;
            gridViewCommandColumn1.Name = "btnsView";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.Width = 35;
            this.gvListFiles.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1});
            this.gvListFiles.MasterTemplate.EnableCustomFiltering = true;
            this.gvListFiles.MasterTemplate.EnableFiltering = true;
            this.gvListFiles.MasterTemplate.EnableGrouping = false;
            this.gvListFiles.MasterTemplate.ShowFilteringRow = false;
            this.gvListFiles.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvListFiles.Name = "gvListFiles";
            this.gvListFiles.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvListFiles.Size = new System.Drawing.Size(907, 99);
            this.gvListFiles.TabIndex = 7;
            this.gvListFiles.ThemeName = "Office2013Light";
            this.gvListFiles.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvListFiles_CommandCellClick);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFile.Location = new System.Drawing.Point(16, 409);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(110, 24);
            this.btnAddFile.TabIndex = 8;
            this.btnAddFile.Text = "Додати документ";
            this.btnAddFile.ThemeName = "Office2013Light";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // MiddleControlCabinetFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.gvListFiles);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.ctrlHeaderInfo);
            this.MinimumSize = new System.Drawing.Size(913, 436);
            this.Name = "MiddleControlCabinetFiles";
            this.Size = new System.Drawing.Size(913, 436);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InformationOfUserControl ctrlHeaderInfo;
        private SingleShowInformationControl agentEmail;
        private SingleShowInformationControl agentPhone;
        private SingleShowInformationControl agentPib;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGridView gvListFiles;
        private Telerik.WinControls.UI.RadButton btnAddFile;
    }
}
