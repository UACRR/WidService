using System.Drawing;
using sysAdminwp;

namespace ipsTestExp
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.radPageViewMain = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPMain = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPVPageDictTest = new Telerik.WinControls.UI.RadPageViewPage();
            this.dataEditControl = new sysAdminwp.DataEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewMain)).BeginInit();
            this.radPageViewMain.SuspendLayout();
            this.radPVPageDictTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageViewMain
            // 
            this.radPageViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageViewMain.Controls.Add(this.radPageViewPMain);
            this.radPageViewMain.Controls.Add(this.radPVPageDictTest);
            this.radPageViewMain.DefaultPage = this.radPageViewPMain;
            this.radPageViewMain.Location = new System.Drawing.Point(-2, 2);
            this.radPageViewMain.Name = "radPageViewMain";
            this.radPageViewMain.SelectedPage = this.radPVPageDictTest;
            this.radPageViewMain.Size = new System.Drawing.Size(1172, 614);
            this.radPageViewMain.TabIndex = 0;
            this.radPageViewMain.ThemeName = "ControlDefault";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageViewMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPMain
            // 
            this.radPageViewPMain.ItemSize = new System.Drawing.SizeF(55F, 24F);
            this.radPageViewPMain.Location = new System.Drawing.Point(10, 33);
            this.radPageViewPMain.Name = "radPageViewPMain";
            this.radPageViewPMain.Size = new System.Drawing.Size(1151, 570);
            this.radPageViewPMain.Text = "Головна";
            // 
            // radPVPageDictTest
            // 
            this.radPVPageDictTest.Controls.Add(this.dataEditControl);
            this.radPVPageDictTest.ItemSize = new System.Drawing.SizeF(75F, 24F);
            this.radPVPageDictTest.Location = new System.Drawing.Point(10, 33);
            this.radPVPageDictTest.Name = "radPVPageDictTest";
            this.radPVPageDictTest.Size = new System.Drawing.Size(1151, 570);
            this.radPVPageDictTest.Text = "Довідники+";
            // 
            // dataEditControl
            // 
            this.dataEditControl.Enabled = false;
            this.dataEditControl.Location = new System.Drawing.Point(203, 3);
            this.dataEditControl.Name = "dataEditControl";
            this.dataEditControl.Size = new System.Drawing.Size(943, 559);
            this.dataEditControl.TabIndex = 0;
            this.dataEditControl.Url = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 613);
            this.Controls.Add(this.radPageViewMain);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "IPS";
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewMain)).EndInit();
            this.radPageViewMain.ResumeLayout(false);
            this.radPVPageDictTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageViewMain;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPMain;
        private Telerik.WinControls.UI.RadPageViewPage radPVPageDictTest;
        private sysAdminwp.DataEditControl dataEditControl;

    }
}

