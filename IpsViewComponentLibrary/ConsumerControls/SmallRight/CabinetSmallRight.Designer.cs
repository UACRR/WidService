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
            this.btnUpdateData = new Telerik.WinControls.UI.RadButton();
            this.btnEditAgr = new Telerik.WinControls.UI.RadButton();
            this.mсInfoAgrCalc = new IpsViewComponentLibrary.MiddleControlInfoAgrCalc();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateData.Location = new System.Drawing.Point(978, 3);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(141, 20);
            this.btnUpdateData.TabIndex = 5;
            this.btnUpdateData.Text = "Оновити";
            this.btnUpdateData.TextWrap = true;
            this.btnUpdateData.ThemeName = "Office2013Light";
            this.btnUpdateData.Click += new System.EventHandler(this.UpdateCustomer_Click);
            // 
            // btnEditAgr
            // 
            this.btnEditAgr.Location = new System.Drawing.Point(3, 3);
            this.btnEditAgr.Name = "btnEditAgr";
            this.btnEditAgr.Size = new System.Drawing.Size(210, 20);
            this.btnEditAgr.TabIndex = 8;
            this.btnEditAgr.Text = "Редагувати анкету споживача";
            this.btnEditAgr.TextWrap = true;
            this.btnEditAgr.ThemeName = "Office2013Light";
            this.btnEditAgr.Click += new System.EventHandler(this.EditExistCustomer_Click);
            // 
            // mсInfoAgrCalc
            // 
            this.mсInfoAgrCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mсInfoAgrCalc.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.mсInfoAgrCalc.Location = new System.Drawing.Point(3, 29);
            this.mсInfoAgrCalc.MinimumSize = new System.Drawing.Size(500, 665);
            this.mсInfoAgrCalc.Name = "mсInfoAgrCalc";
            this.mсInfoAgrCalc.Rights = ipsFormsDesign.Dictionary.TypeRights.SmallRights;
            this.mсInfoAgrCalc.Size = new System.Drawing.Size(1116, 665);
            this.mсInfoAgrCalc.TabIndex = 0;
            // 
            // CabinetSmallRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.Controls.Add(this.btnEditAgr);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.mсInfoAgrCalc);
            this.DoubleBuffered = true;
            this.Name = "CabinetSmallRight";
            this.Size = new System.Drawing.Size(1122, 696);
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditAgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton btnUpdateData;
        private Telerik.WinControls.UI.RadButton btnEditAgr;
        public MiddleControlInfoAgrCalc mсInfoAgrCalc;
    }
}
