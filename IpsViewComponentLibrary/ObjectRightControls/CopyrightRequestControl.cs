using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class CopyrightRequestControl : UserControl
    {
        private CopyrightRequestPresenter _presenter;
        public CopyrightRequestPresenter Presenter
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

        public CopyrightRequestControl()
        {
            InitializeComponent();
        }

        private void CopyrightRequestControl_Click(object sender, EventArgs e)
        {
            _presenter.Do();
        }
    }
}
