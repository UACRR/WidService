namespace ipsAnketaClient
{
    partial class AddPremisesForm
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
            this.rBtnAdd = new Telerik.WinControls.UI.RadButton();
            this.rBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.lblTypePremisses = new Telerik.WinControls.UI.RadLabel();
            this.lblMetrsPlaceTxt = new Telerik.WinControls.UI.RadLabel();
            this.rtxtBoxTypePremisses = new Telerik.WinControls.UI.RadTextBox();
            this.rtxtBoxMetersPlaces = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMetrsPlaceTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxTypePremisses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMetersPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rBtnAdd
            // 
            this.rBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnAdd.Location = new System.Drawing.Point(13, 66);
            this.rBtnAdd.Name = "rBtnAdd";
            this.rBtnAdd.Size = new System.Drawing.Size(126, 24);
            this.rBtnAdd.TabIndex = 0;
            this.rBtnAdd.Text = "Додати приміщення";
            this.rBtnAdd.Click += new System.EventHandler(this.rBtnAdd_Click);
            // 
            // rBtnCancel
            // 
            this.rBtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnCancel.Location = new System.Drawing.Point(384, 66);
            this.rBtnCancel.Name = "rBtnCancel";
            this.rBtnCancel.Size = new System.Drawing.Size(110, 24);
            this.rBtnCancel.TabIndex = 1;
            this.rBtnCancel.Text = "Скасувати";
            this.rBtnCancel.Click += new System.EventHandler(this.rBtnCancel_Click);
            // 
            // lblTypePremisses
            // 
            this.lblTypePremisses.AutoSize = false;
            this.lblTypePremisses.Location = new System.Drawing.Point(13, 13);
            this.lblTypePremisses.Name = "lblTypePremisses";
            this.lblTypePremisses.Size = new System.Drawing.Size(93, 18);
            this.lblTypePremisses.TabIndex = 2;
            this.lblTypePremisses.Text = "Тип приміщення";
            this.lblTypePremisses.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMetrsPlaceTxt
            // 
            this.lblMetrsPlaceTxt.AutoSize = false;
            this.lblMetrsPlaceTxt.Location = new System.Drawing.Point(12, 37);
            this.lblMetrsPlaceTxt.Name = "lblMetrsPlaceTxt";
            this.lblMetrsPlaceTxt.Size = new System.Drawing.Size(93, 18);
            this.lblMetrsPlaceTxt.TabIndex = 3;
            this.lblMetrsPlaceTxt.Text = "Місць";
            this.lblMetrsPlaceTxt.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtxtBoxTypePremisses
            // 
            this.rtxtBoxTypePremisses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxTypePremisses.Location = new System.Drawing.Point(112, 12);
            this.rtxtBoxTypePremisses.Name = "rtxtBoxTypePremisses";
            this.rtxtBoxTypePremisses.Size = new System.Drawing.Size(382, 20);
            this.rtxtBoxTypePremisses.TabIndex = 4;
            // 
            // rtxtBoxMetersPlaces
            // 
            this.rtxtBoxMetersPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxMetersPlaces.Location = new System.Drawing.Point(112, 36);
            this.rtxtBoxMetersPlaces.Name = "rtxtBoxMetersPlaces";
            this.rtxtBoxMetersPlaces.Size = new System.Drawing.Size(97, 20);
            this.rtxtBoxMetersPlaces.TabIndex = 5;
            // 
            // AddPremisesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 102);
            this.Controls.Add(this.rtxtBoxMetersPlaces);
            this.Controls.Add(this.rtxtBoxTypePremisses);
            this.Controls.Add(this.lblMetrsPlaceTxt);
            this.Controls.Add(this.lblTypePremisses);
            this.Controls.Add(this.rBtnCancel);
            this.Controls.Add(this.rBtnAdd);
            this.MaximumSize = new System.Drawing.Size(514, 132);
            this.Name = "AddPremisesForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(514, 132);
            this.Text = "Додати приміщення закладу";
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTypePremisses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMetrsPlaceTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxTypePremisses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtBoxMetersPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton rBtnAdd;
        private Telerik.WinControls.UI.RadButton rBtnCancel;
        private Telerik.WinControls.UI.RadLabel lblTypePremisses;
        private Telerik.WinControls.UI.RadLabel lblMetrsPlaceTxt;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxTypePremisses;
        private Telerik.WinControls.UI.RadTextBox rtxtBoxMetersPlaces;
    }
}
