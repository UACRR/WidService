namespace IpsViewComponentLibrary
{
    partial class IpsBossNameContactsControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtPhone = new Telerik.WinControls.UI.RadTextBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSurName = new Telerik.WinControls.UI.RadTextBox();
            this.txtFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.txtLastName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtEmail = new Telerik.WinControls.UI.RadTextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.txtPhone, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.txtSurName, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.txtFirstName, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.txtLastName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.radLabel2, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.radLabel3, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.txtEmail, 5, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(600, 56);
            this.tableLayoutPanel.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "PhoneNumber", true));
            this.txtPhone.Location = new System.Drawing.Point(33, 35);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.txtPhone.MaxLength = 13;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(173, 21);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "+380";
            this.txtPhone.ThemeName = "Office2013Light";
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IEmployee);
            // 
            // txtSurName
            // 
            this.txtSurName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSurName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "SurName", true));
            this.txtSurName.Location = new System.Drawing.Point(425, 3);
            this.txtSurName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.NullText = "По батькові";
            this.txtSurName.Size = new System.Drawing.Size(175, 21);
            this.txtSurName.TabIndex = 2;
            this.txtSurName.ThemeName = "Office2013Light";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "FirstName", true));
            this.txtFirstName.Location = new System.Drawing.Point(229, 3);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.NullText = "Ім\'я";
            this.txtFirstName.Size = new System.Drawing.Size(173, 21);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.ThemeName = "Office2013Light";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "LastName", true));
            this.txtLastName.Location = new System.Drawing.Point(33, 3);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.NullText = "Прізвище";
            this.txtLastName.Size = new System.Drawing.Size(173, 21);
            this.txtLastName.TabIndex = 0;
            this.txtLastName.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(24, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "ПІБ:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radLabel2.Location = new System.Drawing.Point(3, 34);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(24, 19);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Тел.:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radLabel3.AutoSize = false;
            this.radLabel3.Location = new System.Drawing.Point(283, 33);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(116, 22);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Електронна пошта:";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Email", true));
            this.txtEmail.Location = new System.Drawing.Point(425, 35);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.NullText = "#####@####.##";
            this.txtEmail.Size = new System.Drawing.Size(175, 21);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.ThemeName = "Office2013Light";
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // IpsBossNameContactsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "IpsBossNameContactsControl";
            this.Size = new System.Drawing.Size(600, 56);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Telerik.WinControls.UI.RadTextBox txtLastName;
        private Telerik.WinControls.UI.RadTextBox txtFirstName;
        private Telerik.WinControls.UI.RadTextBox txtSurName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtPhone;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtEmail;
        private System.Windows.Forms.BindingSource employeeBindingSource;
    }
}
