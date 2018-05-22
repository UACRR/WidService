namespace IpsViewComponentLibrary
{
    partial class IpsExclusionsLimitationsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvExlusionsLimitations = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvExlusionsLimitations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExlusionsLimitations.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // gvExlusionsLimitations
            // 
            this.gvExlusionsLimitations.BackColor = System.Drawing.SystemColors.Control;
            this.gvExlusionsLimitations.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvExlusionsLimitations.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gvExlusionsLimitations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gvExlusionsLimitations.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvExlusionsLimitations.Location = new System.Drawing.Point(28, 30);
            // 
            // 
            // 
            this.gvExlusionsLimitations.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "column1";
            gridViewTextBoxColumn1.MinWidth = 100;
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 300;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "column2";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column2";
            gridViewCheckBoxColumn1.Width = 66;
            this.gvExlusionsLimitations.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1});
            this.gvExlusionsLimitations.MasterTemplate.ShowColumnHeaders = false;
            this.gvExlusionsLimitations.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvExlusionsLimitations.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvExlusionsLimitations.Name = "gvExlusionsLimitations";
            this.gvExlusionsLimitations.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvExlusionsLimitations.Size = new System.Drawing.Size(509, 414);
            this.gvExlusionsLimitations.TabIndex = 0;
            // 
            // IpsExclusionsLimitationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvExlusionsLimitations);
            this.Name = "IpsExclusionsLimitationsControl";
            this.Size = new System.Drawing.Size(563, 469);
            ((System.ComponentModel.ISupportInitialize)(this.gvExlusionsLimitations.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExlusionsLimitations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvExlusionsLimitations;
    }
}
