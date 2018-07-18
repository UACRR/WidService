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
            this.gboxStatus = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSetCanceledStatus = new Telerik.WinControls.UI.RadButton();
            this.btnSetStatus = new Telerik.WinControls.UI.RadButton();
            this.gboxSearch = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSearchSelected = new Telerik.WinControls.UI.RadButton();
            this.btnSearchAll = new Telerik.WinControls.UI.RadButton();
            this.btnSearchNotLinked = new Telerik.WinControls.UI.RadButton();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
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
            ((System.ComponentModel.ISupportInitialize)(this.gboxStatus)).BeginInit();
            this.gboxStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetCanceledStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gboxSearch)).BeginInit();
            this.gboxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchNotLinked)).BeginInit();
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
            this.btnCancel.Location = new System.Drawing.Point(3, 538);
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
            this.btnSave.Location = new System.Drawing.Point(1115, 538);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 24);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Зберегти";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gboxStatus
            // 
            this.gboxStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gboxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxStatus.Controls.Add(this.btnSetCanceledStatus);
            this.gboxStatus.Controls.Add(this.btnSetStatus);
            this.gboxStatus.HeaderText = "Cтатус";
            this.gboxStatus.Location = new System.Drawing.Point(5, 472);
            this.gboxStatus.Name = "gboxStatus";
            this.gboxStatus.Size = new System.Drawing.Size(237, 57);
            this.gboxStatus.TabIndex = 18;
            this.gboxStatus.Text = "Cтатус";
            this.gboxStatus.ThemeName = "Office2013Light";
            // 
            // btnSetCanceledStatus
            // 
            this.btnSetCanceledStatus.Location = new System.Drawing.Point(121, 21);
            this.btnSetCanceledStatus.Name = "btnSetCanceledStatus";
            this.btnSetCanceledStatus.Size = new System.Drawing.Size(110, 24);
            this.btnSetCanceledStatus.TabIndex = 1;
            this.btnSetCanceledStatus.Text = "Скасувати";
            this.btnSetCanceledStatus.ThemeName = "Office2013Light";
            this.btnSetCanceledStatus.Click += new System.EventHandler(this.btnSetCanceledStatus_Click);
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Location = new System.Drawing.Point(5, 21);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(110, 24);
            this.btnSetStatus.TabIndex = 0;
            this.btnSetStatus.Text = "Погодити";
            this.btnSetStatus.ThemeName = "Office2013Light";
            this.btnSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // gboxSearch
            // 
            this.gboxSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gboxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxSearch.Controls.Add(this.btnSearchSelected);
            this.gboxSearch.Controls.Add(this.btnSearchAll);
            this.gboxSearch.Controls.Add(this.btnSearchNotLinked);
            this.gboxSearch.Controls.Add(this.radButton4);
            this.gboxSearch.HeaderText = "Пошук";
            this.gboxSearch.Location = new System.Drawing.Point(273, 472);
            this.gboxSearch.Name = "gboxSearch";
            this.gboxSearch.Size = new System.Drawing.Size(579, 57);
            this.gboxSearch.TabIndex = 19;
            this.gboxSearch.Text = "Пошук";
            this.gboxSearch.ThemeName = "Office2013Light";
            // 
            // btnSearchSelected
            // 
            this.btnSearchSelected.Location = new System.Drawing.Point(441, 21);
            this.btnSearchSelected.Name = "btnSearchSelected";
            this.btnSearchSelected.Size = new System.Drawing.Size(131, 24);
            this.btnSearchSelected.TabIndex = 3;
            this.btnSearchSelected.Text = "Шукати вибрані";
            this.btnSearchSelected.ThemeName = "Office2013Light";
            this.btnSearchSelected.Click += new System.EventHandler(this.btnSearchSelected_Click);
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(167, 21);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(131, 24);
            this.btnSearchAll.TabIndex = 1;
            this.btnSearchAll.Text = "Шукати всі";
            this.btnSearchAll.ThemeName = "Office2013Light";
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // btnSearchNotLinked
            // 
            this.btnSearchNotLinked.Location = new System.Drawing.Point(304, 21);
            this.btnSearchNotLinked.Name = "btnSearchNotLinked";
            this.btnSearchNotLinked.Size = new System.Drawing.Size(131, 24);
            this.btnSearchNotLinked.TabIndex = 2;
            this.btnSearchNotLinked.Text = "Шукати не знайдені";
            this.btnSearchNotLinked.ThemeName = "Office2013Light";
            this.btnSearchNotLinked.Click += new System.EventHandler(this.btnSearchNotLinked_Click);
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
            this.ctrlRegisterItemList.AllowFindCommand = true;
            this.ctrlRegisterItemList.AllowLinkCommand = true;
            this.ctrlRegisterItemList.AllowShowObjectCommand = true;
            this.ctrlRegisterItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegisterItemList.DataSource = typeof(ipsFormsDesign.Model.RegisterItem);
            this.ctrlRegisterItemList.Location = new System.Drawing.Point(0, 41);
            this.ctrlRegisterItemList.MultiSelect = true;
            this.ctrlRegisterItemList.Name = "ctrlRegisterItemList";
            this.ctrlRegisterItemList.SelectedRegisterItem = null;
            this.ctrlRegisterItemList.Size = new System.Drawing.Size(1294, 425);
            this.ctrlRegisterItemList.TabIndex = 6;
            this.ctrlRegisterItemList.FindCommandExecuted += new System.EventHandler<ipsFormsDesign.Dictionary.RegisterItemViewModel>(this.ctrlRegisterItemList_FindCommandExecuted);
            // 
            // RegisterView
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1292, 564);
            this.Controls.Add(this.gboxSearch);
            this.Controls.Add(this.gboxStatus);
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
            ((System.ComponentModel.ISupportInitialize)(this.gboxStatus)).EndInit();
            this.gboxStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSetCanceledStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gboxSearch)).EndInit();
            this.gboxSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchNotLinked)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnSetStatus;
        private Telerik.WinControls.UI.RadGroupBox gboxStatus;
        private Telerik.WinControls.UI.RadButton btnSetCanceledStatus;
        private Telerik.WinControls.UI.RadGroupBox gboxSearch;
        private Telerik.WinControls.UI.RadButton btnSearchSelected;
        private Telerik.WinControls.UI.RadButton btnSearchAll;
        private Telerik.WinControls.UI.RadButton btnSearchNotLinked;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
