namespace IpsViewComponentLibrary
{
    partial class AddressLetterControl
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
            this.anketaDictionatiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtCity = new Telerik.WinControls.UI.RadTextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ddlRegion = new Telerik.WinControls.UI.RadDropDownList();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.txtAddress = new Telerik.WinControls.UI.RadTextBox();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox3 = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.anketaDictionatiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            this.txtAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            this.radTextBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // anketaDictionatiesBindingSource
            // 
            this.anketaDictionatiesBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.AnketaDictionaties);
            // 
            // txtCity
            // 
            this.tableLayoutPanel.SetColumnSpan(this.txtCity, 3);
            this.txtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCity.Location = new System.Drawing.Point(412, 0);
            this.txtCity.Margin = new System.Windows.Forms.Padding(0);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(188, 20);
            this.txtCity.TabIndex = 2;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 7;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.50152F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.50152F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.91733F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.07963F));
            this.tableLayoutPanel.Controls.Add(this.radTextBox2, 6, 2);
            this.tableLayoutPanel.Controls.Add(this.ddlCountry, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtAddress, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.ddlRegion, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.txtCity, 4, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(600, 45);
            this.tableLayoutPanel.TabIndex = 7;
            // 
            // ddlRegion
            // 
            this.ddlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ddlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRegion.Location = new System.Drawing.Point(206, 0);
            this.ddlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.ddlRegion.Name = "ddlRegion";
            this.ddlRegion.Size = new System.Drawing.Size(186, 20);
            this.ddlRegion.TabIndex = 1;
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.Location = new System.Drawing.Point(576, 0);
            this.radTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(505, 20);
            this.radTextBox1.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.txtAddress, 5);
            this.txtAddress.Controls.Add(this.radTextBox1);
            this.txtAddress.Location = new System.Drawing.Point(0, 25);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(524, 20);
            this.txtAddress.TabIndex = 11;
            // 
            // ddlCountry
            // 
            this.ddlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ddlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountry.Location = new System.Drawing.Point(0, 0);
            this.ddlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(186, 20);
            this.ddlCountry.TabIndex = 0;
            // 
            // radTextBox2
            // 
            this.radTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox2.Controls.Add(this.radTextBox3);
            this.radTextBox2.Location = new System.Drawing.Point(544, 25);
            this.radTextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(56, 20);
            this.radTextBox2.TabIndex = 13;
            // 
            // radTextBox3
            // 
            this.radTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox3.Location = new System.Drawing.Point(576, 0);
            this.radTextBox3.Margin = new System.Windows.Forms.Padding(0);
            this.radTextBox3.Name = "radTextBox3";
            this.radTextBox3.Size = new System.Drawing.Size(37, 20);
            this.radTextBox3.TabIndex = 4;
            // 
            // AddressLetterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(1200, 45);
            this.Name = "AddressLetterControl";
            this.Size = new System.Drawing.Size(600, 45);
            ((System.ComponentModel.ISupportInitialize)(this.anketaDictionatiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            this.txtAddress.ResumeLayout(false);
            this.txtAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            this.radTextBox2.ResumeLayout(false);
            this.radTextBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource anketaDictionatiesBindingSource;
        private Telerik.WinControls.UI.RadTextBox txtCity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadTextBox radTextBox3;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
        private Telerik.WinControls.UI.RadTextBox txtAddress;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadDropDownList ddlRegion;
    }
}
