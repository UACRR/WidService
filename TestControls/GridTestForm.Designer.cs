namespace TestControls
{
    partial class GridTestForm
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
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.vgvMain = new Telerik.WinControls.UI.RadVirtualGrid();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton1.Location = new System.Drawing.Point(13, 460);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "radButton1";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton2.Location = new System.Drawing.Point(129, 460);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "radButton2";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton3
            // 
            this.radButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radButton3.Location = new System.Drawing.Point(245, 460);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(110, 24);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "radButton3";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // vgvMain
            // 
            this.vgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vgvMain.AutoScroll = true;
            this.vgvMain.Location = new System.Drawing.Point(12, 12);
            this.vgvMain.MasterViewInfo.AllowColumnSort = false;
            this.vgvMain.MasterViewInfo.AllowCut = false;
            this.vgvMain.MasterViewInfo.AllowDelete = false;
            this.vgvMain.MasterViewInfo.AllowEdit = false;
            this.vgvMain.MasterViewInfo.AllowPaste = false;
            this.vgvMain.MasterViewInfo.AutoSizeColumnsMode = Telerik.WinControls.UI.VirtualGridAutoSizeColumnsMode.Fill;
            this.vgvMain.MasterViewInfo.ColumnCount = 3;
            this.vgvMain.MasterViewInfo.ShowFilterRow = false;
            this.vgvMain.MasterViewInfo.ShowNewRow = false;
            this.vgvMain.Name = "vgvMain";
            this.vgvMain.SelectionMode = Telerik.WinControls.UI.VirtualGridSelectionMode.FullRowSelect;
            this.vgvMain.Size = new System.Drawing.Size(918, 442);
            this.vgvMain.TabIndex = 4;
            this.vgvMain.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadVirtualGridElement)(this.vgvMain.GetChildAt(0))).TextWrap = true;
            ((Telerik.WinControls.UI.VirtualGridTableElement)(this.vgvMain.GetChildAt(0).GetChildAt(0))).Text = "<html>Hello world!</html>";
            ((Telerik.WinControls.UI.VirtualRowsContainerElement)(this.vgvMain.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // GridTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 496);
            this.Controls.Add(this.vgvMain);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Name = "GridTestForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadVirtualGrid vgvMain;
    }
}
