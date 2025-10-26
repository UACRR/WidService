namespace CwrTools
{
    partial class FormRightHolderRoles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRightHolderRoles));
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateInfoInDb = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.rbFilterAll = new System.Windows.Forms.RadioButton();
            this.rbFilterAuthors = new System.Windows.Forms.RadioButton();
            this.rbFilterPublishers = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFilterNameText = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.lvRightHolders = new System.Windows.Forms.ListView();
            this.panelChangeType = new System.Windows.Forms.TableLayoutPanel();
            this.panelNewType = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSetRightHolderType = new System.Windows.Forms.Button();
            this.panelRoles = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSetRoleCA = new System.Windows.Forms.Button();
            this.btnSetRoleE = new System.Windows.Forms.Button();
            this.btnSetRoleAR = new System.Windows.Forms.Button();
            this.btnSetRoleC = new System.Windows.Forms.Button();
            this.btnSetRoleA = new System.Windows.Forms.Button();
            this.btnSetRoleU = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCntU = new System.Windows.Forms.TextBox();
            this.tbCntA = new System.Windows.Forms.TextBox();
            this.tbCntC = new System.Windows.Forms.TextBox();
            this.tbCntAR = new System.Windows.Forms.TextBox();
            this.tbCntE = new System.Windows.Forms.TextBox();
            this.tbCntCA = new System.Windows.Forms.TextBox();
            this.tbCntERR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ilStatuses = new System.Windows.Forms.ImageList(this.components);
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelChangeType.SuspendLayout();
            this.panelNewType.SuspendLayout();
            this.panelRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 2;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMain.Controls.Add(this.panelTop, 0, 0);
            this.panelMain.Controls.Add(this.panelFilter, 0, 1);
            this.panelMain.Controls.Add(this.label3, 0, 2);
            this.panelMain.Controls.Add(this.panelMiddle, 0, 4);
            this.panelMain.Controls.Add(this.label4, 0, 3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 6;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelMain.Size = new System.Drawing.Size(944, 536);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.ColumnCount = 3;
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.panelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Controls.Add(this.label1, 0, 0);
            this.panelTop.Controls.Add(this.btnCreateInfoInDb, 1, 0);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.RowCount = 1;
            this.panelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTop.Size = new System.Drawing.Size(933, 33);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Правовласники що мають неузгоджені ролі";
            // 
            // btnCreateInfoInDb
            // 
            this.btnCreateInfoInDb.Location = new System.Drawing.Point(250, 3);
            this.btnCreateInfoInDb.Name = "btnCreateInfoInDb";
            this.btnCreateInfoInDb.Size = new System.Drawing.Size(128, 23);
            this.btnCreateInfoInDb.TabIndex = 1;
            this.btnCreateInfoInDb.Text = "Оновити перелік";
            this.btnCreateInfoInDb.UseVisualStyleBackColor = true;
            this.btnCreateInfoInDb.Click += new System.EventHandler(this.btnCreateInfoInDb_Click);
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.rbFilterAll);
            this.panelFilter.Controls.Add(this.rbFilterAuthors);
            this.panelFilter.Controls.Add(this.rbFilterPublishers);
            this.panelFilter.Controls.Add(this.label5);
            this.panelFilter.Controls.Add(this.tbFilterNameText);
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 42);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(933, 32);
            this.panelFilter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Показати";
            // 
            // rbFilterAll
            // 
            this.rbFilterAll.AutoSize = true;
            this.rbFilterAll.Location = new System.Drawing.Point(65, 6);
            this.rbFilterAll.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.rbFilterAll.Name = "rbFilterAll";
            this.rbFilterAll.Size = new System.Drawing.Size(127, 17);
            this.rbFilterAll.TabIndex = 1;
            this.rbFilterAll.TabStop = true;
            this.rbFilterAll.Text = "всіх правовласників";
            this.rbFilterAll.UseVisualStyleBackColor = true;
            // 
            // rbFilterAuthors
            // 
            this.rbFilterAuthors.AutoSize = true;
            this.rbFilterAuthors.Location = new System.Drawing.Point(198, 6);
            this.rbFilterAuthors.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.rbFilterAuthors.Name = "rbFilterAuthors";
            this.rbFilterAuthors.Size = new System.Drawing.Size(91, 17);
            this.rbFilterAuthors.TabIndex = 1;
            this.rbFilterAuthors.TabStop = true;
            this.rbFilterAuthors.Text = "лише авторів";
            this.rbFilterAuthors.UseVisualStyleBackColor = true;
            // 
            // rbFilterPublishers
            // 
            this.rbFilterPublishers.AutoSize = true;
            this.rbFilterPublishers.Location = new System.Drawing.Point(295, 6);
            this.rbFilterPublishers.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.rbFilterPublishers.Name = "rbFilterPublishers";
            this.rbFilterPublishers.Size = new System.Drawing.Size(98, 17);
            this.rbFilterPublishers.TabIndex = 1;
            this.rbFilterPublishers.TabStop = true;
            this.rbFilterPublishers.Text = "лише видавців";
            this.rbFilterPublishers.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "де назва містить текст";
            // 
            // tbFilterNameText
            // 
            this.tbFilterNameText.Location = new System.Drawing.Point(529, 3);
            this.tbFilterNameText.Name = "tbFilterNameText";
            this.tbFilterNameText.Size = new System.Drawing.Size(100, 20);
            this.tbFilterNameText.TabIndex = 4;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(635, 3);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(98, 23);
            this.btnApplyFilter.TabIndex = 2;
            this.btnApplyFilter.Text = "Застосувати";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(318, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Скорочення для типу правовласника: A  - автор, E - видавець";
            // 
            // panelMiddle
            // 
            this.panelMiddle.ColumnCount = 3;
            this.panelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.panelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panelMiddle.Controls.Add(this.lvRightHolders, 0, 0);
            this.panelMiddle.Controls.Add(this.panelChangeType, 1, 0);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(3, 134);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.RowCount = 1;
            this.panelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMiddle.Size = new System.Drawing.Size(933, 390);
            this.panelMiddle.TabIndex = 6;
            // 
            // lvRightHolders
            // 
            this.lvRightHolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRightHolders.HideSelection = false;
            this.lvRightHolders.Location = new System.Drawing.Point(3, 3);
            this.lvRightHolders.Name = "lvRightHolders";
            this.lvRightHolders.Size = new System.Drawing.Size(660, 384);
            this.lvRightHolders.TabIndex = 1;
            this.lvRightHolders.UseCompatibleStateImageBehavior = false;
            this.lvRightHolders.SelectedIndexChanged += new System.EventHandler(this.lvRightHolders_SelectedIndexChanged);
            // 
            // panelChangeType
            // 
            this.panelChangeType.ColumnCount = 1;
            this.panelChangeType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelChangeType.Controls.Add(this.panelNewType, 0, 0);
            this.panelChangeType.Controls.Add(this.panelRoles, 0, 1);
            this.panelChangeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChangeType.Location = new System.Drawing.Point(669, 3);
            this.panelChangeType.Name = "panelChangeType";
            this.panelChangeType.RowCount = 3;
            this.panelChangeType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.panelChangeType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelChangeType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelChangeType.Size = new System.Drawing.Size(256, 384);
            this.panelChangeType.TabIndex = 2;
            // 
            // panelNewType
            // 
            this.panelNewType.Controls.Add(this.label9);
            this.panelNewType.Controls.Add(this.btnSetRightHolderType);
            this.panelNewType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNewType.Location = new System.Drawing.Point(3, 3);
            this.panelNewType.Name = "panelNewType";
            this.panelNewType.Size = new System.Drawing.Size(250, 32);
            this.panelNewType.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Змінити тип правовласника на";
            // 
            // btnSetRightHolderType
            // 
            this.btnSetRightHolderType.Location = new System.Drawing.Point(172, 3);
            this.btnSetRightHolderType.Name = "btnSetRightHolderType";
            this.btnSetRightHolderType.Size = new System.Drawing.Size(34, 23);
            this.btnSetRightHolderType.TabIndex = 2;
            this.btnSetRightHolderType.Text = "A";
            this.btnSetRightHolderType.UseVisualStyleBackColor = true;
            this.btnSetRightHolderType.Click += new System.EventHandler(this.setRightHolderType_Click);
            // 
            // panelRoles
            // 
            this.panelRoles.ColumnCount = 4;
            this.panelRoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.panelRoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.panelRoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.panelRoles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.panelRoles.Controls.Add(this.label13, 0, 1);
            this.panelRoles.Controls.Add(this.label14, 0, 2);
            this.panelRoles.Controls.Add(this.btnSetRoleCA, 2, 6);
            this.panelRoles.Controls.Add(this.btnSetRoleE, 2, 5);
            this.panelRoles.Controls.Add(this.btnSetRoleAR, 2, 4);
            this.panelRoles.Controls.Add(this.btnSetRoleC, 2, 3);
            this.panelRoles.Controls.Add(this.btnSetRoleA, 2, 2);
            this.panelRoles.Controls.Add(this.btnSetRoleU, 2, 1);
            this.panelRoles.Controls.Add(this.label15, 0, 3);
            this.panelRoles.Controls.Add(this.label16, 0, 4);
            this.panelRoles.Controls.Add(this.label17, 0, 5);
            this.panelRoles.Controls.Add(this.label18, 0, 6);
            this.panelRoles.Controls.Add(this.label19, 0, 7);
            this.panelRoles.Controls.Add(this.label10, 0, 0);
            this.panelRoles.Controls.Add(this.label11, 1, 0);
            this.panelRoles.Controls.Add(this.label12, 2, 0);
            this.panelRoles.Controls.Add(this.tbCntU, 1, 1);
            this.panelRoles.Controls.Add(this.tbCntA, 1, 2);
            this.panelRoles.Controls.Add(this.tbCntC, 1, 3);
            this.panelRoles.Controls.Add(this.tbCntAR, 1, 4);
            this.panelRoles.Controls.Add(this.tbCntE, 1, 5);
            this.panelRoles.Controls.Add(this.tbCntCA, 1, 6);
            this.panelRoles.Controls.Add(this.tbCntERR, 1, 7);
            this.panelRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoles.Location = new System.Drawing.Point(3, 41);
            this.panelRoles.Name = "panelRoles";
            this.panelRoles.RowCount = 10;
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelRoles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRoles.Size = new System.Drawing.Size(250, 332);
            this.panelRoles.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 35);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "U";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 67);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "A";
            // 
            // btnSetRoleCA
            // 
            this.btnSetRoleCA.Location = new System.Drawing.Point(149, 195);
            this.btnSetRoleCA.Name = "btnSetRoleCA";
            this.btnSetRoleCA.Size = new System.Drawing.Size(34, 23);
            this.btnSetRoleCA.TabIndex = 2;
            this.btnSetRoleCA.Text = "CA";
            this.btnSetRoleCA.UseVisualStyleBackColor = true;
            this.btnSetRoleCA.Click += new System.EventHandler(this.btnSetRoleCA_Click);
            // 
            // btnSetRoleE
            // 
            this.btnSetRoleE.Location = new System.Drawing.Point(149, 163);
            this.btnSetRoleE.Name = "btnSetRoleE";
            this.btnSetRoleE.Size = new System.Drawing.Size(34, 23);
            this.btnSetRoleE.TabIndex = 2;
            this.btnSetRoleE.Text = "E";
            this.btnSetRoleE.UseVisualStyleBackColor = true;
            this.btnSetRoleE.Click += new System.EventHandler(this.btnSetRoleE_Click);
            // 
            // btnSetRoleAR
            // 
            this.btnSetRoleAR.Location = new System.Drawing.Point(149, 131);
            this.btnSetRoleAR.Name = "btnSetRoleAR";
            this.btnSetRoleAR.Size = new System.Drawing.Size(34, 23);
            this.btnSetRoleAR.TabIndex = 2;
            this.btnSetRoleAR.Text = "AR";
            this.btnSetRoleAR.UseVisualStyleBackColor = true;
            this.btnSetRoleAR.Click += new System.EventHandler(this.btnSetRoleAR_Click);
            // 
            // btnSetRoleC
            // 
            this.btnSetRoleC.Location = new System.Drawing.Point(149, 99);
            this.btnSetRoleC.Name = "btnSetRoleC";
            this.btnSetRoleC.Size = new System.Drawing.Size(34, 23);
            this.btnSetRoleC.TabIndex = 2;
            this.btnSetRoleC.Text = "C";
            this.btnSetRoleC.UseVisualStyleBackColor = true;
            this.btnSetRoleC.Click += new System.EventHandler(this.btnSetRoleC_Click);
            // 
            // btnSetRoleA
            // 
            this.btnSetRoleA.Location = new System.Drawing.Point(149, 67);
            this.btnSetRoleA.Name = "btnSetRoleA";
            this.btnSetRoleA.Size = new System.Drawing.Size(34, 23);
            this.btnSetRoleA.TabIndex = 2;
            this.btnSetRoleA.Text = "A";
            this.btnSetRoleA.UseVisualStyleBackColor = true;
            this.btnSetRoleA.Click += new System.EventHandler(this.btnSetRoleA_Click);
            // 
            // btnSetRoleU
            // 
            this.btnSetRoleU.Location = new System.Drawing.Point(149, 35);
            this.btnSetRoleU.Name = "btnSetRoleU";
            this.btnSetRoleU.Size = new System.Drawing.Size(34, 23);
            this.btnSetRoleU.TabIndex = 2;
            this.btnSetRoleU.Text = "U";
            this.btnSetRoleU.UseVisualStyleBackColor = true;
            this.btnSetRoleU.Click += new System.EventHandler(this.btnSetRoleU_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 99);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "C";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 131);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "AR";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 163);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "E";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 195);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "CA";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 227);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "ERR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Роль";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(77, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Кількість";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(149, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Встановити";
            // 
            // tbCntU
            // 
            this.tbCntU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCntU.Location = new System.Drawing.Point(77, 35);
            this.tbCntU.Name = "tbCntU";
            this.tbCntU.ReadOnly = true;
            this.tbCntU.Size = new System.Drawing.Size(66, 20);
            this.tbCntU.TabIndex = 4;
            // 
            // tbCntA
            // 
            this.tbCntA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCntA.Location = new System.Drawing.Point(77, 67);
            this.tbCntA.Name = "tbCntA";
            this.tbCntA.ReadOnly = true;
            this.tbCntA.Size = new System.Drawing.Size(66, 20);
            this.tbCntA.TabIndex = 4;
            // 
            // tbCntC
            // 
            this.tbCntC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCntC.Location = new System.Drawing.Point(77, 99);
            this.tbCntC.Name = "tbCntC";
            this.tbCntC.ReadOnly = true;
            this.tbCntC.Size = new System.Drawing.Size(66, 20);
            this.tbCntC.TabIndex = 4;
            // 
            // tbCntAR
            // 
            this.tbCntAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCntAR.Location = new System.Drawing.Point(77, 131);
            this.tbCntAR.Name = "tbCntAR";
            this.tbCntAR.ReadOnly = true;
            this.tbCntAR.Size = new System.Drawing.Size(66, 20);
            this.tbCntAR.TabIndex = 4;
            // 
            // tbCntE
            // 
            this.tbCntE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCntE.Location = new System.Drawing.Point(77, 163);
            this.tbCntE.Name = "tbCntE";
            this.tbCntE.ReadOnly = true;
            this.tbCntE.Size = new System.Drawing.Size(66, 20);
            this.tbCntE.TabIndex = 4;
            // 
            // tbCntCA
            // 
            this.tbCntCA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCntCA.Location = new System.Drawing.Point(77, 195);
            this.tbCntCA.Name = "tbCntCA";
            this.tbCntCA.ReadOnly = true;
            this.tbCntCA.Size = new System.Drawing.Size(66, 20);
            this.tbCntCA.TabIndex = 4;
            // 
            // tbCntERR
            // 
            this.tbCntERR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCntERR.Location = new System.Drawing.Point(77, 227);
            this.tbCntERR.Name = "tbCntERR";
            this.tbCntERR.ReadOnly = true;
            this.tbCntERR.Size = new System.Drawing.Size(66, 20);
            this.tbCntERR.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(879, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Скорочення для творчої ролі: U - невіома, A  - автор тексту, C - композитор, AR -" +
    " аранжувальник, E - видавець, CA - композитор/автор тексту, ERR - не відповідає " +
    "вимогам\r\n";
            // 
            // ilStatuses
            // 
            this.ilStatuses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStatuses.ImageStream")));
            this.ilStatuses.TransparentColor = System.Drawing.Color.Transparent;
            this.ilStatuses.Images.SetKeyName(0, "Success-16.png");
            this.ilStatuses.Images.SetKeyName(1, "Warning-16.png");
            this.ilStatuses.Images.SetKeyName(2, "Error-16.png");
            this.ilStatuses.Images.SetKeyName(3, "Refresh-16.png");
            // 
            // FormRightHolderRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 536);
            this.Controls.Add(this.panelMain);
            this.Name = "FormRightHolderRoles";
            this.Text = "Ролі правовласників";
            this.Load += new System.EventHandler(this.FormRightHolderRoles_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.panelChangeType.ResumeLayout(false);
            this.panelNewType.ResumeLayout(false);
            this.panelNewType.PerformLayout();
            this.panelRoles.ResumeLayout(false);
            this.panelRoles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.TableLayoutPanel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateInfoInDb;
        private System.Windows.Forms.ListView lvRightHolders;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbFilterAll;
        private System.Windows.Forms.RadioButton rbFilterAuthors;
        private System.Windows.Forms.RadioButton rbFilterPublishers;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFilterNameText;
        private System.Windows.Forms.Button btnSetRightHolderType;
        private System.Windows.Forms.Button btnSetRoleA;
        private System.Windows.Forms.Button btnSetRoleC;
        private System.Windows.Forms.Button btnSetRoleAR;
        private System.Windows.Forms.Button btnSetRoleE;
        private System.Windows.Forms.Button btnSetRoleCA;
        private System.Windows.Forms.Button btnSetRoleU;
        private System.Windows.Forms.ImageList ilStatuses;
        private System.Windows.Forms.TableLayoutPanel panelMiddle;
        private System.Windows.Forms.TableLayoutPanel panelChangeType;
        private System.Windows.Forms.FlowLayoutPanel panelNewType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel panelRoles;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCntU;
        private System.Windows.Forms.TextBox tbCntA;
        private System.Windows.Forms.TextBox tbCntC;
        private System.Windows.Forms.TextBox tbCntAR;
        private System.Windows.Forms.TextBox tbCntE;
        private System.Windows.Forms.TextBox tbCntCA;
        private System.Windows.Forms.TextBox tbCntERR;
    }
}