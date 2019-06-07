using System;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightBrView : Telerik.WinControls.UI.RadForm
    {
        private ObjectRightBrPresenter _presenter;
        public ObjectRightBrPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        public object ObjectRightDataSource
        {
            get => ctrlObjectRightInfo.ObjectRightDataSource;
            set => ctrlObjectRightInfo.ObjectRightDataSource = value;
        }

        public object LicenseBigRDataSource
        {
            get => ctrlObjectRightInfo.LicenseBigRDataSource;
            set => ctrlObjectRightInfo.LicenseBigRDataSource = value;
        }

        public object AuthorRightholderListDataSource
        {
            get => ctrlAuthorRightholderList.DataSource;
            set => ctrlAuthorRightholderList.DataSource = value;
        }

        public ObjectRightBrView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }

        public void SetHeader(string header)
        {
            Text = header + " - Об'єкт права";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void ObjectRightBrView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Close();
            e.Cancel = true;
        }
    }
}
