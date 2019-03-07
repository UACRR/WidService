using System.Drawing;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.ConsumerControls
{
    partial class ManagersControl
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ctrlBookkeeper = new IpsBossNameContactsControl();
            this.txtOnBasicsIfHeadBoss = new Telerik.WinControls.UI.RadTextBox();
            this.ctrlHeadBoss = new IpsBossNameContactsControl();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator5 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator4 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gvContactPersons = new Telerik.WinControls.UI.RadGridView();
            this.bsEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddContact = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtSurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContactPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContactPersons.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddContact)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlBookkeeper
            // 
            this.ctrlBookkeeper.DataSource = typeof(ipsFormsDesign.Interfaces.IEmployee);
            this.ctrlBookkeeper.Location = new System.Drawing.Point(54, 145);
            this.ctrlBookkeeper.Name = "ctrlBookkeeper";
            this.ctrlBookkeeper.OutsidePhone = false;
            this.ctrlBookkeeper.Size = new System.Drawing.Size(682, 56);
            this.ctrlBookkeeper.TabIndex = 32;
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBookkeeper.TxtEmail.Location = new System.Drawing.Point(481, 35);
            this.ctrlBookkeeper.TxtEmail.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlBookkeeper.TxtEmail.Name = "txtEmail";
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtEmail.RootElement.ControlBounds = new System.Drawing.Rectangle(481, 36, 201, 20);
            this.ctrlBookkeeper.TxtEmail.RootElement.StretchVertically = true;
            this.ctrlBookkeeper.TxtEmail.Size = new System.Drawing.Size(201, 20);
            this.ctrlBookkeeper.TxtEmail.TabIndex = 4;
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBookkeeper.TxtFirstName.Location = new System.Drawing.Point(257, 4);
            this.ctrlBookkeeper.TxtFirstName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlBookkeeper.TxtFirstName.Name = "txtFirstName";
            this.ctrlBookkeeper.TxtFirstName.NullText = "Ім\'я";
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtFirstName.RootElement.ControlBounds = new System.Drawing.Rectangle(257, 4, 201, 20);
            this.ctrlBookkeeper.TxtFirstName.RootElement.StretchVertically = true;
            this.ctrlBookkeeper.TxtFirstName.Size = new System.Drawing.Size(201, 20);
            this.ctrlBookkeeper.TxtFirstName.TabIndex = 1;
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBookkeeper.TxtLastName.Location = new System.Drawing.Point(33, 4);
            this.ctrlBookkeeper.TxtLastName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlBookkeeper.TxtLastName.Name = "txtLastName";
            this.ctrlBookkeeper.TxtLastName.NullText = "Прізвище";
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtLastName.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 4, 201, 20);
            this.ctrlBookkeeper.TxtLastName.RootElement.StretchVertically = true;
            this.ctrlBookkeeper.TxtLastName.Size = new System.Drawing.Size(201, 20);
            this.ctrlBookkeeper.TxtLastName.TabIndex = 0;
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBookkeeper.TxtPhone.Location = new System.Drawing.Point(33, 35);
            this.ctrlBookkeeper.TxtPhone.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlBookkeeper.TxtPhone.MaxLength = 13;
            this.ctrlBookkeeper.TxtPhone.Name = "txtPhone";
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtPhone.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 36, 201, 20);
            this.ctrlBookkeeper.TxtPhone.RootElement.StretchVertically = true;
            this.ctrlBookkeeper.TxtPhone.Size = new System.Drawing.Size(201, 20);
            this.ctrlBookkeeper.TxtPhone.TabIndex = 3;
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtSurName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBookkeeper.TxtSurName.Location = new System.Drawing.Point(481, 4);
            this.ctrlBookkeeper.TxtSurName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlBookkeeper.TxtSurName.Name = "txtSurName";
            this.ctrlBookkeeper.TxtSurName.NullText = "По батькові";
            // 
            // 
            // 
            this.ctrlBookkeeper.TxtSurName.RootElement.ControlBounds = new System.Drawing.Rectangle(481, 4, 201, 20);
            this.ctrlBookkeeper.TxtSurName.RootElement.StretchVertically = true;
            this.ctrlBookkeeper.TxtSurName.Size = new System.Drawing.Size(201, 20);
            this.ctrlBookkeeper.TxtSurName.TabIndex = 2;
            // 
            // txtOnBasicsIfHeadBoss
            // 
            this.txtOnBasicsIfHeadBoss.AutoSize = false;
            this.txtOnBasicsIfHeadBoss.Location = new System.Drawing.Point(153, 30);
            this.txtOnBasicsIfHeadBoss.Multiline = true;
            this.txtOnBasicsIfHeadBoss.Name = "txtOnBasicsIfHeadBoss";
            this.txtOnBasicsIfHeadBoss.NullText = "(статуту, положення, довіреності, свідоцтва про реєстрацію, виписки з ЄДР)";
            this.txtOnBasicsIfHeadBoss.Size = new System.Drawing.Size(583, 20);
            this.txtOnBasicsIfHeadBoss.TabIndex = 30;
            this.txtOnBasicsIfHeadBoss.ThemeName = "Office2013Light";
            // 
            // ctrlHeadBoss
            // 
            this.ctrlHeadBoss.DataSource = typeof(ipsFormsDesign.Interfaces.IEmployee);
            this.ctrlHeadBoss.Location = new System.Drawing.Point(54, 56);
            this.ctrlHeadBoss.Name = "ctrlHeadBoss";
            this.ctrlHeadBoss.OutsidePhone = false;
            this.ctrlHeadBoss.Size = new System.Drawing.Size(682, 56);
            this.ctrlHeadBoss.TabIndex = 31;
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlHeadBoss.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlHeadBoss.TxtEmail.Location = new System.Drawing.Point(481, 35);
            this.ctrlHeadBoss.TxtEmail.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlHeadBoss.TxtEmail.Name = "txtEmail";
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtEmail.RootElement.ControlBounds = new System.Drawing.Rectangle(481, 36, 201, 20);
            this.ctrlHeadBoss.TxtEmail.RootElement.StretchVertically = true;
            this.ctrlHeadBoss.TxtEmail.Size = new System.Drawing.Size(201, 20);
            this.ctrlHeadBoss.TxtEmail.TabIndex = 4;
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlHeadBoss.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlHeadBoss.TxtFirstName.Location = new System.Drawing.Point(257, 4);
            this.ctrlHeadBoss.TxtFirstName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlHeadBoss.TxtFirstName.Name = "txtFirstName";
            this.ctrlHeadBoss.TxtFirstName.NullText = "Ім\'я";
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtFirstName.RootElement.ControlBounds = new System.Drawing.Rectangle(257, 4, 201, 20);
            this.ctrlHeadBoss.TxtFirstName.RootElement.StretchVertically = true;
            this.ctrlHeadBoss.TxtFirstName.Size = new System.Drawing.Size(201, 20);
            this.ctrlHeadBoss.TxtFirstName.TabIndex = 1;
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlHeadBoss.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlHeadBoss.TxtLastName.Location = new System.Drawing.Point(33, 4);
            this.ctrlHeadBoss.TxtLastName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlHeadBoss.TxtLastName.Name = "txtLastName";
            this.ctrlHeadBoss.TxtLastName.NullText = "Прізвище";
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtLastName.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 4, 201, 20);
            this.ctrlHeadBoss.TxtLastName.RootElement.StretchVertically = true;
            this.ctrlHeadBoss.TxtLastName.Size = new System.Drawing.Size(201, 20);
            this.ctrlHeadBoss.TxtLastName.TabIndex = 0;
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlHeadBoss.TxtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlHeadBoss.TxtPhone.Location = new System.Drawing.Point(33, 35);
            this.ctrlHeadBoss.TxtPhone.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlHeadBoss.TxtPhone.MaxLength = 13;
            this.ctrlHeadBoss.TxtPhone.Name = "txtPhone";
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtPhone.RootElement.ControlBounds = new System.Drawing.Rectangle(33, 36, 201, 20);
            this.ctrlHeadBoss.TxtPhone.RootElement.StretchVertically = true;
            this.ctrlHeadBoss.TxtPhone.Size = new System.Drawing.Size(201, 20);
            this.ctrlHeadBoss.TxtPhone.TabIndex = 3;
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtSurName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlHeadBoss.TxtSurName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ctrlHeadBoss.TxtSurName.Location = new System.Drawing.Point(481, 4);
            this.ctrlHeadBoss.TxtSurName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.ctrlHeadBoss.TxtSurName.Name = "txtSurName";
            this.ctrlHeadBoss.TxtSurName.NullText = "По батькові";
            // 
            // 
            // 
            this.ctrlHeadBoss.TxtSurName.RootElement.ControlBounds = new System.Drawing.Rectangle(481, 4, 201, 20);
            this.ctrlHeadBoss.TxtSurName.RootElement.StretchVertically = true;
            this.ctrlHeadBoss.TxtSurName.Size = new System.Drawing.Size(201, 20);
            this.ctrlHeadBoss.TxtSurName.TabIndex = 2;
            // 
            // radLabel8
            // 
            this.radLabel8.AutoSize = false;
            this.radLabel8.Location = new System.Drawing.Point(54, 30);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(93, 20);
            this.radLabel8.TabIndex = 23;
            this.radLabel8.Text = "Діє на підставі:";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // radSeparator5
            // 
            this.radSeparator5.Location = new System.Drawing.Point(116, 207);
            this.radSeparator5.Name = "radSeparator5";
            this.radSeparator5.Size = new System.Drawing.Size(619, 21);
            this.radSeparator5.TabIndex = 24;
            this.radSeparator5.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel6.Location = new System.Drawing.Point(3, 207);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(107, 21);
            this.radLabel6.TabIndex = 25;
            this.radLabel6.Text = "Контактні особи";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // radSeparator4
            // 
            this.radSeparator4.Location = new System.Drawing.Point(75, 118);
            this.radSeparator4.Name = "radSeparator4";
            this.radSeparator4.Size = new System.Drawing.Size(661, 21);
            this.radSeparator4.TabIndex = 26;
            this.radSeparator4.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel5.Location = new System.Drawing.Point(3, 118);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(66, 21);
            this.radLabel5.TabIndex = 27;
            this.radLabel5.Text = "Бухгалтер";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Location = new System.Drawing.Point(75, 3);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(661, 21);
            this.radSeparator3.TabIndex = 28;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel4.Location = new System.Drawing.Point(3, 3);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(62, 21);
            this.radLabel4.TabIndex = 29;
            this.radLabel4.Text = "Керівник";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // gvContactPersons
            // 
            this.gvContactPersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvContactPersons.Location = new System.Drawing.Point(3, 258);
            // 
            // 
            // 
            this.gvContactPersons.MasterTemplate.AllowAddNewRow = false;
            this.gvContactPersons.MasterTemplate.AllowColumnReorder = false;
            this.gvContactPersons.MasterTemplate.AllowDeleteRow = false;
            this.gvContactPersons.MasterTemplate.AllowEditRow = false;
            this.gvContactPersons.MasterTemplate.AutoGenerateColumns = false;
            this.gvContactPersons.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "Emplid";
            gridViewDecimalColumn1.HeaderText = "Emplid";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "Emplid";
            gridViewDecimalColumn1.Width = 52;
            gridViewDecimalColumn2.DataType = typeof(System.Nullable<int>);
            gridViewDecimalColumn2.FieldName = "CustId";
            gridViewDecimalColumn2.HeaderText = "CustId";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Name = "CustId";
            gridViewDecimalColumn2.Width = 57;
            gridViewTextBoxColumn1.FieldName = "UserId";
            gridViewTextBoxColumn1.HeaderText = "UserId";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "UserId";
            gridViewTextBoxColumn1.Width = 63;
            gridViewTextBoxColumn2.FieldName = "LastName";
            gridViewTextBoxColumn2.HeaderText = "Прізвище";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "LastName";
            gridViewTextBoxColumn2.Width = 135;
            gridViewTextBoxColumn3.FieldName = "FirstName";
            gridViewTextBoxColumn3.HeaderText = "Ім\'я";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "FirstName";
            gridViewTextBoxColumn3.Width = 84;
            gridViewTextBoxColumn4.FieldName = "SurName";
            gridViewTextBoxColumn4.HeaderText = "По батькові";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "SurName";
            gridViewTextBoxColumn4.Width = 84;
            gridViewTextBoxColumn5.FieldName = "PhoneNumber";
            gridViewTextBoxColumn5.HeaderText = "Номер";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.MaxWidth = 105;
            gridViewTextBoxColumn5.MinWidth = 105;
            gridViewTextBoxColumn5.Name = "PhoneNumber";
            gridViewTextBoxColumn5.Width = 105;
            gridViewTextBoxColumn6.FieldName = "Email";
            gridViewTextBoxColumn6.HeaderText = "Email";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "Email";
            gridViewTextBoxColumn6.Width = 125;
            gridViewTextBoxColumn7.FieldName = "Comment";
            gridViewTextBoxColumn7.HeaderText = "Примітка";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "Comment";
            gridViewTextBoxColumn7.Width = 275;
            gridViewTextBoxColumn8.DataType = typeof(ipsFormsDesign.Model.Customer);
            gridViewTextBoxColumn8.FieldName = "Cust";
            gridViewTextBoxColumn8.HeaderText = "Cust";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "Cust";
            gridViewTextBoxColumn8.Width = 70;
            gridViewTextBoxColumn9.DataType = typeof(ipsFormsDesign.Model.AspNetUsers);
            gridViewTextBoxColumn9.FieldName = "User";
            gridViewTextBoxColumn9.HeaderText = "User";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "User";
            gridViewTextBoxColumn9.Width = 79;
            gridViewTextBoxColumn10.DataType = typeof(ipsFormsDesign.Interfaces.ObservableListSource<ipsFormsDesign.Model.RelEmployee>);
            gridViewTextBoxColumn10.FieldName = "RelEmployee";
            gridViewTextBoxColumn10.HeaderText = "RelEmployee";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "RelEmployee";
            gridViewTextBoxColumn10.Width = 79;
            gridViewCommandColumn1.FieldName = "editBtn";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "editBtn";
            gridViewCommandColumn1.Width = 30;
            gridViewCommandColumn2.FieldName = "deleteBtn";
            gridViewCommandColumn2.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = global::IpsViewComponentLibrary.Properties.Resources.deleteIcon;
            gridViewCommandColumn2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.MaxWidth = 30;
            gridViewCommandColumn2.MinWidth = 30;
            gridViewCommandColumn2.Name = "deleteBtn";
            gridViewCommandColumn2.Width = 30;
            this.gvContactPersons.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.gvContactPersons.MasterTemplate.DataSource = this.bsEmployee;
            this.gvContactPersons.MasterTemplate.EnableGrouping = false;
            this.gvContactPersons.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvContactPersons.Name = "gvContactPersons";
            this.gvContactPersons.ReadOnly = true;
            this.gvContactPersons.Size = new System.Drawing.Size(887, 193);
            this.gvContactPersons.TabIndex = 33;
            this.gvContactPersons.ThemeName = "Office2013Light";
            this.gvContactPersons.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvContactPersons_CommandCellClick);
            // 
            // bsEmployee
            // 
            this.bsEmployee.DataSource = typeof(ipsFormsDesign.Model.Employee);
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(3, 232);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(156, 20);
            this.btnAddContact.TabIndex = 34;
            this.btnAddContact.Text = "Додати контакну особу";
            this.btnAddContact.ThemeName = "Office2013Light";
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // ManagersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.gvContactPersons);
            this.Controls.Add(this.ctrlBookkeeper);
            this.Controls.Add(this.txtOnBasicsIfHeadBoss);
            this.Controls.Add(this.ctrlHeadBoss);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radSeparator5);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radSeparator4);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radSeparator3);
            this.Controls.Add(this.radLabel4);
            this.Name = "ManagersControl";
            this.Size = new System.Drawing.Size(893, 454);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBookkeeper.TxtSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeadBoss.TxtSurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContactPersons.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContactPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IpsBossNameContactsControl ctrlBookkeeper;
        private Telerik.WinControls.UI.RadTextBox txtOnBasicsIfHeadBoss;
        private IpsBossNameContactsControl ctrlHeadBoss;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadSeparator radSeparator5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadSeparator radSeparator4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadSeparator radSeparator3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadGridView gvContactPersons;
        private System.Windows.Forms.BindingSource bsEmployee;
        private Telerik.WinControls.UI.RadButton btnAddContact;
    }
}
