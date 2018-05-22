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
            this.ddlActivityCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.anketaCompanyBindingSource, "ActivityCode", true));
            this.ddlActivityCode.Location = new System.Drawing.Point(119, 49);
            this.ddlActivityCode.Name = "ddlActivityCode";
            this.ddlActivityCode.Size = new System.Drawing.Size(324, 20);
            this.ddlActivityCode.TabIndex = 11;
            // 
            // anketaCompanyBindingSource
            // 
            this.anketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            // 
            // txtShortName
            // 
            this.txtShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "ShortName", true));
            this.txtShortName.Location = new System.Drawing.Point(119, 25);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(324, 20);
            this.txtShortName.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.anketaCompanyBindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(119, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 20);
            this.txtName.TabIndex = 9;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(2, 51);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(97, 18);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Сфера діяльності:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(2, 27);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(83, 18);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Коротка назва:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(2, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(79, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Назва клієнту:";
            // 
            // IpsAnketaCompanyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlActivityCode);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(900, 71);
            this.Name = "IpsAnketaCompanyControl";
            this.Size = new System.Drawing.Size(446, 71);
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
