namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class ClosedAgreementsControl
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvClosedLicenses = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.gvClosedLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClosedLicenses.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // gvClosedLicenses
            // 
            this.gvClosedLicenses.AutoScroll = true;
            this.gvClosedLicenses.AutoSizeRows = true;
            this.gvClosedLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvClosedLicenses.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvClosedLicenses.MasterTemplate.AllowAddNewRow = false;
            this.gvClosedLicenses.MasterTemplate.AllowDeleteRow = false;
            this.gvClosedLicenses.MasterTemplate.AllowDragToGroup = false;
            this.gvClosedLicenses.MasterTemplate.AllowEditRow = false;
            this.gvClosedLicenses.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "LicenseCode";
            gridViewTextBoxColumn1.HeaderText = "Шифр / версія";
            gridViewTextBoxColumn1.MinWidth = 50;
            gridViewTextBoxColumn1.Name = "LicenseCode";
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.FieldName = "License";
            gridViewTextBoxColumn2.HeaderText = "Ліцензія";
            gridViewTextBoxColumn2.MinWidth = 120;
            gridViewTextBoxColumn2.Name = "License";
            gridViewTextBoxColumn2.Width = 251;
            gridViewTextBoxColumn3.FieldName = "Series";
            gridViewTextBoxColumn3.HeaderText = "Серія";
            gridViewTextBoxColumn3.MinWidth = 50;
            gridViewTextBoxColumn3.Name = "Series";
            gridViewTextBoxColumn4.FieldName = "AgrNumber";
            gridViewTextBoxColumn4.HeaderText = "Номер договору";
            gridViewTextBoxColumn4.MinWidth = 110;
            gridViewTextBoxColumn4.Name = "AgrNumber";
            gridViewTextBoxColumn4.Width = 110;
            gridViewTextBoxColumn5.FieldName = "DateBegin";
            gridViewTextBoxColumn5.HeaderText = "Дата початку";
            gridViewTextBoxColumn5.MaxWidth = 80;
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "DateBegin";
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "DateEnd";
            gridViewTextBoxColumn6.HeaderText = "Дата завершення";
            gridViewTextBoxColumn6.MaxWidth = 80;
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Name = "DateEnd";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "MinRate";
            gridViewTextBoxColumn7.FormatString = "{0:##0.00}";
            gridViewTextBoxColumn7.HeaderText = "Тариф";
            gridViewTextBoxColumn7.MaxWidth = 90;
            gridViewTextBoxColumn7.MinWidth = 90;
            gridViewTextBoxColumn7.Name = "MinRate";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 90;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewDecimalColumn1.FieldName = "MinAmount";
            gridViewDecimalColumn1.FormatString = "{0:### ### ##0.00}";
            gridViewDecimalColumn1.HeaderText = "Гарантійний платіж";
            gridViewDecimalColumn1.MinWidth = 100;
            gridViewDecimalColumn1.Name = "MinAmount";
            gridViewDecimalColumn1.Width = 100;
            gridViewDecimalColumn1.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "State";
            gridViewTextBoxColumn8.HeaderText = "Статус";
            gridViewTextBoxColumn8.MinWidth = 120;
            gridViewTextBoxColumn8.Name = "State";
            gridViewTextBoxColumn8.Width = 120;
            gridViewTextBoxColumn9.FieldName = "PeriodPayment";
            gridViewTextBoxColumn9.HeaderText = "Періодичність оплати";
            gridViewTextBoxColumn9.MaxWidth = 120;
            gridViewTextBoxColumn9.MinWidth = 100;
            gridViewTextBoxColumn9.Name = "PeriodPayment";
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.FieldName = "DateLastPayment";
            gridViewTextBoxColumn10.HeaderText = "Дата останньої оплати";
            gridViewTextBoxColumn10.MaxWidth = 90;
            gridViewTextBoxColumn10.MinWidth = 90;
            gridViewTextBoxColumn10.Multiline = true;
            gridViewTextBoxColumn10.Name = "DateLastPayment";
            gridViewTextBoxColumn10.Width = 90;
            gridViewTextBoxColumn10.WrapText = true;
            gridViewTextBoxColumn11.FieldName = "Id";
            gridViewTextBoxColumn11.HeaderText = "Id";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "Id";
            gridViewTextBoxColumn11.Width = 48;
            gridViewCheckBoxColumn1.FieldName = "IsAutoprolog";
            gridViewCheckBoxColumn1.HeaderText = "а-п";
            gridViewCheckBoxColumn1.MaxWidth = 30;
            gridViewCheckBoxColumn1.MinWidth = 30;
            gridViewCheckBoxColumn1.Name = "IsAutoprolog";
            gridViewCheckBoxColumn1.Width = 30;
            gridViewCommandColumn1.FieldName = "printBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.print_solid;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "printBtn";
            gridViewCommandColumn1.Width = 30;
            this.gvClosedLicenses.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewCheckBoxColumn1,
            gridViewCommandColumn1});
            this.gvClosedLicenses.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvClosedLicenses.MinimumSize = new System.Drawing.Size(300, 100);
            this.gvClosedLicenses.Name = "gvClosedLicenses";
            this.gvClosedLicenses.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvClosedLicenses.ReadOnly = true;
            // 
            // 
            // 
            this.gvClosedLicenses.RootElement.MinSize = new System.Drawing.Size(300, 100);
            this.gvClosedLicenses.ShowGroupPanel = false;
            this.gvClosedLicenses.Size = new System.Drawing.Size(993, 523);
            this.gvClosedLicenses.TabIndex = 12;
            this.gvClosedLicenses.ThemeName = "Office2013Light";
            this.gvClosedLicenses.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvClosedLicenses_CommandCellClick);
            // 
            // ClosedAgreementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvClosedLicenses);
            this.Name = "ClosedAgreementsControl";
            this.Size = new System.Drawing.Size(993, 523);
            ((System.ComponentModel.ISupportInitialize)(this.gvClosedLicenses.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClosedLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvClosedLicenses;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
