namespace Fixation
{
    partial class FixationForm
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
            this.fixationListControl1 = new IpsViewComponentLibrary.FixationControls.FixationListControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // fixationListControl1
            // 
            this.fixationListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixationListControl1.FixationDataSource = typeof(ipsFormsDesign.ViewModels.Fixations.FixationListViewModel);
            this.fixationListControl1.Location = new System.Drawing.Point(0, 0);
            this.fixationListControl1.Name = "fixationListControl1";
            this.fixationListControl1.SelectedFixation = null;
            this.fixationListControl1.Size = new System.Drawing.Size(1227, 609);
            this.fixationListControl1.TabIndex = 0;
            // 
            // FixationForm
            // 
            this.AccessibleDescription = "Violation";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1227, 609);
            this.Controls.Add(this.fixationListControl1);
            this.Name = "FixationForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Фіксація порушень";
            this.ThemeName = "Office2013Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IpsViewComponentLibrary.FixationControls.FixationListControl fixationListControl1;
    }
}