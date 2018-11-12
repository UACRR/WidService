namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    partial class RadioPlaceParameterControl
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
            this.separatorButtons = new Telerik.WinControls.UI.RadSeparator();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.titleParametr = new Telerik.WinControls.UI.RadLabel();
            this.txtPlaceValue = new Telerik.WinControls.UI.RadTextBox();
            this.bsClnPlaceHoll = new System.Windows.Forms.BindingSource(this.components);
            this.rLblTypeInst = new Telerik.WinControls.UI.RadLabel();
            this.rLblName = new Telerik.WinControls.UI.RadLabel();
            this.txtPlaceType = new Telerik.WinControls.UI.RadTextBox();
            this.txtPlaceName = new Telerik.WinControls.UI.RadTextBox();
            this.bsClnBusinessPlace = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictTypePlace = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.separatorButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleParametr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnBusinessPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).BeginInit();
            this.SuspendLayout();
            // 
            // separatorButtons
            // 
            this.separatorButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorButtons.Location = new System.Drawing.Point(3, 123);
            this.separatorButtons.Name = "separatorButtons";
            this.separatorButtons.Size = new System.Drawing.Size(654, 14);
            this.separatorButtons.TabIndex = 29;
            this.separatorButtons.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(3, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(547, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // titleParametr
            // 
            this.titleParametr.AutoSize = false;
            this.titleParametr.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.titleParametr.Location = new System.Drawing.Point(3, 60);
            this.titleParametr.Name = "titleParametr";
            this.titleParametr.Size = new System.Drawing.Size(106, 43);
            this.titleParametr.TabIndex = 26;
            this.titleParametr.Text = "Адреси трансляції";
            this.titleParametr.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.titleParametr.ThemeName = "Office2013Light";
            // 
            // txtPlaceValue
            // 
            this.txtPlaceValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnPlaceHoll, "ValueAdd", true));
            this.txtPlaceValue.Location = new System.Drawing.Point(115, 60);
            this.txtPlaceValue.MaximumSize = new System.Drawing.Size(660, 100);
            this.txtPlaceValue.MaxLength = 256;
            this.txtPlaceValue.Multiline = true;
            this.txtPlaceValue.Name = "txtPlaceValue";
            // 
            // 
            // 
            this.txtPlaceValue.RootElement.MaxSize = new System.Drawing.Size(660, 100);
            this.txtPlaceValue.RootElement.StretchVertically = true;
            this.txtPlaceValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlaceValue.Size = new System.Drawing.Size(542, 60);
            this.txtPlaceValue.TabIndex = 25;
            this.txtPlaceValue.ThemeName = "Office2013Light";
            // 
            // bsClnPlaceHoll
            // 
            this.bsClnPlaceHoll.DataSource = typeof(ipsFormsDesign.Model.ClnPlaceHoll);
            // 
            // rLblTypeInst
            // 
            this.rLblTypeInst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblTypeInst.Location = new System.Drawing.Point(29, 32);
            this.rLblTypeInst.Name = "rLblTypeInst";
            this.rLblTypeInst.Size = new System.Drawing.Size(80, 21);
            this.rLblTypeInst.TabIndex = 23;
            this.rLblTypeInst.Text = "Тип закладу";
            this.rLblTypeInst.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.rLblTypeInst.ThemeName = "Office2013Light";
            // 
            // rLblName
            // 
            this.rLblName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rLblName.Location = new System.Drawing.Point(3, 3);
            this.rLblName.Name = "rLblName";
            this.rLblName.Size = new System.Drawing.Size(106, 23);
            this.rLblName.TabIndex = 21;
            this.rLblName.Text = "Назва закладу";
            this.rLblName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.rLblName.ThemeName = "Office2013Light";
            // 
            // txtPlaceType
            // 
            this.txtPlaceType.Location = new System.Drawing.Point(115, 33);
            this.txtPlaceType.Name = "txtPlaceType";
            this.txtPlaceType.ReadOnly = true;
            this.txtPlaceType.Size = new System.Drawing.Size(283, 21);
            this.txtPlaceType.TabIndex = 24;
            this.txtPlaceType.ThemeName = "Office2013Light";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceName.BackColor = System.Drawing.Color.White;
            this.txtPlaceName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnBusinessPlace, "PlaceName", true));
            this.txtPlaceName.Location = new System.Drawing.Point(115, 6);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(542, 21);
            this.txtPlaceName.TabIndex = 22;
            this.txtPlaceName.ThemeName = "Office2013Light";
            // 
            // bsClnBusinessPlace
            // 
            this.bsClnBusinessPlace.DataSource = typeof(ipsFormsDesign.Model.ClnBusinessPlace);
            // 
            // bsDictTypePlace
            // 
            this.bsDictTypePlace.DataSource = typeof(ipsFormsDesign.Model.TypePlace);
            // 
            // RadioPlaceParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.separatorButtons);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.titleParametr);
            this.Controls.Add(this.txtPlaceValue);
            this.Controls.Add(this.rLblTypeInst);
            this.Controls.Add(this.rLblName);
            this.Controls.Add(this.txtPlaceType);
            this.Controls.Add(this.txtPlaceName);
            this.MaximumSize = new System.Drawing.Size(660, 170);
            this.MinimumSize = new System.Drawing.Size(430, 170);
            this.Name = "RadioPlaceParameterControl";
            this.Size = new System.Drawing.Size(660, 170);
            ((System.ComponentModel.ISupportInitialize)(this.separatorButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleParametr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnBusinessPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsClnBusinessPlace;
        private System.Windows.Forms.BindingSource bsClnPlaceHoll;
        private System.Windows.Forms.BindingSource bsDictTypePlace;
        private Telerik.WinControls.UI.RadSeparator separatorButtons;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadLabel titleParametr;
        private Telerik.WinControls.UI.RadTextBox txtPlaceValue;
        private Telerik.WinControls.UI.RadLabel rLblTypeInst;
        private Telerik.WinControls.UI.RadLabel rLblName;
        private Telerik.WinControls.UI.RadTextBox txtPlaceType;
        private Telerik.WinControls.UI.RadTextBox txtPlaceName;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
