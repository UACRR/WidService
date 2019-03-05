namespace sysAdminwp.ComplexParamForms
{
    partial class TypePlaceParamsForm
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
            this.lbTypePlace = new System.Windows.Forms.Label();
            this.ddlTypePlace = new Telerik.WinControls.UI.RadDropDownList();
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTypePlace
            // 
            this.lbTypePlace.AutoSize = true;
            this.lbTypePlace.Location = new System.Drawing.Point(12, 9);
            this.lbTypePlace.Name = "lbTypePlace";
            this.lbTypePlace.Size = new System.Drawing.Size(46, 15);
            this.lbTypePlace.TabIndex = 1;
            this.lbTypePlace.Text = "Обьект";
            // 
            // ddlTypePlace
            // 
            this.ddlTypePlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlTypePlace.DataSource = this.dictBaseTypeIBindingSource;
            this.ddlTypePlace.DisplayMember = "Name";
            this.ddlTypePlace.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlTypePlace.FormattingEnabled = false;
            this.ddlTypePlace.Location = new System.Drawing.Point(64, 7);
            this.ddlTypePlace.Name = "ddlTypePlace";
            this.ddlTypePlace.Size = new System.Drawing.Size(478, 21);
            this.ddlTypePlace.TabIndex = 2;
            this.ddlTypePlace.ThemeName = "Office2013Light";
            this.ddlTypePlace.ValueMember = "CodeI";
            this.ddlTypePlace.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlTypePlace_SelectedIndexChanged);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // TypePlaceParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 270);
            this.Controls.Add(this.ddlTypePlace);
            this.Controls.Add(this.lbTypePlace);
            this.Name = "TypePlaceParamsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "TypePlaceParams";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTypePlace;
        private Telerik.WinControls.UI.RadDropDownList ddlTypePlace;
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
    }
}
