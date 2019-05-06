namespace IpsViewComponentLibrary.CatalogControls
{
    partial class CommentControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtComm = new Telerik.WinControls.UI.RadLabel();
            this.txtComment = new Telerik.WinControls.UI.RadTextBox();
            this.bsComment = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlSaveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsComment)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComm
            // 
            this.txtComm.AutoSize = false;
            this.txtComm.Location = new System.Drawing.Point(3, 3);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(81, 19);
            this.txtComm.TabIndex = 0;
            this.txtComm.Text = "Коментар";
            this.txtComm.ThemeName = "Office2013Light";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComment, "Comment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtComment.Location = new System.Drawing.Point(0, 28);
            this.txtComment.MaxLength = 1024;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            // 
            // 
            // 
            this.txtComment.RootElement.StretchVertically = true;
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(481, 138);
            this.txtComment.TabIndex = 1;
            this.txtComment.ThemeName = "Office2013Light";
            // 
            // bsComment
            // 
            this.bsComment.DataSource = typeof(ipsFormsDesign.Model.CatalogFile);
            // 
            // ctrlSaveCancel
            // 
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 172);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.SaveButtonEnabled = true;
            this.ctrlSaveCancel.Size = new System.Drawing.Size(481, 31);
            this.ctrlSaveCancel.TabIndex = 4;
            // 
            // CommentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlSaveCancel);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtComm);
            this.Name = "CommentControl";
            this.Size = new System.Drawing.Size(481, 203);
            ((System.ComponentModel.ISupportInitialize)(this.txtComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsComment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel txtComm;
        private Telerik.WinControls.UI.RadTextBox txtComment;
        private System.Windows.Forms.BindingSource bsComment;
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
    }
}
