
namespace IpsViewComponentLibrary.ConsumerControls.Calculation
{
    partial class ChangePeriodAmount
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
            this.office2013LightTheme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOldAmount = new System.Windows.Forms.RichTextBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNewAmount = new System.Windows.Forms.RichTextBox();
            this.saveCancel = new IpsViewComponentLibrary.Common.SaveCancelButtonsControl();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.522F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.478F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOldAmount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNewAmount, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(461, 109);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поточна сума вимоги";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Нова сума вимоги:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOldAmount
            // 
            this.txtOldAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OldAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.txtOldAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOldAmount.Location = new System.Drawing.Point(147, 18);
            this.txtOldAmount.Multiline = false;
            this.txtOldAmount.Name = "txtOldAmount";
            this.txtOldAmount.ReadOnly = true;
            this.txtOldAmount.Size = new System.Drawing.Size(188, 24);
            this.txtOldAmount.TabIndex = 2;
            this.txtOldAmount.Text = "";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(ipsFormsDesign.CustomModel.ChangePeriodAmountModel);
            // 
            // txtNewAmount
            // 
            this.txtNewAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NewAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.txtNewAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewAmount.Location = new System.Drawing.Point(147, 58);
            this.txtNewAmount.Multiline = false;
            this.txtNewAmount.Name = "txtNewAmount";
            this.txtNewAmount.Size = new System.Drawing.Size(188, 24);
            this.txtNewAmount.TabIndex = 3;
            this.txtNewAmount.Text = "";
            this.txtNewAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewAmount_Validating);
            // 
            // saveCancel
            // 
            this.saveCancel.ButtonSaveDialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveCancel.Location = new System.Drawing.Point(0, 109);
            this.saveCancel.MaximumSize = new System.Drawing.Size(3000, 31);
            this.saveCancel.MinimumSize = new System.Drawing.Size(300, 31);
            this.saveCancel.Name = "saveCancel";
            this.saveCancel.SaveButtonEnabled = true;
            this.saveCancel.Size = new System.Drawing.Size(461, 31);
            this.saveCancel.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ChangePeriodAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(461, 140);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.saveCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePeriodAmount";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Змінити суму вимоги періода";
            this.ThemeName = "Office2013Light";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtOldAmount;
        private System.Windows.Forms.RichTextBox txtNewAmount;
        private Common.SaveCancelButtonsControl saveCancel;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}