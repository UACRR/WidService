using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.ConsumerControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    partial class AnketaConsumerJurForm
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
            this.ctrlTabNavigationExpanded = new TabNavigationExpandedControl();
            this.ctrlConsumerAnketa = new IpsViewComponentLibrary.ConsumerControls.AnketaConsumer();
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
            this.ctrlTabNavigationExpanded.TabIndex = 15;
            // 
            // ctrlConsumerAnketa
            // 
            this.ctrlConsumerAnketa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlConsumerAnketa.Location = new System.Drawing.Point(0, 0);
            this.ctrlConsumerAnketa.Name = "ctrlConsumerAnketa";
            this.ctrlConsumerAnketa.Size = new System.Drawing.Size(1192, 671);
            this.ctrlConsumerAnketa.TabIndex = 0;
            this.ctrlConsumerAnketa.TypeRights = ipsFormsDesign.Dictionary.TypeRights.SmallRights;
            // 
            // AnketaConsumerJurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1192, 702);
            this.Controls.Add(this.ctrlConsumerAnketa);
            this.Controls.Add(this.ctrlTabNavigationExpanded);
            this.Name = "AnketaConsumerJurForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Анкета користувача [юридична особа]";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AnketaConsumer ctrlConsumerAnketa;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private TabNavigationExpandedControl ctrlTabNavigationExpanded;
    }
}
