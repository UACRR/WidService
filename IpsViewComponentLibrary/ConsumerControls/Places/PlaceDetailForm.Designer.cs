namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    partial class PlaceDetailForm
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.internalPanel = new Telerik.WinControls.UI.RadPanel();
            this.ctrlPlaceParameters = new IpsViewComponentLibrary.ConsumerControls.Places.Components.CommonPlaceParametersControl();
            this.ctrlSaveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.internalPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // internalPanel
            // 
            this.internalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalPanel.Location = new System.Drawing.Point(0, 137);
            this.internalPanel.Name = "internalPanel";
            this.internalPanel.Size = new System.Drawing.Size(592, 51);
            this.internalPanel.TabIndex = 1;
            this.internalPanel.ThemeName = "Office2013Light";
            // 
            // ctrlPlaceParameters
            // 
            this.ctrlPlaceParameters.BusinessPlaceDataSource = typeof(ipsFormsDesign.Model.ClnBusinessPlace);
            this.ctrlPlaceParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPlaceParameters.Location = new System.Drawing.Point(0, 0);
            this.ctrlPlaceParameters.MaximumSize = new System.Drawing.Size(800, 137);
            this.ctrlPlaceParameters.MinimumSize = new System.Drawing.Size(520, 137);
            this.ctrlPlaceParameters.Name = "ctrlPlaceParameters";
            this.ctrlPlaceParameters.Size = new System.Drawing.Size(592, 137);
            this.ctrlPlaceParameters.TabIndex = 0;
            // 
            // ctrlSaveCancel
            // 
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 188);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.Size = new System.Drawing.Size(592, 31);
            this.ctrlSaveCancel.TabIndex = 0;
            // 
            // PlaceDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 219);
            this.Controls.Add(this.internalPanel);
            this.Controls.Add(this.ctrlPlaceParameters);
            this.Controls.Add(this.ctrlSaveCancel);
            this.Name = "PlaceDetailForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Бізнес-точка";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.internalPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
        private Telerik.WinControls.UI.RadPanel internalPanel;
        private Components.CommonPlaceParametersControl ctrlPlaceParameters;
    }
}
