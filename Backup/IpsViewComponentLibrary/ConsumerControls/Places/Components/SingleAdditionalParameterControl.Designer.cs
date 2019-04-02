namespace IpsViewComponentLibrary.ConsumerControls.Places.Components
{
    partial class SingleAdditionalParameterControl
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
            this.bsClnPlaceHoll = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
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
            this.txtPlaceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsClnPlaceHoll, "ValueAdd", true));
            this.txtPlaceValue.Location = new System.Drawing.Point(143, 3);
            this.txtPlaceValue.MaxLength = 256;
            this.txtPlaceValue.Multiline = true;
            this.txtPlaceValue.Name = "txtPlaceValue";
            // 
            // 
            // 
            this.txtPlaceValue.RootElement.MaxSize = new System.Drawing.Size(0, 0);
            this.txtPlaceValue.RootElement.StretchVertically = true;
            this.txtPlaceValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlaceValue.Size = new System.Drawing.Size(298, 48);
            this.txtPlaceValue.TabIndex = 5;
            this.txtPlaceValue.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(133, 19);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Додатковий параметр";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // SingleAdditionalParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtPlaceValue);
            this.Name = "SingleAdditionalParameterControl";
            this.Size = new System.Drawing.Size(444, 54);
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
