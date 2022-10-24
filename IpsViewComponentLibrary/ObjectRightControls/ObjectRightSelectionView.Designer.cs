namespace IpsViewComponentLibrary.ObjectRightControls
{
    partial class ObjectRightSelectionView
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
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.ctrlObjectRightList = new IpsViewComponentLibrary.ObjectRightControls.ObjectRightListControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.panelCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(892, 4);
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
            this.btnOk.Location = new System.Drawing.Point(776, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Вибрати";
            this.btnOk.ThemeName = "Office2013Light";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelCommand
            // 
            this.panelCommand.BackColor = System.Drawing.Color.Silver;
            this.panelCommand.Controls.Add(this.btnCancel);
            this.panelCommand.Controls.Add(this.btnOk);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 469);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(1005, 31);
            this.panelCommand.TabIndex = 1;
            // 
            // ctrlObjectRightList
            // 
            this.ctrlObjectRightList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlObjectRightList.Location = new System.Drawing.Point(0, 0);
            this.ctrlObjectRightList.Name = "ctrlObjectRightList";
            this.ctrlObjectRightList.SelectedObject = null;
            this.ctrlObjectRightList.Size = new System.Drawing.Size(1005, 469);
            this.ctrlObjectRightList.TabIndex = 2;
            this.ctrlObjectRightList.ObjectSelected += new System.EventHandler<ipsFormsDesign.Dictionary.ObjectRightMainView>(this.ctrlObjectRightList_ObjectSelected);
            this.ctrlObjectRightList.EditCommandExecuted += new System.EventHandler<ipsFormsDesign.Dictionary.ObjectRightMainView>(this.ctrlObjectRightList_EditCommandExecuted);
            // 
            // ObjectRightSelectionView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1005, 500);
            this.Controls.Add(this.ctrlObjectRightList);
            this.Controls.Add(this.panelCommand);
            this.Name = "ObjectRightSelectionView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Оберіть об\'єкт права";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.panelCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private System.Windows.Forms.Panel panelCommand;
        private ObjectRightListControl ctrlObjectRightList;
    }
}
