namespace sysAdminwp.ComplexParamForms
{
    partial class GenreTypeParamsForm
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
            this.lbCategory = new System.Windows.Forms.Label();
            this.ddlCategory = new Telerik.WinControls.UI.RadDropDownList();
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(12, 9);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(70, 15);
            this.lbCategory.TabIndex = 1;
            this.lbCategory.Text = "Вид об\'єкта";
            // 
            // ddlCategory
            // 
            this.ddlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCategory.DataSource = this.dictBaseTypeIBindingSource;
            this.ddlCategory.DisplayMember = "Name";
            this.ddlCategory.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCategory.FormattingEnabled = false;
            this.ddlCategory.Location = new System.Drawing.Point(87, 7);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(536, 21);
            this.ddlCategory.TabIndex = 2;
            this.ddlCategory.ThemeName = "Office2013Light";
            this.ddlCategory.ValueMember = "CodeI";
            this.ddlCategory.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCategory_SelectedIndexChanged);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // GenreTypeParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 270);
            this.Controls.Add(this.ddlCategory);
            this.Controls.Add(this.lbCategory);
            this.Name = "GenreTypeParamsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "GenreTypeParams";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.ddlCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCategory;
        private Telerik.WinControls.UI.RadDropDownList ddlCategory;
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
    }
}
