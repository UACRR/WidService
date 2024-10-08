
namespace WidAdminConsole
{
    partial class UcParameters
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
            System.Windows.Forms.TableLayoutPanel panelTitle;
            this.labTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessage = new System.Windows.Forms.TableLayoutPanel();
            this.labMessage = new System.Windows.Forms.Label();
            this.panelParameters = new System.Windows.Forms.TableLayoutPanel();
            this.pgParameters = new System.Windows.Forms.PropertyGrid();
            this.panelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            panelTitle = new System.Windows.Forms.TableLayoutPanel();
            panelTitle.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.panelParameters.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.ColumnCount = 2;
            panelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 759F));
            panelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelTitle.Controls.Add(this.labTitle, 0, 0);
            panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTitle.Location = new System.Drawing.Point(3, 3);
            panelTitle.Name = "panelTitle";
            panelTitle.RowCount = 1;
            panelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelTitle.Size = new System.Drawing.Size(1239, 24);
            panelTitle.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle.Location = new System.Drawing.Point(3, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(753, 24);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Параметри завантаження і оновлення локальної бази даних WID";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(panelTitle, 0, 0);
            this.panelMain.Controls.Add(this.panelMessage, 0, 1);
            this.panelMain.Controls.Add(this.panelParameters, 0, 2);
            this.panelMain.Controls.Add(this.panelButtons, 0, 3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 5;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(1245, 541);
            this.panelMain.TabIndex = 0;
            // 
            // panelMessage
            // 
            this.panelMessage.ColumnCount = 2;
            this.panelMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 758F));
            this.panelMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMessage.Controls.Add(this.labMessage, 0, 0);
            this.panelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessage.Location = new System.Drawing.Point(3, 33);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.RowCount = 1;
            this.panelMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMessage.Size = new System.Drawing.Size(1239, 27);
            this.panelMessage.TabIndex = 1;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMessage.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMessage.Location = new System.Drawing.Point(3, 0);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(752, 27);
            this.labMessage.TabIndex = 0;
            this.labMessage.Text = "Введіть потрібні значення і натисніть Зберегти. Зміни можливі лише якщо жодна зад" +
    "ача незавершилась.";
            this.labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelParameters
            // 
            this.panelParameters.ColumnCount = 1;
            this.panelParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelParameters.Controls.Add(this.pgParameters, 0, 0);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParameters.Location = new System.Drawing.Point(3, 66);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.RowCount = 1;
            this.panelParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelParameters.Size = new System.Drawing.Size(1239, 421);
            this.panelParameters.TabIndex = 2;
            // 
            // pgParameters
            // 
            this.pgParameters.BackColor = System.Drawing.SystemColors.Window;
            this.pgParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgParameters.HelpVisible = false;
            this.pgParameters.Location = new System.Drawing.Point(3, 3);
            this.pgParameters.Name = "pgParameters";
            this.pgParameters.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgParameters.Size = new System.Drawing.Size(1233, 415);
            this.pgParameters.TabIndex = 0;
            this.pgParameters.ToolbarVisible = false;
            // 
            // panelButtons
            // 
            this.panelButtons.ColumnCount = 2;
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.panelButtons.Controls.Add(this.btnSave, 1, 0);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(3, 493);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.RowCount = 1;
            this.panelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelButtons.Size = new System.Drawing.Size(1239, 37);
            this.panelButtons.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(1127, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UcParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcParameters";
            this.Size = new System.Drawing.Size(1245, 541);
            this.Load += new System.EventHandler(this.UcParameters_Load);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelMessage;
        private System.Windows.Forms.TableLayoutPanel panelParameters;
        private System.Windows.Forms.TableLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.PropertyGrid pgParameters;
    }
}
