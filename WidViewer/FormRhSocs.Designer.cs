
namespace WidViewer
{
    partial class FormRhSocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRhSocs));
            this.зфтудЬфшт = new System.Windows.Forms.TableLayoutPanel();
            this.panelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvSocs = new System.Windows.Forms.ListView();
            this.SocId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rgt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TisNr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tisan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.Shr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.зфтудЬфшт.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // зфтудЬфшт
            // 
            this.зфтудЬфшт.ColumnCount = 1;
            this.зфтудЬфшт.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.зфтудЬфшт.Controls.Add(this.panelBottom, 0, 1);
            this.зфтудЬфшт.Controls.Add(this.lvSocs, 0, 0);
            this.зфтудЬфшт.Dock = System.Windows.Forms.DockStyle.Fill;
            this.зфтудЬфшт.Location = new System.Drawing.Point(0, 0);
            this.зфтудЬфшт.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.зфтудЬфшт.Name = "зфтудЬфшт";
            this.зфтудЬфшт.RowCount = 2;
            this.зфтудЬфшт.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.зфтудЬфшт.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.зфтудЬфшт.Size = new System.Drawing.Size(557, 314);
            this.зфтудЬфшт.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.ColumnCount = 2;
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.panelBottom.Controls.Add(this.btnClose, 1, 0);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 269);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.RowCount = 1;
            this.panelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottom.Size = new System.Drawing.Size(551, 41);
            this.panelBottom.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(443, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvSocs
            // 
            this.lvSocs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SocId,
            this.Shr,
            this.CreClass,
            this.Rol,
            this.Rgt,
            this.TisNr,
            this.Tisan});
            this.lvSocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSocs.FullRowSelect = true;
            this.lvSocs.GridLines = true;
            this.lvSocs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSocs.HideSelection = false;
            this.lvSocs.Location = new System.Drawing.Point(3, 4);
            this.lvSocs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvSocs.Name = "lvSocs";
            this.lvSocs.Size = new System.Drawing.Size(551, 257);
            this.lvSocs.TabIndex = 1;
            this.lvSocs.UseCompatibleStateImageBehavior = false;
            this.lvSocs.View = System.Windows.Forms.View.Details;
            // 
            // SocId
            // 
            this.SocId.Text = "Код товариства";
            this.SocId.Width = 120;
            // 
            // CreClass
            // 
            this.CreClass.Text = "Класс";
            // 
            // Rol
            // 
            this.Rol.Text = "Роль";
            // 
            // Rgt
            // 
            this.Rgt.Text = "Тип права";
            this.Rgt.Width = 87;
            // 
            // TisNr
            // 
            this.TisNr.Text = "Тісан-Код";
            this.TisNr.Width = 84;
            // 
            // Tisan
            // 
            this.Tisan.Text = "Тісан";
            this.Tisan.Width = 49;
            // 
            // timerLoad
            // 
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // Shr
            // 
            this.Shr.Text = "Процент";
            this.Shr.Width = 76;
            // 
            // FormRhSocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 314);
            this.ControlBox = false;
            this.Controls.Add(this.зфтудЬфшт);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRhSocs";
            this.ShowInTaskbar = false;
            this.Text = "Товариства правовласника";
            this.Load += new System.EventHandler(this.FormRhSocs_Load);
            this.зфтудЬфшт.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel зфтудЬфшт;
        private System.Windows.Forms.TableLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvSocs;
        private System.Windows.Forms.ColumnHeader SocId;
        private System.Windows.Forms.ColumnHeader CreClass;
        private System.Windows.Forms.ColumnHeader Rol;
        private System.Windows.Forms.ColumnHeader Rgt;
        private System.Windows.Forms.ColumnHeader TisNr;
        private System.Windows.Forms.ColumnHeader Tisan;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.ColumnHeader Shr;
    }
}