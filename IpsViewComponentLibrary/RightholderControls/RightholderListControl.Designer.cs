namespace IpsViewComponentLibrary.RightholderControls
{
    partial class RightholderListControl
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn7 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn8 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn9 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rightholderMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearchRightholder = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.gvRightholdersList = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRightholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // rightholderMainViewBindingSource
            // 
            this.rightholderMainViewBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.RightholderMainView);
            // 
            // txtSearchRightholder
            // 
            this.txtSearchRightholder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchRightholder.Location = new System.Drawing.Point(189, 3);
            this.txtSearchRightholder.Name = "txtSearchRightholder";
            this.txtSearchRightholder.Size = new System.Drawing.Size(558, 21);
            this.txtSearchRightholder.TabIndex = 26;
            this.txtSearchRightholder.ThemeName = "Office2013Light";
            this.txtSearchRightholder.TextChanged += new System.EventHandler(this.txtSearchRightholder_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(137, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 19);
            this.radLabel1.TabIndex = 25;
            this.radLabel1.Text = "Пошук";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // gvRightholdersList
            // 
            this.gvRightholdersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightholdersList.EnableCustomFiltering = true;
            this.gvRightholdersList.Location = new System.Drawing.Point(3, 55);
            // 
            // 
            // 
            this.gvRightholdersList.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersList.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn11.DataType = typeof(int);
            gridViewTextBoxColumn11.FieldName = "CustId";
            gridViewTextBoxColumn11.HeaderText = "CustId";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "CustId";
            gridViewTextBoxColumn12.FieldName = "InnerCode";
            gridViewTextBoxColumn12.HeaderText = "Шифр автора / правовласника";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "InnerCode";
            gridViewTextBoxColumn12.Width = 46;
            gridViewTextBoxColumn13.FieldName = "InterCode";
            gridViewTextBoxColumn13.HeaderText = "IPI";
            gridViewTextBoxColumn13.IsAutoGenerated = true;
            gridViewTextBoxColumn13.Name = "InterCode";
            gridViewTextBoxColumn13.Width = 46;
            gridViewTextBoxColumn14.FieldName = "Name";
            gridViewTextBoxColumn14.HeaderText = "Правовласник";
            gridViewTextBoxColumn14.IsAutoGenerated = true;
            gridViewTextBoxColumn14.Name = "Name";
            gridViewTextBoxColumn14.Width = 113;
            gridViewDateTimeColumn3.AllowResize = false;
            gridViewDateTimeColumn3.FieldName = "RegistrDate";
            gridViewDateTimeColumn3.FormatString = "{0:dd/MM/yyyy}";
            gridViewDateTimeColumn3.HeaderText = "Дата народження / реєстрації";
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.Name = "RegistrDate";
            gridViewDateTimeColumn3.Width = 92;
            gridViewDecimalColumn5.AllowResize = false;
            gridViewDecimalColumn5.DataType = typeof(int);
            gridViewDecimalColumn5.FieldName = "CntObj";
            gridViewDecimalColumn5.HeaderText = "К-ть об\'єктів";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "CntObj";
            gridViewDecimalColumn6.AllowResize = false;
            gridViewDecimalColumn6.FieldName = "YearProfit";
            gridViewDecimalColumn6.FormatString = "{0:N2}";
            gridViewDecimalColumn6.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.Name = "YearProfit";
            gridViewDecimalColumn6.Width = 94;
            gridViewTextBoxColumn15.FieldName = "Community_Name";
            gridViewTextBoxColumn15.HeaderText = "Cпільнота";
            gridViewTextBoxColumn15.Name = "Community_Name";
            gridViewTextBoxColumn15.Width = 70;
            gridViewCommandColumn7.AllowResize = false;
            gridViewCommandColumn7.DefaultText = "Зм. статус";
            gridViewCommandColumn7.HeaderText = "";
            gridViewCommandColumn7.Name = "SetStatusColumn";
            gridViewCommandColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn7.UseDefaultText = true;
            gridViewCommandColumn7.Width = 80;
            gridViewCommandColumn8.AllowResize = false;
            gridViewCommandColumn8.DefaultText = "Об\'єкти";
            gridViewCommandColumn8.HeaderText = "";
            gridViewCommandColumn8.Name = "ObjectListColumn";
            gridViewCommandColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn8.UseDefaultText = true;
            gridViewCommandColumn8.Width = 80;
            gridViewCommandColumn9.AllowResize = false;
            gridViewCommandColumn9.DefaultText = "Редагувати";
            gridViewCommandColumn9.HeaderText = "";
            gridViewCommandColumn9.Name = "EditColumn";
            gridViewCommandColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn9.UseDefaultText = true;
            gridViewCommandColumn9.Width = 80;
            this.gvRightholdersList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewDateTimeColumn3,
            gridViewDecimalColumn5,
            gridViewDecimalColumn6,
            gridViewTextBoxColumn15,
            gridViewCommandColumn7,
            gridViewCommandColumn8,
            gridViewCommandColumn9});
            this.gvRightholdersList.MasterTemplate.DataSource = this.rightholderMainViewBindingSource;
            this.gvRightholdersList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRightholdersList.MasterTemplate.EnableFiltering = true;
            this.gvRightholdersList.MasterTemplate.ShowFilteringRow = false;
            this.gvRightholdersList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersList.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.gvRightholdersList.Name = "gvRightholdersList";
            this.gvRightholdersList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvRightholdersList.ReadOnly = true;
            this.gvRightholdersList.ShowGroupPanel = false;
            this.gvRightholdersList.Size = new System.Drawing.Size(744, 342);
            this.gvRightholdersList.TabIndex = 27;
            this.gvRightholdersList.ThemeName = "Office2013Light";
            this.gvRightholdersList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersList_CellDoubleClick);
            this.gvRightholdersList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRightholdersList_CommandCellClick);
            this.gvRightholdersList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvRightholdersList_CustomFiltering);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 21);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.ThemeName = "Office2013Light";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlStatus.Location = new System.Drawing.Point(189, 28);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(203, 21);
            this.ddlStatus.TabIndex = 35;
            this.ddlStatus.ThemeName = "Office2013Light";
            this.ddlStatus.SelectedValueChanged += new System.EventHandler(this.ddlStatus_SelectedValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(142, 28);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(42, 19);
            this.radLabel3.TabIndex = 34;
            this.radLabel3.Text = "Статус";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // RightholderListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gvRightholdersList);
            this.Controls.Add(this.txtSearchRightholder);
            this.Controls.Add(this.radLabel1);
            this.Name = "RightholderListControl";
            this.Size = new System.Drawing.Size(750, 400);
            this.Load += new System.EventHandler(this.RightholderListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRightholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource rightholderMainViewBindingSource;
        private Telerik.WinControls.UI.RadTextBox txtSearchRightholder;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView gvRightholdersList;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadDropDownList ddlStatus;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
