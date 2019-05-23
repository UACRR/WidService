using System.Windows.Forms;

namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class IpsAnketaCompanyAddControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtBrand = new Telerik.WinControls.UI.RadTextBox();
            this.txtGroup = new Telerik.WinControls.UI.RadTextBox();
            this.bsClient = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClient)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Бренд:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 31);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(42, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Група:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // txtBrand
            // 
            this.txtBrand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBrand.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClient, "ClientBrand", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtBrand.Location = new System.Drawing.Point(53, 3);
            this.txtBrand.MaxLength = 100;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(350, 21);
            this.txtBrand.TabIndex = 2;
            this.txtBrand.ThemeName = "Office2013Light";
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClient, "ClientGroup", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.txtGroup.Location = new System.Drawing.Point(53, 30);
            this.txtGroup.MaxLength = 100;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(350, 21);
            this.txtGroup.TabIndex = 3;
            this.txtGroup.ThemeName = "Office2013Light";
            // 
            // bsClient
            // 
            this.bsClient.DataSource = typeof(ipsFormsDesign.Model.Client);
            // 
            // IpsAnketaCompanyAddControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(1000, 54);
            this.MinimumSize = new System.Drawing.Size(100, 54);
            this.Name = "IpsAnketaCompanyAddControl";
            this.Size = new System.Drawing.Size(406, 54);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtBrand;
        private Telerik.WinControls.UI.RadTextBox txtGroup;
        private System.Windows.Forms.BindingSource bsClient;
    }
}
