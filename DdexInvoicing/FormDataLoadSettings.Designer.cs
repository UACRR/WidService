namespace DdexInvoicing
{
    partial class FormDataLoadSettings
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radBtnOk = new Telerik.WinControls.UI.RadButton();
            this.radBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radComboStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radComboSortCol = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radComboSortOrder = new Telerik.WinControls.UI.RadDropDownList();
            this.radComboRange = new Telerik.WinControls.UI.RadDropDownList();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboSortCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboSortOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboRange)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 136);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel2.Controls.Add(this.radBtnOk, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.radBtnCancel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 104);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(450, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // radBtnOk
            // 
            this.radBtnOk.Location = new System.Drawing.Point(227, 3);
            this.radBtnOk.Name = "radBtnOk";
            this.radBtnOk.Size = new System.Drawing.Size(107, 23);
            this.radBtnOk.TabIndex = 0;
            this.radBtnOk.Text = "Завантажити";
            this.radBtnOk.Click += new System.EventHandler(this.radBtnOk_Click);
            // 
            // radBtnCancel
            // 
            this.radBtnCancel.Location = new System.Drawing.Point(340, 3);
            this.radBtnCancel.Name = "radBtnCancel";
            this.radBtnCancel.Size = new System.Drawing.Size(107, 23);
            this.radBtnCancel.TabIndex = 0;
            this.radBtnCancel.Text = "Відмінити";
            this.radBtnCancel.Click += new System.EventHandler(this.radBtnCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radLabel1);
            this.flowLayoutPanel1.Controls.Add(this.radComboRange);
            this.flowLayoutPanel1.Controls.Add(this.radLabel2);
            this.flowLayoutPanel1.Controls.Add(this.radLabel3);
            this.flowLayoutPanel1.Controls.Add(this.radComboStatus);
            this.flowLayoutPanel1.Controls.Add(this.radLabel4);
            this.flowLayoutPanel1.Controls.Add(this.radComboSortCol);
            this.flowLayoutPanel1.Controls.Add(this.radLabel5);
            this.flowLayoutPanel1.Controls.Add(this.radComboSortOrder);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(450, 95);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(169, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Завантажити твори з діапазону";
            // 
            // radLabel2
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.radLabel2, true);
            this.radLabel2.Location = new System.Drawing.Point(428, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(2, 2);
            this.radLabel2.TabIndex = 2;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(3, 29);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(58, 18);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "Включити";
            // 
            // radComboStatus
            // 
            this.radComboStatus.DropDownHeight = 250;
            this.radComboStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.flowLayoutPanel1.SetFlowBreak(this.radComboStatus, true);
            this.radComboStatus.Location = new System.Drawing.Point(67, 29);
            this.radComboStatus.Name = "radComboStatus";
            this.radComboStatus.Size = new System.Drawing.Size(333, 20);
            this.radComboStatus.TabIndex = 4;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(3, 55);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(74, 18);
            this.radLabel4.TabIndex = 5;
            this.radLabel4.Text = "Сортувати за";
            // 
            // radComboSortCol
            // 
            this.radComboSortCol.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radComboSortCol.Location = new System.Drawing.Point(83, 55);
            this.radComboSortCol.Name = "radComboSortCol";
            this.radComboSortCol.Size = new System.Drawing.Size(151, 20);
            this.radComboSortCol.TabIndex = 6;
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(240, 55);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(58, 18);
            this.radLabel5.TabIndex = 7;
            this.radLabel5.Text = "у порядку";
            // 
            // radComboSortOrder
            // 
            this.radComboSortOrder.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radComboSortOrder.Location = new System.Drawing.Point(304, 55);
            this.radComboSortOrder.Name = "radComboSortOrder";
            this.radComboSortOrder.Size = new System.Drawing.Size(118, 20);
            this.radComboSortOrder.TabIndex = 6;
            // 
            // radComboRange
            // 
            this.radComboRange.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.radComboRange.Location = new System.Drawing.Point(178, 3);
            this.radComboRange.Name = "radComboRange";
            this.radComboRange.Size = new System.Drawing.Size(244, 20);
            this.radComboRange.TabIndex = 8;
            // 
            // FormDataLoadSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 136);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDataLoadSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметри завантаження";
            this.Load += new System.EventHandler(this.FormDataLoadSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCancel)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboSortCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboSortOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboRange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadButton radBtnOk;
        private Telerik.WinControls.UI.RadButton radBtnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList radComboStatus;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList radComboSortCol;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadDropDownList radComboSortOrder;
        private Telerik.WinControls.UI.RadDropDownList radComboRange;
    }
}