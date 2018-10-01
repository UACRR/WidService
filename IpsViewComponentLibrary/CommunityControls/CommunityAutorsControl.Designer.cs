namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityAutorsControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewAutors = new Telerik.WinControls.UI.RadGridView();
            this.lblPartnerName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.btnAddAutor = new Telerik.WinControls.UI.RadButton();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPartnerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAutor)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewAutors
            // 
            this.gvViewAutors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewAutors.AutoScroll = true;
            this.gvViewAutors.EnableCustomFiltering = true;
            this.gvViewAutors.Location = new System.Drawing.Point(3, 54);
            // 
            // 
            // 
            this.gvViewAutors.MasterTemplate.AllowAddNewRow = false;
            this.gvViewAutors.MasterTemplate.AllowDeleteRow = false;
            this.gvViewAutors.MasterTemplate.AllowDragToGroup = false;
            this.gvViewAutors.MasterTemplate.AllowEditRow = false;
            this.gvViewAutors.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewAutors.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "ClCustId";
            gridViewTextBoxColumn2.HeaderText = "Шифр автора / правовласника";
            gridViewTextBoxColumn2.MaxWidth = 100;
            gridViewTextBoxColumn2.MinWidth = 100;
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "ClCustId";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "Innokpo";
            gridViewTextBoxColumn3.HeaderText = "IPI";
            gridViewTextBoxColumn3.MaxWidth = 100;
            gridViewTextBoxColumn3.MinWidth = 80;
            gridViewTextBoxColumn3.Name = "Innokpo";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 80;
            gridViewTextBoxColumn4.FieldName = "ClientName";
            gridViewTextBoxColumn4.HeaderText = "Правовласник";
            gridViewTextBoxColumn4.Multiline = true;
            gridViewTextBoxColumn4.Name = "ClientName";
            gridViewTextBoxColumn4.Width = 306;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.FieldName = "AgrCount";
            gridViewTextBoxColumn5.FormatString = "{0:d}";
            gridViewTextBoxColumn5.HeaderText = "Дата народження / створення";
            gridViewTextBoxColumn5.MaxWidth = 120;
            gridViewTextBoxColumn5.MinWidth = 120;
            gridViewTextBoxColumn5.Multiline = true;
            gridViewTextBoxColumn5.Name = "AgrCount";
            gridViewTextBoxColumn5.Width = 120;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.HeaderText = "К-сть об\'єктів";
            gridViewTextBoxColumn6.MaxWidth = 80;
            gridViewTextBoxColumn6.MinWidth = 80;
            gridViewTextBoxColumn6.Name = "column1";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "SumBorg";
            gridViewTextBoxColumn7.HeaderText = "Дохід з початку року";
            gridViewTextBoxColumn7.MaxWidth = 110;
            gridViewTextBoxColumn7.MinWidth = 110;
            gridViewTextBoxColumn7.Name = "SumBorg";
            gridViewTextBoxColumn7.Width = 110;
            gridViewTextBoxColumn7.WrapText = true;
            this.gvViewAutors.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.gvViewAutors.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableGrouping = false;
            this.gvViewAutors.MasterTemplate.ShowFilteringRow = false;
            this.gvViewAutors.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewAutors.Name = "gvViewAutors";
            this.gvViewAutors.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewAutors.Size = new System.Drawing.Size(817, 365);
            this.gvViewAutors.TabIndex = 40;
            this.gvViewAutors.ThemeName = "Office2013Light";
            // 
            // lblPartnerName
            // 
            this.lblPartnerName.AutoSize = false;
            this.lblPartnerName.BorderVisible = true;
            this.lblPartnerName.Location = new System.Drawing.Point(74, 3);
            this.lblPartnerName.MinimumSize = new System.Drawing.Size(45, 18);
            this.lblPartnerName.Name = "lblPartnerName";
            // 
            // 
            // 
            this.lblPartnerName.RootElement.MinSize = new System.Drawing.Size(45, 18);
            this.lblPartnerName.Size = new System.Drawing.Size(379, 18);
            this.lblPartnerName.TabIndex = 39;
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
            this.radLabel16.Size = new System.Drawing.Size(65, 19);
            this.radLabel16.TabIndex = 38;
            this.radLabel16.Text = "Спільнота:";
            this.radLabel16.ThemeName = "Office2013Light";
            // 
            // btnAddAutor
            // 
            this.btnAddAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAutor.Location = new System.Drawing.Point(3, 425);
            this.btnAddAutor.Name = "btnAddAutor";
            this.btnAddAutor.Size = new System.Drawing.Size(110, 20);
            this.btnAddAutor.TabIndex = 37;
            this.btnAddAutor.Text = "Додати Автора";
            this.btnAddAutor.ThemeName = "Office2013Light";
            this.btnAddAutor.Click += new System.EventHandler(this.btnAddAutor_Click);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(6, 28);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(630, 20);
            this.ctrlSearch.TabIndex = 36;
            // 
            // CommunityAutorsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvViewAutors);
            this.Controls.Add(this.lblPartnerName);
            this.Controls.Add(this.radLabel16);
            this.Controls.Add(this.btnAddAutor);
            this.Controls.Add(this.ctrlSearch);
            this.Name = "CommunityAutorsControl";
            this.Size = new System.Drawing.Size(823, 448);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPartnerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAutor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvViewAutors;
        private Telerik.WinControls.UI.RadLabel lblPartnerName;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadButton btnAddAutor;
        private Common.SearchTextBoxControl ctrlSearch;
    }
}
