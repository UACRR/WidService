
namespace WidServiceInstaller
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelSteps = new System.Windows.Forms.TableLayoutPanel();
            this.lvSteps = new System.Windows.Forms.ListView();
            this.stepName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilSteps = new System.Windows.Forms.ImageList(this.components);
            this.panelUserControls = new System.Windows.Forms.Panel();
            this.ucDatabaseSettings = new WidServiceInstaller.UcDatabaseSettings();
            this.ucFinish = new WidServiceInstaller.UcFinish();
            this.ucSettingsSummary = new WidServiceInstaller.UcSettingsSummary();
            this.ucIpiFtpSettings = new WidServiceInstaller.UcIpiFtpSettings();
            this.ucWidFtpSettings = new WidServiceInstaller.UcWidFtpSettings();
            this.ucGeneralSettings = new WidServiceInstaller.UcGeneralSettings();
            this.panelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labHeading = new System.Windows.Forms.Label();
            this.timerOnLoad = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panelSteps.SuspendLayout();
            this.panelUserControls.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.19469F));
            this.panelMain.Controls.Add(this.panelSteps, 0, 1);
            this.panelMain.Controls.Add(this.panelButtons, 0, 2);
            this.panelMain.Controls.Add(this.labHeading, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(10, 10);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.panelMain.Size = new System.Drawing.Size(1298, 599);
            this.panelMain.TabIndex = 0;
            // 
            // panelSteps
            // 
            this.panelSteps.ColumnCount = 2;
            this.panelSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 296F));
            this.panelSteps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSteps.Controls.Add(this.lvSteps, 0, 0);
            this.panelSteps.Controls.Add(this.panelUserControls, 1, 0);
            this.panelSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSteps.Location = new System.Drawing.Point(3, 42);
            this.panelSteps.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSteps.Name = "panelSteps";
            this.panelSteps.RowCount = 1;
            this.panelSteps.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSteps.Size = new System.Drawing.Size(1292, 505);
            this.panelSteps.TabIndex = 0;
            // 
            // lvSteps
            // 
            this.lvSteps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stepName});
            this.lvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSteps.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvSteps.FullRowSelect = true;
            this.lvSteps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSteps.HideSelection = false;
            this.lvSteps.LabelWrap = false;
            this.lvSteps.Location = new System.Drawing.Point(3, 4);
            this.lvSteps.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvSteps.MultiSelect = false;
            this.lvSteps.Name = "lvSteps";
            this.lvSteps.Size = new System.Drawing.Size(290, 497);
            this.lvSteps.SmallImageList = this.ilSteps;
            this.lvSteps.TabIndex = 0;
            this.lvSteps.UseCompatibleStateImageBehavior = false;
            this.lvSteps.View = System.Windows.Forms.View.Details;
            this.lvSteps.SelectedIndexChanged += new System.EventHandler(this.lvSteps_SelectedIndexChanged);
            // 
            // stepName
            // 
            this.stepName.Width = 180;
            // 
            // ilSteps
            // 
            this.ilSteps.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSteps.ImageStream")));
            this.ilSteps.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSteps.Images.SetKeyName(0, "pending");
            this.ilSteps.Images.SetKeyName(1, "inprogress");
            this.ilSteps.Images.SetKeyName(2, "completed");
            this.ilSteps.Images.SetKeyName(3, "failed");
            // 
            // panelUserControls
            // 
            this.panelUserControls.Controls.Add(this.ucDatabaseSettings);
            this.panelUserControls.Controls.Add(this.ucFinish);
            this.panelUserControls.Controls.Add(this.ucSettingsSummary);
            this.panelUserControls.Controls.Add(this.ucIpiFtpSettings);
            this.panelUserControls.Controls.Add(this.ucWidFtpSettings);
            this.panelUserControls.Controls.Add(this.ucGeneralSettings);
            this.panelUserControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserControls.Location = new System.Drawing.Point(299, 4);
            this.panelUserControls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelUserControls.Name = "panelUserControls";
            this.panelUserControls.Padding = new System.Windows.Forms.Padding(6);
            this.panelUserControls.Size = new System.Drawing.Size(990, 497);
            this.panelUserControls.TabIndex = 1;
            // 
            // ucDatabaseSettings
            // 
            this.ucDatabaseSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucDatabaseSettings.deploymentConfig = null;
            this.ucDatabaseSettings.Location = new System.Drawing.Point(3, 207);
            this.ucDatabaseSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucDatabaseSettings.Name = "ucDatabaseSettings";
            this.ucDatabaseSettings.Size = new System.Drawing.Size(175, 185);
            this.ucDatabaseSettings.TabIndex = 5;
            // 
            // ucFinish
            // 
            this.ucFinish.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucFinish.deploymentConfig = null;
            this.ucFinish.Location = new System.Drawing.Point(367, 207);
            this.ucFinish.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucFinish.Name = "ucFinish";
            this.ucFinish.Size = new System.Drawing.Size(175, 185);
            this.ucFinish.TabIndex = 4;
            // 
            // ucSettingsSummary
            // 
            this.ucSettingsSummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucSettingsSummary.deploymentConfig = null;
            this.ucSettingsSummary.Location = new System.Drawing.Point(185, 207);
            this.ucSettingsSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSettingsSummary.Name = "ucSettingsSummary";
            this.ucSettingsSummary.Size = new System.Drawing.Size(175, 185);
            this.ucSettingsSummary.TabIndex = 3;
            // 
            // ucIpiFtpSettings
            // 
            this.ucIpiFtpSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucIpiFtpSettings.deploymentConfig = null;
            this.ucIpiFtpSettings.Location = new System.Drawing.Point(367, 15);
            this.ucIpiFtpSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucIpiFtpSettings.Name = "ucIpiFtpSettings";
            this.ucIpiFtpSettings.Size = new System.Drawing.Size(175, 185);
            this.ucIpiFtpSettings.TabIndex = 2;
            // 
            // ucWidFtpSettings
            // 
            this.ucWidFtpSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucWidFtpSettings.deploymentConfig = null;
            this.ucWidFtpSettings.Location = new System.Drawing.Point(185, 15);
            this.ucWidFtpSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucWidFtpSettings.Name = "ucWidFtpSettings";
            this.ucWidFtpSettings.Size = new System.Drawing.Size(175, 185);
            this.ucWidFtpSettings.TabIndex = 1;
            // 
            // ucGeneralSettings
            // 
            this.ucGeneralSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucGeneralSettings.deploymentConfig = null;
            this.ucGeneralSettings.Location = new System.Drawing.Point(3, 15);
            this.ucGeneralSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucGeneralSettings.Name = "ucGeneralSettings";
            this.ucGeneralSettings.Size = new System.Drawing.Size(175, 185);
            this.ucGeneralSettings.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.ColumnCount = 5;
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.panelButtons.Controls.Add(this.btnPrev, 2, 0);
            this.panelButtons.Controls.Add(this.btnNext, 3, 0);
            this.panelButtons.Controls.Add(this.btnClose, 4, 0);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(3, 555);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.RowCount = 1;
            this.panelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelButtons.Size = new System.Drawing.Size(1292, 40);
            this.panelButtons.TabIndex = 1;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(997, 4);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(82, 28);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "< Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1086, 4);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(87, 28);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Далі >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1190, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labHeading
            // 
            this.labHeading.AutoSize = true;
            this.labHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labHeading.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labHeading.Location = new System.Drawing.Point(3, 0);
            this.labHeading.Name = "labHeading";
            this.labHeading.Size = new System.Drawing.Size(1292, 38);
            this.labHeading.TabIndex = 2;
            this.labHeading.Text = "Виконайте наступні кроки для встановлення сервісу реплікації WID";
            this.labHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerOnLoad
            // 
            this.timerOnLoad.Enabled = true;
            this.timerOnLoad.Interval = 1;
            this.timerOnLoad.Tick += new System.EventHandler(this.timerOnLoad_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 619);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Встановлення сервісу реплікації WID";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelSteps.ResumeLayout(false);
            this.panelUserControls.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelSteps;
        private System.Windows.Forms.ListView lvSteps;
        private System.Windows.Forms.ImageList ilSteps;
        private System.Windows.Forms.ColumnHeader stepName;
        private System.Windows.Forms.Timer timerOnLoad;
        private System.Windows.Forms.TableLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labHeading;
        private System.Windows.Forms.Panel panelUserControls;
        private UcFinish ucFinish;
        private UcSettingsSummary ucSettingsSummary;
        private UcIpiFtpSettings ucIpiFtpSettings;
        private UcWidFtpSettings ucWidFtpSettings;
        private UcGeneralSettings ucGeneralSettings;
        private UcDatabaseSettings ucDatabaseSettings;
    }
}

