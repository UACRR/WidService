
namespace WidExport
{
    partial class UcMainWorkGroups
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
            this.panelAuthors = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtons = new System.Windows.Forms.ListView();
            this.labStatistics = new System.Windows.Forms.Label();
            this.panelGroupCommandsRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCreateSubmFile = new System.Windows.Forms.Button();
            this.btnRefreshWicIswc = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.ucWidGroupStatistics = new WidExport.UcWidGroupStatistics();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.panelGroups = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lvGroups = new System.Windows.Forms.ListView();
            this.panelGroupCommands = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMiddle = new System.Windows.Forms.SplitContainer();
            this.panelAuthors.SuspendLayout();
            this.panelGroupCommandsRight.SuspendLayout();
            this.panelGroups.SuspendLayout();
            this.panelGroupCommands.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).BeginInit();
            this.panelMiddle.Panel1.SuspendLayout();
            this.panelMiddle.Panel2.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAuthors
            // 
            this.panelAuthors.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelAuthors.ColumnCount = 1;
            this.panelAuthors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAuthors.Controls.Add(this.panelButtons, 0, 2);
            this.panelAuthors.Controls.Add(this.labStatistics, 0, 3);
            this.panelAuthors.Controls.Add(this.panelGroupCommandsRight, 0, 5);
            this.panelAuthors.Controls.Add(this.labelGroupName, 0, 0);
            this.panelAuthors.Controls.Add(this.ucWidGroupStatistics, 0, 4);
            this.panelAuthors.Controls.Add(this.label1, 0, 1);
            this.panelAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuthors.Location = new System.Drawing.Point(0, 0);
            this.panelAuthors.Name = "panelAuthors";
            this.panelAuthors.RowCount = 7;
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelAuthors.Size = new System.Drawing.Size(766, 510);
            this.panelAuthors.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Enabled = false;
            this.panelButtons.HideSelection = false;
            this.panelButtons.Location = new System.Drawing.Point(4, 51);
            this.panelButtons.MultiSelect = false;
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(758, 189);
            this.panelButtons.TabIndex = 1;
            this.panelButtons.UseCompatibleStateImageBehavior = false;
            this.panelButtons.View = System.Windows.Forms.View.List;
            // 
            // labStatistics
            // 
            this.labStatistics.AutoSize = true;
            this.labStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labStatistics.Location = new System.Drawing.Point(4, 244);
            this.labStatistics.Name = "labStatistics";
            this.labStatistics.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labStatistics.Size = new System.Drawing.Size(758, 25);
            this.labStatistics.TabIndex = 2;
            this.labStatistics.Text = "Статистика";
            // 
            // panelGroupCommandsRight
            // 
            this.panelGroupCommandsRight.Controls.Add(this.btnDeleteGroup);
            this.panelGroupCommandsRight.Controls.Add(this.btnUpdate);
            this.panelGroupCommandsRight.Controls.Add(this.btnShow);
            this.panelGroupCommandsRight.Controls.Add(this.btnCreateSubmFile);
            this.panelGroupCommandsRight.Controls.Add(this.btnClose);
            this.panelGroupCommandsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroupCommandsRight.Location = new System.Drawing.Point(4, 469);
            this.panelGroupCommandsRight.Name = "panelGroupCommandsRight";
            this.panelGroupCommandsRight.Size = new System.Drawing.Size(758, 28);
            this.panelGroupCommandsRight.TabIndex = 3;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.AutoSize = true;
            this.btnDeleteGroup.Location = new System.Drawing.Point(3, 3);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(71, 23);
            this.btnDeleteGroup.TabIndex = 0;
            this.btnDeleteGroup.Text = "Видалити";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Location = new System.Drawing.Point(80, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(71, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Оновити";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnShow
            // 
            this.btnShow.AutoSize = true;
            this.btnShow.Location = new System.Drawing.Point(157, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(78, 23);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Показати ...";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnCreateSubmFile
            // 
            this.btnCreateSubmFile.AutoSize = true;
            this.btnCreateSubmFile.Location = new System.Drawing.Point(241, 3);
            this.btnCreateSubmFile.Name = "btnCreateSubmFile";
            this.btnCreateSubmFile.Size = new System.Drawing.Size(144, 23);
            this.btnCreateSubmFile.TabIndex = 0;
            this.btnCreateSubmFile.Text = "Створити файл публікації";
            this.btnCreateSubmFile.UseVisualStyleBackColor = true;
            this.btnCreateSubmFile.Click += new System.EventHandler(this.btnCreateSubmFile_Click);
            // 
            // btnRefreshWicIswc
            // 
            this.btnRefreshWicIswc.Location = new System.Drawing.Point(94, 3);
            this.btnRefreshWicIswc.Name = "btnRefreshWicIswc";
            this.btnRefreshWicIswc.Size = new System.Drawing.Size(219, 23);
            this.btnRefreshWicIswc.TabIndex = 1;
            this.btnRefreshWicIswc.Text = "Передати прийняті твори в СМАРТ";
            this.btnRefreshWicIswc.UseVisualStyleBackColor = true;
            this.btnRefreshWicIswc.Click += new System.EventHandler(this.btnRefreshWicIswc_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Location = new System.Drawing.Point(391, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити Групу";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelGroupName
            // 
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGroupName.Location = new System.Drawing.Point(4, 1);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelGroupName.Size = new System.Drawing.Size(758, 20);
            this.labelGroupName.TabIndex = 4;
            this.labelGroupName.Text = "-- назва групи --";
            // 
            // ucWidGroupStatistics
            // 
            this.ucWidGroupStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWidGroupStatistics.Location = new System.Drawing.Point(4, 273);
            this.ucWidGroupStatistics.Name = "ucWidGroupStatistics";
            this.ucWidGroupStatistics.Size = new System.Drawing.Size(758, 189);
            this.ucWidGroupStatistics.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(758, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Автори/Правовласники";
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
            this.panelGroups.Size = new System.Drawing.Size(355, 510);
            this.panelGroups.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Групи";
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
            this.lvGroups.Size = new System.Drawing.Size(349, 442);
            this.lvGroups.TabIndex = 1;
            this.lvGroups.UseCompatibleStateImageBehavior = false;
            this.lvGroups.View = System.Windows.Forms.View.Details;
            this.lvGroups.SelectedIndexChanged += new System.EventHandler(this.lvGroups_SelectedIndexChanged);
            // 
            // panelGroupCommands
            // 
            this.panelGroupCommands.Controls.Add(this.btnAddGroup);
            this.panelGroupCommands.Controls.Add(this.btnRefreshWicIswc);
            this.panelGroupCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroupCommands.Location = new System.Drawing.Point(3, 471);
            this.panelGroupCommands.Name = "panelGroupCommands";
            this.panelGroupCommands.Size = new System.Drawing.Size(349, 28);
            this.panelGroupCommands.TabIndex = 2;
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
            this.tbFilter.Enabled = false;
            this.tbFilter.Location = new System.Drawing.Point(253, 4);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(100, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Enabled = false;
            this.btnApplyFilter.Location = new System.Drawing.Point(359, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(75, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Шукати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.tbFilter);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(4, 4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1125, 32);
            this.panelFilter.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelFilter, 0, 0);
            this.panelMain.Controls.Add(this.panelMiddle, 0, 1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1133, 566);
            this.panelMain.TabIndex = 1;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.panelMiddle.Location = new System.Drawing.Point(4, 43);
            this.panelMiddle.Name = "panelMiddle";
            // 
            // panelMiddle.Panel1
            // 
            this.panelMiddle.Panel1.Controls.Add(this.panelGroups);
            // 
            // panelMiddle.Panel2
            // 
            this.panelMiddle.Panel2.Controls.Add(this.panelAuthors);
            this.panelMiddle.Size = new System.Drawing.Size(1125, 510);
            this.panelMiddle.SplitterDistance = 355;
            this.panelMiddle.TabIndex = 1;
            // 
            // UcMainWorkGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcMainWorkGroups";
            this.Size = new System.Drawing.Size(1133, 566);
            this.Load += new System.EventHandler(this.UcMainWorkGroups_Load);
            this.panelAuthors.ResumeLayout(false);
            this.panelAuthors.PerformLayout();
            this.panelGroupCommandsRight.ResumeLayout(false);
            this.panelGroupCommandsRight.PerformLayout();
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            this.panelGroupCommands.ResumeLayout(false);
            this.panelGroupCommands.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMiddle.Panel1.ResumeLayout(false);
            this.panelMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMiddle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelAuthors;
        private System.Windows.Forms.ListView panelButtons;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.TableLayoutPanel panelGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvGroups;
        private System.Windows.Forms.FlowLayoutPanel panelGroupCommands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer panelMiddle;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnCreateSubmFile;
        private System.Windows.Forms.Label labStatistics;
        private System.Windows.Forms.FlowLayoutPanel panelGroupCommandsRight;
        private System.Windows.Forms.Label labelGroupName;
        private UcWidGroupStatistics ucWidGroupStatistics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshWicIswc;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
    }
}
