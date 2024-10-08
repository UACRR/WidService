
namespace WidExport
{
    partial class UcWidSubmWorkCheckList
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
            this.lvCheckList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvCheckList
            // 
            this.lvCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCheckList.FullRowSelect = true;
            this.lvCheckList.GridLines = true;
            this.lvCheckList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCheckList.HideSelection = false;
            this.lvCheckList.Location = new System.Drawing.Point(0, 0);
            this.lvCheckList.MultiSelect = false;
            this.lvCheckList.Name = "lvCheckList";
            this.lvCheckList.Size = new System.Drawing.Size(899, 410);
            this.lvCheckList.TabIndex = 0;
            this.lvCheckList.UseCompatibleStateImageBehavior = false;
            this.lvCheckList.View = System.Windows.Forms.View.Details;
            // 
            // UcWidSubmWorkCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvCheckList);
            this.Name = "UcWidSubmWorkCheckList";
            this.Size = new System.Drawing.Size(899, 410);
            this.Load += new System.EventHandler(this.UcCheckList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCheckList;
    }
}
