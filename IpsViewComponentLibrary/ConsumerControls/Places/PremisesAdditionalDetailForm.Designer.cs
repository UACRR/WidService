using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.Places
{
    partial class PremisesAdditionalDetailForm
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
            this.txtPlaceName = new Telerik.WinControls.UI.RadTextBox();
            this.bsClnPlaceHoll = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlParameter = new IpsViewComponentLibrary.ConsumerControls.Places.Components.SingleAdditionalParameterControl();
            this.ctrlSaveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).BeginInit();
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
            // txtPlaceName
            // 
            this.txtPlaceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnPlaceHoll, "HollName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPlaceName.Location = new System.Drawing.Point(120, 12);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Size = new System.Drawing.Size(376, 21);
            this.txtPlaceName.TabIndex = 1;
            this.txtPlaceName.ThemeName = "Office2013Light";
            // 
            // bsClnPlaceHoll
            // 
            this.bsClnPlaceHoll.DataSource = typeof(ipsFormsDesign.Model.ClnPlaceHoll);
            // 
            // ctrlParameter
            // 
            this.ctrlParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlParameter.DataSource = typeof(ipsFormsDesign.Model.ClnPlaceHoll);
            this.ctrlParameter.Location = new System.Drawing.Point(13, 38);
            this.ctrlParameter.Name = "ctrlParameter";
            this.ctrlParameter.Size = new System.Drawing.Size(485, 112);
            this.ctrlParameter.TabIndex = 5;
            // 
            // ctrlSaveCancel
            // 
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 161);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.Size = new System.Drawing.Size(506, 31);
            this.ctrlSaveCancel.TabIndex = 6;
            // 
            // PremisesAdditionalDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 192);
            this.Controls.Add(this.ctrlSaveCancel);
            this.Controls.Add(this.ctrlParameter);
            this.Controls.Add(this.txtPlaceName);
            this.Controls.Add(this.lblTypePremisses);
            this.MaximumSize = new System.Drawing.Size(514, 400);
            this.MinimumSize = new System.Drawing.Size(514, 132);
            this.Name = "PremisesAdditionalDetailForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(514, 400);
            this.Text = "Додати приміщення бізнес-точки";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel lblTypePremisses;
        private Telerik.WinControls.UI.RadTextBox txtPlaceName;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsClnPlaceHoll;
        private Components.SingleAdditionalParameterControl ctrlParameter;
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
    }
}
