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
            this.windows8Theme = new Telerik.WinControls.Themes.Windows8Theme();
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // rGViewComDir
            // 
            this.rGViewComDir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGViewComDir.AutoSizeRows = true;
            this.rGViewComDir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rGViewComDir.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.rGViewComDir.MasterTemplate.AllowAddNewRow = false;
            this.rGViewComDir.MasterTemplate.AllowColumnReorder = false;
            this.rGViewComDir.MasterTemplate.AllowDeleteRow = false;
            this.rGViewComDir.MasterTemplate.AllowDragToGroup = false;
            this.rGViewComDir.MasterTemplate.AllowEditRow = false;
            this.rGViewComDir.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.rGViewComDir.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rGViewComDir.Name = "rGViewComDir";
            this.rGViewComDir.ReadOnly = true;
            this.rGViewComDir.Size = new System.Drawing.Size(766, 490);
            this.rGViewComDir.TabIndex = 0;
            this.rGViewComDir.ThemeName = "Windows8";
            // 
            // ComDirControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.rGViewComDir);
            this.Name = "ComDirControl";
            this.Size = new System.Drawing.Size(772, 496);
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGViewComDir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rGViewComDir;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme;
    }
}
