namespace IpsViewComponentLibrary._trash
{
    partial class FormTestDataSource
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.controlWithDataSource1 = new IpsViewComponentLibrary._trash.ControlWithDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // controlWithDataSource1
            // 
            this.controlWithDataSource1.DataBindings.Add(new System.Windows.Forms.Binding("DisplayMember", this.bindingSource1, "ShortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.controlWithDataSource1.DataBindings.Add(new System.Windows.Forms.Binding("selectedCountry", this.bindingSource1, "JaCountry", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "804"));
            this.controlWithDataSource1.DataMember = "";
            this.controlWithDataSource1.DataSource = this.bindingSource1;
            this.controlWithDataSource1.DisplayMember = "";
            this.controlWithDataSource1.Location = new System.Drawing.Point(12, 12);
            this.controlWithDataSource1.Name = "controlWithDataSource1";
            this.controlWithDataSource1.selectedCountry = null;
            this.controlWithDataSource1.Size = new System.Drawing.Size(472, 150);
            this.controlWithDataSource1.TabIndex = 0;
            // 
            // FormTestDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 184);
            this.Controls.Add(this.controlWithDataSource1);
            this.Name = "FormTestDataSource";
            this.Text = "FormTestDataSource";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlWithDataSource controlWithDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}