namespace sysAdminwp.viewPageDictionaryControls
{
    partial class ComplexDictionaryControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.complexTreeView = new Telerik.WinControls.UI.RadTreeView();
            this.tableLayout_MarkupElement = new System.Windows.Forms.TableLayoutPanel();
            this.dictBaseEditPanel = new System.Windows.Forms.BindingSource(this.components);
            this.dictBaseTypeIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlPanel = new IpsViewComponentLibrary.Common.Editors.IpsPanel();
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).BeginInit();
            this.tableLayout_MarkupElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseEditPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // complexTreeView
            // 
            this.complexTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.complexTreeView.Location = new System.Drawing.Point(3, 3);
            this.complexTreeView.Name = "complexTreeView";
            this.complexTreeView.Size = new System.Drawing.Size(192, 560);
            this.complexTreeView.SpacingBetweenNodes = -1;
            this.complexTreeView.TabIndex = 5;
            this.complexTreeView.ThemeName = "Office2013Light";
            this.complexTreeView.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.complexTreeView_SelectedNodeChanged);
            // 
            // tableLayout_MarkupElement
            // 
            this.tableLayout_MarkupElement.ColumnCount = 2;
            this.tableLayout_MarkupElement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.82682F));
            this.tableLayout_MarkupElement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.17319F));
            this.tableLayout_MarkupElement.Controls.Add(this.complexTreeView, 0, 0);
            this.tableLayout_MarkupElement.Controls.Add(this.controlPanel, 1, 0);
            this.tableLayout_MarkupElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout_MarkupElement.Location = new System.Drawing.Point(0, 0);
            this.tableLayout_MarkupElement.Name = "tableLayout_MarkupElement";
            this.tableLayout_MarkupElement.RowCount = 1;
            this.tableLayout_MarkupElement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout_MarkupElement.Size = new System.Drawing.Size(1432, 566);
            this.tableLayout_MarkupElement.TabIndex = 1;
            // 
            // dictBaseEditPanel
            // 
            this.dictBaseEditPanel.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // dictBaseTypeIBindingSource
            // 
            this.dictBaseTypeIBindingSource.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // controlPanel
            // 
            this.controlPanel.BorderVisible = false;
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(201, 3);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1228, 560);
            this.controlPanel.TabIndex = 6;
            // 
            // ComplexDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayout_MarkupElement);
            this.Name = "ComplexDictionaryControl";
            this.Size = new System.Drawing.Size(1432, 566);
            ((System.ComponentModel.ISupportInitialize)(this.complexTreeView)).EndInit();
            this.tableLayout_MarkupElement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseEditPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictBaseTypeIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dictBaseTypeIBindingSource;
        private System.Windows.Forms.BindingSource dictBaseEditPanel;
        private Telerik.WinControls.UI.RadTreeView complexTreeView;
        private System.Windows.Forms.TableLayoutPanel tableLayout_MarkupElement;
        private IpsViewComponentLibrary.Common.Editors.IpsPanel controlPanel;
    }
}
