using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    partial class PremisesDetailForm
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
            this.lblTypePremisses = new Telerik.WinControls.UI.RadLabel();
            this.lblTitlePlace = new Telerik.WinControls.UI.RadLabel();
            this.txtPlaceName = new Telerik.WinControls.UI.RadTextBox();
            this.bsClnPlaceHoll = new System.Windows.Forms.BindingSource(this.components);
            this.txtPlaceValue = new Telerik.WinControls.UI.RadTextBox();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlSaveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitlePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.lblTitlePlace.TabIndex = 0;
            this.lblTitlePlace.Text = "Місць";
            this.lblTitlePlace.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitlePlace.ThemeName = "Office2013Light";
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnPlaceHoll, "HollName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPlaceName.Location = new System.Drawing.Point(120, 12);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(374, 21);
            this.txtPlaceName.TabIndex = 1;
            this.txtPlaceName.ThemeName = "Office2013Light";
            // 
            // bsClnPlaceHoll
            // 
            this.bsClnPlaceHoll.DataSource = typeof(ipsFormsDesign.Model.ClnPlaceHoll);
            // 
            // txtPlaceValue
            // 
            this.txtPlaceValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnPlaceHoll, "ValuePlace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.txtPlaceValue.Location = new System.Drawing.Point(120, 36);
            this.txtPlaceValue.Name = "txtPlaceValue";
            this.txtPlaceValue.Size = new System.Drawing.Size(89, 21);
            this.txtPlaceValue.TabIndex = 2;
            this.txtPlaceValue.ThemeName = "Office2013Light";
            // 
            // ctrlSaveCancel
            // 
            this.ctrlSaveCancel.ButtonSaveDialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 74);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.SaveButtonEnabled = true;
            this.ctrlSaveCancel.Size = new System.Drawing.Size(506, 31);
            this.ctrlSaveCancel.TabIndex = 3;
            // 
            // PremisesDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(506, 105);
            this.Controls.Add(this.ctrlSaveCancel);
            this.Controls.Add(this.txtPlaceValue);
            this.Controls.Add(this.txtPlaceName);
            this.Controls.Add(this.lblTitlePlace);
            this.Controls.Add(this.lblTypePremisses);
            this.MaximumSize = new System.Drawing.Size(514, 200);
            this.Name = "PremisesDetailForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(514, 200);
            this.Text = "Додати приміщення бізнес-точки";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitlePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel lblTypePremisses;
        private Telerik.WinControls.UI.RadLabel lblTitlePlace;
        private Telerik.WinControls.UI.RadTextBox txtPlaceName;
        private Telerik.WinControls.UI.RadTextBox txtPlaceValue;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsClnPlaceHoll;
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
    }
}
