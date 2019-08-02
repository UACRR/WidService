namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    partial class CreatePeriod
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ddlPeriod = new Telerik.WinControls.UI.RadDropDownList();
            this.btnCreate = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.dtStartDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // radLabel4
            // 
            this.radLabel4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "LicDate", true));
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel4.Location = new System.Drawing.Point(130, 67);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(2, 2);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.TextWrap = false;
            // 
            // ddlPeriod
            // 
            this.ddlPeriod.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ddlPeriod.Location = new System.Drawing.Point(138, 54);
            this.ddlPeriod.Name = "ddlPeriod";
            this.ddlPeriod.Size = new System.Drawing.Size(232, 25);
            this.ddlPeriod.TabIndex = 1;
            this.ddlPeriod.ThemeName = "Office2013Light";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 106);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(111, 24);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Створити";
            this.btnCreate.ThemeName = "Office2013Light";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(256, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtStartDate.Location = new System.Drawing.Point(138, 18);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(155, 25);
            this.dtStartDate.TabIndex = 0;
            this.dtStartDate.TabStop = false;
            this.dtStartDate.Text = "21 липня 2018 р.";
            this.dtStartDate.ThemeName = "Office2013Light";
            this.dtStartDate.Value = new System.DateTime(2018, 7, 21, 7, 51, 24, 863);
            this.dtStartDate.ValueChanged += new System.EventHandler(this.radDateTimePicker1_ValueChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(69, 54);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 24);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "Період";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel2.Location = new System.Drawing.Point(11, 16);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(115, 23);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Початкова дата";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // CreatePeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(380, 142);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.ddlPeriod);
            this.Controls.Add(this.radLabel4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новий період";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList ddlPeriod;
        private Telerik.WinControls.UI.RadButton btnCreate;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadDateTimePicker dtStartDate;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}