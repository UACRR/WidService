namespace DdexInvoicing
{
    partial class FormCreateInvoice
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
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn1 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateInvoice));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radBtnOk = new Telerik.WinControls.UI.RadButton();
            this.radBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.radGridParams = new Telerik.WinControls.UI.RadGridView();
            this.radLabelPrompt = new Telerik.WinControls.UI.RadLabel();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridParams.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelPrompt)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelMain.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.panelMain.Controls.Add(this.radGridParams, 0, 1);
            this.panelMain.Controls.Add(this.radLabelPrompt, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.66993F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.33007F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(827, 425);
            this.panelMain.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel3.Controls.Add(this.radBtnOk, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.radBtnCancel, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 375);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(821, 38);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // radBtnOk
            // 
            this.radBtnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radBtnOk.Location = new System.Drawing.Point(616, 3);
            this.radBtnOk.Name = "radBtnOk";
            this.radBtnOk.Size = new System.Drawing.Size(113, 32);
            this.radBtnOk.TabIndex = 0;
            this.radBtnOk.Text = "Створити рахунок";
            this.radBtnOk.Click += new System.EventHandler(this.radBtnOk_Click);
            // 
            // radBtnCancel
            // 
            this.radBtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radBtnCancel.Location = new System.Drawing.Point(735, 3);
            this.radBtnCancel.Name = "radBtnCancel";
            this.radBtnCancel.Size = new System.Drawing.Size(83, 32);
            this.radBtnCancel.TabIndex = 0;
            this.radBtnCancel.Text = "Відмінити";
            this.radBtnCancel.Click += new System.EventHandler(this.radBtnCancel_Click);
            // 
            // radGridParams
            // 
            this.radGridParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridParams.EnableHotTracking = false;
            this.radGridParams.Location = new System.Drawing.Point(3, 57);
            // 
            // 
            // 
            this.radGridParams.MasterTemplate.AllowAddNewRow = false;
            this.radGridParams.MasterTemplate.AllowColumnChooser = false;
            this.radGridParams.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridParams.MasterTemplate.AllowColumnReorder = false;
            this.radGridParams.MasterTemplate.AllowColumnResize = false;
            this.radGridParams.MasterTemplate.AllowDeleteRow = false;
            this.radGridParams.MasterTemplate.AllowDragToGroup = false;
            this.radGridParams.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn1.FieldName = "paramName";
            gridViewTextBoxColumn1.HeaderText = "Параметр";
            gridViewTextBoxColumn1.Name = "paramName";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 500;
            gridViewMaskBoxColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
            gridViewMaskBoxColumn1.FieldName = "paramValue";
            gridViewMaskBoxColumn1.HeaderText = "Значення";
            gridViewMaskBoxColumn1.Mask = "p";
            gridViewMaskBoxColumn1.MaskType = Telerik.WinControls.UI.MaskType.None;
            gridViewMaskBoxColumn1.Name = "paramValue";
            gridViewMaskBoxColumn1.ReadOnly = true;
            gridViewMaskBoxColumn1.Width = 300;
            this.radGridParams.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewMaskBoxColumn1});
            this.radGridParams.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridParams.MasterTemplate.EnableGrouping = false;
            this.radGridParams.MasterTemplate.EnableSorting = false;
            this.radGridParams.MasterTemplate.ShowFilteringRow = false;
            this.radGridParams.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridParams.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridParams.Name = "radGridParams";
            this.radGridParams.ShowGroupPanel = false;
            this.radGridParams.Size = new System.Drawing.Size(821, 312);
            this.radGridParams.TabIndex = 4;
            // 
            // radLabelPrompt
            // 
            this.radLabelPrompt.AutoSize = false;
            this.radLabelPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelPrompt.Location = new System.Drawing.Point(3, 3);
            this.radLabelPrompt.Name = "radLabelPrompt";
            this.radLabelPrompt.Size = new System.Drawing.Size(821, 48);
            this.radLabelPrompt.TabIndex = 0;
            this.radLabelPrompt.Text = "radLabel1";
            // 
            // FormCreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(827, 425);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateInvoice";
            this.Text = "Параметри розрахунку суми до виплати";
            this.Load += new System.EventHandler(this.FormCreateInvoice_Load);
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridParams.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelPrompt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private Telerik.WinControls.UI.RadLabel radLabelPrompt;
        private Telerik.WinControls.UI.RadGridView radGridParams;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Telerik.WinControls.UI.RadButton radBtnOk;
        private Telerik.WinControls.UI.RadButton radBtnCancel;
    }
}