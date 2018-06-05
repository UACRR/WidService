namespace RightholderWorkplaceSeparateForm.Rightholder
{
    partial class RightholderItemView
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBox3 = new Telerik.WinControls.UI.RadTextBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.rightholderModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(84, 65);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(55, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "radLabel1";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(84, 89);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(55, 18);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "radLabel1";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(84, 113);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(55, 18);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "radLabel1";
            // 
            // radTextBox1
            // 
            this.radTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightholderModelBindingSource, "FirstName", true));
            this.radTextBox1.Location = new System.Drawing.Point(168, 64);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(100, 20);
            this.radTextBox1.TabIndex = 1;
            // 
            // radTextBox2
            // 
            this.radTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightholderModelBindingSource, "LastName", true));
            this.radTextBox2.Location = new System.Drawing.Point(168, 88);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(100, 20);
            this.radTextBox2.TabIndex = 2;
            // 
            // radTextBox3
            // 
            this.radTextBox3.Location = new System.Drawing.Point(168, 112);
            this.radTextBox3.Name = "radTextBox3";
            this.radTextBox3.Size = new System.Drawing.Size(100, 20);
            this.radTextBox3.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(168, 166);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rightholderModelBindingSource
            // 
            this.rightholderModelBindingSource.DataSource = typeof(RightholderWorkplaceSeparateForm.Models.RightholderModel);
            // 
            // RightholderItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 560);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radTextBox3);
            this.Controls.Add(this.radTextBox2);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RightholderItemView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RightholderItemView";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadTextBox radTextBox3;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.BindingSource rightholderModelBindingSource;
    }
}
