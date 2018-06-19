using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
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
        public event EventHandler ShowAnketaCommandExecuted;

        public RightholderSelectorControl()
        {
            InitializeComponent();
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
            ShowAnketaCommandExecuted?.Invoke(sender, EventArgs.Empty);
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

        private void OnRightholderChandged()
        {
            RightholderChanged?.Invoke(this, _rightholder);
        }
    }
}
