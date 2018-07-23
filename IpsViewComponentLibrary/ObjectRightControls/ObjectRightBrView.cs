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
