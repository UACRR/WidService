namespace IpsViewComponentLibrary.CatalogControls
{
    partial class CatalogControl
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn64 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn65 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn66 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn67 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn68 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn69 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn70 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn71 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn72 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition8 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.btnLoadExl = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadExl)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.EnableCustomFiltering = true;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoGenerateColumns = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn64.HeaderText = "№п/п";
            gridViewTextBoxColumn64.ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gridViewTextBoxColumn64.Name = "number";
            gridViewTextBoxColumn64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn64.Width = 55;
            gridViewTextBoxColumn65.HeaderText = "Назва файлу";
            gridViewTextBoxColumn65.Name = "fileName";
            gridViewTextBoxColumn65.Width = 148;
            gridViewTextBoxColumn66.HeaderText = "Дата завантаження";
            gridViewTextBoxColumn66.Name = "dateDownload";
            gridViewTextBoxColumn66.Width = 148;
            gridViewTextBoxColumn67.HeaderText = "К-ть записів всього";
            gridViewTextBoxColumn67.Name = "countFiles";
            gridViewTextBoxColumn67.Width = 49;
            gridViewTextBoxColumn68.HeaderText = "К-ть відкинутих записів";
            gridViewTextBoxColumn68.Name = "countLeaveFiles";
            gridViewTextBoxColumn68.Width = 49;
            gridViewTextBoxColumn69.HeaderText = "Статус файлу";
            gridViewTextBoxColumn69.Name = "statusFile";
            gridViewTextBoxColumn69.Width = 49;
            gridViewTextBoxColumn70.HeaderText = "Коментар";
            gridViewTextBoxColumn70.Name = "comment";
            gridViewTextBoxColumn70.Width = 49;
            gridViewTextBoxColumn71.HeaderText = "Хто завантажив";
            gridViewTextBoxColumn71.Name = "downloadFace";
            gridViewTextBoxColumn71.Width = 49;
            gridViewTextBoxColumn72.HeaderText = "Дія(Перегляд Вилучити\\Ред.коментар)";
            gridViewTextBoxColumn72.Name = "actionFile";
            gridViewTextBoxColumn72.Width = 146;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn64,
            gridViewTextBoxColumn65,
            gridViewTextBoxColumn66,
            gridViewTextBoxColumn67,
            gridViewTextBoxColumn68,
            gridViewTextBoxColumn69,
            gridViewTextBoxColumn70,
            gridViewTextBoxColumn71,
            gridViewTextBoxColumn72});
            this.radGridView1.MasterTemplate.EnableCustomFiltering = true;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition8;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(760, 231);
            this.radGridView1.TabIndex = 1;
            this.radGridView1.ThemeName = "Office2013Light";
            // 
            // btnLoadExl
            // 
            this.btnLoadExl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadExl.Location = new System.Drawing.Point(3, 462);
            this.btnLoadExl.Name = "btnLoadExl";
            this.btnLoadExl.Size = new System.Drawing.Size(219, 24);
            this.btnLoadExl.TabIndex = 2;
            this.btnLoadExl.Text = "Завантажити каталог";
            this.btnLoadExl.ThemeName = "Office2013Light";
            this.btnLoadExl.Click += new System.EventHandler(this.btnLoadExl_Click);
            // 
            // CatalogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadExl);
            this.Controls.Add(this.radGridView1);
            this.Name = "CatalogControl";
            this.Size = new System.Drawing.Size(760, 489);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadExl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton btnLoadExl;
    }
}
