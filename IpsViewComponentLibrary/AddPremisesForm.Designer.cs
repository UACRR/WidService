namespace ipsAnketaClient
{
    partial class AddPremisesForm
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
            this.rBtnAdd = new Telerik.WinControls.UI.RadButton();
            this.rBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.lblTypePremisses = new Telerik.WinControls.UI.RadLabel();
            this.lblTitlePlace = new Telerik.WinControls.UI.RadLabel();
            this.txtPlaceName = new Telerik.WinControls.UI.RadTextBox();
            this.txtPlaceValue = new Telerik.WinControls.UI.RadTextBox();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitlePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rBtnAdd
            // 
            this.rBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnAdd.Location = new System.Drawing.Point(13, 64);
            this.rBtnAdd.Name = "rBtnAdd";
            this.rBtnAdd.Size = new System.Drawing.Size(143, 24);
            this.rBtnAdd.TabIndex = 2;
            this.rBtnAdd.Text = "Додати приміщення";
            this.rBtnAdd.ThemeName = "Office2013Light";
            this.rBtnAdd.Click += new System.EventHandler(this.rBtnAdd_Click);
            // 
            // rBtnCancel
            // 
            this.rBtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnCancel.Location = new System.Drawing.Point(384, 64);
            this.rBtnCancel.Name = "rBtnCancel";
            this.rBtnCancel.Size = new System.Drawing.Size(110, 24);
            this.rBtnCancel.TabIndex = 3;
            this.rBtnCancel.Text = "Скасувати";
            this.rBtnCancel.ThemeName = "Office2013Light";
            this.rBtnCancel.Click += new System.EventHandler(this.rBtnCancel_Click);
            // 
            // lblTypePremisses
            // 
            this.lblTypePremisses.AutoSize = false;
            this.lblTypePremisses.Location = new System.Drawing.Point(13, 13);
            this.lblTypePremisses.Name = "lblTypePremisses";
            this.lblTypePremisses.Size = new System.Drawing.Size(101, 18);
            this.lblTypePremisses.TabIndex = 0;
            this.lblTypePremisses.Text = "Тип приміщення";
            this.lblTypePremisses.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTypePremisses.ThemeName = "Office2013Light";
            // 
            // lblTitlePlace
            // 
            this.lblTitlePlace.AutoSize = false;
            this.lblTitlePlace.Location = new System.Drawing.Point(12, 37);
            this.lblTitlePlace.Name = "lblTitlePlace";
            this.lblTitlePlace.Size = new System.Drawing.Size(102, 18);
            this.lblTitlePlace.TabIndex = 1;
            this.lblTitlePlace.Text = "Місць";
            this.lblTitlePlace.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitlePlace.ThemeName = "Office2013Light";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceName.Location = new System.Drawing.Point(120, 12);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(374, 21);
            this.txtPlaceName.TabIndex = 0;
            this.txtPlaceName.ThemeName = "Office2013Light";
            // 
            // txtPlaceValue
            // 
            this.txtPlaceValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceValue.Location = new System.Drawing.Point(120, 36);
            this.txtPlaceValue.Name = "txtPlaceValue";
            this.txtPlaceValue.Size = new System.Drawing.Size(89, 21);
            this.txtPlaceValue.TabIndex = 1;
            this.txtPlaceValue.ThemeName = "Office2013Light";
            // 
            // AddPremisesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 100);
            this.Controls.Add(this.txtPlaceValue);
            this.Controls.Add(this.txtPlaceName);
            this.Controls.Add(this.lblTitlePlace);
            this.Controls.Add(this.lblTypePremisses);
            this.Controls.Add(this.rBtnCancel);
            this.Controls.Add(this.rBtnAdd);
            this.MaximumSize = new System.Drawing.Size(514, 132);
            this.Name = "AddPremisesForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(514, 132);
            this.Text = "Додати приміщення закладу";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitlePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton rBtnAdd;
        private Telerik.WinControls.UI.RadButton rBtnCancel;
        private Telerik.WinControls.UI.RadLabel lblTypePremisses;
        private Telerik.WinControls.UI.RadLabel lblTitlePlace;
        private Telerik.WinControls.UI.RadTextBox txtPlaceName;
        private Telerik.WinControls.UI.RadTextBox txtPlaceValue;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
