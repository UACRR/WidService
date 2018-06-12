namespace IpsViewComponentLibrary
{
    partial class GlobalControlConsumerCabinet
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.mсInfoAgrCalc = new IpsViewComponentLibrary.MiddleControlInfoAgrCalc();
            this.gvConsumerList = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // mсInfoAgrCalc
            // 
            this.mсInfoAgrCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mсInfoAgrCalc.AutoScroll = true;
            this.mсInfoAgrCalc.Location = new System.Drawing.Point(315, 3);
            this.mсInfoAgrCalc.Name = "mсInfoAgrCalc";
            this.mсInfoAgrCalc.Size = new System.Drawing.Size(1096, 628);
            this.mсInfoAgrCalc.TabIndex = 0;
            // 
            // gvConsumerList
            // 
            this.gvConsumerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gvConsumerList.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.gvConsumerList.MasterTemplate.AllowAddNewRow = false;
            this.gvConsumerList.MasterTemplate.AllowDeleteRow = false;
            this.gvConsumerList.MasterTemplate.AllowDragToGroup = false;
            this.gvConsumerList.MasterTemplate.AllowEditRow = false;
            this.gvConsumerList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "innokpo";
            gridViewTextBoxColumn1.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn1.Name = "Innokpo";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 85;
            gridViewTextBoxColumn2.FieldName = "name";
            gridViewTextBoxColumn2.HeaderText = "Назва";
            gridViewTextBoxColumn2.Multiline = true;
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 201;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.DataType = typeof(int);
            gridViewTextBoxColumn3.FieldName = "countAgree";
            gridViewTextBoxColumn3.HeaderText = "К-сть діючих договорів";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "CountAgree";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 19;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(double);
            gridViewTextBoxColumn4.FieldName = "undistribamount";
            gridViewTextBoxColumn4.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "Undistribamount";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 24;
            gridViewTextBoxColumn4.WrapText = true;
            gridViewTextBoxColumn5.DataType = typeof(int);
            gridViewTextBoxColumn5.FieldName = "CustId";
            gridViewTextBoxColumn5.HeaderText = "ID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "CustId";
            gridViewTextBoxColumn5.Width = 42;
            this.gvConsumerList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvConsumerList.MasterTemplate.EnableGrouping = false;
            this.gvConsumerList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvConsumerList.Name = "gvConsumerList";
            this.gvConsumerList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvConsumerList.ReadOnly = true;
            this.gvConsumerList.Size = new System.Drawing.Size(306, 628);
            this.gvConsumerList.TabIndex = 4;
            this.gvConsumerList.ThemeName = "Office2007Silver";
            this.gvConsumerList.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.gvConsumerList_CurrentRowChanged);
            // 
            // GlobalControlConsumerCabinet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvConsumerList);
            this.Controls.Add(this.mсInfoAgrCalc);
            this.Name = "GlobalControlConsumerCabinet";
            this.Size = new System.Drawing.Size(1414, 634);
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsumerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MiddleControlInfoAgrCalc mсInfoAgrCalc;
        private Telerik.WinControls.UI.RadGridView gvConsumerList;
    }
}
