using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class AnketaConsumerPhisForm
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
            this.ctrlTabNavigationExpanded = new IpsViewComponentLibrary.Common.TabNavigationExpandedControl();
            this.ctrlAnketaConsumerPhis = new IpsViewComponentLibrary.ConsumerControls.AnketaConsumerPhis();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlTabNavigationExpanded
            // 
            this.ctrlTabNavigationExpanded.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigationExpanded.Location = new System.Drawing.Point(0, 671);
            this.ctrlTabNavigationExpanded.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigationExpanded.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigationExpanded.Name = "ctrlTabNavigationExpanded";
            this.ctrlTabNavigationExpanded.Size = new System.Drawing.Size(1192, 31);
            this.ctrlTabNavigationExpanded.TabIndex = 14;
            // 
            // ctrlAnketaConsumerPhis
            // 
            this.ctrlAnketaConsumerPhis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAnketaConsumerPhis.Location = new System.Drawing.Point(0, 0);
            this.ctrlAnketaConsumerPhis.Name = "ctrlAnketaConsumerPhis";
            this.ctrlAnketaConsumerPhis.Size = new System.Drawing.Size(1192, 671);
            this.ctrlAnketaConsumerPhis.TabIndex = 15;
            // 
            // AnketaConsumerPhisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1192, 702);
            this.Controls.Add(this.ctrlAnketaConsumerPhis);
            this.Controls.Add(this.ctrlTabNavigationExpanded);
            this.Name = "AnketaConsumerPhisForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Анкета користувача [фізична особа]";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private TabNavigationExpandedControl ctrlTabNavigationExpanded;
        private ConsumerControls.AnketaConsumerPhis ctrlAnketaConsumerPhis;
    }
}