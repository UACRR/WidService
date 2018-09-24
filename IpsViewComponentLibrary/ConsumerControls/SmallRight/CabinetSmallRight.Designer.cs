namespace IpsViewComponentLibrary
{
    partial class CabinetSmallRight
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
            this.pagesControl = new IpsViewComponentLibrary.PagesCabinetControl();
            this.SuspendLayout();
            // 
            // pagesControl
            // 
            this.pagesControl.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.pagesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagesControl.Location = new System.Drawing.Point(0, 0);
            this.pagesControl.MinimumSize = new System.Drawing.Size(500, 665);
            this.pagesControl.Name = "pagesControl";
            this.pagesControl.Rights = ipsFormsDesign.Dictionary.TypeRights.SmallRights;
            this.pagesControl.Size = new System.Drawing.Size(1122, 696);
            this.pagesControl.TabIndex = 0;
            // 
            // CabinetSmallRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.Controls.Add(this.pagesControl);
            this.DoubleBuffered = true;
            this.Name = "CabinetSmallRight";
            this.Size = new System.Drawing.Size(1122, 696);
            this.ResumeLayout(false);

        }

        #endregion
        public PagesCabinetControl pagesControl;
    }
}
