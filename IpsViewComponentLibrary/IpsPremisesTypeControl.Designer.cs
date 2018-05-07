namespace IpsViewComponentLibrary
{
    partial class IpsPremisesTypeControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rLblPremises = new Telerik.WinControls.UI.RadLabel();
            this.rGridViewPremises = new Telerik.WinControls.UI.RadGridView();
            this.rBtnAddPremises = new Telerik.WinControls.UI.RadButton();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.rLblPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddPremises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            this.SuspendLayout();
            // 
            // rLblPremises
            // 
            this.rLblPremises.AutoSize = false;
            this.rLblPremises.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblPremises.Location = new System.Drawing.Point(3, 3);
            this.rLblPremises.Name = "rLblPremises";
            this.rLblPremises.Size = new System.Drawing.Size(170, 26);
            this.rLblPremises.TabIndex = 4;
            this.rLblPremises.Text = "Приміщення закладу";
            this.rLblPremises.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // rGridViewPremises
            // 
            this.rGridViewPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridViewPremises.Location = new System.Drawing.Point(17, 35);
            // 
            // 
            // 
            this.rGridViewPremises.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rGridViewPremises.Name = "rGridViewPremises";
            this.rGridViewPremises.Size = new System.Drawing.Size(616, 87);
            this.rGridViewPremises.TabIndex = 5;
            // 
            // rBtnAddPremises
            // 
            this.rBtnAddPremises.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnAddPremises.Location = new System.Drawing.Point(17, 128);
            this.rBtnAddPremises.Name = "rBtnAddPremises";
            this.rBtnAddPremises.Size = new System.Drawing.Size(138, 24);
            this.rBtnAddPremises.TabIndex = 6;
            this.rBtnAddPremises.Text = "Додати приміщення";
            this.rBtnAddPremises.Click += new System.EventHandler(this.rBtnAddPremises_Click);
            // 
            // radSeparator1
            // 
            this.radSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator1.Location = new System.Drawing.Point(179, 9);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(454, 20);
            this.radSeparator1.TabIndex = 12;
            // 
            // IpsPremisesTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.rBtnAddPremises);
            this.Controls.Add(this.rGridViewPremises);
            this.Controls.Add(this.rLblPremises);
            this.Name = "IpsPremisesTypeControl";
            this.Size = new System.Drawing.Size(636, 155);
            ((System.ComponentModel.ISupportInitialize)(this.rLblPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddPremises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel rLblPremises;
        private Telerik.WinControls.UI.RadGridView rGridViewPremises;
        private Telerik.WinControls.UI.RadButton rBtnAddPremises;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
    }
}
