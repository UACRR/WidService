using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using System;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderSelectionView : Telerik.WinControls.UI.RadForm
    {
        public RightholderMainView SelectedRightholder
        {
            get => ctrlRightholderList.SelectedRightholder;
            set => ctrlRightholderList.SelectedRightholder = value;
        }

        public string SearchText
        {
            get => ctrlRightholderList.SearchText;
            set => ctrlRightholderList.SearchText = value;
        }

        public event EventHandler<RightholderMainView> RightholderSelected;
        public event EventHandler SelectionCanceled;

        public RightholderSelectionView()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;
        }

        public void SetAllowedStatuses(RightholderStatusType[] statuses)
        {
            ctrlRightholderList.SetAllowedStatuses(statuses);
        }

        public void ClearAllowedStatuses()
        {
            ctrlRightholderList.ClearAllowedStatuses();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            OnSelectionCanceled();
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

        protected void OnRightholderSelected(RightholderMainView item)
        {
            RightholderSelected?.Invoke(this, item);
        }

        protected void OnSelectionCanceled()
        {
            SelectionCanceled?.Invoke(this, EventArgs.Empty);
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
