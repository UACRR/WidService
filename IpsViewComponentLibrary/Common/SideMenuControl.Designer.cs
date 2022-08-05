namespace IpsViewComponentLibrary.Common
{
    partial class SideMenuControl
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
            this.tvMenu = new Telerik.WinControls.UI.RadTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.tvMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // tvMenu
            // 
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.ShowExpandCollapse = false;
            this.tvMenu.Size = new System.Drawing.Size(209, 537);
            this.tvMenu.TabIndex = 1;
            this.tvMenu.ThemeName = "Office2013Light";
            this.tvMenu.ToggleMode = Telerik.WinControls.UI.ToggleMode.None;
            this.tvMenu.SelectedNodeChanging += new Telerik.WinControls.UI.RadTreeView.RadTreeViewCancelEventHandler(this.tvMenu_SelectedNodeChanging);
            this.tvMenu.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.tvMenu_SelectedNodeChanged);
            this.tvMenu.NodeFormatting += new Telerik.WinControls.UI.TreeNodeFormattingEventHandler(this.tvMenu_NodeFormatting);
            // 
            // SideMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tvMenu);
            this.Name = "SideMenuControl";
            this.Size = new System.Drawing.Size(209, 537);
            ((System.ComponentModel.ISupportInitialize)(this.tvMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView tvMenu;
    }
}
