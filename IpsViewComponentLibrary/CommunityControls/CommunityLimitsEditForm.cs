using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityLimitsEditForm : RadForm
    {
        private readonly CommunityRightLimitationControl ctrlRightLimitation;

        public List<CustCmRight> LimitRights => ctrlRightLimitation.LimitRights;
        public List<TermsOfService> TermsOfServiceLimitRights => ctrlRightLimitation.TermsOfServiceLimitRights;

        public CommunityLimitsEditForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            panelHeader.PanelElement.PanelBorder.Width = 0f;

            ctrlRightLimitation = new CommunityRightLimitationControl
            {
                Dock = DockStyle.Fill,
            };
            mainPanel.Controls.Add(ctrlRightLimitation);
            ctrlSaveCancel.ButtonSaveDialogResult = DialogResult.None;
            ctrlSaveCancel.SaveClck += CtrlSaveCancel_SaveClck;
            
        }

        private void CtrlSaveCancel_SaveClck(object sender, EventArgs e)
        {
            if (ctrlRightLimitation.CheckCanSaveRightLimitChanges())
            {
                ctrlRightLimitation.UpdateData();
                DialogResult = DialogResult.OK;
            }
        }

        public void SetData(CommunityAuthorsView view, List<CustCmRight> custCmRights, List<TermsOfService> termsOfServices, int communityCustId)
        {
            bsHeaderCommunityAuthorsView.DataSource = view;
            ctrlRightLimitation.SetData(view, custCmRights, termsOfServices, communityCustId);
        }
    }
}
