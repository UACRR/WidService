using System.Drawing;

namespace IpsViewComponentLibrary
{
    partial class GlobalControlConsumerMainGridBR
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn40 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn41 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn42 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn43 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn44 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn45 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn46 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn47 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn48 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn49 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn50 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn51 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn52 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvViewConsumers = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnNewConsumer = new Telerik.WinControls.UI.RadButton();
            this.ctrlSearch = new IpsViewComponentLibrary.Common.SearchTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).BeginInit();
            this.SuspendLayout();
            // 
            // gvViewConsumers
            // 
            this.gvViewConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvViewConsumers.AutoScroll = true;
            this.gvViewConsumers.AutoSizeRows = true;
            this.gvViewConsumers.EnableCustomFiltering = true;
            this.gvViewConsumers.Location = new System.Drawing.Point(3, 29);
            // 
            // 
            // 
            this.gvViewConsumers.MasterTemplate.AllowAddNewRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDeleteRow = false;
            this.gvViewConsumers.MasterTemplate.AllowDragToGroup = false;
            this.gvViewConsumers.MasterTemplate.AllowEditRow = false;
            this.gvViewConsumers.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewConsumers.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn40.DataType = typeof(int);
            gridViewTextBoxColumn40.FieldName = "CustId";
            gridViewTextBoxColumn40.HeaderText = "ID";
            gridViewTextBoxColumn40.IsVisible = false;
            gridViewTextBoxColumn40.Name = "CustId";
            gridViewTextBoxColumn41.DataType = typeof(int);
            gridViewTextBoxColumn41.FieldName = "Innokpo";
            gridViewTextBoxColumn41.HeaderText = "ЄДРПОУ";
            gridViewTextBoxColumn41.MaxWidth = 100;
            gridViewTextBoxColumn41.MinWidth = 80;
            gridViewTextBoxColumn41.Name = "Innokpo";
            gridViewTextBoxColumn41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn41.Width = 85;
            gridViewTextBoxColumn42.FieldName = "AgrNumber";
            gridViewTextBoxColumn42.HeaderText = "№ Ген. договору";
            gridViewTextBoxColumn42.MaxWidth = 100;
            gridViewTextBoxColumn42.MinWidth = 78;
            gridViewTextBoxColumn42.Multiline = true;
            gridViewTextBoxColumn42.Name = "AgrNumber";
            gridViewTextBoxColumn42.Width = 82;
            gridViewTextBoxColumn42.WrapText = true;
            gridViewTextBoxColumn43.FieldName = "Name";
            gridViewTextBoxColumn43.HeaderText = "Назва";
            gridViewTextBoxColumn43.MinWidth = 150;
            gridViewTextBoxColumn43.Multiline = true;
            gridViewTextBoxColumn43.Name = "Name";
            gridViewTextBoxColumn43.Width = 183;
            gridViewTextBoxColumn43.WrapText = true;
            gridViewTextBoxColumn44.FieldName = "JaCity";
            gridViewTextBoxColumn44.HeaderText = "Місто";
            gridViewTextBoxColumn44.Name = "JaCity";
            gridViewTextBoxColumn44.Width = 63;
            gridViewTextBoxColumn45.FieldName = "StatusName";
            gridViewTextBoxColumn45.HeaderText = "Статус Угоди";
            gridViewTextBoxColumn45.MaxWidth = 115;
            gridViewTextBoxColumn45.MinWidth = 115;
            gridViewTextBoxColumn45.Multiline = true;
            gridViewTextBoxColumn45.Name = "StatusName";
            gridViewTextBoxColumn45.Width = 115;
            gridViewTextBoxColumn45.WrapText = true;
            gridViewTextBoxColumn46.FieldName = "CountLic1Active";
            gridViewTextBoxColumn46.HeaderText = "К-сть ліцензій";
            gridViewTextBoxColumn46.MaxWidth = 55;
            gridViewTextBoxColumn46.MinWidth = 55;
            gridViewTextBoxColumn46.Multiline = true;
            gridViewTextBoxColumn46.Name = "CountLic1Active";
            gridViewTextBoxColumn46.Width = 55;
            gridViewTextBoxColumn46.WrapText = true;
            gridViewTextBoxColumn47.FieldName = "CountLic2Active";
            gridViewTextBoxColumn47.HeaderText = "К-сть заявок";
            gridViewTextBoxColumn47.MaxWidth = 55;
            gridViewTextBoxColumn47.MinWidth = 55;
            gridViewTextBoxColumn47.Multiline = true;
            gridViewTextBoxColumn47.Name = "CountLic2Active";
            gridViewTextBoxColumn47.Width = 55;
            gridViewTextBoxColumn47.WrapText = true;
            gridViewTextBoxColumn48.FieldName = "CountLic3Active";
            gridViewTextBoxColumn48.HeaderText = "К-сть довідок";
            gridViewTextBoxColumn48.MaxWidth = 55;
            gridViewTextBoxColumn48.MinWidth = 55;
            gridViewTextBoxColumn48.Multiline = true;
            gridViewTextBoxColumn48.Name = "CountLic3Active";
            gridViewTextBoxColumn48.Width = 55;
            gridViewTextBoxColumn48.WrapText = true;
            gridViewTextBoxColumn49.DataType = typeof(double);
            gridViewTextBoxColumn49.FieldName = "UndistribAmount";
            gridViewTextBoxColumn49.HeaderText = "Нерозподілені кошти";
            gridViewTextBoxColumn49.MinWidth = 100;
            gridViewTextBoxColumn49.Multiline = true;
            gridViewTextBoxColumn49.Name = "UndistribAmount";
            gridViewTextBoxColumn49.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn49.Width = 105;
            gridViewTextBoxColumn49.WrapText = true;
            gridViewTextBoxColumn50.FieldName = "UnattachAmount";
            gridViewTextBoxColumn50.HeaderText = "Незакріплені кошти";
            gridViewTextBoxColumn50.MinWidth = 100;
            gridViewTextBoxColumn50.Multiline = true;
            gridViewTextBoxColumn50.Name = "UnattachAmount";
            gridViewTextBoxColumn50.Width = 105;
            gridViewTextBoxColumn50.WrapText = true;
            gridViewTextBoxColumn51.FieldName = "Borg";
            gridViewTextBoxColumn51.HeaderText = "Борг";
            gridViewTextBoxColumn51.MaxWidth = 100;
            gridViewTextBoxColumn51.MinWidth = 100;
            gridViewTextBoxColumn51.Name = "Borg";
            gridViewTextBoxColumn51.Width = 100;
            gridViewTextBoxColumn52.FieldName = "PartnerName";
            gridViewTextBoxColumn52.HeaderText = "Представник";
            gridViewTextBoxColumn52.MinWidth = 80;
            gridViewTextBoxColumn52.Name = "PartnerName";
            gridViewTextBoxColumn52.Width = 96;
            gridViewCommandColumn4.AllowResize = false;
            gridViewCommandColumn4.AllowSort = false;
            gridViewCommandColumn4.DefaultText = "Відкрити";
            gridViewCommandColumn4.FieldName = "btnsView";
            gridViewCommandColumn4.HeaderImage = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn4.HeaderText = "";
            gridViewCommandColumn4.Image = global::IpsViewComponentLibrary.Properties.Resources.viewAct;
            gridViewCommandColumn4.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn4.MaxWidth = 35;
            gridViewCommandColumn4.MinWidth = 35;
            gridViewCommandColumn4.Name = "btnsView";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn4.Width = 35;
            this.gvViewConsumers.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn40,
            gridViewTextBoxColumn41,
            gridViewTextBoxColumn42,
            gridViewTextBoxColumn43,
            gridViewTextBoxColumn44,
            gridViewTextBoxColumn45,
            gridViewTextBoxColumn46,
            gridViewTextBoxColumn47,
            gridViewTextBoxColumn48,
            gridViewTextBoxColumn49,
            gridViewTextBoxColumn50,
            gridViewTextBoxColumn51,
            gridViewTextBoxColumn52,
            gridViewCommandColumn4});
            this.gvViewConsumers.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableFiltering = true;
            this.gvViewConsumers.MasterTemplate.EnableGrouping = false;
            this.gvViewConsumers.MasterTemplate.ShowFilteringRow = false;
            this.gvViewConsumers.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.gvViewConsumers.Name = "gvViewConsumers";
            this.gvViewConsumers.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewConsumers.Size = new System.Drawing.Size(1148, 556);
            this.gvViewConsumers.TabIndex = 6;
            this.gvViewConsumers.ThemeName = "Office2013Light";
            this.gvViewConsumers.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvViewConsumers_CellDoubleClick);
            this.gvViewConsumers.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.gvViewConsumers_CommandCellClick);
            // 
            // btnNewConsumer
            // 
            this.btnNewConsumer.Location = new System.Drawing.Point(488, 3);
            this.btnNewConsumer.Name = "btnNewConsumer";
            this.btnNewConsumer.Size = new System.Drawing.Size(164, 20);
            this.btnNewConsumer.TabIndex = 10;
            this.btnNewConsumer.Text = "Новий користувач";
            this.btnNewConsumer.ThemeName = "Office2013Light";
            this.btnNewConsumer.Click += new System.EventHandler(this.btnNewConsumer_Click);
            // 
            // ctrlSearch
            // 
            this.ctrlSearch.Location = new System.Drawing.Point(3, 3);
            this.ctrlSearch.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ctrlSearch.MinimumSize = new System.Drawing.Size(20, 20);
            this.ctrlSearch.Name = "ctrlSearch";
            this.ctrlSearch.Size = new System.Drawing.Size(479, 20);
            this.ctrlSearch.TabIndex = 11;
            // 
            // GlobalControlConsumerMainGridBR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlSearch);
            this.Controls.Add(this.btnNewConsumer);
            this.Controls.Add(this.gvViewConsumers);
            this.Name = "GlobalControlConsumerMainGridBR";
            this.Size = new System.Drawing.Size(1154, 588);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewConsumers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewConsumer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView gvViewConsumers;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnNewConsumer;
        private Common.SearchTextBoxControl ctrlSearch;
    }
}
