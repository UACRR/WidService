using System;
using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderSelectorControl : UserControl
    {
        private RightholderMainView _rightholder;
        public RightholderMainView Rightholder
        {
            get
            {
                return _rightholder;
            }
            set
            {
                if (_rightholder != value)
                {
                    _rightholder = value;
                    UpdateView();
                    OnRightholderChandged();
                }
            }
        }

        public event EventHandler<RightholderMainView> RightholderChanged;
        public event EventHandler<RightholderMainView> ShowAnketaCommandExecuted;

        public RightholderSelectorControl()
        {
            InitializeComponent();

            lblBirthDate.Text = "";
            lblProfit.Text = "";
        }

        private void ddlSelectedRightholder_PopupOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            using (var selectionView = new RightholderSelectionView())
            {
                selectionView.SelectedRightholder = _rightholder;
                selectionView.RightholderSelected += (s, selectedRightholder) =>
                {
                    Rightholder = selectedRightholder;
                };
                selectionView.ShowDialog();
            }
        }

        private void btnAnketa_Click(object sender, EventArgs e)
        {
            OnShowAnketaCommandExecuted(_rightholder);
        }

        private void UpdateView()
        {
            if (_rightholder != null)
            {
                ddlSelectedRightholder.Text = _rightholder.Name;
                lblBirthDate.Text = _rightholder.RegistrDate.ToShortDateString();
                lblProfit.Text = _rightholder.YearProfit.ToString("N2");
            }
            else
            {
                ddlSelectedRightholder.Text = "";
                lblBirthDate.Text = "";
                lblProfit.Text = "";
            }
        }

        protected void OnRightholderChandged()
        {
            RightholderChanged?.Invoke(this, _rightholder);
        }

        protected void OnShowAnketaCommandExecuted(RightholderMainView selectedRightholder)
        {
            if (selectedRightholder != null)
                ShowAnketaCommandExecuted?.Invoke(this, selectedRightholder);
        }
    }
}
