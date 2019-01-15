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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvClosedLicenses = new Telerik.WinControls.UI.RadGridView();
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
            gridViewTextBoxColumn1.FieldName = "License";
            gridViewTextBoxColumn1.HeaderText = "Ліцензія";
            gridViewTextBoxColumn1.Name = "License";
            gridViewTextBoxColumn1.Width = 155;
            gridViewTextBoxColumn2.FieldName = "Series";
            gridViewTextBoxColumn2.HeaderText = "Серія";
            gridViewTextBoxColumn2.Name = "Series";
            gridViewTextBoxColumn2.Width = 43;
            gridViewTextBoxColumn3.FieldName = "AgrNumber";
            gridViewTextBoxColumn3.HeaderText = "Номер договору";
            gridViewTextBoxColumn3.Name = "AgrNumber";
            gridViewTextBoxColumn3.Width = 107;
            gridViewTextBoxColumn4.FieldName = "DateBegin";
            gridViewTextBoxColumn4.HeaderText = "Дата початку";
            gridViewTextBoxColumn4.MaxWidth = 80;
            gridViewTextBoxColumn4.MinWidth = 80;
            gridViewTextBoxColumn4.Name = "DateBegin";
            gridViewTextBoxColumn4.Width = 80;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "DateEnd";
            gridViewTextBoxColumn5.HeaderText = "Дата завершення";
            gridViewTextBoxColumn5.MaxWidth = 80;
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "DateEnd";
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "MinRate";
            gridViewTextBoxColumn6.HeaderText = "Умова %";
            gridViewTextBoxColumn6.Name = "MinRate";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 60;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewDecimalColumn1.FieldName = "MinAmount";
            gridViewDecimalColumn1.HeaderText = "Умова мін. сума";
            gridViewDecimalColumn1.Name = "MinAmount";
            gridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn1.Width = 77;
            gridViewDecimalColumn1.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "State";
            gridViewTextBoxColumn7.HeaderText = "Статус";
            gridViewTextBoxColumn7.Name = "State";
            gridViewTextBoxColumn7.Width = 77;
            gridViewTextBoxColumn8.FieldName = "PeriodPayment";
            gridViewTextBoxColumn8.HeaderText = "Періодичність оплати";
            gridViewTextBoxColumn8.Name = "PeriodPayment";
            gridViewTextBoxColumn8.Width = 149;
            gridViewTextBoxColumn8.WrapText = true;
            gridViewTextBoxColumn9.FieldName = "DateLastPayment";
            gridViewTextBoxColumn9.HeaderText = "Дата останньої оплати";
            gridViewTextBoxColumn9.MaxWidth = 90;
            gridViewTextBoxColumn9.MinWidth = 90;
            gridViewTextBoxColumn9.Multiline = true;
            gridViewTextBoxColumn9.Name = "DateLastPayment";
            gridViewTextBoxColumn9.Width = 90;
            gridViewTextBoxColumn9.WrapText = true;
            gridViewTextBoxColumn10.FieldName = "Id";
            gridViewTextBoxColumn10.HeaderText = "Id";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "Id";
            gridViewTextBoxColumn10.Width = 48;
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
            gridViewDecimalColumn1,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
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
    }
}
