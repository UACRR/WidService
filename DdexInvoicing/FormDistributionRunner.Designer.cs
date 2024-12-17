namespace DdexInvoicing
{
    partial class FormDistributionRunner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDistributionRunner));
            this.panelDistributionProgress = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.lvDistributionProgress = new System.Windows.Forms.ListView();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.timerDistributionStep = new System.Windows.Forms.Timer(this.components);
            this.panelDistributionProgress.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDistributionProgress
            // 
            this.panelDistributionProgress.ColumnCount = 1;
            this.panelDistributionProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDistributionProgress.Controls.Add(this.label16, 0, 0);
            this.panelDistributionProgress.Controls.Add(this.lvDistributionProgress, 0, 1);
            this.panelDistributionProgress.Controls.Add(this.panelButtons, 0, 2);
            this.panelDistributionProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistributionProgress.Location = new System.Drawing.Point(0, 0);
            this.panelDistributionProgress.Name = "panelDistributionProgress";
            this.panelDistributionProgress.RowCount = 4;
            this.panelDistributionProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelDistributionProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDistributionProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.panelDistributionProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelDistributionProgress.Size = new System.Drawing.Size(854, 499);
            this.panelDistributionProgress.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(848, 30);
            this.label16.TabIndex = 0;
            this.label16.Text = "Виконання розподілу і оплати";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvDistributionProgress
            // 
            this.lvDistributionProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDistributionProgress.HideSelection = false;
            this.lvDistributionProgress.Location = new System.Drawing.Point(3, 33);
            this.lvDistributionProgress.Name = "lvDistributionProgress";
            this.lvDistributionProgress.Size = new System.Drawing.Size(848, 418);
            this.lvDistributionProgress.TabIndex = 2;
            this.lvDistributionProgress.UseCompatibleStateImageBehavior = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(3, 457);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(848, 29);
            this.panelButtons.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(770, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "iconfinder_OK_132710.png");
            this.ilMain.Images.SetKeyName(1, "iconfinder_Forward_132664.png");
            this.ilMain.Images.SetKeyName(2, "iconfinder_Error_132716.png");
            this.ilMain.Images.SetKeyName(3, "iconfinder_History_132755.png");
            // 
            // timerDistributionStep
            // 
            this.timerDistributionStep.Tick += new System.EventHandler(this.timerDistributionStep_Tick);
            // 
            // FormDistributionRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 499);
            this.ControlBox = false;
            this.Controls.Add(this.panelDistributionProgress);
            this.Name = "FormDistributionRunner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Виконання розрахунку розподілу і оплати";
            this.Load += new System.EventHandler(this.FormDistributionRunner_Load);
            this.panelDistributionProgress.ResumeLayout(false);
            this.panelDistributionProgress.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelDistributionProgress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView lvDistributionProgress;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.Timer timerDistributionStep;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnClose;
    }
}