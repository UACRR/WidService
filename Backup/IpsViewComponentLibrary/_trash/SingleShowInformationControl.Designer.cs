namespace IpsViewComponentLibrary
{
    partial class SingleShowInformationControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbltxtName = new System.Windows.Forms.Label();
            this.txtShow = new Telerik.WinControls.UI.RadLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.radSeparator = new Telerik.WinControls.UI.RadSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.txtShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltxtName
            // 
            this.lbltxtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltxtName.CausesValidation = false;
            this.lbltxtName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbltxtName.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lbltxtName.Location = new System.Drawing.Point(0, 0);
            this.lbltxtName.Name = "lbltxtName";
            this.lbltxtName.Size = new System.Drawing.Size(91, 28);
            this.lbltxtName.TabIndex = 3;
            this.lbltxtName.Text = "Титул текст";
            this.lbltxtName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShow
            // 
            this.txtShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShow.AutoSize = false;
            this.txtShow.CausesValidation = false;
            this.txtShow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtShow.Location = new System.Drawing.Point(0, 0);
            this.txtShow.Name = "txtShow";
            this.txtShow.Size = new System.Drawing.Size(233, 28);
            this.txtShow.TabIndex = 2;
            this.txtShow.ThemeName = "Office2013Light";
            // 
            // splitContainer
            // 
            this.splitContainer.CausesValidation = false;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.MaximumSize = new System.Drawing.Size(1000, 50);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lbltxtName);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer.Panel2.CausesValidation = false;
            this.splitContainer.Panel2.Controls.Add(this.radSeparator);
            this.splitContainer.Panel2.Controls.Add(this.txtShow);
            this.splitContainer.Size = new System.Drawing.Size(328, 28);
            this.splitContainer.SplitterDistance = 91;
            this.splitContainer.TabIndex = 4;
            // 
            // radSeparator
            // 
            this.radSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeparator.Location = new System.Drawing.Point(-1, 19);
            this.radSeparator.Name = "radSeparator";
            // 
            // 
            // 
            this.radSeparator.RootElement.ControlBounds = new System.Drawing.Rectangle(-1, 19, 200, 4);
            this.radSeparator.Size = new System.Drawing.Size(234, 10);
            this.radSeparator.TabIndex = 5;
            this.radSeparator.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.SeparatorElement)(this.radSeparator.GetChildAt(0))).BorderWidth = 3F;
            ((Telerik.WinControls.UI.SeparatorElement)(this.radSeparator.GetChildAt(0))).BorderTopWidth = 3F;
            ((Telerik.WinControls.UI.SeparatorElement)(this.radSeparator.GetChildAt(0))).BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            ((Telerik.WinControls.UI.SeparatorElement)(this.radSeparator.GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            ((Telerik.WinControls.UI.SeparatorElement)(this.radSeparator.GetChildAt(0))).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            ((Telerik.WinControls.UI.SeparatorElement)(this.radSeparator.GetChildAt(0))).BorderHighlightThickness = 1;
            ((Telerik.WinControls.UI.SeparatorElement)(this.radSeparator.GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).LineWidth = 3;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).SeparatorOrientation = Telerik.WinControls.SepOrientation.Horizontal;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).SweepAngle = 0;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentPadding;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).GradientAngle = 90F;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).GradientPercentage = 0.1934156F;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).GradientPercentage2 = 0.8045267F;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.BottomCenter;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(1))).SeparatorOrientation = Telerik.WinControls.SepOrientation.Horizontal;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(1))).SweepAngle = 0;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentPadding;
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            ((Telerik.WinControls.Primitives.LinePrimitive)(this.radSeparator.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // SingleShowInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1000, 28);
            this.MinimumSize = new System.Drawing.Size(150, 25);
            this.Name = "SingleShowInformationControl";
            this.Size = new System.Drawing.Size(328, 28);
            ((System.ComponentModel.ISupportInitialize)(this.txtShow)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbltxtName;
        private Telerik.WinControls.UI.RadLabel txtShow;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Telerik.WinControls.UI.RadSeparator radSeparator;
    }
}
