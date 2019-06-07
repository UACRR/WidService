namespace IpsViewComponentLibrary.ImportDBF
{
    partial class PaymentsAttachForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.footerPanel = new Telerik.WinControls.UI.RadPanel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnAttach = new Telerik.WinControls.UI.RadButton();
            this.headerPanel = new Telerik.WinControls.UI.RadPanel();
            this.txtDestinationPay = new Telerik.WinControls.UI.RadTextBoxControl();
            this.txtName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.txtIpnokpo = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.fileNameTitle = new Telerik.WinControls.UI.RadLabel();
            this.gvCustomers = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestinationPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpnokpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Silver;
            this.footerPanel.Controls.Add(this.btnCancel);
            this.footerPanel.Controls.Add(this.btnAttach);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 481);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(982, 30);
            this.footerPanel.TabIndex = 2;
            this.footerPanel.ThemeName = "Office2013Light";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(859, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttach.Location = new System.Drawing.Point(721, 3);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(120, 24);
            this.btnAttach.TabIndex = 3;
            this.btnAttach.Text = "Прив\'язати";
            this.btnAttach.ThemeName = "Office2013Light";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.txtDestinationPay);
            this.headerPanel.Controls.Add(this.txtName);
            this.headerPanel.Controls.Add(this.ctrlSearch);
            this.headerPanel.Controls.Add(this.radSeparator1);
            this.headerPanel.Controls.Add(this.txtIpnokpo);
            this.headerPanel.Controls.Add(this.radLabel3);
            this.headerPanel.Controls.Add(this.radLabel2);
            this.headerPanel.Controls.Add(this.radLabel1);
            this.headerPanel.Controls.Add(this.fileNameTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(982, 151);
            this.headerPanel.TabIndex = 3;
            this.headerPanel.ThemeName = "Office2013Light";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.headerPanel.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // txtDestinationPay
            // 
            this.txtDestinationPay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationPay.IsReadOnly = true;
            this.txtDestinationPay.IsReadOnlyCaretVisible = true;
            this.txtDestinationPay.Location = new System.Drawing.Point(162, 81);
            this.txtDestinationPay.MinimumSize = new System.Drawing.Size(120, 19);
            this.txtDestinationPay.Name = "txtDestinationPay";
            // 
            // 
            // 
            this.txtDestinationPay.RootElement.MinSize = new System.Drawing.Size(120, 19);
            this.txtDestinationPay.Size = new System.Drawing.Size(808, 19);
            this.txtDestinationPay.TabIndex = 11;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderWidth = 1F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderLeftWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderTopWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderRightWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderTopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtDestinationPay.GetChildAt(0))).BorderTopShadowColor = System.Drawing.Color.Transparent;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.IsReadOnly = true;
            this.txtName.IsReadOnlyCaretVisible = true;
            this.txtName.Location = new System.Drawing.Point(137, 56);
            this.txtName.MinimumSize = new System.Drawing.Size(120, 19);
            this.txtName.Name = "txtName";
            // 
            // 
            // 
            this.txtName.RootElement.MinSize = new System.Drawing.Size(120, 19);
            this.txtName.Size = new System.Drawing.Size(833, 19);
            this.txtName.TabIndex = 10;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderWidth = 1F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderLeftWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderTopWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderRightWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderTopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtName.GetChildAt(0))).BorderTopShadowColor = System.Drawing.Color.Transparent;
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(13, 123);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 9;
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(3, 107);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(976, 10);
            this.radSeparator1.TabIndex = 8;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // txtIpnokpo
            // 
            this.txtIpnokpo.IsReadOnly = true;
            this.txtIpnokpo.IsReadOnlyCaretVisible = true;
            this.txtIpnokpo.Location = new System.Drawing.Point(86, 31);
            this.txtIpnokpo.MinimumSize = new System.Drawing.Size(120, 19);
            this.txtIpnokpo.Name = "txtIpnokpo";
            // 
            // 
            // 
            this.txtIpnokpo.RootElement.MinSize = new System.Drawing.Size(120, 19);
            this.txtIpnokpo.Size = new System.Drawing.Size(181, 19);
            this.txtIpnokpo.TabIndex = 5;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderWidth = 1F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderLeftWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderTopWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderRightWidth = 0F;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderColor2 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderColor3 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderColor4 = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderTopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            ((Telerik.WinControls.UI.RadTextBoxControlElement)(this.txtIpnokpo.GetChildAt(0))).BorderTopShadowColor = System.Drawing.Color.Transparent;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(13, 81);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(143, 19);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "– призначення платежу:";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(13, 56);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(125, 19);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "– назва користувача:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(67, 19);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "– ЄДРПОУ:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // fileNameTitle
            // 
            this.fileNameTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameTitle.Location = new System.Drawing.Point(12, 3);
            this.fileNameTitle.Name = "fileNameTitle";
            this.fileNameTitle.Size = new System.Drawing.Size(179, 21);
            this.fileNameTitle.TabIndex = 1;
            this.fileNameTitle.Text = "Дані по обраному платежу: ";
            this.fileNameTitle.ThemeName = "Office2013Light";
            // 
            // gvCustomers
            // 
            this.gvCustomers.AutoScroll = true;
            this.gvCustomers.AutoSizeRows = true;
            this.gvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCustomers.EnableCustomFiltering = true;
            this.gvCustomers.Location = new System.Drawing.Point(0, 151);
            // 
            // 
            // 
            this.gvCustomers.MasterTemplate.AllowAddNewRow = false;
            this.gvCustomers.MasterTemplate.AllowCellContextMenu = false;
            this.gvCustomers.MasterTemplate.AllowColumnChooser = false;
            this.gvCustomers.MasterTemplate.AllowDeleteRow = false;
            this.gvCustomers.MasterTemplate.AllowDragToGroup = false;
            this.gvCustomers.MasterTemplate.AllowEditRow = false;
            this.gvCustomers.MasterTemplate.AutoGenerateColumns = false;
            this.gvCustomers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "Innokpo";
            gridViewTextBoxColumn2.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn2.MaxWidth = 120;
            gridViewTextBoxColumn2.MinWidth = 120;
            gridViewTextBoxColumn2.Name = "Innokpo";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.FieldName = "name";
            gridViewTextBoxColumn3.HeaderText = "Назва користувача";
            gridViewTextBoxColumn3.MinWidth = 110;
            gridViewTextBoxColumn3.Name = "name";
            gridViewTextBoxColumn3.Width = 837;
            gridViewTextBoxColumn3.WrapText = true;
            this.gvCustomers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.gvCustomers.MasterTemplate.EnableCustomFiltering = true;
            this.gvCustomers.MasterTemplate.EnableFiltering = true;
            this.gvCustomers.MasterTemplate.EnableGrouping = false;
            this.gvCustomers.MasterTemplate.ShowFilteringRow = false;
            this.gvCustomers.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvCustomers.Name = "gvCustomers";
            this.gvCustomers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvCustomers.ReadOnly = true;
            this.gvCustomers.ShowGroupPanel = false;
            this.gvCustomers.ShowGroupPanelScrollbars = false;
            this.gvCustomers.Size = new System.Drawing.Size(982, 330);
            this.gvCustomers.TabIndex = 4;
            this.gvCustomers.ThemeName = "Office2013Light";
            this.gvCustomers.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvCustomers_CellDoubleClick);
            // 
            // PaymentsAttachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(982, 511);
            this.Controls.Add(this.gvCustomers);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.footerPanel);
            this.MinimumSize = new System.Drawing.Size(575, 360);
            this.Name = "PaymentsAttachForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Пошук і прив\'язка платежів до користувача";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestinationPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpnokpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileNameTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPanel footerPanel;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnAttach;
        private Telerik.WinControls.UI.RadPanel headerPanel;
        private Telerik.WinControls.UI.RadLabel fileNameTitle;
        private Telerik.WinControls.UI.RadGridView gvCustomers;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadTextBoxControl txtIpnokpo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBoxControl txtDestinationPay;
        private Telerik.WinControls.UI.RadTextBoxControl txtName;
    }
}