using System.Drawing;
using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.Shared.Controls;

namespace IpsViewComponentLibrary.CommunityControls
{
    partial class CommunityCabinetForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewHyperlinkColumn gridViewHyperlinkColumn1 = new Telerik.WinControls.UI.GridViewHyperlinkColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.pageViewMain = new Telerik.WinControls.UI.RadPageView();
            this.pvAnketaData = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageViewAnketa = new Telerik.WinControls.UI.RadPageView();
            this.pvCommunityName = new Telerik.WinControls.UI.RadPageViewPage();
            this.radSeparator5 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtOnBasicsIfHeadBoss = new Telerik.WinControls.UI.RadTextBox();
            this.bsRelEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator4 = new Telerik.WinControls.UI.RadSeparator();
            this.txtIpi = new Telerik.WinControls.UI.RadTextBox();
            this.bsCommunity = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.pvAddress = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnCopyFromJuToFa = new Telerik.WinControls.UI.RadButton();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator3 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.btnCopyFromFaToLett = new Telerik.WinControls.UI.RadButton();
            this.btnCopyFromJuToLett = new Telerik.WinControls.UI.RadButton();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.pvBank = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvAgrData = new Telerik.WinControls.UI.RadPageViewPage();
            this.lblCommunityName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddbtnChangeAgrStatus = new Telerik.WinControls.UI.RadSplitButton();
            this.btnAcceptAgr = new Telerik.WinControls.UI.RadMenuItem();
            this.btnCloseAgr = new Telerik.WinControls.UI.RadMenuItem();
            this.lblStatusName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.pvAutorsData = new Telerik.WinControls.UI.RadPageViewPage();
            this.parentGridPanel = new Telerik.WinControls.UI.RadPanel();
            this.gvViewAutors = new Telerik.WinControls.UI.RadGridView();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.bsCommunityAuthorsView = new System.Windows.Forms.BindingSource(this.components);
            this.bottomPanel = new Telerik.WinControls.UI.RadPanel();
            this.btnLimitationRight = new Telerik.WinControls.UI.RadButton();
            this.pvReportsData = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvFilesData = new Telerik.WinControls.UI.RadPageViewPage();
            this.ctrlTabNavigation = new IpsViewComponentLibrary.Common.TabNavigationControl();
            this.ctrlContactPerson = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.ctrlClientName = new IpsViewComponentLibrary.Shared.Controls.IpsAnketaCompanyControl();
            this.ctrlHeadBoss = new IpsViewComponentLibrary.Shared.Controls.IpsBossNameContactsControl();
            this.ctrlAddressLe = new IpsViewComponentLibrary.CommunityControls.CommunityAddressLetterControl();
            this.ctrlAddressFa = new IpsViewComponentLibrary.CommunityControls.CommunityAddressControl();
            this.ctrlAddressJu = new IpsViewComponentLibrary.CommunityControls.CommunityAddressControl();
            this.ctrlBankAccount = new IpsViewComponentLibrary.Shared.Controls.IpsBankAccountControl();
            this.ctrlAgreement = new IpsViewComponentLibrary.CommunityControls.CommunityAgreementControl();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.pageViewMain)).BeginInit();
            this.pageViewMain.SuspendLayout();
            this.pvAnketaData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageViewAnketa)).BeginInit();
            this.pageViewAnketa.SuspendLayout();
            this.pvCommunityName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            this.pvAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJuToFa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromFaToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJuToLett)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            this.pvBank.SuspendLayout();
            this.pvAgrData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCommunityName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnChangeAgrStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.pvAutorsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentGridPanel)).BeginInit();
            this.parentGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).BeginInit();
            this.gvViewAutors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunityAuthorsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimitationRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageViewMain
            // 
            this.pageViewMain.Controls.Add(this.pvAnketaData);
            this.pageViewMain.Controls.Add(this.pvAgrData);
            this.pageViewMain.Controls.Add(this.pvAutorsData);
            this.pageViewMain.Controls.Add(this.pvReportsData);
            this.pageViewMain.Controls.Add(this.pvFilesData);
            this.pageViewMain.DefaultPage = this.pvAutorsData;
            this.pageViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageViewMain.Location = new System.Drawing.Point(0, 0);
            this.pageViewMain.Name = "pageViewMain";
            this.pageViewMain.SelectedPage = this.pvAutorsData;
            this.pageViewMain.Size = new System.Drawing.Size(976, 536);
            this.pageViewMain.TabIndex = 0;
            this.pageViewMain.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pvAnketaData
            // 
            this.pvAnketaData.Controls.Add(this.ctrlTabNavigation);
            this.pvAnketaData.Controls.Add(this.pageViewAnketa);
            this.pvAnketaData.ItemSize = new System.Drawing.SizeF(52F, 25F);
            this.pvAnketaData.Location = new System.Drawing.Point(5, 29);
            this.pvAnketaData.Name = "pvAnketaData";
            this.pvAnketaData.Size = new System.Drawing.Size(966, 502);
            this.pvAnketaData.Text = "Анкета";
            // 
            // pageViewAnketa
            // 
            this.pageViewAnketa.Controls.Add(this.pvCommunityName);
            this.pageViewAnketa.Controls.Add(this.pvAddress);
            this.pageViewAnketa.Controls.Add(this.pvBank);
            this.pageViewAnketa.DefaultPage = this.pvCommunityName;
            this.pageViewAnketa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageViewAnketa.Location = new System.Drawing.Point(0, 0);
            this.pageViewAnketa.Name = "pageViewAnketa";
            this.pageViewAnketa.SelectedPage = this.pvCommunityName;
            this.pageViewAnketa.Size = new System.Drawing.Size(966, 502);
            this.pageViewAnketa.TabIndex = 0;
            this.pageViewAnketa.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageViewAnketa.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // pvCommunityName
            // 
            this.pvCommunityName.Controls.Add(this.radSeparator5);
            this.pvCommunityName.Controls.Add(this.radLabel10);
            this.pvCommunityName.Controls.Add(this.txtOnBasicsIfHeadBoss);
            this.pvCommunityName.Controls.Add(this.radLabel4);
            this.pvCommunityName.Controls.Add(this.radSeparator4);
            this.pvCommunityName.Controls.Add(this.txtIpi);
            this.pvCommunityName.Controls.Add(this.radLabel3);
            this.pvCommunityName.Controls.Add(this.radLabel6);
            this.pvCommunityName.Controls.Add(this.ctrlContactPerson);
            this.pvCommunityName.Controls.Add(this.ctrlClientName);
            this.pvCommunityName.Controls.Add(this.ctrlHeadBoss);
            this.pvCommunityName.ItemSize = new System.Drawing.SizeF(128F, 25F);
            this.pvCommunityName.Location = new System.Drawing.Point(132, 5);
            this.pvCommunityName.Name = "pvCommunityName";
            this.pvCommunityName.Size = new System.Drawing.Size(829, 492);
            this.pvCommunityName.Text = "Товариство";
            // 
            // radSeparator5
            // 
            this.radSeparator5.Location = new System.Drawing.Point(92, 84);
            this.radSeparator5.Name = "radSeparator5";
            this.radSeparator5.Size = new System.Drawing.Size(527, 19);
            this.radSeparator5.TabIndex = 0;
            this.radSeparator5.ThemeName = "Office2013Light";
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(22, 84);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(64, 19);
            this.radLabel10.TabIndex = 0;
            this.radLabel10.Text = "Директор:";
            this.radLabel10.ThemeName = "Office2013Light";
            // 
            // txtOnBasicsIfHeadBoss
            // 
            this.txtOnBasicsIfHeadBoss.AutoSize = false;
            this.txtOnBasicsIfHeadBoss.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRelEmployee, "RelDocument", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtOnBasicsIfHeadBoss.Location = new System.Drawing.Point(121, 109);
            this.txtOnBasicsIfHeadBoss.Multiline = true;
            this.txtOnBasicsIfHeadBoss.Name = "txtOnBasicsIfHeadBoss";
            this.txtOnBasicsIfHeadBoss.NullText = "(статуту, положення, довіреності, свідоцтва про реєстрацію, виписки з ЄДР)";
            this.txtOnBasicsIfHeadBoss.Size = new System.Drawing.Size(498, 20);
            this.txtOnBasicsIfHeadBoss.TabIndex = 3;
            this.txtOnBasicsIfHeadBoss.ThemeName = "Office2013Light";
            // 
            // bsRelEmployee
            // 
            this.bsRelEmployee.DataSource = typeof(ipsFormsDesign.Model.RelEmployee);
            // 
            // radLabel4
            // 
            this.radLabel4.AutoSize = false;
            this.radLabel4.Location = new System.Drawing.Point(22, 109);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(93, 20);
            this.radLabel4.TabIndex = 0;
            this.radLabel4.Text = "Діє на підставі:";
            this.radLabel4.ThemeName = "Office2013Light";
            // 
            // radSeparator4
            // 
            this.radSeparator4.Location = new System.Drawing.Point(132, 199);
            this.radSeparator4.Name = "radSeparator4";
            this.radSeparator4.Size = new System.Drawing.Size(487, 19);
            this.radSeparator4.TabIndex = 0;
            this.radSeparator4.ThemeName = "Office2013Light";
            // 
            // txtIpi
            // 
            this.txtIpi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCommunity, "InterCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.txtIpi.Location = new System.Drawing.Point(231, 57);
            this.txtIpi.Name = "txtIpi";
            this.txtIpi.Size = new System.Drawing.Size(243, 21);
            this.txtIpi.TabIndex = 2;
            this.txtIpi.ThemeName = "Office2013Light";
            // 
            // bsCommunity
            // 
            this.bsCommunity.DataSource = typeof(ipsFormsDesign.Model.Community);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(22, 59);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(203, 19);
            this.radLabel3.TabIndex = 0;
            this.radLabel3.Text = "Міжнародний код товариства (IPI):";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(22, 199);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(104, 19);
            this.radLabel6.TabIndex = 0;
            this.radLabel6.Text = "Контактна особа:";
            this.radLabel6.ThemeName = "Office2013Light";
            // 
            // pvAddress
            // 
            this.pvAddress.Controls.Add(this.ctrlAddressLe);
            this.pvAddress.Controls.Add(this.btnCopyFromJuToFa);
            this.pvAddress.Controls.Add(this.radLabel9);
            this.pvAddress.Controls.Add(this.radSeparator3);
            this.pvAddress.Controls.Add(this.radLabel8);
            this.pvAddress.Controls.Add(this.radSeparator2);
            this.pvAddress.Controls.Add(this.btnCopyFromFaToLett);
            this.pvAddress.Controls.Add(this.btnCopyFromJuToLett);
            this.pvAddress.Controls.Add(this.radLabel7);
            this.pvAddress.Controls.Add(this.radSeparator1);
            this.pvAddress.Controls.Add(this.ctrlAddressFa);
            this.pvAddress.Controls.Add(this.ctrlAddressJu);
            this.pvAddress.ItemSize = new System.Drawing.SizeF(128F, 25F);
            this.pvAddress.Location = new System.Drawing.Point(134, 5);
            this.pvAddress.Name = "pvAddress";
            this.pvAddress.Size = new System.Drawing.Size(827, 490);
            this.pvAddress.Text = "Адреса";
            // 
            // btnCopyFromJuToFa
            // 
            this.btnCopyFromJuToFa.Location = new System.Drawing.Point(140, 112);
            this.btnCopyFromJuToFa.Name = "btnCopyFromJuToFa";
            this.btnCopyFromJuToFa.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromJuToFa.TabIndex = 2;
            this.btnCopyFromJuToFa.Text = "Копіювати з юридичної адреси";
            this.btnCopyFromJuToFa.ThemeName = "Office2013Light";
            this.btnCopyFromJuToFa.Click += new System.EventHandler(this.btnCopyFromLiveToReg_Click);
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(24, 191);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(114, 19);
            this.radLabel9.TabIndex = 0;
            this.radLabel9.Text = "Адреса листування";
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // radSeparator3
            // 
            this.radSeparator3.Location = new System.Drawing.Point(140, 191);
            this.radSeparator3.Name = "radSeparator3";
            this.radSeparator3.Size = new System.Drawing.Size(503, 19);
            this.radSeparator3.TabIndex = 0;
            this.radSeparator3.ThemeName = "Office2013Light";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(24, 87);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(103, 19);
            this.radLabel8.TabIndex = 0;
            this.radLabel8.Text = "Фактична адреса";
            this.radLabel8.ThemeName = "Office2013Light";
            // 
            // radSeparator2
            // 
            this.radSeparator2.Location = new System.Drawing.Point(140, 87);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(503, 19);
            this.radSeparator2.TabIndex = 0;
            this.radSeparator2.ThemeName = "Office2013Light";
            // 
            // btnCopyFromFaToLett
            // 
            this.btnCopyFromFaToLett.Location = new System.Drawing.Point(341, 216);
            this.btnCopyFromFaToLett.Name = "btnCopyFromFaToLett";
            this.btnCopyFromFaToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromFaToLett.TabIndex = 5;
            this.btnCopyFromFaToLett.Text = "Копіювати з фактичної адреси";
            this.btnCopyFromFaToLett.ThemeName = "Office2013Light";
            this.btnCopyFromFaToLett.Click += new System.EventHandler(this.btnCopyFromRegToLett_Click);
            // 
            // btnCopyFromJuToLett
            // 
            this.btnCopyFromJuToLett.Location = new System.Drawing.Point(140, 216);
            this.btnCopyFromJuToLett.Name = "btnCopyFromJuToLett";
            this.btnCopyFromJuToLett.Size = new System.Drawing.Size(195, 19);
            this.btnCopyFromJuToLett.TabIndex = 4;
            this.btnCopyFromJuToLett.Text = "Копіювати з юридичної адреси";
            this.btnCopyFromJuToLett.ThemeName = "Office2013Light";
            this.btnCopyFromJuToLett.Click += new System.EventHandler(this.btnCopyFromLiveToLett_Click);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(24, 8);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(110, 19);
            this.radLabel7.TabIndex = 0;
            this.radLabel7.Text = "Юридична адреса";
            this.radLabel7.ThemeName = "Office2013Light";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(140, 8);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(503, 19);
            this.radSeparator1.TabIndex = 0;
            this.radSeparator1.ThemeName = "Office2013Light";
            // 
            // pvBank
            // 
            this.pvBank.Controls.Add(this.ctrlBankAccount);
            this.pvBank.ItemSize = new System.Drawing.SizeF(128F, 25F);
            this.pvBank.Location = new System.Drawing.Point(134, 5);
            this.pvBank.Name = "pvBank";
            this.pvBank.Size = new System.Drawing.Size(827, 490);
            this.pvBank.Text = "Банківські реквізити";
            // 
            // pvAgrData
            // 
            this.pvAgrData.Controls.Add(this.lblCommunityName);
            this.pvAgrData.Controls.Add(this.radLabel2);
            this.pvAgrData.Controls.Add(this.groupBox1);
            this.pvAgrData.Controls.Add(this.ctrlAgreement);
            this.pvAgrData.ItemSize = new System.Drawing.SizeF(57F, 25F);
            this.pvAgrData.Location = new System.Drawing.Point(5, 31);
            this.pvAgrData.Name = "pvAgrData";
            this.pvAgrData.Size = new System.Drawing.Size(966, 500);
            this.pvAgrData.Text = "Договір";
            // 
            // lblCommunityName
            // 
            this.lblCommunityName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCommunityName.Location = new System.Drawing.Point(18, 29);
            this.lblCommunityName.Name = "lblCommunityName";
            this.lblCommunityName.Size = new System.Drawing.Size(37, 19);
            this.lblCommunityName.TabIndex = 0;
            this.lblCommunityName.Text = "name";
            this.lblCommunityName.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel2.Location = new System.Drawing.Point(18, 4);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(207, 19);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "Тип договору: Угода з товариством";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddbtnChangeAgrStatus);
            this.groupBox1.Controls.Add(this.lblStatusName);
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Location = new System.Drawing.Point(10, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Налаштування договору";
            // 
            // ddbtnChangeAgrStatus
            // 
            this.ddbtnChangeAgrStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddbtnChangeAgrStatus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btnAcceptAgr,
            this.btnCloseAgr});
            this.ddbtnChangeAgrStatus.Location = new System.Drawing.Point(318, 22);
            this.ddbtnChangeAgrStatus.Name = "ddbtnChangeAgrStatus";
            this.ddbtnChangeAgrStatus.Size = new System.Drawing.Size(177, 19);
            this.ddbtnChangeAgrStatus.TabIndex = 1;
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
            // lblStatusName
            // 
            this.lblStatusName.AutoSize = false;
            this.lblStatusName.BorderVisible = true;
            this.lblStatusName.Location = new System.Drawing.Point(169, 23);
            this.lblStatusName.MinimumSize = new System.Drawing.Size(120, 18);
            this.lblStatusName.Name = "lblStatusName";
            // 
            // 
            // 
            this.lblStatusName.RootElement.MinSize = new System.Drawing.Size(120, 18);
            this.lblStatusName.Size = new System.Drawing.Size(143, 18);
            this.lblStatusName.TabIndex = 0;
            this.lblStatusName.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lblStatusName.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatusName.GetChildAt(0))).BorderVisible = true;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblStatusName.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
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
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(6, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(157, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Поточний статус договору";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // pvAutorsData
            // 
            this.pvAutorsData.Controls.Add(this.parentGridPanel);
            this.pvAutorsData.Controls.Add(this.bottomPanel);
            this.pvAutorsData.ItemSize = new System.Drawing.SizeF(54F, 25F);
            this.pvAutorsData.Location = new System.Drawing.Point(5, 29);
            this.pvAutorsData.Name = "pvAutorsData";
            this.pvAutorsData.Size = new System.Drawing.Size(966, 502);
            this.pvAutorsData.Text = "Автори";
            // 
            // parentGridPanel
            // 
            this.parentGridPanel.Controls.Add(this.gvViewAutors);
            this.parentGridPanel.Controls.Add(this.ctrlSearch);
            this.parentGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentGridPanel.Location = new System.Drawing.Point(0, 0);
            this.parentGridPanel.Name = "parentGridPanel";
            this.parentGridPanel.Size = new System.Drawing.Size(966, 471);
            this.parentGridPanel.TabIndex = 0;
            this.parentGridPanel.ThemeName = "Office2013Light";
            // 
            // gvViewAutors
            // 
            this.gvViewAutors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewAutors.AutoScroll = true;
            this.gvViewAutors.AutoSizeRows = true;
            this.gvViewAutors.Controls.Add(this.waitingBar);
            this.gvViewAutors.EnableCustomFiltering = true;
            this.gvViewAutors.Location = new System.Drawing.Point(0, 29);
            // 
            // 
            // 
            this.gvViewAutors.MasterTemplate.AllowAddNewRow = false;
            this.gvViewAutors.MasterTemplate.AllowDeleteRow = false;
            this.gvViewAutors.MasterTemplate.AllowDragToGroup = false;
            this.gvViewAutors.MasterTemplate.AllowEditRow = false;
            this.gvViewAutors.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewAutors.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.FieldName = "CustId";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "CustId";
            gridViewTextBoxColumn2.DataType = typeof(System.Nullable<int>);
            gridViewTextBoxColumn2.FieldName = "CmCustId";
            gridViewTextBoxColumn2.HeaderText = "cmID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "CmCustId";
            gridViewTextBoxColumn2.Width = 25;
            gridViewTextBoxColumn3.FieldName = "InnerCode";
            gridViewTextBoxColumn3.HeaderText = "Шифр";
            gridViewTextBoxColumn3.MaxWidth = 95;
            gridViewTextBoxColumn3.MinWidth = 95;
            gridViewTextBoxColumn3.Multiline = true;
            gridViewTextBoxColumn3.Name = "InnerCode";
            gridViewTextBoxColumn3.Width = 95;
            gridViewTextBoxColumn3.WrapText = true;
            gridViewTextBoxColumn4.DataType = typeof(int);
            gridViewTextBoxColumn4.FieldName = "InterCode";
            gridViewTextBoxColumn4.HeaderText = "IPI";
            gridViewTextBoxColumn4.MaxWidth = 95;
            gridViewTextBoxColumn4.MinWidth = 95;
            gridViewTextBoxColumn4.Name = "InterCode";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 95;
            gridViewTextBoxColumn5.FieldName = "Name";
            gridViewTextBoxColumn5.HeaderText = "Правовласник";
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "Name";
            gridViewTextBoxColumn5.Width = 454;
            gridViewTextBoxColumn6.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn6.FieldName = "RegistrDate";
            gridViewTextBoxColumn6.FormatString = "{0:d}";
            gridViewTextBoxColumn6.HeaderText = "Дата народження/ Дата створення";
            gridViewTextBoxColumn6.MaxWidth = 120;
            gridViewTextBoxColumn6.MinWidth = 120;
            gridViewTextBoxColumn6.Multiline = true;
            gridViewTextBoxColumn6.Name = "RegistrDate";
            gridViewTextBoxColumn6.Width = 120;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewHyperlinkColumn1.DataType = typeof(int);
            gridViewHyperlinkColumn1.FieldName = "CntObj";
            gridViewHyperlinkColumn1.HeaderText = "К-сть об\'єктів";
            gridViewHyperlinkColumn1.MaxWidth = 60;
            gridViewHyperlinkColumn1.MinWidth = 60;
            gridViewHyperlinkColumn1.Name = "CntObj";
            gridViewHyperlinkColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewHyperlinkColumn1.Width = 60;
            gridViewHyperlinkColumn1.WrapText = true;
            gridViewTextBoxColumn7.DataType = typeof(decimal);
            gridViewTextBoxColumn7.FieldName = "YearProfit";
            gridViewTextBoxColumn7.HeaderText = "Дохід з початку року";
            gridViewTextBoxColumn7.MaxWidth = 90;
            gridViewTextBoxColumn7.MinWidth = 90;
            gridViewTextBoxColumn7.Name = "YearProfit";
            gridViewTextBoxColumn7.Width = 90;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewCommandColumn1.FieldName = "btnsEdit";
            gridViewCommandColumn1.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = global::IpsViewComponentLibrary.Properties.Resources.editIcon;
            gridViewCommandColumn1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.MaxWidth = 30;
            gridViewCommandColumn1.MinWidth = 30;
            gridViewCommandColumn1.Name = "btnsEdit";
            gridViewCommandColumn1.Width = 30;
            this.gvViewAutors.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewHyperlinkColumn1,
            gridViewTextBoxColumn7,
            gridViewCommandColumn1});
            this.gvViewAutors.MasterTemplate.DataSource = this.bsCommunityAuthorsView;
            this.gvViewAutors.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableFiltering = true;
            this.gvViewAutors.MasterTemplate.EnableGrouping = false;
            this.gvViewAutors.MasterTemplate.ShowFilteringRow = false;
            this.gvViewAutors.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewAutors.Name = "gvViewAutors";
            this.gvViewAutors.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewAutors.Size = new System.Drawing.Size(966, 439);
            this.gvViewAutors.TabIndex = 1;
            this.gvViewAutors.ThemeName = "Office2013Light";
            this.gvViewAutors.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewAutors_CellDoubleClick);
            this.gvViewAutors.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewAutors_CommandCellClick);
            // 
            // waitingBar
            // 
            this.waitingBar.AssociatedControl = this.parentGridPanel;
            this.waitingBar.Location = new System.Drawing.Point(448, 183);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 0;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.ThemeName = "Office2013Light";
            this.waitingBar.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement1);
            this.waitingBar.WaitingSpeed = 50;
            this.waitingBar.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.waitingBar.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.waitingBar.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.waitingBar.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // bsCommunityAuthorsView
            // 
            this.bsCommunityAuthorsView.DataSource = typeof(ipsFormsDesign.Interfaces.CommunityAuthorsView);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Silver;
            this.bottomPanel.Controls.Add(this.btnLimitationRight);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 471);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(966, 31);
            this.bottomPanel.TabIndex = 1;
            this.bottomPanel.ThemeName = "Office2013Light";
            // 
            // btnLimitationRight
            // 
            this.btnLimitationRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimitationRight.Location = new System.Drawing.Point(7, 3);
            this.btnLimitationRight.Name = "btnLimitationRight";
            this.btnLimitationRight.Size = new System.Drawing.Size(182, 24);
            this.btnLimitationRight.TabIndex = 0;
            this.btnLimitationRight.Text = "Додати правовласника";
            this.btnLimitationRight.ThemeName = "Office2013Light";
            this.btnLimitationRight.Click += new System.EventHandler(this.btnAddCommunity_Click);
            // 
            // pvReportsData
            // 
            this.pvReportsData.Enabled = false;
            this.pvReportsData.ItemSize = new System.Drawing.SizeF(41F, 25F);
            this.pvReportsData.Location = new System.Drawing.Point(5, 29);
            this.pvReportsData.Name = "pvReportsData";
            this.pvReportsData.Size = new System.Drawing.Size(966, 502);
            this.pvReportsData.Text = "Звіти";
            // 
            // pvFilesData
            // 
            this.pvFilesData.Enabled = false;
            this.pvFilesData.ItemSize = new System.Drawing.SizeF(49F, 25F);
            this.pvFilesData.Location = new System.Drawing.Point(5, 31);
            this.pvFilesData.Name = "pvFilesData";
            this.pvFilesData.Size = new System.Drawing.Size(966, 500);
            this.pvFilesData.Text = "Файли";
            // 
            // ctrlTabNavigation
            // 
            this.ctrlTabNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTabNavigation.Location = new System.Drawing.Point(0, 471);
            this.ctrlTabNavigation.MaximumSize = new System.Drawing.Size(2000, 31);
            this.ctrlTabNavigation.MinimumSize = new System.Drawing.Size(300, 31);
            this.ctrlTabNavigation.Name = "ctrlTabNavigation";
            this.ctrlTabNavigation.Size = new System.Drawing.Size(966, 31);
            this.ctrlTabNavigation.TabIndex = 1;
            // 
            // ctrlContactPerson
            // 
            this.ctrlContactPerson.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlContactPerson.Location = new System.Drawing.Point(22, 224);
            this.ctrlContactPerson.Name = "ctrlContactPerson";
            this.ctrlContactPerson.OutsidePhone = false;
            this.ctrlContactPerson.PhoneNullText = "+380## ### ## ##";
            this.ctrlContactPerson.Size = new System.Drawing.Size(597, 56);
            this.ctrlContactPerson.TabIndex = 5;
            // 
            // ctrlClientName
            // 
            this.ctrlClientName.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            this.ctrlClientName.Location = new System.Drawing.Point(22, 6);
            this.ctrlClientName.MaximumSize = new System.Drawing.Size(900, 47);
            this.ctrlClientName.MinimumSize = new System.Drawing.Size(400, 47);
            this.ctrlClientName.Name = "ctrlClientName";
            this.ctrlClientName.Size = new System.Drawing.Size(452, 47);
            this.ctrlClientName.TabIndex = 1;
            // 
            // ctrlHeadBoss
            // 
            this.ctrlHeadBoss.DataSource = typeof(ipsFormsDesign.Model.Employee);
            this.ctrlHeadBoss.Location = new System.Drawing.Point(22, 135);
            this.ctrlHeadBoss.Name = "ctrlHeadBoss";
            this.ctrlHeadBoss.OutsidePhone = false;
            this.ctrlHeadBoss.PhoneNullText = "+380## ### ## ##";
            this.ctrlHeadBoss.Size = new System.Drawing.Size(597, 56);
            this.ctrlHeadBoss.TabIndex = 4;
            // 
            // ctrlAddressLe
            // 
            this.ctrlAddressLe.AddressDataMember = null;
            this.ctrlAddressLe.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressLe.CityDataMember = null;
            this.ctrlAddressLe.CountryDataMember = "";
            this.ctrlAddressLe.Location = new System.Drawing.Point(140, 242);
            this.ctrlAddressLe.Name = "ctrlAddressLe";
            this.ctrlAddressLe.PostIndexDataMember = null;
            this.ctrlAddressLe.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressLe.TabIndex = 6;
            // 
            // ctrlAddressFa
            // 
            this.ctrlAddressFa.AddressDataMember = "";
            this.ctrlAddressFa.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressFa.CityDataMember = "";
            this.ctrlAddressFa.CountryDataMember = "";
            this.ctrlAddressFa.Location = new System.Drawing.Point(140, 137);
            this.ctrlAddressFa.Name = "ctrlAddressFa";
            this.ctrlAddressFa.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressFa.TabIndex = 3;
            // 
            // ctrlAddressJu
            // 
            this.ctrlAddressJu.AddressDataMember = "";
            this.ctrlAddressJu.AnketaCompanyDataSource = typeof(ipsFormsDesign.Model.AnketaCompany);
            this.ctrlAddressJu.CityDataMember = "";
            this.ctrlAddressJu.CountryDataMember = "";
            this.ctrlAddressJu.Location = new System.Drawing.Point(140, 33);
            this.ctrlAddressJu.Name = "ctrlAddressJu";
            this.ctrlAddressJu.Size = new System.Drawing.Size(489, 48);
            this.ctrlAddressJu.TabIndex = 1;
            // 
            // ctrlBankAccount
            // 
            this.ctrlBankAccount.DataSource = typeof(ipsFormsDesign.Model.BankAccount);
            this.ctrlBankAccount.Location = new System.Drawing.Point(22, 6);
            this.ctrlBankAccount.Name = "ctrlBankAccount";
            this.ctrlBankAccount.Size = new System.Drawing.Size(409, 127);
            this.ctrlBankAccount.TabIndex = 0;
            // 
            // ctrlAgreement
            // 
            this.ctrlAgreement.AgreementDataSource = typeof(ipsFormsDesign.Model.AgreementAddCommunity);
            this.ctrlAgreement.Location = new System.Drawing.Point(7, 54);
            this.ctrlAgreement.Name = "ctrlAgreement";
            this.ctrlAgreement.Size = new System.Drawing.Size(641, 260);
            this.ctrlAgreement.TabIndex = 1;
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 3);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(548, 20);
            this.ctrlSearch.TabIndex = 0;
            // 
            // CommunityCabinetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 536);
            this.Controls.Add(this.pageViewMain);
            this.Name = "CommunityCabinetForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Кабінет товариства";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.pageViewMain)).EndInit();
            this.pageViewMain.ResumeLayout(false);
            this.pvAnketaData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageViewAnketa)).EndInit();
            this.pageViewAnketa.ResumeLayout(false);
            this.pvCommunityName.ResumeLayout(false);
            this.pvCommunityName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnBasicsIfHeadBoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRelEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            this.pvAddress.ResumeLayout(false);
            this.pvAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJuToFa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromFaToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyFromJuToLett)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            this.pvBank.ResumeLayout(false);
            this.pvAgrData.ResumeLayout(false);
            this.pvAgrData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCommunityName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddbtnChangeAgrStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.pvAutorsData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parentGridPanel)).EndInit();
            this.parentGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewAutors)).EndInit();
            this.gvViewAutors.ResumeLayout(false);
            this.gvViewAutors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCommunityAuthorsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLimitationRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadPageView pageViewMain;
        private Telerik.WinControls.UI.RadPageViewPage pvAnketaData;
        private Telerik.WinControls.UI.RadPageViewPage pvAgrData;
        private Telerik.WinControls.UI.RadPageViewPage pvAutorsData;
        private Telerik.WinControls.UI.RadPageViewPage pvReportsData;
        private Telerik.WinControls.UI.RadPageViewPage pvFilesData;
        private Telerik.WinControls.UI.RadPageView pageViewAnketa;
        private Telerik.WinControls.UI.RadPageViewPage pvCommunityName;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private IpsBossNameContactsControl ctrlContactPerson;
        private IpsAnketaCompanyControl ctrlClientName;
        private Telerik.WinControls.UI.RadPageViewPage pvAddress;
        private CommunityAddressLetterControl ctrlAddressLe;
        private Telerik.WinControls.UI.RadButton btnCopyFromJuToFa;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadSeparator radSeparator3;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadSeparator radSeparator2;
        private Telerik.WinControls.UI.RadButton btnCopyFromFaToLett;
        private Telerik.WinControls.UI.RadButton btnCopyFromJuToLett;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private CommunityAddressControl ctrlAddressFa;
        private CommunityAddressControl ctrlAddressJu;
        private Telerik.WinControls.UI.RadPageViewPage pvBank;
        private IpsBankAccountControl ctrlBankAccount;
        private TabNavigationControl ctrlTabNavigation;
        private Common.SearchTextBoxControl ctrlSearch;
        private Telerik.WinControls.UI.RadGridView gvViewAutors;
        private Telerik.WinControls.UI.RadButton btnLimitationRight;
        private Telerik.WinControls.UI.RadLabel lblCommunityName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadSplitButton ddbtnChangeAgrStatus;
        private Telerik.WinControls.UI.RadMenuItem btnAcceptAgr;
        private Telerik.WinControls.UI.RadMenuItem btnCloseAgr;
        private Telerik.WinControls.UI.RadLabel lblStatusName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private CommunityAgreementControl ctrlAgreement;
        private Telerik.WinControls.UI.RadTextBox txtIpi;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.BindingSource bsCommunity;
        private System.Windows.Forms.BindingSource bsCommunityAuthorsView;
        private Telerik.WinControls.UI.RadPanel parentGridPanel;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadPanel bottomPanel;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadTextBox txtOnBasicsIfHeadBoss;
        private IpsBossNameContactsControl ctrlHeadBoss;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadSeparator radSeparator4;
        private Telerik.WinControls.UI.RadSeparator radSeparator5;
        private System.Windows.Forms.BindingSource bsRelEmployee;
    }
}
