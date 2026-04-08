namespace SmartViewer
{
    partial class UcCustomerAffiliation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCustomerAffiliation));
            this.ucListViewBase = new SmartViewer.UcListViewBase();
            this.SuspendLayout();
            // 
            // ucListViewBase
            // 
            this.ucListViewBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucListViewBase.Location = new System.Drawing.Point(0, 0);
            this.ucListViewBase.Name = "ucListViewBase";
            this.ucListViewBase.Size = new System.Drawing.Size(791, 430);
            this.ucListViewBase.SqlSelect = resources.GetString("ucListViewBase.SqlSelect");
            this.ucListViewBase.TabIndex = 0;
            // 
            // UcCustomerAffiliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucListViewBase);
            this.Name = "UcCustomerAffiliation";
            this.Size = new System.Drawing.Size(791, 430);
            this.Load += new System.EventHandler(this.UcCustomerAffiliation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UcListViewBase ucListViewBase;
    }
}
