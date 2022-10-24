using IpsViewComponentLibrary.ConsumerControls.BigRight;

namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class CabinetBigRightForm
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
            this.cabinet = new IpsViewComponentLibrary.ConsumerControls.BigRight.CabinetBigRight();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cabinet
            // 
            this.cabinet.AutoScroll = true;
            this.cabinet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cabinet.Location = new System.Drawing.Point(0, 0);
            this.cabinet.Margin = new System.Windows.Forms.Padding(4);
            this.cabinet.Name = "cabinet";
            this.cabinet.Size = new System.Drawing.Size(1141, 514);
            this.cabinet.TabIndex = 0;
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.AssociatedControl = this.cabinet;
            this.radWaitingBar1.Location = new System.Drawing.Point(543, 214);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(88, 88);
            this.radWaitingBar1.TabIndex = 1;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingSpeed = 50;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            // 
            // CabinetBigRightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1141, 514);
            this.Controls.Add(this.radWaitingBar1);
            this.Controls.Add(this.cabinet);
            this.Name = "CabinetBigRightForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Кабінет користувача";
            this.ThemeName = "Office2013Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CabinetBigRightForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        public CabinetBigRight cabinet;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        public Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
    }
}
