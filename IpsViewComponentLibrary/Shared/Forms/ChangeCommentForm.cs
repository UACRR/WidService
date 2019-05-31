using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Shared.Forms
{
    public partial class ChangeCommentForm : RadForm
    {
        private const string Title = "Змінити коментар до файлу ";
        private readonly CatalogFile _catalogFile;

        public ChangeCommentForm(CatalogFile catalogFile)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _catalogFile = catalogFile;
            txtComment.Text = _catalogFile.Comment;

            Text = string.Concat(Title, _catalogFile.FileName);

            ctrlSaveCancel.SaveClck += CtrlSaveCancel_SaveClck;
        }

        private void CtrlSaveCancel_SaveClck(object sender, System.EventArgs e)
        {
            _catalogFile.Comment = txtComment.Text;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
    }
}
