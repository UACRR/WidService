
namespace WidAdminConsole
{
    partial class UcTasks
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lvTasks = new System.Windows.Forms.ListView();
            this.colEntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTaskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPercentDone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStaredAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndedAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnShowError = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.lvTasks, 0, 0);
            this.panelMain.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.panelMain.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 5;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.panelMain.Size = new System.Drawing.Size(1171, 616);
            this.panelMain.TabIndex = 0;
            // 
            // lvTasks
            // 
            this.lvTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEntityName,
            this.colTaskName,
            this.colState,
            this.colPercentDone,
            this.colStaredAt,
            this.colEndedAt});
            this.lvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTasks.FullRowSelect = true;
            this.lvTasks.GridLines = true;
            this.lvTasks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTasks.HideSelection = false;
            this.lvTasks.Location = new System.Drawing.Point(3, 3);
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(1165, 500);
            this.lvTasks.TabIndex = 0;
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            this.lvTasks.View = System.Windows.Forms.View.Details;
            // 
            // colEntityName
            // 
            this.colEntityName.Text = "Об\'єкт";
            this.colEntityName.Width = 100;
            // 
            // colTaskName
            // 
            this.colTaskName.Text = "Задача";
            this.colTaskName.Width = 200;
            // 
            // colState
            // 
            this.colState.Text = "Статус";
            this.colState.Width = 100;
            // 
            // colPercentDone
            // 
            this.colPercentDone.Text = "Прогрес %";
            this.colPercentDone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPercentDone.Width = 100;
            // 
            // colStaredAt
            // 
            this.colStaredAt.Text = "Розпочато";
            this.colStaredAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colStaredAt.Width = 160;
            // 
            // colEndedAt
            // 
            this.colEndedAt.Text = "Завершено";
            this.colEndedAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colEndedAt.Width = 160;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Controls.Add(this.btnRun, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 559);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1165, 34);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Location = new System.Drawing.Point(870, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(99, 28);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Стартувати";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(975, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(92, 28);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Зупинити";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(1073, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel2.Controls.Add(this.btnShowError, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labMessage, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 509);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1165, 44);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnShowError
            // 
            this.btnShowError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowError.Location = new System.Drawing.Point(1047, 3);
            this.btnShowError.Name = "btnShowError";
            this.btnShowError.Size = new System.Drawing.Size(115, 38);
            this.btnShowError.TabIndex = 0;
            this.btnShowError.Text = "Показати помилку";
            this.btnShowError.UseVisualStyleBackColor = true;
            this.btnShowError.Click += new System.EventHandler(this.btnShowError_Click);
            // 
            // labMessage
            // 
            this.labMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMessage.Location = new System.Drawing.Point(3, 0);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(1038, 44);
            this.labMessage.TabIndex = 1;
            this.labMessage.Text = "<Varying message text>";
            this.labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // UcTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcTasks";
            this.Size = new System.Drawing.Size(1171, 616);
            this.Load += new System.EventHandler(this.UcTasks_Load);
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.ColumnHeader colEntityName;
        private System.Windows.Forms.ColumnHeader colTaskName;
        private System.Windows.Forms.ColumnHeader colState;
        private System.Windows.Forms.ColumnHeader colPercentDone;
        private System.Windows.Forms.ColumnHeader colStaredAt;
        private System.Windows.Forms.ColumnHeader colEndedAt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnShowError;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Timer timerRefresh;
    }
}
