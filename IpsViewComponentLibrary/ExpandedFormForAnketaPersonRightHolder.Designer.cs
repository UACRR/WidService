namespace IpsViewComponentLibrary
{
    partial class ExpandedFormForAnketaPersonRightHolder
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
            this.lblTextRu = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxTextRu = new Telerik.WinControls.UI.RadTextBox();
            this.rBtnSave = new Telerik.WinControls.UI.RadButton();
            this.rBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.rtxtBoxTextEn = new Telerik.WinControls.UI.RadTextBox();
            this.lblTextEn = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTextRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxTextRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxTextEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTextEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextRu
            // 
            this.lblTextRu.Location = new System.Drawing.Point(13, 13);
            this.lblTextRu.Name = "lblTextRu";
            this.lblTextRu.Size = new System.Drawing.Size(140, 18);
            this.lblTextRu.TabIndex = 0;
            this.lblTextRu.Text = "Псевдонім (сценічне ім\'я)";
            // 
            // rtxtBoxTextRu
            // 
            this.rtxtBoxTextRu.Location = new System.Drawing.Point(13, 37);
            this.rtxtBoxTextRu.Name = "rtxtBoxTextRu";
            this.rtxtBoxTextRu.Size = new System.Drawing.Size(407, 20);
            this.rtxtBoxTextRu.TabIndex = 0;
            this.rtxtBoxTextRu.ThemeName = "Office2007Silver";
            // 
            // rBtnSave
            // 
            this.rBtnSave.Location = new System.Drawing.Point(12, 116);
            this.rBtnSave.Name = "rBtnSave";
            this.rBtnSave.Size = new System.Drawing.Size(90, 24);
            this.rBtnSave.TabIndex = 2;
            this.rBtnSave.Text = "Зберегти";
            this.rBtnSave.ThemeName = "Office2007Silver";
            this.rBtnSave.Click += new System.EventHandler(this.rBtnSave_Click);
            // 
            // rBtnCancel
            // 
            this.rBtnCancel.Location = new System.Drawing.Point(108, 116);
            this.rBtnCancel.Name = "rBtnCancel";
            this.rBtnCancel.Size = new System.Drawing.Size(90, 24);
            this.rBtnCancel.TabIndex = 3;
            this.rBtnCancel.Text = "Скасувати";
            this.rBtnCancel.ThemeName = "Office2007Silver";
            this.rBtnCancel.Click += new System.EventHandler(this.rBtnCancel_Click);
            // 
            // rtxtBoxTextEn
            // 
            this.rtxtBoxTextEn.Location = new System.Drawing.Point(13, 87);
            this.rtxtBoxTextEn.Name = "rtxtBoxTextEn";
            this.rtxtBoxTextEn.Size = new System.Drawing.Size(407, 20);
            this.rtxtBoxTextEn.TabIndex = 1;
            this.rtxtBoxTextEn.ThemeName = "Office2007Silver";
            // 
            // lblTextEn
            // 
            this.lblTextEn.Location = new System.Drawing.Point(13, 63);
            this.lblTextEn.Name = "lblTextEn";
            this.lblTextEn.Size = new System.Drawing.Size(140, 18);
            this.lblTextEn.TabIndex = 1;
            this.lblTextEn.Text = "Псевдонім (сценічне ім\'я)";
            // 
            // ExpandedFormForAnketaPersonRightHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 148);
            this.Controls.Add(this.rtxtBoxTextEn);
            this.Controls.Add(this.lblTextEn);
            this.Controls.Add(this.rBtnCancel);
            this.Controls.Add(this.rBtnSave);
            this.Controls.Add(this.rtxtBoxTextRu);
            this.Controls.Add(this.lblTextRu);
            this.MaximumSize = new System.Drawing.Size(440, 180);
            this.MinimumSize = new System.Drawing.Size(440, 180);
            this.Name = "ExpandedFormForAnketaPersonRightHolder";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(440, 180);
            this.Text = "";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.lblTextRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxTextRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxTextEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTextEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTextRu;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxTextRu;
        private Telerik.WinControls.UI.RadButton rBtnSave;
        private Telerik.WinControls.UI.RadButton rBtnCancel;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxTextEn;
        private Telerik.WinControls.UI.RadLabel lblTextEn;
    }
}
