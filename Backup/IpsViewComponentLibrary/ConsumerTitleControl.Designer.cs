namespace IpsViewComponentLibrary
{
    partial class ConsumerTitleControl
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblClientName = new Telerik.WinControls.UI.RadLabel();
            this.lblNumberContract = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblDateBegin = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClientName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNumberContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateBegin)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(174, 24);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Ліцензійний договір №";
            // 
            // lblClientName
            // 
            this.lblClientName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClientName.Location = new System.Drawing.Point(3, 31);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(114, 22);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "Client \"Name\"";
            // 
            // lblNumberContract
            // 
            this.lblNumberContract.AutoSize = false;
            this.lblNumberContract.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberContract.Location = new System.Drawing.Point(183, 5);
            this.lblNumberContract.Name = "lblNumberContract";
            this.lblNumberContract.Size = new System.Drawing.Size(142, 22);
            this.lblNumberContract.TabIndex = 2;
            this.lblNumberContract.Text = "AAA - 00/00000";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel3.Location = new System.Drawing.Point(328, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(27, 23);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "від";
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateBegin.Location = new System.Drawing.Point(361, 5);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(83, 22);
            this.lblDateBegin.TabIndex = 4;
            this.lblDateBegin.Text = "00/00/0000";
            // 
            // ConsumerTitleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDateBegin);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.lblNumberContract);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.radLabel1);
            this.MaximumSize = new System.Drawing.Size(448, 60);
            this.MinimumSize = new System.Drawing.Size(448, 60);
            this.Name = "ConsumerTitleControl";
            this.Size = new System.Drawing.Size(448, 60);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClientName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNumberContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateBegin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblClientName;
        private Telerik.WinControls.UI.RadLabel lblNumberContract;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblDateBegin;
    }
}
