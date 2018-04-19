namespace sysAdminwp
{
    partial class DataEditControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLblSearch = new System.Windows.Forms.Label();
            this.rTxtBSearchData = new Telerik.WinControls.UI.RadTextBox();
            this.rPanelChange = new Telerik.WinControls.UI.RadPanel();
            this.rTxtBNameRu = new Telerik.WinControls.UI.RadTextBox();
            this.rTxtBNameEn = new Telerik.WinControls.UI.RadTextBox();
            this.rTxtBNameUa = new Telerik.WinControls.UI.RadTextBox();
            this.rTxtBCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabelNameRu = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameEn = new Telerik.WinControls.UI.RadLabel();
            this.radLabelNameUa = new Telerik.WinControls.UI.RadLabel();
            this.radLabelCode = new Telerik.WinControls.UI.RadLabel();
            this.rBtnCancel = new Telerik.WinControls.UI.RadButton();
            this.rBtnSave = new Telerik.WinControls.UI.RadButton();
            this.rBtnRemove = new Telerik.WinControls.UI.RadButton();
            this.rBtnAdd = new Telerik.WinControls.UI.RadButton();
            this.rGridViewData = new Telerik.WinControls.UI.RadGridView();
            this.rMenuItemCfg = new Telerik.WinControls.UI.RadMenuItem();
            this.rMItemSaveConfig = new Telerik.WinControls.UI.RadMenuItem();
            this.rMItemsSetDefaultSett = new Telerik.WinControls.UI.RadMenuItem();
            this.rMainMenu = new Telerik.WinControls.UI.RadMenu();
            this.rLblStatus = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBSearchData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelChange)).BeginInit();
            this.rPanelChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMainMenu)).BeginInit();
            this.rMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // radLblSearch
            // 
            this.radLblSearch.AutoSize = true;
            this.radLblSearch.Location = new System.Drawing.Point(3, 35);
            this.radLblSearch.Name = "radLblSearch";
            this.radLblSearch.Size = new System.Drawing.Size(43, 13);
            this.radLblSearch.TabIndex = 15;
            this.radLblSearch.Text = "Пошук:";
            // 
            // rTxtBSearchData
            // 
            this.rTxtBSearchData.Location = new System.Drawing.Point(53, 33);
            this.rTxtBSearchData.Name = "rTxtBSearchData";
            this.rTxtBSearchData.NullText = "Введіть слово для пошуку...";
            this.rTxtBSearchData.Size = new System.Drawing.Size(338, 20);
            this.rTxtBSearchData.TabIndex = 14;
            this.rTxtBSearchData.TabStop = false;
            // 
            // rPanelChange
            // 
            this.rPanelChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rPanelChange.Controls.Add(this.rTxtBNameRu);
            this.rPanelChange.Controls.Add(this.rTxtBNameEn);
            this.rPanelChange.Controls.Add(this.rTxtBNameUa);
            this.rPanelChange.Controls.Add(this.rTxtBCode);
            this.rPanelChange.Controls.Add(this.radLabelNameRu);
            this.rPanelChange.Controls.Add(this.radLabelNameEn);
            this.rPanelChange.Controls.Add(this.radLabelNameUa);
            this.rPanelChange.Controls.Add(this.radLabelCode);
            this.rPanelChange.Controls.Add(this.rBtnCancel);
            this.rPanelChange.Controls.Add(this.rBtnSave);
            this.rPanelChange.Location = new System.Drawing.Point(3, 415);
            this.rPanelChange.Name = "rPanelChange";
            this.rPanelChange.Size = new System.Drawing.Size(969, 178);
            this.rPanelChange.TabIndex = 12;
            this.rPanelChange.Text = "Дані довідника";
            this.rPanelChange.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.UI.RadPanelElement)(this.rPanelChange.GetChildAt(0))).Text = "Дані довідника";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rPanelChange.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rPanelChange.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Azure;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rPanelChange.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.rPanelChange.GetChildAt(0).GetChildAt(2))).TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.rPanelChange.GetChildAt(0).GetChildAt(2))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.rPanelChange.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rTxtBNameRu
            // 
            this.rTxtBNameRu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBNameRu.Location = new System.Drawing.Point(162, 109);
            this.rTxtBNameRu.Name = "rTxtBNameRu";
            this.rTxtBNameRu.Size = new System.Drawing.Size(789, 20);
            this.rTxtBNameRu.TabIndex = 9;
            // 
            // rTxtBNameEn
            // 
            this.rTxtBNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBNameEn.Location = new System.Drawing.Point(162, 82);
            this.rTxtBNameEn.Name = "rTxtBNameEn";
            this.rTxtBNameEn.Size = new System.Drawing.Size(789, 20);
            this.rTxtBNameEn.TabIndex = 8;
            // 
            // rTxtBNameUa
            // 
            this.rTxtBNameUa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBNameUa.Location = new System.Drawing.Point(162, 55);
            this.rTxtBNameUa.Name = "rTxtBNameUa";
            this.rTxtBNameUa.Size = new System.Drawing.Size(789, 20);
            this.rTxtBNameUa.TabIndex = 7;
            // 
            // rTxtBCode
            // 
            this.rTxtBCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBCode.Location = new System.Drawing.Point(162, 28);
            this.rTxtBCode.Name = "rTxtBCode";
            this.rTxtBCode.Size = new System.Drawing.Size(789, 20);
            this.rTxtBCode.TabIndex = 6;
            // 
            // radLabelNameRu
            // 
            this.radLabelNameRu.AutoSize = false;
            this.radLabelNameRu.BackColor = System.Drawing.Color.Transparent;
            this.radLabelNameRu.Location = new System.Drawing.Point(55, 109);
            this.radLabelNameRu.Name = "radLabelNameRu";
            this.radLabelNameRu.Size = new System.Drawing.Size(90, 18);
            this.radLabelNameRu.TabIndex = 5;
            this.radLabelNameRu.Text = "Название (RU):";
            this.radLabelNameRu.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabelNameEn
            // 
            this.radLabelNameEn.AutoSize = false;
            this.radLabelNameEn.BackColor = System.Drawing.Color.Transparent;
            this.radLabelNameEn.Location = new System.Drawing.Point(55, 82);
            this.radLabelNameEn.Name = "radLabelNameEn";
            this.radLabelNameEn.Size = new System.Drawing.Size(90, 18);
            this.radLabelNameEn.TabIndex = 4;
            this.radLabelNameEn.Text = "Name (EN):";
            this.radLabelNameEn.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabelNameUa
            // 
            this.radLabelNameUa.AutoSize = false;
            this.radLabelNameUa.BackColor = System.Drawing.Color.Transparent;
            this.radLabelNameUa.Location = new System.Drawing.Point(55, 55);
            this.radLabelNameUa.Name = "radLabelNameUa";
            this.radLabelNameUa.Size = new System.Drawing.Size(90, 18);
            this.radLabelNameUa.TabIndex = 3;
            this.radLabelNameUa.Text = "Назва (UA):";
            this.radLabelNameUa.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabelCode
            // 
            this.radLabelCode.AutoSize = false;
            this.radLabelCode.BackColor = System.Drawing.Color.Transparent;
            this.radLabelCode.Location = new System.Drawing.Point(55, 28);
            this.radLabelCode.Name = "radLabelCode";
            this.radLabelCode.Size = new System.Drawing.Size(90, 18);
            this.radLabelCode.TabIndex = 2;
            this.radLabelCode.Text = "Код:";
            this.radLabelCode.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // rBtnCancel
            // 
            this.rBtnCancel.Location = new System.Drawing.Point(278, 135);
            this.rBtnCancel.Name = "rBtnCancel";
            this.rBtnCancel.Size = new System.Drawing.Size(110, 24);
            this.rBtnCancel.TabIndex = 1;
            this.rBtnCancel.Text = "Відміна";
            // 
            // rBtnSave
            // 
            this.rBtnSave.Location = new System.Drawing.Point(162, 135);
            this.rBtnSave.Name = "rBtnSave";
            this.rBtnSave.Size = new System.Drawing.Size(110, 24);
            this.rBtnSave.TabIndex = 0;
            this.rBtnSave.Text = "Зберегти";
            // 
            // rBtnRemove
            // 
            this.rBtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnRemove.Location = new System.Drawing.Point(143, 378);
            this.rBtnRemove.Name = "rBtnRemove";
            this.rBtnRemove.Size = new System.Drawing.Size(110, 24);
            this.rBtnRemove.TabIndex = 10;
            this.rBtnRemove.Text = "Видалити";
            // 
            // rBtnAdd
            // 
            this.rBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnAdd.Location = new System.Drawing.Point(13, 378);
            this.rBtnAdd.Name = "rBtnAdd";
            this.rBtnAdd.Size = new System.Drawing.Size(110, 24);
            this.rBtnAdd.TabIndex = 9;
            this.rBtnAdd.Text = "Додати";
            // 
            // rGridViewData
            // 
            this.rGridViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridViewData.EnableCustomFiltering = true;
            this.rGridViewData.Location = new System.Drawing.Point(1, 60);
            this.rGridViewData.Margin = new System.Windows.Forms.Padding(1);
            // 
            // 
            // 
            this.rGridViewData.MasterTemplate.AllowAddNewRow = false;
            this.rGridViewData.MasterTemplate.AllowEditRow = false;
            this.rGridViewData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGridViewData.MasterTemplate.EnableCustomFiltering = true;
            this.rGridViewData.MasterTemplate.EnableFiltering = true;
            this.rGridViewData.MasterTemplate.ShowFilteringRow = false;
            this.rGridViewData.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rGridViewData.Name = "rGridViewData";
            this.rGridViewData.Size = new System.Drawing.Size(971, 314);
            this.rGridViewData.TabIndex = 8;
            // 
            // rMenuItemCfg
            // 
            this.rMenuItemCfg.Alignment = System.Drawing.ContentAlignment.TopLeft;
            this.rMenuItemCfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.rMenuItemCfg.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rMItemSaveConfig,
            this.rMItemsSetDefaultSett});
            this.rMenuItemCfg.Name = "rMenuItemCfg";
            this.rMenuItemCfg.PopupDirection = Telerik.WinControls.UI.RadDirection.Right;
            this.rMenuItemCfg.Text = "Конфігурація";
            this.rMenuItemCfg.UseCompatibleTextRendering = false;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rMenuItemCfg.GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rMenuItemCfg.GetChildAt(1))).BorderDrawMode = Telerik.WinControls.BorderDrawModes.VerticalOverHorizontal;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rMenuItemCfg.GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rMItemSaveConfig
            // 
            this.rMItemSaveConfig.Name = "rMItemSaveConfig";
            this.rMItemSaveConfig.Text = "Зберегти поточну конфігурацію";
            this.rMItemSaveConfig.UseCompatibleTextRendering = false;
            // 
            // rMItemsSetDefaultSett
            // 
            this.rMItemsSetDefaultSett.Name = "rMItemsSetDefaultSett";
            this.rMItemsSetDefaultSett.Text = "Відновити початкові налаштуавння";
            this.rMItemsSetDefaultSett.UseCompatibleTextRendering = false;
            // 
            // rMainMenu
            // 
            this.rMainMenu.AutoSize = false;
            this.rMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.rMainMenu.Controls.Add(this.rLblStatus);
            this.rMainMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rMainMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rMenuItemCfg});
            this.rMainMenu.Location = new System.Drawing.Point(0, 0);
            this.rMainMenu.Name = "rMainMenu";
            this.rMainMenu.Size = new System.Drawing.Size(975, 27);
            this.rMainMenu.TabIndex = 16;
            ((Telerik.WinControls.UI.RadMenuElement)(this.rMainMenu.GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadMenuElement)(this.rMainMenu.GetChildAt(0))).RightToLeft = true;
            ((Telerik.WinControls.Layout.WrapLayoutPanel)(this.rMainMenu.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.TopRight;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rMainMenu.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.rMainMenu.GetChildAt(0).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.TopRight;
            ((Telerik.WinControls.Layouts.StackLayoutPanel)(this.rMainMenu.GetChildAt(0).GetChildAt(2))).Alignment = System.Drawing.ContentAlignment.TopRight;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.rMainMenu.GetChildAt(0).GetChildAt(3))).Alignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // rLblStatus
            // 
            this.rLblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rLblStatus.Location = new System.Drawing.Point(13, 4);
            this.rLblStatus.Name = "rLblStatus";
            this.rLblStatus.Size = new System.Drawing.Size(2, 2);
            this.rLblStatus.TabIndex = 0;
            // 
            // DataEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rMainMenu);
            this.Controls.Add(this.radLblSearch);
            this.Controls.Add(this.rTxtBSearchData);
            this.Controls.Add(this.rPanelChange);
            this.Controls.Add(this.rBtnRemove);
            this.Controls.Add(this.rBtnAdd);
            this.Controls.Add(this.rGridViewData);
            this.Name = "DataEditControl";
            this.Size = new System.Drawing.Size(975, 599);
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBSearchData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelChange)).EndInit();
            this.rPanelChange.ResumeLayout(false);
            this.rPanelChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelNameUa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMainMenu)).EndInit();
            this.rMainMenu.ResumeLayout(false);
            this.rMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label radLblSearch;
        private Telerik.WinControls.UI.RadTextBox rTxtBSearchData;
        private Telerik.WinControls.UI.RadPanel rPanelChange;
        private Telerik.WinControls.UI.RadTextBox rTxtBNameRu;
        private Telerik.WinControls.UI.RadTextBox rTxtBNameEn;
        private Telerik.WinControls.UI.RadTextBox rTxtBNameUa;
        private Telerik.WinControls.UI.RadTextBox rTxtBCode;
        private Telerik.WinControls.UI.RadLabel radLabelNameRu;
        private Telerik.WinControls.UI.RadLabel radLabelNameEn;
        private Telerik.WinControls.UI.RadLabel radLabelNameUa;
        private Telerik.WinControls.UI.RadLabel radLabelCode;
        private Telerik.WinControls.UI.RadButton rBtnCancel;
        private Telerik.WinControls.UI.RadButton rBtnSave;
        private Telerik.WinControls.UI.RadButton rBtnRemove;
        private Telerik.WinControls.UI.RadButton rBtnAdd;
        private Telerik.WinControls.UI.RadGridView rGridViewData;
        private Telerik.WinControls.UI.RadMenuItem rMenuItemCfg;
        private Telerik.WinControls.UI.RadMenuItem rMItemSaveConfig;
        private Telerik.WinControls.UI.RadMenuItem rMItemsSetDefaultSett;
        private Telerik.WinControls.UI.RadMenu rMainMenu;
        private Telerik.WinControls.UI.RadLabel rLblStatus;
    }
}
