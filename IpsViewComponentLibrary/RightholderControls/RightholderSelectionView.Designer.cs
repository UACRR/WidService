namespace IpsViewComponentLibrary.RightholderControls
{
    partial class RightholderSelectionView
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
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.rightholderMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlRightholderList = new IpsViewComponentLibrary.RightholderControls.RightholderListControl();
            this.panelCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.BackColor = System.Drawing.Color.Silver;
            this.panelCommand.Controls.Add(this.btnCancel);
            this.panelCommand.Controls.Add(this.btnOk);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 444);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(1048, 31);
            this.panelCommand.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(935, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(819, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Вибрати";
            this.btnOk.ThemeName = "Office2013Light";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rightholderMainViewBindingSource
            // 
            this.rightholderMainViewBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.RightholderMainView);
            // 
            // ctrlRightholderList
            // 
            this.ctrlRightholderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRightholderList.Location = new System.Drawing.Point(0, 2);
            this.ctrlRightholderList.Name = "ctrlRightholderList";
            this.ctrlRightholderList.SearchText = "";
            this.ctrlRightholderList.SelectedRightholder = null;
            this.ctrlRightholderList.ShowCommandColumns = false;
            this.ctrlRightholderList.Size = new System.Drawing.Size(1048, 440);
            this.ctrlRightholderList.TabIndex = 24;
            this.ctrlRightholderList.RightholderSelected += new System.EventHandler<ipsFormsDesign.Interfaces.RightholderMainView>(this.ctrlRightholderList_RightholderSelected);
            // 
            // RightholderSelectionView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1048, 475);
            this.Controls.Add(this.ctrlRightholderList);
            this.Controls.Add(this.panelCommand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RightholderSelectionView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Оберіть правовласника";
            this.ThemeName = "Office2013Light";
            this.panelCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommand;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private System.Windows.Forms.BindingSource rightholderMainViewBindingSource;
        private RightholderListControl ctrlRightholderList;
    }
}
