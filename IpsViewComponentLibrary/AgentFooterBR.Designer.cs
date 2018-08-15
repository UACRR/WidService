namespace IpsViewComponentLibrary
{
    partial class AgentFooterBR
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
            this.agrNumber = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.agentPib = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agentPhone = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agentEmail = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agrDate = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.btnAddNew = new Telerik.WinControls.UI.RadButton();
            this.btnViewAnketa = new Telerik.WinControls.UI.RadButton();
            this.ddlSelectedAgent = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnSaveChange = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.bsAgent = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewAnketa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelectedAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // agrNumber
            // 
            this.agrNumber.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agrNumber.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agrNumber.Location = new System.Drawing.Point(16, 3);
            this.agrNumber.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agrNumber.MinimumSize = new System.Drawing.Size(150, 25);
            this.agrNumber.Name = "agrNumber";
            this.agrNumber.Size = new System.Drawing.Size(187, 28);
            this.agrNumber.SplitterRatio = 80;
            this.agrNumber.StringFormat = "";
            this.agrNumber.TabIndex = 0;
            this.agrNumber.TextTitle = "№ договору";
            this.agrNumber.TextValue = "";
            this.agrNumber.ValueDataMemger = "";
            this.agrNumber.ValueDataSource = null;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.agentEmail);
            this.radPanel1.Controls.Add(this.agentPhone);
            this.radPanel1.Controls.Add(this.agentPib);
            this.radPanel1.Location = new System.Drawing.Point(3, 70);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(428, 74);
            this.radPanel1.TabIndex = 1;
            this.radPanel1.ThemeName = "Office2013Light";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(16, 61);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(73, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Представник";
            // 
            // agentPib
            // 
            this.agentPib.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPib.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPib.Location = new System.Drawing.Point(3, 10);
            this.agentPib.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agentPib.MinimumSize = new System.Drawing.Size(150, 25);
            this.agentPib.Name = "agentPib";
            this.agentPib.Size = new System.Drawing.Size(422, 28);
            this.agentPib.SplitterRatio = 35;
            this.agentPib.StringFormat = "";
            this.agentPib.TabIndex = 1;
            this.agentPib.TextTitle = "ПІБ";
            this.agentPib.TextValue = "";
            this.agentPib.ValueDataMemger = "";
            this.agentPib.ValueDataSource = null;
            // 
            // agentPhone
            // 
            this.agentPhone.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPhone.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentPhone.Location = new System.Drawing.Point(3, 39);
            this.agentPhone.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agentPhone.MinimumSize = new System.Drawing.Size(150, 25);
            this.agentPhone.Name = "agentPhone";
            this.agentPhone.Size = new System.Drawing.Size(152, 28);
            this.agentPhone.SplitterRatio = 35;
            this.agentPhone.StringFormat = "";
            this.agentPhone.TabIndex = 2;
            this.agentPhone.TextTitle = "Тел.";
            this.agentPhone.TextValue = "";
            this.agentPhone.ValueDataMemger = "";
            this.agentPhone.ValueDataSource = null;
            // 
            // agentEmail
            // 
            this.agentEmail.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentEmail.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentEmail.Location = new System.Drawing.Point(161, 39);
            this.agentEmail.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agentEmail.MinimumSize = new System.Drawing.Size(150, 25);
            this.agentEmail.Name = "agentEmail";
            this.agentEmail.Size = new System.Drawing.Size(264, 28);
            this.agentEmail.SplitterRatio = 41;
            this.agentEmail.StringFormat = "";
            this.agentEmail.TabIndex = 3;
            this.agentEmail.TextTitle = "Email";
            this.agentEmail.TextValue = "";
            this.agentEmail.ValueDataMemger = "";
            this.agentEmail.ValueDataSource = null;
            // 
            // agrDate
            // 
            this.agrDate.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.agrDate.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agrDate.Location = new System.Drawing.Point(209, 3);
            this.agrDate.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agrDate.MinimumSize = new System.Drawing.Size(150, 25);
            this.agrDate.Name = "agrDate";
            this.agrDate.Size = new System.Drawing.Size(167, 28);
            this.agrDate.SplitterRatio = 90;
            this.agrDate.StringFormat = "";
            this.agrDate.TabIndex = 2;
            this.agrDate.TextTitle = "Дата договору";
            this.agrDate.TextValue = "";
            this.agrDate.ValueDataMemger = "";
            this.agrDate.ValueDataSource = null;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(437, 70);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(185, 21);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Додати нового представника";
            this.btnAddNew.TextWrap = true;
            this.btnAddNew.ThemeName = "Office2013Light";
            // 
            // btnViewAnketa
            // 
            this.btnViewAnketa.Location = new System.Drawing.Point(437, 36);
            this.btnViewAnketa.Name = "btnViewAnketa";
            this.btnViewAnketa.Size = new System.Drawing.Size(185, 21);
            this.btnViewAnketa.TabIndex = 4;
            this.btnViewAnketa.Text = "Перегляд анкети представника";
            this.btnViewAnketa.TextWrap = true;
            this.btnViewAnketa.ThemeName = "Office2013Light";
            // 
            // ddlSelectedAgent
            // 
            this.ddlSelectedAgent.Location = new System.Drawing.Point(132, 36);
            this.ddlSelectedAgent.Name = "ddlSelectedAgent";
            this.ddlSelectedAgent.Size = new System.Drawing.Size(299, 21);
            this.ddlSelectedAgent.TabIndex = 5;
            this.ddlSelectedAgent.ThemeName = "Office2013Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(6, 37);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(122, 18);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Обраний представник";
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Location = new System.Drawing.Point(16, 150);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(112, 21);
            this.btnSaveChange.TabIndex = 7;
            this.btnSaveChange.Text = "Записати зміни";
            this.btnSaveChange.TextWrap = true;
            this.btnSaveChange.ThemeName = "Office2013Light";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(132, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 21);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Скасувати зміни";
            this.btnCancel.TextWrap = true;
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // AgentFooterBR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveChange);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ddlSelectedAgent);
            this.Controls.Add(this.btnViewAnketa);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.agrDate);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.agrNumber);
            this.MaximumSize = new System.Drawing.Size(625, 174);
            this.MinimumSize = new System.Drawing.Size(625, 174);
            this.Name = "AgentFooterBR";
            this.Size = new System.Drawing.Size(625, 174);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewAnketa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelectedAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SingleShowInformationControl agrNumber;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private SingleShowInformationControl agentEmail;
        private SingleShowInformationControl agentPhone;
        private SingleShowInformationControl agentPib;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private SingleShowInformationControl agrDate;
        private Telerik.WinControls.UI.RadButton btnAddNew;
        private Telerik.WinControls.UI.RadButton btnViewAnketa;
        private Telerik.WinControls.UI.RadDropDownList ddlSelectedAgent;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnSaveChange;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private System.Windows.Forms.BindingSource bsAgent;
    }
}
