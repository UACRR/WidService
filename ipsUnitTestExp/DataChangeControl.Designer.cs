using System.Drawing;

namespace ipsTestExp
{
    partial class DataChangeControl
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
            this.rDropDownListGroup = new Telerik.WinControls.UI.RadDropDownList();
            this.rLblNameUk = new Telerik.WinControls.UI.RadLabel();
            this.rTxtBoxNameUk = new Telerik.WinControls.UI.RadTextBox();
            this.rTxtBoxNameEn = new Telerik.WinControls.UI.RadTextBox();
            this.rTxtBoxNameRu = new Telerik.WinControls.UI.RadTextBox();
            this.rPanelGroupName = new Telerik.WinControls.UI.RadPanel();
            this.rLblNameEn = new Telerik.WinControls.UI.RadLabel();
            this.rLblNameRu = new Telerik.WinControls.UI.RadLabel();
            this.rLblNameKind = new Telerik.WinControls.UI.RadLabel();
            this.rTxtBoxKindUk = new Telerik.WinControls.UI.RadTextBox();
            this.rPanelKindName = new Telerik.WinControls.UI.RadPanel();
            this.rTxtBoxKindEn = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rTxtBoxKindRu = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownListGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameUk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameUk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelGroupName)).BeginInit();
            this.rPanelGroupName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxKindUk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelKindName)).BeginInit();
            this.rPanelKindName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxKindEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxKindRu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // rDropDownListGroup
            // 
            this.rDropDownListGroup.Location = new System.Drawing.Point(4, 4);
            this.rDropDownListGroup.Name = "rDropDownListGroup";
            this.rDropDownListGroup.NullText = "Оберіть групу";
            this.rDropDownListGroup.Size = new System.Drawing.Size(283, 20);
            this.rDropDownListGroup.TabIndex = 0;
            this.rDropDownListGroup.SelectedValueChanged += new System.EventHandler(this.rDropDownListGroup_SelectedValueChanged);
            // 
            // rLblNameUk
            // 
            this.rLblNameUk.AutoSize = false;
            this.rLblNameUk.Location = new System.Drawing.Point(3, 3);
            this.rLblNameUk.Name = "rLblNameUk";
            this.rLblNameUk.Size = new System.Drawing.Size(146, 18);
            this.rLblNameUk.TabIndex = 3;
            this.rLblNameUk.Text = "Введіть назву групи:";
            this.rLblNameUk.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rTxtBoxNameUk
            // 
            this.rTxtBoxNameUk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBoxNameUk.AutoSize = false;
            this.rTxtBoxNameUk.Location = new System.Drawing.Point(155, 2);
            this.rTxtBoxNameUk.Multiline = true;
            this.rTxtBoxNameUk.Name = "rTxtBoxNameUk";
            this.rTxtBoxNameUk.Size = new System.Drawing.Size(633, 20);
            this.rTxtBoxNameUk.TabIndex = 4;
            // 
            // rTxtBoxNameEn
            // 
            this.rTxtBoxNameEn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBoxNameEn.AutoSize = false;
            this.rTxtBoxNameEn.Location = new System.Drawing.Point(155, 54);
            this.rTxtBoxNameEn.Multiline = true;
            this.rTxtBoxNameEn.Name = "rTxtBoxNameEn";
            this.rTxtBoxNameEn.Size = new System.Drawing.Size(633, 20);
            this.rTxtBoxNameEn.TabIndex = 5;
            // 
            // rTxtBoxNameRu
            // 
            this.rTxtBoxNameRu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBoxNameRu.AutoSize = false;
            this.rTxtBoxNameRu.Location = new System.Drawing.Point(155, 28);
            this.rTxtBoxNameRu.Multiline = true;
            this.rTxtBoxNameRu.Name = "rTxtBoxNameRu";
            this.rTxtBoxNameRu.Size = new System.Drawing.Size(633, 20);
            this.rTxtBoxNameRu.TabIndex = 5;
            // 
            // rPanelGroupName
            // 
            this.rPanelGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rPanelGroupName.Controls.Add(this.rLblNameEn);
            this.rPanelGroupName.Controls.Add(this.rLblNameRu);
            this.rPanelGroupName.Controls.Add(this.rTxtBoxNameUk);
            this.rPanelGroupName.Controls.Add(this.rLblNameUk);
            this.rPanelGroupName.Controls.Add(this.rTxtBoxNameRu);
            this.rPanelGroupName.Controls.Add(this.rTxtBoxNameEn);
            this.rPanelGroupName.Location = new System.Drawing.Point(293, 4);
            this.rPanelGroupName.Name = "rPanelGroupName";
            this.rPanelGroupName.Size = new System.Drawing.Size(791, 78);
            this.rPanelGroupName.TabIndex = 6;
            // 
            // rLblNameEn
            // 
            this.rLblNameEn.AutoSize = false;
            this.rLblNameEn.Location = new System.Drawing.Point(3, 52);
            this.rLblNameEn.Name = "rLblNameEn";
            this.rLblNameEn.Size = new System.Drawing.Size(146, 18);
            this.rLblNameEn.TabIndex = 7;
            this.rLblNameEn.Text = "Enter name of group:";
            this.rLblNameEn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rLblNameRu
            // 
            this.rLblNameRu.AutoSize = false;
            this.rLblNameRu.Location = new System.Drawing.Point(3, 28);
            this.rLblNameRu.Name = "rLblNameRu";
            this.rLblNameRu.Size = new System.Drawing.Size(146, 18);
            this.rLblNameRu.TabIndex = 6;
            this.rLblNameRu.Text = "Введите название группы:";
            this.rLblNameRu.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rLblNameKind
            // 
            this.rLblNameKind.AutoSize = false;
            this.rLblNameKind.Location = new System.Drawing.Point(3, 10);
            this.rLblNameKind.Name = "rLblNameKind";
            this.rLblNameKind.Size = new System.Drawing.Size(110, 18);
            this.rLblNameKind.TabIndex = 7;
            this.rLblNameKind.Text = "Введіть назву виду:";
            // 
            // rTxtBoxKindUk
            // 
            this.rTxtBoxKindUk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBoxKindUk.AutoSize = false;
            this.rTxtBoxKindUk.Location = new System.Drawing.Point(3, 34);
            this.rTxtBoxKindUk.Multiline = true;
            this.rTxtBoxKindUk.Name = "rTxtBoxKindUk";
            this.rTxtBoxKindUk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rTxtBoxKindUk.Size = new System.Drawing.Size(1073, 80);
            this.rTxtBoxKindUk.TabIndex = 8;
            // 
            // rPanelKindName
            // 
            this.rPanelKindName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rPanelKindName.Controls.Add(this.rTxtBoxKindEn);
            this.rPanelKindName.Controls.Add(this.radLabel2);
            this.rPanelKindName.Controls.Add(this.rTxtBoxKindRu);
            this.rPanelKindName.Controls.Add(this.radLabel1);
            this.rPanelKindName.Controls.Add(this.rTxtBoxKindUk);
            this.rPanelKindName.Controls.Add(this.rLblNameKind);
            this.rPanelKindName.Location = new System.Drawing.Point(3, 99);
            this.rPanelKindName.Name = "rPanelKindName";
            this.rPanelKindName.Size = new System.Drawing.Size(1079, 343);
            this.rPanelKindName.TabIndex = 9;
            // 
            // rTxtBoxKindEn
            // 
            this.rTxtBoxKindEn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBoxKindEn.AutoSize = false;
            this.rTxtBoxKindEn.Location = new System.Drawing.Point(3, 254);
            this.rTxtBoxKindEn.Multiline = true;
            this.rTxtBoxKindEn.Name = "rTxtBoxKindEn";
            this.rTxtBoxKindEn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rTxtBoxKindEn.Size = new System.Drawing.Size(1073, 80);
            this.rTxtBoxKindEn.TabIndex = 12;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(3, 230);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(110, 18);
            this.radLabel2.TabIndex = 11;
            this.radLabel2.Text = "Enter name of kind:";
            // 
            // rTxtBoxKindRu
            // 
            this.rTxtBoxKindRu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxtBoxKindRu.AutoSize = false;
            this.rTxtBoxKindRu.Location = new System.Drawing.Point(3, 144);
            this.rTxtBoxKindRu.Multiline = true;
            this.rTxtBoxKindRu.Name = "rTxtBoxKindRu";
            this.rTxtBoxKindRu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rTxtBoxKindRu.Size = new System.Drawing.Size(1073, 80);
            this.rTxtBoxKindRu.TabIndex = 10;
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(3, 120);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(175, 18);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "Введите название вида:";
            // 
            // DataChangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rPanelKindName);
            this.Controls.Add(this.rPanelGroupName);
            this.Controls.Add(this.rDropDownListGroup);
            this.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.MinimumSize = new System.Drawing.Size(670, 400);
            this.Name = "DataChangeControl";
            this.Size = new System.Drawing.Size(1087, 445);
            ((System.ComponentModel.ISupportInitialize)(this.rDropDownListGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameUk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameUk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelGroupName)).EndInit();
            this.rPanelGroupName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLblNameKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxKindUk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPanelKindName)).EndInit();
            this.rPanelKindName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxKindEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTxtBoxKindRu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList rDropDownListGroup;
        private Telerik.WinControls.UI.RadLabel rLblNameUk;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxNameUk;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxKindUk;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxNameEn;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxKindRu;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxNameRu;
        private Telerik.WinControls.UI.RadTextBox rTxtBoxKindEn;
        private Telerik.WinControls.UI.RadPanel rPanelGroupName;
        private Telerik.WinControls.UI.RadLabel rLblNameEn;
        private Telerik.WinControls.UI.RadLabel rLblNameRu;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel rLblNameKind;
        private Telerik.WinControls.UI.RadPanel rPanelKindName;
    }
}
