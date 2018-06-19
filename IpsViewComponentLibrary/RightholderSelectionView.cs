using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class RightholderSelectionView : Telerik.WinControls.UI.RadForm
    {
        private RightholderMainView _rightholder;
        public RightholderMainView SelectedRightholder
        {
            get
            {
                return gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;
            }
            set
            {
                if (_rightholder != value)
                {
                    _rightholder = value;

                    var row = gvRightholdersList.Rows.FirstOrDefault(r => (int)r.Cells["CustId"].Value == _rightholder.CustId);
                    if (row != null)
                    {
                        gvRightholdersList.CurrentRow = row;
                    }
                }
            }
        }

        public event EventHandler<RightholderMainView> RightholderSelected;

        public RightholderSelectionView()
        {
            InitializeComponent();

            var service = new RightholderService();
            var list = service.GetMainView();
            rightholderMainViewBindingSource.DataSource = list;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void gvRightholdersList_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void OnRightholderSelected(RightholderMainView item)
        {
            RightholderSelected?.Invoke(this, item);
        }

        private void SelectAndClose()
        {
            var item = gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;

            OnRightholderSelected(item);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
