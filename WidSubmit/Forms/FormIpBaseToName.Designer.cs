namespace WidSubmit
{
    partial class FormIpBaseToName
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
            this.panelTblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pannelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.panelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.cbColName = new System.Windows.Forms.ComboBox();
            this.tbNewValue = new System.Windows.Forms.TextBox();
            this.btnApplyFieldValue = new System.Windows.Forms.Button();
            this.btnCbdCopy = new System.Windows.Forms.Button();
            this.btnCbdPaste = new System.Windows.Forms.Button();
            this.panelSplitRh = new System.Windows.Forms.SplitContainer();
            this.lvRhMs = new System.Windows.Forms.ListView();
            this.lvIpNames = new System.Windows.Forms.ListView();
            this.panelTblMain.SuspendLayout();
            this.pannelBottom.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitRh)).BeginInit();
            this.panelSplitRh.Panel1.SuspendLayout();
            this.panelSplitRh.Panel2.SuspendLayout();
            this.panelSplitRh.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTblMain
            // 
            this.panelTblMain.ColumnCount = 1;
            this.panelTblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelTblMain.Controls.Add(this.pannelBottom, 0, 2);
            this.panelTblMain.Controls.Add(this.label1, 0, 0);
            this.panelTblMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelTblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTblMain.Location = new System.Drawing.Point(0, 0);
            this.panelTblMain.Name = "panelTblMain";
            this.panelTblMain.RowCount = 3;
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelTblMain.Size = new System.Drawing.Size(800, 450);
            this.panelTblMain.TabIndex = 0;
            // 
            // pannelBottom
            // 
            this.pannelBottom.Controls.Add(this.btnCancel);
            this.pannelBottom.Controls.Add(this.btnApply);
            this.pannelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pannelBottom.Location = new System.Drawing.Point(3, 420);
            this.pannelBottom.Name = "pannelBottom";
            this.pannelBottom.Size = new System.Drawing.Size(794, 27);
            this.pannelBottom.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(716, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Вийти";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(606, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(104, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Застосувати";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Проблемні правовласники";
            // 
            // panelMiddle
            // 
            this.panelMiddle.ColumnCount = 1;
            this.panelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddle.Controls.Add(this.panelActions, 0, 1);
            this.panelMiddle.Controls.Add(this.panelSplitRh, 0, 0);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(3, 30);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.RowCount = 2;
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMiddle.Size = new System.Drawing.Size(794, 384);
            this.panelMiddle.TabIndex = 2;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.cbColName);
            this.panelActions.Controls.Add(this.tbNewValue);
            this.panelActions.Controls.Add(this.btnApplyFieldValue);
            this.panelActions.Controls.Add(this.btnCbdCopy);
            this.panelActions.Controls.Add(this.btnCbdPaste);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActions.Location = new System.Drawing.Point(3, 354);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(788, 27);
            this.panelActions.TabIndex = 0;
            // 
            // cbColName
            // 
            this.cbColName.FormattingEnabled = true;
            this.cbColName.Location = new System.Drawing.Point(3, 3);
            this.cbColName.Name = "cbColName";
            this.cbColName.Size = new System.Drawing.Size(148, 21);
            this.cbColName.TabIndex = 4;
            // 
            // tbNewValue
            // 
            this.tbNewValue.Location = new System.Drawing.Point(157, 3);
            this.tbNewValue.Name = "tbNewValue";
            this.tbNewValue.Size = new System.Drawing.Size(119, 20);
            this.tbNewValue.TabIndex = 2;
            // 
            // btnApplyFieldValue
            // 
            this.btnApplyFieldValue.Location = new System.Drawing.Point(282, 3);
            this.btnApplyFieldValue.Name = "btnApplyFieldValue";
            this.btnApplyFieldValue.Size = new System.Drawing.Size(99, 23);
            this.btnApplyFieldValue.TabIndex = 3;
            this.btnApplyFieldValue.Text = "Застосувати";
            this.btnApplyFieldValue.UseVisualStyleBackColor = true;
            this.btnApplyFieldValue.Click += new System.EventHandler(this.btnApplyFieldValue_Click);
            // 
            // btnCbdCopy
            // 
            this.btnCbdCopy.Location = new System.Drawing.Point(387, 3);
            this.btnCbdCopy.Name = "btnCbdCopy";
            this.btnCbdCopy.Size = new System.Drawing.Size(156, 23);
            this.btnCbdCopy.TabIndex = 5;
            this.btnCbdCopy.Text = "Копіювати в буфер обміну";
            this.btnCbdCopy.UseVisualStyleBackColor = true;
            this.btnCbdCopy.Click += new System.EventHandler(this.btnCbdCopy_Click);
            // 
            // btnCbdPaste
            // 
            this.btnCbdPaste.Location = new System.Drawing.Point(549, 3);
            this.btnCbdPaste.Name = "btnCbdPaste";
            this.btnCbdPaste.Size = new System.Drawing.Size(158, 23);
            this.btnCbdPaste.TabIndex = 5;
            this.btnCbdPaste.Text = "Замінити із буферу обміну";
            this.btnCbdPaste.UseVisualStyleBackColor = true;
            this.btnCbdPaste.Click += new System.EventHandler(this.btnCbdPaste_Click);
            // 
            // panelSplitRh
            // 
            this.panelSplitRh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitRh.Location = new System.Drawing.Point(3, 3);
            this.panelSplitRh.Name = "panelSplitRh";
            // 
            // panelSplitRh.Panel1
            // 
            this.panelSplitRh.Panel1.Controls.Add(this.lvRhMs);
            // 
            // panelSplitRh.Panel2
            // 
            this.panelSplitRh.Panel2.Controls.Add(this.lvIpNames);
            this.panelSplitRh.Panel2Collapsed = true;
            this.panelSplitRh.Size = new System.Drawing.Size(788, 345);
            this.panelSplitRh.SplitterDistance = 481;
            this.panelSplitRh.TabIndex = 1;
            // 
            // lvRhMs
            // 
            this.lvRhMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRhMs.HideSelection = false;
            this.lvRhMs.Location = new System.Drawing.Point(0, 0);
            this.lvRhMs.Name = "lvRhMs";
            this.lvRhMs.Size = new System.Drawing.Size(788, 345);
            this.lvRhMs.TabIndex = 0;
            this.lvRhMs.UseCompatibleStateImageBehavior = false;
            this.lvRhMs.SelectedIndexChanged += new System.EventHandler(this.lvRhMs_SelectedIndexChanged);
            // 
            // lvIpNames
            // 
            this.lvIpNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvIpNames.HideSelection = false;
            this.lvIpNames.Location = new System.Drawing.Point(0, 0);
            this.lvIpNames.Name = "lvIpNames";
            this.lvIpNames.Size = new System.Drawing.Size(96, 100);
            this.lvIpNames.TabIndex = 0;
            this.lvIpNames.UseCompatibleStateImageBehavior = false;
            // 
            // FormIpBaseToName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTblMain);
            this.Name = "FormIpBaseToName";
            this.Text = "Коди міжнародної назви за базовим міжнародним кодом";
            this.Load += new System.EventHandler(this.FormIpBaseToName_Load);
            this.panelTblMain.ResumeLayout(false);
            this.panelTblMain.PerformLayout();
            this.pannelBottom.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.panelSplitRh.Panel1.ResumeLayout(false);
            this.panelSplitRh.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSplitRh)).EndInit();
            this.panelSplitRh.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelTblMain;
        private System.Windows.Forms.FlowLayoutPanel pannelBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelMiddle;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.SplitContainer panelSplitRh;
        private System.Windows.Forms.ListView lvRhMs;
        private System.Windows.Forms.ListView lvIpNames;
        private System.Windows.Forms.TextBox tbNewValue;
        private System.Windows.Forms.Button btnApplyFieldValue;
        private System.Windows.Forms.ComboBox cbColName;
        private System.Windows.Forms.Button btnCbdCopy;
        private System.Windows.Forms.Button btnCbdPaste;
    }
}