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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPageViewMain = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPMain = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();
            this.radPVPageDictTest = new Telerik.WinControls.UI.RadPageViewPage();
            this.dataEditControl = new sysAdminwp.DataEditControl();
            this.rPViewPageComDir = new Telerik.WinControls.UI.RadPageViewPage();
            this.rBtnDelete = new Telerik.WinControls.UI.RadButton();
            this.rBtnEditOrSave = new Telerik.WinControls.UI.RadButton();
            this.rBtnAddOrCancel = new Telerik.WinControls.UI.RadButton();
            this.comDirControl = new ipsTestExp.ComDirControl();
            this.ipsAddressControl1 = new IpsViewComponentLibrary.IpsAddressControl();
            ((System.ComponentModel.ISupportInitialize)(this.radPageViewMain)).BeginInit();
            this.radPageViewMain.SuspendLayout();
            this.radPageViewPMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();
            this.radPVPageDictTest.SuspendLayout();
            this.rPViewPageComDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnEditOrSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddOrCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageViewMain
            // 
            this.radPageViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPageViewMain.CausesValidation = false;
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
            this.radPageViewPMain.Controls.Add(this.ipsAddressControl1);
            this.radPageViewPMain.Controls.Add(this.radGridView2);
            this.radPageViewPMain.ItemSize = new System.Drawing.SizeF(59F, 28F);
            this.radPageViewPMain.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPMain.Name = "radPageViewPMain";
            this.radPageViewPMain.Size = new System.Drawing.Size(1151, 566);
            this.radPageViewPMain.Text = "Головна";
            // 
            // radGridView2
            // 
            this.radGridView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.radGridView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGridView2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView2.ForeColor = System.Drawing.Color.Black;
            this.radGridView2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView2.Location = new System.Drawing.Point(0, 0);
            this.radGridView2.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.radGridView2.MasterTemplate.AutoGenerateColumns = false;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "Code";
            gridViewDecimalColumn1.HeaderText = "Code";
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            gridViewDecimalColumn1.MinWidth = 6;
            gridViewDecimalColumn1.Name = "Code";
            gridViewDecimalColumn1.Width = 145;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "ParentCode";
            gridViewDecimalColumn2.HeaderText = "ParentCode";
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            gridViewDecimalColumn2.MinWidth = 6;
            gridViewDecimalColumn2.Name = "ParentCode";
            gridViewDecimalColumn2.Width = 178;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "NameEn";
            gridViewTextBoxColumn1.HeaderText = "NameEn";
            gridViewTextBoxColumn1.MinWidth = 6;
            gridViewTextBoxColumn1.Name = "NameEn";
            gridViewTextBoxColumn1.Width = 509;
            this.radGridView2.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn1});
            this.radGridView2.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView2.Size = new System.Drawing.Size(1151, 321);
            this.radGridView2.TabIndex = 0;
            this.radGridView2.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridView2_CellFormatting);
            // 
            // radPVPageDictTest
            // 
            this.radPVPageDictTest.Controls.Add(this.dataEditControl);
            this.radPVPageDictTest.ItemSize = new System.Drawing.SizeF(79F, 28F);
            this.radPVPageDictTest.Location = new System.Drawing.Point(10, 37);
            this.radPVPageDictTest.Name = "radPVPageDictTest";
            this.radPVPageDictTest.Size = new System.Drawing.Size(1151, 566);
            this.radPVPageDictTest.Text = "Довідники+";
            // 
            // dataEditControl
            // 
            this.dataEditControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataEditControl.Enabled = false;
            this.dataEditControl.Location = new System.Drawing.Point(203, 3);
            this.dataEditControl.Margin = new System.Windows.Forms.Padding(4);
            this.dataEditControl.Name = "dataEditControl";
            this.dataEditControl.Size = new System.Drawing.Size(943, 555);
            this.dataEditControl.TabIndex = 0;
            this.dataEditControl.Url = null;
            // 
            // rPViewPageComDir
            // 
            this.rPViewPageComDir.Controls.Add(this.rBtnDelete);
            this.rPViewPageComDir.Controls.Add(this.rBtnEditOrSave);
            this.rPViewPageComDir.Controls.Add(this.rBtnAddOrCancel);
            this.rPViewPageComDir.Controls.Add(this.comDirControl);
            this.rPViewPageComDir.ItemSize = new System.Drawing.SizeF(116F, 28F);
            this.rPViewPageComDir.Location = new System.Drawing.Point(10, 37);
            this.rPViewPageComDir.Name = "rPViewPageComDir";
            this.rPViewPageComDir.Size = new System.Drawing.Size(1151, 566);
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
            this.rBtnEditOrSave.Location = new System.Drawing.Point(3, 538);
            this.rBtnEditOrSave.Name = "rBtnEditOrSave";
            this.rBtnEditOrSave.Size = new System.Drawing.Size(110, 24);
            this.rBtnEditOrSave.TabIndex = 1;
            this.rBtnEditOrSave.Text = "Змінити";
            this.rBtnEditOrSave.Click += new System.EventHandler(this.rBtnEdit_Click);
            // 
            // rBtnAddOrCancel
            // 
            this.rBtnAddOrCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnAddOrCancel.Location = new System.Drawing.Point(1036, 538);
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
            this.comDirControl.Margin = new System.Windows.Forms.Padding(4);
            this.comDirControl.Name = "comDirControl";
            this.comDirControl.Size = new System.Drawing.Size(1151, 532);
            this.comDirControl.TabIndex = 0;
            this.comDirControl.Url = null;
            // 
            // ipsAddressControl1
            // 
            this.ipsAddressControl1.Location = new System.Drawing.Point(4, 342);
            this.ipsAddressControl1.Name = "ipsAddressControl1";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCity.Location = new System.Drawing.Point(289, 6);
            this.ipsAddressControl1.radDropDownListCity.Name = "radDropDownList2";
            this.ipsAddressControl1.radDropDownListCity.Size = new System.Drawing.Size(349, 20);
            this.ipsAddressControl1.radDropDownListCity.TabIndex = 4;
            this.ipsAddressControl1.radDropDownListCity.Text = "radDropDownList2";
            // 
            // 
            // 
            this.ipsAddressControl1.radDropDownListCountry.Location = new System.Drawing.Point(4, 6);
            this.ipsAddressControl1.radDropDownListCountry.Name = "radDropDownList1";
            this.ipsAddressControl1.radDropDownListCountry.Size = new System.Drawing.Size(268, 20);
            this.ipsAddressControl1.radDropDownListCountry.TabIndex = 3;
            this.ipsAddressControl1.radDropDownListCountry.Text = "radDropDownList1";
            // 
            // 
            // 
            this.ipsAddressControl1.radTextBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipsAddressControl1.radTextBoxAddress.Location = new System.Drawing.Point(4, 35);
            this.ipsAddressControl1.radTextBoxAddress.Name = "radTextBox1";
            this.ipsAddressControl1.radTextBoxAddress.Size = new System.Drawing.Size(1133, 20);
            this.ipsAddressControl1.radTextBoxAddress.TabIndex = 2;
            this.ipsAddressControl1.Size = new System.Drawing.Size(1142, 68);
            this.ipsAddressControl1.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();
            this.radPVPageDictTest.ResumeLayout(false);
            this.rPViewPageComDir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rBtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnEditOrSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnAddOrCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radDropDownListCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipsAddressControl1.radTextBoxAddress)).EndInit();
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
        private Telerik.WinControls.UI.RadGridView radGridView2;
        private IpsViewComponentLibrary.IpsAddressControl ipsAddressControl1;
    }
}

