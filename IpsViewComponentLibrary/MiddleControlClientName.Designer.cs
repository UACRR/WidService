using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary
{
    partial class MiddleControlClientName
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
            this.ctrlRegistrationsCompany = new IpsViewComponentLibrary.Shared.Controls.IpsRegistrationsCompanyControl();
            this.ctrlAnketaCompany = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaCompanyControl();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.SuspendLayout();
            // 
            // ctrlRegistrationsCompany
            // 
            this.ctrlRegistrationsCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegistrationsCompany.DataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlRegistrationsCompany.Location = new System.Drawing.Point(3, 101);
            this.ctrlRegistrationsCompany.MaxDate = new System.DateTime(2018, 7, 2, 0, 0, 0, 0);
            this.ctrlRegistrationsCompany.Name = "ctrlRegistrationsCompany";
            this.ctrlRegistrationsCompany.Size = new System.Drawing.Size(705, 109);
            this.ctrlRegistrationsCompany.TabIndex = 3;
            // 
            // ctrlAnketaCompany
            // 
            this.ctrlAnketaCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlAnketaCompany.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            this.ctrlAnketaCompany.Location = new System.Drawing.Point(3, 4);
            this.ctrlAnketaCompany.MaximumSize = new System.Drawing.Size(900, 200);
            this.ctrlAnketaCompany.MinimumSize = new System.Drawing.Size(400, 47);
            this.ctrlAnketaCompany.Name = "ctrlAnketaCompany";
            this.ctrlAnketaCompany.Size = new System.Drawing.Size(705, 91);
            this.ctrlAnketaCompany.TabIndex = 0;
            // 
            // MiddleControlClientName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlRegistrationsCompany);
            this.Controls.Add(this.ctrlAnketaCompany);
            this.MaximumSize = new System.Drawing.Size(800, 217);
            this.MinimumSize = new System.Drawing.Size(607, 217);
            this.Name = "MiddleControlClientName";
            this.Size = new System.Drawing.Size(711, 217);
            this.ResumeLayout(false);

        }

        #endregion

        private IpsAnketaCompanyControl ctrlAnketaCompany;
        private IpsRegistrationsCompanyControl ctrlRegistrationsCompany;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
