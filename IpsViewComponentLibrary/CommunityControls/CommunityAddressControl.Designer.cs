namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityAddressControl
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.txtAddress = new Telerik.WinControls.UI.RadTextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtCity = new Telerik.WinControls.UI.RadTextBox();
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            this.SuspendLayout();
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
            this.ddlCountry.NullText = "Країна";
            this.ddlCountry.Size = new System.Drawing.Size(201, 20);
            this.ddlCountry.TabIndex = 0;
            this.ddlCountry.ThemeName = "Office2013Light";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.txtAddress, 3);
            this.txtAddress.Location = new System.Drawing.Point(0, 25);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.NullText = "Адреса";
            this.txtAddress.Size = new System.Drawing.Size(596, 21);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.ThemeName = "Office2013Light";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel.Controls.Add(this.txtAddress, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.ddlCountry, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtCity, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(596, 48);
            this.tableLayoutPanel.TabIndex = 7;
            // 
            // txtCity
            // 
            this.txtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCity.Location = new System.Drawing.Point(221, 0);
            this.txtCity.Margin = new System.Windows.Forms.Padding(0);
            this.txtCity.Name = "txtCity";
            this.txtCity.NullText = "Місто";
            this.txtCity.Size = new System.Drawing.Size(375, 20);
            this.txtCity.TabIndex = 2;
            this.txtCity.ThemeName = "Office2013Light";
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // CommunityAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "CommunityAddressControl";
            this.Size = new System.Drawing.Size(596, 48);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
        private Telerik.WinControls.UI.RadTextBox txtAddress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Telerik.WinControls.UI.RadTextBox txtCity;
        private System.Windows.Forms.BindingSource bsAnketaCompany;
    }
}
