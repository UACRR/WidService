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
            this.BankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtTransitNumber = new Telerik.WinControls.UI.RadTextBox();
            this.txtMfoOkpo = new Telerik.WinControls.UI.RadTextBox();
            this.txtMfo = new Telerik.WinControls.UI.RadTextBox();
            this.txtMfoName = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankAccountBindingSource)).BeginInit();
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
            this.radLabel1.Size = new System.Drawing.Size(70, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Назва банку";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(4, 29);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "МФО";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(4, 54);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(50, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "ЄДРПОУ";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(4, 79);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(81, 18);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Рахунок банку";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(4, 104);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(108, 18);
            this.radLabel5.TabIndex = 4;
            this.radLabel5.Text = "Особистий рахунок";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountBindingSource, "AccountNumber", true));
            this.txtAccountNumber.Location = new System.Drawing.Point(118, 103);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(286, 20);
            this.txtAccountNumber.TabIndex = 4;
            // 
            // BankAccountBindingSource
            // 
            this.BankAccountBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IBankAccount);
            // 
            // txtTransitNumber
            // 
            this.txtTransitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransitNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountBindingSource, "TransitNumber", true));
            this.txtTransitNumber.Location = new System.Drawing.Point(118, 78);
            this.txtTransitNumber.Name = "txtTransitNumber";
            this.txtTransitNumber.Size = new System.Drawing.Size(286, 20);
            this.txtTransitNumber.TabIndex = 3;
            // 
            // txtMfoOkpo
            // 
            this.txtMfoOkpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMfoOkpo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountBindingSource, "MfoOkpo", true));
            this.txtMfoOkpo.Location = new System.Drawing.Point(118, 53);
            this.txtMfoOkpo.MaxLength = 10;
            this.txtMfoOkpo.Name = "txtMfoOkpo";
            this.txtMfoOkpo.Size = new System.Drawing.Size(286, 20);
            this.txtMfoOkpo.TabIndex = 2;
            this.txtMfoOkpo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMfoOkpo_KeyPress);
            // 
            // txtMfo
            // 
            this.txtMfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMfo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountBindingSource, "Mfo", true));
            this.txtMfo.Location = new System.Drawing.Point(118, 28);
            this.txtMfo.MaxLength = 6;
            this.txtMfo.Name = "txtMfo";
            this.txtMfo.Size = new System.Drawing.Size(286, 20);
            this.txtMfo.TabIndex = 1;
            this.txtMfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMfo_KeyPress);
            // 
            // txtMfoName
            // 
            this.txtMfoName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMfoName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BankAccountBindingSource, "MfoName", true));
            this.txtMfoName.Location = new System.Drawing.Point(118, 3);
            this.txtMfoName.Name = "txtMfoName";
            this.txtMfoName.Size = new System.Drawing.Size(286, 20);
            this.txtMfoName.TabIndex = 0;
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
            this.Size = new System.Drawing.Size(409, 127);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankAccountBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource BankAccountBindingSource;
    }
}
