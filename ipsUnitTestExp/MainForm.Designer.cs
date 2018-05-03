using System.Drawing;
using sysAdminwp;

namespace ipsTestExp
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPageViewMain = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPMain = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPVPageDictTest = new Telerik.WinControls.UI.RadPageViewPage();
            this.dataEditControl = new sysAdminwp.DataEditControl();
            this.rPViewPageComDir = new Telerik.WinControls.UI.RadPageViewPage();
            this.rBtnDelete = new Telerik.WinControls.UI.RadButton();
            this.rBtnEditOrSave = new Telerik.WinControls.UI.RadButton();
            this.rBtnAddOrCancel = new Telerik.WinControls.UI.RadButton();
            this.comDirControl = new ipsTestExp.ComDirControl();
            this.radGridViewSelfRef = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewMain)).BeginInit();
            this.radPageViewMain.SuspendLayout();
            this.radPageViewPMain.SuspendLayout();
            this.radPVPageDictTest.SuspendLayout();
            this.rPViewPageComDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnEditOrSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddOrCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSelfRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSelfRef.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageViewMain
            // 
            this.radPageViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageViewMain.Controls.Add(this.radPageViewPMain);
            this.radPageViewMain.Controls.Add(this.radPVPageDictTest);
            this.radPageViewMain.Controls.Add(this.rPViewPageComDir);
            this.radPageViewMain.DefaultPage = this.radPageViewPMain;
            this.radPageViewMain.Location = new System.Drawing.Point(-2, 2);
            this.radPageViewMain.Name = "radPageViewMain";
            this.radPageViewMain.SelectedPage = this.radPageViewPMain;
            this.radPageViewMain.Size = new System.Drawing.Size(1172, 614);
            this.radPageViewMain.TabIndex = 0;
            this.radPageViewMain.ThemeName = "ControlDefault";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageViewMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPMain
            // 
            this.radPageViewPMain.Controls.Add(this.radGridViewSelfRef);
            this.radPageViewPMain.ItemSize = new System.Drawing.SizeF(55F, 24F);
            this.radPageViewPMain.Location = new System.Drawing.Point(10, 33);
            this.radPageViewPMain.Name = "radPageViewPMain";
            this.radPageViewPMain.Size = new System.Drawing.Size(1151, 570);
            this.radPageViewPMain.Text = "Головна";
            // 
            // radPVPageDictTest
            // 
            this.radPVPageDictTest.Controls.Add(this.dataEditControl);
            this.radPVPageDictTest.ItemSize = new System.Drawing.SizeF(75F, 24F);
            this.radPVPageDictTest.Location = new System.Drawing.Point(10, 33);
            this.radPVPageDictTest.Name = "radPVPageDictTest";
            this.radPVPageDictTest.Size = new System.Drawing.Size(1151, 570);
            this.radPVPageDictTest.Text = "Довідники+";
            // 
            // dataEditControl
            // 
            this.dataEditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataEditControl.Enabled = false;
            this.dataEditControl.Location = new System.Drawing.Point(203, 3);
            this.dataEditControl.Name = "dataEditControl";
            this.dataEditControl.Size = new System.Drawing.Size(943, 559);
            this.dataEditControl.TabIndex = 0;
            this.dataEditControl.Url = null;
            // 
            // rPViewPageComDir
            // 
            this.rPViewPageComDir.Controls.Add(this.rBtnDelete);
            this.rPViewPageComDir.Controls.Add(this.rBtnEditOrSave);
            this.rPViewPageComDir.Controls.Add(this.rBtnAddOrCancel);
            this.rPViewPageComDir.Controls.Add(this.comDirControl);
            this.rPViewPageComDir.ItemSize = new System.Drawing.SizeF(112F, 24F);
            this.rPViewPageComDir.Location = new System.Drawing.Point(10, 33);
            this.rPViewPageComDir.Name = "rPViewPageComDir";
            this.rPViewPageComDir.Size = new System.Drawing.Size(1151, 570);
            this.rPViewPageComDir.Text = "Складний довідник";
            // 
            // rBtnDelete
            // 
            this.rBtnDelete.Location = new System.Drawing.Point(129, 538);
            this.rBtnDelete.Name = "rBtnDelete";
            this.rBtnDelete.Size = new System.Drawing.Size(110, 24);
            this.rBtnDelete.TabIndex = 3;
            this.rBtnDelete.Text = "radButton1";
            // 
            // rBtnEditOrSave
            // 
            this.rBtnEditOrSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnEditOrSave.Location = new System.Drawing.Point(3, 542);
            this.rBtnEditOrSave.Name = "rBtnEditOrSave";
            this.rBtnEditOrSave.Size = new System.Drawing.Size(110, 24);
            this.rBtnEditOrSave.TabIndex = 1;
            this.rBtnEditOrSave.Text = "Змінити";
            this.rBtnEditOrSave.Click += new System.EventHandler(this.rBtnEdit_Click);
            // 
            // rBtnAddOrCancel
            // 
            this.rBtnAddOrCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnAddOrCancel.Location = new System.Drawing.Point(1036, 542);
            this.rBtnAddOrCancel.Name = "rBtnAddOrCancel";
            this.rBtnAddOrCancel.Size = new System.Drawing.Size(110, 24);
            this.rBtnAddOrCancel.TabIndex = 2;
            this.rBtnAddOrCancel.Text = "Додати";
            this.rBtnAddOrCancel.Click += new System.EventHandler(this.rBtnAdd_Click);
            // 
            // comDirControl
            // 
            this.comDirControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comDirControl.BackColor = System.Drawing.Color.Linen;
            this.comDirControl.Location = new System.Drawing.Point(0, 0);
            this.comDirControl.Name = "comDirControl";
            this.comDirControl.Size = new System.Drawing.Size(1151, 536);
            this.comDirControl.TabIndex = 0;
            this.comDirControl.Url = null;
            // 
            // radGridViewSelfRef
            // 
            this.radGridViewSelfRef.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGridViewSelfRef.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridViewSelfRef.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridViewSelfRef.Name = "radGridViewSelfRef";
            this.radGridViewSelfRef.Size = new System.Drawing.Size(1151, 318);
            this.radGridViewSelfRef.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 613);
            this.Controls.Add(this.radPageViewMain);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "IPS";
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewMain)).EndInit();
            this.radPageViewMain.ResumeLayout(false);
            this.radPageViewPMain.ResumeLayout(false);
            this.radPVPageDictTest.ResumeLayout(false);
            this.rPViewPageComDir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rBtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnEditOrSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddOrCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSelfRef.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSelfRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitializeDataChangeControl()
        {
                    this.dataChangeControl = new ipsTestExp.DataChangeControl();
                    this.dataChangeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                                           | System.Windows.Forms.AnchorStyles.Left)
                                                                                          | System.Windows.Forms.AnchorStyles.Right)));
                    this.dataChangeControl.BackColor = System.Drawing.Color.Linen;
                    this.dataChangeControl.Location = new System.Drawing.Point(0, 0);
                    this.dataChangeControl.Name = "comDirControl";

                    this.dataChangeControl.Size = new System.Drawing.Size(rPViewPageComDir.Size.Width, rPViewPageComDir.Size.Height - 30);
                    this.dataChangeControl.TabIndex = 0;
                    this.dataChangeControl.VisibleDropBox = true;

                    this.rPViewPageComDir.Controls.Add(this.dataChangeControl);
        }


        #endregion

        private Telerik.WinControls.UI.RadPageView radPageViewMain;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPMain;
        private Telerik.WinControls.UI.RadPageViewPage radPVPageDictTest;
        private sysAdminwp.DataEditControl dataEditControl;
        private Telerik.WinControls.UI.RadPageViewPage rPViewPageComDir;
        private ComDirControl comDirControl;
        private Telerik.WinControls.UI.RadButton rBtnAddOrCancel;
        private Telerik.WinControls.UI.RadButton rBtnEditOrSave;
        private DataChangeControl dataChangeControl;
        private Telerik.WinControls.UI.RadButton rBtnDelete;
        private Telerik.WinControls.UI.RadGridView radGridViewSelfRef;
    }
}

