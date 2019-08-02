namespace IpsViewComponentLibrary.ConsumerControls.Reports.Forms
{
    partial class CreateRatedList
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
            this.components = new System.ComponentModel.Container();
            this.radTextPeriod = new Telerik.WinControls.UI.RadTextBox();
            this.bindingPeriod = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radTextAmount = new Telerik.WinControls.UI.RadTextBox();
            this.bindingSourceRatedList = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radTextRoyalty = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radTextCntReport = new Telerik.WinControls.UI.RadTextBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radTextPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRatedList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextRoyalty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextCntReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextPeriod
            // 
            this.radTextPeriod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingPeriod, "PeriodName", true));
            this.radTextPeriod.Enabled = false;
            this.radTextPeriod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radTextPeriod.Location = new System.Drawing.Point(186, 9);
            this.radTextPeriod.Name = "radTextPeriod";
            this.radTextPeriod.Size = new System.Drawing.Size(183, 23);
            this.radTextPeriod.TabIndex = 0;
            this.radTextPeriod.ThemeName = "Office2013Light";
            // 
            // bindingPeriod
            // 
            this.bindingPeriod.DataSource = typeof(ipsFormsDesign.Model.PaidPeriod);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(13, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(50, 21);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Період";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(13, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(132, 42);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Загальна сума збору по р/л";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radTextAmount
            // 
            this.radTextAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRatedList, "Amount", true));
            this.radTextAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radTextAmount.Location = new System.Drawing.Point(186, 49);
            this.radTextAmount.Name = "radTextAmount";
            this.radTextAmount.Size = new System.Drawing.Size(183, 23);
            this.radTextAmount.TabIndex = 1;
            this.radTextAmount.ThemeName = "Office2013Light";
            // 
            // bindingSourceRatedList
            // 
            this.bindingSourceRatedList.DataSource = typeof(ipsFormsDesign.Model.RegisterRatedList);
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel3.Location = new System.Drawing.Point(13, 89);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(171, 42);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Загальна сума авторської винаговроди по р/л";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radTextRoyalty
            // 
            this.radTextRoyalty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRatedList, "Royalty", true));
            this.radTextRoyalty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radTextRoyalty.Location = new System.Drawing.Point(186, 99);
            this.radTextRoyalty.Name = "radTextRoyalty";
            this.radTextRoyalty.Size = new System.Drawing.Size(183, 23);
            this.radTextRoyalty.TabIndex = 2;
            this.radTextRoyalty.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel4.Location = new System.Drawing.Point(13, 139);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(99, 21);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Кількість звітів ";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // radTextCntReport
            // 
            this.radTextCntReport.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRatedList, "CntReport", true));
            this.radTextCntReport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radTextCntReport.Location = new System.Drawing.Point(186, 138);
            this.radTextCntReport.Name = "radTextCntReport";
            this.radTextCntReport.Size = new System.Drawing.Size(183, 23);
            this.radTextCntReport.TabIndex = 3;
            this.radTextCntReport.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(13, 188);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // CreateRatedList
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(387, 219);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radTextCntReport);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radTextRoyalty);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radTextAmount);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radTextPeriod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateRatedList";
            this.Text = "Новий розрахунковий лист";
            ((System.ComponentModel.ISupportInitialize)(this.radTextPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRatedList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextRoyalty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextCntReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceRatedList;
        private Telerik.WinControls.UI.RadTextBox radTextPeriod;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox radTextAmount;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox radTextRoyalty;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox radTextCntReport;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.BindingSource bindingPeriod;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}