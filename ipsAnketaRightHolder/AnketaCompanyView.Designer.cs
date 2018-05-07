namespace ipsAnketaRightHolder
{
    partial class AnketaCompanyView
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.tbName = new Telerik.WinControls.UI.RadTextBox();
            this.tbShortName = new Telerik.WinControls.UI.RadTextBox();
            this.ddl = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.ipsAddressControl1 = new IpsViewComponentLibrary.IpsAddressControl();
            this.iAnketaCompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaCompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(79, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Назва клієнту:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 36);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(83, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Коротка назва:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 60);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(97, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Сфера діяльності:";
            // 
            // tbName
            // 
            this.tbName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaCompanyBindingSource, "Name", true));
            this.tbName.Location = new System.Drawing.Point(129, 10);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(551, 20);
            this.tbName.TabIndex = 3;
            // 
            // tbShortName
            // 
            this.tbShortName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaCompanyBindingSource, "ShortName", true));
            this.tbShortName.Location = new System.Drawing.Point(129, 34);
            this.tbShortName.Name = "tbShortName";
            this.tbShortName.Size = new System.Drawing.Size(551, 20);
            this.tbShortName.TabIndex = 4;
            // 
            // ddl
            // 
            this.ddl.Location = new System.Drawing.Point(129, 58);
            this.ddl.Name = "ddl";
            this.ddl.Size = new System.Drawing.Size(551, 20);
            this.ddl.TabIndex = 5;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(12, 99);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(101, 18);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Юридична адреса";
            // 
            // ipsAddressControl1
            // 
            this.ipsAddressControl1.Location = new System.Drawing.Point(129, 117);
            this.ipsAddressControl1.Name = "ipsAddressControl1";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radDropDownListCity.AutoSize = false;
            this.ipsAddressControl1.radDropDownListCity.Location = new System.Drawing.Point(190, 0);
            this.ipsAddressControl1.radDropDownListCity.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radDropDownListCity.Name = "radDropDownList2";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCity.RootElement.ControlBounds = new System.Drawing.Rectangle(206, 0, 186, 20);
            this.ipsAddressControl1.radDropDownListCity.Size = new System.Drawing.Size(170, 20);
            this.ipsAddressControl1.radDropDownListCity.TabIndex = 7;
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radDropDownListCountry.AutoSize = false;
            this.ipsAddressControl1.radDropDownListCountry.Location = new System.Drawing.Point(0, 0);
            this.ipsAddressControl1.radDropDownListCountry.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radDropDownListCountry.Name = "radDropDownList1";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCountry.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 186, 20);
            this.ipsAddressControl1.radDropDownListCountry.Size = new System.Drawing.Size(170, 20);
            this.ipsAddressControl1.radDropDownListCountry.TabIndex = 4;
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radDropDownListRegion.AutoSize = false;
            this.ipsAddressControl1.radDropDownListRegion.Location = new System.Drawing.Point(380, 0);
            this.ipsAddressControl1.radDropDownListRegion.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radDropDownListRegion.Name = "radDropDownList3";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListRegion.RootElement.ControlBounds = new System.Drawing.Rectangle(412, 0, 188, 20);
            this.ipsAddressControl1.radDropDownListRegion.Size = new System.Drawing.Size(171, 20);
            this.ipsAddressControl1.radDropDownListRegion.TabIndex = 8;
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radTextBoxAddress.AutoSize = false;
            this.ipsAddressControl1.radTextBoxAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iAnketaCompanyBindingSource, "JaAddress", true));
            this.ipsAddressControl1.radTextBoxAddress.Location = new System.Drawing.Point(0, 25);
            this.ipsAddressControl1.radTextBoxAddress.Margin = new System.Windows.Forms.Padding(0);
            this.ipsAddressControl1.radTextBoxAddress.Name = "radTextBox1";
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxAddress.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 25, 600, 20);
            this.ipsAddressControl1.radTextBoxAddress.Size = new System.Drawing.Size(551, 20);
            this.ipsAddressControl1.radTextBoxAddress.TabIndex = 10;
            this.ipsAddressControl1.Size = new System.Drawing.Size(551, 45);
            this.ipsAddressControl1.TabIndex = 6;
            // 
            // iAnketaCompanyBindingSource
            // 
            this.iAnketaCompanyBindingSource.DataSource = typeof(ipsFormsDesign.Interfaces.IAnketaCompany);
            // 
            // AnketaCompanyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 470);
            this.Controls.Add(this.ipsAddressControl1);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.ddl);
            this.Controls.Add(this.tbShortName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "AnketaCompanyView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Анкета (юридична особа)";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iAnketaCompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox tbName;
        private Telerik.WinControls.UI.RadTextBox tbShortName;
        private Telerik.WinControls.UI.RadDropDownList ddl;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private IpsViewComponentLibrary.IpsAddressControl ipsAddressControl1;
        private System.Windows.Forms.BindingSource iAnketaCompanyBindingSource;
    }
}