namespace DdexInvoicing
{
    partial class UcInvoiceStatistics
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
            this.wbControl = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbControl
            // 
            this.wbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbControl.Location = new System.Drawing.Point(0, 0);
            this.wbControl.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbControl.Name = "wbControl";
            this.wbControl.Size = new System.Drawing.Size(471, 239);
            this.wbControl.TabIndex = 0;
            this.wbControl.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbControl_DocumentCompleted);
            // 
            // UcInvoiceStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wbControl);
            this.Name = "UcInvoiceStatistics";
            this.Size = new System.Drawing.Size(471, 239);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbControl;
    }
}
