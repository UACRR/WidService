using System;

namespace IpsViewComponentLibrary
{
    partial class AddCompositionForm
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
            this.dataEntry = new Telerik.WinControls.UI.RadDataEntry();
            this.bsMusicDesign = new System.Windows.Forms.BindingSource(this.components);
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.radTextBox5 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel6 = new Telerik.WinControls.UI.RadPanel();
            this.radTextBox6 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel7 = new Telerik.WinControls.UI.RadPanel();
            this.radTextBox7 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel8 = new Telerik.WinControls.UI.RadPanel();
            this.radTextBox8 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel15 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel9 = new Telerik.WinControls.UI.RadPanel();
            this.radTextBox9 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel17 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataEntry)).BeginInit();
            this.dataEntry.PanelContainer.SuspendLayout();
            this.dataEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMusicDesign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel6)).BeginInit();
            this.radPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel7)).BeginInit();
            this.radPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).BeginInit();
            this.radPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel9)).BeginInit();
            this.radPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dataEntry
            // 
            this.dataEntry.DataSource = this.bsMusicDesign;
            this.dataEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataEntry.Location = new System.Drawing.Point(0, 0);
            this.dataEntry.Name = "dataEntry";
            // 
            // dataEntry.PanelContainer
            // 
            this.dataEntry.PanelContainer.Controls.Add(this.radPanel5);
            this.dataEntry.PanelContainer.Controls.Add(this.radPanel6);
            this.dataEntry.PanelContainer.Controls.Add(this.radPanel7);
            this.dataEntry.PanelContainer.Controls.Add(this.radPanel8);
            this.dataEntry.PanelContainer.Controls.Add(this.radPanel9);
            this.dataEntry.PanelContainer.Size = new System.Drawing.Size(470, 123);
            this.dataEntry.Size = new System.Drawing.Size(472, 125);
            this.dataEntry.TabIndex = 0;
            this.dataEntry.ThemeName = "Office2013Light";
            // 
            // bsMusicDesign
            // 
            this.bsMusicDesign.DataSource = typeof(ipsFormsDesign.Model.MusicalDesign);
            // 
            // radPanel5
            // 
            this.radPanel5.Controls.Add(this.radTextBox5);
            this.radPanel5.Controls.Add(this.radLabel9);
            this.radPanel5.Controls.Add(this.radLabel10);
            this.radPanel5.Location = new System.Drawing.Point(11, 11);
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.Size = new System.Drawing.Size(448, 22);
            this.radPanel5.TabIndex = 4;
            // 
            // radTextBox5
            // 
            this.radTextBox5.AutoSize = false;
            this.radTextBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMusicDesign, "ObjName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radTextBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBox5.Location = new System.Drawing.Point(106, 0);
            this.radTextBox5.Name = "radTextBox5";
            this.radTextBox5.Size = new System.Drawing.Size(340, 22);
            this.radTextBox5.TabIndex = 5;
            this.radTextBox5.ThemeName = "Office2013Light";
            // 
            // radLabel9
            // 
            this.radLabel9.AutoSize = false;
            this.radLabel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.radLabel9.Location = new System.Drawing.Point(0, 0);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(106, 22);
            this.radLabel9.TabIndex = 6;
            this.radLabel9.Text = "Назва твору";
            this.radLabel9.TextWrap = false;
            this.radLabel9.ThemeName = "Office2013Light";
            // 
            // radLabel10
            // 
            this.radLabel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel10.Location = new System.Drawing.Point(446, 0);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(2, 22);
            this.radLabel10.TabIndex = 7;
            this.radLabel10.TextWrap = false;
            // 
            // radPanel6
            // 
            this.radPanel6.Controls.Add(this.radTextBox6);
            this.radPanel6.Controls.Add(this.radLabel11);
            this.radPanel6.Controls.Add(this.radLabel12);
            this.radPanel6.Location = new System.Drawing.Point(11, 38);
            this.radPanel6.Name = "radPanel6";
            this.radPanel6.Size = new System.Drawing.Size(448, 22);
            this.radPanel6.TabIndex = 5;
            // 
            // radTextBox6
            // 
            this.radTextBox6.AutoSize = false;
            this.radTextBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMusicDesign, "NameMusician", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radTextBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBox6.Location = new System.Drawing.Point(106, 0);
            this.radTextBox6.Name = "radTextBox6";
            this.radTextBox6.Size = new System.Drawing.Size(340, 22);
            this.radTextBox6.TabIndex = 6;
            this.radTextBox6.ThemeName = "Office2013Light";
            // 
            // radLabel11
            // 
            this.radLabel11.AutoSize = false;
            this.radLabel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.radLabel11.Location = new System.Drawing.Point(0, 0);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(106, 22);
            this.radLabel11.TabIndex = 7;
            this.radLabel11.Text = "ПІБ композитора";
            this.radLabel11.TextWrap = false;
            this.radLabel11.ThemeName = "Office2013Light";
            // 
            // radLabel12
            // 
            this.radLabel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel12.Location = new System.Drawing.Point(446, 0);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(2, 22);
            this.radLabel12.TabIndex = 8;
            this.radLabel12.TextWrap = false;
            // 
            // radPanel7
            // 
            this.radPanel7.Controls.Add(this.radTextBox7);
            this.radPanel7.Controls.Add(this.radLabel13);
            this.radPanel7.Controls.Add(this.radLabel14);
            this.radPanel7.Location = new System.Drawing.Point(11, 65);
            this.radPanel7.Name = "radPanel7";
            this.radPanel7.Size = new System.Drawing.Size(448, 22);
            this.radPanel7.TabIndex = 6;
            // 
            // radTextBox7
            // 
            this.radTextBox7.AutoSize = false;
            this.radTextBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMusicDesign, "NameSinger", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radTextBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBox7.Location = new System.Drawing.Point(106, 0);
            this.radTextBox7.Name = "radTextBox7";
            this.radTextBox7.Size = new System.Drawing.Size(340, 22);
            this.radTextBox7.TabIndex = 7;
            this.radTextBox7.ThemeName = "Office2013Light";
            // 
            // radLabel13
            // 
            this.radLabel13.AutoSize = false;
            this.radLabel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.radLabel13.Location = new System.Drawing.Point(0, 0);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(106, 22);
            this.radLabel13.TabIndex = 8;
            this.radLabel13.Text = "ПІБ виконавця";
            this.radLabel13.TextWrap = false;
            this.radLabel13.ThemeName = "Office2013Light";
            // 
            // radLabel14
            // 
            this.radLabel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel14.Location = new System.Drawing.Point(446, 0);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(2, 22);
            this.radLabel14.TabIndex = 9;
            this.radLabel14.TextWrap = false;
            // 
            // radPanel8
            // 
            this.radPanel8.Controls.Add(this.radTextBox8);
            this.radPanel8.Controls.Add(this.radLabel15);
            this.radPanel8.Controls.Add(this.radLabel16);
            this.radPanel8.Location = new System.Drawing.Point(11, 92);
            this.radPanel8.Name = "radPanel8";
            this.radPanel8.Size = new System.Drawing.Size(202, 22);
            this.radPanel8.TabIndex = 7;
            // 
            // radTextBox8
            // 
            this.radTextBox8.AutoSize = false;
            this.radTextBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMusicDesign, "NumbPerfom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radTextBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBox8.Location = new System.Drawing.Point(118, 0);
            this.radTextBox8.Name = "radTextBox8";
            this.radTextBox8.Size = new System.Drawing.Size(82, 22);
            this.radTextBox8.TabIndex = 8;
            this.radTextBox8.ThemeName = "Office2013Light";
            // 
            // radLabel15
            // 
            this.radLabel15.AutoSize = false;
            this.radLabel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.radLabel15.Location = new System.Drawing.Point(0, 0);
            this.radLabel15.Name = "radLabel15";
            this.radLabel15.Size = new System.Drawing.Size(118, 22);
            this.radLabel15.TabIndex = 9;
            this.radLabel15.Text = "Кількість виконань";
            this.radLabel15.TextWrap = false;
            this.radLabel15.ThemeName = "Office2013Light";
            // 
            // radLabel16
            // 
            this.radLabel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel16.Location = new System.Drawing.Point(200, 0);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(2, 22);
            this.radLabel16.TabIndex = 10;
            this.radLabel16.TextWrap = false;
            // 
            // radPanel9
            // 
            this.radPanel9.Controls.Add(this.radTextBox9);
            this.radPanel9.Controls.Add(this.radLabel17);
            this.radPanel9.Controls.Add(this.radLabel18);
            this.radPanel9.Location = new System.Drawing.Point(211, 92);
            this.radPanel9.Name = "radPanel9";
            this.radPanel9.Size = new System.Drawing.Size(248, 22);
            this.radPanel9.TabIndex = 8;
            // 
            // radTextBox9
            // 
            this.radTextBox9.AutoSize = false;
            this.radTextBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMusicDesign, "Duration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, new TimeSpan(0,00,00,01)));
            this.radTextBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBox9.Location = new System.Drawing.Point(152, 0);
            this.radTextBox9.Name = "radTextBox9";
            this.radTextBox9.Size = new System.Drawing.Size(94, 22);
            this.radTextBox9.TabIndex = 9;
            this.radTextBox9.ThemeName = "Office2013Light";
            // 
            // radLabel17
            // 
            this.radLabel17.AutoSize = false;
            this.radLabel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.radLabel17.Location = new System.Drawing.Point(0, 0);
            this.radLabel17.Name = "radLabel17";
            this.radLabel17.Size = new System.Drawing.Size(152, 22);
            this.radLabel17.TabIndex = 10;
            this.radLabel17.Text = "Тривалість звучання (хв)";
            this.radLabel17.TextWrap = false;
            this.radLabel17.ThemeName = "Office2013Light";
            // 
            // radLabel18
            // 
            this.radLabel18.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel18.Location = new System.Drawing.Point(246, 0);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(2, 22);
            this.radLabel18.TabIndex = 11;
            this.radLabel18.TextWrap = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Додати";
            this.btnSave.ThemeName = "Office2013Light";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(350, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.ThemeName = "Office2013Light";
            // 
            // AddCompositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 179);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataEntry);
            this.MaximumSize = new System.Drawing.Size(480, 210);
            this.MinimumSize = new System.Drawing.Size(480, 210);
            this.Name = "AddCompositionForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(480, 210);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Додати музичний твір";
            this.ThemeName = "Office2013Light";
            this.dataEntry.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataEntry)).EndInit();
            this.dataEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsMusicDesign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel6)).EndInit();
            this.radPanel6.ResumeLayout(false);
            this.radPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel7)).EndInit();
            this.radPanel7.ResumeLayout(false);
            this.radPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel8)).EndInit();
            this.radPanel8.ResumeLayout(false);
            this.radPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel9)).EndInit();
            this.radPanel9.ResumeLayout(false);
            this.radPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme;
        private Telerik.WinControls.UI.RadDataEntry dataEntry;
        private System.Windows.Forms.BindingSource bsMusicDesign;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.RadTextBox radTextBox5;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadPanel radPanel6;
        private Telerik.WinControls.UI.RadTextBox radTextBox6;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private Telerik.WinControls.UI.RadPanel radPanel7;
        private Telerik.WinControls.UI.RadTextBox radTextBox7;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadPanel radPanel8;
        private Telerik.WinControls.UI.RadTextBox radTextBox8;
        private Telerik.WinControls.UI.RadLabel radLabel15;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private Telerik.WinControls.UI.RadPanel radPanel9;
        private Telerik.WinControls.UI.RadTextBox radTextBox9;
        private Telerik.WinControls.UI.RadLabel radLabel17;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
