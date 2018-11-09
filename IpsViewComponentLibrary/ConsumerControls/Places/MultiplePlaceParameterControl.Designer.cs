namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    partial class MultiplePlaceParameterControl
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
            this.bsDictRegion = new System.Windows.Forms.BindingSource(this.components);
            this.bsDictTypePlace = new System.Windows.Forms.BindingSource(this.components);
            this.rLblTypeInst = new Telerik.WinControls.UI.RadLabel();
            this.rLblName = new Telerik.WinControls.UI.RadLabel();
            this.txtPlaceType = new Telerik.WinControls.UI.RadTextBox();
            this.txtPlaceName = new Telerik.WinControls.UI.RadTextBox();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.rLblMainHeader = new Telerik.WinControls.UI.RadLabel();
            this.txtStreet = new Telerik.WinControls.UI.RadTextBox();
            this.ddlRegion = new Telerik.WinControls.UI.RadDropDownList();
            this.lblStreet = new Telerik.WinControls.UI.RadLabel();
            this.lblRegion = new Telerik.WinControls.UI.RadLabel();
            this.lblTown = new Telerik.WinControls.UI.RadLabel();
            this.txtTownName = new Telerik.WinControls.UI.RadTextBox();
            this.separatorButtons = new Telerik.WinControls.UI.RadSeparator();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.ctrlPremises = new IpsViewComponentLibrary.ConsumerControls.Places.PremisesControl();
            this.bsClnBusinessPlace = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsDictRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            this.radSeparator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMainHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStreet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStreet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTownName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnBusinessPlace)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDictRegion
            // 
            this.bsDictRegion.DataSource = typeof(ipsFormsDesign.Model.Region);
            // 
            // bsDictTypePlace
            // 
            this.bsDictTypePlace.DataSource = typeof(ipsFormsDesign.Model.TypePlace);
            // 
            // rLblTypeInst
            // 
            this.rLblTypeInst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblTypeInst.Location = new System.Drawing.Point(29, 32);
            this.rLblTypeInst.Name = "rLblTypeInst";
            this.rLblTypeInst.Size = new System.Drawing.Size(80, 21);
            this.rLblTypeInst.TabIndex = 24;
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
            this.rLblName.TabIndex = 22;
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
            this.txtPlaceType.TabIndex = 25;
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
            this.txtPlaceName.TabIndex = 23;
            this.txtPlaceName.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Controls.Add(this.rLblMainHeader);
            this.radSeparator1.Location = new System.Drawing.Point(5, 58);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(652, 21);
            this.radSeparator1.TabIndex = 15;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // rLblMainHeader
            // 
            this.rLblMainHeader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rLblMainHeader.Location = new System.Drawing.Point(10, 0);
            this.rLblMainHeader.Name = "rLblMainHeader";
            this.rLblMainHeader.Size = new System.Drawing.Size(104, 21);
            this.rLblMainHeader.TabIndex = 5;
            this.rLblMainHeader.Text = "Адреса закладу";
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
            this.txtStreet.TabIndex = 20;
            this.txtStreet.ThemeName = "Office2013Light";
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
            this.ddlRegion.TabIndex = 18;
            this.ddlRegion.ThemeName = "Office2013Light";
            this.ddlRegion.ValueMember = "CodeI";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = false;
            this.lblStreet.Location = new System.Drawing.Point(49, 113);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(60, 17);
            this.lblStreet.TabIndex = 21;
            this.lblStreet.Text = "Вулиця";
            this.lblStreet.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStreet.ThemeName = "Office2013Light";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = false;
            this.lblRegion.Location = new System.Drawing.Point(49, 85);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(60, 18);
            this.lblRegion.TabIndex = 19;
            this.lblRegion.Text = "Область";
            this.lblRegion.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRegion.ThemeName = "Office2013Light";
            // 
            // lblTown
            // 
            this.lblTown.Location = new System.Drawing.Point(290, 85);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(98, 18);
            this.lblTown.TabIndex = 16;
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
            this.txtTownName.TabIndex = 17;
            this.txtTownName.ThemeName = "Office2013Light";
            // 
            // separatorButtons
            // 
            this.separatorButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorButtons.Location = new System.Drawing.Point(3, 403);
            this.separatorButtons.Name = "separatorButtons";
            this.separatorButtons.Size = new System.Drawing.Size(654, 12);
            this.separatorButtons.TabIndex = 28;
            this.separatorButtons.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(3, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(547, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctrlPremises
            // 
            this.ctrlPremises.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPremises.Location = new System.Drawing.Point(3, 137);
            this.ctrlPremises.MinimumSize = new System.Drawing.Size(450, 260);
            this.ctrlPremises.Name = "ctrlPremises";
            this.ctrlPremises.PlaceType = IpsViewComponentLibrary.MeasurementOfPlaces.Empty;
            this.ctrlPremises.Size = new System.Drawing.Size(654, 260);
            this.ctrlPremises.TabIndex = 29;
            // 
            // bsClnBusinessPlace
            // 
            this.bsClnBusinessPlace.DataSource = typeof(ipsFormsDesign.Model.ClnBusinessPlace);
            // 
            // MultiplePlaceParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPremises);
            this.Controls.Add(this.separatorButtons);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
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
            this.MaximumSize = new System.Drawing.Size(660, 447);
            this.MinimumSize = new System.Drawing.Size(520, 447);
            this.Name = "MultiplePlaceParameterControl";
            this.Size = new System.Drawing.Size(660, 447);
            ((System.ComponentModel.ISupportInitialize)(this.bsDictRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDictTypePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            this.radSeparator1.ResumeLayout(false);
            this.radSeparator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblMainHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStreet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStreet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTownName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnBusinessPlace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDictRegion;
        private System.Windows.Forms.BindingSource bsDictTypePlace;
        private Telerik.WinControls.UI.RadLabel rLblTypeInst;
        private Telerik.WinControls.UI.RadLabel rLblName;
        private Telerik.WinControls.UI.RadTextBox txtPlaceType;
        private Telerik.WinControls.UI.RadTextBox txtPlaceName;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadLabel rLblMainHeader;
        private Telerik.WinControls.UI.RadTextBox txtStreet;
        private Telerik.WinControls.UI.RadDropDownList ddlRegion;
        private Telerik.WinControls.UI.RadLabel lblStreet;
        private Telerik.WinControls.UI.RadLabel lblRegion;
        private Telerik.WinControls.UI.RadLabel lblTown;
        private Telerik.WinControls.UI.RadTextBox txtTownName;
        private Telerik.WinControls.UI.RadSeparator separatorButtons;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private PremisesControl ctrlPremises;
        private System.Windows.Forms.BindingSource bsClnBusinessPlace;
    }
}
