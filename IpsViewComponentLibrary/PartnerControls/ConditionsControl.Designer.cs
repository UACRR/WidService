using System.Windows.Forms;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class ConditionsControl
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
            this.bsAgreementAddPartner = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.txtCourtCompRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.txtNoCourtRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.txtCourtRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtPfMounthRate = new Telerik.WinControls.UI.RadTextBox();
            this.txtPfFirstRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtSrMounthRate = new Telerik.WinControls.UI.RadTextBox();
            this.txtSrFirstRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddPartner)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCourtCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoCourtRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCourtRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPfMounthRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPfFirstRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSrMounthRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSrFirstRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.SuspendLayout();
            // 
            // bsAgreementAddPartner
            // 
            this.bsAgreementAddPartner.DataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.radLabel15);
            this.groupBox5.Controls.Add(this.txtCourtCompRate);
            this.groupBox5.Controls.Add(this.radLabel11);
            this.groupBox5.Location = new System.Drawing.Point(3, 301);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(726, 51);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Винагорода за стягнення компенсації за порушення майнових авторських прав Користу" +
    "вачем в судовому порядку";
            // 
            // radLabel15
            // 
            this.radLabel15.Location = new System.Drawing.Point(324, 24);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(15, 18);
            this.radLabel15.TabIndex = 6;
            this.radLabel15.Text = "%";
            // 
            // txtCourtCompRate
            // 
            this.txtCourtCompRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "CourtCompRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtCourtCompRate.Location = new System.Drawing.Point(264, 21);
            this.txtCourtCompRate.Name = "txtCourtCompRate";
            this.txtCourtCompRate.Size = new System.Drawing.Size(54, 21);
            this.txtCourtCompRate.TabIndex = 3;
            this.txtCourtCompRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCourtCompRate.ThemeName = "Office2013Light";
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(7, 23);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(210, 19);
            this.radLabel11.TabIndex = 1;
            this.radLabel11.Text = "Відсоток від суми платежів процесу";
            this.radLabel11.ThemeName = "Office2013Light";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.radLabel14);
            this.groupBox4.Controls.Add(this.txtNoCourtRate);
            this.groupBox4.Controls.Add(this.radLabel10);
            this.groupBox4.Location = new System.Drawing.Point(3, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(726, 68);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Винагорода за послуги із погашення заборгованості у позасудовому порядку";
            // 
            // radLabel14
            // 
            this.radLabel14.Location = new System.Drawing.Point(324, 25);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(15, 18);
            this.radLabel14.TabIndex = 5;
            this.radLabel14.Text = "%";
            // 
            // txtNoCourtRate
            // 
            this.txtNoCourtRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "NoCourtRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtNoCourtRate.Location = new System.Drawing.Point(264, 23);
            this.txtNoCourtRate.Name = "txtNoCourtRate";
            this.txtNoCourtRate.Size = new System.Drawing.Size(54, 21);
            this.txtNoCourtRate.TabIndex = 3;
            this.txtNoCourtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoCourtRate.ThemeName = "Office2013Light";
            // 
            // radLabel10
            // 
            this.radLabel10.AutoSize = false;
            this.radLabel10.Location = new System.Drawing.Point(7, 23);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(240, 35);
            this.radLabel10.TabIndex = 1;
            this.radLabel10.Text = "Відсоток від суми платежів позасудового процесу";
            this.radLabel10.ThemeName = "Office2013Light";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.radLabel13);
            this.groupBox3.Controls.Add(this.txtCourtRate);
            this.groupBox3.Controls.Add(this.radLabel12);
            this.groupBox3.Location = new System.Drawing.Point(3, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(726, 64);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Винагорода за послуги із погашення заборгованості у судовому порядку";
            // 
            // radLabel13
            // 
            this.radLabel13.Location = new System.Drawing.Point(324, 24);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(15, 18);
            this.radLabel13.TabIndex = 5;
            this.radLabel13.Text = "%";
            // 
            // txtCourtRate
            // 
            this.txtCourtRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "CourtRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtCourtRate.Location = new System.Drawing.Point(264, 22);
            this.txtCourtRate.Name = "txtCourtRate";
            this.txtCourtRate.Size = new System.Drawing.Size(54, 21);
            this.txtCourtRate.TabIndex = 3;
            this.txtCourtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCourtRate.ThemeName = "Office2013Light";
            // 
            // radLabel12
            // 
            this.radLabel12.AutoSize = false;
            this.radLabel12.Location = new System.Drawing.Point(6, 22);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(241, 35);
            this.radLabel12.TabIndex = 2;
            this.radLabel12.Text = "Відсоток від суми платежів судового процесу";
            this.radLabel12.ThemeName = "Office2013Light";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radLabel9);
            this.groupBox2.Controls.Add(this.radLabel3);
            this.groupBox2.Controls.Add(this.txtPfMounthRate);
            this.groupBox2.Controls.Add(this.txtPfFirstRate);
            this.groupBox2.Controls.Add(this.radLabel8);
            this.groupBox2.Controls.Add(this.radLabel7);
            this.groupBox2.Location = new System.Drawing.Point(3, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 53);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "З організаторами концертно-видовищних заходів, гастрольних заходів, театральних т" +
    "а видовищних постановок, антеприз";
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(641, 24);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(15, 18);
            this.radLabel9.TabIndex = 6;
            this.radLabel9.Text = "%";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(324, 24);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(15, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "%";
            // 
            // txtPfMounthRate
            // 
            this.txtPfMounthRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "PfMonthRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtPfMounthRate.Location = new System.Drawing.Point(581, 22);
            this.txtPfMounthRate.Name = "txtPfMounthRate";
            this.txtPfMounthRate.Size = new System.Drawing.Size(54, 21);
            this.txtPfMounthRate.TabIndex = 4;
            this.txtPfMounthRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPfMounthRate.ThemeName = "Office2013Light";
            // 
            // txtPfFirstRate
            // 
            this.txtPfFirstRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "PfFirstRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtPfFirstRate.Location = new System.Drawing.Point(264, 22);
            this.txtPfFirstRate.Name = "txtPfFirstRate";
            this.txtPfFirstRate.Size = new System.Drawing.Size(54, 21);
            this.txtPfFirstRate.TabIndex = 3;
            this.txtPfFirstRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPfFirstRate.ThemeName = "Office2013Light";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(376, 23);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(199, 19);
            this.radLabel8.TabIndex = 2;
            this.radLabel8.Text = "Відсоток від щомісячних платежів";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(7, 22);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(240, 19);
            this.radLabel7.TabIndex = 1;
            this.radLabel7.Text = "Відсоток від одноразово отриманої суми";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Controls.Add(this.txtSrMounthRate);
            this.groupBox1.Controls.Add(this.txtSrFirstRate);
            this.groupBox1.Controls.Add(this.radLabel6);
            this.groupBox1.Controls.Add(this.radLabel5);
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 53);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "З користувачами малих прав";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(641, 23);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(15, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "%";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(324, 23);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(15, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "%";
            // 
            // txtSrMounthRate
            // 
            this.txtSrMounthRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "SrMonthRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtSrMounthRate.Location = new System.Drawing.Point(581, 21);
            this.txtSrMounthRate.Name = "txtSrMounthRate";
            this.txtSrMounthRate.Size = new System.Drawing.Size(54, 21);
            this.txtSrMounthRate.TabIndex = 3;
            this.txtSrMounthRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSrMounthRate.ThemeName = "Office2013Light";
            // 
            // txtSrFirstRate
            // 
            this.txtSrFirstRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementAddPartner, "SrFirstRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtSrFirstRate.Location = new System.Drawing.Point(264, 22);
            this.txtSrFirstRate.Name = "txtSrFirstRate";
            this.txtSrFirstRate.Size = new System.Drawing.Size(54, 21);
            this.txtSrFirstRate.TabIndex = 2;
            this.txtSrFirstRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSrFirstRate.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(390, 22);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(185, 19);
            this.radLabel6.TabIndex = 1;
            this.radLabel6.Text = "Відсоток від місячного платежу";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(7, 23);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(238, 19);
            this.radLabel5.TabIndex = 0;
            this.radLabel5.Text = "Відсоток від першого місячного платежу";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel4.Location = new System.Drawing.Point(174, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(284, 30);
            this.radLabel4.TabIndex = 45;
            this.radLabel4.Text = "Умови за укладення договорів";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // ConditionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radLabel4);
            this.Name = "ConditionsControl";
            this.Size = new System.Drawing.Size(734, 357);
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementAddPartner)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCourtCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoCourtRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCourtRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPfMounthRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPfFirstRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSrMounthRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSrFirstRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsAgreementAddPartner;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.GroupBox groupBox5;
        private Telerik.WinControls.UI.RadTextBox txtCourtCompRate;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private System.Windows.Forms.GroupBox groupBox4;
        private Telerik.WinControls.UI.RadTextBox txtNoCourtRate;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private System.Windows.Forms.GroupBox groupBox3;
        private Telerik.WinControls.UI.RadTextBox txtCourtRate;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadTextBox txtPfMounthRate;
        private Telerik.WinControls.UI.RadTextBox txtPfFirstRate;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadTextBox txtSrMounthRate;
        private Telerik.WinControls.UI.RadTextBox txtSrFirstRate;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
