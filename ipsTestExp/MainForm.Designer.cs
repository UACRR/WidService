using System.Drawing;
using sysAdminwp;

namespace ipsTestExp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.iAnketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBox1
            // 
            this.radTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaCompanyBindingSource, "Name", true));
            this.radTextBox1.Location = new System.Drawing.Point(100, 12);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(862, 24);
            this.radTextBox1.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(23, 15);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(37, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Назва";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id";
            // 
            // radTextBox2
            // 
            this.radTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormBindingSource, "CustId", true));
            this.radTextBox2.Location = new System.Drawing.Point(100, 45);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(125, 24);
            this.radTextBox2.TabIndex = 4;
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(ipsTestExp.MainForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 613);
            this.Controls.Add(this.radTextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radTextBox1);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "IPS";
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeDataChangeControl()
        {

        }

        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.BindingSource iAnketaCompanyBindingSource;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
    }
}

