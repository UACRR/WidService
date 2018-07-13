namespace IpsViewComponentLibrary
{
    partial class MiddleControlCabinetGenAgreement
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ctrlHeaderInfo = new IpsViewComponentLibrary.InformationOfUserControl();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.gvViewLicences = new Telerik.WinControls.UI.RadGridView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlHeaderInfo
            // 
            this.ctrlHeaderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlHeaderInfo.Edrpou = "";
            this.ctrlHeaderInfo.EmailContactPerson = "";
            this.ctrlHeaderInfo.EmailManager = "";
            this.ctrlHeaderInfo.GroupOrHolding = "Копірайт";
            this.ctrlHeaderInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeaderInfo.MaximumSize = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.MinimumSize = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.Name = "ctrlHeaderInfo";
            this.ctrlHeaderInfo.NameInfo = "";
            this.ctrlHeaderInfo.OrganisationForm = "";
            this.ctrlHeaderInfo.PhoneContactPerson = "";
            this.ctrlHeaderInfo.PhoneManager = "";
            this.ctrlHeaderInfo.PibContactPerson = "";
            this.ctrlHeaderInfo.PibManager = "";
            this.ctrlHeaderInfo.Size = new System.Drawing.Size(912, 209);
            this.ctrlHeaderInfo.TabIndex = 0;
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(4, 210);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(905, 10);
            this.radSeparator1.TabIndex = 1;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // gvViewLicences
            // 
            this.gvViewLicences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewLicences.AutoSizeRows = true;
            this.gvViewLicences.EnableCustomFiltering = true;
            this.gvViewLicences.Location = new System.Drawing.Point(4, 226);
            // 
            // 
            // 
            this.gvViewLicences.MasterTemplate.AllowAddNewRow = false;
            this.gvViewLicences.MasterTemplate.AllowDeleteRow = false;
            this.gvViewLicences.MasterTemplate.AllowDragToGroup = false;
            this.gvViewLicences.MasterTemplate.AllowEditRow = false;
            this.gvViewLicences.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewLicences.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Назва клієнта";
            gridViewTextBoxColumn2.MinWidth = 0;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 414;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "JaCity";
            gridViewTextBoxColumn3.HeaderText = "№ ген. договору";
            gridViewTextBoxColumn3.MinWidth = 0;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "JaCity";
            gridViewTextBoxColumn3.Width = 149;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.FieldName = "CountLic2Active";
            gridViewTextBoxColumn4.HeaderText = "Дата початку";
            gridViewTextBoxColumn4.MaxWidth = 100;
            gridViewTextBoxColumn4.MinWidth = 100;
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "CountLic2Active";
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "CountLic3Active";
            gridViewTextBoxColumn5.HeaderText = "Дата завершення";
            gridViewTextBoxColumn5.MaxWidth = 100;
            gridViewTextBoxColumn5.MinWidth = 100;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "CountLic3Active";
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "PartnerName";
            gridViewTextBoxColumn6.HeaderText = "Стан";
            gridViewTextBoxColumn6.MaxWidth = 120;
            gridViewTextBoxColumn6.MinWidth = 120;
            gridViewTextBoxColumn6.Name = "PartnerName";
            gridViewTextBoxColumn6.Width = 120;
            this.gvViewLicences.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gvViewLicences.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableFiltering = true;
            this.gvViewLicences.MasterTemplate.EnableGrouping = false;
            this.gvViewLicences.MasterTemplate.ShowFilteringRow = false;
            this.gvViewLicences.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewLicences.Name = "gvViewLicences";
            this.gvViewLicences.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewLicences.Size = new System.Drawing.Size(905, 164);
            this.gvViewLicences.TabIndex = 8;
            this.gvViewLicences.ThemeName = "Office2013Light";
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton1.Location = new System.Drawing.Point(4, 396);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 9;
            this.radButton1.Text = "Перегляд";
            this.radButton1.ThemeName = "Office2013Light";
            // 
            // radButton2
            // 
            this.radButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton2.Location = new System.Drawing.Point(567, 396);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 10;
            this.radButton2.Text = "Новий договір";
            this.radButton2.ThemeName = "Office2013Light";
            // 
            // radButton3
            // 
            this.radButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton3.Location = new System.Drawing.Point(799, 396);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(110, 24);
            this.radButton3.TabIndex = 11;
            this.radButton3.Text = "Підтвердити";
            this.radButton3.ThemeName = "Office2013Light";
            // 
            // radButton4
            // 
            this.radButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton4.Location = new System.Drawing.Point(683, 396);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(110, 24);
            this.radButton4.TabIndex = 12;
            this.radButton4.Text = "Редагувати";
            this.radButton4.ThemeName = "Office2013Light";
            // 
            // MiddleControlCabinetGenAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radButton4);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.gvViewLicences);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.ctrlHeaderInfo);
            this.MinimumSize = new System.Drawing.Size(912, 300);
            this.Name = "MiddleControlCabinetGenAgreement";
            this.Size = new System.Drawing.Size(912, 594);
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private InformationOfUserControl ctrlHeaderInfo;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadGridView gvViewLicences;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton4;
    }
}
