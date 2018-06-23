namespace IpsViewComponentLibrary
{
    partial class RightholderSelectorControl
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
            this.lblBirthDate = new Telerik.WinControls.UI.RadLabel();
            this.btnAnketa = new Telerik.WinControls.UI.RadButton();
            this.lblProfit = new Telerik.WinControls.UI.RadLabel();
            this.ddlSelectedRightholder = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnketa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelectedRightholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBirthDate.Location = new System.Drawing.Point(435, 2);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(86, 25);
            this.lblBirthDate.TabIndex = 1;
            this.lblBirthDate.Text = "10.07.1957";
            this.lblBirthDate.ThemeName = "Office2013Light";
            // 
            // btnAnketa
            // 
            this.btnAnketa.Location = new System.Drawing.Point(775, 4);
            this.btnAnketa.Name = "btnAnketa";
            this.btnAnketa.Size = new System.Drawing.Size(110, 21);
            this.btnAnketa.TabIndex = 3;
            this.btnAnketa.Text = "Анкета";
            this.btnAnketa.ThemeName = "Office2013Light";
            this.btnAnketa.Click += new System.EventHandler(this.btnAnketa_Click);
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = false;
            this.lblProfit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProfit.Location = new System.Drawing.Point(660, 2);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(109, 25);
            this.lblProfit.TabIndex = 2;
            this.lblProfit.Text = "200 000,00";
            this.lblProfit.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lblProfit.ThemeName = "Office2013Light";
            // 
            // ddlSelectedRightholder
            // 
            this.ddlSelectedRightholder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlSelectedRightholder.Location = new System.Drawing.Point(96, 4);
            this.ddlSelectedRightholder.Name = "ddlSelectedRightholder";
            this.ddlSelectedRightholder.ReadOnly = true;
            this.ddlSelectedRightholder.Size = new System.Drawing.Size(333, 21);
            this.ddlSelectedRightholder.TabIndex = 60;
            this.ddlSelectedRightholder.ThemeName = "Office2013Light";
            this.ddlSelectedRightholder.PopupOpening += new System.ComponentModel.CancelEventHandler(this.ddlSelectedRightholder_PopupOpening);
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(7, 5);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(83, 18);
            this.radLabel11.TabIndex = 61;
            this.radLabel11.Text = "Правовласник:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(537, 5);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(117, 18);
            this.radLabel2.TabIndex = 62;
            this.radLabel2.Text = "Дохід з початку року:";
            // 
            // RightholderSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ddlSelectedRightholder);
            this.Controls.Add(this.radLabel11);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.btnAnketa);
            this.Controls.Add(this.lblBirthDate);
            this.Name = "RightholderSelectorControl";
            this.Size = new System.Drawing.Size(889, 29);
            ((System.ComponentModel.ISupportInitialize)(this.lblBirthDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnketa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelectedRightholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel lblBirthDate;
        private Telerik.WinControls.UI.RadButton btnAnketa;
        private Telerik.WinControls.UI.RadLabel lblProfit;
        private Telerik.WinControls.UI.RadDropDownList ddlSelectedRightholder;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
