namespace DdexInvoicing
{
    partial class UcCcidInvoiceTestResults
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
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.radBtnCopy = new Telerik.WinControls.UI.RadButton();
            this.lvResult = new System.Windows.Forms.ListView();
            this.ucCcidInvoiceTestDetails17 = new DdexInvoicing.UcCcidInvoiceTestDetails17();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 1;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Controls.Add(this.lvResult, 0, 1);
            this.panelMain.Controls.Add(this.ucCcidInvoiceTestDetails17, 0, 3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 5;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelMain.Size = new System.Drawing.Size(976, 461);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.ColumnCount = 3;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 696F));
            this.panelTop.Controls.Add(this.btnRefresh, 1, 0);
            this.panelTop.Controls.Add(this.radBtnCopy, 0, 0);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 1;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(970, 34);
            this.panelTop.TabIndex = 2;
            // 
            // radBtnCopy
            // 
            this.radBtnCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radBtnCopy.Location = new System.Drawing.Point(3, 3);
            this.radBtnCopy.Name = "radBtnCopy";
            this.radBtnCopy.Size = new System.Drawing.Size(181, 28);
            this.radBtnCopy.TabIndex = 0;
            this.radBtnCopy.Text = "Скопіювати в буфер обміну";
            this.radBtnCopy.Click += new System.EventHandler(this.radBtnCopy_Click);
            // 
            // lvResult
            // 
            this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResult.FullRowSelect = true;
            this.lvResult.GridLines = true;
            this.lvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvResult.HideSelection = false;
            this.lvResult.Location = new System.Drawing.Point(3, 43);
            this.lvResult.MultiSelect = false;
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(970, 221);
            this.lvResult.TabIndex = 3;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            // 
            // ucCcidInvoiceTestDetails17
            // 
            this.ucCcidInvoiceTestDetails17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCcidInvoiceTestDetails17.Location = new System.Drawing.Point(3, 295);
            this.ucCcidInvoiceTestDetails17.Name = "ucCcidInvoiceTestDetails17";
            this.ucCcidInvoiceTestDetails17.Size = new System.Drawing.Size(970, 154);
            this.ucCcidInvoiceTestDetails17.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Location = new System.Drawing.Point(190, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UcCcidInvoiceTestResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UcCcidInvoiceTestResults";
            this.Size = new System.Drawing.Size(976, 461);
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private Telerik.WinControls.UI.RadButton radBtnCopy;
        private System.Windows.Forms.ListView lvResult;
        private UcCcidInvoiceTestDetails17 ucCcidInvoiceTestDetails17;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
