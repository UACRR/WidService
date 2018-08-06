using System.Drawing;

namespace IpsViewComponentLibrary
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
            this.components = new System.ComponentModel.Container();
            this.ddlRegion = new Telerik.WinControls.UI.RadDropDownList();
            this.txtCity = new Telerik.WinControls.UI.RadTextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPostIndex = new Telerik.WinControls.UI.RadTextBox();
            this.txtAddress = new Telerik.WinControls.UI.RadTextBox();
            this.anketaDictionatiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaDictionatiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlRegion
            // 
            this.ddlRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlRegion.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ddlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRegion.Location = new System.Drawing.Point(240, 0);
            this.ddlRegion.Margin = new System.Windows.Forms.Padding(0);
            this.ddlRegion.Name = "ddlRegion";
            this.ddlRegion.Size = new System.Drawing.Size(220, 21);
            this.ddlRegion.TabIndex = 1;
            this.ddlRegion.ThemeName = "Office2013Light";
            // 
            // txtCity
            // 
            this.txtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCity.Location = new System.Drawing.Point(480, 0);
            this.txtCity.Margin = new System.Windows.Forms.Padding(0);
            this.txtCity.Name = "txtCity";
            this.txtCity.NullText = "Місто";
            this.txtCity.Size = new System.Drawing.Size(220, 21);
            this.txtCity.TabIndex = 2;
            this.txtCity.ThemeName = "Office2013Light";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33457F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33345F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33197F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.ddlCountry, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.ddlRegion, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.txtCity, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.txtPostIndex, 4, 2);
            this.tableLayoutPanel.Controls.Add(this.txtAddress, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(700, 45);
            this.tableLayoutPanel.TabIndex = 7;
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
            this.ddlCountry.Size = new System.Drawing.Size(220, 21);
            this.ddlCountry.TabIndex = 0;
            this.ddlCountry.ThemeName = "Office2013Light";
            // 
            // txtPostIndex
            // 
            this.txtPostIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostIndex.Location = new System.Drawing.Point(480, 25);
            this.txtPostIndex.Margin = new System.Windows.Forms.Padding(0);
            this.txtPostIndex.Name = "txtPostIndex";
            this.txtPostIndex.NullText = "Поштовий індекс";
            this.txtPostIndex.Size = new System.Drawing.Size(220, 21);
            this.txtPostIndex.TabIndex = 4;
            this.txtPostIndex.ThemeName = "Office2013Light";
            // 
            // txtAddress
            // 
            this.tableLayoutPanel.SetColumnSpan(this.txtAddress, 3);
            this.txtAddress.Location = new System.Drawing.Point(0, 25);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.NullText = "Адреса";
            this.txtAddress.Size = new System.Drawing.Size(460, 21);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.ThemeName = "Office2013Light";
            // 
            // anketaDictionatiesBindingSource
            // 
            this.anketaDictionatiesBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.AnketaDictionaties);
            // 
            // AddressLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(700, 45);
            this.MinimumSize = new System.Drawing.Size(700, 45);
            this.Name = "AddressLetter";
            this.Size = new System.Drawing.Size(700, 45);
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaDictionatiesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlRegion;
        private Telerik.WinControls.UI.RadTextBox txtCity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
        private System.Windows.Forms.BindingSource anketaDictionatiesBindingSource;
        private Telerik.WinControls.UI.RadTextBox txtPostIndex;
        private Telerik.WinControls.UI.RadTextBox txtAddress;
    }
}
