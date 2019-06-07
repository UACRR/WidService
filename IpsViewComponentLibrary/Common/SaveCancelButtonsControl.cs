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

        public DialogResult ButtonSaveDialogResult
        {
            get => btnSave.DialogResult;
            set => btnSave.DialogResult = value;
        }

        public bool SaveButtonEnabled
        {
            get => btnSave.Enabled;
            set => btnSave.Enabled = value;
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
