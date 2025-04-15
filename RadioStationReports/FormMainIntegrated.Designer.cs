using System.Drawing;
using System.Windows.Forms;

namespace RadioStationReports
{
    partial class FormMainIntegrated
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
            panelMain = new TabControl();
            tabPage2 = new TabPage();
            ucRegisteredReports = new UcRegisteredReports();
            tabPage1 = new TabPage();
            ucMainIntegrated = new UcMainIntegrated();
            panelMain.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(tabPage1);
            panelMain.Controls.Add(tabPage2);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.SelectedIndex = 0;
            panelMain.Size = new Size(959, 486);
            panelMain.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(ucRegisteredReports);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(951, 458);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Зареєстровані звіти";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucRegisteredReports
            // 
            ucRegisteredReports.Dock = DockStyle.Fill;
            ucRegisteredReports.Location = new Point(3, 3);
            ucRegisteredReports.Name = "ucRegisteredReports";
            ucRegisteredReports.Size = new Size(945, 452);
            ucRegisteredReports.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ucMainIntegrated);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(951, 458);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Пошук/Реєстрація Звітів";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucMainIntegrated
            // 
            ucMainIntegrated.Dock = DockStyle.Fill;
            ucMainIntegrated.Location = new Point(3, 3);
            ucMainIntegrated.Name = "ucMainIntegrated";
            ucMainIntegrated.Size = new Size(945, 452);
            ucMainIntegrated.TabIndex = 0;
            // 
            // FormMainIntegrated
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 486);
            Controls.Add(panelMain);
            Name = "FormMainIntegrated";
            Text = "Звіти користувачів";
            Load += FormMainIntegrated_Load;
            panelMain.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl panelMain;
        private TabPage tabPage1;
        private UcMainIntegrated ucMainIntegrated;
        private TabPage tabPage2;
        private UcRegisteredReports ucRegisteredReports;
    }
}