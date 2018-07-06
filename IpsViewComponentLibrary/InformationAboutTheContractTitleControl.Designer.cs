namespace IpsViewComponentLibrary
{
    partial class InformationAboutTheContractTitleControl
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
            this.checkAttach = new Telerik.WinControls.UI.RadCheckBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.isProlongationCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.dateEndCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.dateBeginCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.minPayCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.percentCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.isPayCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.implemCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.stateCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.distributedAmountCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.amountCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.bankCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtNotation = new Telerik.WinControls.UI.RadTextBoxControl();
            this.periodCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.agentCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.dateCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            this.numberCtrl = new IpsViewComponentLibrary.SingleShowInformationControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkAttach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotation)).BeginInit();
            this.SuspendLayout();
            // 
            // checkAttach
            // 
            this.checkAttach.AutoSize = false;
            this.checkAttach.Location = new System.Drawing.Point(249, 38);
            this.checkAttach.Name = "checkAttach";
            this.checkAttach.Size = new System.Drawing.Size(308, 28);
            this.checkAttach.TabIndex = 4;
            this.checkAttach.Text = "Закріпляти, навіть якщо прострочений";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.isProlongationCtrl);
            this.radPanel1.Controls.Add(this.dateEndCtrl);
            this.radPanel1.Controls.Add(this.dateBeginCtrl);
            this.radPanel1.Location = new System.Drawing.Point(4, 73);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(190, 97);
            this.radPanel1.TabIndex = 5;
            // 
            // isProlongationCtrl
            // 
            this.isProlongationCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.isProlongationCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.isProlongationCtrl.Location = new System.Drawing.Point(3, 57);
            this.isProlongationCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.isProlongationCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.isProlongationCtrl.Name = "isProlongationCtrl";
            this.isProlongationCtrl.Size = new System.Drawing.Size(184, 28);
            this.isProlongationCtrl.SplitterRatio = 142;
            this.isProlongationCtrl.TabIndex = 9;
            this.isProlongationCtrl.TextTitle = "Пролонгація";
            this.isProlongationCtrl.TextValue = "ТАК";
            // 
            // dateEndCtrl
            // 
            this.dateEndCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.dateEndCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.dateEndCtrl.Location = new System.Drawing.Point(3, 30);
            this.dateEndCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.dateEndCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.dateEndCtrl.Name = "dateEndCtrl";
            this.dateEndCtrl.Size = new System.Drawing.Size(184, 28);
            this.dateEndCtrl.SplitterRatio = 96;
            this.dateEndCtrl.TabIndex = 9;
            this.dateEndCtrl.TextTitle = "Кінець дії";
            this.dateEndCtrl.TextValue = "10.10.1010";
            // 
            // dateBeginCtrl
            // 
            this.dateBeginCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.dateBeginCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.dateBeginCtrl.Location = new System.Drawing.Point(3, 3);
            this.dateBeginCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.dateBeginCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.dateBeginCtrl.Name = "dateBeginCtrl";
            this.dateBeginCtrl.Size = new System.Drawing.Size(184, 28);
            this.dateBeginCtrl.SplitterRatio = 96;
            this.dateBeginCtrl.TabIndex = 8;
            this.dateBeginCtrl.TextTitle = "Початок дії";
            this.dateBeginCtrl.TextValue = "10.10.1010";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.minPayCtrl);
            this.radPanel2.Controls.Add(this.percentCtrl);
            this.radPanel2.Location = new System.Drawing.Point(200, 73);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(190, 97);
            this.radPanel2.TabIndex = 6;
            // 
            // minPayCtrl
            // 
            this.minPayCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.minPayCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.minPayCtrl.Location = new System.Drawing.Point(3, 31);
            this.minPayCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.minPayCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.minPayCtrl.Name = "minPayCtrl";
            this.minPayCtrl.Size = new System.Drawing.Size(182, 28);
            this.minPayCtrl.SplitterRatio = 109;
            this.minPayCtrl.TabIndex = 11;
            this.minPayCtrl.TextTitle = "Мінімальна сума";
            this.minPayCtrl.TextValue = "14799.50";
            // 
            // percentCtrl
            // 
            this.percentCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.percentCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.percentCtrl.Location = new System.Drawing.Point(3, 4);
            this.percentCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.percentCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.percentCtrl.Name = "percentCtrl";
            this.percentCtrl.Size = new System.Drawing.Size(182, 28);
            this.percentCtrl.SplitterRatio = 143;
            this.percentCtrl.TabIndex = 10;
            this.percentCtrl.TextTitle = "Відсоток відрахувань";
            this.percentCtrl.TextValue = "3";
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.isPayCtrl);
            this.radPanel3.Controls.Add(this.implemCtrl);
            this.radPanel3.Controls.Add(this.stateCtrl);
            this.radPanel3.Location = new System.Drawing.Point(396, 73);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(190, 97);
            this.radPanel3.TabIndex = 7;
            // 
            // isPayCtrl
            // 
            this.isPayCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.isPayCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.isPayCtrl.Location = new System.Drawing.Point(3, 58);
            this.isPayCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.isPayCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.isPayCtrl.Name = "isPayCtrl";
            this.isPayCtrl.Size = new System.Drawing.Size(184, 28);
            this.isPayCtrl.SplitterRatio = 68;
            this.isPayCtrl.TabIndex = 12;
            this.isPayCtrl.TextTitle = "Оплата";
            this.isPayCtrl.TextValue = "Не сплачений";
            // 
            // implemCtrl
            // 
            this.implemCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.implemCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.implemCtrl.Location = new System.Drawing.Point(3, 31);
            this.implemCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.implemCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.implemCtrl.Name = "implemCtrl";
            this.implemCtrl.Size = new System.Drawing.Size(184, 28);
            this.implemCtrl.SplitterRatio = 72;
            this.implemCtrl.TabIndex = 11;
            this.implemCtrl.TextTitle = "Виконання";
            this.implemCtrl.TextValue = "Немає акту";
            // 
            // stateCtrl
            // 
            this.stateCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.stateCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.stateCtrl.Location = new System.Drawing.Point(3, 4);
            this.stateCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.stateCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.stateCtrl.Name = "stateCtrl";
            this.stateCtrl.Size = new System.Drawing.Size(184, 28);
            this.stateCtrl.SplitterRatio = 40;
            this.stateCtrl.TabIndex = 10;
            this.stateCtrl.TextTitle = "Стан";
            this.stateCtrl.TextValue = "Не дійсний";
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.distributedAmountCtrl);
            this.radPanel4.Controls.Add(this.amountCtrl);
            this.radPanel4.Controls.Add(this.bankCtrl);
            this.radPanel4.Location = new System.Drawing.Point(592, 73);
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.Size = new System.Drawing.Size(190, 97);
            this.radPanel4.TabIndex = 6;
            // 
            // distributedAmountCtrl
            // 
            this.distributedAmountCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.distributedAmountCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.distributedAmountCtrl.Location = new System.Drawing.Point(3, 58);
            this.distributedAmountCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.distributedAmountCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.distributedAmountCtrl.Name = "distributedAmountCtrl";
            this.distributedAmountCtrl.Size = new System.Drawing.Size(184, 28);
            this.distributedAmountCtrl.SplitterRatio = 110;
            this.distributedAmountCtrl.TabIndex = 12;
            this.distributedAmountCtrl.TextTitle = "Розподілена сума";
            this.distributedAmountCtrl.TextValue = "640";
            // 
            // amountCtrl
            // 
            this.amountCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.amountCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.amountCtrl.Location = new System.Drawing.Point(3, 31);
            this.amountCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.amountCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.amountCtrl.Name = "amountCtrl";
            this.amountCtrl.Size = new System.Drawing.Size(184, 28);
            this.amountCtrl.SplitterRatio = 110;
            this.amountCtrl.TabIndex = 11;
            this.amountCtrl.TextTitle = "Сума звірки";
            this.amountCtrl.TextValue = "94500";
            // 
            // bankCtrl
            // 
            this.bankCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.bankCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleRight;
            this.bankCtrl.Location = new System.Drawing.Point(3, 4);
            this.bankCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.bankCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.bankCtrl.Name = "bankCtrl";
            this.bankCtrl.Size = new System.Drawing.Size(184, 28);
            this.bankCtrl.SplitterRatio = 110;
            this.bankCtrl.TabIndex = 10;
            this.bankCtrl.TextTitle = "Банк";
            this.bankCtrl.TextValue = "960";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(4, 176);
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
            this.txtNotation.Location = new System.Drawing.Point(64, 176);
            this.txtNotation.Multiline = true;
            this.txtNotation.Name = "txtNotation";
            this.txtNotation.Size = new System.Drawing.Size(717, 78);
            this.txtNotation.TabIndex = 9;
            // 
            // periodCtrl
            // 
            this.periodCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.periodCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.periodCtrl.Location = new System.Drawing.Point(4, 38);
            this.periodCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.periodCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.periodCtrl.Name = "periodCtrl";
            this.periodCtrl.Size = new System.Drawing.Size(225, 28);
            this.periodCtrl.SplitterRatio = 96;
            this.periodCtrl.TabIndex = 3;
            this.periodCtrl.TextTitle = "Період звітності";
            this.periodCtrl.TextValue = "Щоночі";
            // 
            // agentCtrl
            // 
            this.agentCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.agentCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.agentCtrl.Location = new System.Drawing.Point(391, 4);
            this.agentCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.agentCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.agentCtrl.Name = "agentCtrl";
            this.agentCtrl.Size = new System.Drawing.Size(391, 28);
            this.agentCtrl.SplitterRatio = 85;
            this.agentCtrl.TabIndex = 2;
            this.agentCtrl.TextTitle = "Представник";
            this.agentCtrl.TextValue = "";
            // 
            // dateCtrl
            // 
            this.dateCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleRight;
            this.dateCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.dateCtrl.Location = new System.Drawing.Point(235, 4);
            this.dateCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.dateCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.dateCtrl.Name = "dateCtrl";
            this.dateCtrl.Size = new System.Drawing.Size(150, 28);
            this.dateCtrl.SplitterRatio = 45;
            this.dateCtrl.TabIndex = 1;
            this.dateCtrl.TextTitle = "Дата";
            this.dateCtrl.TextValue = "12.12.2020";
            // 
            // numberCtrl
            // 
            this.numberCtrl.AlignmentTitle = System.Drawing.ContentAlignment.MiddleLeft;
            this.numberCtrl.AlignmentValue = System.Drawing.ContentAlignment.MiddleLeft;
            this.numberCtrl.Location = new System.Drawing.Point(4, 4);
            this.numberCtrl.MaximumSize = new System.Drawing.Size(1000, 28);
            this.numberCtrl.MinimumSize = new System.Drawing.Size(150, 25);
            this.numberCtrl.Name = "numberCtrl";
            this.numberCtrl.Size = new System.Drawing.Size(225, 28);
            this.numberCtrl.SplitterRatio = 48;
            this.numberCtrl.TabIndex = 0;
            this.numberCtrl.TextTitle = "Номер";
            this.numberCtrl.TextValue = "КБЦКП - 95/87845-45а";
            // 
            // InformationAboutTheContractTitleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNotation);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanel4);
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.checkAttach);
            this.Controls.Add(this.periodCtrl);
            this.Controls.Add(this.agentCtrl);
            this.Controls.Add(this.dateCtrl);
            this.Controls.Add(this.numberCtrl);
            this.MaximumSize = new System.Drawing.Size(788, 500);
            this.MinimumSize = new System.Drawing.Size(788, 257);
            this.Name = "InformationAboutTheContractTitleControl";
            this.Size = new System.Drawing.Size(788, 257);
            ((System.ComponentModel.ISupportInitialize)(this.checkAttach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SingleShowInformationControl numberCtrl;
        private SingleShowInformationControl dateCtrl;
        private SingleShowInformationControl agentCtrl;
        private SingleShowInformationControl periodCtrl;
        private Telerik.WinControls.UI.RadCheckBox checkAttach;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private SingleShowInformationControl isProlongationCtrl;
        private SingleShowInformationControl dateEndCtrl;
        private SingleShowInformationControl dateBeginCtrl;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private SingleShowInformationControl minPayCtrl;
        private SingleShowInformationControl percentCtrl;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private SingleShowInformationControl isPayCtrl;
        private SingleShowInformationControl implemCtrl;
        private SingleShowInformationControl stateCtrl;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private SingleShowInformationControl distributedAmountCtrl;
        private SingleShowInformationControl amountCtrl;
        private SingleShowInformationControl bankCtrl;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBoxControl txtNotation;
    }
}
