using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityLimitsEditForm : RadForm
    {
        public CommunityLimitsEditForm(CommunityAuthorsView view, List<CustCmRight> custCmRights, int communityCustId)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            panelHeader.PanelElement.PanelBorder.BottomColor = Color.Transparent;

            bsHeaderCommunityAuthorsView.DataSource = view;
            ctrlRightLimitation.SetData(view, custCmRights, communityCustId);
        }

        public List<CustCmRight> LimitRights => ctrlRightLimitation.LimitRights;
    }
}
