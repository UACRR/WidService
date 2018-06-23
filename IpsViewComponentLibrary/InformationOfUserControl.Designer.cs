namespace IpsViewComponentLibrary
{
    partial class InformationOfUserControl
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
            this.panelUserInfo = new Telerik.WinControls.UI.RadPanel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.groupholdingCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.panelMeneger = new Telerik.WinControls.UI.RadPanel();
            this.managerEmail = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.managerPhoneCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.managerPibCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.panelContactPerson = new Telerik.WinControls.UI.RadPanel();
            this.contactPersEmailCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.contactPersPhoneCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.contactPersPibCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.organisationFormCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.edrpouCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.nameCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelUserInfo)).BeginInit();
            this.panelUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMeneger)).BeginInit();
            this.panelMeneger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContactPerson)).BeginInit();
            this.panelContactPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserInfo.Controls.Add(this.radLabel3);
            this.panelUserInfo.Controls.Add(this.groupholdingCtrl);
            this.panelUserInfo.Controls.Add(this.radLabel2);
            this.panelUserInfo.Controls.Add(this.panelMeneger);
            this.panelUserInfo.Controls.Add(this.panelContactPerson);
            this.panelUserInfo.Controls.Add(this.organisationFormCtrl);
            this.panelUserInfo.Controls.Add(this.edrpouCtrl);
            this.panelUserInfo.Controls.Add(this.nameCtrl);
            this.panelUserInfo.Location = new System.Drawing.Point(3, 12);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Size = new System.Drawing.Size(906, 194);
            this.panelUserInfo.TabIndex = 0;
            this.panelUserInfo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(531, 75);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(53, 18);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "Керівник";
            // 
            // groupholdingCtrl
            // 
            this.groupholdingCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.groupholdingCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupholdingCtrl.Location = new System.Drawing.Point(512, 16);
            this.groupholdingCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.groupholdingCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.groupholdingCtrl.Name = "groupholdingCtrl";
            this.groupholdingCtrl.Size = new System.Drawing.Size(328, 35);
            this.groupholdingCtrl.SplitterRatio = 100;
            this.groupholdingCtrl.TabIndex = 5;
            this.groupholdingCtrl.TextTitle = "Група / Холдінг";
            this.groupholdingCtrl.TextValue = "Копірайт";
            this.groupholdingCtrl.Visible = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(18, 75);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(93, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Контактна особа";
            // 
            // panelMeneger
            // 
            this.panelMeneger.Controls.Add(this.managerEmail);
            this.panelMeneger.Controls.Add(this.managerPhoneCtrl);
            this.panelMeneger.Controls.Add(this.managerPibCtrl);
            this.panelMeneger.Location = new System.Drawing.Point(517, 84);
            this.panelMeneger.Name = "panelMeneger";
            this.panelMeneger.Size = new System.Drawing.Size(385, 106);
            this.panelMeneger.TabIndex = 4;
            // 
            // managerEmail
            // 
            this.managerEmail.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerEmail.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerEmail.Location = new System.Drawing.Point(3, 69);
            this.managerEmail.MaximumSize = new System.Drawing.Size(1000, 35);
            this.managerEmail.MinimumSize = new System.Drawing.Size(150, 35);
            this.managerEmail.Name = "managerEmail";
            this.managerEmail.Size = new System.Drawing.Size(302, 35);
            this.managerEmail.SplitterRatio = 50;
            this.managerEmail.TabIndex = 6;
            this.managerEmail.TextTitle = "E-Mail";
            this.managerEmail.TextValue = "qwerty@qwer.ty";
            // 
            // managerPhoneCtrl
            // 
            this.managerPhoneCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerPhoneCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerPhoneCtrl.Location = new System.Drawing.Point(3, 43);
            this.managerPhoneCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.managerPhoneCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.managerPhoneCtrl.Name = "managerPhoneCtrl";
            this.managerPhoneCtrl.Size = new System.Drawing.Size(163, 35);
            this.managerPhoneCtrl.SplitterRatio = 50;
            this.managerPhoneCtrl.TabIndex = 3;
            this.managerPhoneCtrl.TextTitle = "Тел.";
            this.managerPhoneCtrl.TextValue = "+380999999999";
            // 
            // managerPibCtrl
            // 
            this.managerPibCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerPibCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerPibCtrl.Location = new System.Drawing.Point(3, 15);
            this.managerPibCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.managerPibCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.managerPibCtrl.Name = "managerPibCtrl";
            this.managerPibCtrl.Size = new System.Drawing.Size(379, 35);
            this.managerPibCtrl.SplitterRatio = 50;
            this.managerPibCtrl.TabIndex = 1;
            this.managerPibCtrl.TextTitle = "ПІБ";
            this.managerPibCtrl.TextValue = "Прізвище КапецьякевеличезнеІм\'я Побатькові";
            // 
            // panelContactPerson
            // 
            this.panelContactPerson.Controls.Add(this.contactPersEmailCtrl);
            this.panelContactPerson.Controls.Add(this.contactPersPhoneCtrl);
            this.panelContactPerson.Controls.Add(this.contactPersPibCtrl);
            this.panelContactPerson.Location = new System.Drawing.Point(4, 84);
            this.panelContactPerson.Name = "panelContactPerson";
            this.panelContactPerson.Size = new System.Drawing.Size(507, 106);
            this.panelContactPerson.TabIndex = 3;
            // 
            // contactPersEmailCtrl
            // 
            this.contactPersEmailCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactPersEmailCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactPersEmailCtrl.Location = new System.Drawing.Point(181, 43);
            this.contactPersEmailCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.contactPersEmailCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.contactPersEmailCtrl.Name = "contactPersEmailCtrl";
            this.contactPersEmailCtrl.Size = new System.Drawing.Size(321, 35);
            this.contactPersEmailCtrl.SplitterRatio = 44;
            this.contactPersEmailCtrl.TabIndex = 5;
            this.contactPersEmailCtrl.TextTitle = "E-Mail";
            this.contactPersEmailCtrl.TextValue = "qwerty@qwer.ty";
            // 
            // contactPersPhoneCtrl
            // 
            this.contactPersPhoneCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactPersPhoneCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactPersPhoneCtrl.Location = new System.Drawing.Point(3, 43);
            this.contactPersPhoneCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.contactPersPhoneCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.contactPersPhoneCtrl.Name = "contactPersPhoneCtrl";
            this.contactPersPhoneCtrl.Size = new System.Drawing.Size(163, 35);
            this.contactPersPhoneCtrl.SplitterRatio = 50;
            this.contactPersPhoneCtrl.TabIndex = 2;
            this.contactPersPhoneCtrl.TextTitle = "Тел.";
            this.contactPersPhoneCtrl.TextValue = "+380999999999";
            // 
            // contactPersPibCtrl
            // 
            this.contactPersPibCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactPersPibCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactPersPibCtrl.Location = new System.Drawing.Point(3, 15);
            this.contactPersPibCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.contactPersPibCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.contactPersPibCtrl.Name = "contactPersPibCtrl";
            this.contactPersPibCtrl.Size = new System.Drawing.Size(499, 35);
            this.contactPersPibCtrl.SplitterRatio = 50;
            this.contactPersPibCtrl.TabIndex = 0;
            this.contactPersPibCtrl.TextTitle = "ПІБ";
            this.contactPersPibCtrl.TextValue = "Прізвище Ім\'я Побатькові";
            // 
            // organisationFormCtrl
            // 
            this.organisationFormCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.organisationFormCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.organisationFormCtrl.Location = new System.Drawing.Point(236, 44);
            this.organisationFormCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.organisationFormCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.organisationFormCtrl.Name = "organisationFormCtrl";
            this.organisationFormCtrl.Size = new System.Drawing.Size(270, 35);
            this.organisationFormCtrl.SplitterRatio = 140;
            this.organisationFormCtrl.TabIndex = 2;
            this.organisationFormCtrl.TextTitle = "Організаційна форма";
            this.organisationFormCtrl.TextValue = "ТОВ";
            this.organisationFormCtrl.Visible = false;
            // 
            // edrpouCtrl
            // 
            this.edrpouCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.edrpouCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.edrpouCtrl.Location = new System.Drawing.Point(6, 44);
            this.edrpouCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.edrpouCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.edrpouCtrl.Name = "edrpouCtrl";
            this.edrpouCtrl.Size = new System.Drawing.Size(223, 35);
            this.edrpouCtrl.SplitterRatio = 58;
            this.edrpouCtrl.TabIndex = 1;
            this.edrpouCtrl.TextTitle = "ЄДРПОУ";
            this.edrpouCtrl.TextValue = "46546545";
            // 
            // nameCtrl
            // 
            this.nameCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.nameCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.nameCtrl.Location = new System.Drawing.Point(7, 16);
            this.nameCtrl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.nameCtrl.MinimumSize = new System.Drawing.Size(150, 35);
            this.nameCtrl.Name = "nameCtrl";
            this.nameCtrl.Size = new System.Drawing.Size(499, 35);
            this.nameCtrl.SplitterRatio = 58;
            this.nameCtrl.TabIndex = 0;
            this.nameCtrl.TextTitle = "Назва";
            this.nameCtrl.TextValue = "ррррр";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(21, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(134, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Інформація користувача";
            // 
            // InformationOfUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.panelUserInfo);
            this.MaximumSize = new System.Drawing.Size(912, 209);
            this.MinimumSize = new System.Drawing.Size(912, 209);
            this.Name = "InformationOfUserControl";
            this.Size = new System.Drawing.Size(912, 209);
            ((System.ComponentModel.ISupportInitialize)(this.panelUserInfo)).EndInit();
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMeneger)).EndInit();
            this.panelMeneger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContactPerson)).EndInit();
            this.panelContactPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel panelUserInfo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private SingleShowInformationControl edrpouCtrl;
        private SingleShowInformationControl nameCtrl;
        private SingleShowInformationControl organisationFormCtrl;
        private Telerik.WinControls.UI.RadPanel panelContactPerson;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadPanel panelMeneger;
        private SingleShowInformationControl contactPersPibCtrl;
        private SingleShowInformationControl contactPersPhoneCtrl;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private SingleShowInformationControl groupholdingCtrl;
        private SingleShowInformationControl managerPhoneCtrl;
        private SingleShowInformationControl managerPibCtrl;
        private SingleShowInformationControl contactPersEmailCtrl;
        private SingleShowInformationControl managerEmail;
    }
}
