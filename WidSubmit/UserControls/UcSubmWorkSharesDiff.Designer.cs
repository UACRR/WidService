namespace WidSubmit
{
    partial class UcSubmWorkSharesDiff
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSubmWorkSharesDiff));
            this.lvShareDiff = new System.Windows.Forms.ListView();
            this.ilChangeType = new System.Windows.Forms.ImageList(this.components);
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lvNameDiff = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvShareDiff
            // 
            this.lvShareDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShareDiff.HideSelection = false;
            this.lvShareDiff.Location = new System.Drawing.Point(3, 147);
            this.lvShareDiff.Name = "lvShareDiff";
            this.lvShareDiff.Size = new System.Drawing.Size(633, 200);
            this.lvShareDiff.SmallImageList = this.ilChangeType;
            this.lvShareDiff.TabIndex = 0;
            this.lvShareDiff.UseCompatibleStateImageBehavior = false;
            this.lvShareDiff.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvShareDiff_ItemSelectionChanged);
            this.lvShareDiff.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvSubmWorkShares_MouseDown);
            // 
            // ilChangeType
            // 
            this.ilChangeType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilChangeType.ImageStream")));
            this.ilChangeType.TransparentColor = System.Drawing.Color.Transparent;
            this.ilChangeType.Images.SetKeyName(0, "icons8-equals-16.png");
            this.ilChangeType.Images.SetKeyName(1, "icons8-add-16.png");
            this.ilChangeType.Images.SetKeyName(2, "icons8-update-done-16.png");
            this.ilChangeType.Images.SetKeyName(3, "icons8-delete-16.png");
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.lvShareDiff, 0, 6);
            this.panelMain.Controls.Add(this.lvNameDiff, 0, 4);
            this.panelMain.Controls.Add(this.label1, 0, 3);
            this.panelMain.Controls.Add(this.label2, 0, 5);
            this.panelMain.Controls.Add(this.label3, 0, 1);
            this.panelMain.Controls.Add(this.label4, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 7;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Size = new System.Drawing.Size(644, 350);
            this.panelMain.TabIndex = 1;
            // 
            // lvNameDiff
            // 
            this.lvNameDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNameDiff.HideSelection = false;
            this.lvNameDiff.Location = new System.Drawing.Point(3, 72);
            this.lvNameDiff.Name = "lvNameDiff";
            this.lvNameDiff.Size = new System.Drawing.Size(633, 47);
            this.lvNameDiff.TabIndex = 1;
            this.lvNameDiff.UseCompatibleStateImageBehavior = false;
            this.lvNameDiff.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvNameDiff_ItemSelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Назва";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 122);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Проценти";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label3.Size = new System.Drawing.Size(633, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Зміни твору в порівнянні з попереднім сеансом публікації";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label4.Size = new System.Drawing.Size(633, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "ЗАУВАЖЕННЯ : Якщо твір через додаток не передавався, але має код ISWC, тут показа" +
    "на відповідна нова інформація";
            // 
            // UcSubmWorkSharesDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelMain);
            this.Name = "UcSubmWorkSharesDiff";
            this.Size = new System.Drawing.Size(644, 350);
            this.Load += new System.EventHandler(this.UcSubmWorkShares_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvShareDiff;
        private System.Windows.Forms.ImageList ilChangeType;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.ListView lvNameDiff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
