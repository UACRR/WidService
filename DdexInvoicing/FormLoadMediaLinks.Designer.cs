namespace DdexInvoicing
{
    partial class FormLoadMediaLinks
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoad = new Telerik.WinControls.UI.RadButton();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.ColumnCount = 3;
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelBottom.Controls.Add(this.btnLoad, 1, 0);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 412);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.RowCount = 1;
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.Size = new System.Drawing.Size(794, 35);
            this.panelBottom.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(668, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 29);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Завантажити";
            // 
            // FormLoadMediaLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLoadMediaLinks";
            this.Text = "Завантажити посилання на відео";
            this.panelMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelBottom;
        private Telerik.WinControls.UI.RadButton btnLoad;
    }
}