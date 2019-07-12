using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    partial class ContactPersonActionForm
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlContactPerson = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.ddlPosition = new Telerik.WinControls.UI.RadDropDownList();
            this.bsRelEmpl = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtComment = new Telerik.WinControls.UI.RadTextBox();
            this.bsEmpl = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.saveCancelButtonsControl1 = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlContactPerson.Location = new System.Drawing.Point(11, 39);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.OutsidePhone = false;
            this.ctrlContactPerson.PhoneNullText = "+380## ### ## ##";
            this.ctrlContactPerson.Size = new System.Drawing.Size(584, 56);
            this.ctrlContactPerson.TabIndex = 33;
            // 
            // ddlPosition
            // 
            this.ddlPosition.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRelEmpl, "PositionCode", true));
            this.ddlPosition.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlPosition.Location = new System.Drawing.Point(152, 12);
            this.ddlPosition.Name = "ddlPosition";
            this.ddlPosition.Size = new System.Drawing.Size(203, 21);
            this.ddlPosition.TabIndex = 34;
            this.ddlPosition.ThemeName = "Office2013Light";
            // 
            // bsRelEmpl
            // 
            this.bsRelEmpl.DataSource = typeof(ipsFormsDesign.Model.RelEmployee);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(14, 105);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 19);
            this.radLabel1.TabIndex = 35;
            this.radLabel1.Text = "Примітка:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmpl, "Comment", true));
            this.txtComment.Location = new System.Drawing.Point(82, 104);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(514, 21);
            this.txtComment.TabIndex = 36;
            this.txtComment.ThemeName = "Office2013Light";
            // 
            // bsEmpl
            // 
            this.bsEmpl.DataSource = typeof(ipsFormsDesign.Model.Employee);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(14, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(132, 19);
            this.radLabel2.TabIndex = 37;
            this.radLabel2.Text = "Вид контактної особи:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // saveCancelButtonsControl1
            // 
            this.saveCancelButtonsControl1.ButtonSaveDialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveCancelButtonsControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveCancelButtonsControl1.Location = new System.Drawing.Point(0, 138);
            this.saveCancelButtonsControl1.MaximumSize = new System.Drawing.Size(3000, 31);
            this.saveCancelButtonsControl1.MinimumSize = new System.Drawing.Size(300, 31);
            this.saveCancelButtonsControl1.Name = "saveCancelButtonsControl1";
            this.saveCancelButtonsControl1.SaveButtonEnabled = true;
            this.saveCancelButtonsControl1.Size = new System.Drawing.Size(608, 31);
            this.saveCancelButtonsControl1.TabIndex = 38;
            // 
            // ContactPersonActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(608, 169);
            this.Controls.Add(this.saveCancelButtonsControl1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlPosition);
            this.Controls.Add(this.ctrlContactPerson);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "ContactPersonActionForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.ddlPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private IpsBossNameContactsControl ctrlContactPerson;
        private Telerik.WinControls.UI.RadDropDownList ddlPosition;
        private System.Windows.Forms.BindingSource bsRelEmpl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtComment;
        private System.Windows.Forms.BindingSource bsEmpl;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Common.SaveCancelButtonsControl saveCancelButtonsControl1;
    }
}
