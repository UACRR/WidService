namespace RadioStationReports
{
    partial class FormCisNetImport
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
            ucCisNetImport = new UcCisNetImport();
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            panelTitle = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            btnGetWork = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            panelActions = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            panelMain.SuspendLayout();
            panelTitle.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // ucCisNetImport
            // 
            ucCisNetImport.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCisNetImport.Location = new System.Drawing.Point(3, 38);
            ucCisNetImport.Name = "ucCisNetImport";
            ucCisNetImport.Size = new System.Drawing.Size(786, 322);
            ucCisNetImport.TabIndex = 0;
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.Controls.Add(ucCisNetImport, 0, 1);
            panelMain.Controls.Add(panelTitle, 0, 0);
            panelMain.Controls.Add(label2, 0, 2);
            panelMain.Controls.Add(panelActions, 0, 3);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 4;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            panelMain.Size = new System.Drawing.Size(792, 433);
            panelMain.TabIndex = 1;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = System.Drawing.SystemColors.Info;
            panelTitle.Controls.Add(label1);
            panelTitle.Controls.Add(btnGetWork);
            panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTitle.Location = new System.Drawing.Point(3, 3);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new System.Drawing.Size(786, 29);
            panelTitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label1.Size = new System.Drawing.Size(245, 22);
            label1.TabIndex = 0;
            label1.Text = "Імпортуйте твір з додатку CisNet і натисніть";
            // 
            // btnGetWork
            // 
            btnGetWork.Location = new System.Drawing.Point(254, 3);
            btnGetWork.Name = "btnGetWork";
            btnGetWork.Size = new System.Drawing.Size(115, 23);
            btnGetWork.TabIndex = 1;
            btnGetWork.Text = "Отримати твір";
            btnGetWork.UseVisualStyleBackColor = true;
            btnGetWork.Click += btnGetWork_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.Info;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 363);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            label2.Size = new System.Drawing.Size(786, 28);
            label2.TabIndex = 0;
            label2.Text = "Якщо твір відповідає рядку звіту натисніть Застосувати";
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnCancel);
            panelActions.Controls.Add(btnApply);
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelActions.Location = new System.Drawing.Point(3, 394);
            panelActions.Name = "panelActions";
            panelActions.Size = new System.Drawing.Size(786, 36);
            panelActions.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(708, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Відмінити";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new System.Drawing.Point(610, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(92, 23);
            btnApply.TabIndex = 0;
            btnApply.Text = "Застосувати";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // FormCisNetImport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(792, 433);
            ControlBox = false;
            Controls.Add(panelMain);
            Name = "FormCisNetImport";
            Text = "Опрацювання твору CisNet";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private UcCisNetImport ucCisNetImport;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetWork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}