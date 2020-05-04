using System.Windows.Forms;

namespace IpsViewComponentLibrary.Shared.Controls
{
    partial class IpsBossNameContactsExtendedControl
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
            this.txtComment = new Telerik.WinControls.UI.RadTextBox();
            this.bsEmpl = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlContactPerson = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmpl, "Comment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtComment.Location = new System.Drawing.Point(74, 68);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(605, 21);
            this.txtComment.TabIndex = 39;
            this.txtComment.ThemeName = "Office2013Light";
            // 
            // bsEmpl
            // 
            this.bsEmpl.DataSource = typeof(ipsFormsDesign.Model.Employee);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(7, 69);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 19);
            this.radLabel1.TabIndex = 38;
            this.radLabel1.Text = "Примітка:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlContactPerson.Location = new System.Drawing.Point(3, 3);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.OutsidePhone = false;
            this.ctrlContactPerson.PhoneNullText = "+380## ### ## ##";
            this.ctrlContactPerson.Size = new System.Drawing.Size(676, 56);
            this.ctrlContactPerson.TabIndex = 37;
            // 
            // IpsBossNameContactsExtendedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ctrlContactPerson);
            this.MaximumSize = new System.Drawing.Size(1000, 94);
            this.MinimumSize = new System.Drawing.Size(450, 94);
            this.Name = "IpsBossNameContactsExtendedControl";
            this.Size = new System.Drawing.Size(682, 94);
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtComment;
        private System.Windows.Forms.BindingSource bsEmpl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private IpsBossNameContactsControl ctrlContactPerson;
    }
}
