namespace IpsViewComponentLibrary
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rightholderMainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearchRightholder = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.gvRightholdersList = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRightholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).BeginInit();
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
            this.txtSearchRightholder.Location = new System.Drawing.Point(56, 3);
            this.txtSearchRightholder.Name = "txtSearchRightholder";
            this.txtSearchRightholder.Size = new System.Drawing.Size(691, 21);
            this.txtSearchRightholder.TabIndex = 26;
            this.txtSearchRightholder.ThemeName = "Office2013Light";
            this.txtSearchRightholder.TextChanged += new System.EventHandler(this.txtSearchRightholder_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(47, 19);
            this.radLabel1.TabIndex = 25;
            this.radLabel1.Text = "Пошук:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // gvRightholdersList
            // 
            this.gvRightholdersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightholdersList.EnableCustomFiltering = true;
            this.gvRightholdersList.Location = new System.Drawing.Point(3, 30);
            // 
            // 
            // 
            this.gvRightholdersList.MasterTemplate.AllowAddNewRow = false;
            this.gvRightholdersList.MasterTemplate.AutoGenerateColumns = false;
            this.gvRightholdersList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "CustId";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.FieldName = "InnerCode";
            gridViewTextBoxColumn2.HeaderText = "Шифр автора / правовласника";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "InnerCode";
            gridViewTextBoxColumn2.Width = 46;
            gridViewTextBoxColumn3.FieldName = "InterCode";
            gridViewTextBoxColumn3.HeaderText = "IPI";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "InterCode";
            gridViewTextBoxColumn3.Width = 46;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.HeaderText = "Правовласник";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Name";
            gridViewTextBoxColumn4.Width = 113;
            gridViewDateTimeColumn1.AllowResize = false;
            gridViewDateTimeColumn1.FieldName = "RegistrDate";
            gridViewDateTimeColumn1.FormatString = "{0:dd/MM/yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Дата народження / реєстрації";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.Name = "RegistrDate";
            gridViewDateTimeColumn1.Width = 92;
            gridViewDecimalColumn1.AllowResize = false;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "CntObj";
            gridViewDecimalColumn1.HeaderText = "К-ть об\'єктів";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "CntObj";
            gridViewDecimalColumn2.AllowResize = false;
            gridViewDecimalColumn2.FieldName = "YearProfit";
            gridViewDecimalColumn2.FormatString = "{0:N2}";
            gridViewDecimalColumn2.HeaderText = "Дохід з початку року";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.Name = "YearProfit";
            gridViewDecimalColumn2.Width = 94;
            gridViewTextBoxColumn5.FieldName = "Community_Name";
            gridViewTextBoxColumn5.HeaderText = "Cпільнота";
            gridViewTextBoxColumn5.Name = "Community_Name";
            gridViewTextBoxColumn5.Width = 70;
            gridViewCommandColumn1.AllowResize = false;
            gridViewCommandColumn1.DefaultText = "Зм. статус";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Name = "SetStatusColumn";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 80;
            gridViewCommandColumn2.AllowResize = false;
            gridViewCommandColumn2.DefaultText = "Об\'єкти";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Name = "ObjectListColumn";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 80;
            gridViewCommandColumn3.AllowResize = false;
            gridViewCommandColumn3.DefaultText = "Редагувати";
            gridViewCommandColumn3.HeaderText = "";
            gridViewCommandColumn3.Name = "EditColumn";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 80;
            this.gvRightholdersList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewCommandColumn3});
            this.gvRightholdersList.MasterTemplate.DataSource = this.rightholderMainViewBindingSource;
            this.gvRightholdersList.MasterTemplate.EnableCustomFiltering = true;
            this.gvRightholdersList.MasterTemplate.EnableFiltering = true;
            this.gvRightholdersList.MasterTemplate.ShowFilteringRow = false;
            this.gvRightholdersList.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvRightholdersList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvRightholdersList.Name = "gvRightholdersList";
            this.gvRightholdersList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvRightholdersList.ReadOnly = true;
            this.gvRightholdersList.ShowGroupPanel = false;
            this.gvRightholdersList.Size = new System.Drawing.Size(744, 367);
            this.gvRightholdersList.TabIndex = 27;
            this.gvRightholdersList.ThemeName = "Office2013Light";
            this.gvRightholdersList.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvRightholdersList_CellDoubleClick);
            this.gvRightholdersList.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvRightholdersList_CommandCellClick);
            this.gvRightholdersList.CustomFiltering += new Telerik.WinControls.UI.GridViewCustomFilteringEventHandler(this.gvRightholdersList_CustomFiltering);
            // 
            // RightholderListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvRightholdersList);
            this.Controls.Add(this.txtSearchRightholder);
            this.Controls.Add(this.radLabel1);
            this.Name = "RightholderListControl";
            this.Size = new System.Drawing.Size(750, 400);
            ((System.ComponentModel.ISupportInitialize)(this.rightholderMainViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRightholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource rightholderMainViewBindingSource;
        private Telerik.WinControls.UI.RadTextBox txtSearchRightholder;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView gvRightholdersList;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
    }
}
