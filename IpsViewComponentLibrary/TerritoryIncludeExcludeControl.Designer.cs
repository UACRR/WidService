namespace IpsViewComponentLibrary
{
    partial class TerritoryIncludeExcludeControl
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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.countryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.btnRemove = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.lblIncludeExclude = new Telerik.WinControls.UI.RadLabel();
            this.checkAroundWorld = new Telerik.WinControls.UI.RadCheckBox();
            this.rightHolderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvCountries = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIncludeExclude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAroundWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightHolderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountries.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // countryBindingSource
            // 
            this.countryBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.ICountry);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(183, 410);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(169, 24);
            this.btnRemove.TabIndex = 53;
            this.btnRemove.Text = "Видалити";
            this.btnRemove.ThemeName = "Office2013Light";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(3, 410);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(169, 24);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "Додати";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblIncludeExclude
            // 
            this.lblIncludeExclude.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIncludeExclude.Location = new System.Drawing.Point(3, 31);
            this.lblIncludeExclude.Name = "lblIncludeExclude";
            this.lblIncludeExclude.Size = new System.Drawing.Size(246, 25);
            this.lblIncludeExclude.TabIndex = 51;
            this.lblIncludeExclude.Text = "Розповсюджується на території";
            // 
            // checkAroundWorld
            // 
            this.checkAroundWorld.DataBindings.Add(new System.Windows.Forms.Binding("IsChecked", this.rightHolderBindingSource, "AroundWord", true));
            this.checkAroundWorld.Location = new System.Drawing.Point(3, 3);
            this.checkAroundWorld.Name = "checkAroundWorld";
            this.checkAroundWorld.Size = new System.Drawing.Size(73, 19);
            this.checkAroundWorld.TabIndex = 50;
            this.checkAroundWorld.Text = "Весь світ";
            this.checkAroundWorld.ThemeName = "Office2013Light";
            this.checkAroundWorld.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.checkAroundWorld_ToggleStateChanged);
            // 
            // rightHolderBindingSource
            // 
            this.rightHolderBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IRightHolder);
            // 
            // gvCountries
            // 
            this.gvCountries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvCountries.Location = new System.Drawing.Point(3, 67);
            // 
            // 
            // 
            this.gvCountries.MasterTemplate.AllowAddNewRow = false;
            this.gvCountries.MasterTemplate.AutoGenerateColumns = false;
            this.gvCountries.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewComboBoxColumn1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            gridViewComboBoxColumn1.DataSource = this.countryBindingSource;
            gridViewComboBoxColumn1.DisplayMember = "CountryName";
            gridViewComboBoxColumn1.FieldName = "CountryCode";
            gridViewComboBoxColumn1.HeaderText = "Країна";
            gridViewComboBoxColumn1.Name = "CountryCode";
            gridViewComboBoxColumn1.ValueMember = "CountryCode";
            gridViewComboBoxColumn1.Width = 348;
            this.gvCountries.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewComboBoxColumn1});
            this.gvCountries.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvCountries.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvCountries.Name = "gvCountries";
            this.gvCountries.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvCountries.ShowGroupPanel = false;
            this.gvCountries.Size = new System.Drawing.Size(349, 337);
            this.gvCountries.TabIndex = 49;
            this.gvCountries.ThemeName = "Office2013Light";
            // 
            // TerritoryIncludeExcludeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.checkAroundWorld);
            this.Controls.Add(this.lblIncludeExclude);
            this.Controls.Add(this.gvCountries);
            this.Name = "TerritoryIncludeExcludeControl";
            this.Size = new System.Drawing.Size(356, 437);
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIncludeExclude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAroundWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightHolderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountries.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCountries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadButton btnRemove;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadLabel lblIncludeExclude;
        private Telerik.WinControls.UI.RadCheckBox checkAroundWorld;
        private Telerik.WinControls.UI.RadGridView gvCountries;
        private System.Windows.Forms.BindingSource rightHolderBindingSource;
        private System.Windows.Forms.BindingSource countryBindingSource;
    }
}
