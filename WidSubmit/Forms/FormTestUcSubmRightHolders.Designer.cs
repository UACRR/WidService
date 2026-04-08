namespace WidSubmit
{
    partial class FormTestUcSubmRightHolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestUcSubmRightHolders));
            this.ucSubmRightHolders = new WidSubmit.UcSubmRightHolders();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCurSubm = new System.Windows.Forms.Button();
            this.btnPrevSubm = new System.Windows.Forms.Button();
            this.btnSelectRightHolders = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucSubmRightHolders
            // 
            this.ucSubmRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubmRightHolders.Location = new System.Drawing.Point(3, 3);
            this.ucSubmRightHolders.Name = "ucSubmRightHolders";
            this.ucSubmRightHolders.Size = new System.Drawing.Size(789, 405);
            this.ucSubmRightHolders.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Controls.Add(this.ucSubmRightHolders, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCurSubm);
            this.flowLayoutPanel1.Controls.Add(this.btnPrevSubm);
            this.flowLayoutPanel1.Controls.Add(this.btnSelectRightHolders);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 414);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(785, 33);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCurSubm
            // 
            this.btnCurSubm.Location = new System.Drawing.Point(3, 3);
            this.btnCurSubm.Name = "btnCurSubm";
            this.btnCurSubm.Size = new System.Drawing.Size(121, 23);
            this.btnCurSubm.TabIndex = 0;
            this.btnCurSubm.Text = "Поточний сеанс";
            this.btnCurSubm.UseVisualStyleBackColor = true;
            this.btnCurSubm.Click += new System.EventHandler(this.btnCurSubm_Click);
            // 
            // btnPrevSubm
            // 
            this.btnPrevSubm.Location = new System.Drawing.Point(130, 3);
            this.btnPrevSubm.Name = "btnPrevSubm";
            this.btnPrevSubm.Size = new System.Drawing.Size(131, 23);
            this.btnPrevSubm.TabIndex = 0;
            this.btnPrevSubm.Text = "Попередній сеанс";
            this.btnPrevSubm.UseVisualStyleBackColor = true;
            this.btnPrevSubm.Click += new System.EventHandler(this.btnPrevSubm_Click);
            // 
            // btnSelectRightHolders
            // 
            this.btnSelectRightHolders.Location = new System.Drawing.Point(267, 3);
            this.btnSelectRightHolders.Name = "btnSelectRightHolders";
            this.btnSelectRightHolders.Size = new System.Drawing.Size(162, 23);
            this.btnSelectRightHolders.TabIndex = 0;
            this.btnSelectRightHolders.Text = "Вибір правовласників";
            this.btnSelectRightHolders.UseVisualStyleBackColor = true;
            this.btnSelectRightHolders.Click += new System.EventHandler(this.btnSelectRightHolders_Click);
            // 
            // FormTestUcSubmRightHolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTestUcSubmRightHolders";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcSubmRightHolders ucSubmRightHolders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCurSubm;
        private System.Windows.Forms.Button btnPrevSubm;
        private System.Windows.Forms.Button btnSelectRightHolders;
    }
}