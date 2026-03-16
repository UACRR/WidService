namespace WidSubmit
{
    partial class FormTest
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
            this.lvSubmWorkShares = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvSubmWorkShares
            // 
            this.lvSubmWorkShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubmWorkShares.HideSelection = false;
            this.lvSubmWorkShares.Location = new System.Drawing.Point(0, 0);
            this.lvSubmWorkShares.Name = "lvSubmWorkShares";
            this.lvSubmWorkShares.OwnerDraw = true;
            this.lvSubmWorkShares.Size = new System.Drawing.Size(800, 450);
            this.lvSubmWorkShares.TabIndex = 0;
            this.lvSubmWorkShares.UseCompatibleStateImageBehavior = false;
            this.lvSubmWorkShares.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvSubmWorkShares_DrawColumnHeader);
            this.lvSubmWorkShares.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvSubmWorkShares_DrawItem);
            this.lvSubmWorkShares.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvSubmWorkShares_DrawSubItem);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvSubmWorkShares);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvSubmWorkShares;
    }
}