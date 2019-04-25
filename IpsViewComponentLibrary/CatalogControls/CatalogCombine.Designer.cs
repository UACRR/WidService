namespace IpsViewComponentLibrary.CatalogControls
{
    partial class CatalogCombine
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
            this.catalogFiles = new IpsViewComponentLibrary.CatalogControls.CatalogControl();
            this.SuspendLayout();
            // 
            // catalogFiles
            // 
            this.catalogFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogFiles.Location = new System.Drawing.Point(0, 0);
            this.catalogFiles.Name = "catalogFiles";
            this.catalogFiles.Size = new System.Drawing.Size(1052, 563);
            this.catalogFiles.TabIndex = 0;
            // 
            // CatalogCombine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.catalogFiles);
            this.Name = "CatalogCombine";
            this.Size = new System.Drawing.Size(1052, 563);
            this.ResumeLayout(false);

        }

        #endregion

        private CatalogControl catalogFiles;
    }
}
