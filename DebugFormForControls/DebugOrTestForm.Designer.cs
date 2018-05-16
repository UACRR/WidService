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
            this.contactsPersonControl1 = new DebugFormForControls.ContactsPersonControl();
            ((System.ComponentModel.ISupportInitialize)(this.BtnActionOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnActionSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnActionOne
            // 
            this.BtnActionOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnActionOne.Location = new System.Drawing.Point(13, 407);
            this.BtnActionOne.Name = "BtnActionOne";
            this.BtnActionOne.Size = new System.Drawing.Size(110, 24);
            this.BtnActionOne.TabIndex = 1;
            this.BtnActionOne.Text = "Кнопка";
            this.BtnActionOne.Click += new System.EventHandler(this.BtnActionOne_Click);
            // 
            // BtnActionSecond
            // 
            this.BtnActionSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnActionSecond.Location = new System.Drawing.Point(140, 407);
            this.BtnActionSecond.Name = "BtnActionSecond";
            this.BtnActionSecond.Size = new System.Drawing.Size(110, 24);
            this.BtnActionSecond.TabIndex = 2;
            this.BtnActionSecond.Text = "Додаткова кнопка";
            this.BtnActionSecond.Click += new System.EventHandler(this.BtnActionSecond_Click);
            // 
            // anketaPersonRightHolderControl1
            // 
            this.anketaPersonRightHolderControl1.Location = new System.Drawing.Point(13, 13);
            this.anketaPersonRightHolderControl1.MaximumSize = new System.Drawing.Size(900, 128);
            this.anketaPersonRightHolderControl1.Name = "anketaPersonRightHolderControl1";
            this.anketaPersonRightHolderControl1.Size = new System.Drawing.Size(625, 128);
            this.anketaPersonRightHolderControl1.TabIndex = 3;
            // 
            // contactsPersonControl1
            // 
            this.contactsPersonControl1.Location = new System.Drawing.Point(13, 200);
            this.contactsPersonControl1.MaximumSize = new System.Drawing.Size(625, 50);
            this.contactsPersonControl1.Name = "contactsPersonControl1";
            this.contactsPersonControl1.Size = new System.Drawing.Size(625, 50);
            this.contactsPersonControl1.TabIndex = 4;
            // 
            // DebugOrTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 443);
            this.Controls.Add(this.contactsPersonControl1);
            this.Controls.Add(this.anketaPersonRightHolderControl1);
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
        private AnketaPersonRightHolderControl anketaPersonRightHolderControl1;
        private ContactsPersonControl contactsPersonControl1;
    }
}