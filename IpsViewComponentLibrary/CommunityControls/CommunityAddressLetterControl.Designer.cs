namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityAddressLetterControl
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
            this.txtCity = new Telerik.WinControls.UI.RadTextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPostIndex = new Telerik.WinControls.UI.RadTextBox();
            this.txtAddress = new Telerik.WinControls.UI.RadTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCity
            // 
            this.txtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCity.Location = new System.Drawing.Point(233, 0);
            this.txtCity.Margin = new System.Windows.Forms.Padding(0);
            this.txtCity.Name = "txtCity";
            this.txtCity.NullText = "Місто";
            this.txtCity.Size = new System.Drawing.Size(397, 20);
            this.txtCity.TabIndex = 2;
            this.txtCity.ThemeName = "Office2013Light";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel.Controls.Add(this.txtCity, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.ddlCountry, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(630, 25);
            this.tableLayoutPanel.TabIndex = 8;
            // 
            // ddlCountry
            // 
            this.ddlCountry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ddlCountry.DropDownMaxSize = new System.Drawing.Size(200, 300);
            this.ddlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountry.Location = new System.Drawing.Point(0, 0);
            this.ddlCountry.Margin = new System.Windows.Forms.Padding(0);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(213, 20);
            this.ddlCountry.TabIndex = 0;
            this.ddlCountry.ThemeName = "Office2013Light";
            // 
            // txtPostIndex
            // 
            this.txtPostIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPostIndex.Location = new System.Drawing.Point(447, 1);
            this.txtPostIndex.Margin = new System.Windows.Forms.Padding(0);
            this.txtPostIndex.Name = "txtPostIndex";
            this.txtPostIndex.NullText = "Поштовий індекс";
            this.txtPostIndex.Size = new System.Drawing.Size(183, 21);
            this.txtPostIndex.TabIndex = 4;
            this.txtPostIndex.ThemeName = "Office2013Light";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(0, 1);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.NullText = "Адреса";
            // 
            // 
            // 
            this.txtAddress.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.txtAddress.Size = new System.Drawing.Size(427, 21);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.ThemeName = "Office2013Light";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.txtAddress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPostIndex, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 23);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // CommunityAddressLetterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "CommunityAddressLetterControl";
            this.Size = new System.Drawing.Size(630, 48);
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox txtCity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
        private Telerik.WinControls.UI.RadTextBox txtPostIndex;
        private Telerik.WinControls.UI.RadTextBox txtAddress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource bsAnketaCompany;
    }
}
