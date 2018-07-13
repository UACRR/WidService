namespace IpsViewComponentLibrary
{
    partial class RegisterView
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.registerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtCreateDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtNumber = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton6 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton5 = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.ctrlRegisterItemList = new IpsViewComponentLibrary.RegisterItemListControl();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 1);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Номер";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(160, 1);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(23, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "від";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(337, 2);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(42, 19);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Статус";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.registerBindingSource, "RgStatus", true));
            this.ddlStatus.Location = new System.Drawing.Point(385, 2);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.ReadOnly = true;
            this.ddlStatus.Size = new System.Drawing.Size(158, 21);
            this.ddlStatus.TabIndex = 3;
            this.ddlStatus.ThemeName = "Office2013Light";
            // 
            // registerBindingSource
            // 
            this.registerBindingSource.DataSource = typeof(ipsFormsDesign.Model.Register);
            // 
            // dtCreateDate
            // 
            this.dtCreateDate.Culture = new System.Globalization.CultureInfo("uk-UA");
            this.dtCreateDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.registerBindingSource, "CreateDate", true));
            this.dtCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreateDate.Location = new System.Drawing.Point(189, 2);
            this.dtCreateDate.Name = "dtCreateDate";
            this.dtCreateDate.ReadOnly = true;
            this.dtCreateDate.Size = new System.Drawing.Size(103, 21);
            this.dtCreateDate.TabIndex = 4;
            this.dtCreateDate.TabStop = false;
            this.dtCreateDate.Text = "13.07.2018";
            this.dtCreateDate.ThemeName = "Office2013Light";
            this.dtCreateDate.Value = new System.DateTime(2018, 7, 13, 11, 0, 20, 75);
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registerBindingSource, "RegId", true));
            this.txtNumber.Location = new System.Drawing.Point(54, 2);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(100, 21);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.ThemeName = "Office2013Light";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(3, 394);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 24);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(680, 394);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 24);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox1.Controls.Add(this.radButton2);
            this.radGroupBox1.Controls.Add(this.radButton1);
            this.radGroupBox1.HeaderText = "Cтатус";
            this.radGroupBox1.Location = new System.Drawing.Point(5, 328);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(237, 57);
            this.radGroupBox1.TabIndex = 18;
            this.radGroupBox1.Text = "Cтатус";
            this.radGroupBox1.ThemeName = "Office2013Light";
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(121, 21);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 1;
            this.radButton2.Text = "Скасувати";
            this.radButton2.ThemeName = "Office2013Light";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(5, 21);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Погодити";
            this.radButton1.ThemeName = "Office2013Light";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox2.Controls.Add(this.radButton6);
            this.radGroupBox2.Controls.Add(this.radButton3);
            this.radGroupBox2.Controls.Add(this.radButton5);
            this.radGroupBox2.Controls.Add(this.radButton4);
            this.radGroupBox2.HeaderText = "Пошук";
            this.radGroupBox2.Location = new System.Drawing.Point(273, 328);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(579, 57);
            this.radGroupBox2.TabIndex = 19;
            this.radGroupBox2.Text = "Пошук";
            this.radGroupBox2.ThemeName = "Office2013Light";
            // 
            // radButton6
            // 
            this.radButton6.Location = new System.Drawing.Point(441, 21);
            this.radButton6.Name = "radButton6";
            this.radButton6.Size = new System.Drawing.Size(131, 24);
            this.radButton6.TabIndex = 3;
            this.radButton6.Text = "Шукати вибрані";
            this.radButton6.ThemeName = "Office2013Light";
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(167, 21);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(131, 24);
            this.radButton3.TabIndex = 1;
            this.radButton3.Text = "Шукати всі";
            this.radButton3.ThemeName = "Office2013Light";
            // 
            // radButton5
            // 
            this.radButton5.Location = new System.Drawing.Point(304, 21);
            this.radButton5.Name = "radButton5";
            this.radButton5.Size = new System.Drawing.Size(131, 24);
            this.radButton5.TabIndex = 2;
            this.radButton5.Text = "Шукати не знайдені";
            this.radButton5.ThemeName = "Office2013Light";
            // 
            // radButton4
            // 
            this.radButton4.Location = new System.Drawing.Point(5, 21);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(156, 24);
            this.radButton4.TabIndex = 0;
            this.radButton4.Text = "Прив\'язати автоматично";
            this.radButton4.ThemeName = "Office2013Light";
            // 
            // ctrlRegisterItemList
            // 
            this.ctrlRegisterItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegisterItemList.Location = new System.Drawing.Point(0, 41);
            this.ctrlRegisterItemList.Name = "ctrlRegisterItemList";
            this.ctrlRegisterItemList.SelectedRegisterItem = null;
            this.ctrlRegisterItemList.Size = new System.Drawing.Size(859, 281);
            this.ctrlRegisterItemList.TabIndex = 6;
            // 
            // RegisterView
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(857, 420);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ctrlRegisterItemList);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.dtCreateDate);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "RegisterView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Відомість";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList ddlStatus;
        private Telerik.WinControls.UI.RadDateTimePicker dtCreateDate;
        private Telerik.WinControls.UI.RadTextBox txtNumber;
        private System.Windows.Forms.BindingSource registerBindingSource;
        private RegisterItemListControl ctrlRegisterItemList;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton radButton6;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton5;
        private Telerik.WinControls.UI.RadButton radButton4;
    }
}
