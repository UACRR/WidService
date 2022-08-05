namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    partial class CommonPlaceParametersControl
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
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.rLblMainHeader = new Telerik.WinControls.UI.RadLabel();
            this.txtStreet = new Telerik.WinControls.UI.RadTextBox();
            this.bsClnBusinessPlace = new System.Windows.Forms.BindingSource(this.components);
            this.ddlRegion = new Telerik.WinControls.UI.RadDropDownList();
            this.bsDictRegion = new System.Windows.Forms.BindingSource(this.components);
            this.lblStreet = new Telerik.WinControls.UI.RadLabel();
            this.lblRegion = new Telerik.WinControls.UI.RadLabel();
            this.lblTown = new Telerik.WinControls.UI.RadLabel();
            this.txtTownName = new Telerik.WinControls.UI.RadTextBox();
            this.rLblTypeInst = new Telerik.WinControls.UI.RadLabel();
            this.rLblName = new Telerik.WinControls.UI.RadLabel();
            this.txtPlaceType = new Telerik.WinControls.UI.RadTextBox();
            this.txtPlaceName = new Telerik.WinControls.UI.RadTextBox();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bsDictTypePlace = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            this.radSeparator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMainHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStreet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnBusinessPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStreet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTownName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).BeginInit();
            this.SuspendLayout();
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Controls.Add(this.rLblMainHeader);
            this.radSeparator1.Location = new System.Drawing.Point(5, 58);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(652, 21);
            this.radSeparator1.TabIndex = 0;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // rLblMainHeader
            // 
            this.rLblMainHeader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rLblMainHeader.Location = new System.Drawing.Point(10, 0);
            this.rLblMainHeader.Name = "rLblMainHeader";
            this.rLblMainHeader.Size = new System.Drawing.Size(136, 21);
            this.rLblMainHeader.TabIndex = 0;
            this.rLblMainHeader.Text = "Адреса бізнес-точки";
            this.rLblMainHeader.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.rLblMainHeader.ThemeName = "Office2013Light";
            // 
            // txtStreet
            // 
            this.txtStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnBusinessPlace, "PlaceAddress", true));
            this.txtStreet.Location = new System.Drawing.Point(115, 110);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.NullText = " Назва вулиці / № будинку ";
            this.txtStreet.Size = new System.Drawing.Size(542, 21);
            this.txtStreet.TabIndex = 4;
            this.txtStreet.ThemeName = "Office2013Light";
            // 
            // bsClnBusinessPlace
            // 
            this.bsClnBusinessPlace.DataSource = typeof(ipsFormsDesign.Model.ClnBusinessPlace);
            // 
            // ddlRegion
            // 
            this.ddlRegion.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsClnBusinessPlace, "PlaceRegion", true));
            this.ddlRegion.DataSource = this.bsDictRegion;
            this.ddlRegion.DisplayMember = "Name";
            this.ddlRegion.DropDownMinSize = new System.Drawing.Size(0, 200);
            this.ddlRegion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlRegion.Location = new System.Drawing.Point(115, 83);
            this.ddlRegion.Name = "ddlRegion";
            this.ddlRegion.NullText = "Оберіть область";
            this.ddlRegion.Size = new System.Drawing.Size(164, 21);
            this.ddlRegion.TabIndex = 2;
            this.ddlRegion.ThemeName = "Office2013Light";
            this.ddlRegion.ValueMember = "CodeI";
            // 
            // bsDictRegion
            // 
            this.bsDictRegion.DataSource = typeof(ipsFormsDesign.Model.Region);
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = false;
            this.lblStreet.Location = new System.Drawing.Point(49, 113);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(60, 17);
            this.lblStreet.TabIndex = 0;
            this.lblStreet.Text = "Адреса";
            this.lblStreet.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStreet.ThemeName = "Office2013Light";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = false;
            this.lblRegion.Location = new System.Drawing.Point(49, 85);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(60, 18);
            this.lblRegion.TabIndex = 0;
            this.lblRegion.Text = "Область";
            this.lblRegion.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRegion.ThemeName = "Office2013Light";
            // 
            // lblTown
            // 
            this.lblTown.Location = new System.Drawing.Point(290, 85);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(98, 18);
            this.lblTown.TabIndex = 0;
            this.lblTown.Text = "<html>Населений пункт</html>";
            this.lblTown.ThemeName = "Office2013Light";
            // 
            // txtTownName
            // 
            this.txtTownName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTownName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnBusinessPlace, "PlaceCity", true));
            this.txtTownName.Location = new System.Drawing.Point(394, 83);
            this.txtTownName.Name = "txtTownName";
            this.txtTownName.Size = new System.Drawing.Size(263, 21);
            this.txtTownName.TabIndex = 3;
            this.txtTownName.ThemeName = "Office2013Light";
            // 
            // rLblTypeInst
            // 
            this.rLblTypeInst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblTypeInst.Location = new System.Drawing.Point(29, 32);
            this.rLblTypeInst.Name = "rLblTypeInst";
            this.rLblTypeInst.Size = new System.Drawing.Size(112, 21);
            this.rLblTypeInst.TabIndex = 0;
            this.rLblTypeInst.Text = "Тип бізнес-точки";
            this.rLblTypeInst.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.rLblTypeInst.ThemeName = "Office2013Light";
            // 
            // rLblName
            // 
            this.rLblName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rLblName.Location = new System.Drawing.Point(3, 3);
            this.rLblName.Name = "rLblName";
            this.rLblName.Size = new System.Drawing.Size(141, 23);
            this.rLblName.TabIndex = 0;
            this.rLblName.Text = "Назва бізнес-точки";
            this.rLblName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.rLblName.ThemeName = "Office2013Light";
            // 
            // txtPlaceType
            // 
            this.txtPlaceType.Location = new System.Drawing.Point(150, 33);
            this.txtPlaceType.Name = "txtPlaceType";
            this.txtPlaceType.ReadOnly = true;
            this.txtPlaceType.Size = new System.Drawing.Size(248, 21);
            this.txtPlaceType.TabIndex = 0;
            this.txtPlaceType.ThemeName = "Office2013Light";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceName.BackColor = System.Drawing.Color.White;
            this.txtPlaceName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnBusinessPlace, "PlaceName", true));
            this.txtPlaceName.Location = new System.Drawing.Point(150, 6);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(507, 21);
            this.txtPlaceName.TabIndex = 1;
            this.txtPlaceName.ThemeName = "Office2013Light";
            // 
            // bsDictTypePlace
            // 
            this.bsDictTypePlace.DataSource = typeof(ipsFormsDesign.Model.TypePlace);
            // 
            // CommonPlaceParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.rLblTypeInst);
            this.Controls.Add(this.rLblName);
            this.Controls.Add(this.txtPlaceType);
            this.Controls.Add(this.txtPlaceName);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.ddlRegion);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblTown);
            this.Controls.Add(this.txtTownName);
            this.MaximumSize = new System.Drawing.Size(800, 137);
            this.MinimumSize = new System.Drawing.Size(520, 137);
            this.Name = "CommonPlaceParametersControl";
            this.Size = new System.Drawing.Size(660, 137);
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            this.radSeparator1.ResumeLayout(false);
            this.radSeparator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMainHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStreet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnBusinessPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStreet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTownName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadTextBox txtStreet;
        private Telerik.WinControls.UI.RadDropDownList ddlRegion;
        private Telerik.WinControls.UI.RadLabel lblStreet;
        private Telerik.WinControls.UI.RadLabel lblRegion;
        private Telerik.WinControls.UI.RadLabel lblTown;
        private Telerik.WinControls.UI.RadLabel rLblMainHeader;
        private Telerik.WinControls.UI.RadTextBox txtTownName;
        private Telerik.WinControls.UI.RadLabel rLblTypeInst;
        private Telerik.WinControls.UI.RadLabel rLblName;
        private Telerik.WinControls.UI.RadTextBox txtPlaceType;
        private Telerik.WinControls.UI.RadTextBox txtPlaceName;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsDictRegion;
        private System.Windows.Forms.BindingSource bsClnBusinessPlace;
        private System.Windows.Forms.BindingSource bsDictTypePlace;
    }
}
