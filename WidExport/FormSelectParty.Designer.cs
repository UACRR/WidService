
namespace WidExport
{
    partial class FormSelectParty
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
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvParties = new System.Windows.Forms.ListView();
            this.panelCommands = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Controls.Add(this.lvParties, 0, 1);
            this.panelMain.Controls.Add(this.panelCommands, 0, 2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 4;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.ColumnCount = 4;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 391F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelTop.Controls.Add(this.label1, 0, 0);
            this.panelTop.Controls.Add(this.tbFilter, 1, 0);
            this.panelTop.Controls.Add(this.btnSearch, 2, 0);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 1;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(794, 27);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Перші 100 Авторів/Правовласників ( шаблон імені або базовий код IPI )";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbFilter
            // 
            this.tbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFilter.Location = new System.Drawing.Point(394, 3);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(288, 20);
            this.tbFilter.TabIndex = 1;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(688, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Шукати";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvParties
            // 
            this.lvParties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvParties.FullRowSelect = true;
            this.lvParties.HideSelection = false;
            this.lvParties.Location = new System.Drawing.Point(3, 36);
            this.lvParties.MultiSelect = false;
            this.lvParties.Name = "lvParties";
            this.lvParties.Size = new System.Drawing.Size(794, 365);
            this.lvParties.TabIndex = 1;
            this.lvParties.UseCompatibleStateImageBehavior = false;
            this.lvParties.View = System.Windows.Forms.View.Details;
            this.lvParties.SelectedIndexChanged += new System.EventHandler(this.lvParties_SelectedIndexChanged);
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnClose);
            this.panelCommands.Controls.Add(this.btnSelect);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommands.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelCommands.Location = new System.Drawing.Point(3, 407);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(794, 31);
            this.panelCommands.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(716, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Скасувати";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(635, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Вибрати";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FormSelectParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormSelectParty";
            this.Text = "Вибір автора/правовласника з бази даних IPI";
            this.Load += new System.EventHandler(this.FormSelectParty_Load);
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvParties;
        private System.Windows.Forms.FlowLayoutPanel panelCommands;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
    }
}