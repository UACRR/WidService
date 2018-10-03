using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class ConsumerExternalView : Telerik.WinControls.UI.RadForm
    {
        private ConsumerExternalPresenter _presenter;
        public ConsumerExternalPresenter Presenter
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

        private AnketaExternal _anketa;
        public AnketaExternal Anketa
        {
            get { return _anketa; }
            set
            {
                _anketa = value;
                bsAnketaExternal.DataSource = _anketa;
            }
        }

        public ConsumerExternalView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _presenter.Close();
        }
    }
}
