using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    partial class DistributionForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.office2007SilverTheme = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.gvDistributionPayment = new Telerik.WinControls.UI.RadGridView();
            this.btnCreateNewPeriod = new Telerik.WinControls.UI.RadButton();
            this.btnSaveDistrib = new Telerik.WinControls.UI.RadButton();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtPayNumber = new Telerik.WinControls.UI.RadTextBox();
            this.txtPayDate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtPayAmount = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtPayDistribution = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtPayGoalInvoice = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.radSeparator2 = new Telerik.WinControls.UI.RadSeparator();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveDistrib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayGoalInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).BeginInit();
            this.radSeparator2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvDistributionPayment
            // 
            this.gvDistributionPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDistributionPayment.AutoScroll = true;
            this.gvDistributionPayment.Location = new System.Drawing.Point(12, 137);
            // 
            // 
            // 
            this.gvDistributionPayment.MasterTemplate.AllowAddNewRow = false;
            this.gvDistributionPayment.MasterTemplate.AllowColumnReorder = false;
            this.gvDistributionPayment.MasterTemplate.AllowDeleteRow = false;
            this.gvDistributionPayment.MasterTemplate.AllowDragToGroup = false;
            this.gvDistributionPayment.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.FieldName = "Period";
            gridViewTextBoxColumn4.HeaderText = "Період";
            gridViewTextBoxColumn4.Name = "Period";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 176;
            gridViewTextBoxColumn5.FieldName = "StateOfPeriod";
            gridViewTextBoxColumn5.HeaderText = "Стан періоду";
            gridViewTextBoxColumn5.Name = "StateOfPeriod";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 147;
            gridViewDecimalColumn4.FieldName = "AmountNeed";
            gridViewDecimalColumn4.HeaderText = "Вимога";
            gridViewDecimalColumn4.Name = "AmountNeed";
            gridViewDecimalColumn4.ReadOnly = true;
            gridViewDecimalColumn4.Width = 169;
            gridViewDecimalColumn5.FieldName = "AmountBound";
            gridViewDecimalColumn5.HeaderText = "Прив\'язано";
            gridViewDecimalColumn5.Name = "AmountBound";
            gridViewDecimalColumn5.ReadOnly = true;
            gridViewDecimalColumn5.Width = 169;
            gridViewDecimalColumn6.FieldName = "Arrears";
            gridViewDecimalColumn6.HeaderText = "Борг";
            gridViewDecimalColumn6.Name = "Arrears";
            gridViewDecimalColumn6.ReadOnly = true;
            gridViewDecimalColumn6.Width = 146;
            gridViewTextBoxColumn6.DataType = typeof(decimal);
            gridViewTextBoxColumn6.FieldName = "DistribAmount";
            gridViewTextBoxColumn6.HeaderText = "Сума прив\'язки";
            gridViewTextBoxColumn6.Name = "DistribAmount";
            gridViewTextBoxColumn6.Width = 139;
            this.gvDistributionPayment.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewDecimalColumn4,
            gridViewDecimalColumn5,
            gridViewDecimalColumn6,
            gridViewTextBoxColumn6});
            this.gvDistributionPayment.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvDistributionPayment.Name = "gvDistributionPayment";
            this.gvDistributionPayment.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.gvDistributionPayment.ShowGroupPanel = false;
            this.gvDistributionPayment.Size = new System.Drawing.Size(962, 196);
            this.gvDistributionPayment.TabIndex = 10;
            this.gvDistributionPayment.ThemeName = "Office2007Silver";
            // 
            // btnCreateNewPeriod
            // 
            this.btnCreateNewPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateNewPeriod.Location = new System.Drawing.Point(12, 339);
            this.btnCreateNewPeriod.Name = "btnCreateNewPeriod";
            this.btnCreateNewPeriod.Size = new System.Drawing.Size(151, 24);
            this.btnCreateNewPeriod.TabIndex = 11;
            this.btnCreateNewPeriod.Text = "Створити новий період";
            this.btnCreateNewPeriod.ThemeName = "Office2007Silver";
            this.btnCreateNewPeriod.Click += new System.EventHandler(this.btnCreateNewPeriod_Click);
            // 
            // btnSaveDistrib
            // 
            this.btnSaveDistrib.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveDistrib.Location = new System.Drawing.Point(169, 339);
            this.btnSaveDistrib.Name = "btnSaveDistrib";
            this.btnSaveDistrib.Size = new System.Drawing.Size(110, 24);
            this.btnSaveDistrib.TabIndex = 12;
            this.btnSaveDistrib.Text = "Зберегти";
            this.btnSaveDistrib.ThemeName = "Office2007Silver";
            this.btnSaveDistrib.Click += new System.EventHandler(this.btnSaveDistrib_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(864, 339);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 24);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Скасувати";
            this.btnExit.ThemeName = "Office2007Silver";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(87, 18);
            this.radLabel1.TabIndex = 14;
            this.radLabel1.Text = "Номер платежу";
            // 
            // txtPayNumber
            // 
            this.txtPayNumber.Location = new System.Drawing.Point(106, 12);
            this.txtPayNumber.Name = "txtPayNumber";
            this.txtPayNumber.ReadOnly = true;
            this.txtPayNumber.Size = new System.Drawing.Size(224, 20);
            this.txtPayNumber.TabIndex = 15;
            this.txtPayNumber.ThemeName = "Office2007Silver";
            // 
            // txtPayDate
            // 
            this.txtPayDate.Location = new System.Drawing.Point(418, 12);
            this.txtPayDate.Name = "txtPayDate";
            this.txtPayDate.ReadOnly = true;
            this.txtPayDate.Size = new System.Drawing.Size(102, 20);
            this.txtPayDate.TabIndex = 17;
            this.txtPayDate.ThemeName = "Office2007Silver";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(336, 13);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 18);
            this.radLabel2.TabIndex = 16;
            this.radLabel2.Text = "Дата платежу";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(610, 12);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.ReadOnly = true;
            this.txtPayAmount.Size = new System.Drawing.Size(122, 20);
            this.txtPayAmount.TabIndex = 19;
            this.txtPayAmount.ThemeName = "Office2007Silver";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(526, 13);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(78, 18);
            this.radLabel3.TabIndex = 18;
            this.radLabel3.Text = "Сума платежу";
            // 
            // txtPayDistribution
            // 
            this.txtPayDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayDistribution.Location = new System.Drawing.Point(852, 12);
            this.txtPayDistribution.Name = "txtPayDistribution";
            this.txtPayDistribution.ReadOnly = true;
            this.txtPayDistribution.Size = new System.Drawing.Size(122, 20);
            this.txtPayDistribution.TabIndex = 21;
            this.txtPayDistribution.ThemeName = "Office2007Silver";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(738, 13);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(108, 18);
            this.radLabel4.TabIndex = 20;
            this.radLabel4.Text = "Сума для прив\'язки";
            // 
            // txtPayGoalInvoice
            // 
            this.txtPayGoalInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayGoalInvoice.Location = new System.Drawing.Point(141, 36);
            this.txtPayGoalInvoice.Name = "txtPayGoalInvoice";
            this.txtPayGoalInvoice.ReadOnly = true;
            this.txtPayGoalInvoice.Size = new System.Drawing.Size(833, 20);
            this.txtPayGoalInvoice.TabIndex = 23;
            this.txtPayGoalInvoice.ThemeName = "Office2007Silver";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(13, 37);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(122, 18);
            this.radLabel5.TabIndex = 22;
            this.radLabel5.Text = "Призначення платежу";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(112, 77);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.ReadOnly = true;
            this.radTextBox1.Size = new System.Drawing.Size(228, 20);
            this.radTextBox1.TabIndex = 25;
            this.radTextBox1.ThemeName = "Office2007Silver";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(13, 78);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(93, 18);
            this.radLabel6.TabIndex = 24;
            this.radLabel6.Text = "Номер договору";
            // 
            // radTextBox2
            // 
            this.radTextBox2.Location = new System.Drawing.Point(478, 77);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.ReadOnly = true;
            this.radTextBox2.Size = new System.Drawing.Size(102, 20);
            this.radTextBox2.TabIndex = 27;
            this.radTextBox2.ThemeName = "Office2007Silver";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(346, 78);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(126, 18);
            this.radLabel7.TabIndex = 26;
            this.radLabel7.Text = "Дата початку договору";
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(13, 62);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(961, 10);
            this.radSeparator1.TabIndex = 28;
            this.radSeparator1.ThemeName = "Office2007Silver";
            // 
            // radSeparator2
            // 
            this.radSeparator2.Controls.Add(this.radLabel8);
            this.radSeparator2.Location = new System.Drawing.Point(13, 103);
            this.radSeparator2.Name = "radSeparator2";
            this.radSeparator2.Size = new System.Drawing.Size(961, 28);
            this.radSeparator2.TabIndex = 29;
            this.radSeparator2.ThemeName = "Office2007Silver";
            // 
            // radLabel8
            // 
            this.radLabel8.AutoSize = false;
            this.radLabel8.Location = new System.Drawing.Point(392, 0);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(146, 28);
            this.radLabel8.TabIndex = 0;
            this.radLabel8.Text = "Періоди та суми прив\'язки";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DistributionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 375);
            this.Controls.Add(this.radSeparator2);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.radTextBox2);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.txtPayGoalInvoice);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txtPayDistribution);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtPayAmount);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtPayDate);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtPayNumber);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveDistrib);
            this.Controls.Add(this.btnCreateNewPeriod);
            this.Controls.Add(this.gvDistributionPayment);
            this.MaximumSize = new System.Drawing.Size(994, 407);
            this.MinimumSize = new System.Drawing.Size(994, 407);
            this.Name = "DistributionForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(994, 407);
            this.Text = "Прив\'язка суми платежу до Розрахункових періодів";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistributionPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateNewPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveDistrib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayDistribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayGoalInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator2)).EndInit();
            this.radSeparator2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme;
        private Telerik.WinControls.UI.RadGridView gvDistributionPayment;
        private Telerik.WinControls.UI.RadButton btnCreateNewPeriod;
        private Telerik.WinControls.UI.RadButton btnSaveDistrib;
        private RadButton btnExit;
        private RadLabel radLabel1;
        private RadTextBox txtPayNumber;
        private RadTextBox radTextBox1;
        private RadTextBox txtPayDate;
        private RadTextBox radTextBox2;
        private RadLabel radLabel2;
        private RadTextBox txtPayAmount;
        private RadLabel radLabel3;
        private RadTextBox txtPayDistribution;
        private RadLabel radLabel4;
        private RadTextBox txtPayGoalInvoice;
        private RadLabel radLabel5;
        private RadLabel radLabel6;
        private RadLabel radLabel7;
        private RadSeparator radSeparator1;
        private RadSeparator radSeparator2;
        private RadLabel radLabel8;
    }
}
