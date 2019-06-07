using IpsViewComponentLibrary.Common;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.Utilities
{
    public class DialogService
    {
        public void ShowMessage(string message)
        {
            ShowMessage(null, message, null);
        }

        public void ShowMessage(string message, string details)
        {
            ShowMessage(null, message, details);
        }

        public void ShowMessage(IWin32Window parent, string message)
        {
            ShowMessage(parent, message, null);
        }

        public void ShowMessage(IWin32Window parent, string message, string details)
        {
            RadMessageBox.Show(parent, message, "Інформація", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1, RightToLeft.Inherit, details);
        }


        public void ShowError(string message)
        {
            ShowError(null, message, null);
        }

        public void ShowError(string message, string details)
        {
            ShowError(null, message, details);
        }

        public void ShowError(IWin32Window parent, string message)
        {
            ShowError(parent, message, null);
        }

        public void ShowError(IWin32Window parent, string message, string details)
        {
            RadMessageBox.Show(parent, message, "Помилка", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Inherit, details);
        }

        public bool ClosingIsConfirmed()
        {
            return ClosingIsConfirmed(null);
        }

        public bool ClosingIsConfirmed(IWin32Window parent)
        {
            return RadMessageBox.Show(parent, "Закрити без збереження?", "Питання", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes;
        }

        public void ShowErrorView(string header, string message)
        {
            var v = new ConfirmationView();
            v.Text = header;
            v.InformationText = message;
            v.ShowDialog();
        }

        public bool ShowConfirmationView(string header, string message)
        {
            var v = new ConfirmationView();
            v.Text = header;
            v.InformationText = message;
            v.ShowAcceptButton = true;
            return v.ShowDialog() == DialogResult.OK;
        }
    }
}
