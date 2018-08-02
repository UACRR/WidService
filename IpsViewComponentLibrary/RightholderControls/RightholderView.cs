using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderView : Telerik.WinControls.UI.RadForm
    {
        private RightholderPresenter _presenter;
        public RightholderPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        public RightholderView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }

        private void btnNewRightholderCancel1_Click(object sender, EventArgs e)
        {

        }

        private void btnNextAnketa_Click(object sender, EventArgs e)
        {

        }

        private void btnNextPassport_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevFullNameComission_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevAnketa_Click(object sender, EventArgs e)
        {

        }

        private void btnNextRoyalty_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevPassport_Click(object sender, EventArgs e)
        {

        }

        private void ddlTypeMethodGet_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNextExclusionLimitation_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevRoyalty_Click(object sender, EventArgs e)
        {

        }

        private void btnNextTerritoryLimitation_Click(object sender, EventArgs e)
        {

        }

        private void btnNextAgreement_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevRightLimitation_Click(object sender, EventArgs e)
        {

        }

        private void miSaveRightholder_Click(object sender, EventArgs e)
        {

        }

        private void miAcceptAndSaveRightholder_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevTerritoryLimitation_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateRightholderAgreement_Click(object sender, EventArgs e)
        {

        }
    }
}
