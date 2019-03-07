namespace sysAdminwp.ComplexParamForms
{
    partial class CountryParamsForm
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
            this.lbContinent = new Telerik.WinControls.UI.RadLabel();
            this.ddlContinent = new Telerik.WinControls.UI.RadDropDownList();
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbContinent
            // 
            this.lbContinent.Location = new System.Drawing.Point(12, 21);
            this.lbContinent.Name = "lbContinent";
            this.lbContinent.Size = new System.Drawing.Size(61, 18);
            this.lbContinent.TabIndex = 2;
            this.lbContinent.Text = "Континент";
            // 
            // ddlContinent
            // 
            this.ddlContinent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlContinent.DataSource = this.dictBaseTypeIBindingSource;
            this.ddlContinent.DisplayMember = "Name";
            this.ddlContinent.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlContinent.FormattingEnabled = false;
            this.ddlContinent.Location = new System.Drawing.Point(79, 21);
            this.ddlContinent.Name = "ddlContinent";
            this.ddlContinent.Size = new System.Drawing.Size(432, 21);
            this.ddlContinent.TabIndex = 3;
            this.ddlContinent.ThemeName = "Office2013Light";
            this.ddlContinent.ValueMember = "CodeI";
            this.ddlContinent.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlContinent_SelectedIndexChanged);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // CountryParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 270);
            this.Controls.Add(this.ddlContinent);
            this.Controls.Add(this.lbContinent);
            this.Name = "CountryParamsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CountryParams";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.lbContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lbContinent;
        private Telerik.WinControls.UI.RadDropDownList ddlContinent;
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
    }
}
