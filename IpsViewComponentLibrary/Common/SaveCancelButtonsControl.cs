using System;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.Common
{
    public partial class SaveCancelButtonsControl : UserControl
    {
        public event EventHandler SaveClck;
        public event EventHandler CancelClick;
        public SaveCancelButtonsControl()
        {
            InitializeComponent();
            btnSave.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClck?.Invoke(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke(sender, e);
        }
    }
}
