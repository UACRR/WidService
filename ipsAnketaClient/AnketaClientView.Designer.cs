namespace ipsAnketaClient
{
    partial class AnketaClientView
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rGridViewInstitution = new Telerik.WinControls.UI.RadGridView();
            this.rPanelAdd = new Telerik.WinControls.UI.RadPanel();
            this.rLblTypeInst = new Telerik.WinControls.UI.RadLabel();
            this.rLblName = new Telerik.WinControls.UI.RadLabel();
            this.rTxtBoxTypeInst = new Telerik.WinControls.UI.RadTextBox();
            this.rTxtBoxNameInst = new Telerik.WinControls.UI.RadTextBox();
            this.rDropDownBtnAddInst = new Telerik.WinControls.UI.RadDropDownButton();
            this.rBtnAddRestaurant = new Telerik.WinControls.UI.RadMenuItem();
            this.rBtnAddHotel = new Telerik.WinControls.UI.RadMenuItem();
            this.rBtnAddNightClub = new Telerik.WinControls.UI.RadMenuItem();
            this.rBtnAddCaffeOrBar = new Telerik.WinControls.UI.RadMenuItem();
            this.rBtnSave = new Telerik.WinControls.UI.RadButton();
            this.rBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.lblLocation = new System.Windows.Forms.Label();
            this.addressControl = new IpsViewComponentLibrary.IpsAddressExpandedControl();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewInstitution.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelAdd)).BeginInit();
            this.rPanelAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxTypeInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownBtnAddInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rGridViewInstitution
            // 
            this.rGridViewInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridViewInstitution.Location = new System.Drawing.Point(13, 13);
            // 
            // 
            // 
            this.rGridViewInstitution.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rGridViewInstitution.Name = "rGridViewInstitution";
            this.rGridViewInstitution.Size = new System.Drawing.Size(889, 244);
            this.rGridViewInstitution.TabIndex = 0;
            // 
            // rPanelAdd
            // 
            this.rPanelAdd.Controls.Add(this.lblLocation);
            this.rPanelAdd.Controls.Add(this.addressControl);
            this.rPanelAdd.Controls.Add(this.rBtnCancel);
            this.rPanelAdd.Controls.Add(this.rBtnSave);
            this.rPanelAdd.Controls.Add(this.rLblTypeInst);
            this.rPanelAdd.Controls.Add(this.rLblName);
            this.rPanelAdd.Controls.Add(this.rTxtBoxTypeInst);
            this.rPanelAdd.Controls.Add(this.rTxtBoxNameInst);
            this.rPanelAdd.Location = new System.Drawing.Point(13, 303);
            this.rPanelAdd.Name = "rPanelAdd";
            this.rPanelAdd.Size = new System.Drawing.Size(889, 201);
            this.rPanelAdd.TabIndex = 2;
            this.rPanelAdd.Visible = false;
            // 
            // rLblTypeInst
            // 
            this.rLblTypeInst.AutoSize = false;
            this.rLblTypeInst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblTypeInst.Location = new System.Drawing.Point(13, 37);
            this.rLblTypeInst.Name = "rLblTypeInst";
            this.rLblTypeInst.Size = new System.Drawing.Size(115, 18);
            this.rLblTypeInst.TabIndex = 3;
            this.rLblTypeInst.Text = "Тип закладу";
            this.rLblTypeInst.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rLblName
            // 
            this.rLblName.AutoSize = false;
            this.rLblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblName.Location = new System.Drawing.Point(13, 6);
            this.rLblName.Name = "rLblName";
            this.rLblName.Size = new System.Drawing.Size(115, 25);
            this.rLblName.TabIndex = 2;
            this.rLblName.Text = "<html>Назва закладу</html>";
            this.rLblName.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rTxtBoxTypeInst
            // 
            this.rTxtBoxTypeInst.Location = new System.Drawing.Point(134, 37);
            this.rTxtBoxTypeInst.Name = "rTxtBoxTypeInst";
            this.rTxtBoxTypeInst.ReadOnly = true;
            this.rTxtBoxTypeInst.Size = new System.Drawing.Size(283, 20);
            this.rTxtBoxTypeInst.TabIndex = 1;
            // 
            // rTxtBoxNameInst
            // 
            this.rTxtBoxNameInst.Location = new System.Drawing.Point(134, 11);
            this.rTxtBoxNameInst.Name = "rTxtBoxNameInst";
            this.rTxtBoxNameInst.Size = new System.Drawing.Size(456, 20);
            this.rTxtBoxNameInst.TabIndex = 0;
            // 
            // rDropDownBtnAddInst
            // 
            this.rDropDownBtnAddInst.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rBtnAddRestaurant,
            this.rBtnAddHotel,
            this.rBtnAddNightClub,
            this.rBtnAddCaffeOrBar});
            this.rDropDownBtnAddInst.Location = new System.Drawing.Point(13, 264);
            this.rDropDownBtnAddInst.Name = "rDropDownBtnAddInst";
            this.rDropDownBtnAddInst.Size = new System.Drawing.Size(140, 24);
            this.rDropDownBtnAddInst.TabIndex = 3;
            this.rDropDownBtnAddInst.Text = "Додати заклад";
            // 
            // rBtnAddRestaurant
            // 
            this.rBtnAddRestaurant.AccessibleDescription = "Додати ресторан";
            this.rBtnAddRestaurant.Name = "rBtnAddRestaurant";
            this.rBtnAddRestaurant.Text = "Ресторан";
            this.rBtnAddRestaurant.Click += new System.EventHandler(this.rBtnAddRestaurant_Click);
            // 
            // rBtnAddHotel
            // 
            this.rBtnAddHotel.Name = "rBtnAddHotel";
            this.rBtnAddHotel.Text = "Готель";
            this.rBtnAddHotel.Click += new System.EventHandler(this.rBtnAddHotel_Click);
            // 
            // rBtnAddNightClub
            // 
            this.rBtnAddNightClub.Name = "rBtnAddNightClub";
            this.rBtnAddNightClub.Text = "Нічний клуб";
            this.rBtnAddNightClub.Click += new System.EventHandler(this.rBtnAddNightClub_Click);
            // 
            // rBtnAddCaffeOrBar
            // 
            this.rBtnAddCaffeOrBar.Name = "rBtnAddCaffeOrBar";
            this.rBtnAddCaffeOrBar.Text = "Кафе/Бар";
            this.rBtnAddCaffeOrBar.Click += new System.EventHandler(this.rBtnAddCaffeOrBar_Click);
            // 
            // rBtnSave
            // 
            this.rBtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnSave.Location = new System.Drawing.Point(4, 174);
            this.rBtnSave.Name = "rBtnSave";
            this.rBtnSave.Size = new System.Drawing.Size(110, 24);
            this.rBtnSave.TabIndex = 4;
            this.rBtnSave.Text = "Зберегти";
            this.rBtnSave.Click += new System.EventHandler(this.rBtnSave_Click);
            // 
            // rBtnCancel
            // 
            this.rBtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnCancel.Location = new System.Drawing.Point(120, 174);
            this.rBtnCancel.Name = "rBtnCancel";
            this.rBtnCancel.Size = new System.Drawing.Size(110, 24);
            this.rBtnCancel.TabIndex = 5;
            this.rBtnCancel.Text = "Скасувати";
            this.rBtnCancel.Click += new System.EventHandler(this.rBtnCancel_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(10, 154);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(38, 13);
            this.lblLocation.TabIndex = 7;
            this.lblLocation.Text = "label1";
            // 
            // addressControl
            // 
            this.addressControl.Location = new System.Drawing.Point(13, 62);
            this.addressControl.Name = "addressControl";
            this.addressControl.Size = new System.Drawing.Size(873, 89);
            this.addressControl.TabIndex = 6;
            // 
            // AnketaClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 516);
            this.Controls.Add(this.rDropDownBtnAddInst);
            this.Controls.Add(this.rPanelAdd);
            this.Controls.Add(this.rGridViewInstitution);
            this.Name = "AnketaClientView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewInstitution.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelAdd)).EndInit();
            this.rPanelAdd.ResumeLayout(false);
            this.rPanelAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblTypeInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxTypeInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownBtnAddInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rGridViewInstitution;
        private Telerik.WinControls.UI.RadPanel rPanelAdd;
        private Telerik.WinControls.UI.RadDropDownButton rDropDownBtnAddInst;
        private Telerik.WinControls.UI.RadMenuItem rBtnAddRestaurant;
        private Telerik.WinControls.UI.RadMenuItem rBtnAddHotel;
        private Telerik.WinControls.UI.RadMenuItem rBtnAddNightClub;
        private Telerik.WinControls.UI.RadMenuItem rBtnAddCaffeOrBar;
        private Telerik.WinControls.UI.RadLabel rLblTypeInst;
        private Telerik.WinControls.UI.RadLabel rLblName;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxTypeInst;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxNameInst;
        private Telerik.WinControls.UI.RadButton rBtnCancel;
        private Telerik.WinControls.UI.RadButton rBtnSave;
        private IpsViewComponentLibrary.IpsAddressExpandedControl addressControl;
        private System.Windows.Forms.Label lblLocation;
    }
}