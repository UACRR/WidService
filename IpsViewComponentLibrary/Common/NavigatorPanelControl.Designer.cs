namespace IpsViewComponentLibrary.Common
{
    partial class NavigatorPanelControl
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.panel = new System.Windows.Forms.Panel();
            this.mebCountPerPage = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btnLast = new Telerik.WinControls.UI.RadButton();
            this.btnNext = new Telerik.WinControls.UI.RadButton();
            this.lblCountItem = new Telerik.WinControls.UI.RadLabel();
            this.mebPositionItem = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.btnPrev = new Telerik.WinControls.UI.RadButton();
            this.btnMoveFirst = new Telerik.WinControls.UI.RadButton();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mebCountPerPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCountItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mebPositionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.mebCountPerPage);
            this.panel.Controls.Add(this.radLabel4);
            this.panel.Controls.Add(this.btnLast);
            this.panel.Controls.Add(this.btnNext);
            this.panel.Controls.Add(this.lblCountItem);
            this.panel.Controls.Add(this.mebPositionItem);
            this.panel.Controls.Add(this.btnPrev);
            this.panel.Controls.Add(this.btnMoveFirst);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(350, 28);
            this.panel.TabIndex = 2;
            // 
            // mebCountPerPage
            // 
            this.mebCountPerPage.Location = new System.Drawing.Point(301, 3);
            this.mebCountPerPage.Mask = "N0";
            this.mebCountPerPage.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mebCountPerPage.Name = "mebCountPerPage";
            this.mebCountPerPage.Size = new System.Drawing.Size(45, 21);
            this.mebCountPerPage.TabIndex = 7;
            this.mebCountPerPage.TabStop = false;
            this.mebCountPerPage.Text = "0";
            this.mebCountPerPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mebCountPerPage.ThemeName = "Office2013Light";
            this.mebCountPerPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mebCountPerPage_KeyPress);
            this.mebCountPerPage.Leave += new System.EventHandler(this.mebCountPerPage_Leave);
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(203, 5);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(98, 19);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "К-ть на сторінку";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // btnLast
            // 
            this.btnLast.Image = global::IpsViewComponentLibrary.Properties.Resources.angle_double_right_solid;
            this.btnLast.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLast.Location = new System.Drawing.Point(178, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(21, 21);
            this.btnLast.TabIndex = 5;
            this.btnLast.ThemeName = "Office2013Light";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::IpsViewComponentLibrary.Properties.Resources.angle_right_solid;
            this.btnNext.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNext.Location = new System.Drawing.Point(154, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(21, 21);
            this.btnNext.TabIndex = 4;
            this.btnNext.ThemeName = "Office2013Light";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblCountItem
            // 
            this.lblCountItem.Location = new System.Drawing.Point(103, 5);
            this.lblCountItem.Name = "lblCountItem";
            this.lblCountItem.Size = new System.Drawing.Size(49, 19);
            this.lblCountItem.TabIndex = 3;
            this.lblCountItem.Text = " з 1000 ";
            this.lblCountItem.ThemeName = "Office2013Light";
            // 
            // mebPositionItem
            // 
            this.mebPositionItem.Location = new System.Drawing.Point(52, 3);
            this.mebPositionItem.Mask = "N0";
            this.mebPositionItem.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mebPositionItem.Name = "mebPositionItem";
            this.mebPositionItem.Size = new System.Drawing.Size(45, 21);
            this.mebPositionItem.TabIndex = 2;
            this.mebPositionItem.TabStop = false;
            this.mebPositionItem.Text = "0";
            this.mebPositionItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mebPositionItem.ThemeName = "Office2013Light";
            this.mebPositionItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mebPositionItem_KeyPress);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::IpsViewComponentLibrary.Properties.Resources.angle_left_solid;
            this.btnPrev.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrev.Location = new System.Drawing.Point(27, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(21, 21);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.ThemeName = "Office2013Light";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnMoveFirst
            // 
            this.btnMoveFirst.Image = global::IpsViewComponentLibrary.Properties.Resources.angle_double_left_solid;
            this.btnMoveFirst.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMoveFirst.Location = new System.Drawing.Point(3, 3);
            this.btnMoveFirst.Name = "btnMoveFirst";
            this.btnMoveFirst.Size = new System.Drawing.Size(21, 21);
            this.btnMoveFirst.TabIndex = 0;
            this.btnMoveFirst.ThemeName = "Office2013Light";
            this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
            // 
            // NavigatorPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel);
            this.Name = "NavigatorPanelControl";
            this.Size = new System.Drawing.Size(350, 28);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mebCountPerPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCountItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mebPositionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveFirst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.Panel panel;
        private Telerik.WinControls.UI.RadMaskedEditBox mebCountPerPage;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnLast;
        private Telerik.WinControls.UI.RadButton btnNext;
        private Telerik.WinControls.UI.RadLabel lblCountItem;
        private Telerik.WinControls.UI.RadMaskedEditBox mebPositionItem;
        private Telerik.WinControls.UI.RadButton btnPrev;
        private Telerik.WinControls.UI.RadButton btnMoveFirst;
    }
}
