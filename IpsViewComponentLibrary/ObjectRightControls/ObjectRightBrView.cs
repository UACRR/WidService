using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

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
    }
}
