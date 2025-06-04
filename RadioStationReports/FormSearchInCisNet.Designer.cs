namespace RadioStationReports
{
    partial class FormSearchInCisNet
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
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            panelActions = new System.Windows.Forms.TableLayoutPanel();
            panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            panelMain.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Controls.Add(label1, 0, 0);
            panelMain.Controls.Add(panelActions, 0, 1);
            panelMain.Controls.Add(panelButtons, 0, 2);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 3;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelMain.Size = new System.Drawing.Size(553, 370);
            panelMain.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(542, 19);
            label1.TabIndex = 0;
            label1.Text = "Виконайте потрібні дії, після завершення ставте відмітку.";
            // 
            // panelActions
            // 
            panelActions.ColumnCount = 4;
            panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            panelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.Location = new System.Drawing.Point(6, 31);
            panelActions.Margin = new System.Windows.Forms.Padding(6, 6, 3, 3);
            panelActions.Name = "panelActions";
            panelActions.RowCount = 1;
            panelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelActions.Size = new System.Drawing.Size(539, 298);
            panelActions.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnApply);
            panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelButtons.Location = new System.Drawing.Point(3, 335);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(542, 32);
            panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(464, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Відмінити";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new System.Drawing.Point(370, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(88, 23);
            btnApply.TabIndex = 0;
            btnApply.Text = "Застосувати";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // FormSearchInCisNet
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(553, 370);
            ControlBox = false;
            Controls.Add(panelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Name = "FormSearchInCisNet";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Пошук творів в CISNet";
            Load += FormSearchInCisNet_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelActions;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}