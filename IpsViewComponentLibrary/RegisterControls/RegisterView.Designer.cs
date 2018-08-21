namespace IpsViewComponentLibrary.RegisterControls
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
            this.btnCreateSelected = new Telerik.WinControls.UI.RadButton();
            this.btnSearchSelected = new Telerik.WinControls.UI.RadButton();
            this.btnSearchAll = new Telerik.WinControls.UI.RadButton();
            this.btnSearchNotLinked = new Telerik.WinControls.UI.RadButton();
            this.btnSearchAuto = new Telerik.WinControls.UI.RadButton();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.splitContainer = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanelStage = new Telerik.WinControls.UI.SplitPanel();
            this.ctrlRegisterItemListStage = new IpsViewComponentLibrary.RegisterControls.RegisterItemListControl();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlRegisterItemList = new IpsViewComponentLibrary.RegisterControls.RegisterItemListControl();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchNotLinked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelStage)).BeginInit();
            this.splitPanelStage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
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
            ((Telerik.WinControls.UI.RadDropDownListArrowButtonElement)(this.ddlStatus.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
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
            ((Telerik.WinControls.UI.RadDateTimePickerArrowButtonElement)(this.dtCreateDate.GetChildAt(0).GetChildAt(2).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
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
            this.btnCancel.Location = new System.Drawing.Point(3, 4);
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
            this.btnSave.Location = new System.Drawing.Point(1114, 4);
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
            this.gboxSearch.Controls.Add(this.btnCreateSelected);
            this.gboxSearch.Controls.Add(this.btnSearchSelected);
            this.gboxSearch.Controls.Add(this.btnSearchAll);
            this.gboxSearch.Controls.Add(this.btnSearchNotLinked);
            this.gboxSearch.Controls.Add(this.btnSearchAuto);
            this.gboxSearch.HeaderText = "Дії з об\'єктами звіту";
            this.gboxSearch.Location = new System.Drawing.Point(273, 472);
            this.gboxSearch.Name = "gboxSearch";
            this.gboxSearch.Size = new System.Drawing.Size(811, 57);
            this.gboxSearch.TabIndex = 19;
            this.gboxSearch.Text = "Дії з об\'єктами звіту";
            this.gboxSearch.ThemeName = "Office2013Light";
            // 
            // btnCreateSelected
            // 
            this.btnCreateSelected.Location = new System.Drawing.Point(650, 21);
            this.btnCreateSelected.Name = "btnCreateSelected";
            this.btnCreateSelected.Size = new System.Drawing.Size(155, 24);
            this.btnCreateSelected.TabIndex = 4;
            this.btnCreateSelected.Text = "Створити для обраних";
            this.btnCreateSelected.ThemeName = "Office2013Light";
            this.btnCreateSelected.Click += new System.EventHandler(this.btnCreateSelected_Click);
            // 
            // btnSearchSelected
            // 
            this.btnSearchSelected.Location = new System.Drawing.Point(489, 21);
            this.btnSearchSelected.Name = "btnSearchSelected";
            this.btnSearchSelected.Size = new System.Drawing.Size(155, 24);
            this.btnSearchSelected.TabIndex = 3;
            this.btnSearchSelected.Text = "Шукати для обраних";
            this.btnSearchSelected.ThemeName = "Office2013Light";
            this.btnSearchSelected.Click += new System.EventHandler(this.btnSearchSelected_Click);
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(167, 21);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(155, 24);
            this.btnSearchAll.TabIndex = 1;
            this.btnSearchAll.Text = "Шукати для всіх";
            this.btnSearchAll.ThemeName = "Office2013Light";
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // btnSearchNotLinked
            // 
            this.btnSearchNotLinked.Location = new System.Drawing.Point(328, 21);
            this.btnSearchNotLinked.Name = "btnSearchNotLinked";
            this.btnSearchNotLinked.Size = new System.Drawing.Size(155, 24);
            this.btnSearchNotLinked.TabIndex = 2;
            this.btnSearchNotLinked.Text = "Шукати для не знайдених";
            this.btnSearchNotLinked.ThemeName = "Office2013Light";
            this.btnSearchNotLinked.Click += new System.EventHandler(this.btnSearchNotLinked_Click);
            // 
            // btnSearchAuto
            // 
            this.btnSearchAuto.Location = new System.Drawing.Point(5, 21);
            this.btnSearchAuto.Name = "btnSearchAuto";
            this.btnSearchAuto.Size = new System.Drawing.Size(156, 24);
            this.btnSearchAuto.TabIndex = 0;
            this.btnSearchAuto.Text = "Прив\'язати автоматично";
            this.btnSearchAuto.ThemeName = "Office2013Light";
            this.btnSearchAuto.Click += new System.EventHandler(this.btnSearchAuto_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Silver;
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Controls.Add(this.btnSave);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radPanel1.Location = new System.Drawing.Point(0, 537);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1292, 31);
            this.radPanel1.TabIndex = 91;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Controls.Add(this.splitPanelStage);
            this.splitContainer.Controls.Add(this.splitPanel2);
            this.splitContainer.Location = new System.Drawing.Point(0, 26);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.splitContainer.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitContainer.Size = new System.Drawing.Size(1292, 443);
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 92;
            this.splitContainer.TabStop = false;
            this.splitContainer.ThemeName = "Office2013Light";
            // 
            // splitPanelStage
            // 
            this.splitPanelStage.Controls.Add(this.radLabel5);
            this.splitPanelStage.Controls.Add(this.ctrlRegisterItemListStage);
            this.splitPanelStage.Location = new System.Drawing.Point(0, 0);
            this.splitPanelStage.Name = "splitPanelStage";
            // 
            // 
            // 
            this.splitPanelStage.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanelStage.Size = new System.Drawing.Size(1292, 155);
            this.splitPanelStage.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.1461187F);
            this.splitPanelStage.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -64);
            this.splitPanelStage.TabIndex = 0;
            this.splitPanelStage.TabStop = false;
            this.splitPanelStage.Text = "splitPanel1";
            this.splitPanelStage.ThemeName = "Office2013Light";
            // 
            // ctrlRegisterItemListStage
            // 
            this.ctrlRegisterItemListStage.AllowCreateObjectCommand = true;
            this.ctrlRegisterItemListStage.AllowEditList = false;
            this.ctrlRegisterItemListStage.AllowFindCommand = true;
            this.ctrlRegisterItemListStage.AllowLinkCommand = true;
            this.ctrlRegisterItemListStage.AllowShowObjectCommand = true;
            this.ctrlRegisterItemListStage.AllowUnlinkCommand = true;
            this.ctrlRegisterItemListStage.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterItemViewModel);
            this.ctrlRegisterItemListStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRegisterItemListStage.Location = new System.Drawing.Point(0, 0);
            this.ctrlRegisterItemListStage.MultiSelect = false;
            this.ctrlRegisterItemListStage.Name = "ctrlRegisterItemListStage";
            this.ctrlRegisterItemListStage.SelectedRegisterItem = null;
            this.ctrlRegisterItemListStage.ShowAuthors = true;
            this.ctrlRegisterItemListStage.ShowObjectInfo = true;
            this.ctrlRegisterItemListStage.Size = new System.Drawing.Size(1292, 155);
            this.ctrlRegisterItemListStage.TabIndex = 0;
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.radLabel4);
            this.splitPanel2.Controls.Add(this.ctrlRegisterItemList);
            this.splitPanel2.Location = new System.Drawing.Point(0, 160);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(1292, 283);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.1461187F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 64);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel4.Location = new System.Drawing.Point(297, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(96, 19);
            this.radLabel4.TabIndex = 2;
            this.radLabel4.Text = "Музичні твори";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // ctrlRegisterItemList
            // 
            this.ctrlRegisterItemList.AllowCreateObjectCommand = true;
            this.ctrlRegisterItemList.AllowEditList = false;
            this.ctrlRegisterItemList.AllowFindCommand = true;
            this.ctrlRegisterItemList.AllowLinkCommand = true;
            this.ctrlRegisterItemList.AllowShowObjectCommand = true;
            this.ctrlRegisterItemList.AllowUnlinkCommand = true;
            this.ctrlRegisterItemList.DataSource = typeof(ipsFormsDesign.Dictionary.RegisterItemViewModel);
            this.ctrlRegisterItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRegisterItemList.Location = new System.Drawing.Point(0, 0);
            this.ctrlRegisterItemList.MultiSelect = false;
            this.ctrlRegisterItemList.Name = "ctrlRegisterItemList";
            this.ctrlRegisterItemList.SelectedRegisterItem = null;
            this.ctrlRegisterItemList.ShowAuthors = true;
            this.ctrlRegisterItemList.ShowObjectInfo = true;
            this.ctrlRegisterItemList.Size = new System.Drawing.Size(1292, 283);
            this.ctrlRegisterItemList.TabIndex = 1;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel5.Location = new System.Drawing.Point(297, 3);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(78, 19);
            this.radLabel5.TabIndex = 3;
            this.radLabel5.Text = "Постановка";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // RegisterView
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1292, 568);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.gboxSearch);
            this.Controls.Add(this.gboxStatus);
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
            this.Text = "Звіт (малі права)";
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
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchNotLinked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanelStage)).EndInit();
            this.splitPanelStage.ResumeLayout(false);
            this.splitPanelStage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            this.splitPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
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
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnSetStatus;
        private Telerik.WinControls.UI.RadGroupBox gboxStatus;
        private Telerik.WinControls.UI.RadButton btnSetCanceledStatus;
        private Telerik.WinControls.UI.RadGroupBox gboxSearch;
        private Telerik.WinControls.UI.RadButton btnSearchSelected;
        private Telerik.WinControls.UI.RadButton btnSearchAll;
        private Telerik.WinControls.UI.RadButton btnSearchNotLinked;
        private Telerik.WinControls.UI.RadButton btnSearchAuto;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnCreateSelected;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadSplitContainer splitContainer;
        private Telerik.WinControls.UI.SplitPanel splitPanelStage;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private RegisterItemListControl ctrlRegisterItemList;
        private RegisterItemListControl ctrlRegisterItemListStage;
        private Telerik.WinControls.UI.RadLabel radLabel5;
    }
}
