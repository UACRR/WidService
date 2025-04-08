namespace WidExport
{
    partial class UcMainRightHolderOwnership
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lvRightHolder = new System.Windows.Forms.ListView();
            this.panelFilter = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.rbAuto = new System.Windows.Forms.RadioButton();
            this.rbForeign = new System.Windows.Forms.RadioButton();
            this.rbOwn = new System.Windows.Forms.RadioButton();
            this.panelMain.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.label1, 0, 0);
            this.panelMain.Controls.Add(this.lvRightHolder, 0, 2);
            this.panelMain.Controls.Add(this.panelFilter, 0, 1);
            this.panelMain.Controls.Add(this.panelBottom, 0, 3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.Size = new System.Drawing.Size(736, 369);
            this.panelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Правила встановлення приналежності правовласника до товариства";
            // 
            // lvRightHolder
            // 
            this.lvRightHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRightHolder.HideSelection = false;
            this.lvRightHolder.Location = new System.Drawing.Point(3, 67);
            this.lvRightHolder.Name = "lvRightHolder";
            this.lvRightHolder.Size = new System.Drawing.Size(725, 269);
            this.lvRightHolder.TabIndex = 1;
            this.lvRightHolder.UseCompatibleStateImageBehavior = false;
            this.lvRightHolder.SelectedIndexChanged += new System.EventHandler(this.lvRightHolder_SelectedIndexChanged);
            // 
            // panelFilter
            // 
            this.panelFilter.ColumnCount = 4;
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.panelFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFilter.Controls.Add(this.label2, 0, 0);
            this.panelFilter.Controls.Add(this.tbFilter, 1, 0);
            this.panelFilter.Controls.Add(this.btnApplyFilter, 2, 0);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 32);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.RowCount = 1;
            this.panelFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelFilter.Size = new System.Drawing.Size(725, 29);
            this.panelFilter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(97, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Вибір за текстом";
            // 
            // tbFilter
            // 
            this.tbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFilter.Location = new System.Drawing.Point(106, 4);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(211, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApplyFilter.Location = new System.Drawing.Point(323, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(98, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Застосувати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.rbAuto);
            this.panelBottom.Controls.Add(this.rbOwn);
            this.panelBottom.Controls.Add(this.rbForeign);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 342);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(725, 24);
            this.panelBottom.TabIndex = 3;
            // 
            // rbAuto
            // 
            this.rbAuto.AutoSize = true;
            this.rbAuto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbAuto.Location = new System.Drawing.Point(3, 3);
            this.rbAuto.Name = "rbAuto";
            this.rbAuto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbAuto.Size = new System.Drawing.Size(139, 17);
            this.rbAuto.TabIndex = 0;
            this.rbAuto.TabStop = true;
            this.rbAuto.Text = "За наявності договору";
            this.rbAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbAuto.UseVisualStyleBackColor = true;
            this.rbAuto.CheckedChanged += new System.EventHandler(this.rbAuto_CheckedChanged);
            // 
            // rbForeign
            // 
            this.rbForeign.AutoSize = true;
            this.rbForeign.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbForeign.Location = new System.Drawing.Point(314, 3);
            this.rbForeign.Name = "rbForeign";
            this.rbForeign.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbForeign.Size = new System.Drawing.Size(150, 17);
            this.rbForeign.TabIndex = 1;
            this.rbForeign.TabStop = true;
            this.rbForeign.Text = "Сторонній правовласник";
            this.rbForeign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbForeign.UseVisualStyleBackColor = true;
            this.rbForeign.CheckedChanged += new System.EventHandler(this.rbForeign_CheckedChanged);
            // 
            // rbOwn
            // 
            this.rbOwn.AutoSize = true;
            this.rbOwn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbOwn.Location = new System.Drawing.Point(148, 3);
            this.rbOwn.Name = "rbOwn";
            this.rbOwn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbOwn.Size = new System.Drawing.Size(160, 17);
            this.rbOwn.TabIndex = 1;
            this.rbOwn.TabStop = true;
            this.rbOwn.Text = "Правовласник товариства";
            this.rbOwn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbOwn.UseVisualStyleBackColor = true;
            this.rbOwn.CheckedChanged += new System.EventHandler(this.rbOwn_CheckedChanged);
            // 
            // UcMainRightHolderOwnership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcMainRightHolderOwnership";
            this.Size = new System.Drawing.Size(736, 369);
            this.Load += new System.EventHandler(this.UcMainRightHolderOwnership_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvRightHolder;
        private System.Windows.Forms.TableLayoutPanel panelFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.RadioButton rbAuto;
        private System.Windows.Forms.RadioButton rbForeign;
        private System.Windows.Forms.RadioButton rbOwn;
    }
}
