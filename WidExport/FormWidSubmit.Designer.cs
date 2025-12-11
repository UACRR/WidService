
namespace WidExport
{
    partial class FormWidSubmit
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
            this.splitMiddle = new System.Windows.Forms.SplitContainer();
            this.panelAuthors = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvParties = new System.Windows.Forms.ListView();
            this.panelPartyCommands = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddParty = new System.Windows.Forms.Button();
            this.btnRemoveParty = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.panelLeft = new WidExport.UcWidSubmWorks();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).BeginInit();
            this.splitMiddle.Panel1.SuspendLayout();
            this.splitMiddle.Panel2.SuspendLayout();
            this.splitMiddle.SuspendLayout();
            this.panelAuthors.SuspendLayout();
            this.panelPartyCommands.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.splitMiddle, 0, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 3;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(1108, 617);
            this.panelMain.TabIndex = 0;
            // 
            // splitMiddle
            // 
            this.splitMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMiddle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMiddle.Location = new System.Drawing.Point(4, 4);
            this.splitMiddle.Name = "splitMiddle";
            // 
            // splitMiddle.Panel1
            // 
            this.splitMiddle.Panel1.Controls.Add(this.panelAuthors);
            // 
            // splitMiddle.Panel2
            // 
            this.splitMiddle.Panel2.Controls.Add(this.panelLeft);
            this.splitMiddle.Size = new System.Drawing.Size(1100, 591);
            this.splitMiddle.SplitterDistance = 359;
            this.splitMiddle.TabIndex = 0;
            // 
            // panelAuthors
            // 
            this.panelAuthors.ColumnCount = 1;
            this.panelAuthors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAuthors.Controls.Add(this.label2, 0, 0);
            this.panelAuthors.Controls.Add(this.lvParties, 0, 2);
            this.panelAuthors.Controls.Add(this.panelPartyCommands, 0, 3);
            this.panelAuthors.Controls.Add(this.panelFilter, 0, 1);
            this.panelAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuthors.Location = new System.Drawing.Point(0, 0);
            this.panelAuthors.Name = "panelAuthors";
            this.panelAuthors.RowCount = 5;
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelAuthors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelAuthors.Size = new System.Drawing.Size(359, 591);
            this.panelAuthors.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Автори/Правовласники";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvParties
            // 
            this.lvParties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvParties.FullRowSelect = true;
            this.lvParties.HideSelection = false;
            this.lvParties.Location = new System.Drawing.Point(3, 65);
            this.lvParties.MultiSelect = false;
            this.lvParties.Name = "lvParties";
            this.lvParties.Size = new System.Drawing.Size(353, 478);
            this.lvParties.TabIndex = 1;
            this.lvParties.UseCompatibleStateImageBehavior = false;
            this.lvParties.View = System.Windows.Forms.View.Details;
            this.lvParties.SelectedIndexChanged += new System.EventHandler(this.lvParties_SelectedIndexChanged);
            // 
            // panelPartyCommands
            // 
            this.panelPartyCommands.Controls.Add(this.btnAddParty);
            this.panelPartyCommands.Controls.Add(this.btnRemoveParty);
            this.panelPartyCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPartyCommands.Location = new System.Drawing.Point(3, 549);
            this.panelPartyCommands.Name = "panelPartyCommands";
            this.panelPartyCommands.Size = new System.Drawing.Size(353, 31);
            this.panelPartyCommands.TabIndex = 2;
            // 
            // btnAddParty
            // 
            this.btnAddParty.Location = new System.Drawing.Point(3, 3);
            this.btnAddParty.Name = "btnAddParty";
            this.btnAddParty.Size = new System.Drawing.Size(75, 23);
            this.btnAddParty.TabIndex = 0;
            this.btnAddParty.Text = "Додати";
            this.btnAddParty.UseVisualStyleBackColor = true;
            this.btnAddParty.Click += new System.EventHandler(this.btnAddParty_Click);
            // 
            // btnRemoveParty
            // 
            this.btnRemoveParty.Location = new System.Drawing.Point(84, 3);
            this.btnRemoveParty.Name = "btnRemoveParty";
            this.btnRemoveParty.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveParty.TabIndex = 0;
            this.btnRemoveParty.Text = "Видалити";
            this.btnRemoveParty.UseVisualStyleBackColor = true;
            this.btnRemoveParty.Click += new System.EventHandler(this.btnRemoveParty_Click);
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.tbFilter);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 29);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(353, 30);
            this.panelFilter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вибрати за текстом в назві";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(156, 4);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(100, 20);
            this.tbFilter.TabIndex = 1;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(262, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(83, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Застосувати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(737, 591);
            this.panelLeft.TabIndex = 0;
            // 
            // FormWidSubmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 617);
            this.Controls.Add(this.panelMain);
            this.Name = "FormWidSubmit";
            this.Text = "Підготовка творів для передачі в WID";
            this.Load += new System.EventHandler(this.FormWidSubmit_Load);
            this.panelMain.ResumeLayout(false);
            this.splitMiddle.Panel1.ResumeLayout(false);
            this.splitMiddle.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).EndInit();
            this.splitMiddle.ResumeLayout(false);
            this.panelAuthors.ResumeLayout(false);
            this.panelAuthors.PerformLayout();
            this.panelPartyCommands.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.SplitContainer splitMiddle;
        private System.Windows.Forms.TableLayoutPanel panelAuthors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvParties;
        private System.Windows.Forms.FlowLayoutPanel panelPartyCommands;
        private System.Windows.Forms.Button btnAddParty;
        private System.Windows.Forms.Button btnRemoveParty;
        private UcWidSubmWorks panelLeft;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnApplyFilter;
    }
}