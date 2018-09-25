namespace IpsViewComponentLibrary.PartnerControls
{
    partial class PartnerClientsControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            this.btnAddClient = new Telerik.WinControls.UI.RadButton();
            this.lblPartnerName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.gvViewClientsOfPartner = new Telerik.WinControls.UI.RadGridView();
            this.btnDetach = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPartnerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewClientsOfPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewClientsOfPartner.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetach)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(6, 28);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(630, 20);
            this.ctrlSearch.TabIndex = 0;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddClient.Location = new System.Drawing.Point(3, 537);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(110, 20);
            this.btnAddClient.TabIndex = 2;
            this.btnAddClient.Text = "Додати Клієнта";
            this.btnAddClient.ThemeName = "Office2013Light";
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // lblPartnerName
            // 
            this.lblPartnerName.AutoSize = false;
            this.lblPartnerName.BorderVisible = true;
            this.lblPartnerName.Location = new System.Drawing.Point(92, 3);
            this.lblPartnerName.MinimumSize = new System.Drawing.Size(45, 18);
            this.lblPartnerName.Name = "lblPartnerName";
            // 
            // 
            // 
            this.lblPartnerName.RootElement.MinSize = new System.Drawing.Size(45, 18);
            this.lblPartnerName.Size = new System.Drawing.Size(379, 18);
            this.lblPartnerName.TabIndex = 32;
            this.lblPartnerName.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lblPartnerName.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblPartnerName.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblPartnerName.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblPartnerName.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblPartnerName.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel16
            // 
            this.radLabel16.Location = new System.Drawing.Point(3, 3);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(83, 19);
            this.radLabel16.TabIndex = 31;
            this.radLabel16.Text = "Представник:";
            this.radLabel16.ThemeName = "Office2013Light";
            // 
            // gvViewClientsOfPartner
            // 
            this.gvViewClientsOfPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewClientsOfPartner.AutoScroll = true;
            this.gvViewClientsOfPartner.EnableCustomFiltering = true;
            this.gvViewClientsOfPartner.Location = new System.Drawing.Point(3, 54);
            // 
            // 
            // 
            this.gvViewClientsOfPartner.MasterTemplate.AllowAddNewRow = false;
            this.gvViewClientsOfPartner.MasterTemplate.AllowDeleteRow = false;
            this.gvViewClientsOfPartner.MasterTemplate.AllowDragToGroup = false;
            this.gvViewClientsOfPartner.MasterTemplate.AllowEditRow = false;
            this.gvViewClientsOfPartner.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewClientsOfPartner.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "ClCustId";
            gridViewTextBoxColumn2.HeaderText = "ID клієнта";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 78;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "ClCustId";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "Innokpo";
            gridViewTextBoxColumn3.HeaderText = "ЄДРПОУ/ІПН";
            gridViewTextBoxColumn3.MaxWidth = 100;
            gridViewTextBoxColumn3.MinWidth = 80;
            gridViewTextBoxColumn3.Name = "Innokpo";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "ClientName";
            gridViewTextBoxColumn4.HeaderText = "Назва клієнта";
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "ClientName";
            gridViewTextBoxColumn4.Width = 544;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "AgrCount";
            gridViewTextBoxColumn5.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn5.MaxWidth = 80;
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "AgrCount";
            gridViewTextBoxColumn5.Width = 80;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "SumBorg";
            gridViewTextBoxColumn6.HeaderText = "Заборгованість";
            gridViewTextBoxColumn6.MaxWidth = 110;
            gridViewTextBoxColumn6.MinWidth = 110;
            gridViewTextBoxColumn6.Name = "SumBorg";
            gridViewTextBoxColumn6.Width = 110;
            this.gvViewClientsOfPartner.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.gvViewClientsOfPartner.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewClientsOfPartner.MasterTemplate.EnableFiltering = true;
            this.gvViewClientsOfPartner.MasterTemplate.EnableGrouping = false;
            this.gvViewClientsOfPartner.MasterTemplate.ShowFilteringRow = false;
            this.gvViewClientsOfPartner.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewClientsOfPartner.Name = "gvViewClientsOfPartner";
            this.gvViewClientsOfPartner.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewClientsOfPartner.Size = new System.Drawing.Size(956, 477);
            this.gvViewClientsOfPartner.TabIndex = 34;
            this.gvViewClientsOfPartner.ThemeName = "Office2013Light";
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetach.Location = new System.Drawing.Point(128, 537);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(110, 20);
            this.btnDetach.TabIndex = 35;
            this.btnDetach.Text = "Відв\'язати клієнта";
            this.btnDetach.ThemeName = "Office2013Light";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // PartnerClientsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDetach);
            this.Controls.Add(this.gvViewClientsOfPartner);
            this.Controls.Add(this.lblPartnerName);
            this.Controls.Add(this.radLabel16);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.ctrlSearch);
            this.Name = "PartnerClientsControl";
            this.Size = new System.Drawing.Size(962, 560);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPartnerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewClientsOfPartner.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewClientsOfPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadButton btnAddClient;
        private Telerik.WinControls.UI.RadLabel lblPartnerName;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadGridView gvViewClientsOfPartner;
        private Telerik.WinControls.UI.RadButton btnDetach;
    }
}
