using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    partial class DistributionForm
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2007SilverTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.gvUserMoneys = new Telerik.WinControls.UI.RadGridView();
            this.gvDistributionPayment = new Telerik.WinControls.UI.RadGridView();
            this.btnCreateNewPeriod = new Telerik.WinControls.UI.RadButton();
            this.btnSaveDistrib = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserMoneys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserMoneys.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveDistrib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvUserMoneys
            // 
            this.gvUserMoneys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvUserMoneys.Location = new System.Drawing.Point(12, 12);
            // 
            // 
            // 
            this.gvUserMoneys.MasterTemplate.AllowAddNewRow = false;
            this.gvUserMoneys.MasterTemplate.AllowColumnReorder = false;
            this.gvUserMoneys.MasterTemplate.AllowDragToGroup = false;
            this.gvUserMoneys.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.Expression = "";
            gridViewTextBoxColumn1.FieldName = "NumberInvoice";
            gridViewTextBoxColumn1.HeaderText = "Номер платежу";
            gridViewTextBoxColumn1.Name = "NumberInvoice";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.EnableExpressionEditor = true;
            gridViewTextBoxColumn2.Expression = "";
            gridViewTextBoxColumn2.FieldName = "DateInvoice";
            gridViewTextBoxColumn2.FormatString = "\"{0:d}\"";
            gridViewTextBoxColumn2.HeaderText = "Дата платежу";
            gridViewTextBoxColumn2.Name = "DateInvoice";
            gridViewTextBoxColumn2.Width = 100;
            gridViewDecimalColumn1.FieldName = "Amount";
            gridViewDecimalColumn1.HeaderText = "Сума платежу";
            gridViewDecimalColumn1.Name = "Amount";
            gridViewDecimalColumn1.Width = 120;
            gridViewDecimalColumn2.FieldName = "DestribAmount";
            gridViewDecimalColumn2.HeaderText = "Сума для прив\'язки";
            gridViewDecimalColumn2.Name = "DestribAmount";
            gridViewDecimalColumn2.Width = 120;
            gridViewTextBoxColumn3.FieldName = "GoalInvoice";
            gridViewTextBoxColumn3.HeaderText = "Призначення платежу";
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "GoalInvoice";
            gridViewTextBoxColumn3.Width = 547;
            gridViewTextBoxColumn4.FieldName = "PaidId";
            gridViewTextBoxColumn4.HeaderText = "Id";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "PaidId";
            gridViewTextBoxColumn4.Width = 49;
            this.gvUserMoneys.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvUserMoneys.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvUserMoneys.Name = "gvUserMoneys";
            this.gvUserMoneys.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvUserMoneys.ReadOnly = true;
            this.gvUserMoneys.ShowGroupPanel = false;
            this.gvUserMoneys.ShowGroupPanelScrollbars = false;
            this.gvUserMoneys.Size = new System.Drawing.Size(1004, 79);
            this.gvUserMoneys.TabIndex = 9;
            this.gvUserMoneys.ThemeName = "Office2007Silver";
            // 
            // gvDistributionPayment
            // 
            this.gvDistributionPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDistributionPayment.AutoScroll = true;
            this.gvDistributionPayment.Location = new System.Drawing.Point(12, 97);
            // 
            // 
            // 
            this.gvDistributionPayment.MasterTemplate.AllowAddNewRow = false;
            this.gvDistributionPayment.MasterTemplate.AllowColumnReorder = false;
            this.gvDistributionPayment.MasterTemplate.AllowDeleteRow = false;
            this.gvDistributionPayment.MasterTemplate.AllowDragToGroup = false;
            this.gvDistributionPayment.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.FieldName = "Period";
            gridViewTextBoxColumn5.HeaderText = "Період";
            gridViewTextBoxColumn5.Name = "Period";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 184;
            gridViewTextBoxColumn6.FieldName = "StateOfPeriod";
            gridViewTextBoxColumn6.HeaderText = "Стан періоду";
            gridViewTextBoxColumn6.Name = "StateOfPeriod";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 154;
            gridViewDecimalColumn3.FieldName = "AmountNeed";
            gridViewDecimalColumn3.HeaderText = "Вимога";
            gridViewDecimalColumn3.Name = "AmountNeed";
            gridViewDecimalColumn3.ReadOnly = true;
            gridViewDecimalColumn3.Width = 176;
            gridViewDecimalColumn4.FieldName = "AmountBound";
            gridViewDecimalColumn4.HeaderText = "Прив\'язано";
            gridViewDecimalColumn4.Name = "AmountBound";
            gridViewDecimalColumn4.ReadOnly = true;
            gridViewDecimalColumn4.Width = 176;
            gridViewDecimalColumn5.FieldName = "Arrears";
            gridViewDecimalColumn5.HeaderText = "Борг";
            gridViewDecimalColumn5.Name = "Arrears";
            gridViewDecimalColumn5.ReadOnly = true;
            gridViewDecimalColumn5.Width = 152;
            gridViewTextBoxColumn7.DataType = typeof(decimal);
            gridViewTextBoxColumn7.FieldName = "DistribAmount";
            gridViewTextBoxColumn7.HeaderText = "Сума прив\'язки";
            gridViewTextBoxColumn7.Name = "DistribAmount";
            gridViewTextBoxColumn7.Width = 146;
            this.gvDistributionPayment.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewDecimalColumn5,
            gridViewTextBoxColumn7});
            this.gvDistributionPayment.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvDistributionPayment.Name = "gvDistributionPayment";
            this.gvDistributionPayment.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvDistributionPayment.ShowGroupPanel = false;
            this.gvDistributionPayment.Size = new System.Drawing.Size(1004, 114);
            this.gvDistributionPayment.TabIndex = 10;
            this.gvDistributionPayment.ThemeName = "Office2007Silver";
            // 
            // btnCreateNewPeriod
            // 
            this.btnCreateNewPeriod.Location = new System.Drawing.Point(13, 218);
            this.btnCreateNewPeriod.Name = "btnCreateNewPeriod";
            this.btnCreateNewPeriod.Size = new System.Drawing.Size(207, 24);
            this.btnCreateNewPeriod.TabIndex = 11;
            this.btnCreateNewPeriod.Text = "Створити новий період";
            this.btnCreateNewPeriod.ThemeName = "Office2007Silver";
            this.btnCreateNewPeriod.Click += new System.EventHandler(this.btnCreateNewPeriod_Click);
            // 
            // btnSaveDistrib
            // 
            this.btnSaveDistrib.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDistrib.Location = new System.Drawing.Point(906, 228);
            this.btnSaveDistrib.Name = "btnSaveDistrib";
            this.btnSaveDistrib.Size = new System.Drawing.Size(110, 24);
            this.btnSaveDistrib.TabIndex = 12;
            this.btnSaveDistrib.Text = "Зберегти";
            this.btnSaveDistrib.ThemeName = "Office2007Silver";
            this.btnSaveDistrib.Click += new System.EventHandler(this.btnSaveDistrib_Click);
            // 
            // DistributionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 276);
            this.Controls.Add(this.btnSaveDistrib);
            this.Controls.Add(this.btnCreateNewPeriod);
            this.Controls.Add(this.gvDistributionPayment);
            this.Controls.Add(this.gvUserMoneys);
            this.MaximumSize = new System.Drawing.Size(1800, 308);
            this.MinimumSize = new System.Drawing.Size(600, 308);
            this.Name = "DistributionForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(1800, 308);
            this.Text = "Прив\'язка суми платежу до Розрахункових періодів";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.gvUserMoneys.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserMoneys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveDistrib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme;
        private Telerik.WinControls.UI.RadGridView gvUserMoneys;
        private Telerik.WinControls.UI.RadGridView gvDistributionPayment;
        private Telerik.WinControls.UI.RadButton btnCreateNewPeriod;
        private Telerik.WinControls.UI.RadButton btnSaveDistrib;
    }
}
