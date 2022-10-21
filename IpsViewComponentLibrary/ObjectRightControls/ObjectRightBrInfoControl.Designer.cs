namespace IpsViewComponentLibrary.ObjectRightControls
{
    partial class ObjectRightBrInfoControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlGenreType = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.mtxtActCode = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.mtxtRate = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ddlLangCode = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.licenseBigRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.objectRightBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGenreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtActCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLangCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseBigRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(88, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Назва вистави";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objectRightBindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(118, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(348, 21);
            this.txtName.TabIndex = 1;
            this.txtName.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(3, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(63, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Вид твору";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // ddlGenreType
            // 
            this.ddlGenreType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlGenreType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.objectRightBindingSource, "GenreType", true));
            this.ddlGenreType.Location = new System.Drawing.Point(118, 30);
            this.ddlGenreType.Name = "ddlGenreType";
            this.ddlGenreType.Size = new System.Drawing.Size(348, 21);
            this.ddlGenreType.TabIndex = 2;
            this.ddlGenreType.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 58);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(86, 19);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "Кількість актів";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // mtxtActCode
            // 
            this.mtxtActCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objectRightBindingSource, "ActCode", true));
            this.mtxtActCode.Location = new System.Drawing.Point(118, 57);
            this.mtxtActCode.Mask = "N0";
            this.mtxtActCode.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mtxtActCode.Name = "mtxtActCode";
            this.mtxtActCode.PromptChar = '0';
            this.mtxtActCode.Size = new System.Drawing.Size(69, 21);
            this.mtxtActCode.TabIndex = 6;
            this.mtxtActCode.TabStop = false;
            this.mtxtActCode.Text = "0";
            this.mtxtActCode.ThemeName = "Office2013Light";
            // 
            // mtxtRate
            // 
            this.mtxtRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.licenseBigRBindingSource, "Rate", true));
            this.mtxtRate.Location = new System.Drawing.Point(397, 57);
            this.mtxtRate.Mask = "N2";
            this.mtxtRate.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mtxtRate.Name = "mtxtRate";
            this.mtxtRate.PromptChar = '0';
            this.mtxtRate.Size = new System.Drawing.Size(69, 21);
            this.mtxtRate.TabIndex = 8;
            this.mtxtRate.TabStop = false;
            this.mtxtRate.Text = "0,00";
            this.mtxtRate.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(209, 59);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(182, 19);
            this.radLabel4.TabIndex = 7;
            this.radLabel4.Text = "Мінімальна ставка винагороди";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // ddlLangCode
            // 
            this.ddlLangCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlLangCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.licenseBigRBindingSource, "LangCode", true));
            this.ddlLangCode.Location = new System.Drawing.Point(118, 84);
            this.ddlLangCode.Name = "ddlLangCode";
            this.ddlLangCode.Size = new System.Drawing.Size(192, 21);
            this.ddlLangCode.TabIndex = 9;
            this.ddlLangCode.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(3, 84);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(102, 19);
            this.radLabel5.TabIndex = 4;
            this.radLabel5.Text = "Мова виконання";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // licenseBigRBindingSource
            // 
            this.licenseBigRBindingSource.DataSource = typeof(ipsFormsDesign.Model.LicenseBigR);
            // 
            // objectRightBindingSource
            // 
            this.objectRightBindingSource.DataSource = typeof(ipsFormsDesign.Model.ObjectRight);
            // 
            // ObjectRightBrInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.ddlLangCode);
            this.Controls.Add(this.mtxtRate);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.mtxtActCode);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.ddlGenreType);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.radLabel1);
            this.Name = "ObjectRightBrInfoControl";
            this.Size = new System.Drawing.Size(469, 110);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGenreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtActCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtxtRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLangCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseBigRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectRightBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList ddlGenreType;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadMaskedEditBox mtxtActCode;
        private Telerik.WinControls.UI.RadMaskedEditBox mtxtRate;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList ddlLangCode;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource objectRightBindingSource;
        private System.Windows.Forms.BindingSource licenseBigRBindingSource;
    }
}
