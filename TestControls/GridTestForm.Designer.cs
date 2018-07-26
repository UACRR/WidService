namespace TestControls
{
    partial class GridTestForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.collapsiblePanel = new Telerik.WinControls.UI.RadCollapsiblePanel();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.pvSpectacle = new Telerik.WinControls.UI.RadPageViewPage();
            this.gvViewSpectacles = new Telerik.WinControls.UI.RadGridView();
            this.pvMusicalDesign = new Telerik.WinControls.UI.RadPageViewPage();
            this.licenseAgreementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.licenseAgrParamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.collapsiblePanel)).BeginInit();
            this.collapsiblePanel.PanelContainer.SuspendLayout();
            this.collapsiblePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.pvSpectacle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewSpectacles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewSpectacles.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgrParamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // collapsiblePanel
            // 
            this.collapsiblePanel.AnimationType = Telerik.WinControls.UI.CollapsiblePanelAnimationType.Slide;
            this.collapsiblePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsiblePanel.HeaderText = "Інформація по розрахунковому листу";
            this.collapsiblePanel.HorizontalHeaderAlignment = Telerik.WinControls.UI.RadHorizontalAlignment.Right;
            this.collapsiblePanel.Location = new System.Drawing.Point(0, 201);
            this.collapsiblePanel.Name = "collapsiblePanel";
            this.collapsiblePanel.OwnerBoundsCache = new System.Drawing.Rectangle(0, 214, 1197, 295);
            // 
            // collapsiblePanel.PanelContainer
            // 
            this.collapsiblePanel.PanelContainer.Controls.Add(this.radPageView1);
            this.collapsiblePanel.PanelContainer.Size = new System.Drawing.Size(940, 267);
            this.collapsiblePanel.Size = new System.Drawing.Size(942, 295);
            this.collapsiblePanel.TabIndex = 13;
            this.collapsiblePanel.ThemeName = "Office2013Light";
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.pvSpectacle);
            this.radPageView1.Controls.Add(this.pvMusicalDesign);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.pvSpectacle;
            this.radPageView1.Size = new System.Drawing.Size(940, 267);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.ThemeName = "Office2013Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pvSpectacle
            // 
            this.pvSpectacle.Controls.Add(this.gvViewSpectacles);
            this.pvSpectacle.ItemSize = new System.Drawing.SizeF(58F, 25F);
            this.pvSpectacle.Location = new System.Drawing.Point(5, 29);
            this.pvSpectacle.Name = "pvSpectacle";
            this.pvSpectacle.Size = new System.Drawing.Size(930, 233);
            this.pvSpectacle.Text = "Вистави";
            // 
            // gvViewSpectacles
            // 
            this.gvViewSpectacles.AutoScroll = true;
            this.gvViewSpectacles.AutoSizeRows = true;
            this.gvViewSpectacles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvViewSpectacles.EnableCustomFiltering = true;
            this.gvViewSpectacles.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvViewSpectacles.MasterTemplate.AllowAddNewRow = false;
            this.gvViewSpectacles.MasterTemplate.AllowDeleteRow = false;
            this.gvViewSpectacles.MasterTemplate.AllowDragToGroup = false;
            this.gvViewSpectacles.MasterTemplate.AllowEditRow = false;
            this.gvViewSpectacles.MasterTemplate.AutoGenerateColumns = false;
            this.gvViewSpectacles.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gvViewSpectacles.MasterTemplate.EnableCustomFiltering = true;
            this.gvViewSpectacles.MasterTemplate.EnableFiltering = true;
            this.gvViewSpectacles.MasterTemplate.EnableGrouping = false;
            this.gvViewSpectacles.MasterTemplate.ShowFilteringRow = false;
            this.gvViewSpectacles.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvViewSpectacles.Name = "gvViewSpectacles";
            this.gvViewSpectacles.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvViewSpectacles.Size = new System.Drawing.Size(930, 233);
            this.gvViewSpectacles.TabIndex = 11;
            this.gvViewSpectacles.ThemeName = "Office2013Light";
            // 
            // pvMusicalDesign
            // 
            this.pvMusicalDesign.ItemSize = new System.Drawing.SizeF(139F, 25F);
            this.pvMusicalDesign.Location = new System.Drawing.Point(5, 31);
            this.pvMusicalDesign.Name = "pvMusicalDesign";
            this.pvMusicalDesign.Size = new System.Drawing.Size(975, 136);
            this.pvMusicalDesign.Text = "Музичне оформлення";
            // 
            // licenseAgreementBindingSource
            // 
            this.licenseAgreementBindingSource.DataSource = typeof(ipsFormsDesign.Model.LicenseAgreement);
            // 
            // licenseAgrParamBindingSource
            // 
            this.licenseAgrParamBindingSource.DataSource = typeof(ipsFormsDesign.Model.LicenseAgrParam);
            // 
            // GridTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 496);
            this.Controls.Add(this.collapsiblePanel);
            this.Name = "GridTestForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ThemeName = "Office2013Light";
            this.collapsiblePanel.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsiblePanel)).EndInit();
            this.collapsiblePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.pvSpectacle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvViewSpectacles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewSpectacles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgreementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.licenseAgrParamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.BindingSource licenseAgreementBindingSource;
        private System.Windows.Forms.BindingSource licenseAgrParamBindingSource;
        private Telerik.WinControls.UI.RadCollapsiblePanel collapsiblePanel;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage pvSpectacle;
        private Telerik.WinControls.UI.RadGridView gvViewSpectacles;
        private Telerik.WinControls.UI.RadPageViewPage pvMusicalDesign;
    }
}
