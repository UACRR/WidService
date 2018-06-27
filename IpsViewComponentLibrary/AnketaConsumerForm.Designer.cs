namespace IpsViewComponentLibrary
{
    partial class AnketaConsumerForm
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
            this.ctrlConsumerAnketa = new IpsViewComponentLibrary.GlobalControlConsumerAnketa();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlConsumerAnketa
            // 
            this.ctrlConsumerAnketa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlConsumerAnketa.IsContainPlaces = false;
            this.ctrlConsumerAnketa.Location = new System.Drawing.Point(0, 0);
            this.ctrlConsumerAnketa.Name = "ctrlConsumerAnketa";
            this.ctrlConsumerAnketa.Size = new System.Drawing.Size(1267, 702);
            this.ctrlConsumerAnketa.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 641);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 41);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Зберегти внесені зміни";
            this.btnSave.TextWrap = true;
            this.btnSave.ThemeName = "Office2007Silver";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(17, 593);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 41);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Скасувати зміни та вийти";
            this.btnCancel.TextWrap = true;
            this.btnCancel.ThemeName = "Office2007Silver";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AnketaConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 702);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlConsumerAnketa);
            this.Name = "AnketaConsumerForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Анкета нового споживача";
            this.ThemeName = "Office2007Silver";
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GlobalControlConsumerAnketa ctrlConsumerAnketa;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
