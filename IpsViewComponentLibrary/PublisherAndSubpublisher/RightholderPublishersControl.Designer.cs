namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    partial class RightholderPublishersControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvPublishers = new Telerik.WinControls.UI.RadGridView();
            this.ipsPanel1 = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            this.ctrlGridRowCountPublishers = new IpsViewComponentLibrary.Common.GridRowCountControl();
            this.bsPublisherAndSubpublisherView = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).BeginInit();
            this.ipsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPublisherAndSubpublisherView)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPublishers
            // 
            this.gvPublishers.AutoScroll = true;
            this.gvPublishers.AutoSizeRows = true;
            this.gvPublishers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPublishers.EnableCustomFiltering = true;
            this.gvPublishers.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvPublishers.MasterTemplate.AllowAddNewRow = false;
            this.gvPublishers.MasterTemplate.AllowDeleteRow = false;
            this.gvPublishers.MasterTemplate.AllowDragToGroup = false;
            this.gvPublishers.MasterTemplate.AllowEditRow = false;
            this.gvPublishers.MasterTemplate.AutoGenerateColumns = false;
            this.gvPublishers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustIdPub";
            gridViewTextBoxColumn1.HeaderText = "CustIdPub";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustIdPub";
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.FieldName = "CustIdSub";
            gridViewTextBoxColumn2.HeaderText = "CustIdSub";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "CustIdSub";
            gridViewTextBoxColumn2.Width = 47;
            gridViewTextBoxColumn3.FieldName = "PubName";
            gridViewTextBoxColumn3.HeaderText = "Назва Оригінального видавництва";
            gridViewTextBoxColumn3.MinWidth = 150;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "PubName";
            gridViewTextBoxColumn3.Width = 602;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn4.FieldName = "DateBegin";
            gridViewTextBoxColumn4.FormatString = "{0:d}";
            gridViewTextBoxColumn4.HeaderText = "Дата з";
            gridViewTextBoxColumn4.MaxWidth = 100;
            gridViewTextBoxColumn4.MinWidth = 100;
            gridViewTextBoxColumn4.Name = "DateBegin";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewTextBoxColumn5.FieldName = "DateEnd";
            gridViewTextBoxColumn5.FormatString = "{0:d}";
            gridViewTextBoxColumn5.HeaderText = "Дата по";
            gridViewTextBoxColumn5.MaxWidth = 100;
            gridViewTextBoxColumn5.MinWidth = 100;
            gridViewTextBoxColumn5.Name = "DateEnd";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 100;
            this.gvPublishers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvPublishers.MasterTemplate.DataSource = this.bsPublisherAndSubpublisherView;
            this.gvPublishers.MasterTemplate.EnableCustomFiltering = true;
            this.gvPublishers.MasterTemplate.EnableFiltering = true;
            this.gvPublishers.MasterTemplate.EnableGrouping = false;
            this.gvPublishers.MasterTemplate.ShowFilteringRow = false;
            this.gvPublishers.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvPublishers.Name = "gvPublishers";
            this.gvPublishers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvPublishers.Size = new System.Drawing.Size(826, 423);
            this.gvPublishers.TabIndex = 13;
            this.gvPublishers.ThemeName = "Office2013Light";
            // 
            // ipsPanel1
            // 
            this.ipsPanel1.BorderVisible = false;
            this.ipsPanel1.Controls.Add(this.ctrlGridRowCountPublishers);
            this.ipsPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ipsPanel1.Location = new System.Drawing.Point(0, 423);
            this.ipsPanel1.Name = "ipsPanel1";
            this.ipsPanel1.Size = new System.Drawing.Size(826, 30);
            this.ipsPanel1.TabIndex = 14;
            // 
            // ctrlGridRowCountPublishers
            // 
            this.ctrlGridRowCountPublishers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridRowCountPublishers.Location = new System.Drawing.Point(668, 3);
            this.ctrlGridRowCountPublishers.MaximumSize = new System.Drawing.Size(200, 25);
            this.ctrlGridRowCountPublishers.MinimumSize = new System.Drawing.Size(150, 25);
            this.ctrlGridRowCountPublishers.Name = "ctrlGridRowCountPublishers";
            this.ctrlGridRowCountPublishers.RadGridViewDataSource = null;
            this.ctrlGridRowCountPublishers.Size = new System.Drawing.Size(155, 25);
            this.ctrlGridRowCountPublishers.TabIndex = 1;
            // 
            // bsPublisherAndSubpublisherView
            // 
            this.bsPublisherAndSubpublisherView.DataSource = typeof(ipsFormsDesign.ViewModels.Other.PublisherAndSubpublisherView);
            // 
            // RightholderPublishersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gvPublishers);
            this.Controls.Add(this.ipsPanel1);
            this.Name = "RightholderPublishersControl";
            this.Size = new System.Drawing.Size(826, 453);
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPublishers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsPanel1)).EndInit();
            this.ipsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPublisherAndSubpublisherView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvPublishers;
        private Common.Editors.IpsPanel ipsPanel1;
        private Common.GridRowCountControl ctrlGridRowCountPublishers;
        private System.Windows.Forms.BindingSource bsPublisherAndSubpublisherView;
    }
}
