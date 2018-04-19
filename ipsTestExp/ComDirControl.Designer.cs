namespace ipsTestExp
{
    partial class ComDirControl
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rGViewComDir = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rGViewComDir
            // 
            this.rGViewComDir.Location = new System.Drawing.Point(74, 18);
            // 
            // 
            // 
            this.rGViewComDir.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rGViewComDir.Name = "rGViewComDir";
            this.rGViewComDir.Size = new System.Drawing.Size(593, 433);
            this.rGViewComDir.TabIndex = 0;
            // 
            // ComDirControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rGViewComDir);
            this.Name = "ComDirControl";
            this.Size = new System.Drawing.Size(837, 539);
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rGViewComDir;
    }
}
