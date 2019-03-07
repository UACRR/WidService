namespace sysAdminwp.ComplexParamForms
{
    partial class CreativeRoleTypeParamsForm
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlCategory = new Telerik.WinControls.UI.RadDropDownList();
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(60, 19);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "Категорія";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ddlCategory
            // 
            this.ddlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCategory.DataSource = this.dictBaseTypeIBindingSource;
            this.ddlCategory.DisplayMember = "Name";
            this.ddlCategory.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCategory.FormattingEnabled = false;
            this.ddlCategory.Location = new System.Drawing.Point(78, 12);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(421, 21);
            this.ddlCategory.TabIndex = 10;
            this.ddlCategory.ThemeName = "Office2013Light";
            this.ddlCategory.ValueMember = "CodeI";
            this.ddlCategory.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCategory_SelectedIndexChanged);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // CreativeRoleTypeParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 270);
            this.Controls.Add(this.ddlCategory);
            this.Controls.Add(this.radLabel1);
            this.Name = "CreativeRoleTypeParamsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CreativeRoleTypeParams";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList ddlCategory;
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
    }
}
