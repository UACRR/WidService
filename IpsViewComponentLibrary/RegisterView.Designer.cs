namespace IpsViewComponentLibrary
{
    partial class RegisterView
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
            this.ddlStatus = new Telerik.WinControls.UI.RadDropDownList();
            this.registerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtCreateDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtNumber = new Telerik.WinControls.UI.RadTextBox();
            this.ctrlRegisterItemList = new IpsViewComponentLibrary.RegisterItemListControl();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 1);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Номер";
            this.radLabel1.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(160, 1);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(23, 19);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "від";
            this.radLabel2.ThemeName = "Office2013Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(337, 2);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(42, 19);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Статус";
            this.radLabel3.ThemeName = "Office2013Light";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.registerBindingSource, "RgStatus", true));
            this.ddlStatus.Location = new System.Drawing.Point(385, 2);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.ReadOnly = true;
            this.ddlStatus.Size = new System.Drawing.Size(158, 21);
            this.ddlStatus.TabIndex = 3;
            this.ddlStatus.ThemeName = "Office2013Light";
            // 
            // registerBindingSource
            // 
            this.registerBindingSource.DataSource = typeof(ipsFormsDesign.Model.Register);
            // 
            // dtCreateDate
            // 
            this.dtCreateDate.Culture = new System.Globalization.CultureInfo("uk-UA");
            this.dtCreateDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.registerBindingSource, "CreateDate", true));
            this.dtCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCreateDate.Location = new System.Drawing.Point(189, 2);
            this.dtCreateDate.Name = "dtCreateDate";
            this.dtCreateDate.ReadOnly = true;
            this.dtCreateDate.Size = new System.Drawing.Size(103, 21);
            this.dtCreateDate.TabIndex = 4;
            this.dtCreateDate.TabStop = false;
            this.dtCreateDate.Text = "13.07.2018";
            this.dtCreateDate.ThemeName = "Office2013Light";
            this.dtCreateDate.Value = new System.DateTime(2018, 7, 13, 11, 0, 20, 75);
            // 
            // txtNumber
            // 
            this.txtNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registerBindingSource, "RegId", true));
            this.txtNumber.Location = new System.Drawing.Point(54, 2);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(100, 21);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.ThemeName = "Office2013Light";
            // 
            // ctrlRegisterItemList
            // 
            this.ctrlRegisterItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlRegisterItemList.Location = new System.Drawing.Point(0, 41);
            this.ctrlRegisterItemList.Name = "ctrlRegisterItemList";
            this.ctrlRegisterItemList.Size = new System.Drawing.Size(859, 346);
            this.ctrlRegisterItemList.TabIndex = 6;
            // 
            // RegisterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 433);
            this.Controls.Add(this.ctrlRegisterItemList);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.dtCreateDate);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "RegisterView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Відомість";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList ddlStatus;
        private Telerik.WinControls.UI.RadDateTimePicker dtCreateDate;
        private Telerik.WinControls.UI.RadTextBox txtNumber;
        private System.Windows.Forms.BindingSource registerBindingSource;
        private RegisterItemListControl ctrlRegisterItemList;
    }
}
