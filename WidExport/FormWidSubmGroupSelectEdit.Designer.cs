
namespace WidExport
{
    partial class FormWidSubmGroupSelectEdit
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
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.panelGroups = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lvGroups = new System.Windows.Forms.ListView();
            this.panelGroupCommands = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.panelAuthors = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lvParties = new System.Windows.Forms.ListView();
            this.panelFormCommands = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelGroups.SuspendLayout();
            this.panelGroupCommands.SuspendLayout();
            this.panelAuthors.SuspendLayout();
            this.panelFormCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelFilter, 0, 1);
            this.panelMain.Controls.Add(this.label1, 0, 0);
            this.panelMain.Controls.Add(this.panelMiddle, 0, 2);
            this.panelMain.Controls.Add(this.panelFormCommands, 0, 3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 5;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.tbFilter);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(4, 34);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(792, 32);
            this.panelFilter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Показувати групи для авторів/правовласників";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(253, 4);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(100, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(359, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(75, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Шукати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(792, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Групи творів для передачі в WID одним файлом";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(4, 73);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.panelGroups);
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.panelAuthors);
            this.panelMiddle.Size = new System.Drawing.Size(792, 329);
            this.panelMiddle.SplitterDistance = 330;
            this.panelMiddle.TabIndex = 1;
            // 
            // panelGroups
            // 
            this.panelGroups.ColumnCount = 1;
            this.panelGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelGroups.Controls.Add(this.label3, 0, 0);
            this.panelGroups.Controls.Add(this.lvGroups, 0, 1);
            this.panelGroups.Controls.Add(this.panelGroupCommands, 0, 2);
            this.panelGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroups.Location = new System.Drawing.Point(0, 0);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.RowCount = 4;
            this.panelGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelGroups.Size = new System.Drawing.Size(330, 329);
            this.panelGroups.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Перелік груп";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvGroups
            // 
            this.lvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGroups.FullRowSelect = true;
            this.lvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvGroups.HideSelection = false;
            this.lvGroups.Location = new System.Drawing.Point(3, 23);
            this.lvGroups.MultiSelect = false;
            this.lvGroups.Name = "lvGroups";
            this.lvGroups.Size = new System.Drawing.Size(324, 261);
            this.lvGroups.TabIndex = 1;
            this.lvGroups.UseCompatibleStateImageBehavior = false;
            this.lvGroups.View = System.Windows.Forms.View.Details;
            this.lvGroups.SelectedIndexChanged += new System.EventHandler(this.lvGroups_SelectedIndexChanged);
            this.lvGroups.DoubleClick += new System.EventHandler(this.lvGroups_DoubleClick);
            // 
            // panelGroupCommands
            // 
            this.panelGroupCommands.Controls.Add(this.btnAddGroup);
            this.panelGroupCommands.Controls.Add(this.btnDeleteGroup);
            this.panelGroupCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroupCommands.Location = new System.Drawing.Point(3, 290);
            this.panelGroupCommands.Name = "panelGroupCommands";
            this.panelGroupCommands.Size = new System.Drawing.Size(324, 28);
            this.panelGroupCommands.TabIndex = 2;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.AutoSize = true;
            this.btnAddGroup.Location = new System.Drawing.Point(3, 3);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(85, 23);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "Додати групу";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.AutoSize = true;
            this.btnDeleteGroup.Location = new System.Drawing.Point(94, 3);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteGroup.TabIndex = 0;
            this.btnDeleteGroup.Text = "Видалити останню групу";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // panelAuthors
            // 
            this.panelAuthors.ColumnCount = 1;
            this.panelAuthors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAuthors.Controls.Add(this.label4, 0, 0);
            this.panelAuthors.Controls.Add(this.lvParties, 0, 1);
            this.panelAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuthors.Location = new System.Drawing.Point(0, 0);
            this.panelAuthors.Name = "panelAuthors";
            this.panelAuthors.RowCount = 3;
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelAuthors.Size = new System.Drawing.Size(458, 329);
            this.panelAuthors.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(452, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Перевік авторів/правовласників групи";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvParties
            // 
            this.lvParties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvParties.Enabled = false;
            this.lvParties.HideSelection = false;
            this.lvParties.Location = new System.Drawing.Point(3, 23);
            this.lvParties.MultiSelect = false;
            this.lvParties.Name = "lvParties";
            this.lvParties.Size = new System.Drawing.Size(452, 295);
            this.lvParties.TabIndex = 1;
            this.lvParties.UseCompatibleStateImageBehavior = false;
            this.lvParties.View = System.Windows.Forms.View.List;
            // 
            // panelFormCommands
            // 
            this.panelFormCommands.Controls.Add(this.btnClose);
            this.panelFormCommands.Controls.Add(this.btnSelect);
            this.panelFormCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormCommands.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelFormCommands.Location = new System.Drawing.Point(4, 409);
            this.panelFormCommands.Name = "panelFormCommands";
            this.panelFormCommands.Size = new System.Drawing.Size(792, 28);
            this.panelFormCommands.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Location = new System.Drawing.Point(714, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Вийти";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = true;
            this.btnSelect.Location = new System.Drawing.Point(633, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Вибрати";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FormWidSubmGroupSelectEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormWidSubmGroupSelectEdit";
            this.Text = "Створення і вибір груп творів для передачі в WID";
            this.Load += new System.EventHandler(this.FormWidSubmGroupSelectEdit_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            this.panelGroupCommands.ResumeLayout(false);
            this.panelGroupCommands.PerformLayout();
            this.panelAuthors.ResumeLayout(false);
            this.panelAuthors.PerformLayout();
            this.panelFormCommands.ResumeLayout(false);
            this.panelFormCommands.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.TableLayoutPanel panelGroups;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvGroups;
        private System.Windows.Forms.FlowLayoutPanel panelGroupCommands;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.TableLayoutPanel panelAuthors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvParties;
        private System.Windows.Forms.FlowLayoutPanel panelFormCommands;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
    }
}