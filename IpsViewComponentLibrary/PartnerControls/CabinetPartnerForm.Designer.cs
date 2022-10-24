using IpsViewComponentLibrary.Common;

namespace IpsViewComponentLibrary.PartnerControls
{
    partial class CabinetPartnerForm
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pvFiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvClients = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlPartnerClients = new IpsViewComponentLibrary.PartnerControls.PartnerClientsControl();
            this.pvAnketa = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageViewAgreement = new Telerik.WinControls.UI.RadPageView();
            this.pvAgrMain = new Telerik.WinControls.UI.RadPageViewPage();
            this.checkPartnerInternal = new Telerik.WinControls.UI.RadCheckBox();
            this.bsPartner = new System.Windows.Forms.BindingSource(this.components);
            this.ddbtnChangeAgrStatus = new Telerik.WinControls.UI.RadSplitButton();
            this.btnAcceptAgr = new Telerik.WinControls.UI.RadMenuItem();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadMenuItem();
            this.separator = new Telerik.WinControls.UI.RadSeparator();
            this.lblStatusName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.ctrlAgreement = new IpsViewComponentLibrary.PartnerControls.AgreementPartnerControl();
            this.pvAgrTerms = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlConditions = new IpsViewComponentLibrary.PartnerControls.ConditionsControl();
            this.ctrlSaveCancelButtons = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            this.bsBankAccount = new System.Windows.Forms.BindingSource(this.components);
            this.pvClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pvAgreement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageViewAgreement)).BeginInit();
            this.pageViewAgreement.SuspendLayout();
            this.pvAgrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPartnerInternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnChangeAgrStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            this.pvAgrTerms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pvFiles
            // 
            this.pvFiles.Enabled = false;
            this.pvFiles.ItemSize = new System.Drawing.SizeF(51F, 27F);
            this.pvFiles.Location = new System.Drawing.Point(5, 31);
            this.pvFiles.Name = "pvFiles";
            this.pvFiles.Size = new System.Drawing.Size(1065, 510);
            this.pvFiles.Text = "Файли";
            // 
            // pvClients
            // 
            this.pvClients.Controls.Add(this.ctrlPartnerClients);
            this.pvClients.ItemSize = new System.Drawing.SizeF(83F, 27F);
            this.pvClients.Location = new System.Drawing.Point(5, 31);
            this.pvClients.Name = "pvClients";
            this.pvClients.Size = new System.Drawing.Size(1065, 510);
            this.pvClients.Text = "Користувачі";
            // 
            // ctrlPartnerClients
            // 
            this.ctrlPartnerClients.ClientName = "";
            this.ctrlPartnerClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPartnerClients.Location = new System.Drawing.Point(0, 0);
            this.ctrlPartnerClients.Name = "ctrlPartnerClients";
            this.ctrlPartnerClients.Size = new System.Drawing.Size(1065, 510);
            this.ctrlPartnerClients.TabIndex = 0;
            // 
            // pvAnketa
            // 
            this.pvAnketa.ItemSize = new System.Drawing.SizeF(135F, 27F);
            this.pvAnketa.Location = new System.Drawing.Point(5, 31);
            this.pvAnketa.Name = "pvAnketa";
            this.pvAnketa.Size = new System.Drawing.Size(1065, 510);
            this.pvAnketa.Text = "Анкета представника";
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pvAnketa);
            this.pageView.Controls.Add(this.pvAgreement);
            this.pageView.Controls.Add(this.pvClients);
            this.pageView.Controls.Add(this.pvFiles);
            this.pageView.DefaultPage = this.pvClients;
            this.pageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageView.Location = new System.Drawing.Point(0, 0);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pvClients;
            this.pageView.Size = new System.Drawing.Size(1075, 546);
            this.pageView.TabIndex = 0;
            this.pageView.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pvAgreement
            // 
            this.pvAgreement.Controls.Add(this.pageViewAgreement);
            this.pvAgreement.Controls.Add(this.ctrlSaveCancelButtons);
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(59F, 27F);
            this.pvAgreement.Location = new System.Drawing.Point(5, 31);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(1065, 510);
            this.pvAgreement.Text = "Договір";
            // 
            // pageViewAgreement
            // 
            this.pageViewAgreement.Controls.Add(this.pvAgrMain);
            this.pageViewAgreement.Controls.Add(this.pvAgrTerms);
            this.pageViewAgreement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageViewAgreement.Location = new System.Drawing.Point(0, 0);
            this.pageViewAgreement.Name = "pageViewAgreement";
            this.pageViewAgreement.SelectedPage = this.pvAgrMain;
            this.pageViewAgreement.Size = new System.Drawing.Size(1065, 479);
            this.pageViewAgreement.TabIndex = 0;
            this.pageViewAgreement.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAgreement.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAgreement.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAgreement.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvAgrMain
            // 
            this.pvAgrMain.Controls.Add(this.checkPartnerInternal);
            this.pvAgrMain.Controls.Add(this.ddbtnChangeAgrStatus);
            this.pvAgrMain.Controls.Add(this.separator);
            this.pvAgrMain.Controls.Add(this.lblStatusName);
            this.pvAgrMain.Controls.Add(this.radLabel7);
            this.pvAgrMain.Controls.Add(this.ctrlAgreement);
            this.pvAgrMain.ItemSize = new System.Drawing.SizeF(136F, 27F);
            this.pvAgrMain.Location = new System.Drawing.Point(140, 5);
            this.pvAgrMain.Name = "pvAgrMain";
            this.pvAgrMain.Size = new System.Drawing.Size(920, 469);
            this.pvAgrMain.Text = "Інформація договору";
            // 
            // checkPartnerInternal
            // 
            this.checkPartnerInternal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsPartner, "IsMy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, false));
            this.checkPartnerInternal.Location = new System.Drawing.Point(35, 149);
            this.checkPartnerInternal.Name = "checkPartnerInternal";
            this.checkPartnerInternal.Size = new System.Drawing.Size(233, 19);
            this.checkPartnerInternal.TabIndex = 2;
            this.checkPartnerInternal.Text = "Представник - співробітник компанії";
            this.checkPartnerInternal.ThemeName = "Office2013Light";
            // 
            // bsPartner
            // 
            this.bsPartner.DataSource = typeof(ipsFormsDesign.Model.Partner);
            // 
            // ddbtnChangeAgrStatus
            // 
            this.ddbtnChangeAgrStatus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAcceptAgr,
            this.btnCloseAgr});
            this.ddbtnChangeAgrStatus.Location = new System.Drawing.Point(279, 200);
            this.ddbtnChangeAgrStatus.Name = "ddbtnChangeAgrStatus";
            this.ddbtnChangeAgrStatus.Size = new System.Drawing.Size(177, 19);
            this.ddbtnChangeAgrStatus.TabIndex = 3;
            this.ddbtnChangeAgrStatus.Text = "Змінити статус договору";
            this.ddbtnChangeAgrStatus.ThemeName = "Office2013Light";
            // 
            // btnAcceptAgr
            // 
            this.btnAcceptAgr.Name = "btnAcceptAgr";
            this.btnAcceptAgr.Text = "Підтвердити договір";
            this.btnAcceptAgr.UseCompatibleTextRendering = false;
            this.btnAcceptAgr.Click += new System.EventHandler(this.btnAcceptAgr_Click);
            // 
            // btnCloseAgr
            // 
            this.btnCloseAgr.Name = "btnCloseAgr";
            this.btnCloseAgr.Text = "Закрити договір";
            this.btnCloseAgr.UseCompatibleTextRendering = false;
            this.btnCloseAgr.Click += new System.EventHandler(this.btnCloseAgr_Click);
            // 
            // separator
            // 
            this.separator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator.Location = new System.Drawing.Point(3, 174);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(914, 20);
            this.separator.TabIndex = 0;
            this.separator.ThemeName = "Office2013Light";
            // 
            // lblStatusName
            // 
            this.lblStatusName.AutoSize = false;
            this.lblStatusName.BorderVisible = true;
            this.lblStatusName.Location = new System.Drawing.Point(130, 201);
            this.lblStatusName.MinimumSize = new System.Drawing.Size(120, 18);
            this.lblStatusName.Name = "lblStatusName";
            // 
            // 
            // 
            this.lblStatusName.RootElement.MinSize = new System.Drawing.Size(120, 18);
            this.lblStatusName.Size = new System.Drawing.Size(143, 18);
            this.lblStatusName.TabIndex = 0;
            this.lblStatusName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblStatusName.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatusName.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatusName.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatusName.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).LeftWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).TopWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).RightWidth = 0F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).LeftColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).TopColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).RightColor = System.Drawing.Color.Transparent;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.lblStatusName.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(25, 200);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(99, 19);
            this.radLabel7.TabIndex = 0;
            this.radLabel7.Text = "Статус договору";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementCommunityDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlAgreement.IsReadOnly = false;
            this.ctrlAgreement.Location = new System.Drawing.Point(25, 3);
            this.ctrlAgreement.MaximumSize = new System.Drawing.Size(500, 140);
            this.ctrlAgreement.MinimumSize = new System.Drawing.Size(394, 140);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(498, 140);
            this.ctrlAgreement.TabIndex = 1;
            // 
            // pvAgrTerms
            // 
            this.pvAgrTerms.Controls.Add(this.ctrlConditions);
            this.pvAgrTerms.ItemSize = new System.Drawing.SizeF(136F, 27F);
            this.pvAgrTerms.Location = new System.Drawing.Point(140, 5);
            this.pvAgrTerms.Name = "pvAgrTerms";
            this.pvAgrTerms.Size = new System.Drawing.Size(920, 469);
            this.pvAgrTerms.Text = "Умови представника";
            // 
            // ctrlConditions
            // 
            this.ctrlConditions.AgreementAddPartnerDataSource = typeof(ipsFormsDesign.Model.AgreementAddPartner);
            this.ctrlConditions.IsReadOnly = false;
            this.ctrlConditions.Location = new System.Drawing.Point(25, 3);
            this.ctrlConditions.Name = "ctrlConditions";
            this.ctrlConditions.Size = new System.Drawing.Size(702, 357);
            this.ctrlConditions.TabIndex = 1;
            // 
            // ctrlSaveCancelButtons
            // 
            this.ctrlSaveCancelButtons.ButtonSaveDialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctrlSaveCancelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlSaveCancelButtons.Location = new System.Drawing.Point(0, 479);
            this.ctrlSaveCancelButtons.MaximumSize = new System.Drawing.Size(3000, 31);
            this.ctrlSaveCancelButtons.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlSaveCancelButtons.Name = "ctrlSaveCancelButtons";
            this.ctrlSaveCancelButtons.SaveButtonEnabled = true;
            this.ctrlSaveCancelButtons.Size = new System.Drawing.Size(1065, 31);
            this.ctrlSaveCancelButtons.TabIndex = 2;
            // 
            // bsBankAccount
            // 
            this.bsBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            // 
            // CabinetPartnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1075, 546);
            this.Controls.Add(this.pageView);
            this.Name = "CabinetPartnerForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Кабінет";
            this.ThemeName = "Office2013Light";
            this.pvClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pvAgreement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageViewAgreement)).EndInit();
            this.pageViewAgreement.ResumeLayout(false);
            this.pvAgrMain.ResumeLayout(false);
            this.pvAgrMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPartnerInternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnChangeAgrStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            this.pvAgrTerms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsBankAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource bsBankAccount;
        private Telerik.WinControls.UI.RadPageViewPage pvFiles;
        private Telerik.WinControls.UI.RadPageViewPage pvClients;
        private PartnerControls.PartnerClientsControl ctrlPartnerClients;
        private Telerik.WinControls.UI.RadPageViewPage pvAnketa;
        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.UI.RadPageView pageViewAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvAgrMain;
        private Telerik.WinControls.UI.RadPageViewPage pvAgrTerms;
        private Telerik.WinControls.UI.RadSeparator separator;
        private Telerik.WinControls.UI.RadSplitButton ddbtnChangeAgrStatus;
        private Telerik.WinControls.UI.RadMenuItem btnAcceptAgr;
        private Telerik.WinControls.UI.RadMenuItem btnCloseAgr;
        private Telerik.WinControls.UI.RadLabel lblStatusName;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private PartnerControls.AgreementPartnerControl ctrlAgreement;
        private PartnerControls.ConditionsControl ctrlConditions;
        private Telerik.WinControls.UI.RadCheckBox checkPartnerInternal;
        private System.Windows.Forms.BindingSource bsPartner;
        private SaveCancelButtonsControl ctrlSaveCancelButtons;
    }
}
