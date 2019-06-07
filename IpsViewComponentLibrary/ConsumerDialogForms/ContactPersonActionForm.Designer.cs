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
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.ctrlContactPerson = new IpsBossNameContactsControl();
            this.ddlPosition = new Telerik.WinControls.UI.RadDropDownList();
            this.bsRelEmpl = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtComment = new Telerik.WinControls.UI.RadTextBox();
            this.bsEmpl = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(526, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlContactPerson.Location = new System.Drawing.Point(12, 39);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.OutsidePhone = false;
            this.ctrlContactPerson.Size = new System.Drawing.Size(624, 56);
            this.ctrlContactPerson.TabIndex = 33;
            // 
            // ddlPosition
            // 
            this.ddlPosition.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRelEmpl, "PositionCode", true));
            this.ddlPosition.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlPosition.Location = new System.Drawing.Point(150, 12);
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
            this.radLabel1.Location = new System.Drawing.Point(12, 105);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 19);
            this.radLabel1.TabIndex = 35;
            this.radLabel1.Text = "Примітка:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // txtComment
            // 
            this.txtComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmpl, "Comment", true));
            this.txtComment.Location = new System.Drawing.Point(80, 104);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(556, 21);
            this.txtComment.TabIndex = 36;
            this.txtComment.ThemeName = "Office2013Light";
            // 
            // bsEmpl
            // 
            this.bsEmpl.DataSource = typeof(ipsFormsDesign.Model.Employee);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(132, 19);
            this.radLabel2.TabIndex = 37;
            this.radLabel2.Text = "Вид контактної особи:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // ContactPersonActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(648, 188);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlPosition);
            this.Controls.Add(this.ctrlContactPerson);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "ContactPersonActionForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private IpsBossNameContactsControl ctrlContactPerson;
        private Telerik.WinControls.UI.RadDropDownList ddlPosition;
        private System.Windows.Forms.BindingSource bsRelEmpl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtComment;
        private System.Windows.Forms.BindingSource bsEmpl;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
