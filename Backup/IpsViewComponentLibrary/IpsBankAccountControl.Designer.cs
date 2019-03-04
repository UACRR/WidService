using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    partial class IpsBankAccountControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtAccountNumber = new Telerik.WinControls.UI.RadTextBox();
            this.bsBankAccount = new System.Windows.Forms.BindingSource(this.components);
            this.txtTransitNumber = new Telerik.WinControls.UI.RadTextBox();
            this.txtMfoOkpo = new Telerik.WinControls.UI.RadTextBox();
            this.txtMfo = new Telerik.WinControls.UI.RadTextBox();
            this.txtMfoName = new Telerik.WinControls.UI.RadTextBox();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransitNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMfoOkpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMfoName)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(76, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Назва банку";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(4, 29);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(36, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "МФО";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(4, 54);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(55, 19);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "ЄДРПОУ";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(4, 79);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(158, 19);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Транзитний рахунок банку";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(4, 104);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(142, 19);
            this.radLabel5.TabIndex = 4;
            this.radLabel5.Text = "Розрахунковий рахунок";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBankAccount, "AccountNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtAccountNumber.Location = new System.Drawing.Point(168, 103);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(261, 21);
            this.txtAccountNumber.TabIndex = 4;
            this.txtAccountNumber.ThemeName = "Office2013Light";
            // 
            // bsBankAccount
            // 
            this.bsBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            // 
            // txtTransitNumber
            // 
            this.txtTransitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransitNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBankAccount, "TransitNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtTransitNumber.Location = new System.Drawing.Point(168, 78);
            this.txtTransitNumber.Name = "txtTransitNumber";
            this.txtTransitNumber.Size = new System.Drawing.Size(261, 21);
            this.txtTransitNumber.TabIndex = 3;
            this.txtTransitNumber.ThemeName = "Office2013Light";
            // 
            // txtMfoOkpo
            // 
            this.txtMfoOkpo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMfoOkpo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBankAccount, "MfoOkpo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtMfoOkpo.Location = new System.Drawing.Point(168, 53);
            this.txtMfoOkpo.MaxLength = 10;
            this.txtMfoOkpo.Name = "txtMfoOkpo";
            this.txtMfoOkpo.Size = new System.Drawing.Size(261, 21);
            this.txtMfoOkpo.TabIndex = 2;
            this.txtMfoOkpo.ThemeName = "Office2013Light";
            this.txtMfoOkpo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtMfo
            // 
            this.txtMfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMfo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBankAccount, "Mfo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, default(int)));
            this.txtMfo.Location = new System.Drawing.Point(168, 28);
            this.txtMfo.MaxLength = 6;
            this.txtMfo.Name = "txtMfo";
            this.txtMfo.Size = new System.Drawing.Size(261, 21);
            this.txtMfo.TabIndex = 1;
            this.txtMfo.ThemeName = "Office2013Light";
            this.txtMfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtMfoName
            // 
            this.txtMfoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMfoName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBankAccount, "MfoName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtMfoName.Location = new System.Drawing.Point(168, 3);
            this.txtMfoName.Name = "txtMfoName";
            this.txtMfoName.Size = new System.Drawing.Size(261, 21);
            this.txtMfoName.TabIndex = 0;
            this.txtMfoName.ThemeName = "Office2013Light";
            // 
            // IpsBankAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMfoName);
            this.Controls.Add(this.txtMfo);
            this.Controls.Add(this.txtMfoOkpo);
            this.Controls.Add(this.txtTransitNumber);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "IpsBankAccountControl";
            this.Size = new System.Drawing.Size(434, 127);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransitNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMfoOkpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMfoName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtAccountNumber;
        private Telerik.WinControls.UI.RadTextBox txtMfoOkpo;
        private Telerik.WinControls.UI.RadTextBox txtTransitNumber;
        private Telerik.WinControls.UI.RadTextBox txtMfo;
        private Telerik.WinControls.UI.RadTextBox txtMfoName;
        private System.Windows.Forms.BindingSource bsBankAccount;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
