using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    partial class ProlongationBigRight
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitleClientName = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAgrMain = new IpsViewComponentLibrary.ContractConsumerMainControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(440, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Користувач";
            // 
            // lblTitleClientName
            // 
            this.lblTitleClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleClientName.AutoSize = false;
            this.lblTitleClientName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleClientName.Location = new System.Drawing.Point(89, 12);
            this.lblTitleClientName.Name = "lblTitleClientName";
            this.lblTitleClientName.Padding = new System.Windows.Forms.Padding(0, 0, 60, 0);
            this.lblTitleClientName.Size = new System.Drawing.Size(435, 22);
            this.lblTitleClientName.TabIndex = 22;
            this.lblTitleClientName.Text = "Назва «Клієнта»";
            this.lblTitleClientName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlAgrMain
            // 
            this.ctrlAgrMain.AgreementLabelType = ipsFormsDesign.Dictionary.TypeRights.BigRights;
            this.ctrlAgrMain.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            this.ctrlAgrMain.DataSourceBr = typeof(ipsFormsDesign.Model.AgreementAddBr);
            this.ctrlAgrMain.DateEndNullDate = new System.DateTime(((long)(0)));
            this.ctrlAgrMain.DateTimeType = ConsumerAgreementInitType.None;
            this.ctrlAgrMain.Location = new System.Drawing.Point(12, 40);
            this.ctrlAgrMain.MaximumSize = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.Name = "ctrlAgrMain";
            this.ctrlAgrMain.Size = new System.Drawing.Size(477, 49);
            this.ctrlAgrMain.TabIndex = 24;
            // 
            // ProlongationBigRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 152);
            this.Controls.Add(this.ctrlAgrMain);
            this.Controls.Add(this.lblTitleClientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(500, 183);
            this.Name = "ProlongationBigRight";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пролонгація";
            this.ThemeName = "Office2013Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProlongationBigRight_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitleClientName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadLabel lblTitleClientName;
        private ContractConsumerMainControl ctrlAgrMain;
    }
}
