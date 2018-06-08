namespace RightholderWorkplace
{
    partial class AuthorItemView
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
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.ddlAuthorName = new Telerik.WinControls.UI.RadDropDownList();
            this.authorsBindingSource = new System.Windows.Forms.BindingSource();
            this.ddlAuthorState = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlRoleCode = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel23 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel21 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.panelCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuthorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuthorState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRoleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnCancel);
            this.panelCommand.Controls.Add(this.btnSave);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 108);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(634, 31);
            this.panelCommand.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(521, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(405, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            // 
            // ddlAuthorName
            // 
            this.ddlAuthorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlAuthorName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.authorsBindingSource, "AuthorName", true));
            this.ddlAuthorName.Location = new System.Drawing.Point(92, 73);
            this.ddlAuthorName.Name = "ddlAuthorName";
            this.ddlAuthorName.Size = new System.Drawing.Size(538, 21);
            this.ddlAuthorName.TabIndex = 57;
            this.ddlAuthorName.ThemeName = "Office2013Light";
            this.ddlAuthorName.PopupOpening += new System.ComponentModel.CancelEventHandler(this.ddlAuthorName_PopupOpening);
            // 
            // authorsBindingSource
            // 
            this.authorsBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAuthors);
            // 
            // ddlAuthorState
            // 
            this.ddlAuthorState.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.authorsBindingSource, "IsFolkOrUnknown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, 0));
            this.ddlAuthorState.Location = new System.Drawing.Point(92, 46);
            this.ddlAuthorState.Name = "ddlAuthorState";
            this.ddlAuthorState.Size = new System.Drawing.Size(267, 21);
            this.ddlAuthorState.TabIndex = 56;
            this.ddlAuthorState.ThemeName = "Office2013Light";
            this.ddlAuthorState.SelectedValueChanged += new System.EventHandler(this.ddlAuthorState_SelectedValueChanged);
            // 
            // ddlRoleCode
            // 
            this.ddlRoleCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlRoleCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.authorsBindingSource, "RoleCode", true));
            this.ddlRoleCode.Location = new System.Drawing.Point(92, 19);
            this.ddlRoleCode.Name = "ddlRoleCode";
            this.ddlRoleCode.Size = new System.Drawing.Size(267, 21);
            this.ddlRoleCode.TabIndex = 55;
            this.ddlRoleCode.ThemeName = "Office2013Light";
            // 
            // radLabel23
            // 
            this.radLabel23.Location = new System.Drawing.Point(5, 46);
            this.radLabel23.Name = "radLabel23";
            this.radLabel23.Size = new System.Drawing.Size(68, 19);
            this.radLabel23.TabIndex = 54;
            this.radLabel23.Text = "Авторство:";
            this.radLabel23.ThemeName = "Office2013Light";
            // 
            // radLabel21
            // 
            this.radLabel21.Location = new System.Drawing.Point(5, 21);
            this.radLabel21.Name = "radLabel21";
            this.radLabel21.Size = new System.Drawing.Size(81, 19);
            this.radLabel21.TabIndex = 53;
            this.radLabel21.Text = "Творча роль:";
            this.radLabel21.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(5, 73);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(43, 19);
            this.radLabel1.TabIndex = 55;
            this.radLabel1.Text = "Автор:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // AuthorItemView
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(634, 139);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlAuthorName);
            this.Controls.Add(this.ddlAuthorState);
            this.Controls.Add(this.ddlRoleCode);
            this.Controls.Add(this.radLabel23);
            this.Controls.Add(this.radLabel21);
            this.Controls.Add(this.panelCommand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AuthorItemView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Автор";
            this.ThemeName = "Office2013Light";
            this.panelCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuthorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuthorState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRoleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCommand;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadDropDownList ddlAuthorName;
        private Telerik.WinControls.UI.RadDropDownList ddlAuthorState;
        private Telerik.WinControls.UI.RadDropDownList ddlRoleCode;
        private Telerik.WinControls.UI.RadLabel radLabel23;
        private Telerik.WinControls.UI.RadLabel radLabel21;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.BindingSource authorsBindingSource;
    }
}
