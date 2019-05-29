namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class AddressLetter
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPostIndex = new Telerik.WinControls.UI.RadTextBox();
            this.txtAddress = new Telerik.WinControls.UI.RadTextBox();
            this.txtCity = new Telerik.WinControls.UI.RadTextBox();
            this.ddlRegion = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.txtPostIndex, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtAddress, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtCity, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.ddlRegion, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.ddlCountry, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(718, 54);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // txtPostIndex
            // 
            this.txtPostIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPostIndex.Location = new System.Drawing.Point(494, 30);
            this.txtPostIndex.Name = "txtPostIndex";
            this.txtPostIndex.NullText = "Поштовий індекс";
            this.txtPostIndex.Size = new System.Drawing.Size(221, 21);
            this.txtPostIndex.TabIndex = 12;
            this.txtPostIndex.ThemeName = "Office2013Light";
            // 
            // txtAddress
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtAddress, 3);
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(3, 30);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.NullText = "Адреса";
            this.txtAddress.Size = new System.Drawing.Size(465, 21);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.ThemeName = "Office2013Light";
            // 
            // txtCity
            // 
            this.txtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCity.Location = new System.Drawing.Point(494, 3);
            this.txtCity.Name = "txtCity";
            this.txtCity.NullText = "Місто";
            this.txtCity.Size = new System.Drawing.Size(221, 16);
            this.txtCity.TabIndex = 12;
            this.txtCity.ThemeName = "Office2013Light";
            // 
            // ddlRegion
            // 
            this.ddlRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ddlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRegion.Location = new System.Drawing.Point(248, 3);
            this.ddlRegion.Name = "ddlRegion";
            this.ddlRegion.Size = new System.Drawing.Size(220, 16);
            this.ddlRegion.TabIndex = 12;
            this.ddlRegion.ThemeName = "Office2013Light";
            // 
            // ddlCountry
            // 
            this.ddlCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ddlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountry.Location = new System.Drawing.Point(3, 3);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(219, 16);
            this.ddlCountry.TabIndex = 12;
            this.ddlCountry.ThemeName = "Office2013Light";
            // 
            // AddressLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "AddressLetter";
            this.Size = new System.Drawing.Size(718, 54);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Telerik.WinControls.UI.RadTextBox txtPostIndex;
        private Telerik.WinControls.UI.RadTextBox txtAddress;
        private Telerik.WinControls.UI.RadTextBox txtCity;
        private Telerik.WinControls.UI.RadDropDownList ddlRegion;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
    }
}
