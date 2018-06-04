namespace RightholderWorkplaceSeparateForm.Rightholder
{
    partial class RightholderListView
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.commandPanel = new Telerik.WinControls.UI.RadPanel();
            this.ddbAddRightholder = new Telerik.WinControls.UI.RadDropDownButton();
            this.gvRightholdersList = new Telerik.WinControls.UI.RadGridView();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadDropDownMenu();
            this.miAddRightholderPerson = new Telerik.WinControls.UI.RadMenuItem();
            this.miAddRightholderCompany = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.commandPanel)).BeginInit();
            this.commandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddbAddRightholder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenuItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.ddbAddRightholder);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandPanel.Location = new System.Drawing.Point(0, 497);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(908, 33);
            this.commandPanel.TabIndex = 1;
            // 
            // ddbAddRightholder
            // 
            this.ddbAddRightholder.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.miAddRightholderPerson,
            this.miAddRightholderCompany});
            this.ddbAddRightholder.Location = new System.Drawing.Point(12, 5);
            this.ddbAddRightholder.Name = "ddbAddRightholder";
            this.ddbAddRightholder.Size = new System.Drawing.Size(140, 24);
            this.ddbAddRightholder.TabIndex = 0;
            this.ddbAddRightholder.Text = "Додати";
            // 
            // gvRightholdersList
            // 
            this.gvRightholdersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRightholdersList.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvRightholdersList.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvRightholdersList.Name = "gvRightholdersList";
            this.gvRightholdersList.Size = new System.Drawing.Size(908, 491);
            this.gvRightholdersList.TabIndex = 2;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.AnimationEnabled = true;
            this.radMenuItem1.AnimationFrames = 1;
            this.radMenuItem1.AnimationType = Telerik.WinControls.UI.PopupAnimationTypes.Fade;
            this.radMenuItem1.DropDownAnimationDirection = Telerik.WinControls.UI.RadDirection.Down;
            this.radMenuItem1.DropShadow = true;
            this.radMenuItem1.EasingType = Telerik.WinControls.RadEasingType.InQuad;
            this.radMenuItem1.EnableAeroEffects = false;
            this.radMenuItem1.FadeAnimationFrames = 10;
            this.radMenuItem1.FadeAnimationSpeed = 10;
            this.radMenuItem1.FadeAnimationType = Telerik.WinControls.UI.FadeAnimationType.FadeIn;
            this.radMenuItem1.FitToScreenMode = ((Telerik.WinControls.UI.FitToScreenModes)((Telerik.WinControls.UI.FitToScreenModes.FitWidth | Telerik.WinControls.UI.FitToScreenModes.FitHeight)));
            this.radMenuItem1.HorizontalAlignmentCorrectionMode = Telerik.WinControls.UI.AlignmentCorrectionMode.SnapToOuterEdges;
            this.radMenuItem1.LastShowDpiScaleFactor = new System.Drawing.SizeF(1F, 1F);
            this.radMenuItem1.Location = new System.Drawing.Point(0, 0);
            this.radMenuItem1.Maximum = new System.Drawing.Size(0, 0);
            this.radMenuItem1.Minimum = new System.Drawing.Size(0, 0);
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Opacity = 1F;
            this.radMenuItem1.ProcessKeyboard = false;
            this.radMenuItem1.RollOverItemSelection = true;
            this.radMenuItem1.Size = new System.Drawing.Size(0, 0);
            this.radMenuItem1.TabIndex = 0;
            this.radMenuItem1.VerticalAlignmentCorrectionMode = Telerik.WinControls.UI.AlignmentCorrectionMode.SnapToOuterEdges;
            this.radMenuItem1.Visible = false;
            // 
            // miAddRightholderPerson
            // 
            this.miAddRightholderPerson.Name = "miAddRightholderPerson";
            this.miAddRightholderPerson.Text = "Фізична особа";
            this.miAddRightholderPerson.Click += new System.EventHandler(this.miAddRightholderPerson_Click);
            // 
            // miAddRightholderCompany
            // 
            this.miAddRightholderCompany.Name = "miAddRightholderCompany";
            this.miAddRightholderCompany.Text = "Юридична особа";
            // 
            // RightholderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 530);
            this.Controls.Add(this.gvRightholdersList);
            this.Controls.Add(this.commandPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RightholderListView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RightholderListView";
            ((System.ComponentModel.ISupportInitialize)(this.commandPanel)).EndInit();
            this.commandPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddbAddRightholder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRightholdersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenuItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel commandPanel;
        private Telerik.WinControls.UI.RadDropDownButton ddbAddRightholder;
        private Telerik.WinControls.UI.RadGridView gvRightholdersList;
        private Telerik.WinControls.UI.RadDropDownMenu radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem miAddRightholderPerson;
        private Telerik.WinControls.UI.RadMenuItem miAddRightholderCompany;
    }
}
