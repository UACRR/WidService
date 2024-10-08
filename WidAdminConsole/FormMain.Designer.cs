
namespace WidAdminConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tcPages = new System.Windows.Forms.TabControl();
            this.tpParameters = new System.Windows.Forms.TabPage();
            this.ucParameters1 = new WidAdminConsole.UcParameters();
            this.tpTasks = new System.Windows.Forms.TabPage();
            this.ucTasks1 = new WidAdminConsole.UcTasks();
            this.tcPages.SuspendLayout();
            this.tpParameters.SuspendLayout();
            this.tpTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPages
            // 
            this.tcPages.Controls.Add(this.tpParameters);
            this.tcPages.Controls.Add(this.tpTasks);
            this.tcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPages.Location = new System.Drawing.Point(0, 0);
            this.tcPages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(933, 554);
            this.tcPages.TabIndex = 0;
            // 
            // tpParameters
            // 
            this.tpParameters.Controls.Add(this.ucParameters1);
            this.tpParameters.Location = new System.Drawing.Point(4, 25);
            this.tpParameters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpParameters.Name = "tpParameters";
            this.tpParameters.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpParameters.Size = new System.Drawing.Size(925, 525);
            this.tpParameters.TabIndex = 0;
            this.tpParameters.Text = "Параметри";
            this.tpParameters.UseVisualStyleBackColor = true;
            // 
            // ucParameters1
            // 
            this.ucParameters1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucParameters1.Location = new System.Drawing.Point(3, 4);
            this.ucParameters1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ucParameters1.Name = "ucParameters1";
            this.ucParameters1.Size = new System.Drawing.Size(919, 517);
            this.ucParameters1.TabIndex = 0;
            // 
            // tpTasks
            // 
            this.tpTasks.Controls.Add(this.ucTasks1);
            this.tpTasks.Location = new System.Drawing.Point(4, 25);
            this.tpTasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTasks.Name = "tpTasks";
            this.tpTasks.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpTasks.Size = new System.Drawing.Size(925, 525);
            this.tpTasks.TabIndex = 1;
            this.tpTasks.Text = "Задачі";
            this.tpTasks.UseVisualStyleBackColor = true;
            // 
            // ucTasks1
            // 
            this.ucTasks1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTasks1.Location = new System.Drawing.Point(3, 4);
            this.ucTasks1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ucTasks1.Name = "ucTasks1";
            this.ucTasks1.Size = new System.Drawing.Size(919, 517);
            this.ucTasks1.TabIndex = 0;
            this.ucTasks1.Load += new System.EventHandler(this.ucTasks1_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.tcPages);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "Консоль управлыння WID";
            this.tcPages.ResumeLayout(false);
            this.tpParameters.ResumeLayout(false);
            this.tpTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPages;
        private System.Windows.Forms.TabPage tpParameters;
        private System.Windows.Forms.TabPage tpTasks;
        private UcParameters ucParameters1;
        private UcTasks ucTasks1;
    }
}

