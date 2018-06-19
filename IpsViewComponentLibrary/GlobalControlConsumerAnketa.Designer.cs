namespace IpsViewComponentLibrary
{
    partial class GlobalControlConsumerAnketa
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageAnketaConsumer = new Telerik.WinControls.UI.RadPageView();
            this.pvClientName = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvAddress = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvManagers = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvPlaces = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvBankRequisites = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvAgreement = new Telerik.WinControls.UI.RadPageViewPage();
            this.pvPrint = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnNext = new Telerik.WinControls.UI.RadButton();
            this.btnBack = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).BeginInit();
            this.pageAnketaConsumer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // pageAnketaConsumer
            // 
            this.pageAnketaConsumer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageAnketaConsumer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pageAnketaConsumer.Controls.Add(this.pvClientName);
            this.pageAnketaConsumer.Controls.Add(this.pvAddress);
            this.pageAnketaConsumer.Controls.Add(this.pvManagers);
            this.pageAnketaConsumer.Controls.Add(this.pvPlaces);
            this.pageAnketaConsumer.Controls.Add(this.pvBankRequisites);
            this.pageAnketaConsumer.Controls.Add(this.pvAgreement);
            this.pageAnketaConsumer.Controls.Add(this.pvPrint);
            this.pageAnketaConsumer.DefaultPage = this.pvClientName;
            this.pageAnketaConsumer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pageAnketaConsumer.Location = new System.Drawing.Point(3, 3);
            this.pageAnketaConsumer.Name = "pageAnketaConsumer";
            // 
            // 
            // 
            this.pageAnketaConsumer.RootElement.FocusBorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pageAnketaConsumer.SelectedPage = this.pvClientName;
            this.pageAnketaConsumer.SelectionWrap = false;
            this.pageAnketaConsumer.Size = new System.Drawing.Size(1165, 622);
            this.pageAnketaConsumer.TabIndex = 1;
            this.pageAnketaConsumer.ThemeName = "Office2007Silver";
            this.pageAnketaConsumer.SelectedPageChanging += new System.EventHandler<Telerik.WinControls.UI.RadPageViewCancelEventArgs>(this.pageAnketaConsumer_SelectedPageChanging);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageAnketaConsumer.GetChildAt(0))).ShadowColor = System.Drawing.Color.Black;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).CustomFontStyle = System.Drawing.FontStyle.Bold;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.StripViewItemLayout)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Enabled = true;
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).ToolTipText = "Scroll Strip Right";
            ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.pageAnketaConsumer.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Enabled = false;
            // 
            // pvClientName
            // 
            this.pvClientName.ItemSize = new System.Drawing.SizeF(124F, 26F);
            this.pvClientName.Location = new System.Drawing.Point(133, 10);
            this.pvClientName.Name = "pvClientName";
            this.pvClientName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pvClientName.Size = new System.Drawing.Size(1021, 601);
            this.pvClientName.TabStop = true;
            this.pvClientName.Text = "Назва клієнта";
            // 
            // pvAddress
            // 
            this.pvAddress.ItemSize = new System.Drawing.SizeF(124F, 26F);
            this.pvAddress.Location = new System.Drawing.Point(133, 10);
            this.pvAddress.Name = "pvAddress";
            this.pvAddress.Size = new System.Drawing.Size(1021, 510);
            this.pvAddress.Text = "Адреса";
            // 
            // pvManagers
            // 
            this.pvManagers.ItemSize = new System.Drawing.SizeF(124F, 26F);
            this.pvManagers.Location = new System.Drawing.Point(133, 10);
            this.pvManagers.Name = "pvManagers";
            this.pvManagers.Size = new System.Drawing.Size(1021, 510);
            this.pvManagers.Text = "Керівники";
            // 
            // pvPlaces
            // 
            this.pvPlaces.ItemSize = new System.Drawing.SizeF(124F, 26F);
            this.pvPlaces.Location = new System.Drawing.Point(133, 10);
            this.pvPlaces.Name = "pvPlaces";
            this.pvPlaces.Size = new System.Drawing.Size(1021, 510);
            this.pvPlaces.Text = "Майданчики";
            // 
            // pvBankRequisites
            // 
            this.pvBankRequisites.AutoScroll = true;
            this.pvBankRequisites.ItemSize = new System.Drawing.SizeF(124F, 26F);
            this.pvBankRequisites.Location = new System.Drawing.Point(133, 10);
            this.pvBankRequisites.Name = "pvBankRequisites";
            this.pvBankRequisites.Size = new System.Drawing.Size(1021, 510);
            this.pvBankRequisites.Text = "Банківські реквізити";
            // 
            // pvAgreement
            // 
            this.pvAgreement.ItemSize = new System.Drawing.SizeF(124F, 26F);
            this.pvAgreement.Location = new System.Drawing.Point(133, 10);
            this.pvAgreement.Name = "pvAgreement";
            this.pvAgreement.Size = new System.Drawing.Size(1021, 510);
            this.pvAgreement.Text = "Договір";
            // 
            // pvPrint
            // 
            this.pvPrint.ItemSize = new System.Drawing.SizeF(124F, 26F);
            this.pvPrint.Location = new System.Drawing.Point(133, 10);
            this.pvPrint.Name = "pvPrint";
            this.pvPrint.Size = new System.Drawing.Size(1021, 510);
            this.pvPrint.Text = "Друк";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(979, 588);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(175, 24);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "вперед";
            this.btnNext.ThemeName = "Aqua";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(798, 588);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 24);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "назад";
            this.btnBack.ThemeName = "Aqua";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // GlobalControlConsumerAnketa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pageAnketaConsumer);
            this.Name = "GlobalControlConsumerAnketa";
            this.Size = new System.Drawing.Size(1171, 628);
            ((System.ComponentModel.ISupportInitialize)(this.pageAnketaConsumer)).EndInit();
            this.pageAnketaConsumer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageAnketaConsumer;
        private Telerik.WinControls.UI.RadPageViewPage pvClientName;
        private Telerik.WinControls.UI.RadPageViewPage pvAddress;
        private Telerik.WinControls.UI.RadPageViewPage pvManagers;
        private Telerik.WinControls.UI.RadPageViewPage pvPlaces;
        private Telerik.WinControls.UI.RadPageViewPage pvBankRequisites;
        private Telerik.WinControls.UI.RadPageViewPage pvAgreement;
        private Telerik.WinControls.UI.RadPageViewPage pvPrint;
        private Telerik.WinControls.UI.RadButton btnNext;
        private Telerik.WinControls.UI.RadButton btnBack;
    }
}
