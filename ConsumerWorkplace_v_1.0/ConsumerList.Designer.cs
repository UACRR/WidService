namespace ConsumerWorkplace_v_1._0
{
    partial class ConsumerList
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radDropDownButton1 = new Telerik.WinControls.UI.RadDropDownButton();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.bindingSourceConsumerList = new System.Windows.Forms.BindingSource(this.components);
            this.custIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.innokpoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countAgreeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.undistribamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceConsumerList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.custIdDataGridViewTextBoxColumn,
            this.innokpoDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.countAgreeDataGridViewTextBoxColumn,
            this.undistribamountDataGridViewTextBoxColumn,
            this.Column1});
            this.dataGridView1.DataSource = this.bindingSourceConsumerList;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(877, 243);
            this.dataGridView1.TabIndex = 0;
            // 
            // radDropDownButton1
            // 
            this.radDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2});
            this.radDropDownButton1.Location = new System.Drawing.Point(3, 249);
            this.radDropDownButton1.Name = "radDropDownButton1";
            this.radDropDownButton1.Size = new System.Drawing.Size(175, 30);
            this.radDropDownButton1.TabIndex = 1;
            this.radDropDownButton1.Text = "Створити нового споживача";
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Юридичну особу";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Фізичну особу";
            // 
            // bindingSourceConsumerList
            // 
            this.bindingSourceConsumerList.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerSmallRightView);
            // 
            // custIdDataGridViewTextBoxColumn
            // 
            this.custIdDataGridViewTextBoxColumn.DataPropertyName = "custId";
            this.custIdDataGridViewTextBoxColumn.FillWeight = 60F;
            this.custIdDataGridViewTextBoxColumn.HeaderText = "custId";
            this.custIdDataGridViewTextBoxColumn.Name = "custIdDataGridViewTextBoxColumn";
            this.custIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.custIdDataGridViewTextBoxColumn.Visible = false;
            this.custIdDataGridViewTextBoxColumn.Width = 60;
            // 
            // innokpoDataGridViewTextBoxColumn
            // 
            this.innokpoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.innokpoDataGridViewTextBoxColumn.DataPropertyName = "innokpo";
            this.innokpoDataGridViewTextBoxColumn.HeaderText = "ОКПО";
            this.innokpoDataGridViewTextBoxColumn.Name = "innokpoDataGridViewTextBoxColumn";
            this.innokpoDataGridViewTextBoxColumn.ReadOnly = true;
            this.innokpoDataGridViewTextBoxColumn.Width = 78;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Назва Споживача";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countAgreeDataGridViewTextBoxColumn
            // 
            this.countAgreeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.countAgreeDataGridViewTextBoxColumn.DataPropertyName = "countAgree";
            this.countAgreeDataGridViewTextBoxColumn.HeaderText = "Кількість Договорів";
            this.countAgreeDataGridViewTextBoxColumn.Name = "countAgreeDataGridViewTextBoxColumn";
            this.countAgreeDataGridViewTextBoxColumn.ReadOnly = true;
            this.countAgreeDataGridViewTextBoxColumn.Width = 150;
            // 
            // undistribamountDataGridViewTextBoxColumn
            // 
            this.undistribamountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.undistribamountDataGridViewTextBoxColumn.DataPropertyName = "undistribamount";
            this.undistribamountDataGridViewTextBoxColumn.HeaderText = "Нерозподілена сума";
            this.undistribamountDataGridViewTextBoxColumn.Name = "undistribamountDataGridViewTextBoxColumn";
            this.undistribamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.undistribamountDataGridViewTextBoxColumn.Width = 157;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Редагувати";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ConsumerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radDropDownButton1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ConsumerList";
            this.Size = new System.Drawing.Size(880, 293);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceConsumerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn custIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn innokpoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countAgreeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn undistribamountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.BindingSource bindingSourceConsumerList;
        private Telerik.WinControls.UI.RadDropDownButton radDropDownButton1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
    }
}
