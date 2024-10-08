
namespace WidExport
{
    partial class UcWidSubmWorkShares
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
            this.panelShares = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lvShares = new System.Windows.Forms.ListView();
            this.lvShareDetails = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.panelShares)).BeginInit();
            this.panelShares.Panel1.SuspendLayout();
            this.panelShares.Panel2.SuspendLayout();
            this.panelShares.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelShares
            // 
            this.panelShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShares.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelShares.Location = new System.Drawing.Point(0, 0);
            this.panelShares.Name = "panelShares";
            // 
            // panelShares.Panel1
            // 
            this.panelShares.Panel1.Controls.Add(this.panelLeft);
            // 
            // panelShares.Panel2
            // 
            this.panelShares.Panel2.Controls.Add(this.lvShareDetails);
            this.panelShares.Size = new System.Drawing.Size(943, 489);
            this.panelShares.SplitterDistance = 543;
            this.panelShares.TabIndex = 5;
            // 
            // panelLeft
            // 
            this.panelLeft.ColumnCount = 1;
            this.panelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.Controls.Add(this.lvShares, 0, 0);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RowCount = 2;
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelLeft.Size = new System.Drawing.Size(543, 489);
            this.panelLeft.TabIndex = 0;
            // 
            // lvShares
            // 
            this.lvShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShares.FullRowSelect = true;
            this.lvShares.GridLines = true;
            this.lvShares.HideSelection = false;
            this.lvShares.Location = new System.Drawing.Point(3, 3);
            this.lvShares.MultiSelect = false;
            this.lvShares.Name = "lvShares";
            this.lvShares.Size = new System.Drawing.Size(537, 475);
            this.lvShares.TabIndex = 1;
            this.lvShares.UseCompatibleStateImageBehavior = false;
            this.lvShares.View = System.Windows.Forms.View.Details;
            this.lvShares.SelectedIndexChanged += new System.EventHandler(this.lvShares_SelectedIndexChanged);
            // 
            // lvShareDetails
            // 
            this.lvShareDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShareDetails.FullRowSelect = true;
            this.lvShareDetails.HideSelection = false;
            this.lvShareDetails.Location = new System.Drawing.Point(0, 0);
            this.lvShareDetails.MultiSelect = false;
            this.lvShareDetails.Name = "lvShareDetails";
            this.lvShareDetails.Size = new System.Drawing.Size(396, 489);
            this.lvShareDetails.TabIndex = 0;
            this.lvShareDetails.UseCompatibleStateImageBehavior = false;
            this.lvShareDetails.View = System.Windows.Forms.View.Details;
            // 
            // UcWidSubmWorkShares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelShares);
            this.Name = "UcWidSubmWorkShares";
            this.Size = new System.Drawing.Size(943, 489);
            this.Load += new System.EventHandler(this.UcWidSubmWorkShares_Load);
            this.panelShares.Panel1.ResumeLayout(false);
            this.panelShares.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelShares)).EndInit();
            this.panelShares.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer panelShares;
        private System.Windows.Forms.ListView lvShares;
        private System.Windows.Forms.ListView lvShareDetails;
        private System.Windows.Forms.TableLayoutPanel panelLeft;
    }
}
