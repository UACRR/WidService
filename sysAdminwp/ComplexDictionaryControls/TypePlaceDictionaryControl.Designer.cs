namespace sysAdminwp.ComplexDictionaryControls
{
    partial class TypePlaceDictionaryControl
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
            this.components = new System.ComponentModel.Container();
            this.lbTypePlace = new System.Windows.Forms.Label();
            this.ddlTypePlace = new Telerik.WinControls.UI.RadDropDownList();
            this.bsTypePlace = new System.Windows.Forms.BindingSource(this.components);
            this.bsTypePlaceList = new System.Windows.Forms.BindingSource(this.components);
            this.bsTypePlaceParam = new System.Windows.Forms.BindingSource(this.components);
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlaceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlaceParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTypePlace
            // 
            this.lbTypePlace.AutoSize = true;
            this.lbTypePlace.Location = new System.Drawing.Point(7, 5);
            this.lbTypePlace.Name = "lbTypePlace";
            this.lbTypePlace.Size = new System.Drawing.Size(44, 13);
            this.lbTypePlace.TabIndex = 0;
            this.lbTypePlace.Text = "Обьект";
            // 
            // ddlTypePlace
            // 
            this.ddlTypePlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlTypePlace.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTypePlace, "ParamType", true));
            this.ddlTypePlace.DataSource = this.bsTypePlaceList;
            this.ddlTypePlace.DisplayMember = "Name";
            this.ddlTypePlace.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlTypePlace.FormattingEnabled = false;
            this.ddlTypePlace.Location = new System.Drawing.Point(57, 3);
            this.ddlTypePlace.Name = "ddlTypePlace";
            this.ddlTypePlace.Size = new System.Drawing.Size(448, 21);
            this.ddlTypePlace.TabIndex = 1;
            this.ddlTypePlace.ThemeName = "Office2013Light";
            this.ddlTypePlace.ValueMember = "CodeI";
            this.ddlTypePlace.Click += new System.EventHandler(this.ddlTypePlace_Click);
            // 
            // bsTypePlace
            // 
            this.bsTypePlace.DataSource = typeof(ipsFormsDesign.Model.TypePlace);
            // 
            // bsTypePlaceList
            // 
            this.bsTypePlaceList.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // bsTypePlaceParam
            // 
            this.bsTypePlaceParam.DataSource = typeof(ipsFormsDesign.Dictionary.DictBaseTypeI);
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Location = new System.Drawing.Point(10, 30);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(212, 19);
            this.radCheckBox1.TabIndex = 4;
            this.radCheckBox1.Text = "Вказувати данні про приміщення";
            this.radCheckBox1.ThemeName = "Office2013Light";
            this.radCheckBox1.Click += new System.EventHandler(this.radCheckBox1_Click);
            // 
            // TypePlaceDictionaryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radCheckBox1);
            this.Controls.Add(this.ddlTypePlace);
            this.Controls.Add(this.lbTypePlace);
            this.Name = "TypePlaceDictionaryControl";
            this.Size = new System.Drawing.Size(508, 53);
            ((System.ComponentModel.ISupportInitialize)(this.ddlTypePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlaceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTypePlaceParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTypePlace;
        private Telerik.WinControls.UI.RadDropDownList ddlTypePlace;
        private System.Windows.Forms.BindingSource bsTypePlace;
        private System.Windows.Forms.BindingSource bsTypePlaceList;
        private System.Windows.Forms.BindingSource bsTypePlaceParam;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
    }
}
