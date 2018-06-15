namespace IpsViewComponentLibrary
{
    partial class RightholderPersonInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new Telerik.WinControls.UI.RadLabel();
            this.lblBirthDate = new Telerik.WinControls.UI.RadLabel();
            this.lblSex = new Telerik.WinControls.UI.RadLabel();
            this.btnAnketa = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnketa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(4, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(167, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ivanov Ivan Ivanovych";
            this.lblName.ThemeName = "Office2013Light";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBirthDate.Location = new System.Drawing.Point(266, 4);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(86, 25);
            this.lblBirthDate.TabIndex = 1;
            this.lblBirthDate.Text = "10.07.1957";
            this.lblBirthDate.ThemeName = "Office2013Light";
            // 
            // lblSex
            // 
            this.lblSex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSex.Location = new System.Drawing.Point(378, 4);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(44, 25);
            this.lblSex.TabIndex = 2;
            this.lblSex.Text = "Male";
            this.lblSex.ThemeName = "Office2013Light";
            // 
            // btnAnketa
            // 
            this.btnAnketa.Location = new System.Drawing.Point(461, 4);
            this.btnAnketa.Name = "btnAnketa";
            this.btnAnketa.Size = new System.Drawing.Size(110, 24);
            this.btnAnketa.TabIndex = 3;
            this.btnAnketa.Text = "Анкета";
            this.btnAnketa.ThemeName = "Office2013Light";
            // 
            // RightholderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAnketa);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblName);
            this.Name = "RightholderInfo";
            this.Size = new System.Drawing.Size(574, 31);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnketa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblName;
        private Telerik.WinControls.UI.RadLabel lblBirthDate;
        private Telerik.WinControls.UI.RadLabel lblSex;
        private Telerik.WinControls.UI.RadButton btnAnketa;
    }
}
