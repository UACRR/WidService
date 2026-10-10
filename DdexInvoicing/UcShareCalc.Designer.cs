namespace DdexInvoicing
{
    partial class UcShareCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcShareCalc));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSharesTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelWork = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWorkCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWorkName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbExcSets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.panelShares = new System.Windows.Forms.SplitContainer();
            this.lvShares = new System.Windows.Forms.ListView();
            this.lvShareDetails = new System.Windows.Forms.ListView();
            this.panelTikTok = new System.Windows.Forms.FlowLayoutPanel();
            this.chkTikTok = new System.Windows.Forms.CheckBox();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.panelMain.SuspendLayout();
            this.panelSharesTitle.SuspendLayout();
            this.panelWork.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelShares)).BeginInit();
            this.panelShares.Panel1.SuspendLayout();
            this.panelShares.Panel2.SuspendLayout();
            this.panelShares.SuspendLayout();
            this.panelTikTok.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelSharesTitle, 0, 3);
            this.panelMain.Controls.Add(this.panelWork, 0, 0);
            this.panelMain.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.panelMain.Controls.Add(this.panelShares, 0, 4);
            this.panelMain.Controls.Add(this.panelTikTok, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 6;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Size = new System.Drawing.Size(954, 439);
            this.panelMain.TabIndex = 0;
            // 
            // panelSharesTitle
            // 
            this.panelSharesTitle.Controls.Add(this.label3);
            this.panelSharesTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSharesTitle.Location = new System.Drawing.Point(3, 108);
            this.panelSharesTitle.Name = "panelSharesTitle";
            this.panelSharesTitle.Size = new System.Drawing.Size(948, 29);
            this.panelSharesTitle.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Розподіл процентів за твір";
            // 
            // panelWork
            // 
            this.panelWork.ColumnCount = 5;
            this.panelWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.panelWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.panelWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.panelWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelWork.Controls.Add(this.label4, 2, 0);
            this.panelWork.Controls.Add(this.tbWorkCode, 1, 0);
            this.panelWork.Controls.Add(this.label1, 0, 0);
            this.panelWork.Controls.Add(this.tbWorkName, 3, 0);
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(3, 3);
            this.panelWork.Name = "panelWork";
            this.panelWork.RowCount = 1;
            this.panelWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelWork.Size = new System.Drawing.Size(948, 29);
            this.panelWork.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(201, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Назва твору";
            // 
            // tbWorkCode
            // 
            this.tbWorkCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWorkCode.Location = new System.Drawing.Point(82, 3);
            this.tbWorkCode.Name = "tbWorkCode";
            this.tbWorkCode.ReadOnly = true;
            this.tbWorkCode.Size = new System.Drawing.Size(113, 20);
            this.tbWorkCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код твору";
            // 
            // tbWorkName
            // 
            this.tbWorkName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWorkName.Location = new System.Drawing.Point(292, 3);
            this.tbWorkName.Name = "tbWorkName";
            this.tbWorkName.ReadOnly = true;
            this.tbWorkName.Size = new System.Drawing.Size(648, 20);
            this.tbWorkName.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Controls.Add(this.cbExcSets, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCalc, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(948, 29);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cbExcSets
            // 
            this.cbExcSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbExcSets.FormattingEnabled = true;
            this.cbExcSets.Location = new System.Drawing.Point(175, 3);
            this.cbExcSets.Name = "cbExcSets";
            this.cbExcSets.Size = new System.Drawing.Size(619, 21);
            this.cbExcSets.TabIndex = 1;
            this.cbExcSets.DropDown += new System.EventHandler(this.cbExcSets_DropDown);
            this.cbExcSets.SelectedIndexChanged += new System.EventHandler(this.cbExcSets_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Виключення користувача";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(800, 3);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(139, 23);
            this.btnCalc.TabIndex = 2;
            this.btnCalc.Text = "Розрахувати проценти";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Visible = false;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // panelShares
            // 
            this.panelShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShares.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.panelShares.Location = new System.Drawing.Point(3, 143);
            this.panelShares.Name = "panelShares";
            // 
            // panelShares.Panel1
            // 
            this.panelShares.Panel1.Controls.Add(this.lvShares);
            this.panelShares.Panel1MinSize = 100;
            // 
            // panelShares.Panel2
            // 
            this.panelShares.Panel2.Controls.Add(this.lvShareDetails);
            this.panelShares.Size = new System.Drawing.Size(948, 288);
            this.panelShares.SplitterDistance = 453;
            this.panelShares.TabIndex = 3;
            // 
            // lvShares
            // 
            this.lvShares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShares.HideSelection = false;
            this.lvShares.Location = new System.Drawing.Point(0, 0);
            this.lvShares.Name = "lvShares";
            this.lvShares.Size = new System.Drawing.Size(453, 288);
            this.lvShares.TabIndex = 0;
            this.lvShares.UseCompatibleStateImageBehavior = false;
            this.lvShares.SelectedIndexChanged += new System.EventHandler(this.lvShares_SelectedIndexChanged);
            // 
            // lvShareDetails
            // 
            this.lvShareDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShareDetails.HideSelection = false;
            this.lvShareDetails.Location = new System.Drawing.Point(0, 0);
            this.lvShareDetails.Name = "lvShareDetails";
            this.lvShareDetails.Size = new System.Drawing.Size(491, 288);
            this.lvShareDetails.TabIndex = 0;
            this.lvShareDetails.UseCompatibleStateImageBehavior = false;
            // 
            // panelTikTok
            // 
            this.panelTikTok.Controls.Add(this.chkTikTok);
            this.panelTikTok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTikTok.Location = new System.Drawing.Point(3, 73);
            this.panelTikTok.Name = "panelTikTok";
            this.panelTikTok.Size = new System.Drawing.Size(948, 29);
            this.panelTikTok.TabIndex = 4;
            // 
            // chkTikTok
            // 
            this.chkTikTok.AutoSize = true;
            this.chkTikTok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkTikTok.Location = new System.Drawing.Point(3, 3);
            this.chkTikTok.Name = "chkTikTok";
            this.chkTikTok.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTikTok.Size = new System.Drawing.Size(198, 17);
            this.chkTikTok.TabIndex = 0;
            this.chkTikTok.Text = "Застосувати правила ТікТок";
            this.chkTikTok.UseVisualStyleBackColor = true;
            this.chkTikTok.CheckedChanged += new System.EventHandler(this.chkTikTok_CheckedChanged);
            // 
            // ilStatuses
            // 
            this.ilStatuses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStatuses.ImageStream")));
            this.ilStatuses.TransparentColor = System.Drawing.Color.Transparent;
            this.ilStatuses.Images.SetKeyName(0, "angle-right-solid.ico");
            this.ilStatuses.Images.SetKeyName(1, "inprogress");
            this.ilStatuses.Images.SetKeyName(2, "completed");
            this.ilStatuses.Images.SetKeyName(3, "failed");
            this.ilStatuses.Images.SetKeyName(4, "pending");
            // 
            // UcShareCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcShareCalc";
            this.Size = new System.Drawing.Size(954, 439);
            this.Load += new System.EventHandler(this.UcShareCalc_Load);
            this.panelMain.ResumeLayout(false);
            this.panelSharesTitle.ResumeLayout(false);
            this.panelSharesTitle.PerformLayout();
            this.panelWork.ResumeLayout(false);
            this.panelWork.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelShares.Panel1.ResumeLayout(false);
            this.panelShares.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelShares)).EndInit();
            this.panelShares.ResumeLayout(false);
            this.panelTikTok.ResumeLayout(false);
            this.panelTikTok.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panelSharesTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWorkCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbExcSets;
        private System.Windows.Forms.TableLayoutPanel panelWork;
        private System.Windows.Forms.TextBox tbWorkName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.SplitContainer panelShares;
        private System.Windows.Forms.ListView lvShares;
        private System.Windows.Forms.ListView lvShareDetails;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.FlowLayoutPanel panelTikTok;
        private System.Windows.Forms.CheckBox chkTikTok;
    }
}
