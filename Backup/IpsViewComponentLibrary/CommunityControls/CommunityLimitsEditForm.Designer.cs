namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityLimitsEditForm
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
            this.components = new System.ComponentModel.Container();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.ctrlSaveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            this.ctrlRightLimitation = new IpsViewComponentLibrary.CommunityControls.CommunityRightLimitationControl();
            this.panelHeader = new Telerik.WinControls.UI.RadPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblCipherCode = new Telerik.WinControls.UI.RadLabel();
            this.lblIpi = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblRhName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.bsHeaderCommunityAuthorsView = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCipherCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIpi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRhName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHeaderCommunityAuthorsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlSaveCancel
            // 
            this.ctrlSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancel.Location = new System.Drawing.Point(0, 471);
            this.ctrlSaveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancel.Name = "ctrlSaveCancel";
            this.ctrlSaveCancel.Size = new System.Drawing.Size(884, 31);
            this.ctrlSaveCancel.TabIndex = 0;
            // 
            // ctrlRightLimitation
            // 
            this.ctrlRightLimitation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRightLimitation.Location = new System.Drawing.Point(0, 65);
            this.ctrlRightLimitation.Name = "ctrlRightLimitation";
            this.ctrlRightLimitation.Size = new System.Drawing.Size(884, 406);
            this.ctrlRightLimitation.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblRhName);
            this.panelHeader.Controls.Add(this.radLabel5);
            this.panelHeader.Controls.Add(this.lblIpi);
            this.panelHeader.Controls.Add(this.radLabel3);
            this.panelHeader.Controls.Add(this.lblCipherCode);
            this.panelHeader.Controls.Add(this.radLabel1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(884, 65);
            this.panelHeader.TabIndex = 2;
            this.panelHeader.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 4);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(40, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Шифр:";
            // 
            // lblCipherCode
            // 
            this.lblCipherCode.BorderVisible = true;
            this.lblCipherCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHeaderCommunityAuthorsView, "InnerCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.lblCipherCode.Location = new System.Drawing.Point(50, 4);
            this.lblCipherCode.MinimumSize = new System.Drawing.Size(125, 18);
            this.lblCipherCode.Name = "lblCipherCode";
            // 
            // 
            // 
            this.lblCipherCode.RootElement.MinSize = new System.Drawing.Size(125, 18);
            this.lblCipherCode.Size = new System.Drawing.Size(125, 18);
            this.lblCipherCode.TabIndex = 25;
            this.lblCipherCode.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblCipherCode.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblCipherCode.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblCipherCode.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblCipherCode.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblCipherCode.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // lblIpi
            // 
            this.lblIpi.BorderVisible = true;
            this.lblIpi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHeaderCommunityAuthorsView, "InterCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.lblIpi.Location = new System.Drawing.Point(208, 4);
            this.lblIpi.MinimumSize = new System.Drawing.Size(150, 18);
            this.lblIpi.Name = "lblIpi";
            // 
            // 
            // 
            this.lblIpi.RootElement.MinSize = new System.Drawing.Size(150, 18);
            this.lblIpi.Size = new System.Drawing.Size(150, 18);
            this.lblIpi.TabIndex = 27;
            this.lblIpi.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblIpi.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblIpi.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblIpi.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblIpi.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblIpi.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(181, 4);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(21, 18);
            this.radLabel3.TabIndex = 26;
            this.radLabel3.Text = "IPI:";
            // 
            // lblRhName
            // 
            this.lblRhName.BorderVisible = true;
            this.lblRhName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHeaderCommunityAuthorsView, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty));
            this.lblRhName.Location = new System.Drawing.Point(93, 28);
            this.lblRhName.MinimumSize = new System.Drawing.Size(300, 18);
            this.lblRhName.Name = "lblRhName";
            // 
            // 
            // 
            this.lblRhName.RootElement.MinSize = new System.Drawing.Size(300, 18);
            this.lblRhName.Size = new System.Drawing.Size(300, 18);
            this.lblRhName.TabIndex = 29;
            this.lblRhName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblRhName.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblRhName.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblRhName.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblRhName.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblRhName.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(4, 28);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(83, 18);
            this.radLabel5.TabIndex = 28;
            this.radLabel5.Text = "Правовласник:";
            // 
            // bsHeaderCommunityAuthorsView
            // 
            this.bsHeaderCommunityAuthorsView.DataSource = typeof(ipsFormsDesign.Interfaces.CommunityAuthorsView);
            // 
            // CommunityLimitsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 502);
            this.Controls.Add(this.ctrlRightLimitation);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.ctrlSaveCancel);
            this.Name = "CommunityLimitsEditForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Редагування обмеження прав правовласника";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCipherCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIpi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRhName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHeaderCommunityAuthorsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Common.SaveCancelButtonsControl ctrlSaveCancel;
        private CommunityRightLimitationControl ctrlRightLimitation;
        private Telerik.WinControls.UI.RadPanel panelHeader;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblCipherCode;
        private Telerik.WinControls.UI.RadLabel lblRhName;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel lblIpi;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.BindingSource bsHeaderCommunityAuthorsView;
    }
}
