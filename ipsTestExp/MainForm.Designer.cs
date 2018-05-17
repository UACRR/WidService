using System.Drawing;
using sysAdminwp;

namespace ipsTestExp
{
    partial class MainForm
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


        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ddl = new Telerik.WinControls.UI.RadDropDownList();
            this.tbShortName = new Telerik.WinControls.UI.RadTextBox();
            this.iAnketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ipsAddressControl1 = new IpsViewComponentLibrary.IpsAddressControl();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(12, 99);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(101, 18);
            this.radLabel4.TabIndex = 10;
            this.radLabel4.Text = "Юридична адреса";
            // 
            // ddl
            // 
            this.ddl.Location = new System.Drawing.Point(129, 58);
            this.ddl.Name = "ddl";
            this.ddl.Size = new System.Drawing.Size(551, 20);
            this.ddl.TabIndex = 13;
            // 
            // tbShortName
            // 
            this.tbShortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaCompanyBindingSource, "ShortName", true));
            this.tbShortName.Location = new System.Drawing.Point(129, 34);
            this.tbShortName.Name = "tbShortName";
            this.tbShortName.Size = new System.Drawing.Size(551, 20);
            this.tbShortName.TabIndex = 12;
            // 
            // iAnketaCompanyBindingSource
            // 
            this.iAnketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            // 
            // tbName
            // 
            this.tbName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaCompanyBindingSource, "Name", true));
            this.tbName.Location = new System.Drawing.Point(129, 10);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(551, 20);
            this.tbName.TabIndex = 11;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 60);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(97, 18);
            this.radLabel3.TabIndex = 9;
            this.radLabel3.Text = "Сфера діяльності:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 36);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(83, 18);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "Коротка назва:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(79, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Назва клієнту:";
            // 
            // ipsAddressControl1
            // 
            this.ipsAddressControl1.Location = new System.Drawing.Point(129, 115);
            this.ipsAddressControl1.Name = "ipsAddressControl1";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radDropDownListCountry.AutoSize = false;
            this.ipsAddressControl1.radDropDownListCountry.DataSource = this.mainFormBindingSource;
            this.ipsAddressControl1.radDropDownListCountry.Location = new System.Drawing.Point(0, 0);
            this.ipsAddressControl1.radDropDownListCountry.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radDropDownListCountry.Name = "ddlCountry";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 186, 20);
            this.ipsAddressControl1.radDropDownListCountry.Size = new System.Drawing.Size(170, 20);
            this.ipsAddressControl1.radDropDownListCountry.TabIndex = 18;
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radDropDownListRegion.AutoSize = false;
            this.ipsAddressControl1.radDropDownListRegion.Location = new System.Drawing.Point(190, 0);
            this.ipsAddressControl1.radDropDownListRegion.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radDropDownListRegion.Name = "ddlRegion";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(206, 0, 186, 20);
            this.ipsAddressControl1.radDropDownListRegion.Size = new System.Drawing.Size(170, 20);
            this.ipsAddressControl1.radDropDownListRegion.TabIndex = 22;
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radTextBoxAddress.AutoSize = false;
            this.ipsAddressControl1.radTextBoxAddress.Location = new System.Drawing.Point(0, 25);
            this.ipsAddressControl1.radTextBoxAddress.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radTextBoxAddress.Name = "txtAddress";
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 600, 20);
            this.ipsAddressControl1.radTextBoxAddress.Size = new System.Drawing.Size(551, 20);
            this.ipsAddressControl1.radTextBoxAddress.TabIndex = 10;
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxCity.AutoSize = false;
            this.ipsAddressControl1.radTextBoxCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipsAddressControl1.radTextBoxCity.Location = new System.Drawing.Point(380, 0);
            this.ipsAddressControl1.radTextBoxCity.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radTextBoxCity.Name = "txtCity";
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxCity.RootElement.ControlBounds = new System.Drawing.Rectangle(412, 0, 188, 20);
            this.ipsAddressControl1.radTextBoxCity.Size = new System.Drawing.Size(171, 20);
            this.ipsAddressControl1.radTextBoxCity.TabIndex = 23;
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radTextBoxEmail.AutoSize = false;
            this.ipsAddressControl1.radTextBoxEmail.Location = new System.Drawing.Point(440, 50);
            this.ipsAddressControl1.radTextBoxEmail.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radTextBoxEmail.Name = "txtEmail";
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxEmail.RootElement.ControlBounds = new System.Drawing.Rectangle(472, 50, 128, 0);
            this.ipsAddressControl1.radTextBoxEmail.Size = new System.Drawing.Size(111, 20);
            this.ipsAddressControl1.radTextBoxEmail.TabIndex = 27;
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radTextBoxFax.AutoSize = false;
            this.ipsAddressControl1.radTextBoxFax.Location = new System.Drawing.Point(250, 50);
            this.ipsAddressControl1.radTextBoxFax.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radTextBoxFax.Name = "txtFax";
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxFax.RootElement.ControlBounds = new System.Drawing.Rectangle(266, 50, 126, 0);
            this.ipsAddressControl1.radTextBoxFax.Size = new System.Drawing.Size(110, 20);
            this.ipsAddressControl1.radTextBoxFax.TabIndex = 26;
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radTextBoxPhone.AutoSize = false;
            this.ipsAddressControl1.radTextBoxPhone.Location = new System.Drawing.Point(60, 50);
            this.ipsAddressControl1.radTextBoxPhone.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radTextBoxPhone.Name = "txtPhone";
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxPhone.RootElement.ControlBounds = new System.Drawing.Rectangle(60, 50, 126, 0);
            this.ipsAddressControl1.radTextBoxPhone.Size = new System.Drawing.Size(110, 20);
            this.ipsAddressControl1.radTextBoxPhone.TabIndex = 21;
            this.ipsAddressControl1.Size = new System.Drawing.Size(551, 70);
            this.ipsAddressControl1.TabIndex = 14;
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(ipsTestExp.MainForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 275);
            this.Controls.Add(this.ipsAddressControl1);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.ddl);
            this.Controls.Add(this.tbShortName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "IPS";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeDataChangeControl()
        {

        }
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList ddl;
        private Telerik.WinControls.UI.RadTextBox tbShortName;
        private Telerik.WinControls.UI.RadTextBox tbName;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.BindingSource iAnketaCompanyBindingSource;
        private IpsViewComponentLibrary.IpsAddressControl ipsAddressControl1;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
    }
}

