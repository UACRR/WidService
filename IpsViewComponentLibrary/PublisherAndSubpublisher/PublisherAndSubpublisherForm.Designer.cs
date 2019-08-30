namespace IpsViewComponentLibrary.PublisherAndSubpublisher
{
    partial class PublisherAndSubpublisherForm
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
            this.ddlPublisher = new IpsViewComponentLibrary.Common.Editors.IpsDropDownList();
            this.bsRelSubPublish = new System.Windows.Forms.BindingSource(this.components);
            this.ddlSubPublisher = new IpsViewComponentLibrary.Common.Editors.IpsDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dtDateBegin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.dtDateEnd = new Telerik.WinControls.UI.RadDateTimePicker();
            this.ctrlSaveCancelButtons = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            this.lblInfo = new Telerik.WinControls.UI.RadLabel();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bsPublishers = new System.Windows.Forms.BindingSource(this.components);
            this.bsSubPublishers = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPublisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelSubPublish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubPublisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPublishers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubPublishers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(84, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Видавництво:";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // ddlPublisher
            // 
            this.ddlPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlPublisher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlPublisher.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRelSubPublish, "CustIdPub", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlPublisher.DataSource = this.bsPublishers;
            this.ddlPublisher.DisplayMember = "PublisherName";
            this.ddlPublisher.Location = new System.Drawing.Point(122, 12);
            this.ddlPublisher.Name = "ddlPublisher";
            this.ddlPublisher.Size = new System.Drawing.Size(333, 21);
            this.ddlPublisher.TabIndex = 1;
            this.ddlPublisher.ThemeName = "Office2013Light";
            this.ddlPublisher.ValueMember = "CustId";
            // 
            // bsRelSubPublish
            // 
            this.bsRelSubPublish.DataSource = typeof(ipsFormsDesign.Model.RelSubPublish);
            // 
            // ddlSubPublisher
            // 
            this.ddlSubPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlSubPublisher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlSubPublisher.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsRelSubPublish, "CustIdSub", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ddlSubPublisher.DataSource = this.bsSubPublishers;
            this.ddlSubPublisher.DisplayMember = "PublisherName";
            this.ddlSubPublisher.Location = new System.Drawing.Point(122, 39);
            this.ddlSubPublisher.Name = "ddlSubPublisher";
            this.ddlSubPublisher.Size = new System.Drawing.Size(333, 21);
            this.ddlSubPublisher.TabIndex = 3;
            this.ddlSubPublisher.ThemeName = "Office2013Light";
            this.ddlSubPublisher.ValueMember = "CustId";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(104, 19);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Субвидавництво:";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 67);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(108, 19);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Дія повноважень:";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRelSubPublish, "DateBegin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateBegin.Location = new System.Drawing.Point(144, 66);
            this.dtDateBegin.Name = "dtDateBegin";
            this.dtDateBegin.NullText = " / / ";
            this.dtDateBegin.Size = new System.Drawing.Size(113, 21);
            this.dtDateBegin.TabIndex = 5;
            this.dtDateBegin.TabStop = false;
            this.dtDateBegin.ThemeName = "Office2013Light";
            this.dtDateBegin.Value = new System.DateTime(((long)(0)));
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(128, 67);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(12, 19);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "з";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(270, 67);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(21, 19);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "по";
            this.radLabel5.ThemeName = "Office2013Light";
            // 
            // dtDateEnd
            // 
            this.dtDateEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsRelSubPublish, "DateEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateEnd.Location = new System.Drawing.Point(295, 66);
            this.dtDateEnd.Name = "dtDateEnd";
            this.dtDateEnd.NullText = " / / ";
            this.dtDateEnd.Size = new System.Drawing.Size(113, 21);
            this.dtDateEnd.TabIndex = 7;
            this.dtDateEnd.TabStop = false;
            this.dtDateEnd.ThemeName = "Office2013Light";
            this.dtDateEnd.Value = new System.DateTime(((long)(0)));
            // 
            // ctrlSaveCancelButtons
            // 
            this.ctrlSaveCancelButtons.ButtonSaveDialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrlSaveCancelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancelButtons.Location = new System.Drawing.Point(0, 172);
            this.ctrlSaveCancelButtons.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancelButtons.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancelButtons.Name = "ctrlSaveCancelButtons";
            this.ctrlSaveCancelButtons.SaveButtonEnabled = true;
            this.ctrlSaveCancelButtons.Size = new System.Drawing.Size(489, 31);
            this.ctrlSaveCancelButtons.TabIndex = 9;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = false;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(21, 103);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(377, 39);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "*Для продовження або дострокового розірвання повноважень Субвидавництва змініть \"" +
    "дату по\"!";
            this.lblInfo.ThemeName = "Office2013Light";
            this.lblInfo.Visible = false;
            // 
            // bsPublishers
            // 
            this.bsPublishers.DataSource = typeof(ipsFormsDesign.ViewModels.Other.PublishersView);
            // 
            // bsSubPublishers
            // 
            this.bsSubPublishers.DataSource = typeof(ipsFormsDesign.ViewModels.Other.PublishersView);
            // 
            // PublisherAndSubpublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(489, 203);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.ctrlSaveCancelButtons);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.dtDateEnd);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.dtDateBegin);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.ddlSubPublisher);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ddlPublisher);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PublisherAndSubpublisherForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметри угоди для Субвидавництва";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPublisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelSubPublish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubPublisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPublishers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSubPublishers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Common.Editors.IpsDropDownList ddlPublisher;
        private Common.Editors.IpsDropDownList ddlSubPublisher;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateBegin;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadDateTimePicker dtDateEnd;
        private Common.SaveCancelButtonsControl ctrlSaveCancelButtons;
        private Telerik.WinControls.UI.RadLabel lblInfo;
        private System.Windows.Forms.BindingSource bsRelSubPublish;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsPublishers;
        private System.Windows.Forms.BindingSource bsSubPublishers;
    }
}