using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class JurPersonName
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
            this.ctrlRegistrationsCompany = new IpsViewComponentLibrary.Shared.Controls.IpsRegistrationsCompanyControl();
            this.bsAnketaCompany = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlAnketaCompany = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaCompanyControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlRegistrationsCompany
            // 
            this.ctrlRegistrationsCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegistrationsCompany.DataSource = this.bsAnketaCompany;
            // 
            // 
            // 
            this.ctrlRegistrationsCompany.Location = new System.Drawing.Point(4, 99);
            this.ctrlRegistrationsCompany.Name = "ctrlRegistrationsCompany";
            this.ctrlRegistrationsCompany.Size = new System.Drawing.Size(704, 109);
            this.ctrlRegistrationsCompany.TabIndex = 3;
            // 
            // bsAnketaCompany
            // 
            this.bsAnketaCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            // 
            // ctrlAnketaCompany
            // 
            this.ctrlAnketaCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAnketaCompany.DataSource = this.bsAnketaCompany;
            this.ctrlAnketaCompany.Location = new System.Drawing.Point(4, 4);
            this.ctrlAnketaCompany.MaximumSize = new System.Drawing.Size(800, 86);
            this.ctrlAnketaCompany.MinimumSize = new System.Drawing.Size(400, 86);
            this.ctrlAnketaCompany.Name = "ctrlAnketaCompany";
            this.ctrlAnketaCompany.Size = new System.Drawing.Size(704, 86);
            this.ctrlAnketaCompany.TabIndex = 0;
            // 
            // JurPersonName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ctrlRegistrationsCompany);
            this.Controls.Add(this.ctrlAnketaCompany);
            this.Name = "JurPersonName";
            this.Size = new System.Drawing.Size(711, 211);
            ((System.ComponentModel.ISupportInitialize)(this.bsAnketaCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IpsAnketaCompanyControl ctrlAnketaCompany;
        private IpsRegistrationsCompanyControl ctrlRegistrationsCompany;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsAnketaCompany;
    }
}
