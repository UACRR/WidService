using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    partial class InformationFooterGenAgrBigRight
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
            this.panel = new Telerik.WinControls.UI.RadPanel();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.bindRequest = new System.Windows.Forms.Label();
            this.bindReference = new System.Windows.Forms.Label();
            this.bsVbrLicense = new System.Windows.Forms.BindingSource(this.components);
            this.distribAmount = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.unAttackAmount = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.attachAmount = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.noAcceptReference = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.noAcceptRequest = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.activeRequestReference = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.noProlongLicense = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.noAcceptLicense = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.activeLicense = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.partnerName = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agrDate = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agrNumber = new IpsViewComponentLibrary.SingleShowInformationControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsVbrLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.bindReference);
            this.panel.Controls.Add(this.bindRequest);
            this.panel.Controls.Add(this.radPanel4);
            this.panel.Controls.Add(this.radPanel2);
            this.panel.Controls.Add(this.radPanel1);
            this.panel.Controls.Add(this.partnerName);
            this.panel.Controls.Add(this.agrDate);
            this.panel.Controls.Add(this.agrNumber);
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(906, 149);
            this.panel.TabIndex = 1;
            this.panel.ThemeName = "Office2013Light";
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.distribAmount);
            this.radPanel4.Controls.Add(this.unAttackAmount);
            this.radPanel4.Controls.Add(this.attachAmount);
            this.radPanel4.Location = new System.Drawing.Point(539, 37);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(232, 106);
            this.radPanel4.TabIndex = 6;
            this.radPanel4.ThemeName = "Office2013Light";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.noAcceptReference);
            this.radPanel2.Controls.Add(this.noAcceptRequest);
            this.radPanel2.Controls.Add(this.activeRequestReference);
            this.radPanel2.Location = new System.Drawing.Point(280, 37);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(223, 106);
            this.radPanel2.TabIndex = 4;
            this.radPanel2.ThemeName = "Office2013Light";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.noProlongLicense);
            this.radPanel1.Controls.Add(this.noAcceptLicense);
            this.radPanel1.Controls.Add(this.activeLicense);
            this.radPanel1.Location = new System.Drawing.Point(19, 37);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(223, 106);
            this.radPanel1.TabIndex = 3;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // bindRequest
            // 
            this.bindRequest.AutoSize = true;
            this.bindRequest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "CountLic2Active", true));
            this.bindRequest.Location = new System.Drawing.Point(864, 64);
            this.bindRequest.Name = "bindRequest";
            this.bindRequest.Size = new System.Drawing.Size(27, 15);
            this.bindRequest.TabIndex = 7;
            this.bindRequest.Text = "Req";
            this.bindRequest.Visible = false;
            // 
            // bindReference
            // 
            this.bindReference.AutoSize = true;
            this.bindReference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVbrLicense, "CountLic3Active", true));
            this.bindReference.Location = new System.Drawing.Point(864, 79);
            this.bindReference.Name = "bindReference";
            this.bindReference.Size = new System.Drawing.Size(24, 15);
            this.bindReference.TabIndex = 8;
            this.bindReference.Text = "Ref";
            this.bindReference.Visible = false;
            // 
            // bsVbrLicense
            // 
            this.bsVbrLicense.DataSource = typeof(ipsFormsDesign.Interfaces.ConsumerBigRightView);
            // 
            // distribAmount
            // 
            this.distribAmount.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.distribAmount.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.distribAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.distribAmount.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "PrePayRest", true));
            this.distribAmount.Location = new System.Drawing.Point(3, 71);
            this.distribAmount.MaximumSize = new System.Drawing.Size(1000, 28);
            this.distribAmount.MinimumSize = new System.Drawing.Size(150, 25);
            this.distribAmount.Name = "distribAmount";
            this.distribAmount.Size = new System.Drawing.Size(226, 28);
            this.distribAmount.SplitterRatio = 145;
            this.distribAmount.StringFormat = "0";
            this.distribAmount.TabIndex = 6;
            this.distribAmount.TextTitle = "Залишок авансів";
            this.distribAmount.TextValue = "";
            this.distribAmount.ValueDataMemger = "";
            this.distribAmount.ValueDataSource = null;
            // 
            // unAttackAmount
            // 
            this.unAttackAmount.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.unAttackAmount.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.unAttackAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unAttackAmount.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "UnattachAmount", true));
            this.unAttackAmount.Location = new System.Drawing.Point(3, 37);
            this.unAttackAmount.MaximumSize = new System.Drawing.Size(1000, 28);
            this.unAttackAmount.MinimumSize = new System.Drawing.Size(150, 25);
            this.unAttackAmount.Name = "unAttackAmount";
            this.unAttackAmount.Size = new System.Drawing.Size(226, 28);
            this.unAttackAmount.SplitterRatio = 145;
            this.unAttackAmount.StringFormat = "0";
            this.unAttackAmount.TabIndex = 5;
            this.unAttackAmount.TextTitle = "Неприв\'язаних коштів";
            this.unAttackAmount.TextValue = "";
            this.unAttackAmount.ValueDataMemger = "";
            this.unAttackAmount.ValueDataSource = null;
            // 
            // attachAmount
            // 
            this.attachAmount.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.attachAmount.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.attachAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attachAmount.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "Borg", true));
            this.attachAmount.Location = new System.Drawing.Point(3, 3);
            this.attachAmount.MaximumSize = new System.Drawing.Size(1000, 28);
            this.attachAmount.MinimumSize = new System.Drawing.Size(150, 25);
            this.attachAmount.Name = "attachAmount";
            this.attachAmount.Size = new System.Drawing.Size(226, 28);
            this.attachAmount.SplitterRatio = 145;
            this.attachAmount.StringFormat = "0";
            this.attachAmount.TabIndex = 4;
            this.attachAmount.TextTitle = "Заборгованість";
            this.attachAmount.TextValue = "";
            this.attachAmount.ValueDataMemger = "";
            this.attachAmount.ValueDataSource = null;
            // 
            // noAcceptReference
            // 
            this.noAcceptReference.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.noAcceptReference.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.noAcceptReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noAcceptReference.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "CountLic3NoActive", true));
            this.noAcceptReference.Location = new System.Drawing.Point(3, 71);
            this.noAcceptReference.MaximumSize = new System.Drawing.Size(1000, 28);
            this.noAcceptReference.MinimumSize = new System.Drawing.Size(150, 25);
            this.noAcceptReference.Name = "noAcceptReference";
            this.noAcceptReference.Size = new System.Drawing.Size(217, 28);
            this.noAcceptReference.SplitterRatio = 151;
            this.noAcceptReference.StringFormat = "0";
            this.noAcceptReference.TabIndex = 6;
            this.noAcceptReference.TextTitle = "Довідок не акцептованих";
            this.noAcceptReference.TextValue = "";
            this.noAcceptReference.ValueDataMemger = "";
            this.noAcceptReference.ValueDataSource = null;
            // 
            // noAcceptRequest
            // 
            this.noAcceptRequest.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.noAcceptRequest.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.noAcceptRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noAcceptRequest.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "CountLic2NoActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.noAcceptRequest.Location = new System.Drawing.Point(3, 37);
            this.noAcceptRequest.MaximumSize = new System.Drawing.Size(1000, 28);
            this.noAcceptRequest.MinimumSize = new System.Drawing.Size(150, 25);
            this.noAcceptRequest.Name = "noAcceptRequest";
            this.noAcceptRequest.Size = new System.Drawing.Size(217, 28);
            this.noAcceptRequest.SplitterRatio = 151;
            this.noAcceptRequest.StringFormat = "0";
            this.noAcceptRequest.TabIndex = 5;
            this.noAcceptRequest.TextTitle = "Заявок не акцептованих";
            this.noAcceptRequest.TextValue = "";
            this.noAcceptRequest.ValueDataMemger = "";
            this.noAcceptRequest.ValueDataSource = null;
            // 
            // activeRequestReference
            // 
            this.activeRequestReference.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.activeRequestReference.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.activeRequestReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeRequestReference.Location = new System.Drawing.Point(3, 3);
            this.activeRequestReference.MaximumSize = new System.Drawing.Size(1000, 28);
            this.activeRequestReference.MinimumSize = new System.Drawing.Size(150, 25);
            this.activeRequestReference.Name = "activeRequestReference";
            this.activeRequestReference.Size = new System.Drawing.Size(217, 28);
            this.activeRequestReference.SplitterRatio = 151;
            this.activeRequestReference.StringFormat = "0";
            this.activeRequestReference.TabIndex = 4;
            this.activeRequestReference.TextTitle = "Активних заявок/довідок";
            this.activeRequestReference.TextValue = "";
            this.activeRequestReference.ValueDataMemger = "";
            this.activeRequestReference.ValueDataSource = null;
            // 
            // noProlongLicense
            // 
            this.noProlongLicense.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.noProlongLicense.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.noProlongLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noProlongLicense.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "CountLic1ToProlong", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.noProlongLicense.Location = new System.Drawing.Point(3, 71);
            this.noProlongLicense.MaximumSize = new System.Drawing.Size(1000, 28);
            this.noProlongLicense.MinimumSize = new System.Drawing.Size(150, 25);
            this.noProlongLicense.Name = "noProlongLicense";
            this.noProlongLicense.Size = new System.Drawing.Size(217, 28);
            this.noProlongLicense.SplitterRatio = 152;
            this.noProlongLicense.StringFormat = "0";
            this.noProlongLicense.TabIndex = 6;
            this.noProlongLicense.TextTitle = "Ліцензій до пролонгації";
            this.noProlongLicense.TextValue = "";
            this.noProlongLicense.ValueDataMemger = "";
            this.noProlongLicense.ValueDataSource = null;
            // 
            // noAcceptLicense
            // 
            this.noAcceptLicense.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.noAcceptLicense.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.noAcceptLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noAcceptLicense.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "CountLic1NoActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.noAcceptLicense.Location = new System.Drawing.Point(3, 37);
            this.noAcceptLicense.MaximumSize = new System.Drawing.Size(1000, 28);
            this.noAcceptLicense.MinimumSize = new System.Drawing.Size(150, 25);
            this.noAcceptLicense.Name = "noAcceptLicense";
            this.noAcceptLicense.Size = new System.Drawing.Size(217, 28);
            this.noAcceptLicense.SplitterRatio = 152;
            this.noAcceptLicense.StringFormat = "0";
            this.noAcceptLicense.TabIndex = 5;
            this.noAcceptLicense.TextTitle = "Ліцензій не акцептованих";
            this.noAcceptLicense.TextValue = "";
            this.noAcceptLicense.ValueDataMemger = "";
            this.noAcceptLicense.ValueDataSource = null;
            // 
            // activeLicense
            // 
            this.activeLicense.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.activeLicense.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.activeLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeLicense.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "CountLic1Active", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.activeLicense.Location = new System.Drawing.Point(3, 3);
            this.activeLicense.MaximumSize = new System.Drawing.Size(1000, 28);
            this.activeLicense.MinimumSize = new System.Drawing.Size(150, 25);
            this.activeLicense.Name = "activeLicense";
            this.activeLicense.Size = new System.Drawing.Size(217, 28);
            this.activeLicense.SplitterRatio = 152;
            this.activeLicense.StringFormat = "0";
            this.activeLicense.TabIndex = 4;
            this.activeLicense.TextTitle = "Активних ліцензій";
            this.activeLicense.TextValue = "";
            this.activeLicense.ValueDataMemger = "";
            this.activeLicense.ValueDataSource = null;
            // 
            // partnerName
            // 
            this.partnerName.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.partnerName.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.partnerName.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "PartnerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.partnerName.Location = new System.Drawing.Point(391, 3);
            this.partnerName.MaximumSize = new System.Drawing.Size(1000, 28);
            this.partnerName.MinimumSize = new System.Drawing.Size(150, 25);
            this.partnerName.Name = "partnerName";
            this.partnerName.Size = new System.Drawing.Size(458, 28);
            this.partnerName.SplitterRatio = 87;
            this.partnerName.StringFormat = "0";
            this.partnerName.TabIndex = 2;
            this.partnerName.TextTitle = "Представник";
            this.partnerName.TextValue = "";
            this.partnerName.ValueDataMemger = "";
            this.partnerName.ValueDataSource = null;
            // 
            // agrDate
            // 
            this.agrDate.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agrDate.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.agrDate.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "AgrDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.agrDate.Location = new System.Drawing.Point(197, 3);
            this.agrDate.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agrDate.MinimumSize = new System.Drawing.Size(150, 25);
            this.agrDate.Name = "agrDate";
            this.agrDate.Size = new System.Drawing.Size(188, 28);
            this.agrDate.SplitterRatio = 90;
            this.agrDate.StringFormat = "0";
            this.agrDate.TabIndex = 1;
            this.agrDate.TextTitle = "Дата договору";
            this.agrDate.TextValue = "";
            this.agrDate.ValueDataMemger = "";
            this.agrDate.ValueDataSource = null;
            // 
            // agrNumber
            // 
            this.agrNumber.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agrNumber.AlignmentValue = System.Drawing.ContentAlignment.MiddleCenter;
            this.agrNumber.DataBindings.Add(new System.Windows.Forms.Binding("ValueDataMemger", this.bsVbrLicense, "AgrNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, ""));
            this.agrNumber.Location = new System.Drawing.Point(3, 3);
            this.agrNumber.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agrNumber.MinimumSize = new System.Drawing.Size(150, 25);
            this.agrNumber.Name = "agrNumber";
            this.agrNumber.Size = new System.Drawing.Size(188, 28);
            this.agrNumber.SplitterRatio = 90;
            this.agrNumber.StringFormat = "0";
            this.agrNumber.TabIndex = 0;
            this.agrNumber.TextTitle = "№ договору";
            this.agrNumber.TextValue = "";
            this.agrNumber.ValueDataMemger = "";
            this.agrNumber.ValueDataSource = null;
            // 
            // InformationFooterGenAgrBigRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.MaximumSize = new System.Drawing.Size(912, 155);
            this.MinimumSize = new System.Drawing.Size(912, 155);
            this.Name = "InformationFooterGenAgrBigRight";
            this.Size = new System.Drawing.Size(912, 155);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsVbrLicense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SingleShowInformationControl agrNumber;
        private Telerik.WinControls.UI.RadPanel panel;
        private SingleShowInformationControl partnerName;
        private SingleShowInformationControl agrDate;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private SingleShowInformationControl distribAmount;
        private SingleShowInformationControl unAttackAmount;
        private SingleShowInformationControl attachAmount;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private SingleShowInformationControl noAcceptReference;
        private SingleShowInformationControl noAcceptRequest;
        private SingleShowInformationControl activeRequestReference;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private SingleShowInformationControl noProlongLicense;
        private SingleShowInformationControl noAcceptLicense;
        private SingleShowInformationControl activeLicense;
        private System.Windows.Forms.BindingSource bsVbrLicense;
        private Label bindReference;
        private Label bindRequest;
    }
}
