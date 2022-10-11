namespace SmRoPermitClientLib
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.radBtnOk = new Telerik.WinControls.UI.RadButton();
            this.radBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.radLabPassword = new Telerik.WinControls.UI.RadLabel();
            this.radLabNewPassword = new Telerik.WinControls.UI.RadLabel();
            this.radLabConfirmPassword = new Telerik.WinControls.UI.RadLabel();
            this.radLabLogin = new Telerik.WinControls.UI.RadLabel();
            this.radLabPrompt = new Telerik.WinControls.UI.RadLabel();
            this.radTbLogin = new Telerik.WinControls.UI.RadTextBox();
            this.radTbPassword = new Telerik.WinControls.UI.RadTextBox();
            this.radTbNewPassword = new Telerik.WinControls.UI.RadTextBox();
            this.radTbConfirmPassword = new Telerik.WinControls.UI.RadTextBox();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbConfirmPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelButtons, 1, 5);
            this.panelMain.Controls.Add(this.radLabPassword, 0, 2);
            this.panelMain.Controls.Add(this.radLabNewPassword, 0, 3);
            this.panelMain.Controls.Add(this.radLabConfirmPassword, 0, 4);
            this.panelMain.Controls.Add(this.radLabLogin, 0, 1);
            this.panelMain.Controls.Add(this.radLabPrompt, 0, 0);
            this.panelMain.Controls.Add(this.radTbLogin, 1, 1);
            this.panelMain.Controls.Add(this.radTbPassword, 1, 2);
            this.panelMain.Controls.Add(this.radTbNewPassword, 1, 3);
            this.panelMain.Controls.Add(this.radTbConfirmPassword, 1, 4);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 6;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.Size = new System.Drawing.Size(408, 189);
            this.panelMain.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.ColumnCount = 3;
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.panelButtons.Controls.Add(this.radBtnOk, 1, 0);
            this.panelButtons.Controls.Add(this.radBtnCancel, 2, 0);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(99, 153);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.RowCount = 1;
            this.panelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelButtons.Size = new System.Drawing.Size(306, 33);
            this.panelButtons.TabIndex = 0;
            // 
            // radBtnOk
            // 
            this.radBtnOk.Location = new System.Drawing.Point(160, 3);
            this.radBtnOk.Name = "radBtnOk";
            this.radBtnOk.Size = new System.Drawing.Size(69, 24);
            this.radBtnOk.TabIndex = 0;
            this.radBtnOk.Text = "OK";
            this.radBtnOk.Click += new System.EventHandler(this.radBtnOk_Click);
            // 
            // radBtnCancel
            // 
            this.radBtnCancel.Location = new System.Drawing.Point(235, 3);
            this.radBtnCancel.Name = "radBtnCancel";
            this.radBtnCancel.Size = new System.Drawing.Size(66, 24);
            this.radBtnCancel.TabIndex = 0;
            this.radBtnCancel.Text = "Cancel";
            this.radBtnCancel.Click += new System.EventHandler(this.radBtnCancel_Click);
            // 
            // radLabPassword
            // 
            this.radLabPassword.AutoSize = false;
            this.radLabPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabPassword.Location = new System.Drawing.Point(3, 63);
            this.radLabPassword.Name = "radLabPassword";
            this.radLabPassword.Size = new System.Drawing.Size(90, 24);
            this.radLabPassword.TabIndex = 1;
            this.radLabPassword.Text = "Password:";
            // 
            // radLabNewPassword
            // 
            this.radLabNewPassword.AutoSize = false;
            this.radLabNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabNewPassword.Location = new System.Drawing.Point(3, 93);
            this.radLabNewPassword.Name = "radLabNewPassword";
            this.radLabNewPassword.Size = new System.Drawing.Size(90, 24);
            this.radLabNewPassword.TabIndex = 1;
            this.radLabNewPassword.Text = "New Password:";
            // 
            // radLabConfirmPassword
            // 
            this.radLabConfirmPassword.AutoSize = false;
            this.radLabConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabConfirmPassword.Location = new System.Drawing.Point(3, 123);
            this.radLabConfirmPassword.Name = "radLabConfirmPassword";
            this.radLabConfirmPassword.Size = new System.Drawing.Size(90, 24);
            this.radLabConfirmPassword.TabIndex = 1;
            this.radLabConfirmPassword.Text = "Confirm:";
            // 
            // radLabLogin
            // 
            this.radLabLogin.AutoSize = false;
            this.radLabLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabLogin.Location = new System.Drawing.Point(3, 33);
            this.radLabLogin.Name = "radLabLogin";
            this.radLabLogin.Size = new System.Drawing.Size(90, 24);
            this.radLabLogin.TabIndex = 1;
            this.radLabLogin.Text = "Login:";
            // 
            // radLabPrompt
            // 
            this.radLabPrompt.AutoSize = false;
            this.panelMain.SetColumnSpan(this.radLabPrompt, 2);
            this.radLabPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabPrompt.Location = new System.Drawing.Point(3, 3);
            this.radLabPrompt.Name = "radLabPrompt";
            this.radLabPrompt.Size = new System.Drawing.Size(402, 24);
            this.radLabPrompt.TabIndex = 2;
            this.radLabPrompt.Text = "Please, input your login and password";
            // 
            // radTbLogin
            // 
            this.radTbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTbLogin.Location = new System.Drawing.Point(99, 33);
            this.radTbLogin.Name = "radTbLogin";
            this.radTbLogin.Size = new System.Drawing.Size(306, 24);
            this.radTbLogin.TabIndex = 3;
            this.radTbLogin.Text = "SysAdmin";
            // 
            // radTbPassword
            // 
            this.radTbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTbPassword.Location = new System.Drawing.Point(99, 63);
            this.radTbPassword.Name = "radTbPassword";
            this.radTbPassword.PasswordChar = '*';
            this.radTbPassword.Size = new System.Drawing.Size(306, 24);
            this.radTbPassword.TabIndex = 3;
            this.radTbPassword.Text = "@o123456M";
            // 
            // radTbNewPassword
            // 
            this.radTbNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTbNewPassword.Location = new System.Drawing.Point(99, 93);
            this.radTbNewPassword.Name = "radTbNewPassword";
            this.radTbNewPassword.PasswordChar = '*';
            this.radTbNewPassword.Size = new System.Drawing.Size(306, 24);
            this.radTbNewPassword.TabIndex = 3;
            // 
            // radTbConfirmPassword
            // 
            this.radTbConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTbConfirmPassword.Location = new System.Drawing.Point(99, 123);
            this.radTbConfirmPassword.Name = "radTbConfirmPassword";
            this.radTbConfirmPassword.PasswordChar = '*';
            this.radTbConfirmPassword.Size = new System.Drawing.Size(306, 24);
            this.radTbConfirmPassword.TabIndex = 3;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(408, 189);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTbConfirmPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelButtons;
        private Telerik.WinControls.UI.RadLabel radLabPassword;
        private Telerik.WinControls.UI.RadLabel radLabNewPassword;
        private Telerik.WinControls.UI.RadLabel radLabConfirmPassword;
        private Telerik.WinControls.UI.RadLabel radLabLogin;
        private Telerik.WinControls.UI.RadButton radBtnOk;
        private Telerik.WinControls.UI.RadButton radBtnCancel;
        private Telerik.WinControls.UI.RadLabel radLabPrompt;
        private Telerik.WinControls.UI.RadTextBox radTbLogin;
        private Telerik.WinControls.UI.RadTextBox radTbPassword;
        private Telerik.WinControls.UI.RadTextBox radTbNewPassword;
        private Telerik.WinControls.UI.RadTextBox radTbConfirmPassword;
    }
}