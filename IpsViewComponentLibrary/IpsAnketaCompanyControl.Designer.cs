namespace IpsViewComponentLibrary
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
            this.ddlActivityCode = new Telerik.WinControls.UI.RadDropDownList();
            this.anketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtShortName = new Telerik.WinControls.UI.RadTextBox();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ddlActivityCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlActivityCode
            // 
            this.ddlActivityCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlActivityCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.anketaCompanyBindingSource, "ActivityCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.ddlActivityCode.DropDownHeight = 141;
            this.ddlActivityCode.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlActivityCode.Location = new System.Drawing.Point(159, 60);
            this.ddlActivityCode.Margin = new System.Windows.Forms.Padding(4);
            this.ddlActivityCode.Name = "ddlActivityCode";
            this.ddlActivityCode.Size = new System.Drawing.Size(432, 24);
            this.ddlActivityCode.TabIndex = 5;
            // 
            // anketaCompanyBindingSource
            // 
            this.anketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "ShortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtShortName.Location = new System.Drawing.Point(159, 31);
            this.txtShortName.Margin = new System.Windows.Forms.Padding(4);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(432, 24);
            this.txtShortName.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtName.Location = new System.Drawing.Point(159, 1);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(432, 24);
            this.txtName.TabIndex = 1;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 63);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(97, 18);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Сфера діяльності:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 33);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(83, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Коротка назва:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 4);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(79, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Назва клієнту:";
            // 
            // IpsAnketaCompanyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlActivityCode);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1200, 87);
            this.Name = "IpsAnketaCompanyControl";
            this.Size = new System.Drawing.Size(595, 87);
            ((System.ComponentModel.ISupportInitialize)(this.ddlActivityCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anketaCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList ddlActivityCode;
        private Telerik.WinControls.UI.RadTextBox txtShortName;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.BindingSource anketaCompanyBindingSource;
    }
}
