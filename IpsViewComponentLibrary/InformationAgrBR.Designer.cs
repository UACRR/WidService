using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    partial class InformationAgrBR
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
            this.components = new System.ComponentModel.Container();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtNotation = new Telerik.WinControls.UI.RadTextBoxControl();
            this.btnSaveComment = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.bsAgreementView = new System.Windows.Forms.BindingSource(this.components);
            this.singleShowInformationControl3 = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.singleShowInformationControl4 = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.singleShowInformationControl1 = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.singleShowInformationControl2 = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cAvanceRemainder = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cAvanceOfAgr = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cIsProlong = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cAmount = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cValuta = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cDate = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cAgrNumber = new IpsViewComponentLibrary.SingleShowInformationControl();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementView)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.cAmount);
            this.radPanel1.Controls.Add(this.cValuta);
            this.radPanel1.Location = new System.Drawing.Point(4, 47);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(205, 76);
            this.radPanel1.TabIndex = 5;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(16, 129);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(54, 18);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "Примітка";
            // 
            // txtNotation
            // 
            this.txtNotation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotation.AutoScroll = true;
            this.txtNotation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAgreementView, "Comment", true));
            this.txtNotation.Location = new System.Drawing.Point(76, 129);
            this.txtNotation.Multiline = true;
            this.txtNotation.Name = "txtNotation";
            this.txtNotation.Size = new System.Drawing.Size(775, 65);
            this.txtNotation.TabIndex = 9;
            this.txtNotation.ThemeName = "Office2013Light";
            // 
            // btnSaveComment
            // 
            this.btnSaveComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveComment.Location = new System.Drawing.Point(3, 160);
            this.btnSaveComment.Name = "btnSaveComment";
            this.btnSaveComment.Size = new System.Drawing.Size(66, 34);
            this.btnSaveComment.TabIndex = 10;
            this.btnSaveComment.Text = "Зберегти примітку";
            this.btnSaveComment.TextWrap = true;
            this.btnSaveComment.ThemeName = "Office2013Light";
            this.btnSaveComment.Click += new System.EventHandler(this.btnSaveComment_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(16, 38);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(109, 18);
            this.radLabel2.TabIndex = 10;
            this.radLabel2.Text = "Паушальний платіж";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(227, 38);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(37, 18);
            this.radLabel3.TabIndex = 12;
            this.radLabel3.Text = "Аванс";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.cAvanceRemainder);
            this.radPanel2.Controls.Add(this.cAvanceOfAgr);
            this.radPanel2.Location = new System.Drawing.Point(215, 47);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(205, 76);
            this.radPanel2.TabIndex = 11;
            this.radPanel2.ThemeName = "Office2013Light";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(438, 38);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(132, 18);
            this.radLabel4.TabIndex = 14;
            this.radLabel4.Text = "Інформація про виставу";
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.singleShowInformationControl1);
            this.radPanel3.Controls.Add(this.singleShowInformationControl2);
            this.radPanel3.Location = new System.Drawing.Point(426, 47);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(205, 76);
            this.radPanel3.TabIndex = 13;
            this.radPanel3.ThemeName = "Office2013Light";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(649, 38);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(124, 18);
            this.radLabel5.TabIndex = 16;
            this.radLabel5.Text = "Додаткова інформація";
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.singleShowInformationControl3);
            this.radPanel4.Controls.Add(this.singleShowInformationControl4);
            this.radPanel4.Location = new System.Drawing.Point(637, 47);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(205, 76);
            this.radPanel4.TabIndex = 15;
            this.radPanel4.ThemeName = "Office2013Light";
            // 
            // bsAgreementView
            // 
            this.bsAgreementView.DataSource = typeof(ipsFormsDesign.Interfaces.VbrLicense);
            // 
            // singleShowInformationControl3
            // 
            this.singleShowInformationControl3.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.singleShowInformationControl3.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.singleShowInformationControl3.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "TicketPriceNC", true));
            this.singleShowInformationControl3.Location = new System.Drawing.Point(3, 42);
            this.singleShowInformationControl3.MaximumSize = new System.Drawing.Size(1000, 28);
            this.singleShowInformationControl3.MinimumSize = new System.Drawing.Size(150, 25);
            this.singleShowInformationControl3.Name = "singleShowInformationControl3";
            this.singleShowInformationControl3.Size = new System.Drawing.Size(199, 28);
            this.singleShowInformationControl3.SplitterRatio = 140;
            this.singleShowInformationControl3.StringFormat = "";
            this.singleShowInformationControl3.TabIndex = 9;
            this.singleShowInformationControl3.TextTitle = "Орієнтовна ціна квитка";
            this.singleShowInformationControl3.TextValue = "";
            this.singleShowInformationControl3.ValueDataMemger = "";
            this.singleShowInformationControl3.ValueDataSource = null;
            // 
            // singleShowInformationControl4
            // 
            this.singleShowInformationControl4.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.singleShowInformationControl4.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.singleShowInformationControl4.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "FillingRate", true));
            this.singleShowInformationControl4.Location = new System.Drawing.Point(3, 15);
            this.singleShowInformationControl4.MaximumSize = new System.Drawing.Size(1000, 28);
            this.singleShowInformationControl4.MinimumSize = new System.Drawing.Size(150, 25);
            this.singleShowInformationControl4.Name = "singleShowInformationControl4";
            this.singleShowInformationControl4.Size = new System.Drawing.Size(199, 28);
            this.singleShowInformationControl4.SplitterRatio = 150;
            this.singleShowInformationControl4.StringFormat = "";
            this.singleShowInformationControl4.TabIndex = 9;
            this.singleShowInformationControl4.TextTitle = "Заповнюваність залу (%)";
            this.singleShowInformationControl4.TextValue = "";
            this.singleShowInformationControl4.ValueDataMemger = "";
            this.singleShowInformationControl4.ValueDataSource = null;
            // 
            // singleShowInformationControl1
            // 
            this.singleShowInformationControl1.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.singleShowInformationControl1.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.singleShowInformationControl1.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "PerformNumb", true));
            this.singleShowInformationControl1.Location = new System.Drawing.Point(3, 42);
            this.singleShowInformationControl1.MaximumSize = new System.Drawing.Size(1000, 28);
            this.singleShowInformationControl1.MinimumSize = new System.Drawing.Size(150, 25);
            this.singleShowInformationControl1.Name = "singleShowInformationControl1";
            this.singleShowInformationControl1.Size = new System.Drawing.Size(199, 28);
            this.singleShowInformationControl1.SplitterRatio = 122;
            this.singleShowInformationControl1.StringFormat = "";
            this.singleShowInformationControl1.TabIndex = 9;
            this.singleShowInformationControl1.TextTitle = "Кількість вистав";
            this.singleShowInformationControl1.TextValue = "";
            this.singleShowInformationControl1.ValueDataMemger = "";
            this.singleShowInformationControl1.ValueDataSource = null;
            // 
            // singleShowInformationControl2
            // 
            this.singleShowInformationControl2.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.singleShowInformationControl2.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.singleShowInformationControl2.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "DatePremiere", true));
            this.singleShowInformationControl2.Location = new System.Drawing.Point(3, 15);
            this.singleShowInformationControl2.MaximumSize = new System.Drawing.Size(1000, 28);
            this.singleShowInformationControl2.MinimumSize = new System.Drawing.Size(150, 25);
            this.singleShowInformationControl2.Name = "singleShowInformationControl2";
            this.singleShowInformationControl2.Size = new System.Drawing.Size(199, 28);
            this.singleShowInformationControl2.SplitterRatio = 122;
            this.singleShowInformationControl2.StringFormat = "";
            this.singleShowInformationControl2.TabIndex = 9;
            this.singleShowInformationControl2.TextTitle = "Дата прем\'єри";
            this.singleShowInformationControl2.TextValue = "";
            this.singleShowInformationControl2.ValueDataMemger = "";
            this.singleShowInformationControl2.ValueDataSource = null;
            // 
            // cAvanceRemainder
            // 
            this.cAvanceRemainder.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cAvanceRemainder.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.cAvanceRemainder.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "PrepayRest", true));
            this.cAvanceRemainder.Location = new System.Drawing.Point(3, 42);
            this.cAvanceRemainder.MaximumSize = new System.Drawing.Size(1000, 28);
            this.cAvanceRemainder.MinimumSize = new System.Drawing.Size(150, 25);
            this.cAvanceRemainder.Name = "cAvanceRemainder";
            this.cAvanceRemainder.Size = new System.Drawing.Size(199, 28);
            this.cAvanceRemainder.SplitterRatio = 122;
            this.cAvanceRemainder.StringFormat = "";
            this.cAvanceRemainder.TabIndex = 9;
            this.cAvanceRemainder.TextTitle = "Залишок авансу";
            this.cAvanceRemainder.TextValue = "";
            this.cAvanceRemainder.ValueDataMemger = "";
            this.cAvanceRemainder.ValueDataSource = null;
            // 
            // cAvanceOfAgr
            // 
            this.cAvanceOfAgr.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cAvanceOfAgr.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.cAvanceOfAgr.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "PrepayAvans", true));
            this.cAvanceOfAgr.Location = new System.Drawing.Point(3, 15);
            this.cAvanceOfAgr.MaximumSize = new System.Drawing.Size(1000, 28);
            this.cAvanceOfAgr.MinimumSize = new System.Drawing.Size(150, 25);
            this.cAvanceOfAgr.Name = "cAvanceOfAgr";
            this.cAvanceOfAgr.Size = new System.Drawing.Size(199, 28);
            this.cAvanceOfAgr.SplitterRatio = 122;
            this.cAvanceOfAgr.StringFormat = "";
            this.cAvanceOfAgr.TabIndex = 9;
            this.cAvanceOfAgr.TextTitle = "Аванс за договором";
            this.cAvanceOfAgr.TextValue = "";
            this.cAvanceOfAgr.ValueDataMemger = "";
            this.cAvanceOfAgr.ValueDataSource = null;
            // 
            // cIsProlong
            // 
            this.cIsProlong.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cIsProlong.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.cIsProlong.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "ToProlong", true));
            this.cIsProlong.Location = new System.Drawing.Point(342, 4);
            this.cIsProlong.MaximumSize = new System.Drawing.Size(1000, 28);
            this.cIsProlong.MinimumSize = new System.Drawing.Size(150, 25);
            this.cIsProlong.Name = "cIsProlong";
            this.cIsProlong.Size = new System.Drawing.Size(158, 28);
            this.cIsProlong.SplitterRatio = 105;
            this.cIsProlong.StringFormat = "";
            this.cIsProlong.TabIndex = 8;
            this.cIsProlong.TextTitle = "На пролонгацію";
            this.cIsProlong.TextValue = "";
            this.cIsProlong.ValueDataMemger = "";
            this.cIsProlong.ValueDataSource = null;
            // 
            // cAmount
            // 
            this.cAmount.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cAmount.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.cAmount.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "PrepayPaush", true));
            this.cAmount.Location = new System.Drawing.Point(3, 42);
            this.cAmount.MaximumSize = new System.Drawing.Size(1000, 28);
            this.cAmount.MinimumSize = new System.Drawing.Size(150, 25);
            this.cAmount.Name = "cAmount";
            this.cAmount.Size = new System.Drawing.Size(199, 28);
            this.cAmount.SplitterRatio = 100;
            this.cAmount.StringFormat = "";
            this.cAmount.TabIndex = 9;
            this.cAmount.TextTitle = "Сума";
            this.cAmount.TextValue = "";
            this.cAmount.ValueDataMemger = "";
            this.cAmount.ValueDataSource = null;
            // 
            // cValuta
            // 
            this.cValuta.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cValuta.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.cValuta.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "R030", true));
            this.cValuta.Location = new System.Drawing.Point(3, 15);
            this.cValuta.MaximumSize = new System.Drawing.Size(1000, 28);
            this.cValuta.MinimumSize = new System.Drawing.Size(150, 25);
            this.cValuta.Name = "cValuta";
            this.cValuta.Size = new System.Drawing.Size(199, 28);
            this.cValuta.SplitterRatio = 100;
            this.cValuta.StringFormat = "";
            this.cValuta.TabIndex = 9;
            this.cValuta.TextTitle = "Валюта";
            this.cValuta.TextValue = "";
            this.cValuta.ValueDataMemger = "";
            this.cValuta.ValueDataSource = null;
            // 
            // cDate
            // 
            this.cDate.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.cDate.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.cDate.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "LicDate", true));
            this.cDate.Location = new System.Drawing.Point(191, 4);
            this.cDate.MaximumSize = new System.Drawing.Size(1000, 28);
            this.cDate.MinimumSize = new System.Drawing.Size(100, 25);
            this.cDate.Name = "cDate";
            this.cDate.Size = new System.Drawing.Size(119, 28);
            this.cDate.SplitterRatio = 36;
            this.cDate.StringFormat = "d";
            this.cDate.TabIndex = 1;
            this.cDate.TextTitle = "Дата";
            this.cDate.TextValue = "";
            this.cDate.ValueDataMemger = "";
            this.cDate.ValueDataSource = null;
            // 
            // cAgrNumber
            // 
            this.cAgrNumber.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cAgrNumber.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.cAgrNumber.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "AgrNumber", true));
            this.cAgrNumber.Location = new System.Drawing.Point(4, 4);
            this.cAgrNumber.MaximumSize = new System.Drawing.Size(1000, 28);
            this.cAgrNumber.MinimumSize = new System.Drawing.Size(150, 25);
            this.cAgrNumber.Name = "cAgrNumber";
            this.cAgrNumber.Size = new System.Drawing.Size(181, 28);
            this.cAgrNumber.SplitterRatio = 50;
            this.cAgrNumber.StringFormat = "";
            this.cAgrNumber.TabIndex = 0;
            this.cAgrNumber.TextTitle = "Номер";
            this.cAgrNumber.TextValue = "";
            this.cAgrNumber.ValueDataMemger = "";
            this.cAgrNumber.ValueDataSource = null;
            // 
            // InformationAgrBR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radPanel4);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.btnSaveComment);
            this.Controls.Add(this.txtNotation);
            this.Controls.Add(this.cIsProlong);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.cDate);
            this.Controls.Add(this.cAgrNumber);
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(845, 197);
            this.Name = "InformationAgrBR";
            this.Size = new System.Drawing.Size(854, 197);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SingleShowInformationControl cAgrNumber;
        private SingleShowInformationControl cDate;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private SingleShowInformationControl cAmount;
        private SingleShowInformationControl cValuta;
        private SingleShowInformationControl cIsProlong;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBoxControl txtNotation;
        private Telerik.WinControls.UI.RadButton btnSaveComment;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private SingleShowInformationControl cAvanceRemainder;
        private SingleShowInformationControl cAvanceOfAgr;
        private BindingSource bsAgreementView;
        private SingleShowInformationControl singleShowInformationControl1;
        private SingleShowInformationControl singleShowInformationControl2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private SingleShowInformationControl singleShowInformationControl3;
        private SingleShowInformationControl singleShowInformationControl4;
    }
}
