namespace IpsViewComponentLibrary.Common
{
    partial class ConfirmationView
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
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnAccept = new Telerik.WinControls.UI.RadButton();
            this.txtInformation = new Telerik.WinControls.UI.RadTextBox();
            this.panelCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.BackColor = System.Drawing.Color.Silver;
            this.panelCommand.Controls.Add(this.btnClose);
            this.panelCommand.Controls.Add(this.btnAccept);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 408);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(693, 31);
            this.panelCommand.TabIndex = 37;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(580, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрити";
            this.btnClose.ThemeName = "Office2013Light";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(464, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Продовжити";
            this.btnAccept.ThemeName = "Office2013Light";
            this.btnAccept.Visible = false;
            // 
            // txtInformation
            // 
            this.txtInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformation.Location = new System.Drawing.Point(0, 3);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            // 
            // 
            // 
            this.txtInformation.RootElement.StretchVertically = true;
            this.txtInformation.Size = new System.Drawing.Size(693, 402);
            this.txtInformation.TabIndex = 38;
            this.txtInformation.ThemeName = "Office2013Light";
            // 
            // ConfirmationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(693, 439);
            this.Controls.Add(this.txtInformation);
            this.Controls.Add(this.panelCommand);
            this.Name = "ConfirmationView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ConfirmationView";
            this.ThemeName = "Office2013Light";
            this.panelCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.Panel panelCommand;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton btnAccept;
        private Telerik.WinControls.UI.RadTextBox txtInformation;
    }
}
