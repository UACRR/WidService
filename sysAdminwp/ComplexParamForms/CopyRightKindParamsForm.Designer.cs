namespace sysAdminwp.ComplexParamForms
{
    partial class CopyRightKindParamsForm
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
            this.lbCrkindGroup = new Telerik.WinControls.UI.RadLabel();
            this.ddlCrkindGroup = new Telerik.WinControls.UI.RadDropDownList();
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lbCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCrkindGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCrkindGroup
            // 
            this.lbCrkindGroup.Location = new System.Drawing.Point(12, 35);
            this.lbCrkindGroup.Name = "lbCrkindGroup";
            this.lbCrkindGroup.Size = new System.Drawing.Size(117, 18);
            this.lbCrkindGroup.TabIndex = 4;
            this.lbCrkindGroup.Text = "Спосіб використання";
            // 
            // ddlCrkindGroup
            // 
            this.ddlCrkindGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCrkindGroup.DataSource = this.dictBaseTypeIBindingSource;
            this.ddlCrkindGroup.DisplayMember = "Name";
            this.ddlCrkindGroup.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlCrkindGroup.FormattingEnabled = false;
            this.ddlCrkindGroup.Location = new System.Drawing.Point(135, 32);
            this.ddlCrkindGroup.Name = "ddlCrkindGroup";
            this.ddlCrkindGroup.Size = new System.Drawing.Size(336, 21);
            this.ddlCrkindGroup.TabIndex = 5;
            this.ddlCrkindGroup.ThemeName = "Office2013Light";
            this.ddlCrkindGroup.ValueMember = "CodeI";
            this.ddlCrkindGroup.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlCrkindGroup_SelectedIndexChanged);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // CopyRightKindParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 270);
            this.Controls.Add(this.ddlCrkindGroup);
            this.Controls.Add(this.lbCrkindGroup);
            this.Name = "CopyRightKindParamsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "CopyRightKind";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.lbCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCrkindGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lbCrkindGroup;
        private Telerik.WinControls.UI.RadDropDownList ddlCrkindGroup;
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
    }
}
