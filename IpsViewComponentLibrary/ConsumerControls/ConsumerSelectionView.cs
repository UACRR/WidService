using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using System;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ConsumerSelectionView : Telerik.WinControls.UI.RadForm
    {
        public ConsumerSmallRightView SelectedConsumer
        {
            get => ctrlConsumerList.SelectedConsumer;
            set => ctrlConsumerList.SelectedConsumer = value;
        }

        public event EventHandler<ConsumerSmallRightView> ConsumerSelected;

        public ConsumerSelectionView()
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

        private void ctrlConsumerList_ConsumerSelected(object sender, RightholderMainView selectedRightholder)
        {
            SelectAndClose();
        }

        private void ctrlConsumerList_ConsumerSelected(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            SelectAndClose();
        }

        protected void OnConsumerSelected(ConsumerSmallRightView item)
        {
            ConsumerSelected?.Invoke(this, item);
        }

        private void SelectAndClose()
        {
            var item = ctrlConsumerList.SelectedConsumer;

            if (item != null)
            {
                OnConsumerSelected(item);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
                DialogResult = DialogResult.None;
        }
    }
}
