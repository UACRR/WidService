
namespace WidExport
{
    partial class UcWidSubmWorkPerformers

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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lvPerformers = new System.Windows.Forms.ListView();
            this.panelCommands = new System.Windows.Forms.TableLayoutPanel();
            this.tbPerformer = new System.Windows.Forms.TextBox();
            this.btnUkr = new System.Windows.Forms.Button();
            this.btnRus = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.lvPerformers, 0, 0);
            this.panelMain.Controls.Add(this.panelCommands, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(632, 340);
            this.panelMain.TabIndex = 0;
            // 
            // lvPerformers
            // 
            this.lvPerformers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPerformers.FullRowSelect = true;
            this.lvPerformers.HideSelection = false;
            this.lvPerformers.Location = new System.Drawing.Point(3, 3);
            this.lvPerformers.MultiSelect = false;
            this.lvPerformers.Name = "lvPerformers";
            this.lvPerformers.Size = new System.Drawing.Size(626, 290);
            this.lvPerformers.TabIndex = 0;
            this.lvPerformers.UseCompatibleStateImageBehavior = false;
            this.lvPerformers.View = System.Windows.Forms.View.Details;
            this.lvPerformers.SelectedIndexChanged += new System.EventHandler(this.lvPerformers_SelectedIndexChanged);
            // 
            // panelCommands
            // 
            this.panelCommands.ColumnCount = 7;
            this.panelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.panelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.panelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.panelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.panelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelCommands.Controls.Add(this.tbPerformer, 0, 0);
            this.panelCommands.Controls.Add(this.btnUkr, 1, 0);
            this.panelCommands.Controls.Add(this.btnRus, 2, 0);
            this.panelCommands.Controls.Add(this.btnApply, 3, 0);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommands.Location = new System.Drawing.Point(3, 299);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.RowCount = 1;
            this.panelCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelCommands.Size = new System.Drawing.Size(626, 30);
            this.panelCommands.TabIndex = 1;
            // 
            // tbPerformer
            // 
            this.tbPerformer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPerformer.Location = new System.Drawing.Point(3, 3);
            this.tbPerformer.Name = "tbPerformer";
            this.tbPerformer.Size = new System.Drawing.Size(298, 20);
            this.tbPerformer.TabIndex = 0;
            this.tbPerformer.TextChanged += new System.EventHandler(this.tbPerformer_TextChanged);
            // 
            // btnUkr
            // 
            this.btnUkr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUkr.Location = new System.Drawing.Point(307, 3);
            this.btnUkr.Name = "btnUkr";
            this.btnUkr.Size = new System.Drawing.Size(58, 24);
            this.btnUkr.TabIndex = 1;
            this.btnUkr.Text = "Укр";
            this.btnUkr.UseVisualStyleBackColor = true;
            this.btnUkr.Click += new System.EventHandler(this.btnUkr_Click);
            // 
            // btnRus
            // 
            this.btnRus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRus.Location = new System.Drawing.Point(371, 3);
            this.btnRus.Name = "btnRus";
            this.btnRus.Size = new System.Drawing.Size(43, 24);
            this.btnRus.TabIndex = 1;
            this.btnRus.Text = "Рос";
            this.btnRus.UseVisualStyleBackColor = true;
            this.btnRus.Click += new System.EventHandler(this.btnRus_Click);
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Location = new System.Drawing.Point(420, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(83, 24);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Застосувати";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // UcWidSubmWorkPerformers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcWidSubmWorkPerformers";
            this.Size = new System.Drawing.Size(632, 340);
            this.Load += new System.EventHandler(this.UcWidSubmPerformers_Load);
            this.panelMain.ResumeLayout(false);
            this.panelCommands.ResumeLayout(false);
            this.panelCommands.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.ListView lvPerformers;
        private System.Windows.Forms.TableLayoutPanel panelCommands;
        private System.Windows.Forms.TextBox tbPerformer;
        private System.Windows.Forms.Button btnUkr;
        private System.Windows.Forms.Button btnRus;
        private System.Windows.Forms.Button btnApply;
    }
}
