namespace CwrTools
{
    partial class FormSpecImport
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFields = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbRecordType = new System.Windows.Forms.ComboBox();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.label1, 0, 1);
            this.panelMain.Controls.Add(this.tbFields, 0, 2);
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поля запису (вставте копію таблиці з PDF специфікації)";
            // 
            // tbFields
            // 
            this.tbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFields.Location = new System.Drawing.Point(3, 54);
            this.tbFields.Multiline = true;
            this.tbFields.Name = "tbFields";
            this.tbFields.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFields.Size = new System.Drawing.Size(789, 364);
            this.tbFields.TabIndex = 1;
            this.tbFields.WordWrap = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.cbRecordType);
            this.panelTop.Controls.Add(this.btnImport);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(789, 30);
            this.panelTop.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Код запису";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(200, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(91, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Імпортувати";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbRecordType
            // 
            this.cbRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecordType.FormattingEnabled = true;
            this.cbRecordType.Location = new System.Drawing.Point(73, 3);
            this.cbRecordType.Name = "cbRecordType";
            this.cbRecordType.Size = new System.Drawing.Size(121, 21);
            this.cbRecordType.TabIndex = 3;
            // 
            // FormSpecImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormSpecImport";
            this.Text = "Імпорт специфікацій";
            this.Load += new System.EventHandler(this.FormSpecImport_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFields;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbRecordType;
    }
}