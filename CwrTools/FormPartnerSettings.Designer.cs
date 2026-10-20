
namespace CwrTools
{
    partial class FormPartnerSettings
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
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.labTitle = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCalcel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.panelMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbFtpUrl = new System.Windows.Forms.TextBox();
            this.tbFtpLogin = new System.Windows.Forms.TextBox();
            this.tbFtpPwd = new System.Windows.Forms.TextBox();
            this.tbFtpPort = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Controls.Add(this.panelBottom, 0, 2);
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.Size = new System.Drawing.Size(495, 280);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(489, 27);
            this.panelTop.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(3, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labTitle.Size = new System.Drawing.Size(131, 18);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Налаштування партнера";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCalcel);
            this.panelBottom.Controls.Add(this.btnApply);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(3, 250);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(489, 27);
            this.panelBottom.TabIndex = 1;
            // 
            // btnCalcel
            // 
            this.btnCalcel.Location = new System.Drawing.Point(411, 3);
            this.btnCalcel.Name = "btnCalcel";
            this.btnCalcel.Size = new System.Drawing.Size(75, 23);
            this.btnCalcel.TabIndex = 0;
            this.btnCalcel.Text = "Відмінити";
            this.btnCalcel.UseVisualStyleBackColor = true;
            this.btnCalcel.Click += new System.EventHandler(this.btnCalcel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(317, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(88, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Застосувати";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panelMiddle
            // 
            this.panelMiddle.ColumnCount = 2;
            this.panelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.panelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddle.Controls.Add(this.label2, 0, 0);
            this.panelMiddle.Controls.Add(this.label3, 0, 1);
            this.panelMiddle.Controls.Add(this.label4, 0, 2);
            this.panelMiddle.Controls.Add(this.label5, 0, 3);
            this.panelMiddle.Controls.Add(this.label6, 0, 4);
            this.panelMiddle.Controls.Add(this.label7, 0, 5);
            this.panelMiddle.Controls.Add(this.cbPeriod, 1, 0);
            this.panelMiddle.Controls.Add(this.tbEmail, 1, 1);
            this.panelMiddle.Controls.Add(this.tbFtpUrl, 1, 2);
            this.panelMiddle.Controls.Add(this.tbFtpLogin, 1, 3);
            this.panelMiddle.Controls.Add(this.tbFtpPwd, 1, 4);
            this.panelMiddle.Controls.Add(this.tbFtpPort, 1, 5);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(3, 36);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.RowCount = 7;
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddle.Size = new System.Drawing.Size(489, 208);
            this.panelMiddle.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Період передачі файлу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "EMail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "FtpUrl";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 99);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "FtpLogin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 132);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "FtpPassword";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 165);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "FtpPort";
            // 
            // cbPeriod
            // 
            this.cbPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Location = new System.Drawing.Point(161, 3);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(325, 21);
            this.cbPeriod.TabIndex = 1;
            // 
            // tbEmail
            // 
            this.tbEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEmail.Location = new System.Drawing.Point(161, 36);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(325, 20);
            this.tbEmail.TabIndex = 2;
            // 
            // tbFtpUrl
            // 
            this.tbFtpUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFtpUrl.Location = new System.Drawing.Point(161, 69);
            this.tbFtpUrl.Name = "tbFtpUrl";
            this.tbFtpUrl.Size = new System.Drawing.Size(325, 20);
            this.tbFtpUrl.TabIndex = 2;
            // 
            // tbFtpLogin
            // 
            this.tbFtpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFtpLogin.Location = new System.Drawing.Point(161, 102);
            this.tbFtpLogin.Name = "tbFtpLogin";
            this.tbFtpLogin.Size = new System.Drawing.Size(325, 20);
            this.tbFtpLogin.TabIndex = 2;
            // 
            // tbFtpPwd
            // 
            this.tbFtpPwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFtpPwd.Location = new System.Drawing.Point(161, 135);
            this.tbFtpPwd.Name = "tbFtpPwd";
            this.tbFtpPwd.Size = new System.Drawing.Size(325, 20);
            this.tbFtpPwd.TabIndex = 2;
            // 
            // tbFtpPort
            // 
            this.tbFtpPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFtpPort.Location = new System.Drawing.Point(161, 168);
            this.tbFtpPort.Name = "tbFtpPort";
            this.tbFtpPort.Size = new System.Drawing.Size(325, 20);
            this.tbFtpPort.TabIndex = 2;
            // 
            // FormPartnerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 280);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormPartnerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Налаштування партнера";
            this.Load += new System.EventHandler(this.FormPartnerSettings_Load);
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelMiddle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.TableLayoutPanel panelMiddle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCalcel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbFtpUrl;
        private System.Windows.Forms.TextBox tbFtpLogin;
        private System.Windows.Forms.TextBox tbFtpPwd;
        private System.Windows.Forms.TextBox tbFtpPort;
    }
}