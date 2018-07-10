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
        public RightholderMainView SelectedRightholder
        {
            get => ctrlRightholderList.SelectedRightholder;
            set => ctrlRightholderList.SelectedRightholder = value;
        }

        public event EventHandler<RightholderMainView> RightholderSelected;

        public RightholderSelectionView()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
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

        private void ctrlRightholderList_RightholderSelected(object sender, RightholderMainView selectedRightholder)
        {
            SelectAndClose();
        }

        private void OnRightholderSelected(RightholderMainView item)
        {
            RightholderSelected?.Invoke(this, item);
        }

        private void SelectAndClose()
        {
            var item = ctrlRightholderList.SelectedRightholder;

            if (item != null)
            {
                OnRightholderSelected(item);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
                DialogResult = DialogResult.None;
        }
    }
}
