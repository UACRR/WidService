using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    partial class SingleParameterCountControl
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bsClnPlaceHoll = new System.Windows.Forms.BindingSource(this.components);
            this.txtPlaceValue = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsClnPlaceHoll
            // 
            this.bsClnPlaceHoll.DataSource = typeof(ipsFormsDesign.Model.ClnPlaceHoll);
            // 
            // txtPlaceValue
            // 
            this.txtPlaceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnPlaceHoll, "ValuePlace", true));
            this.txtPlaceValue.Location = new System.Drawing.Point(98, 2);
            this.txtPlaceValue.Name = "txtPlaceValue";
            this.txtPlaceValue.Size = new System.Drawing.Size(49, 21);
            this.txtPlaceValue.TabIndex = 0;
            this.txtPlaceValue.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(90, 19);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Кількість місць";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // SingleParameterCountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtPlaceValue);
            this.MaximumSize = new System.Drawing.Size(150, 25);
            this.MinimumSize = new System.Drawing.Size(150, 25);
            this.Name = "SingleParameterCountControl";
            this.Size = new System.Drawing.Size(150, 25);
            ((System.ComponentModel.ISupportInitialize)(this.bsClnPlaceHoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlaceValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bsClnPlaceHoll;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadTextBox txtPlaceValue;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
