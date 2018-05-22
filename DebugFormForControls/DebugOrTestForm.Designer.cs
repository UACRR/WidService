namespace DebugFormForControls
{
    partial class DebugOrTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnActionOne = new Telerik.WinControls.UI.RadButton();
            this.BtnActionSecond = new Telerik.WinControls.UI.RadButton();
            this.anketaPersonRightHolderControl1 = new DebugFormForControls.AnketaPersonRightHolderControl();
            this.passportControl1 = new IpsViewComponentLibrary.PassportControl();
            this.contractConsumerMainControl1 = new IpsViewComponentLibrary.ContractConsumerMainControl();
            this.contactsPersonControl1 = new DebugFormForControls.ContactsPersonControl();
            this.anketaPersonControl1 = new DebugFormForControls.AnketaPersonControl();
            this.registrationPersonsControl1 = new IpsViewComponentLibrary.RegistrationPersonsControl();
            ((System.ComponentModel.ISupportInitialize)(this.BtnActionOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnActionSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnActionOne
            // 
            this.BtnActionOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnActionOne.Location = new System.Drawing.Point(13, 536);
            this.BtnActionOne.Name = "BtnActionOne";
            this.BtnActionOne.Size = new System.Drawing.Size(110, 24);
            this.BtnActionOne.TabIndex = 1;
            this.BtnActionOne.Text = "Кнопка";
            this.BtnActionOne.Click += new System.EventHandler(this.BtnActionOne_Click);
            // 
            // BtnActionSecond
            // 
            this.BtnActionSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnActionSecond.Location = new System.Drawing.Point(140, 536);
            this.BtnActionSecond.Name = "BtnActionSecond";
            this.BtnActionSecond.Size = new System.Drawing.Size(110, 24);
            this.BtnActionSecond.TabIndex = 2;
            this.BtnActionSecond.Text = "Додаткова кнопка";
            this.BtnActionSecond.Click += new System.EventHandler(this.BtnActionSecond_Click);
            // 
            // anketaPersonRightHolderControl1
            // 
            this.anketaPersonRightHolderControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            this.anketaPersonRightHolderControl1.DataSourceDropList = 0;
            this.anketaPersonRightHolderControl1.Location = new System.Drawing.Point(13, 125);
            this.anketaPersonRightHolderControl1.MaximumSize = new System.Drawing.Size(900, 128);
            this.anketaPersonRightHolderControl1.Name = "anketaPersonRightHolderControl1";
            this.anketaPersonRightHolderControl1.Size = new System.Drawing.Size(645, 128);
            this.anketaPersonRightHolderControl1.TabIndex = 8;
            // 
            // passportControl1
            // 
            this.passportControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            this.passportControl1.Location = new System.Drawing.Point(12, 371);
            this.passportControl1.MaximumSize = new System.Drawing.Size(410, 94);
            this.passportControl1.Name = "passportControl1";
            this.passportControl1.Size = new System.Drawing.Size(410, 94);
            this.passportControl1.TabIndex = 7;
            // 
            // contractConsumerMainControl1
            // 
            this.contractConsumerMainControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IAgreementMaster);
            this.contractConsumerMainControl1.Location = new System.Drawing.Point(12, 315);
            this.contractConsumerMainControl1.MaximumSize = new System.Drawing.Size(477, 49);
            this.contractConsumerMainControl1.Name = "contractConsumerMainControl1";
            this.contractConsumerMainControl1.Size = new System.Drawing.Size(477, 49);
            this.contractConsumerMainControl1.TabIndex = 6;
            // 
            // contactsPersonControl1
            // 
            this.contactsPersonControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            this.contactsPersonControl1.Location = new System.Drawing.Point(12, 258);
            this.contactsPersonControl1.MaximumSize = new System.Drawing.Size(625, 50);
            this.contactsPersonControl1.Name = "contactsPersonControl1";
            this.contactsPersonControl1.Size = new System.Drawing.Size(625, 50);
            this.contactsPersonControl1.TabIndex = 4;
            // 
            // anketaPersonControl1
            // 
            this.anketaPersonControl1.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaPerson);
            this.anketaPersonControl1.DataSourceDropList = 0;
            this.anketaPersonControl1.Location = new System.Drawing.Point(13, 13);
            this.anketaPersonControl1.MaximumSize = new System.Drawing.Size(900, 105);
            this.anketaPersonControl1.Name = "anketaPersonControl1";
            this.anketaPersonControl1.Size = new System.Drawing.Size(645, 105);
            this.anketaPersonControl1.TabIndex = 3;
            // 
            // registrationPersonsControl1
            // 
            this.registrationPersonsControl1.Location = new System.Drawing.Point(495, 315);
            this.registrationPersonsControl1.Name = "registrationPersonsControl1";
            this.registrationPersonsControl1.Size = new System.Drawing.Size(416, 53);
            this.registrationPersonsControl1.TabIndex = 9;
            // 
            // DebugOrTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 572);
            this.Controls.Add(this.registrationPersonsControl1);
            this.Controls.Add(this.anketaPersonRightHolderControl1);
            this.Controls.Add(this.passportControl1);
            this.Controls.Add(this.contractConsumerMainControl1);
            this.Controls.Add(this.contactsPersonControl1);
            this.Controls.Add(this.anketaPersonControl1);
            this.Controls.Add(this.BtnActionSecond);
            this.Controls.Add(this.BtnActionOne);
            this.Name = "DebugOrTestForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Хабіб";
            ((System.ComponentModel.ISupportInitialize)(this.BtnActionOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnActionSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton BtnActionOne;
        private Telerik.WinControls.UI.RadButton BtnActionSecond;
        private AnketaPersonControl anketaPersonControl1;
        private ContactsPersonControl contactsPersonControl1;
        private IpsViewComponentLibrary.ContractConsumerMainControl contractConsumerMainControl1;
        private IpsViewComponentLibrary.PassportControl passportControl1;
        private AnketaPersonRightHolderControl anketaPersonRightHolderControl1;
        private IpsViewComponentLibrary.RegistrationPersonsControl registrationPersonsControl1;
    }
}