namespace sysAdminwp.ComplexParamForms
{
    partial class KLR030Params
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
            this.lbKlr = new System.Windows.Forms.Label();
            this.ddlCountry = new Telerik.WinControls.UI.RadDropDownList();
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbKlr
            // 
            this.lbKlr.AutoSize = true;
            this.lbKlr.Location = new System.Drawing.Point(12, 9);
            this.lbKlr.Name = "lbKlr";
            this.lbKlr.Size = new System.Drawing.Size(37, 13);
            this.lbKlr.TabIndex = 1;
            this.lbKlr.Text = "Місто";
            // 
            // ddlCountry
            // 
            this.ddlCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCountry.DataSource = this.dictBaseTypeIBindingSource;
            this.ddlCountry.DisplayMember = "Name";
            this.ddlCountry.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCountry.FormattingEnabled = false;
            this.ddlCountry.Location = new System.Drawing.Point(55, 7);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(476, 21);
            this.ddlCountry.TabIndex = 2;
            this.ddlCountry.ThemeName = "Office2013Light";
            this.ddlCountry.ValueMember = "CodeI";
            this.ddlCountry.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCountry_SelectedIndexChanged);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // KLR030Params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 270);
            this.Controls.Add(this.ddlCountry);
            this.Controls.Add(this.lbKlr);
            this.Name = "KLR030Params";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "KLR030Params";
            ((System.ComponentModel.ISupportInitialize)(this.ddlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbKlr;
        private Telerik.WinControls.UI.RadDropDownList ddlCountry;
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
    }
}
