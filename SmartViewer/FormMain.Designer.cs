namespace SmartViewer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabPanelMain = new System.Windows.Forms.TabControl();
            this.tabPageCustomerWorks = new System.Windows.Forms.TabPage();
            this.ucCustomerWorks = new SmartViewer.UcCustomerWorks();
            this.tabPageCustomerAffiliation = new System.Windows.Forms.TabPage();
            this.ucCustomerAffiliation = new SmartViewer.UcCustomerAffiliation();
            this.tabPageSearchIpiCodes = new System.Windows.Forms.TabPage();
            this.ucSearchIpiCodes = new SmartViewer.UcSearchIpiCodes();
            this.ilMainTabs = new System.Windows.Forms.ImageList(this.components);
            this.tabPanelMain.SuspendLayout();
            this.tabPageCustomerWorks.SuspendLayout();
            this.tabPageCustomerAffiliation.SuspendLayout();
            this.tabPageSearchIpiCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanelMain
            // 
            this.tabPanelMain.Controls.Add(this.tabPageCustomerWorks);
            this.tabPanelMain.Controls.Add(this.tabPageCustomerAffiliation);
            this.tabPanelMain.Controls.Add(this.tabPageSearchIpiCodes);
            this.tabPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanelMain.ImageList = this.ilMainTabs;
            this.tabPanelMain.ItemSize = new System.Drawing.Size(94, 45);
            this.tabPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tabPanelMain.Name = "tabPanelMain";
            this.tabPanelMain.SelectedIndex = 0;
            this.tabPanelMain.Size = new System.Drawing.Size(1044, 589);
            this.tabPanelMain.TabIndex = 0;
            this.tabPanelMain.SelectedIndexChanged += new System.EventHandler(this.tabPanelMain_SelectedIndexChanged);
            // 
            // tabPageCustomerWorks
            // 
            this.tabPageCustomerWorks.Controls.Add(this.ucCustomerWorks);
            this.tabPageCustomerWorks.ImageIndex = 0;
            this.tabPageCustomerWorks.Location = new System.Drawing.Point(4, 49);
            this.tabPageCustomerWorks.Name = "tabPageCustomerWorks";
            this.tabPageCustomerWorks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomerWorks.Size = new System.Drawing.Size(1036, 536);
            this.tabPageCustomerWorks.TabIndex = 1;
            this.tabPageCustomerWorks.Text = "Правоволодіння";
            this.tabPageCustomerWorks.UseVisualStyleBackColor = true;
            // 
            // ucCustomerWorks
            // 
            this.ucCustomerWorks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCustomerWorks.Location = new System.Drawing.Point(3, 3);
            this.ucCustomerWorks.Name = "ucCustomerWorks";
            this.ucCustomerWorks.Size = new System.Drawing.Size(1030, 530);
            this.ucCustomerWorks.TabIndex = 0;
            this.ucCustomerWorks.Load += new System.EventHandler(this.ucCustomerWorks_Load);
            // 
            // tabPageCustomerAffiliation
            // 
            this.tabPageCustomerAffiliation.Controls.Add(this.ucCustomerAffiliation);
            this.tabPageCustomerAffiliation.ImageIndex = 1;
            this.tabPageCustomerAffiliation.Location = new System.Drawing.Point(4, 49);
            this.tabPageCustomerAffiliation.Name = "tabPageCustomerAffiliation";
            this.tabPageCustomerAffiliation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomerAffiliation.Size = new System.Drawing.Size(1036, 536);
            this.tabPageCustomerAffiliation.TabIndex = 0;
            this.tabPageCustomerAffiliation.Text = "Афілійованість правовласників";
            this.tabPageCustomerAffiliation.UseVisualStyleBackColor = true;
            // 
            // ucCustomerAffiliation
            // 
            this.ucCustomerAffiliation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCustomerAffiliation.Location = new System.Drawing.Point(3, 3);
            this.ucCustomerAffiliation.Name = "ucCustomerAffiliation";
            this.ucCustomerAffiliation.Size = new System.Drawing.Size(1030, 530);
            this.ucCustomerAffiliation.TabIndex = 0;
            // 
            // tabPageSearchIpiCodes
            // 
            this.tabPageSearchIpiCodes.Controls.Add(this.ucSearchIpiCodes);
            this.tabPageSearchIpiCodes.ImageIndex = 1;
            this.tabPageSearchIpiCodes.Location = new System.Drawing.Point(4, 49);
            this.tabPageSearchIpiCodes.Name = "tabPageSearchIpiCodes";
            this.tabPageSearchIpiCodes.Size = new System.Drawing.Size(1036, 536);
            this.tabPageSearchIpiCodes.TabIndex = 2;
            this.tabPageSearchIpiCodes.Text = "Пошук кодів в IPI";
            this.tabPageSearchIpiCodes.UseVisualStyleBackColor = true;
            // 
            // ucSearchIpiCodes
            // 
            this.ucSearchIpiCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSearchIpiCodes.Location = new System.Drawing.Point(0, 0);
            this.ucSearchIpiCodes.Name = "ucSearchIpiCodes";
            this.ucSearchIpiCodes.Size = new System.Drawing.Size(1036, 536);
            this.ucSearchIpiCodes.TabIndex = 0;
            // 
            // ilMainTabs
            // 
            this.ilMainTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMainTabs.ImageStream")));
            this.ilMainTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMainTabs.Images.SetKeyName(0, "icons8-music-library-30.png");
            this.ilMainTabs.Images.SetKeyName(1, "icons8-users-30.png");
            this.ilMainTabs.Images.SetKeyName(2, "icons8-history-30.png");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 589);
            this.Controls.Add(this.tabPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "SMART GTI";
            this.tabPanelMain.ResumeLayout(false);
            this.tabPageCustomerWorks.ResumeLayout(false);
            this.tabPageCustomerAffiliation.ResumeLayout(false);
            this.tabPageSearchIpiCodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPanelMain;
        private System.Windows.Forms.TabPage tabPageCustomerAffiliation;
        private System.Windows.Forms.TabPage tabPageCustomerWorks;
        private UcCustomerWorks ucCustomerWorks;
        private System.Windows.Forms.ImageList ilMainTabs;
        private UcCustomerAffiliation ucCustomerAffiliation;
        private System.Windows.Forms.TabPage tabPageSearchIpiCodes;
        private UcSearchIpiCodes ucSearchIpiCodes;
    }
}