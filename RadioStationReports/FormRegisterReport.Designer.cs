namespace RadioStationReports
{
    partial class FormRegisterReport
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegisterReport));
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            panelTop = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            tbRegId = new System.Windows.Forms.TextBox();
            tbCustomerName = new System.Windows.Forms.TextBox();
            tbStartDate = new System.Windows.Forms.TextBox();
            tbEndDate = new System.Windows.Forms.TextBox();
            tbFileName = new System.Windows.Forms.TextBox();
            panelStartRegistration = new System.Windows.Forms.FlowLayoutPanel();
            btnRegister = new System.Windows.Forms.Button();
            lvActions = new System.Windows.Forms.ListView();
            panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            btnClose = new System.Windows.Forms.Button();
            ilActions = new System.Windows.Forms.ImageList(components);
            timerRunAction = new System.Windows.Forms.Timer(components);
            panelMain.SuspendLayout();
            panelTop.SuspendLayout();
            panelStartRegistration.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Controls.Add(panelTop, 0, 0);
            panelMain.Controls.Add(panelStartRegistration, 0, 1);
            panelMain.Controls.Add(lvActions, 0, 2);
            panelMain.Controls.Add(panelBottom, 0, 3);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 5;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            panelMain.Size = new System.Drawing.Size(798, 447);
            panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.ColumnCount = 3;
            panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelTop.Controls.Add(label1, 0, 0);
            panelTop.Controls.Add(label2, 0, 1);
            panelTop.Controls.Add(label3, 0, 2);
            panelTop.Controls.Add(label4, 0, 3);
            panelTop.Controls.Add(label5, 0, 4);
            panelTop.Controls.Add(tbRegId, 1, 0);
            panelTop.Controls.Add(tbCustomerName, 1, 1);
            panelTop.Controls.Add(tbStartDate, 1, 2);
            panelTop.Controls.Add(tbEndDate, 1, 3);
            panelTop.Controls.Add(tbFileName, 1, 4);
            panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTop.Location = new System.Drawing.Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.RowCount = 5;
            panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelTop.Size = new System.Drawing.Size(787, 142);
            panelTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label1.Size = new System.Drawing.Size(121, 28);
            label1.TabIndex = 0;
            label1.Text = "Код в СМАРТ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 28);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label2.Size = new System.Drawing.Size(121, 28);
            label2.TabIndex = 0;
            label2.Text = "Користувач";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 56);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label3.Size = new System.Drawing.Size(121, 28);
            label3.TabIndex = 0;
            label3.Text = "Початок періоду";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 84);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label4.Size = new System.Drawing.Size(121, 28);
            label4.TabIndex = 0;
            label4.Text = "Закінчення періоду";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(3, 112);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label5.Size = new System.Drawing.Size(121, 30);
            label5.TabIndex = 0;
            label5.Text = "Назва файлу";
            // 
            // tbRegId
            // 
            tbRegId.Dock = System.Windows.Forms.DockStyle.Fill;
            tbRegId.Location = new System.Drawing.Point(130, 3);
            tbRegId.Name = "tbRegId";
            tbRegId.ReadOnly = true;
            tbRegId.Size = new System.Drawing.Size(649, 23);
            tbRegId.TabIndex = 1;
            // 
            // tbCustomerName
            // 
            tbCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbCustomerName.Location = new System.Drawing.Point(130, 31);
            tbCustomerName.Name = "tbCustomerName";
            tbCustomerName.ReadOnly = true;
            tbCustomerName.Size = new System.Drawing.Size(649, 23);
            tbCustomerName.TabIndex = 1;
            // 
            // tbStartDate
            // 
            tbStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            tbStartDate.Location = new System.Drawing.Point(130, 59);
            tbStartDate.Name = "tbStartDate";
            tbStartDate.ReadOnly = true;
            tbStartDate.Size = new System.Drawing.Size(649, 23);
            tbStartDate.TabIndex = 1;
            // 
            // tbEndDate
            // 
            tbEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            tbEndDate.Location = new System.Drawing.Point(130, 87);
            tbEndDate.Name = "tbEndDate";
            tbEndDate.ReadOnly = true;
            tbEndDate.Size = new System.Drawing.Size(649, 23);
            tbEndDate.TabIndex = 1;
            // 
            // tbFileName
            // 
            tbFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            tbFileName.Location = new System.Drawing.Point(130, 115);
            tbFileName.Name = "tbFileName";
            tbFileName.ReadOnly = true;
            tbFileName.Size = new System.Drawing.Size(649, 23);
            tbFileName.TabIndex = 1;
            // 
            // panelStartRegistration
            // 
            panelStartRegistration.Controls.Add(btnRegister);
            panelStartRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            panelStartRegistration.Location = new System.Drawing.Point(3, 151);
            panelStartRegistration.Name = "panelStartRegistration";
            panelStartRegistration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            panelStartRegistration.Size = new System.Drawing.Size(787, 32);
            panelStartRegistration.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.Location = new System.Drawing.Point(626, 3);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(158, 23);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Виконати реєстрацію";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lvActions
            // 
            lvActions.Dock = System.Windows.Forms.DockStyle.Fill;
            lvActions.HideSelection = false;
            lvActions.Location = new System.Drawing.Point(3, 189);
            lvActions.Name = "lvActions";
            lvActions.Size = new System.Drawing.Size(787, 211);
            lvActions.TabIndex = 2;
            lvActions.UseCompatibleStateImageBehavior = false;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnClose);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBottom.Location = new System.Drawing.Point(3, 406);
            panelBottom.Name = "panelBottom";
            panelBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            panelBottom.Size = new System.Drawing.Size(787, 30);
            panelBottom.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(709, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ilActions
            // 
            ilActions.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilActions.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilActions.ImageStream");
            ilActions.TransparentColor = System.Drawing.Color.Transparent;
            ilActions.Images.SetKeyName(0, "Hopstarter-Sleek-Xp-Basic-Ok.ico");
            ilActions.Images.SetKeyName(1, "iconfinder_Error_132716.png");
            // 
            // timerRunAction
            // 
            timerRunAction.Tick += timerRunAction_Tick;
            // 
            // FormRegisterReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(798, 447);
            ControlBox = false;
            Controls.Add(panelMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "FormRegisterReport";
            Text = "Реєстрація звіту";
            FormClosing += FormRegisterReport_FormClosing;
            Load += FormRegisterReport_Load;
            panelMain.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelStartRegistration.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRegId;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.TextBox tbEndDate;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.FlowLayoutPanel panelStartRegistration;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ListView lvActions;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ImageList ilActions;
        private System.Windows.Forms.Timer timerRunAction;
    }
}