using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ObjectRightItemView : Telerik.WinControls.UI.RadForm, IObjectRightItemView
    {
        private ObjectRightItemPresenter _presenter;
        public ObjectRightItemPresenter Presenter
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

        public ObjectRightItemView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }
    }
}
