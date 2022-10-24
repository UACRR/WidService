namespace IpsViewComponentLibrary
{
    partial class AddFileDialogForm
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.ddlDocType = new Telerik.WinControls.UI.RadDropDownList();
            this.fileTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtComment = new Telerik.WinControls.UI.RadTextBox();
            this.txtFileName = new Telerik.WinControls.UI.RadTextBox();
            this.btnOpenFileDialog = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFileDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(83, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Тип документу";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 40);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(57, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Коментар";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 68);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(33, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Файл";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // ddlDocType
            // 
            this.ddlDocType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fileTypeBindingSource, "CodeI", true));
            this.ddlDocType.DataSource = this.fileTypeBindingSource;
            this.ddlDocType.DisplayMember = "Name";
            this.ddlDocType.Location = new System.Drawing.Point(101, 12);
            this.ddlDocType.Name = "ddlDocType";
            this.ddlDocType.Size = new System.Drawing.Size(278, 21);
            this.ddlDocType.TabIndex = 5;
            this.ddlDocType.ThemeName = "Office2013Light";
            this.ddlDocType.ValueMember = "CodeI";
            // 
            // fileTypeBindingSource
            // 
            this.fileTypeBindingSource.DataSource = typeof(ipsFormsDesign.Model.FileType);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(101, 39);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(484, 21);
            this.txtComment.TabIndex = 6;
            this.txtComment.ThemeName = "Office2013Light";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(101, 66);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(450, 21);
            this.txtFileName.TabIndex = 7;
            this.txtFileName.ThemeName = "Office2013Light";
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenFileDialog.Location = new System.Drawing.Point(557, 66);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(28, 21);
            this.btnOpenFileDialog.TabIndex = 8;
            this.btnOpenFileDialog.Text = "...";
            this.btnOpenFileDialog.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenFileDialog.ThemeName = "Office2013Light";
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // AddFileDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(597, 137);
            this.Controls.Add(this.btnOpenFileDialog);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.ddlDocType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "AddFileDialogForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Додати новий файл";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFileDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadDropDownList ddlDocType;
        private Telerik.WinControls.UI.RadTextBox txtComment;
        private Telerik.WinControls.UI.RadTextBox txtFileName;
        private Telerik.WinControls.UI.RadButton btnOpenFileDialog;
        private System.Windows.Forms.BindingSource fileTypeBindingSource;
    }
}
