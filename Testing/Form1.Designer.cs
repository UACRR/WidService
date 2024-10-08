
namespace Testing
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
            this.btnLoadIpiFromDump = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadIpiFromDump
            // 
            this.btnLoadIpiFromDump.Location = new System.Drawing.Point(485, 320);
            this.btnLoadIpiFromDump.Name = "btnLoadIpiFromDump";
            this.btnLoadIpiFromDump.Size = new System.Drawing.Size(195, 23);
            this.btnLoadIpiFromDump.TabIndex = 0;
            this.btnLoadIpiFromDump.Text = "LoadI Ipi From Dump";
            this.btnLoadIpiFromDump.UseVisualStyleBackColor = true;
            this.btnLoadIpiFromDump.Click += new System.EventHandler(this.btnLoadIpiFromDump_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ConnectionString";
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Location = new System.Drawing.Point(118, 28);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(476, 20);
            this.tbConnectionString.TabIndex = 2;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(600, 26);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(126, 23);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.tbConnectionString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadIpiFromDump);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadIpiFromDump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
    }
}

