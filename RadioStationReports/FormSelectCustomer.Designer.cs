namespace RadioStationReports
{
    partial class FormSelectCustomer
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
            panelMain = new System.Windows.Forms.TableLayoutPanel();
            panelSearchCustomer = new System.Windows.Forms.TableLayoutPanel();
            lvFoundCustomers = new System.Windows.Forms.ListView();
            panelCustomerFilter = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            tbSearchFilter = new System.Windows.Forms.TextBox();
            btnSearchCustomer = new System.Windows.Forms.Button();
            lvPlaces = new System.Windows.Forms.ListView();
            label2 = new System.Windows.Forms.Label();
            panelFormActions = new System.Windows.Forms.TableLayoutPanel();
            btnClose = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            panelMain.SuspendLayout();
            panelSearchCustomer.SuspendLayout();
            panelCustomerFilter.SuspendLayout();
            panelFormActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.ColumnCount = 2;
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelMain.Controls.Add(panelSearchCustomer, 0, 0);
            panelMain.Controls.Add(panelFormActions, 0, 1);
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 2;
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            panelMain.Size = new System.Drawing.Size(676, 447);
            panelMain.TabIndex = 0;
            // 
            // panelSearchCustomer
            // 
            panelSearchCustomer.ColumnCount = 2;
            panelSearchCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelSearchCustomer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelSearchCustomer.Controls.Add(lvFoundCustomers, 0, 1);
            panelSearchCustomer.Controls.Add(panelCustomerFilter, 0, 0);
            panelSearchCustomer.Controls.Add(lvPlaces, 0, 3);
            panelSearchCustomer.Controls.Add(label2, 0, 2);
            panelSearchCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSearchCustomer.Location = new System.Drawing.Point(3, 3);
            panelSearchCustomer.Name = "panelSearchCustomer";
            panelSearchCustomer.RowCount = 5;
            panelSearchCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            panelSearchCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelSearchCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            panelSearchCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelSearchCustomer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelSearchCustomer.Size = new System.Drawing.Size(665, 407);
            panelSearchCustomer.TabIndex = 0;
            // 
            // lvFoundCustomers
            // 
            lvFoundCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            lvFoundCustomers.HideSelection = false;
            lvFoundCustomers.Location = new System.Drawing.Point(3, 41);
            lvFoundCustomers.Name = "lvFoundCustomers";
            lvFoundCustomers.Size = new System.Drawing.Size(654, 162);
            lvFoundCustomers.TabIndex = 0;
            lvFoundCustomers.UseCompatibleStateImageBehavior = false;
            lvFoundCustomers.SelectedIndexChanged += lvFoundCustomers_SelectedIndexChanged;
            // 
            // panelCustomerFilter
            // 
            panelCustomerFilter.Controls.Add(label1);
            panelCustomerFilter.Controls.Add(tbSearchFilter);
            panelCustomerFilter.Controls.Add(btnSearchCustomer);
            panelCustomerFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCustomerFilter.Location = new System.Drawing.Point(3, 3);
            panelCustomerFilter.Name = "panelCustomerFilter";
            panelCustomerFilter.Size = new System.Drawing.Size(654, 32);
            panelCustomerFilter.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(274, 15);
            label1.TabIndex = 0;
            label1.Text = "Вибрати користуча за текстом в назві або кодом";
            // 
            // tbSearchFilter
            // 
            tbSearchFilter.Location = new System.Drawing.Point(283, 3);
            tbSearchFilter.Name = "tbSearchFilter";
            tbSearchFilter.Size = new System.Drawing.Size(203, 23);
            tbSearchFilter.TabIndex = 1;
            tbSearchFilter.TextChanged += tbSearchFilter_TextChanged;
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Location = new System.Drawing.Point(492, 3);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new System.Drawing.Size(75, 23);
            btnSearchCustomer.TabIndex = 2;
            btnSearchCustomer.Text = "Шукати";
            btnSearchCustomer.UseVisualStyleBackColor = true;
            btnSearchCustomer.Click += btnSearchCustomer_Click;
            // 
            // lvPlaces
            // 
            lvPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            lvPlaces.HideSelection = false;
            lvPlaces.Location = new System.Drawing.Point(3, 237);
            lvPlaces.Name = "lvPlaces";
            lvPlaces.Size = new System.Drawing.Size(654, 162);
            lvPlaces.TabIndex = 2;
            lvPlaces.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 212);
            label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Майданчики";
            // 
            // panelFormActions
            // 
            panelFormActions.ColumnCount = 4;
            panelFormActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelFormActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            panelFormActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            panelFormActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            panelFormActions.Controls.Add(btnClose, 2, 0);
            panelFormActions.Controls.Add(btnApply, 1, 0);
            panelFormActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFormActions.Location = new System.Drawing.Point(3, 416);
            panelFormActions.Name = "panelFormActions";
            panelFormActions.RowCount = 1;
            panelFormActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelFormActions.Size = new System.Drawing.Size(665, 28);
            panelFormActions.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            btnClose.Location = new System.Drawing.Point(570, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(87, 22);
            btnClose.TabIndex = 0;
            btnClose.Text = "Відмінити";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new System.Drawing.Point(477, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(87, 22);
            btnApply.TabIndex = 1;
            btnApply.Text = "Застосувати";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // FormSelectCustomer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(676, 447);
            ControlBox = false;
            Controls.Add(panelMain);
            Name = "FormSelectCustomer";
            ShowInTaskbar = false;
            Text = "Вибір користувача";
            Load += FormSelectCustomer_Load;
            panelMain.ResumeLayout(false);
            panelSearchCustomer.ResumeLayout(false);
            panelSearchCustomer.PerformLayout();
            panelCustomerFilter.ResumeLayout(false);
            panelCustomerFilter.PerformLayout();
            panelFormActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelFormActions;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel panelSearchCustomer;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ListView lvFoundCustomers;
        private System.Windows.Forms.FlowLayoutPanel panelCustomerFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearchFilter;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.ListView lvPlaces;
        private System.Windows.Forms.Label label2;
    }
}