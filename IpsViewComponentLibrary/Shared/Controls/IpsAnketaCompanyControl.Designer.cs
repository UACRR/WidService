namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class IpsAnketaCompanyControl
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
            this.txtShortName = new Telerik.WinControls.UI.RadTextBox();
            this.anketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblShortName = new Telerik.WinControls.UI.RadLabel();
            this.lblFullName = new Telerik.WinControls.UI.RadLabel();
            this.txtName = new IpsViewComponentLibrary.RadTextBoxAuto();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "ShortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtShortName.Location = new System.Drawing.Point(114, 64);
            this.txtShortName.MaxLength = 254;
            this.txtShortName.Name = "txtShortName";
            // 
            // 
            // 
            this.txtShortName.RootElement.MaxSize = new System.Drawing.Size(0, 0);
            this.txtShortName.Size = new System.Drawing.Size(422, 21);
            this.txtShortName.TabIndex = 1;
            this.txtShortName.ThemeName = "Office2013Light";
            // 
            // anketaCompanyBindingSource
            // 
            this.anketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // lblShortName
            // 
            this.lblShortName.Location = new System.Drawing.Point(2, 65);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(91, 19);
            this.lblShortName.TabIndex = 1;
            this.lblShortName.Text = "Коротка назва:";
            this.lblShortName.ThemeName = "Office2013Light";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(2, 3);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(106, 19);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Юридична назва:";
            this.lblFullName.ThemeName = "Office2013Light";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtName.Location = new System.Drawing.Point(114, 3);
            this.txtName.MaxLength = 254;
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(422, 55);
            this.txtName.TabIndex = 0;
            this.txtName.ThemeName = "Office2013Light";
            this.txtName.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.txtName.Leave += new System.EventHandler(this.TxtName_Leave);
            // 
            // IpsAnketaCompanyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblShortName);
            this.Controls.Add(this.lblFullName);
            this.MaximumSize = new System.Drawing.Size(800, 86);
            this.MinimumSize = new System.Drawing.Size(400, 86);
            this.Name = "IpsAnketaCompanyControl";
            this.Size = new System.Drawing.Size(539, 86);
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox txtShortName;
        private RadTextBoxAuto txtName;
        private Telerik.WinControls.UI.RadLabel lblShortName;
        private Telerik.WinControls.UI.RadLabel lblFullName;
        private System.Windows.Forms.BindingSource anketaCompanyBindingSource;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
