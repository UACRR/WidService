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
            this.cAvanceRemainder = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.cAvanceOfAgr = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.bsAgreementView = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.bsAgreementView)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.cAmount);
            this.radPanel1.Controls.Add(this.cValuta);
            this.radPanel1.Location = new System.Drawing.Point(64, 47);
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
            this.txtNotation.Size = new System.Drawing.Size(509, 94);
            this.txtNotation.TabIndex = 9;
            this.txtNotation.ThemeName = "Office2013Light";
            // 
            // btnSaveComment
            // 
            this.btnSaveComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveComment.Location = new System.Drawing.Point(3, 189);
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
            this.radLabel2.Location = new System.Drawing.Point(76, 38);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(109, 18);
            this.radLabel2.TabIndex = 10;
            this.radLabel2.Text = "Паушальний платіж";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(307, 38);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(37, 18);
            this.radLabel3.TabIndex = 12;
            this.radLabel3.Text = "Аванс";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.cAvanceRemainder);
            this.radPanel2.Controls.Add(this.cAvanceOfAgr);
            this.radPanel2.Location = new System.Drawing.Point(295, 47);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(205, 76);
            this.radPanel2.TabIndex = 11;
            this.radPanel2.ThemeName = "Office2013Light";
            // 
            // cAvanceRemainder
            // 
            this.cAvanceRemainder.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cAvanceRemainder.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
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
            // bsAgreementView
            // 
            this.bsAgreementView.DataSource = typeof(ipsFormsDesign.Interfaces.VbrLicense);
            // 
            // cIsProlong
            // 
            this.cIsProlong.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.cIsProlong.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cAmount.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "TicketPriceNC", true));
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
            this.cValuta.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsAgreementView, "TicketPriceUSD", true));
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
            this.MaximumSize = new System.Drawing.Size(788, 500);
            this.MinimumSize = new System.Drawing.Size(503, 188);
            this.Name = "InformationAgrBR";
            this.Size = new System.Drawing.Size(588, 226);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
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
    }
}
