namespace RadioStationReports
{
    partial class FormImportFromCisNet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImportFromCisNet));
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            panelManualActions = new System.Windows.Forms.TableLayoutPanel();
            lvAutoActions = new System.Windows.Forms.ListView();
            panelImportButton = new System.Windows.Forms.FlowLayoutPanel();
            btnImport = new System.Windows.Forms.Button();
            ilStatuses = new System.Windows.Forms.ImageList(components);
            timerRunAutoAction = new System.Windows.Forms.Timer(components);
            panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnClose = new System.Windows.Forms.Button();
            panelMain.SuspendLayout();
            panelImportButton.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Controls.Add(label1, 0, 0);
            panelMain.Controls.Add(panelManualActions, 0, 1);
            panelMain.Controls.Add(lvAutoActions, 0, 3);
            panelMain.Controls.Add(panelImportButton, 0, 2);
            panelMain.Controls.Add(panelButtons, 0, 4);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(10, 10);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 5;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            panelMain.Size = new System.Drawing.Size(903, 514);
            panelMain.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 7);
            label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(481, 15);
            label1.TabIndex = 0;
            label1.Text = "Виконайте попередні дії з переліку знизу. Після завершення дії проставляйте відмітку.";
            // 
            // panelManualActions
            // 
            panelManualActions.AutoSize = true;
            panelManualActions.ColumnCount = 2;
            panelManualActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelManualActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelManualActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelManualActions.Location = new System.Drawing.Point(3, 32);
            panelManualActions.Name = "panelManualActions";
            panelManualActions.RowCount = 2;
            panelManualActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelManualActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelManualActions.Size = new System.Drawing.Size(892, 1);
            panelManualActions.TabIndex = 1;
            // 
            // lvAutoActions
            // 
            lvAutoActions.Dock = System.Windows.Forms.DockStyle.Fill;
            lvAutoActions.Location = new System.Drawing.Point(3, 77);
            lvAutoActions.Name = "lvAutoActions";
            lvAutoActions.Size = new System.Drawing.Size(892, 399);
            lvAutoActions.TabIndex = 3;
            lvAutoActions.UseCompatibleStateImageBehavior = false;
            // 
            // panelImportButton
            // 
            panelImportButton.Controls.Add(btnImport);
            panelImportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            panelImportButton.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelImportButton.Location = new System.Drawing.Point(3, 38);
            panelImportButton.Name = "panelImportButton";
            panelImportButton.Size = new System.Drawing.Size(892, 33);
            panelImportButton.TabIndex = 2;
            // 
            // btnImport
            // 
            btnImport.Location = new System.Drawing.Point(784, 3);
            btnImport.Name = "btnImport";
            btnImport.Size = new System.Drawing.Size(105, 23);
            btnImport.TabIndex = 0;
            btnImport.Text = "Імпортувати";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // ilStatuses
            // 
            ilStatuses.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilStatuses.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilStatuses.ImageStream");
            ilStatuses.TransparentColor = System.Drawing.Color.Transparent;
            ilStatuses.Images.SetKeyName(0, "Status_Pending.png");
            ilStatuses.Images.SetKeyName(1, "Status_Running.png");
            ilStatuses.Images.SetKeyName(2, "Status_Completed.png");
            ilStatuses.Images.SetKeyName(3, "Status_Error.png");
            // 
            // timerRunAutoAction
            // 
            timerRunAutoAction.Tick += timerRunAutoAction_Tick;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnClose);
            panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            panelButtons.Location = new System.Drawing.Point(3, 482);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(892, 29);
            panelButtons.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.Location = new System.Drawing.Point(814, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Закрити";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FormImportFromCisNet
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(923, 534);
            ControlBox = false;
            Controls.Add(panelMain);
            MinimumSize = new System.Drawing.Size(800, 550);
            Name = "FormImportFromCisNet";
            Padding = new System.Windows.Forms.Padding(10);
            Text = "Імпорт творів із CISNet";
            Load += FormImportFromCisNet_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelImportButton.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel panelManualActions;
        private System.Windows.Forms.FlowLayoutPanel panelImportButton;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ListView lvAutoActions;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.Timer timerRunAutoAction;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnClose;
    }
}